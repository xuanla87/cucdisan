namespace CucDiSanService.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Data.Repositories;
    using CucDiSanService.Models;
    public interface ILienketWebServices
    {
        LienKetWeb Add(LienKetWeb model);

        void Update(LienKetWeb model);

        LienKetWeb Delete(int id);

        IEnumerable<LienKetWeb> GetAll();

        LienKetWeb GetById(int id);

        LienKetWebView All(string searchKey, int? parentId, bool? isTrash, int? pageIndex, int? pageSize);

        void Save();
    }
    public class LienketWebServices : ILienketWebServices
    {
        private ILienKetWebRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public LienketWebServices(ILienKetWebRepository repository, IUnitOfWork unitOfWork)
        {
            this._Repository = repository;
            this._unitOfWork = unitOfWork;
        }

        public LienKetWeb Add(LienKetWeb model)
        {
            return _Repository.Add(model);
        }

        public LienKetWeb Delete(int id)
        {
            return _Repository.Delete(id);
        }

        public IEnumerable<LienKetWeb> GetAll()
        {
            return _Repository.GetAll().OrderByDescending(x => x.isSort);
        }

        public LienKetWeb GetById(int id)
        {
            return _Repository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(LienKetWeb model)
        {
            _Repository.Update(model);
        }
        public LienKetWebView All(string searchKey, int? parentId, bool? isTrash, int? pageIndex, int? pageSize)
        {
            var entitys = GetAll();
            if (isTrash.HasValue)
                entitys = entitys.Where(x => x.isTrash == isTrash);
            if (!string.IsNullOrEmpty(searchKey))
                entitys = entitys.Where(x => x.lienKetName.ToLower().Contains(searchKey.ToLower().Trim()));
            if (parentId.HasValue)
                entitys = entitys.Where(x => x.parentId == parentId);
            var totalRecord = entitys.Count();
            if (pageIndex != null && pageSize != null)
                entitys = entitys.Skip(((int)pageIndex - 1) * (int)pageSize);
            var totalPage = 0;
            if (pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / pageSize.Value);
                entitys = entitys.Take((int)pageSize);
            }
            var result = new LienKetWebView { Total = totalPage, LienKetWebs = entitys, TotalRecord = totalRecord };
            return result;
        }
    }
}

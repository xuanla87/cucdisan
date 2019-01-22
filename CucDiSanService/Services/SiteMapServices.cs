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

    public interface ISiteMapServices
    {
        SiteMap Add(SiteMap _model);

        void Update(SiteMap _model);

        SiteMap Delete(int _id);

        IEnumerable<SiteMap> GetAll();

        IEnumerable<SiteMap> GetByParent(int? _id);

        SiteMap GetById(int _id);

        void Save();
    }
    public class SiteMapServices : ISiteMapServices
    {
        private ISiteMapRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public SiteMapServices(ISiteMapRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;
        }

        public SiteMap Add(SiteMap _model)
        {
            return _Repository.Add(_model);
        }

        public SiteMap Delete(int _id)
        {
            return _Repository.Delete(_id);
        }

        public IEnumerable<SiteMap> GetAll()
        {
            return _Repository.GetAll();
        }

        public IEnumerable<SiteMap> GetByParent(int? _id)
        {
            return _Repository.GetByParent(_id);
        }

        public SiteMap GetById(int _id)
        {
            return _Repository.GetSingleById(_id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(SiteMap _model)
        {
            _Repository.Update(_model);
        }
    }
}

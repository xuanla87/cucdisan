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
    public interface IVideoServices
    {
        Video Add(Video model);

        void Update(Video model);

        Video Delete(int id);

        IEnumerable<Video> GetAll();

        Video GetById(int id);

        Video GetIsHome();

        VideoView All(string searchKey, int? parentId, DateTime? fromDate, bool? isTrash, DateTime? toDate, int? pageIndex, int? pageSize);

        void Save();
        IEnumerable<DropdownModel> Dropdownlist(int _id, int? _curentId);
    }
    public class VideoServices : IVideoServices
    {
        private IVideoRepository _videoRepository;
        private ICategoryVideoRepository _categoryRepository;
        private IUnitOfWork _unitOfWork;
        public VideoServices(ICategoryVideoRepository categoryRepository, IVideoRepository videoRepository, IUnitOfWork unitOfWork)
        {
            this._videoRepository = videoRepository;
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public Video Add(Video model)
        {
            return _videoRepository.Add(model);
        }

        public Video Delete(int id)
        {
            return _videoRepository.Delete(id);
        }

        public IEnumerable<Video> GetAll()
        {
            return _videoRepository.GetAll().OrderByDescending(x => x.updateTime);
        }

        public Video GetById(int id)
        {
            return _videoRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Video model)
        {
            _videoRepository.Update(model);
        }
        public Video GetIsHome()
        {
            var entity = GetAll();
            entity = entity.OrderByDescending(x => x.updateTime);
            return entity.FirstOrDefault();
        }
        public VideoView All(string searchKey, int? parentId, DateTime? fromDate, bool? isTrash, DateTime? toDate, int? pageIndex, int? pageSize)
        {
            var entitys = GetAll();
            if (isTrash.HasValue)
                entitys = entitys.Where(x => x.isTrash == isTrash);
            if (!string.IsNullOrEmpty(searchKey))
                entitys = entitys.Where(x => x.videoTitle.ToLower().Contains(searchKey.ToLower().Trim()));
            if (fromDate.HasValue)
                entitys = entitys.Where(x => x.createTime.Date >= fromDate.Value.Date);
            if (toDate.HasValue)
                entitys = entitys.Where(x => x.createTime.Date <= toDate.Value.Date);
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
            var result = new VideoView { Total = totalPage, Videos = entitys, TotalRecord = totalRecord };
            return result;
        }

        public IEnumerable<DropdownModel> Dropdownlist(int _id, int? _curentId)
        {
            try
            {
                var entitys = _categoryRepository.GetMulti(x => x.isTrash == false && x.categoryId != _id);
                if (_curentId.HasValue && _curentId > 0)
                    entitys = entitys.Where(x => x.categoryId != _curentId);
                var result = new List<DropdownModel>();
                foreach (var item in entitys)
                {
                    if (item.parentId == null || item.parentId == 0)
                    {
                        result.Add(new DropdownModel { Text = item.categoryName, Value = item.categoryId });
                        DropdownlistChild(result, entitys, item.categoryId, "-");
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return new List<DropdownModel>();
            }
        }

        private IEnumerable<DropdownModel> DropdownlistChild(List<DropdownModel> model, IEnumerable<CategoryVideo> entity, int _parentId, string st)
        {
            try
            {
                foreach (var item in entity)
                {
                    if (item.parentId == _parentId)
                    {
                        model.Add(new DropdownModel { Text = st + item.categoryName, Value = item.categoryId });
                        DropdownlistChild(model, entity, item.categoryId, st + st);
                    }
                }
                return model;
            }
            catch (Exception)
            {
                return model;
            }
        }
    }

    public interface ICategoryVideoServices
    {
        CategoryVideo Add(CategoryVideo model);

        void Update(CategoryVideo model);

        CategoryVideo Delete(int id);

        IEnumerable<CategoryVideo> GetAll();

        CategoryVideo GetById(int id);

        void Save();
    }
    public class CategoryVideoServices : ICategoryVideoServices
    {
        private ICategoryVideoRepository _categoryVideoRepository;
        private IUnitOfWork _unitOfWork;
        public CategoryVideoServices(ICategoryVideoRepository categoryVideoRepository, IUnitOfWork unitOfWork)
        {
            this._categoryVideoRepository = categoryVideoRepository;
            this._unitOfWork = unitOfWork;
        }

        public CategoryVideo Add(CategoryVideo model)
        {
            return _categoryVideoRepository.Add(model);
        }

        public CategoryVideo Delete(int id)
        {
            return _categoryVideoRepository.Delete(id);
        }

        public IEnumerable<CategoryVideo> GetAll()
        {
            return _categoryVideoRepository.GetAll().OrderBy(x => x.parentId);
        }

        public CategoryVideo GetById(int id)
        {
            return _categoryVideoRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CategoryVideo model)
        {
            _categoryVideoRepository.Update(model);
        }
    }
}

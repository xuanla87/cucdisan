﻿namespace CucDiSanService.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CucDiSanService.Data.Infrastructure;
    using CucDiSanService.Data.Repositories;
    using CucDiSanService.Models;

    public interface IMenuServices
    {
        Menu Add(Menu _model);

        void Update(Menu _model);

        Menu Delete(int _id);

        IEnumerable<Menu> All();

        MenuView GetAll(string _keyWords, int? _parentId, int? _languageId, bool? _isTrash, int? _pageIndex, int? _pageSize);

        IEnumerable<DropdownModel> Dropdownlist(int _id, int? _curentId, int _languageId);

        IEnumerable<Menu> GetByParent(int? _id);

        Menu GetById(int _id);

        string GetNameById(int? _id);

        void Save();
    }
    public class MenuServices : IMenuServices
    {
        private IMenuRepository _Repository;
        private IUnitOfWork _unitOfWork;
        public MenuServices(IMenuRepository Repository, IUnitOfWork unitOfWork)
        {
            this._Repository = Repository;
            this._unitOfWork = unitOfWork;
        }

        public Menu Add(Menu _model)
        {
            return _Repository.Add(_model);
        }

        public Menu Delete(int _id)
        {
            return _Repository.Delete(_id);
        }

        public MenuView GetAll(string _keyWords, int? _parentId, int? _languageId, bool? _isTrash, int? _pageIndex, int? _pageSize)
        {
            var entitys = _Repository.GetAll();
            if (!string.IsNullOrEmpty(_keyWords))
            {
                entitys = entitys.Where(x => x.menuName.ToLower().Contains(_keyWords.ToLower().Trim()) || x.menuUrl.Contains(_keyWords.ToLower().Trim()));
            }
            if (_isTrash.HasValue)
            {
                entitys = entitys.Where(x => x.isTrash == _isTrash);
            }
            if (_parentId.HasValue)
            {
                entitys = entitys.Where(x => x.parentId == _parentId);
            }
            if (_languageId.HasValue)
            {
                entitys = entitys.Where(x => x.languageId == _languageId.Value);
            }
            entitys = entitys.OrderBy(x => x.isSort);
            int totalRecord = entitys.Count();
            if (_pageIndex != null && _pageSize != null)
            {
                entitys = entitys.Skip((_pageIndex.Value - 1) * _pageSize.Value);
            }
            var totalPage = 0;
            if (_pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / _pageSize.Value);
                entitys = entitys.Take(_pageSize.Value);
            }
            return new MenuView { Menus = entitys, Total = totalPage };
        }

        public IEnumerable<Menu> All()
        {
            return _Repository.GetAll();
        }

        public IEnumerable<DropdownModel> Dropdownlist(int _id, int? _curentId, int _languageId)
        {
            try
            {
                var entitys = _Repository.GetMulti(x => x.isTrash == false && x.languageId == _languageId);
                if (_curentId.HasValue)
                    entitys = entitys.Where(x => x.menuId != _curentId && x.parentId != _curentId);
                var result = new List<DropdownModel>();
                foreach (var item in entitys)
                {
                    if (item.parentId == null || item.parentId == 0)
                    {
                        result.Add(new DropdownModel { Text = item.menuName, Value = item.menuId });
                        DropdownlistChild(result, entitys, item.menuId, "-");
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return new List<DropdownModel>();
            }
        }

        private IEnumerable<DropdownModel> DropdownlistChild(List<DropdownModel> model, IEnumerable<Menu> entity, int _parentId, string st)
        {
            try
            {
                foreach (var item in entity)
                {
                    if (item.parentId == _parentId)
                    {
                        model.Add(new DropdownModel { Text = st + item.menuName, Value = item.menuId });
                        DropdownlistChild(model, entity, item.menuId, st + st);
                    }
                }
                return model;
            }
            catch (Exception)
            {
                return model;
            }
        }

        public IEnumerable<Menu> GetByParent(int? _id)
        {
            return _Repository.GetByParent(_id);
        }

        public Menu GetById(int _id)
        {
            return _Repository.GetSingleById(_id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public string GetNameById(int? _id)
        {
            if (_id.HasValue && _id > 0)
            {
                var entity = _Repository.GetSingleById(_id.Value);
                if (entity != null && entity.menuName != null)
                    return entity.menuName;
                else return null;
            }
            else return null;
        }

        public void Update(Menu _model)
        {
            _Repository.Update(_model);
        }
    }
}

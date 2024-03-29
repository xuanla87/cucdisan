﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CucDiSanVN.Models
{
    public class ServiceCucDiSan
    {
        public Content Add(Content _model, HitCounterEntity _db)
        {
            var model = new Content();
            model = _model;
            _db.Contents.Add(model);
            _db.SaveChanges();
            return model;
        }

        public void Delete(int _id, HitCounterEntity _db)
        {
            var model = _db.Contents.Find(_id);
            if (model != null && model.contentId > 0)
            {

            }
        }
        public ContentView TraCuuVanBan(string _name, string _no, DateTime? _ngayBanHanh, int? _languageId, int? _pageIndex, int? _pageSize)
        {
            var enContent = _Repository.GetMulti(x => x.contentKey == "Document");
            if (!string.IsNullOrEmpty(_name))
                enContent = enContent.Where(x => x.contentName.ToLower().Contains(_name.ToLower().Trim()));
            if (!string.IsNullOrEmpty(_no))
                enContent = enContent.Where(x => x.no != null && x.no.ToLower().Contains(_no.ToLower().Trim()));
            if (_languageId.HasValue)
                enContent = enContent.Where(x => x.languageId == _languageId.Value);
            if (_ngayBanHanh.HasValue)
                enContent = enContent.Where(x => x.createTime.Date == _ngayBanHanh.Value.Date);
            enContent = enContent.Where(x => x.isTrash == false);
            enContent = enContent.OrderByDescending(x => x.ngayBanHanh);
            int totalRecord = enContent.Count();
            if (_pageIndex != null && _pageSize != null)
                enContent = enContent.Skip((_pageIndex.Value - 1) * _pageSize.Value);
            var totalPage = 0;
            if (_pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / _pageSize.Value);
                enContent = enContent.Take(_pageSize.Value);
            }
            return new ContentView { Contents = enContent, Total = totalPage, TotalRecord = totalRecord };
        }
        public ContentView GetAll(string _keyWords, DateTime? _fromDate, DateTime? _toDate, int? _parentId, string _contentKey, int? _languageId, bool? _isTrash, int? _pageIndex, int? _pageSize)
        {
            var enContent = _Repository.GetMulti(x => x.contentKey.ToLower() == _contentKey.ToLower().Trim());
            if (!string.IsNullOrEmpty(_keyWords))
            {
                enContent = enContent.Where(x => x.contentName.ToLower().Contains(_keyWords.ToLower().Trim()) || (x.tacGia != null && x.tacGia.ToLower().Contains(_keyWords.ToLower().Trim())));
            }
            if (_isTrash.HasValue)
            {
                enContent = enContent.Where(x => x.isTrash == _isTrash);
            }
            if (_parentId.HasValue)
            {
                enContent = enContent.Where(x => x.parentId == _parentId);
            }
            if (_fromDate.HasValue)
            {
                enContent = enContent.Where(x => x.updateTime.Date >= _fromDate.Value.Date);
            }
            if (_toDate.HasValue)
            {
                enContent = enContent.Where(x => x.updateTime.Date <= _toDate.Value.Date);
            }
            if (_languageId.HasValue)
            {
                enContent = enContent.Where(x => x.languageId == _languageId.Value);
            }
            enContent = enContent.OrderByDescending(x => x.updateTime);
            int totalRecord = enContent.Count();
            if (_pageIndex != null && _pageSize != null)
            {
                enContent = enContent.Skip((_pageIndex.Value - 1) * _pageSize.Value);
            }
            var totalPage = 0;
            if (_pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / _pageSize.Value);
                enContent = enContent.Take(_pageSize.Value);
            }
            return new ContentView { Contents = enContent, Total = totalPage, TotalRecord = totalRecord };
        }

        public ContentView GetAll2(string _keyWords, DateTime? _fromDate, DateTime? _toDate, int? _parentId, string _contentKey, int? _languageId, bool? _isTrash, bool? _approval, int? _pageIndex, int? _pageSize)
        {
            var enContent = _Repository.GetMulti(x => x.contentKey.ToLower() == _contentKey.ToLower().Trim() && x.approval == true && x.isTrash == false);
            if (!string.IsNullOrEmpty(_keyWords))
            {
                enContent = enContent.Where(x => x.contentName.ToLower().Contains(_keyWords.ToLower().Trim()) || (x.tacGia != null && x.tacGia.ToLower().Contains(_keyWords.ToLower().Trim())));
            }
            if (_parentId.HasValue)
            {
                enContent = enContent.Where(x => x.parentId == _parentId);
            }
            if (_fromDate.HasValue)
            {
                enContent = enContent.Where(x => x.updateTime.Date >= _fromDate.Value.Date);
            }
            if (_toDate.HasValue)
            {
                enContent = enContent.Where(x => x.updateTime.Date <= _toDate.Value.Date);
            }
            if (_languageId.HasValue)
            {
                enContent = enContent.Where(x => x.languageId == _languageId.Value);
            }
            enContent = enContent.OrderByDescending(x => x.updateTime);
            int totalRecord = enContent.Count();
            if (_pageIndex != null && _pageSize != null)
            {
                enContent = enContent.Skip((_pageIndex.Value - 1) * _pageSize.Value);
            }
            var totalPage = 0;
            if (_pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / _pageSize.Value);
                enContent = enContent.Take(_pageSize.Value);
            }
            return new ContentView { Contents = enContent, Total = totalPage, TotalRecord = totalRecord };
        }

        public ContentView GetAll3(int _parentId, int? _languageId, int? _pageIndex, int? _pageSize)
        {
            var enContent = _Repository.GetMulti(x => x.parentId == _parentId && x.approval == true && x.isTrash == false && x.languageId == _languageId.Value);
            enContent = enContent.OrderByDescending(x => x.updateTime);
            int totalRecord = enContent.Count();
            if (_pageIndex != null && _pageSize != null)
                enContent = enContent.Skip((_pageIndex.Value - 1) * _pageSize.Value);
            var totalPage = 0;
            if (_pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / _pageSize.Value);
                enContent = enContent.Take(_pageSize.Value);
            }
            return new ContentView { Contents = enContent, Total = totalPage, TotalRecord = totalRecord };
        }

        public ContentView GetVanBan(string _keyWords, DateTime? _fromDate, DateTime? _toDate, int? _parentId, string _contentKey, int? _languageId, bool? _isTrash, int? _pageIndex, int? _pageSize)
        {
            var enContent = _Repository.GetMulti(x => x.contentKey.ToLower() == _contentKey.ToLower().Trim());
            if (!string.IsNullOrEmpty(_keyWords))
            {
                enContent = enContent.Where(x => x.contentName.ToLower().Contains(_keyWords.ToLower().Trim()) || (x.tacGia != null && x.tacGia.ToLower().Contains(_keyWords.ToLower().Trim())));
            }
            if (_isTrash.HasValue)
            {
                enContent = enContent.Where(x => x.isTrash == _isTrash);
            }
            if (_parentId.HasValue)
            {
                enContent = enContent.Where(x => x.parentId == _parentId);
            }
            if (_fromDate.HasValue)
            {
                enContent = enContent.Where(x => x.updateTime.Date >= _fromDate.Value.Date);
            }
            if (_toDate.HasValue)
            {
                enContent = enContent.Where(x => x.updateTime.Date <= _toDate.Value.Date);
            }
            if (_languageId.HasValue)
            {
                enContent = enContent.Where(x => x.languageId == _languageId.Value);
            }
            enContent = enContent.OrderByDescending(x => x.ngayBanHanh);
            int totalRecord = enContent.Count();
            if (_pageIndex != null && _pageSize != null)
            {
                enContent = enContent.Skip((_pageIndex.Value - 1) * _pageSize.Value);
            }
            var totalPage = 0;
            if (_pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / _pageSize.Value);
                enContent = enContent.Take(_pageSize.Value);
            }
            return new ContentView { Contents = enContent, Total = totalPage, TotalRecord = totalRecord };
        }

        public ContentView GetThongBao(string _keyWords, DateTime? _fromDate, DateTime? _toDate, int? _parentId, int? _languageId, bool? _isTrash, int? _pageIndex, int? _pageSize)
        {
            var enContent = _Repository.GetMulti(x => x.contentKey == "News" && x.isNew == true);
            if (!string.IsNullOrEmpty(_keyWords))
            {
                enContent = enContent.Where(x => x.contentName.ToLower().Contains(_keyWords.ToLower().Trim()) || (x.tacGia != null && x.tacGia.ToLower().Contains(_keyWords.ToLower().Trim())));
            }
            if (_isTrash.HasValue)
            {
                enContent = enContent.Where(x => x.isTrash == _isTrash);
            }
            if (_parentId.HasValue)
            {
                enContent = enContent.Where(x => x.parentId == _parentId);
            }
            if (_fromDate.HasValue)
            {
                enContent = enContent.Where(x => x.updateTime.Date >= _fromDate.Value.Date);
            }
            if (_toDate.HasValue)
            {
                enContent = enContent.Where(x => x.updateTime.Date <= _toDate.Value.Date);
            }
            if (_languageId.HasValue)
            {
                enContent = enContent.Where(x => x.languageId == _languageId.Value);
            }
            enContent = enContent.OrderByDescending(x => x.updateTime);
            int totalRecord = enContent.Count();
            if (_pageIndex != null && _pageSize != null)
            {
                enContent = enContent.Skip((_pageIndex.Value - 1) * _pageSize.Value);
            }
            var totalPage = 0;
            if (_pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / _pageSize.Value);
                enContent = enContent.Take(_pageSize.Value);
            }
            return new ContentView { Contents = enContent, Total = totalPage, TotalRecord = totalRecord };
        }

        public IEnumerable<Content> All()
        {
            var enContent = _Repository.GetAll();
            return enContent;
        }
        public IEnumerable<Content> GetCategoryAdmin(int? _parentId, string _contentKey, int? _languageId, bool? _isTrash)
        {
            var enContent = _Repository.GetMulti(x => x.contentKey.ToLower() == _contentKey.ToLower().Trim());
            enContent = enContent.Where(x => x.parentId == _parentId);
            if (_languageId.HasValue)
            {
                enContent = enContent.Where(x => x.languageId == _languageId.Value);
            }
            if (_isTrash.HasValue)
            {
                enContent = enContent.Where(x => x.isTrash == _isTrash);
            }
            enContent = enContent.OrderBy(x => x.isSort);
            return enContent;
        }
        public IEnumerable<Content> GetOldById(int _id, int? _parentId, string _contentKey, int? _languageId, int? _pageSize)
        {
            var enContent = _Repository.GetMulti(x => x.contentKey.ToLower() == _contentKey.ToLower().Trim() && x.contentId < _id);
            if (_parentId.HasValue)
            {
                enContent = enContent.Where(x => x.parentId == _parentId);
            }
            if (_languageId.HasValue)
            {
                enContent = enContent.Where(x => x.languageId == _languageId.Value);
            }
            enContent = enContent.OrderByDescending(x => x.updateTime);
            int totalRecord = enContent.Count();
            var totalPage = 0;
            if (_pageSize != null)
            {
                totalPage = (int)Math.Ceiling(1.0 * totalRecord / _pageSize.Value);
                enContent = enContent.Take(_pageSize.Value);
            }
            return enContent;
        }
        public Content Trash(int _id)
        {
            var enContent = _Repository.GetSingleById(_id);
            if (enContent != null && enContent.isTrash == false)
                enContent.isTrash = true;
            _Repository.Update(enContent);
            Save();
            return enContent;
        }

        public Content UnTrash(int _id)
        {
            var enContent = _Repository.GetSingleById(_id);
            if (enContent != null && enContent.isTrash == true)
                enContent.isTrash = false;
            _Repository.Update(enContent);
            Save();
            return enContent;
        }

        public Content Approval(int _id)
        {
            var enContent = _Repository.GetSingleById(_id);
            if (enContent != null && enContent.approval != true)
                enContent.approval = true;
            _Repository.Update(enContent);
            Save();
            return enContent;
        }
        public Content UnApproval(int _id)
        {
            var enContent = _Repository.GetSingleById(_id);
            if (enContent != null && enContent.approval == true)
                enContent.approval = false;
            _Repository.Update(enContent);
            Save();
            return enContent;
        }
        public Content GetByAlias(string _alias)
        {
            if (!string.IsNullOrEmpty(_alias))
                return _Repository.GetByAlias(_alias);
            else
                return null;
        }

        public IEnumerable<Content> getSuKienQuaAnhIsHome(int _languageId)
        {
            var enContent = _Repository.GetMulti(x => x.contentKey == "csukienquaanh" && x.isTrash == false && x.isHome == true);
            return enContent;
        }

        public IEnumerable<Content> getCategoryIsHome(int _languageId)
        {
            var enContent = _Repository.GetMulti(x => x.languageId == _languageId && x.isTrash == false && x.isHome == true && (x.contentKey == "cthongtindisanvanhoa" || x.contentKey == "cnews" || x.contentKey == "cdisanvanhoa" || x.contentKey == "canphamtailieu" || x.contentKey == "cduthaovanbanphapluat" || x.contentKey == "cthutuchanhchinh" || x.contentKey == "cvanbanphapluat"));
            return enContent;
        }

        public IEnumerable<Content> getContentInCategoryIsHome(int _id, int _total)
        {
            var eCurent = GetById(_id);
            if (eCurent != null)
            {
                var _list = ListChild(_id);
                List<Content> _listContent = new List<Content>();
                foreach (var item in _list)
                {
                    var enContent = _Repository.GetMulti(x => x.parentId == item && x.isTrash == false && (x.contentKey == "News" || x.contentKey == "AnPhamTaiLieu" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "Thongtindisanvanhoa" || x.contentKey == "TTHC" || x.contentKey == "Document") && x.isHome == true && x.approval == true);
                    enContent = enContent.OrderByDescending(x => x.updateTime);
                    var _entity = enContent.ToList();
                    if (_entity.Count > 0)
                        _listContent.AddRange(_entity);
                }

                if (_total > 0)
                {
                    _listContent = _listContent.Take(_total).ToList();
                }
                return _listContent;
            }
            else
                return null;
        }
        private List<int> _Child(int _id, List<int> _list)
        {
            var eCurent = GetById(_id);
            if (eCurent != null)
            {
                var enContent = _Repository.GetMulti(x => x.parentId == _id && x.contentKey == eCurent.contentKey && x.isTrash == false && x.approval == true).ToList();
                if (enContent.Count > 0)
                {
                    foreach (var item in enContent)
                    {
                        if (!_list.Contains(item.contentId))
                        {
                            _list.AddRange(_Child(item.contentId, _list));
                        }
                    }
                }
                else if (!_list.Contains(_id))
                {
                    _list.Add(_id);
                }
            }
            return _list;
        }
        private List<int> ListChild(int _id)
        {
            List<int> _list = new List<int>();
            List<int> _list2 = new List<int>();
            var eCurent = GetById(_id);
            if (eCurent != null)
            {
                var enContent = _Repository.GetMulti(x => x.contentKey == eCurent.contentKey && x.parentId == _id && x.isTrash == false && x.approval == true).ToList();
                if (enContent.Count > 0)
                {
                    foreach (var item in enContent)
                    {
                        if (!_list.Contains(item.contentId))
                        {
                            _list.AddRange(_Child(item.contentId, _list));
                        }
                    }
                }
                else if (!_list.Contains(_id))
                {
                    _list.Add(_id);
                }

            }
            foreach (var item in _list)
            {
                if (!_list2.Contains(item))
                {
                    _list2.Add(item);
                }
            }
            if (!_list2.Contains(_id))
            {
                _list2.Add(_id);
            }
            return _list2;
        }
        public Content GetById(int _id)
        {
            return _Repository.GetSingleById(_id);
        }


        public string GetNameById(int? _id)
        {
            if (_id.HasValue)
            {
                var entity = _Repository.GetSingleById(_id.Value);
                if (entity != null && entity.contentName != null)
                    return entity.contentName;
                else return null;
            }
            else return null;
        }

        public IEnumerable<DropdownModel> Dropdownlist(int _id, int? _curentId, string _key, int _languageId)
        {
            try
            {
                var entitys = _Repository.GetMulti(x => x.isTrash == false && x.contentKey == _key && x.languageId == _languageId);
                if (_curentId.HasValue && _curentId > 0)
                    entitys = entitys.Where(x => x.contentId != _curentId && x.parentId != _curentId);
                var result = new List<DropdownModel>();
                foreach (var item in entitys)
                {
                    if (item.parentId == null || item.parentId == 0)
                    {
                        result.Add(new DropdownModel { Text = item.contentName, Value = item.contentId });
                        DropdownlistChild(result, entitys, item.contentId, "-");
                    }
                }
                return result;
            }
            catch (Exception)
            {
                return new List<DropdownModel>();
            }
        }

        private IEnumerable<DropdownModel> DropdownlistChild(List<DropdownModel> model, IEnumerable<Content> entity, int _parentId, string st)
        {
            try
            {
                foreach (var item in entity)
                {
                    if (item.parentId == _parentId)
                    {
                        model.Add(new DropdownModel { Text = st + item.contentName, Value = item.contentId });
                        DropdownlistChild(model, entity, item.contentId, st + st);
                    }
                }
                return model;
            }
            catch (Exception)
            {
                return model;
            }
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Content _model)
        {
            _Repository.Update(_model);
        }
    }
}
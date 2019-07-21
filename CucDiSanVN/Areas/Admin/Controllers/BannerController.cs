using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CucDiSanService;
using CucDiSanVN.Areas.Admin.Models;
using CucDiSanService.Data.Infrastructure;
using CucDiSanService.Data.Repositories;
using CucDiSanService.Services;
using CucDiSanService.Models;
using System.Globalization;

namespace CucDiSanVN.Areas.Admin.Controllers
{
    public class BannerController : Controller
    {
        IContentServices _services;
        ILanguageServices _languageService;
        IActionLogServices _serviceLog;
        int _languageId = 1;
        public BannerController(IContentServices services, ILanguageServices languageService, IActionLogServices serviceLog)
        {
            this._services = services;
            this._languageService = languageService;
            this._serviceLog = serviceLog;
        }

        public ActionResult Index(string _searchKey, int? _parentId, int? _pageIndex)
        {
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out _languageId);
            ContentView result;
            result = _services.GetAll(_searchKey, null, null, _parentId, "Banner", _languageId, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            var category = _services.Dropdownlist(0, null, "cbanner", _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Contents.Count() > 0)
            {
                var model = result.Contents.Select(x => new modelBanner
                {
                    Alias = x.contentAlias,
                    BodyContent = x.contentBody,
                    Id = x.contentId,
                    Img = x.contentThumbnail,
                    LanguageId = x.languageId,
                    LanguageName = _languageService.GetNameById(x.languageId),
                    Name = x.contentName,
                    ParentId = x.parentId,
                    ParentName = _services.GetNameById(x.parentId),
                    IsSort = x.isSort,
                    IsTrash = x.isTrash
                });
                return View(model);
            }
            else
            {
                var model = new List<modelBanner>();
                return View(model);
            }
        }

        public ActionResult Category(string _searchKey, int? _parentId, int? _pageIndex)
        {
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out _languageId);
            ContentView result;
            result = _services.GetAll(_searchKey, null, null, _parentId, "cbanner", _languageId, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            var category = _services.Dropdownlist(0, null, "cbanner", _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Contents.Count() > 0)
            {
                var model = result.Contents.Select(x => new modelCategories
                {
                    Alias = x.contentAlias,
                    Id = x.contentId,
                    Img = x.contentThumbnail,
                    LanguageId = x.languageId,
                    LanguageName = _languageService.GetNameById(x.languageId),
                    MetaDescription = x.contentDescription,
                    MetaKeywords = x.contentKeywords,
                    MetaTitle = x.contentTitle,
                    Name = x.contentName,
                    Note = x.note,
                    ParentId = x.parentId,
                    ParentName = _services.GetNameById(x.parentId)
                });
                return View(model);
            }
            else
            {
                var model = new List<modelCategories>();
                return View(model);
            }
        }

        public ActionResult CategoryTrash(string _searchKey, int? _parentId, int? _pageIndex)
        {
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out _languageId);
            ContentView result;
            result = _services.GetAll(_searchKey, null, null, _parentId, "cbanner", _languageId, true, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            var category = _services.Dropdownlist(0, null, "cbanner", _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Contents.Count() > 0)
            {
                var model = result.Contents.Select(x => new modelCategories
                {
                    Alias = x.contentAlias,
                    Id = x.contentId,
                    Img = x.contentThumbnail,
                    LanguageId = x.languageId,
                    LanguageName = _languageService.GetNameById(x.languageId),
                    MetaDescription = x.contentDescription,
                    MetaKeywords = x.contentKeywords,
                    MetaTitle = x.contentTitle,
                    Name = x.contentName,
                    Note = x.note,
                    ParentId = x.parentId,
                    ParentName = _services.GetNameById(x.parentId)
                });
                return View(model);
            }
            else
            {
                var model = new List<modelCategories>();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DetailCategory(int? Id)
        {
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out _languageId);
            modelCategories entity;
            if (Id.HasValue && Id > 0)
            {
                var model = _services.GetById(Id.Value);
                entity = new modelCategories();
                entity.Id = model.contentId;
                entity.Alias = model.contentAlias;
                entity.Img = model.contentThumbnail;
                entity.LanguageId = model.languageId;
                entity.MetaDescription = model.contentDescription;
                entity.MetaKeywords = model.contentKeywords;
                entity.MetaTitle = model.contentTitle;
                entity.Name = model.contentName;
                entity.Note = model.note;
                entity.ParentId = model.parentId;
                if (model.isHome.HasValue)
                    entity.IsHome = model.isHome.Value;
                else
                    entity.IsHome = false;
                entity.No = model.isSort;
                ViewBag.Title = "Cập nhật chuyên mục banner";
            }
            else
            {
                entity = new modelCategories
                {
                    LanguageId = _languageId
                };
                ViewBag.Title = "Thêm mới chuyên mục banner";
            }
            var category = _services.Dropdownlist(0, entity.Id, "cbanner", _languageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DetailCategory(modelCategories entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.Id > 0)
                {
                    var model = _services.GetById(entity.Id);
                    model.contentAlias = entity.Alias;
                    model.contentDescription = entity.MetaDescription;
                    model.contentId = entity.Id;
                    model.contentThumbnail = entity.Img;
                    model.contentTitle = entity.MetaTitle;
                    model.updateTime = DateTime.Now;
                    model.parentId = entity.ParentId;
                    model.isHome = entity.IsHome;
                    model.note = entity.Note;
                    model.contentName = entity.Name;
                    model.isSort = entity.No.GetValueOrDefault();
                    _services.Update(model);
                    _services.Save();
                    _serviceLog.Add(new ActionLog { actionLogStatus = 1, actionLogTime = DateTime.Now, actionLogType = 1, actionNote = "Cập nhật chuyên mục banner Id:" + model.contentId, userIp = "", userName = User.Identity.Name });
                    _serviceLog.Save();
                }
                else
                {
                    var model = new Content();
                    model.contentAlias = entity.Alias;
                    model.contentDescription = entity.MetaDescription;
                    model.contentId = entity.Id;
                    model.contentThumbnail = entity.Img;
                    model.contentTitle = entity.MetaTitle;
                    model.updateTime = DateTime.Now;
                    model.parentId = entity.ParentId;
                    model.note = entity.Note;
                    model.contentName = entity.Name;
                    model.createTime = DateTime.Now;
                    model.isSort = entity.No.GetValueOrDefault();
                    model.isHome = entity.IsHome;
                    model.isTrash = false;
                    model.isView = 0;
                    model.languageId = entity.LanguageId;
                    model.contentKey = "cbanner";
                    _services.Add(model);
                    _services.Save();
                    model.contentAlias = model.contentAlias + "-" + model.contentId;
                    _services.Update(model);
                    _services.Save();
                    _serviceLog.Add(new ActionLog { actionLogStatus = 1, actionLogTime = DateTime.Now, actionLogType = 1, actionNote = "Thêm mới chuyên mục banner Id:" + model.contentId, userIp = "", userName = User.Identity.Name });
                    _serviceLog.Save();
                }
                return RedirectToAction("Category", new { _parentId = entity.ParentId });
            }
            var category = _services.Dropdownlist(0, entity.Id, "cbanner", entity.LanguageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }

        [HttpGet]
        public ActionResult Detail(int? Id)
        {
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out _languageId);
            modelBanner entity;
            if (Id.HasValue && Id > 0)
            {
                var model = _services.GetById(Id.Value);
                entity = new modelBanner
                {
                    Id = model.contentId,
                    Alias = model.contentAlias,
                    BodyContent = model.contentBody,
                    Img = model.contentThumbnail,
                    LanguageId = model.languageId,
                    Name = model.contentName,
                    ParentId = model.parentId,
                    IsSort = model.isSort,
                    IsTrash = model.isTrash,
                    Link = model.note
                };
                ViewBag.Title = "Cập nhật banner";
            }
            else
            {
                entity = new modelBanner
                {
                    LanguageId = _languageId
                };
                ViewBag.Title = "Thêm mới banner";
            }
            var category = _services.Dropdownlist(0, entity.Id, "cbanner", _languageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(modelBanner entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.Id > 0)
                {
                    var model = _services.GetById(entity.Id);
                    model.contentAlias = entity.Alias;
                    model.note = entity.Link;
                    model.contentBody = entity.BodyContent;
                    model.contentId = entity.Id;
                    model.contentThumbnail = entity.Img;
                    model.updateTime = DateTime.Now;
                    model.parentId = entity.ParentId;
                    model.contentName = entity.Name;
                    _services.Update(model);
                    _services.Save();
                    _serviceLog.Add(new ActionLog { actionLogStatus = 1, actionLogTime = DateTime.Now, actionLogType = 1, actionNote = "Cập nhật banner Id:" + model.contentId, userIp = "", userName = User.Identity.Name });
                    _serviceLog.Save();
                    _serviceLog.Save();
                }
                else
                {
                    var model = new Content();
                    model.contentAlias = Guid.NewGuid().ToString();
                    model.contentBody = entity.BodyContent;
                    model.note = entity.Link;
                    model.contentId = entity.Id;
                    model.contentThumbnail = entity.Img;
                    model.updateTime = DateTime.Now;
                    model.parentId = entity.ParentId;
                    model.contentName = entity.Name;
                    model.createTime = DateTime.Now;
                    model.isSort = entity.IsSort;
                    model.isTrash = false;
                    model.isView = 0;
                    model.languageId = entity.LanguageId;
                    model.contentKey = "Banner";
                    _services.Add(model);
                    _services.Save();
                    model.contentAlias = model.contentAlias + "-" + model.contentId;
                    _services.Update(model);
                    _services.Save();
                    _serviceLog.Add(new ActionLog { actionLogStatus = 1, actionLogTime = DateTime.Now, actionLogType = 1, actionNote = "Thêm mới banner Id:" + model.contentId, userIp = "", userName = User.Identity.Name });
                    _serviceLog.Save();
                }
                return RedirectToAction("Index", new { _parentId = entity.ParentId });
            }
            var category = _services.Dropdownlist(0, entity.Id, "cbanner", entity.LanguageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }

        public ActionResult AllTrash(string _searchKey, int? _parentId, int? _pageIndex)
        {
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out _languageId);
            var result = new ContentView();
            result = _services.GetAll(_searchKey, null, null, _parentId, "Banner", _languageId, true, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            var category = _services.Dropdownlist(0, null, "cbanner", _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Contents.Count() > 0)
            {
                var model = result.Contents.Select(x => new modelBanner
                {
                    Alias = x.contentAlias,
                    BodyContent = x.contentAlias,
                    Id = x.contentId,
                    Img = x.contentThumbnail,
                    LanguageId = x.languageId,
                    LanguageName = _languageService.GetNameById(x.languageId),
                    Name = x.contentName,
                    ParentId = x.parentId,
                    ParentName = _services.GetNameById(x.parentId),
                    IsSort = x.isSort,
                    IsTrash = x.isTrash
                });
                return View(model);
            }
            else
            {
                var model = new List<modelBanner>();
                return View(model);
            }
        }
    }
}
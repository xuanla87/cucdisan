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
    [Authorize]
    public class AnPhamTaiLieuController : Controller
    {
        IContentServices _services;
        ILanguageServices _languageService;
        int _languageId = 1;
        public AnPhamTaiLieuController(IContentServices services, ILanguageServices languageService)
        {
            this._services = services;
            this._languageService = languageService;
        }

        public ActionResult Index(string _searchKey, int? _parentId, DateTime? _fromDate, DateTime? _toDate, int? _pageIndex)
        {
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out _languageId);
            ContentView result;
            result = _services.GetAll(_searchKey, _fromDate, _toDate, _parentId, "AnPhamTaiLieu", _languageId, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            ViewBag.FromDate = _fromDate?.ToString("dd/MM/yyyy") ?? null;
            ViewBag.ToDate = _toDate?.ToString("dd/MM/yyyy") ?? null;
            var category = _services.Dropdownlist(0, null, "canphamtailieu", _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Contents.Count() > 0)
            {
                var model = result.Contents.Select(x => new modelAnPhamTaiLieu
                {
                    Alias = x.contentAlias,
                    BodyContent = x.contentBody,
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
                    ParentName = _services.GetNameById(x.parentId),
                    CreateTime = x.updateTime.ToString("dd/MM/yyyy")
                });
                return View(model);
            }
            else
            {
                var model = new List<modelAnPhamTaiLieu>();
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
            result = _services.GetAll(_searchKey, null, null, _parentId, "canphamtailieu", _languageId, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            var category = _services.Dropdownlist(0, null, "canphamtailieu", _languageId);
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
            result = _services.GetAll(_searchKey, null, null, _parentId, "canphamtailieu", _languageId, true, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            var category = _services.Dropdownlist(0, null, "canphamtailieu", _languageId);
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
                ViewBag.Title = "Cập nhật chuyên mục ấn phẩm tài liệu";
            }
            else
            {
                entity = new modelCategories
                {
                    LanguageId = _languageId
                };
                ViewBag.Title = "Thêm mới chuyên mục ấn phẩm tài liệu";
            }
            var category = _services.Dropdownlist(0, entity.Id, "canphamtailieu", _languageId);
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
                    model.contentKey = "canphamtailieu";
                    model.isTrash = false;
                    model.isSort = entity.No.GetValueOrDefault();
                    model.contentName = entity.Name;
                    _services.Update(model);
                    _services.Save();
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
                    model.contentKey = "canphamtailieu";
                    _services.Add(model);
                    _services.Save();
                    model.contentAlias = model.contentAlias + "-" + model.contentId;
                    _services.Update(model);
                    _services.Save();
                }
                return RedirectToAction("Category", new { _parentId = entity.ParentId });
            }
            var category = _services.Dropdownlist(0, entity.Id, "canphamtailieu", entity.LanguageId);
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
            modelAnPhamTaiLieu entity;
            if (Id.HasValue && Id > 0)
            {
                var model = _services.GetById(Id.Value);
                entity = new modelAnPhamTaiLieu
                {
                    Id = model.contentId,
                    Alias = model.contentAlias,
                    BodyContent = model.contentBody,
                    CreateTime = model.updateTime.ToString("dd/MM/yyyy"),
                    Img = model.contentThumbnail,
                    LanguageId = model.languageId,
                    MetaDescription = model.contentDescription,
                    MetaKeywords = model.contentKeywords,
                    MetaTitle = model.contentTitle,
                    Name = model.contentName,
                    Note = model.note,
                    ParentId = model.parentId,
                    Sort =model.isSort
                };
                ViewBag.Title = "Cập nhật ấn phẩm tài liệu";
            }
            else
            {
                entity = new modelAnPhamTaiLieu
                {
                    CreateTime = DateTime.Now.ToString("dd/MM/yyyy"),
                    LanguageId = _languageId
                };
                ViewBag.Title = "Thêm mới ấn phẩm tài liệu";
            }
            var category = _services.Dropdownlist(0, entity.Id, "canphamtailieu", _languageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(modelAnPhamTaiLieu entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.Id > 0)
                {
                    var model = _services.GetById(entity.Id);
                    model.contentAlias = entity.Alias;
                    model.contentBody = entity.BodyContent;
                    model.contentDescription = entity.MetaDescription;
                    model.contentId = entity.Id;
                    model.contentThumbnail = entity.Img;
                    model.contentTitle = entity.MetaTitle;
                    if (string.IsNullOrEmpty(entity.CreateTime))
                        model.updateTime = DateTime.Now;
                    else
                        model.updateTime = DateTime.ParseExact(entity.CreateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    model.parentId = entity.ParentId;
                    model.note = entity.Note;
                    model.contentName = entity.Name;
                    model.isSort = entity.Sort;
                    _services.Update(model);
                    _services.Save();
                }
                else
                {
                    var model = new Content();
                    model.contentAlias = entity.Alias;
                    model.contentBody = entity.BodyContent;
                    model.contentDescription = entity.MetaDescription;
                    model.contentId = entity.Id;
                    model.contentThumbnail = entity.Img;
                    model.contentTitle = entity.MetaTitle;
                    if (string.IsNullOrEmpty(entity.CreateTime))
                        model.updateTime = DateTime.Now;
                    else
                        model.updateTime = DateTime.ParseExact(entity.CreateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    model.parentId = entity.ParentId;
                    model.note = entity.Note;
                    model.contentName = entity.Name;
                    model.createTime = DateTime.Now;
                    model.isSort = entity.Sort;
                    model.isTrash = false;
                    model.isView = 0;
                    model.languageId = entity.LanguageId;
                    model.contentKey = "AnPhamTaiLieu";
                    _services.Add(model);
                    _services.Save();
                    model.contentAlias = model.contentAlias + "-" + model.contentId;
                    _services.Update(model);
                    _services.Save();
                }
                return RedirectToAction("Index", new { _parentId = entity.ParentId });
            }
            var category = _services.Dropdownlist(0, entity.Id, "canphamtailieu", entity.LanguageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }

        public ActionResult AllTrash(string _searchKey, int? _parentId, DateTime? _fromDate, DateTime? _toDate, int? _pageIndex)
        {
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out _languageId);
            var result = new ContentView();
            result = _services.GetAll(_searchKey, _fromDate, _toDate, _parentId, "AnPhamTaiLieu", _languageId, true, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            ViewBag.FromDate = _fromDate?.ToString("dd/MM/yyyy") ?? null;
            ViewBag.ToDate = _toDate?.ToString("dd/MM/yyyy") ?? null;
            var category = _services.Dropdownlist(0, null, "canphamtailieu", _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Contents.Count() > 0)
            {
                var model = result.Contents.Select(x => new modelAnPhamTaiLieu
                {
                    Alias = x.contentAlias,
                    BodyContent = x.contentAlias,
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
                    ParentName = _services.GetNameById(x.parentId),
                    CreateTime = x.updateTime.ToString("dd/MM/yyyy")
                });
                return View(model);
            }
            else
            {
                var model = new List<modelAnPhamTaiLieu>();
                return View(model);
            }
        }
    }
}
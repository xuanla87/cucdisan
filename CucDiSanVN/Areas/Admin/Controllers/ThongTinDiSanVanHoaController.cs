using CucDiSanService.Models;
using CucDiSanService.Services;
using CucDiSanVN.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace CucDiSanVN.Areas.Admin.Controllers
{
    [Authorize]
    public class ThongTinDiSanVanHoaController : Controller
    {
        private IContentServices _services;
        private ILanguageServices _languageService;
        public ThongTinDiSanVanHoaController(IContentServices services, ILanguageServices languageService)
        {
            _services = services;
            _languageService = languageService;
        }
        public ActionResult Index(string _searchKey, int? _parentId, DateTime? _fromDate, DateTime? _toDate, int? _pageIndex)
        {
            ContentView result;
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out int _languageId);
            result = _services.GetAll(_searchKey, _fromDate, _toDate, _parentId, "Thongtindisanvanhoa", _languageId, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            ViewBag.FromDate = _fromDate?.ToString("dd/MM/yyyy") ?? null;
            ViewBag.ToDate = _toDate?.ToString("dd/MM/yyyy") ?? null;
            IEnumerable<DropdownModel> category = _services.Dropdownlist(0, null, "cthongtindisanvanhoa", _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Contents.Count() > 0)
            {
                IEnumerable<modelThongTinDiSanVanHoa> model = result.Contents.Select(x => new modelThongTinDiSanVanHoa
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
                List<modelThongTinDiSanVanHoa> model = new List<modelThongTinDiSanVanHoa>();
                return View(model);
            }
        }

        public ActionResult Category(string _searchKey, int? _parentId, int? _pageIndex)
        {
            ContentView result;
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out int _languageId);
            result = _services.GetAll(_searchKey, null, null, _parentId, "cthongtindisanvanhoa", _languageId, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            IEnumerable<DropdownModel> category = _services.Dropdownlist(0, null, "cthongtindisanvanhoa", _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Contents.Count() > 0)
            {
                IEnumerable<modelCategories> model = result.Contents.Select(x => new modelCategories
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
                List<modelCategories> model = new List<modelCategories>();
                return View(model);
            }
        }

        public ActionResult CategoryTrash(string _searchKey, int? _parentId, int? _pageIndex)
        {
            ContentView result;
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out int _languageId);
            result = _services.GetAll(_searchKey, null, null, _parentId, "cthongtindisanvanhoa", _languageId, true, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            IEnumerable<DropdownModel> category = _services.Dropdownlist(0, null, "cthongtindisanvanhoa", _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Contents.Count() > 0)
            {
                IEnumerable<modelCategories> model = result.Contents.Select(x => new modelCategories
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
                List<modelCategories> model = new List<modelCategories>();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult DetailCategory(int? Id)
        {
            modelCategories entity;
            int _languageId = 1;
            if (Id.HasValue && Id > 0)
            {
                Content model = _services.GetById(Id.Value);
                entity = new modelCategories
                {
                    Id = model.contentId,
                    Alias = model.contentAlias,
                    Img = model.contentThumbnail,
                    LanguageId = model.languageId,
                    MetaDescription = model.contentDescription,
                    MetaKeywords = model.contentKeywords,
                    MetaTitle = model.contentTitle,
                    Name = model.contentName,
                    Note = model.note,
                    ParentId = model.parentId
                };
                if (model.isHome.HasValue)
                {
                    entity.IsHome = model.isHome.Value;
                }
                else
                {
                    entity.IsHome = false;
                }

                entity.No = model.isSort;
                ViewBag.Title = "Cập nhật chuyên mục thông tin di sản văn hóa";
            }
            else
            {
                entity = new modelCategories
                {
                    LanguageId = _languageId
                };
                ViewBag.Title = "Thêm mới chuyên mục thông tin di sản văn hóa";
            }
            IEnumerable<DropdownModel> category = _services.Dropdownlist(0, entity.Id, "cthongtindisanvanhoa", _languageId);
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
                    Content model = _services.GetById(entity.Id);
                    model.contentAlias = entity.Alias;
                    model.contentDescription = entity.MetaDescription;
                    model.contentId = entity.Id;
                    model.contentThumbnail = entity.Img;
                    model.contentTitle = entity.MetaTitle;
                    model.updateTime = DateTime.Now;
                    model.parentId = entity.ParentId;
                    model.note = entity.Note;
                    model.contentKey = "cthongtindisanvanhoa";
                    model.isTrash = false;
                    model.isHome = entity.IsHome;
                    model.contentName = entity.Name;
                    model.isSort = entity.No.GetValueOrDefault();
                    _services.Update(model);
                    _services.Save();
                }
                else
                {
                    Content model = new Content
                    {
                        contentAlias = entity.Alias,
                        contentDescription = entity.MetaDescription,
                        contentId = entity.Id,
                        contentThumbnail = entity.Img,
                        contentTitle = entity.MetaTitle,
                        updateTime = DateTime.Now,
                        parentId = entity.ParentId,
                        note = entity.Note,
                        contentName = entity.Name,
                        createTime = DateTime.Now,
                        isSort = entity.No.GetValueOrDefault(),
                        isHome = entity.IsHome,
                        isTrash = false,
                        isView = 0,
                        languageId = entity.LanguageId,
                        contentKey = "cthongtindisanvanhoa"
                    };
                    _services.Add(model);
                    _services.Save();
                    model.contentAlias = model.contentAlias + "-" + model.contentId;
                    _services.Update(model);
                    _services.Save();
                }
                return RedirectToAction("Category", new { _parentId = entity.ParentId });
            }
            IEnumerable<DropdownModel> category = _services.Dropdownlist(0, entity.Id, "cthongtindisanvanhoa", entity.LanguageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }

        [HttpGet]
        public ActionResult Detail(int? Id)
        {
            modelThongTinDiSanVanHoa entity;
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out int _languageId);
            if (Id.HasValue && Id > 0)
            {
                Content model = _services.GetById(Id.Value);
                entity = new modelThongTinDiSanVanHoa
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
                    Sort = model.isSort,
                    TacGia = model.tacGia
                };
                ViewBag.Title = "Cập nhật thông tin di sản văn hóa";
            }
            else
            {
                entity = new modelThongTinDiSanVanHoa
                {
                    CreateTime = DateTime.Now.ToString("dd/MM/yyyy"),
                    LanguageId = _languageId
                };
                ViewBag.Title = "Thêm mới thông tin di sản văn hóa";
            }
            IEnumerable<DropdownModel> category = _services.Dropdownlist(0, entity.Id, "cthongtindisanvanhoa", _languageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(modelThongTinDiSanVanHoa entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.Id > 0)
                {
                    Content model = _services.GetById(entity.Id);
                    model.contentAlias = entity.Alias;
                    model.contentBody = entity.BodyContent;
                    model.contentDescription = entity.MetaDescription;
                    model.contentId = entity.Id;
                    model.contentThumbnail = entity.Img;
                    model.contentTitle = entity.MetaTitle;
                    if (string.IsNullOrEmpty(entity.CreateTime))
                    {
                        model.updateTime = DateTime.Now;
                    }
                    else
                    {
                        model.updateTime = DateTime.ParseExact(entity.CreateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }

                    model.parentId = entity.ParentId;
                    model.note = entity.Note;
                    model.contentName = entity.Name;
                    model.isSort = entity.Sort;
                    model.tacGia = entity.TacGia;
                    _services.Update(model);
                    _services.Save();
                }
                else
                {
                    Content model = new Content
                    {
                        contentAlias = entity.Alias,
                        contentBody = entity.BodyContent,
                        contentDescription = entity.MetaDescription,
                        contentId = entity.Id,
                        contentThumbnail = entity.Img,
                        contentTitle = entity.MetaTitle
                    };
                    if (string.IsNullOrEmpty(entity.CreateTime))
                    {
                        model.updateTime = DateTime.Now;
                    }
                    else
                    {
                        model.updateTime = DateTime.ParseExact(entity.CreateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }

                    model.parentId = entity.ParentId;
                    model.note = entity.Note;
                    model.contentName = entity.Name;
                    model.createTime = DateTime.Now;
                    model.tacGia = entity.TacGia;
                    model.isSort = entity.Sort;
                    model.isTrash = false;
                    model.isView = 0;
                    model.languageId = entity.LanguageId;
                    model.contentKey = "Thongtindisanvanhoa";
                    _services.Add(model);
                    _services.Save();
                    model.contentAlias = model.contentAlias + "-" + model.contentId;
                    _services.Update(model);
                    _services.Save();
                }
                return RedirectToAction("Index", new { _parentId = entity.ParentId });
            }
            IEnumerable<DropdownModel> category = _services.Dropdownlist(0, entity.Id, "cthongtindisanvanhoa", entity.LanguageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }

        public ActionResult AllTrash(string _searchKey, int? _parentId, DateTime? _fromDate, DateTime? _toDate, int? _pageIndex)
        {
            ContentView result = new ContentView();
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out int _languageId);
            result = _services.GetAll(_searchKey, _fromDate, _toDate, _parentId, "Thongtindisanvanhoa", _languageId, true, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            ViewBag.FromDate = _fromDate?.ToString("dd/MM/yyyy") ?? null;
            ViewBag.ToDate = _toDate?.ToString("dd/MM/yyyy") ?? null;
            IEnumerable<DropdownModel> category = _services.Dropdownlist(0, null, "cthongtindisanvanhoa", _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Contents.Count() > 0)
            {
                IEnumerable<modelThongTinDiSanVanHoa> model = result.Contents.Select(x => new modelThongTinDiSanVanHoa
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
                List<modelThongTinDiSanVanHoa> model = new List<modelThongTinDiSanVanHoa>();
                return View(model);
            }
        }
    }
}
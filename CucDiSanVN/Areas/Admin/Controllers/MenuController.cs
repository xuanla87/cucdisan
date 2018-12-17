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
    public class MenuController : Controller
    {
        IMenuServices _services;
        ILanguageServices _languageService;
        public MenuController(IMenuServices services, ILanguageServices languageService)
        {
            this._services = services;
            this._languageService = languageService;
        }
        public ActionResult Index(string _searchKey, int? _parentId, int? _pageIndex)
        {
            MenuView result;
            int _languageId = 1;
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out _languageId);
            result = _services.GetAll(_searchKey, _parentId, _languageId, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            var category = _services.Dropdownlist(0, null, _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Menus.Count() > 0)
            {
                var model = result.Menus.Select(x => new modelMenu
                {
                    isIcon = x.isIcon,
                    isSort = x.isSort,
                    isTaget = x.isTaget,
                    isTrash = x.isTrash,
                    languageId = x.languageId,
                    menuId = x.menuId,
                    menuName = x.menuName,
                    menuUrl = x.menuUrl,
                    parentId = x.parentId,
                    parentName = _services.GetNameById(x.parentId)
                });
                return View(model);
            }
            else
            {
                var model = new List<modelMenu>();
                return View(model);
            }
        }

        public ActionResult AllTrash(string _searchKey, int? _parentId, int? _pageIndex)
        {
            MenuView result;
            int _languageId = 1;
            result = _services.GetAll(_searchKey, _parentId, _languageId, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            var category = _services.Dropdownlist(0, null, _languageId);
            ViewBag._parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            if (result != null && result.Menus.Count() > 0)
            {
                var model = result.Menus.Select(x => new modelMenu
                {
                    isIcon = x.isIcon,
                    isSort = x.isSort,
                    isTaget = x.isTaget,
                    isTrash = x.isTrash,
                    languageId = x.languageId,
                    menuId = x.menuId,
                    menuName = x.menuName,
                    menuUrl = x.menuUrl,
                    parentId = x.parentId,
                    parentName = _services.GetNameById(x.parentId)
                });
                return View(model);
            }
            else
            {
                var model = new List<modelMenu>();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult Detail(int? Id)
        {
            modelMenu entity;
            int _languageId = 1;
            string cookieLanguage = "1";
            if (Request.Cookies["cookieLanguage"] != null)
            {
                cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            }
            int.TryParse(cookieLanguage, out _languageId);
            if (Id.HasValue && Id > 0)
            {
                var model = _services.GetById(Id.Value);
                entity = new modelMenu
                {
                    isIcon = model.isIcon,
                    isSort = model.isSort,
                    isTaget = model.isTaget,
                    isTrash = model.isTrash,
                    languageId = model.languageId,
                    menuId = model.menuId,
                    menuName = model.menuName,
                    menuUrl = model.menuUrl,
                    parentId = model.parentId
                };
                ViewBag.Title = "Cập nhật danh mục";
            }
            else
            {
                entity = new modelMenu
                {
                    languageId = _languageId
                };
                ViewBag.Title = "Thêm mới danh mục";
            }
            var category = _services.Dropdownlist(0, entity.menuId, _languageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(modelMenu entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.menuId > 0)
                {
                    var model = _services.GetById(entity.menuId);
                    model.menuName = entity.menuName;
                    model.menuUrl = entity.menuUrl;
                    model.parentId = entity.parentId;
                    model.isIcon = entity.isIcon;
                    model.isSort = entity.isSort;
                    model.isTaget = entity.isTaget;
                    _services.Update(model);
                    _services.Save();
                }
                else
                {
                    var model = new Menu();
                    model.menuName = entity.menuName;
                    model.menuUrl = entity.menuUrl;
                    model.parentId = entity.parentId;
                    model.isIcon = entity.isIcon;
                    model.isSort = entity.isSort;
                    model.isTaget = entity.isTaget;
                    model.isTrash = false;
                    model.languageId = entity.languageId;
                    _services.Add(model);
                    _services.Save();
                }
                return RedirectToAction("Index", new { _parentId = entity.parentId });
            }
            var category = _services.Dropdownlist(0, entity.menuId, entity.languageId);
            ViewBag.ParentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(entity);
        }
    }
}
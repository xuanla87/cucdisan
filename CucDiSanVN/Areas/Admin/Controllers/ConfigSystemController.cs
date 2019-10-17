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
    public class ConfigSystemController : Controller
    {
        IConfigSystemServices _services;
        ILanguageServices _languageService;
        IMenuServices _menuService;
        IContentServices _contentService;
        public ConfigSystemController(IConfigSystemServices services, ILanguageServices languageService, IMenuServices menuService, IContentServices contentService)
        {
            this._services = services;
            this._languageService = languageService;
            this._menuService = menuService;
            this._contentService = contentService;
        }
        public ActionResult Index()
        {
            modelConfig model = new modelConfig();
            if (!string.IsNullOrEmpty(_services.GetValueByKey("MenuFooter")))
                model.MenuFooter = int.Parse(_services.GetValueByKey("MenuFooter"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("MenuLeft1")))
                model.MenuLeft1 = int.Parse(_services.GetValueByKey("MenuLeft1"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("MenuLeft2")))
                model.MenuLeft2 = int.Parse(_services.GetValueByKey("MenuLeft2"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("MenuMain")))
                model.MenuMain = int.Parse(_services.GetValueByKey("MenuMain"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("BoxHinhAnh")))
                model.BoxHinhAnh = int.Parse(_services.GetValueByKey("BoxHinhAnh"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("BannerLeft")))
                model.BannerLeft = int.Parse(_services.GetValueByKey("BannerLeft"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("BannerRight")))
                model.BannerRight = int.Parse(_services.GetValueByKey("BannerRight"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("ThongBao")))
                model.ThongBao = int.Parse(_services.GetValueByKey("ThongBao"));
            model.SiteBanner = _services.GetValueByKey("SiteBanner");
            model.SiteContact = _services.GetValueByKey("SiteContact");
            model.SiteDescription = _services.GetValueByKey("SiteDescription");
            model.SiteEmail = _services.GetValueByKey("SiteEmail");
            model.SiteFooterInfo = _services.GetValueByKey("SiteFooterInfo");
            model.SiteKeywords = _services.GetValueByKey("SiteKeywords");
            model.SiteTitle = _services.GetValueByKey("SiteTitle");
            var enMenu = _menuService.Dropdownlist(0, null, 1);
            var enHinhAnh = _contentService.Dropdownlist(0, null, "csukienquaanh", 1);
            var enBannerLeft = _contentService.Dropdownlist(0, null, "cbanner", 1);
            var enBannerRight = _contentService.Dropdownlist(0, null, "cbanner", 1);
            var enThongBao = _contentService.Dropdownlist(0, null, "cnews", 1);
            ViewBag.MenuMain = enMenu.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.MenuLeft1 = enMenu.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.MenuLeft2 = enMenu.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.BoxHinhAnh = enHinhAnh.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.BannerLeft = enBannerLeft.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.BannerRight = enBannerRight.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.ThongBao = enThongBao.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Index(modelConfig model)
        {
            if (ModelState.IsValid)
            {
                _services.SaveData("MenuFooter", model.MenuFooter.ToString());
                _services.SaveData("MenuLeft1", model.MenuLeft1.ToString());
                _services.SaveData("MenuLeft2", model.MenuLeft2.ToString());
                _services.SaveData("MenuMain", model.MenuMain.ToString());
                _services.SaveData("BoxHinhAnh", model.BoxHinhAnh.ToString());
                _services.SaveData("SiteBanner", model.SiteBanner);
                _services.SaveData("SiteContact", model.SiteContact);
                _services.SaveData("SiteDescription", model.SiteDescription);
                _services.SaveData("SiteEmail", model.SiteEmail);
                _services.SaveData("SiteFooterInfo", model.SiteFooterInfo);
                _services.SaveData("SiteKeywords", model.SiteKeywords);
                _services.SaveData("SiteTitle", model.SiteTitle);
                _services.SaveData("BannerLeft", model.BannerLeft.ToString());
                _services.SaveData("BannerRight", model.BannerRight.ToString());
                _services.SaveData("ThongBao", model.ThongBao.ToString());
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult SetUpEnglish()
        {
            modelConfig model = new modelConfig();
            if (!string.IsNullOrEmpty(_services.GetValueByKey("MenuFooterEn")))
                model.MenuFooterEn = int.Parse(_services.GetValueByKey("MenuFooterEn"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("MenuLeft1En")))
                model.MenuLeft1En = int.Parse(_services.GetValueByKey("MenuLeft1En"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("MenuLeft2En")))
                model.MenuLeft2En = int.Parse(_services.GetValueByKey("MenuLeft2En"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("MenuMainEn")))
                model.MenuMainEn = int.Parse(_services.GetValueByKey("MenuMainEn"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("BoxHinhAnhEn")))
                model.BoxHinhAnhEn = int.Parse(_services.GetValueByKey("BoxHinhAnhEn"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("BannerLeftEn")))
                model.BannerLeftEn = int.Parse(_services.GetValueByKey("BannerLeftEn"));
            if (!string.IsNullOrEmpty(_services.GetValueByKey("BannerRightEn")))
                model.BannerRightEn = int.Parse(_services.GetValueByKey("BannerRightEn"));
            model.SiteBannerEn = _services.GetValueByKey("SiteBannerEn");
            model.SiteContactEn = _services.GetValueByKey("SiteContactEn");
            model.SiteDescriptionEn = _services.GetValueByKey("SiteDescriptionEn");
            model.SiteEmailEn = _services.GetValueByKey("SiteEmailEn");
            model.SiteFooterInfoEn = _services.GetValueByKey("SiteFooterInfoEn");
            model.SiteKeywordsEn = _services.GetValueByKey("SiteKeywordsEn");
            model.SiteTitleEn = _services.GetValueByKey("SiteTitleEn");
            var enMenu = _menuService.Dropdownlist(0, null, 2);
            var enHinhAnh = _contentService.Dropdownlist(0, null, "csukienquaanh", 2);
            var enBannerLeft = _contentService.Dropdownlist(0, null, "cbanner", 2);
            var enBannerRight = _contentService.Dropdownlist(0, null, "cbanner", 2);
            ViewBag.MenuMainEn = enMenu.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.MenuLeft1En = enMenu.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.MenuLeft2En = enMenu.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.BoxHinhAnhEn = enHinhAnh.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.BannerLeftEn = enBannerLeft.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            ViewBag.BannerRightEn = enBannerRight.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult SetUpEnglish(modelConfig model)
        {
            if (ModelState.IsValid)
            {
                _services.SaveData("MenuFooterEn", model.MenuFooterEn.ToString());
                _services.SaveData("MenuLeft1En", model.MenuLeft1En.ToString());
                _services.SaveData("MenuLeft2En", model.MenuLeft2En.ToString());
                _services.SaveData("MenuMainEn", model.MenuMainEn.ToString());
                _services.SaveData("BoxHinhAnhEn", model.BoxHinhAnhEn.ToString());
                _services.SaveData("SiteBannerEn", model.SiteBannerEn);
                _services.SaveData("SiteContactEn", model.SiteContactEn);
                _services.SaveData("SiteDescriptionEn", model.SiteDescriptionEn);
                _services.SaveData("SiteEmailEn", model.SiteEmailEn);
                _services.SaveData("SiteFooterInfoEn", model.SiteFooterInfoEn);
                _services.SaveData("SiteKeywordsEn", model.SiteKeywordsEn);
                _services.SaveData("SiteTitleEn", model.SiteTitleEn);
                _services.SaveData("BannerLeftEn", model.BannerLeftEn.ToString());
                _services.SaveData("BannerRightEn", model.BannerRightEn.ToString());
                return RedirectToAction("SetUpEnglish");
            }
            return RedirectToAction("SetUpEnglish");
        }
    }
}
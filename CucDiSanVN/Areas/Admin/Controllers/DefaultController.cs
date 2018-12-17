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
    public class DefaultController : Controller
    {
        IContentServices _services;
        IMenuServices _menuServices;
        ILanguageServices _languageServices;
        IConfigSystemServices _configSystemServices;
        IVideoServices _videoServices;
        private int _languageId = 1;
        public DefaultController(IContentServices services, IMenuServices menuServices, IConfigSystemServices configSystemServices, IVideoServices videoServices, ILanguageServices languageServices)
        {
            this._services = services;
            this._menuServices = menuServices;
            this._configSystemServices = configSystemServices;
            this._videoServices = videoServices;
            this._languageServices = languageServices;
        }
        public ActionResult Index()
        {
            //string cookieLanguage = "1";
            //if (Request.Cookies["cookieLanguage"] != null)
            //{
            //    cookieLanguage = Request.Cookies["cookieLanguage"].Value.ToString();
            //}
            //int.TryParse(cookieLanguage, out _languageId);
            //var _all = _services.GetAll(null, null, null, null, null, _languageId, null, null, null);
            //var _content = _all.Contents.ToList();
            //for (int i = 0; i < _content.Count; i++)
            //{
            //    _content[i].contentAlias = _content[i].contentAlias.Replace("(", "");
            //    _content[i].contentAlias = _content[i].contentAlias.Replace(")", "");
            //    _content[i].contentAlias = _content[i].contentAlias.Replace("\"", "");
            //    _services.Update(_content[i]);
            //    _services.Save();
            //}
            return View();
        }

        public ActionResult _setLanguage(int _languageId)
        {
            Response.Cookies["cookieLanguage"].Value = _languageId.ToString();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
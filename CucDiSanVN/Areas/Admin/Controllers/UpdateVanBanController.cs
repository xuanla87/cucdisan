using CucDiSanService.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CucDiSanVN.Areas.Admin.Controllers
{
    public class UpdateVanBanController : Controller
    {
        private IContentServices _services;
        public UpdateVanBanController(IContentServices services)
        {
            _services = services;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
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
    public class LienKetController : Controller
    {
        ILienketWebServices _services;
        private IActionLogServices _serviceLog;
        public LienKetController(ILienketWebServices services, IActionLogServices serviceLog)
        {
            this._services = services;
            this._serviceLog = serviceLog;
        }
        public ActionResult Index(string _searchKey, int? _pageIndex)
        {
            LienKetWebView result;
            result = _services.All(_searchKey, null, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            return View(result.LienKetWebs);
        }

        [HttpGet]
        public ActionResult Detail(int? Id)
        {
            LienKetWeb entity;
            if (Id.HasValue && Id > 0)
            {
                entity = _services.GetById(Id.Value);
                ViewBag.Title = "Cập nhật liên kết website";
            }
            else
            {
                entity = new LienKetWeb
                {
                    isTrash = false
                };
                ViewBag.Title = "Thêm mới liên kết website";
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(LienKetWeb entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.lienKetId > 0)
                {
                    var model = _services.GetById(entity.lienKetId);
                    model.lienKetName = entity.lienKetName;
                    model.lienKetLink = entity.lienKetLink;
                    model.isSort = entity.isSort;
                    _services.Update(model);
                    _services.Save();
                    _serviceLog.Add(new ActionLog { actionLogStatus = 1, actionLogTime = DateTime.Now, actionLogType = 1, actionNote = "Cập nhật liên kết website Id:" + model.lienKetId, userIp = "", userName = User.Identity.Name });
                    _serviceLog.Save();
                }
                else
                {
                    var model = new LienKetWeb();
                    model.lienKetName = entity.lienKetName;
                    model.isSort = entity.isSort;
                    model.parentId = entity.parentId;
                    model.lienKetLink = entity.lienKetLink;
                    model.isTrash = false;
                    _services.Add(model);
                    _services.Save();
                    _serviceLog.Add(new ActionLog { actionLogStatus = 1, actionLogTime = DateTime.Now, actionLogType = 1, actionNote = "Thêm mới liên kết website Id:" + model.lienKetId, userIp = "", userName = User.Identity.Name });
                    _serviceLog.Save();
                }
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public ActionResult Trash(int Id)
        {
            var model = _services.GetById(Id);
            model.isTrash = true;
            _services.Update(model);
            _services.Save();
            _serviceLog.Add(new ActionLog { actionLogStatus = 1, actionLogTime = DateTime.Now, actionLogType = 1, actionNote = "Xóa liên kết website Id:" + model.lienKetId, userIp = "", userName = User.Identity.Name });
            _serviceLog.Save();
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
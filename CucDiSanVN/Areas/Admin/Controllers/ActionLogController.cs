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
    public class ActionLogController : Controller
    {
        IActionLogServices _serviceLog;
        public ActionLogController(IActionLogServices serviceLog)
        {
            _serviceLog = serviceLog;
        }
        public ActionResult Index(DateTime? _fromDate, DateTime? _toDate, int? _pageIndex)
        {
            ActionLogView result;
            result = _serviceLog.GetaAdmin(_fromDate, _toDate, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.FromDate = _fromDate?.ToString("dd/MM/yyyy") ?? null;
            ViewBag.ToDate = _toDate?.ToString("dd/MM/yyyy") ?? null;
            return View(result.ActionLogs);
        }
    }
}
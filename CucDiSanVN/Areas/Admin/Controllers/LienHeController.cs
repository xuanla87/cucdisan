﻿using System;
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
    public class LienHeController : Controller
    {
        IContactServices _services;
        public LienHeController(IContactServices services)
        {
            this._services = services;
        }
        public ActionResult Index(string _searchKey, DateTime? _formDate, DateTime? _toDate, int? _pageIndex)
        {
            ContactView result;
            result = _services.GetAll(_searchKey, _formDate, _toDate, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            return View(result.Contacts);
        }
    }
}
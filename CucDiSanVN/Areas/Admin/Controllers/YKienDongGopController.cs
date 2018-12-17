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
    public class YKienDongGopController : Controller
    {
        IFeedbackServices _services;
        public YKienDongGopController(IFeedbackServices services)
        {
            this._services = services;
        }
        public ActionResult Index(string searchKey, DateTime? toDate, DateTime? fromDate, DateTime? startDate, DateTime? endDate, int? _pageIndex)
        {
            FeedbackView result;
            result = _services.All(searchKey, fromDate, toDate, startDate, endDate, false, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(searchKey) ? string.Empty : searchKey;
            ViewBag.FromDate = fromDate?.ToString("dd/MM/yyyy") ?? null;
            ViewBag.ToDate = toDate?.ToString("dd/MM/yyyy") ?? null;
            ViewBag.StartDate = startDate?.ToString("dd/MM/yyyy") ?? null;
            ViewBag.EndDate = endDate?.ToString("dd/MM/yyyy") ?? null;
            if (result != null && result.Feedbacks.Count() > 0)
            {
                var model = result.Feedbacks;
                return View(model);
            }
            else
            {
                var model = new List<Feedback>();
                return View(model);
            }
        }

        public ActionResult Detail(int? Id)
        {
            FeedbackModel entity;
            if (Id.HasValue && Id > 0)
            {
                var model = _services.GetById(Id.Value);
                entity = new FeedbackModel
                {
                    createTime = model.createTime,
                    endDate = model.endDate.ToString("dd/MM/yyyy"),
                    feedbackBody = model.feedbackBody,
                    feedbackId = model.feedbackId,
                    feedbackName = model.feedbackName,
                    startDate = model.startDate.ToString("dd/MM/yyyy"),
                    feedbackNote = model.feedbackNote,
                    isEnd = model.isEnd,
                    isTrash = model.isTrash,
                    updateTime = model.updateTime
                };
                ViewBag.Title = "Cập nhật văn bản dự thảo";
            }
            else
            {
                entity = new FeedbackModel
                {
                    createTime = DateTime.Now,
                    updateTime = DateTime.Now,
                    isTrash = false,
                    isEnd = false
                };
                ViewBag.Title = "Thêm mới văn bản dự thảo";
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Detail(FeedbackModel entity)
        {
            if (ModelState.IsValid)
            {
                if (entity.feedbackId > 0)
                {
                    var model = _services.GetById(entity.feedbackId);
                    model.feedbackName = entity.feedbackName;
                    model.feedbackBody = entity.feedbackBody;
                    model.feedbackNote = entity.feedbackNote;
                    model.updateTime = entity.updateTime;
                    if (string.IsNullOrEmpty(entity.startDate))
                        model.startDate = DateTime.Now;
                    else
                        model.startDate = DateTime.ParseExact(entity.startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (string.IsNullOrEmpty(entity.endDate))
                        model.endDate = DateTime.Now;
                    else
                        model.endDate = DateTime.ParseExact(entity.endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    _services.Update(model);
                    _services.Save();
                }
                else
                {
                    var model = new Feedback();
                    model.feedbackBody = entity.feedbackBody;
                    model.feedbackName = entity.feedbackName;
                    model.feedbackNote = entity.feedbackNote;
                    if (string.IsNullOrEmpty(entity.startDate))
                        model.startDate = DateTime.Now;
                    else
                        model.startDate = DateTime.ParseExact(entity.startDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    if (string.IsNullOrEmpty(entity.endDate))
                        model.endDate = DateTime.Now;
                    else
                        model.endDate = DateTime.ParseExact(entity.endDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    model.createTime = DateTime.Now;
                    model.updateTime = DateTime.Now;
                    model.isEnd = false;
                    model.isTrash = false;
                    _services.Add(model);
                    _services.Save();
                }
                return RedirectToAction("Index");
            }
            return View(entity);
        }

        public ActionResult Trash(int Id)
        {
            var entity = _services.GetById(Id);
            if (entity != null && entity.isTrash == false)
            {
                entity.isTrash = true;
                _services.Update(entity);
                _services.Save();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TrashDetail(int Id)
        {
            var entity = _services.GetDetailById(Id);
            if (entity != null && entity.isTrash == false)
            {
                entity.isTrash = true;
                _services.UpdateDetail(entity);
                _services.Save();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult YKienGopY(int Id)
        {
            var entity = _services.GetById(Id);
            ViewBag.Title = "Danh sách đóng góp ý kiến";
            ViewBag.FeedbackName = entity.feedbackName;
            var entitys = _services.GetDetailByFeedbackId(Id);
            if (entitys != null)
                entitys = entitys.Where(x => x.isTrash == false);
            return View(entitys);
        }

        public ActionResult ApprovalDetail(int Id)
        {
            var entity = _services.GetDetailById(Id);
            if (entity != null && entity.isApproval == false)
            {
                entity.isApproval = true;
                _services.UpdateDetail(entity);
                _services.Save();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult UnApprovalDetail(int Id)
        {
            var entity = _services.GetDetailById(Id);
            if (entity != null && entity.isApproval == true)
            {
                entity.isApproval = false;
                _services.UpdateDetail(entity);
                _services.Save();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}
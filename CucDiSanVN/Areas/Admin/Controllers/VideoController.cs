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
using System.IO;

namespace CucDiSanVN.Areas.Admin.Controllers
{
    [Authorize]
    public class VideoController : Controller
    {
        IContentServices _services;
        IVideoServices _videoService;
        ICategoryVideoServices _categoryVideoService;
        public VideoController(ICategoryVideoServices categoryVideoService, IContentServices services, IVideoServices videoService)
        {
            this._services = services;
            this._videoService = videoService;
            this._categoryVideoService = categoryVideoService;
        }
        public ActionResult Index(string searchKey, DateTime? fromDate, DateTime? toDate, int? pageIndex)
        {
            var model = _videoService.All(searchKey, null, fromDate, false, toDate, pageIndex, 20);
            int totalPage = model?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.pageIndex = pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(searchKey) ? string.Empty : searchKey;
            ViewBag.FromDate = fromDate?.ToString("MM/dd/yyyy") ?? null;
            ViewBag.ToDate = toDate?.ToString("MM/dd/yyyy") ?? null;
            return View(model?.Videos ?? new List<Video>());
        }

        public ActionResult Add()
        {
            var model = new Video
            {
                isTrash = false,
                createTime = DateTime.Now,
                updateTime = DateTime.Now
            };
            var category = _videoService.Dropdownlist(0, model.parentId);
            ViewBag.parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Video model, HttpPostedFileBase fileVideo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (fileVideo.ContentLength > 0)
                    {
                        string _fileName = Path.GetFileName(fileVideo.FileName);
                        string _path = Path.Combine(Server.MapPath("~/FileVideo"), _fileName);
                        fileVideo.SaveAs(_path);
                        model.videoBody = _fileName;
                        _videoService.Add(model);
                        _videoService.Save();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {

                }
            }
            var category = _videoService.Dropdownlist(0, model.parentId);
            ViewBag.parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(model);
        }
        public ActionResult Update(int? id)
        {
            if (id.HasValue)
            {
                var model = _videoService.GetById(id.Value);
                var category = _videoService.Dropdownlist(0, model.parentId);
                ViewBag.parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
                return View(model);
            }
            return RedirectToAction("Add");
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Video model, HttpPostedFileBase fileVideo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (fileVideo != null && fileVideo.ContentLength > 0)
                    {
                        string _fileName = Path.GetFileName(fileVideo.FileName);
                        string _path = Path.Combine(Server.MapPath("~/FileVideo"), _fileName);
                        fileVideo.SaveAs(_path);
                        model.videoBody = _fileName;
                        model.updateTime = DateTime.Now;
                        _videoService.Update(model);
                        _videoService.Save();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        model.updateTime = DateTime.Now;
                        _videoService.Update(model);
                        _videoService.Save();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                }
            }
            var category = _videoService.Dropdownlist(0, model.parentId);
            ViewBag.parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(model);
        }

        [HttpGet]
        public ActionResult Trash(int id)
        {
            var model = _videoService.GetById(id);
            if (model != null)
            {
                model.isTrash = true;
                _videoService.Update(model);
                _videoService.Save();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CategoryVideo()
        {
            var model = _categoryVideoService.GetAll();
            return View(model);
        }

        public ActionResult DetailCategory(int? Id)
        {
            var model = new CategoryVideo();
            if (Id.HasValue && Id > 0)
            {
                model = _categoryVideoService.GetById(Id.Value);
                ViewBag.Title = "Cập nhật chuyên mục video";
            }
            else
            {
                model.isTrash = false;
                model.isSort = 0;
                ViewBag.Title = "Thêm mới chuyên mục video";
            }
            var category = _videoService.Dropdownlist(0, model.categoryId);
            ViewBag.parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DetailCategory(CategoryVideo model)
        {
            if (ModelState.IsValid)
            {
                _categoryVideoService.Add(model);
                _categoryVideoService.Save();
                return RedirectToAction("CategoryVideo");
            }
            var category = _videoService.Dropdownlist(0, model.parentId);
            ViewBag.parentId = category.Select(x => new SelectListItem { Text = x.Text, Value = x.Value.ToString() });
            return View(model);
        }

        public string _getCategoryNameById(int? Id)
        {
            if (Id.HasValue && Id > 0)
            {
                var entity = _categoryVideoService.GetById(Id.Value);
                return entity.categoryName;
            }
            return "";
        }
    }
}
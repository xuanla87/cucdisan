using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CucDiSanService.Models;
using CucDiSanService.Data;
using CucDiSanService.Services;
using CucDiSanVN.Models;
using System.Text;
using System.IO;

namespace CucDiSanVN.Controllers
{
    public class HomeController : Controller
    {
        IContentServices _services;
        ILanguageServices _languageService;
        IMenuServices _menuServices;
        IConfigSystemServices _configSystemServices;
        IVideoServices _videoServices;
        IFeedbackServices _feedbackServices;
        ICategoryVideoServices _categoryVideoServices;
        int _languageId = 1;
        public HomeController(ICategoryVideoServices categoryVideoServices, IFeedbackServices feedbackServices, IContentServices services, IMenuServices menuServices, IConfigSystemServices configSystemServices, IVideoServices videoServices, ILanguageServices languageService)
        {
            this._services = services;
            this._menuServices = menuServices;
            this._configSystemServices = configSystemServices;
            this._videoServices = videoServices;
            this._languageService = languageService;
            this._feedbackServices = feedbackServices;
            this._categoryVideoServices = categoryVideoServices;
        }
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult Detail(string pageUrl)
        {
            var entity = _services.GetByAlias(pageUrl);
            return View(entity);
        }

        public ActionResult Display(string pageUrl, int? _pageIndex)
        {
            var entity = _services.GetByAlias(pageUrl);
            if (entity != null)
                ViewBag.Title = entity.contentName;
            else
                ViewBag.Title = _configSystemServices.GetValueByKey("SiteTitle");
            return View(entity);
        }

        public ActionResult pageLeft()
        {
            return PartialView();
        }

        public ActionResult pageRight()
        {
            return PartialView();
        }

        public ActionResult getMenuMain()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            int Id = 0;
            if (_languageId == 1)
                int.TryParse(_configSystemServices.GetValueByKey("MenuMain"), out Id);
            else
                int.TryParse(_configSystemServices.GetValueByKey("MenuMainEn"), out Id);
            List<Menu> eMenus = _menuServices.GetByParent(Id).OrderBy(x => x.isSort).ToList();
            return PartialView(eMenus);
        }

        public ActionResult getMenuLeft1()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            int Id = 0;
            if (_languageId == 1)
                int.TryParse(_configSystemServices.GetValueByKey("MenuLeft1"), out Id);
            else
                int.TryParse(_configSystemServices.GetValueByKey("MenuLeft1En"), out Id);
            var entity = _menuServices.GetById(Id);
            if (entity != null)
                ViewBag.MTitle = entity.menuName;
            else
                ViewBag.MTitle = "";
            List<Menu> eMenus = _menuServices.GetByParent(Id).OrderBy(x => x.isSort).ToList();
            return PartialView(eMenus);
        }

        public ActionResult getMenuLeft2()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            int Id = 0;
            if (_languageId == 1)
                int.TryParse(_configSystemServices.GetValueByKey("MenuLeft2"), out Id);
            else
                int.TryParse(_configSystemServices.GetValueByKey("MenuLeft2En"), out Id);
            var entity = _menuServices.GetById(Id);
            if (entity != null)
                ViewBag.MTitle = entity.menuName;
            else
                ViewBag.MTitle = "";
            List<Menu> eMenus = _menuServices.GetByParent(Id).OrderBy(x => x.isSort).ToList();
            return PartialView(eMenus);
        }

        public ActionResult getMenuFooter(int? Id)
        {
            List<Menu> eMenus = _menuServices.GetByParent(Id).OrderBy(x => x.isSort).ToList();
            return PartialView(eMenus);
        }

        public ActionResult getSubMenu(int Id)
        {
            List<Menu> eMenus = _menuServices.GetByParent(Id).OrderBy(x => x.isSort).ToList();
            return PartialView(eMenus);
        }

        public ActionResult getBoxLeft(int? Id)
        {
            return View();
        }

        public ActionResult getFooterInfor()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            if (_languageId == 1)
            {
                var entity = _configSystemServices.GetValueByKey("SiteFooterInfo");
                ViewBag.FooterInFo = entity;
            }
            else
            {
                var entity = _configSystemServices.GetValueByKey("SiteFooterInfoEn");
                ViewBag.FooterInFo = entity;
            }
            return PartialView();
        }

        public ActionResult suKienQuaAnh()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            var entity = _services.getSuKienQuaAnhIsHome(_languageId);
            return PartialView(entity);
        }

        public ActionResult suKienQuaAnhItem(int Id)
        {
            var entity = _services.GetAll(null, null, null, Id, "SuKienQuaAnh", _languageId, false, null, null);
            return PartialView(entity.Contents);
        }

        public ActionResult getBannerRight()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            int Id = 0;
            if (_languageId == 1)
                int.TryParse(_configSystemServices.GetValueByKey("BannerRight"), out Id);
            else
                int.TryParse(_configSystemServices.GetValueByKey("BannerRightEn"), out Id);
            var entity = _services.GetAll(null, null, null, Id, "Banner", _languageId, false, null, null);
            return PartialView(entity.Contents.OrderBy(x => x.isSort).ToList());
        }

        public ActionResult getBannerLeft()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            int Id = 0;
            if (_languageId == 1)
                int.TryParse(_configSystemServices.GetValueByKey("BannerLeft"), out Id);
            else
                int.TryParse(_configSystemServices.GetValueByKey("BannerLeftEn"), out Id);
            var entity = _services.GetAll(null, null, null, Id, "Banner", _languageId, false, null, null);
            return PartialView(entity.Contents.ToList());
        }

        public ActionResult getAnh()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            int Id = 0;
            if (_languageId == 1)
                int.TryParse(_configSystemServices.GetValueByKey("BoxHinhAnh"), out Id);
            else
                int.TryParse(_configSystemServices.GetValueByKey("BoxHinhAnhEn"), out Id);
            var entity = _services.GetAll(null, null, null, Id, "SuKienQuaAnh", _languageId, false, null, null);
            var model = _services.GetById(Id);
            ViewBag.Url = model.contentAlias;
            return PartialView(entity.Contents.ToList());
        }

        public ActionResult getVideo()
        {
            return PartialView();
        }

        public ActionResult getCategoryIsHome()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            IEnumerable<Content> _list = _services.getCategoryIsHome(_languageId).OrderBy(x => x.isSort);
            //IEnumerable<Content> _listNew = _services.getCategoryIsHome(_languageId).Where(x => x.contentKey == "cnews").OrderBy(x => x.isSort);
            //ViewBag.ListNew = _listNew.Take(3).ToList();
            return PartialView(_list.Take(3).ToList());
        }

        public ActionResult getContentInCategoryHomeId(int Id, int Total)
        {
            IEnumerable<Content> _list = _services.getContentInCategoryIsHome(Id, Total);
            return PartialView(_list);
        }

        public ActionResult getBreadcrumb(string pageUrl)
        {
            var entity = _services.GetByAlias(pageUrl);
            if (entity != null && entity.parentId.HasValue)
            {
                var model = _services.GetById(entity.parentId.Value);
                if (model != null)
                {
                    ViewBag.PTitle = "<a href=\"" + model.contentAlias + "\">" + model.contentName + "</a> > ";
                }
            }
            return PartialView();
        }

        public ActionResult getChildDisplay(int Id, string _url, int? _pageIndex)
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            int _totalRecord = 0;
            _pageIndex = _pageIndex ?? 1;
            var entity = _services.GetAll(null, null, null, Id, null, _languageId, false, _pageIndex, 10);
            _totalRecord = entity.TotalRecord;
            ViewBag.TotalRecord = _totalRecord.ToString();
            ViewBag.TotalPage = entity.Total;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.CurentUrl = _url;
            return PartialView(entity.Contents);
        }
        public ActionResult getChildDisplay2(int Id, string _url, int? _pageIndex)
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            int _totalRecord = 0;
            _pageIndex = _pageIndex ?? 1;
            var entity = _services.GetAll(null, null, null, Id, null, _languageId, false, _pageIndex, null);
            _totalRecord = entity.TotalRecord;
            ViewBag.TotalRecord = _totalRecord.ToString();
            ViewBag.TotalPage = entity.Total;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.CurentUrl = _url;
            return PartialView(entity.Contents);
        }

        public ActionResult getVideoIsHome()
        {
            var entity = _videoServices.GetIsHome();
            return PartialView(entity);
        }

        public ActionResult VideoAll(int? Id, int? _pageIndex)
        {
            if (Id.HasValue && Id > 0)
            {
                var model = _categoryVideoServices.GetById(Id.GetValueOrDefault());
                ViewBag.Title = model.categoryName;
                ViewBag.Breadcrumb = "<a href=\"video-clip/" + Id + "\">Danh sách video</a> > " + model.categoryName;
                ViewBag.CurentUrl = "video-clip/" + Id;
            }
            else
            {
                ViewBag.CurentUrl = "video-clip";
                ViewBag.Title = "Danh sách video";

            }
            int _totalRecord = 0;
            var entity = _videoServices.All(null, Id, null, false, null, _pageIndex, 18);
            _pageIndex = _pageIndex ?? 1;
            _totalRecord = entity.TotalRecord;
            ViewBag.TotalRecord = _totalRecord.ToString();
            ViewBag.TotalPage = entity.Total;
            ViewBag.PageIndex = _pageIndex ?? 1;
            return View(entity.Videos);
        }

        public ActionResult VideoDetail(int Id)
        {
            var model = _videoServices.GetById(Id);
            ViewBag.Title = model.videoTitle;
            var _c = _categoryVideoServices.GetById(model.parentId ?? 0);
            if (_c != null)
                ViewBag.Breadcrumb = "<a href=\"video-clip/" + _c.categoryId + "\">" + _c.categoryName + "</a> > " + model.videoTitle;
            else
                ViewBag.Breadcrumb = "<a href=\"video-clip\">Danh sách video</a> > " + model.videoTitle;
            return View(model);
        }

        public ActionResult _HitCounter()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            HitCounterEntity db = new HitCounterEntity();
            int TotalOnline = 0;
            int TotalYesterday = 0;
            int TotalMonth = 0;
            int Total = 0;
            var _hit = db.Visitors.ToList();
            TotalOnline = (int)HttpContext.Application["Totaluser"];
            TotalYesterday = _hit.Where(x => x.visitTime <= DateTime.Now && x.visitTime >= DateTime.Now.Date).Count();
            TotalMonth = _hit.Where(x => x.visitTime.Year == DateTime.Now.Year && x.visitTime.Month == DateTime.Now.Month).Count();
            Total = _hit.Count();
            ViewBag.TotalOnline = TotalOnline.ToString("N0");
            ViewBag.TotalYesterday = TotalYesterday.ToString("N0"); ;
            ViewBag.TotalMonth = TotalMonth.ToString("N0");
            ViewBag.Total = Total.ToString("N0");
            ViewBag.LaguageId = _languageId;
            return PartialView();
        }

        public ActionResult _fixAlias()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            var _all = _services.GetAll(null, null, null, null, null, _languageId, null, null, null);
            var _content = _all.Contents.ToList();
            for (int i = 0; i < _content.Count; i++)
            {
                if (!_content[i].contentAlias.Contains("-" + _content[i].contentId))
                {
                    _content[i].contentAlias = _content[i].contentAlias + "-" + _content[i].contentId;
                    _services.Update(_content[i]);
                    _services.Save();
                }
            }
            return View();
        }

        public ActionResult _getLanguage()
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            ViewBag.LanguageId = _languageId;
            return PartialView();
        }

        public ActionResult _setLanguage(int _languageId)
        {
            Session["languageId"] = _languageId;
            return Redirect("/");
        }

        public ActionResult YKienDongGop(string _searchKey, int? _pageIndex)
        {
            var entitys = _feedbackServices.All(null, null, null, null, null, false, false, null, null);
            ViewBag.TotalRecord = entitys.TotalRecord;
            ViewBag.Entity = entitys.Feedbacks.ToList();
            var entityEnd = _feedbackServices.All(_searchKey, null, null, null, null, true, false, _pageIndex, 10);
            ViewBag.TotalRecordEnd = entityEnd.TotalRecord;
            ViewBag.TotalPage = entityEnd.Total;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = _searchKey;
            return View(entityEnd.Feedbacks);
        }

        public ActionResult YKienDongGopDetail(int Id)
        {
            var entity = _feedbackServices.GetById(Id);
            ViewBag.Title = entity.feedbackName;
            ViewBag.StartDate = entity.startDate.ToString("dd-MM-yyyy");
            ViewBag.EndDate = entity.endDate.ToString("dd-MM-yyyy");
            ViewBag.End = entity.isEnd;
            ViewBag.FeedbackId = entity.feedbackId;
            ViewBag.Note = entity.feedbackNote;
            ViewBag.Content = entity.feedbackBody;
            var model = _feedbackServices.GetDetailByFeedbackId(Id);
            if (model != null)
                model = model.Where(x => x.isTrash == false && x.isApproval == true);
            ViewBag.ListFile = model.ToList();
            DongGopYKienModel enYKien = new DongGopYKienModel();
            enYKien.feedbackId = Id;
            Session["CAPTCHA"] = GetRandomText();
            return View(enYKien);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult YKienDongGopDetail(DongGopYKienModel model, HttpPostedFileBase FileAtachment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string _captcha = Session["CAPTCHA"].ToString();
                    if (_captcha.ToLower() == model.CaptCha.ToLower())
                    {
                        if (FileAtachment != null && FileAtachment.ContentLength > 0)
                        {
                            string _fileName = Path.GetFileName(FileAtachment.FileName);
                            bool exists = System.IO.Directory.Exists(Server.MapPath("~/FileAtachment"));
                            if (!exists)
                                System.IO.Directory.CreateDirectory(Server.MapPath("~/FileAtachment"));
                            string _path = Path.Combine(Server.MapPath("~/FileAtachment"), _fileName);
                            FileAtachment.SaveAs(_path);
                            var entity = new FeedbackDetail();
                            entity.fileAttachment = _fileName;
                            entity.feedbackContent = model.Body;
                            entity.feedbackId = model.feedbackId;
                            entity.fullName = model.FullName;
                            entity.email = model.Email;
                            entity.address = model.Add;
                            entity.phone = model.Phone;
                            entity.isTrash = false;
                            entity.isApproval = false;
                            entity.createTime = DateTime.Now;
                            _feedbackServices.AddDetail(entity);
                            _feedbackServices.Save();
                            return RedirectToAction("YKienDongGopDetail", new { Id = model.feedbackId });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mã bảo mật không đúng!");
                    }
                }
                catch (Exception ex)
                {
                }
            }
            var entitys = _feedbackServices.GetById(model.feedbackId);
            ViewBag.Title = entitys.feedbackName;
            ViewBag.StartDate = entitys.startDate.ToString("dd-MM-yyyy");
            ViewBag.EndDate = entitys.endDate.ToString("dd-MM-yyyy");
            ViewBag.End = entitys.isEnd;
            ViewBag.FeedbackId = entitys.feedbackId;
            var models = _feedbackServices.GetDetailByFeedbackId(model.feedbackId);
            if (models != null)
                models = models.Where(x => x.isTrash == false && x.isApproval == true);
            ViewBag.ListFile = models.ToList();
            return View(model);
        }

        public string getFileName(string _linkFile)
        {
            string[] _list = _linkFile.Split('/');
            if (_list.Length > 0)
                return _list[_list.Length - 1];
            return _linkFile;
        }

        private string GetRandomText()
        {
            StringBuilder randomText = new StringBuilder();
            string alphabets = "012345679ACEFGHKLMNPRSWXZabcdefghijkhlmnopqrstuvwxyz";
            Random r = new Random();
            for (int j = 0; j < 4; j++)
            {
                randomText.Append(alphabets[r.Next(alphabets.Length)]);
            }
            return randomText.ToString();
        }

        public FileResult GetCaptchaImage()
        {
            string text = Session["CAPTCHA"].ToString();
            MemoryStream ms = new MemoryStream();
            RandomImage _captcha = new RandomImage(text, 220, 50);
            _captcha.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            _captcha.Dispose();
            return File(ms.ToArray(), "image/png");
        }

        public ActionResult FromDongGop(int feedbackId)
        {
            DongGopYKienModel model = new DongGopYKienModel();
            model.feedbackId = feedbackId;
            Session["CAPTCHA"] = GetRandomText();
            return PartialView(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult FromDongGop(DongGopYKienModel model, HttpPostedFileBase FileAtachment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string _captcha = Session["CAPTCHA"].ToString();
                    if (_captcha.ToLower() == model.CaptCha.ToLower())
                    {
                        if (FileAtachment != null && FileAtachment.ContentLength > 0)
                        {
                            string _fileName = Path.GetFileName(FileAtachment.FileName);
                            string _path = Path.Combine(Server.MapPath("~/FileAtachment"), _fileName);
                            FileAtachment.SaveAs(_path);
                            var entity = new FeedbackDetail();
                            entity.fileAttachment = _fileName;
                            entity.feedbackContent = model.Body;
                            entity.feedbackId = model.feedbackId;
                            entity.fullName = model.FullName;
                            entity.email = model.Email;
                            entity.address = model.Add;
                            entity.phone = model.Phone;
                            entity.isTrash = false;
                            entity.isApproval = false;
                            entity.createTime = DateTime.Now;
                            _feedbackServices.AddDetail(entity);
                            _feedbackServices.Save();
                            return RedirectToAction("YKienDongGopDetail", new { Id = model.feedbackId });
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mã bảo mật không đúng!");
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return RedirectToAction("YKienDongGopDetail", new { Id = model.feedbackId });
        }

        public ActionResult ViewVanBan(int Id, string _url, int? _pageIndex)
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            int _totalRecord = 0;
            _pageIndex = _pageIndex ?? 1;
            var entity = _services.GetAll(null, null, null, Id, "Document", _languageId, false, _pageIndex, 10);
            _totalRecord = entity.TotalRecord;
            ViewBag.TotalRecord = _totalRecord.ToString();
            ViewBag.TotalPage = entity.Total;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.CurentUrl = _url;
            var entitys = _services.GetAll(null, null, null, Id, "cvanbanphapluat", _languageId, false, null, null);
            ViewBag.ListItem = entitys.Contents.ToList();
            return PartialView(entity.Contents);
        }

        public ActionResult TraCuuVanBan(string _Name, string _No, DateTime? _NgayBanHanh, int? _pageIndex)
        {
            try
            {
                _languageId = (int)Session["languageId"];
            }
            catch
            {
            }
            int _totalRecord = 0;
            _pageIndex = _pageIndex ?? 1;
            var entity = _services.TraCuuVanBan(_Name, _No, _NgayBanHanh, _languageId, _pageIndex, 10);
            _totalRecord = entity.TotalRecord;
            ViewBag.TotalRecord = _totalRecord.ToString();
            ViewBag.TotalPage = entity.Total;
            ViewBag.PageIndex = _pageIndex ?? 1;
            return View(entity.Contents);
        }
    }
}
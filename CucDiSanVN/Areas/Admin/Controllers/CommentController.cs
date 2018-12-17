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
    public class CommentController : Controller
    {
        ICommentServices _services;
        IContentServices _contentService;
        public CommentController(ICommentServices services, IContentServices contentService)
        {
            this._services = services;
            this._contentService = contentService;
        }
        public ActionResult Index(string _searchKey, DateTime? _formDate, DateTime? _toDate, int? _pageIndex)
        {
            CommentView result;
            result = _services.GetAll(_searchKey, _formDate, _toDate, false, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            if (result != null && result.Comments.Count() > 0)
            {
                var model = result.Comments.Select(x => new modelComment
                {
                    commentBody = x.commentBody,
                    commentEmail = x.commentEmail,
                    commentFullName = x.commentFullName,
                    commentId = x.commentId,
                    commentPhone = x.commentPhone,
                    commentTime = x.commentTime,
                    commentTitle = x.commentTitle,
                    contentId = x.contentId,
                    contentName = _contentService.GetNameById(x.contentId),
                    isTrash = x.isTrash
                });
                return View(model);
            }
            else
            {
                var model = new List<modelComment>();
                return View(model);
            }
        }

        public ActionResult AllTrash(string _searchKey, DateTime? _formDate, DateTime _toDate, int? _pageIndex)
        {
            CommentView result;
            result = _services.GetAll(_searchKey, _formDate, _toDate, true, _pageIndex, 20);
            int totalPage = result?.Total ?? 0;
            ViewBag.TotalPage = totalPage;
            ViewBag.PageIndex = _pageIndex ?? 1;
            ViewBag.SearchKey = string.IsNullOrWhiteSpace(_searchKey) ? string.Empty : _searchKey;
            if (result != null && result.Comments.Count() > 0)
            {
                var model = result.Comments.Select(x => new modelComment
                {
                    commentBody = x.commentBody,
                    commentEmail = x.commentEmail,
                    commentFullName = x.commentFullName,
                    commentId = x.commentId,
                    commentPhone = x.commentPhone,
                    commentTime = x.commentTime,
                    commentTitle = x.commentTitle,
                    contentId = x.contentId,
                    contentName = _contentService.GetNameById(x.contentId),
                    isTrash = x.isTrash
                });
                return View(model);
            }
            else
            {
                var model = new List<modelComment>();
                return View(model);
            }
        }
    }
}
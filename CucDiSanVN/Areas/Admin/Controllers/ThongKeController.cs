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
    public class ThongKeController : Controller
    {
        IVisitorServices _visitorServices;
        IContentServices _contentServices;
        IVideoServices _videoServices;

        public ThongKeController(IVisitorServices visitorServices, IContentServices contentServices, IVideoServices videoServices)
        {
            _visitorServices = visitorServices;
            _contentServices = contentServices;
            _videoServices = videoServices;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThongKeTheoThangTrongNam(string _nam)
        {
            return View();
        }

        public ActionResult ThongKeTheoTungNam(int? fromYear, int? toYear)
        {
            List<int> _listYear = new List<int>();
            for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year; i++)
            {
                _listYear.Add(i);
            }
            ViewBag.fromYear = _listYear.Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() });
            ViewBag.toYear = _listYear.Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() });
            List<modelThongKeSoLuongTinTheoCacNam> _List = new List<modelThongKeSoLuongTinTheoCacNam>();
            var model = _contentServices.All();
            var modelVideo = _videoServices.GetAll();
            modelVideo = modelVideo.Where(x => x.isTrash == false);
            model = model.Where(x => x.isTrash == false);
            if (fromYear.HasValue && toYear.HasValue)
            {
                if (toYear > fromYear)
                {
                    for (int i = fromYear.Value; i <= toYear.Value; i++)
                    {
                        model = model.Where(x => x.createTime.Year == i);
                        modelThongKeSoLuongTinTheoCacNam _item = new modelThongKeSoLuongTinTheoCacNam();
                        _item.Nam = i;
                        _item.Tin = model.Where(x => x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa").Count();
                        _item.Video = modelVideo.Where(x => x.createTime.Year == i).Count();
                        _item.Logo = _item.VanBan = model.Where(x => x.contentKey == "Banner").Count();
                        _item.VanBan = model.Where(x => x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document").Count(); ;
                        _item.Khac = 0;
                        _item.Toatal = _item.Tin + _item.Video + _item.Logo + _item.VanBan + _item.Khac;
                        _List.Add(_item);
                    }
                }
                else
                {
                    for (int i = toYear.Value; i <= fromYear.Value; i++)
                    {
                        model = model.Where(x => x.createTime.Year == i);
                        modelThongKeSoLuongTinTheoCacNam _item = new modelThongKeSoLuongTinTheoCacNam();
                        _item.Nam = i;
                        _item.Toatal = model.Count();
                        _List.Add(_item);
                    }
                }
            }
            return View(_List);
        }

        public ActionResult ThongKeTheoChuyenMuc(string _thang, string _quy, string _nam)
        {
            return View();
        }

        public ActionResult ThongKeTheoMotChuyenMuc(string _ngayBatDau, string _ngayKetThu, int _chuyenMuc)
        {
            return View();
        }

        public ActionResult ThongKeLuongTruyCapCacNam(int? fromYear, int? toYear)
        {
            List<int> _listYear = new List<int>();
            for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year; i++)
            {
                _listYear.Add(i);
            }
            ViewBag.fromYear = _listYear.Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() });
            ViewBag.toYear = _listYear.Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() });
            List<modelThongKeTruyCapCacNam> _List = new List<modelThongKeTruyCapCacNam>();
            var model = _visitorServices.GetAll();
            if (fromYear.HasValue && toYear.HasValue)
            {
                if (toYear > fromYear)
                {
                    for (int i = fromYear.Value; i <= toYear.Value; i++)
                    {
                        model = model.Where(x => x.visitTime.Year == i);
                        modelThongKeTruyCapCacNam _item = new modelThongKeTruyCapCacNam();
                        _item.Nam = i;
                        _item.Thang1 = model.Where(x => x.visitTime.Month == 1).Count();
                        _item.Thang2 = model.Where(x => x.visitTime.Month == 2).Count();
                        _item.Thang3 = model.Where(x => x.visitTime.Month == 3).Count();
                        _item.Thang4 = model.Where(x => x.visitTime.Month == 4).Count();
                        _item.Thang5 = model.Where(x => x.visitTime.Month == 5).Count();
                        _item.Thang6 = model.Where(x => x.visitTime.Month == 6).Count();
                        _item.Thang7 = model.Where(x => x.visitTime.Month == 7).Count();
                        _item.Thang8 = model.Where(x => x.visitTime.Month == 8).Count();
                        _item.Thang9 = model.Where(x => x.visitTime.Month == 9).Count();
                        _item.Thang10 = model.Where(x => x.visitTime.Month == 10).Count();
                        _item.Thang11 = model.Where(x => x.visitTime.Month == 11).Count();
                        _item.Thang12 = model.Where(x => x.visitTime.Month == 12).Count();
                        _item.Toatal = model.Count();
                        _List.Add(_item);
                    }
                }
                else
                {
                    for (int i = toYear.Value; i <= fromYear.Value; i++)
                    {
                        model = model.Where(x => x.visitTime.Year == i);
                        modelThongKeTruyCapCacNam _item = new modelThongKeTruyCapCacNam();
                        _item.Nam = i;
                        _item.Thang1 = model.Where(x => x.visitTime.Month == 1).Count();
                        _item.Thang2 = model.Where(x => x.visitTime.Month == 2).Count();
                        _item.Thang3 = model.Where(x => x.visitTime.Month == 3).Count();
                        _item.Thang4 = model.Where(x => x.visitTime.Month == 4).Count();
                        _item.Thang5 = model.Where(x => x.visitTime.Month == 5).Count();
                        _item.Thang6 = model.Where(x => x.visitTime.Month == 6).Count();
                        _item.Thang7 = model.Where(x => x.visitTime.Month == 7).Count();
                        _item.Thang8 = model.Where(x => x.visitTime.Month == 8).Count();
                        _item.Thang9 = model.Where(x => x.visitTime.Month == 9).Count();
                        _item.Thang10 = model.Where(x => x.visitTime.Month == 10).Count();
                        _item.Thang11 = model.Where(x => x.visitTime.Month == 11).Count();
                        _item.Thang12 = model.Where(x => x.visitTime.Month == 12).Count();
                        _item.Toatal = model.Count();
                        _List.Add(_item);
                    }
                }
            }
            return View(_List);
        }

        public ActionResult ThongKeSoLuongTrongDanhMucDiSanHienCo()
        {
            return View();
        }
    }
}
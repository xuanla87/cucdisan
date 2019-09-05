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

        public ActionResult ThongKeTheoThangTrongNam(int? curentYear)
        {
            List<int> _listYear = new List<int>();
            for (int i = DateTime.Now.Year - 10; i <= DateTime.Now.Year; i++)
            {
                _listYear.Add(i);
            }
            ViewBag.curentYear = _listYear.Select(x => new SelectListItem { Text = x.ToString(), Value = x.ToString() });
            var model = _contentServices.All();
            var modelVideo = _videoServices.GetAll();
            modelVideo = modelVideo.Where(x => x.isTrash == false);
            model = model.Where(x => x.isTrash == false);
            List<modelThongKeTinTrongNam> _List = new List<modelThongKeTinTrongNam>();
            ViewBag.Year = curentYear;
            if (curentYear.HasValue)
            {
                model = model.Where(x => x.createTime.Year == curentYear);
                modelVideo = modelVideo.Where(x => x.createTime.Year == curentYear);

                //Tin
                modelThongKeTinTrongNam _item = new modelThongKeTinTrongNam();
                _item.LoaiThongTin = "Tin";
                _item.Thang1 = model.Where(x => x.createTime.Month == 1 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang2 = model.Where(x => x.createTime.Month == 2 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang3 = model.Where(x => x.createTime.Month == 3 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang4 = model.Where(x => x.createTime.Month == 4 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang5 = model.Where(x => x.createTime.Month == 5 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang6 = model.Where(x => x.createTime.Month == 6 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang7 = model.Where(x => x.createTime.Month == 7 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang8 = model.Where(x => x.createTime.Month == 8 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang9 = model.Where(x => x.createTime.Month == 9 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang10 = model.Where(x => x.createTime.Month == 10 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang11 = model.Where(x => x.createTime.Month == 11 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Thang12 = model.Where(x => x.createTime.Month == 12 && (x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa")).Count();
                _item.Toatal = _item.Thang1 + _item.Thang2 + _item.Thang3 + _item.Thang4 + _item.Thang5 + _item.Thang6 + _item.Thang7 + _item.Thang8 + _item.Thang9 + _item.Thang10 + _item.Thang11 + _item.Thang12;
                _List.Add(_item);

                //Anh
                _item = new modelThongKeTinTrongNam();
                _item.LoaiThongTin = "Ảnh";
                _item.Thang1 = model.Where(x => x.createTime.Month == 1 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang2 = model.Where(x => x.createTime.Month == 2 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang3 = model.Where(x => x.createTime.Month == 3 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang4 = model.Where(x => x.createTime.Month == 4 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang5 = model.Where(x => x.createTime.Month == 5 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang6 = model.Where(x => x.createTime.Month == 6 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang7 = model.Where(x => x.createTime.Month == 7 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang8 = model.Where(x => x.createTime.Month == 8 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang9 = model.Where(x => x.createTime.Month == 9 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang10 = model.Where(x => x.createTime.Month == 10 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang11 = model.Where(x => x.createTime.Month == 11 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Thang12 = model.Where(x => x.createTime.Month == 12 && x.contentKey == "SuKienQuaAnh").Count();
                _item.Toatal = _item.Thang1 + _item.Thang2 + _item.Thang3 + _item.Thang4 + _item.Thang5 + _item.Thang6 + _item.Thang7 + _item.Thang8 + _item.Thang9 + _item.Thang10 + _item.Thang11 + _item.Thang12;
                _List.Add(_item);

                //Phim
                _item = new modelThongKeTinTrongNam();
                _item.LoaiThongTin = "Phim";
                _item.Thang1 = modelVideo.Where(x => x.createTime.Month == 1).Count();
                _item.Thang2 = modelVideo.Where(x => x.createTime.Month == 2).Count();
                _item.Thang3 = modelVideo.Where(x => x.createTime.Month == 3).Count();
                _item.Thang4 = modelVideo.Where(x => x.createTime.Month == 4).Count();
                _item.Thang5 = modelVideo.Where(x => x.createTime.Month == 5).Count();
                _item.Thang6 = modelVideo.Where(x => x.createTime.Month == 6).Count();
                _item.Thang7 = modelVideo.Where(x => x.createTime.Month == 7).Count();
                _item.Thang8 = modelVideo.Where(x => x.createTime.Month == 8).Count();
                _item.Thang9 = modelVideo.Where(x => x.createTime.Month == 9).Count();
                _item.Thang10 = modelVideo.Where(x => x.createTime.Month == 10).Count();
                _item.Thang11 = modelVideo.Where(x => x.createTime.Month == 11).Count();
                _item.Thang12 = modelVideo.Where(x => x.createTime.Month == 12).Count();
                _item.Toatal = _item.Thang1 + _item.Thang2 + _item.Thang3 + _item.Thang4 + _item.Thang5 + _item.Thang6 + _item.Thang7 + _item.Thang8 + _item.Thang9 + _item.Thang10 + _item.Thang11 + _item.Thang12;
                _List.Add(_item);

                //Logo/Banner
                _item = new modelThongKeTinTrongNam();
                _item.LoaiThongTin = "Logo/Banner";
                _item.Thang1 = model.Where(x => x.createTime.Month == 1 && x.contentKey == "Banner").Count();
                _item.Thang2 = model.Where(x => x.createTime.Month == 2 && x.contentKey == "Banner").Count();
                _item.Thang3 = model.Where(x => x.createTime.Month == 3 && x.contentKey == "Banner").Count();
                _item.Thang4 = model.Where(x => x.createTime.Month == 4 && x.contentKey == "Banner").Count();
                _item.Thang5 = model.Where(x => x.createTime.Month == 5 && x.contentKey == "Banner").Count();
                _item.Thang6 = model.Where(x => x.createTime.Month == 6 && x.contentKey == "Banner").Count();
                _item.Thang7 = model.Where(x => x.createTime.Month == 7 && x.contentKey == "Banner").Count();
                _item.Thang8 = model.Where(x => x.createTime.Month == 8 && x.contentKey == "Banner").Count();
                _item.Thang9 = model.Where(x => x.createTime.Month == 9 && x.contentKey == "Banner").Count();
                _item.Thang10 = model.Where(x => x.createTime.Month == 10 && x.contentKey == "Banner").Count();
                _item.Thang11 = model.Where(x => x.createTime.Month == 11 && x.contentKey == "Banner").Count();
                _item.Thang12 = model.Where(x => x.createTime.Month == 12 && x.contentKey == "Banner").Count();
                _item.Toatal = _item.Thang1 + _item.Thang2 + _item.Thang3 + _item.Thang4 + _item.Thang5 + _item.Thang6 + _item.Thang7 + _item.Thang8 + _item.Thang9 + _item.Thang10 + _item.Thang11 + _item.Thang12;

                _List.Add(_item);
                //Văn bản
                _item = new modelThongKeTinTrongNam();
                _item.LoaiThongTin = "Văn bản";
                _item.Thang1 = model.Where(x => x.createTime.Month == 1 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang2 = model.Where(x => x.createTime.Month == 2 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang3 = model.Where(x => x.createTime.Month == 3 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang4 = model.Where(x => x.createTime.Month == 4 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang5 = model.Where(x => x.createTime.Month == 5 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang6 = model.Where(x => x.createTime.Month == 6 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang7 = model.Where(x => x.createTime.Month == 7 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang8 = model.Where(x => x.createTime.Month == 8 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang9 = model.Where(x => x.createTime.Month == 9 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang10 = model.Where(x => x.createTime.Month == 10 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang11 = model.Where(x => x.createTime.Month == 11 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Thang12 = model.Where(x => x.createTime.Month == 12 && (x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document")).Count();
                _item.Toatal = _item.Thang1 + _item.Thang2 + _item.Thang3 + _item.Thang4 + _item.Thang5 + _item.Thang6 + _item.Thang7 + _item.Thang8 + _item.Thang9 + _item.Thang10 + _item.Thang11 + _item.Thang12;
                _List.Add(_item);
                //Khác
                _item = new modelThongKeTinTrongNam();
                _item.LoaiThongTin = "Khác";
                _item.Thang1 = 0;
                _item.Thang2 = 0;
                _item.Thang3 = 0;
                _item.Thang4 = 0;
                _item.Thang5 = 0;
                _item.Thang6 = 0;
                _item.Thang7 = 0;
                _item.Thang8 = 0;
                _item.Thang9 = 0;
                _item.Thang10 = 0;
                _item.Thang11 = 0;
                _item.Thang12 = 0;
                _item.Toatal = 0;
                _List.Add(_item);
            }
            return View(_List);
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
                        _item.Anh = model.Where(x => x.contentKey == "SuKienQuaAnh").Count();
                        _item.Logo = model.Where(x => x.contentKey == "Banner").Count();
                        _item.VanBan = model.Where(x => x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document").Count(); ;
                        _item.Khac = 0;
                        _item.Toatal = _item.Tin + _item.Video + _item.Logo + _item.VanBan + _item.Khac + _item.Anh;
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
                        _item.Tin = model.Where(x => x.contentKey == "News" || x.contentKey == "DiSanVanHoa" || x.contentKey == "Thongtindisanvanhoa").Count();
                        _item.Video = modelVideo.Where(x => x.createTime.Year == i).Count();
                        _item.Anh = model.Where(x => x.contentKey == "SuKienQuaAnh").Count();
                        _item.Logo = model.Where(x => x.contentKey == "Banner").Count();
                        _item.VanBan = model.Where(x => x.contentKey == "AnPhamTaiLieu" || x.contentKey == "Duthaovanbanphapluat" || x.contentKey == "TTHC" || x.contentKey == "Document").Count(); ;
                        _item.Khac = 0;
                        _item.Toatal = _item.Tin + _item.Video + _item.Logo + _item.VanBan + _item.Khac + _item.Anh;
                        _List.Add(_item);
                    }
                }
            }
            return View(_List);
        }

        public ActionResult ThongKeTheoChuyenMucThang(int? fromMonth, int? fromYear)
        {
            return View();
        }

        public ActionResult ThongKeTheoChuyenMucQuy(int? fromQuy, int? fromYear)
        {
            return View();
        }

        public ActionResult ThongKeTheoChuyenMucNam(int? fromYear)
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
            var model = _contentServices.All();
            var model2 = model.Where(x => x.contentKey == "cdisanvanhoa" || x.contentKey == "cthongtindisanvanhoa");
            IEnumerable<modelThongKeSoLuongDanhMucDiSanVanHoa> _list = model2.Select(x => new modelThongKeSoLuongDanhMucDiSanVanHoa
            {
                Name = x.contentName,
                SoLuong = model.Where(y => y.parentId == x.contentId && (y.contentKey == "Thongtindisanvanhoa" || x.contentKey == "DiSanVanHoa")).Count()
            });
            return View(_list);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using everTrucking_Web.Code.DTO;
using everTrucking_Web.Code.BUS;
using everTrucking_Web.Code;
namespace everTrucking_Web.Controllers
{
    public class KeHoachVanTaiController : Controller
    {
        // GET: KeHoachVanTai
        [HttpGet]
        public ActionResult Index(listChungTuRequest model)
        {
            DataTable dtDanhMucKhachHang = Code.BUS.DanhMucKhachHangBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongKhachHang, null);
            GlobalVariables.listKhachHang = new List<DanhMucKhachHang>();

            GlobalVariables.listKhachHang.Add(new DanhMucKhachHang()
            {
                ID = null,
                Ma = null,
                Ten = "Tất cả",
            });

            foreach (DataRow drKhachHang in dtDanhMucKhachHang.Rows)
            {
                GlobalVariables.listKhachHang.Add(new DanhMucKhachHang()
                {
                    ID = drKhachHang["ID"].ToString(),
                    Ma = drKhachHang["Ma"].ToString(),
                    Ten = drKhachHang["Ten"].ToString(),
                });
            }
            //
            model.TuNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("dd/MM/yyyy");
            model.DenNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("dd/MM/yyyy");

            DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.ListDisplay(Code.GlobalVariables.IDDanhMucChungTuKeHoachVanTai, new DateTime(Int16.Parse(model.TuNgay.Substring(6, 4)), Int16.Parse(model.TuNgay.Substring(3, 2)), Int16.Parse(model.TuNgay.Substring(0, 2))), new DateTime(Int16.Parse(model.DenNgay.Substring(6, 4)), Int16.Parse(model.DenNgay.Substring(3, 2)), Int16.Parse(model.DenNgay.Substring(0, 2))), null, null);
            List<ctKeHoachVanTai> listKeHoachVanTai = new List<ctKeHoachVanTai>();
            foreach(DataRow drKeHoachVanTai in dtKeHoachVanTai.Rows)
            {
                listKeHoachVanTai.Add(new ctKeHoachVanTai()
                {
                    ID = drKeHoachVanTai["ID"].ToString(),
                    So = drKeHoachVanTai["So"].ToString(),
                    NgayLap = drKeHoachVanTai["NgayLap"].ToString(),
                    TenLoaiHinh = drKeHoachVanTai["TenLoaiHinh"].ToString(),
                    TenLoaiHang = drKeHoachVanTai["TenLoaiHang"].ToString(),
                    TenDanhMucKhachHang = drKeHoachVanTai["TenDanhMucKhachHang"].ToString(),
                    TenDanhMucDiaDiemNangCont = drKeHoachVanTai["TenDanhMucDiaDiemNangCont"].ToString(),
                    NgayNangCont = drKeHoachVanTai["NgayNangCont"].ToString(),
                    TenDanhMucDiaDiemHaCont = drKeHoachVanTai["TenDanhMucDiaDiemHaCont"].ToString(),
                    NgayHaCont = drKeHoachVanTai["NgayHaCont"].ToString(),
                    TenDanhMucDiaDiemDongHang = drKeHoachVanTai["TenDanhMucDiaDiemDongHang"].ToString(),
                    NgayDongHang = drKeHoachVanTai["NgayDongHang"].ToString(),
                    TenDanhMucDiaDiemTraHang = drKeHoachVanTai["TenDanhMucDiaDiemTraHang"].ToString(),
                    NgayTraHang = drKeHoachVanTai["NgayTraHang"].ToString(),
                });
            }    
            ViewBag.ListKhachHang = GlobalVariables.listKhachHang;
            ViewBag.ListKeHoachVanTai = listKeHoachVanTai;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IndexPost(listChungTuRequest model)
        {
            //DataTable dtDanhMucKhachHang = Code.BUS.DanhMucKhachHangBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongKhachHang, null);
            //List<DanhMucKhachHang> listKhachHang = new List<DanhMucKhachHang>();

            //listKhachHang.Add(new DanhMucKhachHang()
            //{
            //    ID = null,
            //    Ma = null,
            //    Ten = "Tất cả",
            //});

            //foreach (DataRow drKhachHang in dtDanhMucKhachHang.Rows)
            //{
            //    listKhachHang.Add(new DanhMucKhachHang()
            //    {
            //        ID = drKhachHang["ID"].ToString(),
            //        Ma = drKhachHang["Ma"].ToString(),
            //        Ten = drKhachHang["Ten"].ToString(),
            //    });
            //}
            //
            //model.TuNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("dd/MM/yyyy");
            //model.DenNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("dd/MM/yyyy");

            DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.ListDisplay(Code.GlobalVariables.IDDanhMucChungTuKeHoachVanTai, new DateTime(Int16.Parse(model.TuNgay.Substring(6, 4)), Int16.Parse(model.TuNgay.Substring(3, 2)), Int16.Parse(model.TuNgay.Substring(0, 2))), new DateTime(Int16.Parse(model.DenNgay.Substring(6, 4)), Int16.Parse(model.DenNgay.Substring(3, 2)), Int16.Parse(model.DenNgay.Substring(0, 2))), model.IDDanhMucKhachHang, null);
            List<ctKeHoachVanTai> listKeHoachVanTai = new List<ctKeHoachVanTai>();
            if (dtKeHoachVanTai.Rows.Count > 0)
            {
                foreach (DataRow drKeHoachVanTai in dtKeHoachVanTai.Rows)
                {
                    listKeHoachVanTai.Add(new ctKeHoachVanTai()
                    {
                        ID = drKeHoachVanTai["ID"].ToString(),
                        So = drKeHoachVanTai["So"].ToString(),
                        NgayLap = drKeHoachVanTai["NgayLap"].ToString(),
                        TenLoaiHinh = drKeHoachVanTai["TenLoaiHinh"].ToString(),
                        TenLoaiHang = drKeHoachVanTai["TenLoaiHang"].ToString(),
                        TenDanhMucKhachHang = drKeHoachVanTai["TenDanhMucKhachHang"].ToString(),
                        TenDanhMucDiaDiemNangCont = drKeHoachVanTai["TenDanhMucDiaDiemNangCont"].ToString(),
                        NgayNangCont = drKeHoachVanTai["NgayNangCont"].ToString(),
                        TenDanhMucDiaDiemHaCont = drKeHoachVanTai["TenDanhMucDiaDiemHaCont"].ToString(),
                        NgayHaCont = drKeHoachVanTai["NgayHaCont"].ToString(),
                        TenDanhMucDiaDiemDongHang = drKeHoachVanTai["TenDanhMucDiaDiemDongHang"].ToString(),
                        NgayDongHang = drKeHoachVanTai["NgayDongHang"].ToString(),
                        TenDanhMucDiaDiemTraHang = drKeHoachVanTai["TenDanhMucDiaDiemTraHang"].ToString(),
                        NgayTraHang = drKeHoachVanTai["NgayTraHang"].ToString(),
                    });
                }
            }
            else
            {
                listKeHoachVanTai.Add(new ctKeHoachVanTai()
                {
                    ID = "-1",
                    So = string.Empty,
                    NgayLap = string.Empty,
                    TenLoaiHinh = string.Empty,
                    TenLoaiHang = string.Empty,
                    TenDanhMucKhachHang = string.Empty,
                    TenDanhMucDiaDiemNangCont = string.Empty,
                    NgayNangCont = string.Empty,
                    TenDanhMucDiaDiemHaCont = string.Empty,
                    NgayHaCont = string.Empty,
                    TenDanhMucDiaDiemDongHang = string.Empty,
                    NgayDongHang = string.Empty,
                    TenDanhMucDiaDiemTraHang = string.Empty,
                    NgayTraHang = string.Empty,
                });
            }    
            ViewBag.ListKhachHang = GlobalVariables.listKhachHang;
            ViewBag.ListKeHoachVanTai = listKeHoachVanTai;
            return View(model);
        }
        [HttpGet]
        public ActionResult ThemChungTu()
        {
            return View();
        }
        [HttpPost]
       
        public ActionResult ThemChungTu(ChungTu model)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Insert(ChungTu model)
        {
            return View();
        }
    }
}
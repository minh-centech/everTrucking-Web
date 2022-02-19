using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using everTrucking_Web.Code.DTO;
using everTrucking_Web.Code.BUS;
using everTrucking_Web.Code;
using everTrucking_Web.Code.DAO;

namespace everTrucking_Web.Controllers
{
    public class KeHoachVanTaiController : Controller
    {
        // GET: KeHoachVanTai
        // [HttpGet]


        public ActionResult Index(listChungTuRequest model)
        {
            ViewBag.IDDanhKhachHangDefault = string.Empty;
            DataTable dtDanhMucKhachHang = Code.BUS.DanhMucKhachHangBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongKhachHang, null);
            GlobalVariables.listKhachHang = new List<DanhMucKhachHang>();

            foreach (DataRow drKhachHang in dtDanhMucKhachHang.Rows)
            {
                GlobalVariables.listKhachHang.Add(new DanhMucKhachHang()
                {
                    ID = drKhachHang["ID"].ToString(),
                    Ma = drKhachHang["Ma"].ToString(),
                    Ten = drKhachHang["Ten"].ToString(),
                });
            }

            // //model.TuNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("dd/MM/yyyy");
            // //model.DenNgay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).ToString("dd/MM/yyyy");

            DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.ListDisplay(Code.GlobalVariables.IDDanhMucChungTuKeHoachVanTai, DateTime.Now, DateTime.Now, null, null);
            List<ctKeHoachVanTai> listKeHoachVanTai = new List<ctKeHoachVanTai>();
            foreach (DataRow drKeHoachVanTai in dtKeHoachVanTai.Rows)
            {
                listKeHoachVanTai.Add(new ctKeHoachVanTai()
                {
                    ID = drKeHoachVanTai["ID"].ToString(),
                    So = drKeHoachVanTai["So"].ToString(),
                    IDDanhMucSale = drKeHoachVanTai["IDDanhMucSale"].ToString(),
                    TenDanhMucSale = drKeHoachVanTai["TenDanhMucSale"].ToString(),
                    NgayLap = drKeHoachVanTai["NgayLap"].ToString(),
                    TenLoaiHinh = drKeHoachVanTai["TenLoaiHinh"].ToString(),
                    TenLoaiHang = drKeHoachVanTai["TenLoaiHang"].ToString(),
                    IDDanhMucKhachHang = drKeHoachVanTai["IDDanhMucKhachHang"].ToString(),
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

            DataTable dtDanhMucSale = Code.BUS.DanhMucDoiTuongBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongNhanSu, null);
            ViewBag.IDDanhMucSale = string.Empty;
            List<DanhMucDoiTuong> listSale = new List<DanhMucDoiTuong>();
            foreach (DataRow drSale in dtDanhMucSale.Rows)
            {
                listSale.Add(new DanhMucDoiTuong()
                {
                    ID = drSale["ID"].ToString(),
                    Ma = drSale["Ma"].ToString(),
                    Ten = drSale["Ten"].ToString(),
                });

            }

            DataTable dtDanhMucHangTau = Code.BUS.DanhMucDoiTuongBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongHangTau, null);
            List<DanhMucDoiTuong> listHangTau = new List<DanhMucDoiTuong>();
            ViewBag.IDDanhMucHangTauDefault = string.Empty;
            foreach (DataRow drHangTau in dtDanhMucHangTau.Rows)
            {
                listHangTau.Add(new DanhMucDoiTuong()
                {
                    ID = drHangTau["ID"].ToString(),
                    Ma = drHangTau["Ma"].ToString(),
                    Ten = drHangTau["Ten"].ToString(),
                });
            }
            //if (dtDanhMucHangTau.Rows.Count > 0)
            //{
            //    ViewBag.IDDanhMucHangTauDefault = listHangTau[0].ID.ToString();
            //}

            DataTable dtDiaDiemNangHaCont = Code.BUS.DanhMucDoiTuongBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongCangICD, null);
            ViewBag.IDDanhMucDiaDiemNangHaCont = string.Empty;
            List<DanhMucDoiTuong> listDiaDiemNangHaCont = new List<DanhMucDoiTuong>();
            foreach (DataRow drDiaDiemNangHaCont in dtDiaDiemNangHaCont.Rows)
            {
                listDiaDiemNangHaCont.Add(new DanhMucDoiTuong()
                {
                    ID = drDiaDiemNangHaCont["ID"].ToString(),
                    Ma = drDiaDiemNangHaCont["Ma"].ToString(),
                    Ten = drDiaDiemNangHaCont["Ten"].ToString(),
                });

            }



            DataTable dtDiaDiemDongTraHang = Code.BUS.DanhMucDoiTuongBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongKho, null);
            ViewBag.IDDanhMucDiaDiemDongTraHang = string.Empty;
            List<DanhMucDoiTuong> listDiaDiemDongTraHang = new List<DanhMucDoiTuong>();
            foreach (DataRow drDiaDiemDongTra in dtDiaDiemDongTraHang.Rows)
            {
                listDiaDiemDongTraHang.Add(new DanhMucDoiTuong()
                {
                    ID = drDiaDiemDongTra["ID"].ToString(),
                    Ma = drDiaDiemDongTra["Ma"].ToString(),
                    Ten = drDiaDiemDongTra["Ten"].ToString(),
                });

            }


            ViewBag.ListKhachHang = GlobalVariables.listKhachHang;
            ViewBag.ListSale = listSale;
            ViewBag.ListHangTau = listHangTau;

            ViewBag.listDiaDiemNangHaCont = listDiaDiemNangHaCont;
            ViewBag.listDiaDiemDongTraHang = listDiaDiemDongTraHang;
            //ViewBag.ListKhachHang = GlobalVariables.listKhachHang;
            // //ViewBag.ListKeHoachVanTai = listKeHoachVanTai;

            return View(listKeHoachVanTai);
        }


        public JsonResult List(string startDate, string endDate)
        {
            if (Common.IsNull(startDate)) startDate = DateTime.Now.ToString();
            if (Common.IsNull(endDate)) endDate = DateTime.Now.ToString();
            DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.ListDisplay(Code.GlobalVariables.IDDanhMucChungTuKeHoachVanTai, startDate, endDate, null, null);
            List<ctKeHoachVanTai> listKeHoachVanTai = new List<ctKeHoachVanTai>();

            if (dtKeHoachVanTai.Rows.Count > 0)
            {
                foreach (DataRow drKeHoachVanTai in dtKeHoachVanTai.Rows)
                {
                    listKeHoachVanTai.Add(new ctKeHoachVanTai()
                    {
                        ID = drKeHoachVanTai["ID"].ToString(),
                        IDDanhMucDonVi = drKeHoachVanTai["IDDanhMucDonVi"].ToString(),
                        IDDanhMucChungTu = drKeHoachVanTai["IDDanhMucChungTu"].ToString(),
                        IDDanhMucChungTuTrangThai = drKeHoachVanTai["IDDanhMucChungTuTrangThai"].ToString(),
                        So = drKeHoachVanTai["So"].ToString(),
                        NgayLap = drKeHoachVanTai["NgayLap"].ToString(),
                        IDDanhMucSale = drKeHoachVanTai["IDDanhMucSale"].ToString(),
                        TenDanhMucSale = drKeHoachVanTai["TenDanhMucSale"].ToString(),

                        IDDanhMucKhachHang = drKeHoachVanTai["IDDanhMucKhachHang"].ToString(),
                        TenDanhMucKhachHang = drKeHoachVanTai["TenDanhMucKhachHang"].ToString(),
                        LoaiHinh = drKeHoachVanTai["LoaiHinh"].ToString(),
                        TenLoaiHinh = drKeHoachVanTai["TenLoaiHinh"].ToString(),
                        LoaiHang = drKeHoachVanTai["LoaiHang"].ToString(),
                        TenLoaiHang = drKeHoachVanTai["TenLoaiHang"].ToString(),
                        IDDanhMucHangTau = drKeHoachVanTai["IDDanhMucHangTau"].ToString(),
                        // TenDanhMucHangTau = drKeHoachVanTai["TenDanhMucHangTau"].ToString(),
                        IDDanhMucDiaDiemNangCont = drKeHoachVanTai["IDDanhMucDiaDiemNangCont"].ToString(),
                        TenDanhMucDiaDiemNangCont = drKeHoachVanTai["TenDanhMucDiaDiemNangCont"].ToString(),
                        NgayNangCont = drKeHoachVanTai["NgayNangCont"].ToString(),
                        IDDanhMucDiaDiemHaCont = drKeHoachVanTai["IDDanhMucDiaDiemHaCont"].ToString(),
                        TenDanhMucDiaDiemHaCont = drKeHoachVanTai["TenDanhMucDiaDiemHaCont"].ToString(),
                        NgayHaCont = drKeHoachVanTai["NgayHaCont"].ToString(),

                        SoLuongCont20 = drKeHoachVanTai["SoLuongCont20"].ToString(),
                        SoCont20 = drKeHoachVanTai["SoCont20"].ToString(),
                        SoLuongCont40 = drKeHoachVanTai["SoLuongCont40"].ToString(),
                        SoCont40 = drKeHoachVanTai["SoCont40"].ToString(),
                        SoLuongCont45 = drKeHoachVanTai["SoLuongCont45"].ToString(),
                        SoCont45 = drKeHoachVanTai["SoCont45"].ToString(),
                        SoLuongContOpenTop = drKeHoachVanTai["SoLuongContOpenTop"].ToString(),
                        SoContOpenTop = drKeHoachVanTai["SoContOpenTop"].ToString(),
                        SoLuongContFlatRack = drKeHoachVanTai["SoLuongContFlatRack"].ToString(),
                        SoContFlatRack = drKeHoachVanTai["SoContFlatRack"].ToString(),
                        IDDanhMucDiaDiemDongHang = drKeHoachVanTai["IDDanhMucDiaDiemDongHang"].ToString(),
                        TenDanhMucDiaDiemDongHang = drKeHoachVanTai["TenDanhMucDiaDiemDongHang"].ToString(),
                        NgayDongHang = drKeHoachVanTai["NgayDongHang"].ToString(),
                        IDDanhMucDiaDiemTraHang = drKeHoachVanTai["IDDanhMucDiaDiemTraHang"].ToString(),
                        TenDanhMucDiaDiemTraHang = drKeHoachVanTai["TenDanhMucDiaDiemTraHang"].ToString(),
                        NgayTraHang = drKeHoachVanTai["NgayTraHang"].ToString(),
                        KhoiLuong = drKeHoachVanTai["KhoiLuong"].ToString(),
                        NguoiGiaoNhan = drKeHoachVanTai["NguoiGiaoNhan"].ToString(),
                        SoDienThoaiGiaoNhan = drKeHoachVanTai["SoDienThoaiGiaoNhan"].ToString(),
                        GhiChu = drKeHoachVanTai["GhiChu"].ToString(),
                        IDDanhMucNguoiSuDungCreate = drKeHoachVanTai["IDDanhMucNguoiSuDungCreate"].ToString(),
                        CreateDate = drKeHoachVanTai["CreateDate"].ToString(),
                        EditDate = drKeHoachVanTai["EditDate"].ToString(),
                    });
                }
            }
            else
            {
                listKeHoachVanTai.Add(new ctKeHoachVanTai()
                {
                    ID = null,
                    IDDanhMucDonVi = null,
                    IDDanhMucChungTu = null,
                    IDDanhMucChungTuTrangThai = null,
                    So = null,
                    NgayLap = null,
                    IDDanhMucSale = null,

                    IDDanhMucKhachHang = null,

                    LoaiHinh = null,

                    LoaiHang = null,

                    IDDanhMucHangTau = null,

                    IDDanhMucDiaDiemNangCont = null,

                    NgayNangCont = null,
                    IDDanhMucDiaDiemHaCont = null,

                    NgayHaCont = null,

                    SoLuongCont20 = null,
                    SoCont20 = null,
                    SoLuongCont40 = null,
                    SoCont40 = null,
                    SoLuongCont45 = null,
                    SoCont45 = null,
                    SoLuongContOpenTop = null,
                    SoContOpenTop = null,
                    SoLuongContFlatRack = null,
                    SoContFlatRack = null,
                    IDDanhMucDiaDiemDongHang = null,

                    NgayDongHang = null,
                    IDDanhMucDiaDiemTraHang = null,

                    NgayTraHang = null,
                    KhoiLuong = null,
                    NguoiGiaoNhan = null,
                    SoDienThoaiGiaoNhan = null,
                    GhiChu = null,
                    IDDanhMucNguoiSuDungCreate = null,
                });
            }
            return Json(listKeHoachVanTai, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetbyID(string ID)
        {

            DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.List(Code.GlobalVariables.IDDanhMucChungTuKeHoachVanTai, ID);
            List<ctKeHoachVanTai> listKeHoachVanTai = new List<ctKeHoachVanTai>();
            if (dtKeHoachVanTai.Rows.Count > 0)
            {
                foreach (DataRow drKeHoachVanTai in dtKeHoachVanTai.Rows)
                {
                    listKeHoachVanTai.Add(new ctKeHoachVanTai()
                    {
                        ID = drKeHoachVanTai["ID"].ToString(),
                        IDDanhMucDonVi = drKeHoachVanTai["IDDanhMucDonVi"].ToString(),
                        IDDanhMucChungTu = drKeHoachVanTai["IDDanhMucChungTu"].ToString(),
                        IDDanhMucChungTuTrangThai = drKeHoachVanTai["IDDanhMucChungTuTrangThai"].ToString(),
                        So = drKeHoachVanTai["So"].ToString(),
                        NgayLap = drKeHoachVanTai["NgayLap"].ToString(),
                        IDDanhMucSale = drKeHoachVanTai["IDDanhMucSale"].ToString(),
                        //TenDanhMucSale = drKeHoachVanTai["TenDanhMucSale"].ToString(),

                        IDDanhMucKhachHang = drKeHoachVanTai["IDDanhMucKhachHang"].ToString(),
                        TenDanhMucKhachHang = drKeHoachVanTai["TenDanhMucKhachHang"].ToString(),
                        LoaiHinh = drKeHoachVanTai["LoaiHinh"].ToString(),
                        TenLoaiHinh = drKeHoachVanTai["TenLoaiHinh"].ToString(),
                        LoaiHang = drKeHoachVanTai["LoaiHang"].ToString(),
                        TenLoaiHang = drKeHoachVanTai["TenLoaiHang"].ToString(),
                        IDDanhMucHangTau = drKeHoachVanTai["IDDanhMucHangTau"].ToString(),
                        //TenDanhMucHangTau = drKeHoachVanTai["TenDanhMucHangTau"].ToString(),
                        IDDanhMucDiaDiemNangCont = drKeHoachVanTai["IDDanhMucDiaDiemNangCont"].ToString(),
                        //TenDanhMucDiaDiemNangCont = drKeHoachVanTai["TenDanhMucDiaDiemNangCont"].ToString(),
                        NgayNangCont = drKeHoachVanTai["NgayNangCont"].ToString(),
                        IDDanhMucDiaDiemHaCont = drKeHoachVanTai["IDDanhMucDiaDiemHaCont"].ToString(),
                        //TenDanhMucDiaDiemHaCont = drKeHoachVanTai["TenDanhMucDiaDiemHaCont"].ToString(),
                        NgayHaCont = drKeHoachVanTai["NgayHaCont"].ToString(),

                        SoLuongCont20 = drKeHoachVanTai["SoLuongCont20"].ToString(),
                        SoCont20 = drKeHoachVanTai["SoCont20"].ToString(),
                        SoLuongCont40 = drKeHoachVanTai["SoLuongCont40"].ToString(),
                        SoCont40 = drKeHoachVanTai["SoCont40"].ToString(),
                        SoLuongCont45 = drKeHoachVanTai["SoLuongCont45"].ToString(),
                        SoCont45 = drKeHoachVanTai["SoCont45"].ToString(),
                        SoLuongContOpenTop = drKeHoachVanTai["SoLuongContOpenTop"].ToString(),
                        SoContOpenTop = drKeHoachVanTai["SoContOpenTop"].ToString(),
                        SoLuongContFlatRack = drKeHoachVanTai["SoLuongContFlatRack"].ToString(),
                        SoContFlatRack = drKeHoachVanTai["SoContFlatRack"].ToString(),
                        IDDanhMucDiaDiemDongHang = drKeHoachVanTai["IDDanhMucDiaDiemDongHang"].ToString(),
                        //TenDanhMucDiaDiemDongHang = drKeHoachVanTai["TenDanhMucDiaDiemDongHang"].ToString(),
                        NgayDongHang = drKeHoachVanTai["NgayDongHang"].ToString(),
                        IDDanhMucDiaDiemTraHang = drKeHoachVanTai["IDDanhMucDiaDiemTraHang"].ToString(),
                        //TenDanhMucDiaDiemTraHang = drKeHoachVanTai["TenDanhMucDiaDiemTraHang"].ToString(),
                        NgayTraHang = drKeHoachVanTai["NgayTraHang"].ToString(),
                        KhoiLuong = drKeHoachVanTai["KhoiLuong"].ToString(),
                        NguoiGiaoNhan = drKeHoachVanTai["NguoiGiaoNhan"].ToString(),
                        SoDienThoaiGiaoNhan = drKeHoachVanTai["SoDienThoaiGiaoNhan"].ToString(),
                        GhiChu = drKeHoachVanTai["GhiChu"].ToString(),
                        IDDanhMucNguoiSuDungCreate = drKeHoachVanTai["IDDanhMucNguoiSuDungCreate"].ToString(),
                        CreateDate = drKeHoachVanTai["CreateDate"].ToString(),
                        EditDate = drKeHoachVanTai["EditDate"].ToString(),
                    });
                }
            }
            var Employee = listKeHoachVanTai[0];
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ctKeHoachVanTai emp)
        {
            Common.msgResponse msgResponse = ctKeHoachVanTaiBUS.Update(emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ctKeHoachVanTai emp)
        {

            Common.msgResponse msgResponse = ctKeHoachVanTaiBUS.Insert(emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string ID)
        {
            Common.msgResponse msgResponse = ctKeHoachVanTaiBUS.Delete(ID);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
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
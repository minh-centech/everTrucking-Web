using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using cenDTO;
using cenBUS.DatabaseCore;
using cenBUS.cenLogistics;
using cenBUS;
using cenDTO.DatabaseCore;
using cenDTO.cenLogistics;
using ClosedXML.Excel;
using System.IO;

namespace everTrucking_Web.Controllers
{
    public class KeHoachVanTaiContainerNoiDiaController : Controller
    {
        // GET: KeHoachVanTai
        // [HttpGet]


        public ActionResult Index(listChungTuRequest model)
        {
            UserSession Session = UserSessionHelper.GetSession();
            if (Session == null)
                return RedirectToAction("Login", "DanhMucNguoiSuDung");


            DataTable dtDanhMucSale = DanhMucDoiTuongBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu)), null);
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

            DataTable dtDanhMucKhachHang = DanhMucKhachHangBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
            ViewBag.IDDanhMucKhachHang = string.Empty;
            List<DanhMucKhachHang> listKhachHang = new List<DanhMucKhachHang>();
            foreach (DataRow drSale in dtDanhMucKhachHang.Rows)
            {
                listKhachHang.Add(new DanhMucKhachHang()
                {
                    ID = drSale["ID"].ToString(),
                    Ma = drSale["Ma"].ToString(),
                    Ten = drSale["Ten"].ToString(),
                });

            }
            
            DataTable dtDanhMucHangTau = DanhMucDoiTuongBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangTau)), null);
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

            DataTable dtDiaDiemNangHaCont = DanhMucDoiTuongBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongCangICD)), null);
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

            DataTable dtDiaDiemDongTraHang = DanhMucDoiTuongBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKho)), null);
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


            ViewBag.ListKhachHang = listKhachHang;
            ViewBag.ListSale = listSale;
            ViewBag.ListHangTau = listHangTau;

            ViewBag.listDiaDiemNangHaCont = listDiaDiemNangHaCont;
            ViewBag.listDiaDiemDongTraHang = listDiaDiemDongTraHang;

            return View();
        }
        public JsonResult List(string startDate, string endDate, string LoaiHinh, string LoaiHang)
        {
            if (cenCommon.cenCommon.IsNull(startDate))
                startDate = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).ToString();
            else
                startDate = (new DateTime(cenCommon.cenCommon.intParse(startDate.Substring(6, 4)), cenCommon.cenCommon.intParse(startDate.Substring(3, 2)), cenCommon.cenCommon.intParse(startDate.Substring(0, 2)))).ToString();
            if (cenCommon.cenCommon.IsNull(endDate))
                endDate = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).ToString();
            else
                endDate = (new DateTime(cenCommon.cenCommon.intParse(endDate.Substring(6, 4)), cenCommon.cenCommon.intParse(endDate.Substring(3, 2)), cenCommon.cenCommon.intParse(endDate.Substring(0, 2)))).ToString();



            DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.ListDisplay(DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuKeHoachVanTai)), startDate, endDate, null, "3", "1", null);
            List<ctKeHoachVanTai> listKeHoachVanTai = new List<ctKeHoachVanTai>();

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
                    MaDanhMucHangTau = drKeHoachVanTai["MaDanhMucHangTau"].ToString(),
                    TenDanhMucHangTau = drKeHoachVanTai["TenDanhMucHangTau"].ToString(),
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
                    TenDanhMucNguoiSuDungCreate = drKeHoachVanTai["TenDanhMucNguoiSuDungCreate"].ToString(),
                    CreateDate = drKeHoachVanTai["CreateDate"].ToString(),
                    TenDanhMucNguoiSuDungEdit = drKeHoachVanTai["TenDanhMucNguoiSuDungEdit"].ToString(),
                    EditDate = drKeHoachVanTai["EditDate"].ToString(),
                });
            }
            return Json(listKeHoachVanTai, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetbyID(string ID)
        {

            DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.List(DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuKeHoachVanTai)), ID);
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
                        MaDanhMucHangTau = drKeHoachVanTai["MaDanhMucHangTau"].ToString(),
                        TenDanhMucHangTau = drKeHoachVanTai["TenDanhMucHangTau"].ToString(),
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
                        TenDanhMucNguoiSuDungCreate = drKeHoachVanTai["TenDanhMucNguoiSuDungCreate"].ToString(),
                        CreateDate = drKeHoachVanTai["CreateDate"].ToString(),
                        TenDanhMucNguoiSuDungEdit = drKeHoachVanTai["TenDanhMucNguoiSuDungEdit"].ToString(),
                        EditDate = drKeHoachVanTai["EditDate"].ToString(),
                    });
                }
            }
            var Employee = listKeHoachVanTai[0];
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(ctKeHoachVanTai emp)
        {
            emp.IDDanhMucNguoiSuDungEdit = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            if (!cenCommon.cenCommon.IsNull(emp.NgayNangCont))
                emp.NgayNangCont = (new DateTime(cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(6, 4)), cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(3, 2)), cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(0, 2)))).ToString();
            if (!cenCommon.cenCommon.IsNull(emp.NgayHaCont))
                emp.NgayHaCont = (new DateTime(cenCommon.cenCommon.intParse(emp.NgayHaCont.Substring(6, 4)), cenCommon.cenCommon.intParse(emp.NgayHaCont.Substring(3, 2)), cenCommon.cenCommon.intParse(emp.NgayHaCont.Substring(0, 2)))).ToString();
            if (!cenCommon.cenCommon.IsNull(emp.NgayDongHang))
                emp.NgayNangCont = (new DateTime(cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(6, 4)), cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(3, 2)), cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(0, 2)))).ToString();
            if (!cenCommon.cenCommon.IsNull(emp.NgayTraHang))
                emp.NgayTraHang = (new DateTime(cenCommon.cenCommon.intParse(emp.NgayTraHang.Substring(6, 4)), cenCommon.cenCommon.intParse(emp.NgayTraHang.Substring(3, 2)), cenCommon.cenCommon.intParse(emp.NgayTraHang.Substring(0, 2)))).ToString();

            cenDTO.msgResponse msgResponse = ctKeHoachVanTaiBUS.Update(emp);
            if (msgResponse.Status == "00")
            {
                DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.List(DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuKeHoachVanTai)), emp.ID);
                if (dtKeHoachVanTai.Rows.Count > 0)
                {
                    foreach (DataRow drKeHoachVanTai in dtKeHoachVanTai.Rows)
                    {
                        emp = new ctKeHoachVanTai()
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
                            MaDanhMucHangTau = drKeHoachVanTai["MaDanhMucHangTau"].ToString(),
                            TenDanhMucHangTau = drKeHoachVanTai["TenDanhMucHangTau"].ToString(),
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
                            TenDanhMucNguoiSuDungCreate = drKeHoachVanTai["TenDanhMucNguoiSuDungCreate"].ToString(),
                            CreateDate = drKeHoachVanTai["CreateDate"].ToString(),
                            TenDanhMucNguoiSuDungEdit = drKeHoachVanTai["TenDanhMucNguoiSuDungEdit"].ToString(),
                            EditDate = drKeHoachVanTai["EditDate"].ToString(),
                        };
                    }
                }
            }
            msgResponse.Data = Newtonsoft.Json.JsonConvert.SerializeObject(emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ctKeHoachVanTai emp)
        {
            emp.IDDanhMucChungTu = DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuKeHoachVanTai)).ToString();
            emp.IDDanhMucChungTuTrangThai = DanhMucChungTuTrangThaiBUS.List(null, DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuKeHoachVanTai))).Rows[0]["ID"].ToString();
            emp.IDDanhMucNguoiSuDungCreate = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            if (!cenCommon.cenCommon.IsNull(emp.NgayNangCont))
                emp.NgayNangCont = (new DateTime(cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(6, 4)), cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(3, 2)), cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(0, 2)))).ToString();
            if (!cenCommon.cenCommon.IsNull(emp.NgayHaCont))
                emp.NgayHaCont = (new DateTime(cenCommon.cenCommon.intParse(emp.NgayHaCont.Substring(6, 4)), cenCommon.cenCommon.intParse(emp.NgayHaCont.Substring(3, 2)), cenCommon.cenCommon.intParse(emp.NgayHaCont.Substring(0, 2)))).ToString();
            if (!cenCommon.cenCommon.IsNull(emp.NgayDongHang))
                emp.NgayNangCont = (new DateTime(cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(6, 4)), cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(3, 2)), cenCommon.cenCommon.intParse(emp.NgayNangCont.Substring(0, 2)))).ToString();
            if (!cenCommon.cenCommon.IsNull(emp.NgayTraHang))
                emp.NgayTraHang = (new DateTime(cenCommon.cenCommon.intParse(emp.NgayTraHang.Substring(6, 4)), cenCommon.cenCommon.intParse(emp.NgayTraHang.Substring(3, 2)), cenCommon.cenCommon.intParse(emp.NgayTraHang.Substring(0, 2)))).ToString();

            cenDTO.msgResponse msgResponse = ctKeHoachVanTaiBUS.Insert(emp);
            if (msgResponse.Status == "00")
            {
                DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.List(DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuKeHoachVanTai)), emp.ID);
                if (dtKeHoachVanTai.Rows.Count > 0)
                {
                    foreach (DataRow drKeHoachVanTai in dtKeHoachVanTai.Rows)
                    {
                        emp = new ctKeHoachVanTai()
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
                            MaDanhMucHangTau = drKeHoachVanTai["MaDanhMucHangTau"].ToString(),
                            TenDanhMucHangTau = drKeHoachVanTai["TenDanhMucHangTau"].ToString(),
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
                            TenDanhMucNguoiSuDungCreate = drKeHoachVanTai["TenDanhMucNguoiSuDungCreate"].ToString(),
                            CreateDate = drKeHoachVanTai["CreateDate"].ToString(),
                            TenDanhMucNguoiSuDungEdit = drKeHoachVanTai["TenDanhMucNguoiSuDungEdit"].ToString(),
                            EditDate = drKeHoachVanTai["EditDate"].ToString(),
                        };
                    }
                }
            }
            msgResponse.Data = Newtonsoft.Json.JsonConvert.SerializeObject(emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string ID)
        {
            cenDTO.msgResponse msgResponse = ctKeHoachVanTaiBUS.Delete(ID);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ThemChungTu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemChungTu(ctKeHoachVanTai model)
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
        public ActionResult Insert(ctKeHoachVanTai model)
        {
            return View();
        }
        [HttpGet]
        public ActionResult DownloadExcelDocument()
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "KeHoachVanTaiTongHop.xlsx";

            // Taken List of data from json file which we want to export to excel.
            DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.ListDisplay(DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuKeHoachVanTai)), "2022-01-01", "2022-12-31", null, "0", "0", null);
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
                        MaDanhMucKhachHang = drKeHoachVanTai["MaDanhMucKhachHang"].ToString(),
                        TenDanhMucKhachHang = drKeHoachVanTai["TenDanhMucKhachHang"].ToString(),
                        LoaiHinh = drKeHoachVanTai["LoaiHinh"].ToString(),
                        TenLoaiHinh = drKeHoachVanTai["TenLoaiHinh"].ToString(),
                        LoaiHang = drKeHoachVanTai["LoaiHang"].ToString(),
                        TenLoaiHang = drKeHoachVanTai["TenLoaiHang"].ToString(),
                        IDDanhMucHangTau = drKeHoachVanTai["IDDanhMucHangTau"].ToString(),
                        MaDanhMucHangTau = drKeHoachVanTai["MaDanhMucHangTau"].ToString(),
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
                    ID = string.Empty,
                    IDDanhMucDonVi = string.Empty,
                    IDDanhMucChungTu = string.Empty,
                    IDDanhMucChungTuTrangThai = string.Empty,
                    So = string.Empty,
                    NgayLap = string.Empty,
                    IDDanhMucSale = string.Empty,
                    IDDanhMucKhachHang = string.Empty,
                    LoaiHinh = string.Empty,
                    LoaiHang = string.Empty,
                    IDDanhMucHangTau = string.Empty,
                    IDDanhMucDiaDiemNangCont = string.Empty,
                    NgayNangCont = string.Empty,
                    IDDanhMucDiaDiemHaCont = string.Empty,
                    NgayHaCont = string.Empty,
                    SoLuongCont20 = string.Empty,
                    SoCont20 = string.Empty,
                    SoLuongCont40 = string.Empty,
                    SoCont40 = string.Empty,
                    SoLuongCont45 = string.Empty,
                    SoCont45 = string.Empty,
                    SoLuongContOpenTop = string.Empty,
                    SoContOpenTop = string.Empty,
                    SoLuongContFlatRack = string.Empty,
                    SoContFlatRack = string.Empty,
                    IDDanhMucDiaDiemDongHang = string.Empty,
                    NgayDongHang = string.Empty,
                    IDDanhMucDiaDiemTraHang = string.Empty,
                    NgayTraHang = string.Empty,
                    KhoiLuong = string.Empty,
                    NguoiGiaoNhan = string.Empty,
                    SoDienThoaiGiaoNhan = string.Empty,
                    GhiChu = string.Empty,
                    IDDanhMucNguoiSuDungCreate = string.Empty
                });
            }
            
            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet =
                workbook.Worksheets.Add("KeHoachVanTai");
                worksheet.Cell(1, 1).Value = "STT";
                worksheet.Cell(1, 2).Value = "Số kế hoạch";
                worksheet.Cell(1, 3).Value = "Ngày lập";
                worksheet.Cell(1, 4).Value = "Mã khách hàng";
                worksheet.Cell(1, 5).Value = "Tên khách hàng";
                worksheet.Cell(1, 6).Value = "Loại hình";
                worksheet.Cell(1, 7).Value = "Loại hàng";
                worksheet.Cell(1, 8).Value = "Số cont 20";
                worksheet.Cell(1, 9).Value = "Số cont 40";
                worksheet.Cell(1, 10).Value = "Số cont 45";
                worksheet.Cell(1, 11).Value = "Số cont open top";
                worksheet.Cell(1, 12).Value = "Số cont flat rack";
                worksheet.Cell(1, 13).Value = "Địa điểm nâng cont";
                worksheet.Cell(1, 14).Value = "Ngày nâng cont";
                worksheet.Cell(1, 15).Value = "Địa điểm hạ cont";
                worksheet.Cell(1, 16).Value = "Ngày hạ cont";
                worksheet.Cell(1, 17).Value = "Địa điểm đóng hàng";
                worksheet.Cell(1, 18).Value = "Ngày đóng hàng";
                worksheet.Cell(1, 19).Value = "Địa điểm trả hàng";
                worksheet.Cell(1, 20).Value = "Ngày trả hàng";
                for (int index = 1; index <= 21; index++)
                {
                    worksheet.Cell(1, index).Style.Font.Bold = true;
                }
                for (int index = 0; index <= listKeHoachVanTai.Count - 1; index++)
                {
                    worksheet.Cell(index + 2, 1).Value = index + 1;
                    worksheet.Cell(index + 2, 2).Value = listKeHoachVanTai[index].So;
                    worksheet.Cell(index + 2, 3).Value = listKeHoachVanTai[index].NgayLap;
                    worksheet.Cell(index + 2, 4).Value = listKeHoachVanTai[index].MaDanhMucKhachHang;
                    worksheet.Cell(index + 2, 5).Value = listKeHoachVanTai[index].TenDanhMucKhachHang;
                    worksheet.Cell(index + 2, 6).Value = listKeHoachVanTai[index].TenLoaiHinh;
                    worksheet.Cell(index + 2, 7).Value = listKeHoachVanTai[index].TenLoaiHang;
                    worksheet.Cell(index + 2, 8).Value = listKeHoachVanTai[index].SoCont20;
                    worksheet.Cell(index + 2, 9).Value = listKeHoachVanTai[index].SoCont40;
                    worksheet.Cell(index + 2, 10).Value = listKeHoachVanTai[index].SoCont45;
                    worksheet.Cell(index + 2, 11).Value = listKeHoachVanTai[index].SoContOpenTop;
                    worksheet.Cell(index + 2, 12).Value = listKeHoachVanTai[index].SoContFlatRack;
                    worksheet.Cell(index + 2, 13).Value = listKeHoachVanTai[index].TenDanhMucDiaDiemNangCont;
                    worksheet.Cell(index + 2, 14).Value = listKeHoachVanTai[index].NgayNangCont;
                    worksheet.Cell(index + 2, 15).Value = listKeHoachVanTai[index].TenDanhMucDiaDiemHaCont;
                    worksheet.Cell(index + 2, 16).Value = listKeHoachVanTai[index].NgayHaCont;
                    worksheet.Cell(index + 2, 17).Value = listKeHoachVanTai[index].TenDanhMucDiaDiemDongHang;
                    worksheet.Cell(index + 2, 18).Value = listKeHoachVanTai[index].NgayDongHang;
                    worksheet.Cell(index + 2, 19).Value = listKeHoachVanTai[index].TenDanhMucDiaDiemTraHang;
                    worksheet.Cell(index + 2, 20).Value = listKeHoachVanTai[index].NgayTraHang;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, contentType, fileName);
                }
            }
        }
    }
}
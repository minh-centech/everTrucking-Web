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
    public class KeHoachVanTaiHangRoiNoiDiaController : Controller
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



            DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.ListDisplay(DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuKeHoachVanTai)), startDate, endDate, null, "3", "2", null);
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
                emp.NgayDongHang = (new DateTime(cenCommon.cenCommon.intParse(emp.NgayDongHang.Substring(6, 4)), cenCommon.cenCommon.intParse(emp.NgayDongHang.Substring(3, 2)), cenCommon.cenCommon.intParse(emp.NgayDongHang.Substring(0, 2)))).ToString();
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
                emp.NgayDongHang = (new DateTime(cenCommon.cenCommon.intParse(emp.NgayDongHang.Substring(6, 4)), cenCommon.cenCommon.intParse(emp.NgayDongHang.Substring(3, 2)), cenCommon.cenCommon.intParse(emp.NgayDongHang.Substring(0, 2)))).ToString();
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
        public ActionResult DownloadExcelDocument(string startDate, string endDate, string LoaiHinh, string LoaiHang)
        {
            if (cenCommon.cenCommon.IsNull(startDate))
                startDate = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).ToString();
            else
                startDate = (new DateTime(cenCommon.cenCommon.intParse(startDate.Substring(6, 4)), cenCommon.cenCommon.intParse(startDate.Substring(3, 2)), cenCommon.cenCommon.intParse(startDate.Substring(0, 2)))).ToString();
            if (cenCommon.cenCommon.IsNull(endDate))
                endDate = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).ToString();
            else
                endDate = (new DateTime(cenCommon.cenCommon.intParse(endDate.Substring(6, 4)), cenCommon.cenCommon.intParse(endDate.Substring(3, 2)), cenCommon.cenCommon.intParse(endDate.Substring(0, 2)))).ToString();


            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = "KeHoachVanTaiTongHop.xlsx";

            // Taken List of data from json file which we want to export to excel.
            DataTable dtKeHoachVanTai = ctKeHoachVanTaiBUS.rptKeHoachVanTaiTongHop(DanhMucChungTuBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoChungTuKeHoachVanTai)), startDate, endDate, null, "3", "2");
            List<rptKeHoachVanTaiTongHop> listKeHoachVanTai = new List<rptKeHoachVanTaiTongHop>();

            if (dtKeHoachVanTai.Rows.Count > 0)
            {
                foreach (DataRow drKeHoachVanTai in dtKeHoachVanTai.Rows)
                {
                    listKeHoachVanTai.Add(new rptKeHoachVanTaiTongHop()
                    {
                        Stt = drKeHoachVanTai["Stt"].ToString(),
                        NgayLap = drKeHoachVanTai["NgayLap"].ToString(),
                        TenLoaiHinh = drKeHoachVanTai["TenLoaiHinh"].ToString(),
                        LoaiContainer = drKeHoachVanTai["LoaiContainer"].ToString(),
                        SoContainer = drKeHoachVanTai["SoContainer"].ToString(),
                        TenDanhMucKhachHang = drKeHoachVanTai["TenDanhMucKhachHang"].ToString(),
                        KhoiLuong = drKeHoachVanTai["KhoiLuong"].ToString(),
                        TenDanhMucHangTau = drKeHoachVanTai["TenDanhMucHangTau"].ToString(),
                        GhiChu = drKeHoachVanTai["GhiChu"].ToString(),
                        TenDanhMucDiaDiemNangHa = drKeHoachVanTai["TenDanhMucDiaDiemNangHa"].ToString(),
                        TenDanhMucDiaDiemDongTra = drKeHoachVanTai["TenDanhMucDiaDiemDongTra"].ToString()
                    });
                }
            }

            using (var workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet =
                workbook.Worksheets.Add("KeHoachVanTai");
                worksheet.Cell(1, 1).Value = "STT";
                worksheet.Cell(1, 2).Value = "Ngày lập";
                worksheet.Cell(1, 3).Value = "Loại hình";
                worksheet.Cell(1, 4).Value = "Loại cont";
                worksheet.Cell(1, 5).Value = "Số container";
                worksheet.Cell(1, 6).Value = "Tên khách hàng";
                worksheet.Cell(1, 7).Value = "Trọng lượng";
                worksheet.Cell(1, 8).Value = "Hãng tàu";
                worksheet.Cell(1, 9).Value = "Ghi chú";
                worksheet.Cell(1, 10).Value = "Địa chỉ giao nhận";
                worksheet.Cell(1, 11).Value = "Cảng nâng/hạ";
                for (int index = 1; index <= 11; index++)
                {
                    worksheet.Cell(1, index).Style.Font.Bold = true;
                }
                for (int index = 0; index <= listKeHoachVanTai.Count - 1; index++)
                {
                    worksheet.Cell(index + 2, 1).Value = index + 1;
                    worksheet.Cell(index + 2, 2).Value = listKeHoachVanTai[index].NgayLap;
                    worksheet.Cell(index + 2, 3).Value = listKeHoachVanTai[index].TenLoaiHinh;
                    worksheet.Cell(index + 2, 4).Value = listKeHoachVanTai[index].LoaiContainer;
                    worksheet.Cell(index + 2, 5).Value = listKeHoachVanTai[index].SoContainer;
                    worksheet.Cell(index + 2, 6).Value = listKeHoachVanTai[index].TenDanhMucKhachHang;
                    worksheet.Cell(index + 2, 7).Value = listKeHoachVanTai[index].KhoiLuong;
                    worksheet.Cell(index + 2, 8).Value = listKeHoachVanTai[index].TenDanhMucHangTau;
                    worksheet.Cell(index + 2, 9).Value = listKeHoachVanTai[index].GhiChu;
                    worksheet.Cell(index + 2, 10).Value = listKeHoachVanTai[index].TenDanhMucDiaDiemDongTra;
                    worksheet.Cell(index + 2, 11).Value = listKeHoachVanTai[index].TenDanhMucDiaDiemNangHa;
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
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PagedList;
using cenDTO.cenLogistics;
using cenBUS.cenLogistics;
using cenBUS.DatabaseCore;
using cenDTO.DatabaseCore;
using cenDTO;

namespace everTrucking_Web.Controllers
{
    public class DanhMucController : Controller
    {
        //KHÁCH HÀNG
        public ActionResult KhachHangIndex()
        {
            UserSession Session = UserSessionHelper.GetSession();
            if (Session == null)
                return RedirectToAction("Login", "DanhMucNguoiSuDung");
            return View();
        }
        public JsonResult ListKhachHang()
        {
            DataTable dtDanhMucKhachHang = DanhMucKhachHangBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
            List<DanhMucKhachHang> listKhachHang = new List<DanhMucKhachHang>();
            foreach (DataRow drKhachHang in dtDanhMucKhachHang.Rows)
            {
                listKhachHang.Add(new DanhMucKhachHang()
                {
                    ID = drKhachHang["ID"].ToString(),
                    IDDanhMucDonVi = drKhachHang["IDDanhMucDonVi"].ToString(),
                    IDDanhMucLoaiDoiTuong = drKhachHang["IDDanhMucLoaiDoiTuong"].ToString(),
                    Ma = drKhachHang["Ma"].ToString(),
                    Ten = drKhachHang["Ten"].ToString(),
                    MaCS = drKhachHang["MaCS"].ToString(),
                    IDDanhMucNguoiSuDungEdit = drKhachHang["IDDanhMucNguoiSuDungEdit"].ToString(),
                    IDDanhMucNguoiSuDungCreate = drKhachHang["IDDanhMucNguoiSuDungCreate"].ToString(),
                    TenEN = drKhachHang["TenEN"].ToString(),
                    DiaChi = drKhachHang["DiaChi"].ToString(),
                    MaSoThue = drKhachHang["MaSoThue"].ToString(),
                    Nhom = drKhachHang["Nhom"].ToString(),
                    ViTri = drKhachHang["ViTri"].ToString(),
                    LoaiKhachHang = drKhachHang["LoaiKhachHang"].ToString(),
                    TenLoaiKhachHang = drKhachHang["TenLoaiKhachHang"].ToString(),
                    GhiChu = drKhachHang["GhiChu"].ToString(),
                    CreateDate = drKhachHang["CreateDate"].ToString(),
                    EditDate = drKhachHang["EditDate"].ToString(),
                });

            }
            ViewBag.ListKhachHang = listKhachHang;
           
            return Json(listKhachHang, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetKhachHangbyID(string ID)
        {
            DataTable dtDanhMucKhachHang = DanhMucKhachHangBUS.List(ID, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang)), null);
            DanhMucKhachHang obj = null;
            if (dtDanhMucKhachHang.Rows.Count == 1)
            {
                obj = new DanhMucKhachHang()
                {
                    ID = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["ID"]),
                    IDDanhMucDonVi = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["IDDanhMucDonVi"]),
                    IDDanhMucLoaiDoiTuong = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["IDDanhMucLoaiDoiTuong"]),
                    Ma = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["Ma"]),
                    Ten = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["Ten"]),
                    MaCS = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["MaCS"]),
                    TenEN = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["TenEN"]),
                    DiaChi = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["DiaChi"]),
                    MaSoThue = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["MaSoThue"]),
                    Nhom = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["Nhom"]),
                    ViTri = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["ViTri"]),
                    LoaiKhachHang = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["LoaiKhachHang"]),
                    TenLoaiKhachHang = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["TenLoaiKhachHang"]),
                    GhiChu = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["GhiChu"]),
                    IDDanhMucNguoiSuDungCreate = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["IDDanhMucNguoiSuDungCreate"]),
                    IDDanhMucNguoiSuDungEdit = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["IDDanhMucNguoiSuDungEdit"]),
                    CreateDate = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["CreateDate"]),
                    EditDate = cenCommon.cenCommon.stringParse(dtDanhMucKhachHang.Rows[0]["EditDate"]),
                };
            }
            
            var Employee = obj;
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateKhachHang(DanhMucKhachHang emp)
        {
            emp.IDDanhMucNguoiSuDungEdit = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            cenDTO.msgResponse msgResponse =  DanhMucKhachHangBUS.Update(ref emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddKhachHang(DanhMucKhachHang emp)          
        {
            emp.IDDanhMucDonVi = cenCommon.GlobalVariables.IDDonVi;
            emp.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang));
            emp.IDDanhMucNguoiSuDungCreate = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            cenDTO.msgResponse msgResponse = DanhMucKhachHangBUS.Insert(ref emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteKhachHang(string ID)
        {
            cenDTO.msgResponse msgResponse =  DanhMucKhachHangBUS.Delete(ID);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        //SALE
        public ActionResult SaleIndex()
        {
            UserSession Session = UserSessionHelper.GetSession();
            if (Session == null)
                return RedirectToAction("Login", "DanhMucNguoiSuDung");
            return View();
        }
        public JsonResult ListSale()
        {
            DataTable dtDanhMucSale = DanhMucDoiTuongBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu)), null);
            List<DanhMucDoiTuong> listSale = new List<DanhMucDoiTuong>();
            foreach (DataRow drSale in dtDanhMucSale.Rows)
            {
                listSale.Add(new DanhMucDoiTuong()
                {
                    ID = drSale["ID"].ToString(),
                    IDDanhMucDonVi = drSale["IDDanhMucDonVi"].ToString(),
                    IDDanhMucLoaiDoiTuong = drSale["IDDanhMucLoaiDoiTuong"].ToString(),
                    Ma = drSale["Ma"].ToString(),
                    Ten = drSale["Ten"].ToString(),
                    IDDanhMucNguoiSuDungEdit = drSale["IDDanhMucNguoiSuDungEdit"].ToString(),
                    IDDanhMucNguoiSuDungCreate = drSale["IDDanhMucNguoiSuDungCreate"].ToString(),
                    CreateDate = drSale["CreateDate"].ToString(),
                    EditDate = drSale["EditDate"].ToString(),
                });

            }
            ViewBag.ListSale = listSale;

            return Json(listSale, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSalebyID(string ID)
        {
            DataTable dtDanhMucSale = DanhMucDoiTuongBUS.List(ID, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu)), null);
            DanhMucDoiTuong obj = null;
            if (dtDanhMucSale.Rows.Count == 1)
            {
                obj = new DanhMucDoiTuong()
                {
                    ID = cenCommon.cenCommon.stringParse(dtDanhMucSale.Rows[0]["ID"]),
                    IDDanhMucDonVi = cenCommon.cenCommon.stringParse(dtDanhMucSale.Rows[0]["IDDanhMucDonVi"]),
                    IDDanhMucLoaiDoiTuong = cenCommon.cenCommon.stringParse(dtDanhMucSale.Rows[0]["IDDanhMucLoaiDoiTuong"]),
                    Ma = cenCommon.cenCommon.stringParse(dtDanhMucSale.Rows[0]["Ma"]),
                    Ten = cenCommon.cenCommon.stringParse(dtDanhMucSale.Rows[0]["Ten"]),
                    IDDanhMucNguoiSuDungCreate = cenCommon.cenCommon.stringParse(dtDanhMucSale.Rows[0]["IDDanhMucNguoiSuDungCreate"]),
                    IDDanhMucNguoiSuDungEdit = cenCommon.cenCommon.stringParse(dtDanhMucSale.Rows[0]["IDDanhMucNguoiSuDungEdit"]),
                    CreateDate = cenCommon.cenCommon.stringParse(dtDanhMucSale.Rows[0]["CreateDate"]),
                    EditDate = cenCommon.cenCommon.stringParse(dtDanhMucSale.Rows[0]["EditDate"]),
                };
            }

            var Employee = obj;
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateSale(DanhMucDoiTuong emp)
        {
            emp.IDDanhMucNguoiSuDungEdit = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            cenDTO.msgResponse msgResponse = DanhMucDoiTuongBUS.Update(ref emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddSale(DanhMucDoiTuong emp)
        {
            emp.IDDanhMucDonVi = cenCommon.GlobalVariables.IDDonVi;
            emp.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongNhanSu));
            emp.IDDanhMucNguoiSuDungCreate = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            cenDTO.msgResponse msgResponse = DanhMucDoiTuongBUS.Insert(ref emp);
            msgResponse.Data = Newtonsoft.Json.JsonConvert.SerializeObject(emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteSale (string ID)
        {
            cenDTO.msgResponse msgResponse = DanhMucDoiTuongBUS.Delete(ID);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }

        //HÃNG TÀU
        public ActionResult HangTauIndex()
        {
            UserSession Session = UserSessionHelper.GetSession();
            if (Session == null)
                return RedirectToAction("Login", "DanhMucNguoiSuDung");
            return View();
        }
        public JsonResult ListHangTau()
        {
            DataTable dtDanhMucHangTau = DanhMucDoiTuongBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangTau)), null);
            List<DanhMucDoiTuong> listHangTau = new List<DanhMucDoiTuong>();
            foreach (DataRow drHangTau in dtDanhMucHangTau.Rows)
            {
                listHangTau.Add(new DanhMucDoiTuong()
                {
                    ID = drHangTau["ID"].ToString(),
                    IDDanhMucDonVi = drHangTau["IDDanhMucDonVi"].ToString(),
                    IDDanhMucLoaiDoiTuong = drHangTau["IDDanhMucLoaiDoiTuong"].ToString(),
                    Ma = drHangTau["Ma"].ToString(),
                    Ten = drHangTau["Ten"].ToString(),
                    IDDanhMucNguoiSuDungEdit = drHangTau["IDDanhMucNguoiSuDungEdit"].ToString(),
                    IDDanhMucNguoiSuDungCreate = drHangTau["IDDanhMucNguoiSuDungCreate"].ToString(),
                    CreateDate = drHangTau["CreateDate"].ToString(),
                    EditDate = drHangTau["EditDate"].ToString(),
                });

            }
            ViewBag.ListHangTau = listHangTau;

            return Json(listHangTau, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetHangTaubyID(string ID)
        {
            DataTable dtDanhMucHangTau = DanhMucDoiTuongBUS.List(ID, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangTau)), null);
            DanhMucDoiTuong obj = null;
            if (dtDanhMucHangTau.Rows.Count == 1)
            {
                obj = new DanhMucDoiTuong()
                {
                    ID = cenCommon.cenCommon.stringParse(dtDanhMucHangTau.Rows[0]["ID"]),
                    IDDanhMucDonVi = cenCommon.cenCommon.stringParse(dtDanhMucHangTau.Rows[0]["IDDanhMucDonVi"]),
                    IDDanhMucLoaiDoiTuong = cenCommon.cenCommon.stringParse(dtDanhMucHangTau.Rows[0]["IDDanhMucLoaiDoiTuong"]),
                    Ma = cenCommon.cenCommon.stringParse(dtDanhMucHangTau.Rows[0]["Ma"]),
                    Ten = cenCommon.cenCommon.stringParse(dtDanhMucHangTau.Rows[0]["Ten"]),
                    IDDanhMucNguoiSuDungCreate = cenCommon.cenCommon.stringParse(dtDanhMucHangTau.Rows[0]["IDDanhMucNguoiSuDungCreate"]),
                    IDDanhMucNguoiSuDungEdit = cenCommon.cenCommon.stringParse(dtDanhMucHangTau.Rows[0]["IDDanhMucNguoiSuDungEdit"]),
                    CreateDate = cenCommon.cenCommon.stringParse(dtDanhMucHangTau.Rows[0]["CreateDate"]),
                    EditDate = cenCommon.cenCommon.stringParse(dtDanhMucHangTau.Rows[0]["EditDate"]),
                };
            }

            var Employee = obj;
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateHangTau(DanhMucDoiTuong emp)
        {
            emp.IDDanhMucNguoiSuDungEdit = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            cenDTO.msgResponse msgResponse = DanhMucDoiTuongBUS.Update(ref emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddHangTau(DanhMucDoiTuong emp)
        {
            emp.IDDanhMucDonVi = cenCommon.GlobalVariables.IDDonVi;
            emp.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongHangTau));
            emp.IDDanhMucNguoiSuDungCreate = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            cenDTO.msgResponse msgResponse = DanhMucDoiTuongBUS.Insert(ref emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteHangTau(string ID)
        {
            cenDTO.msgResponse msgResponse = DanhMucDoiTuongBUS.Delete(ID);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        //KHO
        public ActionResult KhoIndex()
        {
            UserSession Session = UserSessionHelper.GetSession();
            if (Session == null)
                return RedirectToAction("Login", "DanhMucNguoiSuDung");
            return View();
        }
        public JsonResult ListKho()
        {
            DataTable dtDanhMucKho = DanhMucDiaDiemGiaoNhanBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKho)), null);
            List<DanhMucDiaDiemGiaoNhan> listKho = new List<DanhMucDiaDiemGiaoNhan>();
            foreach (DataRow drKho in dtDanhMucKho.Rows)
            {
                listKho.Add(new DanhMucDiaDiemGiaoNhan()
                {
                    ID = drKho["ID"].ToString(),
                    IDDanhMucDonVi = drKho["IDDanhMucDonVi"].ToString(),
                    IDDanhMucLoaiDoiTuong = drKho["IDDanhMucLoaiDoiTuong"].ToString(),
                    Ma = drKho["Ma"].ToString(),
                    Ten = drKho["Ten"].ToString(),
                    DiaChi = drKho["DiaChi"].ToString(),
                    IDDanhMucNguoiSuDungEdit = drKho["IDDanhMucNguoiSuDungEdit"].ToString(),
                    IDDanhMucNguoiSuDungCreate = drKho["IDDanhMucNguoiSuDungCreate"].ToString(),
                    CreateDate = drKho["CreateDate"].ToString(),
                    EditDate = drKho["EditDate"].ToString(),
                });

            }
            ViewBag.ListKho = listKho;

            return Json(listKho, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetKhobyID(string ID)
        {
            DataTable dtDanhMucKho = DanhMucDiaDiemGiaoNhanBUS.List(ID, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKho)), null);
            DanhMucDiaDiemGiaoNhan obj = null;
            if (dtDanhMucKho.Rows.Count == 1)
            {
                obj = new DanhMucDiaDiemGiaoNhan()
                {
                    ID = cenCommon.cenCommon.stringParse(dtDanhMucKho.Rows[0]["ID"]),
                    IDDanhMucDonVi = cenCommon.cenCommon.stringParse(dtDanhMucKho.Rows[0]["IDDanhMucDonVi"]),
                    IDDanhMucLoaiDoiTuong = cenCommon.cenCommon.stringParse(dtDanhMucKho.Rows[0]["IDDanhMucLoaiDoiTuong"]),
                    Ma = cenCommon.cenCommon.stringParse(dtDanhMucKho.Rows[0]["Ma"]),
                    Ten = cenCommon.cenCommon.stringParse(dtDanhMucKho.Rows[0]["Ten"]),
                    DiaChi = cenCommon.cenCommon.stringParse(dtDanhMucKho.Rows[0]["DiaChi"]),
                    IDDanhMucNguoiSuDungCreate = cenCommon.cenCommon.stringParse(dtDanhMucKho.Rows[0]["IDDanhMucNguoiSuDungCreate"]),
                    IDDanhMucNguoiSuDungEdit = cenCommon.cenCommon.stringParse(dtDanhMucKho.Rows[0]["IDDanhMucNguoiSuDungEdit"]),
                    CreateDate = cenCommon.cenCommon.stringParse(dtDanhMucKho.Rows[0]["CreateDate"]),
                    EditDate = cenCommon.cenCommon.stringParse(dtDanhMucKho.Rows[0]["EditDate"]),
                };
            }

            var Employee = obj;
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateKho(DanhMucDiaDiemGiaoNhan emp)
        {
            emp.IDDanhMucNguoiSuDungEdit = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            cenDTO.msgResponse msgResponse = DanhMucDiaDiemGiaoNhanBUS.Update(ref emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddKho(DanhMucDiaDiemGiaoNhan emp)
        {
            emp.IDDanhMucDonVi = cenCommon.GlobalVariables.IDDonVi;
            emp.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKho));
            emp.IDDanhMucNguoiSuDungCreate = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            cenDTO.msgResponse msgResponse = DanhMucDiaDiemGiaoNhanBUS.Insert(ref emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteKho(string ID)
        {
            cenDTO.msgResponse msgResponse = DanhMucDiaDiemGiaoNhanBUS.Delete(ID);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        //CẢNG-ICD
        public ActionResult CangICDIndex()
        {
            UserSession Session = UserSessionHelper.GetSession();
            if (Session == null)
                return RedirectToAction("Login", "DanhMucNguoiSuDung");
            return View();
        }
        public JsonResult ListCangICD()
        {
            DataTable dtDanhMucCangICD = DanhMucDiaDiemGiaoNhanBUS.List(null, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongCangICD)), null);
            List<DanhMucDiaDiemGiaoNhan> listCangICD = new List<DanhMucDiaDiemGiaoNhan>();
            foreach (DataRow drCangICD in dtDanhMucCangICD.Rows)
            {
                listCangICD.Add(new DanhMucDiaDiemGiaoNhan()
                {
                    ID = drCangICD["ID"].ToString(),
                    IDDanhMucDonVi = drCangICD["IDDanhMucDonVi"].ToString(),
                    IDDanhMucLoaiDoiTuong = drCangICD["IDDanhMucLoaiDoiTuong"].ToString(),
                    Ma = drCangICD["Ma"].ToString(),
                    Ten = drCangICD["Ten"].ToString(),
                    DiaChi = drCangICD["DiaChi"].ToString(),
                    IDDanhMucNguoiSuDungEdit = drCangICD["IDDanhMucNguoiSuDungEdit"].ToString(),
                    IDDanhMucNguoiSuDungCreate = drCangICD["IDDanhMucNguoiSuDungCreate"].ToString(),
                    CreateDate = drCangICD["CreateDate"].ToString(),
                    EditDate = drCangICD["EditDate"].ToString(),
                });

            }
            ViewBag.ListCangICD = listCangICD;

            return Json(listCangICD, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCangICDbyID(string ID)
        {
            DataTable dtDanhMucCangICD = DanhMucDiaDiemGiaoNhanBUS.List(ID, DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongCangICD)), null);
            DanhMucDiaDiemGiaoNhan obj = null;
            if (dtDanhMucCangICD.Rows.Count == 1)
            {
                obj = new DanhMucDiaDiemGiaoNhan()
                {
                    ID = cenCommon.cenCommon.stringParse(dtDanhMucCangICD.Rows[0]["ID"]),
                    IDDanhMucDonVi = cenCommon.cenCommon.stringParse(dtDanhMucCangICD.Rows[0]["IDDanhMucDonVi"]),
                    IDDanhMucLoaiDoiTuong = cenCommon.cenCommon.stringParse(dtDanhMucCangICD.Rows[0]["IDDanhMucLoaiDoiTuong"]),
                    Ma = cenCommon.cenCommon.stringParse(dtDanhMucCangICD.Rows[0]["Ma"]),
                    Ten = cenCommon.cenCommon.stringParse(dtDanhMucCangICD.Rows[0]["Ten"]),
                    DiaChi = cenCommon.cenCommon.stringParse(dtDanhMucCangICD.Rows[0]["DiaChi"]),
                    IDDanhMucNguoiSuDungCreate = cenCommon.cenCommon.stringParse(dtDanhMucCangICD.Rows[0]["IDDanhMucNguoiSuDungCreate"]),
                    IDDanhMucNguoiSuDungEdit = cenCommon.cenCommon.stringParse(dtDanhMucCangICD.Rows[0]["IDDanhMucNguoiSuDungEdit"]),
                    CreateDate = cenCommon.cenCommon.stringParse(dtDanhMucCangICD.Rows[0]["CreateDate"]),
                    EditDate = cenCommon.cenCommon.stringParse(dtDanhMucCangICD.Rows[0]["EditDate"]),
                };
            }

            var Employee = obj;
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateCangICD(DanhMucDiaDiemGiaoNhan emp)
        {
            emp.IDDanhMucNguoiSuDungEdit = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            cenDTO.msgResponse msgResponse = DanhMucDiaDiemGiaoNhanBUS.Update(ref emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddCangICD(DanhMucDiaDiemGiaoNhan emp)
        {
            emp.IDDanhMucDonVi = cenCommon.GlobalVariables.IDDonVi;
            emp.IDDanhMucLoaiDoiTuong = DanhMucLoaiDoiTuongBUS.GetID(DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongCangICD));
            emp.IDDanhMucNguoiSuDungCreate = UserSessionHelper.GetSession().IDDanhMucNguoiSuDung;
            cenDTO.msgResponse msgResponse = DanhMucDiaDiemGiaoNhanBUS.Insert(ref emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCangICD(string ID)
        {
            cenDTO.msgResponse msgResponse = DanhMucDiaDiemGiaoNhanBUS.Delete(ID);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
    }
}
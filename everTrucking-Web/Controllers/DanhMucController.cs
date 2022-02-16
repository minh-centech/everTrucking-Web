using everTrucking_Web.Code.DTO;
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
using everTrucking_Web.Code.BUS;
using everTrucking_Web.Code.DAO;

namespace everTrucking_Web.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: QuanLyDonHang
        public ActionResult KhachHangIndex()
        {
            DataTable dtDanhMucKhachHang = Code.BUS.DanhMucKhachHangBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongKhachHang, null);
            List<DanhMucKhachHang> listKhachHang = new List<DanhMucKhachHang>();
            foreach (DataRow drKhachHang in dtDanhMucKhachHang.Rows)
            {
               listKhachHang.Add(new DanhMucKhachHang()
                {
                    ID = drKhachHang["ID"].ToString(),
                   Ma = drKhachHang["Ma"].ToString(),
                    Ten = drKhachHang["Ten"].ToString(),
                   MaCS = drKhachHang["MaCS"].ToString(),
                   IDDanhMucDonVi = drKhachHang["IDDanhMucDonVi"].ToString(),
                   IDDanhMucLoaiDoiTuong = drKhachHang["IDDanhMucLoaiDoiTuong"].ToString(),
                   IDDanhMucNguoiSuDungEdit = drKhachHang["IDDanhMucNguoiSuDungEdit"].ToString(),
                   IDDanhMucNguoiSuDungCreate = drKhachHang["IDDanhMucNguoiSuDungCreate"].ToString(),
                   TenEN = drKhachHang["TenEN"].ToString(),
                   DiaChi = drKhachHang["DiaChi"].ToString(),
                   MaSoThue = drKhachHang["MaSoThue"].ToString(),
                   Nhom = drKhachHang["Nhom"].ToString(),
                   ViTri = drKhachHang["ViTri"].ToString(),
                   GhiChu = drKhachHang["GhiChu"].ToString(),
                   CreateDate = drKhachHang["CreateDate"].ToString(),
                   EditDate = drKhachHang["EditDate"].ToString(),




               });

            }
            ViewBag.ListKhachHang = listKhachHang;
            return View(listKhachHang);
        }
        public JsonResult List()
        {
            DataTable dtDanhMucKhachHang = Code.BUS.DanhMucKhachHangBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongKhachHang, null);
            List<DanhMucKhachHang> listKhachHang = new List<DanhMucKhachHang>();
            foreach (DataRow drKhachHang in dtDanhMucKhachHang.Rows)
            {
                listKhachHang.Add(new DanhMucKhachHang()
                {
                    ID = drKhachHang["ID"].ToString(),
                    Ma = drKhachHang["Ma"].ToString(),
                    Ten = drKhachHang["Ten"].ToString(),
                    MaCS = drKhachHang["MaCS"].ToString(),
                    IDDanhMucDonVi = drKhachHang["IDDanhMucDonVi"].ToString(),
                    IDDanhMucLoaiDoiTuong = drKhachHang["IDDanhMucLoaiDoiTuong"].ToString(),
                    IDDanhMucNguoiSuDungEdit = drKhachHang["IDDanhMucNguoiSuDungEdit"].ToString(),
                    IDDanhMucNguoiSuDungCreate = drKhachHang["IDDanhMucNguoiSuDungCreate"].ToString(),
                    TenEN = drKhachHang["TenEN"].ToString(),
                    DiaChi = drKhachHang["DiaChi"].ToString(),
                    MaSoThue = drKhachHang["MaSoThue"].ToString(),
                    Nhom = drKhachHang["Nhom"].ToString(),
                    ViTri = drKhachHang["ViTri"].ToString(),
                    GhiChu = drKhachHang["GhiChu"].ToString(),
                    CreateDate = drKhachHang["CreateDate"].ToString(),
                    EditDate = drKhachHang["EditDate"].ToString(),




                });

            }
            ViewBag.ListKhachHang = listKhachHang;
           
            return Json(listKhachHang, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(string ID)
        {
            DataTable dtDanhMucKhachHang = Code.BUS.DanhMucKhachHangBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongKhachHang, null);
            List<DanhMucKhachHang> listKhachHang = new List<DanhMucKhachHang>();
            foreach (DataRow drKhachHang in dtDanhMucKhachHang.Rows)
            {
                listKhachHang.Add(new DanhMucKhachHang()
                {
                    ID = drKhachHang["ID"].ToString(),
                    Ma = drKhachHang["Ma"].ToString(),
                    Ten = drKhachHang["Ten"].ToString(),
                    MaCS = drKhachHang["MaCS"].ToString(),
                    IDDanhMucDonVi = drKhachHang["IDDanhMucDonVi"].ToString(),
                    IDDanhMucLoaiDoiTuong = drKhachHang["IDDanhMucLoaiDoiTuong"].ToString(),
                    IDDanhMucNguoiSuDungEdit = drKhachHang["IDDanhMucNguoiSuDungEdit"].ToString(),
                    IDDanhMucNguoiSuDungCreate = drKhachHang["IDDanhMucNguoiSuDungCreate"].ToString(),
                    TenEN = drKhachHang["TenEN"].ToString(),
                    DiaChi = drKhachHang["DiaChi"].ToString(),
                    MaSoThue = drKhachHang["MaSoThue"].ToString(),
                    Nhom = drKhachHang["Nhom"].ToString(),
                    ViTri = drKhachHang["ViTri"].ToString(),
                    GhiChu = drKhachHang["GhiChu"].ToString(),
                    CreateDate = drKhachHang["CreateDate"].ToString(),
                    EditDate = drKhachHang["EditDate"].ToString(),
                });

            }
            
            var Employee = listKhachHang.Find(x => x.ID.Equals(ID));
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(DanhMucKhachHang emp)
        {
            DanhMucKhachHangDAO empDB = new DanhMucKhachHangDAO();
            return Json(empDB.Update(ref emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(DanhMucKhachHang emp)
        {
            DanhMucKhachHangDAO empDB = new DanhMucKhachHangDAO();
            return Json(empDB.Insert(ref emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string ID)
        {

            DanhMucKhachHangDAO empDB = new DanhMucKhachHangDAO();
            return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }


      
        public ActionResult SaleIndex()
        {
            DataTable dtDanhMucSale = Code.BUS.DanhMucDoiTuongBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongNhanSu, null);
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
            ViewBag.ListSale = listSale;
            return View();
        }
        public ActionResult KhoIndex()
        {
            DataTable dtDanhMucDiaDiemGiaoNhan = Code.BUS.DanhMucDiaDiemGiaoNhanBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongKho, null);
            List<DanhMucDiaDiemGiaoNhan> listDiaDiemGiaoNhan = new List<DanhMucDiaDiemGiaoNhan>();
            foreach (DataRow drDiaDiemGiaoNhan in dtDanhMucDiaDiemGiaoNhan.Rows)
            {
                listDiaDiemGiaoNhan.Add(new DanhMucDiaDiemGiaoNhan()
                {
                    ID = drDiaDiemGiaoNhan["ID"].ToString(),
                    Ma = drDiaDiemGiaoNhan["Ma"].ToString(),
                    Ten = drDiaDiemGiaoNhan["Ten"].ToString(),
                    DiaChi = drDiaDiemGiaoNhan["DiaChi"].ToString(),
                });
            }
            ViewBag.ListDiaDiemGiaoNhan = listDiaDiemGiaoNhan;
            return View();
        }
        public ActionResult CangICDIndex()
        {
            DataTable dtDanhMucDiaDiemGiaoNhan = Code.BUS.DanhMucDiaDiemGiaoNhanBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongCangICD, null);
            List<DanhMucDiaDiemGiaoNhan> listDiaDiemGiaoNhan = new List<DanhMucDiaDiemGiaoNhan>();
            foreach (DataRow drDiaDiemGiaoNhan in dtDanhMucDiaDiemGiaoNhan.Rows)
            {
                listDiaDiemGiaoNhan.Add(new DanhMucDiaDiemGiaoNhan()
                {
                    ID = drDiaDiemGiaoNhan["ID"].ToString(),
                    Ma = drDiaDiemGiaoNhan["Ma"].ToString(),
                    Ten = drDiaDiemGiaoNhan["Ten"].ToString(),
                    DiaChi = drDiaDiemGiaoNhan["DiaChi"].ToString(),
                });
            }
            ViewBag.ListDiaDiemGiaoNhan = listDiaDiemGiaoNhan;
            return View();
        }


        //public void InsertToDB(string username, string phone, string email, string code, string filename)
      //  {
            //this.resumeRepository.Entity.Create(
            //    new Resume
            //    {

            //    }
            //    );
          //  var resume_results = Request.Form.Keys;
          //  resume_results.Add("");
        //}
    }
}
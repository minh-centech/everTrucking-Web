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





               });

            }
            ViewBag.ListKhachHang = listKhachHang;
            return View(listKhachHang);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View("KhachHangIndex");
        }
        [HttpPost]
        public ActionResult Create(DanhMucKhachHang model)
        {
            if (ModelState.IsValid)
            {
                var bus = new DanhMucKhachHangBUS();
                bool id = bus.Insert(ref model);
                model.listChiTiet = JsonConvert.DeserializeObject<List<DanhMucKhachHang.ChiTiet>>(model.strChiTiet);
                if (id)
                {

                    return RedirectToAction("KhachHangIndex", "DanhMuc");
                }

               // else
                //{
                //    ModelState.AddModelError("", "Thêm User không thành công");
                //}
            }

            return View("");
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
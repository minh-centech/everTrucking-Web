using everTrucking_Web.Code.BUS;
using everTrucking_Web.Code.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace everTrucking_Web.Controllers
{
    public class DanhMucKhachHangController : Controller
    {
        // GET: DanhMucKhachHang
        public ActionResult Index()
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
                 //   IDDanhMucDonVi = drKhachHang["IDDanhMucDonVi"].ToString(),
                  //  IDDanhMucLoaiDoiTuong = drKhachHang["IDDanhMucLoaiDoiTuong"].ToString(),
                  //  TenEN = drKhachHang["TenEN"].ToString(),
                  //  DiaChi = drKhachHang["DiaChi"].ToString(),
                  //  MaSoThue = drKhachHang["MaSoThue"].ToString(),
                   // Nhom = drKhachHang["Nhom"].ToString(),
                  //  ViTri = drKhachHang["ViTri"].ToString(),
                  //  GhiChu = drKhachHang["GhiChu"].ToString(),
                  //  IDDanhMucNguoiSuDungCreate = drKhachHang["IDDanhMucNguoiSuDungCreate"].ToString(),
                 //   IDDanhMucNguoiSuDungEdit = drKhachHang["IDDanhMucNguoiSuDungEdit"].ToString(),
                 //   CreateDate = drKhachHang["CreateDate"].ToString(),
                  //  EditDate = drKhachHang["EditDate"].ToString(),
                  

                }); ;

            }
            //ViewBag.ListKhachHang = listKhachHang;
            return View(listKhachHang);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(DanhMucKhachHang model)
        {
            if (ModelState.IsValid)
            {
                var bus = new DanhMucKhachHangBUS();
                bool id = bus.Insert(ref model);

                if (id)
                {

                    return RedirectToAction("Index", "DanhMucKhachHang");
                }

                else
                {
                    ModelState.AddModelError("", "Thêm User không thành công");
                }
            }

            return View("Index");
        }

    }
}
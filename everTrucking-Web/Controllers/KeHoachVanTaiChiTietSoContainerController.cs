using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using cenBUS.cenLogistics;
using cenBUS.DatabaseCore;

namespace everTrucking_Web.Controllers
{
    public class KeHoachVanTaiChiTietSoContainerController : Controller
    {
        // GET: KeHoachVanTai
        // [HttpGet]


        public ActionResult Index(listChungTuRequest model)
        {
            ViewBag.IDDanhKhachHangDefault = string.Empty;
            DataTable dtDanhMucKhachHang = Code.BUS.DanhMucKhachHangBUS.List(null, DanhMucThamSoHeThongBUS.GetGiaTri(cenCommon.ThamSoHeThong.MaThamSoLoaiDoiTuongKhachHang), null);
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

            DataTable dtKeHoachVanTai = ctKeHoachVanTaiChiTietSoContainerBUS.ListDisplay(Code.GlobalVariables.IDDanhMucChungTuKeHoachVanTai, DateTime.Now, DateTime.Now, null, null);
            List<ctKeHoachVanTaiChiTietSoContainer> listKeHoachVanTai = new List<ctKeHoachVanTaiChiTietSoContainer>();
            foreach (DataRow drKeHoachVanTai in dtKeHoachVanTai.Rows)
            {
                listKeHoachVanTai.Add(new ctKeHoachVanTaiChiTietSoContainer()
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

            DataSet dsKeHoachVanTai = ctKeHoachVanTaiChiTietSoContainerBUS.List(Code.GlobalVariables.IDDanhMucChungTuKeHoachVanTai, ID);
            List<ctKeHoachVanTaiChiTietSoContainer> listKeHoachVanTai = new List<ctKeHoachVanTaiChiTietSoContainer>();
            if (dsKeHoachVanTai.Tables[ctKeHoachVanTaiChiTietSoContainer.tableName].Rows.Count > 0)
            {
                foreach (DataRow drKeHoachVanTai in dsKeHoachVanTai.Tables[ctKeHoachVanTaiChiTietSoContainer.tableName].Rows)
                {
                    ctKeHoachVanTaiChiTietSoContainer obj = new ctKeHoachVanTaiChiTietSoContainer()
                    {
                        ID = drKeHoachVanTai["ID"].ToString(),
                        IDDanhMucDonVi = drKeHoachVanTai["IDDanhMucDonVi"].ToString(),
                        IDDanhMucChungTu = drKeHoachVanTai["IDDanhMucChungTu"].ToString(),
                        IDDanhMucChungTuTrangThai = drKeHoachVanTai["IDDanhMucChungTuTrangThai"].ToString(),
                        So = drKeHoachVanTai["So"].ToString(),
                        NgayLap = drKeHoachVanTai["NgayLap"].ToString(),
                        IDDanhMucSale = drKeHoachVanTai["IDDanhMucSale"].ToString(),
                        IDDanhMucKhachHang = drKeHoachVanTai["IDDanhMucKhachHang"].ToString(),
                        TenDanhMucKhachHang = drKeHoachVanTai["TenDanhMucKhachHang"].ToString(),
                        LoaiHinh = drKeHoachVanTai["LoaiHinh"].ToString(),
                        TenLoaiHinh = drKeHoachVanTai["TenLoaiHinh"].ToString(),
                        LoaiHang = drKeHoachVanTai["LoaiHang"].ToString(),
                        TenLoaiHang = drKeHoachVanTai["TenLoaiHang"].ToString(),
                        IDDanhMucHangTau = drKeHoachVanTai["IDDanhMucHangTau"].ToString(),
                        IDDanhMucDiaDiemNangCont = drKeHoachVanTai["IDDanhMucDiaDiemNangCont"].ToString(),
                        NgayNangCont = drKeHoachVanTai["NgayNangCont"].ToString(),
                        IDDanhMucDiaDiemHaCont = drKeHoachVanTai["IDDanhMucDiaDiemHaCont"].ToString(),
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
                        NgayDongHang = drKeHoachVanTai["NgayDongHang"].ToString(),
                        IDDanhMucDiaDiemTraHang = drKeHoachVanTai["IDDanhMucDiaDiemTraHang"].ToString(),
                        NgayTraHang = drKeHoachVanTai["NgayTraHang"].ToString(),
                        KhoiLuong = drKeHoachVanTai["KhoiLuong"].ToString(),
                        NguoiGiaoNhan = drKeHoachVanTai["NguoiGiaoNhan"].ToString(),
                        SoDienThoaiGiaoNhan = drKeHoachVanTai["SoDienThoaiGiaoNhan"].ToString(),
                        GhiChu = drKeHoachVanTai["GhiChu"].ToString(),
                        IDDanhMucNguoiSuDungCreate = drKeHoachVanTai["IDDanhMucNguoiSuDungCreate"].ToString(),
                        CreateDate = drKeHoachVanTai["CreateDate"].ToString(),
                        EditDate = drKeHoachVanTai["EditDate"].ToString(),
                    };

                    foreach (DataRow drKeHoachVanTaiChiTietSoContainer in dsKeHoachVanTai.Tables[ctKeHoachVanTaiChiTietSoContainer.ctKeHoachVanTaiChiTietSoContainerChiTiet.tableName].Rows)
                    {
                        if (Code.Common.stringParse(drKeHoachVanTaiChiTietSoContainer["IDChungTu"]) == obj.ID)
                        {
                            obj.listChiTiet.Add(new ctKeHoachVanTaiChiTietSoContainer.ctKeHoachVanTaiChiTietSoContainerChiTiet
                            {
                                ID = drKeHoachVanTaiChiTietSoContainer["ID"].ToString(),
                                IDDanhMucDonVi = drKeHoachVanTaiChiTietSoContainer["IDDanhMucDonVi"].ToString(),
                                IDDanhMucChungTu = drKeHoachVanTaiChiTietSoContainer["IDDanhMucChungTu"].ToString(),
                                IDChungTu = drKeHoachVanTaiChiTietSoContainer["IDChungTu"].ToString(),
                                SoContainer = drKeHoachVanTaiChiTietSoContainer["SoContainer"].ToString(),
                            });
                        }
                    }
                    listKeHoachVanTai.Add(obj);
                }
            }
            var Employee = listKeHoachVanTai[0];
            return Json(Employee, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ctKeHoachVanTaiChiTietSoContainer emp)
        {
            cenDTO.msgResponse msgResponse = ctKeHoachVanTaiChiTietSoContainerBUS.Update(emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(ctKeHoachVanTaiChiTietSoContainer emp)
        {

            cenDTO.msgResponse msgResponse = ctKeHoachVanTaiChiTietSoContainerBUS.Insert(emp);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string ID)
        {
            cenDTO.msgResponse msgResponse = ctKeHoachVanTaiChiTietSoContainerBUS.Delete(ID);
            return Json(msgResponse, JsonRequestBehavior.AllowGet);
        }
    }
}
using System.Collections.Generic;
using System.Data;
namespace cenDTO
{
    public class ctKeHoachVanTai
    {
        public const string tableName = "ctKeHoachVanTai";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        
        public const string listDisplayProcedureName = "List_" + tableName + "_Display";
        //
        public string ID { get; set; }
        public string IDDanhMucDonVi{ get; set; }
        public string IDDanhMucChungTu { get; set; }
        public string IDDanhMucChungTuTrangThai { get; set; }
        public string So { get; set; }
        public string NgayLap { get; set; }
        //
        public string IDDanhMucSale { get; set; }
        public string TenDanhMucSale { get; set; }
        public string IDDanhMucKhachHang { get; set; }
        public string MaDanhMucKhachHang { get; set; }
        public string TenDanhMucKhachHang { get; set; }
        public string LoaiHinh { get; set; }
        public string TenLoaiHinh { get; set; }
        public string LoaiHang { get; set; }
        public string TenLoaiHang { get; set; }
        public string IDDanhMucHangTau { get; set; }
        public string MaDanhMucHangTau { get; set; }
        public string TenDanhMucHangTau { get; set; }
        public string IDDanhMucLoaiContainer { get; set; }
        public string MaDanhMucLoaiContainer { get; set; }
        public string SoLuongContainer { get; set; }
        public string SoContainer { get; set; }
        public string KhoiLuong { get; set; }
        public string IDDanhMucDiaDiemNangCont { get; set; }
        public string TenDanhMucDiaDiemNangCont { get; set; }
        public string NgayNangCont { get; set; }
        public string IDDanhMucDiaDiemHaCont { get; set; }
        public string TenDanhMucDiaDiemHaCont { get; set; }
        public string NgayHaCont { get; set; }
        public string IDDanhMucDiaDiemGiaoNhan { get; set; }
        public string MaDanhMucDiaDiemGiaoNhan { get; set; }
        public string TenDanhMucDiaDiemGiaoNhan { get; set; }
        public string NgayGiaoNhan { get; set; }
        public string NguoiGiaoNhan { get; set; }
        public string SoDienThoaiGiaoNhan { get; set; }
        //
        public string GhiChu { get; set; }
        public string IDDanhMucNguoiSuDungCreate { get; set; }
        public string MaDanhMucNguoiSuDungCreate { get; set; }
        public string TenDanhMucNguoiSuDungCreate { get; set; }
        public object CreateDate { get; set; }
        public string IDDanhMucNguoiSuDungEdit { get; set; }
        public string MaDanhMucNguoiSuDungEdit { get; set; }
        public string TenDanhMucNguoiSuDungEdit { get; set; }
        public object EditDate { get; set; }
        //
        public ctKeHoachVanTai()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            IDDanhMucSale = null;
            TenDanhMucSale = null;
            IDDanhMucKhachHang = null;
            TenDanhMucKhachHang = null;
            LoaiHinh = null;
            TenLoaiHinh = null;
            LoaiHang = null;
            TenLoaiHang = null;
            IDDanhMucHangTau = null;
            MaDanhMucHangTau = null;
            TenDanhMucHangTau = null;
            IDDanhMucLoaiContainer = null;
            MaDanhMucLoaiContainer = null;
            SoLuongContainer = null;
            SoContainer = null;
            KhoiLuong = null;
            IDDanhMucDiaDiemNangCont = null;
            TenDanhMucDiaDiemNangCont = null;
            NgayNangCont = null;
            IDDanhMucDiaDiemHaCont = null;
            TenDanhMucDiaDiemHaCont = null;
            NgayHaCont = null;
            IDDanhMucDiaDiemGiaoNhan = null;
            MaDanhMucDiaDiemGiaoNhan = null;
            TenDanhMucDiaDiemGiaoNhan = null;
            NgayGiaoNhan = null;
            KhoiLuong = null;
            NguoiGiaoNhan = null;
            SoDienThoaiGiaoNhan = null;
            //
            IDDanhMucNguoiSuDungCreate = null;
            MaDanhMucNguoiSuDungCreate = null;
            TenDanhMucNguoiSuDungCreate = null;
            CreateDate = null;
            IDDanhMucNguoiSuDungEdit = null;
            MaDanhMucNguoiSuDungEdit = null;
            TenDanhMucNguoiSuDungEdit = null;
            EditDate = null;
           
        }
    }
    public class rptKeHoachVanTaiTongHop
    {
        public const string listProcedureName = "rptKeHoachVanTaiTongHop";
        public string Stt { get; set; }
        public string NgayLap { get; set; }
        public string TenLoaiHinh { get; set; }
        public string LoaiContainer { get; set; }
        public string SoLuongContainer { get; set; }
        public string SoContainer { get; set; }
        public string TenDanhMucKhachHang { get; set; }
        public string KhoiLuong { get; set; }
        public string TenDanhMucHangTau { get; set; }
        public string GhiChu { get; set; }
        public string TenDanhMucDiaDiemNangHa { get; set; }
        public string TenDanhMucDiaDiemGiaoNhan { get; set; }
        public rptKeHoachVanTaiTongHop()
        {
            Stt = null;
            NgayLap = null;
            TenLoaiHinh = null;
            LoaiContainer = null;
            SoLuongContainer = null;
            SoContainer = null;
            TenDanhMucKhachHang = null;
            KhoiLuong = null;
            TenDanhMucHangTau = null;
            GhiChu = null;
            TenDanhMucDiaDiemNangHa = null;
            TenDanhMucDiaDiemGiaoNhan = null;
        }
    }
}

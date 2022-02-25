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
        public string IDDanhMucDiaDiemNangCont { get; set; }
        public string TenDanhMucDiaDiemNangCont { get; set; }
        public string NgayNangCont { get; set; }
        public string IDDanhMucDiaDiemHaCont { get; set; }
        public string TenDanhMucDiaDiemHaCont { get; set; }
        public string NgayHaCont { get; set; }
        public string SoLuongCont20 { get; set; }
        public string SoCont20 { get; set; }
        public string SoLuongCont40 { get; set; }
        public string SoCont40 { get; set; }
        public string SoLuongCont45 { get; set; }
        public string SoCont45 { get; set; }
        public string SoLuongContOpenTop { get; set; }
        public string SoContOpenTop { get; set; }
        public string SoLuongContFlatRack { get; set; }
        public string SoContFlatRack { get; set; }
        public string IDDanhMucDiaDiemDongHang { get; set; }
        public string TenDanhMucDiaDiemDongHang { get; set; }
        public string NgayDongHang { get; set; }
        public string IDDanhMucDiaDiemTraHang { get; set; }
        public string TenDanhMucDiaDiemTraHang { get; set; }
        public string NgayTraHang { get; set; }
        public string KhoiLuong { get; set; }
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
            IDDanhMucDiaDiemNangCont = null;
            TenDanhMucDiaDiemNangCont = null;
            NgayNangCont = null;
            IDDanhMucDiaDiemHaCont = null;
            TenDanhMucDiaDiemHaCont = null;
            NgayHaCont = null;
            SoLuongCont20 = null;
            SoCont20 = null;
            SoLuongCont40 = null;
            SoCont40 = null;
            SoLuongCont45 = null;
            SoCont45 = null;
            IDDanhMucDiaDiemDongHang = null;
            TenDanhMucDiaDiemDongHang = null;
            NgayDongHang = null;
            IDDanhMucDiaDiemTraHang = null;
            TenDanhMucDiaDiemTraHang = null;
            NgayTraHang = null;
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
}

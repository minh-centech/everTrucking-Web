using System.Collections.Generic;
using System.Data;
namespace everTrucking_Web.Code.DTO
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
        public object IDDanhMucSale { get; set; }
        public object TenDanhMucSale { get; set; }
        public object IDDanhMucKhachHang { get; set; }
        public object TenDanhMucKhachHang { get; set; }
        public object LoaiHinh { get; set; }
        public object TenLoaiHinh { get; set; }
        public object LoaiHang { get; set; }
        public object TenLoaiHang { get; set; }
        public object IDDanhMucHangTau { get; set; }
        public object TenDanhMucHangTau { get; set; }
        public object IDDanhMucDiaDiemNangCont { get; set; }
        public object TenDanhMucDiaDiemNangCont { get; set; }
        public object NgayNangCont { get; set; }
        public object IDDanhMucDiaDiemHaCont { get; set; }
        public object TenDanhMucDiaDiemHaCont { get; set; }
        public object NgayHaCont { get; set; }
        public object SoLuongCont20 { get; set; }
        public object SoCont20 { get; set; }
        public object SoLuongCont40 { get; set; }
        public object SoCont40 { get; set; }
        public object SoLuongCont45 { get; set; }
        public object SoCont45 { get; set; }
        public object SoLuongContOpenTop { get; set; }
        public object SoContOpenTop { get; set; }
        public object SoLuongContFlatRack { get; set; }
        public object SoContFlatRack { get; set; }
        public object IDDanhMucDiaDiemDongHang { get; set; }
        public object TenDanhMucDiaDiemDongHang { get; set; }
        public object NgayDongHang { get; set; }
        public object IDDanhMucDiaDiemTraHang { get; set; }
        public object TenDanhMucDiaDiemTraHang { get; set; }
        public object NgayTraHang { get; set; }
        public object KhoiLuong { get; set; }
        public object NguoiGiaoNhan { get; set; }
        public object SoDienThoaiGiaoNhan { get; set; }
        //
        public string GhiChu { get; set; }
        public string IDDanhMucNguoiSuDungCreate { get; set; }
        public string MaDanhMucNguoiSuDungCreate { get; set; }
        public string TenDanhMucNguoiSuDungCreate { get; set; }
        public string CreateDate { get; set; }
        public string IDDanhMucNguoiSuDungEdit { get; set; }
        public string MaDanhMucNguoiSuDungEdit { get; set; }
        public string TenDanhMucNguoiSuDungEdit { get; set; }
        public string EditDate { get; set; }
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
            TenDanhMucHangTau = null;
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

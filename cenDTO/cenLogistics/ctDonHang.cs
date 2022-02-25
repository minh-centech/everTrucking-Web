using System.Collections.Generic;
using System.Data;
namespace cenDTO.cenLogistics
{
    public class ctDonHang : ctDTO
    {
        public object IDDanhMucSale { get; set; }
        public object IDDanhMucKhachHang { get; set; }
        public object MaDanhMucKhachHang { get; set; }
        public object TenDanhMucKhachHang { get; set; }
        public object IDDanhMucKhachHangF2 { get; set; }
        public object DebitNote { get; set; }
        public object BillBooking { get; set; }
        public object LoaiHang { get; set; }
        public object IDDanhMucNhomHangVanChuyen { get; set; }
        public object IDDanhMucHangHoa { get; set; }
        public object IDDanhMucHangTau { get; set; }
        public object SoLuong { get; set; }
        public object KhoiLuong { get; set; }
        public object TheTich { get; set; }
        public object SoContainer { get; set; }
        public object IDDanhMucDiaDiemLayContHang { get; set; }
        public object IDDanhMucDiaDiemTraContHang { get; set; }
        public object NgayDongHang { get; set; }
        public object GioDongHang { get; set; }
        public object NgayTraHang { get; set; }
        public object GioTraHang { get; set; }
        public object IDDanhMucKhachHangF3DongHang { get; set; }
        public object IDDanhMucKhachHangF3TraHang { get; set; }
        public object IDDanhMucTuyenVanTai { get; set; }
        public object NgayCatMang { get; set; }
        public object GioCatMang { get; set; }
        public object NguoiGiaoNhan { get; set; }
        public object SoDienThoaiGiaoNhan { get; set; }
        public object SoTienCuoc { get; set; }
        public object SoTienThuTuc { get; set; }
        public object SoTienDoanhThuKhac { get; set; }
        public object SoTienHoaHong { get; set; }
        public object ThoiHanThanhToan { get; set; }
        public class ctDonHangChiTietTamUng
        {
            public object ID { get; set; }
            public object IDChungTu { get; set; }
            public object NgayTamUng { get; set; }
            public object LanTamUng { get; set; }
            public object IDDanhMucHangTau { get; set; }
            public object MaDanhMucHangTau { get; set; }
            public object TenDanhMucHangTau { get; set; }
            public object SoTienCuocVo { get; set; }
            public object SoTienHaiQuan { get; set; }
            public object SoTienNangHa { get; set; }
            public object SoTienChiKhac { get; set; }
            public object IDDanhMucCanBoTamUng { get; set; }
            public object MaDanhMucCanBoTamUng { get; set; }
            public object TenDanhMucCanBoTamUng { get; set; }
            public object ThoiHanThanhToan { get; set; }
            public object GhiChu { get; set; }
            public DataRowState DataRowState { get; set; }
        }

        public List<ctDonHangChiTietTamUng> listChiTiet;

        public const string tableName = "ctDonHang";
        public const string listProcedureName = "List_" + tableName;
        public const string listDisplayProcedureName = "List_" + tableName + "_Display";
        public const string listNhomHangVanChuyenProcedureName = "List_" + tableName + "_NhomHangVanChuyen";
        public const string validDebitNoteProcedureName = "List_" + tableName + "_ValidDebitNote";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string getIDctChotDoanhThuGuiKeToanProcedureName = "Get_" + tableName + "_IDctChotDoanhThuGuiKeToan";

        public const string tableNameChiTiet = tableName + "ChiTietTamUng";
        public const string listChiTietProcedureName = "List_" + tableNameChiTiet;
        public const string listIDChiTietProcedureName = "List_" + tableNameChiTiet + "_ID";
        public const string insertChiTietProcedureName = "Insert_" + tableNameChiTiet;
        public const string updateChiTietProcedureName = "Update_" + tableNameChiTiet;
        public const string deleteChiTietProcedureName = "Delete_" + tableNameChiTiet;
        //
        public ctDonHang()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            IDDanhMucSale = null;
            IDDanhMucKhachHang = null;
            MaDanhMucKhachHang = null;
            TenDanhMucKhachHang = null;
            IDDanhMucKhachHangF2 = null;
            DebitNote = null;
            BillBooking = null;
            LoaiHang = null;
            IDDanhMucNhomHangVanChuyen = null;
            IDDanhMucHangHoa = null;
            IDDanhMucHangTau = null;
            SoLuong = null;
            KhoiLuong = null;
            TheTich = null;
            SoContainer = null;
            IDDanhMucDiaDiemLayContHang = null;
            IDDanhMucDiaDiemTraContHang = null;
            NgayDongHang = null;
            GioDongHang = null;
            NgayTraHang = null;
            GioTraHang = null;
            IDDanhMucKhachHangF3DongHang = null;
            IDDanhMucKhachHangF3TraHang = null;
            IDDanhMucTuyenVanTai = null;
            NgayCatMang = null;
            GioCatMang = null;
            NguoiGiaoNhan = null;
            SoDienThoaiGiaoNhan = null;
            SoTienCuoc = null;
            SoTienThuTuc = null;
            SoTienDoanhThuKhac = null;
            SoTienHoaHong = null;
            ThoiHanThanhToan = null;
            GhiChu = null;
            //
            IDDanhMucNguoiSuDungCreate = null;
            MaDanhMucNguoiSuDungCreate = null;
            TenDanhMucNguoiSuDungCreate = null;
            CreateDate = null;
            IDDanhMucNguoiSuDungEdit = null;
            MaDanhMucNguoiSuDungEdit = null;
            TenDanhMucNguoiSuDungEdit = null;
            EditDate = null;
            listChiTiet = new List<ctDonHangChiTietTamUng>();
        }
    }
}

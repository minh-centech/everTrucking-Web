using System.Collections.Generic;
using System.Data;
namespace everTrucking_Web.Code.DTO
{
    public class ctDonHang
    {
        public const string tableName = "ctDonHang";
        public const string insertProcedureName = "Insert_" + tableName;
        public string ID { get; set; }
        public string IDDanhMucDonVi{ get; set; }
      
        public string IDDanhMucChungTu { get; set; }
        public string IDDanhMucChungTuTrangThai { get; set; }
        public string So { get; set; }

        public string NgayLap { get; set; }
        public string IDDanhMucSale { get; set; }
        public string IDDanhMucKhachHang { get; set; }
        public string MaDanhMucKhachHang { get; set; }
        public string TenDanhMucKhachHang { get; set; }
        public string IDDanhMucKhachHangF2 { get; set; }
        public string DebitNote { get; set; }
        public string BillBooking { get; set; }
        public string LoaiHang { get; set; }
        public string IDDanhMucNhomHangVanChuyen { get; set; }
        public string IDDanhMucHangHoa { get; set; }
        public string IDDanhMucHangTau { get; set; }
        public string SoLuong { get; set; }
        public string KhoiLuong { get; set; }
        public string TheTich { get; set; }
        public string SoContainer { get; set; }
        public string IDDanhMucDiaDiemLayContHang { get; set; }
        public string IDDanhMucDiaDiemTraContHang { get; set; }
        public string NgayDongHang { get; set; }
        public string GioDongHang { get; set; }
        public string NgayTraHang { get; set; }
        public string GioTraHang { get; set; }
        public string IDDanhMucKhachHangF3DongHang { get; set; }
        public string IDDanhMucKhachHangF3TraHang { get; set; }
        public string IDDanhMucTuyenVanTai { get; set; }
        public string NgayCatMang { get; set; }
        public string GioCatMang { get; set; }
        public string NguoiGiaoNhan { get; set; }
        public string SoDienThoaiGiaoNhan { get; set; }
        public string SoTienCuoc { get; set; }
        public string SoTienThuTuc { get; set; }
        public string SoTienDoanhThuKhac { get; set; }
        public string SoTienHoaHong { get; set; }
        public string ThoiHanThanhToan { get; set; }
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
           
        }
    }
}

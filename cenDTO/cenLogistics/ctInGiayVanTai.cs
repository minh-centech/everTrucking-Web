namespace cenDTO.cenLogistics
{
    public class ctInGiayVanTai : ctDTO
    {
        public object IDChungTu { get; set; }
        public object LoaiDonChuyen { get; set; }
        public object SoKmVoHangNhe { get; set; }
        public object SoKmHangNhe { get; set; }
        public object SoKmVoHangNang { get; set; }
        public object SoKmHangNang { get; set; }
        public object SoLuongNhienLieuDinhMuc { get; set; }
        public object SoLuongNhienLieuCapThem { get; set; }
        public object LyDoCapThem { get; set; }
        public object SoTienVeCauDuong { get; set; }
        public object SoTienLuatAnCa { get; set; }

        public const string tableName = "ctInGiayVanTai";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        //
        public ctInGiayVanTai()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            IDChungTu = null;
            LoaiDonChuyen = null;
            SoKmVoHangNhe = null;
            SoKmHangNhe = null;
            SoKmVoHangNang = null;
            SoKmHangNang = null;
            SoLuongNhienLieuDinhMuc = null;
            SoLuongNhienLieuCapThem = null;
            LyDoCapThem = null;
            SoTienVeCauDuong = null;
            SoTienLuatAnCa = null;
            //
            GhiChu = null;
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

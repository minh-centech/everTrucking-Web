namespace cenDTO.cenLogistics
{
    public class DanhMucDinhMucChiPhiHaiQuan : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object NgayApDung { get; set; }
        public object IDDanhMucNhomHangVanChuyen { get; set; }
        public object MaDanhMucNhomHangVanChuyen { get; set; }
        public object TenDanhMucNhomHangVanChuyen { get; set; }
        public object IDDanhMucHangHoa { get; set; }
        public object MaDanhMucHangHoa { get; set; }
        public object TenDanhMucHangHoa { get; set; }
        public object IDDanhMucKhachHang { get; set; }
        public object MaDanhMucKhachHang { get; set; }
        public object TenDanhMucKhachHang { get; set; }
        public object IDDanhMucChiPhiHaiQuanKinhDoanh { get; set; }
        public object MaDanhMucChiPhiHaiQuanKinhDoanh { get; set; }
        public object TenDanhMucChiPhiHaiQuanKinhDoanh { get; set; }
        public object SoTien { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucDinhMucChiPhiHaiQuan";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucDinhMucChiPhiHaiQuan()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            NgayApDung = null;
            IDDanhMucNhomHangVanChuyen = null;
            MaDanhMucNhomHangVanChuyen = null;
            TenDanhMucNhomHangVanChuyen = null;
            IDDanhMucHangHoa = null;
            MaDanhMucHangHoa = null;
            TenDanhMucHangHoa = null;
            IDDanhMucKhachHang = null;
            MaDanhMucKhachHang = null;
            TenDanhMucKhachHang = null;
            IDDanhMucChiPhiHaiQuanKinhDoanh = null;
            MaDanhMucChiPhiHaiQuanKinhDoanh = null;
            TenDanhMucChiPhiHaiQuanKinhDoanh = null;
            SoTien = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}

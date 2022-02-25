namespace cenDTO.cenLogistics
{
    public class DanhMucXe : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object BienSo { get; set; }
        public object IDDanhMucNhomXe { get; set; }
        public object MaDanhMucNhomXe { get; set; }
        public object TenDanhMucNhomXe { get; set; }
        public object IDDanhMucNhienLieu { get; set; }
        public object MaDanhMucNhienLieu { get; set; }
        public object TenDanhMucNhienLieu { get; set; }
        public object IDDanhMucThauPhu { get; set; }
        public object TenDanhMucThauPhu { get; set; }
        public object IDDanhMucNhomHangVanChuyen { get; set; }
        public object TenDanhMucNhomHangVanChuyen { get; set; }
        public object MaTaiKhoanDoanhThu { get; set; }
        public object MaTaiKhoanChietKhau { get; set; }
        public object HinhAnhMatTruoc { get; set; }
        public object HinhAnhNgang { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucXe";
        public const string listProcedureName = "List_" + tableName;
        public const string listHinhAnhProcedureName = "List_" + tableName + "_HinhAnh";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucXe()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            BienSo = null;
            IDDanhMucNhomXe = null;
            MaDanhMucNhomXe = null;
            TenDanhMucNhomXe = null;
            IDDanhMucNhienLieu = null;
            MaDanhMucNhienLieu = null;
            TenDanhMucNhienLieu = null;
            IDDanhMucThauPhu = null;
            TenDanhMucThauPhu = null;
            IDDanhMucNhomHangVanChuyen = null;
            TenDanhMucNhomHangVanChuyen = null;
            MaTaiKhoanDoanhThu = null;
            MaTaiKhoanChietKhau = null;
            HinhAnhMatTruoc = null;
            HinhAnhNgang = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}

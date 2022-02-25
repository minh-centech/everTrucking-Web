namespace cenDTO.cenLogistics
{
    public class DanhMucThauPhu : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object DiaChi { get; set; }
        public object SoDienThoai { get; set; }
        public object MaSoThueCMND { get; set; }
        public object IDDanhMucNhomHangVanChuyen { get; set; }
        public object KyHieuKeToan { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucThauPhu";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucThauPhu()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            Ma = null;
            Ten = null;
            DiaChi = null;
            SoDienThoai = null;
            MaSoThueCMND = null;
            IDDanhMucNhomHangVanChuyen = null;
            KyHieuKeToan = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}

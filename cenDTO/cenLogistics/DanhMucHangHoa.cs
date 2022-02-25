namespace cenDTO.cenLogistics
{
    public class DanhMucHangHoa : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object IDDanhMucNhomHangVanChuyen { get; set; }
        public object MaDanhMucNhomHangVanChuyen { get; set; }
        public object TenDanhMucNhomHangVanChuyen { get; set; }
        public object KichThuoc { get; set; }
        public object DonViTinh { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucHangHoa";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucHangHoa()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            Ma = null;
            Ten = null;
            IDDanhMucNhomHangVanChuyen = null;
            MaDanhMucNhomHangVanChuyen = null;
            TenDanhMucNhomHangVanChuyen = null;
            KichThuoc = null;
            DonViTinh = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}

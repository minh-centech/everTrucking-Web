namespace cenDTO.cenLogistics
{
    public class DanhMucGiaNhienLieu : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object IDDanhMucNhienLieu { get; set; }
        public object MaDanhMucNhienLieu { get; set; }
        public object TenDanhMucNhienLieu { get; set; }
        public object NgayGioApDung { get; set; }
        public object DonGiaTruocThue { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucGiaNhienLieu";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucGiaNhienLieu()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            IDDanhMucNhienLieu = null;
            MaDanhMucNhienLieu = null;
            TenDanhMucNhienLieu = null;
            NgayGioApDung = null;
            DonGiaTruocThue = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}

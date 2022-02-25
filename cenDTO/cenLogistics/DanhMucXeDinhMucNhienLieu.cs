namespace cenDTO.cenLogistics
{
    public class DanhMucXeDinhMucNhienLieu : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object NgayApDung { get; set; }
        public object IDDanhMucXe { get; set; }
        public object BienSo { get; set; }
        public object DinhMucNhienLieuHangNheVo { get; set; }
        public object DinhMucNhienLieuHangNhe { get; set; }
        public object DinhMucNhienLieuHangNangVo { get; set; }
        public object DinhMucNhienLieuHangNang { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucXeDinhMucNhienLieu";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucXeDinhMucNhienLieu()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            NgayApDung = null;
            IDDanhMucXe = null;
            BienSo = null;
            DinhMucNhienLieuHangNheVo = null;
            DinhMucNhienLieuHangNhe = null;
            DinhMucNhienLieuHangNangVo = null;
            DinhMucNhienLieuHangNang = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}

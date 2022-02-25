namespace cenDTO.cenLogistics
{
    public class DanhMucKhachHang : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public string TenEN { get; set; }
        public string MaCS { get; set; }
        public string DiaChi { get; set; }
        public string MaSoThue { get; set; }
        public string Nhom { get; set; }
        public string ViTri { get; set; }
        public string LoaiKhachHang { get; set; }
        public string TenLoaiKhachHang { get; set; }
        public string GhiChu { get; set; }
        public string IDDanhMucNguoiSuDungCreate { get; set; }
        public string IDDanhMucNguoiSuDungEdit { get; set; }
        public const string tableName = "DanhMucKhachHang";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string validProcedureName = "List_" + tableName + "_Valid";
        public DanhMucKhachHang()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            Ma = null;
            Ten = null;
            TenEN = null;
            MaCS = null;
            DiaChi = null;
            MaSoThue = null;
            Nhom = null;
            ViTri = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }


}

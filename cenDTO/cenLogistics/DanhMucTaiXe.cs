namespace cenDTO.cenLogistics
{
    public class DanhMucTaiXe : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object SoDienThoai { get; set; }
        public object DiaChi { get; set; }
        public object SoCMND { get; set; }
        public object SoBangLai { get; set; }
        public object IDDanhMucThauPhu { get; set; }
        public object TenDanhMucThauPhu { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucTaiXe";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucTaiXe()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            Ma = null;
            Ten = null;
            SoDienThoai = null;
            DiaChi = null;
            SoCMND = null;
            SoBangLai = null;
            IDDanhMucThauPhu = null;
            TenDanhMucThauPhu = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}

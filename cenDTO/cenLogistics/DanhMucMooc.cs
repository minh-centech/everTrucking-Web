namespace cenDTO.cenLogistics
{
    public class DanhMucMooc : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object BienSo { get; set; }
        public object IDDanhMucChuMooc { get; set; }
        public object MaDanhMucChuMooc { get; set; }
        public object TenDanhMucChuMooc { get; set; }
        public object TaiTrong { get; set; }
        public object HinhAnhMatTruoc { get; set; }
        public object HinhAnhNgang { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucMooc";
        public const string listProcedureName = "List_" + tableName;
        public const string listHinhAnhProcedureName = "List_" + tableName + "_HinhAnh";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucMooc()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            BienSo = null;
            IDDanhMucChuMooc = null;
            MaDanhMucChuMooc = null;
            TenDanhMucChuMooc = null;
            TaiTrong = null;
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

namespace cenDTO.cenLogistics
{
    public class DanhMucDinhMucChiPhi : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object NgayApDung { get; set; }
        public object IDDanhMucTuyenVanTai { get; set; }
        public object MaDanhMucTuyenVanTai { get; set; }
        public object TenDanhMucTuyenVanTai { get; set; }
        public object SoTienVeCauDuong { get; set; }
        public object SoTienLuatAnCa { get; set; }
        public object SoTienLuuCaKhac { get; set; }
        public object SoTienLuatDuongCam { get; set; }
        public object SoTienLuongChuyen { get; set; }
        public object SoTramLuat { get; set; }
        public object SoTramVe { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucDinhMucChiPhi";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucDinhMucChiPhi()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            NgayApDung = null;
            IDDanhMucTuyenVanTai = null;
            MaDanhMucTuyenVanTai = null;
            TenDanhMucTuyenVanTai = null;
            SoTienVeCauDuong = null;
            SoTienLuatAnCa = null;
            SoTienLuuCaKhac = null;
            SoTienLuatDuongCam = null;
            SoTienLuongChuyen = null;
            SoTramLuat = null;
            SoTramVe = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}

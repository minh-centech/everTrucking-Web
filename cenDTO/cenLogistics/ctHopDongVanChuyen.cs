namespace cenDTO.cenLogistics
{
    public class ctHopDongVanChuyen : ctDTO
    {
        public object SoHopDong { get; set; }
        public object NgayHopDong { get; set; }
        public object NgayCoHieuLuc { get; set; }
        public object NgayHetHieuLuc { get; set; }
        public object IDDanhMucKhachHang { get; set; }
        public object MaDanhMucKhachHang { get; set; }
        public object TenDanhMucKhachHang { get; set; }
        public object NoiDung { get; set; }
        public object SoTien { get; set; }
        public object TrangThaiHopDong { get; set; }
        public object FileName { get; set; }
        public object FileContent { get; set; }

        public const string tableName = "ctHopDongVanChuyen";
        public const string listProcedureName = "List_" + tableName;
        public const string listFileContentProcedureName = "List_" + tableName + "_FileContent";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public const string validSoHopDongProcedureName = "List_" + tableName + "_ValidSoHopDong";
        //
        public ctHopDongVanChuyen()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            SoHopDong = null;
            NgayHopDong = null;
            NgayCoHieuLuc = null;
            NgayHetHieuLuc = null;
            IDDanhMucKhachHang = null;
            MaDanhMucKhachHang = null;
            TenDanhMucKhachHang = null;
            NoiDung = null;
            SoTien = null;
            TrangThaiHopDong = null;
            FileName = null;
            FileContent = null;
            //
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            MaDanhMucNguoiSuDungCreate = null;
            TenDanhMucNguoiSuDungCreate = null;
            CreateDate = null;
            IDDanhMucNguoiSuDungEdit = null;
            MaDanhMucNguoiSuDungEdit = null;
            TenDanhMucNguoiSuDungEdit = null;
            EditDate = null;
        }

    }
}

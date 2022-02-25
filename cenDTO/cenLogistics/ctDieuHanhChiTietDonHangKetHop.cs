namespace cenDTO.cenLogistics
{
    public class ctDieuHanhChiTietDonHangKetHop : ctDTO
    {
        public object IDChungTu { get; set; }
        public object IDChungTuChiTiet { get; set; }
        public object IDctDonHang { get; set; }
        public object SoDonHang { get; set; }
        public object DebitNote { get; set; }

        public const string tableName = "ctDieuHanhChiTietDonHangKetHop";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        //
        public ctDieuHanhChiTietDonHangKetHop()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            IDChungTu = null;
            IDChungTuChiTiet = null;
            IDctDonHang = null;
            SoDonHang = null;
            DebitNote = null;
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

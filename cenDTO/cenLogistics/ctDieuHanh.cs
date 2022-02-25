namespace cenDTO.cenLogistics
{
    public class ctDieuHanh : ctDTO
    {
        public object IDChungTu { get; set; }
        public object IDDanhMucThauPhu { get; set; }
        public object TenDanhMucThauPhu { get; set; }
        public object IDDanhMucXe { get; set; }
        public object BienSo { get; set; }
        public object IDDanhMucTaiXe { get; set; }
        public object TenDanhMucTaiXe { get; set; }
        public object DienThoai { get; set; }
        public object TrangThaiDonHang { get; set; }
        public object SoDonHangKetHop { get; set; }

        public const string tableName = "ctDieuHanh";
        public const string listProcedureName = "List_" + tableName;
        public const string list2ProcedureName = "List_" + tableName + "2";
        public const string listDisplayProcedureName = "List_" + tableName + "_Display";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        //
        public ctDieuHanh()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            IDChungTu = null;
            IDDanhMucThauPhu = null;
            TenDanhMucThauPhu = null;
            IDDanhMucXe = null;
            BienSo = null;
            IDDanhMucTaiXe = null;
            TenDanhMucTaiXe = null;
            DienThoai = null;
            TrangThaiDonHang = null;
            SoDonHangKetHop = null;
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

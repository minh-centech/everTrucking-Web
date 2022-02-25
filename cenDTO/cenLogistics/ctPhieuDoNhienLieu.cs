namespace cenDTO.cenLogistics
{
    public class ctPhieuDoNhienLieu : ctDTO
    {
        public object IDChungTu { get; set; }
        public object NgayDoNhienLieu { get; set; }
        public object IDDanhMucDonViCungCapNhienLieu { get; set; }
        public object MaDanhMucDonViCungCapNhienLieu { get; set; }
        public object TenDanhMucDonViCungCapNhienLieu { get; set; }
        public object SoLuongNhienLieu { get; set; }
        public object DonGia { get; set; }

        public const string tableName = "ctPhieuDoNhienLieu";
        public const string listProcedureName = "List_" + tableName;
        public const string listDisplayProcedureName = "List_" + tableName + "_Display";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        //
        public ctPhieuDoNhienLieu()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            IDChungTu = null;
            NgayDoNhienLieu = null;
            IDDanhMucDonViCungCapNhienLieu = null;
            MaDanhMucDonViCungCapNhienLieu = null;
            TenDanhMucDonViCungCapNhienLieu = null;
            SoLuongNhienLieu = null;
            DonGia = null;
            GhiChu = null;
            //
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

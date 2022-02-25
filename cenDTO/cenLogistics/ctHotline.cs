namespace cenDTO.cenLogistics
{
    public class ctHotline : ctDTO
    {
        public object IDChungTu { get; set; }
        public object NgayGioThucHien { get; set; }
        public object NgayThucHien { get; set; }
        public object GioThucHien { get; set; }
        public object DienThoai { get; set; }
        public object ThongTinThuTuc { get; set; }
        public object GhiChuHotline { get; set; }
        public object TinhTrangHotline { get; set; }
        public object TrangThaiHotline { get; set; }

        public const string tableName = "ctHotline";
        public const string listProcedureName = "List_" + tableName;
        public const string listDisplayProcedureName = "List_" + tableName + "_Display";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        //
        public ctHotline()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            IDChungTu = null;
            NgayGioThucHien = null;
            NgayThucHien = null;
            GioThucHien = null;
            DienThoai = null;
            ThongTinThuTuc = null;
            GhiChuHotline = null;
            TinhTrangHotline = null;
            TrangThaiHotline = null;
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

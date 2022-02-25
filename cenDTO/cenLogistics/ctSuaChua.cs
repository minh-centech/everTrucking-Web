namespace cenDTO.cenLogistics
{
    public class ctSuaChua : ctDTO
    {
        public object IDDanhMucXe { get; set; }
        public object BienSo { get; set; }
        public object NgaySuaChua { get; set; }
        public object NoiDungSuaChua { get; set; }
        public object NoiSuaChua { get; set; }
        public object SoKmDongHo { get; set; }
        public object DonViTinh { get; set; }
        public object SoLuong { get; set; }
        public object DonGiaNhanCong { get; set; }
        public object SoTienNhanCong { get; set; }
        public object DonGiaVatTu { get; set; }
        public object SoTienVatTu { get; set; }
        public object SoTien { get; set; }
        public object ThoiGianBaoHanh { get; set; }
        public object NguoiSuaChua { get; set; }

        public const string tableName = "ctSuaChua";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        //
        public ctSuaChua()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            IDDanhMucXe = null;
            BienSo = null;
            NgaySuaChua = null;
            NoiDungSuaChua = null;
            NoiSuaChua = null;
            SoKmDongHo = null;
            DonViTinh = null;
            SoLuong = null;
            DonGiaNhanCong = null;
            SoTienNhanCong = null;
            DonGiaVatTu = null;
            SoTienVatTu = null;
            SoTien = null;
            ThoiGianBaoHanh = null;
            NguoiSuaChua = null;
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

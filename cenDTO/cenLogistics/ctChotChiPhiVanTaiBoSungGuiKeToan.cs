namespace cenDTO.cenLogistics
{
    public class ctChotChiPhiVanTaiBoSungGuiKeToan : ctDTO
    {
        public object IDChungTu { get; set; }

        public const string tableName = "ctChotChiPhiVanTaiBoSungGuiKeToan";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        //
        public ctChotChiPhiVanTaiBoSungGuiKeToan()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            IDChungTu = null;
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

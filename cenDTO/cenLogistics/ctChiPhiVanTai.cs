namespace cenDTO.cenLogistics
{
    public class ctChiPhiVanTai : ctDTO
    {
        public object IDChungTu { get; set; }
        public object SoLuongNhienLieu { get; set; }
        public object SoTienVeCauDuong { get; set; }
        public object SoTienLuatAnCa { get; set; }
        public object SoTienKetHopVeCauDuongLuatAnCa { get; set; }
        public object SoTienLuuCaKhac { get; set; }
        public object SoTienLuatDuongCam { get; set; }
        public object SoTienTongLuuCaKhacLuatDuongCam { get; set; }
        public object SoTienLuongChuyen { get; set; }
        public object SoTienLuongChuNhat { get; set; }
        public object SoTienCuocThueXeNgoai { get; set; }
        public object IDDanhMucCanBoTamUng { get; set; }
        public object ThoiHanThanhToan { get; set; }

        public const string tableName = "ctChiPhiVanTai";
        public const string listProcedureName = "List_" + tableName;
        public const string listDisplayProcedureName = "List_" + tableName + "_Display";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public const string getIDctChotChiPhiVanTaiGuiKeToanProcedureName = "Get_" + tableName + "_IDctChotChiPhiVanTaiGuiKeToan";
        public const string listSoDonHangProcedureName = "List_" + tableName + "_ValidSoDonHang";
        //
        public ctChiPhiVanTai()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucChungTu = null;
            IDDanhMucChungTuTrangThai = null;
            So = null;
            NgayLap = null;
            //
            IDChungTu = null;
            SoLuongNhienLieu = null;
            SoTienVeCauDuong = null;
            SoTienLuatAnCa = null;
            SoTienKetHopVeCauDuongLuatAnCa = null;
            SoTienLuuCaKhac = null;
            SoTienLuatDuongCam = null;
            SoTienTongLuuCaKhacLuatDuongCam = null;
            SoTienLuongChuyen = null;
            SoTienLuongChuNhat = null;
            SoTienCuocThueXeNgoai = null;
            IDDanhMucCanBoTamUng = null;
            ThoiHanThanhToan = null;
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

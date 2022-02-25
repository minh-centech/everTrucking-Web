using System.Data;
namespace cenDTO.cenLogistics
{
    public class ctThanhToanTamUng : ctDTO
    {
        public object IDChungTu { get; set; }
        public object IDChungTuChiTiet { get; set; }
        public object LoaiThanhToanTamUng { get; set; }
        public object IDDanhMucCanBoThanhToanTamUng { get; set; }
        public object MaDanhMucCanBoThanhToanTamUng { get; set; }
        public object TenDanhMucCanBoThanhToanTamUng { get; set; }
        public object NgayThanhToanTamUng { get; set; }
        public object SoTienHoanTamUng { get; set; }
        public object IDDanhMucChiPhiHaiQuanKinhDoanh { get; set; }
        public object MaDanhMucChiPhiHaiQuanKinhDoanh { get; set; }
        public object TenDanhMucChiPhiHaiQuanKinhDoanh { get; set; }
        public object SoTienChiThuTuc { get; set; }
        public object SoTienChiTraHoCoHoaDon { get; set; }
        public object SoTienChiCuocVo { get; set; }
        public object SoHoaDon { get; set; }
        public DataRowState DataRowState { get; set; }


        public const string tableName = "ctThanhToanTamUng";
        public const string listProcedureName = "List_" + tableName;
        public const string listDisplayProcedureName = "List_" + tableName + "_Display";
        public const string listDeNghiThanhToanHoanUngProcedureName = "List_" + tableName + "_DeNghiThanhToanHoanUng";
        public const string listDeNghiThanhToanProcedureName = "List_" + tableName + "_DeNghiThanhToan";
        public const string listDeNghiThanhToanGuiKhachHangProcedureName = "List_" + tableName + "_DeNghiThanhToanGuiKhachHang";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        //
        public ctThanhToanTamUng()
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
            LoaiThanhToanTamUng = null;
            IDDanhMucCanBoThanhToanTamUng = null;
            MaDanhMucCanBoThanhToanTamUng = null;
            TenDanhMucCanBoThanhToanTamUng = null;
            NgayThanhToanTamUng = null;
            SoTienHoanTamUng = null;
            IDDanhMucChiPhiHaiQuanKinhDoanh = null;
            MaDanhMucChiPhiHaiQuanKinhDoanh = null;
            TenDanhMucChiPhiHaiQuanKinhDoanh = null;
            SoTienChiThuTuc = null;
            SoTienChiTraHoCoHoaDon = null;
            SoTienChiCuocVo = null;
            SoHoaDon = null;
            DataRowState = DataRowState.Unchanged;
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

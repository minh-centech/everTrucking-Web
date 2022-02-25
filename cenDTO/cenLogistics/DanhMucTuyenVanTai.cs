namespace cenDTO.cenLogistics
{
    public class DanhMucTuyenVanTai : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object DiemDau { get; set; }
        public object IDDanhMucTinhThanhDau { get; set; }
        public object MaDanhMucTinhThanhDau { get; set; }
        public object TenDanhMucTinhThanhDau { get; set; }
        public object DiemCuoi { get; set; }
        public object IDDanhMucTinhThanhCuoi { get; set; }
        public object MaDanhMucTinhThanhCuoi { get; set; }
        public object TenDanhMucTinhThanhCuoi { get; set; }
        public object CuLy { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucTuyenVanTai";
        public const string listProcedureName = "List_" + tableName;
        public const string validProcedureName = "List_" + tableName + "_byID";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucTuyenVanTai()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            Ma = null;
            Ten = null;
            DiemDau = null;
            IDDanhMucTinhThanhDau = null;
            MaDanhMucTinhThanhDau = null;
            TenDanhMucTinhThanhDau = null;
            DiemCuoi = null;
            IDDanhMucTinhThanhCuoi = null;
            MaDanhMucTinhThanhCuoi = null;
            TenDanhMucTinhThanhCuoi = null;
            CuLy = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucTuyenVanTaiDinhMucNhienLieu : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object IDDanhMucTuyenVanTai { get; set; }
        public object MaDanhMucTuyenVanTai { get; set; }
        public object TenDanhMucTuyenVanTai { get; set; }
        public object NgayApDung { get; set; }
        public object IDDanhMucNhomXe { get; set; }
        public object MaDanhMucNhomXe { get; set; }
        public object TenDanhMucNhomXe { get; set; }
        public object IDDanhMucNhienLieu { get; set; }
        public object MaDanhMucNhienLieu { get; set; }
        public object TenDanhMucNhienLieu { get; set; }
        public object TaiTrongDau { get; set; }
        public object TaiTrongCuoi { get; set; }
        public object DinhMucNhienLieu1km { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucTuyenVanTaiDinhMucNhienLieu";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucTuyenVanTaiDinhMucNhienLieu()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            IDDanhMucTuyenVanTai = null;
            MaDanhMucTuyenVanTai = null;
            TenDanhMucTuyenVanTai = null;
            NgayApDung = null;
            IDDanhMucNhomXe = null;
            MaDanhMucNhomXe = null;
            TenDanhMucNhomXe = null;
            IDDanhMucNhienLieu = null;
            MaDanhMucNhienLieu = null;
            TenDanhMucNhienLieu = null;
            TaiTrongDau = null;
            TaiTrongCuoi = null;
            DinhMucNhienLieu1km = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
    public class DanhMucTuyenVanTaiDinhMucChiPhi : BaseDTO
    {
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object IDDanhMucTuyenVanTai { get; set; }
        public object MaDanhMucTuyenVanTai { get; set; }
        public object TenDanhMucTuyenVanTai { get; set; }
        public object ChieuVanTai { get; set; }
        public object NgayApDung { get; set; }
        public object IDDanhMucNhomXe { get; set; }
        public object MaDanhMucNhomXe { get; set; }
        public object TenDanhMucNhomXe { get; set; }
        public object IDDanhMucChiPhiDieuVanThuongXuyen { get; set; }
        public object MaDanhMucChiPhiDieuVanThuongXuyen { get; set; }
        public object TenDanhMucChiPhiDieuVanThuongXuyen { get; set; }
        public object SoLuong { get; set; }
        public object SoTien { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }

        public const string tableName = "DanhMucTuyenVanTaiDinhMucChiPhi";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;

        public DanhMucTuyenVanTaiDinhMucChiPhi()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            IDDanhMucTuyenVanTai = null;
            MaDanhMucTuyenVanTai = null;
            TenDanhMucTuyenVanTai = null;
            ChieuVanTai = null;
            NgayApDung = null;
            IDDanhMucNhomXe = null;
            MaDanhMucNhomXe = null;
            TenDanhMucNhomXe = null;
            IDDanhMucChiPhiDieuVanThuongXuyen = null;
            MaDanhMucChiPhiDieuVanThuongXuyen = null;
            TenDanhMucChiPhiDieuVanThuongXuyen = null;
            SoLuong = null;
            SoTien = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}

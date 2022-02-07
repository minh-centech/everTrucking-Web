using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code.DTO
{
    public class DanhMucKhachHang
    {
        public object ID { get; set; }
        public object IDDanhMucDonVi { get; set; }
        public object IDDanhMucLoaiDoiTuong { get; set; }
        public object Ma { get; set; }
        public object Ten { get; set; }
        public object TenEN { get; set; }
        public object MaCS { get; set; }
        public object DiaChi { get; set; }
        public object MaSoThue { get; set; }
        public object Nhom { get; set; }
        public object ViTri { get; set; }
        public object GhiChu { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }
        public object CreateDate { get; set; }
        public object EditDate { get; set; }

        public const string tableName = "DanhMucKhachHang";
        public const string listProcedureName = "List_" + tableName;
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string validProcedureName = "List_" + tableName + "_Valid";

        public DanhMucKhachHang()
        {
            ID = null;
            IDDanhMucDonVi = null;
            IDDanhMucLoaiDoiTuong = null;
            Ma = null;
            Ten = null;
            TenEN = null;
            MaCS = null;
            DiaChi = null;
            MaSoThue = null;
            Nhom = null;
            ViTri = null;
            GhiChu = null;
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
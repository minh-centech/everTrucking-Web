using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code.DTO
{
    public partial class DanhMucKhachHang
    {
        public string ID { get; set; }
        public string IDDanhMucDonVi { get; set; }
        public string IDDanhMucLoaiDoiTuong { get; set; }
        public string Ma { get; set; }
        public string Ten { get; set; }
        public string TenEN { get; set; }
        public string MaCS { get; set; }
        public string DiaChi { get; set; }
        public string MaSoThue { get; set; }
        public string Nhom { get; set; }
        public string ViTri { get; set; }
        public string GhiChu { get; set; }

       // public class ChiTiet
       // {
         //   public string DiaChi { get; set; }
           // public string TinhThanh { get; set; }
       // }

       // public List<ChiTiet> listChiTiet;
       // public string strChiTiet { get; set; }

        public string IDDanhMucNguoiSuDungCreate { get; set; }
        public string IDDanhMucNguoiSuDungEdit { get; set; }
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
            //strChiTiet = string.Empty;
            //listChiTiet = new List<ChiTiet>();
            IDDanhMucNguoiSuDungCreate = null;
            IDDanhMucNguoiSuDungEdit = null;
            CreateDate = null;
            EditDate = null;
        }
    }
}
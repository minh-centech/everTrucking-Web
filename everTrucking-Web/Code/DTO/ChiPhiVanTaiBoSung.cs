using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code.DTO
{
    public class ctChiPhiVanTaiBoSung
    {
        public object ID { set; get; }
        public object IDDanhMucDonVi { set; get; }
        public object IDDanhMucChungTu { set; get; }
        public object IDDanhMucChungTuTrangThai { get; set; }

        public object So { get; set; }
        public object NgayLap { get; set; }
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
        public object NgayBoSung { get; set; }
        public object IDDanhMucNguoiSuDungCreate { get; set; }
        public object MaDanhMucNguoiSuDungCreate { get; set; }
        public object TenDanhMucNguoiSuDungCreate { get; set; }
        public object CreateDate { get; set; }
        public object IDDanhMucNguoiSuDungEdit { get; set; }
        public object MaDanhMucNguoiSuDungEdit { get; set; }

        public object TenDanhMucNguoiSuDungEdit { get; set; }

        public object EditDate { get; set; }

        public DataRowState DataRowState { get; set; }

        public const string tableName = "ctChiPhiVanTaiBoSung";
        public const string listProcedureName = "List_" + tableName;
        public const string listDisplayProcedureName = "List_" + tableName + "_Display";
        public const string insertProcedureName = "Insert_" + tableName;
        public const string updateProcedureName = "Update_" + tableName;
        public const string deleteProcedureName = "Delete_" + tableName;
        public const string getIDctChotChiPhiVanTaiBoSungGuiKeToanProcedureName = "Get_" + tableName + "_IDctChotChiPhiVanTaiBoSungGuiKeToan";
        //
        public ctChiPhiVanTaiBoSung()
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
            NgayBoSung = null;
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
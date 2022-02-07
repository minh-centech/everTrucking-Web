using everTrucking_Web.Code.DAO;
using everTrucking_Web.Code.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code.BUS
{
    public class DanhMucDiaDiemGiaoNhanBUS
    {
        public static DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DataTable Valid(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                return dao.Valid(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(ref DanhMucDiaDiemGiaoNhan obj)
        {
            try
            {
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucDiaDiemGiaoNhan obj)
        {
            try
            {
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucDiaDiemGiaoNhan obj)
        {
            try
            {
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
using everTrucking_Web.Code.DAO;
using everTrucking_Web.Code.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code.BUS
{
    public class DanhMucDoiTuongBUS
    {
        public static DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
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
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.Valid(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool Insert(ref DanhMucDoiTuong obj)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Update(ref DanhMucDoiTuong obj)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool Delete(DanhMucDoiTuong obj)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
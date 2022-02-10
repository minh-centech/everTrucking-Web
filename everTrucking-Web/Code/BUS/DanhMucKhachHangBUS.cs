using everTrucking_Web.Code.DAO;
using everTrucking_Web.Code.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code.BUS
{
    public class DanhMucKhachHangBUS
    {
        public static DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
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
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.Valid(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public  bool Insert(ref DanhMucKhachHang obj)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public  bool Update(ref DanhMucKhachHang obj)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucKhachHang obj)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
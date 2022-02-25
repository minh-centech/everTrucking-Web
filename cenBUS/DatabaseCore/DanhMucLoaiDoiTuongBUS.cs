using cenDAO.DatabaseCore;
using cenDTO.DatabaseCore;
using System;
using System.Data;
namespace cenBUS.DatabaseCore
{
    public class DanhMucLoaiDoiTuongBUS
    {
        public DanhMucLoaiDoiTuongBUS()
        {
        }

        public DataTable List(object ID)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucLoaiDoiTuong obj)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucLoaiDoiTuong obj)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucLoaiDoiTuong obj)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string GetTenBangDuLieu(object ID)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.GetTenBangDuLieu(ID);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public static object GetID(object Ma)
        {
            try
            {
                DanhMucLoaiDoiTuongDAO dao = new DanhMucLoaiDoiTuongDAO();
                return dao.GetID(Ma);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

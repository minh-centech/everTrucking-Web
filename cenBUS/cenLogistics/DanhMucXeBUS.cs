using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucXeBUS
    {
        public DanhMucXeBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucThauPhu, object IDDanhMucNhomHangVanChuyen, object SearchStr)
        {
            try
            {
                DanhMucXeDAO dao = new DanhMucXeDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, IDDanhMucThauPhu, IDDanhMucNhomHangVanChuyen, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListHinhAnh(object ID)
        {
            try
            {
                DanhMucXeDAO dao = new DanhMucXeDAO();
                return dao.ListHinhAnh(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucXe obj)
        {
            try
            {
                DanhMucXeDAO dao = new DanhMucXeDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucXe obj)
        {
            try
            {
                DanhMucXeDAO dao = new DanhMucXeDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucXe obj)
        {
            try
            {
                DanhMucXeDAO dao = new DanhMucXeDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

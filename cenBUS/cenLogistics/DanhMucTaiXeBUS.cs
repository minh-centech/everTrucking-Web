using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucTaiXeBUS
    {
        public DanhMucTaiXeBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucThauPhu, object SearchStr)
        {
            try
            {
                DanhMucTaiXeDAO dao = new DanhMucTaiXeDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, IDDanhMucThauPhu, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucTaiXe obj)
        {
            try
            {
                DanhMucTaiXeDAO dao = new DanhMucTaiXeDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucTaiXe obj)
        {
            try
            {
                DanhMucTaiXeDAO dao = new DanhMucTaiXeDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucTaiXe obj)
        {
            try
            {
                DanhMucTaiXeDAO dao = new DanhMucTaiXeDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

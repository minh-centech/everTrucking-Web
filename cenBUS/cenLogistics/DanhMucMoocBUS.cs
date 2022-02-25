using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucMoocBUS
    {
        public DanhMucMoocBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucMoocDAO dao = new DanhMucMoocDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
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
                DanhMucMoocDAO dao = new DanhMucMoocDAO();
                return dao.ListHinhAnh(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucMooc obj)
        {
            try
            {
                DanhMucMoocDAO dao = new DanhMucMoocDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucMooc obj)
        {
            try
            {
                DanhMucMoocDAO dao = new DanhMucMoocDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucMooc obj)
        {
            try
            {
                DanhMucMoocDAO dao = new DanhMucMoocDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucGiaNhienLieuBUS
    {
        public DanhMucGiaNhienLieuBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucGiaNhienLieuDAO dao = new DanhMucGiaNhienLieuDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucGiaNhienLieu obj)
        {
            try
            {
                DanhMucGiaNhienLieuDAO dao = new DanhMucGiaNhienLieuDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucGiaNhienLieu obj)
        {
            try
            {
                DanhMucGiaNhienLieuDAO dao = new DanhMucGiaNhienLieuDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucGiaNhienLieu obj)
        {
            try
            {
                DanhMucGiaNhienLieuDAO dao = new DanhMucGiaNhienLieuDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

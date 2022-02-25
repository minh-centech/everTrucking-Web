using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucXeDinhMucNhienLieuBUS
    {
        public DanhMucXeDinhMucNhienLieuBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucXeDinhMucNhienLieuDAO dao = new DanhMucXeDinhMucNhienLieuDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucXeDinhMucNhienLieu obj)
        {
            try
            {
                DanhMucXeDinhMucNhienLieuDAO dao = new DanhMucXeDinhMucNhienLieuDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucXeDinhMucNhienLieu obj)
        {
            try
            {
                DanhMucXeDinhMucNhienLieuDAO dao = new DanhMucXeDinhMucNhienLieuDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucXeDinhMucNhienLieu obj)
        {
            try
            {
                DanhMucXeDinhMucNhienLieuDAO dao = new DanhMucXeDinhMucNhienLieuDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

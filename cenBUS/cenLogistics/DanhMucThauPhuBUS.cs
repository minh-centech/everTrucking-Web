using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucThauPhuBUS
    {
        public DanhMucThauPhuBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucNhomHangVanChuyen, object SearchStr)
        {
            try
            {
                DanhMucThauPhuDAO dao = new DanhMucThauPhuDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, IDDanhMucNhomHangVanChuyen, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Insert(ref DanhMucThauPhu obj)
        {
            try
            {
                DanhMucThauPhuDAO dao = new DanhMucThauPhuDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucThauPhu obj)
        {
            try
            {
                DanhMucThauPhuDAO dao = new DanhMucThauPhuDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucThauPhu obj)
        {
            try
            {
                DanhMucThauPhuDAO dao = new DanhMucThauPhuDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

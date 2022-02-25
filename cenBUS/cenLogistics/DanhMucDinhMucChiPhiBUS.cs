using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucDinhMucChiPhiBUS
    {
        public DanhMucDinhMucChiPhiBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucDinhMucChiPhiDAO dao = new DanhMucDinhMucChiPhiDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucDinhMucChiPhi obj)
        {
            try
            {
                DanhMucDinhMucChiPhiDAO dao = new DanhMucDinhMucChiPhiDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucDinhMucChiPhi obj)
        {
            try
            {
                DanhMucDinhMucChiPhiDAO dao = new DanhMucDinhMucChiPhiDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucDinhMucChiPhi obj)
        {
            try
            {
                DanhMucDinhMucChiPhiDAO dao = new DanhMucDinhMucChiPhiDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

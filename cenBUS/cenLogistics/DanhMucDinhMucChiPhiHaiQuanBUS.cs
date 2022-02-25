using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucDinhMucChiPhiHaiQuanBUS
    {
        public DanhMucDinhMucChiPhiHaiQuanBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucDinhMucChiPhiHaiQuanDAO dao = new DanhMucDinhMucChiPhiHaiQuanDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucDinhMucChiPhiHaiQuan obj)
        {
            try
            {
                DanhMucDinhMucChiPhiHaiQuanDAO dao = new DanhMucDinhMucChiPhiHaiQuanDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucDinhMucChiPhiHaiQuan obj)
        {
            try
            {
                DanhMucDinhMucChiPhiHaiQuanDAO dao = new DanhMucDinhMucChiPhiHaiQuanDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucDinhMucChiPhiHaiQuan obj)
        {
            try
            {
                DanhMucDinhMucChiPhiHaiQuanDAO dao = new DanhMucDinhMucChiPhiHaiQuanDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

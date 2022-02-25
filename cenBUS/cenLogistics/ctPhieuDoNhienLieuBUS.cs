using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctPhieuDoNhienLieuBUS
    {
        public ctPhieuDoNhienLieuBUS()
        {
        }

        public DataTable List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ctPhieuDoNhienLieuDAO dao = new ctPhieuDoNhienLieuDAO();
                return dao.List(IDDanhMucChungTu, ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListDisplay(object IDDanhMucChungTu, object ID, object TuNgay, object DenNgay)
        {
            try
            {
                ctPhieuDoNhienLieuDAO dao = new ctPhieuDoNhienLieuDAO();
                return dao.ListDisplay(IDDanhMucChungTu, ID, TuNgay, DenNgay);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref ctPhieuDoNhienLieu obj)
        {
            try
            {
                ctPhieuDoNhienLieuDAO dao = new ctPhieuDoNhienLieuDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref ctPhieuDoNhienLieu obj)
        {
            try
            {
                ctPhieuDoNhienLieuDAO dao = new ctPhieuDoNhienLieuDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctPhieuDoNhienLieu obj)
        {
            try
            {
                ctPhieuDoNhienLieuDAO dao = new ctPhieuDoNhienLieuDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

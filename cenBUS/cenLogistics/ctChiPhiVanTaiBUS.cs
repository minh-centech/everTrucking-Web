using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctChiPhiVanTaiBUS
    {
        public ctChiPhiVanTaiBUS()
        {
        }

        public DataTable List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ctChiPhiVanTaiDAO dao = new ctChiPhiVanTaiDAO();
                DataTable dt = dao.List(IDDanhMucChungTu, ID);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucNhomHangVanChuyen)
        {
            try
            {
                ctChiPhiVanTaiDAO dao = new ctChiPhiVanTaiDAO();
                DataTable dt = dao.ListDisplay(IDDanhMucChungTu, TuNgay, DenNgay, IDDanhMucNhomHangVanChuyen);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListValidSoDonHang(object SoDonHang)
        {
            try
            {
                ctChiPhiVanTaiDAO dao = new ctChiPhiVanTaiDAO();
                DataTable dt = dao.ListValidSoDonHang(SoDonHang);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref ctChiPhiVanTai obj)
        {
            try
            {
                ctChiPhiVanTaiDAO dao = new ctChiPhiVanTaiDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref ctChiPhiVanTai obj)
        {
            try
            {
                ctChiPhiVanTaiDAO dao = new ctChiPhiVanTaiDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctChiPhiVanTai obj)
        {
            try
            {
                ctChiPhiVanTaiDAO dao = new ctChiPhiVanTaiDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

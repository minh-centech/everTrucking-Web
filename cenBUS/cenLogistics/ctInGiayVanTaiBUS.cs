using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctInGiayVanTaiBUS
    {
        public ctInGiayVanTaiBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucChuXe)
        {
            try
            {
                ctInGiayVanTaiDAO dao = new ctInGiayVanTaiDAO();
                return dao.List(ID, IDDanhMucChungTu, TuNgay, DenNgay, IDDanhMucChuXe);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref ctInGiayVanTai obj)
        {
            try
            {
                ctInGiayVanTaiDAO dao = new ctInGiayVanTaiDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref ctInGiayVanTai obj)
        {
            try
            {
                ctInGiayVanTaiDAO dao = new ctInGiayVanTaiDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctInGiayVanTai obj)
        {
            try
            {
                ctInGiayVanTaiDAO dao = new ctInGiayVanTaiDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

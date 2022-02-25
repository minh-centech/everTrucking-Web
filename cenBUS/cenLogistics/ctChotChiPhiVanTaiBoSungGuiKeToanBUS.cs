using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Collections.Generic;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctChotChiPhiVanTaiBoSungGuiKeToanBUS
    {
        public ctChotChiPhiVanTaiBoSungGuiKeToanBUS()
        {
        }

        public DataSet List(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucNhomHangVanChuyen, object IDDanhMucSale)
        {
            try
            {
                ctChotChiPhiVanTaiBoSungGuiKeToanDAO dao = new ctChotChiPhiVanTaiBoSungGuiKeToanDAO();
                DataSet ds = dao.List(IDDanhMucChungTu, TuNgay, DenNgay, IDDanhMucNhomHangVanChuyen, IDDanhMucSale);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(List<ctChotChiPhiVanTaiBoSungGuiKeToan> objList)
        {
            try
            {
                ctChotChiPhiVanTaiBoSungGuiKeToanDAO dao = new ctChotChiPhiVanTaiBoSungGuiKeToanDAO();
                return dao.Insert(objList);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(List<ctChotChiPhiVanTaiBoSungGuiKeToan> objList)
        {
            try
            {
                ctChotChiPhiVanTaiBoSungGuiKeToanDAO dao = new ctChotChiPhiVanTaiBoSungGuiKeToanDAO();
                return dao.Delete(objList);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

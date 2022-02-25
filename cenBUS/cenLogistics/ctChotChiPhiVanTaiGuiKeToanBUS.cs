using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Collections.Generic;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctChotChiPhiVanTaiGuiKeToanBUS
    {
        public ctChotChiPhiVanTaiGuiKeToanBUS()
        {
        }

        public DataSet List(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucNhomHangVanChuyen, object IDDanhMucSale)
        {
            try
            {
                ctChotChiPhiVanTaiGuiKeToanDAO dao = new ctChotChiPhiVanTaiGuiKeToanDAO();
                DataSet ds = dao.List(IDDanhMucChungTu, TuNgay, DenNgay, IDDanhMucNhomHangVanChuyen, IDDanhMucSale);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(List<ctChotChiPhiVanTaiGuiKeToan> objList)
        {
            try
            {
                ctChotChiPhiVanTaiGuiKeToanDAO dao = new ctChotChiPhiVanTaiGuiKeToanDAO();
                return dao.Insert(objList);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(List<ctChotChiPhiVanTaiGuiKeToan> objList)
        {
            try
            {
                ctChotChiPhiVanTaiGuiKeToanDAO dao = new ctChotChiPhiVanTaiGuiKeToanDAO();
                return dao.Delete(objList);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

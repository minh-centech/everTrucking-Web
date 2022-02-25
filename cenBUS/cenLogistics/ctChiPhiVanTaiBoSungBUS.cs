using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Collections.Generic;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctChiPhiVanTaiBoSungBUS
    {
        public ctChiPhiVanTaiBoSungBUS()
        {
        }

        public DataSet List(object IDDanhMucChungTu, object IDctDonHang)
        {
            try
            {
                ctChiPhiVanTaiBoSungDAO dao = new ctChiPhiVanTaiBoSungDAO();
                DataSet ds = dao.List(IDDanhMucChungTu, IDctDonHang);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object ID, object IDDanhMucNhomHangVanChuyen)
        {
            try
            {
                ctChiPhiVanTaiBoSungDAO dao = new ctChiPhiVanTaiBoSungDAO();
                DataTable dt = dao.ListDisplay(IDDanhMucChungTu, TuNgay, DenNgay, ID, IDDanhMucNhomHangVanChuyen);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(List<ctChiPhiVanTaiBoSung> obj)
        {
            try
            {
                ctChiPhiVanTaiBoSungDAO dao = new ctChiPhiVanTaiBoSungDAO();
                return dao.Insert(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(List<ctChiPhiVanTaiBoSung> obj)
        {
            try
            {
                ctChiPhiVanTaiBoSungDAO dao = new ctChiPhiVanTaiBoSungDAO();
                return dao.Update(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctChiPhiVanTaiBoSung obj)
        {
            try
            {
                ctChiPhiVanTaiBoSungDAO dao = new ctChiPhiVanTaiBoSungDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

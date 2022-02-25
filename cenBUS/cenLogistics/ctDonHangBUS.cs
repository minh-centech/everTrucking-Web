using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctDonHangBUS
    {
        public ctDonHangBUS()
        {
        }
        public DataSet List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ctDonHangDAO dao = new ctDonHangDAO();
                DataSet ds = dao.List(IDDanhMucChungTu, ID);
                return ds;
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
                ctDonHangDAO dao = new ctDonHangDAO();
                DataTable dt = dao.ListDisplay(IDDanhMucChungTu, ID, TuNgay, DenNgay);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListNhomHangVanChuyen(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucNhomHangVanChuyen)
        {
            try
            {
                ctDonHangDAO dao = new ctDonHangDAO();
                DataTable dt = dao.ListNhomHangVanChuyen(IDDanhMucChungTu, TuNgay, DenNgay, IDDanhMucNhomHangVanChuyen);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ValidDebitNote(object IDDanhMucChungTu, object DebitNote)
        {
            try
            {
                ctDonHangDAO dao = new ctDonHangDAO();
                DataTable dt = dao.ValidDebitNote(IDDanhMucChungTu, DebitNote);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref ctDonHang obj)
        {
            try
            {
                ctDonHangDAO dao = new ctDonHangDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref ctDonHang obj)
        {
            try
            {
                ctDonHangDAO dao = new ctDonHangDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctDonHang obj)
        {
            try
            {
                ctDonHangDAO dao = new ctDonHangDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static object GetIDctChotDoanhThuGuiKeToan(object IDctDonHang)
        {
            ctDonHangDAO dao = new ctDonHangDAO();
            return dao.GetIDctChotDoanhThuGuiKeToan(IDctDonHang);
        }
        public static object GetIDctChotChiPhiVanTaiBoSungGuiKeToan(object IDctDonHang)
        {
            ctDonHangDAO dao = new ctDonHangDAO();
            return dao.GetIDctChotChiPhiVanTaiBoSungGuiKeToan(IDctDonHang);
        }
        public static object GetIDctChotChiPhiVanTaiGuiKeToan(object IDctDonHang)
        {
            ctDonHangDAO dao = new ctDonHangDAO();
            return dao.GetIDctChotChiPhiVanTaiGuiKeToan(IDctDonHang);
        }
    }
}

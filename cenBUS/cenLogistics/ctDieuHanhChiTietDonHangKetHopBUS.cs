using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctDieuHanhChiTietDonHangKetHopBUS
    {
        public ctDieuHanhChiTietDonHangKetHopBUS()
        {
        }

        public DataTable List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ctDieuHanhChiTietDonHangKetHopDAO dao = new ctDieuHanhChiTietDonHangKetHopDAO();
                return dao.List(IDDanhMucChungTu, ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref ctDieuHanhChiTietDonHangKetHop obj)
        {
            try
            {
                ctDieuHanhChiTietDonHangKetHopDAO dao = new ctDieuHanhChiTietDonHangKetHopDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref ctDieuHanhChiTietDonHangKetHop obj)
        {
            try
            {
                ctDieuHanhChiTietDonHangKetHopDAO dao = new ctDieuHanhChiTietDonHangKetHopDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctDieuHanhChiTietDonHangKetHop obj)
        {
            try
            {
                ctDieuHanhChiTietDonHangKetHopDAO dao = new ctDieuHanhChiTietDonHangKetHopDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctHopDongVanChuyenBUS
    {
        public ctHopDongVanChuyenBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucChungTu, object TuNgay, object DenNgay)
        {
            try
            {
                ctHopDongVanChuyenDAO dao = new ctHopDongVanChuyenDAO();
                return dao.List(ID, IDDanhMucChungTu, TuNgay, DenNgay);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListFileContent(object ID)
        {
            try
            {
                ctHopDongVanChuyenDAO dao = new ctHopDongVanChuyenDAO();
                return dao.ListFileContent(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref ctHopDongVanChuyen obj)
        {
            try
            {
                ctHopDongVanChuyenDAO dao = new ctHopDongVanChuyenDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref ctHopDongVanChuyen obj)
        {
            try
            {
                ctHopDongVanChuyenDAO dao = new ctHopDongVanChuyenDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctHopDongVanChuyen obj)
        {
            try
            {
                ctHopDongVanChuyenDAO dao = new ctHopDongVanChuyenDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DataTable ValidSoHopDong(object SoHopDong)
        {
            try
            {
                ctHopDongVanChuyenDAO dao = new ctHopDongVanChuyenDAO();
                return dao.ValidSoHopDong(SoHopDong);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

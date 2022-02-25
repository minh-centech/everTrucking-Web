using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctDieuHanhBUS
    {
        public ctDieuHanhBUS()
        {
        }

        public DataTable List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ctDieuHanhDAO dao = new ctDieuHanhDAO();
                return dao.List(IDDanhMucChungTu, ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable List2(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ctDieuHanhDAO dao = new ctDieuHanhDAO();
                return dao.List2(IDDanhMucChungTu, ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListDisplay(object IDDanhMucChungTu, object ID, object TuNgay, object DenNgay, object IDDanhMucNhomHangVanChuyen)
        {
            try
            {
                ctDieuHanhDAO dao = new ctDieuHanhDAO();
                return dao.ListDisplay(IDDanhMucChungTu, ID, TuNgay, DenNgay, IDDanhMucNhomHangVanChuyen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref ctDieuHanh obj)
        {
            try
            {
                ctDieuHanhDAO dao = new ctDieuHanhDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref ctDieuHanh obj)
        {
            try
            {
                ctDieuHanhDAO dao = new ctDieuHanhDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctDieuHanh obj)
        {
            try
            {
                ctDieuHanhDAO dao = new ctDieuHanhDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctHotlineBUS
    {
        public ctHotlineBUS()
        {
        }

        public DataTable List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ctHotlineDAO dao = new ctHotlineDAO();
                return dao.List(IDDanhMucChungTu, ID);
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
                ctHotlineDAO dao = new ctHotlineDAO();
                return dao.ListDisplay(IDDanhMucChungTu, ID, TuNgay, DenNgay, IDDanhMucNhomHangVanChuyen);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref ctHotline obj)
        {
            try
            {
                ctHotlineDAO dao = new ctHotlineDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref ctHotline obj)
        {
            try
            {
                ctHotlineDAO dao = new ctHotlineDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctHotline obj)
        {
            try
            {
                ctHotlineDAO dao = new ctHotlineDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

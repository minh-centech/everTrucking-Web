using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctSuaChuaBUS
    {
        public ctSuaChuaBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucXe)
        {
            try
            {
                ctSuaChuaDAO dao = new ctSuaChuaDAO();
                return dao.List(ID, IDDanhMucChungTu, TuNgay, DenNgay, IDDanhMucXe);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref ctSuaChua obj)
        {
            try
            {
                ctSuaChuaDAO dao = new ctSuaChuaDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref ctSuaChua obj)
        {
            try
            {
                ctSuaChuaDAO dao = new ctSuaChuaDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctSuaChua obj)
        {
            try
            {
                ctSuaChuaDAO dao = new ctSuaChuaDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

using cenDAO.DatabaseCore;
using cenDTO.DatabaseCore;
using System;
using System.Data;
namespace cenBUS.DatabaseCore
{
    public class DanhMucTuDienBUS
    {
        public DanhMucTuDienBUS()
        {
        }

        public DataTable List(object ID)
        {
            try
            {
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucTuDien obj)
        {
            try
            {
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucTuDien obj)
        {
            try
            {
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucTuDien obj)
        {
            try
            {
                DanhMucTuDienDAO dao = new DanhMucTuDienDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

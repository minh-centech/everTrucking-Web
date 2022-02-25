using cenDAO.DatabaseCore;
using cenDTO.DatabaseCore;
using System;
using System.Data;
namespace cenBUS.DatabaseCore
{
    public class DanhMucDonViBUS
    {
        public DanhMucDonViBUS()
        {
        }

        public DataTable List(object ID)
        {
            try
            {
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucDonVi obj)
        {
            try
            {
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucDonVi obj)
        {
            try
            {
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucDonVi obj)
        {
            try
            {
                DanhMucDonViDAO dao = new DanhMucDonViDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

using cenDAO.DatabaseCore;
using System;
using System.Data;
namespace cenBUS.DatabaseCore
{
    public class NhatKyDuLieuBUS
    {
        public NhatKyDuLieuBUS()
        {
        }
        public DataTable List()
        {
            try
            {
                NhatKyDuLieuDAO dao = new NhatKyDuLieuDAO();
                return dao.List();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

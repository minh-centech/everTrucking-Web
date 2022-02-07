using everTrucking_Web.Code.DAO;
using everTrucking_Web.Code.DTO;
using System;
using System.Data;
namespace everTrucking_Web.Code.BUS
{
    public class ctDonHangBUS
    {
        public static DataTable ListDisplay()
        {
            try
            {
                ctDonHangDAO dao = new ctDonHangDAO();
                DataTable dt = dao.ListDisplay();
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ctDonHang obj)
        {
                ctDonHangDAO dao = new ctDonHangDAO();
                return dao.Insert(obj);
            
          
        }
    }
}

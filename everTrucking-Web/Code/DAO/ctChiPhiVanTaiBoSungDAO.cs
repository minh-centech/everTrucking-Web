using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code.DAO
{
    public class ctChiPhiVanTaiBoSungDAO
    {
        public DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object ID, object IDDanhMucNhomHangVanChuyen)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", Code.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", Code.GlobalVariables.IDDanhMucChungTuDonHang);
            sqlParameters[2] = new SqlParameter("@TuNgay", "10/1/2021");
            sqlParameters[3] = new SqlParameter("@DenNgay", "10/14/2021");
            sqlParameters[4] = new SqlParameter("@ID", ID);
            sqlParameters[5] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", DBNull.Value);
            DataTable dt = dao.tableList(sqlParameters, "List_ctChiPhiVanTaiBoSung_Display", "List_ctChiPhiVanTaiBoSung_Display");
            return dt;
        }
    }
}
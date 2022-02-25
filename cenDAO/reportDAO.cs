using System.Data.SqlClient;

namespace cenDAO
{
    public static class reportDAO
    {
        public static void repChiTietBaoGiaMSCDetail(object TuNgay, object DenNgay, object IDDanhMucHangTau)
        {
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@TuNgay", TuNgay);
            sqlParameters[1] = new SqlParameter("@DenNgay", DenNgay);
            sqlParameters[2] = new SqlParameter("@IDDanhMucHangTau", IDDanhMucHangTau);
            ConnectionDAO connectionDAO = new ConnectionDAO();
            connectionDAO.tableList(sqlParameters, "", "");
        }
    }
}

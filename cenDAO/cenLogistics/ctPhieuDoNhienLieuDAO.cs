using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class ctPhieuDoNhienLieuDAO
    {
        public DataTable List(object IDDanhMucChungTu, object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@ID", ID);
            DataTable dt = dao.tableList(sqlParameters, ctPhieuDoNhienLieu.listProcedureName, ctPhieuDoNhienLieu.listProcedureName);
            return dt;
        }
        public DataTable ListDisplay(object IDDanhMucChungTu, object ID, object TuNgay, object DenNgay)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@TuNgay", TuNgay);
            sqlParameters[3] = new SqlParameter("@DenNgay", DenNgay);
            sqlParameters[4] = new SqlParameter("@ID", ID);
            DataTable dt = dao.tableList(sqlParameters, ctPhieuDoNhienLieu.listDisplayProcedureName, ctPhieuDoNhienLieu.tableName);
            return dt;
        }
        public bool Insert(ref ctPhieuDoNhienLieu obj)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString);
                connection.Open();
                command = new SqlCommand(ctPhieuDoNhienLieu.insertProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[13];
                sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                {
                    Direction = ParameterDirection.Output,
                    Size = sizeof(Int64)
                };
                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                sqlParameters[3] = new SqlParameter("@IDDanhMucChungTuTrangThai", obj.IDDanhMucChungTuTrangThai);
                sqlParameters[4] = new SqlParameter("@So", obj.So)
                {
                    Direction = ParameterDirection.Output,
                    Size = 35
                };
                sqlParameters[5] = new SqlParameter("@NgayLap", obj.NgayLap);
                //
                sqlParameters[6] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                sqlParameters[7] = new SqlParameter("@NgayDoNhienLieu", obj.NgayDoNhienLieu);
                sqlParameters[8] = new SqlParameter("@IDDanhMucDonViCungCapNhienLieu", obj.IDDanhMucDonViCungCapNhienLieu);
                sqlParameters[9] = new SqlParameter("@SoLuongNhienLieu", obj.SoLuongNhienLieu);
                sqlParameters[10] = new SqlParameter("@DonGia", obj.DonGia);
                //
                sqlParameters[11] = new SqlParameter("@GhiChu", obj.GhiChu);
                sqlParameters[12] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParameters);
                int rowAffected = command.ExecuteNonQuery();
                obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                obj.So = sqlParameters[4].Value.ToString();
                return true;
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        public bool Update(ref ctPhieuDoNhienLieu obj)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString);
                connection.Open();
                command = new SqlCommand(ctPhieuDoNhienLieu.updateProcedureName, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[13];
                sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                sqlParameters[3] = new SqlParameter("@IDDanhMucChungTuTrangThai", obj.IDDanhMucChungTuTrangThai);
                sqlParameters[4] = new SqlParameter("@So", obj.So);
                sqlParameters[5] = new SqlParameter("@NgayLap", obj.NgayLap);
                //
                sqlParameters[6] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                sqlParameters[7] = new SqlParameter("@NgayDoNhienLieu", obj.NgayDoNhienLieu);
                sqlParameters[8] = new SqlParameter("@IDDanhMucDonViCungCapNhienLieu", obj.IDDanhMucDonViCungCapNhienLieu);
                sqlParameters[9] = new SqlParameter("@SoLuongNhienLieu", obj.SoLuongNhienLieu);
                sqlParameters[10] = new SqlParameter("@DonGia", obj.DonGia);
                //
                sqlParameters[11] = new SqlParameter("@GhiChu", obj.GhiChu);
                sqlParameters[12] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParameters);
                int rowAffected = command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
            finally
            {
                command.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        public bool Delete(ctPhieuDoNhienLieu obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand(ctPhieuDoNhienLieu.deleteProcedureName, sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] sqlParameters = new SqlParameter[1];
                        sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                        sqlCommand.Parameters.AddRange(sqlParameters);
                        int rowAffected = sqlCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
    }
}

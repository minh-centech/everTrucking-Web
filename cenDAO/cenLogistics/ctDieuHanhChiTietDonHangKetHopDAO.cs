using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class ctDieuHanhChiTietDonHangKetHopDAO
    {
        public DataTable List(object IDDanhMucChungTu, object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@ID", ID);
            DataTable dt = dao.tableList(sqlParameters, ctDieuHanhChiTietDonHangKetHop.listProcedureName, ctDieuHanhChiTietDonHangKetHop.tableName);
            return dt;
        }
        public bool Insert(ref ctDieuHanhChiTietDonHangKetHop obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctDieuHanhChiTietDonHangKetHop.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[7];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                            sqlParameters[3] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                            sqlParameters[4] = new SqlParameter("@IDChungTuChiTiet", obj.IDChungTuChiTiet);
                            sqlParameters[5] = new SqlParameter("@IDctDonHang", obj.IDctDonHang);
                            sqlParameters[6] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(ctDieuHanhChiTietDonHangKetHop.tableName), sqlConnection, sqlTransaction))
                            {
                                sqlTransaction.Commit();
                                return true;
                            }
                            else
                            {
                                sqlTransaction.Rollback();
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public bool Update(ref ctDieuHanhChiTietDonHangKetHop obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctDieuHanhChiTietDonHangKetHop.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[7];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                            sqlParameters[3] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                            sqlParameters[4] = new SqlParameter("@IDChungTuChiTiet", obj.IDChungTuChiTiet);
                            sqlParameters[5] = new SqlParameter("@IDctDonHang", obj.IDctDonHang);
                            sqlParameters[6] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(ctDieuHanhChiTietDonHangKetHop.tableName), sqlConnection, sqlTransaction))
                            {
                                sqlTransaction.Commit();
                                return true;
                            }
                            else
                            {
                                sqlTransaction.Rollback();
                                return false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public bool Delete(ctDieuHanhChiTietDonHangKetHop obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctDieuHanhChiTietDonHangKetHop.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(ctDieuHanhChiTietDonHangKetHop.tableName), sqlConnection, sqlTransaction))
                            {
                                sqlTransaction.Commit();
                                return true;
                            }
                            else
                            {
                                sqlTransaction.Rollback();
                                return false;
                            }
                        }
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

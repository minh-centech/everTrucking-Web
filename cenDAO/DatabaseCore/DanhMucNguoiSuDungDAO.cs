using cenDTO.DatabaseCore;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.DatabaseCore
{
    public class DanhMucNguoiSuDungDAO
    {
        public DataTable List(object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = dao.tableList(sqlParameters, DanhMucNguoiSuDung.listProcedureName, DanhMucNguoiSuDung.tableName);
            return dt;
        }
        public bool Insert(ref DanhMucNguoiSuDung obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucNguoiSuDung.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[7];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucPhanQuyen", obj.IDDanhMucPhanQuyen);
                            sqlParameters[2] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[3] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[4] = new SqlParameter("@Password", obj.Password);
                            sqlParameters[5] = new SqlParameter("@isAdmin", obj.isAdmin);
                            sqlParameters[6] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(DanhMucNguoiSuDung.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref DanhMucNguoiSuDung obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucNguoiSuDung.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[6];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucPhanQuyen", obj.IDDanhMucPhanQuyen);
                            sqlParameters[2] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[3] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[4] = new SqlParameter("@isAdmin", obj.isAdmin);
                            sqlParameters[5] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(DanhMucNguoiSuDung.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(DanhMucNguoiSuDung obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucNguoiSuDung.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(DanhMucNguoiSuDung.tableName), sqlConnection, sqlTransaction))
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
        public string GetID(string Ma, string Password, out string IDDanhMucPhanQuyen, out string isAdmin)
        {
            IDDanhMucPhanQuyen = "";
            isAdmin = "0";
            try
            {

                SqlParameter[] sqlParameters = new SqlParameter[5];
                sqlParameters[0] = new SqlParameter("@Ma", Ma);
                sqlParameters[1] = new SqlParameter("@Password", Password);
                sqlParameters[2] = new SqlParameter("@ID", DBNull.Value)
                {
                    Direction = ParameterDirection.Output,
                    Size = sizeof(Int64)
                };
                sqlParameters[3] = new SqlParameter("@IDDanhMucPhanQuyen", DBNull.Value)
                {
                    Direction = ParameterDirection.Output,
                    Size = sizeof(Int64)
                };
                sqlParameters[4] = new SqlParameter("@isAdmin", DBNull.Value)
                {
                    Direction = ParameterDirection.Output,
                    Size = sizeof(Int64)
                };
                ConnectionDAO dao = new ConnectionDAO();
                bool OK = dao.ExecNonQuery(sqlParameters, DanhMucNguoiSuDung.getIDProcedureName);
                if (!cenCommon.cenCommon.IsNull(sqlParameters[2].Value))
                {
                    IDDanhMucPhanQuyen = cenCommon.cenCommon.stringParse(sqlParameters[3].Value);
                    isAdmin = cenCommon.cenCommon.stringParse(sqlParameters[4].Value);
                    return cenCommon.cenCommon.stringParse(sqlParameters[2].Value);
                }
                else return null;
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return null;
            }
        }
        public bool UpdatePassword(object ID, object Password)
        {
            try
            {
                SqlParameter[] sqlParameters = new SqlParameter[2];
                sqlParameters[0] = new SqlParameter("@ID", ID);
                sqlParameters[1] = new SqlParameter("@Password", Password);
                ConnectionDAO dao = new ConnectionDAO();
                bool OK = dao.ExecNonQuery(sqlParameters, DanhMucNguoiSuDung.updatePasswordProcedureName);
                return OK;
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }

    }
}

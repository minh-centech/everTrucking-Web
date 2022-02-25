using cenCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO
{
    public static class commonDAO
    {
        public static Boolean IsGlobalParameter(String ParameterName)
        {
            return (cenCommon.GlobalVariables.GlobalSqlParametersList.IndexOf("(" + ParameterName.ToUpper() + ")") >= 0);
        }
        public static void SetGlobalParameterValue(SqlParameterCollection sqlParameters)
        {
            foreach (SqlParameter sp in sqlParameters)
            {
                if (IsGlobalParameter(sp.ParameterName))
                {
                    if (sqlParameters.Contains("@IDDonVi"))
                        sqlParameters["@IDDonVi"].Value = cenCommon.GlobalVariables.IDDonVi;
                    if (sqlParameters.Contains("@IDDanhMucDonVi"))
                        sqlParameters["@IDDanhMucDonVi"].Value = cenCommon.GlobalVariables.IDDonVi;
                    if (sqlParameters.Contains("@IDDanhMucNguoiSuDungCreate"))
                        sqlParameters["@IDDanhMucNguoiSuDungCreate"].Value = cenCommon.GlobalVariables.IDDanhMucNguoiSuDung;
                    if (sqlParameters.Contains("@IDDanhMucNguoiSuDungEdit"))
                        sqlParameters["@IDDanhMucNguoiSuDungEdit"].Value = cenCommon.GlobalVariables.IDDanhMucNguoiSuDung;
                    if (sqlParameters.Contains("@IDDanhMucNguoiSuDungDelete"))
                        sqlParameters["@IDDanhMucNguoiSuDungDelete"].Value = cenCommon.GlobalVariables.IDDanhMucNguoiSuDung;
                    if (sqlParameters.Contains("@IDDanhMucNguoiSuDung"))
                        sqlParameters["@IDDanhMucNguoiSuDung"].Value = cenCommon.GlobalVariables.IDDanhMucNguoiSuDung;
                }
            }
        }
        public static Boolean ExecNonQueryStoredProcedure(String spName, List<SqlParameter> paramList)
        {
            Int32 rowAffected = 0;
            SqlConnection connection = new SqlConnection(GlobalVariables.ConnectionString);
            connection.Open();
            SqlCommand sqlCMD;
            try
            {
                sqlCMD = new SqlCommand
                {
                    CommandTimeout = 0,
                    Connection = connection,
                    CommandText = spName,
                    CommandType = CommandType.StoredProcedure
                };
                //Lấy tham số 
                SqlCommandBuilder.DeriveParameters(sqlCMD);
                SetGlobalParameterValue(sqlCMD.Parameters);
                //Truyển một số giá trị mặc định vào tham số
                foreach (SqlParameter param in sqlCMD.Parameters)
                {
                    if (param.ParameterName != "@RETURN_VALUE" && !IsGlobalParameter(param.ParameterName))
                    {
                        foreach (SqlParameter iParamList in paramList)
                        {
                            if (param.ParameterName.ToUpper() == iParamList.ParameterName.ToUpper())
                            {
                                param.Value = iParamList.Value;
                                break;
                            }
                        }
                    }
                    if (param.Value == null)
                        param.Value = DBNull.Value;
                }
                rowAffected = sqlCMD.ExecuteNonQuery();
                //Lấy các tham số out nếu có
                foreach (SqlParameter param in sqlCMD.Parameters)
                {
                    if (param.ParameterName != "@RETURN_VALUE" && !IsGlobalParameter(param.ParameterName))
                    {
                        foreach (SqlParameter iParamList in paramList)
                        {
                            if (param.ParameterName.ToUpper() == iParamList.ParameterName.ToUpper())
                            {
                                iParamList.Value = param.Value;
                                break;
                            }
                        }
                    }
                    if (param.Value == null)
                        param.Value = DBNull.Value;
                }
                return (rowAffected > 0);
            }
            catch (SqlException e)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public static DataSet ExecQueryStoredProcedure(String spName, List<SqlParameter> paramList)
        {
            DataSet ds = new DataSet();
            SqlConnection connection = new SqlConnection(GlobalVariables.ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand sqlCMD = new SqlCommand(spName, connection);
            try
            {
                sqlCMD.CommandTimeout = 0;
                sqlCMD.CommandType = CommandType.StoredProcedure;
                sqlCMD.Connection = connection;
                connection.Open();
                SqlCommandBuilder.DeriveParameters(sqlCMD);
                SetGlobalParameterValue(sqlCMD.Parameters);
                //Truyển một số giá trị mặc định vào tham số
                foreach (SqlParameter param in sqlCMD.Parameters)
                {
                    if (param.ParameterName != "@RETURN_VALUE" && !IsGlobalParameter(param.ParameterName))
                    {
                        foreach (SqlParameter iParamList in paramList)
                        {
                            if (param.ParameterName.ToUpper() == iParamList.ParameterName.ToUpper())
                            {
                                param.Value = iParamList.Value;
                                break;
                            }
                        }
                    }
                    if (param.Value == null)
                        param.Value = DBNull.Value;
                }
                da.SelectCommand = sqlCMD;
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return null;
            }
            finally
            {
                ds.Dispose();
                sqlCMD.Dispose();
                da.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        public static Boolean UpdateRow2Server(DataRow dr, String spName, SqlConnection Connection, SqlTransaction Transaction, out object ID, Boolean INSChungTu)
        {
            Int32 rowAffected = 0;
            SqlCommand sqlCMD;
            ID = null;
            try
            {
                sqlCMD = new SqlCommand
                {
                    CommandTimeout = 0,
                    Connection = Connection,
                    CommandText = spName,
                    CommandType = CommandType.StoredProcedure
                };
                //Nếu lệnh này thuộc 1 transaction thì gán transaction
                if (Transaction != null) sqlCMD.Transaction = Transaction;
                //Lấy tham số 
                SqlCommandBuilder.DeriveParameters(sqlCMD);
                //Gán giá trị trong DataRow cho tham số của procedure
                MapDataRow2ParameterList(dr, sqlCMD.Parameters);
                rowAffected = sqlCMD.ExecuteNonQuery();
                if (sqlCMD.Parameters.Contains("@ID"))
                {
                    ID = sqlCMD.Parameters["@ID"].Value;
                    if (dr.Table.Columns.Contains("ID")) dr["ID"] = ID;
                }
                //Gán lại số chứng từ nếu là insert chứng từ
                if (INSChungTu && sqlCMD.Parameters.Contains("@So") && dr.Table.Columns.Contains("So"))
                    dr["So"] = sqlCMD.Parameters["@So"].Value.ToString();
                return true;
            }
            catch (SqlException ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public static Boolean DeleteRowServer(String spName, SqlConnection Connection, SqlTransaction Transaction, DataRow dr)
        {
            Int32 rowAffected = 0;
            SqlCommand sqlCMD;
            try
            {
                sqlCMD = new SqlCommand
                {
                    CommandTimeout = 0,
                    Connection = Connection,
                    CommandText = spName,
                    CommandType = CommandType.StoredProcedure
                };
                //Nếu lệnh này thuộc 1 transaction thì gán transaction
                if (Transaction != null) sqlCMD.Transaction = Transaction;
                //Lấy tham số 
                SqlCommandBuilder.DeriveParameters(sqlCMD);
                SetGlobalParameterValue(sqlCMD.Parameters);
                sqlCMD.Parameters["@ID"].Value = dr["ID", DataRowVersion.Original];
                rowAffected = sqlCMD.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
        }
        public static void MapDataRow2ParameterList(DataRow drParameter, SqlParameterCollection ParameterList)
        {
            SetGlobalParameterValue(ParameterList);
            foreach (SqlParameter sqlParameter in ParameterList)
            {
                if (!IsGlobalParameter(sqlParameter.ParameterName) && drParameter.Table.Columns.Contains(sqlParameter.ParameterName.Substring(1)))
                {
                    sqlParameter.Value = drParameter[sqlParameter.ParameterName.Substring(1)];
                }
            }
            foreach (SqlParameter sqlParameter in ParameterList)
            {
                if (!IsGlobalParameter(sqlParameter.ParameterName) && drParameter.Table.Columns.Contains(sqlParameter.ParameterName.Substring(1)) && sqlParameter.ParameterName.ToUpper().StartsWith("@ID") && sqlParameter.Value != DBNull.Value && sqlParameter.Value.ToString() == "")
                    sqlParameter.Value = DBNull.Value;
            }
        }
        public static void Copy2DataRows(DataRow drSource, DataRow drDestination)
        {
            if (drSource != null && drDestination != null)
            {
                foreach (DataColumn dc in drSource.Table.Columns)
                {
                    if (drDestination.Table.Columns.Contains(dc.ColumnName))
                    {
                        drDestination[dc.ColumnName] = drSource[dc];
                    }
                }
            }
        }
        public static DataTable ConvertToDataTable<T>(IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, System.Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static void countID(string tableName, out long countID)
        {
            countID = 0;
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@TableName", tableName);
            sqlParameters[1] = new SqlParameter("@countID", countID)
            {
                Size = 8,
                Direction = ParameterDirection.InputOutput
            };
            dao.ExecNonQuery(sqlParameters, "countID");
            if (!cenCommon.cenCommon.IsNull(sqlParameters[1].Value))
                long.TryParse(sqlParameters[1].Value.ToString(), out countID);
        }
    }
}

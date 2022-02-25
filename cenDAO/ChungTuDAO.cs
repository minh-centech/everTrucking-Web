using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO
{
    public class ChungTuDAO
    {
        public DataSet LoadEmpty(object IDDanhMucChungTu, Int16 DetailLevel, String TableName, String TableNameDetail, String TableNameDetail2)
        {
            DataSet dsChungTu = new System.Data.DataSet();
            ConnectionDAO ConnectionDAO = new ConnectionDAO();
            SqlParameter[] SqlParameter = new SqlParameter[2];
            SqlParameter[0] = new SqlParameter("@IDDonVi", DBNull.Value);
            SqlParameter[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            dsChungTu = ConnectionDAO.dsList(SqlParameter, "List_" + TableName);
            if (dsChungTu == null)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly("Không lấy được dữ liệu chứng từ!");
                return null;
            }
            dsChungTu.Tables[0].TableName = TableName;
            dsChungTu.Tables[TableName].PrimaryKey = new DataColumn[] { dsChungTu.Tables[TableName].Columns["ID"] };
            if (DetailLevel >= 1)
            {
                //Set relations
                dsChungTu.Relations.Clear();
                dsChungTu.EnforceConstraints = false;
                dsChungTu.Tables[1].TableName = TableNameDetail;
                dsChungTu.Tables[TableNameDetail].PrimaryKey = new DataColumn[] { dsChungTu.Tables[TableNameDetail].Columns["ID"] };
                dsChungTu.Relations.Add(new DataRelation(cenCommon.GlobalVariables.prefix_DataRelation + TableNameDetail, dsChungTu.Tables[TableName].Columns["ID"], dsChungTu.Tables[TableNameDetail].Columns["IDChungTu"]));
                //Nếu có 2 mức chi tiết
                if (DetailLevel == 2)
                {
                    dsChungTu.Tables[2].TableName = TableNameDetail2;
                    dsChungTu.Tables[TableNameDetail2].PrimaryKey = new DataColumn[] { dsChungTu.Tables[TableNameDetail2].Columns["ID"] };
                    dsChungTu.Relations.Add(new DataRelation(cenCommon.GlobalVariables.prefix_DataRelation + TableNameDetail2, dsChungTu.Tables[TableNameDetail].Columns["ID"], dsChungTu.Tables[TableNameDetail2].Columns["IDChungTuChiTiet"]));
                }
            }
            return dsChungTu;
        }
        public DataSet Load(DataTable dtThamSo, object IDDanhMucChungTu, Int16 DetailLevel, String TableName, String TableNameDetail, String TableNameDetail2)
        {
            DataSet dsChungTu = new System.Data.DataSet();
            ConnectionDAO ConnectionDAO = new ConnectionDAO();
            SqlParameter[] SqlParameter = new SqlParameter[0];
            if (dtThamSo.Rows.Count > 0)
            {
                SqlParameter = new SqlParameter[dtThamSo.Rows.Count];
                Int16 _rIndex = 0;
                foreach (DataRow _row in dtThamSo.Rows)
                {
                    if (_row["Ten"].ToString() == "@IDDONVI") _row["GiaTri"] = cenCommon.GlobalVariables.IDDonVi;
                    if (_row["Ten"].ToString() == "@IDDANHMUCCHUNGTU") _row["GiaTri"] = IDDanhMucChungTu;
                    SqlParameter[_rIndex] = new SqlParameter(_row["Ten"].ToString(), _row["GiaTri"]);
                    _rIndex++;
                }
            }
            dsChungTu = ConnectionDAO.dsList(SqlParameter, "List_" + TableName);
            if (dsChungTu == null)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly("Không lấy được dữ liệu chứng từ!");

                return dsChungTu;
            }
            dsChungTu.Tables[0].TableName = TableName;
            dsChungTu.Tables[TableName].PrimaryKey = new DataColumn[] { dsChungTu.Tables[TableName].Columns["ID"] };
            if (dsChungTu.Tables[TableName].Rows.Count == 0)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly("Không tìm thấy chứng từ nào!");
                return null;
            }
            if (DetailLevel >= 1)
            {
                //Set relations
                dsChungTu.Relations.Clear();
                dsChungTu.EnforceConstraints = false;
                dsChungTu.Tables[1].TableName = TableNameDetail;
                dsChungTu.Tables[TableNameDetail].PrimaryKey = new DataColumn[] { dsChungTu.Tables[TableNameDetail].Columns["ID"] };
                dsChungTu.Relations.Add(new DataRelation(cenCommon.GlobalVariables.prefix_DataRelation + TableNameDetail, dsChungTu.Tables[TableName].Columns["ID"], dsChungTu.Tables[TableNameDetail].Columns["IDChungTu"]));
                //Nếu có 2 mức chi tiết
                if (DetailLevel == 2)
                {
                    dsChungTu.Tables[2].TableName = TableNameDetail2;
                    dsChungTu.Tables[TableNameDetail2].PrimaryKey = new DataColumn[] { dsChungTu.Tables[TableNameDetail2].Columns["ID"] };
                    dsChungTu.Relations.Add(new DataRelation(cenCommon.GlobalVariables.prefix_DataRelation + TableNameDetail2, dsChungTu.Tables[TableNameDetail].Columns["ID"], dsChungTu.Tables[TableNameDetail2].Columns["IDChungTuChiTiet"]));
                }
            }
            return dsChungTu;
        }
        public DataSet LoadByID(Object IDChungTu, object IDDanhMucChungTu, Int16 DetailLevel, String TableName, String TableNameDetail, String TableNameDetail2)
        {
            DataSet dsChungTu = new System.Data.DataSet();
            ConnectionDAO ConnectionDAO = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@IDDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@ID", IDChungTu);
            dsChungTu = ConnectionDAO.dsList(sqlParameters, "List_" + TableName);
            if (dsChungTu == null)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly("Không lấy được dữ liệu chứng từ!");
                return dsChungTu;
            }
            dsChungTu.Tables[0].TableName = TableName;
            dsChungTu.Tables[TableName].PrimaryKey = new DataColumn[] { dsChungTu.Tables[TableName].Columns["ID"] };
            if (dsChungTu.Tables[TableName].Rows.Count == 0)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly("Không tìm thấy chứng từ nào!");
                return null;
            }
            if (DetailLevel >= 1)
            {
                //Set relations
                dsChungTu.Relations.Clear();
                dsChungTu.EnforceConstraints = false;
                dsChungTu.Tables[1].TableName = TableNameDetail;
                dsChungTu.Tables[TableNameDetail].PrimaryKey = new DataColumn[] { dsChungTu.Tables[TableNameDetail].Columns["ID"] };
                dsChungTu.Relations.Add(new DataRelation(cenCommon.GlobalVariables.prefix_DataRelation + TableNameDetail, dsChungTu.Tables[TableName].Columns["ID"], dsChungTu.Tables[TableNameDetail].Columns["IDChungTu"]));
                //Nếu có 2 mức chi tiết
                if (DetailLevel == 2)
                {
                    dsChungTu.Tables[2].TableName = TableNameDetail2;
                    dsChungTu.Tables[TableNameDetail2].PrimaryKey = new DataColumn[] { dsChungTu.Tables[TableNameDetail2].Columns["ID"] };
                    dsChungTu.Relations.Add(new DataRelation(cenCommon.GlobalVariables.prefix_DataRelation + TableNameDetail2, dsChungTu.Tables[TableNameDetail].Columns["ID"], dsChungTu.Tables[TableNameDetail2].Columns["IDChungTuChiTiet"]));
                }
            }
            return dsChungTu;
        }
        public Boolean Insert(out Object ID, out String So, String InsertProcName, String InsertChiTietProcName, String InsertChiTiet2ProcName, DataTable dtMaster, DataTable dtDetail, DataTable dtDetail2)
        {
            String MoTa = String.Empty;
            Boolean OK = true;
            So = "";
            ID = null;
            SqlConnection connection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString);
            SqlTransaction transaction;
            //BẮT ĐẦU GIAO DỊCH
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                foreach (DataRow drMaster in dtMaster.Rows)
                {
                    if (drMaster.RowState != DataRowState.Deleted)
                    {
                        OK = commonDAO.UpdateRow2Server(drMaster, InsertProcName, connection, transaction, out ID, true);
                        if (OK)
                        {
                            drMaster["ID"] = ID;
                            So = drMaster["So"].ToString();
                            drMaster.AcceptChanges();
                            foreach (DataColumn dc in drMaster.Table.Columns)
                            {
                                if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drMaster[dc] != DBNull.Value && drMaster[dc].ToString().Trim() != "")
                                {
                                    MoTa += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drMaster[dc].ToString() + "]; ";
                                }
                            }
                            if (dtDetail != null)
                            {
                                MoTa += "\nCHI TIẾT CHỨNG TỪ\n";
                                //Insert dòng chi tiết
                                foreach (DataRow drDetail in dtDetail.Rows)
                                {
                                    if (drDetail.RowState == DataRowState.Added)
                                    {
                                        drDetail["IDChungTu"] = ID;
                                        OK = commonDAO.UpdateRow2Server(drDetail, InsertChiTietProcName, connection, transaction, out object IDChiTiet, true);
                                        if (OK)
                                        {
                                            drDetail["ID"] = IDChiTiet;
                                            foreach (DataColumn dc in drDetail.Table.Columns)
                                            {
                                                if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drDetail[dc] != DBNull.Value && drDetail[dc].ToString().Trim() != "")
                                                {
                                                    MoTa += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drDetail[dc].ToString() + "]; ";
                                                }
                                            }
                                            MoTa += "\n";
                                            //Insert dòng chi tiết 2 nếu có
                                            if (dtDetail2 != null)
                                            {
                                                object IDChiTiet2 = "";
                                                foreach (DataRow drDetail2 in dtDetail2.Rows)
                                                {
                                                    if (drDetail2.RowState != DataRowState.Deleted && drDetail2["IDChungTuChiTiet"] == drDetail["ID"])
                                                    {

                                                        drDetail2["IDChungTu"] = ID;
                                                        drDetail2["IDChungTuChiTiet"] = IDChiTiet;
                                                        OK = commonDAO.UpdateRow2Server(drDetail2, InsertChiTiet2ProcName, connection, transaction, out IDChiTiet2, false);
                                                        if (OK)
                                                        {

                                                            foreach (DataColumn dc in drDetail2.Table.Columns)
                                                            {
                                                                if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drDetail2[dc] != DBNull.Value && drDetail2[dc].ToString().Trim() != "")
                                                                {
                                                                    MoTa += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drDetail2[dc].ToString() + "]; ";
                                                                }
                                                            }
                                                            MoTa += "\n";
                                                            drDetail2["ID"] = IDChiTiet2;
                                                        }
                                                        else break;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                            break;
                                    }
                                }
                            }

                        }
                        else
                            break;
                    }
                }
                //HOÀN TẤT GIAO DỊCH
                if (OK)
                {
                    //Ghi nhật kí dữ liệu
                    SqlCommand cmdNhatKy = new SqlCommand
                    {
                        Connection = connection,
                        Transaction = transaction
                    };
                    cmdNhatKy.Parameters.AddWithValue("@IDDonVi", cenCommon.GlobalVariables.IDDonVi);
                    cmdNhatKy.Parameters.AddWithValue("@IDDanhMucNguoiSuDung", cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                    cmdNhatKy.Parameters.AddWithValue("@HoatDong", "Thêm " + cenCommon.cenCommon.TraTuDien(InsertProcName.Substring(InsertProcName.IndexOf("_") + 1)));
                    MoTa = "ID: [" + ID + "]\n" + MoTa;
                    cmdNhatKy.Parameters.AddWithValue("@MoTa", MoTa);
                    cmdNhatKy.CommandType = CommandType.StoredProcedure;
                    cmdNhatKy.CommandText = "Insert_sysNhatKyDuLieu";
                    OK = (cmdNhatKy.ExecuteNonQuery() > 0);
                    if (OK)
                        transaction.Commit();
                    else
                        transaction.Rollback();
                }
                else
                    transaction.Rollback();
                return OK;
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public Boolean Insert(out Object ID, out String So, String InsertProcName, String InsertChiTietProcName, String InsertChiTiet2ProcName, DataRow drMaster, DataTable dtDetail, DataTable dtDetail2)
        {
            Boolean OK = true;
            String MoTa = String.Empty;
            So = "";
            ID = null;
            SqlConnection connection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString);
            SqlTransaction transaction;
            //BẮT ĐẦU GIAO DỊCH
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                if (drMaster.RowState != DataRowState.Deleted)
                {
                    OK = commonDAO.UpdateRow2Server(drMaster, InsertProcName, connection, transaction, out ID, true);
                    if (OK)
                    {
                        drMaster["ID"] = ID;
                        So = drMaster["So"].ToString();
                        drMaster.AcceptChanges();
                        foreach (DataColumn dc in drMaster.Table.Columns)
                        {
                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drMaster[dc] != DBNull.Value && drMaster[dc].ToString().Trim() != "")
                            {
                                MoTa += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drMaster[dc].ToString() + "]; ";
                            }
                        }
                        if (dtDetail != null)
                        {
                            MoTa += "\nCHI TIẾT CHỨNG TỪ\n";
                            //Insert dòng chi tiết
                            foreach (DataRow drDetail in dtDetail.Rows)
                            {

                                if (drDetail.RowState != DataRowState.Deleted)
                                {
                                    drDetail["IDChungTu"] = ID;
                                    OK = commonDAO.UpdateRow2Server(drDetail, InsertChiTietProcName, connection, transaction, out object IDChiTiet, true);
                                    if (OK)
                                    {
                                        drDetail["ID"] = IDChiTiet;

                                        foreach (DataColumn dc in drDetail.Table.Columns)
                                        {
                                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drDetail[dc] != DBNull.Value && drDetail[dc].ToString().Trim() != "")
                                            {
                                                MoTa += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drDetail[dc].ToString() + "]; ";
                                            }
                                        }
                                        MoTa += "\n";
                                        //Insert dòng chi tiết 2 nếu có
                                        if (dtDetail2 != null)
                                        {
                                            object IDChiTiet2 = "";
                                            foreach (DataRow drDetail2 in dtDetail2.Rows)
                                            {
                                                if (drDetail2.RowState != DataRowState.Deleted && drDetail2["IDChungTuChiTiet"] == drDetail["ID"])
                                                {
                                                    drDetail2["IDChungTu"] = ID;
                                                    drDetail2["IDChungTuChiTiet"] = IDChiTiet;
                                                    OK = commonDAO.UpdateRow2Server(drDetail2, InsertChiTiet2ProcName, connection, transaction, out IDChiTiet2, false);
                                                    if (OK)
                                                    {
                                                        drDetail2["ID"] = IDChiTiet2;

                                                        foreach (DataColumn dc in drDetail2.Table.Columns)
                                                        {
                                                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drDetail2[dc] != DBNull.Value && drDetail2[dc].ToString().Trim() != "")
                                                            {
                                                                MoTa += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drDetail2[dc].ToString() + "]; ";
                                                            }
                                                        }
                                                        MoTa += "\n";
                                                    }
                                                    else break;
                                                }
                                            }
                                        }
                                    }
                                    else
                                        break;
                                }
                            }
                        }

                    }
                }
                //HOÀN TẤT GIAO DỊCH
                if (OK)
                {
                    //Ghi nhật kí dữ liệu
                    SqlCommand cmdNhatKy = new SqlCommand
                    {
                        Connection = connection,
                        Transaction = transaction
                    };
                    cmdNhatKy.Parameters.AddWithValue("@IDDonVi", cenCommon.GlobalVariables.IDDonVi);
                    cmdNhatKy.Parameters.AddWithValue("@IDDanhMucNguoiSuDung", cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                    cmdNhatKy.Parameters.AddWithValue("@HoatDong", "Thêm " + cenCommon.cenCommon.TraTuDien(InsertProcName.Substring(InsertProcName.IndexOf("_") + 1)));
                    MoTa = "ID: [" + ID + "]\n" + MoTa;
                    cmdNhatKy.Parameters.AddWithValue("@MoTa", MoTa);
                    cmdNhatKy.CommandType = CommandType.StoredProcedure;
                    cmdNhatKy.CommandText = "Insert_sysNhatKyDuLieu";
                    OK = (cmdNhatKy.ExecuteNonQuery() > 0);
                    if (OK)
                        transaction.Commit();
                    else
                        transaction.Rollback();
                }
                else
                    transaction.Rollback();
                return OK;
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public Boolean Update(Object ID, String UpdateProcName, String InsertChiTietProcName, String InsertChiTiet2ProcName, String UpdateChiTietProcName, String UpdateChiTiet2ProcName, String DeleteChiTietProcName, String DeleteChiTiet2ProcName, DataTable dtMaster, DataTable dtDetail, DataTable dtDetail2)
        {
            Boolean OK = true;
            String MoTa = String.Empty, MoTa2 = String.Empty;
            Object IDChiTiet = null;
            SqlConnection connection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString);
            SqlTransaction transaction;
            //BẮT ĐẦU GIAO DỊCH
            connection.Open();
            transaction = connection.BeginTransaction();
            //try
            //{
            foreach (DataRow drMaster in dtMaster.Rows)
            {
                if (drMaster["ID"] == ID)
                {
                    OK = commonDAO.UpdateRow2Server(drMaster, UpdateProcName, connection, transaction, out ID, false);
                    ID = drMaster["ID"].ToString();
                    //drMaster.AcceptChanges();
                    if (OK)
                    {
                        foreach (DataColumn dc in drMaster.Table.Columns)
                        {
                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drMaster[dc].ToString().Trim() != drMaster[dc, DataRowVersion.Original].ToString().Trim())
                            {
                                MoTa += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": từ [" + drMaster[dc, DataRowVersion.Original].ToString() + "] thành [" + drMaster[dc].ToString() + "]; ";
                            }
                        }
                        MoTa = "ID: [" + ID.ToString() + "]\n" + "Số: [" + drMaster["So", DataRowVersion.Original].ToString() + "]" + ((MoTa.Trim() != "") ? "\n" + MoTa : "") + "\nCHI TIẾT CHỨNG TỪ\n";
                        if (dtDetail != null)
                        {
                            //Update dòng chi tiết
                            foreach (DataRow drDetail in dtDetail.Rows)
                            {
                                String MoTaChiTiet = String.Empty;

                                if (drDetail.RowState != DataRowState.Deleted)
                                {
                                    IDChiTiet = drDetail["ID"];
                                }

                                if (drDetail.RowState == DataRowState.Deleted)
                                {
                                    OK = commonDAO.DeleteRowServer(DeleteChiTietProcName, connection, transaction, drDetail);
                                    if (OK)
                                    {
                                        foreach (DataColumn dc in drDetail.Table.Columns)
                                        {
                                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drDetail[dc, DataRowVersion.Original] != DBNull.Value && drDetail[dc, DataRowVersion.Original].ToString().Trim() != "")
                                            {
                                                MoTaChiTiet += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drDetail[dc, DataRowVersion.Original].ToString() + "]; ";
                                            }
                                        }
                                        MoTaChiTiet = "Xóa dòng chi tiết ID: " + MoTaChiTiet;
                                    }
                                    else
                                        break;
                                }
                                if (drDetail.RowState == DataRowState.Modified)
                                {
                                    OK = commonDAO.UpdateRow2Server(drDetail, UpdateChiTietProcName, connection, transaction, out IDChiTiet, false);
                                    if (OK)
                                    {
                                        drDetail["ID"] = IDChiTiet;
                                        foreach (DataColumn dc in drDetail.Table.Columns)
                                        {
                                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drDetail[dc].ToString().Trim() != drDetail[dc, DataRowVersion.Original].ToString().Trim())
                                            {
                                                MoTaChiTiet += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": từ [" + drDetail[dc, DataRowVersion.Original].ToString() + "] thành [" + drDetail[dc].ToString() + "]; ";
                                            }
                                        }

                                        MoTaChiTiet = "Sửa dòng chi tiết ID: [" + IDChiTiet.ToString() + "]\n" + MoTaChiTiet;
                                    }
                                    else
                                        break;
                                }
                                if (drDetail.RowState == DataRowState.Added)
                                {
                                    IDChiTiet = "";
                                    drDetail["IDChungTu"] = ID;
                                    OK = commonDAO.UpdateRow2Server(drDetail, InsertChiTietProcName, connection, transaction, out IDChiTiet, false);
                                    if (OK)
                                    {
                                        drDetail["ID"] = IDChiTiet;
                                        foreach (DataColumn dc in drDetail.Table.Columns)
                                        {
                                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drDetail[dc] != DBNull.Value && drDetail[dc].ToString().Trim() != "")
                                            {
                                                MoTaChiTiet += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drDetail[dc].ToString() + "]; ";
                                            }
                                        }
                                        MoTaChiTiet = "Thêm dòng chi tiết ID: [" + ID + "]\n" + MoTaChiTiet;
                                    }
                                    else
                                        break;
                                }
                                //Update chi tiết 2
                                if (dtDetail2 != null)
                                {
                                    object IDChiTiet2 = "";
                                    foreach (DataRow drDetail2 in dtDetail2.Rows)
                                    {
                                        if (drDetail2.RowState == DataRowState.Deleted)
                                        {
                                            OK = commonDAO.DeleteRowServer(DeleteChiTiet2ProcName, connection, transaction, drDetail2);
                                            if (!OK)
                                                break;
                                        }
                                        if (drDetail2.RowState == DataRowState.Modified && drDetail2["IDChungTuChiTiet"].ToString() == drDetail["ID"].ToString())
                                        {
                                            drDetail2["IDChungTu"] = ID;
                                            drDetail2["IDChungTuChiTiet"] = IDChiTiet;
                                            OK = commonDAO.UpdateRow2Server(drDetail2, UpdateChiTiet2ProcName, connection, transaction, out IDChiTiet2, false);
                                            if (OK)
                                            {
                                                drDetail2.AcceptChanges();
                                            }
                                            else break;
                                        }
                                        if (drDetail2.RowState == DataRowState.Added && drDetail2["IDChungTuChiTiet"].ToString() == drDetail["ID"].ToString())
                                        {
                                            drDetail2["IDChungTu"] = ID;
                                            drDetail2["IDChungTuChiTiet"] = IDChiTiet;
                                            OK = commonDAO.UpdateRow2Server(drDetail2, InsertChiTiet2ProcName, connection, transaction, out IDChiTiet2, false);
                                            if (OK)
                                            {
                                                drDetail2["ID"] = IDChiTiet2;
                                                drDetail2.AcceptChanges();
                                            }
                                            else break;
                                        }
                                    }
                                }
                                MoTa2 += MoTaChiTiet;
                            }
                        }
                    }
                    else
                        break;
                }
            }
            //HOÀN TẤT GIAO DỊCH
            if (OK)
            {
                //Ghi nhật kí dữ liệu
                SqlCommand cmdNhatKy = new SqlCommand
                {
                    Connection = connection,
                    Transaction = transaction
                };
                cmdNhatKy.Parameters.AddWithValue("@IDDonVi", cenCommon.GlobalVariables.IDDonVi);
                cmdNhatKy.Parameters.AddWithValue("@IDDanhMucNguoiSuDung", cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                cmdNhatKy.Parameters.AddWithValue("@HoatDong", "Sửa " + cenCommon.cenCommon.TraTuDien(UpdateProcName.Substring(UpdateProcName.IndexOf("_") + 1)));
                cmdNhatKy.Parameters.AddWithValue("@MoTa", MoTa + MoTa2);
                cmdNhatKy.CommandType = CommandType.StoredProcedure;
                cmdNhatKy.CommandText = "Insert_sysNhatKyDuLieu";
                OK = (cmdNhatKy.ExecuteNonQuery() > 0);
                if (OK)
                    transaction.Commit();
                else
                    transaction.Rollback();
            }
            else
                transaction.Rollback();
            connection.Close();
            connection.Dispose();
            return OK;
            //}
            //catch (Exception ex)
            //{
            //    cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
            //    return false;
            //}
            //finally
            //{
            //connection.Close();
            //connection.Dispose();
            //}
        }
        public Boolean Update(Object ID, String UpdateProcName, String InsertChiTietProcName, String InsertChiTiet2ProcName, String UpdateChiTietProcName, String UpdateChiTiet2ProcName, String DeleteChiTietProcName, String DeleteChiTiet2ProcName, DataRow drMaster, DataTable dtDetail, DataTable dtDetail2)
        {
            String MoTa = String.Empty, MoTa2 = String.Empty;
            Boolean OK = true;
            Object IDChiTiet = null;
            SqlConnection connection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString);
            SqlTransaction transaction;
            //BẮT ĐẦU GIAO DỊCH
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {

                if (drMaster["ID"] == ID)
                {
                    OK = commonDAO.UpdateRow2Server(drMaster, UpdateProcName, connection, transaction, out ID, false);
                    ID = drMaster["ID"].ToString();
                    //drMaster.AcceptChanges();
                    if (OK)
                    {
                        foreach (DataColumn dc in drMaster.Table.Columns)
                        {
                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drMaster[dc].ToString().Trim() != drMaster[dc, DataRowVersion.Original].ToString().Trim())
                            {
                                MoTa += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": từ [" + drMaster[dc, DataRowVersion.Original].ToString() + "] thành [" + drMaster[dc].ToString() + "]; ";
                            }
                        }
                        MoTa = "ID: [" + ID.ToString() + "]\n" + "Số: [" + drMaster["So", DataRowVersion.Original].ToString() + "]" + ((MoTa.Trim() != "") ? "\n" + MoTa : "") + "\nCHI TIẾT CHỨNG TỪ\n";
                        if (dtDetail != null)
                        {
                            //Update dòng chi tiết
                            foreach (DataRow drDetail in dtDetail.Rows)
                            {
                                String MoTaChiTiet = String.Empty;
                                if (drDetail.RowState != DataRowState.Deleted)
                                    IDChiTiet = drDetail["ID"];
                                if (drDetail.RowState == DataRowState.Deleted)
                                {
                                    OK = commonDAO.DeleteRowServer(DeleteChiTietProcName, connection, transaction, drDetail);
                                    if (OK)
                                    {
                                        foreach (DataColumn dc in drDetail.Table.Columns)
                                        {
                                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drDetail[dc, DataRowVersion.Original] != DBNull.Value && drDetail[dc, DataRowVersion.Original].ToString().Trim() != "")
                                            {
                                                MoTaChiTiet += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drDetail[dc, DataRowVersion.Original].ToString() + "]; ";
                                            }
                                        }
                                        MoTaChiTiet = "Xóa dòng chi tiết ID: [" + IDChiTiet.ToString() + "]\n" + MoTaChiTiet;
                                    }
                                    else
                                        break;
                                }
                                if (drDetail.RowState == DataRowState.Modified)
                                {
                                    OK = commonDAO.UpdateRow2Server(drDetail, UpdateChiTietProcName, connection, transaction, out IDChiTiet, false);
                                    if (OK)
                                    {
                                        drDetail["ID"] = IDChiTiet;
                                        foreach (DataColumn dc in drDetail.Table.Columns)
                                        {
                                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drDetail[dc].ToString().Trim() != drDetail[dc, DataRowVersion.Original].ToString().Trim())
                                            {
                                                MoTaChiTiet += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": từ [" + drDetail[dc, DataRowVersion.Original].ToString() + "] thành [" + drDetail[dc].ToString() + "]; ";
                                            }
                                        }

                                        MoTaChiTiet = "Sửa dòng chi tiết ID: [" + IDChiTiet.ToString() + "]\n" + MoTaChiTiet;
                                    }
                                    else
                                        break;
                                }
                                if (drDetail.RowState == DataRowState.Added)
                                {
                                    IDChiTiet = "";
                                    drDetail["IDChungTu"] = ID;
                                    OK = commonDAO.UpdateRow2Server(drDetail, InsertChiTietProcName, connection, transaction, out IDChiTiet, false);
                                    if (OK)
                                    {
                                        drDetail["ID"] = IDChiTiet;
                                        foreach (DataColumn dc in drDetail.Table.Columns)
                                        {
                                            if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drDetail[dc] != DBNull.Value && drDetail[dc].ToString().Trim() != "")
                                            {
                                                MoTaChiTiet += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drDetail[dc].ToString() + "]; ";
                                            }
                                        }
                                        MoTaChiTiet = "Thêm dòng chi tiết ID: [" + ID + "]\n" + MoTaChiTiet;
                                    }
                                    else
                                        break;
                                }
                                //Update chi tiết 2
                                if (dtDetail2 != null)
                                {
                                    object IDChiTiet2 = "";
                                    foreach (DataRow drDetail2 in dtDetail2.Rows)
                                    {
                                        if (drDetail2.RowState == DataRowState.Deleted && drDetail2["IDChungTuChiTiet", DataRowVersion.Original].ToString() == drDetail["ID"].ToString())
                                        {
                                            OK = commonDAO.DeleteRowServer(DeleteChiTiet2ProcName, connection, transaction, drDetail2);
                                            if (!OK)
                                                break;
                                        }
                                        if (drDetail2.RowState == DataRowState.Modified && drDetail2["IDChungTuChiTiet"].ToString() == drDetail["ID"].ToString())
                                        {
                                            drDetail2["IDChungTu"] = ID;
                                            drDetail2["IDChungTuChiTiet"] = IDChiTiet;
                                            OK = commonDAO.UpdateRow2Server(drDetail2, UpdateChiTiet2ProcName, connection, transaction, out IDChiTiet2, false);
                                            if (OK)
                                            {
                                                drDetail2.AcceptChanges();
                                            }
                                            else break;
                                        }
                                        if (drDetail2.RowState == DataRowState.Added && drDetail2["IDChungTuChiTiet"].ToString() == drDetail["ID"].ToString())
                                        {
                                            drDetail2["IDChungTu"] = ID;
                                            drDetail2["IDChungTuChiTiet"] = IDChiTiet;
                                            OK = commonDAO.UpdateRow2Server(drDetail2, InsertChiTiet2ProcName, connection, transaction, out IDChiTiet2, false);
                                            if (OK)
                                            {
                                                drDetail2["ID"] = IDChiTiet2;
                                                drDetail2.AcceptChanges();
                                            }
                                            else break;
                                        }
                                    }
                                }
                                MoTa2 += MoTaChiTiet;
                            }
                        }
                    }
                }

                //HOÀN TẤT GIAO DỊCH
                if (OK)
                {
                    //Ghi nhật kí dữ liệu
                    SqlCommand cmdNhatKy = new SqlCommand
                    {
                        Connection = connection,
                        Transaction = transaction
                    };
                    cmdNhatKy.Parameters.AddWithValue("@IDDonVi", cenCommon.GlobalVariables.IDDonVi);
                    cmdNhatKy.Parameters.AddWithValue("@IDDanhMucNguoiSuDung", cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                    cmdNhatKy.Parameters.AddWithValue("@HoatDong", "Sửa " + cenCommon.cenCommon.TraTuDien(UpdateProcName.Substring(UpdateProcName.IndexOf("_") + 1)));
                    cmdNhatKy.Parameters.AddWithValue("@MoTa", MoTa + MoTa2);
                    cmdNhatKy.CommandType = CommandType.StoredProcedure;
                    cmdNhatKy.CommandText = "Insert_sysNhatKyDuLieu";
                    OK = (cmdNhatKy.ExecuteNonQuery() > 0);
                    if (OK)
                        transaction.Commit();
                    else
                        transaction.Rollback();
                }
                else
                    transaction.Rollback();
                return OK;
            }
            catch (Exception ex)
            {
                cenCommon.cenCommon.ErrorMessageOkOnly(ex.Message);
                return false;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
        public Boolean Delete(DataRow drChungTu, String deleteProcName)
        {
            SqlConnection connection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString);
            SqlTransaction transaction;
            //BẮT ĐẦU GIAO DỊCH
            connection.Open();
            transaction = connection.BeginTransaction();
            try
            {
                Boolean A = commonDAO.DeleteRowServer(deleteProcName, connection, transaction, drChungTu);
                if (A)
                {
                    //Ghi nhật kí dữ liệu
                    String MoTa = String.Empty;
                    SqlCommand cmdNhatKy = new SqlCommand
                    {
                        Connection = connection,
                        Transaction = transaction
                    };
                    cmdNhatKy.Parameters.AddWithValue("@IDDonVi", cenCommon.GlobalVariables.IDDonVi);
                    cmdNhatKy.Parameters.AddWithValue("@IDDanhMucNguoiSuDung", cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                    cmdNhatKy.Parameters.AddWithValue("@HoatDong", "Xóa " + cenCommon.cenCommon.TraTuDien(deleteProcName.Substring(deleteProcName.IndexOf("_") + 1)));
                    foreach (DataColumn dc in drChungTu.Table.Columns)
                    {
                        if (!dc.ColumnName.StartsWith("ID") && dc.ColumnName != "CreateDate" && dc.ColumnName != "EditDate" && drChungTu[dc, DataRowVersion.Original] != DBNull.Value && drChungTu[dc, DataRowVersion.Original].ToString().Trim() != "")
                        {
                            MoTa += cenCommon.cenCommon.TraTuDien(dc.ColumnName) + ": [" + drChungTu[dc, DataRowVersion.Original].ToString() + "]; ";
                        }
                    }
                    MoTa = "ID: [" + drChungTu["ID", DataRowVersion.Original].ToString() + "]\n" + MoTa;
                    cmdNhatKy.Parameters.AddWithValue("@MoTa", MoTa);
                    cmdNhatKy.CommandType = CommandType.StoredProcedure;
                    cmdNhatKy.CommandText = "Insert_sysNhatKyDuLieu";
                    A = (cmdNhatKy.ExecuteNonQuery() > 0);
                    transaction.Commit();
                    return true;
                }
                else
                    return false;
            }
            catch (SqlException e)
            {
                transaction.Rollback();
                cenCommon.cenCommon.ErrorMessageOkOnly(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }
    }
}

using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace cenDAO.cenLogistics
{
    public class ctThanhToanTamUngDAO
    {
        public DataSet List(object IDDanhMucChungTu, object IDChungTu, object IDChungTuChiTiet)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@IDChungTu", IDChungTu);
            sqlParameters[3] = new SqlParameter("@IDChungTuChiTiet", IDChungTuChiTiet);
            DataSet ds = dao.dsList(sqlParameters, ctThanhToanTamUng.listProcedureName);
            if (ds != null)
            {
                ds.Tables[0].TableName = ctDonHang.tableName;
                ds.Tables[1].TableName = ctThanhToanTamUng.tableName;
                ds.Relations.Add(cenCommon.GlobalVariables.prefix_DataRelation + ctThanhToanTamUng.tableName, ds.Tables[ctDonHang.tableName].Columns["ID"], ds.Tables[ctThanhToanTamUng.tableName].Columns["IDChungTu"]);

            }
            return ds;
        }
        public DataTable ListDisplay(object IDDanhMucChungTu, object IDChungTu, object IDChungTuChiTiet, object TuNgay, object DenNgay)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@IDChungTu", IDChungTu);
            sqlParameters[3] = new SqlParameter("@IDChungTuChiTiet", IDChungTuChiTiet);
            sqlParameters[4] = new SqlParameter("@TuNgay", TuNgay);
            sqlParameters[5] = new SqlParameter("@DenNgay", DenNgay);
            DataTable dt = dao.tableList(sqlParameters, ctThanhToanTamUng.listDisplayProcedureName, ctThanhToanTamUng.tableName);
            return dt;
        }
        public DataTable ListDeNghiThanhToanGuiKhachHang(object IDDanhMucChungTu, object IDChungTu)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@ID", IDChungTu);
            DataTable dt = dao.tableList(sqlParameters, ctThanhToanTamUng.listDeNghiThanhToanGuiKhachHangProcedureName, ctThanhToanTamUng.listDeNghiThanhToanGuiKhachHangProcedureName);
            return dt;
        }

        public bool Insert(List<ctThanhToanTamUng> objList)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctThanhToanTamUng.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            foreach (ctThanhToanTamUng obj in objList)
                            {
                                SqlParameter[] sqlParameters = new SqlParameter[17];
                                sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                                {
                                    Direction = ParameterDirection.Output,
                                    Size = sizeof(Int64)
                                };
                                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                                sqlParameters[3] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                                sqlParameters[4] = new SqlParameter("@IDChungTuChiTiet", obj.IDChungTuChiTiet);
                                sqlParameters[5] = new SqlParameter("@LoaiThanhToanTamUng", obj.LoaiThanhToanTamUng);
                                sqlParameters[6] = new SqlParameter("@IDDanhMucCanBoThanhToanTamUng", obj.IDDanhMucCanBoThanhToanTamUng);
                                sqlParameters[7] = new SqlParameter("@NgayThanhToanTamUng", obj.NgayThanhToanTamUng);
                                sqlParameters[8] = new SqlParameter("@SoTienHoanTamUng", obj.SoTienHoanTamUng);
                                sqlParameters[9] = new SqlParameter("@IDDanhMucChiPhiHaiQuanKinhDoanh", obj.IDDanhMucChiPhiHaiQuanKinhDoanh);
                                sqlParameters[10] = new SqlParameter("@SoTienChiThuTuc", obj.SoTienChiThuTuc);
                                sqlParameters[11] = new SqlParameter("@SoTienChiTraHoCoHoaDon", obj.SoTienChiTraHoCoHoaDon);
                                sqlParameters[12] = new SqlParameter("@SoTienChiCuocVo", obj.SoTienChiCuocVo);
                                sqlParameters[13] = new SqlParameter("@SoHoaDon", obj.SoHoaDon);
                                sqlParameters[14] = new SqlParameter("@GhiChu", obj.GhiChu);
                                sqlParameters[15] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                                sqlParameters[16] = new SqlParameter("@CreateDate", DBNull.Value)
                                {
                                    Direction = ParameterDirection.Output,
                                    Size = 8
                                };
                                sqlCommand.Parameters.Clear();
                                sqlCommand.Parameters.AddRange(sqlParameters);
                                int rowAffected = sqlCommand.ExecuteNonQuery();
                                obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                                obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                                if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(ctThanhToanTamUng.tableName), sqlConnection, sqlTransaction))
                                {
                                    sqlTransaction.Rollback();
                                    return false;
                                }
                            }
                            sqlTransaction.Commit();
                            return true;
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
        public bool Update(List<ctThanhToanTamUng> objList)
        {
            try
            {
                SqlParameter[] sqlParameters;
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        foreach (ctThanhToanTamUng obj in objList)
                        {
                            if (obj.DataRowState == DataRowState.Deleted)
                            {
                                SqlCommand sqlCommand = new SqlCommand(ctThanhToanTamUng.deleteProcedureName, sqlConnection, sqlTransaction);
                                sqlCommand.CommandType = CommandType.StoredProcedure;
                                sqlParameters = new SqlParameter[1];
                                sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                                sqlCommand.Parameters.Clear();
                                sqlCommand.Parameters.AddRange(sqlParameters);
                                int rowAffected = sqlCommand.ExecuteNonQuery();
                                if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(ctThanhToanTamUng.tableName), sqlConnection, sqlTransaction))
                                {
                                    sqlTransaction.Rollback();
                                    return false;
                                }
                            }
                            if (obj.DataRowState == DataRowState.Added)
                            {
                                SqlCommand sqlCommand = new SqlCommand(ctThanhToanTamUng.insertProcedureName, sqlConnection, sqlTransaction);
                                sqlCommand.CommandType = CommandType.StoredProcedure;
                                sqlParameters = new SqlParameter[17];
                                sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                                {
                                    Direction = ParameterDirection.Output,
                                    Size = sizeof(Int64)
                                };
                                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                                sqlParameters[3] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                                sqlParameters[4] = new SqlParameter("@IDChungTuChiTiet", obj.IDChungTuChiTiet);
                                sqlParameters[5] = new SqlParameter("@LoaiThanhToanTamUng", obj.LoaiThanhToanTamUng);
                                sqlParameters[6] = new SqlParameter("@IDDanhMucCanBoThanhToanTamUng", obj.IDDanhMucCanBoThanhToanTamUng);
                                sqlParameters[7] = new SqlParameter("@NgayThanhToanTamUng", obj.NgayThanhToanTamUng);
                                sqlParameters[8] = new SqlParameter("@SoTienHoanTamUng", obj.SoTienHoanTamUng);
                                sqlParameters[9] = new SqlParameter("@IDDanhMucChiPhiHaiQuanKinhDoanh", obj.IDDanhMucChiPhiHaiQuanKinhDoanh);
                                sqlParameters[10] = new SqlParameter("@SoTienChiThuTuc", obj.SoTienChiThuTuc);
                                sqlParameters[11] = new SqlParameter("@SoTienChiTraHoCoHoaDon", obj.SoTienChiTraHoCoHoaDon);
                                sqlParameters[12] = new SqlParameter("@SoTienChiCuocVo", obj.SoTienChiCuocVo);
                                sqlParameters[13] = new SqlParameter("@SoHoaDon", obj.SoHoaDon);
                                sqlParameters[14] = new SqlParameter("@GhiChu", obj.GhiChu);
                                sqlParameters[15] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                                sqlParameters[16] = new SqlParameter("@CreateDate", DBNull.Value)
                                {
                                    Direction = ParameterDirection.Output,
                                    Size = 8
                                };
                                sqlCommand.Parameters.Clear();
                                sqlCommand.Parameters.AddRange(sqlParameters);
                                int rowAffected = sqlCommand.ExecuteNonQuery();
                                obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                                obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                                if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(ctThanhToanTamUng.tableName), sqlConnection, sqlTransaction))
                                {
                                    sqlTransaction.Rollback();
                                    return false;
                                }
                            }
                            if (obj.DataRowState == DataRowState.Modified)
                            {
                                SqlCommand sqlCommand = new SqlCommand(ctThanhToanTamUng.updateProcedureName, sqlConnection, sqlTransaction);
                                sqlCommand.CommandType = CommandType.StoredProcedure;
                                sqlParameters = new SqlParameter[17];
                                sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                                sqlParameters[3] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                                sqlParameters[4] = new SqlParameter("@IDChungTuChiTiet", obj.IDChungTuChiTiet);
                                sqlParameters[5] = new SqlParameter("@LoaiThanhToanTamUng", obj.LoaiThanhToanTamUng);
                                sqlParameters[6] = new SqlParameter("@IDDanhMucCanBoThanhToanTamUng", obj.IDDanhMucCanBoThanhToanTamUng);
                                sqlParameters[7] = new SqlParameter("@NgayThanhToanTamUng", obj.NgayThanhToanTamUng);
                                sqlParameters[8] = new SqlParameter("@SoTienHoanTamUng", obj.SoTienHoanTamUng);
                                sqlParameters[9] = new SqlParameter("@IDDanhMucChiPhiHaiQuanKinhDoanh", obj.IDDanhMucChiPhiHaiQuanKinhDoanh);
                                sqlParameters[10] = new SqlParameter("@SoTienChiThuTuc", obj.SoTienChiThuTuc);
                                sqlParameters[11] = new SqlParameter("@SoTienChiTraHoCoHoaDon", obj.SoTienChiTraHoCoHoaDon);
                                sqlParameters[12] = new SqlParameter("@SoTienChiCuocVo", obj.SoTienChiCuocVo);
                                sqlParameters[13] = new SqlParameter("@SoHoaDon", obj.SoHoaDon);
                                sqlParameters[14] = new SqlParameter("@GhiChu", obj.GhiChu);
                                sqlParameters[15] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                                sqlParameters[16] = new SqlParameter("@EditDate", DBNull.Value)
                                {
                                    Direction = ParameterDirection.Output,
                                    Size = 8
                                };
                                sqlCommand.Parameters.Clear();
                                sqlCommand.Parameters.AddRange(sqlParameters);
                                int rowAffected = sqlCommand.ExecuteNonQuery();
                                obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                                obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                                if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(ctThanhToanTamUng.tableName), sqlConnection, sqlTransaction))
                                {
                                    sqlTransaction.Rollback();
                                    return false;
                                }
                            }
                        }
                        sqlTransaction.Commit();
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
        public bool Delete(ctThanhToanTamUng obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctThanhToanTamUng.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(ctThanhToanTamUng.tableName), sqlConnection, sqlTransaction))
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

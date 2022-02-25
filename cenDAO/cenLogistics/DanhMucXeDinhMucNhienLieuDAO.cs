using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class DanhMucXeDinhMucNhienLieuDAO
    {
        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucXeDinhMucNhienLieu.listProcedureName, DanhMucXeDinhMucNhienLieu.tableName);
            return dt;
        }
        public bool Insert(ref DanhMucXeDinhMucNhienLieu obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucXeDinhMucNhienLieu.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[12];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@NgayApDung", obj.NgayApDung);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucXe", obj.IDDanhMucXe);
                            sqlParameters[5] = new SqlParameter("@DinhMucNhienLieuHangNheVo", obj.DinhMucNhienLieuHangNheVo);
                            sqlParameters[6] = new SqlParameter("@DinhMucNhienLieuHangNhe", obj.DinhMucNhienLieuHangNhe);
                            sqlParameters[7] = new SqlParameter("@DinhMucNhienLieuHangNangVo", obj.DinhMucNhienLieuHangNangVo);
                            sqlParameters[8] = new SqlParameter("@DinhMucNhienLieuHangNang", obj.DinhMucNhienLieuHangNang);
                            sqlParameters[9] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[10] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[11] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(DanhMucXeDinhMucNhienLieu.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref DanhMucXeDinhMucNhienLieu obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucXeDinhMucNhienLieu.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[12];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@NgayApDung", obj.NgayApDung);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucXe", obj.IDDanhMucXe);
                            sqlParameters[5] = new SqlParameter("@DinhMucNhienLieuHangNheVo", obj.DinhMucNhienLieuHangNheVo);
                            sqlParameters[6] = new SqlParameter("@DinhMucNhienLieuHangNhe", obj.DinhMucNhienLieuHangNhe);
                            sqlParameters[7] = new SqlParameter("@DinhMucNhienLieuHangNangVo", obj.DinhMucNhienLieuHangNangVo);
                            sqlParameters[8] = new SqlParameter("@DinhMucNhienLieuHangNang", obj.DinhMucNhienLieuHangNang);
                            sqlParameters[9] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[10] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[11] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(DanhMucXeDinhMucNhienLieu.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(DanhMucXeDinhMucNhienLieu obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucXeDinhMucNhienLieu.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(DanhMucXeDinhMucNhienLieu.tableName), sqlConnection, sqlTransaction))
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

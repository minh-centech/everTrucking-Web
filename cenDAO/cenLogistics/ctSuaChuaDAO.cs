using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class ctSuaChuaDAO
    {
        public DataTable List(object ID, object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucXe)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[3] = new SqlParameter("@TuNgay", TuNgay);
            sqlParameters[4] = new SqlParameter("@DenNgay", DenNgay);
            sqlParameters[5] = new SqlParameter("@IDDanhMucXe", IDDanhMucXe);
            DataTable dt = dao.tableList(sqlParameters, ctSuaChua.listProcedureName, ctSuaChua.tableName);
            return dt;
        }
        public bool Insert(ref ctSuaChua obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctSuaChua.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[23];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                            sqlParameters[3] = new SqlParameter("@IDDanhMucChungTuTrangThai", obj.IDDanhMucChungTuTrangThai);
                            sqlParameters[4] = new SqlParameter("@So", obj.So)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 35
                            };
                            sqlParameters[5] = new SqlParameter("@NgayLap", obj.NgayLap);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucXe", obj.IDDanhMucXe);
                            sqlParameters[7] = new SqlParameter("@NgaySuaChua", obj.NgaySuaChua);
                            sqlParameters[8] = new SqlParameter("@NoiDungSuaChua", obj.NoiDungSuaChua);
                            sqlParameters[9] = new SqlParameter("@NoiSuaChua", obj.NoiSuaChua);
                            sqlParameters[10] = new SqlParameter("@SoKmDongHo", obj.SoKmDongHo);
                            sqlParameters[11] = new SqlParameter("@DonViTinh", obj.DonViTinh);
                            sqlParameters[12] = new SqlParameter("@SoLuong", obj.SoLuong);
                            sqlParameters[13] = new SqlParameter("@DonGiaNhanCong", obj.DonGiaNhanCong);
                            sqlParameters[14] = new SqlParameter("@SoTienNhanCong", obj.SoTienNhanCong);
                            sqlParameters[15] = new SqlParameter("@DonGiaVatTu", obj.DonGiaVatTu);
                            sqlParameters[16] = new SqlParameter("@SoTienVatTu", obj.SoTienVatTu);
                            sqlParameters[17] = new SqlParameter("@SoTien", obj.SoTien);
                            sqlParameters[18] = new SqlParameter("@ThoiGianBaoHanh", obj.ThoiGianBaoHanh);
                            sqlParameters[19] = new SqlParameter("@NguoiSuaChua", obj.NguoiSuaChua);
                            sqlParameters[20] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[21] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[22] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.So = Int64.Parse(sqlParameters[4].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(ctSuaChua.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref ctSuaChua obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctSuaChua.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[21];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                            sqlParameters[3] = new SqlParameter("@IDDanhMucChungTuTrangThai", obj.IDDanhMucChungTuTrangThai);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucXe", obj.IDDanhMucXe);
                            sqlParameters[5] = new SqlParameter("@NgaySuaChua", obj.NgaySuaChua);
                            sqlParameters[6] = new SqlParameter("@NoiDungSuaChua", obj.NoiDungSuaChua);
                            sqlParameters[7] = new SqlParameter("@NoiSuaChua", obj.NoiSuaChua);
                            sqlParameters[8] = new SqlParameter("@SoKmDongHo", obj.SoKmDongHo);
                            sqlParameters[9] = new SqlParameter("@DonViTinh", obj.DonViTinh);
                            sqlParameters[10] = new SqlParameter("@SoLuong", obj.SoLuong);
                            sqlParameters[11] = new SqlParameter("@DonGiaNhanCong", obj.DonGiaNhanCong);
                            sqlParameters[12] = new SqlParameter("@SoTienNhanCong", obj.SoTienNhanCong);
                            sqlParameters[13] = new SqlParameter("@DonGiaVatTu", obj.DonGiaVatTu);
                            sqlParameters[14] = new SqlParameter("@SoTienVatTu", obj.SoTienVatTu);
                            sqlParameters[15] = new SqlParameter("@SoTien", obj.SoTien);
                            sqlParameters[16] = new SqlParameter("@ThoiGianBaoHanh", obj.ThoiGianBaoHanh);
                            sqlParameters[17] = new SqlParameter("@NguoiSuaChua", obj.NguoiSuaChua);
                            sqlParameters[18] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[19] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[20] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(ctSuaChua.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(ctSuaChua obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctSuaChua.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(ctSuaChua.tableName), sqlConnection, sqlTransaction))
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

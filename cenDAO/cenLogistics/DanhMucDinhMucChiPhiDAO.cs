using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class DanhMucDinhMucChiPhiDAO
    {
        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucDinhMucChiPhi.listProcedureName, DanhMucDinhMucChiPhi.tableName);
            return dt;
        }
        public bool Insert(ref DanhMucDinhMucChiPhi obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucDinhMucChiPhi.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[15];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@NgayApDung", obj.NgayApDung);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucTuyenVanTai", obj.IDDanhMucTuyenVanTai);
                            sqlParameters[5] = new SqlParameter("@SoTienVeCauDuong", obj.SoTienVeCauDuong);
                            sqlParameters[6] = new SqlParameter("@SoTienLuatAnCa", obj.SoTienLuatAnCa);
                            sqlParameters[7] = new SqlParameter("@SoTienLuuCaKhac", obj.SoTienLuuCaKhac);
                            sqlParameters[8] = new SqlParameter("@SoTienLuatDuongCam", obj.SoTienLuatDuongCam);
                            sqlParameters[9] = new SqlParameter("@SoTienLuongChuyen", obj.SoTienLuongChuyen);
                            sqlParameters[10] = new SqlParameter("@SoTramLuat", obj.SoTramLuat);
                            sqlParameters[11] = new SqlParameter("@SoTramVe", obj.SoTramVe);
                            sqlParameters[12] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[13] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[14] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(DanhMucDinhMucChiPhi.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref DanhMucDinhMucChiPhi obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucDinhMucChiPhi.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[15];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@NgayApDung", obj.NgayApDung);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucTuyenVanTai", obj.IDDanhMucTuyenVanTai);
                            sqlParameters[5] = new SqlParameter("@SoTienVeCauDuong", obj.SoTienVeCauDuong);
                            sqlParameters[6] = new SqlParameter("@SoTienLuatAnCa", obj.SoTienLuatAnCa);
                            sqlParameters[7] = new SqlParameter("@SoTienLuuCaKhac", obj.SoTienLuuCaKhac);
                            sqlParameters[8] = new SqlParameter("@SoTienLuatDuongCam", obj.SoTienLuatDuongCam);
                            sqlParameters[9] = new SqlParameter("@SoTienLuongChuyen", obj.SoTienLuongChuyen);
                            sqlParameters[10] = new SqlParameter("@SoTramLuat", obj.SoTramLuat);
                            sqlParameters[11] = new SqlParameter("@SoTramVe", obj.SoTramVe);
                            sqlParameters[12] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[13] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[14] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(DanhMucDinhMucChiPhi.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(DanhMucDinhMucChiPhi obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucDinhMucChiPhi.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(DanhMucDinhMucChiPhi.tableName), sqlConnection, sqlTransaction))
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

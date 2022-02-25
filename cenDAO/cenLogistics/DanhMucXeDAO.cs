using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class DanhMucXeDAO
    {
        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucThauPhu, object IDDanhMucNhomHangVanChuyen, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@IDDanhMucThauPhu", IDDanhMucThauPhu);
            sqlParameters[4] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", IDDanhMucNhomHangVanChuyen);
            sqlParameters[5] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucXe.listProcedureName, DanhMucXe.tableName);
            return dt;
        }
        public DataTable ListHinhAnh(object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = dao.tableList(sqlParameters, DanhMucXe.listHinhAnhProcedureName, DanhMucXe.tableName);
            return dt;
        }
        public bool Insert(ref DanhMucXe obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucXe.insertProcedureName, sqlConnection, sqlTransaction))
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
                            sqlParameters[3] = new SqlParameter("@BienSo", obj.BienSo);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucNhomXe", obj.IDDanhMucNhomXe);
                            sqlParameters[5] = new SqlParameter("@IDDanhMucNhienLieu", obj.IDDanhMucNhienLieu);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucThauPhu", obj.IDDanhMucThauPhu);
                            sqlParameters[7] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", obj.IDDanhMucNhomHangVanChuyen);
                            sqlParameters[8] = new SqlParameter("@MaTaiKhoanDoanhThu", obj.MaTaiKhoanDoanhThu);
                            sqlParameters[9] = new SqlParameter("@MaTaiKhoanChietKhau", obj.MaTaiKhoanChietKhau);
                            sqlParameters[10] = new SqlParameter("@HinhAnhMatTruoc", obj.HinhAnhMatTruoc);
                            sqlParameters[11] = new SqlParameter("@HinhAnhNgang", obj.HinhAnhNgang);
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
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(DanhMucXe.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref DanhMucXe obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucXe.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[15];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@BienSo", obj.BienSo);
                            sqlParameters[4] = new SqlParameter("@IDDanhMucNhomXe", obj.IDDanhMucNhomXe);
                            sqlParameters[5] = new SqlParameter("@IDDanhMucNhienLieu", obj.IDDanhMucNhienLieu);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucThauPhu", obj.IDDanhMucThauPhu);
                            sqlParameters[7] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", obj.IDDanhMucNhomHangVanChuyen);
                            sqlParameters[8] = new SqlParameter("@MaTaiKhoanDoanhThu", obj.MaTaiKhoanDoanhThu);
                            sqlParameters[9] = new SqlParameter("@MaTaiKhoanChietKhau", obj.MaTaiKhoanChietKhau);
                            sqlParameters[10] = new SqlParameter("@HinhAnhMatTruoc", obj.HinhAnhMatTruoc);
                            sqlParameters[11] = new SqlParameter("@HinhAnhNgang", obj.HinhAnhNgang);
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
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(DanhMucXe.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(DanhMucXe obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucXe.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(DanhMucXe.tableName), sqlConnection, sqlTransaction))
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

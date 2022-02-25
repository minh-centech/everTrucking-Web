using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class ctInGiayVanTaiDAO
    {
        public DataTable List(object ID, object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucChuXe)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@ID", ID);
            sqlParameters[3] = new SqlParameter("@TuNgay", TuNgay);
            sqlParameters[4] = new SqlParameter("@DenNgay", DenNgay);
            sqlParameters[5] = new SqlParameter("@IDDanhMucChuXe", IDDanhMucChuXe);
            DataTable dt = dao.tableList(sqlParameters, ctInGiayVanTai.listProcedureName, ctInGiayVanTai.tableName);
            return dt;
        }
        public bool Insert(ref ctInGiayVanTai obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctInGiayVanTai.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[16];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                            sqlParameters[3] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                            sqlParameters[4] = new SqlParameter("@LoaiDonChuyen", obj.LoaiDonChuyen);
                            sqlParameters[5] = new SqlParameter("@SoKmVoHangNhe", obj.SoKmVoHangNhe);
                            sqlParameters[6] = new SqlParameter("@SoKmHangNhe", obj.SoKmHangNhe);
                            sqlParameters[7] = new SqlParameter("@SoKmVoHangNang", obj.SoKmVoHangNang);
                            sqlParameters[8] = new SqlParameter("@SoKmHangNang", obj.SoKmHangNang);
                            sqlParameters[9] = new SqlParameter("@SoLuongNhienLieuDinhMuc", obj.SoLuongNhienLieuDinhMuc);
                            sqlParameters[10] = new SqlParameter("@SoLuongNhienLieuCapThem", obj.SoLuongNhienLieuCapThem);
                            sqlParameters[11] = new SqlParameter("@SoTienVeCauDuong", obj.SoTienVeCauDuong);
                            sqlParameters[12] = new SqlParameter("@SoTienLuatAnCa", obj.SoTienLuatAnCa);
                            sqlParameters[13] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[14] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[15] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(ctInGiayVanTai.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref ctInGiayVanTai obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctInGiayVanTai.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[16];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                            sqlParameters[3] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                            sqlParameters[4] = new SqlParameter("@LoaiDonChuyen", obj.LoaiDonChuyen);
                            sqlParameters[5] = new SqlParameter("@SoKmVoHangNhe", obj.SoKmVoHangNhe);
                            sqlParameters[6] = new SqlParameter("@SoKmHangNhe", obj.SoKmHangNhe);
                            sqlParameters[7] = new SqlParameter("@SoKmVoHangNang", obj.SoKmVoHangNang);
                            sqlParameters[8] = new SqlParameter("@SoKmHangNang", obj.SoKmHangNang);
                            sqlParameters[9] = new SqlParameter("@SoLuongNhienLieuDinhMuc", obj.SoLuongNhienLieuDinhMuc);
                            sqlParameters[10] = new SqlParameter("@SoLuongNhienLieuCapThem", obj.SoLuongNhienLieuCapThem);
                            sqlParameters[11] = new SqlParameter("@SoTienVeCauDuong", obj.SoTienVeCauDuong);
                            sqlParameters[12] = new SqlParameter("@SoTienLuatAnCa", obj.SoTienLuatAnCa);
                            sqlParameters[13] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[14] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[15] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(ctInGiayVanTai.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(ctInGiayVanTai obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctInGiayVanTai.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(ctInGiayVanTai.tableName), sqlConnection, sqlTransaction))
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

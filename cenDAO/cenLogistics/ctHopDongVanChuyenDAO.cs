using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class ctHopDongVanChuyenDAO
    {
        public DataTable List(object ID, object IDDanhMucChungTu, object TuNgay, object DenNgay)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[3] = new SqlParameter("@TuNgay", TuNgay);
            sqlParameters[4] = new SqlParameter("@DenNgay", DenNgay);
            DataTable dt = dao.tableList(sqlParameters, ctHopDongVanChuyen.listProcedureName, ctHopDongVanChuyen.tableName);
            return dt;
        }
        public DataTable ListFileContent(object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            DataTable dt = dao.tableList(sqlParameters, ctHopDongVanChuyen.listFileContentProcedureName, ctHopDongVanChuyen.tableName);
            return dt;
        }
        public bool Insert(ref ctHopDongVanChuyen obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctHopDongVanChuyen.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[19];
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
                            sqlParameters[6] = new SqlParameter("@SoHopDong", obj.SoHopDong);
                            sqlParameters[7] = new SqlParameter("@NgayHopDong", obj.NgayHopDong);
                            sqlParameters[8] = new SqlParameter("@NgayCoHieuLuc", obj.NgayCoHieuLuc);
                            sqlParameters[9] = new SqlParameter("@NgayHetHieuLuc", obj.NgayHetHieuLuc);
                            sqlParameters[10] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                            sqlParameters[11] = new SqlParameter("@NoiDung", obj.NoiDung);
                            sqlParameters[12] = new SqlParameter("@SoTien", obj.SoTien);
                            sqlParameters[13] = new SqlParameter("@TrangThaiHopDong", obj.TrangThaiHopDong);
                            sqlParameters[14] = new SqlParameter("@FileName", obj.FileName);
                            sqlParameters[15] = new SqlParameter("@FileContent", obj.FileContent);
                            sqlParameters[16] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[17] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[18] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.So = Int64.Parse(sqlParameters[4].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(ctHopDongVanChuyen.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref ctHopDongVanChuyen obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctHopDongVanChuyen.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[17];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                            sqlParameters[3] = new SqlParameter("@IDDanhMucChungTuTrangThai", obj.IDDanhMucChungTuTrangThai);
                            sqlParameters[4] = new SqlParameter("@SoHopDong", obj.SoHopDong);
                            sqlParameters[5] = new SqlParameter("@NgayHopDong", obj.NgayHopDong);
                            sqlParameters[6] = new SqlParameter("@NgayCoHieuLuc", obj.NgayCoHieuLuc);
                            sqlParameters[7] = new SqlParameter("@NgayHetHieuLuc", obj.NgayHetHieuLuc);
                            sqlParameters[8] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                            sqlParameters[9] = new SqlParameter("@NoiDung", obj.NoiDung);
                            sqlParameters[10] = new SqlParameter("@SoTien", obj.SoTien);
                            sqlParameters[11] = new SqlParameter("@TrangThaiHopDong", obj.TrangThaiHopDong);
                            sqlParameters[12] = new SqlParameter("@FileName", obj.FileName);
                            sqlParameters[13] = new SqlParameter("@FileContent", obj.FileContent);
                            sqlParameters[14] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[15] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[16] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(ctHopDongVanChuyen.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(ctHopDongVanChuyen obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctHopDongVanChuyen.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(ctHopDongVanChuyen.tableName), sqlConnection, sqlTransaction))
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
        public DataTable ValidSoHopDong(object SoHopDong)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@SoHopDong", SoHopDong);
            DataTable dt = dao.tableList(sqlParameters, ctHopDongVanChuyen.validSoHopDongProcedureName, ctHopDongVanChuyen.tableName);
            return dt;
        }
    }
}

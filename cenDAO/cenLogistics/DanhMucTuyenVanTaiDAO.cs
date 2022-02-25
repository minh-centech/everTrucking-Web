using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class DanhMucTuyenVanTaiDAO
    {
        public DataSet List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@SearchStr", SearchStr);
            DataSet ds = dao.dsList(sqlParameters, DanhMucTuyenVanTai.listProcedureName);
            if (ds != null)
            {
                ds.Tables[0].TableName = DanhMucTuyenVanTai.tableName;
                ds.Tables[1].TableName = DanhMucTuyenVanTaiDinhMucNhienLieu.tableName;
                ds.Tables[2].TableName = DanhMucTuyenVanTaiDinhMucChiPhi.tableName;
                ds.Relations.Add(cenCommon.GlobalVariables.prefix_DataRelation + DanhMucTuyenVanTaiDinhMucNhienLieu.tableName, ds.Tables[DanhMucTuyenVanTai.tableName].Columns["ID"], ds.Tables[DanhMucTuyenVanTaiDinhMucNhienLieu.tableName].Columns["IDDanhMucTuyenVanTai"]);
                ds.Relations.Add(cenCommon.GlobalVariables.prefix_DataRelation + DanhMucTuyenVanTaiDinhMucChiPhi.tableName, ds.Tables[DanhMucTuyenVanTai.tableName].Columns["ID"], ds.Tables[DanhMucTuyenVanTaiDinhMucChiPhi.tableName].Columns["IDDanhMucTuyenVanTai"]);
            }
            return ds;
        }
        public bool Insert(ref DanhMucTuyenVanTai obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTuyenVanTai.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[13];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[4] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[5] = new SqlParameter("@DiemDau", obj.DiemDau);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucTinhThanhDau", obj.IDDanhMucTinhThanhDau);
                            sqlParameters[7] = new SqlParameter("@DiemCuoi", obj.DiemCuoi);
                            sqlParameters[8] = new SqlParameter("@IDDanhMucTinhThanhCuoi", obj.IDDanhMucTinhThanhCuoi);
                            sqlParameters[9] = new SqlParameter("@CuLy", obj.CuLy);
                            sqlParameters[10] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[11] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[12] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(DanhMucTuyenVanTai.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref DanhMucTuyenVanTai obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTuyenVanTai.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[13];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[4] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[5] = new SqlParameter("@DiemDau", obj.DiemDau);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucTinhThanhDau", obj.IDDanhMucTinhThanhDau);
                            sqlParameters[7] = new SqlParameter("@DiemCuoi", obj.DiemCuoi);
                            sqlParameters[8] = new SqlParameter("@IDDanhMucTinhThanhCuoi", obj.IDDanhMucTinhThanhCuoi);
                            sqlParameters[9] = new SqlParameter("@CuLy", obj.CuLy);
                            sqlParameters[10] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[11] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[12] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(DanhMucTuyenVanTai.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(DanhMucTuyenVanTai obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTuyenVanTai.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(DanhMucTuyenVanTai.tableName), sqlConnection, sqlTransaction))
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
        public DataTable Valid(object ID, object IDDanhMucLoaiDoiTuong)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            DataTable dt = dao.tableList(sqlParameters, DanhMucTuyenVanTai.validProcedureName, DanhMucTuyenVanTai.validProcedureName);
            return dt;
        }

    }
    public class DanhMucTuyenVanTaiDinhMucNhienLieuDAO
    {
        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucTuyenVanTaiDinhMucNhienLieu.listProcedureName, DanhMucTuyenVanTaiDinhMucNhienLieu.tableName);
            return dt;
        }
        public bool Insert(ref DanhMucTuyenVanTaiDinhMucNhienLieu obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTuyenVanTaiDinhMucNhienLieu.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[13];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@IDDanhMucTuyenVanTai", obj.IDDanhMucTuyenVanTai);
                            sqlParameters[4] = new SqlParameter("@NgayApDung", obj.NgayApDung);
                            sqlParameters[5] = new SqlParameter("@IDDanhMucNhomXe", obj.IDDanhMucNhomXe);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucNhienLieu", obj.IDDanhMucNhienLieu);
                            sqlParameters[7] = new SqlParameter("@TaiTrongDau", obj.TaiTrongDau);
                            sqlParameters[8] = new SqlParameter("@TaiTrongCuoi", obj.TaiTrongCuoi);
                            sqlParameters[9] = new SqlParameter("@DinhMucNhienLieu1km", obj.DinhMucNhienLieu1km);
                            sqlParameters[10] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[11] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[12] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(DanhMucTuyenVanTaiDinhMucNhienLieu.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref DanhMucTuyenVanTaiDinhMucNhienLieu obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTuyenVanTaiDinhMucNhienLieu.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[13];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@IDDanhMucTuyenVanTai", obj.IDDanhMucTuyenVanTai);
                            sqlParameters[4] = new SqlParameter("@NgayApDung", obj.NgayApDung);
                            sqlParameters[5] = new SqlParameter("@IDDanhMucNhomXe", obj.IDDanhMucNhomXe);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucNhienLieu", obj.IDDanhMucNhienLieu);
                            sqlParameters[7] = new SqlParameter("@TaiTrongDau", obj.TaiTrongDau);
                            sqlParameters[8] = new SqlParameter("@TaiTrongCuoi", obj.TaiTrongCuoi);
                            sqlParameters[9] = new SqlParameter("@DinhMucNhienLieu1km", obj.DinhMucNhienLieu1km);
                            sqlParameters[10] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[11] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[12] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(DanhMucTuyenVanTaiDinhMucNhienLieu.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(DanhMucTuyenVanTaiDinhMucNhienLieu obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTuyenVanTaiDinhMucNhienLieu.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(DanhMucTuyenVanTaiDinhMucNhienLieu.tableName), sqlConnection, sqlTransaction))
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
    public class DanhMucTuyenVanTaiDinhMucChiPhiDAO
    {
        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucTuyenVanTaiDinhMucChiPhi.listProcedureName, DanhMucTuyenVanTaiDinhMucChiPhi.tableName);
            return dt;
        }
        public bool Insert(ref DanhMucTuyenVanTaiDinhMucChiPhi obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTuyenVanTaiDinhMucChiPhi.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[13];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@IDDanhMucTuyenVanTai", obj.IDDanhMucTuyenVanTai);
                            sqlParameters[4] = new SqlParameter("@ChieuVanTai", obj.ChieuVanTai);
                            sqlParameters[5] = new SqlParameter("@NgayApDung", obj.NgayApDung);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucNhomXe", obj.IDDanhMucNhomXe);
                            sqlParameters[7] = new SqlParameter("@IDDanhMucChiPhiDieuVanThuongXuyen", obj.IDDanhMucChiPhiDieuVanThuongXuyen);
                            sqlParameters[8] = new SqlParameter("@SoLuong", obj.SoLuong);
                            sqlParameters[9] = new SqlParameter("@SoTien", obj.SoTien);
                            sqlParameters[10] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[11] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[12] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(DanhMucTuyenVanTaiDinhMucChiPhi.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref DanhMucTuyenVanTaiDinhMucChiPhi obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTuyenVanTaiDinhMucChiPhi.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[13];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@IDDanhMucTuyenVanTai", obj.IDDanhMucTuyenVanTai);
                            sqlParameters[4] = new SqlParameter("@ChieuVanTai", obj.ChieuVanTai);
                            sqlParameters[5] = new SqlParameter("@NgayApDung", obj.NgayApDung);
                            sqlParameters[6] = new SqlParameter("@IDDanhMucNhomXe", obj.IDDanhMucNhomXe);
                            sqlParameters[7] = new SqlParameter("@IDDanhMucChiPhiDieuVanThuongXuyen", obj.IDDanhMucChiPhiDieuVanThuongXuyen);
                            sqlParameters[8] = new SqlParameter("@SoLuong", obj.SoLuong);
                            sqlParameters[9] = new SqlParameter("@SoTien", obj.SoTien);
                            sqlParameters[10] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[11] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[12] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(DanhMucTuyenVanTaiDinhMucChiPhi.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(DanhMucTuyenVanTaiDinhMucChiPhi obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucTuyenVanTaiDinhMucChiPhi.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(DanhMucTuyenVanTaiDinhMucChiPhi.tableName), sqlConnection, sqlTransaction))
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

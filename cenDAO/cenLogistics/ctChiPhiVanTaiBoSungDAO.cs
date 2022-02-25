using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace cenDAO.cenLogistics
{
    public class ctChiPhiVanTaiBoSungDAO
    {
        public DataSet List(object IDDanhMucChungTu, object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@ID", ID);
            DataSet ds = dao.dsList(sqlParameters, ctChiPhiVanTaiBoSung.listProcedureName);
            if (ds != null)
            {
                ds.Tables[0].TableName = ctDonHang.tableName;
                ds.Tables[1].TableName = ctChiPhiVanTaiBoSung.tableName;
                ds.Relations.Add(cenCommon.GlobalVariables.prefix_DataRelation + ctChiPhiVanTaiBoSung.tableName, ds.Tables[ctDonHang.tableName].Columns["ID"], ds.Tables[ctChiPhiVanTaiBoSung.tableName].Columns["IDChungTu"]);
            }
            return ds;
        }
        public DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object ID, object IDDanhMucNhomHangVanChuyen)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@TuNgay", TuNgay);
            sqlParameters[3] = new SqlParameter("@DenNgay", DenNgay);
            sqlParameters[4] = new SqlParameter("@ID", ID);
            sqlParameters[5] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", IDDanhMucNhomHangVanChuyen);
            DataTable dt = dao.tableList(sqlParameters, ctChiPhiVanTaiBoSung.listDisplayProcedureName, ctChiPhiVanTaiBoSung.listProcedureName);
            return dt;
        }
        public bool Insert(List<ctChiPhiVanTaiBoSung> objList)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctChiPhiVanTaiBoSung.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            foreach (ctChiPhiVanTaiBoSung obj in objList)
                            {
                                SqlParameter[] sqlParameters = new SqlParameter[18];
                                sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                                {
                                    Direction = ParameterDirection.Output,
                                    Size = sizeof(Int64)
                                };
                                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                                sqlParameters[3] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                                sqlParameters[4] = new SqlParameter("@SoLuongNhienLieu", obj.SoLuongNhienLieu);
                                sqlParameters[5] = new SqlParameter("@SoTienVeCauDuong", obj.SoTienVeCauDuong);
                                sqlParameters[6] = new SqlParameter("@SoTienLuatAnCa", obj.SoTienLuatAnCa);
                                sqlParameters[7] = new SqlParameter("@SoTienKetHopVeCauDuongLuatAnCa", obj.SoTienKetHopVeCauDuongLuatAnCa);
                                sqlParameters[8] = new SqlParameter("@SoTienLuuCaKhac", obj.SoTienLuuCaKhac);
                                sqlParameters[9] = new SqlParameter("@SoTienLuatDuongCam", obj.SoTienLuatDuongCam);
                                sqlParameters[10] = new SqlParameter("@SoTienTongLuuCaKhacLuatDuongCam", obj.SoTienTongLuuCaKhacLuatDuongCam);
                                sqlParameters[11] = new SqlParameter("@SoTienLuongChuyen", obj.SoTienLuongChuyen);
                                sqlParameters[12] = new SqlParameter("@SoTienLuongChuNhat", obj.SoTienLuongChuNhat);
                                sqlParameters[13] = new SqlParameter("@SoTienCuocThueXeNgoai", obj.SoTienCuocThueXeNgoai);
                                sqlParameters[14] = new SqlParameter("@NgayBoSung", obj.NgayBoSung);
                                sqlParameters[15] = new SqlParameter("@GhiChu", obj.GhiChu);
                                sqlParameters[16] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                                sqlParameters[17] = new SqlParameter("@CreateDate", DBNull.Value)
                                {
                                    Direction = ParameterDirection.Output,
                                    Size = 8
                                };
                                sqlCommand.Parameters.Clear();
                                sqlCommand.Parameters.AddRange(sqlParameters);
                                int rowAffected = sqlCommand.ExecuteNonQuery();
                                obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                                obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                                if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(ctChiPhiVanTaiBoSung.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(List<ctChiPhiVanTaiBoSung> objList)
        {
            try
            {
                SqlParameter[] sqlParameters;
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        foreach (ctChiPhiVanTaiBoSung obj in objList)
                        {
                            if (obj.DataRowState == DataRowState.Deleted)
                            {
                                SqlCommand sqlCommand = new SqlCommand(ctChiPhiVanTaiBoSung.deleteProcedureName, sqlConnection, sqlTransaction);
                                sqlCommand.CommandType = CommandType.StoredProcedure;
                                sqlParameters = new SqlParameter[1];
                                sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                                sqlCommand.Parameters.AddRange(sqlParameters);
                                int rowAffected = sqlCommand.ExecuteNonQuery();
                                if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(ctChiPhiVanTaiBoSung.tableName), sqlConnection, sqlTransaction))
                                {
                                    sqlTransaction.Rollback();
                                    return false;
                                }
                            }
                            if (obj.DataRowState == DataRowState.Added)
                            {
                                SqlCommand sqlCommand = new SqlCommand(ctChiPhiVanTaiBoSung.insertProcedureName, sqlConnection, sqlTransaction);
                                sqlCommand.CommandType = CommandType.StoredProcedure;
                                sqlParameters = new SqlParameter[18];
                                sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                                {
                                    Direction = ParameterDirection.Output,
                                    Size = sizeof(Int64)
                                };
                                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                                sqlParameters[3] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                                sqlParameters[4] = new SqlParameter("@SoLuongNhienLieu", obj.SoLuongNhienLieu);
                                sqlParameters[5] = new SqlParameter("@SoTienVeCauDuong", obj.SoTienVeCauDuong);
                                sqlParameters[6] = new SqlParameter("@SoTienLuatAnCa", obj.SoTienLuatAnCa);
                                sqlParameters[7] = new SqlParameter("@SoTienKetHopVeCauDuongLuatAnCa", obj.SoTienKetHopVeCauDuongLuatAnCa);
                                sqlParameters[8] = new SqlParameter("@SoTienLuuCaKhac", obj.SoTienLuuCaKhac);
                                sqlParameters[9] = new SqlParameter("@SoTienLuatDuongCam", obj.SoTienLuatDuongCam);
                                sqlParameters[10] = new SqlParameter("@SoTienTongLuuCaKhacLuatDuongCam", obj.SoTienTongLuuCaKhacLuatDuongCam);
                                sqlParameters[11] = new SqlParameter("@SoTienLuongChuyen", obj.SoTienLuongChuyen);
                                sqlParameters[12] = new SqlParameter("@SoTienLuongChuNhat", obj.SoTienLuongChuNhat);
                                sqlParameters[13] = new SqlParameter("@SoTienCuocThueXeNgoai", obj.SoTienCuocThueXeNgoai);
                                sqlParameters[14] = new SqlParameter("@NgayBoSung", obj.NgayBoSung);
                                sqlParameters[15] = new SqlParameter("@GhiChu", obj.GhiChu);
                                sqlParameters[16] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                                sqlParameters[17] = new SqlParameter("@CreateDate", DBNull.Value)
                                {
                                    Direction = ParameterDirection.Output,
                                    Size = 8
                                };
                                sqlCommand.Parameters.AddRange(sqlParameters);
                                int rowAffected = sqlCommand.ExecuteNonQuery();
                                obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                                obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                                if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(ctChiPhiVanTaiBoSung.tableName), sqlConnection, sqlTransaction))
                                {
                                    sqlTransaction.Rollback();
                                    return false;
                                }
                            }
                            if (obj.DataRowState == DataRowState.Modified)
                            {
                                SqlCommand sqlCommand = new SqlCommand(ctChiPhiVanTaiBoSung.updateProcedureName, sqlConnection, sqlTransaction);
                                sqlCommand.CommandType = CommandType.StoredProcedure;
                                sqlParameters = new SqlParameter[18];
                                sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                                sqlParameters[3] = new SqlParameter("@IDChungTu", obj.IDChungTu);
                                sqlParameters[4] = new SqlParameter("@SoLuongNhienLieu", obj.SoLuongNhienLieu);
                                sqlParameters[5] = new SqlParameter("@SoTienVeCauDuong", obj.SoTienVeCauDuong);
                                sqlParameters[6] = new SqlParameter("@SoTienLuatAnCa", obj.SoTienLuatAnCa);
                                sqlParameters[7] = new SqlParameter("@SoTienKetHopVeCauDuongLuatAnCa", obj.SoTienKetHopVeCauDuongLuatAnCa);
                                sqlParameters[8] = new SqlParameter("@SoTienLuuCaKhac", obj.SoTienLuuCaKhac);
                                sqlParameters[9] = new SqlParameter("@SoTienLuatDuongCam", obj.SoTienLuatDuongCam);
                                sqlParameters[10] = new SqlParameter("@SoTienTongLuuCaKhacLuatDuongCam", obj.SoTienTongLuuCaKhacLuatDuongCam);
                                sqlParameters[11] = new SqlParameter("@SoTienLuongChuyen", obj.SoTienLuongChuyen);
                                sqlParameters[12] = new SqlParameter("@SoTienLuongChuNhat", obj.SoTienLuongChuNhat);
                                sqlParameters[13] = new SqlParameter("@SoTienCuocThueXeNgoai", obj.SoTienCuocThueXeNgoai);
                                sqlParameters[14] = new SqlParameter("@NgayBoSung", obj.NgayBoSung);
                                sqlParameters[15] = new SqlParameter("@GhiChu", obj.GhiChu);
                                sqlParameters[16] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                                sqlParameters[17] = new SqlParameter("@EditDate", DBNull.Value)
                                {
                                    Direction = ParameterDirection.Output,
                                    Size = 8
                                };
                                sqlCommand.Parameters.AddRange(sqlParameters);
                                int rowAffected = sqlCommand.ExecuteNonQuery();
                                obj.ID = Int64.Parse(sqlParameters[0].Value.ToString());
                                obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                                if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, obj.ID, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(ctChiPhiVanTaiBoSung.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(ctChiPhiVanTaiBoSung obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctChiPhiVanTaiBoSung.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(ctChiPhiVanTaiBoSung.tableName), sqlConnection, sqlTransaction))
                            {
                                sqlTransaction.Rollback();
                                return false;
                            }
                            else
                            {
                                sqlTransaction.Commit();
                                return true;
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

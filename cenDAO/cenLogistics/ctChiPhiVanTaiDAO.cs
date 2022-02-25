using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;

namespace cenDAO.cenLogistics
{
    public class ctChiPhiVanTaiDAO
    {
        public DataTable List(object IDDanhMucChungTu, object ID)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[3];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@ID", ID);
            DataTable dt = dao.tableList(sqlParameters, ctChiPhiVanTai.listProcedureName, ctChiPhiVanTai.listProcedureName);
            return dt;
        }
        public DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucNhomHangVanChuyen)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
            sqlParameters[2] = new SqlParameter("@TuNgay", TuNgay);
            sqlParameters[3] = new SqlParameter("@DenNgay", DenNgay);
            sqlParameters[4] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", IDDanhMucNhomHangVanChuyen);
            DataTable dt = dao.tableList(sqlParameters, ctChiPhiVanTai.listDisplayProcedureName, ctChiPhiVanTai.listProcedureName);
            return dt;
        }
        public DataTable ListValidSoDonHang(object SoDonHang)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@So", SoDonHang);
            DataTable dt = dao.tableList(sqlParameters, ctChiPhiVanTai.listSoDonHangProcedureName, ctChiPhiVanTai.listProcedureName);
            return dt;
        }
        public bool Insert(ref ctChiPhiVanTai obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctChiPhiVanTai.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[19];
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
                            sqlParameters[14] = new SqlParameter("@IDDanhMucCanBoTamUng", obj.IDDanhMucCanBoTamUng);
                            sqlParameters[15] = new SqlParameter("@ThoiHanThanhToan", obj.ThoiHanThanhToan);
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
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.IDChungTu, obj.ID, null, cenCommon.ThaoTacDuLieu.Them, cenCommon.cenCommon.TraTuDien(ctChiPhiVanTai.tableName), sqlConnection, sqlTransaction))
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
        public bool Update(ref ctChiPhiVanTai obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctChiPhiVanTai.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[19];
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
                            sqlParameters[14] = new SqlParameter("@IDDanhMucCanBoTamUng", obj.IDDanhMucCanBoTamUng);
                            sqlParameters[15] = new SqlParameter("@ThoiHanThanhToan", obj.ThoiHanThanhToan);
                            sqlParameters[16] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[17] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                            sqlParameters[18] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.EditDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
                            if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.IDChungTu, obj.ID, null, cenCommon.ThaoTacDuLieu.Sua, cenCommon.cenCommon.TraTuDien(ctChiPhiVanTai.tableName), sqlConnection, sqlTransaction))
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
        public bool Delete(ctChiPhiVanTai obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctChiPhiVanTai.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            if (!NhatKyDuLieuDAO.Insert(cenCommon.cenCommon.AllPropertiesAndValues(obj), obj.ID, null, null, cenCommon.ThaoTacDuLieu.Xoa, cenCommon.cenCommon.TraTuDien(ctChiPhiVanTai.tableName), sqlConnection, sqlTransaction))
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

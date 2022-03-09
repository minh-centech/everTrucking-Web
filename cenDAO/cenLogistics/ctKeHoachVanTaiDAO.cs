using cenDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO
{
    public class ctKeHoachVanTaiDAO
    {
        public DataTable List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ConnectionDAO dao = new ConnectionDAO();
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
                sqlParameters[2] = new SqlParameter("@ID", ID);
                DataTable dt = dao.tableList(sqlParameters, ctKeHoachVanTai.listProcedureName, ctKeHoachVanTai.listProcedureName);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

     
        public DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucKhachHang, object LoaiHinh, object LoaiHang, object ID)
        {
            try
            {
                ConnectionDAO dao = new ConnectionDAO();
                SqlParameter[] sqlParameters = new SqlParameter[8];
                sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
                sqlParameters[2] = new SqlParameter("@TuNgay", TuNgay);
                sqlParameters[3] = new SqlParameter("@DenNgay", DenNgay);
                sqlParameters[4] = new SqlParameter("@IDDanhMucKhachHang", IDDanhMucKhachHang);
                sqlParameters[5] = new SqlParameter("@LoaiHinh", LoaiHinh);
                sqlParameters[6] = new SqlParameter("@LoaiHang", LoaiHang);
                sqlParameters[7] = new SqlParameter("@ID", ID);
                DataTable dt = dao.tableList(sqlParameters, ctKeHoachVanTai.listDisplayProcedureName, ctKeHoachVanTai.tableName);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string Insert(ctKeHoachVanTai obj)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand(ctKeHoachVanTai.insertProcedureName, connection, transaction);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[25];
                sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                { 
                    Direction = ParameterDirection.Output,
                    Size = sizeof(Int64)
                };
                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                sqlParameters[3] = new SqlParameter("@IDDanhMucChungTuTrangThai", obj.IDDanhMucChungTuTrangThai);
                sqlParameters[4] = new SqlParameter("@So", obj.So)
                {
                    Direction = ParameterDirection.InputOutput,
                    Size = 35
                };
                sqlParameters[5] = new SqlParameter("@NgayLap", DateTime.Now);
                //
                sqlParameters[6] = new SqlParameter("@IDDanhMucSale", obj.IDDanhMucSale);
                sqlParameters[7] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                sqlParameters[8] = new SqlParameter("@LoaiHinh", obj.LoaiHinh);
                sqlParameters[9] = new SqlParameter("@LoaiHang", obj.LoaiHang);
                sqlParameters[10] = new SqlParameter("@IDDanhMucHangTau", obj.IDDanhMucHangTau);
                sqlParameters[11] = new SqlParameter("@IDDanhMucLoaiContainer", obj.IDDanhMucLoaiContainer);
                sqlParameters[12] = new SqlParameter("@SoLuongContainer", obj.SoLuongContainer);
                sqlParameters[13] = new SqlParameter("@SoContainer", obj.SoContainer);
                sqlParameters[14] = new SqlParameter("@KhoiLuong", obj.KhoiLuong);
                sqlParameters[15] = new SqlParameter("@IDDanhMucDiaDiemNangCont", obj.IDDanhMucDiaDiemNangCont);
                sqlParameters[16] = new SqlParameter("@NgayNangCont", obj.NgayNangCont);
                sqlParameters[17] = new SqlParameter("@IDDanhMucDiaDiemHaCont", obj.IDDanhMucDiaDiemHaCont);
                sqlParameters[18] = new SqlParameter("@NgayHaCont", obj.NgayHaCont);
                sqlParameters[19] = new SqlParameter("@IDDanhMucDiaDiemGiaoNhan", obj.IDDanhMucDiaDiemGiaoNhan);
                sqlParameters[20] = new SqlParameter("@NgayGiaoNhan", obj.NgayGiaoNhan);
                sqlParameters[21] = new SqlParameter("@NguoiGiaoNhan", obj.NguoiGiaoNhan);
                sqlParameters[22] = new SqlParameter("@SoDienThoaiGiaoNhan", obj.SoDienThoaiGiaoNhan);
                //
                sqlParameters[23] = new SqlParameter("@GhiChu", obj.GhiChu);
                sqlParameters[24] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParameters);
                int rowAffected = command.ExecuteNonQuery();
                obj.ID = cenCommon.cenCommon.longParse(sqlParameters[0].Value).ToString();
                obj.So = cenCommon.cenCommon.stringParse(sqlParameters[4].Value);
                transaction.Commit();
                return "00:";

            }
            catch (Exception ex)
            {
               
                return "01:" + ex.Message;
            }
            finally
            {
                command.Dispose();
                transaction.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        public string Update(ctKeHoachVanTai obj)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlCommand command = null;
            SqlParameter[] sqlParameters = null;
            try
            {
                connection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString);
                connection.Open();
                transaction = connection.BeginTransaction();

                command = new SqlCommand(ctKeHoachVanTai.updateProcedureName, connection, transaction);
                command.CommandType = CommandType.StoredProcedure;
                sqlParameters = new SqlParameter[25];
                sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                sqlParameters[3] = new SqlParameter("@IDDanhMucChungTuTrangThai", obj.IDDanhMucChungTuTrangThai);
                sqlParameters[4] = new SqlParameter("@So", obj.So);
                sqlParameters[5] = new SqlParameter("@NgayLap", obj.NgayLap);
                //
                sqlParameters[6] = new SqlParameter("@IDDanhMucSale", obj.IDDanhMucSale);
                sqlParameters[7] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                sqlParameters[8] = new SqlParameter("@LoaiHinh", obj.LoaiHinh);
                sqlParameters[9] = new SqlParameter("@LoaiHang", obj.LoaiHang);
                sqlParameters[10] = new SqlParameter("@IDDanhMucHangTau", obj.IDDanhMucHangTau);
                sqlParameters[11] = new SqlParameter("@IDDanhMucLoaiContainer", obj.IDDanhMucLoaiContainer);
                sqlParameters[12] = new SqlParameter("@SoLuongContainer", obj.SoLuongContainer);
                sqlParameters[13] = new SqlParameter("@SoContainer", obj.SoContainer);
                sqlParameters[14] = new SqlParameter("@KhoiLuong", obj.KhoiLuong);
                sqlParameters[15] = new SqlParameter("@IDDanhMucDiaDiemNangCont", obj.IDDanhMucDiaDiemNangCont);
                sqlParameters[16] = new SqlParameter("@NgayNangCont", obj.NgayNangCont);
                sqlParameters[17] = new SqlParameter("@IDDanhMucDiaDiemHaCont", obj.IDDanhMucDiaDiemHaCont);
                sqlParameters[18] = new SqlParameter("@NgayHaCont", obj.NgayHaCont);
                sqlParameters[19] = new SqlParameter("@IDDanhMucDiaDiemGiaoNhan", obj.IDDanhMucDiaDiemGiaoNhan);
                sqlParameters[20] = new SqlParameter("@NgayGiaoNhan", obj.NgayGiaoNhan);
                sqlParameters[21] = new SqlParameter("@NguoiGiaoNhan", obj.NguoiGiaoNhan);
                sqlParameters[22] = new SqlParameter("@SoDienThoaiGiaoNhan", obj.SoDienThoaiGiaoNhan);
                //
                sqlParameters[23] = new SqlParameter("@GhiChu", obj.GhiChu);
                sqlParameters[24] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
               
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParameters);
                int rowAffected = command.ExecuteNonQuery();
              
                //}
                transaction.Commit();
                return "00:";
            }
            catch (Exception ex)
            {
                if (transaction != null) transaction.Rollback();
                return "01:" + ex.Message;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                transaction.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }
        public string Delete(object ID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(ctKeHoachVanTai.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[2];
                            sqlParameters[0] = new SqlParameter("@ID", ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucNguoiSuDungDelete", UserSessionHelper.GetSession().IDDanhMucNguoiSuDung);
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();
                            return "00:";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "01:" + ex.Message;
            }
        }

        public DataTable rptKeHoachVanTaiTongHop(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucKhachHang, object LoaiHinh, object LoaiHang)
        {
            try
            {
                ConnectionDAO dao = new ConnectionDAO();
                SqlParameter[] sqlParameters = new SqlParameter[7];
                sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
                sqlParameters[2] = new SqlParameter("@TuNgay", TuNgay);
                sqlParameters[3] = new SqlParameter("@DenNgay", DenNgay);
                sqlParameters[4] = new SqlParameter("@IDDanhMucKhachHang", IDDanhMucKhachHang);
                sqlParameters[5] = new SqlParameter("@LoaiHinh", LoaiHinh);
                sqlParameters[6] = new SqlParameter("@LoaiHang", LoaiHang);
                DataTable dt = dao.tableList(sqlParameters, cenDTO.rptKeHoachVanTaiTongHop.listProcedureName , cenDTO.rptKeHoachVanTaiTongHop.listProcedureName);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
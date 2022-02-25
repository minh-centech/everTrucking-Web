using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using cenDTO;
namespace cenDAO
{
    public class ctKeHoachVanTaiChiTietSoContainerDAO
    {
        public DataSet List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ConnectionDAO dao = new ConnectionDAO();
                SqlParameter[] sqlParameters = new SqlParameter[3];
                sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
                sqlParameters[2] = new SqlParameter("@ID", ID);
                DataSet ds = dao.dsList(sqlParameters, ctKeHoachVanTaiChiTietSoContainer.listProcedureName);
                if (!cenCommon.cenCommon.IsNull(ds))
                {
                    ds.Tables[0].TableName = ctKeHoachVanTaiChiTietSoContainer.tableName;
                    ds.Tables[1].TableName = ctKeHoachVanTaiChiTietSoContainer.ctKeHoachVanTaiChiTietSoContainerChiTiet.tableName;
                    ds.Relations.Clear();
                    ds.Relations.Add("rltChiTietSoContainer", ds.Tables[ctKeHoachVanTaiChiTietSoContainer.tableName].Columns["ID"], ds.Tables[ctKeHoachVanTaiChiTietSoContainer.ctKeHoachVanTaiChiTietSoContainerChiTiet.tableName].Columns["IDChungTu"]);
                }    
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

     
        public DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucKhachHang, object ID)
        {
            try
            {
                ConnectionDAO dao = new ConnectionDAO();
                SqlParameter[] sqlParameters = new SqlParameter[6];
                sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", IDDanhMucChungTu);
                sqlParameters[2] = new SqlParameter("@TuNgay", TuNgay);
                sqlParameters[3] = new SqlParameter("@DenNgay", DenNgay);
                sqlParameters[4] = new SqlParameter("@IDDanhMucKhachHang", IDDanhMucKhachHang);
                sqlParameters[5] = new SqlParameter("@ID", ID);
                DataTable dt = dao.tableList(sqlParameters, ctKeHoachVanTaiChiTietSoContainer.listDisplayProcedureName, ctKeHoachVanTaiChiTietSoContainer.tableName);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string Insert(ctKeHoachVanTaiChiTietSoContainer obj)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand(ctKeHoachVanTaiChiTietSoContainer.insertProcedureName, connection, transaction);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[34];
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
                sqlParameters[11] = new SqlParameter("@IDDanhMucDiaDiemNangCont", obj.IDDanhMucDiaDiemNangCont);
                sqlParameters[12] = new SqlParameter("@NgayNangCont", obj.NgayNangCont);
                sqlParameters[13] = new SqlParameter("@IDDanhMucDiaDiemHaCont", obj.IDDanhMucDiaDiemHaCont);
                sqlParameters[14] = new SqlParameter("@NgayHaCont", obj.NgayHaCont);
                sqlParameters[15] = new SqlParameter("@SoLuongCont20", obj.SoLuongCont20);
                sqlParameters[16] = new SqlParameter("@SoCont20", obj.SoCont20);
                sqlParameters[17] = new SqlParameter("@SoLuongCont40", obj.SoLuongCont40);
                sqlParameters[18] = new SqlParameter("@SoCont40", obj.SoCont40);
                sqlParameters[19] = new SqlParameter("@SoLuongCont45", obj.SoLuongCont45);
                sqlParameters[20] = new SqlParameter("@SoCont45", obj.SoCont45);
                sqlParameters[21] = new SqlParameter("@SoLuongContOpenTop", obj.SoLuongContOpenTop);
                sqlParameters[22] = new SqlParameter("@SoContOpenTop", obj.SoContOpenTop);
                sqlParameters[23] = new SqlParameter("@SoLuongContFlatRack", obj.SoLuongContFlatRack);
                sqlParameters[24] = new SqlParameter("@SoContFlatRack", obj.SoContFlatRack);
                sqlParameters[25] = new SqlParameter("@IDDanhMucDiaDiemDongHang", obj.IDDanhMucDiaDiemDongHang);
                sqlParameters[26] = new SqlParameter("@NgayDongHang", obj.NgayDongHang);
                sqlParameters[27] = new SqlParameter("@IDDanhMucDiaDiemTraHang", obj.IDDanhMucDiaDiemTraHang);
                sqlParameters[28] = new SqlParameter("@NgayTraHang", obj.NgayTraHang);
                sqlParameters[29] = new SqlParameter("@KhoiLuong", obj.KhoiLuong);
                sqlParameters[30] = new SqlParameter("@NguoiGiaoNhan", obj.NguoiGiaoNhan);
                sqlParameters[31] = new SqlParameter("@SoDienThoaiGiaoNhan", obj.SoDienThoaiGiaoNhan);
                //
                sqlParameters[32] = new SqlParameter("@GhiChu", obj.GhiChu);
                sqlParameters[33] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParameters);
                int rowAffected = command.ExecuteNonQuery();
                obj.ID = cenCommon.cenCommon.longParse(sqlParameters[0].Value).ToString();
                obj.So = cenCommon.cenCommon.stringParse(sqlParameters[4].Value);
                foreach(ctKeHoachVanTaiChiTietSoContainer.ctKeHoachVanTaiChiTietSoContainerChiTiet objChiTiet in obj.listChiTiet)
                {
                    command = new SqlCommand(ctKeHoachVanTaiChiTietSoContainer.ctKeHoachVanTaiChiTietSoContainerChiTiet.insertProcedureName, connection, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    sqlParameters = new SqlParameter[5];
                    sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                    {
                        Direction = ParameterDirection.Output,
                        Size = sizeof(Int64)
                    };
                    sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                    sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                    sqlParameters[3] = new SqlParameter("@IDChungTu", obj.ID);
                    sqlParameters[4] = new SqlParameter("@So", objChiTiet.SoContainer);
                    command.Parameters.Clear();
                    command.Parameters.AddRange(sqlParameters);
                    rowAffected = command.ExecuteNonQuery();
                }    


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
        public string Update(ctKeHoachVanTaiChiTietSoContainer obj)
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

                command = new SqlCommand(ctKeHoachVanTaiChiTietSoContainer.updateProcedureName, connection, transaction);
                command.CommandType = CommandType.StoredProcedure;
                sqlParameters = new SqlParameter[34];
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
                sqlParameters[11] = new SqlParameter("@IDDanhMucDiaDiemNangCont", obj.IDDanhMucDiaDiemNangCont);
                sqlParameters[12] = new SqlParameter("@NgayNangCont", obj.NgayNangCont);
                sqlParameters[13] = new SqlParameter("@IDDanhMucDiaDiemHaCont", obj.IDDanhMucDiaDiemHaCont);
                sqlParameters[14] = new SqlParameter("@NgayHaCont", obj.NgayHaCont);
                sqlParameters[15] = new SqlParameter("@SoLuongCont20", obj.SoLuongCont20);
                sqlParameters[16] = new SqlParameter("@SoCont20", obj.SoCont20);
                sqlParameters[17] = new SqlParameter("@SoLuongCont40", obj.SoLuongCont40);
                sqlParameters[18] = new SqlParameter("@SoCont40", obj.SoCont40);
                sqlParameters[19] = new SqlParameter("@SoLuongCont45", obj.SoLuongCont45);
                sqlParameters[20] = new SqlParameter("@SoCont45", obj.SoCont45);
                sqlParameters[21] = new SqlParameter("@SoLuongContOpenTop", obj.SoLuongContOpenTop);
                sqlParameters[22] = new SqlParameter("@SoContOpenTop", obj.SoContOpenTop);
                sqlParameters[23] = new SqlParameter("@SoLuongContFlatRack", obj.SoLuongContFlatRack);
                sqlParameters[24] = new SqlParameter("@SoContFlatRack", obj.SoContFlatRack);
                sqlParameters[25] = new SqlParameter("@IDDanhMucDiaDiemDongHang", obj.IDDanhMucDiaDiemDongHang);
                sqlParameters[26] = new SqlParameter("@NgayDongHang", obj.NgayDongHang);
                sqlParameters[27] = new SqlParameter("@IDDanhMucDiaDiemTraHang", obj.IDDanhMucDiaDiemTraHang);
                sqlParameters[28] = new SqlParameter("@NgayTraHang", obj.NgayTraHang);
                sqlParameters[29] = new SqlParameter("@KhoiLuong", obj.KhoiLuong);
                sqlParameters[30] = new SqlParameter("@NguoiGiaoNhan", obj.NguoiGiaoNhan);
                sqlParameters[31] = new SqlParameter("@SoDienThoaiGiaoNhan", obj.SoDienThoaiGiaoNhan);
                //
                sqlParameters[32] = new SqlParameter("@GhiChu", obj.GhiChu);
                sqlParameters[33] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
               
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParameters);
                int rowAffected = command.ExecuteNonQuery();

                foreach (ctKeHoachVanTaiChiTietSoContainer.ctKeHoachVanTaiChiTietSoContainerChiTiet objChiTiet in obj.listChiTiet)
                {
                    if (objChiTiet.dataRowState == DataRowState.Deleted)
                    {
                        command = new SqlCommand(ctKeHoachVanTaiChiTietSoContainer.ctKeHoachVanTaiChiTietSoContainerChiTiet.deleteProcedureName, connection, transaction);
                        command.CommandType = CommandType.StoredProcedure;
                        sqlParameters = new SqlParameter[1];
                        sqlParameters[0] = new SqlParameter("@ID", objChiTiet.ID);
                        command.Parameters.Clear();
                        command.Parameters.AddRange(sqlParameters);
                        rowAffected = command.ExecuteNonQuery();
                    }
                    if (objChiTiet.dataRowState == DataRowState.Modified)
                    {
                        command = new SqlCommand(ctKeHoachVanTaiChiTietSoContainer.ctKeHoachVanTaiChiTietSoContainerChiTiet.updateProcedureName, connection, transaction);
                        command.CommandType = CommandType.StoredProcedure;
                        sqlParameters = new SqlParameter[5];
                        sqlParameters[0] = new SqlParameter("@ID", objChiTiet.ID)
                        {
                            Direction = ParameterDirection.Output,
                            Size = sizeof(Int64)
                        };
                        sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                        sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                        sqlParameters[3] = new SqlParameter("@IDChungTu", obj.ID);
                        sqlParameters[4] = new SqlParameter("@SoContainer", objChiTiet.SoContainer);
                        command.Parameters.Clear();
                        command.Parameters.AddRange(sqlParameters);
                        rowAffected = command.ExecuteNonQuery();
                    }
                    if (objChiTiet.dataRowState == DataRowState.Added)
                    {
                        command = new SqlCommand(ctKeHoachVanTaiChiTietSoContainer.ctKeHoachVanTaiChiTietSoContainerChiTiet.insertProcedureName, connection, transaction);
                        command.CommandType = CommandType.StoredProcedure;
                        sqlParameters = new SqlParameter[5];
                        sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                        {
                            Direction = ParameterDirection.Output,
                            Size = sizeof(Int64)
                        };
                        sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                        sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                        sqlParameters[3] = new SqlParameter("@IDChungTu", obj.ID);
                        sqlParameters[4] = new SqlParameter("@SoContainer", objChiTiet.SoContainer);
                        command.Parameters.Clear();
                        command.Parameters.AddRange(sqlParameters);
                        rowAffected = command.ExecuteNonQuery();
                    }
                }

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
                        using (SqlCommand sqlCommand = new SqlCommand(ctKeHoachVanTaiChiTietSoContainer.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[2];
                            sqlParameters[0] = new SqlParameter("@ID", ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucNguoiSuDungDelete", cenCommon.GlobalVariables.IDDanhMucNguoiSuDung);
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
    }
}
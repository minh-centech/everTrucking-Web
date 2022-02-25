using cenDAO.DatabaseCore;
using cenDTO.cenLogistics;
using System;
using System.Data;
using System.Data.SqlClient;
namespace cenDAO.cenLogistics
{
    public class DanhMucKhachHangDAO
    {
        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucKhachHang.listProcedureName, DanhMucKhachHang.listProcedureName);
            return dt;
        }
        public DataTable Valid(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[4];
            sqlParameters[0] = new SqlParameter("@ID", ID);
            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", IDDanhMucLoaiDoiTuong);
            sqlParameters[3] = new SqlParameter("@SearchStr", SearchStr);
            DataTable dt = dao.tableList(sqlParameters, DanhMucKhachHang.validProcedureName, DanhMucKhachHang.tableName);
            return dt;
        }


        public string Insert(ref DanhMucKhachHang obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucKhachHang.insertProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[15];
                            sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = sizeof(Int64)
                            };
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", cenCommon.GlobalVariables.IDDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[4] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[5] = new SqlParameter("@TenEN", obj.TenEN);
                            sqlParameters[6] = new SqlParameter("@MaCS", obj.MaCS);
                            sqlParameters[7] = new SqlParameter("@DiaChi", obj.DiaChi);
                            sqlParameters[8] = new SqlParameter("@MaSoThue", obj.MaSoThue);
                            sqlParameters[9] = new SqlParameter("@Nhom", obj.Nhom);
                            sqlParameters[10] = new SqlParameter("@ViTri", obj.ViTri);
                            sqlParameters[11] = new SqlParameter("@LoaiKhachHang", obj.LoaiKhachHang);
                            sqlParameters[12] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[13] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", obj.IDDanhMucNguoiSuDungCreate);
                            sqlParameters[14] = new SqlParameter("@CreateDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = sqlParameters[0].Value.ToString();
                            obj.CreateDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
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
        public string Update(ref DanhMucKhachHang obj)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucKhachHang.updateProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[15];
                            sqlParameters[0] = new SqlParameter("@ID", obj.ID);
                            sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", obj.IDDanhMucDonVi);
                            sqlParameters[2] = new SqlParameter("@IDDanhMucLoaiDoiTuong", obj.IDDanhMucLoaiDoiTuong);
                            sqlParameters[3] = new SqlParameter("@Ma", obj.Ma);
                            sqlParameters[4] = new SqlParameter("@Ten", obj.Ten);
                            sqlParameters[5] = new SqlParameter("@TenEN", obj.TenEN);
                            sqlParameters[6] = new SqlParameter("@MaCS", obj.MaCS);
                            sqlParameters[7] = new SqlParameter("@DiaChi", obj.DiaChi);
                            sqlParameters[8] = new SqlParameter("@MaSoThue", obj.MaSoThue);
                            sqlParameters[9] = new SqlParameter("@Nhom", obj.Nhom);
                            sqlParameters[10] = new SqlParameter("@ViTri", obj.ViTri);
                            sqlParameters[11] = new SqlParameter("@LoaiKhachHang", obj.LoaiKhachHang);
                            sqlParameters[12] = new SqlParameter("@GhiChu", obj.GhiChu);
                            sqlParameters[13] = new SqlParameter("@IDDanhMucNguoiSuDungEdit", obj.IDDanhMucNguoiSuDungEdit);
                            sqlParameters[14] = new SqlParameter("@EditDate", DBNull.Value)
                            {
                                Direction = ParameterDirection.Output,
                                Size = 8
                            };
                            sqlCommand.Parameters.AddRange(sqlParameters);
                            int rowAffected = sqlCommand.ExecuteNonQuery();
                            obj.ID = sqlParameters[0].Value.ToString();
                            obj.EditDate = DateTime.Parse(sqlParameters[sqlParameters.Length - 1].Value.ToString());
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
        public string Delete(string ID)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(cenCommon.GlobalVariables.ConnectionString))
                {
                    sqlConnection.Open();
                    using (SqlTransaction sqlTransaction = sqlConnection.BeginTransaction())
                    {
                        using (SqlCommand sqlCommand = new SqlCommand(DanhMucKhachHang.deleteProcedureName, sqlConnection, sqlTransaction))
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            SqlParameter[] sqlParameters = new SqlParameter[1];
                            sqlParameters[0] = new SqlParameter("@ID", ID);
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

using everTrucking_Web.Code.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
namespace everTrucking_Web.Code.DAO
{
    public class ctDonHangDAO
    {
        public DataTable ListDisplay()
        {
            ConnectionDAO dao = new ConnectionDAO();
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@IDDanhMucDonVi", Code.GlobalVariables.IDDonVi);
            sqlParameters[1] = new SqlParameter("@IDDanhMucChungTu", Code.GlobalVariables.IDDanhMucChungTuDonHang);
            sqlParameters[2] = new SqlParameter("@ID", DBNull.Value);
            sqlParameters[3] = new SqlParameter("@TuNgay", "10/1/2021");
            sqlParameters[4] = new SqlParameter("@DenNgay", "10/14/2021");
            DataTable dt = dao.tableList(sqlParameters, "List_ctDonHang_Display", "List_ctDonHang_Display");
            return dt;
        }

        public bool Insert(ctDonHang obj)
        {
            SqlConnection connection = null;
            SqlTransaction transaction = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(Code.GlobalVariables.webConnectionString);
                connection.Open();
                transaction = connection.BeginTransaction();
                command = new SqlCommand(ctDonHang.insertProcedureName, connection, transaction);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter[] sqlParameters = new SqlParameter[35];
                sqlParameters[0] = new SqlParameter("@ID", DBNull.Value)
                {
                    Direction = ParameterDirection.Output,
                    Size = sizeof(Int64)
                };
                sqlParameters[1] = new SqlParameter("@IDDanhMucDonVi", Code.GlobalVariables.IDDonVi);
                sqlParameters[2] = new SqlParameter("@IDDanhMucChungTu", obj.IDDanhMucChungTu);
                sqlParameters[3] = new SqlParameter("@IDDanhMucChungTuTrangThai", obj.IDDanhMucChungTuTrangThai);
                sqlParameters[4] = new SqlParameter("@So", obj.So)
                {
                    Direction = ParameterDirection.Output,
                    Size = 35
                };
                sqlParameters[5] = new SqlParameter("@NgayLap", obj.NgayLap);
                //
                sqlParameters[6] = new SqlParameter("@IDDanhMucSale", obj.IDDanhMucSale);
                sqlParameters[7] = new SqlParameter("@IDDanhMucKhachHang", obj.IDDanhMucKhachHang);
                sqlParameters[8] = new SqlParameter("@DebitNote", obj.DebitNote);
                sqlParameters[9] = new SqlParameter("@BillBooking", obj.BillBooking);
                sqlParameters[10] = new SqlParameter("@LoaiHang", obj.LoaiHang);
                sqlParameters[11] = new SqlParameter("@IDDanhMucNhomHangVanChuyen", obj.IDDanhMucNhomHangVanChuyen);
                sqlParameters[12] = new SqlParameter("@IDDanhMucHangHoa", obj.IDDanhMucHangHoa);
                sqlParameters[13] = new SqlParameter("@IDDanhMucHangTau", obj.IDDanhMucHangTau);
                sqlParameters[14] = new SqlParameter("@SoLuong", obj.SoLuong);
                sqlParameters[15] = new SqlParameter("@KhoiLuong", obj.KhoiLuong);
                sqlParameters[16] = new SqlParameter("@TheTich", obj.TheTich);
                sqlParameters[17] = new SqlParameter("@SoContainer", obj.SoContainer);
                sqlParameters[18] = new SqlParameter("@IDDanhMucDiaDiemLayCont", obj.IDDanhMucDiaDiemLayContHang);
                sqlParameters[19] = new SqlParameter("@IDDanhMucDiaDiemTraCont", obj.IDDanhMucDiaDiemTraContHang);
                sqlParameters[20] = new SqlParameter("@NgayDongHang", obj.NgayDongHang);
                sqlParameters[21] = new SqlParameter("@GioDongHang", obj.GioDongHang);
                sqlParameters[22] = new SqlParameter("@NgayTraHang", obj.NgayTraHang);
                sqlParameters[23] = new SqlParameter("@GioTraHang", obj.GioTraHang);
                sqlParameters[24] = new SqlParameter("@IDDanhMucDiaDiemLayHang", obj.IDDanhMucDiaDiemLayContHang);
                sqlParameters[25] = new SqlParameter("@IDDanhMucDiaDiemTraHang", obj.IDDanhMucDiaDiemTraContHang);
                sqlParameters[26] = new SqlParameter("@IDDanhMucTuyenVanTai", obj.IDDanhMucTuyenVanTai);
                sqlParameters[27] = new SqlParameter("@NgayCatMang", obj.NgayCatMang);
                sqlParameters[28] = new SqlParameter("@GioCatMang", obj.GioCatMang);
                sqlParameters[29] = new SqlParameter("@NguoiGiaoNhan", obj.NguoiGiaoNhan);
                sqlParameters[30] = new SqlParameter("@SoDienThoaiGiaoNhan", obj.SoDienThoaiGiaoNhan);
                sqlParameters[31] = new SqlParameter("@SoTienCuoc", obj.SoTienCuoc);
               
                sqlParameters[32] = new SqlParameter("@ThoiHanThanhToan", obj.ThoiHanThanhToan);
                //
                sqlParameters[33] = new SqlParameter("@GhiChu", obj.GhiChu);
                sqlParameters[34] = new SqlParameter("@IDDanhMucNguoiSuDungCreate", Code.GlobalVariables.IDDanhMucNguoiSuDung);
                command.Parameters.Clear();
                command.Parameters.AddRange(sqlParameters);
                int rowAffected = command.ExecuteNonQuery();
               
                obj.So = sqlParameters[4].Value.ToString();
                return true;

            }
            catch (Exception ex)
            {
              
              
                return false;
            }
           
        }
    }
}
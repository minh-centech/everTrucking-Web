using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucDiaDiemGiaoNhanBUS
    {
        public static DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static cenDTO.msgResponse Insert(ref DanhMucDiaDiemGiaoNhan obj)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                Response = dao.Insert(ref obj);
                if (Response.StartsWith("00:"))
                {
                    msgResponse.Status = "00";
                    msgResponse.Data = "";
                    msgResponse.Message = "Thêm dữ liệu thành công!";
                }
                else
                {
                    msgResponse.Status = "01";
                    msgResponse.Data = "";
                    msgResponse.Message = Response;
                };
            }
            catch (Exception ex)
            {
                msgResponse.Status = "01";
                msgResponse.Data = "";
                msgResponse.Message = ex.Message;
            }
            return msgResponse;
        }
        public static cenDTO.msgResponse Update(ref DanhMucDiaDiemGiaoNhan obj)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                Response = dao.Update(ref obj);
                if (Response.StartsWith("00:"))
                {
                    msgResponse.Status = "00";
                    msgResponse.Data = "";
                    msgResponse.Message = "Sửa dữ liệu thành công!";
                }
                else
                {
                    msgResponse.Status = "01";
                    msgResponse.Data = "";
                    msgResponse.Message = Response;
                };
            }
            catch (Exception ex)
            {
                msgResponse.Status = "01";
                msgResponse.Data = "";
                msgResponse.Message = ex.Message;
            }
            return msgResponse;
        }
        public static cenDTO.msgResponse Delete(string ID)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                DanhMucDiaDiemGiaoNhanDAO dao = new DanhMucDiaDiemGiaoNhanDAO();
                Response = dao.Delete(ID);
                if (Response.StartsWith("00:"))
                {
                    msgResponse.Status = "00";
                    msgResponse.Data = "";
                    msgResponse.Message = "Xóa dữ liệu thành công!";
                }
                else
                {
                    msgResponse.Status = "01";
                    msgResponse.Data = "";
                    msgResponse.Message = Response;
                };
            }
            catch (Exception ex)
            {
                msgResponse.Status = "01";
                msgResponse.Data = "";
                msgResponse.Message = ex.Message;
            }
            return msgResponse;
        }
    }
}

using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucKhachHangBUS
    {
        public static DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DataTable Valid(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                return dao.Valid(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static cenDTO.msgResponse Insert(ref DanhMucKhachHang obj)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
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
        public static cenDTO.msgResponse Update(ref DanhMucKhachHang obj)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                Response = dao.Update(ref obj);
                if (Response.StartsWith("00:"))
                {
                    msgResponse.Status = "00";
                    msgResponse.Data = "";
                    msgResponse.Message = "Cập nhập dữ liệu thành công!";
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
        public static cenDTO.msgResponse Delete(string obj)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                DanhMucKhachHangDAO dao = new DanhMucKhachHangDAO();
                Response = dao.Delete(obj);
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

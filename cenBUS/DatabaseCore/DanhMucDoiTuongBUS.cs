using cenDAO.DatabaseCore;
using cenDTO.DatabaseCore;
using System;
using System.Data;
namespace cenBUS.DatabaseCore
{
    public class DanhMucDoiTuongBUS
    {
        public static DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object SearchStr)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static cenDTO.msgResponse Insert(ref DanhMucDoiTuong obj)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
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
        public static cenDTO.msgResponse Update(ref DanhMucDoiTuong obj)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
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
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
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
        public static object GetID(object IDDanhMucLoaiDoiTuong, object Ma)
        {
            try
            {
                DanhMucDoiTuongDAO dao = new DanhMucDoiTuongDAO();
                return dao.GetID(IDDanhMucLoaiDoiTuong, Ma);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

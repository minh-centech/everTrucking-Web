using everTrucking_Web.Code.DAO;
using everTrucking_Web.Code.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code.BUS
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
        public static Common.msgResponse Insert(ref DanhMucKhachHang obj)
        {
            Common.msgResponse msgResponse = new Common.msgResponse();
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
        public static Common.msgResponse Update(ref DanhMucKhachHang obj)
        {
            Common.msgResponse msgResponse = new Common.msgResponse();
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
        public static Common.msgResponse Delete(string obj)
        {
            Common.msgResponse msgResponse = new Common.msgResponse();
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
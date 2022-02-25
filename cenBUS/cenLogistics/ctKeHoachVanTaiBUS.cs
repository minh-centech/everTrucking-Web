using cenDAO;
using cenDTO;
using System;
using System.Data;

namespace cenBUS
{
    public class ctKeHoachVanTaiBUS
    {
        public static DataTable List(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
                return dao.List(IDDanhMucChungTu, ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucKhachHang, object LoaiHinh, object LoaiHang, object ID)
        {
            try
            {
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
                return dao.ListDisplay(IDDanhMucChungTu, TuNgay, DenNgay, IDDanhMucKhachHang, LoaiHinh, LoaiHang, ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static cenDTO.msgResponse Insert(ctKeHoachVanTai obj)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
                Response = dao.Insert(obj);
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
        public static cenDTO.msgResponse Update(ctKeHoachVanTai obj)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
                Response = dao.Update(obj);
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
        public static cenDTO.msgResponse Delete(object ID)
        {
            cenDTO.msgResponse msgResponse = new cenDTO.msgResponse();
            try
            {
                string Response = "01:";
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
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

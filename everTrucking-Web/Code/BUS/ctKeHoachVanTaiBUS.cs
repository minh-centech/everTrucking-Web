using everTrucking_Web.Code.DAO;
using everTrucking_Web.Code.DTO;
using System;
using System.Data;
using static everTrucking_Web.Code.Common;

namespace everTrucking_Web.Code.BUS
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
        public static DataTable ListDisplay(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucKhachHang, object ID)
        {
            try
            {
                
                ctKeHoachVanTaiDAO dao = new ctKeHoachVanTaiDAO();
                return dao.ListDisplay(IDDanhMucChungTu, TuNgay, DenNgay, IDDanhMucKhachHang, ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Common.msgResponse Insert(ctKeHoachVanTai obj)
        {
            Common.msgResponse msgResponse = new Common.msgResponse();
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
        public static Common.msgResponse Update(ctKeHoachVanTai obj)
        {
            Common.msgResponse msgResponse = new Common.msgResponse();
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
        public static Common.msgResponse Delete(object ID)
        {
            Common.msgResponse msgResponse = new Common.msgResponse();
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

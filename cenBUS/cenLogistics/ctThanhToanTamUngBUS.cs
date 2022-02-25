using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Collections.Generic;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctThanhToanTamUngBUS
    {
        public ctThanhToanTamUngBUS()
        {
        }

        public DataSet List(object IDDanhMucChungTu, object ID, object IDChungTuChiTiet)
        {
            try
            {
                ctThanhToanTamUngDAO dao = new ctThanhToanTamUngDAO();
                DataSet ds = dao.List(IDDanhMucChungTu, ID, IDChungTuChiTiet);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ListDisplay(object IDDanhMucChungTu, object ID, object IDChungTuChiTiet, object TuNgay, object DenNgay)
        {
            try
            {
                ctThanhToanTamUngDAO dao = new ctThanhToanTamUngDAO();
                DataTable dt = dao.ListDisplay(IDDanhMucChungTu, ID, IDChungTuChiTiet, TuNgay, DenNgay);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(List<ctThanhToanTamUng> objList)
        {
            try
            {
                ctThanhToanTamUngDAO dao = new ctThanhToanTamUngDAO();
                return dao.Insert(objList);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(List<ctThanhToanTamUng> objList)
        {
            try
            {
                ctThanhToanTamUngDAO dao = new ctThanhToanTamUngDAO();
                return dao.Update(objList);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(ctThanhToanTamUng obj)
        {
            try
            {
                ctThanhToanTamUngDAO dao = new ctThanhToanTamUngDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DataTable ListDeNghiThanhToanTamUngGuiKhachHang(object IDDanhMucChungTu, object ID)
        {
            try
            {
                ctThanhToanTamUngDAO dao = new ctThanhToanTamUngDAO();
                DataTable dt = dao.ListDeNghiThanhToanGuiKhachHang(IDDanhMucChungTu, ID);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

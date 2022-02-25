using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Collections.Generic;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class ctChotDoanhThuGuiKeToanBUS
    {
        public ctChotDoanhThuGuiKeToanBUS()
        {
        }

        public DataSet List(object IDDanhMucChungTu, object TuNgay, object DenNgay, object IDDanhMucKhachHang, object IDDanhMucSale)
        {
            try
            {
                ctChotDoanhThuGuiKeToanDAO dao = new ctChotDoanhThuGuiKeToanDAO();
                DataSet ds = dao.List(IDDanhMucChungTu, TuNgay, DenNgay, IDDanhMucKhachHang, IDDanhMucSale);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(List<ctChotDoanhThuGuiKeToan> objList)
        {
            try
            {
                ctChotDoanhThuGuiKeToanDAO dao = new ctChotDoanhThuGuiKeToanDAO();
                return dao.Insert(objList);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(List<ctChotDoanhThuGuiKeToan> objList)
        {
            try
            {
                ctChotDoanhThuGuiKeToanDAO dao = new ctChotDoanhThuGuiKeToanDAO();
                return dao.Delete(objList);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

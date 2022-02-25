using cenDAO.cenLogistics;
using cenDTO.cenLogistics;
using System;
using System.Data;
namespace cenBUS.cenLogistics
{
    public class DanhMucHangHoaBUS
    {
        public DanhMucHangHoaBUS()
        {
        }

        public DataTable List(object ID, object IDDanhMucLoaiDoiTuong, object IDDanhMucNhomHangVanChuyen, object SearchStr)
        {
            try
            {
                DanhMucHangHoaDAO dao = new DanhMucHangHoaDAO();
                return dao.List(ID, IDDanhMucLoaiDoiTuong, IDDanhMucNhomHangVanChuyen, SearchStr);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucHangHoa obj)
        {
            try
            {
                DanhMucHangHoaDAO dao = new DanhMucHangHoaDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucHangHoa obj)
        {
            try
            {
                DanhMucHangHoaDAO dao = new DanhMucHangHoaDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucHangHoa obj)
        {
            try
            {
                DanhMucHangHoaDAO dao = new DanhMucHangHoaDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

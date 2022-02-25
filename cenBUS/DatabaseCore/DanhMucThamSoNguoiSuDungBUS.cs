using cenDAO.DatabaseCore;
using cenDTO.DatabaseCore;
using System;
using System.Data;
namespace cenBUS.DatabaseCore
{
    public class DanhMucThamSoNguoiSuDungBUS
    {
        public DanhMucThamSoNguoiSuDungBUS()
        {
        }

        public DataTable List(object ID)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucThamSoNguoiSuDung obj)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucThamSoNguoiSuDung obj)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucThamSoNguoiSuDung obj)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static object GetGiaTri(object Ma)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.GetGiaTri(Ma);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static object UpdateGiaTri(object Ma, object GiaTri)
        {
            try
            {
                DanhMucThamSoNguoiSuDungDAO dao = new DanhMucThamSoNguoiSuDungDAO();
                return dao.UpdateGiaTri(Ma, GiaTri);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

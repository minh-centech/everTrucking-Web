using cenDAO.DatabaseCore;
using cenDTO.DatabaseCore;
using System;
using System.Data;
namespace cenBUS.DatabaseCore
{
    public class DanhMucNguoiSuDungBUS
    {
        public DanhMucNguoiSuDungBUS()
        {
        }

        public DataTable List(object ID)
        {
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.List(ID);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucNguoiSuDung obj)
        {
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucNguoiSuDung obj)
        {
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucNguoiSuDung obj)
        {
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static string GetID(string Ma, string Password, out string IDDanhMucPhanQuyen, out string isAdmin)
        {
            IDDanhMucPhanQuyen = "";
            isAdmin = "0";
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.GetID(Ma, Password, out IDDanhMucPhanQuyen, out isAdmin);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
        public static bool UpdatePassword(object ID, object Password)
        {
            try
            {
                DanhMucNguoiSuDungDAO dao = new DanhMucNguoiSuDungDAO();
                return dao.UpdatePassword(ID, Password);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

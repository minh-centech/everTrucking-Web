using cenDAO.DatabaseCore;
using cenDTO.DatabaseCore;
using System;
using System.Data;
namespace cenBUS.DatabaseCore
{
    public class DanhMucMenuBUS
    {
        public DanhMucMenuBUS()
        {
        }
        public DataSet List(object ID)
        {
            try
            {
                DanhMucMenuDAO dao = new DanhMucMenuDAO();
                DataSet ds = dao.List(ID);
                ds.Tables[0].TableName = DanhMucMenu.tableName;
                ds.Tables[1].TableName = DanhMucMenuLoaiDoiTuong.tableName;
                ds.Tables[2].TableName = DanhMucMenuChungTu.tableName;
                ds.Tables[3].TableName = DanhMucMenuBaoCao.tableName;
                ds.Relations.Add(cenCommon.GlobalVariables.prefix_DataRelation + DanhMucMenuLoaiDoiTuong.tableName, ds.Tables[DanhMucMenu.tableName].Columns["ID"], ds.Tables[DanhMucMenuLoaiDoiTuong.tableName].Columns["IDDanhMucMenu"]);
                ds.Relations.Add(cenCommon.GlobalVariables.prefix_DataRelation + DanhMucMenuChungTu.tableName, ds.Tables[DanhMucMenu.tableName].Columns["ID"], ds.Tables[DanhMucMenuChungTu.tableName].Columns["IDDanhMucMenu"]);
                ds.Relations.Add(cenCommon.GlobalVariables.prefix_DataRelation + DanhMucMenuBaoCao.tableName, ds.Tables[DanhMucMenu.tableName].Columns["ID"], ds.Tables[DanhMucMenuBaoCao.tableName].Columns["IDDanhMucMenu"]);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucMenu obj)
        {
            try
            {
                DanhMucMenuDAO dao = new DanhMucMenuDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucMenu obj)
        {
            try
            {
                DanhMucMenuDAO dao = new DanhMucMenuDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucMenu obj)
        {
            try
            {
                DanhMucMenuDAO dao = new DanhMucMenuDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

    public class DanhMucMenuLoaiDoiTuongBUS
    {
        public DanhMucMenuLoaiDoiTuongBUS()
        {
        }
        public DataTable List(Object ID = null, Object IDDanhMucMenu = null)
        {
            try
            {
                DanhMucMenuLoaiDoiTuongDAO dao = new DanhMucMenuLoaiDoiTuongDAO();
                return dao.List(ID, IDDanhMucMenu);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucMenuLoaiDoiTuong obj)
        {
            try
            {
                DanhMucMenuLoaiDoiTuongDAO dao = new DanhMucMenuLoaiDoiTuongDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucMenuLoaiDoiTuong obj)
        {
            try
            {
                DanhMucMenuLoaiDoiTuongDAO dao = new DanhMucMenuLoaiDoiTuongDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucMenuLoaiDoiTuong obj)
        {
            try
            {
                DanhMucMenuLoaiDoiTuongDAO dao = new DanhMucMenuLoaiDoiTuongDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

    public class DanhMucMenuChungTuBUS
    {
        public DanhMucMenuChungTuBUS()
        {
        }
        public DataTable List(Object ID = null, Object IDDanhMucMenu = null)
        {
            try
            {
                DanhMucMenuChungTuDAO dao = new DanhMucMenuChungTuDAO();
                return dao.List(ID, IDDanhMucMenu);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucMenuChungTu obj)
        {
            try
            {
                DanhMucMenuChungTuDAO dao = new DanhMucMenuChungTuDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucMenuChungTu obj)
        {
            try
            {
                DanhMucMenuChungTuDAO dao = new DanhMucMenuChungTuDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucMenuChungTu obj)
        {
            try
            {
                DanhMucMenuChungTuDAO dao = new DanhMucMenuChungTuDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }

    public class DanhMucMenuBaoCaoBUS
    {
        public DanhMucMenuBaoCaoBUS()
        {
        }
        public DataTable List(Object ID = null, Object IDDanhMucMenu = null)
        {
            try
            {
                DanhMucMenuBaoCaoDAO dao = new DanhMucMenuBaoCaoDAO();
                return dao.List(ID, IDDanhMucMenu);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Insert(ref DanhMucMenuBaoCao obj)
        {
            try
            {
                DanhMucMenuBaoCaoDAO dao = new DanhMucMenuBaoCaoDAO();
                return dao.Insert(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(ref DanhMucMenuBaoCao obj)
        {
            try
            {
                DanhMucMenuBaoCaoDAO dao = new DanhMucMenuBaoCaoDAO();
                return dao.Update(ref obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(DanhMucMenuBaoCao obj)
        {
            try
            {
                DanhMucMenuBaoCaoDAO dao = new DanhMucMenuBaoCaoDAO();
                return dao.Delete(obj);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}

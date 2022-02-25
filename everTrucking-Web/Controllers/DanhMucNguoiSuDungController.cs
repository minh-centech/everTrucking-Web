using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using cenDTO.DatabaseCore;
using cenBUS.DatabaseCore;
using cenDTO;

namespace webHungThinhBDSReport.Controllers
{
    public class DanhMucNguoiSuDungController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            DanhMucNguoiSuDung model = new DanhMucNguoiSuDung();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(DanhMucNguoiSuDung model)
        {
            if (model.Ma == null) model.Ma = "";
            if (model.Password == null) model.Password = "";
            string ID = DanhMucNguoiSuDungBUS.GetID(model.Ma.ToString(), cenCommon.cenCommon.EncryptString(model.Password.ToString()), out string IDDanhMucPhanQuyen, out string isAdmin);
            if (!cenCommon.cenCommon.IsNull(ID) && ModelState.IsValid)
            {
                //Sau này đổi lại IDDanhMucDonVi theo user phân quyền đơn vị
                UserSessionHelper.SetSession(new UserSession() { IDDanhMucDonVi = cenCommon.GlobalVariables.IDDonVi, IDDanhMucNguoiSuDung = ID, IDDanhMucPhanQuyen = IDDanhMucPhanQuyen, IsAdmin = isAdmin });
                return RedirectToAction("Index", "KeHoachVanTaiTongHop");
            }
            else
            {
                ModelState.AddModelError("", cenCommon.GlobalVariables.InvalidLoginMsg);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Logout()
        {
            UserSessionHelper.SetSession(null);
            return RedirectToAction("Login", "DanhMucNguoiSuDung");
        }
    }
}
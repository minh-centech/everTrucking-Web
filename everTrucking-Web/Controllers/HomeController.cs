using cenDTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace everTrucking_Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            UserSession Session = UserSessionHelper.GetSession();
            if (Session == null)
                return RedirectToAction("Login", "DanhMucNguoiSuDung");
            return View();
        }
    }
}
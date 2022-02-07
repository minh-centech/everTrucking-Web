using everTrucking_Web.Code.DAO;
using everTrucking_Web.Code.DTO;
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
    public class DonHangController : Controller
    {
        // GET: DonHang
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public string GetJsonTest()
        {
            DataTable ctDonHang = Code.BUS.ctDonHangBUS.ListDisplay();
            List<ctDonHang> listDonHang = new List<ctDonHang>();
            foreach (DataRow drDonHang in ctDonHang.Rows)
            {
                listDonHang.Add(new ctDonHang()
                {
                    ID = drDonHang["ID"].ToString(),
                    So = drDonHang["So"].ToString(),
                    MaDanhMucKhachHang = drDonHang["MaDanhMucKhachHang"].ToString(),                  
                    DebitNote = drDonHang["DebitNote"].ToString(),
                    BillBooking = drDonHang["BillBooking"].ToString(),                                  
                    KhoiLuong = drDonHang["Khoiluong"].ToString(),                
                    GhiChu = drDonHang["GhiChu"].ToString(),


                });

            }
            string strData = JsonConvert.SerializeObject(listDonHang, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            strData = Regex.Unescape(strData);
            return strData;
            //return Json(bookList, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(ctDonHang model)
        {
            if (ModelState.IsValid)
            {
                var dao = new ctDonHangDAO();
                bool id = dao.Insert(model);

                if (id == true)
                {
                  
                    return RedirectToAction("Index", "DonHang");
                }

                else
                {
                    ModelState.AddModelError("", "Thêm User không thành công");
                }
            }
           
            return View("Index");
        }
    }
}
using everTrucking_Web.Code.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace everTrucking_Web.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        // GET: QuanLyDonHang
       
        public ActionResult Index()
        {
            DataTable dtDanhMucKhachHang = Code.BUS.DanhMucKhachHangBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongKhachHang, null);
            List<DanhMucKhachHang> listKhachHang = new List<DanhMucKhachHang>();
            foreach (DataRow drKhachHang in dtDanhMucKhachHang.Rows)
            {
                listKhachHang.Add(new DanhMucKhachHang()
                {
                    ID = drKhachHang["ID"].ToString(),
                    Ma = drKhachHang["Ma"].ToString(),
                    Ten = drKhachHang["Ten"].ToString(),
                    MaCS = drKhachHang["MaCS"].ToString(),

                });

            }
            ViewBag.ListKhachHang = listKhachHang;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string tungay,string denngay,string tencongty)
        {

            try
            {
                ViewData["Tungay"] = tungay;
                ViewData["Denngay"] = denngay;
                ViewData["Tencongty"] = tencongty;
                return View("Index");
            }
            catch
            {
                return View();
            }
         
        }
        [HttpGet]
        public string GetJsonTest()
        {
            DataTable dtDanhMucKhachHang = Code.BUS.DanhMucKhachHangBUS.List(null, Code.GlobalVariables.IDDanhMucLoaiDoiTuongKhachHang, null);
            List<DanhMucKhachHang> listKhachHang = new List<DanhMucKhachHang>();
            foreach (DataRow drKhachHang in dtDanhMucKhachHang.Rows)
            {
                listKhachHang.Add(new DanhMucKhachHang()
                {
                    ID = drKhachHang["ID"].ToString(),
                    Ma = drKhachHang["Ma"].ToString(),
                    Ten = drKhachHang["Ten"].ToString(),
                    MaCS = drKhachHang["MaCS"].ToString(),

                });
                
            }
            string strData = JsonConvert.SerializeObject(listKhachHang, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
            strData = Regex.Unescape(strData);
            return strData;
            //return Json(bookList, JsonRequestBehavior.AllowGet);
        }

       

    }
}
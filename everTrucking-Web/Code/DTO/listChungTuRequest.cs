using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code.DTO
{
    public class listChungTuRequest
    {
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public string IDDanhMucChungTu { get; set; }
        public string IDDanhMucKhachHang { get; set; }
    }
}
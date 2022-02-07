using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace everTrucking_Web.Code.DTO
{
    public class ChungTu
    {
        public string ID { get; set; }
        public string SoChungTu { get; set; }
        public string NgayLap { get; set; }
        public string Sales { get; set; }
        public string LoaiHang { get; set; }

        public string KhachHang { get; set; }
        public string Hangtau { get; set; }
        public string Diadiemnangcont { get; set; }

        public string Ngaynangcont { get; set; }
        public string Diadiemhacont { get; set; }

        public string Ngayhacont { get; set; }
      
        public string Soluongcon20 { get; set; }
        public string Socon20 { get; set; }
        public string Soluongcon40 { get; set; }
        public string Socon40 { get; set; }
        public string Soluongcon45 { get; set; }
        public string Socon45 { get; set; }

        public string Diadiemdonghang{ get; set; }

       
        public string NgayDongHang { get; set; }
        public string Diadiemdtrahang { get; set; }
        public string NgayTraHang { get; set; }
        public string NguoiGiaoNhan { get; set; }
        public string DienThoai { get; set; }

        public string GhiChu { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cenDTO
{
    [Serializable]
    public class UserSession
    {
        public string IDDanhMucDonVi { get; set; }
        public string IDDanhMucNguoiSuDung { get; set; }
        public string IDDanhMucPhanQuyen { get; set; }
        public string IsAdmin { get; set; }
    }
}

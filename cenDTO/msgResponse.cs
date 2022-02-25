using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cenDTO
{
    public class msgResponse
    {
        public string Status { get; set; } //00: OK, 01: Error
        public string Data { get; set; } //Du lieu
        public string Message { get; set; } //Thong bao
    }
}

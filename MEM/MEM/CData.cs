using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEM
{
    class CData
    {
        public string hospital_id { get; set; }
        public string hospital_name { get; set; }
        public string servlet_ip { get; set; }
        public string servlet_ip_2 { get; set; }
        public string license_key_no { get; set; }

        public void Clear()
        {
            hospital_id = "";
            hospital_name = "";
            servlet_ip = "";
            servlet_ip_2 = "";
            license_key_no = "";
        }


    }
}

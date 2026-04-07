using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEM
{
    class CDataSub
    {
        public string license_key_no { get; set; }
        public string hospital_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }

        public void Clear()
        {
            license_key_no = "";
            hospital_id = "";
            start_date = "";
            end_date = "";
        }
    }
}

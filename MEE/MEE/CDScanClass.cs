using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEE
{
    class CDScanClass
    {
        public String scanClass;
        public String scanClassName;

        public String displayScanClassName
        {
            get
            {
                return scanClass + " " + scanClassName;
            }
        }
    }
}

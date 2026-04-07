using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEE
{
    class CServer
    {
        private static String m_ServerIp;
        //public static String serverIp = "180.70.20.24";
        public static String serverIp
        {
            get 
            {
                String retValue = m_ServerIp;
                if (retValue.Equals("")) retValue = "180.70.20.24";
                String[] arr = (retValue + ":").Split(':');
                if (arr[1].Equals("")) retValue += ":8080";
                return retValue; 
            }
            set
            {
                m_ServerIp = value;
            }
        }
        public static String hospitalId = "";

        
    }
}

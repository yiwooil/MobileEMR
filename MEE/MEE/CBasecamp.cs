using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Json;
using System.Text;

namespace MEE
{
    class CBasecamp
    {
        public List<string> GetHospitalList()
        {
            List<string> retList = new List<string>();

            String url = "http://180.70.20.24:8080/emrdroid/servlet/BasecampServlet?mode=hospitallist&wifimacaddress=&licensekeyno=metro-soft-dev";
            WebClient webClient = new WebClient();
            webClient.BaseAddress = url;
            webClient.Encoding = System.Text.Encoding.UTF8;
            string ret = webClient.DownloadString(url);

            // 파싱
            JsonTextParser parser = new JsonTextParser();
            JsonObject obj = parser.Parse(ret);
            JsonArrayCollection main = (JsonArrayCollection)obj;
            JsonArrayCollection control = (JsonArrayCollection)main[0];
            JsonObjectCollection ctrl = (JsonObjectCollection)control[0];

            string returnDesc = (string)ctrl["return_desc"].GetValue();
            double returnCode = (double)ctrl["return_code"].GetValue();
            if (returnCode < 0)
            {
                // 오류.
                return null;
            }
            else if (returnCode == 0)
            {
                // 자료없음.
                return null;
            }
            else
            {
                // 자료있음.
                int cnt = (int)returnCode;
                JsonArrayCollection data = (JsonArrayCollection)main[1];
                JsonObjectCollection dtRow = null;
                for (int i = 0; i < cnt; i++)
                {
                    dtRow = (JsonObjectCollection)data[i];
                    if ((string)dtRow["servlet_ip"].GetValue() == "") continue;
                    string hos = ((string)dtRow["servlet_ip"].GetValue()).Replace("http://", "") + " " + (string)dtRow["hospital_name"].GetValue();

                    retList.Add(hos);
                }
                return retList;
            }
        }
    }
}

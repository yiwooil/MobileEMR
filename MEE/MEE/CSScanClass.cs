using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Json;
using System.Text;

namespace MEE
{
    class CSScanClass
    {
        public String errorMessage;
        public List<CDScanClass> m_ScanClassList;

        private String serverUrl
        {
            get
            {
                String url = "http://" + CServer.serverIp + "/emrdroid/servlet";
                return url;
            }
        }

        private String hospitalId
        {
            get
            {
                return CServer.hospitalId;
            }
        }

        public Boolean getData()
        {
            try
            {
                errorMessage = "";

                m_ScanClassList = null;
                m_ScanClassList = new List<CDScanClass>();


                // 결과 읽어오기
                string url = "";
                url += serverUrl + "/CommonCodeServlet";
                url += "?mode=3";
                url += "&hospitalid=" + hospitalId;
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
                    errorMessage = returnDesc;
                    return false;
                }
                else if (returnCode == 0)
                {
                    // 자료없음.
                    return true;
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
                        CDScanClass scanClass = new CDScanClass();
                        scanClass.scanClass = (string)dtRow["scan_class"].GetValue();
                        scanClass.scanClassName = (string)dtRow["scan_class_name"].GetValue();

                        m_ScanClassList.Add(scanClass);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}

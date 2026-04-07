using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Json;
using System.Text;

namespace MEE
{
    class CSCcfPaper
    {

        public String errorMessage;
        public String m_url;
        public string m_FileName;
        public CDCcfValues m_CcfValues;

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

        public Boolean getData(String ccfId)
        {
            try
            {
                errorMessage = "";

                m_url = "";


                // 결과 읽어오기
                string url = "";
                url += serverUrl + "/CertificatePaperServlet";
                url += "?mode=1";
                url += "&hospitalid=" + hospitalId;
                url += "&ccfid=" + ccfId;
                url += "&no_fill=Y";
                WebClient webClient = new WebClient();
                webClient.BaseAddress = url;
                webClient.Encoding = System.Text.Encoding.UTF8;
                string ret = webClient.DownloadString(url);

                m_url = ret;

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public Boolean getDataImage(String ccfId)
        {
            try
            {
                errorMessage = "";

                m_FileName = "";

                string tempFolderPath = System.IO.Path.GetTempPath();
                String downloadFolder = tempFolderPath;
                m_FileName = downloadFolder + ccfId;

                // 결과 읽어오기
                string url = "";
                url += serverUrl + "/EmrScanServlet";
                url += "?mode=8";
                url += "&hospitalid=" + hospitalId;
                url += "&ccfid=" + ccfId;
                WebClient webClient = new WebClient();
                webClient.BaseAddress = url;
                webClient.Encoding = System.Text.Encoding.UTF8;
                webClient.DownloadFile(url, m_FileName);

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }

        public Boolean getDataValue(String ccfId)
        {
            try
            {
                errorMessage = "";

                m_CcfValues = new CDCcfValues();

                // 결과 읽어오기
                string url = "";
                url += serverUrl + "/CertificatePaperServlet";
                url += "?mode=11";
                url += "&hospitalid=" + hospitalId;
                url += "&ccfid=" + ccfId;
                url += "&pid=";
                url += "&bededt=";

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
                        String ccfField = (String)dtRow["ccf_field"].GetValue();
                        String ccfX = (String)dtRow["ccf_x"].GetValue();
                        String ccfY = (String)dtRow["ccf_y"].GetValue();
                        String ccfW = (String)dtRow["ccf_w"].GetValue();
                        String ccfH = (String)dtRow["ccf_h"].GetValue();
                        String ccfValue = (String)dtRow["ccf_value"].GetValue();
                        String ccfAutoFit = (String)dtRow["ccf_auto_fit"].GetValue();

                        m_CcfValues.addCcfValue(ccfField, ccfX, ccfY, ccfW, ccfH, ccfAutoFit);
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

        public Boolean saveItems(String ccfId, String itemString)
        {
            try
            {
                errorMessage = "";


                // 결과 읽어오기
                string url = "";
                url += serverUrl + "/CertificatePaperServlet";
                url += "?mode=12";
                url += "&hospitalid=" + hospitalId;
                url += "&ccfid=" + ccfId;
                url += "&ccfitems=" + itemString;

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
                    return false;
                }
                else
                {
                    // 자료있음.
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

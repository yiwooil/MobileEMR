using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MEE
{
    class CSFileUpload
    {
        public String errorMessage;

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

        public Boolean putData(String filePath)
        {
            try
            {
                errorMessage = "";

                string url = "";
                url += serverUrl + "/FileUploadServlet";
                url += "?hospital_id=" + hospitalId;
                url += "&file_type=ccf";
                WebClient webClient = new WebClient();
                webClient.BaseAddress = url;
                webClient.Encoding = System.Text.Encoding.UTF8;
                byte[] retByte = webClient.UploadFile(url, "POST", filePath);
                String retString = Encoding.UTF8.GetString(retByte);

                return true;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }

        }
    }
}

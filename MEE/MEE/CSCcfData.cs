using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Json;
using System.Text;

namespace MEE
{
    class CSCcfData
    {
        public String errorMessage;
        public List<CDCcfData> m_CcfDataList;

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

                m_CcfDataList = null;
                m_CcfDataList = new List<CDCcfData>();


                // 결과 읽어오기
                string url = "";
                url += serverUrl + "/CertificatePaperServlet";
                url += "?mode=0";
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
                        String ccfGroup = (string)dtRow["ccf_group"].GetValue();
                        String[] aCcfGroup = ccfGroup.Split(';');
                        for (int ii = 0; ii < aCcfGroup.Length; ii++)
                        {

                            CDCcfData ccfData = new CDCcfData();
                            ccfData.ccfId = (string)dtRow["ccf_id"].GetValue();
                            ccfData.ccfName = (string)dtRow["ccf_name"].GetValue();
                            ccfData.ccfFileName = (string)dtRow["ccf_filename"].GetValue();
                            ccfData.ccfGroup = aCcfGroup[ii];// (string)dtRow["ccf_group"].GetValue();
                            ccfData.ccfGroupValue = (string)dtRow["ccf_group"].GetValue();
                            ccfData.subPageList = (string)dtRow["sub_page_list"].GetValue();
                            ccfData.subPageNo = (string)dtRow["sub_page_no"].GetValue();
                            ccfData.hxType = (string)dtRow["hx_type"].GetValue();
                            ccfData.emrScanClass = (string)dtRow["emr_scan_class"].GetValue();
                            ccfData.emrScanClassName = (string)dtRow["emr_scan_class_name"].GetValue();

                            m_CcfDataList.Add(ccfData);
                        }
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

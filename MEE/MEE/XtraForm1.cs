using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;

using PdfiumViewer;

namespace MEE
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        private Boolean OnPgm = false;
        private Dictionary<String, String> m_FieldText = new Dictionary<string, string>();

        public XtraForm1()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));

            //String latestSetupFile = checkVersion();
            String latestSetupFile = ""; // 버전체크기능을 끔
            if (latestSetupFile != "")
            {
                SplashScreenManager.CloseForm();

                MessageBox.Show("버전이 변경되었습니다. 최신버전을 설치합니다.");

                // 셋업파일 실행
                System.Diagnostics.ProcessStartInfo run = new System.Diagnostics.ProcessStartInfo();
                run.FileName = latestSetupFile;
                System.Diagnostics.Process.Start(run);

                Environment.Exit(0);
                this.Close();
                return;
            }

            InitializeComponent();

            //webBrowser1.Width = 800;
            //webBrowser1.Height = 1010;

            panMain.Width = 800;
            panMain.Height = 1122;


            this.loadServerIp();
            if (CServer.serverIp == "")
            {
                this.saveServerIp(false);
            }
            this.initHosCombo();
            this.initTreeList();

            // 필드버튼 생성
            makeItemButtons();

            SplashScreenManager.CloseForm();
        }

        private void makeItemButtons()
        {

            // 지우고
            xtraScrollableControl2.Controls.Clear();
            m_FieldText.Clear();

            CSCcfItemList server = new CSCcfItemList();
            if (server.getData() == true)
            {
                for (int i = 0; i < server.m_CcfItemList.Count; i++)
                {
                    String btnTag = server.m_CcfItemList[i].ccf_field;
                    SimpleButton btn = new SimpleButton();
                    xtraScrollableControl2.Controls.Add(btn);

                    btn.Tag = btnTag;
                    btn.Text = server.m_CcfItemList[i].ccf_field_text;
                    btn.Left = 5;
                    btn.Top = (i * 30);
                    btn.Width = xtraScrollableControl2.Width - 10;
                    btn.Height = 25;
                    btn.Click += new EventHandler(btnItem_Click);

                    m_FieldText.Add(server.m_CcfItemList[i].ccf_field, server.m_CcfItemList[i].ccf_field_text);

                }
                return;
            }

            /*
            String[] btnArray = null;
            btnArray = new String[] {"pid", "pnm", "resid", "bthdt", "age", "psex", "addr", "htelno", "otelno", "ntelno", "bededt", "qfynm", "ibdyy", "ibdmm", "ibddd", "dptnm", "drnm", "drsign", "logindrnm", "logindrsign", "ward", "wardnm", "rmid", "dxd", "rsvop", "rsvdacd", "rsvopdt", "rsvopdptnm", "rsvopdrnm", "rsvopdt_ymd", "rsvop_2nd", "yy", "mm", "dd", "hhhh", "mmmm", "ssss" };

            // 지우고
            xtraScrollableControl2.Controls.Clear();
            // 다시만든다.
            int aryCount = btnArray.Length;
            for (int i = 0; i < aryCount; i++)
            {
                String btnTag = btnArray[i];
                SimpleButton btn = new SimpleButton();
                xtraScrollableControl2.Controls.Add(btn);

                btn.Tag = btnTag;
                btn.Text = getFieldText(btnTag);
                btn.Left = 5;
                btn.Top = (i * 30);
                btn.Width = xtraScrollableControl2.Width - 10;
                btn.Height = 25;
                btn.Click+=new EventHandler(btnItem_Click);
            }

            // 나무병원 전용
            if ("0051".Equals(CServer.hospitalId))
            {
                String[] arr_0051 = null;
                arr_0051 = new String[] { 
                    "dischk1", "disetc1", 
                    "dischk2", "disetc2", 
                    "dischk3", "disetc3", 
                    "dischk4", "disetc4", 
                    "dischk5", "disetc5", 
                    "dischk6", "disetc6", 
                    "dischk7", "disetc7", 
                    "dischk8", "disetc8", 
                    "dischk9", "disetc9", 
                    "dischk10", "disetc10", 
                    "dischk11", "disetc11", 
                    "dischk12", "disetc12", 
                    "opration","opretc", 
                    "medchk1", "medetc1", 
                    "medchk2", "medetc2", 
                    "medchk3", "medetc3", 
                    "specchk1", "specetc1", 
                    "specchk5", "specetc5", 
                    "specchk2", 
                    "specchk3",
                    "esigned",
                    "nonmed", "stopdt",
                    "namu_rsvdt"
                     };

                int ary_0051_Count = arr_0051.Length;
                for (int i = 0; i < ary_0051_Count; i++)
                {
                    String btnTag = arr_0051[i];
                    SimpleButton btn = new SimpleButton();
                    xtraScrollableControl2.Controls.Add(btn);

                    btn.Tag = btnTag;
                    btn.Text = getFieldText(btnTag);
                    btn.Left = 5;
                    btn.Top = ((aryCount + i) * 30);
                    btn.Width = xtraScrollableControl2.Width - 10;
                    btn.Height = 25;
                    btn.Click += new EventHandler(btnItem_Click);
                }
            }

            // 백두병원 전용
            if ("0134".Equals(CServer.hospitalId))
            {
                String[] arr_0134 = null;
                arr_0134 = new String[] { 
                    "bd_1591_5",
                    "bd_1591_9",
                    "bd_1591_22",
                    "bd_1591_23",
                    "bd_1591_11",
                    "bd_1591_14",
                    "bd_1591_15",
                    "bd_1591_24",

                    // 2022.01.02 WOOIL - 이하 마취전 환자 평가표
                    "bd2_rptdt",
                    "bd2_rpttm",
                    "bd2_opdt",
                    "bd2_opnm",
                    "bd2_dxnm",
                    "bd2_preop1",
                    "bd2_preop2",
                    "bd2_preop3",
                    "bd2_preop4",
                    "bd2_preop5",
                    "bd2_preop6",
                    "bd2_preop7",
                    "bd2_bmi",
                    "bd2_gumsa1",
                    "bd2_gumsa2",
                    "bd2_gumsa3",
                    "bd2_gumsa4",
                    "bd2_gumsa5",
                    "bd2_gumsa6",
                    "bd2_gumsa7",
                    "bd2_gumsa8",
                    "bd2_gumsa9",
                    "bd2_gumsa10",
                    "bd2_gumsa11",
                    "bd2_gumsa12",
                    "bd2_gumsa13",
                    "bd2_rh",
                    "bd2_dise1",
                    "bd2_dise2",
                    "bd2_dise3",
                    "bd2_dise4",
                    "bd2_dise5",
                    "bd2_dise6",
                    "bd2_dise7",
                    "bd2_disetxt",
                    "bd2_ophis",
                    "bd2_ophistxt",
                    "bd2_bigo",
                    "bd2_asa1",
                    "bd2_asa2",
                    "bd2_asa3",
                    "bd2_asa4",
                    "bd2_asa5",
                    "bd2_asa6",
                    "bd2_mallampati1",
                    "bd2_mallampati2",
                    "bd2_mallampati3",
                    "bd2_mallampati4",
                    "bd2_aneplan1",
                    "bd2_aneplan2",
                    "bd2_aneplan3",
                    "bd2_aneplan4",
                    "bd2_aneplan5",
                    "bd2_aneplan6",
                    "bd2_drug_allergy1",
                    "bd2_drug_allergy2",
                    "bd2_medication1",
                    "bd2_medication2",
                    "bd2_drug_his",
                    "bd2_neck_ex1",
                    "bd2_neck_ex2",
                    "bd2_mouth1",
                    "bd2_mouth2",
                    "bd2_teeth_ex1",
                    "bd2_teeth_ex2",
                    "bd2_alcoh1",
                    "bd2_alcoh2",
                    "bd2_alcoh3",
                    "bd2_smoke1",
                    "bd2_smoke2",
                    "bd2_smoke3",
                    "bd2_neck",
                    "bd2_anedrnm"
                     };

                int ary_0134_Count = arr_0134.Length;
                for (int i = 0; i < ary_0134_Count; i++)
                {
                    String btnTag = arr_0134[i];
                    SimpleButton btn = new SimpleButton();
                    xtraScrollableControl2.Controls.Add(btn);

                    btn.Tag = btnTag;
                    btn.Text = getFieldText(btnTag);
                    btn.Left = 5;
                    btn.Top = ((aryCount + i) * 30);
                    btn.Width = xtraScrollableControl2.Width - 10;
                    btn.Height = 25;
                    btn.Click += new EventHandler(btnItem_Click);
                }
            }

            // 2023.12.12 WOOIL - 비급여 동의서
            String[] arr_bi_dong = new String[] { 
                "bi_no_1","bi_onm_1","bi_gumak_1",
                "bi_no_2","bi_onm_2","bi_gumak_2",
                "bi_no_3","bi_onm_3","bi_gumak_3",
                "bi_no_4","bi_onm_4","bi_gumak_4",
                "bi_no_5","bi_onm_5","bi_gumak_5",
                "bi_no_6","bi_onm_6","bi_gumak_6",
                "bi_no_7","bi_onm_7","bi_gumak_7",
                "bi_no_8","bi_onm_8","bi_gumak_8",
                "bi_no_9","bi_onm_9","bi_gumak_9",
                "bi_no_10","bi_onm_10","bi_gumak_10",
                "bi_no_11","bi_onm_11","bi_gumak_11",
                "bi_no_12","bi_onm_12","bi_gumak_12",
                "bi_no_13","bi_onm_13","bi_gumak_13",
                "bi_no_14","bi_onm_14","bi_gumak_14",
                "bi_no_15","bi_onm_15","bi_gumak_15",
                "bi_gumak_tot"
            };
            int ary_bi_dong_Count = arr_bi_dong.Length;
            for (int i = 0; i < ary_bi_dong_Count; i++)
            {
                String btnTag = arr_bi_dong[i];
                SimpleButton btn = new SimpleButton();
                xtraScrollableControl2.Controls.Add(btn);

                btn.Tag = btnTag;
                btn.Text = getFieldText(btnTag);
                btn.Left = 5;
                btn.Top = ((aryCount + i) * 30);
                btn.Width = xtraScrollableControl2.Width - 10;
                btn.Height = 25;
                btn.Click += new EventHandler(btnItem_Click);
            }
            */
        }

        private void showReadMe()
        {
            /*
            // 셋업후 최초 한번 수정내역을 보여주도록 하기 위함임.
            string readMeFilePath = Application.StartupPath + "/readme.txt";
            if (File.Exists(readMeFilePath) == false) return; // 파일이 없으면 종료.
            String version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); // 이 프로그램의 버전
            String readReadMeVersion = getReadReadMeVersion(); // readme를 어느 버번까지 읽었는지
            if (version == readReadMeVersion) return; // 이미 읽었음.
            ReadMeForm f = new ReadMeForm();
            f.ShowDialog();
            saveReadReadMeVersion(version); // 읽었음 표시.
            */
        }

        String checkVersion()
        {
            // 컴파일시 버전을 변경하는 방법
            // AssemblyInfo.cs에서 변경함.

            // 버전을 검사한다.
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            String latestVersion = "";
            CSVersionInfo server = new CSVersionInfo();
            if (server.getData() == false)
            {
                //
                return "";
            }
            else
            {
                latestVersion = server.m_VersionInfo.versionNo;
            }
            if (version == latestVersion) return ""; // 최신상태임'
            // 임시폴더
            string tempFolderPath = System.IO.Path.GetTempPath();
            String downloadFolder = tempFolderPath;
            String downloadFile = downloadFolder + "meesetup.msi";
            // setup파일을 다운로드한다.
            WebClient webClient = new WebClient();
            Uri uri = new Uri("http://www.metrosoft.co.kr/mee/meesetup.msi");
            webClient.DownloadFile(uri, downloadFile);

            return downloadFile;
        }

        private void loadServerIp()
        {
            // 저장된 서버IP를 불러온다.
            try
            {
                bool isServerElement = false;

                string ip = "";

                string xmlFilePath = Application.StartupPath + "/mee.xml";
                FileInfo fi = new FileInfo(xmlFilePath);
                if (fi.Exists == true)
                {
                    XmlTextReader xmlTextReader = new XmlTextReader(xmlFilePath);
                    string sName = "";
                    while (xmlTextReader.Read())
                    {
                        switch (xmlTextReader.NodeType)
                        {
                            case XmlNodeType.EndElement:
                                if (xmlTextReader.Name == "server")
                                {
                                    isServerElement = false;
                                }
                                break;
                            case XmlNodeType.Element:
                                if (isServerElement == true)
                                {
                                    sName = xmlTextReader.Name;
                                }
                                else if (xmlTextReader.Name == "server")
                                {
                                    isServerElement = true;
                                }

                                break;
                            case XmlNodeType.Text:
                                switch (sName)
                                {
                                    case "ip":
                                        ip = xmlTextReader.Value;
                                        break;
                                }
                                break;
                        }
                    }
                    xmlTextReader.Close();
                }

                CServer.serverIp = ip;
                lblServer.Text = CServer.serverIp;
                if (lblServer.Text == "") lblServer.Text = "서버IP";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveServerIp(bool combo)
        {
            // 저장된 서버IP를 불러온다.
            try
            {
                String newIp = CServer.serverIp;

                DialogResult result;
                if (combo == false)
                {
                    result = InputBox.ShowBox("주소", "서버IP를 입력하세요", ref newIp);
                }
                else
                {
                    result = InputBox.ShowHosListBox("주소", "병원을 선택하세요", ref newIp);
                    newIp = newIp.Split(' ')[0];
                }
                if (result == DialogResult.Cancel) return;
                if (newIp == CServer.serverIp) return;
                if (newIp == "") return;

                CServer.serverIp = newIp;
                lblServer.Text = CServer.serverIp;

                string xmlFilePath = Application.StartupPath + "/mee.xml";
                if (File.Exists(xmlFilePath) == false)
                {
                    // 파일이 없으면 새로 생성
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(xmlFilePath, null);
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlTextWriter.WriteStartDocument();
                    xmlTextWriter.WriteStartElement("server");
                    // 서버IP
                    xmlTextWriter.WriteStartElement("ip");
                    xmlTextWriter.WriteString(newIp);
                    xmlTextWriter.WriteEndElement();
                    //
                    xmlTextWriter.WriteEndElement();
                    xmlTextWriter.WriteEndDocument();
                    xmlTextWriter.Flush();
                    xmlTextWriter.Close();
                }
                else
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(xmlFilePath);

                    XmlNode firstNode = xmlDoc.DocumentElement; // server임.
                    XmlNode ipNode = firstNode.SelectSingleNode("ip");
                    if(ipNode!=null) firstNode.RemoveChild(ipNode); // 기존내역삭제
                    firstNode.AppendChild(createNode(xmlDoc, "ip", newIp)); // 새로운 값으로 추가

                    xmlDoc.Save(xmlFilePath);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String getReadReadMeVersion()
        {
            // 저장된 서버IP를 불러온다.
            try
            {
                bool isServerElement = false;

                string readReadMeVersion = "";

                string xmlFilePath = Application.StartupPath + "/mee.xml";
                FileInfo fi = new FileInfo(xmlFilePath);
                if (fi.Exists == true)
                {
                    XmlTextReader xmlTextReader = new XmlTextReader(xmlFilePath);
                    string sName = "";
                    while (xmlTextReader.Read())
                    {
                        switch (xmlTextReader.NodeType)
                        {
                            case XmlNodeType.EndElement:
                                if (xmlTextReader.Name == "server")
                                {
                                    isServerElement = false;
                                }
                                break;
                            case XmlNodeType.Element:
                                if (isServerElement == true)
                                {
                                    sName = xmlTextReader.Name;
                                }
                                else if (xmlTextReader.Name == "server")
                                {
                                    isServerElement = true;
                                }

                                break;
                            case XmlNodeType.Text:
                                switch (sName)
                                {
                                    case "readreadmeversion":
                                        readReadMeVersion = xmlTextReader.Value;
                                        break;
                                }
                                break;
                        }
                    }
                    xmlTextReader.Close();
                }

                return readReadMeVersion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }

        private XmlNode createNode(XmlDocument xmlDoc, String name, String innerXml)
        {
            XmlNode node = xmlDoc.CreateElement(name);
            node.InnerXml = innerXml;

            return node;
        }

        private void saveReadReadMeVersion(String readReadMeVersion)
        {
            // 
            try
            {

                string xmlFilePath = Application.StartupPath + "/mee.xml";
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(xmlFilePath);

                XmlNode firstNode = xmlDoc.DocumentElement; // server임.
                XmlNode node = firstNode.SelectSingleNode("readreadmeversion");
                if(node!=null) firstNode.RemoveChild(node); // 기존내역삭제
                firstNode.AppendChild(createNode(xmlDoc, "readreadmeversion", readReadMeVersion)); // 새로 추가

                xmlDoc.Save(xmlFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowProgressForm(String caption, String description)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormCaption(caption);
            DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription(description);
        }

        private void CloseProgressForm(String caption, String description)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm(false);
        }


        private void initHosCombo()
        {
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit1.Text = "";

            CSHospitalData server = new CSHospitalData();
            if (server.getData() == false)
            {
                MessageBox.Show(server.errorMessage);
                return;
            }
            List<CDHospitalData> hospitalDataList = server.m_HospitalDataList;
            ComboBoxItemCollection items = comboBoxEdit1.Properties.Items;
            items.BeginUpdate();
            for (int i = 0; i < hospitalDataList.Count; i++)
            {
                items.Add(hospitalDataList[i]);
            }
            items.EndUpdate();
            OnPgm = true;
            comboBoxEdit1.SelectedIndex = 0;
            OnPgm = false;
            CServer.hospitalId = hospitalDataList[0].hospitalId;
        }

        private void initTreeList()
        {
            String[] tvwLocationColumns = { "명칭" };
            treeList1.Nodes.Clear();
            treeList1.BeginUpdate();
            for (int i = 0; i < tvwLocationColumns.Length; i++)
            {
                treeList1.Columns.Add();
                treeList1.Columns[i].Caption = tvwLocationColumns[i];
                treeList1.Columns[i].VisibleIndex = i;
            }
            treeList1.EndUpdate();

            List<CDCcfGroup> ccfGroupList = GetCcfGroupList();
            if (ccfGroupList == null) return;
            List<CDCcfData> ccfDataList = GetCcfDataList();
            if (ccfDataList == null) return;

            for (int i = 0; i < ccfGroupList.Count; i++)
            {
                TreeListNode node = treeList1.AppendNode(new object[] { ccfGroupList[i].ccfGroup}, null);

                for (int j = 0; j < ccfDataList.Count; j++)
                {
                    if (ccfGroupList[i].ccfGroup == ccfDataList[j].ccfGroup)
                    {
                        TreeListNode subNode = treeList1.AppendNode(new object[] { ccfDataList[j].ccfName }, node);
                        //subNode.Tag = ccfDataList[j].ccfId;
                        subNode.Tag = ccfDataList[j];
                    }
                }
            }
            treeList1.ExpandAll();

        }

        private List<CDCcfGroup> GetCcfGroupList()
        {
            CSCcfGroup server = new CSCcfGroup();
            if (server.getData() == true)
            {
                return server.m_CcfGroupList;
            }
            else
            {
                MessageBox.Show(server.errorMessage);
                return null;
            }
        }

        private List<CDCcfData> GetCcfDataList()
        {
            CSCcfData server = new CSCcfData();
            if (server.getData() == true)
            {
                return server.m_CcfDataList;
            }
            else
            {
                MessageBox.Show(server.errorMessage);
                return null;
            }
        }

        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            panMain.Controls.Clear();
            panMain.BackgroundImage = null;
            lblEmrScanClass.Text = "";

            TreeListNode selectedNode = treeList1.FocusedNode;
            if (selectedNode == null) return;

            CDCcfData ccfData = (CDCcfData)selectedNode.Tag;
            if (ccfData == null) return;

            String ccfId = ccfData.ccfId;
            String emrScanClass = ccfData.emrScanClass;
            String emrScanClassName = ccfData.emrScanClassName;

            lblEmrScanClass.Text = emrScanClass + " " + emrScanClassName;
            if (ccfData.hxType != "") lblEmrScanClass.Text += "(" + ccfData.hxType + ")";

            if (ccfId == null) return;
            if (ccfId == "") return;

            if (checkButton1.Checked) return;

            /*
            CSCcfPaper server = new CSCcfPaper();
            if (server.getData(ccfId) == true)
            {
                webBrowser1.DocumentText = server.m_url;
            }
            else
            {
                MessageBox.Show(server.errorMessage);
            }
            */

            ShowProgressForm("", "자료조회중입니다.");

            panMain.Controls.Clear();

            // 동의서 이미지를 불러온다.
            CSCcfPaper server = new CSCcfPaper();
            if (server.getDataImage(ccfId) == true)
            {
                try
                {
                    panMain.Width = 800;
                    panMain.Height = 1122;

                    if (panMain.BackgroundImage != null)
                    {
                        Image oldImage = panMain.BackgroundImage;
                        panMain.BackgroundImage = null;
                        oldImage.Dispose();
                    }
                    using (Image img = Image.FromFile(server.m_FileName))
                    {
                        //MessageBox.Show("w=" + img.Width + ", h=" + img.Height);
                        Image image = (Image)(new Bitmap(img, 800, 1122));
                        //panMain.Width = image.Width;
                        //panMain.Height = image.Height;
                        panMain.BackgroundImage = image;
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (panMain.BackgroundImage != null)
                        {
                            Image oldImage = panMain.BackgroundImage;
                            panMain.BackgroundImage = null;
                            oldImage.Dispose();
                        }

                        using (var document = PdfDocument.Load(server.m_FileName))
                        {
                            var size = document.PageSizes[0]; // 문서의 크기를 구한다.
                            float pdfWidth = size.Width;
                            float pdfHeight = size.Height;

                            int width = panMain.Width;
                            int height = (int)(pdfHeight / pdfWidth * width);

                            width = (int)pdfWidth;
                            height = (int)pdfHeight;

                            panMain.Width = width;
                            panMain.Height = height;


                            Image img = document.Render(0, width, height, 96, 96, PdfRenderFlags.Annotations);
                            panMain.BackgroundImage = img;
                        }
                    }
                    catch (Exception ex1)
                    {
                        CloseProgressForm("", "자료조회중입니다.");
                        MessageBox.Show(ex1.Message);
                        return;
                    }
                }
            }
            else
            {
                CloseProgressForm("", "자료조회중입니다.");
                MessageBox.Show(server.errorMessage);
                return;
            }


            // 동의서 이미지에 출력될 값을 올린다.
            if (server.getDataValue(ccfId) == true)
            {
                CDCcfValues ccfValues = server.m_CcfValues;
                int cnt = ccfValues.getCount();
                for (int i = 0; i < cnt; i++)
                {
                    MoveableBorderedLabel label = new MoveableBorderedLabel();
                    label.Left = (int)ccfValues.getX(i);
                    label.Top = (int)ccfValues.getY(i);
                    label.Height = (int)ccfValues.getH(i) > 0 ? (int)ccfValues.getH(i) : 14;
                    label.Width = (int)ccfValues.getW(i) > 0 ? (int)ccfValues.getW(i) : 100;
                    label.setText(getFieldText(ccfValues.getField(i)));
                    label.Field = ccfValues.getField(i);
                    label.AutoFit = ccfValues.getAutoFit(i);
                    label.TypeName = ccfValues.getTypeName(i);
                    label.GroupName = ccfValues.getGroupName(i);
                    label.BackColor = Color.Pink;
                    label.Visible = true;

                    string tooltipmsg = getFieldText(label.Field);
                    toolTip1.SetToolTip(label, tooltipmsg);
                    toolTip1.SetToolTip(label.InnerLabel, tooltipmsg);

                    label.MovedResized += new MoveableBorderedPanel.MovedResizedHandler(label_MovedResized);
                    label.MouseDown += new MouseEventHandler(label_MouseDown);
                    label.PreviewKeyDown += new PreviewKeyDownEventHandler(label_PreviewKeyDown);

                    panMain.Controls.Add(label);
                }
            }
            else
            {
                MessageBox.Show(server.errorMessage);
            }

            CloseProgressForm("", "자료조회중입니다.");
            
        }

        void label_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (MoveableBorderedLabel ctrl in panMain.Controls)
            {
                MoveableBorderedLabel lbl = ctrl as MoveableBorderedLabel;
                if (lbl == null) continue;
                ctrl.BackColor = Color.Pink;
            }

            MoveableBorderedLabel label = sender as MoveableBorderedLabel;
            if (label == null) return;

            label.BackColor = Color.LightBlue;
            //
            txtName.Text = label.Field;
            txtLeft.Text = label.Left.ToString();
            txtTop.Text = label.Top.ToString();
            txtWidth.Text = label.Width.ToString();
            txtHeight.Text = label.Height.ToString();
            chkAutoFit.Checked = label.AutoFit == "true";
            cboTypeName.Text = label.TypeName == null ? "" : label.TypeName;
            txtGroupName.Text = label.GroupName;
        }

        void label_MovedResized(object sender, MovedResizedEventArgs e)
        {
            MoveableBorderedLabel label = sender as MoveableBorderedLabel;
            if (e.GetMoveOrResize() == MovedResizedEventArgs.MOVE)
            {
                if (e.GetDirection() == MovedResizedEventArgs.LEFT)
                {
                    label.Left -= e.GetValue();
                }
                else if (e.GetDirection() == MovedResizedEventArgs.RIGHT)
                {
                    label.Left += e.GetValue();
                }
                else if (e.GetDirection() == MovedResizedEventArgs.UP)
                {
                    label.Top -= e.GetValue();
                }
                else if (e.GetDirection() == MovedResizedEventArgs.DOWN)
                {
                    label.Top += e.GetValue();
                }
            }
            else
            {
                if (e.GetDirection() == MovedResizedEventArgs.LEFT)
                {
                    label.Width -= e.GetValue();
                }
                else if (e.GetDirection() == MovedResizedEventArgs.RIGHT)
                {
                    label.Width += e.GetValue();
                }
                else if (e.GetDirection() == MovedResizedEventArgs.UP)
                {
                    label.Height -= e.GetValue();
                }
                else if (e.GetDirection() == MovedResizedEventArgs.DOWN)
                {
                    label.Height += e.GetValue();
                }
            }
        }

        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnPgm) return;
            CDHospitalData hospitalData = (CDHospitalData)comboBoxEdit1.Properties.Items[comboBoxEdit1.SelectedIndex];
            CServer.hospitalId = hospitalData.hospitalId;

            this.initTreeList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            TreeListNode selectedNode = treeList1.FocusedNode;
            if (selectedNode == null) return;
            CDCcfData ccfData = (CDCcfData)selectedNode.Tag;
            if (ccfData == null) return;

            String ccfId = (String)ccfData.ccfId;
            if (ccfId == null) return;
            if (ccfId == "") return;

            CSCcfSave server = new CSCcfSave();
            if (server.setOrderUp(ccfId) == true)
            {
                this.initTreeList();
            }
            else
            {
                MessageBox.Show(server.errorMessage);
            }
            // 포커스를 주자
            setFocusTreeList(ccfId);
        }

        private void setFocusTreeList(String ccfId)
        {
            int nodeCount = treeList1.Nodes.Count;
            for (int i = 0; i < nodeCount; i++)
            {
                if (setFocusTreeList2(treeList1.Nodes[i], ccfId) == true) break;
            }
        }

        private Boolean setFocusTreeList2(TreeListNode treeNode, String ccfId)
        {
            foreach (TreeListNode tn in treeNode.Nodes)
            {
                CDCcfData ccfData = (CDCcfData)tn.Tag;
                if (ccfData == null) continue;

                String tnTag = (String)ccfData.ccfId;
                if (tnTag != null)
                {
                    if (tnTag == ccfId)
                    {
                        tn.Selected = true;
                        return true;
                    }
                }
                if (setFocusTreeList2(tn, ccfId) == true) return true;
            }
            return false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            TreeListNode selectedNode = treeList1.FocusedNode;
            if (selectedNode == null) return;
            CDCcfData ccfData = (CDCcfData)selectedNode.Tag;
            if (ccfData == null) return;

            String ccfId = (String)ccfData.ccfId;
            if (ccfId == null) return;
            if (ccfId == "") return;

            CSCcfSave server = new CSCcfSave();
            if (server.setOrderDown(ccfId) == true)
            {
                this.initTreeList();
            }
            else
            {
                MessageBox.Show(server.errorMessage);
            }
            // 포커스를 주자
            setFocusTreeList(ccfId);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            TreeListNode selectedNode = treeList1.FocusedNode;
            if (selectedNode == null) return;
            CDCcfData ccfData = (CDCcfData)selectedNode.Tag;
            if (ccfData == null) return;

            String ccfId = (String)ccfData.ccfId;
            if (ccfId == null) return;
            if (ccfId == "") return;

            String ccfGroup = ccfData.ccfGroupValue;
            String hxType = ccfData.hxType;

            XtraForm5 f = new XtraForm5();
            f.m_ccfGroup = ccfGroup;
            f.m_hxType = hxType;

            f.ShowDialog(this);

            bool isOk = f.m_isOK;
            String newCcfGroup = f.m_ccfGroup;
            String newHxType = f.m_hxType;

            f = null;


            //DialogResult result = InputBox.ShowBox("그룹", "새로운 그룹", ref newCcfGroup);
            //if (result == DialogResult.Cancel) return;
            //if (ccfGroup == newCcfGroup) return;

            if (isOk == true)
            {
                CSCcfSave server = new CSCcfSave();
                if (server.setGroup(ccfId, newCcfGroup, newHxType) == true)
                {
                    this.initTreeList();
                }
                else
                {
                    MessageBox.Show(server.errorMessage);
                }
                // 포커스를 주자
                setFocusTreeList(ccfId);
            }
        }

        private void simpleButton21_Click(object sender, EventArgs e)
        {
            TreeListNode selectedNode = treeList1.FocusedNode;
            if (selectedNode == null) return;
            CDCcfData ccfData = (CDCcfData)selectedNode.Tag;
            if (ccfData == null) return;

            String ccfId = (String)ccfData.ccfId;
            if (ccfId == null) return;
            if (ccfId == "") return;


            XtraForm6 f = new XtraForm6();
            f.m_ccfId = ccfId;

            f.ShowDialog(this);

            bool isOk = f.m_isOK;

            f = null;


            if (isOk == true)
            {
                // 포커스를 주자
                setFocusTreeList(ccfId);
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            XtraForm2 f = new XtraForm2();
            DialogResult result = f.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.initTreeList();
            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            TreeListNode selectedNode = treeList1.FocusedNode;
            if (selectedNode == null) return;
            CDCcfData ccfData = (CDCcfData)selectedNode.Tag;
            if (ccfData == null) return;

            String ccfId = (String)ccfData.ccfId;
            if (ccfId == null) return;
            if (ccfId == "") return;

            String ccfName = (String)selectedNode.GetValue(0);

            XtraForm2 f = new XtraForm2();
            DialogResult result = f.SaveUpd(ccfId, ccfName);
            if (result == DialogResult.OK)
            {
                this.initTreeList();
            }

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            XtraForm3 f = new XtraForm3();
            f.Show(this);
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            TreeListNode selectedNode = treeList1.FocusedNode;
            if (selectedNode == null) return;
            CDCcfData ccfData = (CDCcfData)selectedNode.Tag;
            if (ccfData == null) return;

            String ccfId = (String)ccfData.ccfId;
            if (ccfId == null) return;
            if (ccfId == "") return;

            String ccfName = (String)selectedNode.GetValue(0);

            String newCcfName = ccfName;
            DialogResult result = InputBox.ShowBox("명칭", "새로운 명칭", ref newCcfName);
            if (result == DialogResult.Cancel) return;
            if (ccfName == newCcfName) return;

            CSCcfSave server = new CSCcfSave();
            if (server.setName(ccfId, newCcfName) == true)
            {
                this.initTreeList();
            }
            else
            {
                MessageBox.Show(server.errorMessage);
            }
            // 포커스를 주자
            setFocusTreeList(ccfId);
        }

        private void lblServer_DoubleClick(object sender, EventArgs e)
        {
            this.saveServerIp(false);
            this.initHosCombo();
            this.makeItemButtons();
            this.initTreeList();
        }

        private void lblServer_Click(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control && (ModifierKeys & Keys.Shift) == Keys.Shift && (ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                this.saveServerIp(true);
                this.initHosCombo();
                this.makeItemButtons();
                this.initTreeList();
            }
        }


        private void btnItem_Click(object sender, EventArgs e)
        {
            String nxt_idx_str = "";

            SimpleButton btnItem = sender as SimpleButton;

            // 2026.04.27 WOOIL - 추가한 항목이 PDF 필드이면 pdf_field1, pdf_fiedl2, ... 식으로
            if (btnItem.Tag.ToString() == "pdf_field")
            {
                int max_idx = 0;
                foreach (Control ctrl in panMain.Controls)
                {
                    MoveableBorderedLabel lbl = (MoveableBorderedLabel)ctrl;
                    if (lbl == null) continue;
                    if (lbl.Field.StartsWith("pdf_field"))
                    {
                        String idxStr = lbl.Field.Replace("pdf_field", "");
                        int idx = 0;
                        int.TryParse(idxStr, out idx);
                        if (idx > max_idx) max_idx = idx;
                    }
                }
                nxt_idx_str = (max_idx + 1).ToString();
            }

            String fieldText = getFieldText((String)btnItem.Tag + nxt_idx_str);

            MoveableBorderedLabel label = new MoveableBorderedLabel();
            label.Left = 100;
            label.Top = 400;
            label.Height = 14;
            label.Width = 100;
            label.setText(fieldText);
            label.Field = btnItem.Tag.ToString() + nxt_idx_str;
            label.AutoFit = "";
            label.BackColor = Color.Pink;
            label.Visible = true;

            toolTip1.SetToolTip(label, fieldText);
            toolTip1.SetToolTip(label.InnerLabel, fieldText);

            label.MovedResized += new MoveableBorderedPanel.MovedResizedHandler(label_MovedResized);
            label.MouseDown += new MouseEventHandler(label_MouseDown);
            label.PreviewKeyDown += new PreviewKeyDownEventHandler(label_PreviewKeyDown);

            int width = getItemWidth(label.Field);
            if (width > 0)
            {
                label.Width = width;
            }
            panMain.Controls.Add(label);
        }

        private int getItemWidth(String field)
        {
            int ret = -1;
            if (field == "yy" || field == "ibdyy")
            {
                ret = 35;
            }
            else if (field == "mm" || field == "dd" || field == "ibdmm" || field == "ibddd")
            {
                ret = 15;
            }
            else if (field == "psex" || field == "age")
            {
                ret = 15;
            }

            return ret;
        }

        void label_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                MoveableBorderedLabel label = sender as MoveableBorderedLabel;
                panMain.Controls.Remove(label);
            }
        }

        private String getFieldText(String field)
        {
            if (m_FieldText.ContainsKey(field)) return m_FieldText[field];

            if (field == "pid")
            {
                if(CServer.hospitalId.StartsWith("C")) return "병록번호";
                return "환자ID";
            }
            if (field == "pnm") return "환자명";
            if (field == "psex") return "성별";
            if (field == "age") return "나이";
            if (field == "resid") return "주민등록번호";
            if (field == "bthdt") return "생년월일";
            if (field == "addr") return "주소";
            if (field == "htelno") return "전화번호1";
            if (field == "otelno") return "전화번호2";
            if (field == "ntelno") return "전화번호3";
            if (field == "yy") return "년도(현재)";
            if (field == "mm") return "월(현재)";
            if (field == "dd") return "일(현재)";
            if (field == "hhhh") return "시(현재)";
            if (field == "mmmm") return "분(현재)";
            if (field == "ssss") return "초(현재)";
            if (field == "bededt") return "입원일자(8자리)";
            if (field == "bedodt") return "퇴원일자";
            if (field == "qfynm")
            {
                if (CServer.hospitalId.StartsWith("C")) return "보험유형";
                return "자격명";
            }
            if (field == "insnm") return "보호자명";
            if (field == "famrelnm") return "관계";
            if (field == "p_resid") return "보호자주민등록번호";
            if (field == "dptnm") return "진료과";
            if (field == "drnm") return "주치의";
            if (field == "logindrnm") return "로그인의사(>주치의)";
            if (field == "drsign") return "주치의sign";
            if (field == "logindrsign") return "로그인의사sign(>주치의)";
            if (field == "ward") return "병실";
            if (field == "wardnm") return "병동명";// 2024.07.09 WOOIL
            if (field == "rmid") return "병실ID";// 2024.07.09 WOOIL
            if (field == "maddr") return "보호자주소";
            if (field == "ibdyy") return "년도(입원)";
            if (field == "ibdmm") return "월(입원)";
            if (field == "ibddd") return "일(입원)";
            if (field == "rsvop") return "수술명";
            if (field == "rsvdacd") return "수술전진단";
            if (field == "rsvopdt") return "수술(예정)일(8자리)";
            if (field == "rsvopdt_ymd") return "수술(예정)일(년월일표시)";
            if (field == "rsvopdptnm") return "수술과";
            if (field == "rsvopdrnm") return "수술의명";
            if (field == "dxd") return "주진단명";

            if (field == "rsvop_2nd") return "수술명(두번째)"; // 2023.10.19 WOOIL - 추가

            // 나무병월에서 사용하는 필드
            if (field == "disetc1") return "고혈압내용";
            if (field == "disetc2") return "당뇨병내용";
            if (field == "disetc3") return "심장질환내용";
            if (field == "disetc4") return "호흡기계질활내용";
            if (field == "disetc5") return "신장질환내용";
            if (field == "disetc6") return "암내용";
            if (field == "disetc7") return "간질환내용";
            if (field == "disetc8") return "뇌혈관질환내용";
            if (field == "disetc9") return "녹내장내용";
            if (field == "disetc10") return "전립선비대내용";
            if (field == "disetc11") return "혈액응고질환내용";
            if (field == "disetc12") return "기타질환내용";
            if (field == "opration") return "수술력 유체크";
            if (field == "opretc") return "수술력 유내용";
            if (field == "medetc1") return "항혈소판내용";
            if (field == "medetc2") return "경구혈당내용";
            if (field == "medetc3") return "복용약물기타내용";
            if (field == "specetc1") return "알레르기내용";
            if (field == "specetc5") return "기타기타내용";
            if (field == "dischk1") return "고혈압체크";
            if (field == "dischk2") return "당뇨병체크";
            if (field == "dischk3") return "심장질환체크";
            if (field == "dischk4") return "호흡기질환체크";
            if (field == "dischk5") return "신장질환체크";
            if (field == "dischk6") return "암체크";
            if (field == "dischk7") return "간질환체크";
            if (field == "dischk8") return "뇌혈관질환체크";
            if (field == "dischk9") return "녹내장체크";
            if (field == "dischk10") return "전립선비대체크";
            if (field == "dischk11") return "혈액응고질환체크";
            if (field == "dischk12") return "기타질환체크";
            if (field == "medchk1") return "항혈소판체크";
            if (field == "medchk2") return "경구혈당체크";
            if (field == "medchk3") return "복용약물기타체크";
            if (field == "specchk1") return "알레르기체크";
            if (field == "specchk2") return "기도이상체크";
            if (field == "specchk3") return "턱관절장애체크";
            if (field == "specchk5") return "기타기타체크";
            if (field == "esigned") return "(전자서명됨)";
            if (field == "nonmed") return "해당사항없음"; // 2021.01.21 WOOIL
            if (field == "stopdt") return "일전중지"; // 2021.01.21 WOOIL
            if (field == "namu_rsvdt") return "내시경예약일"; // 2021.02.15 WOOIL

            // 백두병원 용
            if (field == "bd_1591_5") return "SP.환자성명"; // 2021.07.27 WOOIL
            if (field == "bd_1591_9") return "SP.의사명"; // 2021.07.27 WOOIL
            if (field == "bd_1591_22") return "SP.성별"; // 2021.07.27 WOOIL
            if (field == "bd_1591_23") return "SP.나이"; // 2021.07.27 WOOIL
            if (field == "bd_1591_11") return "SP.수술일"; // 2021.07.27 WOOIL
            if (field == "bd_1591_14") return "SP.수술명"; // 2021.07.27 WOOIL
            if (field == "bd_1591_15") return "SP.내용"; // 2021.07.27 WOOIL
            if (field == "bd_1591_24") return "SP.주치의"; // 2021.07.27 WOOIL

            // 2023.01.02 WOOIL - 백두병원 마취전 환자 평가표
            if (field == "bd2_rptdt") return "BD2.작성일자";
            if (field == "bd2_rpttm") return "BD2.작성시간";
            if (field == "bd2_opdt") return "BD2.수술일자";
            if (field == "bd2_opnm") return "BD2.수술명";
            if (field == "bd2_dxnm") return "BD2.진단명";
            if (field == "bd2_preop1") return "BD2.혈압(수축기)";
            if (field == "bd2_preop2") return "BD2.혈압(이완기)";
            if (field == "bd2_preop3") return "BD2.맥박";
            if (field == "bd2_preop4") return "BD2.호흡";
            if (field == "bd2_preop5") return "BD2.체온";
            if (field == "bd2_preop6") return "BD2.신장";
            if (field == "bd2_preop7") return "BD2.체중";
            if (field == "bd2_bmi") return "BD2.BMI";
            if (field == "bd2_gumsa1") return "BD2.Chest X-ray";
            if (field == "bd2_gumsa2") return "BD2.EKG";
            if (field == "bd2_gumsa3") return "BD2.Echo";
            if (field == "bd2_gumsa4") return "BD2.Abd sono";
            if (field == "bd2_gumsa5") return "BD2.PFT";
            if (field == "bd2_gumsa6") return "BD2.Hb/Hct";
            if (field == "bd2_gumsa7") return "BD2.BUN/Cr";
            if (field == "bd2_gumsa8") return "BD2.HIV";
            if (field == "bd2_gumsa9") return "BD2.PT/aPTT";
            if (field == "bd2_gumsa10") return "BD2.HbsAg/Ab";
            if (field == "bd2_gumsa11") return "BD2.VDRL";
            if (field == "bd2_gumsa12") return "BD2.GOT/GPT";
            if (field == "bd2_gumsa13") return "BD2.HCV/Ab";
            if (field == "bd2_rh") return "BD2.혈액형";
            if (field == "bd2_dise1") return "BD2.DM";
            if (field == "bd2_dise2") return "BD2.HTN";
            if (field == "bd2_dise3") return "BD2.Asthma";
            if (field == "bd2_dise4") return "BD2.Thyroid dz";
            if (field == "bd2_dise5") return "BD2.Allergy";
            if (field == "bd2_dise6") return "BD2.없음";
            if (field == "bd2_dise7") return "BD2.기타";
            if (field == "bd2_disetxt") return "BD2.기타내용";
            if (field == "bd2_ophis") return "BD2.과거수술특이사항없음";
            if (field == "bd2_ophistxt") return "BD2.과거수술";
            if (field == "bd2_bigo") return "BD2.과거수술비고";
            if (field == "bd2_asa1") return "BD2.ASA class1";
            if (field == "bd2_asa2") return "BD2.ASA class2";
            if (field == "bd2_asa3") return "BD2.ASA class3";
            if (field == "bd2_asa4") return "BD2.ASA class4";
            if (field == "bd2_asa5") return "BD2.ASA class5";
            if (field == "bd2_asa6") return "BD2.ASA Emergency";
            if (field == "bd2_mallampati1") return "BD2.상기도 Class1";
            if (field == "bd2_mallampati2") return "BD2.상기도 Class2";
            if (field == "bd2_mallampati3") return "BD2.상기도 Class3";
            if (field == "bd2_mallampati4") return "BD2.상기도 Class4";
            if (field == "bd2_aneplan1") return "BD2.마취계획 Gen";
            if (field == "bd2_aneplan2") return "BD2.마취계획 Spinal";
            if (field == "bd2_aneplan3") return "BD2.마취계획 Epidural";
            if (field == "bd2_aneplan4") return "BD2.마취계획 BPB";
            if (field == "bd2_aneplan5") return "BD2.마취계획 IV Gen";
            if (field == "bd2_aneplan6") return "BD2.마취계획 기타";
            if (field == "bd2_drug_allergy1") return "BD2.약물 알레르기 NO";
            if (field == "bd2_drug_allergy2") return "BD2.약물 알레르기 YES";
            if (field == "bd2_medication1") return "BD2.Medication NO";
            if (field == "bd2_medication2") return "BD2.Medication YES";
            if (field == "bd2_drug_his") return "BD2.Drug Hx 비고";
            if (field == "bd2_neck_ex1") return "BD2.Neck Good";
            if (field == "bd2_neck_ex2") return "BD2.Neck Poor";
            if (field == "bd2_mouth1") return "BD2.Mouth Good";
            if (field == "bd2_mouth2") return "BD2.Mouth Poor";
            if (field == "bd2_teeth_ex1") return "BD2.Teeth Good";
            if (field == "bd2_teeth_ex2") return "BD2.Teeth Poor";
            if (field == "bd2_alcoh1") return "BD2.음주 NO";
            if (field == "bd2_alcoh2") return "BD2.음주 YES";
            if (field == "bd2_alcoh3") return "BD2.음주 내용";
            if (field == "bd2_smoke1") return "BD2.흡연 NO";
            if (field == "bd2_smoke2") return "BD2.흡연 YES";
            if (field == "bd2_smoke3") return "BD2.흡연 내용";
            if (field == "bd2_neck") return "BD2.기도상태 비고";
            if (field == "bd2_anedrnm") return "BD2.마취의성명";

            // 2023.12.12 WOOIL - 비급여 사용 동의서
            if (field == "bi_no_1") return "비급여 동의서 no 1";
            if (field == "bi_onm_1") return "비급여 동의서 명칭 1";
            if (field == "bi_gumak_1") return "비급여 동의서 금액 1";
            if (field == "bi_no_2") return "비급여 동의서 no 2";
            if (field == "bi_onm_2") return "비급여 동의서 명칭 2";
            if (field == "bi_gumak_2") return "비급여 동의서 금액 2";
            if (field == "bi_no_3") return "비급여 동의서 no 3";
            if (field == "bi_onm_3") return "비급여 동의서 명칭 3";
            if (field == "bi_gumak_3") return "비급여 동의서 금액 3";
            if (field == "bi_no_4") return "비급여 동의서 no 4";
            if (field == "bi_onm_4") return "비급여 동의서 명칭 4";
            if (field == "bi_gumak_4") return "비급여 동의서 금액 4";
            if (field == "bi_no_5") return "비급여 동의서 no 5";
            if (field == "bi_onm_5") return "비급여 동의서 명칭 5";
            if (field == "bi_gumak_5") return "비급여 동의서 금액 5";
            if (field == "bi_no_6") return "비급여 동의서 no 6";
            if (field == "bi_onm_6") return "비급여 동의서 명칭 6";
            if (field == "bi_gumak_6") return "비급여 동의서 금액 6";
            if (field == "bi_no_7") return "비급여 동의서 no 7";
            if (field == "bi_onm_7") return "비급여 동의서 명칭 7";
            if (field == "bi_gumak_7") return "비급여 동의서 금액 7";
            if (field == "bi_no_8") return "비급여 동의서 no 8";
            if (field == "bi_onm_8") return "비급여 동의서 명칭 8";
            if (field == "bi_gumak_8") return "비급여 동의서 금액 8";
            if (field == "bi_no_9") return "비급여 동의서 no 9";
            if (field == "bi_onm_9") return "비급여 동의서 명칭 9";
            if (field == "bi_gumak_9") return "비급여 동의서 금액 9";
            if (field == "bi_no_10") return "비급여 동의서 no 10";
            if (field == "bi_onm_10") return "비급여 동의서 명칭 10";
            if (field == "bi_gumak_10") return "비급여 동의서 금액 10";
            if (field == "bi_no_11") return "비급여 동의서 no 11";
            if (field == "bi_onm_11") return "비급여 동의서 명칭 11";
            if (field == "bi_gumak_11") return "비급여 동의서 금액 11";
            if (field == "bi_no_12") return "비급여 동의서 no 12";
            if (field == "bi_onm_12") return "비급여 동의서 명칭 12";
            if (field == "bi_gumak_12") return "비급여 동의서 금액 12";
            if (field == "bi_no_13") return "비급여 동의서 no 13";
            if (field == "bi_onm_13") return "비급여 동의서 명칭 13";
            if (field == "bi_gumak_13") return "비급여 동의서 금액 13";
            if (field == "bi_no_14") return "비급여 동의서 no 14";
            if (field == "bi_onm_14") return "비급여 동의서 명칭 14";
            if (field == "bi_gumak_14") return "비급여 동의서 금액 14";
            if (field == "bi_no_15") return "비급여 동의서 no 15";
            if (field == "bi_onm_15") return "비급여 동의서 명칭 15";
            if (field == "bi_gumak_15") return "비급여 동의서 금액 15";
            if (field == "bi_gumak_tot") return "비급여 동의서 금액 합계";

            // 2026.04.21 WOOIL - PDF 용
            if (field.StartsWith("pdf_field"))
            {
                return "pdf필드" + field.Replace("pdf_field","");
            }

            return field;
        }

        private void simpleButton14_Click(object sender, EventArgs e)
        {
            try
            {
                TreeListNode selectedNode = treeList1.FocusedNode;
                if (selectedNode == null) return;
                CDCcfData ccfData = (CDCcfData)selectedNode.Tag;
                if (ccfData == null) return;

                String ccfId = ccfData.ccfId;
                if (ccfId == null) return;
                if (ccfId == "") return;

                String itemString = getItemString();
                //if (itemString == "") return;


                CSCcfPaper server = new CSCcfPaper();
                if (server.saveItems(ccfId, itemString) == true)
                {
                    MessageBox.Show("저장이 완료되었습니다.");
                }
                else
                {
                    MessageBox.Show(server.errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String getItemString()
        {
            String itemString = "";
            foreach (Control ctrl in panMain.Controls)
            {
                MoveableBorderedLabel label = (MoveableBorderedLabel)ctrl;
                if (itemString == "")
                {
                    itemString = label.Field + "," + label.Left + "," + label.Top + "," + label.Width + "," + label.Height + "," + label.AutoFit + "," + label.TypeName + "," + label.GroupName;
                }
                else
                {
                    itemString += ":" + label.Field + "," + label.Left + "," + label.Top + "," + label.Width + "," + label.Height + "," + label.AutoFit + "," + label.TypeName + "," + label.GroupName;
                }
            }
            return itemString;
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {

            showReadMe();

        }

        private void simpleButton17_Click(object sender, EventArgs e)
        {

            TreeListNode selectedNode = treeList1.FocusedNode;
            if (selectedNode == null) return;
            CDCcfData ccfData = (CDCcfData)selectedNode.Tag;
            if (ccfData == null) return;

            String ccfId = (String)ccfData.ccfId;
            if (ccfId == null) return;
            if (ccfId == "") return;

            String emrScanClass = (String)ccfData.emrScanClass;

            String newEmrScanClass = emrScanClass;

            XtraForm4 f = new XtraForm4();
            DialogResult result = f.GetEmrScanClass(emrScanClass, ref newEmrScanClass);

            if (result == DialogResult.Cancel) return;
            if (emrScanClass == newEmrScanClass) return;

            CSCcfSave server = new CSCcfSave();
            
            if (server.setEmrScanClass(ccfId, newEmrScanClass) == true)
            {
                this.initTreeList();
            }
            else
            {
                MessageBox.Show(server.errorMessage);
            }
            
            // 포커스를 주자
            setFocusTreeList(ccfId);
        }

        private void simpleButton18_Click(object sender, EventArgs e)
        {
            TreeListNode selectedNode = treeList1.FocusedNode;
            if (selectedNode == null) return;
            CDCcfData ccfData = (CDCcfData)selectedNode.Tag;
            if (ccfData == null) return;

            String ccfId = (String)ccfData.ccfId;
            if (ccfId == null) return;
            if (ccfId == "") return;

            String ccfName = (String)selectedNode.GetValue(0);

            DialogResult result = MessageBox.Show("[" + ccfName + "]를 삭제하시겠습니까?","삭제확인",MessageBoxButtons.YesNo);
            if (result == DialogResult.No) return;

            CSCcfSave server = new CSCcfSave();
            if (server.saveDel(ccfId) == true)
            {
                this.initTreeList();
            }
            else
            {
                MessageBox.Show(server.errorMessage);
            }
            // 포커스를 주자
            setFocusTreeList(ccfId);
        }

        private void txtLeft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            MoveMyLabel("left");
        }

        private void txtLeft_Leave(object sender, EventArgs e)
        {
            MoveMyLabel("left");
        }

        private void txtTop_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            MoveMyLabel("top");
        }

        private void txtTop_Leave(object sender, EventArgs e)
        {
            MoveMyLabel("top");
        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            MoveMyLabel("width");
        }

        private void txtWidth_Leave(object sender, EventArgs e)
        {
            MoveMyLabel("width");
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            MoveMyLabel("height");
        }

        private void txtHeight_Leave(object sender, EventArgs e)
        {
            MoveMyLabel("height");
        }

        private void MoveMyLabel(string kind)
        {
            if (txtName.Text.ToString() == "") return;
            try
            {
                foreach (MoveableBorderedLabel ctrl in panMain.Controls)
                {
                    if (ctrl.Field == txtName.Text.ToString())
                    {
                        int value = 0;
                        if (kind == "left")
                        {
                            int.TryParse(txtLeft.Text.ToString(), out value);
                            ctrl.Left = value;
                        }
                        if (kind == "top")
                        {
                            int.TryParse(txtTop.Text.ToString(), out value);
                            ctrl.Top = value;
                        }
                        if (kind == "width")
                        {
                            int.TryParse(txtWidth.Text.ToString(), out value);
                            ctrl.Width = value;
                        }
                        if (kind == "height")
                        {
                            int.TryParse(txtHeight.Text.ToString(), out value);
                            ctrl.Height = value;
                        }
                        if (kind == "auto_fit")
                        {
                            ctrl.AutoFit = chkAutoFit.Checked ? "true" : "";
                        }
                        if (kind == "type_name")
                        {
                            ctrl.TypeName = cboTypeName.Text;
                        }
                        if (kind == "group_name")
                        {
                            ctrl.GroupName = txtGroupName.Text;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chkAutoFit_CheckedChanged(object sender, EventArgs e)
        {
            MoveMyLabel("auto_fit");
        }

        private void cboTypeName_TextChanged(object sender, EventArgs e)
        {
            MoveMyLabel("type_name");
        }

        private void cboTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtGroupName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            MoveMyLabel("group_name");
        }

        private void txtGroupName_Leave(object sender, EventArgs e)
        {
            MoveMyLabel("group_name");
        }


    }
}
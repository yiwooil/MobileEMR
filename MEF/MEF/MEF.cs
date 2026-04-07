using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

using Ionic.Zip;

namespace MEF
{
    public partial class MEF : Form
    {
        private bool IsFirst;

        public MEF()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Run()
        {
            lstMsg.Items.Clear();

            // ---------------------------------------------------------------------------------------------------
            // FTP 정보를 구한다.
            // ---------------------------------------------------------------------------------------------------
            string ftpServer = "";
            string ftpUser = "";
            string ftpPwd = "";
            SetFtpInformation(out ftpServer, out ftpUser, out ftpPwd);
            ftpServer = ftpServer.Replace("8.ADD", "X.이우일");
            ftpServer += "EmrDroid/EmrServelts/";
            lstMsg.Items.Add(DateTime.Now.ToString() + " Ftp 접속정보를 읽었습니다.(" + ftpServer + ")");

            // ---------------------------------------------------------------------------------------------------
            // FTP폴더에서 파일리스트를 읽는다.
            // ---------------------------------------------------------------------------------------------------
            List<string> ftpFileList = GetFtpFileList(ftpServer, ftpUser, ftpPwd);
            lstMsg.Items.Add(DateTime.Now.ToString() + " 다운로드할 파일리스트를 읽었습니다.");

            // ---------------------------------------------------------------------------------------------------
            // FTP폴더에서 파일을 다운로드한다.
            // ---------------------------------------------------------------------------------------------------
            string currentPath = System.Reflection.Assembly.GetExecutingAssembly().Location; // 이 실행파일이 구동되는 FULL PATH
            string currentPathName = System.IO.Path.GetDirectoryName(currentPath); // 이 파일이 구동되는 폴더
            lstMsg.Items.Add(DateTime.Now.ToString() + " " + currentPathName);
            bool bFileExists = false;
            List<string> fileList = new List<string>();
            foreach (String ftpFile in ftpFileList)
            {
                if (ftpFile.StartsWith("UPD", StringComparison.CurrentCultureIgnoreCase))
                {
                    if (ftpFile.EndsWith(".zip", StringComparison.CurrentCultureIgnoreCase))
                    {
                        bFileExists = true;
                        lstMsg.Items.Add(DateTime.Now.ToString() + " 다운로드 " + ftpFile);
                        DownloadViaFtp(ftpServer, ftpUser, ftpPwd, ftpFile, currentPathName);
                        fileList.Add(currentPathName + Path.DirectorySeparatorChar + ftpFile); // 다운로드된 파일을 담아놓는다.
                    }
                }
            }
            lstMsg.Items.Add(DateTime.Now.ToString() + " 다운로드가 완료되었습니다.");

            // ---------------------------------------------------------------------------------------------------
            // 다운로드한 파일을 실행하여 압출을 푼다.(나중에 구현하자...)
            // ---------------------------------------------------------------------------------------------------
            if (bFileExists == true)
            {
                foreach (String filePathName in fileList)
                {
                    lstMsg.Items.Add(DateTime.Now.ToString() + " 압축풀기 " + filePathName);
                    using (ZipFile zip = ZipFile.Read(filePathName))
                    {
                        String extractPath = Path.GetDirectoryName(filePathName);
                        lstMsg.Items.Add(DateTime.Now.ToString() + " 대상폴더 " + extractPath);
                        zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
        }

        private void SetFtpInformation(out String ftpServer, out String ftpUser, out String ftpPwd)
        {
            string strFtpAutoText = GetUrlSource("http://www.metrosoft.co.kr/emr/FtpAutoText.asp", "http://180.70.20.22/emr/FtpAutoText.asp");
            string[] lines = strFtpAutoText.Split(new String[] { System.Environment.NewLine }, StringSplitOptions.None);
            ftpServer = lines[0].Substring(5) + "/";
            ftpUser = lines[1];
            ftpPwd = lines[2];
            for (int i = 3; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("cd", StringComparison.CurrentCultureIgnoreCase))
                {
                    ftpServer += lines[i].Substring(3) + "/";
                }
            }
        }

        private string GetUrlSource(string url, string url2)
        {
            string urlSource = "";
            try
            {
                urlSource = GetUrlSourceInner(url);
                return urlSource;
            }
            catch (Exception e1)
            {
                // www.metrosoft.co.kr은 접속이 안되고
                // 180.70.20.22 로는 접속이 되는 병원이 있음.
            }
            try
            {
                urlSource = GetUrlSourceInner(url2);
                return urlSource;
            }
            catch (Exception e2)
            {
                // 180.70.20.22 로도 접속이 안되는 병원이 있음.
            }
            return urlSource;
        }

        private string GetUrlSourceInner(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);

            string urlSource = reader.ReadToEnd();

            reader.Close();
            dataStream.Close();
            response.Close();

            return urlSource;
        }

        private List<string> GetFtpFileList(String ftpServer, String ftpUser, String ftpPwd)
        {
            List<string> result = new List<string>();

            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create("ftp://" + ftpServer);
            request.UseBinary = true;
            request.Credentials = new NetworkCredential(ftpUser, ftpPwd);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        result.Add(line);
                        line = reader.ReadLine();
                    }
                    reader.Close();
                }
                response.Close();
            }
            return result;
        }

        private void DownloadViaFtp(String ftpServer, String ftpUser, String ftpPwd, String ftpFile, String workingPath)
        {
            String uri = "ftp://" + ftpServer + ftpFile;
            Uri ftpServerUri = new Uri(uri);
            if (ftpServerUri.Scheme != Uri.UriSchemeFtp) return;

            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            request.Credentials = new NetworkCredential(ftpUser, ftpPwd);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.UseBinary = true;
            request.UsePassive = true;
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (FileStream fileStream = new FileStream(workingPath + Path.DirectorySeparatorChar + ftpFile, FileMode.Create))
                    {
                        int len = 2048;
                        Byte[] buf = new Byte[len];
                        int bytesRead = responseStream.Read(buf, 0, len);
                        while (bytesRead > 0)
                        {
                            fileStream.Write(buf, 0, bytesRead);
                            bytesRead = responseStream.Read(buf, 0, len);
                        }
                        fileStream.Close();
                    }
                    response.Close();
                }
            }
        }

        private void MEF_Load(object sender, EventArgs e)
        {
            IsFirst = true;
        }

        private void MEF_Activated(object sender, EventArgs e)
        {
            if (IsFirst == false) return;
            IsFirst = false;

            btnRun.PerformClick();

            if (MessageBox.Show("종료하시겠습니까?", this.Text, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}

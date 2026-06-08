using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

using Ionic.Zip;
using Microsoft.VisualBasic;

namespace MES
{
    public partial class MES : Form
    {
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(IntPtr hProcess, out bool wow64Process);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder returnValue, int size, string filePath);


        private ToolTip toolTip1 = new ToolTip();

        public MES()
        {
            InitializeComponent();

            toolTip1.SetToolTip(txtWin3264, "OS가 32비트인지 64비트인지 알려줍니다.");
            toolTip1.SetToolTip(txtTomcatFolder, "Tomcat을 설치할 폴더입니다.");
            toolTip1.SetToolTip(txtComplusIP, "COM+ 서버 IP입니다. 더블클릭하면 입력할 수 있습니다.");
            toolTip1.SetToolTip(txtMetroHis, "MetroHis.ini 파일 위치입니다.");
            toolTip1.SetToolTip(txtDBIp, "데이터베이스 서버 IP입니다. 포트도 포함되어 있습니다.");
            toolTip1.SetToolTip(txtDBName, "데이터베이스 명칭입니다.");
            toolTip1.SetToolTip(txtHospitalName, "병원 명칭입니다.");
            toolTip1.SetToolTip(txtHospitalNo, "병원 번호입니다. 메트로소프트에서 자체적으로 관리하는 번호입니다.");
            toolTip1.SetToolTip(txtEmrScan, "동의서 파일이 저장되는 위치입니다.");

        }

        private void MES_Load(object sender, EventArgs e)
        {
            if (Is64BitOperatingSystem())
                txtWin3264.Text = "64비트";
            else
                txtWin3264.Text = "32비트";

            // 실행 파일이 위치한 폴더 경로
            txtTomcatFolder.Text = GetExeDrive() + "Tomcat7";

            // MetroHis.ini 파일
            string result = Interaction.InputBox("complus 서버 IP : ", "", "", 0, 0);
            if (!string.IsNullOrEmpty(result))
            {
                txtComplusIP.Text = result;
            }
        }

        static bool Is64BitOperatingSystem()
        {
            // 64비트 프로세스라면 무조건 64비트 OS
            if (IntPtr.Size == 8)
                return true;

            // 32비트 프로세스라면 WOW64 여부 확인
            bool isWow64;
            IntPtr handle = Process.GetCurrentProcess().Handle; // 현재 프로세스 핸들 얻기[2][5]
            if (!IsWow64Process(handle, out isWow64))
                throw new System.ComponentModel.Win32Exception();
            return isWow64;
        }

        private void txtComplusIP_TextChanged(object sender, EventArgs e)
        {
            Application.DoEvents();

            txtMetroHis.Text = "\\\\" + txtComplusIP.Text.ToString() + "\\FtpHome\\MetroHis.ini";

            // DB서버
            txtDBIp.Text = ReadIniValue("MetroHis", "DBSERVER", txtMetroHis.Text.ToString(), "");
            txtDBName.Text = ReadIniValue("MetroHis", "DBNAME", txtMetroHis.Text.ToString(), "");
            txtHospitalName.Text = ReadIniValue("MetroHis", "HOSPITAL", txtMetroHis.Text.ToString(), "");
            txtHospitalNo.Text = GetHospitalNo();

            // 동의서 이미지가 저장될 서버 정보 
            txtNewScanFg.Text = ReadIniValue("MetroHis", "NEWSCANPATHFG", txtMetroHis.Text.ToString(), "");
            if (txtNewScanFg.Text.ToString() == "Y")
            {
                txtEmrScan.Text = ReadIniValue("MetroHis", "NEWSCANPATH", txtMetroHis.Text.ToString(), "");
                txtEmrScanRead.Text = ReadIniValue("MetroHis", "NEWSCAN_READPATH", txtMetroHis.Text.ToString(), "");
            }
            else
            {
                txtEmrScan.Text = ReadIniValue("MetroHis", "SCANFILEPATH", txtMetroHis.Text.ToString(), "");
                txtEmrScanRead.Text = txtEmrScan.Text;
            }

            // 맨 뒤에 \문자가 없으면 붙이자.
            if (txtEmrScan.Text.ToString() != "" && txtEmrScan.Text.ToString().EndsWith("\\") == false)
            {
                txtEmrScan.Text = txtEmrScan.Text.ToString() + "\\";
            }
            if (txtEmrScanRead.Text.ToString() != "" && txtEmrScanRead.Text.ToString().EndsWith("\\") == false)
            {
                txtEmrScanRead.Text = txtEmrScanRead.Text.ToString() + "\\";
            }
            
        }

        private void txtComplusIP_DoubleClick(object sender, EventArgs e)
        {
            string result = Interaction.InputBox("complus 서버 IP : ", "", "", 0, 0);
            if (!string.IsNullOrEmpty(result))
            {
                txtComplusIP.Text = result;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("관리자 권한으로 실행해야합니다. 계속 진행할까요?", "확인", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }

                if (txtWin3264.Text.ToString() != "64비트" && txtWin3264.Text.ToString() != "32비트")
                {
                    MessageBox.Show("Window가 32비트인지 64비트인지 확실하지 않습니다.");
                    return;
                }
                int tomcat_port = 0;
                int.TryParse(txtHospitalNo.Text.ToString(), out tomcat_port);
                tomcat_port += 8000;


                string msg = "";
                msg += Environment.NewLine + Environment.NewLine + "***주의사항***";
                msg += Environment.NewLine + Environment.NewLine + "톰캣을 " + txtTomcatFolder.Text.ToString() + " 폴더에 설치하세요.";
                msg += Environment.NewLine + Environment.NewLine + "톰캣 포트를 " + tomcat_port.ToString() + " 로 설정하세요.";
                MessageBox.Show(msg);

                // --------------------------------------
                AddMsg("JRE 설치");
                SetupJRE();
                AddMsg(" -> 완료" + Environment.NewLine);
                // --------------------------------------
                AddMsg("Tomcat 설치");
                SetupTomcat();
                AddMsg(" -> 완료" + Environment.NewLine);
                // --------------------------------------
                AddMsg("UTF8 설정");
                ToUTF8();
                AddMsg(" -> 완료" + Environment.NewLine);
                // --------------------------------------
                AddMsg("emrdroid.zip 복사");
                CopyEmrdroid();
                AddMsg(" -> 완료" + Environment.NewLine);
                // --------------------------------------
                AddMsg("emrdroid 압축 풀기");
                UnzipEmrdroid();
                AddMsg(" -> 완료" + Environment.NewLine);
                // --------------------------------------
                AddMsg("추가 Lib 복사");
                CopyLib();
                AddMsg(" -> 완료" + Environment.NewLine);
                // --------------------------------------
                AddMsg("적용.bat 생성");
                MakeApplyBat();
                AddMsg(" -> 완료" + Environment.NewLine);
                // --------------------------------------
                AddMsg("적용.bat 실행");
                RunApplyBat();
                AddMsg(" -> 완료" + Environment.NewLine);
                // --------------------------------------
                AddMsg("config.xml 파일 수정");
                ModifyXml();
                AddMsg(" -> 완료" + Environment.NewLine);
                // --------------------------------------
                AddMsg("tomcat7w.exe 실행");
                ExecTomcat7w();
                AddMsg(" -> 완료" + Environment.NewLine);
                // --------------------------------------
                MessageBox.Show(
                    "설치가 완료되었습니다." + Environment.NewLine + Environment.NewLine +
                    "tomcat을 관리자로 로그인해서 재실행하세요.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddMsg(string msg)
        {
            txtMsg.Text = txtMsg.Text.ToString() + msg;
            MessageBox.Show(msg); // *******************************
            Application.DoEvents();
        }

        private void SetupJRE()
        {
            string exePath = "";
            if (chkTEMURIN.Checked == true)
            {
                //exePath = GetExeDirectory() + "/OpenJDK8U-jdk_x64_windows_hotspot_8u472b08.msi";
                if (txtWin3264.Text.ToString() == "64비트")
                {
                    exePath = GetExeDirectory() + "/jre-6u24-windows-x64.exe";
                }
                else if (txtWin3264.Text.ToString() == "32비트")
                {
                    exePath = GetExeDirectory() + "/jre-6u24-windows-i586.exe";
                }
            }
            else if (chkJRE.Checked == true)
            {
                if (txtWin3264.Text.ToString() == "64비트")
                {
                    exePath = GetExeDirectory() + "/jre-8u202-windows-x64.exe";
                }
                else if (txtWin3264.Text.ToString() == "32비트")
                {
                    exePath = GetExeDirectory() + "/jre-8u202-windows-i586.exe";
                }
            }
            else
            {
                if (txtWin3264.Text.ToString() == "64비트")
                {
                    exePath = GetExeDirectory() + "/jre-6u24-windows-x64.exe";
                }
                else if (txtWin3264.Text.ToString() == "32비트")
                {
                    exePath = GetExeDirectory() + "/jre-6u24-windows-i586.exe";
                }
            }
            // ProcessStartInfo를 사용해 프로세스 정보 설정
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = exePath;
            // 필요하다면 psi.Arguments, psi.WorkingDirectory 등 추가 설정 가능

            // 프로세스 시작
            using (Process process = Process.Start(psi))
            {
                // 프로그램이 종료될 때까지 대기
                process.WaitForExit();
            }

            // 테무린 버전을 추가로 설치한다.
            if (chkTEMURIN.Checked == true)
            {
                exePath = GetExeDirectory() + "/OpenJDK8U-jdk_x64_windows_hotspot_8u472b08.msi";
                // ProcessStartInfo를 사용해 프로세스 정보 설정
                ProcessStartInfo psi2 = new ProcessStartInfo();
                psi2.FileName = exePath;
                // 필요하다면 psi.Arguments, psi.WorkingDirectory 등 추가 설정 가능

                // 프로세스 시작
                using (Process process = Process.Start(psi2))
                {
                    // 프로그램이 종료될 때까지 대기
                    process.WaitForExit();
                }
            }
        }

        private void SetupTomcat()
        {
            string exePath = "";
            if (chkTOMCAT.Checked == true)
            {
                exePath = GetExeDirectory() + "/apache-tomcat-7.0.109.exe";
            }
            else
            {
                exePath = GetExeDirectory() + "/apache-tomcat-7.0.12.exe";
            }
            // ProcessStartInfo를 사용해 프로세스 정보 설정
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = exePath;
            // 필요하다면 psi.Arguments, psi.WorkingDirectory 등 추가 설정 가능

            // 프로세스 시작
            using (Process process = Process.Start(psi))
            {
                // 프로그램이 종료될 때까지 대기
                process.WaitForExit();
            }
        }

        private void ToUTF8()
        {
            string filePath = txtTomcatFolder.Text.ToString() + "/conf/server.xml";
            string searchText = "redirectPort=\"8443\"";
            string textToInsert = Environment.NewLine + "               URIEncoding=\"UTF-8\"";

            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(searchText))
                {
                    int idx = lines[i].IndexOf(searchText) + searchText.Length;
                    lines[i] = lines[i].Insert(idx, textToInsert);
                    break; // 첫 번째만 수정
                }
            }
            File.WriteAllLines(filePath, lines.ToArray());
        }

        private void CopyEmrdroid()
        {
            string sourcePath = GetExeDirectory() + "/emrdroid.zip";
            string destPath = txtTomcatFolder.Text.ToString() + "/webapps/emrdroid.zip";

            // 파일 복사 (덮어쓰기 허용 안 함)
            File.Copy(sourcePath, destPath);

            // 만약 덮어쓰기를 허용하려면 아래처럼 true를 추가
            // File.Copy(sourcePath, destPath, true);
        }

        private void UnzipEmrdroid()
        {
            string zipFilePath = txtTomcatFolder.Text.ToString() + "/webapps/emrdroid.zip";
            string extractPath = txtTomcatFolder.Text.ToString() + "/webapps/emrdroid";

            using (ZipFile zip = ZipFile.Read(zipFilePath))
            {
                zip.ExtractAll(extractPath, ExtractExistingFileAction.OverwriteSilently);
            }
        }

        private void CopyLib()
        {
            string sourceDir = GetExeDirectory() + "/추가파일";
            string destDir = txtTomcatFolder.Text.ToString() + "/webapps/emrdroid/WEB-INF/lib";

            // .jar 파일 목록 가져오기
            string[] jarFiles = Directory.GetFiles(sourceDir, "*.jar");

            // 각 파일 복사
            foreach (string filePath in jarFiles)
            {
                string fileName = Path.GetFileName(filePath);
                string destPath = Path.Combine(destDir, fileName);

                // 이미 있으면 덮어쓰기: true
                File.Copy(filePath, destPath, true);
            }
        }

        private void MakeApplyBat()
        {
            List<string> lines = new List<string>();
            lines.Add(GetExeDrive().Substring(0,2));
            lines.Add("CD " + GetExeDrive() + "EmrDroid\\EmrServelts");
            lines.Add("copy *.class \"" + txtTomcatFolder.Text.ToString() + "\\webapps\\emrdroid\\WEB-INF\\classes\"");
            lines.Add("net stop tomcat7");
            lines.Add("net start tomcat7");
            lines.Add("pause");

            string filePath = GetExeDrive() + "EmrDroid\\EmrServelts\\적용.bat";
            File.WriteAllLines(filePath, lines.ToArray());
        }

        private void RunApplyBat()
        {
            string exePath = GetExeDrive() + "EmrDroid\\EmrServelts\\적용.bat";

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = exePath;
            psi.UseShellExecute = true;
            psi.Verb = "runas"; // 관리자권한으로 실행

            // 프로세스 시작
            using (Process process = Process.Start(psi))
            {
                // 프로그램이 종료될 때까지 대기
                process.WaitForExit();
            }
        }

        private void ModifyXml()
        {
            if (txtHospitalNo.Text.ToString() == "" ||
                txtHospitalName.Text.ToString() == "" ||
                txtDBIp.Text.ToString() == "" ||
                txtDBName.Text.ToString() == "" ||
                txtComplusIP.Text.ToString() == "" ||
                txtEmrScan.Text.ToString() == "")
            {
                MessageBox.Show("정보가 부족하여 config.xml을 수정할 수 없습니다.");
                return;
            }
            string filePath = txtTomcatFolder.Text.ToString() + "/webapps/emrdroid/WEB-INF/classes/config.xml";

            List<string> lines = new List<string>(File.ReadAllLines(filePath));

            lines[3] = "        <id>" + txtHospitalNo.Text.ToString() + "</id>";
            lines[4] = "        <hospital_name>" + txtHospitalName.Text.ToString() + "</hospital_name>";
            lines[5] = "        <mask_yn>n</mask_yn>";
            lines[6] = "        <database_url>jdbc:sqlserver://" + txtDBIp.Text.ToString().Replace(",",":") + ";databaseName=" + txtDBName.Text.ToString() + ";user=sa;password=mms;</database_url>";
            lines[7] = "        <home_url>\\\\" + txtComplusIP.Text.ToString() + "\\FtpHome\\</home_url>";
            lines[8] = "        <scan_url>" + txtEmrScan.Text.ToString() + "</scan_url>";
            lines[9] = "        <presave_url>" + txtEmrScan.Text.ToString() + "pre_save\\</presave_url>";
            lines[10] = "        <mp4_url>" + txtEmrScan.Text.ToString() + "ccf_mp4\\</mp4_url>";
            lines[11] = "        <pic_url>" + txtEmrScan.Text.ToString() + "ccf_pic\\</pic_url>";
            if (txtNewScanFg.Text.ToString() == "Y")
            {
                // 데이터베이스에 경로 정보를 같이 저장한다.
                lines[12] = "";
                lines[12] += "        <filename_prefix>" + txtEmrScanRead.Text.ToString() + "</filename_prefix>" + Environment.NewLine;
                lines[12] += "        <filename_prefix_presave>" + txtEmrScanRead.Text.ToString() + "pre_save\\</filename_prefix_presave>" + Environment.NewLine;
                lines[12] += "        <filename_prefix_pic>" + txtEmrScanRead.Text.ToString() + "ccf_pic\\</filename_prefix_pic>" + Environment.NewLine;
                lines[12] += "        <filename_prefix_mp4>" + txtEmrScanRead.Text.ToString() + "ccf_mp4\\</filename_prefix_mp4>" + Environment.NewLine;
                lines[12] += "        <emr_scan_url>empty</emr_scan_url>";
            }
            else
            {
                lines[12] = "        <emr_scan_url>" + txtEmrScanRead.Text.ToString() + "</emr_scan_url>";
            }

            File.WriteAllLines(filePath, lines.ToArray());
        }

        private void ExecTomcat7w()
        {
            string exePath = txtTomcatFolder.Text.ToString() + "\\bin\\tomcat7w.exe";

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = exePath;
            psi.UseShellExecute = true;
            psi.Verb = "runas"; // 관리자권한으로 실행

            // 프로세스 시작
            using (Process process = Process.Start(psi))
            {
                // 프로그램이 종료될 때까지 대기
                process.WaitForExit();
            }
        }

        private string GetHospitalNo()
        {
            try
            {
                string strPwd = "mms";
                string strUid = "sa";
                string strDBName = txtDBName.Text.ToString();
                string strDBServer = txtDBIp.Text.ToString();

                string strConn = "Provider=SQLOLEDB.1;Password=" + strPwd + ";Persist Security Info=true;User ID=" + strUid + ";Initial Catalog=" + strDBName + ";Data Source=" + strDBServer + "";

                string ret = "";
                using (OleDbConnection conn = new OleDbConnection(strConn))
                {
                    conn.Open();
                    string sql = "";
                    sql = "SELECT FLD1QTY FROM TA88 WHERE MST1CD='C' AND MST2CD='0' AND MST3CD='1'";
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                        {
                            using (DataSet ds = new DataSet())
                            {
                                adapter.Fill(ds);
                                foreach(DataRow row in ds.Tables[0].Rows)
                                {
                                    ret = row["FLD1QTY"].ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }

        }

        private string GetExeDrive()
        {
            // "D:\" 형식으로 반환됨.
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string drive = Path.GetPathRoot(exePath);
            return drive;
        }

        private string GetExeDirectory()
        {
            // "D:\설치" 형식으로 반환됨.
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string exeDirectory = Path.GetDirectoryName(exePath);
            return exeDirectory;
        }

        private string ReadIniValue(string section, string key, string filePath, string defaultValue)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(section, key, defaultValue, temp, 255, filePath);
            return temp.ToString();
        }

        private void txtEmrScan_DoubleClick(object sender, EventArgs e)
        {
            txtEmrScan.ReadOnly = !txtEmrScan.ReadOnly;
        }

        private void txtEmrScanRead_DoubleClick(object sender, EventArgs e)
        {
            txtEmrScanRead.ReadOnly = !txtEmrScanRead.ReadOnly;
        }

    }
}

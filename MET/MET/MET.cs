using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MET
{
    public partial class MET : Form
    {
        public MET()
        {
            InitializeComponent();
        }

        private void MET_Load(object sender, EventArgs e)
        {
            lstJobKind.SelectedIndex = 0;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (lstJobKind.SelectedItem.ToString() == "로그인")
            {
                string url = txtAddr.Text.ToString() + "/emrdroid/servlet/LoginServlet" +
                             "?hospitalid=" + txtHosno.Text.ToString() +
                             "&userid=" + txtUid.Text.ToString() +
                             "&password=" + txtPwd.Text.ToString() +
                             "&ver=2";
                System.Diagnostics.Process.Start(url);
            }
            else if (lstJobKind.SelectedItem.ToString() == "재원환자명단")
            {
                string url = txtAddr.Text.ToString() + "/emrdroid/servlet/InPatientListServlet" +
                             "?hospitalid=" + txtHosno.Text.ToString() +
                             "&userid=" + txtUid.Text.ToString() +
                             "&password=" + txtPwd.Text.ToString() +
                             "&mode=0" +
                             "&sortorder=0" +
                             "&ward=" +
                             "&dept=" +
                             "&pdrid=";
                System.Diagnostics.Process.Start(url);
            }
            else if (lstJobKind.SelectedItem.ToString() == "동의서리스트")
            {
                string url = txtAddr.Text.ToString() + "/emrdroid/servlet/CertificatePaperServlet" +
                             "?hospitalid=" + txtHosno.Text.ToString() +
                             "&userid=" + txtUid.Text.ToString() +
                             "&password=" + txtPwd.Text.ToString() +
                             "&mode=0";
                System.Diagnostics.Process.Start(url);
            }
            else if (lstJobKind.SelectedItem.ToString() == "동의서내용")
            {
                string url = txtAddr.Text.ToString() + "/emrdroid/servlet/CertificatePaperServlet" +
                             "?hospitalid=" + txtHosno.Text.ToString() + "" +
                             "&userid=" + txtUid.Text.ToString() + "" +
                             "&password=" + txtPwd.Text.ToString() + "" +
                             "&pid=" + txtPid.Text.ToString() + "" +
                             "&bededt=" + txtBededt.Text.ToString() + "" +
                             "&ccfid=" + txtCcfid.Text.ToString() + "" +
                             "&mode=11";
                System.Diagnostics.Process.Start(url);
            }
            else if (lstJobKind.SelectedItem.ToString() == "기능검사결과")
            {
                string url = txtAddr.Text.ToString() + "/emrdroid/servlet/ResultRadServlet" +
                             "?hospitalid=" + txtHosno.Text.ToString() + "" +
                             "&userid=" + txtUid.Text.ToString() + "" +
                             "&password=" + txtPwd.Text.ToString() + "" +
                             "&pid=" + txtPid.Text.ToString() + "" +
                             "&bededt=" + txtBededt.Text.ToString() + "" +
                             "&bdiv=" + txtBdiv.Text.ToString() + "" +
                             "&odt=" + txtOdt.Text.ToString() + "" +
                             "&ono=" + txtOno.Text.ToString() + "" +
                             "&mode=1";
                System.Diagnostics.Process.Start(url);
            }
            else if (lstJobKind.SelectedItem.ToString() == "임시저장동의서리스트(모든환자)")
            {
                string url = txtAddr.Text.ToString() + "/emrdroid/servlet/CertificatePaperServlet" +
                             "?hospitalid=" + txtHosno.Text.ToString() + "" +
                             "&userid=" + txtUid.Text.ToString() + "" +
                             "&mode=14";
                System.Diagnostics.Process.Start(url);
            }
            else if (lstJobKind.SelectedItem.ToString() == "임시저장동의서리스트(환자별)")
            {
                string url = txtAddr.Text.ToString() + "/emrdroid/servlet/CertificatePaperServlet" +
                             "?hospitalid=" + txtHosno.Text.ToString() + "" +
                             "&userid=" + txtUid.Text.ToString() + "" +
                             "&pid=" + txtPid.Text.ToString() + "" +
                             "&mode=5";
                System.Diagnostics.Process.Start(url);
            }
            else if (lstJobKind.SelectedItem.ToString() == "환자검색")
            {
                string url = txtAddr.Text.ToString() + "/emrdroid/servlet/InPatientListServlet" +
                             "?hospitalid=" + txtHosno.Text.ToString() + "" +
                             "&userid=" + txtUid.Text.ToString() + "" +
                             "&searchtext=" + txtSearch.Text.ToString() + "" +
                             "&exdt=" + txtOdt.Text.ToString() + "" +
                             "&exdtto=" + txtOdt.Text.ToString() + "" +
                             "&sortorder=1" +
                             "&mode=1";
                System.Diagnostics.Process.Start(url);
            }
        }

        private void lstJobKind_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtPid.Enabled = false;
            txtBededt.Enabled = false;
            txtBdiv.Enabled = false;
            txtOdt.Enabled = false;
            txtOno.Enabled = false;
            txtCcfid.Enabled = false;
            txtSearch.Enabled = false;

            if (lstJobKind.SelectedItem.ToString() == "로그인")
            {
            }
            else if (lstJobKind.SelectedItem.ToString() == "재원환자명단")
            {
            }
            else if (lstJobKind.SelectedItem.ToString() == "동의서리스트")
            {
            }
            else if (lstJobKind.SelectedItem.ToString() == "동의서내용")
            {
                txtPid.Enabled = true;
                txtBededt.Enabled = true;
                txtCcfid.Enabled = true;
            }
            else if (lstJobKind.SelectedItem.ToString() == "기능검사결과")
            {
                txtPid.Enabled = true;
                txtBededt.Enabled = true;
                txtBdiv.Enabled = true;
                txtOdt.Enabled = true;
                txtOno.Enabled = true;
            }
            else if (lstJobKind.SelectedItem.ToString() == "임시저장동의서리스트(모든환자)")
            {
            }
            else if (lstJobKind.SelectedItem.ToString() == "임시저장동의서리스트(환자별)")
            {
                txtPid.Enabled = true;
            }
            else if (lstJobKind.SelectedItem.ToString() == "환자검색")
            {
                txtOdt.Enabled = true;
                txtSearch.Enabled = true;
            }
        }

        private void txtHosno_TextChanged(object sender, EventArgs e)
        {
            string hosno = txtHosno.Text.ToString().Trim();
            if (hosno.Length != 4) return;
            txtAddr.Text = "http://localhost:8" + hosno.Substring(1,3);
            if (hosno == "0123") txtAddr.Text = "http://220.77.198.129:8081"; // 자인메디
            if (hosno == "9996") txtAddr.Text = "http://180.70.20.24:8080"; // 본사 테스트
            

        }
    }
}

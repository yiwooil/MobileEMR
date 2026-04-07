using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MEM
{
    public partial class MEM_1 : Form
    {
        public MEM_1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtHospitalId.Text.ToString() == "")
            {
                MessageBox.Show("병원ID를 입력하세요.");
                return;
            }
            if (txtHospitalName.Text.ToString() == "")
            {
                MessageBox.Show("병원명를 입력하세요.");
                return;
            }
            if (txtServletIp.Text.ToString() == "")
            {
                MessageBox.Show("Servlet IP를 입력하세요.");
                return;
            }
            if (txtLicenseKeyNo.Text.ToString() == "")
            {
                MessageBox.Show("인증번호를 입력하세요.");
                return;
            }

            try
            {
                Save();

                MessageBox.Show("저장되었습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Save()
        {
            string strConn = GetConnectionString();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                OleDbTransaction tran = null;
                try
                {
                    conn.Open();
                    tran = conn.BeginTransaction();

                    // 병원정보
                    string sql = "";
                    sql += Environment.NewLine + "insert into Hospitals(hospital_id,hospital_name,servlet_ip,servlet_ip_2)";
                    sql += Environment.NewLine + "values(?,?,?,?)";

                    List<Object> para = new List<object>();
                    para.Clear();
                    para.Add(txtHospitalId.Text.ToString());
                    para.Add(txtHospitalName.Text.ToString());
                    para.Add(txtServletIp.Text.ToString());
                    para.Add(txtServletIp2.Text.ToString());

                    ExecuteSql(sql, para, conn, tran);

                    // 라이센스 키
                    sql = "";
                    sql += Environment.NewLine + "insert into Licenses(license_key_no,hospital_id,start_date,end_date)";
                    sql += Environment.NewLine + "values(?,?,?,?)";

                    para.Clear();
                    para.Add(txtLicenseKeyNo.Text.ToString());
                    para.Add(txtHospitalId.Text.ToString());
                    para.Add("19990101");
                    para.Add("99991231");

                    ExecuteSql(sql, para, conn, tran);

                    // 개발자용 라이센스 키
                    sql = "";
                    sql += Environment.NewLine + "insert into Licenses(license_key_no,hospital_id,start_date,end_date)";
                    sql += Environment.NewLine + "values(?,?,?,?)";

                    para.Clear();
                    para.Add("metro-soft-dev");
                    para.Add(txtHospitalId.Text.ToString());
                    para.Add("19990101");
                    para.Add("99991231");

                    ExecuteSql(sql, para, conn, tran);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    if (tran != null) tran.Rollback();
                    throw ex;
                }

            }

        }

        private string GetConnectionString()
        {
            string strConn = "Provider=SQLOLEDB.1;Password=mms;Persist Security Info=true;User ID=sa;Initial Catalog=BaseCamp;Data Source=192.168.1.196,5333";
            return strConn;
        }

        private int ExecuteSql(string p_sql, List<Object> p_para, OleDbConnection p_conn, OleDbTransaction p_tran)
        {
            int cnt = 0;
            try
            {
                using (OleDbCommand cmd = new OleDbCommand(p_sql, p_conn, p_tran))
                {
                    int i = 0;
                    foreach (Object obj in p_para)
                    {
                        cmd.Parameters.Add(new OleDbParameter("@" + (++i).ToString(), obj));
                    }

                    cnt = cmd.ExecuteNonQuery();
                }
                return cnt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

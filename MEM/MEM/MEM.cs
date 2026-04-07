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
    public partial class MEM : Form
    {
        public MEM()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void Query()
        {
            grdMain.DataSource = null;
            List<CData> list = new List<CData>();
            grdMain.DataSource = list;

            string strConn = GetConnectionString();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                string sql = "";
                sql += Environment.NewLine + "select hospital_id,hospital_name,servlet_ip,servlet_ip_2 from Hospitals";

                GetDataReader(sql, conn, delegate(OleDbDataReader reader)
                {
                    CData data = new CData();
                    data.Clear();

                    data.hospital_id = reader["hospital_id"].ToString();
                    data.hospital_name = reader["hospital_name"].ToString();
                    data.servlet_ip = reader["servlet_ip"].ToString();
                    data.servlet_ip_2 = reader["servlet_ip_2"].ToString();
                    data.license_key_no = GetLicenseKeyNo(data.hospital_id, conn);

                    list.Add(data);

                    return true;
                });
            }

            RefreshGridMain();
        }

        private string GetLicenseKeyNo(string hospital_id, OleDbConnection p_conn)
        {
            string ret = "";
            string sql = "";
            sql += Environment.NewLine + "select license_key_no,hospital_id,start_date,end_date from Licenses where hospital_id='" + hospital_id + "'";

            GetDataReader(sql, p_conn, delegate(OleDbDataReader reader)
            {
                CDataSub data = new CDataSub();
                data.Clear();

                string license_key_no = reader["license_key_no"].ToString();
                if (license_key_no == "metro-soft-dev")
                {
                    return true;
                }
                else
                {
                    ret = license_key_no;
                    return false;
                }
            });
            return ret;
        }

        private void RefreshGridMain()
        {
            if (grdMain.InvokeRequired)
            {
                // 폼 이외의 스레드에서 호출한 경우
                grdMain.BeginInvoke(new Action(() => grdMainView.RefreshData()));
            }
            else
            {
                // 폼에서 호출한 경우
                grdMainView.RefreshData();
                Application.DoEvents();
            }
        }

        private void GetDataReader(string p_sql, OleDbConnection p_conn, Func<OleDbDataReader, bool> p_callback)
        {
            try
            {
                using (OleDbCommand cmd = new OleDbCommand(p_sql, p_conn))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bool bContinue = p_callback(reader);
                            if (bContinue == false) break;
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetConnectionString()
        {
            string strConn = "Provider=SQLOLEDB.1;Password=mms;Persist Security Info=true;User ID=sa;Initial Catalog=BaseCamp;Data Source=192.168.1.196,5333";
            return strConn;
        }

        private void grdMainView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.RowHandle < 0) return;

            grdSub.DataSource = null;

            string hospital_id = grdMainView.GetRowCellValue(e.RowHandle, "hospital_id").ToString();

            QuerySub(hospital_id);
        }

        private void QuerySub(string hospital_id)
        {
            grdSub.DataSource = null;
            List<CDataSub> list = new List<CDataSub>();
            grdSub.DataSource = list;

            string strConn = GetConnectionString();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                string sql = "";
                sql += Environment.NewLine + "select license_key_no,hospital_id,start_date,end_date from Licenses where hospital_id='" + hospital_id + "'";

                GetDataReader(sql, conn, delegate(OleDbDataReader reader)
                {
                    CDataSub data = new CDataSub();
                    data.Clear();

                    data.license_key_no = reader["license_key_no"].ToString();
                    data.hospital_id = reader["hospital_id"].ToString();
                    data.start_date = reader["start_date"].ToString();
                    data.end_date = reader["end_date"].ToString();

                    list.Add(data);

                    return true;
                });
            }

            RefreshGridSub();
        }

        private void RefreshGridSub()
        {
            if (grdSub.InvokeRequired)
            {
                // 폼 이외의 스레드에서 호출한 경우
                grdSub.BeginInvoke(new Action(() => grdSubView.RefreshData()));
            }
            else
            {
                // 폼에서 호출한 경우
                grdSubView.RefreshData();
                Application.DoEvents();
            }
        }

        private void grdMainView_DoubleClick(object sender, EventArgs e)
        {
            DevExpress.Utils.DXMouseEventArgs ea = e as DevExpress.Utils.DXMouseEventArgs;
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.InRow || info.InRowCell)
            {
                if (info.Column != null)
                {
                    if (info.Column.FieldName == "servlet_ip")
                    {
                        string value = view.GetRowCellValue(info.RowHandle, info.Column).ToString();
                        if (InputBox("입력", "URL을 입력하세요", ref value) == DialogResult.OK)
                        {
                            string hospital_id = view.GetRowCellValue(info.RowHandle, "hospital_id").ToString();
                            if (MessageBox.Show(hospital_id + Environment.NewLine + value + Environment.NewLine + "저장하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                SaveServletIp(hospital_id, value);
                            }
                        }
                    }
                    if (info.Column.FieldName == "servlet_ip_2")
                    {
                        string value = view.GetRowCellValue(info.RowHandle, info.Column).ToString();
                        if (InputBox("입력", "URL2를 입력하세요", ref value) == DialogResult.OK)
                        {
                            string hospital_id = view.GetRowCellValue(info.RowHandle, "hospital_id").ToString();
                            if (MessageBox.Show(hospital_id + Environment.NewLine + value + Environment.NewLine + "저장하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                SaveServletIp2(hospital_id, value);
                            }
                        }
                    }
                }
            }
        }

        private void SaveServletIp(string hospital_id, string servlet_ip)
        {
            try
            {
                string strConn = GetConnectionString();
                using (OleDbConnection conn = new OleDbConnection(strConn))
                {
                    conn.Open();

                    string sql = "";
                    sql += Environment.NewLine + "update Hospitals set servlet_ip=? where hospital_id=?";

                    List<Object> para = new List<object>();
                    para.Clear();
                    para.Add(servlet_ip);
                    para.Add(hospital_id);

                    ExecuteSql(sql, para, conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveServletIp2(string hospital_id, string servlet_ip_2)
        {
            try
            {
                string strConn = GetConnectionString();
                using (OleDbConnection conn = new OleDbConnection(strConn))
                {
                    conn.Open();

                    string sql = "";
                    sql += Environment.NewLine + "update Hospitals set servlet_ip_2=? where hospital_id=?";

                    List<Object> para = new List<object>();
                    para.Clear();
                    para.Add(servlet_ip_2);
                    para.Add(hospital_id);

                    ExecuteSql(sql, para, conn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DialogResult InputBox(string title, string content, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.ClientSize = new Size(300, 100);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            form.Text = title;
            label.Text = content;
            textBox.Text = value;
            buttonOk.Text = "확인";
            buttonCancel.Text = "취소";

            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(65, 17, 100, 20);
            textBox.SetBounds(65, 40, 220, 20);
            buttonOk.SetBounds(135, 70, 70, 20);
            buttonCancel.SetBounds(215, 70, 70, 20);

            DialogResult dialogResult = form.ShowDialog();

            value = textBox.Text;
            return dialogResult;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MEM_1 f = new MEM_1();
            f.ShowDialog(this);
        }

        private int ExecuteSql(string p_sql, List<Object> p_para, OleDbConnection p_conn)
        {
            int cnt = 0;
            try
            {
                using (OleDbCommand cmd = new OleDbCommand(p_sql, p_conn))
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

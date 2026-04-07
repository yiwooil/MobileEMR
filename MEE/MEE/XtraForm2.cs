using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MEE
{
    public partial class XtraForm2 : DevExpress.XtraEditors.XtraForm
    {
        private List<CDScanClass> m_ScanClassList;

        private Boolean m_isupd = false;
        private String m_ccfid = "";

        public XtraForm2()
        {
            InitializeComponent();

            setEmrScanClassComboBox();

            this.DialogResult = DialogResult.Cancel;

            panBoard.Width = 800;
            panBoard.Height = 1122;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "image files(*.png, *.jpg, *.gif)|*.png;*.jpg;*.gif";
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.Cancel) return;

                txtFileName.Text = dialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtFileName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                String fileName = txtFileName.Text;
                if (fileName == "") return;
                if (File.Exists(fileName) == false) return;

                if (txtCcfName.Text == "")
                {
                    txtCcfName.Text = Path.GetFileNameWithoutExtension(fileName);
                }

                FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                Image img = Image.FromFile(fileName);
                Image image = (Image)(new Bitmap(img, 800, 1122));
                panBoard.BackgroundImage = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                CSFileUpload server = new CSFileUpload();
                if (server.putData(txtFileName.Text) == false)
                {
                    MessageBox.Show("파일 업로드에 실패하였습니다.");
                    return;
                }

                CSCcfSave server2 = new CSCcfSave();
                Boolean bRet = false;
                if (m_isupd == false)
                {
                    String emrScanClass = GetEmrScanClass();
                    // 신규
                    bRet = server2.saveNew(txtCcfName.Text, Path.GetFileName(txtFileName.Text), txtCcfGroup.Text, emrScanClass);
                }
                else
                {
                    // 수정
                    bRet = server2.saveUpd(m_ccfid, txtCcfName.Text, Path.GetFileName(txtFileName.Text));
                }
                if (bRet == false)
                {
                    MessageBox.Show(server2.errorMessage);
                }
                else
                {
                    MessageBox.Show("저장이 완료되었습니다.");
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String GetEmrScanClass()
        {
            CDScanClass scanClass = (CDScanClass)lookUpEdit1.GetSelectedDataRow();
            String emrScanClass = "";
            if(scanClass!=null) emrScanClass = scanClass.scanClass;
            return emrScanClass;
        }

        public DialogResult SaveUpd(String ccfId, String ccfName)
        {
            m_isupd = true;
            m_ccfid = ccfId;
            txtCcfName.Text = ccfName;
            labelControl3.Visible = false;
            txtCcfGroup.Visible = false;
            labelControl4.Visible = false;
            lookUpEdit1.Visible = false;

            this.ShowDialog();
            return this.DialogResult;
        }

        private void setEmrScanClassComboBox()
        {
            lookUpEdit1.Properties.DataSource = null;

            CSScanClass server = new CSScanClass();
            if (server.getData() == true)
            {
                m_ScanClassList = server.m_ScanClassList;
                lookUpEdit1.Properties.DataSource = m_ScanClassList;
                lookUpEdit1.Properties.DisplayMember = "displayScanClassName";
            }
            else
            {
                MessageBox.Show(server.errorMessage);
            }
        }
    }
}
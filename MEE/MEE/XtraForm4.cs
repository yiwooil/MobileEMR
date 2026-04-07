using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MEE
{
    public partial class XtraForm4 : DevExpress.XtraEditors.XtraForm
    {
        private List<CDScanClass> m_ScanClassList;

        public XtraForm4()
        {
            InitializeComponent();
        }

        public DialogResult GetEmrScanClass(String emrScanClass, ref String newEmrScanClass)
        {
            setEmrScanClassListBox(emrScanClass);
            this.ShowDialog();
            if (listBoxControl1.SelectedIndex < 0)
            {
                newEmrScanClass = "";
            }
            else
            {
                newEmrScanClass = m_ScanClassList[listBoxControl1.SelectedIndex].scanClass;
            }
            return this.DialogResult;
        }

        private void setEmrScanClassListBox(String defaultValue)
        {
            listBoxControl1.DataSource = null;

            CSScanClass server = new CSScanClass();
            if (server.getData() == true)
            {
                m_ScanClassList = server.m_ScanClassList;
                listBoxControl1.DataSource = m_ScanClassList;
                listBoxControl1.DisplayMember = "displayScanClassName";

                if (defaultValue == "") return;
                for (int i = 0; i < m_ScanClassList.Count; i++)
                {
                    if (m_ScanClassList[i].scanClass == defaultValue)
                    {
                        listBoxControl1.SelectedIndex = i;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show(server.errorMessage);
            }
        }

    }
}
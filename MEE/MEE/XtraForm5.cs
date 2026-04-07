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
    public partial class XtraForm5 : DevExpress.XtraEditors.XtraForm
    {
        public string m_ccfGroup;
        public string m_hxType;

        public bool m_isOK;

        private bool IsFirst;

        public XtraForm5()
        {
            InitializeComponent();
        }

        private void XtraForm5_Load(object sender, EventArgs e)
        {
            IsFirst = true;
        }

        private void XtraForm5_Activated(object sender, EventArgs e)
        {
            if (IsFirst == false) return;
            IsFirst = false;

            txtCcfGroup.Text = m_ccfGroup;
            txtHxType.Text = m_hxType;

            m_isOK = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            m_ccfGroup = txtCcfGroup.Text.ToString();
            m_hxType = txtHxType.Text.ToString();
            m_isOK = true;
            this.Close();
        }
    }
}
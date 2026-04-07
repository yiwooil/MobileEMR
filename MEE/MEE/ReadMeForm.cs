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
    public partial class ReadMeForm : DevExpress.XtraEditors.XtraForm
    {
        public ReadMeForm()
        {
            InitializeComponent();

            readReadMe();
        }

        private void readReadMe()
        {
            try
            {
                string readMeFilePath = Application.StartupPath + "/readme.txt";
                StreamReader reader = new StreamReader(readMeFilePath);
                String str = reader.ReadToEnd();
                memoEdit1.Text = str;
                memoEdit1.SelectionStart = 1;
                memoEdit1.SelectionLength = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
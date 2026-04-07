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
    public partial class XtraForm3 : DevExpress.XtraEditors.XtraForm
    {
        List<CDField> m_FieldList;

        public XtraForm3()
        {
            InitializeComponent();

            this.InitField();
        }

        private void InitField()
        {
            m_FieldList = new List<CDField>();

            m_FieldList.Add(new CDField("@PID@","환자ID"));
            m_FieldList.Add(new CDField("@PNM@","환자명"));
            m_FieldList.Add(new CDField("@SEX@","성별"));
            m_FieldList.Add(new CDField("@AGE@","나이"));
            m_FieldList.Add(new CDField("@RESID@","주민번호"));
            m_FieldList.Add(new CDField("@ADDR@","환자주소"));
            m_FieldList.Add(new CDField("@HTELNO@","전화번호(집)"));
            m_FieldList.Add(new CDField("@OTELNO@","전화번호(사무실)"));
            m_FieldList.Add(new CDField("@YY@","현재년도"));
            m_FieldList.Add(new CDField("@MM@","현재월"));
            m_FieldList.Add(new CDField("@DD@","현재일자"));

            m_FieldList.Add(new CDField("@BDEDT@","입원일"));
            m_FieldList.Add(new CDField("@BEDODT@","퇴원일"));
            m_FieldList.Add(new CDField("@INSNM@","피보험자(보호자)성병"));
            m_FieldList.Add(new CDField("@FAMRELCD@","환자와의관계"));
            m_FieldList.Add(new CDField("@P_RESID@","피보험자(보호자)주민번호"));
            m_FieldList.Add(new CDField("@DPTNM@","진료과"));
            m_FieldList.Add(new CDField("@DRNM@","의사"));
            m_FieldList.Add(new CDField("@WARD@","병동"));
            m_FieldList.Add(new CDField("@MADDR@","피보험자(보호자)주소"));
            m_FieldList.Add(new CDField("@DXNM@","입원상병"));
            m_FieldList.Add(new CDField("@IBDYY@","입원년도"));
            m_FieldList.Add(new CDField("@IBDMM@","입원월"));
            m_FieldList.Add(new CDField("@IBDDD@","입원일자"));

            m_FieldList.Add(new CDField("@HOSNM@","병원명"));
            m_FieldList.Add(new CDField("@OPNM@", "수술명"));

            gridControl1.DataSource=m_FieldList;
        }
    }
}
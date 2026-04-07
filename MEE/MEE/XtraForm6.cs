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
    public partial class XtraForm6 : DevExpress.XtraEditors.XtraForm
    {
        public string m_ccfId;
        public bool m_isOK;

        private bool IsFirst;

        private List<CDCcfData> m_ccfDataList = new List<CDCcfData>();
        private string m_page1_ccfid; // 첫 페이지 동의서ID
        private string m_page1_sub_page_list; // 페이지 리스트

        public XtraForm6()
        {
            InitializeComponent();
        }

        private void XtraForm6_Load(object sender, EventArgs e)
        {
            IsFirst = true;
        }

        private void XtraForm6_Activated(object sender, EventArgs e)
        {
            if (IsFirst == false) return;
            IsFirst = false;

            GetData();
        }

        private void GetData()
        {
            Dictionary<String, String> dicDup = new Dictionary<String, String>(); // 동의서가 중복으로 조회되는 현상을 막는 변수

            List<CDCcfData> ccfDataList = GetCcfDataList();
            if (ccfDataList == null) return;

            // 나중에 저장할 때를 대비하여 담아 놓는다.
            dicDup.Clear();
            m_ccfDataList.Clear();
            for (int i = 0; i < ccfDataList.Count; i++)
            {
                if (dicDup.ContainsKey(ccfDataList[i].ccfId) == false)
                {
                    CDCcfData data = CopyData(ccfDataList[i]);
                    m_ccfDataList.Add(data);
                    dicDup.Add(ccfDataList[i].ccfId, "");
                }
            }

            m_page1_ccfid = "";
            m_page1_sub_page_list = "";

            // 넘어온 동의서가 1페이지이다.
            for (int i = 0; i < ccfDataList.Count; i++)
            {
                if (ccfDataList[i].subPageNo == "" && ccfDataList[i].ccfId == m_ccfId)
                {
                    m_page1_ccfid = m_ccfId;
                    m_page1_sub_page_list = ccfDataList[i].subPageList;
                    break;
                }
            }
            // 1번 페이지 동의서를 찾는다.
            if (m_page1_ccfid == "")
            {
                for (int i = 0; i < ccfDataList.Count; i++)
                {
                    if (ccfDataList[i].subPageNo == "")
                    {
                        if (ccfDataList[i].subPageList != "")
                        {
                            String[] pageList = ccfDataList[i].subPageList.Split(';');
                            for (int j = 0; j < pageList.Length; j++)
                            {
                                if (pageList[j] == m_ccfId)
                                {
                                    m_page1_ccfid = ccfDataList[i].ccfId;
                                    m_page1_sub_page_list = ccfDataList[i].subPageList;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            // 그래도 혹시 못 찾았을까봐
            if (m_page1_ccfid == "") m_page1_ccfid = m_ccfId;
            // 2페이지부터 동의서를 딕셔너리에 담아놓는다.
            Dictionary<String, String> dicSubPageList = new Dictionary<string, string>();
            if (m_page1_sub_page_list != "")
            {
                String[] pageList = m_page1_sub_page_list.Split(';');
                for (int j = 0; j < pageList.Length; j++)
                {
                    dicSubPageList.Add(pageList[j], "");
                }
            }

            List<CDCcfData> list_left = new List<CDCcfData>();
            List<CDCcfData> list_right = new List<CDCcfData>();

            dicDup.Clear();
            for (int i = 0; i < ccfDataList.Count; i++)
            {
                if (dicDup.ContainsKey(ccfDataList[i].ccfId) == false)
                {
                    dicDup.Add(ccfDataList[i].ccfId, "");

                    CDCcfData data = CopyData(ccfDataList[i]);

                    if (data.ccfId == m_page1_ccfid)
                        list_left.Add(data);
                    else if(dicSubPageList.ContainsKey(data.ccfId)==true)
                        list_left.Add(data);
                    else
                        list_right.Add(data);
                }
            }
            grdLeft.DataSource = list_left;
            grdRight.DataSource = list_right;

            RefreshGrid();
        }

        private List<CDCcfData> GetCcfDataList()
        {
            CSCcfData server = new CSCcfData();
            if (server.getData() == true)
            {
                return server.m_CcfDataList;
            }
            else
            {
                MessageBox.Show(server.errorMessage);
                return null;
            }
        }

        private void RefreshGrid()
        {
            if (grdLeft.InvokeRequired)
            {
                // 폼 이외의 스레드에서 호출한 경우
                grdLeft.BeginInvoke(new Action(() => grdLeftView.RefreshData()));
            }
            else
            {
                // 폼에서 호출한 경우
                grdLeftView.RefreshData();
                Application.DoEvents();
            }
            if (grdRight.InvokeRequired)
            {
                // 폼 이외의 스레드에서 호출한 경우
                grdRight.BeginInvoke(new Action(() => grdRightView.RefreshData()));
            }
            else
            {
                // 폼에서 호출한 경우
                grdRightView.RefreshData();
                Application.DoEvents();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int rowHandle = grdLeftView.FocusedRowHandle;
            if (rowHandle < 0) return;
            if (rowHandle == 0) return; // 맨 윗줄임.

            List<CDCcfData> left_list = (List<CDCcfData>)grdLeft.DataSource;

            CDCcfData data = CopyData(left_list[rowHandle]);

            left_list.RemoveAt(rowHandle);
            left_list.Insert(rowHandle - 1, data);

            grdLeftView.FocusedRowHandle = rowHandle - 1;

            RefreshGrid();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int rowHandle = grdLeftView.FocusedRowHandle;
            if (rowHandle < 0) return;
            if (rowHandle == grdLeftView.RowCount - 1) return; // 맨 아랫줄임.

            List<CDCcfData> left_list = (List<CDCcfData>)grdLeft.DataSource;

            CDCcfData data = CopyData(left_list[rowHandle]);

            left_list.RemoveAt(rowHandle);
            left_list.Insert(rowHandle + 1, data);

            grdLeftView.FocusedRowHandle = rowHandle + 1;

            RefreshGrid();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            int rowHandle = grdRightView.FocusedRowHandle;
            if (rowHandle < 0) return;

            List<CDCcfData> left_list = (List<CDCcfData>)grdLeft.DataSource;
            List<CDCcfData> right_list = (List<CDCcfData>)grdRight.DataSource;

            CDCcfData data = CopyData(right_list[rowHandle]);
            left_list.Add(data);

            right_list.RemoveAt(rowHandle);

            RefreshGrid();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            int rowHandle = grdLeftView.FocusedRowHandle;
            if (rowHandle < 0) return;

            List<CDCcfData> left_list = (List<CDCcfData>)grdLeft.DataSource;
            List<CDCcfData> right_list = (List<CDCcfData>)grdRight.DataSource;

            CDCcfData data = CopyData(left_list[rowHandle]);
            right_list.Add(data);

            left_list.RemoveAt(rowHandle);

            RefreshGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
                GetData();
                MessageBox.Show("저장하였습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SaveData()
        {
            List<CDCcfData> left_list = (List<CDCcfData>)grdLeft.DataSource;
            int row = 0;
            string new_page1_ccfid = ""; // 첫 페이지 동의서ID
            string new_page1_sub_page_list = ""; // 페이지 리스트
            string new_ccf_group = "";
            foreach (CDCcfData data in left_list)
            {
                if (row == 0)
                {
                    new_page1_ccfid = data.ccfId;
                    new_ccf_group = data.ccfGroupValue;
                }
                else if (row == 1)
                {
                    new_page1_sub_page_list = data.ccfId;
                }
                else
                {
                    new_page1_sub_page_list += ";" + data.ccfId;
                }
                row++;
            }

            // 동의서 출력 순서를 다시 설정한다.
            Dictionary<string, string> dupDic = new Dictionary<string, string>();
            string disp_ccf_list = "";
            for (int idx = 0; idx < m_ccfDataList.Count; idx++)
            {
                if (m_ccfDataList[idx].ccfId == new_page1_ccfid)
                {
                    // 한 권으로 묶는 동의서리스트
                    foreach (CDCcfData data in left_list)
                    {
                        if (disp_ccf_list == "")
                            disp_ccf_list = data.ccfId;
                        else
                            disp_ccf_list += "," + data.ccfId;
                        dupDic.Add(data.ccfId, ""); // 한 번만 사용하자...
                    }
                }
                else
                {
                    // 나머지 동의서를 순서대로 
                    if (dupDic.ContainsKey(m_ccfDataList[idx].ccfId) == false)
                    {
                        if (disp_ccf_list == "")
                            disp_ccf_list = m_ccfDataList[idx].ccfId;
                        else
                            disp_ccf_list += "," + m_ccfDataList[idx].ccfId;
                    }
                }
            }

            // 서버에 저장하자.
            CSCcfSave server = new CSCcfSave();
            if (server.savePage(m_page1_ccfid, m_page1_sub_page_list, new_page1_ccfid, new_page1_sub_page_list, new_ccf_group, disp_ccf_list) == true)
            {
                return;
            }
            else
            {
                throw new Exception(server.errorMessage);
            }
        }

        private CDCcfData CopyData(CDCcfData srcData)
        {
            CDCcfData data = new CDCcfData();
            
            data.ccfId = srcData.ccfId;
            data.ccfName = srcData.ccfName;
            data.ccfFileName = srcData.ccfFileName;
            data.ccfGroup = srcData.ccfGroup;
            data.ccfGroupValue = srcData.ccfGroupValue;
            data.subPageList = srcData.subPageList;
            data.subPageNo = srcData.subPageNo;
            data.hxType = srcData.hxType;
            data.emrScanClass = srcData.emrScanClass;
            data.emrScanClassName = srcData.emrScanClassName;

            return data;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text.ToString().Replace(" ", "");
            if (search == "")
            {
                grdRightView.LayoutChanged();
                return;
            }

            for (int row = 0; row < grdRightView.RowCount; row++)
            {
                string ccfName = grdRightView.GetRowCellValue(row, "ccfName").ToString().Replace(" ", "");
                if (ccfName.Contains(search) == true)
                {
                    grdRightView.FocusedRowHandle = row;
                    break;
                }
            }
            grdRightView.LayoutChanged();
        }

        private void grdRightView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string search = txtSearch.Text.ToString().Replace(" ", "");
            string ccfName = grdRightView.GetRowCellValue(e.RowHandle, "ccfName").ToString().Replace(" ", "");
            if (e.RowHandle == grdRightView.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.LightCyan;
            }
            else if (search != "" && ccfName.Contains(search) == true)
            {
                e.Appearance.BackColor = Color.LightPink;
            }
            else
            {
                e.Appearance.BackColor = Color.White;
            }
            
        }
    }
}
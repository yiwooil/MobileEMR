namespace MEE
{
    partial class XtraForm6
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdLeft = new DevExpress.XtraGrid.GridControl();
            this.grdLeftView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdRight = new DevExpress.XtraGrid.GridControl();
            this.grdRightView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnDown = new DevExpress.XtraEditors.SimpleButton();
            this.btnLeft = new DevExpress.XtraEditors.SimpleButton();
            this.btnRight = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLeftView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRightView)).BeginInit();
            this.SuspendLayout();
            // 
            // grdLeft
            // 
            this.grdLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdLeft.Location = new System.Drawing.Point(12, 41);
            this.grdLeft.MainView = this.grdLeftView;
            this.grdLeft.Name = "grdLeft";
            this.grdLeft.Size = new System.Drawing.Size(493, 547);
            this.grdLeft.TabIndex = 1;
            this.grdLeft.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdLeftView});
            // 
            // grdLeftView
            // 
            this.grdLeftView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.grdLeftView.GridControl = this.grdLeft;
            this.grdLeftView.Name = "grdLeftView";
            this.grdLeftView.OptionsView.ColumnAutoWidth = false;
            this.grdLeftView.OptionsView.ShowGroupPanel = false;
            this.grdLeftView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "ccfId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 55;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "동의서";
            this.gridColumn2.FieldName = "ccfName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 400;
            // 
            // grdRight
            // 
            this.grdRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRight.Location = new System.Drawing.Point(552, 41);
            this.grdRight.MainView = this.grdRightView;
            this.grdRight.Name = "grdRight";
            this.grdRight.Size = new System.Drawing.Size(510, 547);
            this.grdRight.TabIndex = 2;
            this.grdRight.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdRightView});
            // 
            // grdRightView
            // 
            this.grdRightView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.grdRightView.GridControl = this.grdRight;
            this.grdRightView.Name = "grdRightView";
            this.grdRightView.OptionsView.ColumnAutoWidth = false;
            this.grdRightView.OptionsView.ShowGroupPanel = false;
            this.grdRightView.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.grdRightView.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.grdRightView_RowCellStyle);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "ID";
            this.gridColumn3.FieldName = "ccfId";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            this.gridColumn3.Width = 55;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "동의서";
            this.gridColumn4.FieldName = "ccfName";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            this.gridColumn4.Width = 400;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(12, 12);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(30, 25);
            this.btnUp.TabIndex = 8;
            this.btnUp.Text = "↑";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(44, 12);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 25);
            this.btnDown.TabIndex = 9;
            this.btnDown.Text = "↓";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(513, 143);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(30, 25);
            this.btnLeft.TabIndex = 10;
            this.btnLeft.Text = "←";
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(513, 170);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(30, 25);
            this.btnRight.TabIndex = 11;
            this.btnRight.Text = "→";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(403, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 25);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "저장";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(632, 15);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(429, 22);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(554, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "동의서 검색";
            // 
            // XtraForm6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 600);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.grdRight);
            this.Controls.Add(this.grdLeft);
            this.Name = "XtraForm6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "페이지 설정";
            this.Load += new System.EventHandler(this.XtraForm6_Load);
            this.Activated += new System.EventHandler(this.XtraForm6_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.grdLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLeftView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRightView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdLeft;
        private DevExpress.XtraGrid.Views.Grid.GridView grdLeftView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.GridControl grdRight;
        private DevExpress.XtraGrid.Views.Grid.GridView grdRightView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnUp;
        private DevExpress.XtraEditors.SimpleButton btnDown;
        private DevExpress.XtraEditors.SimpleButton btnLeft;
        private DevExpress.XtraEditors.SimpleButton btnRight;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
    }
}
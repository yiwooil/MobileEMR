namespace MEE
{
    partial class XtraForm5
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
            this.txtHxType = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtCcfGroup = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtHxType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCcfGroup.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHxType
            // 
            this.txtHxType.Location = new System.Drawing.Point(18, 97);
            this.txtHxType.Name = "txtHxType";
            this.txtHxType.Size = new System.Drawing.Size(254, 20);
            this.txtHxType.TabIndex = 8;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(19, 77);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(158, 14);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "추가기능(수술이력,일자선택)";
            // 
            // txtCcfGroup
            // 
            this.txtCcfGroup.Location = new System.Drawing.Point(18, 41);
            this.txtCcfGroup.Name = "txtCcfGroup";
            this.txtCcfGroup.Size = new System.Drawing.Size(254, 20);
            this.txtCcfGroup.TabIndex = 6;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(190, 14);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "그룹(두 개 이상인 경우 ;으로 분리)";
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(145, 151);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 10;
            this.simpleButton2.Text = "취소";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(64, 151);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "확인";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // XtraForm5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtHxType);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtCcfGroup);
            this.Controls.Add(this.labelControl1);
            this.Name = "XtraForm5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "그룹 등 변경";
            this.Load += new System.EventHandler(this.XtraForm5_Load);
            this.Activated += new System.EventHandler(this.XtraForm5_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.txtHxType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCcfGroup.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtHxType;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtCcfGroup;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
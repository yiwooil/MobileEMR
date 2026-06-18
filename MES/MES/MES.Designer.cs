namespace MES
{
    partial class MES
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtWin3264 = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtTomcatFolder = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtMetroHis = new System.Windows.Forms.TextBox();
            this.txtDBIp = new System.Windows.Forms.TextBox();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.txtHospitalName = new System.Windows.Forms.TextBox();
            this.txtHospitalNo = new System.Windows.Forms.TextBox();
            this.txtEmrScan = new System.Windows.Forms.TextBox();
            this.txtComplusIP = new System.Windows.Forms.TextBox();
            this.txtEmrScanRead = new System.Windows.Forms.TextBox();
            this.txtNewScanFg = new System.Windows.Forms.TextBox();
            this.chkJRE = new System.Windows.Forms.CheckBox();
            this.chkTOMCAT = new System.Windows.Forms.CheckBox();
            this.chkTEMURIN = new System.Windows.Forms.CheckBox();
            this.txtTemurin = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtWin3264
            // 
            this.txtWin3264.Location = new System.Drawing.Point(12, 40);
            this.txtWin3264.Name = "txtWin3264";
            this.txtWin3264.ReadOnly = true;
            this.txtWin3264.Size = new System.Drawing.Size(118, 21);
            this.txtWin3264.TabIndex = 0;
            this.txtWin3264.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(12, 478);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(518, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "설치 시작";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtTomcatFolder
            // 
            this.txtTomcatFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTomcatFolder.Location = new System.Drawing.Point(138, 40);
            this.txtTomcatFolder.Name = "txtTomcatFolder";
            this.txtTomcatFolder.ReadOnly = true;
            this.txtTomcatFolder.Size = new System.Drawing.Size(392, 21);
            this.txtTomcatFolder.TabIndex = 3;
            this.txtTomcatFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.Font = new System.Drawing.Font("굴림체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMsg.Location = new System.Drawing.Point(12, 231);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(516, 241);
            this.txtMsg.TabIndex = 4;
            // 
            // txtMetroHis
            // 
            this.txtMetroHis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMetroHis.Location = new System.Drawing.Point(138, 67);
            this.txtMetroHis.Name = "txtMetroHis";
            this.txtMetroHis.ReadOnly = true;
            this.txtMetroHis.Size = new System.Drawing.Size(392, 21);
            this.txtMetroHis.TabIndex = 5;
            this.txtMetroHis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDBIp
            // 
            this.txtDBIp.Location = new System.Drawing.Point(12, 94);
            this.txtDBIp.Name = "txtDBIp";
            this.txtDBIp.ReadOnly = true;
            this.txtDBIp.Size = new System.Drawing.Size(198, 21);
            this.txtDBIp.TabIndex = 6;
            this.txtDBIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDBName
            // 
            this.txtDBName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBName.Location = new System.Drawing.Point(216, 94);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.ReadOnly = true;
            this.txtDBName.Size = new System.Drawing.Size(314, 21);
            this.txtDBName.TabIndex = 7;
            this.txtDBName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHospitalName
            // 
            this.txtHospitalName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHospitalName.Location = new System.Drawing.Point(216, 121);
            this.txtHospitalName.Name = "txtHospitalName";
            this.txtHospitalName.ReadOnly = true;
            this.txtHospitalName.Size = new System.Drawing.Size(314, 21);
            this.txtHospitalName.TabIndex = 8;
            this.txtHospitalName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHospitalNo
            // 
            this.txtHospitalNo.Location = new System.Drawing.Point(12, 121);
            this.txtHospitalNo.Name = "txtHospitalNo";
            this.txtHospitalNo.ReadOnly = true;
            this.txtHospitalNo.Size = new System.Drawing.Size(196, 21);
            this.txtHospitalNo.TabIndex = 9;
            this.txtHospitalNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtEmrScan
            // 
            this.txtEmrScan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmrScan.Location = new System.Drawing.Point(60, 148);
            this.txtEmrScan.Name = "txtEmrScan";
            this.txtEmrScan.ReadOnly = true;
            this.txtEmrScan.Size = new System.Drawing.Size(468, 21);
            this.txtEmrScan.TabIndex = 10;
            this.txtEmrScan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmrScan.DoubleClick += new System.EventHandler(this.txtEmrScan_DoubleClick);
            // 
            // txtComplusIP
            // 
            this.txtComplusIP.Location = new System.Drawing.Point(12, 67);
            this.txtComplusIP.Name = "txtComplusIP";
            this.txtComplusIP.ReadOnly = true;
            this.txtComplusIP.Size = new System.Drawing.Size(118, 21);
            this.txtComplusIP.TabIndex = 11;
            this.txtComplusIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtComplusIP.DoubleClick += new System.EventHandler(this.txtComplusIP_DoubleClick);
            this.txtComplusIP.TextChanged += new System.EventHandler(this.txtComplusIP_TextChanged);
            // 
            // txtEmrScanRead
            // 
            this.txtEmrScanRead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmrScanRead.Location = new System.Drawing.Point(12, 177);
            this.txtEmrScanRead.Name = "txtEmrScanRead";
            this.txtEmrScanRead.ReadOnly = true;
            this.txtEmrScanRead.Size = new System.Drawing.Size(516, 21);
            this.txtEmrScanRead.TabIndex = 12;
            this.txtEmrScanRead.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEmrScanRead.DoubleClick += new System.EventHandler(this.txtEmrScanRead_DoubleClick);
            // 
            // txtNewScanFg
            // 
            this.txtNewScanFg.Location = new System.Drawing.Point(12, 148);
            this.txtNewScanFg.Name = "txtNewScanFg";
            this.txtNewScanFg.ReadOnly = true;
            this.txtNewScanFg.Size = new System.Drawing.Size(42, 21);
            this.txtNewScanFg.TabIndex = 13;
            this.txtNewScanFg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkJRE
            // 
            this.chkJRE.AutoSize = true;
            this.chkJRE.Location = new System.Drawing.Point(106, 12);
            this.chkJRE.Name = "chkJRE";
            this.chkJRE.Size = new System.Drawing.Size(75, 16);
            this.chkJRE.TabIndex = 14;
            this.chkJRE.Text = "jre-8u202";
            this.chkJRE.UseVisualStyleBackColor = true;
            // 
            // chkTOMCAT
            // 
            this.chkTOMCAT.AutoSize = true;
            this.chkTOMCAT.Checked = true;
            this.chkTOMCAT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTOMCAT.Location = new System.Drawing.Point(203, 12);
            this.chkTOMCAT.Name = "chkTOMCAT";
            this.chkTOMCAT.Size = new System.Drawing.Size(106, 16);
            this.chkTOMCAT.TabIndex = 15;
            this.chkTOMCAT.Text = "tomcat-7.0.109";
            this.chkTOMCAT.UseVisualStyleBackColor = true;
            // 
            // chkTEMURIN
            // 
            this.chkTEMURIN.AutoSize = true;
            this.chkTEMURIN.Checked = true;
            this.chkTEMURIN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTEMURIN.Location = new System.Drawing.Point(12, 12);
            this.chkTEMURIN.Name = "chkTEMURIN";
            this.chkTEMURIN.Size = new System.Drawing.Size(71, 16);
            this.chkTEMURIN.TabIndex = 16;
            this.chkTEMURIN.Text = "Temurin";
            this.chkTEMURIN.UseVisualStyleBackColor = true;
            // 
            // txtTemurin
            // 
            this.txtTemurin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTemurin.Location = new System.Drawing.Point(14, 204);
            this.txtTemurin.Name = "txtTemurin";
            this.txtTemurin.ReadOnly = true;
            this.txtTemurin.Size = new System.Drawing.Size(516, 21);
            this.txtTemurin.TabIndex = 17;
            this.txtTemurin.Text = "C:\\Program Files\\Eclipse Adoptium\\jdk-8.0.472.8-hotspot\\jre\\bin\\server\\jvm.dll";
            this.txtTemurin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 521);
            this.Controls.Add(this.txtTemurin);
            this.Controls.Add(this.chkTEMURIN);
            this.Controls.Add(this.chkTOMCAT);
            this.Controls.Add(this.chkJRE);
            this.Controls.Add(this.txtNewScanFg);
            this.Controls.Add(this.txtEmrScanRead);
            this.Controls.Add(this.txtComplusIP);
            this.Controls.Add(this.txtEmrScan);
            this.Controls.Add(this.txtHospitalNo);
            this.Controls.Add(this.txtHospitalName);
            this.Controls.Add(this.txtDBName);
            this.Controls.Add(this.txtDBIp);
            this.Controls.Add(this.txtMetroHis);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.txtTomcatFolder);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtWin3264);
            this.Name = "MES";
            this.Text = "Metro EMR Setup";
            this.Load += new System.EventHandler(this.MES_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWin3264;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtTomcatFolder;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.TextBox txtMetroHis;
        private System.Windows.Forms.TextBox txtDBIp;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.TextBox txtHospitalName;
        private System.Windows.Forms.TextBox txtHospitalNo;
        private System.Windows.Forms.TextBox txtEmrScan;
        private System.Windows.Forms.TextBox txtComplusIP;
        private System.Windows.Forms.TextBox txtEmrScanRead;
        private System.Windows.Forms.TextBox txtNewScanFg;
        private System.Windows.Forms.CheckBox chkJRE;
        private System.Windows.Forms.CheckBox chkTOMCAT;
        private System.Windows.Forms.CheckBox chkTEMURIN;
        private System.Windows.Forms.TextBox txtTemurin;
    }
}


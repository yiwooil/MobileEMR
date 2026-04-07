namespace MET
{
    partial class MET
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHosno = new System.Windows.Forms.TextBox();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCcfid = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBededt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOdt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOno = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBdiv = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.lstJobKind = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "병원ID";
            // 
            // txtHosno
            // 
            this.txtHosno.Location = new System.Drawing.Point(303, 5);
            this.txtHosno.Name = "txtHosno";
            this.txtHosno.Size = new System.Drawing.Size(100, 21);
            this.txtHosno.TabIndex = 1;
            this.txtHosno.Text = "0000";
            this.txtHosno.TextChanged += new System.EventHandler(this.txtHosno_TextChanged);
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(303, 32);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(263, 21);
            this.txtAddr.TabIndex = 3;
            this.txtAddr.Text = "http://localhost:8143";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(244, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "접속주소";
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(303, 59);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(100, 21);
            this.txtUid.TabIndex = 5;
            this.txtUid.Text = "mms";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "로그인";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(466, 59);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(100, 21);
            this.txtPwd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(407, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "비밀번호";
            // 
            // txtCcfid
            // 
            this.txtCcfid.Location = new System.Drawing.Point(303, 219);
            this.txtCcfid.Name = "txtCcfid";
            this.txtCcfid.Size = new System.Drawing.Size(100, 21);
            this.txtCcfid.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "동의서ID";
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(303, 86);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(100, 21);
            this.txtPid.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(244, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "환자ID";
            // 
            // txtBededt
            // 
            this.txtBededt.Location = new System.Drawing.Point(303, 112);
            this.txtBededt.Name = "txtBededt";
            this.txtBededt.Size = new System.Drawing.Size(100, 21);
            this.txtBededt.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(244, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "입원일";
            // 
            // txtOdt
            // 
            this.txtOdt.Location = new System.Drawing.Point(303, 165);
            this.txtOdt.Name = "txtOdt";
            this.txtOdt.Size = new System.Drawing.Size(100, 21);
            this.txtOdt.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "처방일";
            // 
            // txtOno
            // 
            this.txtOno.Location = new System.Drawing.Point(303, 192);
            this.txtOno.Name = "txtOno";
            this.txtOno.Size = new System.Drawing.Size(100, 21);
            this.txtOno.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(244, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 20;
            this.label9.Text = "처방번호";
            // 
            // txtBdiv
            // 
            this.txtBdiv.Location = new System.Drawing.Point(303, 138);
            this.txtBdiv.Name = "txtBdiv";
            this.txtBdiv.Size = new System.Drawing.Size(100, 21);
            this.txtBdiv.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(244, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "입외구분";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(303, 246);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 21);
            this.txtSearch.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(244, 250);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "검색어";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(12, 244);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(213, 23);
            this.btnRun.TabIndex = 31;
            this.btnRun.Text = "실행";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // lstJobKind
            // 
            this.lstJobKind.FormattingEnabled = true;
            this.lstJobKind.ItemHeight = 12;
            this.lstJobKind.Items.AddRange(new object[] {
            "로그인",
            "재원환자명단",
            "동의서리스트",
            "동의서내용",
            "기능검사결과",
            "임시저장동의서리스트(모든환자)",
            "임시저장동의서리스트(환자별)",
            "환자검색"});
            this.lstJobKind.Location = new System.Drawing.Point(12, 9);
            this.lstJobKind.Name = "lstJobKind";
            this.lstJobKind.Size = new System.Drawing.Size(213, 232);
            this.lstJobKind.TabIndex = 32;
            this.lstJobKind.SelectedIndexChanged += new System.EventHandler(this.lstJobKind_SelectedIndexChanged);
            // 
            // MET
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 276);
            this.Controls.Add(this.lstJobKind);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtBdiv);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtOno);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtOdt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBededt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCcfid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHosno);
            this.Controls.Add(this.label1);
            this.Name = "MET";
            this.Text = "모바일EMR테스트(MET)";
            this.Load += new System.EventHandler(this.MET_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHosno;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCcfid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBededt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOdt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOno;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBdiv;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ListBox lstJobKind;
    }
}


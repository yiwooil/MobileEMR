namespace MEM
{
    partial class MEM_1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHospitalId = new System.Windows.Forms.TextBox();
            this.txtHospitalName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServletIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServletIp2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLicenseKeyNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMakeLicenseKeyNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "병원ID";
            // 
            // txtHospitalId
            // 
            this.txtHospitalId.Location = new System.Drawing.Point(89, 47);
            this.txtHospitalId.Name = "txtHospitalId";
            this.txtHospitalId.Size = new System.Drawing.Size(236, 21);
            this.txtHospitalId.TabIndex = 1;
            // 
            // txtHospitalName
            // 
            this.txtHospitalName.Location = new System.Drawing.Point(89, 74);
            this.txtHospitalName.Name = "txtHospitalName";
            this.txtHospitalName.Size = new System.Drawing.Size(236, 21);
            this.txtHospitalName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "병원명";
            // 
            // txtServletIp
            // 
            this.txtServletIp.Location = new System.Drawing.Point(89, 101);
            this.txtServletIp.Name = "txtServletIp";
            this.txtServletIp.Size = new System.Drawing.Size(236, 21);
            this.txtServletIp.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Servlet IP";
            // 
            // txtServletIp2
            // 
            this.txtServletIp2.Location = new System.Drawing.Point(89, 128);
            this.txtServletIp2.Name = "txtServletIp2";
            this.txtServletIp2.Size = new System.Drawing.Size(236, 21);
            this.txtServletIp2.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Servlet IP 2";
            // 
            // txtLicenseKeyNo
            // 
            this.txtLicenseKeyNo.Location = new System.Drawing.Point(89, 155);
            this.txtLicenseKeyNo.Name = "txtLicenseKeyNo";
            this.txtLicenseKeyNo.Size = new System.Drawing.Size(236, 21);
            this.txtLicenseKeyNo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "인증번호";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(91, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "저장";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMakeLicenseKeyNo
            // 
            this.btnMakeLicenseKeyNo.Location = new System.Drawing.Point(217, 191);
            this.btnMakeLicenseKeyNo.Name = "btnMakeLicenseKeyNo";
            this.btnMakeLicenseKeyNo.Size = new System.Drawing.Size(106, 23);
            this.btnMakeLicenseKeyNo.TabIndex = 11;
            this.btnMakeLicenseKeyNo.Text = "인증번호 만들기";
            this.btnMakeLicenseKeyNo.UseVisualStyleBackColor = true;
            this.btnMakeLicenseKeyNo.Click += new System.EventHandler(this.btnMakeLicenseKeyNo_Click);
            // 
            // MEM_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 262);
            this.Controls.Add(this.btnMakeLicenseKeyNo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtLicenseKeyNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtServletIp2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtServletIp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHospitalName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHospitalId);
            this.Controls.Add(this.label1);
            this.Name = "MEM_1";
            this.Text = "병원추가(MEM_1)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHospitalId;
        private System.Windows.Forms.TextBox txtHospitalName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServletIp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServletIp2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLicenseKeyNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMakeLicenseKeyNo;
    }
}
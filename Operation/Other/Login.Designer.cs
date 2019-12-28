namespace Operation.Other
{
    partial class Login
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
            this.btn_logined = new System.Windows.Forms.Button();
            this.cb_dianpu = new System.Windows.Forms.ComboBox();
            this.btn_account = new System.Windows.Forms.Button();
            this.btn_pwd = new System.Windows.Forms.Button();
            this.lbl_account = new System.Windows.Forms.Label();
            this.lbl_pwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_logined
            // 
            this.btn_logined.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_logined.Location = new System.Drawing.Point(182, 321);
            this.btn_logined.Name = "btn_logined";
            this.btn_logined.Size = new System.Drawing.Size(183, 34);
            this.btn_logined.TabIndex = 1;
            this.btn_logined.Text = "登陆后点击此按钮打开软件";
            this.btn_logined.UseVisualStyleBackColor = true;
            this.btn_logined.Click += new System.EventHandler(this.btn_logined_Click);
            // 
            // cb_dianpu
            // 
            this.cb_dianpu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cb_dianpu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_dianpu.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_dianpu.FormattingEnabled = true;
            this.cb_dianpu.Location = new System.Drawing.Point(0, 322);
            this.cb_dianpu.Name = "cb_dianpu";
            this.cb_dianpu.Size = new System.Drawing.Size(183, 32);
            this.cb_dianpu.TabIndex = 2;
            this.cb_dianpu.SelectedIndexChanged += new System.EventHandler(this.cb_dianpu_SelectedIndexChanged);
            // 
            // btn_account
            // 
            this.btn_account.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_account.Location = new System.Drawing.Point(0, 276);
            this.btn_account.Name = "btn_account";
            this.btn_account.Size = new System.Drawing.Size(183, 47);
            this.btn_account.TabIndex = 3;
            this.btn_account.Text = "复制账号";
            this.btn_account.UseVisualStyleBackColor = true;
            this.btn_account.Click += new System.EventHandler(this.btn_account_Click);
            // 
            // btn_pwd
            // 
            this.btn_pwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_pwd.Location = new System.Drawing.Point(182, 276);
            this.btn_pwd.Name = "btn_pwd";
            this.btn_pwd.Size = new System.Drawing.Size(183, 47);
            this.btn_pwd.TabIndex = 3;
            this.btn_pwd.Text = "复制密码";
            this.btn_pwd.UseVisualStyleBackColor = true;
            this.btn_pwd.Click += new System.EventHandler(this.btn_pwd_Click);
            // 
            // lbl_account
            // 
            this.lbl_account.AutoSize = true;
            this.lbl_account.Location = new System.Drawing.Point(12, 188);
            this.lbl_account.Name = "lbl_account";
            this.lbl_account.Size = new System.Drawing.Size(0, 12);
            this.lbl_account.TabIndex = 4;
            this.lbl_account.Visible = false;
            // 
            // lbl_pwd
            // 
            this.lbl_pwd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_pwd.AutoSize = true;
            this.lbl_pwd.Location = new System.Drawing.Point(183, 261);
            this.lbl_pwd.Name = "lbl_pwd";
            this.lbl_pwd.Size = new System.Drawing.Size(0, 12);
            this.lbl_pwd.TabIndex = 4;
            this.lbl_pwd.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 354);
            this.Controls.Add(this.lbl_pwd);
            this.Controls.Add(this.lbl_account);
            this.Controls.Add(this.btn_pwd);
            this.Controls.Add(this.btn_account);
            this.Controls.Add(this.cb_dianpu);
            this.Controls.Add(this.btn_logined);
            this.Name = "Login";
            this.Text = "登录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_logined;
        private System.Windows.Forms.ComboBox cb_dianpu;
        private System.Windows.Forms.Button btn_account;
        private System.Windows.Forms.Button btn_pwd;
        private System.Windows.Forms.Label lbl_account;
        private System.Windows.Forms.Label lbl_pwd;
    }
}
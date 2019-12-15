namespace words
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
            this.lbl_account = new System.Windows.Forms.Label();
            this.txt_account = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.SuspendLayout();
            // 
            // lbl_account
            // 
            this.lbl_account.AutoSize = true;
            this.lbl_account.Location = new System.Drawing.Point(60, 51);
            this.lbl_account.Name = "lbl_account";
            this.lbl_account.Size = new System.Drawing.Size(41, 12);
            this.lbl_account.TabIndex = 0;
            this.lbl_account.Text = "账号：";
            // 
            // txt_account
            // 
            this.txt_account.Location = new System.Drawing.Point(100, 45);
            this.txt_account.Name = "txt_account";
            this.txt_account.Size = new System.Drawing.Size(140, 21);
            this.txt_account.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(114, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "密码：";
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(100, 72);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(140, 21);
            this.txt_pwd.TabIndex = 2;
            this.txt_pwd.UseSystemPasswordChar = true;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 175);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_account);
            this.Controls.Add(this.lbl_account);
            this.Name = "Login";
            this.Text = "内部软件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_account;
        private System.Windows.Forms.TextBox txt_account;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_pwd;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}
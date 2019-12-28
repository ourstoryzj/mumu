namespace Operation
{
    partial class Login_TaoBao
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btn_logined = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(350, 281);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("https://login.taobao.com/member/login.jhtml?f=top&redirectURL=https%3A%2F%2Fwww.t" +
                    "aobao.com%2F&style=mini", System.UriKind.Absolute);
            // 
            // btn_logined
            // 
            this.btn_logined.Location = new System.Drawing.Point(0, 258);
            this.btn_logined.Name = "btn_logined";
            this.btn_logined.Size = new System.Drawing.Size(350, 23);
            this.btn_logined.TabIndex = 1;
            this.btn_logined.Text = "登陆后点击此按钮打开软件";
            this.btn_logined.UseVisualStyleBackColor = true;
            this.btn_logined.Click += new System.EventHandler(this.btn_logined_Click);
            // 
            // Login_TaoBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 281);
            this.Controls.Add(this.btn_logined);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Login_TaoBao";
            this.Text = "登录淘宝";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btn_logined;
    }
}
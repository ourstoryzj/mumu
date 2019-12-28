namespace Operation.Other
{
    partial class MeiTuXiuXiu
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
            this.btn_addjs = new System.Windows.Forms.Button();
            this.txt_js = new System.Windows.Forms.TextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_savehtml = new System.Windows.Forms.Button();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // btn_addjs
            // 
            this.btn_addjs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_addjs.Location = new System.Drawing.Point(121, 743);
            this.btn_addjs.Name = "btn_addjs";
            this.btn_addjs.Size = new System.Drawing.Size(43, 23);
            this.btn_addjs.TabIndex = 4;
            this.btn_addjs.Text = "弹框";
            this.btn_addjs.UseVisualStyleBackColor = true;
            this.btn_addjs.Click += new System.EventHandler(this.btn_addjs_Click);
            // 
            // txt_js
            // 
            this.txt_js.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_js.Location = new System.Drawing.Point(12, 744);
            this.txt_js.Name = "txt_js";
            this.txt_js.Size = new System.Drawing.Size(33, 21);
            this.txt_js.TabIndex = 7;
            // 
            // btn_test
            // 
            this.btn_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_test.Location = new System.Drawing.Point(48, 743);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(30, 23);
            this.btn_test.TabIndex = 8;
            this.btn_test.Text = "JS";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_savehtml
            // 
            this.btn_savehtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_savehtml.Location = new System.Drawing.Point(81, 743);
            this.btn_savehtml.Name = "btn_savehtml";
            this.btn_savehtml.Size = new System.Drawing.Size(37, 23);
            this.btn_savehtml.TabIndex = 8;
            this.btn_savehtml.Text = "HTML";
            this.btn_savehtml.UseVisualStyleBackColor = true;
            this.btn_savehtml.Click += new System.EventHandler(this.btn_savehtml_Click);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser2.Location = new System.Drawing.Point(0, 0);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.Size = new System.Drawing.Size(1187, 776);
            this.webBrowser2.TabIndex = 9;
            this.webBrowser2.Url = new System.Uri("http://xiuxiu.web.meitu.com/main.html", System.UriKind.Absolute);
            // 
            // MeiTuXiuXiu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 776);
            this.Controls.Add(this.btn_savehtml);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.txt_js);
            this.Controls.Add(this.btn_addjs);
            this.Controls.Add(this.webBrowser2);
            this.Name = "MeiTuXiuXiu";
            this.Text = "店铺通用管理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_js;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_savehtml;
        private System.Windows.Forms.Button btn_addjs;
        private System.Windows.Forms.WebBrowser webBrowser2;
    }
}
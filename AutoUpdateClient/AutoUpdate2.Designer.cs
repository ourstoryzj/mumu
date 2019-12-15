namespace AutoUpdateClient
{
    partial class AutoUpdate2
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
            this.btn_upload_code = new System.Windows.Forms.Button();
            this.btn_download_code = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.btn_fileupload_app = new System.Windows.Forms.Button();
            this.btn_update_app = new System.Windows.Forms.Button();
            this.lbl_message = new System.Windows.Forms.Label();
            this.btn_createFTPFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_upload_code
            // 
            this.btn_upload_code.Location = new System.Drawing.Point(12, 12);
            this.btn_upload_code.Name = "btn_upload_code";
            this.btn_upload_code.Size = new System.Drawing.Size(130, 35);
            this.btn_upload_code.TabIndex = 0;
            this.btn_upload_code.Text = "上传源码";
            this.btn_upload_code.UseVisualStyleBackColor = true;
            this.btn_upload_code.Click += new System.EventHandler(this.btn_upload_code_Click);
            // 
            // btn_download_code
            // 
            this.btn_download_code.Location = new System.Drawing.Point(150, 12);
            this.btn_download_code.Name = "btn_download_code";
            this.btn_download_code.Size = new System.Drawing.Size(130, 35);
            this.btn_download_code.TabIndex = 0;
            this.btn_download_code.Text = "更新源码";
            this.btn_download_code.UseVisualStyleBackColor = true;
            this.btn_download_code.Click += new System.EventHandler(this.btn_download_code_Click);
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(439, 69);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(130, 35);
            this.btn_test.TabIndex = 0;
            this.btn_test.Text = "测试功能";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btn_fileupload_app
            // 
            this.btn_fileupload_app.Location = new System.Drawing.Point(299, 12);
            this.btn_fileupload_app.Name = "btn_fileupload_app";
            this.btn_fileupload_app.Size = new System.Drawing.Size(130, 35);
            this.btn_fileupload_app.TabIndex = 0;
            this.btn_fileupload_app.Text = "上传程序";
            this.btn_fileupload_app.UseVisualStyleBackColor = true;
            this.btn_fileupload_app.Click += new System.EventHandler(this.btn_fileupload_app_Click);
            // 
            // btn_update_app
            // 
            this.btn_update_app.Location = new System.Drawing.Point(437, 12);
            this.btn_update_app.Name = "btn_update_app";
            this.btn_update_app.Size = new System.Drawing.Size(130, 35);
            this.btn_update_app.TabIndex = 0;
            this.btn_update_app.Text = "更新程序";
            this.btn_update_app.UseVisualStyleBackColor = true;
            this.btn_update_app.Click += new System.EventHandler(this.btn_update_app_Click);
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(12, 122);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(53, 12);
            this.lbl_message.TabIndex = 1;
            this.lbl_message.Text = "更新信息";
            // 
            // btn_createFTPFolder
            // 
            this.btn_createFTPFolder.Location = new System.Drawing.Point(12, 69);
            this.btn_createFTPFolder.Name = "btn_createFTPFolder";
            this.btn_createFTPFolder.Size = new System.Drawing.Size(130, 35);
            this.btn_createFTPFolder.TabIndex = 0;
            this.btn_createFTPFolder.Text = "ftp上创建文件夹";
            this.btn_createFTPFolder.UseVisualStyleBackColor = true;
            this.btn_createFTPFolder.Click += new System.EventHandler(this.btn_createFTPFolder_Click);
            // 
            // AutoUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 144);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.btn_update_app);
            this.Controls.Add(this.btn_fileupload_app);
            this.Controls.Add(this.btn_download_code);
            this.Controls.Add(this.btn_createFTPFolder);
            this.Controls.Add(this.btn_upload_code);
            this.Name = "AutoUpdate";
            this.Text = "自动更新";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_upload_code;
        private System.Windows.Forms.Button btn_download_code;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_fileupload_app;
        private System.Windows.Forms.Button btn_update_app;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.Button btn_createFTPFolder;
    }
}
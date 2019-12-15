namespace excel_operation.Test
{
    partial class test_caiji
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
            this.txt_url = new System.Windows.Forms.TextBox();
            txt_res = new System.Windows.Forms.TextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(68, 20);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(533, 21);
            this.txt_url.TabIndex = 8;
            // 
            // txt_res
            // 
            txt_res.Location = new System.Drawing.Point(68, 49);
            txt_res.Multiline = true;
            txt_res.Name = "txt_res";
            txt_res.Size = new System.Drawing.Size(614, 489);
            txt_res.TabIndex = 7;
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(607, 20);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 23);
            this.btn_test.TabIndex = 6;
            this.btn_test.Text = "测试";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // test_caiji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 618);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(txt_res);
            this.Controls.Add(this.btn_test);
            this.Name = "test_caiji";
            this.Text = "test_caiji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_url;
        public static System.Windows.Forms.TextBox txt_res;
        private System.Windows.Forms.Button btn_test;
    }
}
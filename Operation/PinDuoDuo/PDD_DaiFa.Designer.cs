namespace Operation.PinDuoDuo
{
    partial class PDD_DaiFa
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_sheng = new System.Windows.Forms.TextBox();
            this.txt_shi = new System.Windows.Forms.TextBox();
            this.txt_xian = new System.Windows.Forms.TextBox();
            this.txt_dizhi = new System.Windows.Forms.TextBox();
            this.btn_jiexi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 656);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(478, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "个人中心";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(478, 431);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "设置收件信息";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_address
            // 
            this.txt_address.Location = new System.Drawing.Point(478, 203);
            this.txt_address.Multiline = true;
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(309, 60);
            this.txt_address.TabIndex = 4;
            this.txt_address.Click += new System.EventHandler(this.txt_address_Click);
            this.txt_address.TextChanged += new System.EventHandler(this.txt_address_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(478, 56);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 38);
            this.button3.TabIndex = 3;
            this.button3.Text = "领券中心";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(478, 350);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(73, 21);
            this.txt_name.TabIndex = 4;
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(557, 350);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(133, 21);
            this.txt_phone.TabIndex = 4;
            // 
            // txt_sheng
            // 
            this.txt_sheng.Location = new System.Drawing.Point(478, 377);
            this.txt_sheng.Name = "txt_sheng";
            this.txt_sheng.Size = new System.Drawing.Size(102, 21);
            this.txt_sheng.TabIndex = 4;
            // 
            // txt_shi
            // 
            this.txt_shi.Location = new System.Drawing.Point(586, 377);
            this.txt_shi.Name = "txt_shi";
            this.txt_shi.Size = new System.Drawing.Size(102, 21);
            this.txt_shi.TabIndex = 4;
            // 
            // txt_xian
            // 
            this.txt_xian.Location = new System.Drawing.Point(694, 377);
            this.txt_xian.Name = "txt_xian";
            this.txt_xian.Size = new System.Drawing.Size(102, 21);
            this.txt_xian.TabIndex = 4;
            // 
            // txt_dizhi
            // 
            this.txt_dizhi.Location = new System.Drawing.Point(478, 404);
            this.txt_dizhi.Name = "txt_dizhi";
            this.txt_dizhi.Size = new System.Drawing.Size(318, 21);
            this.txt_dizhi.TabIndex = 4;
            // 
            // btn_jiexi
            // 
            this.btn_jiexi.Location = new System.Drawing.Point(478, 269);
            this.btn_jiexi.Name = "btn_jiexi";
            this.btn_jiexi.Size = new System.Drawing.Size(146, 38);
            this.btn_jiexi.TabIndex = 3;
            this.btn_jiexi.Text = "解析地址";
            this.btn_jiexi.UseVisualStyleBackColor = true;
            this.btn_jiexi.Click += new System.EventHandler(this.btn_jiexi_Click);
            // 
            // PDD_DaiFa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 680);
            this.Controls.Add(this.txt_dizhi);
            this.Controls.Add(this.txt_xian);
            this.Controls.Add(this.txt_shi);
            this.Controls.Add(this.txt_sheng);
            this.Controls.Add(this.txt_phone);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_address);
            this.Controls.Add(this.btn_jiexi);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "PDD_DaiFa";
            this.Text = "test_meau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.TextBox txt_sheng;
        private System.Windows.Forms.TextBox txt_shi;
        private System.Windows.Forms.TextBox txt_xian;
        private System.Windows.Forms.TextBox txt_dizhi;
        private System.Windows.Forms.Button btn_jiexi;
    }
}
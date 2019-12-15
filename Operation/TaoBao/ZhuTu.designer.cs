namespace excel_operation.TaoBao
{
    partial class ZhuTu
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
            this.txt_key = new System.Windows.Forms.TextBox();
            this.cb_order = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ye = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "关键词";
            // 
            // txt_key
            // 
            this.txt_key.Location = new System.Drawing.Point(84, 24);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(195, 21);
            this.txt_key.TabIndex = 1;
            this.txt_key.Text = "双肩包女";
            // 
            // cb_order
            // 
            this.cb_order.FormattingEnabled = true;
            this.cb_order.Items.AddRange(new object[] {
            "销量",
            "人气",
            "综合"});
            this.cb_order.Location = new System.Drawing.Point(344, 24);
            this.cb_order.Name = "cb_order";
            this.cb_order.Size = new System.Drawing.Size(121, 20);
            this.cb_order.TabIndex = 2;
            this.cb_order.Text = "销量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "排序方式";
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(605, 23);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 3;
            this.btn_search.Text = "搜索并下载";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "采集页数";
            // 
            // txt_ye
            // 
            this.txt_ye.Location = new System.Drawing.Point(530, 24);
            this.txt_ye.Name = "txt_ye";
            this.txt_ye.Size = new System.Drawing.Size(69, 21);
            this.txt_ye.TabIndex = 1;
            this.txt_ye.Text = "1";
            // 
            // ZhuTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 597);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.cb_order);
            this.Controls.Add(this.txt_ye);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ZhuTu";
            this.Text = "主图下载精灵";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.ComboBox cb_order;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ye;
    }
}
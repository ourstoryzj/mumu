namespace Operation.Other
{
    partial class BaiduPanFrom
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
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.dgv1 = new Common.DataGridViewHelper();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_next = new System.Windows.Forms.Button();
            this.cb_site = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_search.Location = new System.Drawing.Point(796, 9);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(87, 28);
            this.btn_search.TabIndex = 0;
            this.btn_search.Text = "搜索";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txt_key
            // 
            this.txt_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_key.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_key.Location = new System.Drawing.Point(196, 10);
            this.txt_key.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_key.Multiline = true;
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(594, 28);
            this.txt_key.TabIndex = 1;
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_name,
            this.col_url,
            this.col_date,
            this.col_size});
            this.dgv1.Location = new System.Drawing.Point(12, 46);
            this.dgv1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(871, 501);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            this.dgv1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DataGridView1_Scroll);
            this.dgv1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // col_name
            // 
            this.col_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_name.DataPropertyName = "Name";
            this.col_name.HeaderText = "文件名称";
            this.col_name.Name = "col_name";
            // 
            // col_url
            // 
            this.col_url.DataPropertyName = "Url";
            this.col_url.HeaderText = "下载链接（双击打开）";
            this.col_url.Name = "col_url";
            this.col_url.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_url.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_url.Width = 266;
            // 
            // col_date
            // 
            this.col_date.DataPropertyName = "Upload";
            this.col_date.FillWeight = 200F;
            this.col_date.HeaderText = "日期";
            this.col_date.Name = "col_date";
            this.col_date.Width = 200;
            // 
            // col_size
            // 
            this.col_size.DataPropertyName = "Size";
            this.col_size.HeaderText = "文件大小";
            this.col_size.Name = "col_size";
            // 
            // btn_next
            // 
            this.btn_next.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_next.BackColor = System.Drawing.Color.SeaGreen;
            this.btn_next.Font = new System.Drawing.Font("微软雅黑", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_next.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_next.Location = new System.Drawing.Point(12, 555);
            this.btn_next.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(871, 59);
            this.btn_next.TabIndex = 3;
            this.btn_next.Text = "下一页";
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cb_site
            // 
            this.cb_site.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_site.FormattingEnabled = true;
            this.cb_site.Location = new System.Drawing.Point(14, 10);
            this.cb_site.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_site.Name = "cb_site";
            this.cb_site.Size = new System.Drawing.Size(174, 28);
            this.cb_site.TabIndex = 4;
            this.cb_site.Text = "史莱姆";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 618);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(895, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Click += new System.EventHandler(this.toolStripProgressBar1_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(131, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // BaiduPanFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 640);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cb_site);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_next);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BaiduPanFrom";
            this.Text = "百度云盘搜索";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_key;
        //private System.Windows.Forms.DataGridView dataGridView1;
        private Common.DataGridViewHelper dgv1;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.ComboBox cb_site;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_url;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_size;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}
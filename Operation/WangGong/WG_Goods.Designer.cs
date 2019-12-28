namespace Operation.WangGong
{
    partial class WG_Goods
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cb_dianpu = new System.Windows.Forms.ComboBox();
            this.btn_caiji1 = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.btn_lishi = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btn_chongzhi = new System.Windows.Forms.Button();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.txt_key2 = new System.Windows.Forms.TextBox();
            this.btn_img = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_page = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_all = new System.Windows.Forms.Button();
            this.col_caozuo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_wgname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_img = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_jiancheng = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sells = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_tbid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_dianpu
            // 
            this.cb_dianpu.DisplayMember = "odpname";
            this.cb_dianpu.DropDownHeight = 200;
            this.cb_dianpu.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_dianpu.FormattingEnabled = true;
            this.cb_dianpu.IntegralHeight = false;
            this.cb_dianpu.ItemHeight = 16;
            this.cb_dianpu.Location = new System.Drawing.Point(12, 11);
            this.cb_dianpu.MaxDropDownItems = 50;
            this.cb_dianpu.Name = "cb_dianpu";
            this.cb_dianpu.Size = new System.Drawing.Size(174, 24);
            this.cb_dianpu.TabIndex = 1;
            this.cb_dianpu.ValueMember = "odTBID";
            // 
            // btn_caiji1
            // 
            this.btn_caiji1.Location = new System.Drawing.Point(332, 10);
            this.btn_caiji1.Name = "btn_caiji1";
            this.btn_caiji1.Size = new System.Drawing.Size(75, 23);
            this.btn_caiji1.TabIndex = 1;
            this.btn_caiji1.Text = "采集数据";
            this.btn_caiji1.UseVisualStyleBackColor = true;
            this.btn_caiji1.Click += new System.EventHandler(this.btn_caiji1_Click);
            // 
            // dgv1
            // 
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.ColumnHeadersHeight = 30;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_caozuo,
            this.col_wgname,
            this.col_img,
            this.col_title,
            this.col_jiancheng,
            this.col_price2,
            this.col_remark,
            this.col_sells,
            this.col_date,
            this.col_tbid});
            this.dgv1.Location = new System.Drawing.Point(12, 38);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 100;
            this.dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv1.Size = new System.Drawing.Size(1163, 528);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv1_CellFormatting);
            this.dgv1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgv1_CellParsing);
            this.dgv1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv1_RowPostPaint);
            this.dgv1.DoubleClick += new System.EventHandler(this.dgv1_DoubleClick);
            // 
            // btn_lishi
            // 
            this.btn_lishi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_lishi.Location = new System.Drawing.Point(937, 9);
            this.btn_lishi.Name = "btn_lishi";
            this.btn_lishi.Size = new System.Drawing.Size(75, 23);
            this.btn_lishi.TabIndex = 3;
            this.btn_lishi.Text = "查询";
            this.btn_lishi.UseVisualStyleBackColor = true;
            this.btn_lishi.Click += new System.EventHandler(this.btn_lishi_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 572);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1163, 235);
            this.webBrowser1.TabIndex = 8;
            // 
            // btn_chongzhi
            // 
            this.btn_chongzhi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_chongzhi.Location = new System.Drawing.Point(1018, 9);
            this.btn_chongzhi.Name = "btn_chongzhi";
            this.btn_chongzhi.Size = new System.Drawing.Size(75, 23);
            this.btn_chongzhi.TabIndex = 9;
            this.btn_chongzhi.Text = "重置时间";
            this.btn_chongzhi.UseVisualStyleBackColor = true;
            this.btn_chongzhi.Click += new System.EventHandler(this.btn_chongzhi_Click);
            // 
            // date1
            // 
            this.date1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.date1.CustomFormat = "请选择";
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date1.Location = new System.Drawing.Point(700, 10);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(125, 21);
            this.date1.TabIndex = 11;
            this.date1.CloseUp += new System.EventHandler(this.date1_CloseUp);
            // 
            // txt_key2
            // 
            this.txt_key2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_key2.Location = new System.Drawing.Point(831, 10);
            this.txt_key2.Name = "txt_key2";
            this.txt_key2.Size = new System.Drawing.Size(100, 21);
            this.txt_key2.TabIndex = 12;
            // 
            // btn_img
            // 
            this.btn_img.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_img.Location = new System.Drawing.Point(1100, 9);
            this.btn_img.Name = "btn_img";
            this.btn_img.Size = new System.Drawing.Size(75, 23);
            this.btn_img.TabIndex = 13;
            this.btn_img.Text = "补齐图片";
            this.btn_img.UseVisualStyleBackColor = true;
            this.btn_img.Click += new System.EventHandler(this.btn_img_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 810);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1187, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Step = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "新品排序前";
            // 
            // txt_page
            // 
            this.txt_page.Location = new System.Drawing.Point(265, 11);
            this.txt_page.Name = "txt_page";
            this.txt_page.Size = new System.Drawing.Size(38, 21);
            this.txt_page.TabIndex = 16;
            this.txt_page.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(309, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "页";
            // 
            // btn_all
            // 
            this.btn_all.Location = new System.Drawing.Point(413, 10);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(124, 23);
            this.btn_all.TabIndex = 1;
            this.btn_all.Text = "所有网供采集数据";
            this.btn_all.UseVisualStyleBackColor = true;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // col_caozuo
            // 
            this.col_caozuo.HeaderText = "操作";
            this.col_caozuo.Name = "col_caozuo";
            this.col_caozuo.Text = "打开网页";
            this.col_caozuo.UseColumnTextForButtonValue = true;
            this.col_caozuo.Width = 80;
            // 
            // col_wgname
            // 
            this.col_wgname.DataPropertyName = "wid";
            this.col_wgname.HeaderText = "网供名称";
            this.col_wgname.Name = "col_wgname";
            this.col_wgname.Width = 120;
            // 
            // col_img
            // 
            this.col_img.DataPropertyName = "wgremark";
            this.col_img.HeaderText = "主图";
            this.col_img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.col_img.Name = "col_img";
            // 
            // col_title
            // 
            this.col_title.DataPropertyName = "wgtittle";
            this.col_title.HeaderText = "标题";
            this.col_title.Name = "col_title";
            this.col_title.Width = 150;
            // 
            // col_jiancheng
            // 
            this.col_jiancheng.DataPropertyName = "wgremark2";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.col_jiancheng.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_jiancheng.HeaderText = "商品简称(双击修改)";
            this.col_jiancheng.Name = "col_jiancheng";
            this.col_jiancheng.Width = 200;
            // 
            // col_price2
            // 
            this.col_price2.DataPropertyName = "wgprice2";
            this.col_price2.HeaderText = "现价";
            this.col_price2.Name = "col_price2";
            this.col_price2.Width = 55;
            // 
            // col_remark
            // 
            this.col_remark.DataPropertyName = "wgremark1";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            this.col_remark.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_remark.HeaderText = "备注(双击修改)";
            this.col_remark.Name = "col_remark";
            this.col_remark.Width = 300;
            // 
            // col_sells
            // 
            this.col_sells.DataPropertyName = "wgxiaoliang";
            this.col_sells.HeaderText = "销量";
            this.col_sells.Name = "col_sells";
            this.col_sells.Width = 80;
            // 
            // col_date
            // 
            this.col_date.DataPropertyName = "wgcollectdate";
            this.col_date.HeaderText = "采集时间";
            this.col_date.Name = "col_date";
            this.col_date.Width = 150;
            // 
            // col_tbid
            // 
            this.col_tbid.DataPropertyName = "wgTBid";
            this.col_tbid.HeaderText = "淘宝ID";
            this.col_tbid.Name = "col_tbid";
            // 
            // WG_Goods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 832);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_page);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_img);
            this.Controls.Add(this.txt_key2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.btn_chongzhi);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btn_lishi);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.btn_all);
            this.Controls.Add(this.btn_caiji1);
            this.Controls.Add(this.cb_dianpu);
            this.Name = "WG_Goods";
            this.Text = "网供商品采集系统";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_dianpu;
        private System.Windows.Forms.Button btn_caiji1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button btn_lishi;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btn_chongzhi;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.TextBox txt_key2;
        private System.Windows.Forms.Button btn_img;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_page;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.DataGridViewButtonColumn col_caozuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_wgname;
        private System.Windows.Forms.DataGridViewImageColumn col_img;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_jiancheng;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sells;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_tbid;
    }
}
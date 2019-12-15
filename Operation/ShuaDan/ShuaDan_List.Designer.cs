namespace excel_operation.ShuaDan
{
    partial class ShuaDan_List
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
            this.label35 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label34 = new System.Windows.Forms.Label();
            this.btn_search = new System.Windows.Forms.Button();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.btn_reset_dgv = new System.Windows.Forms.Button();
            this.btn_weifahuo = new System.Windows.Forms.Button();
            this.dgv_title = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btn_login_fahuo = new System.Windows.Forms.Button();
            this.btn_login_mogujie = new System.Windows.Forms.Button();
            this.btn_login_taobao = new System.Windows.Forms.Button();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_fahuo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_kongbao = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_shoucai = new System.Windows.Forms.ComboBox();
            this.col_del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_shoptype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_orderid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_wuliu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_kongbao = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_fahuo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_kongbao2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fahuo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shoucai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_vpn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_goodsname = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_title)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label35
            // 
            this.label35.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(708, 17);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(53, 12);
            this.label35.TabIndex = 23;
            this.label35.Text = "采集时间";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.CustomFormat = "请选择";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(767, 13);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 21);
            this.dateTimePicker1.TabIndex = 22;
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp);
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(939, 17);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 12);
            this.label34.TabIndex = 21;
            this.label34.Text = "关键词";
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Location = new System.Drawing.Point(1100, 12);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(85, 23);
            this.btn_search.TabIndex = 20;
            this.btn_search.Text = "搜索100条";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txt_key
            // 
            this.txt_key.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_key.Location = new System.Drawing.Point(986, 13);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(108, 21);
            this.txt_key.TabIndex = 19;
            // 
            // btn_reset_dgv
            // 
            this.btn_reset_dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_reset_dgv.Location = new System.Drawing.Point(894, 12);
            this.btn_reset_dgv.Name = "btn_reset_dgv";
            this.btn_reset_dgv.Size = new System.Drawing.Size(40, 23);
            this.btn_reset_dgv.TabIndex = 18;
            this.btn_reset_dgv.Text = "重置";
            this.btn_reset_dgv.UseVisualStyleBackColor = true;
            this.btn_reset_dgv.Click += new System.EventHandler(this.btn_reset_dgv_Click);
            // 
            // btn_weifahuo
            // 
            this.btn_weifahuo.Location = new System.Drawing.Point(13, 12);
            this.btn_weifahuo.Name = "btn_weifahuo";
            this.btn_weifahuo.Size = new System.Drawing.Size(75, 23);
            this.btn_weifahuo.TabIndex = 17;
            this.btn_weifahuo.Text = "未发货订单";
            this.btn_weifahuo.UseVisualStyleBackColor = true;
            this.btn_weifahuo.Click += new System.EventHandler(this.btn_weifahuo_Click);
            // 
            // dgv_title
            // 
            this.dgv_title.AllowUserToAddRows = false;
            this.dgv_title.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv_title.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_title.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_title.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_del,
            this.col_shoptype,
            this.col_phone,
            this.col_orderid,
            this.col_wuliu,
            this.col_kongbao,
            this.col_fahuo,
            this.col_kongbao2,
            this.col_fahuo2,
            this.col_shoucai,
            this.col_remark,
            this.col_vpn,
            this.col_date,
            this.col_goodsname,
            this.col_address});
            this.dgv_title.Location = new System.Drawing.Point(13, 41);
            this.dgv_title.Name = "dgv_title";
            this.dgv_title.RowTemplate.Height = 23;
            this.dgv_title.Size = new System.Drawing.Size(1173, 305);
            this.dgv_title.TabIndex = 16;
            this.dgv_title.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_title_CellContentClick);
            this.dgv_title.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_title_CellFormatting);
            this.dgv_title.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgv_title_CellParsing);
            this.dgv_title.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_title_RowPostPaint_1);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 381);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1173, 322);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1165, 296);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发货平台";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1165, 296);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "蘑菇街";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1165, 296);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "淘宝";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1165, 296);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "备用";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_login_fahuo
            // 
            this.btn_login_fahuo.Location = new System.Drawing.Point(13, 352);
            this.btn_login_fahuo.Name = "btn_login_fahuo";
            this.btn_login_fahuo.Size = new System.Drawing.Size(100, 23);
            this.btn_login_fahuo.TabIndex = 25;
            this.btn_login_fahuo.Text = "登陆发货平台";
            this.btn_login_fahuo.UseVisualStyleBackColor = true;
            this.btn_login_fahuo.Click += new System.EventHandler(this.btn_login_fahuo_Click);
            // 
            // btn_login_mogujie
            // 
            this.btn_login_mogujie.Location = new System.Drawing.Point(119, 352);
            this.btn_login_mogujie.Name = "btn_login_mogujie";
            this.btn_login_mogujie.Size = new System.Drawing.Size(100, 23);
            this.btn_login_mogujie.TabIndex = 25;
            this.btn_login_mogujie.Text = "登陆蘑菇街";
            this.btn_login_mogujie.UseVisualStyleBackColor = true;
            this.btn_login_mogujie.Click += new System.EventHandler(this.btn_login_mogujie_Click);
            // 
            // btn_login_taobao
            // 
            this.btn_login_taobao.Location = new System.Drawing.Point(225, 352);
            this.btn_login_taobao.Name = "btn_login_taobao";
            this.btn_login_taobao.Size = new System.Drawing.Size(100, 23);
            this.btn_login_taobao.TabIndex = 25;
            this.btn_login_taobao.Text = "登陆淘宝";
            this.btn_login_taobao.UseVisualStyleBackColor = true;
            // 
            // cb_type
            // 
            this.cb_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Items.AddRange(new object[] {
            "蘑菇街",
            "淘宝"});
            this.cb_type.Location = new System.Drawing.Point(267, 13);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(60, 20);
            this.cb_type.TabIndex = 26;
            this.cb_type.Text = "蘑菇街";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(208, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "店铺类型";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "空包状态";
            // 
            // cb_fahuo
            // 
            this.cb_fahuo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_fahuo.FormattingEnabled = true;
            this.cb_fahuo.Items.AddRange(new object[] {
            "未发货",
            "已发货"});
            this.cb_fahuo.Location = new System.Drawing.Point(517, 13);
            this.cb_fahuo.Name = "cb_fahuo";
            this.cb_fahuo.Size = new System.Drawing.Size(60, 20);
            this.cb_fahuo.TabIndex = 26;
            this.cb_fahuo.Text = "请选择";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(458, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "发货状态";
            // 
            // cb_kongbao
            // 
            this.cb_kongbao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_kongbao.FormattingEnabled = true;
            this.cb_kongbao.Items.AddRange(new object[] {
            "未获取",
            "已获取"});
            this.cb_kongbao.Location = new System.Drawing.Point(392, 13);
            this.cb_kongbao.Name = "cb_kongbao";
            this.cb_kongbao.Size = new System.Drawing.Size(60, 20);
            this.cb_kongbao.TabIndex = 26;
            this.cb_kongbao.Text = "请选择";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(583, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 23;
            this.label4.Text = "收菜状态";
            // 
            // cb_shoucai
            // 
            this.cb_shoucai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_shoucai.FormattingEnabled = true;
            this.cb_shoucai.Items.AddRange(new object[] {
            "未收菜",
            "已收菜",
            "有问题"});
            this.cb_shoucai.Location = new System.Drawing.Point(642, 13);
            this.cb_shoucai.Name = "cb_shoucai";
            this.cb_shoucai.Size = new System.Drawing.Size(60, 20);
            this.cb_shoucai.TabIndex = 26;
            this.cb_shoucai.Text = "请选择";
            // 
            // col_del
            // 
            this.col_del.HeaderText = "操作";
            this.col_del.Name = "col_del";
            this.col_del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_del.Text = "删除";
            this.col_del.UseColumnTextForButtonValue = true;
            // 
            // col_shoptype
            // 
            this.col_shoptype.DataPropertyName = "sddptype";
            this.col_shoptype.HeaderText = "店铺类型";
            this.col_shoptype.Name = "col_shoptype";
            this.col_shoptype.Width = 80;
            // 
            // col_phone
            // 
            this.col_phone.DataPropertyName = "sdphone";
            this.col_phone.HeaderText = "手机号码(登录)";
            this.col_phone.Name = "col_phone";
            this.col_phone.Width = 120;
            // 
            // col_orderid
            // 
            this.col_orderid.DataPropertyName = "sdorderid";
            this.col_orderid.HeaderText = "订单编号";
            this.col_orderid.Name = "col_orderid";
            // 
            // col_wuliu
            // 
            this.col_wuliu.DataPropertyName = "sdwuliu";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.col_wuliu.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_wuliu.HeaderText = "快递单号";
            this.col_wuliu.Name = "col_wuliu";
            this.col_wuliu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_wuliu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_kongbao
            // 
            this.col_kongbao.DataPropertyName = "sdremark3";
            this.col_kongbao.HeaderText = "是否获取空包";
            this.col_kongbao.Name = "col_kongbao";
            this.col_kongbao.Text = "";
            // 
            // col_fahuo
            // 
            this.col_fahuo.DataPropertyName = "sdremark4";
            this.col_fahuo.HeaderText = "是否发货";
            this.col_fahuo.Name = "col_fahuo";
            this.col_fahuo.Text = "发货";
            // 
            // col_kongbao2
            // 
            this.col_kongbao2.DataPropertyName = "sdremark3";
            this.col_kongbao2.HeaderText = "修改空包状态";
            this.col_kongbao2.Name = "col_kongbao2";
            this.col_kongbao2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_kongbao2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_fahuo2
            // 
            this.col_fahuo2.DataPropertyName = "sdremark4";
            this.col_fahuo2.HeaderText = "修改发货状态";
            this.col_fahuo2.Name = "col_fahuo2";
            this.col_fahuo2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_fahuo2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_shoucai
            // 
            this.col_shoucai.DataPropertyName = "sdremark2";
            this.col_shoucai.HeaderText = "修改收菜状态";
            this.col_shoucai.Name = "col_shoucai";
            this.col_shoucai.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_shoucai.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_remark
            // 
            this.col_remark.DataPropertyName = "sdremark5";
            this.col_remark.HeaderText = "备注";
            this.col_remark.Name = "col_remark";
            this.col_remark.Width = 150;
            // 
            // col_vpn
            // 
            this.col_vpn.DataPropertyName = "sdvpn";
            this.col_vpn.HeaderText = "VPN地址";
            this.col_vpn.Name = "col_vpn";
            // 
            // col_date
            // 
            this.col_date.DataPropertyName = "sddate";
            this.col_date.HeaderText = "刷单时间";
            this.col_date.Name = "col_date";
            // 
            // col_goodsname
            // 
            this.col_goodsname.DataPropertyName = "sdgoodsname";
            this.col_goodsname.HeaderText = "商品名称";
            this.col_goodsname.Name = "col_goodsname";
            this.col_goodsname.Text = "sdgoodsname";
            this.col_goodsname.Width = 200;
            // 
            // col_address
            // 
            this.col_address.DataPropertyName = "sdaddress";
            this.col_address.HeaderText = "收货信息";
            this.col_address.Name = "col_address";
            this.col_address.Width = 300;
            // 
            // ShuaDan_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 715);
            this.Controls.Add(this.cb_kongbao);
            this.Controls.Add(this.cb_shoucai);
            this.Controls.Add(this.cb_fahuo);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.btn_login_taobao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_login_mogujie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_login_fahuo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.btn_reset_dgv);
            this.Controls.Add(this.btn_weifahuo);
            this.Controls.Add(this.dgv_title);
            this.Name = "ShuaDan_List";
            this.Text = "补单记录&发货";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_title)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.Button btn_reset_dgv;
        private System.Windows.Forms.Button btn_weifahuo;
        private System.Windows.Forms.DataGridView dgv_title;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_login_fahuo;
        private System.Windows.Forms.Button btn_login_mogujie;
        private System.Windows.Forms.Button btn_login_taobao;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_fahuo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_kongbao;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_shoucai;
        private System.Windows.Forms.DataGridViewButtonColumn col_del;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shoptype;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_orderid;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_wuliu;
        private System.Windows.Forms.DataGridViewButtonColumn col_kongbao;
        private System.Windows.Forms.DataGridViewButtonColumn col_fahuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_kongbao2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fahuo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shoucai;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_vpn;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewLinkColumn col_goodsname;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_address;
    }
}
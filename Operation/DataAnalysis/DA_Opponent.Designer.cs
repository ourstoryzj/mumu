namespace excel_operation.DataAnalysis
{
    partial class DA_Opponent
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
            this.cb_dianpu = new System.Windows.Forms.ComboBox();
            this.btn_caiji1 = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.col_caozuo = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_img = new System.Windows.Forms.DataGridViewImageColumn();
            this.col_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sells = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_shoucang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_leijipinglun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_price1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_zhekou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_youfei = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_subtitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_lishi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_goodsnum = new System.Windows.Forms.Label();
            this.lbl_sell0 = new System.Windows.Forms.Label();
            this.lbl_skunum = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_pricegao = new System.Windows.Forms.Label();
            this.lbl_pricedi = new System.Windows.Forms.Label();
            this.lbl_pricepingjun = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_salesgao = new System.Windows.Forms.Label();
            this.lbl_salesdi = new System.Windows.Forms.Label();
            this.lbl_salespingjun = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbl_dpsell = new System.Windows.Forms.Label();
            this.lbl_dpsales = new System.Windows.Forms.Label();
            this.lbl_dongxiao = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_jisuan = new System.Windows.Forms.Button();
            this.lbl_wuliu = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lbl_shopid = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_baozhengjin = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_zhiliang = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lbl_miaoshu = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lbl_caijidate = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btn_chongzhi = new System.Windows.Forms.Button();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.txt_key2 = new System.Windows.Forms.TextBox();
            this.btn_img = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_dianpu
            // 
            this.cb_dianpu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_dianpu.DisplayMember = "odpname";
            this.cb_dianpu.DropDownHeight = 200;
            this.cb_dianpu.FormattingEnabled = true;
            this.cb_dianpu.IntegralHeight = false;
            this.cb_dianpu.ItemHeight = 12;
            this.cb_dianpu.Location = new System.Drawing.Point(520, 11);
            this.cb_dianpu.MaxDropDownItems = 30;
            this.cb_dianpu.Name = "cb_dianpu";
            this.cb_dianpu.Size = new System.Drawing.Size(174, 20);
            this.cb_dianpu.TabIndex = 1;
            this.cb_dianpu.ValueMember = "odTBID";
            this.cb_dianpu.SelectedIndexChanged += new System.EventHandler(this.cb_dianpu_SelectedIndexChanged);
            // 
            // btn_caiji1
            // 
            this.btn_caiji1.Location = new System.Drawing.Point(223, 10);
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
            this.col_id,
            this.col_img,
            this.col_title,
            this.col_sells,
            this.col_shoucang,
            this.col_leijipinglun,
            this.col_date,
            this.col_price2,
            this.col_price1,
            this.col_zhekou,
            this.col_youfei,
            this.col_sku,
            this.col_subtitle});
            this.dgv1.Location = new System.Drawing.Point(12, 38);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 50;
            this.dgv1.Size = new System.Drawing.Size(1163, 528);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv1_CellFormatting);
            this.dgv1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv1_RowPostPaint);
            this.dgv1.DoubleClick += new System.EventHandler(this.dgv1_DoubleClick);
            // 
            // col_caozuo
            // 
            this.col_caozuo.HeaderText = "操作";
            this.col_caozuo.Name = "col_caozuo";
            this.col_caozuo.Text = "历史记录";
            this.col_caozuo.UseColumnTextForButtonValue = true;
            this.col_caozuo.Width = 80;
            // 
            // col_id
            // 
            this.col_id.DataPropertyName = "ogTBid";
            this.col_id.HeaderText = "宝贝ID";
            this.col_id.Name = "col_id";
            this.col_id.Width = 80;
            // 
            // col_img
            // 
            this.col_img.DataPropertyName = "ogremark";
            this.col_img.HeaderText = "主图";
            this.col_img.Name = "col_img";
            this.col_img.Width = 70;
            // 
            // col_title
            // 
            this.col_title.DataPropertyName = "ogtittle";
            this.col_title.HeaderText = "标题";
            this.col_title.Name = "col_title";
            this.col_title.Width = 380;
            // 
            // col_sells
            // 
            this.col_sells.DataPropertyName = "ogsales";
            this.col_sells.HeaderText = "30天销量";
            this.col_sells.Name = "col_sells";
            this.col_sells.Width = 80;
            // 
            // col_shoucang
            // 
            this.col_shoucang.DataPropertyName = "ogshoucang";
            this.col_shoucang.HeaderText = "收藏量";
            this.col_shoucang.Name = "col_shoucang";
            this.col_shoucang.Width = 70;
            // 
            // col_leijipinglun
            // 
            this.col_leijipinglun.DataPropertyName = "ogxiaoliang";
            this.col_leijipinglun.HeaderText = "累计评论";
            this.col_leijipinglun.Name = "col_leijipinglun";
            this.col_leijipinglun.Width = 80;
            // 
            // col_date
            // 
            this.col_date.DataPropertyName = "ocollectdate";
            this.col_date.HeaderText = "采集时间";
            this.col_date.Name = "col_date";
            this.col_date.Width = 150;
            // 
            // col_price2
            // 
            this.col_price2.DataPropertyName = "ogprice2";
            this.col_price2.HeaderText = "现价";
            this.col_price2.Name = "col_price2";
            this.col_price2.Width = 55;
            // 
            // col_price1
            // 
            this.col_price1.DataPropertyName = "ogprice1";
            this.col_price1.HeaderText = "原价";
            this.col_price1.Name = "col_price1";
            this.col_price1.Width = 55;
            // 
            // col_zhekou
            // 
            this.col_zhekou.DataPropertyName = "ogdiscount";
            this.col_zhekou.HeaderText = "折扣";
            this.col_zhekou.Name = "col_zhekou";
            this.col_zhekou.Width = 55;
            // 
            // col_youfei
            // 
            this.col_youfei.DataPropertyName = "ogpostage";
            this.col_youfei.HeaderText = "邮费";
            this.col_youfei.Name = "col_youfei";
            this.col_youfei.Width = 55;
            // 
            // col_sku
            // 
            this.col_sku.DataPropertyName = "ogSKU";
            this.col_sku.HeaderText = "SKU数量";
            this.col_sku.Name = "col_sku";
            this.col_sku.Width = 70;
            // 
            // col_subtitle
            // 
            this.col_subtitle.DataPropertyName = "ogremark1";
            this.col_subtitle.HeaderText = "副标题";
            this.col_subtitle.Name = "col_subtitle";
            this.col_subtitle.Width = 1000;
            // 
            // btn_lishi
            // 
            this.btn_lishi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_lishi.Location = new System.Drawing.Point(937, 9);
            this.btn_lishi.Name = "btn_lishi";
            this.btn_lishi.Size = new System.Drawing.Size(75, 23);
            this.btn_lishi.TabIndex = 3;
            this.btn_lishi.Text = "历史查询";
            this.btn_lishi.UseVisualStyleBackColor = true;
            this.btn_lishi.Click += new System.EventHandler(this.btn_lishi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label1.Location = new System.Drawing.Point(42, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "商品数量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label2.Location = new System.Drawing.Point(42, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "0销量宝贝数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label3.Location = new System.Drawing.Point(42, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "SKU数量";
            // 
            // lbl_goodsnum
            // 
            this.lbl_goodsnum.AutoSize = true;
            this.lbl_goodsnum.ForeColor = System.Drawing.Color.Red;
            this.lbl_goodsnum.Location = new System.Drawing.Point(145, 22);
            this.lbl_goodsnum.Name = "lbl_goodsnum";
            this.lbl_goodsnum.Size = new System.Drawing.Size(0, 12);
            this.lbl_goodsnum.TabIndex = 4;
            // 
            // lbl_sell0
            // 
            this.lbl_sell0.AutoSize = true;
            this.lbl_sell0.ForeColor = System.Drawing.Color.Red;
            this.lbl_sell0.Location = new System.Drawing.Point(145, 53);
            this.lbl_sell0.Name = "lbl_sell0";
            this.lbl_sell0.Size = new System.Drawing.Size(0, 12);
            this.lbl_sell0.TabIndex = 4;
            // 
            // lbl_skunum
            // 
            this.lbl_skunum.AutoSize = true;
            this.lbl_skunum.ForeColor = System.Drawing.Color.Red;
            this.lbl_skunum.Location = new System.Drawing.Point(145, 84);
            this.lbl_skunum.Name = "lbl_skunum";
            this.lbl_skunum.Size = new System.Drawing.Size(0, 12);
            this.lbl_skunum.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label7.Location = new System.Drawing.Point(209, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "最高价";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label8.Location = new System.Drawing.Point(209, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 4;
            this.label8.Text = "最低价";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label9.Location = new System.Drawing.Point(209, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 4;
            this.label9.Text = "平均价";
            // 
            // lbl_pricegao
            // 
            this.lbl_pricegao.AutoSize = true;
            this.lbl_pricegao.ForeColor = System.Drawing.Color.Red;
            this.lbl_pricegao.Location = new System.Drawing.Point(300, 22);
            this.lbl_pricegao.Name = "lbl_pricegao";
            this.lbl_pricegao.Size = new System.Drawing.Size(0, 12);
            this.lbl_pricegao.TabIndex = 4;
            // 
            // lbl_pricedi
            // 
            this.lbl_pricedi.AutoSize = true;
            this.lbl_pricedi.ForeColor = System.Drawing.Color.Red;
            this.lbl_pricedi.Location = new System.Drawing.Point(300, 53);
            this.lbl_pricedi.Name = "lbl_pricedi";
            this.lbl_pricedi.Size = new System.Drawing.Size(0, 12);
            this.lbl_pricedi.TabIndex = 4;
            // 
            // lbl_pricepingjun
            // 
            this.lbl_pricepingjun.AutoSize = true;
            this.lbl_pricepingjun.ForeColor = System.Drawing.Color.Red;
            this.lbl_pricepingjun.Location = new System.Drawing.Point(300, 84);
            this.lbl_pricepingjun.Name = "lbl_pricepingjun";
            this.lbl_pricepingjun.Size = new System.Drawing.Size(0, 12);
            this.lbl_pricepingjun.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label13.Location = new System.Drawing.Point(383, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 4;
            this.label13.Text = "最高销量";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label14.Location = new System.Drawing.Point(383, 53);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "最低销量";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label15.Location = new System.Drawing.Point(383, 84);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 4;
            this.label15.Text = "平均销量";
            // 
            // lbl_salesgao
            // 
            this.lbl_salesgao.AutoSize = true;
            this.lbl_salesgao.ForeColor = System.Drawing.Color.Red;
            this.lbl_salesgao.Location = new System.Drawing.Point(491, 22);
            this.lbl_salesgao.Name = "lbl_salesgao";
            this.lbl_salesgao.Size = new System.Drawing.Size(0, 12);
            this.lbl_salesgao.TabIndex = 4;
            // 
            // lbl_salesdi
            // 
            this.lbl_salesdi.AutoSize = true;
            this.lbl_salesdi.ForeColor = System.Drawing.Color.Red;
            this.lbl_salesdi.Location = new System.Drawing.Point(491, 53);
            this.lbl_salesdi.Name = "lbl_salesdi";
            this.lbl_salesdi.Size = new System.Drawing.Size(0, 12);
            this.lbl_salesdi.TabIndex = 4;
            // 
            // lbl_salespingjun
            // 
            this.lbl_salespingjun.AutoSize = true;
            this.lbl_salespingjun.ForeColor = System.Drawing.Color.Red;
            this.lbl_salespingjun.Location = new System.Drawing.Point(491, 84);
            this.lbl_salespingjun.Name = "lbl_salespingjun";
            this.lbl_salespingjun.Size = new System.Drawing.Size(0, 12);
            this.lbl_salespingjun.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label19.Location = new System.Drawing.Point(597, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 12);
            this.label19.TabIndex = 4;
            this.label19.Text = "全店30天销量";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label20.Location = new System.Drawing.Point(597, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 12);
            this.label20.TabIndex = 4;
            this.label20.Text = "全店30天销售额";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label21.Location = new System.Drawing.Point(597, 84);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(113, 12);
            this.label21.TabIndex = 4;
            this.label21.Text = "全店30天宝贝动销率";
            // 
            // lbl_dpsell
            // 
            this.lbl_dpsell.AutoSize = true;
            this.lbl_dpsell.ForeColor = System.Drawing.Color.Red;
            this.lbl_dpsell.Location = new System.Drawing.Point(748, 22);
            this.lbl_dpsell.Name = "lbl_dpsell";
            this.lbl_dpsell.Size = new System.Drawing.Size(0, 12);
            this.lbl_dpsell.TabIndex = 4;
            // 
            // lbl_dpsales
            // 
            this.lbl_dpsales.AutoSize = true;
            this.lbl_dpsales.ForeColor = System.Drawing.Color.Red;
            this.lbl_dpsales.Location = new System.Drawing.Point(748, 53);
            this.lbl_dpsales.Name = "lbl_dpsales";
            this.lbl_dpsales.Size = new System.Drawing.Size(0, 12);
            this.lbl_dpsales.TabIndex = 4;
            // 
            // lbl_dongxiao
            // 
            this.lbl_dongxiao.AutoSize = true;
            this.lbl_dongxiao.ForeColor = System.Drawing.Color.Red;
            this.lbl_dongxiao.Location = new System.Drawing.Point(748, 84);
            this.lbl_dongxiao.Name = "lbl_dongxiao";
            this.lbl_dongxiao.Size = new System.Drawing.Size(0, 12);
            this.lbl_dongxiao.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_jisuan);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lbl_wuliu);
            this.groupBox1.Controls.Add(this.lbl_dongxiao);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl_salespingjun);
            this.groupBox1.Controls.Add(this.lbl_goodsnum);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lbl_sell0);
            this.groupBox1.Controls.Add(this.lbl_shopid);
            this.groupBox1.Controls.Add(this.lbl_pricepingjun);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lbl_baozhengjin);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbl_skunum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbl_pricegao);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lbl_zhiliang);
            this.groupBox1.Controls.Add(this.lbl_pricedi);
            this.groupBox1.Controls.Add(this.lbl_dpsales);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.lbl_miaoshu);
            this.groupBox1.Controls.Add(this.lbl_salesgao);
            this.groupBox1.Controls.Add(this.lbl_dpsell);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.lbl_salesdi);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Location = new System.Drawing.Point(12, 576);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1163, 108);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "店铺综合信息";
            // 
            // btn_jisuan
            // 
            this.btn_jisuan.Location = new System.Drawing.Point(1000, 76);
            this.btn_jisuan.Name = "btn_jisuan";
            this.btn_jisuan.Size = new System.Drawing.Size(75, 23);
            this.btn_jisuan.TabIndex = 5;
            this.btn_jisuan.Text = "计算";
            this.btn_jisuan.UseVisualStyleBackColor = true;
            this.btn_jisuan.Click += new System.EventHandler(this.btn_jisuan_Click);
            // 
            // lbl_wuliu
            // 
            this.lbl_wuliu.AutoSize = true;
            this.lbl_wuliu.ForeColor = System.Drawing.Color.Red;
            this.lbl_wuliu.Location = new System.Drawing.Point(939, 84);
            this.lbl_wuliu.Name = "lbl_wuliu";
            this.lbl_wuliu.Size = new System.Drawing.Size(0, 12);
            this.lbl_wuliu.TabIndex = 4;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label29.Location = new System.Drawing.Point(836, 84);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(47, 12);
            this.label29.TabIndex = 4;
            this.label29.Text = "DSR物流";
            // 
            // lbl_shopid
            // 
            this.lbl_shopid.AutoSize = true;
            this.lbl_shopid.ForeColor = System.Drawing.Color.Red;
            this.lbl_shopid.Location = new System.Drawing.Point(1089, 53);
            this.lbl_shopid.Name = "lbl_shopid";
            this.lbl_shopid.Size = new System.Drawing.Size(0, 12);
            this.lbl_shopid.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label6.Location = new System.Drawing.Point(998, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "店铺ID";
            // 
            // lbl_baozhengjin
            // 
            this.lbl_baozhengjin.AutoSize = true;
            this.lbl_baozhengjin.ForeColor = System.Drawing.Color.Red;
            this.lbl_baozhengjin.Location = new System.Drawing.Point(1101, 22);
            this.lbl_baozhengjin.Name = "lbl_baozhengjin";
            this.lbl_baozhengjin.Size = new System.Drawing.Size(0, 12);
            this.lbl_baozhengjin.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(998, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "保证金";
            // 
            // lbl_zhiliang
            // 
            this.lbl_zhiliang.AutoSize = true;
            this.lbl_zhiliang.ForeColor = System.Drawing.Color.Red;
            this.lbl_zhiliang.Location = new System.Drawing.Point(939, 53);
            this.lbl_zhiliang.Name = "lbl_zhiliang";
            this.lbl_zhiliang.Size = new System.Drawing.Size(0, 12);
            this.lbl_zhiliang.TabIndex = 4;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label27.Location = new System.Drawing.Point(836, 53);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 12);
            this.label27.TabIndex = 4;
            this.label27.Text = "DSR质量";
            // 
            // lbl_miaoshu
            // 
            this.lbl_miaoshu.AutoSize = true;
            this.lbl_miaoshu.ForeColor = System.Drawing.Color.Red;
            this.lbl_miaoshu.Location = new System.Drawing.Point(939, 22);
            this.lbl_miaoshu.Name = "lbl_miaoshu";
            this.lbl_miaoshu.Size = new System.Drawing.Size(0, 12);
            this.lbl_miaoshu.TabIndex = 4;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label25.Location = new System.Drawing.Point(836, 22);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 12);
            this.label25.TabIndex = 4;
            this.label25.Text = "DSR描述";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(312, 15);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 12);
            this.label31.TabIndex = 6;
            this.label31.Text = "采集时间：";
            // 
            // lbl_caijidate
            // 
            this.lbl_caijidate.AutoSize = true;
            this.lbl_caijidate.ForeColor = System.Drawing.Color.Red;
            this.lbl_caijidate.Location = new System.Drawing.Point(383, 15);
            this.lbl_caijidate.Name = "lbl_caijidate";
            this.lbl_caijidate.Size = new System.Drawing.Size(0, 12);
            this.lbl_caijidate.TabIndex = 7;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(12, 690);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1163, 117);
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
            // txt_key
            // 
            this.txt_key.Location = new System.Drawing.Point(12, 11);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(204, 21);
            this.txt_key.TabIndex = 0;
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
            // 
            // DA_Opponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 832);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_img);
            this.Controls.Add(this.txt_key2);
            this.Controls.Add(this.date1);
            this.Controls.Add(this.txt_key);
            this.Controls.Add(this.btn_chongzhi);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.lbl_caijidate);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_lishi);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.btn_caiji1);
            this.Controls.Add(this.cb_dianpu);
            this.Name = "DA_Opponent";
            this.Text = "竞争对手分析精灵";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_goodsnum;
        private System.Windows.Forms.Label lbl_sell0;
        private System.Windows.Forms.Label lbl_skunum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_pricegao;
        private System.Windows.Forms.Label lbl_pricedi;
        private System.Windows.Forms.Label lbl_pricepingjun;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbl_salesgao;
        private System.Windows.Forms.Label lbl_salesdi;
        private System.Windows.Forms.Label lbl_salespingjun;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lbl_dpsell;
        private System.Windows.Forms.Label lbl_dpsales;
        private System.Windows.Forms.Label lbl_dongxiao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_wuliu;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lbl_zhiliang;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lbl_miaoshu;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lbl_caijidate;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btn_chongzhi;
        private System.Windows.Forms.DataGridViewButtonColumn col_caozuo;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewImageColumn col_img;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sells;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_shoucang;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_leijipinglun;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_price1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_zhekou;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_youfei;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sku;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_subtitle;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.TextBox txt_key2;
        private System.Windows.Forms.Label lbl_shopid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_baozhengjin;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_jisuan;
        private System.Windows.Forms.Button btn_img;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
    }
}
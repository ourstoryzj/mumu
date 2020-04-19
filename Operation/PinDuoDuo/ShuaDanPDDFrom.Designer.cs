namespace Operation.Other
{
    partial class ShuaDanPDDFrom
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tp_typelist = new System.Windows.Forms.TabPage();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.cb_state = new System.Windows.Forms.ComboBox();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_typeadd = new System.Windows.Forms.Button();
            this.dgv_type = new Common.DataGridViewHelper();
            this.tp_typeadd = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_phone = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.txt_account = new System.Windows.Forms.TextBox();
            this.btn_typesave = new System.Windows.Forms.Button();
            this.cb_state2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.tp_piliang = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fenge = new System.Windows.Forms.TextBox();
            this.btn_piliangsave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_piliang = new System.Windows.Forms.TextBox();
            this.tp_shuadan = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_go = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.pan_tool = new System.Windows.Forms.Panel();
            this.btn_shuadan_geren = new System.Windows.Forms.Button();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_del = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_login = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dateaccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_openurl = new System.Windows.Forms.TextBox();
            this.btn_openurl = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tp_typelist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_type)).BeginInit();
            this.tp_typeadd.SuspendLayout();
            this.tp_piliang.SuspendLayout();
            this.tp_shuadan.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tp_typelist);
            this.tabControl1.Controls.Add(this.tp_typeadd);
            this.tabControl1.Controls.Add(this.tp_piliang);
            this.tabControl1.Controls.Add(this.tp_shuadan);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1157, 805);
            this.tabControl1.TabIndex = 9;
            // 
            // tp_typelist
            // 
            this.tp_typelist.Controls.Add(this.btn_delete);
            this.tp_typelist.Controls.Add(this.btn_search);
            this.tp_typelist.Controls.Add(this.cb_state);
            this.tp_typelist.Controls.Add(this.txt_key);
            this.tp_typelist.Controls.Add(this.label15);
            this.tp_typelist.Controls.Add(this.label16);
            this.tp_typelist.Controls.Add(this.btn_typeadd);
            this.tp_typelist.Controls.Add(this.dgv_type);
            this.tp_typelist.Location = new System.Drawing.Point(4, 22);
            this.tp_typelist.Name = "tp_typelist";
            this.tp_typelist.Padding = new System.Windows.Forms.Padding(3);
            this.tp_typelist.Size = new System.Drawing.Size(1149, 779);
            this.tp_typelist.TabIndex = 3;
            this.tp_typelist.Text = "话术类型列表";
            // 
            // btn_delete
            // 
            this.btn_delete.ForeColor = System.Drawing.Color.Red;
            this.btn_delete.Location = new System.Drawing.Point(6, 7);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 48;
            this.btn_delete.Text = "批量删除";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click_1);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Location = new System.Drawing.Point(1053, 6);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(85, 23);
            this.btn_search.TabIndex = 44;
            this.btn_search.Text = "搜索1000条";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click_1);
            // 
            // cb_state
            // 
            this.cb_state.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_state.FormattingEnabled = true;
            this.cb_state.Items.AddRange(new object[] {
            "请选择",
            "启用",
            "禁用"});
            this.cb_state.Location = new System.Drawing.Point(826, 7);
            this.cb_state.Name = "cb_state";
            this.cb_state.Size = new System.Drawing.Size(60, 20);
            this.cb_state.TabIndex = 47;
            this.cb_state.Text = "请选择";
            // 
            // txt_key
            // 
            this.txt_key.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_key.Location = new System.Drawing.Point(939, 7);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(108, 21);
            this.txt_key.TabIndex = 43;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(892, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 45;
            this.label15.Text = "关键词";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(793, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 46;
            this.label16.Text = "状态";
            // 
            // btn_typeadd
            // 
            this.btn_typeadd.Location = new System.Drawing.Point(87, 7);
            this.btn_typeadd.Name = "btn_typeadd";
            this.btn_typeadd.Size = new System.Drawing.Size(85, 23);
            this.btn_typeadd.TabIndex = 34;
            this.btn_typeadd.Text = "添加账号";
            this.btn_typeadd.UseVisualStyleBackColor = true;
            this.btn_typeadd.Click += new System.EventHandler(this.btn_typeadd_Click);
            // 
            // dgv_type
            // 
            this.dgv_type.AllowUserToAddRows = false;
            this.dgv_type.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv_type.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_type.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_type.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_type.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_type.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.col_del,
            this.col_login,
            this.col_account,
            this.col_pwd,
            this.col_phone,
            this.col_state,
            this.col_dateaccount,
            this.col_remark});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_type.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_type.Location = new System.Drawing.Point(6, 35);
            this.dgv_type.Name = "dgv_type";
            this.dgv_type.RowTemplate.Height = 23;
            this.dgv_type.Size = new System.Drawing.Size(1133, 738);
            this.dgv_type.TabIndex = 28;
            this.dgv_type.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_type_CellContentClick);
            this.dgv_type.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_type_CellFormatting);
            this.dgv_type.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgv_type_CellParsing);
            // 
            // tp_typeadd
            // 
            this.tp_typeadd.Controls.Add(this.label14);
            this.tp_typeadd.Controls.Add(this.label13);
            this.tp_typeadd.Controls.Add(this.label8);
            this.tp_typeadd.Controls.Add(this.txt_phone);
            this.tp_typeadd.Controls.Add(this.txt_pwd);
            this.tp_typeadd.Controls.Add(this.txt_account);
            this.tp_typeadd.Controls.Add(this.btn_typesave);
            this.tp_typeadd.Controls.Add(this.cb_state2);
            this.tp_typeadd.Controls.Add(this.label1);
            this.tp_typeadd.Controls.Add(this.label7);
            this.tp_typeadd.Controls.Add(this.txt_remark);
            this.tp_typeadd.Location = new System.Drawing.Point(4, 22);
            this.tp_typeadd.Name = "tp_typeadd";
            this.tp_typeadd.Padding = new System.Windows.Forms.Padding(3);
            this.tp_typeadd.Size = new System.Drawing.Size(1155, 728);
            this.tp_typeadd.TabIndex = 4;
            this.tp_typeadd.Text = "添加话术类型";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(30, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 52;
            this.label14.Text = "手机";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 52;
            this.label13.Text = "密码";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 52;
            this.label8.Text = "账号";
            // 
            // txt_phone
            // 
            this.txt_phone.Location = new System.Drawing.Point(65, 66);
            this.txt_phone.Name = "txt_phone";
            this.txt_phone.Size = new System.Drawing.Size(217, 21);
            this.txt_phone.TabIndex = 51;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(65, 39);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(217, 21);
            this.txt_pwd.TabIndex = 51;
            // 
            // txt_account
            // 
            this.txt_account.Location = new System.Drawing.Point(65, 12);
            this.txt_account.Name = "txt_account";
            this.txt_account.Size = new System.Drawing.Size(217, 21);
            this.txt_account.TabIndex = 51;
            // 
            // btn_typesave
            // 
            this.btn_typesave.Location = new System.Drawing.Point(65, 146);
            this.btn_typesave.Name = "btn_typesave";
            this.btn_typesave.Size = new System.Drawing.Size(217, 23);
            this.btn_typesave.TabIndex = 50;
            this.btn_typesave.Text = "保存";
            this.btn_typesave.UseVisualStyleBackColor = true;
            this.btn_typesave.Click += new System.EventHandler(this.btn_typesave_Click);
            // 
            // cb_state2
            // 
            this.cb_state2.FormattingEnabled = true;
            this.cb_state2.Items.AddRange(new object[] {
            "启用",
            "禁用"});
            this.cb_state2.Location = new System.Drawing.Point(65, 93);
            this.cb_state2.Name = "cb_state2";
            this.cb_state2.Size = new System.Drawing.Size(217, 20);
            this.cb_state2.TabIndex = 49;
            this.cb_state2.Text = "启用";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "备注";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 48;
            this.label7.Text = "状态";
            // 
            // txt_remark
            // 
            this.txt_remark.Location = new System.Drawing.Point(65, 119);
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(217, 21);
            this.txt_remark.TabIndex = 46;
            // 
            // tp_piliang
            // 
            this.tp_piliang.Controls.Add(this.label3);
            this.tp_piliang.Controls.Add(this.txt_fenge);
            this.tp_piliang.Controls.Add(this.btn_piliangsave);
            this.tp_piliang.Controls.Add(this.label2);
            this.tp_piliang.Controls.Add(this.txt_piliang);
            this.tp_piliang.Location = new System.Drawing.Point(4, 22);
            this.tp_piliang.Name = "tp_piliang";
            this.tp_piliang.Padding = new System.Windows.Forms.Padding(3);
            this.tp_piliang.Size = new System.Drawing.Size(1155, 728);
            this.tp_piliang.TabIndex = 5;
            this.tp_piliang.Text = "批量添加";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 57;
            this.label3.Text = "账号";
            // 
            // txt_fenge
            // 
            this.txt_fenge.Location = new System.Drawing.Point(48, 559);
            this.txt_fenge.Name = "txt_fenge";
            this.txt_fenge.Size = new System.Drawing.Size(946, 21);
            this.txt_fenge.TabIndex = 56;
            this.txt_fenge.Text = "---";
            // 
            // btn_piliangsave
            // 
            this.btn_piliangsave.Location = new System.Drawing.Point(48, 591);
            this.btn_piliangsave.Name = "btn_piliangsave";
            this.btn_piliangsave.Size = new System.Drawing.Size(217, 90);
            this.btn_piliangsave.TabIndex = 55;
            this.btn_piliangsave.Text = "批量添加";
            this.btn_piliangsave.UseVisualStyleBackColor = true;
            this.btn_piliangsave.Click += new System.EventHandler(this.btn_piliangsave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 562);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 54;
            this.label2.Text = "分割";
            // 
            // txt_piliang
            // 
            this.txt_piliang.Location = new System.Drawing.Point(48, 6);
            this.txt_piliang.Multiline = true;
            this.txt_piliang.Name = "txt_piliang";
            this.txt_piliang.Size = new System.Drawing.Size(946, 547);
            this.txt_piliang.TabIndex = 53;
            // 
            // tp_shuadan
            // 
            this.tp_shuadan.Controls.Add(this.btn_openurl);
            this.tp_shuadan.Controls.Add(this.txt_openurl);
            this.tp_shuadan.Controls.Add(this.btn_shuadan_geren);
            this.tp_shuadan.Controls.Add(this.pan_tool);
            this.tp_shuadan.Controls.Add(this.panel1);
            this.tp_shuadan.Location = new System.Drawing.Point(4, 22);
            this.tp_shuadan.Name = "tp_shuadan";
            this.tp_shuadan.Padding = new System.Windows.Forms.Padding(3);
            this.tp_shuadan.Size = new System.Drawing.Size(1149, 779);
            this.tp_shuadan.TabIndex = 6;
            this.tp_shuadan.Text = "开始刷单";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.btn_go);
            this.panel1.Controls.Add(this.btn_back);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(451, 756);
            this.panel1.TabIndex = 1;
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(408, 3);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(40, 38);
            this.btn_go.TabIndex = 3;
            this.btn_go.Text = ">";
            this.btn_go.UseVisualStyleBackColor = true;
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(3, 3);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(40, 38);
            this.btn_back.TabIndex = 3;
            this.btn_back.Text = "<";
            this.btn_back.UseVisualStyleBackColor = true;
            // 
            // pan_tool
            // 
            this.pan_tool.Location = new System.Drawing.Point(496, 450);
            this.pan_tool.Name = "pan_tool";
            this.pan_tool.Size = new System.Drawing.Size(240, 240);
            this.pan_tool.TabIndex = 2;
            // 
            // btn_shuadan_geren
            // 
            this.btn_shuadan_geren.Location = new System.Drawing.Point(496, 19);
            this.btn_shuadan_geren.Name = "btn_shuadan_geren";
            this.btn_shuadan_geren.Size = new System.Drawing.Size(146, 38);
            this.btn_shuadan_geren.TabIndex = 4;
            this.btn_shuadan_geren.Text = "个人中心";
            this.btn_shuadan_geren.UseVisualStyleBackColor = true;
            this.btn_shuadan_geren.Click += new System.EventHandler(this.btn_shuadan_geren_Click);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "全选";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // col_del
            // 
            this.col_del.HeaderText = "操作";
            this.col_del.Name = "col_del";
            this.col_del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_del.Text = "删除";
            this.col_del.UseColumnTextForButtonValue = true;
            this.col_del.Width = 80;
            // 
            // col_login
            // 
            this.col_login.HeaderText = "登录";
            this.col_login.Name = "col_login";
            this.col_login.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_login.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_login.Text = "登录";
            this.col_login.UseColumnTextForButtonValue = true;
            // 
            // col_account
            // 
            this.col_account.DataPropertyName = "sdaccount";
            this.col_account.HeaderText = "账号";
            this.col_account.Name = "col_account";
            this.col_account.Width = 200;
            // 
            // col_pwd
            // 
            this.col_pwd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_pwd.DataPropertyName = "sdapwd";
            this.col_pwd.HeaderText = "token密码";
            this.col_pwd.Name = "col_pwd";
            // 
            // col_phone
            // 
            this.col_phone.DataPropertyName = "sdaphone";
            this.col_phone.HeaderText = "手机";
            this.col_phone.Name = "col_phone";
            this.col_phone.Width = 150;
            // 
            // col_state
            // 
            this.col_state.DataPropertyName = "sdastate";
            this.col_state.HeaderText = "状态";
            this.col_state.Name = "col_state";
            this.col_state.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_state.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_dateaccount
            // 
            this.col_dateaccount.DataPropertyName = "sdadate";
            this.col_dateaccount.HeaderText = "操作时间";
            this.col_dateaccount.Name = "col_dateaccount";
            this.col_dateaccount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_dateaccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_remark
            // 
            this.col_remark.DataPropertyName = "sdaremark";
            this.col_remark.HeaderText = "备注";
            this.col_remark.Name = "col_remark";
            // 
            // txt_openurl
            // 
            this.txt_openurl.Location = new System.Drawing.Point(496, 81);
            this.txt_openurl.Multiline = true;
            this.txt_openurl.Name = "txt_openurl";
            this.txt_openurl.Size = new System.Drawing.Size(561, 104);
            this.txt_openurl.TabIndex = 5;
            // 
            // btn_openurl
            // 
            this.btn_openurl.Location = new System.Drawing.Point(496, 191);
            this.btn_openurl.Name = "btn_openurl";
            this.btn_openurl.Size = new System.Drawing.Size(75, 23);
            this.btn_openurl.TabIndex = 6;
            this.btn_openurl.Text = "打开网页";
            this.btn_openurl.UseVisualStyleBackColor = true;
            this.btn_openurl.Click += new System.EventHandler(this.btn_openurl_Click);
            // 
            // ShuaDanPDDFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 827);
            this.Controls.Add(this.tabControl1);
            this.Name = "ShuaDanPDDFrom";
            this.Text = "刷单账号管理";
            this.tabControl1.ResumeLayout(false);
            this.tp_typelist.ResumeLayout(false);
            this.tp_typelist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_type)).EndInit();
            this.tp_typeadd.ResumeLayout(false);
            this.tp_typeadd.PerformLayout();
            this.tp_piliang.ResumeLayout(false);
            this.tp_piliang.PerformLayout();
            this.tp_shuadan.ResumeLayout(false);
            this.tp_shuadan.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tp_typelist;
        private System.Windows.Forms.TabPage tp_typeadd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_account;
        private System.Windows.Forms.Button btn_typesave;
        private System.Windows.Forms.ComboBox cb_state2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_remark;
        //private System.Windows.Forms.DataGridView dgv_type;
        private Common.DataGridViewHelper dgv_type;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_phone;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox cb_state;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_typeadd;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TabPage tp_piliang;
        private System.Windows.Forms.Button btn_piliangsave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_piliang;
        private System.Windows.Forms.TextBox txt_fenge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tp_shuadan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Panel pan_tool;
        private System.Windows.Forms.Button btn_shuadan_geren;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn col_del;
        private System.Windows.Forms.DataGridViewButtonColumn col_login;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_account;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dateaccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.Button btn_openurl;
        private System.Windows.Forms.TextBox txt_openurl;
    }
}
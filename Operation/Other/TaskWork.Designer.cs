namespace Operation.Other
{
    partial class TaskWork
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_weifahuo = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.cb_state1 = new System.Windows.Forms.ComboBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.col_all = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dingshi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_date2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.cb_tixing = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.lbl_tixing = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_reset_dgv = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label35 = new System.Windows.Forms.Label();
            this.cb_state = new System.Windows.Forms.ComboBox();
            this.cb_chongfu = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_context = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1163, 723);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_delete);
            this.tabPage2.Controls.Add(this.btn_weifahuo);
            this.tabPage2.Controls.Add(this.btn_search);
            this.tabPage2.Controls.Add(this.cb_state1);
            this.tabPage2.Controls.Add(this.dgv1);
            this.tabPage2.Controls.Add(this.txt_key);
            this.tabPage2.Controls.Add(this.cb_tixing);
            this.tabPage2.Controls.Add(this.label34);
            this.tabPage2.Controls.Add(this.lbl_tixing);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1155, 697);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "任务列表";
            // 
            // btn_delete
            // 
            this.btn_delete.ForeColor = System.Drawing.Color.Red;
            this.btn_delete.Location = new System.Drawing.Point(6, 6);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 46;
            this.btn_delete.Text = "批量删除";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_weifahuo
            // 
            this.btn_weifahuo.Location = new System.Drawing.Point(87, 6);
            this.btn_weifahuo.Name = "btn_weifahuo";
            this.btn_weifahuo.Size = new System.Drawing.Size(75, 23);
            this.btn_weifahuo.TabIndex = 45;
            this.btn_weifahuo.Text = "未完成任务";
            this.btn_weifahuo.UseVisualStyleBackColor = true;
            this.btn_weifahuo.Click += new System.EventHandler(this.btn_weifahuo_Click);
            // 
            // btn_search
            // 
            this.btn_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_search.Location = new System.Drawing.Point(1064, 6);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(85, 23);
            this.btn_search.TabIndex = 33;
            this.btn_search.Text = "搜索1000条";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // cb_state1
            // 
            this.cb_state1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_state1.FormattingEnabled = true;
            this.cb_state1.Items.AddRange(new object[] {
            "请选择",
            "未处理",
            "已完成"});
            this.cb_state1.Location = new System.Drawing.Point(837, 7);
            this.cb_state1.Name = "cb_state1";
            this.cb_state1.Size = new System.Drawing.Size(60, 20);
            this.cb_state1.TabIndex = 42;
            this.cb_state1.Text = "请选择";
            // 
            // dgv1
            // 
            this.dgv1.AllowUserToAddRows = false;
            this.dgv1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_all,
            this.col_edit,
            this.col_name,
            this.col_content,
            this.col_state,
            this.col_dingshi,
            this.col_date1,
            this.col_date2});
            this.dgv1.Location = new System.Drawing.Point(10, 35);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(1139, 687);
            this.dgv1.TabIndex = 27;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentDoubleClick);
            this.dgv1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv1_CellFormatting);
            this.dgv1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgv1_CellParsing);
            this.dgv1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv1_RowPostPaint);
            // 
            // col_all
            // 
            this.col_all.HeaderText = "全选";
            this.col_all.Name = "col_all";
            this.col_all.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_all.Width = 40;
            // 
            // col_edit
            // 
            this.col_edit.HeaderText = "操作";
            this.col_edit.Name = "col_edit";
            this.col_edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.col_edit.Text = "修改";
            this.col_edit.UseColumnTextForButtonValue = true;
            this.col_edit.Width = 80;
            // 
            // col_name
            // 
            this.col_name.DataPropertyName = "btname";
            this.col_name.HeaderText = "任务名称";
            this.col_name.Name = "col_name";
            this.col_name.Width = 200;
            // 
            // col_content
            // 
            this.col_content.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_content.DataPropertyName = "btcontent";
            this.col_content.HeaderText = "任务内容";
            this.col_content.Name = "col_content";
            // 
            // col_state
            // 
            this.col_state.DataPropertyName = "btstate";
            this.col_state.HeaderText = "任务状态";
            this.col_state.Name = "col_state";
            this.col_state.Width = 150;
            // 
            // col_dingshi
            // 
            this.col_dingshi.DataPropertyName = "btspare1";
            this.col_dingshi.HeaderText = "定时提醒";
            this.col_dingshi.Name = "col_dingshi";
            // 
            // col_date1
            // 
            this.col_date1.DataPropertyName = "btdate";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue;
            this.col_date1.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_date1.HeaderText = "执行时间";
            this.col_date1.Name = "col_date1";
            this.col_date1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_date1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_date2
            // 
            this.col_date2.DataPropertyName = "btdate2";
            this.col_date2.HeaderText = "登记时间";
            this.col_date2.Name = "col_date2";
            this.col_date2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_date2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txt_key
            // 
            this.txt_key.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_key.Location = new System.Drawing.Point(950, 7);
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(108, 21);
            this.txt_key.TabIndex = 32;
            // 
            // cb_tixing
            // 
            this.cb_tixing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_tixing.FormattingEnabled = true;
            this.cb_tixing.Items.AddRange(new object[] {
            "无",
            "每天",
            "每月",
            "每年"});
            this.cb_tixing.Location = new System.Drawing.Point(712, 7);
            this.cb_tixing.Name = "cb_tixing";
            this.cb_tixing.Size = new System.Drawing.Size(60, 20);
            this.cb_tixing.TabIndex = 43;
            this.cb_tixing.Text = "无";
            this.cb_tixing.Visible = false;
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(903, 11);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(41, 12);
            this.label34.TabIndex = 34;
            this.label34.Text = "关键词";
            // 
            // lbl_tixing
            // 
            this.lbl_tixing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_tixing.AutoSize = true;
            this.lbl_tixing.Location = new System.Drawing.Point(653, 11);
            this.lbl_tixing.Name = "lbl_tixing";
            this.lbl_tixing.Size = new System.Drawing.Size(53, 12);
            this.lbl_tixing.TabIndex = 36;
            this.lbl_tixing.Text = "定时提醒";
            this.lbl_tixing.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(778, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 39;
            this.label2.Text = "空包状态";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_reset_dgv);
            this.tabPage3.Controls.Add(this.dateTimePicker1);
            this.tabPage3.Controls.Add(this.label35);
            this.tabPage3.Controls.Add(this.cb_state);
            this.tabPage3.Controls.Add(this.cb_chongfu);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btn_save);
            this.tabPage3.Controls.Add(this.txt_context);
            this.tabPage3.Controls.Add(this.txt_name);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1155, 697);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "添加任务";
            // 
            // btn_reset_dgv
            // 
            this.btn_reset_dgv.Location = new System.Drawing.Point(387, 116);
            this.btn_reset_dgv.Name = "btn_reset_dgv";
            this.btn_reset_dgv.Size = new System.Drawing.Size(40, 23);
            this.btn_reset_dgv.TabIndex = 46;
            this.btn_reset_dgv.Text = "重置";
            this.btn_reset_dgv.UseVisualStyleBackColor = true;
            this.btn_reset_dgv.Click += new System.EventHandler(this.btn_reset_dgv_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "请选择";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(162, 118);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(217, 21);
            this.dateTimePicker1.TabIndex = 47;
            this.dateTimePicker1.CloseUp += new System.EventHandler(this.dateTimePicker1_CloseUp_1);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(103, 122);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(53, 12);
            this.label35.TabIndex = 48;
            this.label35.Text = "执行时间";
            // 
            // cb_state
            // 
            this.cb_state.FormattingEnabled = true;
            this.cb_state.Items.AddRange(new object[] {
            "未处理",
            "已完成"});
            this.cb_state.Location = new System.Drawing.Point(162, 92);
            this.cb_state.Name = "cb_state";
            this.cb_state.Size = new System.Drawing.Size(217, 20);
            this.cb_state.TabIndex = 45;
            this.cb_state.Text = "未处理";
            // 
            // cb_chongfu
            // 
            this.cb_chongfu.FormattingEnabled = true;
            this.cb_chongfu.Items.AddRange(new object[] {
            "无",
            "每天",
            "每月",
            "每年"});
            this.cb_chongfu.Location = new System.Drawing.Point(162, 66);
            this.cb_chongfu.Name = "cb_chongfu";
            this.cb_chongfu.Size = new System.Drawing.Size(217, 20);
            this.cb_chongfu.TabIndex = 45;
            this.cb_chongfu.Text = "无";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 44;
            this.label5.Text = "状态";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "任务内容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 44;
            this.label4.Text = "任务标题";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 44;
            this.label3.Text = "重复任务";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(162, 408);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(85, 23);
            this.btn_save.TabIndex = 35;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_context
            // 
            this.txt_context.Location = new System.Drawing.Point(162, 145);
            this.txt_context.Multiline = true;
            this.txt_context.Name = "txt_context";
            this.txt_context.Size = new System.Drawing.Size(454, 212);
            this.txt_context.TabIndex = 34;
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(162, 39);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(217, 21);
            this.txt_name.TabIndex = 34;
            // 
            // btn_add
            // 
            this.btn_add.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_add.Location = new System.Drawing.Point(16, 12);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(1155, 25);
            this.btn_add.TabIndex = 45;
            this.btn_add.Text = "添加任务";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // TaskWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 776);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_add);
            this.Name = "TaskWork";
            this.Text = "店铺通用管理";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox cb_state1;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.ComboBox cb_tixing;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label lbl_tixing;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_weifahuo;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.ComboBox cb_state;
        private System.Windows.Forms.ComboBox cb_chongfu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_reset_dgv;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_context;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_all;
        private System.Windows.Forms.DataGridViewButtonColumn col_edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_content;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dingshi;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date2;
        private System.Windows.Forms.Button btn_add;
    }
}
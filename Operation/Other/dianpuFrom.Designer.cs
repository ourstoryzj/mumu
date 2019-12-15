namespace excel_operation
{
    partial class dianpuFrom
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
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_del = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.btn_sort = new System.Windows.Forms.Button();
            this.lbl_db = new System.Windows.Forms.Label();
            this.lbl_id = new System.Windows.Forms.Label();
            this.btn_clear = new System.Windows.Forms.Button();
            this.c_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_state = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_pwd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_state = new System.Windows.Forms.DataGridViewLinkColumn();
            this.c_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "店铺名称";
            // 
            // txt_name
            // 
            this.txt_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_name.Location = new System.Drawing.Point(69, 12);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(647, 21);
            this.txt_name.TabIndex = 1;
            // 
            // btn_ok
            // 
            this.btn_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ok.Location = new System.Drawing.Point(722, 10);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "保存";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_code,
            this.c_name,
            this.col_state,
            this.col_sort,
            this.col_account,
            this.col_pwd,
            this.col_phone,
            this.col_remark,
            this.c_state,
            this.c_remark});
            this.dataGridView1.Location = new System.Drawing.Point(12, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(863, 312);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            // 
            // btn_del
            // 
            this.btn_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_del.Location = new System.Drawing.Point(800, 10);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(75, 23);
            this.btn_del.TabIndex = 4;
            this.btn_del.Text = "删除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "备注信息";
            // 
            // txt_remark
            // 
            this.txt_remark.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_remark.Location = new System.Drawing.Point(69, 49);
            this.txt_remark.Multiline = true;
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.Size = new System.Drawing.Size(647, 46);
            this.txt_remark.TabIndex = 6;
            // 
            // btn_sort
            // 
            this.btn_sort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sort.Location = new System.Drawing.Point(723, 40);
            this.btn_sort.Name = "btn_sort";
            this.btn_sort.Size = new System.Drawing.Size(75, 23);
            this.btn_sort.TabIndex = 7;
            this.btn_sort.Text = "重置排序";
            this.btn_sort.UseVisualStyleBackColor = true;
            this.btn_sort.Click += new System.EventHandler(this.btn_sort_Click);
            // 
            // lbl_db
            // 
            this.lbl_db.AutoSize = true;
            this.lbl_db.Location = new System.Drawing.Point(12, 71);
            this.lbl_db.Name = "lbl_db";
            this.lbl_db.Size = new System.Drawing.Size(0, 12);
            this.lbl_db.TabIndex = 8;
            this.lbl_db.Visible = false;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(12, 83);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(0, 12);
            this.lbl_id.TabIndex = 9;
            this.lbl_id.Visible = false;
            // 
            // btn_clear
            // 
            this.btn_clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clear.Location = new System.Drawing.Point(801, 40);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 7;
            this.btn_clear.Text = "释放";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // c_code
            // 
            this.c_code.DataPropertyName = "dpid";
            this.c_code.HeaderText = "序号";
            this.c_code.Name = "c_code";
            // 
            // c_name
            // 
            this.c_name.DataPropertyName = "dpname";
            this.c_name.HeaderText = "店铺名称";
            this.c_name.Name = "c_name";
            // 
            // col_state
            // 
            this.col_state.DataPropertyName = "dpstate";
            this.col_state.HeaderText = "状态";
            this.col_state.Name = "col_state";
            this.col_state.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_state.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_sort
            // 
            this.col_sort.DataPropertyName = "dpsort";
            this.col_sort.HeaderText = "排序";
            this.col_sort.Name = "col_sort";
            this.col_sort.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_sort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_account
            // 
            this.col_account.DataPropertyName = "dpaccount";
            this.col_account.HeaderText = "账号";
            this.col_account.Name = "col_account";
            // 
            // col_pwd
            // 
            this.col_pwd.DataPropertyName = "dppwd";
            this.col_pwd.HeaderText = "密码";
            this.col_pwd.Name = "col_pwd";
            // 
            // col_phone
            // 
            this.col_phone.DataPropertyName = "dpremark1";
            this.col_phone.HeaderText = "绑定手机";
            this.col_phone.Name = "col_phone";
            // 
            // col_remark
            // 
            this.col_remark.DataPropertyName = "dpremark2";
            this.col_remark.HeaderText = "备注";
            this.col_remark.Name = "col_remark";
            // 
            // c_state
            // 
            this.c_state.HeaderText = "上移";
            this.c_state.Name = "c_state";
            this.c_state.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.c_state.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.c_state.Visible = false;
            // 
            // c_remark
            // 
            this.c_remark.DataPropertyName = "dpremark";
            this.c_remark.HeaderText = "备注";
            this.c_remark.Name = "c_remark";
            this.c_remark.Width = 200;
            // 
            // dianpuFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 437);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.lbl_db);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_sort);
            this.Controls.Add(this.txt_remark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label1);
            this.Name = "dianpuFrom";
            this.Text = "dianpuFrom";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.Button btn_sort;
        private System.Windows.Forms.Label lbl_db;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_name;
        private System.Windows.Forms.DataGridViewLinkColumn col_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_account;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_pwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_remark;
        private System.Windows.Forms.DataGridViewLinkColumn c_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_remark;
    }
}
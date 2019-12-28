namespace Operation.TaoBao
{
    partial class TB_ZaoCi
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
            this.txt_funame = new System.Windows.Forms.TextBox();
            this.btn_fuadd = new System.Windows.Forms.Button();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_state = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_names = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.col_all = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_name1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_state1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.col_date1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_caozuo1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btn_del = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_funame
            // 
            this.txt_funame.Location = new System.Drawing.Point(93, 13);
            this.txt_funame.Name = "txt_funame";
            this.txt_funame.Size = new System.Drawing.Size(177, 21);
            this.txt_funame.TabIndex = 0;
            this.txt_funame.TextChanged += new System.EventHandler(this.txt_funame_TextChanged);
            // 
            // btn_fuadd
            // 
            this.btn_fuadd.Location = new System.Drawing.Point(276, 12);
            this.btn_fuadd.Name = "btn_fuadd";
            this.btn_fuadd.Size = new System.Drawing.Size(99, 23);
            this.btn_fuadd.TabIndex = 1;
            this.btn_fuadd.Text = "添加噪词类目";
            this.btn_fuadd.UseVisualStyleBackColor = true;
            this.btn_fuadd.Click += new System.EventHandler(this.btn_fuadd_Click);
            // 
            // dgv1
            // 
            this.dgv1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_name,
            this.col_sort,
            this.col_state,
            this.col_date,
            this.col_delete});
            this.dgv1.Location = new System.Drawing.Point(12, 41);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(611, 114);
            this.dgv1.TabIndex = 2;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            this.dgv1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv1_CellFormatting);
            this.dgv1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgv1_CellParsing);
            this.dgv1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv1_RowPostPaint);
            // 
            // col_name
            // 
            this.col_name.DataPropertyName = "zname";
            this.col_name.HeaderText = "噪词类型名称";
            this.col_name.Name = "col_name";
            // 
            // col_sort
            // 
            this.col_sort.DataPropertyName = "zsort";
            this.col_sort.HeaderText = "排序";
            this.col_sort.Name = "col_sort";
            // 
            // col_state
            // 
            this.col_state.DataPropertyName = "zstate";
            this.col_state.HeaderText = "状态";
            this.col_state.Name = "col_state";
            this.col_state.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_state.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // col_date
            // 
            this.col_date.DataPropertyName = "zdate";
            this.col_date.HeaderText = "添加时间";
            this.col_date.Name = "col_date";
            // 
            // col_delete
            // 
            this.col_delete.HeaderText = "操作";
            this.col_delete.Name = "col_delete";
            this.col_delete.Text = "删除";
            this.col_delete.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "噪词类目名称";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txt_names
            // 
            this.txt_names.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_names.Location = new System.Drawing.Point(14, 199);
            this.txt_names.Multiline = true;
            this.txt_names.Name = "txt_names";
            this.txt_names.Size = new System.Drawing.Size(111, 369);
            this.txt_names.TabIndex = 4;
            this.txt_names.Text = "请在此输入噪词";
            this.txt_names.Click += new System.EventHandler(this.txt_names_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(611, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "--------------------";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(199, 171);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(111, 23);
            this.btn_add.TabIndex = 6;
            this.btn_add.Text = "添加噪词";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // cb_type
            // 
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(72, 172);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(121, 20);
            this.cb_type.TabIndex = 7;
            this.cb_type.SelectedIndexChanged += new System.EventHandler(this.cb_type_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "选择类型";
            // 
            // dgv2
            // 
            this.dgv2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_all,
            this.col_name1,
            this.col_state1,
            this.col_date1,
            this.col_caozuo1});
            this.dgv2.Location = new System.Drawing.Point(131, 200);
            this.dgv2.Name = "dgv2";
            this.dgv2.RowTemplate.Height = 23;
            this.dgv2.Size = new System.Drawing.Size(492, 368);
            this.dgv2.TabIndex = 9;
            this.dgv2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv2_CellContentClick);
            this.dgv2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv2_CellFormatting);
            this.dgv2.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dgv2_CellParsing);
            this.dgv2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv2_RowPostPaint);
            // 
            // col_all
            // 
            this.col_all.HeaderText = "全选";
            this.col_all.Name = "col_all";
            this.col_all.Width = 40;
            // 
            // col_name1
            // 
            this.col_name1.DataPropertyName = "zname";
            this.col_name1.HeaderText = "噪词名称";
            this.col_name1.Name = "col_name1";
            // 
            // col_state1
            // 
            this.col_state1.DataPropertyName = "zstate";
            this.col_state1.HeaderText = "状态";
            this.col_state1.Name = "col_state1";
            this.col_state1.Width = 60;
            // 
            // col_date1
            // 
            this.col_date1.DataPropertyName = "zdate";
            this.col_date1.HeaderText = "添加时间";
            this.col_date1.Name = "col_date1";
            this.col_date1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_date1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_caozuo1
            // 
            this.col_caozuo1.HeaderText = "操作";
            this.col_caozuo1.Name = "col_caozuo1";
            this.col_caozuo1.Text = "删除";
            this.col_caozuo1.UseColumnTextForButtonValue = true;
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(316, 171);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(111, 23);
            this.btn_del.TabIndex = 6;
            this.btn_del.Text = "批量删除";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // TB_ZaoCi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 580);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_type);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_names);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv1);
            this.Controls.Add(this.btn_fuadd);
            this.Controls.Add(this.txt_funame);
            this.Name = "TB_ZaoCi";
            this.Text = "噪词管理";
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_funame;
        private System.Windows.Forms.Button btn_fuadd;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_sort;
        private System.Windows.Forms.DataGridViewLinkColumn col_state;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date;
        private System.Windows.Forms.DataGridViewButtonColumn col_delete;
        private System.Windows.Forms.TextBox txt_names;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_all;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_name1;
        private System.Windows.Forms.DataGridViewLinkColumn col_state1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_date1;
        private System.Windows.Forms.DataGridViewButtonColumn col_caozuo1;
    }
}
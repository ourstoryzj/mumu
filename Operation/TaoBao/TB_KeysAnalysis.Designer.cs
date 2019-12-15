namespace excel_operation.TaoBao
{
    partial class TB_KeysAnalysis
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_dp_huan = new System.Windows.Forms.Button();
            this.lbl_message = new System.Windows.Forms.Label();
            this.txt_js = new System.Windows.Forms.TextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_quchonghexinci = new System.Windows.Forms.Button();
            this.btn_clear_hexinci = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.btn_jisuanqingchu = new System.Windows.Forms.Button();
            this.btn_jisuan = new System.Windows.Forms.Button();
            this.dgv_key = new System.Windows.Forms.DataGridView();
            this.col_key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_baohanci = new System.Windows.Forms.TextBox();
            this.txt_hexinci = new System.Windows.Forms.TextBox();
            this.txt_key = new System.Windows.Forms.TextBox();
            this.btn_clearbaohan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_key)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btn_dp_huan);
            this.groupBox1.Controls.Add(this.lbl_message);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 698);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // btn_dp_huan
            // 
            this.btn_dp_huan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_dp_huan.Location = new System.Drawing.Point(6, 20);
            this.btn_dp_huan.Name = "btn_dp_huan";
            this.btn_dp_huan.Size = new System.Drawing.Size(146, 23);
            this.btn_dp_huan.TabIndex = 0;
            this.btn_dp_huan.Text = "更换店铺";
            this.btn_dp_huan.UseVisualStyleBackColor = true;
            this.btn_dp_huan.Click += new System.EventHandler(this.btn_dp_huan_Click);
            // 
            // lbl_message
            // 
            this.lbl_message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(14, 700);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(41, 12);
            this.lbl_message.TabIndex = 31;
            this.lbl_message.Text = "操作：";
            // 
            // txt_js
            // 
            this.txt_js.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_js.Location = new System.Drawing.Point(12, 717);
            this.txt_js.Name = "txt_js";
            this.txt_js.Size = new System.Drawing.Size(77, 21);
            this.txt_js.TabIndex = 7;
            // 
            // btn_test
            // 
            this.btn_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_test.Location = new System.Drawing.Point(95, 716);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 23);
            this.btn_test.TabIndex = 8;
            this.btn_test.Text = "测试JS";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(176, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1084, 727);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.btn_clearbaohan);
            this.tabPage4.Controls.Add(this.btn_quchonghexinci);
            this.tabPage4.Controls.Add(this.btn_clear_hexinci);
            this.tabPage4.Controls.Add(this.btn_clear);
            this.tabPage4.Controls.Add(this.btn_jisuanqingchu);
            this.tabPage4.Controls.Add(this.btn_jisuan);
            this.tabPage4.Controls.Add(this.dgv_key);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.txt_baohanci);
            this.tabPage4.Controls.Add(this.txt_hexinci);
            this.tabPage4.Controls.Add(this.txt_key);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1076, 701);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "标题关键词处理";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(754, 311);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "==>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "==>";
            // 
            // btn_quchonghexinci
            // 
            this.btn_quchonghexinci.Location = new System.Drawing.Point(728, 130);
            this.btn_quchonghexinci.Name = "btn_quchonghexinci";
            this.btn_quchonghexinci.Size = new System.Drawing.Size(75, 23);
            this.btn_quchonghexinci.TabIndex = 4;
            this.btn_quchonghexinci.Text = "去重核心词";
            this.btn_quchonghexinci.UseVisualStyleBackColor = true;
            this.btn_quchonghexinci.Click += new System.EventHandler(this.btn_quchonghexinci_Click);
            // 
            // btn_clear_hexinci
            // 
            this.btn_clear_hexinci.Location = new System.Drawing.Point(728, 101);
            this.btn_clear_hexinci.Name = "btn_clear_hexinci";
            this.btn_clear_hexinci.Size = new System.Drawing.Size(75, 23);
            this.btn_clear_hexinci.TabIndex = 4;
            this.btn_clear_hexinci.Text = "清空";
            this.btn_clear_hexinci.UseVisualStyleBackColor = true;
            this.btn_clear_hexinci.Click += new System.EventHandler(this.btn_clear_hexinci_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(389, 101);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 4;
            this.btn_clear.Text = "清空";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_jisuanqingchu
            // 
            this.btn_jisuanqingchu.Location = new System.Drawing.Point(389, 130);
            this.btn_jisuanqingchu.Name = "btn_jisuanqingchu";
            this.btn_jisuanqingchu.Size = new System.Drawing.Size(75, 55);
            this.btn_jisuanqingchu.TabIndex = 4;
            this.btn_jisuanqingchu.Text = "计算&&清除包含核心词";
            this.btn_jisuanqingchu.UseVisualStyleBackColor = true;
            this.btn_jisuanqingchu.Click += new System.EventHandler(this.btn_jisuanqingchu_Click);
            // 
            // btn_jisuan
            // 
            this.btn_jisuan.Location = new System.Drawing.Point(389, 73);
            this.btn_jisuan.Name = "btn_jisuan";
            this.btn_jisuan.Size = new System.Drawing.Size(75, 23);
            this.btn_jisuan.TabIndex = 4;
            this.btn_jisuan.Text = "开始计算";
            this.btn_jisuan.UseVisualStyleBackColor = true;
            this.btn_jisuan.Click += new System.EventHandler(this.btn_jisuan_Click);
            // 
            // dgv_key
            // 
            this.dgv_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv_key.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_key.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_key,
            this.col_num});
            this.dgv_key.Location = new System.Drawing.Point(470, 18);
            this.dgv_key.Name = "dgv_key";
            this.dgv_key.RowTemplate.Height = 23;
            this.dgv_key.Size = new System.Drawing.Size(251, 650);
            this.dgv_key.TabIndex = 3;
            this.dgv_key.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_key_CellContentClick);
            // 
            // col_key
            // 
            this.col_key.DataPropertyName = "kname";
            this.col_key.HeaderText = "关键词";
            this.col_key.Name = "col_key";
            // 
            // col_num
            // 
            this.col_num.DataPropertyName = "knum";
            this.col_num.HeaderText = "数量";
            this.col_num.Name = "col_num";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(807, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "行业核心关键词/需要排除包含核心词的关键词";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(468, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "分析结果";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "关键词";
            // 
            // txt_baohanci
            // 
            this.txt_baohanci.AllowDrop = true;
            this.txt_baohanci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_baohanci.Location = new System.Drawing.Point(470, 674);
            this.txt_baohanci.Multiline = true;
            this.txt_baohanci.Name = "txt_baohanci";
            this.txt_baohanci.Size = new System.Drawing.Size(251, 21);
            this.txt_baohanci.TabIndex = 1;
            // 
            // txt_hexinci
            // 
            this.txt_hexinci.AllowDrop = true;
            this.txt_hexinci.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_hexinci.Location = new System.Drawing.Point(809, 18);
            this.txt_hexinci.Multiline = true;
            this.txt_hexinci.Name = "txt_hexinci";
            this.txt_hexinci.Size = new System.Drawing.Size(264, 672);
            this.txt_hexinci.TabIndex = 1;
            // 
            // txt_key
            // 
            this.txt_key.AllowDrop = true;
            this.txt_key.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_key.Location = new System.Drawing.Point(6, 18);
            this.txt_key.Multiline = true;
            this.txt_key.Name = "txt_key";
            this.txt_key.Size = new System.Drawing.Size(372, 672);
            this.txt_key.TabIndex = 1;
            this.txt_key.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_key_biaoti_DragDrop);
            this.txt_key.DragEnter += new System.Windows.Forms.DragEventHandler(this.txt_key_biaoti_DragEnter);
            // 
            // btn_clearbaohan
            // 
            this.btn_clearbaohan.Location = new System.Drawing.Point(728, 159);
            this.btn_clearbaohan.Name = "btn_clearbaohan";
            this.btn_clearbaohan.Size = new System.Drawing.Size(75, 23);
            this.btn_clearbaohan.TabIndex = 4;
            this.btn_clearbaohan.Text = "查词根";
            this.btn_clearbaohan.UseVisualStyleBackColor = true;
            this.btn_clearbaohan.Click += new System.EventHandler(this.btn_clearbaohan_Click);
            // 
            // TB_KeysAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 750);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.txt_js);
            this.Controls.Add(this.groupBox1);
            this.Name = "TB_KeysAnalysis";
            this.Text = "店铺通用管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_key)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_dp_huan;
        private System.Windows.Forms.TextBox txt_js;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btn_jisuan;
        private System.Windows.Forms.DataGridView dgv_key;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_key;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_key;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_num;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_baohanci;
        private System.Windows.Forms.TextBox txt_hexinci;
        private System.Windows.Forms.Button btn_clear_hexinci;
        private System.Windows.Forms.Button btn_jisuanqingchu;
        private System.Windows.Forms.Button btn_quchonghexinci;
        private System.Windows.Forms.Button btn_clearbaohan;
    }
}
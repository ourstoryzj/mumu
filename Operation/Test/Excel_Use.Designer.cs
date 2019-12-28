namespace Operation
{
    partial class form_main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_xuanzewenjian = new System.Windows.Forms.Button();
            this.txt_lujing = new System.Windows.Forms.TextBox();
            this.btn_bangding = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_test = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_cishu2 = new System.Windows.Forms.TextBox();
            this.txt_cishu1 = new System.Windows.Forms.TextBox();
            this.txt_renshu2 = new System.Windows.Forms.TextBox();
            this.txt_renshu1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_zhitongche2 = new System.Windows.Forms.TextBox();
            this.txt_zhuanhualv2 = new System.Windows.Forms.TextBox();
            this.txt_dianjilv2 = new System.Windows.Forms.TextBox();
            this.txt_zhitongche1 = new System.Windows.Forms.TextBox();
            this.txt_zhuanhualv1 = new System.Windows.Forms.TextBox();
            this.txt_shangcheng2 = new System.Windows.Forms.TextBox();
            this.txt_dianjilv1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_changdu2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_shangcheng1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_changdu1 = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 192);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1179, 552);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            // 
            // btn_xuanzewenjian
            // 
            this.btn_xuanzewenjian.Location = new System.Drawing.Point(948, 10);
            this.btn_xuanzewenjian.Name = "btn_xuanzewenjian";
            this.btn_xuanzewenjian.Size = new System.Drawing.Size(141, 23);
            this.btn_xuanzewenjian.TabIndex = 1;
            this.btn_xuanzewenjian.Text = "请选择Excel文件";
            this.btn_xuanzewenjian.UseVisualStyleBackColor = true;
            this.btn_xuanzewenjian.Click += new System.EventHandler(this.btn_xuanzewenjian_Click);
            // 
            // txt_lujing
            // 
            this.txt_lujing.Location = new System.Drawing.Point(95, 12);
            this.txt_lujing.Name = "txt_lujing";
            this.txt_lujing.Size = new System.Drawing.Size(841, 21);
            this.txt_lujing.TabIndex = 2;
            this.txt_lujing.Click += new System.EventHandler(this.txt_lujing_Click);
            // 
            // btn_bangding
            // 
            this.btn_bangding.Location = new System.Drawing.Point(1100, 10);
            this.btn_bangding.Name = "btn_bangding";
            this.btn_bangding.Size = new System.Drawing.Size(93, 23);
            this.btn_bangding.TabIndex = 1;
            this.btn_bangding.Text = "重新绑定";
            this.btn_bangding.UseVisualStyleBackColor = true;
            this.btn_bangding.Click += new System.EventHandler(this.btn_bangding_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(1032, 163);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(161, 23);
            this.btn_test.TabIndex = 3;
            this.btn_test.Text = "删除转化率为0%的关键词";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "请选择文件：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(112, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "< = 关键词长度 < =";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txt_cishu2);
            this.groupBox1.Controls.Add(this.txt_cishu1);
            this.groupBox1.Controls.Add(this.txt_renshu2);
            this.groupBox1.Controls.Add(this.txt_renshu1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txt_zhitongche2);
            this.groupBox1.Controls.Add(this.txt_zhuanhualv2);
            this.groupBox1.Controls.Add(this.txt_dianjilv2);
            this.groupBox1.Controls.Add(this.txt_zhitongche1);
            this.groupBox1.Controls.Add(this.txt_zhuanhualv1);
            this.groupBox1.Controls.Add(this.txt_shangcheng2);
            this.groupBox1.Controls.Add(this.txt_dianjilv1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_changdu2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_shangcheng1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txt_changdu1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(14, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1179, 106);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "筛选";
            // 
            // txt_cishu2
            // 
            this.txt_cishu2.Location = new System.Drawing.Point(1073, 20);
            this.txt_cishu2.Name = "txt_cishu2";
            this.txt_cishu2.Size = new System.Drawing.Size(100, 21);
            this.txt_cishu2.TabIndex = 7;
            // 
            // txt_cishu1
            // 
            this.txt_cishu1.Location = new System.Drawing.Point(848, 20);
            this.txt_cishu1.Name = "txt_cishu1";
            this.txt_cishu1.Size = new System.Drawing.Size(100, 21);
            this.txt_cishu1.TabIndex = 7;
            // 
            // txt_renshu2
            // 
            this.txt_renshu2.Location = new System.Drawing.Point(647, 20);
            this.txt_renshu2.Name = "txt_renshu2";
            this.txt_renshu2.Size = new System.Drawing.Size(100, 21);
            this.txt_renshu2.TabIndex = 7;
            // 
            // txt_renshu1
            // 
            this.txt_renshu1.Location = new System.Drawing.Point(422, 20);
            this.txt_renshu1.Name = "txt_renshu1";
            this.txt_renshu1.Size = new System.Drawing.Size(100, 21);
            this.txt_renshu1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(954, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "< = 搜索次数 < =";
            // 
            // txt_zhitongche2
            // 
            this.txt_zhitongche2.Location = new System.Drawing.Point(231, 74);
            this.txt_zhitongche2.Name = "txt_zhitongche2";
            this.txt_zhitongche2.Size = new System.Drawing.Size(100, 21);
            this.txt_zhitongche2.TabIndex = 7;
            // 
            // txt_zhuanhualv2
            // 
            this.txt_zhuanhualv2.Location = new System.Drawing.Point(1073, 47);
            this.txt_zhuanhualv2.Name = "txt_zhuanhualv2";
            this.txt_zhuanhualv2.Size = new System.Drawing.Size(100, 21);
            this.txt_zhuanhualv2.TabIndex = 7;
            // 
            // txt_dianjilv2
            // 
            this.txt_dianjilv2.Location = new System.Drawing.Point(647, 47);
            this.txt_dianjilv2.Name = "txt_dianjilv2";
            this.txt_dianjilv2.Size = new System.Drawing.Size(100, 21);
            this.txt_dianjilv2.TabIndex = 7;
            // 
            // txt_zhitongche1
            // 
            this.txt_zhitongche1.Location = new System.Drawing.Point(6, 74);
            this.txt_zhitongche1.Name = "txt_zhitongche1";
            this.txt_zhitongche1.Size = new System.Drawing.Size(100, 21);
            this.txt_zhitongche1.TabIndex = 7;
            // 
            // txt_zhuanhualv1
            // 
            this.txt_zhuanhualv1.Location = new System.Drawing.Point(848, 47);
            this.txt_zhuanhualv1.Name = "txt_zhuanhualv1";
            this.txt_zhuanhualv1.Size = new System.Drawing.Size(100, 21);
            this.txt_zhuanhualv1.TabIndex = 7;
            // 
            // txt_shangcheng2
            // 
            this.txt_shangcheng2.Location = new System.Drawing.Point(231, 47);
            this.txt_shangcheng2.Name = "txt_shangcheng2";
            this.txt_shangcheng2.Size = new System.Drawing.Size(100, 21);
            this.txt_shangcheng2.TabIndex = 7;
            // 
            // txt_dianjilv1
            // 
            this.txt_dianjilv1.Location = new System.Drawing.Point(422, 47);
            this.txt_dianjilv1.Name = "txt_dianjilv1";
            this.txt_dianjilv1.Size = new System.Drawing.Size(100, 21);
            this.txt_dianjilv1.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(112, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "< = 直通车出价 < =";
            // 
            // txt_changdu2
            // 
            this.txt_changdu2.Location = new System.Drawing.Point(231, 20);
            this.txt_changdu2.Name = "txt_changdu2";
            this.txt_changdu2.Size = new System.Drawing.Size(100, 21);
            this.txt_changdu2.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(954, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "< = 转化率 < =";
            // 
            // txt_shangcheng1
            // 
            this.txt_shangcheng1.Location = new System.Drawing.Point(6, 47);
            this.txt_shangcheng1.Name = "txt_shangcheng1";
            this.txt_shangcheng1.Size = new System.Drawing.Size(100, 21);
            this.txt_shangcheng1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(528, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "< = 点击率 < =";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(528, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "< = 搜索人数 < =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(112, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "< = 商城占比 < =";
            // 
            // txt_changdu1
            // 
            this.txt_changdu1.Location = new System.Drawing.Point(6, 20);
            this.txt_changdu1.Name = "txt_changdu1";
            this.txt_changdu1.Size = new System.Drawing.Size(100, 21);
            this.txt_changdu1.TabIndex = 7;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(14, 162);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(106, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "导出到Excel";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 756);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.txt_lujing);
            this.Controls.Add(this.btn_bangding);
            this.Controls.Add(this.btn_xuanzewenjian);
            this.Controls.Add(this.dataGridView1);
            this.Name = "form_main";
            this.Text = "Excel操作工具";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_xuanzewenjian;
        private System.Windows.Forms.TextBox txt_lujing;
        private System.Windows.Forms.Button btn_bangding;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_changdu1;
        private System.Windows.Forms.TextBox txt_changdu2;
        private System.Windows.Forms.TextBox txt_cishu2;
        private System.Windows.Forms.TextBox txt_cishu1;
        private System.Windows.Forms.TextBox txt_renshu2;
        private System.Windows.Forms.TextBox txt_renshu1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_zhitongche2;
        private System.Windows.Forms.TextBox txt_zhuanhualv2;
        private System.Windows.Forms.TextBox txt_dianjilv2;
        private System.Windows.Forms.TextBox txt_zhitongche1;
        private System.Windows.Forms.TextBox txt_zhuanhualv1;
        private System.Windows.Forms.TextBox txt_shangcheng2;
        private System.Windows.Forms.TextBox txt_dianjilv1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_shangcheng1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_save;
    }
}


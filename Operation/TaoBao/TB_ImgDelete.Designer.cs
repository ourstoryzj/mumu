namespace excel_operation.TaoBao
{
    partial class TB_ImgDelete
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
            this.btn_img = new System.Windows.Forms.Button();
            this.btn_dp_huan = new System.Windows.Forms.Button();
            this.txt_js = new System.Windows.Forms.TextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_url = new System.Windows.Forms.TabPage();
            this.txt_jiafa = new System.Windows.Forms.TextBox();
            this.txt_chengfa = new System.Windows.Forms.TextBox();
            this.btn_fuzhi2 = new System.Windows.Forms.Button();
            this.txt_goodslist = new System.Windows.Forms.TextBox();
            this.btn_caijigoodsreset = new System.Windows.Forms.Button();
            this.btn_searchgoods = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_goodsurl = new System.Windows.Forms.TextBox();
            this.btn_savehtml = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_state = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.txt_url.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btn_state);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_img);
            this.groupBox1.Controls.Add(this.btn_dp_huan);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 724);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // btn_img
            // 
            this.btn_img.Location = new System.Drawing.Point(6, 170);
            this.btn_img.Name = "btn_img";
            this.btn_img.Size = new System.Drawing.Size(146, 23);
            this.btn_img.TabIndex = 0;
            this.btn_img.Text = "图片空间";
            this.btn_img.UseVisualStyleBackColor = true;
            this.btn_img.Click += new System.EventHandler(this.btn_img_Click);
            // 
            // btn_dp_huan
            // 
            this.btn_dp_huan.Location = new System.Drawing.Point(6, 20);
            this.btn_dp_huan.Name = "btn_dp_huan";
            this.btn_dp_huan.Size = new System.Drawing.Size(146, 23);
            this.btn_dp_huan.TabIndex = 0;
            this.btn_dp_huan.Text = "更换店铺";
            this.btn_dp_huan.UseVisualStyleBackColor = true;
            this.btn_dp_huan.Click += new System.EventHandler(this.btn_dp_huan_Click);
            // 
            // txt_js
            // 
            this.txt_js.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_js.Location = new System.Drawing.Point(12, 743);
            this.txt_js.Name = "txt_js";
            this.txt_js.Size = new System.Drawing.Size(57, 21);
            this.txt_js.TabIndex = 7;
            // 
            // btn_test
            // 
            this.btn_test.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_test.Location = new System.Drawing.Point(75, 742);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(52, 23);
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.txt_url);
            this.tabControl1.Location = new System.Drawing.Point(176, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(999, 753);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(991, 727);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "买家中心";
            // 
            // txt_url
            // 
            this.txt_url.Controls.Add(this.txt_jiafa);
            this.txt_url.Controls.Add(this.txt_chengfa);
            this.txt_url.Controls.Add(this.btn_fuzhi2);
            this.txt_url.Controls.Add(this.txt_goodslist);
            this.txt_url.Controls.Add(this.btn_caijigoodsreset);
            this.txt_url.Controls.Add(this.btn_searchgoods);
            this.txt_url.Controls.Add(this.label4);
            this.txt_url.Controls.Add(this.label3);
            this.txt_url.Controls.Add(this.label2);
            this.txt_url.Controls.Add(this.label1);
            this.txt_url.Controls.Add(this.txt_goodsurl);
            this.txt_url.Location = new System.Drawing.Point(4, 22);
            this.txt_url.Name = "txt_url";
            this.txt_url.Padding = new System.Windows.Forms.Padding(3);
            this.txt_url.Size = new System.Drawing.Size(991, 727);
            this.txt_url.TabIndex = 1;
            this.txt_url.Text = "复制商品";
            // 
            // txt_jiafa
            // 
            this.txt_jiafa.Location = new System.Drawing.Point(356, 315);
            this.txt_jiafa.Name = "txt_jiafa";
            this.txt_jiafa.Size = new System.Drawing.Size(100, 21);
            this.txt_jiafa.TabIndex = 5;
            this.txt_jiafa.Text = "-2";
            // 
            // txt_chengfa
            // 
            this.txt_chengfa.Location = new System.Drawing.Point(221, 315);
            this.txt_chengfa.Name = "txt_chengfa";
            this.txt_chengfa.Size = new System.Drawing.Size(100, 21);
            this.txt_chengfa.TabIndex = 5;
            this.txt_chengfa.Text = "100";
            // 
            // btn_fuzhi2
            // 
            this.btn_fuzhi2.Location = new System.Drawing.Point(526, 314);
            this.btn_fuzhi2.Name = "btn_fuzhi2";
            this.btn_fuzhi2.Size = new System.Drawing.Size(310, 23);
            this.btn_fuzhi2.TabIndex = 4;
            this.btn_fuzhi2.Text = "开始复制";
            this.btn_fuzhi2.UseVisualStyleBackColor = true;
            // 
            // txt_goodslist
            // 
            this.txt_goodslist.Location = new System.Drawing.Point(92, 33);
            this.txt_goodslist.Multiline = true;
            this.txt_goodslist.Name = "txt_goodslist";
            this.txt_goodslist.Size = new System.Drawing.Size(744, 274);
            this.txt_goodslist.TabIndex = 3;
            // 
            // btn_caijigoodsreset
            // 
            this.btn_caijigoodsreset.Location = new System.Drawing.Point(842, 33);
            this.btn_caijigoodsreset.Name = "btn_caijigoodsreset";
            this.btn_caijigoodsreset.Size = new System.Drawing.Size(75, 23);
            this.btn_caijigoodsreset.TabIndex = 2;
            this.btn_caijigoodsreset.Text = "重置采集";
            this.btn_caijigoodsreset.UseVisualStyleBackColor = true;
            // 
            // btn_searchgoods
            // 
            this.btn_searchgoods.Location = new System.Drawing.Point(842, 4);
            this.btn_searchgoods.Name = "btn_searchgoods";
            this.btn_searchgoods.Size = new System.Drawing.Size(75, 23);
            this.btn_searchgoods.TabIndex = 2;
            this.btn_searchgoods.Text = "采集";
            this.btn_searchgoods.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(462, 319);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "元";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(327, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "% +";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 319);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "价格设置：宝贝原价 *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "搜索页网址";
            // 
            // txt_goodsurl
            // 
            this.txt_goodsurl.Location = new System.Drawing.Point(92, 6);
            this.txt_goodsurl.Name = "txt_goodsurl";
            this.txt_goodsurl.Size = new System.Drawing.Size(744, 21);
            this.txt_goodsurl.TabIndex = 0;
            // 
            // btn_savehtml
            // 
            this.btn_savehtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_savehtml.Location = new System.Drawing.Point(133, 742);
            this.btn_savehtml.Name = "btn_savehtml";
            this.btn_savehtml.Size = new System.Drawing.Size(37, 23);
            this.btn_savehtml.TabIndex = 8;
            this.btn_savehtml.Text = "HTML";
            this.btn_savehtml.UseVisualStyleBackColor = true;
            this.btn_savehtml.Click += new System.EventHandler(this.btn_savehtml_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(6, 199);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(146, 23);
            this.btn_delete.TabIndex = 0;
            this.btn_delete.Text = "删除本页图片";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_state
            // 
            this.btn_state.ForeColor = System.Drawing.Color.Red;
            this.btn_state.Location = new System.Drawing.Point(6, 62);
            this.btn_state.Name = "btn_state";
            this.btn_state.Size = new System.Drawing.Size(146, 23);
            this.btn_state.TabIndex = 1;
            this.btn_state.Text = "状态：启动";
            this.btn_state.UseVisualStyleBackColor = true;
            this.btn_state.Click += new System.EventHandler(this.btn_state_Click);
            // 
            // TB_ImgDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 776);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_savehtml);
            this.Controls.Add(this.btn_test);
            this.Controls.Add(this.txt_js);
            this.Controls.Add(this.groupBox1);
            this.Name = "TB_ImgDelete";
            this.Text = "店铺通用管理";
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.txt_url.ResumeLayout(false);
            this.txt_url.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_dp_huan;
        private System.Windows.Forms.Button btn_img;
        private System.Windows.Forms.TextBox txt_js;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage txt_url;
        private System.Windows.Forms.Button btn_savehtml;
        private System.Windows.Forms.Button btn_searchgoods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_goodsurl;
        private System.Windows.Forms.TextBox txt_goodslist;
        private System.Windows.Forms.Button btn_caijigoodsreset;
        private System.Windows.Forms.Button btn_fuzhi2;
        private System.Windows.Forms.TextBox txt_chengfa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_jiafa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_state;
    }
}
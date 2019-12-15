namespace TimelyReminder
{
    partial class TimelyRemminder
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimelyRemminder));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_time = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_timeok = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(241, 41);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 0;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "每隔";
            // 
            // txt_time
            // 
            this.txt_time.Location = new System.Drawing.Point(76, 43);
            this.txt_time.Name = "txt_time";
            this.txt_time.Size = new System.Drawing.Size(100, 21);
            this.txt_time.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "分钟提醒";
            // 
            // lbl_timeok
            // 
            this.lbl_timeok.AutoSize = true;
            this.lbl_timeok.Location = new System.Drawing.Point(74, 28);
            this.lbl_timeok.Name = "lbl_timeok";
            this.lbl_timeok.Size = new System.Drawing.Size(0, 12);
            this.lbl_timeok.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "定时提醒";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
            // 
            // TimelyRemminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 108);
            this.Controls.Add(this.txt_time);
            this.Controls.Add(this.lbl_timeok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ok);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(371, 146);
            this.MinimumSize = new System.Drawing.Size(371, 146);
            this.Name = "TimelyRemminder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时提醒";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.TimelyRemminder_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TimelyRemminder_FormClosing);
            this.Load += new System.EventHandler(this.TimelyRemminder_Load);
            this.DoubleClick += new System.EventHandler(this.TimelyRemminder_DoubleClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_timeok;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}


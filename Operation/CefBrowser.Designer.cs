namespace Operation
{
    partial class CefBrowser
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.btn_go = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_f12 = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.个人中心ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询IPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pan_pay = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pan_pay);
            this.panel1.Location = new System.Drawing.Point(12, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 678);
            this.panel1.TabIndex = 0;
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(12, 12);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(30, 30);
            this.btn_back.TabIndex = 1;
            this.btn_back.Text = "<";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // btn_go
            // 
            this.btn_go.Location = new System.Drawing.Point(48, 12);
            this.btn_go.Name = "btn_go";
            this.btn_go.Size = new System.Drawing.Size(30, 30);
            this.btn_go.TabIndex = 2;
            this.btn_go.Text = ">";
            this.btn_go.UseVisualStyleBackColor = true;
            this.btn_go.Click += new System.EventHandler(this.btn_go_Click);
            // 
            // txt_url
            // 
            this.txt_url.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_url.Location = new System.Drawing.Point(84, 12);
            this.txt_url.Multiline = true;
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(237, 30);
            this.txt_url.TabIndex = 0;
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(327, 12);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(39, 30);
            this.btn_open.TabIndex = 3;
            this.btn_open.Text = "打开";
            this.btn_open.UseMnemonic = false;
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_f12
            // 
            this.btn_f12.Location = new System.Drawing.Point(372, 12);
            this.btn_f12.Name = "btn_f12";
            this.btn_f12.Size = new System.Drawing.Size(39, 30);
            this.btn_f12.TabIndex = 4;
            this.btn_f12.Text = "F12";
            this.btn_f12.UseMnemonic = false;
            this.btn_f12.UseVisualStyleBackColor = true;
            this.btn_f12.Click += new System.EventHandler(this.btn_f12_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(417, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(39, 30);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "保存";
            this.btn_save.UseMnemonic = false;
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.个人中心ToolStripMenuItem,
            this.查询IPToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 个人中心ToolStripMenuItem
            // 
            this.个人中心ToolStripMenuItem.Name = "个人中心ToolStripMenuItem";
            this.个人中心ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.个人中心ToolStripMenuItem.Text = "个人中心";
            this.个人中心ToolStripMenuItem.Click += new System.EventHandler(this.个人中心ToolStripMenuItem_Click);
            // 
            // 查询IPToolStripMenuItem
            // 
            this.查询IPToolStripMenuItem.Name = "查询IPToolStripMenuItem";
            this.查询IPToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查询IPToolStripMenuItem.Text = "查询IP";
            this.查询IPToolStripMenuItem.Click += new System.EventHandler(this.查询IPToolStripMenuItem_Click);
            // 
            // pan_pay
            // 
            this.pan_pay.Location = new System.Drawing.Point(218, 455);
            this.pan_pay.Name = "pan_pay";
            this.pan_pay.Size = new System.Drawing.Size(220, 220);
            this.pan_pay.TabIndex = 0;
            this.pan_pay.Visible = false;
            this.pan_pay.Paint += new System.Windows.Forms.PaintEventHandler(this.pan_pay_Paint);
            // 
            // CefBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(465, 738);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_f12);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.txt_url);
            this.Controls.Add(this.btn_go);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "CefBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chrome浏览器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CefBrowser_FormClosing);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_go;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_f12;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 个人中心ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询IPToolStripMenuItem;
        private System.Windows.Forms.Panel pan_pay;
    }
}
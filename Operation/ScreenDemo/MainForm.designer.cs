using System;

namespace Operation.ScreenDemo
{
    partial class MainForm
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
            HRectangle hRectangle1 = new HRectangle();
            this.spControl = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRectangle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddbPen = new System.Windows.Forms.ToolStripDropDownButton();
            this.miRed = new System.Windows.Forms.ToolStripMenuItem();
            this.miBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.miGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.miBlack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLightPen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEraser = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDefault = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.smiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.smiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.smiSaveOther = new System.Windows.Forms.ToolStripMenuItem();
            this.smiSend = new System.Windows.Forms.ToolStripMenuItem();
            this.smiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.smiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.smiTool = new System.Windows.Forms.ToolStripMenuItem();
            this.smiPen = new System.Windows.Forms.ToolStripMenuItem();
            this.smiLightPen = new System.Windows.Forms.ToolStripMenuItem();
            this.smiEraser = new System.Windows.Forms.ToolStripMenuItem();
            this.smiOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.smiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.smiHelp1 = new System.Windows.Forms.ToolStripMenuItem();
            this.smiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new HexPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.spControl)).BeginInit();
            this.spControl.Panel1.SuspendLayout();
            this.spControl.Panel2.SuspendLayout();
            this.spControl.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // spControl
            // 
            this.spControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spControl.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spControl.IsSplitterFixed = true;
            this.spControl.Location = new System.Drawing.Point(0, 0);
            this.spControl.Name = "spControl";
            this.spControl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spControl.Panel1
            // 
            this.spControl.Panel1.Controls.Add(this.toolStrip1);
            this.spControl.Panel1.Controls.Add(this.menuStrip1);
            // 
            // spControl.Panel2
            // 
            this.spControl.Panel2.Controls.Add(this.pictureBox1);
            this.spControl.Size = new System.Drawing.Size(896, 421);
            this.spControl.SplitterDistance = 70;
            this.spControl.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.toolStripSeparator1,
            this.tsbSave,
            this.toolStripSeparator2,
            this.tsbCopy,
            this.toolStripSeparator3,
            this.tsbRectangle,
            this.toolStripSeparator8,
            this.tsddbPen,
            this.toolStripSeparator4,
            this.tsbLightPen,
            this.toolStripSeparator5,
            this.tsbEraser,
            this.toolStripSeparator6,
            this.tsbDefault});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 2, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(896, 26);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::Operation.Properties.Resources.new1;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(70, 21);
            this.tsbNew.Text = "新建(N)";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::Operation.Properties.Resources.save;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(67, 21);
            this.tsbSave.Text = "保存(S)";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbCopy
            // 
            this.tsbCopy.Image = global::Operation.Properties.Resources.copy;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(68, 21);
            this.tsbCopy.Text = "复制(C)";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbRectangle
            // 
            this.tsbRectangle.Image = global::Operation.Properties.Resources.rectangle;
            this.tsbRectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRectangle.Name = "tsbRectangle";
            this.tsbRectangle.Size = new System.Drawing.Size(52, 21);
            this.tsbRectangle.Text = "矩形";
            this.tsbRectangle.Click += new System.EventHandler(this.tsbRectangle_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 24);
            // 
            // tsddbPen
            // 
            this.tsddbPen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRed,
            this.miBlue,
            this.miGreen,
            this.miBlack});
            this.tsddbPen.Image = global::Operation.Properties.Resources.pen;
            this.tsddbPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbPen.Name = "tsddbPen";
            this.tsddbPen.Size = new System.Drawing.Size(49, 21);
            this.tsddbPen.Text = "笔";
            this.tsddbPen.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsddbPen_DropDownItemClicked);
            // 
            // miRed
            // 
            this.miRed.Name = "miRed";
            this.miRed.Size = new System.Drawing.Size(88, 22);
            this.miRed.Tag = "RED";
            this.miRed.Text = "红";
            // 
            // miBlue
            // 
            this.miBlue.Name = "miBlue";
            this.miBlue.Size = new System.Drawing.Size(88, 22);
            this.miBlue.Tag = "BLUE";
            this.miBlue.Text = "蓝";
            // 
            // miGreen
            // 
            this.miGreen.Name = "miGreen";
            this.miGreen.Size = new System.Drawing.Size(88, 22);
            this.miGreen.Tag = "GREEN";
            this.miGreen.Text = "绿";
            // 
            // miBlack
            // 
            this.miBlack.Name = "miBlack";
            this.miBlack.Size = new System.Drawing.Size(88, 22);
            this.miBlack.Tag = "BLACK";
            this.miBlack.Text = "黑";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbLightPen
            // 
            this.tsbLightPen.Image = global::Operation.Properties.Resources.lightpen;
            this.tsbLightPen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLightPen.Name = "tsbLightPen";
            this.tsbLightPen.Size = new System.Drawing.Size(64, 21);
            this.tsbLightPen.Text = "荧光笔";
            this.tsbLightPen.Click += new System.EventHandler(this.tsbLightPen_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbEraser
            // 
            this.tsbEraser.Image = global::Operation.Properties.Resources.easer1;
            this.tsbEraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEraser.Name = "tsbEraser";
            this.tsbEraser.Size = new System.Drawing.Size(64, 21);
            this.tsbEraser.Text = "橡皮擦";
            this.tsbEraser.Click += new System.EventHandler(this.tsbEraser_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbDefault
            // 
            this.tsbDefault.Image = global::Operation.Properties.Resources.mouse;
            this.tsbDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDefault.Name = "tsbDefault";
            this.tsbDefault.Size = new System.Drawing.Size(76, 21);
            this.tsbDefault.Text = "默认光标";
            this.tsbDefault.Click += new System.EventHandler(this.tsbDefault_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiFile,
            this.smiEdit,
            this.smiTool,
            this.smiHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(896, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // smiFile
            // 
            this.smiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiNew,
            this.smiSaveOther,
            this.smiSend,
            this.smiExit});
            this.smiFile.Name = "smiFile";
            this.smiFile.Size = new System.Drawing.Size(58, 21);
            this.smiFile.Text = "文件(F)";
            // 
            // smiNew
            // 
            this.smiNew.Name = "smiNew";
            this.smiNew.Size = new System.Drawing.Size(142, 22);
            this.smiNew.Text = "新建截图(N)";
            this.smiNew.Click += new System.EventHandler(this.smiNew_Click);
            // 
            // smiSaveOther
            // 
            this.smiSaveOther.Name = "smiSaveOther";
            this.smiSaveOther.Size = new System.Drawing.Size(142, 22);
            this.smiSaveOther.Text = "另存为(A)...";
            this.smiSaveOther.Click += new System.EventHandler(this.smiSaveOther_Click);
            // 
            // smiSend
            // 
            this.smiSend.Name = "smiSend";
            this.smiSend.Size = new System.Drawing.Size(142, 22);
            this.smiSend.Text = "发送到(T)";
            this.smiSend.Click += new System.EventHandler(this.smiSend_Click);
            // 
            // smiExit
            // 
            this.smiExit.Name = "smiExit";
            this.smiExit.Size = new System.Drawing.Size(142, 22);
            this.smiExit.Text = "退出(X)";
            this.smiExit.Click += new System.EventHandler(this.smiExit_Click);
            // 
            // smiEdit
            // 
            this.smiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiCopy});
            this.smiEdit.Name = "smiEdit";
            this.smiEdit.Size = new System.Drawing.Size(59, 21);
            this.smiEdit.Text = "编辑(E)";
            // 
            // smiCopy
            // 
            this.smiCopy.Name = "smiCopy";
            this.smiCopy.Size = new System.Drawing.Size(116, 22);
            this.smiCopy.Text = "复制(C)";
            this.smiCopy.Click += new System.EventHandler(this.smiCopy_Click);
            // 
            // smiTool
            // 
            this.smiTool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiPen,
            this.smiLightPen,
            this.smiEraser,
            this.smiOperation});
            this.smiTool.Name = "smiTool";
            this.smiTool.Size = new System.Drawing.Size(59, 21);
            this.smiTool.Text = "工具(T)";
            // 
            // smiPen
            // 
            this.smiPen.Name = "smiPen";
            this.smiPen.Size = new System.Drawing.Size(152, 22);
            this.smiPen.Text = "笔(P)";
            this.smiPen.Click += new System.EventHandler(this.smiPen_Click);
            // 
            // smiLightPen
            // 
            this.smiLightPen.Name = "smiLightPen";
            this.smiLightPen.Size = new System.Drawing.Size(152, 22);
            this.smiLightPen.Text = "荧光笔(H)";
            this.smiLightPen.Click += new System.EventHandler(this.smiLightPen_Click);
            // 
            // smiEraser
            // 
            this.smiEraser.Name = "smiEraser";
            this.smiEraser.Size = new System.Drawing.Size(152, 22);
            this.smiEraser.Text = "橡皮擦(E)";
            this.smiEraser.Click += new System.EventHandler(this.smiEraser_Click);
            // 
            // smiOperation
            // 
            this.smiOperation.Name = "smiOperation";
            this.smiOperation.Size = new System.Drawing.Size(152, 22);
            this.smiOperation.Text = "选项(O)...";
            this.smiOperation.Click += new System.EventHandler(this.smiOperation_Click);
            // 
            // smiHelp
            // 
            this.smiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiHelp1,
            this.smiAbout});
            this.smiHelp.Name = "smiHelp";
            this.smiHelp.Size = new System.Drawing.Size(61, 21);
            this.smiHelp.Text = "帮助(H)";
            // 
            // smiHelp1
            // 
            this.smiHelp1.Name = "smiHelp1";
            this.smiHelp1.Size = new System.Drawing.Size(152, 22);
            this.smiHelp1.Text = "帮助(H)";
            this.smiHelp1.Click += new System.EventHandler(this.smiHelp1_Click);
            // 
            // smiAbout
            // 
            this.smiAbout.Name = "smiAbout";
            this.smiAbout.Size = new System.Drawing.Size(152, 22);
            this.smiAbout.Text = "关于(A)";
            this.smiAbout.Click += new System.EventHandler(this.smiAbout_Click);
            // 
            // pictureBox1
            // 
            hRectangle1.End = new System.Drawing.Point(0, 0);
            hRectangle1.LineColor = System.Drawing.Color.White;
            hRectangle1.LineWidth = 2;
            hRectangle1.Start = new System.Drawing.Point(0, 0);
            this.pictureBox1.CurRect = hRectangle1;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.DrawTypes = DrawType.None;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(896, 347);
            this.pictureBox1.StartDraw = false;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 421);
            this.Controls.Add(this.spControl);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm----截图工具";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.spControl.Panel1.ResumeLayout(false);
            this.spControl.Panel1.PerformLayout();
            this.spControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spControl)).EndInit();
            this.spControl.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spControl;
        private System.Windows.Forms.ToolStripMenuItem smiFile;
        private System.Windows.Forms.ToolStripMenuItem smiEdit;
        private System.Windows.Forms.ToolStripMenuItem smiTool;
        private System.Windows.Forms.ToolStripMenuItem smiHelp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem smiSaveOther;
        private System.Windows.Forms.ToolStripMenuItem smiSend;
        private System.Windows.Forms.ToolStripMenuItem smiExit;
        private System.Windows.Forms.ToolStripMenuItem smiNew;
        private System.Windows.Forms.ToolStripMenuItem smiCopy;
        private System.Windows.Forms.ToolStripMenuItem smiPen;
        private System.Windows.Forms.ToolStripMenuItem smiLightPen;
        private System.Windows.Forms.ToolStripMenuItem smiEraser;
        private System.Windows.Forms.ToolStripMenuItem smiOperation;
        private System.Windows.Forms.ToolStripMenuItem smiHelp1;
        private System.Windows.Forms.ToolStripMenuItem smiAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton tsddbPen;
        private System.Windows.Forms.ToolStripMenuItem miRed;
        private System.Windows.Forms.ToolStripMenuItem miBlue;
        private System.Windows.Forms.ToolStripMenuItem miGreen;
        private System.Windows.Forms.ToolStripMenuItem miBlack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbLightPen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbEraser;
        private HexPictureBox pictureBox1;
        private System.Windows.Forms.ToolStripButton tsbDefault;
        private System.Windows.Forms.ToolStripButton tsbRectangle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
    }
}


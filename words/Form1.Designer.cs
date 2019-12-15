namespace words
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.收起ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.话术ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加话术ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.话术列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加话术类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.话术类型列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.好评ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.待处理返现ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部返现ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.售后ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退货ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退货列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资料列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加资料类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资料类型列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.补单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.淘宝蘑菇街ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统蘑菇街ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.蘑菇街空包网ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.转换自定义格式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷单账号列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加刷单账号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.评语列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加评语ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.姓名列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加姓名ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.地址库列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.其他ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加店铺ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.店铺列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加快递ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.快递列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.处理返现ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pan_huashu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.全部收起ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加话术ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改话术ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pan_web = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pan_huashu.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.pan_web.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 622);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(192, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.RaisedOuter;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(36, 21);
            this.toolStripStatusLabel2.Text = "同步";
            this.toolStripStatusLabel2.Click += new System.EventHandler(this.toolStripStatusLabel2_Click);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 20);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.收起ToolStripMenuItem,
            this.话术ToolStripMenuItem,
            this.好评ToolStripMenuItem,
            this.售后ToolStripMenuItem,
            this.退货ToolStripMenuItem,
            this.资料ToolStripMenuItem,
            this.补单ToolStripMenuItem,
            this.其他ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(192, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 收起ToolStripMenuItem
            // 
            this.收起ToolStripMenuItem.Name = "收起ToolStripMenuItem";
            this.收起ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.收起ToolStripMenuItem.Text = "收起";
            this.收起ToolStripMenuItem.Click += new System.EventHandler(this.收起ToolStripMenuItem_Click);
            // 
            // 话术ToolStripMenuItem
            // 
            this.话术ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加话术ToolStripMenuItem1,
            this.话术列表ToolStripMenuItem,
            this.添加话术类型ToolStripMenuItem,
            this.话术类型列表ToolStripMenuItem});
            this.话术ToolStripMenuItem.Name = "话术ToolStripMenuItem";
            this.话术ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.话术ToolStripMenuItem.Text = "话术";
            this.话术ToolStripMenuItem.Click += new System.EventHandler(this.话术ToolStripMenuItem_Click);
            // 
            // 添加话术ToolStripMenuItem1
            // 
            this.添加话术ToolStripMenuItem1.Name = "添加话术ToolStripMenuItem1";
            this.添加话术ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.添加话术ToolStripMenuItem1.Text = "添加话术";
            this.添加话术ToolStripMenuItem1.Click += new System.EventHandler(this.添加话术ToolStripMenuItem1_Click);
            // 
            // 话术列表ToolStripMenuItem
            // 
            this.话术列表ToolStripMenuItem.Name = "话术列表ToolStripMenuItem";
            this.话术列表ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.话术列表ToolStripMenuItem.Text = "话术列表";
            this.话术列表ToolStripMenuItem.Click += new System.EventHandler(this.话术列表ToolStripMenuItem_Click);
            // 
            // 添加话术类型ToolStripMenuItem
            // 
            this.添加话术类型ToolStripMenuItem.Name = "添加话术类型ToolStripMenuItem";
            this.添加话术类型ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.添加话术类型ToolStripMenuItem.Text = "添加话术类型";
            this.添加话术类型ToolStripMenuItem.Click += new System.EventHandler(this.添加话术类型ToolStripMenuItem_Click);
            // 
            // 话术类型列表ToolStripMenuItem
            // 
            this.话术类型列表ToolStripMenuItem.Name = "话术类型列表ToolStripMenuItem";
            this.话术类型列表ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.话术类型列表ToolStripMenuItem.Text = "话术类型列表";
            this.话术类型列表ToolStripMenuItem.Click += new System.EventHandler(this.话术类型列表ToolStripMenuItem_Click);
            // 
            // 好评ToolStripMenuItem
            // 
            this.好评ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.待处理返现ToolStripMenuItem,
            this.全部返现ToolStripMenuItem});
            this.好评ToolStripMenuItem.Name = "好评ToolStripMenuItem";
            this.好评ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.好评ToolStripMenuItem.Text = "好评";
            this.好评ToolStripMenuItem.Click += new System.EventHandler(this.好评ToolStripMenuItem_Click);
            // 
            // 待处理返现ToolStripMenuItem
            // 
            this.待处理返现ToolStripMenuItem.Name = "待处理返现ToolStripMenuItem";
            this.待处理返现ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.待处理返现ToolStripMenuItem.Text = "待处理返现";
            this.待处理返现ToolStripMenuItem.Click += new System.EventHandler(this.待处理返现ToolStripMenuItem_Click);
            // 
            // 全部返现ToolStripMenuItem
            // 
            this.全部返现ToolStripMenuItem.Name = "全部返现ToolStripMenuItem";
            this.全部返现ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.全部返现ToolStripMenuItem.Text = "全部返现列表";
            this.全部返现ToolStripMenuItem.Click += new System.EventHandler(this.全部返现ToolStripMenuItem_Click);
            // 
            // 售后ToolStripMenuItem
            // 
            this.售后ToolStripMenuItem.Name = "售后ToolStripMenuItem";
            this.售后ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.售后ToolStripMenuItem.Text = "图片";
            this.售后ToolStripMenuItem.Click += new System.EventHandler(this.售后ToolStripMenuItem_Click);
            // 
            // 退货ToolStripMenuItem
            // 
            this.退货ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退货列表ToolStripMenuItem});
            this.退货ToolStripMenuItem.Name = "退货ToolStripMenuItem";
            this.退货ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.退货ToolStripMenuItem.Text = "退货";
            this.退货ToolStripMenuItem.Click += new System.EventHandler(this.退货ToolStripMenuItem_Click);
            // 
            // 退货列表ToolStripMenuItem
            // 
            this.退货列表ToolStripMenuItem.Name = "退货列表ToolStripMenuItem";
            this.退货列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退货列表ToolStripMenuItem.Text = "退货列表";
            this.退货列表ToolStripMenuItem.Click += new System.EventHandler(this.退货列表ToolStripMenuItem_Click);
            // 
            // 资料ToolStripMenuItem
            // 
            this.资料ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.资料列表ToolStripMenuItem,
            this.添加资料类型ToolStripMenuItem,
            this.资料类型列表ToolStripMenuItem});
            this.资料ToolStripMenuItem.Name = "资料ToolStripMenuItem";
            this.资料ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.资料ToolStripMenuItem.Text = "资料";
            this.资料ToolStripMenuItem.Visible = false;
            this.资料ToolStripMenuItem.Click += new System.EventHandler(this.资料ToolStripMenuItem_Click);
            // 
            // 资料列表ToolStripMenuItem
            // 
            this.资料列表ToolStripMenuItem.Name = "资料列表ToolStripMenuItem";
            this.资料列表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.资料列表ToolStripMenuItem.Text = "资料列表";
            this.资料列表ToolStripMenuItem.Click += new System.EventHandler(this.资料列表ToolStripMenuItem_Click);
            // 
            // 添加资料类型ToolStripMenuItem
            // 
            this.添加资料类型ToolStripMenuItem.Name = "添加资料类型ToolStripMenuItem";
            this.添加资料类型ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.添加资料类型ToolStripMenuItem.Text = "添加资料类型";
            this.添加资料类型ToolStripMenuItem.Click += new System.EventHandler(this.添加资料类型ToolStripMenuItem_Click);
            // 
            // 资料类型列表ToolStripMenuItem
            // 
            this.资料类型列表ToolStripMenuItem.Name = "资料类型列表ToolStripMenuItem";
            this.资料类型列表ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.资料类型列表ToolStripMenuItem.Text = "资料类型列表";
            this.资料类型列表ToolStripMenuItem.Click += new System.EventHandler(this.资料类型列表ToolStripMenuItem_Click);
            // 
            // 补单ToolStripMenuItem
            // 
            this.补单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.淘宝蘑菇街ToolStripMenuItem,
            this.系统蘑菇街ToolStripMenuItem,
            this.蘑菇街空包网ToolStripMenuItem,
            this.转换自定义格式ToolStripMenuItem,
            this.刷单账号列表ToolStripMenuItem,
            this.添加刷单账号ToolStripMenuItem,
            this.评语列表ToolStripMenuItem,
            this.添加评语ToolStripMenuItem,
            this.姓名列表ToolStripMenuItem,
            this.添加姓名ToolStripMenuItem,
            this.地址库列表ToolStripMenuItem,
            this.下载记录ToolStripMenuItem});
            this.补单ToolStripMenuItem.Name = "补单ToolStripMenuItem";
            this.补单ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.补单ToolStripMenuItem.Text = "补单";
            this.补单ToolStripMenuItem.Visible = false;
            this.补单ToolStripMenuItem.Click += new System.EventHandler(this.补单ToolStripMenuItem_Click);
            // 
            // 淘宝蘑菇街ToolStripMenuItem
            // 
            this.淘宝蘑菇街ToolStripMenuItem.Name = "淘宝蘑菇街ToolStripMenuItem";
            this.淘宝蘑菇街ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.淘宝蘑菇街ToolStripMenuItem.Text = "淘宝==>蘑菇街";
            this.淘宝蘑菇街ToolStripMenuItem.Click += new System.EventHandler(this.淘宝蘑菇街ToolStripMenuItem_Click);
            // 
            // 系统蘑菇街ToolStripMenuItem
            // 
            this.系统蘑菇街ToolStripMenuItem.Name = "系统蘑菇街ToolStripMenuItem";
            this.系统蘑菇街ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.系统蘑菇街ToolStripMenuItem.Text = "系统==>蘑菇街";
            this.系统蘑菇街ToolStripMenuItem.Click += new System.EventHandler(this.系统蘑菇街ToolStripMenuItem_Click);
            // 
            // 蘑菇街空包网ToolStripMenuItem
            // 
            this.蘑菇街空包网ToolStripMenuItem.Name = "蘑菇街空包网ToolStripMenuItem";
            this.蘑菇街空包网ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.蘑菇街空包网ToolStripMenuItem.Text = "蘑菇街==>空包网";
            this.蘑菇街空包网ToolStripMenuItem.Click += new System.EventHandler(this.蘑菇街空包网ToolStripMenuItem_Click);
            // 
            // 转换自定义格式ToolStripMenuItem
            // 
            this.转换自定义格式ToolStripMenuItem.Name = "转换自定义格式ToolStripMenuItem";
            this.转换自定义格式ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.转换自定义格式ToolStripMenuItem.Text = "转换自定义格式";
            this.转换自定义格式ToolStripMenuItem.Click += new System.EventHandler(this.转换自定义格式ToolStripMenuItem_Click);
            // 
            // 刷单账号列表ToolStripMenuItem
            // 
            this.刷单账号列表ToolStripMenuItem.Name = "刷单账号列表ToolStripMenuItem";
            this.刷单账号列表ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.刷单账号列表ToolStripMenuItem.Text = "刷单账号列表";
            this.刷单账号列表ToolStripMenuItem.Click += new System.EventHandler(this.刷单账号列表ToolStripMenuItem_Click);
            // 
            // 添加刷单账号ToolStripMenuItem
            // 
            this.添加刷单账号ToolStripMenuItem.Name = "添加刷单账号ToolStripMenuItem";
            this.添加刷单账号ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.添加刷单账号ToolStripMenuItem.Text = "添加刷单账号";
            this.添加刷单账号ToolStripMenuItem.Click += new System.EventHandler(this.添加刷单账号ToolStripMenuItem_Click);
            // 
            // 评语列表ToolStripMenuItem
            // 
            this.评语列表ToolStripMenuItem.Name = "评语列表ToolStripMenuItem";
            this.评语列表ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.评语列表ToolStripMenuItem.Text = "评语列表";
            this.评语列表ToolStripMenuItem.Click += new System.EventHandler(this.评语列表ToolStripMenuItem_Click);
            // 
            // 添加评语ToolStripMenuItem
            // 
            this.添加评语ToolStripMenuItem.Name = "添加评语ToolStripMenuItem";
            this.添加评语ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.添加评语ToolStripMenuItem.Text = "添加评语";
            this.添加评语ToolStripMenuItem.Click += new System.EventHandler(this.添加评语ToolStripMenuItem_Click);
            // 
            // 姓名列表ToolStripMenuItem
            // 
            this.姓名列表ToolStripMenuItem.Name = "姓名列表ToolStripMenuItem";
            this.姓名列表ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.姓名列表ToolStripMenuItem.Text = "姓名列表";
            this.姓名列表ToolStripMenuItem.Click += new System.EventHandler(this.姓名列表ToolStripMenuItem_Click);
            // 
            // 添加姓名ToolStripMenuItem
            // 
            this.添加姓名ToolStripMenuItem.Name = "添加姓名ToolStripMenuItem";
            this.添加姓名ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.添加姓名ToolStripMenuItem.Text = "添加姓名";
            this.添加姓名ToolStripMenuItem.Click += new System.EventHandler(this.添加姓名ToolStripMenuItem_Click);
            // 
            // 地址库列表ToolStripMenuItem
            // 
            this.地址库列表ToolStripMenuItem.Name = "地址库列表ToolStripMenuItem";
            this.地址库列表ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.地址库列表ToolStripMenuItem.Text = "地址库列表";
            this.地址库列表ToolStripMenuItem.Click += new System.EventHandler(this.地址库列表ToolStripMenuItem_Click);
            // 
            // 下载记录ToolStripMenuItem
            // 
            this.下载记录ToolStripMenuItem.Name = "下载记录ToolStripMenuItem";
            this.下载记录ToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.下载记录ToolStripMenuItem.Text = "下载记录";
            this.下载记录ToolStripMenuItem.Click += new System.EventHandler(this.下载记录ToolStripMenuItem_Click);
            // 
            // 其他ToolStripMenuItem
            // 
            this.其他ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加店铺ToolStripMenuItem,
            this.店铺列表ToolStripMenuItem,
            this.添加快递ToolStripMenuItem,
            this.快递列表ToolStripMenuItem,
            this.处理返现ToolStripMenuItem});
            this.其他ToolStripMenuItem.Name = "其他ToolStripMenuItem";
            this.其他ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.其他ToolStripMenuItem.Text = "其他";
            this.其他ToolStripMenuItem.Visible = false;
            // 
            // 添加店铺ToolStripMenuItem
            // 
            this.添加店铺ToolStripMenuItem.Name = "添加店铺ToolStripMenuItem";
            this.添加店铺ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加店铺ToolStripMenuItem.Text = "添加店铺";
            this.添加店铺ToolStripMenuItem.Click += new System.EventHandler(this.添加店铺ToolStripMenuItem_Click);
            // 
            // 店铺列表ToolStripMenuItem
            // 
            this.店铺列表ToolStripMenuItem.Name = "店铺列表ToolStripMenuItem";
            this.店铺列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.店铺列表ToolStripMenuItem.Text = "店铺列表";
            this.店铺列表ToolStripMenuItem.Click += new System.EventHandler(this.店铺列表ToolStripMenuItem_Click);
            // 
            // 添加快递ToolStripMenuItem
            // 
            this.添加快递ToolStripMenuItem.Name = "添加快递ToolStripMenuItem";
            this.添加快递ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加快递ToolStripMenuItem.Text = "添加快递";
            this.添加快递ToolStripMenuItem.Click += new System.EventHandler(this.添加快递ToolStripMenuItem_Click);
            // 
            // 快递列表ToolStripMenuItem
            // 
            this.快递列表ToolStripMenuItem.Name = "快递列表ToolStripMenuItem";
            this.快递列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.快递列表ToolStripMenuItem.Text = "快递列表";
            this.快递列表ToolStripMenuItem.Click += new System.EventHandler(this.快递列表ToolStripMenuItem_Click);
            // 
            // 处理返现ToolStripMenuItem
            // 
            this.处理返现ToolStripMenuItem.Name = "处理返现ToolStripMenuItem";
            this.处理返现ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.处理返现ToolStripMenuItem.Text = "处理返现";
            this.处理返现ToolStripMenuItem.Click += new System.EventHandler(this.处理返现ToolStripMenuItem_Click);
            // 
            // pan_huashu
            // 
            this.pan_huashu.Controls.Add(this.label1);
            this.pan_huashu.Controls.Add(this.treeView1);
            this.pan_huashu.Controls.Add(this.statusStrip1);
            this.pan_huashu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_huashu.Location = new System.Drawing.Point(0, 25);
            this.pan_huashu.Name = "pan_huashu";
            this.pan_huashu.Size = new System.Drawing.Size(192, 648);
            this.pan_huashu.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(148, 631);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "F1呼出";
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ItemHeight = 24;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(192, 622);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全部收起ToolStripMenuItem,
            this.添加话术ToolStripMenuItem,
            this.修改话术ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // 全部收起ToolStripMenuItem
            // 
            this.全部收起ToolStripMenuItem.Name = "全部收起ToolStripMenuItem";
            this.全部收起ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.全部收起ToolStripMenuItem.Text = "全部收起";
            this.全部收起ToolStripMenuItem.Click += new System.EventHandler(this.全部收起ToolStripMenuItem_Click);
            // 
            // 添加话术ToolStripMenuItem
            // 
            this.添加话术ToolStripMenuItem.Name = "添加话术ToolStripMenuItem";
            this.添加话术ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加话术ToolStripMenuItem.Text = "添加话术";
            this.添加话术ToolStripMenuItem.Click += new System.EventHandler(this.添加话术ToolStripMenuItem_Click);
            // 
            // 修改话术ToolStripMenuItem
            // 
            this.修改话术ToolStripMenuItem.Name = "修改话术ToolStripMenuItem";
            this.修改话术ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改话术ToolStripMenuItem.Text = "修改话术";
            this.修改话术ToolStripMenuItem.Visible = false;
            this.修改话术ToolStripMenuItem.Click += new System.EventHandler(this.修改话术ToolStripMenuItem_Click);
            // 
            // pan_web
            // 
            this.pan_web.Controls.Add(this.webBrowser1);
            this.pan_web.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_web.Location = new System.Drawing.Point(0, 25);
            this.pan_web.Name = "pan_web";
            this.pan_web.Size = new System.Drawing.Size(192, 648);
            this.pan_web.TabIndex = 4;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(192, 648);
            this.webBrowser1.TabIndex = 0;
            // 
            // skinEngine1
            // 
            this.skinEngine1.@__DrawButtonFocusRectangle = true;
            this.skinEngine1.DisabledButtonTextColor = System.Drawing.Color.Gray;
            this.skinEngine1.DisabledMenuFontColor = System.Drawing.SystemColors.GrayText;
            this.skinEngine1.InactiveCaptionColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 673);
            this.Controls.Add(this.pan_huashu);
            this.Controls.Add(this.pan_web);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "青涩年华话术工具";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pan_huashu.ResumeLayout(false);
            this.pan_huashu.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.pan_web.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 话术ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 好评ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 售后ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退货ToolStripMenuItem;
        
        private System.Windows.Forms.Panel pan_web;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel pan_huashu;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加话术ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改话术ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部收起ToolStripMenuItem;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.ToolStripMenuItem 添加话术ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加话术类型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 话术列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 话术类型列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 待处理返现ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部返现ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退货列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资料列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加资料类型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资料类型列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 补单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 淘宝蘑菇街ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统蘑菇街ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 蘑菇街空包网ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 转换自定义格式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷单账号列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加刷单账号ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 评语列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加评语ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 姓名列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加姓名ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 地址库列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其他ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加店铺ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 店铺列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加快递ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 快递列表ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 收起ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 处理返现ToolStripMenuItem;
    }
}


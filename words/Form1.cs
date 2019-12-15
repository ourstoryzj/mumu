using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Runtime.InteropServices;
using System.Reflection;
using Entity;
using BLL;
using System.Configuration;
using System.Threading;
using System.Diagnostics;

namespace words
{
    public partial class Form1 : Form
    {
        private CodeProject.SystemHotkey.SystemHotkey systemHotkey1 = new CodeProject.SystemHotkey.SystemHotkey();
        private CodeProject.SystemHotkey.SystemHotkey systemHotkey2 = new CodeProject.SystemHotkey.SystemHotkey();
        public static Form1 fm = null;
        public static int huashu_hid = 0;
        /// <summary>
        /// 登录用户的编号 1员工 2主管 3经理
        /// </summary>
        public static string user;
        DateTime clicktime = new DateTime();


        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//位置居中
            //自定义快捷键
            RegHotkey();
            bind();
            bind_user();
            notifyIcon1.Visible = true;
            this.ShowInTaskbar = false;
            fm = this;
            //设置皮肤
            try
            {
                string skinname = ConfigurationManager.AppSettings["Style"].ToString();
                if (!string.IsNullOrEmpty(skinname))
                    this.skinEngine1.SkinFile = System.Environment.CurrentDirectory + skinname;
            }
            catch { }
            //多线程同步数据
            //Control.CheckForIllegalCrossThreadCalls = false;//不设置线程会出错
            //ThreadStart startDownload = new ThreadStart(tongbu); //线程起始设置：即每个线程都执行DownLoad()，注意：DownLoad()必须为不带有参数的方法
            //Thread downloadThread = new Thread(startDownload); //实例化要开启的新类
            //downloadThread.Start();//开启线程

        }

        #region 用户权限
        /// <summary>
        /// 绑定用户权限
        /// </summary>
        public void bind_user()
        {
            if (user == "3")
            {
                资料ToolStripMenuItem.Visible = true;
                补单ToolStripMenuItem.Visible = true;
                其他ToolStripMenuItem.Visible = true;
            }
            else if (user == "2")
            {
                其他ToolStripMenuItem.Visible = true;
            }
        }
        #endregion

        #region bind
        /// <summary>
        /// 绑定话术
        /// </summary>
        public void bind()
        {
            pan_web.Visible = false;
            pan_huashu.Visible = true;
            try
            {
                treeView1.Nodes.Clear();
                XmlDocument doc = new XmlDocument();
                doc.Load("db.xml");    //加载Xml文件  
                XmlElement rootElem = doc.DocumentElement;   //获取根节点  
                XmlNodeList personNodes = rootElem.GetElementsByTagName("Node"); //获取person子节点集合  
                foreach (XmlNode node in personNodes)
                {
                    //设置话术类型
                    string str_zu_txt = ((XmlElement)node).GetAttribute("htitle");   //获取text属性值  
                    TreeNode txt_zu = new TreeNode(str_zu_txt);
                    txt_zu.ForeColor = System.Drawing.Color.MidnightBlue;
                    txt_zu.BackColor = System.Drawing.Color.LightSteelBlue;
                    treeView1.Nodes.Add(txt_zu);
                    XmlNodeList Nodes_hua = ((XmlElement)node).GetElementsByTagName("hua");  //获取hua子XmlElement集合  

                    //设置话术
                    foreach (XmlNode hua_node in Nodes_hua)
                    {
                        //string strAge = subAgeNodes[0].InnerText;
                        string str_hua_txt = ((XmlElement)hua_node).GetAttribute("hcontext");
                        string str_hua_title = ((XmlElement)hua_node).GetAttribute("htitle");
                        TreeNode txt_hua;
                        if (!string.IsNullOrEmpty(str_hua_title))
                        {
                            txt_hua = new TreeNode("( " + str_hua_title + " )     " + str_hua_txt);
                        }
                        else
                        {
                            txt_hua = new TreeNode(str_hua_txt);
                        }
                        txt_hua.ForeColor = System.Drawing.Color.Gray;
                        //txt_hua.NodeFont.
                        txt_zu.Nodes.Add(txt_hua);
                    }
                }
            }
            catch { }
        }
        #endregion

        #region 窗体设置
        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Windows.Forms.Timer StopRectTimer = new System.Windows.Forms.Timer();
            StopRectTimer.Tick += new EventHandler(timer1_Tick);
            StopRectTimer.Interval = 100;//时间
            StopRectTimer.Enabled = true;
        }

        //internal AnchorStyles StopAanhor = AnchorStyles.None;
        internal AnchorStyles StopAanhor = AnchorStyles.None;
        /// <summary>
        /// 窗体根据每秒一刷新。来隐藏窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                //根据窗体位置隐藏
                if (this.Bounds.Contains(Cursor.Position))
                {
                    switch (this.StopAanhor)
                    {
                        case AnchorStyles.Top:
                            this.Location = new Point(this.Location.X, 0);
                            break;
                        case AnchorStyles.Left:
                            this.Location = new Point(0, this.Location.Y);
                            break;
                        case AnchorStyles.Right:
                            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y);
                            break;
                    }
                }
                else
                {
                    switch (this.StopAanhor)
                    {
                        case AnchorStyles.Top:
                            this.Location = new Point(this.Location.X, (this.Height - 2) * (-1));
                            break;
                        case AnchorStyles.Left:
                            this.Location = new Point((-1) * (this.Width - 2), this.Location.Y);
                            break;
                        case AnchorStyles.Right:
                            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 2, this.Location.Y);
                            break;
                    }
                }
            }


            if (clicktime != new DateTime())
            {
                if (clicktime.AddSeconds(15) < DateTime.Now)
                {
                    //treeView1.CollapseAll();
                    //tongbu();
                    //bind();
                    treeView1.CollapseAll();
                    clicktime = new DateTime();
                }
            }

        }
        /// <summary>
        /// 来判断位置的隐藏
        /// </summary>
        private void mStopAnthor()
        {
            if (this.Top <= 0)
            {
                StopAanhor = AnchorStyles.Top;
            }
            else if (this.Left <= 0)
            {
                StopAanhor = AnchorStyles.Left;
            }
            else if (this.Left >= Screen.PrimaryScreen.Bounds.Width - this.Width)
            {
                StopAanhor = AnchorStyles.Right;
            }
            else
            {
                StopAanhor = AnchorStyles.None;
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            this.mStopAnthor();
        }






        #endregion

        #region 话术点击复制
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            toolStripProgressBar1.Value = 1;
            try
            {
                string str = e.Node.Text;
                string _title = "";
                if (str.IndexOf(")") > -1)
                {
                    str = str.Replace(" ", "");
                    string[] strs = str.Split(new char[1] { ')' });
                    str = strs[1];
                    _title = strs[0].Replace("(", "");
                }
                //复制
                Clipboard.SetDataObject(str);

                //设置点击次数
                #region 点击同时连接数据库更新-时间长会有卡顿
                //if (Net.IsConnectedInternet())
                //{
                //    string hid_temp = XMLHelper.GetValue("htitle", _title, "hid");
                //    int hid = 0;
                //    if (int.TryParse(hid_temp, out hid))
                //    {
                //        huashu hs = BLL.huashuManager.SearchByID(hid);
                //        if (hs != null)
                //        {
                //            hs.hcount = hs.hcount + 1;
                //            BLL.huashuManager.Update(hs);
                //            if (hs.hfid > 0)
                //            {
                //                hs = BLL.huashuManager.SearchByID(hs.hfid);
                //                hs.hcount = hs.hcount + 1;
                //                BLL.huashuManager.Update(hs);
                //            }
                //        }
                //    }
                //}
                #endregion

                //设置自动收缩
                clicktime = DateTime.Now;







                //设置点击次数
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("db.xml");

                XmlNodeList nodeList = xmlDoc.SelectSingleNode("huashu").ChildNodes;//获取Employees节点的所有子节点

                foreach (XmlNode xn in nodeList)//遍历所有子节点 
                {
                    XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 
                    XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                    foreach (XmlNode xn1 in nls)//遍历 
                    {
                        XmlElement xe2 = (XmlElement)xn1;//转换类型 
                        if (xe2.GetAttribute("htitle") == _title)//如果找到 
                        {
                            string sort = xe2.GetAttribute("hcount");
                            int _sort = 0;
                            if (int.TryParse(sort, out _sort))
                            {
                                _sort++;
                                xe2.SetAttribute("hcount", _sort.ToString());//则修改话术点击次数
                            }
                            sort = xe.GetAttribute("hcount");
                            if (int.TryParse(sort, out _sort))
                            {
                                _sort++;
                                xe.SetAttribute("hcount", _sort.ToString());//则修改话术类型点击次数
                            }
                            break;
                        }
                    }
                }
                xmlDoc.Save("db.xml");//保存。


            }
            catch { }
            //粘贴
            #region 粘贴
            //IDataObject iData = Clipboard.GetDataObject();
            // Determines whether the data is in a format you can use.
            //if(iData.GetDataPresent(DataFormats.Text)) {
            // Yes it is, so display it in a text box.
            //textBox2.Text = (String)iData.GetData(DataFormats.Text); 
            #endregion
            toolStripProgressBar1.Value = 100;
        }
        #endregion

        #region 最小化

        /// <summary>
        /// 当窗体被停用时发生，隐藏窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Show();
            //this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Normal;
            //notifyIcon1.Visible = false;

        }
        #endregion

        #region 注册快捷键

        #region Form1_KeyDown

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //StringBuilder keyValue = new StringBuilder();
            //keyValue.Length = 0;
            //keyValue.Append("");
            //if (e.Modifiers != 0)
            //{
            //    if (e.Control)
            //        keyValue.Append("Ctrl + ");
            //    if (e.Alt)
            //        keyValue.Append("Alt + ");
            //    if (e.Shift)
            //        keyValue.Append("Shift + ");
            //}
            //if ((e.KeyValue >= 33 && e.KeyValue <= 40) ||
            //    (e.KeyValue >= 65 && e.KeyValue <= 90) ||   //a-z/A-Z
            //    (e.KeyValue >= 112 && e.KeyValue <= 123))   //F1-F12
            //{
            //    keyValue.Append(e.KeyCode);
            //}
            //else if ((e.KeyValue >= 48 && e.KeyValue <= 57))    //0-9
            //{
            //    keyValue.Append(e.KeyCode.ToString().Substring(1));
            //}
            //this.ActiveControl.Text = "";
            ////设置当前活动控件的文本内容
            //this.ActiveControl.Text = keyValue.ToString();
        }
        #endregion


        /// <summary>
        /// 注册快捷键
        /// </summary>
        void RegHotkey()
        {
            this.systemHotkey1.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.systemHotkey1.Pressed += new System.EventHandler(this.systemHotkey1_Pressed);
            //this.systemHotkey2.Shortcut = System.Windows.Forms.Shortcut.F2;
            //this.systemHotkey2.Pressed += new System.EventHandler(this.systemHotkey1_Pressed2);
        }

        /// <summary>
        /// 快捷键要执行的功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void systemHotkey1_Pressed(object sender, System.EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                //if (this.StopAanhor == AnchorStyles.Top || this.StopAanhor == AnchorStyles.Left || this.StopAanhor == AnchorStyles.Right)
                //{
                //    this.Show();//显示窗体
                //    this.WindowState = FormWindowState.Normal;//设置窗体原始大小
                //    this.StartPosition = FormStartPosition.CenterScreen;//位置居中
                //}
                //else
                //{
                //    this.WindowState = FormWindowState.Minimized;
                //}
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.Show();//显示窗体
                this.WindowState = FormWindowState.Normal;//设置窗体原始大小
                //this.Location = new Point(MousePosition.X, MousePosition.Y);//设置窗体的位置
            }

        }

        /// <summary>
        /// 快捷键要执行的功能2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void systemHotkey1_Pressed2(object sender, System.EventArgs e)
        {
            bind();
        }


        #endregion

        #region 同步数据

        #region convert_xml
        /// <summary>
        /// 从XML转换到huashu实例
        /// </summary>
        /// <param name="xn"></param>
        /// <returns></returns>
        huashu convert_xml(XmlNode xn)
        {
            huashu hs = new huashu();
            try
            {
                string hid = ((XmlElement)xn).GetAttribute("hid");   //获取title属性值  
                string hfid = ((XmlElement)xn).GetAttribute("hfid");   //获取title属性值  
                string htitle = ((XmlElement)xn).GetAttribute("htitle");   //获取title属性值  
                string hcontext = ((XmlElement)xn).GetAttribute("hcontext");   //获取title属性值  
                string hsort = ((XmlElement)xn).GetAttribute("hsort");   //获取title属性值  
                string hcount = ((XmlElement)xn).GetAttribute("hcount");   //获取title属性值  
                string hdate = ((XmlElement)xn).GetAttribute("hdate");   //获取title属性值  
                string hstate = ((XmlElement)xn).GetAttribute("hstate");   //获取title属性值  

                int _hid = 0;
                int _hfid = 0;
                int _hsort = 0;
                int _hcount = 0;
                DateTime _hdate = new DateTime();

                int.TryParse(hid, out _hid);
                int.TryParse(hfid, out _hfid);
                int.TryParse(hsort, out _hsort);
                int.TryParse(hcount, out _hcount);
                DateTime.TryParse(hdate, out _hdate);


                hs.hcontext = hcontext;
                hs.hcount = _hcount;
                hs.hdate = _hdate;
                hs.hfid = _hfid;
                hs.hid = _hid;
                hs.hsort = _hsort;
                hs.hstate = hstate;
                hs.htitle = htitle;
            }
            catch
            {
                Debug.WriteLine(xn.ToString());
            }
            return hs;

        }
        #endregion

        #region update
        /// <summary>
        /// 同步数据
        /// </summary>
        /// <param name="h"></param>
        void update(huashu h)
        {

            if (h.hid == 0)
            {
                if ((!string.IsNullOrEmpty(h.htitle)) && (!string.IsNullOrEmpty(h.hcontext)))
                {
                    BLL.huashuManager.Insert(h);
                }
            }
            else
            {
                if (h.hcount != 0)
                {
                    huashu hh = BLL.huashuManager.SearchByID(h.hid);
                    if (hh != null)
                    {

                        hh.hcount = hh.hcount + h.hcount;
                        BLL.huashuManager.Update(hh);
                    }
                }
            }
        }
        #endregion


        #region tongbu_data 暂无引用
        /// <summary>
        /// 没有任何引用
        /// </summary>
        /// <returns></returns>
        List<huashu> tongbu_data()
        {
            List<huashu> list = new List<huashu>();
            huashu hs = new huashu();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("db.xml");    //加载Xml文件  
                XmlElement rootElem = doc.DocumentElement;   //获取根节点  
                XmlNodeList personNodes = rootElem.GetElementsByTagName("Node"); //获取person子节点集合  
                foreach (XmlNode node in personNodes)
                {

                    hs = convert_xml(node);
                    update(hs);

                    //开始处理话术
                    XmlNodeList Nodes_hua = ((XmlElement)node).GetElementsByTagName("hua");  //获取hua子XmlElement集合  
                    foreach (XmlNode hua_node in Nodes_hua)
                    {
                        hs = convert_xml(hua_node);
                        list.Add(hs);
                    }
                }
                foreach (huashu h in list)
                {
                    update(h);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return list;
        }
        #endregion

        #region 话术XML文件转化为List类
        /// <summary>
        /// 话术XML文件转化为List类
        /// </summary>
        /// <returns></returns>
        List<huashu> XmlToListHuaShu()
        {
            List<huashu> list = new List<huashu>();
            try
            {

                huashu hs = new huashu();

                XmlDocument doc = new XmlDocument();
                doc.Load("db.xml");    //加载Xml文件  
                XmlElement rootElem = doc.DocumentElement;   //获取根节点  
                XmlNodeList personNodes = rootElem.GetElementsByTagName("Node"); //获取person子节点集合  
                foreach (XmlNode node in personNodes)
                {

                    hs = convert_xml(node);
                    update(hs);

                    //开始处理话术
                    XmlNodeList Nodes_hua = ((XmlElement)node).GetElementsByTagName("hua");  //获取hua子XmlElement集合  
                    foreach (XmlNode hua_node in Nodes_hua)
                    {
                        hs = convert_xml(hua_node);
                        list.Add(hs);
                    }
                }
            }
            catch { }
            return list;

        }
        #endregion


        #region tongbu
        public void tongbu()
        {
            try
            {
                toolStripProgressBar1.Maximum = 100;
                IList<huashu> ilist1 = BLL.huashuManager.SearchAll("1");
                //判断是否可以连接到数据库
                if (ilist1.Count > 1)
                {
                    toolStripProgressBar1.Value = 5;

                    //huashu hs = new huashu();
                    try
                    {
                        List<huashu> list = XmlToListHuaShu();

                        //本地数据获取完毕
                        toolStripProgressBar1.Value = 25;

                        //本地数据更新到网络数据库
                        foreach (huashu h in list)
                        {
                            update(h);
                        }
                        //tongbu_data();
                        //本地数据更新完毕


                        //删除本地数据
                        XmlDocument xmlDoc = new XmlDocument();
                        xmlDoc.Load("db.xml");
                        XmlNode root = xmlDoc.SelectSingleNode("huashu");
                        root.RemoveAll();
                        //xmlDoc.Save("db.xml");
                        //xmlDoc.Save("db.xml");
                        //删除本地数据
                        toolStripProgressBar1.Value = 50;

                        //下载网络数据
                        //IList<huashu> ilist1 = BLL.huashuManager.SearchAll("1");
                        foreach (huashu _hs1 in ilist1)
                        {
                            XmlElement xe1 = xmlDoc.CreateElement("Node");//创建一个<Node>节点 
                            xe1.SetAttribute("htitle", _hs1.htitle);//设置该节点htitle属性 
                            xe1.SetAttribute("hid", _hs1.hid.ToString());//设置该节点hid属性 
                            xe1.SetAttribute("hfid", "0");//设置该节点hfid属性
                            xe1.SetAttribute("hsort", _hs1.hsort.ToString());//设置该节点hsort属性 
                            xe1.SetAttribute("hcount", "0");//设置该节点hcount属性
                            xe1.SetAttribute("hdate", _hs1.hdate.ToString());//设置该节点hdate属性 
                            xe1.SetAttribute("hstate", _hs1.hstate);//设置该节点hstate属性
                            xe1.SetAttribute("hcontext", _hs1.hcontext);//设置该节点hcontext属性

                            IList<huashu> ilist2 = BLL.huashuManager.Search(0, 100, "", "1", _hs1.hid.ToString(), new DateTime(), new DateTime());
                            foreach (huashu _hs2 in ilist2)
                            {
                                XmlElement xe2 = xmlDoc.CreateElement("hua");//创建一个<Node>节点 
                                xe2.SetAttribute("htitle", _hs2.htitle);//设置该节点htitle属性 
                                xe2.SetAttribute("hid", _hs2.hid.ToString());//设置该节点hid属性 
                                xe2.SetAttribute("hfid", _hs2.hfid.ToString());//设置该节点hfid属性
                                xe2.SetAttribute("hsort", _hs2.hsort.ToString());//设置该节点hsort属性 
                                xe2.SetAttribute("hcount", "0");//设置该节点hcount属性
                                xe2.SetAttribute("hdate", _hs2.hdate.ToString());//设置该节点hdate属性 
                                xe2.SetAttribute("hstate", _hs2.hstate);//设置该节点hstate属性
                                xe2.SetAttribute("hcontext", _hs2.hcontext);//设置该节点hcontext属性
                                xe1.AppendChild(xe2);
                            }
                            root.AppendChild(xe1);
                        }
                        xmlDoc.Save("db.xml");
                        toolStripProgressBar1.Value = 75;
                        bind();
                    }
                    catch { }
                    toolStripProgressBar1.Value = 100;

                }
            }
            catch { }
        }
        #endregion

        #endregion

        #region 菜单功能显示

        /// <summary>
        /// 同步数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            tongbu();
            bind();
        }




        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        private void 话术ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = false;
            pan_huashu.Visible = true;
        }

        private void 好评ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = " http://www.testtest.link/oa/fanxian_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 售后ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = " http://www.testtest.link/oa/sh_problem_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 退货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = " http://www.testtest.link/oa/return_goods_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }



        #region  右键功能


        private void 添加话术ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            huashu_add hs = new huashu_add();
            hs.StartPosition = FormStartPosition.CenterScreen;
            hs.Show();
        }

        private void 全部收起ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //bind();
            treeView1.CollapseAll();
        }

        private void 修改话术ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            huashu_add hs = new huashu_add();
            hs.StartPosition = FormStartPosition.CenterScreen;
            hs.Hid = huashu_hid;
            hs.bind();
            hs.Show();
        }
        //右键获得TreeView的项
        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {


            修改话术ToolStripMenuItem.Visible = false;
            TreeView treev = sender as TreeView;
            Point point = treev.PointToClient(Cursor.Position);
            TreeViewHitTestInfo info = treev.HitTest(point.X, point.Y);
            TreeNode node = info.Node;//获得 右键点击的节点
            if (node != null && MouseButtons.Right == e.Button)
            {
                treev.SelectedNode = node;//关键的一句话，右键点击菜单的时候，会选中右键点击的项


                try
                {
                    string str = node.Text;
                    if (str.IndexOf(")") > -1)
                    {
                        str = str.Replace(" ", "");
                        string[] strs = str.Split(new char[1] { ')' });
                        str = strs[1];
                    }
                    Clipboard.SetDataObject(str);//复制

                    //设置点击次数
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load("db.xml");

                    XmlNodeList nodeList = xmlDoc.SelectSingleNode("huashu").ChildNodes;//获取Employees节点的所有子节点

                    foreach (XmlNode xn in nodeList)//遍历所有子节点 
                    {
                        XmlElement xe = (XmlElement)xn;//将子节点类型转换为XmlElement类型 
                        XmlNodeList nls = xe.ChildNodes;//继续获取xe子节点的所有子节点 
                        foreach (XmlNode xn1 in nls)//遍历 
                        {
                            XmlElement xe2 = (XmlElement)xn1;//转换类型 
                            if (xe2.GetAttribute("hcontext") == str)//如果找到 
                            {
                                string sort = xe2.GetAttribute("hcount");
                                int _sort = 0;
                                if (int.TryParse(sort, out _sort))
                                {
                                    _sort++;
                                    xe2.SetAttribute("hcount", _sort.ToString());//则修改
                                }
                                //设置修改窗体的属性值
                                string hid = xe2.GetAttribute("hid");
                                int _hid = 0;
                                if (int.TryParse(hid, out _hid))
                                {
                                    huashu_hid = _hid;
                                    修改话术ToolStripMenuItem.Visible = true;
                                }
                            }
                        }
                    }
                    xmlDoc.Save("db.xml");//保存。
                }
                catch { }

            }
        }

        #endregion

        private void 添加话术ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = " http://www.testtest.link/oa/huashu_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 添加话术类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/huashu_type_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;

        }

        private void 话术列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/huashu_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 话术类型列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/huashu_type_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 待处理返现ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.testtest.link/oa/fanxian_list.aspx?state=1");
        }

        private void 全部返现ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/fanxian_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 退货列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/return_goods_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 全部售后列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/sh_problem_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 待处理售后ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/sh_problem_list.aspx?state=1";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/pages_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 资料列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/pages_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 添加资料类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/pages_type_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 资料类型列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/pages_type_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 淘宝蘑菇街ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/sd_add_import.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 系统蘑菇街ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/sd_add_dynamic.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 蘑菇街空包网ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/sd_add_convert.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 转换自定义格式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/sd_add_convert2.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 刷单账号列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/sd_account_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 添加刷单账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/sd_account_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 评语列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/sd_pingjia_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 添加评语ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/sd_pingjia_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 姓名列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/sd_name_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 添加姓名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/sd_name_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 地址库列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/sd_address_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 下载记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/sd_record_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 添加店铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/dianpu_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 店铺列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/dianpu_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 添加快递ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            string url = "http://www.testtest.link/oa/courier_add.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 快递列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pan_web.Visible = true;
            pan_huashu.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            string url = "http://www.testtest.link/oa/courier_list.aspx";
            Uri urli = new Uri(url);
            webBrowser1.Url = urli;
        }

        private void 补单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region 关闭程序
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            System.Environment.Exit(0);
        }
        #endregion

        #region 收起
        private void 收起ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1.CollapseAll();
        }
        #endregion

        #region 处理返现ToolStripMenuItem_Click
        private void 处理返现ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fanxian_From fx = new fanxian_From();
            fx.Show();
        }
        #endregion
    }
}

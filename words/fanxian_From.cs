using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Xml;
using Entity;

namespace words
{
    public partial class fanxian_From : Form
    {
        public fanxian_From()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//位置居中
            this.TopMost = true;
            bind();
        }


        const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        //不包含任务栏的屏幕尺寸
        int ping_width = System.Windows.Forms.SystemInformation.WorkingArea.Width;
        int ping_height = System.Windows.Forms.SystemInformation.WorkingArea.Height;

        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        //Windows提供了一个模拟键盘API函数Keybd_event（）
        [System.Runtime.InteropServices.DllImport("user32")]
        private static extern void keybd_event(
             byte bVk, //虚拟键值
             byte bScan,// 一般为0
             int dwFlags, //这里是整数类型 0 为按下，2为释放
             int dwExtraInfo //这里是整数类型 一般情况下设成为 0
                );


        #region 测试
        private void button1_Click(object sender, EventArgs e)
        {
            //Rectangle rect = System.Windows.Forms.SystemInformation.
            //int w = rect.Width;
            //MessageBox.Show(w.ToString());
            //mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, p.X, p.Y, 0, 0);//鼠标移动
            //mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);//鼠标右击
            //mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_MOVE, 6000, 5000, 0, 0);//鼠标移动指定
            //mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
            //mouse_event(MOUSEEVENTF_LEFTDOWN, 5000 * 65536 / 1024, 500 * 65536 / 768, 0, 0);
            //mouse_event(MOUSEEVENTF_LEFTUP, 5000 * 65536 / 1024, 500 * 65536 / 768, 0, 0); 

            //Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);//屏幕居中坐标

            //开始系统后台点击待处理返现
            Point p = new Point(737, 277);
            //Cursor.Position = p;//设置鼠标位置方法1
            //mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
            //移动鼠标到收款人信息
            p = new Point(930, 525);
            Cursor.Position = p;//设置鼠标位置方法1
            //双击收款人信息
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击

            keybd_event(17, 0, 0, 0);
            keybd_event(67, 0, 0, 0);
            keybd_event(17, 0, 2, 0);
            keybd_event(67, 0, 2, 0);

            //延迟1秒，因为系统有延迟
            Thread.Sleep(1 * 1000);
            //判断剪贴板中是否有文字
            if (System.Windows.Forms.Clipboard.ContainsText())
            {
                string mess = System.Windows.Forms.Clipboard.GetText();

                //如果没有文字
                if (string.IsNullOrEmpty(mess))
                {
                    p = new Point(870, 730);
                    Cursor.Position = p;//设置鼠标位置方法1
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
                    //延迟1秒，因为系统有延迟
                    Thread.Sleep(1 * 1000);
                    //确认转账信息页面,选择付款终端
                    p = new Point(880, 710);
                    Cursor.Position = p;//设置鼠标位置方法1
                    //选择电脑付款
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
                    //延迟0.5秒，因为系统有延迟
                    Thread.Sleep(1000 / 2);
                    //确认转账信息页面,移动到确认信息并付款按钮
                    p = new Point(850, 890);
                    Cursor.Position = p;//设置鼠标位置方法1
                    //点击确认信息并付款按钮
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
                    //延迟3秒，因为系统有延迟
                    Thread.Sleep(3 * 1000);
                    //付款页面,移动支付宝支付密码输入框
                    p = new Point(590, 520);
                    Cursor.Position = p;//设置鼠标位置方法1
                    //点击支付宝支付密码输入框
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
                    //输入
                    //zhang
                    keybd_event(90, 0, 0, 0);
                    keybd_event(90, 0, 2, 0);

                    keybd_event(72, 0, 0, 0);
                    keybd_event(72, 0, 2, 0);

                    keybd_event(65, 0, 0, 0);
                    keybd_event(65, 0, 2, 0);

                    keybd_event(78, 0, 0, 0);
                    keybd_event(78, 0, 2, 0);

                    keybd_event(71, 0, 0, 0);
                    keybd_event(71, 0, 2, 0);

                    //jia
                    keybd_event(74, 0, 0, 0);
                    keybd_event(74, 0, 2, 0);

                    keybd_event(73, 0, 0, 0);
                    keybd_event(73, 0, 2, 0);

                    keybd_event(65, 0, 0, 0);
                    keybd_event(65, 0, 2, 0);

                    //zhe
                    keybd_event(90, 0, 0, 0);
                    keybd_event(90, 0, 2, 0);

                    keybd_event(72, 0, 0, 0);
                    keybd_event(72, 0, 2, 0);

                    keybd_event(69, 0, 0, 0);
                    keybd_event(69, 0, 2, 0);


                }
                else
                {
                    //如果有文字
                    MessageBox.Show(mess);
                }
            }

        }




        #region 鼠标移动方法
        /// <summary>        
        /// 引用user32.dll动态链接库（windows api），        
        /// 使用库中定义 API：SetCursorPos         
        /// </summary>        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);
        /// <summary>        
        /// 移动鼠标到指定的坐标点        
        /// </summary>        
        public void MoveMouseToPoint(Point p)
        {
            SetCursorPos(p.X, p.Y);
        }
        /// <summary>        
        /// 设置鼠标的移动范围        
        /// </summary>        
        public void SetMouseRectangle(Rectangle rectangle)
        {
            System.Windows.Forms.Cursor.Clip = rectangle;
        }
        /// <summary>        
        /// 设置鼠标位于屏幕中心        
        /// </summary>        
        public void SetMouseAtCenterScreen()
        {
            int winHeight = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
            int winWidth = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
            Point centerP = new Point(winWidth / 2, winHeight / 2);
            MoveMouseToPoint(centerP);
        }
        #endregion



        private void button2_Click(object sender, EventArgs e)
        {
            //开始系统后台点击待处理返现
            Point p = new Point(737, 277);
            Cursor.Position = p;//设置鼠标位置方法1
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
        }


        /// <summary>
        /// 点击下一步
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_no2_1_Click(object sender, EventArgs e)
        {
            Point p = new Point(870, 730);
            Cursor.Position = p;//设置鼠标位置方法1
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
        }

        private void btn_no3_Click(object sender, EventArgs e)
        {
            //延迟1秒，因为系统有延迟
            Thread.Sleep(1 * 1000);
            //确认转账信息页面,选择付款终端
            Point p = new Point(880, 710);
            Cursor.Position = p;//设置鼠标位置方法1
            //选择电脑付款
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
            //延迟0.5秒，因为系统有延迟
            Thread.Sleep(1000 / 2);
            //确认转账信息页面,移动到确认信息并付款按钮
            p = new Point(850, 890);
            Cursor.Position = p;//设置鼠标位置方法1
            //点击确认信息并付款按钮
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
        }

        private void btn_no4_Click(object sender, EventArgs e)
        {
            //付款页面,移动支付宝支付密码输入框
            Point p = new Point(590, 520);
            Cursor.Position = p;//设置鼠标位置方法1
            //点击支付宝支付密码输入框
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
            //输入
            //zhang
            keybd_event(90, 0, 0, 0);
            keybd_event(90, 0, 2, 0);

            keybd_event(72, 0, 0, 0);
            keybd_event(72, 0, 2, 0);

            keybd_event(65, 0, 0, 0);
            keybd_event(65, 0, 2, 0);

            keybd_event(78, 0, 0, 0);
            keybd_event(78, 0, 2, 0);

            keybd_event(71, 0, 0, 0);
            keybd_event(71, 0, 2, 0);

            //jia
            keybd_event(74, 0, 0, 0);
            keybd_event(74, 0, 2, 0);

            keybd_event(73, 0, 0, 0);
            keybd_event(73, 0, 2, 0);

            keybd_event(65, 0, 0, 0);
            keybd_event(65, 0, 2, 0);

            //zhe
            keybd_event(90, 0, 0, 0);
            keybd_event(90, 0, 2, 0);

            keybd_event(72, 0, 0, 0);
            keybd_event(72, 0, 2, 0);

            keybd_event(69, 0, 0, 0);
            keybd_event(69, 0, 2, 0);

            //延迟1秒，因为系统有延迟
            Thread.Sleep(1000 / 2);
            //移动到确认付款
            p = new Point(555, 590);
            Cursor.Position = p;//设置鼠标位置方法1
            //点击付款
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击

        }

        private void btn_no5_Click(object sender, EventArgs e)
        {
            //移动到确认付款
            Point p = new Point(310, 100);
            Cursor.Position = p;//设置鼠标位置方法1
            //点击付款
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Point p = new Point(1580, 35);
            Cursor.Position = p;//设置鼠标位置方法1
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
            //输入
            //zhang
            keybd_event(90, 0, 0, 0);
            keybd_event(90, 0, 2, 0);

            keybd_event(72, 0, 0, 0);
            keybd_event(72, 0, 2, 0);

            keybd_event(65, 0, 0, 0);
            keybd_event(65, 0, 2, 0);

            keybd_event(78, 0, 0, 0);
            keybd_event(78, 0, 2, 0);

            keybd_event(71, 0, 0, 0);
            keybd_event(71, 0, 2, 0);

            //jia
            keybd_event(74, 0, 0, 0);
            keybd_event(74, 0, 2, 0);

            keybd_event(73, 0, 0, 0);
            keybd_event(73, 0, 2, 0);

            keybd_event(65, 0, 0, 0);
            keybd_event(65, 0, 2, 0);

            //zhe
            keybd_event(90, 0, 0, 0);
            keybd_event(90, 0, 2, 0);

            keybd_event(72, 0, 0, 0);
            keybd_event(72, 0, 2, 0);

            keybd_event(69, 0, 0, 0);
            keybd_event(69, 0, 2, 0);
        }

        #endregion




        #region 声明


        #endregion









        //第一步:打开到付款
        private void button3_Click(object sender, EventArgs e)
        {

            try
            {

                /// <summary>
                /// 自制系统-待处理返现-X坐标
                /// </summary>
                int point_os_x = int.Parse(txt_config_os_x.Text.Trim());
                /// <summary>
                /// 自制系统-待处理返现-Y坐标
                /// </summary>
                int point_os_y = int.Parse(txt_config_os_y.Text.Trim());
                /// <summary>
                /// 系统点击后延迟时间
                /// </summary>
                int sleep_os = int.Parse(txt_config_os_time.Text.Trim());

                /// <summary>
                /// 支付宝-输入打款账号信息-X坐标
                /// </summary>
                int point_account_info_x = int.Parse(txt_config_account_info_x.Text.Trim());
                /// <summary>
                /// 支付宝-输入打款账号信息-Y坐标
                /// </summary>
                int point_account_info_y = int.Parse(txt_config_account_info_y.Text.Trim());
                /// <summary>
                /// 输入打款账号核实信息延迟时间
                /// </summary>
                int sleep_account_info = int.Parse(txt_config_account_info_time.Text.Trim());
                //可以返现文案
                string txt_account_info_ok1 = txt_config_account_info_ok1.Text.Trim();
                string txt_account_info_ok2 = txt_config_account_info_ok2.Text.Trim();
                /// <summary>
                /// 支付宝-输入打款账号-X坐标
                /// </summary>
                int point_account_x = int.Parse(txt_config_account_x.Text.Trim());
                /// <summary>
                /// 支付宝-输入打款账号-Y坐标
                /// </summary>
                int point_account_y = int.Parse(txt_config_account_y.Text.Trim());
                /// <summary>
                /// 输入打款账号后延迟时间
                /// </summary>
                int sleep_account = int.Parse(txt_config_account_time.Text.Trim());

                /// <summary>
                /// 支付宝-确认账号信息页面选择电脑付款-X坐标
                /// </summary>
                int point_confirm_pc_x = int.Parse(txt_config_pc_x.Text.Trim());
                /// <summary>
                /// 支付宝-确认账号信息页面选择电脑付款-Y坐标
                /// </summary>
                int point_confirm_pc_y = int.Parse(txt_config_pc_y.Text.Trim());
                /// <summary>
                /// 确认账号信息页面选择电脑付款后延迟时间
                /// </summary>
                int sleep_confirm_pc = int.Parse(txt_config_pc_time.Text.Trim());

                /// <summary>
                /// 支付宝-确认账号信息页面 确定-X坐标
                /// </summary>
                int point_confirm_x = int.Parse(txt_config_confirm_x.Text.Trim());
                /// <summary>
                /// 支付宝-确认账号信息页面 确定-Y坐标
                /// </summary>
                int point_confirm_y = int.Parse(txt_config_confirm_y.Text.Trim()); ;
                /// <summary>
                /// 确认账号信息页面 确定后延迟时间
                /// </summary>
                int sleep_confirm = int.Parse(txt_config_confirm_time.Text.Trim()); ;

                /// <summary>
                /// 支付宝-确认账号信息页面 确定-X坐标
                /// </summary>
                int point_pwd_x = int.Parse(txt_config_pwd_x.Text.Trim());
                /// <summary>
                /// 支付宝-确认账号信息页面 确定-Y坐标
                /// </summary>
                int point_pwd_y = int.Parse(txt_config_pwd_y.Text.Trim());

                /// <summary>
                /// 软件半自动化第一步-X坐标(软件左上角距离按钮)
                /// </summary>
                int point_banzidonghua2_x = int.Parse(txt_config_btn2_x.Text.Trim());
                /// <summary>
                /// 软件半自动化第一步-X坐标(软件左上角距离按钮)
                /// </summary>
                int point_banzidonghua2_y = int.Parse(txt_config_btn2_y.Text.Trim());




                //开始系统后台点击待处理返现
                Point p = new Point(point_os_x, point_os_y);
                Cursor.Position = p;//设置鼠标位置方法1
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
                Thread.Sleep(sleep_os);


                //支付宝账号确认页面
                p = new Point(point_account_info_x, point_account_info_y);
                Cursor.Position = p;//设置鼠标位置-账号信息
                //延迟1秒，因为系统有延迟
                Thread.Sleep(sleep_account_info);
                //核实账号是否可打款
                //双击收款人信息
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
                //复制Ctrl+c
                keybd_event(17, 0, 0, 0);
                keybd_event(67, 0, 0, 0);
                keybd_event(17, 0, 2, 0);
                keybd_event(67, 0, 2, 0);


                //判断剪贴板中是否有文字
                if (System.Windows.Forms.Clipboard.ContainsText())
                {
                    string mess = System.Windows.Forms.Clipboard.GetText();
                    if (!string.IsNullOrEmpty(mess))
                    {
                        if (mess.IndexOf(txt_account_info_ok1) == -1 && mess.IndexOf(txt_account_info_ok2) == -1)
                        {
                            //List<string> list = new List<string>();
                            //if (!string.IsNullOrEmpty(txt_account_info_ok1))
                            //{
                            //    list.Add(txt_account_info_ok1);
                            //}
                            //if (!string.IsNullOrEmpty(txt_account_info_ok2))
                            //{
                            //    list.Add(txt_account_info_ok2);
                            //}
                            //foreach (string s in list)
                            //{
                            //    if (mess.IndexOf(s) == -1)
                            //    {
                            //fanxian fx = BLL.fanxianManager.SearchLast_FanxianDate();
                            //fx.fx_state = "3";
                            //fx.fx_remark = mess;
                            //if (BLL.fanxianManager.Update(fx) == 1)
                            //{
                            //    MessageBox.Show("买家账号: " + fx.fx_account + " ;返现失败原因: " + mess + " ;已经标记问题返现!");
                            //}
                            MessageBox.Show("返现失败原因: " + mess + " ");
                            return;
                            //    }
                            //}
                        }
                    }
                }

                p = new Point(point_account_x, point_account_y);
                Cursor.Position = p;//设置鼠标位置方法1
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击


                //延迟1秒，因为系统有延迟
                Thread.Sleep(sleep_account);
                //确认转账信息页面,选择付款终端
                p = new Point(point_confirm_pc_x, point_confirm_pc_y);
                Cursor.Position = p;//设置鼠标位置方法1
                //选择电脑付款
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
                //延迟0.5秒，因为系统有延迟
                Thread.Sleep(sleep_confirm_pc);
                //确认转账信息页面,移动到确认信息并付款按钮
                p = new Point(point_confirm_x, point_confirm_y);
                Cursor.Position = p;//设置鼠标位置方法1
                //点击确认信息并付款按钮
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击


                Thread.Sleep(sleep_confirm);
                //付款页面,移动支付宝支付密码输入框
                p = new Point(point_pwd_x, point_pwd_y);
                Cursor.Position = p;//设置鼠标位置方法1
                //点击支付宝支付密码输入框
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击


                //输入密码的时间
                //Thread.Sleep(1000 * 5);

                p = new Point(this.Location.X + point_banzidonghua2_x, this.Location.Y + point_banzidonghua2_y);
                Cursor.Position = p;
            }
            catch { }
        }

        //第二步:关闭页面重新开始
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                /// <summary>
                /// 软件半自动化第二步-X坐标(软件左上角距离按钮)
                /// </summary>
                int point_banzidonghua1_x = int.Parse(txt_config_btn1_x.Text.Trim());
                /// <summary>
                /// 软件半自动化第二步-X坐标(软件左上角距离按钮)
                /// </summary>
                int point_banzidonghua1_y = int.Parse(txt_config_btn1_y.Text.Trim());


                //移动关闭浏览器页面
                Point p = new Point(310, 100);
                Cursor.Position = p;//设置鼠标位置方法1
                //点击关闭
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击

                //button3_Click(sender, e);
                p = new Point(this.Location.X + point_banzidonghua1_x, this.Location.Y + point_banzidonghua1_y);
                Cursor.Position = p;
            }
            catch { }

        }

        private void fanxian_From_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void btn_config_save_Click(object sender, EventArgs e)
        {
            try
            {
                string point_os_x = txt_config_os_x.Text.Trim();
                string point_os_y = txt_config_os_y.Text.Trim();
                string sleep_os = txt_config_os_time.Text.Trim();
                string point_account_x = txt_config_account_x.Text.Trim();
                string point_account_y = txt_config_account_y.Text.Trim();
                string point_account_info_x = txt_config_account_info_x.Text.Trim();
                string point_account_info_y = txt_config_account_info_y.Text.Trim();
                string sleep_account_info = txt_config_account_info_time.Text.Trim();
                string txt_account_info_ok1 = txt_config_account_info_ok1.Text.Trim();
                string txt_account_info_ok2 = txt_config_account_info_ok2.Text.Trim();
                string sleep_account = txt_config_account_time.Text.Trim();
                string point_confirm_pc_x = txt_config_pc_x.Text.Trim();
                string point_confirm_pc_y = txt_config_pc_y.Text.Trim();
                string sleep_confirm_pc = txt_config_pc_time.Text.Trim();
                string point_confirm_x = txt_config_confirm_x.Text.Trim();
                string point_confirm_y = txt_config_confirm_y.Text.Trim();
                string sleep_confirm = txt_config_confirm_time.Text.Trim();
                string point_pwd_x = txt_config_pwd_x.Text.Trim();
                string point_pwd_y = txt_config_pwd_y.Text.Trim();
                string point_banzidonghua1_x = txt_config_btn1_x.Text.Trim();
                string point_banzidonghua1_y = txt_config_btn1_y.Text.Trim();
                string point_banzidonghua2_x = txt_config_btn2_x.Text.Trim();
                string point_banzidonghua2_y = txt_config_btn2_y.Text.Trim();

                XmlDocument doc = new XmlDocument();
                doc.Load("config.xml");
                XmlElement rootElem = doc.DocumentElement;   //获取根节点  
                XmlNodeList personNodes = rootElem.GetElementsByTagName("sit"); //获取person子节点集合  

                foreach (XmlNode node in personNodes)
                {
                    string str_id = ((XmlElement)node).GetAttribute("id");
                    if (str_id == "point_os_x")
                    {
                        ((XmlElement)node).SetAttribute("value", point_os_x);
                    }
                    else if (str_id == "point_os_y")
                    {
                        ((XmlElement)node).SetAttribute("value", point_os_y);
                    }
                    else if (str_id == "sleep_os")
                    {
                        ((XmlElement)node).SetAttribute("value", sleep_os);
                    }
                    else if (str_id == "point_account_info_x")
                    {
                        ((XmlElement)node).SetAttribute("value", point_account_info_x);
                    }
                    else if (str_id == "point_account_info_y")
                    {
                        ((XmlElement)node).SetAttribute("value", point_account_info_y);
                    }
                    else if (str_id == "sleep_account_info")
                    {
                        ((XmlElement)node).SetAttribute("value", sleep_account_info);
                    }
                    else if (str_id == "txt_account_info_ok1")
                    {
                        ((XmlElement)node).SetAttribute("value", txt_account_info_ok1);
                    }
                    else if (str_id == "txt_account_info_ok2")
                    {
                        ((XmlElement)node).SetAttribute("value", txt_account_info_ok2);
                    }
                    else if (str_id == "point_account_x")
                    {
                        ((XmlElement)node).SetAttribute("value", point_account_x);
                    }
                    else if (str_id == "point_account_y")
                    {
                        ((XmlElement)node).SetAttribute("value", point_account_y);
                    }
                    else if (str_id == "sleep_account")
                    {
                        ((XmlElement)node).SetAttribute("value", sleep_account);
                    }
                    else if (str_id == "point_confirm_pc_x")
                    {
                        ((XmlElement)node).SetAttribute("value", point_confirm_pc_x);
                    }
                    else if (str_id == "point_confirm_pc_y")
                    {
                        ((XmlElement)node).SetAttribute("value", point_confirm_pc_y);
                    }
                    else if (str_id == "sleep_confirm_pc")
                    {
                        ((XmlElement)node).SetAttribute("value", sleep_confirm_pc);
                    }
                    else if (str_id == "point_confirm_x")
                    {
                        ((XmlElement)node).SetAttribute("value", point_confirm_x);
                    }
                    else if (str_id == "point_confirm_y")
                    {
                        ((XmlElement)node).SetAttribute("value", point_confirm_y);
                    }
                    else if (str_id == "sleep_confirm")
                    {
                        ((XmlElement)node).SetAttribute("value", sleep_confirm);
                    }
                    else if (str_id == "point_pwd_x")
                    {
                        ((XmlElement)node).SetAttribute("value", point_pwd_x);
                    }
                    else if (str_id == "point_pwd_y")
                    {
                        ((XmlElement)node).SetAttribute("value", point_pwd_y);
                    }
                    else if (str_id == "point_banzidonghua1_x")
                    {
                        ((XmlElement)node).SetAttribute("value", point_banzidonghua1_x);
                    }
                    else if (str_id == "point_banzidonghua1_y")
                    {
                        ((XmlElement)node).SetAttribute("value", point_banzidonghua1_y);
                    }
                    else if (str_id == "point_banzidonghua2_x")
                    {
                        ((XmlElement)node).SetAttribute("value", point_banzidonghua2_x);
                    }
                    else if (str_id == "point_banzidonghua2_y")
                    {
                        ((XmlElement)node).SetAttribute("value", point_banzidonghua2_y);
                    }

                }
                doc.Save("config.xml");
                MessageBox.Show("保存成功");
            }
            catch { MessageBox.Show("保存失败"); }
        }


        void bind()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("config.xml");    //加载Xml文件  
                XmlElement rootElem = doc.DocumentElement;   //获取根节点  
                XmlNodeList personNodes = rootElem.GetElementsByTagName("sit"); //获取person子节点集合  
                foreach (XmlNode node in personNodes)
                {

                    string str_id = ((XmlElement)node).GetAttribute("id");
                    string str_value = ((XmlElement)node).GetAttribute("value");

                    if (str_id == "point_os_x")
                    {
                        txt_config_os_x.Text = str_value;
                    }
                    else if (str_id == "point_os_y")
                    {
                        txt_config_os_y.Text = str_value;
                    }
                    else if (str_id == "sleep_os")
                    {
                        txt_config_os_time.Text = str_value;
                    }
                    else if (str_id == "point_account_info_x")
                    {
                        txt_config_account_info_x.Text = str_value;
                    }
                    else if (str_id == "point_account_info_y")
                    {
                        txt_config_account_info_y.Text = str_value;
                    }
                    else if (str_id == "sleep_account_info")
                    {
                        txt_config_account_info_time.Text = str_value;
                    }
                    else if (str_id == "txt_account_info_ok1")
                    {
                        txt_config_account_info_ok1.Text = str_value;
                    }
                    else if (str_id == "txt_account_info_ok2")
                    {
                        txt_config_account_info_ok2.Text = str_value;
                    }
                    else if (str_id == "point_account_x")
                    {
                        txt_config_account_x.Text = str_value;
                    }
                    else if (str_id == "point_account_y")
                    {
                        txt_config_account_y.Text = str_value;
                    }
                    else if (str_id == "sleep_account")
                    {
                        txt_config_account_time.Text = str_value;
                    }
                    else if (str_id == "point_confirm_pc_x")
                    {
                        txt_config_pc_x.Text = str_value;
                    }
                    else if (str_id == "point_confirm_pc_y")
                    {
                        txt_config_pc_y.Text = str_value;
                    }
                    else if (str_id == "sleep_confirm_pc")
                    {
                        txt_config_pc_time.Text = str_value;
                    }
                    else if (str_id == "point_confirm_x")
                    {
                        txt_config_confirm_x.Text = str_value;
                    }
                    else if (str_id == "point_confirm_y")
                    {
                        txt_config_confirm_y.Text = str_value;
                    }
                    else if (str_id == "sleep_confirm")
                    {
                        txt_config_confirm_time.Text = str_value;
                    }
                    else if (str_id == "point_pwd_x")
                    {
                        txt_config_pwd_x.Text = str_value;
                    }
                    else if (str_id == "point_pwd_y")
                    {
                        txt_config_pwd_y.Text = str_value;
                    }
                    else if (str_id == "point_banzidonghua1_x")
                    {
                        txt_config_btn1_x.Text = str_value;
                    }
                    else if (str_id == "point_banzidonghua1_y")
                    {
                        txt_config_btn1_y.Text = str_value;
                    }
                    else if (str_id == "point_banzidonghua2_x")
                    {
                        txt_config_btn2_x.Text = str_value;
                    }
                    else if (str_id == "point_banzidonghua2_y")
                    {
                        txt_config_btn2_y.Text = str_value;
                    }
                }
            }
            catch { }
        }


    }
}

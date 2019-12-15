using System;
using System.Collections.Generic;

using System.Text;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Common;

namespace Common
{
    public class Auto
    {

        #region 控制鼠标键盘



        /// <summary>
        /// 移动鼠标
        /// </summary>
        public const int MOUSEEVENTF_MOVE = 0x0001;      //移动鼠标 
        /// <summary>
        /// 模拟鼠标左键按下
        /// </summary>
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002; //模拟鼠标左键按下 
        /// <summary>
        /// 模拟鼠标左键抬起
        /// </summary>
        public const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起 
        /// <summary>
        /// 模拟鼠标右键按下
        /// </summary>
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下
        /// <summary>
        /// 模拟鼠标右键抬起
        /// </summary>
        public const int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        /// <summary>
        /// 模拟鼠标中键按下
        /// </summary>
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        /// <summary>
        /// 模拟鼠标中键抬起
        /// </summary>
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起 
        /// <summary>
        /// 标示是否采用绝对坐标
        /// </summary>
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        //不包含任务栏的屏幕尺寸
        /// <summary>
        /// 不包含任务栏的屏幕尺寸宽度
        /// </summary>
        public static int ping_width = System.Windows.Forms.SystemInformation.WorkingArea.Width;
        /// <summary>
        /// 不包含任务栏的屏幕尺寸高度
        /// </summary>
        public static int ping_height = System.Windows.Forms.SystemInformation.WorkingArea.Height;

        /// <summary>
        /// 控制鼠标事件
        /// </summary>
        /// <param name="dwFlags">鼠标操作，使用方法：Manager.MOUSEEVENTF_LEFTDOWN | Manager.MOUSEEVENTF_LEFTUP</param>
        /// <param name="dx">输入0</param>
        /// <param name="dy">输入0</param>
        /// <param name="cButtons">输入0</param>
        /// <param name="dwExtraInfo">输入0</param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        //Windows提供了一个模拟键盘API函数Keybd_event（）
        /// <summary>
        /// 控制键盘事件
        /// </summary>
        /// <param name="bVk">虚拟键值</param>
        /// <param name="bScan">一般为0</param>
        /// <param name="dwFlags">这里是整数类型 0 为按下，2为释放</param>
        /// <param name="dwExtraInfo">一般为0</param>
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern void keybd_event(
             byte bVk, //虚拟键值
             byte bScan,// 一般为0
             int dwFlags, //这里是整数类型 0 为按下，2为释放
             int dwExtraInfo //这里是整数类型 一般情况下设成为 0
                );


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
        public static void MoveMouseToPoint(Point p)
        {
            SetCursorPos(p.X, p.Y);
        }

        /// <summary>        
        /// 移动鼠标到指定的btn上   
        /// </summary>        
        public static void MoveMouseToButton(Button btn)
        {
            Point p = btn.PointToScreen(new Point());
            p = new Point(p.X + 5, p.Y + 5);
            Auto.MoveMouseToPoint(p);
             
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


        #region LocationOnClient
        /// <summary>
        /// 获得窗体上控件相对于屏幕的位置
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Point LocationOnClient(Control c)
        {
            Point p = new Point(0, 0);
            Form fm = c.FindForm();
            p.Offset(fm.Location);
            p.Offset(fm.MdiParent.Location);

            p.X += (fm.WindowState == FormWindowState.Maximized ? SystemInformation.BorderSize.Width : SystemInformation.BorderSize.Width * 2) + 8;
            p.Y += (fm.WindowState == FormWindowState.Maximized ? (SystemInformation.BorderSize.Height + SystemInformation.CaptionHeight) : (SystemInformation.BorderSize.Height + SystemInformation.CaptionHeight) * 2);


            for (; c.Parent != null; c = c.Parent)
            {
                p.Offset(c.Location);
            }
            return p;
        }
        #endregion



        #region Mouse_Left
        /// <summary>
        /// 点击鼠标左键
        /// </summary>
        public static void Mouse_Left()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);//鼠标左键单击
        }

        public static void Mouse_Left(Point p)
        {
            MoveMouseToPoint(p);
            Mouse_Left();
        }
        #endregion

        #region Mouse_Right
        /// <summary>
        /// 点击鼠标右键
        /// </summary>
        public static void Mouse_Right()
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);//鼠标左键单击
        }
        #endregion

        #region Key_Write
        /// <summary>
        /// 操纵键盘输入文字
        /// </summary>
        /// <param name="str"></param>
        public static void Key_Write(string str)
        {
            char[] c = str.ToCharArray();

            foreach (char temp1 in c)
            {
                string temp = temp1.ToString();
                if (!string.IsNullOrEmpty(temp))
                {
                    byte jianzhi = Convert_ShiJinZhi(temp);
                    keybd_event(jianzhi, 0, 0, 0);
                    keybd_event(jianzhi, 0, 0, 0);
                }
            }

        }
        #endregion

        #region Key_Enter 回车
        /// <summary>
        /// 回车
        /// </summary>
        public static void Key_Enter()
        {
            keybd_event(13, 0, 0, 0);
        }
        #endregion

        #region Convert_ShiJinZhi
        /// <summary>
        /// 将字符转换成虚拟键值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte Convert_ShiJinZhi(string str)
        {
            byte res = 0;
            str = str.ToLower();
            switch (str)
            {
                case "0":
                    res = 48;
                    break;
                case "1":
                    res = 49;
                    break;
                case "2":
                    res = 50;
                    break;
                case "3":
                    res = 51;
                    break;
                case "4":
                    res = 52;
                    break;
                case "5":
                    res = 53;
                    break;
                case "6":
                    res = 54;
                    break;
                case "7":
                    res = 55;
                    break;
                case "8":
                    res = 56;
                    break;
                case "9":
                    res = 57;
                    break;
                case "a":
                    res = 65;
                    break;
                case "b":
                    res = 66;
                    break;
                case "c":
                    res = 67;
                    break;
                case "d":
                    res = 68;
                    break;
                case "e":
                    res = 69;
                    break;
                case "f":
                    res = 70;
                    break;
                case "g":
                    res = 71;
                    break;
                case "h":
                    res = 72;
                    break;
                case "i":
                    res = 73;
                    break;
                case "j":
                    res = 74;
                    break;
                case "k":
                    res = 75;
                    break;
                case "l":
                    res = 76;
                    break;
                case "m":
                    res = 77;
                    break;
                case "n":
                    res = 78;
                    break;
                case "o":
                    res = 79;
                    break;
                case "p":
                    res = 80;
                    break;
                case "q":
                    res = 81;
                    break;
                case "r":
                    res = 82;
                    break;
                case "s":
                    res = 83;
                    break;
                case "t":
                    res = 84;
                    break;
                case "u":
                    res = 85;
                    break;
                case "v":
                    res = 86;
                    break;
                case "w":
                    res = 87;
                    break;
                case "x":
                    res = 88;
                    break;
                case "y":
                    res = 89;
                    break;
                case "z":
                    res = 90;
                    break;
                case "*":
                    res = 106;
                    break;
                case "+":
                    res = 107;
                    break;
                case "-":
                    res = 109;
                    break;
                case ".":
                    res = 110;
                    break;
                case "/":
                    res = 111;
                    break;
            }

            return res;
        }
        #endregion

        #region Ctrl_C
        public static void Ctrl_C()
        {
            try
            {
                //复制Ctrl+c
                keybd_event(17, 0, 0, 0);
                keybd_event(67, 0, 0, 0);
                keybd_event(17, 0, 2, 0);
                keybd_event(67, 0, 2, 0);
            }
            catch
            {
            }
        }
        #endregion

        #region Ctrl_C
        public static void Ctrl_C(string str)
        {
            //复制Ctrl+c
            Clipboard_In(str);
        }
        #endregion

        #region Ctrl_V
        public static void Ctrl_V()
        {
            try
            {
                keybd_event(17, 0, 0, 0);
                keybd_event(86, 0, 0, 0);
                keybd_event(17, 0, 2, 0);
                keybd_event(86, 0, 2, 0);
            }
            catch
            {
            }

        }
        #endregion

        #region Ctrl_V
        /// <summary>
        /// 拆分字符，然后每个字符单独输入
        /// </summary>
        /// <param name="times">间隔时间</param>
        public static void Ctrl_V(int times)
        {
            try
            {
                if (System.Windows.Forms.Clipboard.ContainsText())
                {
                    string mess = System.Windows.Forms.Clipboard.GetText();
                    if (!string.IsNullOrEmpty(mess))
                    {
                        char[] temp = mess.ToCharArray();
                        foreach (char t in temp)
                        {
                            Clipboard_In(t.ToString());
                            Ctrl_V();
                            Browser.Delay(times);
                        }
                    }
                }
            }
            catch
            {
            }

        }
        #endregion

        #region Ctrl_V
        /// <summary>
        /// 直接输入字符 延迟500毫秒
        /// </summary>
        /// <param name="str"></param>
        public static void Ctrl_V(string str)
        {
            try
            {
                Ctrl_C(str);
                Browser.Delay(250);
                Ctrl_V();
                Browser.Delay(250);
            }
            catch
            {
            }
        }
        #endregion

        #region Clipboard_Out
        /// <summary>
        /// 提取粘贴板中的文本信息
        /// </summary>
        public static void Clipboard_Out()
        {
            try
            {
                if (System.Windows.Forms.Clipboard.ContainsText())
                {
                    string mess = System.Windows.Forms.Clipboard.GetText();
                    if (!string.IsNullOrEmpty(mess))
                    {
                        Ctrl_V();
                        Browser.Delay(500);
                        //System.Threading.Thread.Sleep(200);
                    }
                }
            }
            catch { }
        }
        #endregion

        #region Clipboard_In
        /// <summary>
        /// 设置粘贴板中的文本信息
        /// </summary>
        public static void Clipboard_In(string str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                    System.Windows.Forms.Clipboard.SetText(str);
            }
            catch
            {
            }
        }
        #endregion

        #endregion



        #region 任务栏高亮功能
        //使用方法： flashTaskBar(this.Handle, falshType.FLASHW_TIMERNOFG);

        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        public enum falshType : uint
        {
            FLASHW_STOP = 0,    //停止闪烁
            FALSHW_CAPTION = 1,  //只闪烁标题
            FLASHW_TRAY = 2,   //只闪烁任务栏
            FLASHW_ALL = 3,     //标题和任务栏同时闪烁
            FLASHW_PARAM1 = 4,
            FLASHW_PARAM2 = 12,
            FLASHW_TIMER = FLASHW_TRAY | FLASHW_PARAM1,   //无条件闪烁任务栏直到发送停止标志或者窗口被激活，如果未激活，停止时高亮
            FLASHW_TIMERNOFG = FLASHW_TRAY | FLASHW_PARAM2  //未激活时闪烁任务栏直到发送停止标志或者窗体被激活，停止后高亮
        }
        public static bool flashTaskBar(IntPtr hWnd, falshType type)
        {
            FLASHWINFO fInfo = new FLASHWINFO();
            fInfo.cbSize = Convert.ToUInt32(System.Runtime.InteropServices.Marshal.SizeOf(fInfo));
            fInfo.hwnd = hWnd;//要闪烁的窗口的句柄，该窗口可以是打开的或最小化的
            fInfo.dwFlags = (uint)type;//闪烁的类型
            fInfo.uCount = UInt32.MaxValue;//闪烁窗口的次数
            fInfo.dwTimeout = 0; //窗口闪烁的频度，毫秒为单位；若该值为0，则为默认图标的闪烁频度
            return FlashWindowEx(ref fInfo);
        }



        #endregion

    }
}

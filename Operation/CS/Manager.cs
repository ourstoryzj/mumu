using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Drawing;
using System.Diagnostics;
using Entity;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Security.Principal;
using System.Security.AccessControl;
using CefSharp;
using CefSharp.WinForms;
using System.Threading.Tasks;

using System.Collections;
using System.Data;
using System.Reflection;
using System.Net.Mail;
using mshtml;
using Common;
using Operation.Other;

namespace Operation
{
    public static class Manager
    {

        /// <summary>
        /// 声明随机数
        /// </summary>
        private static readonly Random random = new Random();
        /// <summary>
        /// 声明锁定线程,以获取随机数
        /// </summary>
        private static readonly object syncLock = new object();

        /// <summary>
        /// 图片存放位置
        /// </summary>
        public static string imgsite = Application.StartupPath + "\\Image";

        /// <summary>
        /// 竞争对手店铺图片存放位置
        /// </summary>
        public static string imgsite_duishou = Application.StartupPath + "\\Image\\DuiShou";

        /// <summary>
        /// 网供货源图片存放位置
        /// </summary>
        public static string imgsite_wanggong = Application.StartupPath + "\\Image\\WangGong";


        /// <summary>
        /// 淘宝制作主图的参数
        /// </summary>
        public static Image taobaozhutu = null;







        #region 淘宝方法


        //鼠标原始位置
        private static Point _mousePoint;
        /// <summary>
        /// 鼠标原始位置
        /// </summary>
        public static Point MousePoint
        {
            get { return _mousePoint; }
            set { _mousePoint = value; }
        }

        public static IList<wanggong_dianpu> List_dianpu
        {
            get
            {
                if (list_dianpu == null || list_dianpu.Count == 0)
                {
                    list_dianpu = BLL2.wanggong_dianpuManager.SearchAll();
                }
                return list_dianpu;
            }

            set
            {
                list_dianpu = value;
            }
        }

        private static IList<wanggong_dianpu> list_dianpu;




        /// <summary>
        /// 操纵鼠标点击网页时，往控件偏移的尺寸
        /// </summary>
        public static Point point_fuyu = new Point(RandomNumber(1, 5), RandomNumber(1, 5));//用随机数模拟鼠标点击随机位置

        /// <summary>
        /// 淘宝登录小窗口网址
        /// </summary>
        public static string url_login = "https://login.taobao.com/member/login.jhtml?f=top&redirectURL=https%3A%2F%2Fwww.taobao.com%2F&style=mini";

        #region WaitLogin
        /// <summary>
        /// 判断是否已经完全加载完成,同时添加JS方法【getClassName】
        /// </summary>
        /// <param name="webBrowser1">web浏览器控件</param>
        /// <returns></returns>
        public static bool WaitLogin(Other.Login login)
        {
            while (true)
            {
                Browser.Delay(50);  //系统延迟50毫秒，够少了吧！ 
                if (login.isok || login.IsDisposed)
                {
                    return true;
                }
            }
        }
        #endregion

        #region WaitTaobaoLogin
        /// <summary>
        /// 判断是否已经完全加载完成,同时添加JS方法【getClassName】
        /// </summary>
        /// <param name="webBrowser1">web浏览器控件</param>
        /// <returns></returns>
        public static bool WaitTaobaoLogin(Taobao_Login login)
        {
            while (true)
            {
                Browser.Delay(50);  //系统延迟50毫秒，够少了吧！ 
                if (login.isok || login.IsDisposed)
                {
                    return true;
                }
            }
        }


        #endregion


        #region WaitDraw
        /// <summary>
        /// 判断是否已经完全加载完成,同时添加JS方法【getClassName】
        /// </summary>
        /// <param name="webBrowser1">web浏览器控件</param>
        /// <returns></returns>
        public static bool WaitDraw(TaoBao.TB_ScreenDemo sd)
        {
            while (true)
            {
                Browser.Delay(50);  //系统延迟50毫秒，够少了吧！ 
                if (sd.isok || sd.IsDisposed)
                {
                    return true;
                }
            }
        }
        #endregion

        #region dianpu_huan
        /// <summary>
        /// 浏览器中更换店铺信息
        /// </summary>
        /// <param name="web"></param>
        public static void dianpu_huan(ChromiumWebBrowser web)
        {
            Taobao_Login tb = new Taobao_Login();
            tb.Show();
            if (Manager.WaitTaobaoLogin(tb))
            {
                tb.Hide();
                web.RequestContext = tb.webBrowser1.RequestContext;
                tb.Close();
                tb.Dispose();
            }
        }
        #endregion




        #endregion


        #region WinFrom方法






        #region 启动电脑程序
        /// <summary>
        /// 使用默认浏览器打开网址
        /// </summary>
        /// <param name="url"></param>
        public static void OpenProgram(string url)
        {
            //"explorer.exe",打开文件夹
            if (!string.IsNullOrEmpty(url))
            {
                url = AddString_Http(url);
                System.Diagnostics.Process.Start(url);
            }
        }
        /// <summary>
        /// 使用IE打开网址
        /// </summary>
        /// <param name="url"></param>
        public static void OpenProgram_IE(string url)
        {
            System.Diagnostics.Process.Start("iexplore.exe", url);
        }

        /// <summary>
        /// 使用资源管理器打开文件夹
        /// </summary>
        /// <param name="url"></param>
        public static void OpenProgram_Directory(string url)
        {
            //System.Diagnostics.Process.Start("explorer.exe", url);
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = url,
                UseShellExecute = true,
                Verb = "open"
            });
        }


        #endregion

        #region 窗体动画函数

        /// <summary>
        /// 窗体动画函数
        /// </summary>
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //下面是可用的常量，根据不同的动画效果声明自己需要的
        public const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        public const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        public const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        public const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        public const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        public const int AW_HIDE = 0x10000;//隐藏窗口
        public const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        public const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        public const int AW_BLEND = 0x80000;//使用淡入淡出效果

        //窗体代码（将窗体的FormBorderStyle属性设置为none）：
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //   int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
        //   int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
        //   this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
        //   AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
        //}

        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //   AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
        //}
        #endregion


        #region  遍历清空指定的控件
        public static void Clear_Control(Control.ControlCollection Con)
        {
            foreach (Control C in Con)
            { //遍历可视化组件中的所有控件
                if (C.GetType().Name == "TextBox")  //判断是否为TextBox控件
                    if (((TextBox)C).Visible == true)   //判断当前控件是否为显示状态
                        ((TextBox)C).Clear();   //清空当前控件
                if (C.GetType().Name == "MaskedTextBox")  //判断是否为MaskedTextBox控件
                    if (((MaskedTextBox)C).Visible == true)   //判断当前控件是否为显示状态
                        ((MaskedTextBox)C).Clear();   //清空当前控件
                if (C.GetType().Name == "ComboBox")  //判断是否为ComboBox控件
                    if (((ComboBox)C).Visible == true)   //判断当前控件是否为显示状态
                        ((ComboBox)C).Text = "";   //清空当前控件的Text属性值
                if (C.GetType().Name == "PictureBox")  //判断是否为PictureBox控件
                    if (((PictureBox)C).Visible == true)   //判断当前控件是否为显示状态
                        ((PictureBox)C).Image = null;   //清空当前控件的Image属性
            }
        }
        #endregion

        #region  遍历清空指定的控件
        public static void Reset_Control(Control.ControlCollection Con)
        {
            foreach (Control cl in Con)
            {
                //Debug.WriteLine(cl.Name);
                if (cl is ComboBox)
                {
                    ComboBox cb = cl as ComboBox;
                    //cb.DataSource = null;
                    //cb.Items.Clear();//清除绑定项
                }
                else if (cl is TextBox)
                {
                    TextBox tb = cl as TextBox;
                    tb.Text = string.Empty;//清除所有TextBox
                }
                else if (cl is RadioButton)
                {
                    RadioButton cb = cl as RadioButton;
                    //cb.DataSource = null;
                    cb.Checked = false;
                }
                else if (cl is CheckBox)
                {
                    CheckBox cb = cl as CheckBox;
                    //cb.DataSource = null;
                    cb.Checked = false;
                }

            }
        }
        #endregion



        #endregion

        #region Path 路径
        /// <summary>
        /// 获取项目绝对路径
        /// </summary>
        /// <returns></returns>
        public static string PathAppliction()
        {
            return Application.StartupPath;
        }

        /// <summary>
        /// 获取桌面路径
        /// </summary>
        /// <returns></returns>
        public static string PathDesktop()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }
        #endregion

        #region String字符串处理

        #region 截取字符串

        /// <summary>
        /// 使用排除法，获得字符换,使用方法：Manager.Substring(str, new string[] { "http", "shop", ":", "s", "/" });
        /// </summary>
        /// <param name="str">要处理的字符串</param>
        /// <param name="strs">要删除的字符串，注意删除顺序</param>
        /// <returns>截取的字符串</returns>
        public static string Substring(string str, string[] strs)
        {
            foreach (string s in strs)
            {
                str = str.Replace(s, "");
            }
            return str;
        }

        public static string Substring(string str, int num)
        {
            str = str.Length > num ? str.Substring(0, (num - 1)) : str;
            return str;
        }
        /// <summary>
        /// 截取字符串,可匹配没有该参数的情况
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="bin_str">开始的字符串（取两个字符中的值）</param>
        /// <param name="end_str">结束的字符串（取两个字符中的值）</param>
        /// <returns></returns>
        public static string Substring(string str, string bin_str, string end_str)
        {
            try
            {
                //str = str.Length > num ? str.Substring(0, (num - 1)) : str;
                int temp1 = str.IndexOf(bin_str);
                int temp2 = str.LastIndexOf(end_str);
                //if (temp1 < 0 && temp2 < 0)
                //{
                //    return str;
                //}
                //else if (temp1 < 0)
                //{
                //    //str = str.Substring(0, temp2 - 2);
                //    str = str.Substring(0, temp2 - end_str.Length);
                //}
                //else if (temp2 < 0)
                //{
                //    str = str.Substring(temp1 + bin_str.Length - 1);
                //}
                if (string.IsNullOrEmpty(bin_str) && string.IsNullOrEmpty(end_str))
                {
                    return str;
                }
                else if (string.IsNullOrEmpty(bin_str) && !string.IsNullOrEmpty(end_str))
                {
                    //str = str.Substring(0, temp2 - 2);
                    str = str.Substring(0, temp2);
                }
                else if (!string.IsNullOrEmpty(bin_str) && string.IsNullOrEmpty(end_str))
                {
                    //str = str.Substring(temp1 + bin_str.Length - 1);
                    str = str.Substring(temp1 + bin_str.Length, str.Length - temp1 - bin_str.Length);
                }
                else
                {
                    if (temp1 != -1 || temp2 != -1)
                    {
                        int temp_index = temp1 + bin_str.Length;
                        //int temp_length = temp2 - end_str.Length - 1;
                        int temp_length = temp2 - temp_index;
                        str = str.Substring(temp_index, temp_length);
                    }
                    else
                    {
                        //没有找到
                        str = "";
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("截取字符串出错" + ex.ToString());
            }
            return str;
        }

        #region SubString
        /// <summary>
        /// 根据两个字符串 截取信息,亲测可使用
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="str1">分割字符串的起始位置</param>
        /// <param name="str2">分割字符串的结束位置</param>
        /// <returns></returns>
        public static string SubString(string str, string str1, string str2)
        {
            string res = "";
            string[] sArray = str.Split(new string[] { str1, str2 }, StringSplitOptions.RemoveEmptyEntries);
            if (sArray.Length > 1)
            {
                res = sArray[1];
            }
            return res;
        }
        #endregion


        #region SubString
        /// <summary>
        /// 根据两个字符串 截取信息,亲测可使用
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="str1">分割字符串的起始位置</param>
        /// <param name="str2">分割字符串的结束位置</param>
        /// <returns></returns>
        public static string SubString2(string str, string str1, string str2)
        {
            string res = "";
            string[] sArray = str.Split(new string[] { str1, str2 }, StringSplitOptions.RemoveEmptyEntries);
            if (sArray.Length > 1)
            {
                res = sArray[1];
            }
            return res;
        }
        #endregion

        /// <summary>
        /// 将字符串分割成字符串数组
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="fenge">分割字符串</param>
        /// <returns></returns>
        public static string[] Str_Split(string str, string fenge)
        {
            string[] strs = null;
            try
            {
                strs = Regex.Split(str, fenge, RegexOptions.IgnoreCase);
            }
            catch
            {
            }

            return strs;
        }


        ///   <summary>
        ///   取出文本中的图片地址
        ///   </summary>
        ///   <param   name="HTMLStr">HTMLStr</param>
        public static string GetImgUrl(string HTMLStr)
        {
            string str = string.Empty;
            //string sPattern = @"^<img\s+[^>]*>";
            Regex r = new Regex(@"<img\s+[^>]*\s*src\s*=\s*([']?)(?<url>\S+)'?[^>]*>",
              RegexOptions.Compiled);
            Match m = r.Match(HTMLStr.ToLower());
            if (m.Success)
                str = m.Result("${url}");
            return str;
        }

        /// <summary> 
        /// 取得HTML中所有图片的 URL。 
        /// </summary> 
        /// <param name="sHtmlText">HTML代码</param> 
        /// <returns>图片的URL列表</returns> 
        public static string[] GetHtmlImageUrlList(string sHtmlText)
        {
            // 定义正则表达式用来匹配 img 标签 
            Regex regImg = new Regex(@"<img\b[^<>]*?\bsrc[\s\t\r\n]*=[\s\t\r\n]*[""']?[\s\t\r\n]*(?<imgUrl>[^\s\t\r\n""'<>]*)[^<>]*?/?[\s\t\r\n]*>", RegexOptions.IgnoreCase);

            // 搜索匹配的字符串 
            MatchCollection matches = regImg.Matches(sHtmlText);
            int i = 0;
            string[] sUrlList = new string[matches.Count];

            // 取得匹配项列表 
            foreach (Match match in matches)
                sUrlList[i++] = match.Groups["imgUrl"].Value;
            return sUrlList;
        }

        #endregion

        #region 添加HTTP://字符串
        public static string AddString_Http(string str)
        {
            //str = str.ToLower();
            if (str.IndexOf("http://") >= 0 || str.IndexOf("https://") >= 0)
            {
                return str;
            }
            else if (str.IndexOf("//") >= 0)
            {
                str = str.Replace("//", "http://");
            }
            else
            {
                str = "http://" + str;
            }
            //if (str.IndexOf("http://") < 0)
            //{

            //}

            return str;
        }
        #endregion



        #region  去除HTML标记
        /**/
        ///   <summary>
        ///   去除HTML标记
        ///   </summary>
        ///   <param   name="NoHTML">包括HTML的源码   </param>
        ///   <returns>已经去除后的文字</returns>
        public static string NoHTML(string Htmlstring)
        {
            if (string.IsNullOrEmpty(Htmlstring))
            {
                return Htmlstring;
            }
            //删除脚本
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "",
         RegexOptions.IgnoreCase);
            //删除HTML
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9",
              RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "",
              RegexOptions.IgnoreCase);

            Htmlstring = Htmlstring.Replace("<", "");
            Htmlstring = Htmlstring.Replace(">", "");
            Htmlstring = Htmlstring.Replace("\r\n", "");
            Htmlstring = Htmlstring.Replace("\t", "");
            //Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }







        #endregion

        #region String_CheckChinese 判断字符是不是汉字


        /// <summary>
        /// 用 正则表达式 判断字符是不是汉字
        /// </summary>
        /// <param name="text">待判断字符或字符串</param>
        /// <returns>真：是汉字；假：不是</returns>
        public static bool String_CheckChinese(string txt)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(txt, @"[\u4e00-\u9fbb]");
        }

        #endregion

        #region GetTBTitleFontNum
        /// <summary>
        /// 获取淘宝标题的字数，非中文两个字符算一个
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int GetTBTitleFontNum(this String str)
        {
            // 中文字符数量
            int resnum = 0;
            //英文和数字数量
            int resnum2 = 0;
            //计算后标题的数量
            int res = 0;

            if (string.IsNullOrEmpty(str))
                return 0;
            Char[] strs = str.ToCharArray();
            foreach (char temp in strs)
            {
                if (Manager.String_CheckChinese(temp.ToString()))
                    resnum++;
                else
                    resnum2++;
            }

            if (resnum2 > 0)
                res = (resnum2 / 2) + ((resnum2 % 2) > 0 ? 1 : 0);
            res = res + resnum;
            return res;
        }
        #endregion

        #region ToInt
        /// <summary>
        /// 转化成Int，如果不成功则返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this String str)
        {
            int res = 0;
            int.TryParse(str, out res);
            return res;
        }

        #endregion

        #region ToDecimal
        /// <summary>
        /// 转化成decimal，如果不成功则返回0
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this String str)
        {
            decimal res = 0;
            decimal.TryParse(str, out res);
            return res;
        }

        #endregion

        #region ToCheckRoot
        /// <summary>
        /// 检查词根,并返回词根
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ToCheckRoot(this String str, string str2)
        {
            if (str == str2)
                return str;
            if (str.IndexOf(str2) > -1)
                return str2;
            if (str2.IndexOf(str) > -1)
                return str;
            return str;
        }

        #endregion

        #endregion

        #region  网址获取参数值

        /// <summary>
        /// 根据网址获取参数值
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="key">参数名称</param>
        /// <returns>参数值</returns>
        public static string GetURLParam(string url, string key)
        {
            string res = "";
            try
            {
                //判断是否存在
                if (url.IndexOf(key) >= 0)
                {
                    string[] temp_1 = url.Split(new char[1] { '?' });
                    if (temp_1.Length > 1)
                    {
                        string[] temp_2 = temp_1[1].Split(new char[1] { '&' });
                        if (temp_2.Length > 0)
                        {
                            foreach (string temp in temp_2)
                            {
                                string[] temp_3 = temp.Split(new char[1] { '=' });
                                if (temp_3[0].Equals(key))
                                {
                                    return temp_3[1];
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Debug.WriteLine("根据网址获取参数值失败！！！！！！！！");
            }
            return res;
        }


        /// <summary>
        /// 根据网址获取参数值,优质方法
        /// </summary>
        /// <param name="url">网址</param>
        /// <param name="key">参数名</param>
        /// <returns>参数值</returns>
        public static string GetValueByURL(string url, string key)
        {
            string searchKey = "";
            try
            {
                Uri uri = new Uri(url);
                string queryString = uri.Query;
                NameValueCollection col = GetQueryString(queryString);
                searchKey = col[key];
            }
            catch
            {
                searchKey = "";
            }
            return searchKey;
        }


        /// <summary>
        /// 将查询字符串解析转换为名值集合.
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static NameValueCollection GetQueryString(string queryString)
        {
            return GetQueryString(queryString, null, false);
        }
        /// <summary>
        /// 将查询字符串解析转换为名值集合.
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="encoding"></param>
        /// <param name="isEncoded"></param>
        /// <returns></returns>
        public static NameValueCollection GetQueryString(string queryString, Encoding encoding, bool isEncoded)
        {
            queryString = queryString.Replace("?", "");
            NameValueCollection result = new NameValueCollection(StringComparer.OrdinalIgnoreCase);
            if (!string.IsNullOrEmpty(queryString))
            {
                int count = queryString.Length;
                for (int i = 0; i < count; i++)
                {
                    int startIndex = i;
                    int index = -1;
                    while (i < count)
                    {
                        char item = queryString[i];
                        if (item == '=')
                        {
                            if (index < 0)
                            {
                                index = i;
                            }
                        }
                        else if (item == '&')
                        {
                            break;
                        }
                        i++;
                    }
                    string key = null;
                    string value = null;
                    if (index >= 0)
                    {
                        key = queryString.Substring(startIndex, index - startIndex);
                        value = queryString.Substring(index + 1, (i - index) - 1);
                    }
                    else
                    {
                        key = queryString.Substring(startIndex, i - startIndex);
                    }
                    if (isEncoded)
                    {
                        //result[MyUrlDeCode(key, encoding)] = MyUrlDeCode(value, encoding);
                    }
                    else
                    {
                        result[key] = value;
                    }
                    if ((i == (count - 1)) && (queryString[i] == '&'))
                    {
                        result[key] = string.Empty;
                    }
                }
            }
            return result;
        }



        /*
    /// <summary>
    /// 解码URL.
    /// </summary>
    /// <param name="encoding">null为自动选择编码</param>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string MyUrlDeCode(string str, Encoding encoding)
    {
     if (encoding == null) 
     { 
         Encoding utf8 = Encoding.UTF8; 
         //首先用utf-8进行解码                      
         string code = HttpUtility.UrlDecode(str.ToUpper(), utf8); 
         //将已经解码的字符再次进行编码. 
         string encode = HttpUtility.UrlEncode(code, utf8).ToUpper(); 
         if (str == encode) 
             encoding = Encoding.UTF8; 
         else 
             encoding = Encoding.GetEncoding( "gb2312");
     } 
     return HttpUtility.UrlDecode(str, encoding); 
    }
         * 
         * */
        #endregion

        #region  下载图片

        //public static Image GetImgByURL(string myImgUri)
        //{
        //    Bitmap myImage = null;
        //    if (!string.IsNullOrEmpty(myImgUri))
        //    {
        //        try
        //        {
        //            string url = AddString_Http(myImgUri);
        //            System.Drawing.Image img=
        //            //byte[] bytes = new System.Net.WebClient().DownloadData(url);
        //            WebRequest webRequest = WebRequest.Create(url);
        //            WebResponse webResponse = webRequest.GetResponse();
        //            myImage = new Bitmap(webResponse.GetResponseStream());

        //        }
        //        catch (Exception ex) { }
        //    }
        //    return (Image)myImage;
        //}

        //public static Image GetImgByURL(string url)
        //{
        //    var image = new Image();
        //    try
        //    {
        //        System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
        //        System.Net.WebResponse webres = webreq.GetResponse();
        //        System.IO.Stream stream = webres.GetResponseStream();
        //        System.Drawing.Image img1 = System.Drawing.Image.FromStream(stream);
        //        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(img1);
        //        IntPtr hBitmap = bmp.GetHbitmap();
        //        System.Windows.Media.ImageSource WpfBitmap = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        //        image.Source = WpfBitmap;
        //        image.Stretch = Stretch.Uniform;
        //        stream.Dispose();
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //    return image;
        //}

        //public static Image GetImgByURL(string url)
        //{
        //    var image = new Image();
        //    image.Source = new BitmapImage(new Uri(url, UriKind.Absolute));
        //    image.Stretch = Stretch.Fill;
        //    return image;
        //}  


        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="picUrl">图片Http地址</param>
        /// <param name="savePath">保存路径，需要加上后面的文件名称</param>
        /// <param name="timeOut">Request最大请求时间，如果为-1则无限制</param>
        /// <returns></returns>
        public static void DownloadFile_Action(string picUrl, string savePath, string fileName, int timeOut)
        {
            bool value = false;
            Stream reader = null;
            HttpWebResponse webResponse = null;
            try
            {
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(picUrl);
                if (timeOut >= 0)
                {
                    webRequest.Timeout = timeOut;
                }
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                //若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理   
                reader = webResponse.GetResponseStream();
                if (!webResponse.ContentType.ToLower().StartsWith("text/"))
                {
                    value = SaveBinaryFile(webResponse, savePath + "\\" + fileName);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(DateTime.Now.ToShortDateString() + "===============================================");
                Debug.WriteLine("文件下载失败：" + ex.Message);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (webResponse != null) webResponse.Close();

            }


            //return value;
        }


        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="picUrl">图片Http地址</param>
        /// <param name="savePath">保存路径，需要加上后面的文件名称</param>
        /// <param name="timeOut">Request最大请求时间，如果为-1则无限制</param>
        /// <returns></returns>
        public static bool DownloadFile(string picUrl, string savePath, string fileName, int timeOut)
        {
            bool value = false;
            Stream reader = null;
            HttpWebResponse webResponse = null;
            try
            {
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(picUrl);
                if (timeOut >= 0)
                {
                    webRequest.Timeout = timeOut;
                }
                webResponse = (HttpWebResponse)webRequest.GetResponse();
                //若成功取得网页的内容，则以System.IO.Stream形式返回，若失败则产生ProtoclViolationException错 误。在此正确的做法应将以下的代码放到一个try块中处理。这里简单处理   
                reader = webResponse.GetResponseStream();
                if (!webResponse.ContentType.ToLower().StartsWith("text/"))
                {
                    value = SaveBinaryFile(webResponse, savePath + "\\" + fileName);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(DateTime.Now.ToShortDateString() + "===============================================");
                Debug.WriteLine("文件下载失败：" + ex.Message);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (webResponse != null) webResponse.Close();

            }


            return value;
        }
        /// <summary>
        /// 下载图片，默认放到Image文件夹内，
        /// </summary>
        /// <param name="picUrl">图片网址</param>
        /// <returns>图片名称</returns>
        public static string DownloadFile(string picUrl)
        {
            string res = "";
            if (!string.IsNullOrEmpty(picUrl))
            {
                string path = Application.StartupPath + "\\Image";
                string imgname = DateTime.Now.ToString("yyyyMMddhhmmss") + Manager.RandomNumber(1000, 99999).ToString() + ".jpg";
                if (DownloadFile(picUrl, path, imgname, 5000))
                {
                    res = imgname;
                }
            }
            return res;
        }
        /// <summary>
        /// 下载图片，默认放到Image文件夹内，
        /// </summary>
        /// <param name="picUrl">图片网址</param>
        /// <param name="fileName">图片名称</param>
        /// <param name="timeOut">Request最大请求时间，如果为-1则无限制</param>
        /// <returns>图片名称</returns>
        public static bool DownloadFile(string picUrl, string fileName, int timeOut)
        {
            bool res = false;
            if (!string.IsNullOrEmpty(picUrl) && !string.IsNullOrEmpty(fileName))
            {
                string path = Application.StartupPath + "\\Image";
                res = DownloadFile(picUrl, path, fileName, timeOut);
            }
            return res;
        }

        private static bool SaveBinaryFile(WebResponse response, string savePath)
        {
            bool value = false;
            byte[] buffer = new byte[1024];
            Stream outStream = null;
            Stream inStream = null;
            try
            {
                if (File.Exists(savePath)) File.Delete(savePath);
                outStream = System.IO.File.Create(savePath);
                inStream = response.GetResponseStream();
                int l;
                do
                {
                    l = inStream.Read(buffer, 0, buffer.Length);
                    if (l > 0) outStream.Write(buffer, 0, l);
                } while (l > 0);
                value = true;
            }
            finally
            {
                if (outStream != null) outStream.Close();
                if (inStream != null) inStream.Close();
            }
            return value;
        }

        /// <summary>  
        /// 拷贝文件夹  
        /// </summary>  
        /// <param name="sourceDirectory"></param>  
        /// <param name="targetDirectory"></param>  
        public static bool DirectoryCopy(string sourceDirectory, string targetDirectory)
        {
            if (!Directory.Exists(sourceDirectory))
            {
                return false;
            }
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }
            DirectoryInfo sourceInfo = new DirectoryInfo(sourceDirectory);
            //拷贝源路径下的文件  
            FileInfo[] fileInfo = sourceInfo.GetFiles();
            foreach (FileInfo fiTemp in fileInfo)
            {
                string sSrcFilePath = String.Format("{0}\\{1}", sourceDirectory, fiTemp.Name);
                string sTarFilePath = String.Format("{0}\\{1}", targetDirectory, fiTemp.Name);
                //去除文件的只读属性  
                //System.IO.File.SetAttributes(sSrcFilePath, System.IO.FileAttributes.Normal);  
                FileAttributes attributes = File.GetAttributes(sSrcFilePath);
                attributes = attributes & ~FileAttributes.ReadOnly;
                File.SetAttributes(sSrcFilePath, attributes);
                File.Copy(sSrcFilePath, sTarFilePath, true);
            }
            //拷贝源路径下的文件夹  
            DirectoryInfo[] diInfo = sourceInfo.GetDirectories();
            foreach (DirectoryInfo diTemp in diInfo)
            {
                string sourcePath = diTemp.FullName;
                string targetPath = diTemp.FullName.Replace(sourceDirectory, targetDirectory);
                Directory.CreateDirectory(targetPath);
                DirectoryCopy(sourcePath, targetPath);
            }
            return true;
        }

        #region 下载文件FileDownload
        /// <summary>
        /// 下载代码
        /// </summary>
        /// <param name="FileName"></param>
        public static void FileDownload(string FileName, string name)
        {
            //String FullFileName = System.Web.HttpContext.Current.Server.MapPath(FileName);
            //FileInfo DownloadFile = new FileInfo(FullFileName);
            //System.Web.HttpContext.Current.Response.Clear();
            //System.Web.HttpContext.Current.Response.ClearHeaders();
            //System.Web.HttpContext.Current.Response.Buffer = false;
            //System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
            //System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + name);
            //System.Web.HttpContext.Current.Response.AppendHeader("Content-Length", DownloadFile.Length.ToString());
            //System.Web.HttpContext.Current.Response.WriteFile(DownloadFile.FullName);
            //System.Web.HttpContext.Current.Response.Flush();
            //System.Web.HttpContext.Current.Response.End();
        }
        #endregion



        //private void btnDown_Click(object sender, EventArgs e)
        //{
        //    DownloadFile("http://localhost:1928/WebServer/downloader/123.rar", @"C:\123.rar", progressBar1, label1);
        //}
        /// <summary>        
        /// c#,.net 下载文件        
        /// </summary>        
        /// <param name="URL">下载文件地址</param>       
        /// 
        /// <param name="Filename">下载后的存放地址</param>        
        /// <param name="Prog">用于显示的进度条</param>        
        /// 
        public static void DownloadFile(string URL, string filename, System.Windows.Forms.ProgressBar prog, System.Windows.Forms.Label label1)
        {
            float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                if (prog != null)
                {
                    prog.Maximum = (int)totalBytes;
                }
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    if (prog != null)
                    {
                        prog.Value = (int)totalDownloadedByte;
                    }
                    osize = st.Read(by, 0, (int)by.Length);

                    percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    label1.Text = "当前补丁下载进度" + percent.ToString() + "%";
                    System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        public static void DownloadFile(string URL, string filename)
        {
            //float percent = 0;
            try
            {
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                long totalBytes = myrp.ContentLength;
                //if (prog != null)
                //{
                //    prog.Maximum = (int)totalBytes;
                //}
                System.IO.Stream st = myrp.GetResponseStream();
                System.IO.Stream so = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                long totalDownloadedByte = 0;
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    totalDownloadedByte = osize + totalDownloadedByte;
                    System.Windows.Forms.Application.DoEvents();
                    so.Write(by, 0, osize);
                    //if (prog != null)
                    //{
                    //    prog.Value = (int)totalDownloadedByte;
                    //}
                    osize = st.Read(by, 0, (int)by.Length);

                    //percent = (float)totalDownloadedByte / (float)totalBytes * 100;
                    //label1.Text = "当前补丁下载进度" + percent.ToString() + "%";
                    //System.Windows.Forms.Application.DoEvents(); //必须加注这句代码，否则label1将因为循环执行太快而来不及显示信息
                }
                so.Close();
                st.Close();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        #endregion

        #region 读取网络资源，返回字节数组

        // 读取网络资源，返回字节数组
        public static byte[] getBytes(string url, CookieContainer cookie, byte[] postData, string contentType)
        {
            try
            {
                int c = url.IndexOf("/", 10);
                byte[] data = null;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //request.Timeout = timeOut;????????
                request.AllowAutoRedirect = true;
                if (cookie != null) request.CookieContainer = cookie;
                request.Referer = (c > 0 ? url.Substring(0, c) : url);
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
                request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";

                if (postData != null)                                           // 需要 Post 数据
                {
                    request.Method = "POST";
                    if (contentType == null) contentType = "application/x-www-form-urlencoded";
                    request.ContentType = contentType;
                    request.ContentLength = postData.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(postData, 0, postData.Length);
                    requestStream.Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //cookies= response.Cookies;
                //wc=response.Headers;
                string ce = response.Headers[HttpResponseHeader.ContentEncoding];
                int ContentLength = (int)response.ContentLength;
                Stream s = response.GetResponseStream();
                c = 1024 * 10;
                if (ContentLength < 0)                                          // 不能获取数据的长度
                {
                    data = new byte[c];
                    MemoryStream ms = new MemoryStream();
                    int l = s.Read(data, 0, c);
                    while (l > 0)
                    {
                        ms.Write(data, 0, l);
                        l = s.Read(data, 0, c);
                    }
                    data = ms.ToArray();
                    ms.Close();
                }
                else                                                            // 数据长度已知
                {
                    data = new byte[ContentLength];
                    int pos = 0;
                    while (ContentLength > 0)
                    {
                        int l = s.Read(data, pos, ContentLength);
                        pos += l;
                        ContentLength -= l;
                    }
                }
                s.Close();
                response.Close();

                if (ce == "gzip")                                               // 若数据是压缩格式，则要进行解压
                {
                    //MemoryStream js = new MemoryStream();                       // 解压后的流   
                    //MemoryStream ms = new MemoryStream(data);                   // 用于解压的流   
                    //GZipStream g = new GZipStream(ms, CompressionMode.Decompress);
                    //byte[] buffer = new byte[c];                                // 读数据缓冲区      
                    //int l = g.Read(buffer, 0, c);                               // 一次读 10K      
                    //while (l > 0)
                    //{
                    //    js.Write(buffer, 0, l);
                    //    l = g.Read(buffer, 0, c);
                    //}
                    //g.Close();
                    //ms.Close();
                    //data = js.ToArray();
                    //js.Close();
                    unRar(ref data);
                }
                return data;                                                    // 返回字节数组
            }
            catch
            {
                return new byte[0];
            }
        }

        private static byte[] unRar(ref byte[] data)     // 解压数据
        {
            try
            {
                MemoryStream js = new MemoryStream();                       // 解压后的流   
                MemoryStream ms = new MemoryStream(data);                   // 用于解压的流   
                GZipStream g = new GZipStream(ms, CompressionMode.Decompress);
                byte[] buffer = new byte[10240];                                // 读数据缓冲区      
                int l = g.Read(buffer, 0, 10240);                               // 一次读 10K      
                while (l > 0)
                {
                    js.Write(buffer, 0, l);
                    l = g.Read(buffer, 0, 10240);
                }
                g.Close();
                ms.Close();
                data = js.ToArray();
                js.Close();
                return data;
            }
            catch
            {
                return data;
            }
        }

        #endregion

        #region RandomNumber
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        #endregion

        #region DataGridView


        /// <summary>
        /// 用于在DataGridView显示图片
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static System.Drawing.Image GetImage(string path)
        {
            System.Drawing.Image result = null;
            //判断文件是否存在
            if (File.Exists(@path))
            {
                //存在
                System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open);
                result = System.Drawing.Image.FromStream(fs);
                fs.Close();
            }
            return result;
        }


        #region BindingSort_opponent_goods
        /// <summary>
        /// 可排序的淘宝商品数据源转换方法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static BindingCollection<opponent_goods> BindingSort_opponent_goods(IList<opponent_goods> list)
        {
            BindingCollection<opponent_goods> objList = new BindingCollection<opponent_goods>();

            //加载数据
            foreach (opponent_goods item in list)
            {
                objList.Add(item);
            }
            return objList;

        }




        #endregion

        #region BindingSort_wanggong_goods
        /// <summary>
        /// 可排序的淘宝商品数据源转换方法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static BindingCollection<wanggong_goods> BindingSort_wanggong_goods(IList<wanggong_goods> list)
        {
            BindingCollection<wanggong_goods> objList = new BindingCollection<wanggong_goods>();

            //加载数据
            foreach (wanggong_goods item in list)
            {
                objList.Add(item);
            }
            return objList;

        }

        #endregion

        #region BindingSort_opponent_goods_ToList
        /// <summary>
        /// 可排序的淘宝商品数据源转换方法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<opponent_goods> BindingSort_opponent_goods_ToList(BindingCollection<opponent_goods> list)
        {
            List<opponent_goods> objList = new List<opponent_goods>();

            //加载数据
            foreach (opponent_goods item in list)
            {
                objList.Add(item);
            }
            return objList;

        }




        #endregion

        #region BindingSort_wanggong_goods_ToList
        /// <summary>
        /// 可排序的淘宝商品数据源转换方法
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<wanggong_goods> BindingSort_wanggong_goods_ToList(BindingCollection<wanggong_goods> list)
        {
            List<wanggong_goods> objList = new List<wanggong_goods>();

            //加载数据
            foreach (wanggong_goods item in list)
            {
                objList.Add(item);
            }
            return objList;

        }




        #endregion


        #endregion

        #region GetZheKou
        /// <summary>
        /// 获取折扣比例
        /// </summary>
        /// <param name="price1">原价</param>
        /// <param name="price2">现价</param>
        /// <returns>折扣比例</returns>
        public static decimal GetZheKou(string price1, string price2)
        {
            decimal temp_price1 = 1;
            decimal temp_price2 = 1;
            decimal.TryParse(price1, out temp_price1);
            decimal.TryParse(price2, out temp_price2);

            decimal res = 0;
            try
            {
                res = temp_price2 * 10 / temp_price1;
            }
            catch
            {
                res = 0;
            }
            return res;
        }

        #endregion

        #region StrToList
        /// <summary>
        /// 每行一个转换成list
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> StrToList(string str)
        {
            //List<string> list = new List<string>();

            str = str.Replace("\r", "");
            //string[] lines = str.Split('\n');
            //foreach (string s in lines)
            //{
            //    if (!string.IsNullOrEmpty(s))
            //    {
            //        list.Add(s);
            //    }
            //}
            //return list;
            return StrToList(str, '\n');
        }

        #endregion

        #region StrToList
        /// <summary>
        /// 每行一个转换成list
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> StrToList(string str, char fenge)
        {
            List<string> list = new List<string>();
            string[] lines = str.Split(fenge);
            foreach (string s in lines)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    list.Add(s);
                }
            }
            return list;
        }

        #endregion

        #region StrOneToList
        /// <summary>
        /// 把一串字符转换成一个字符一个的list
        /// </summary>
        /// <returns></returns>
        public static List<string> StrOneToList(string str)
        {
            char[] temp = str.ToCharArray();
            List<string> list = new List<string>();

            try
            {
                foreach (char s in temp)
                {
                    string temps = s.ToString();
                    list.Add(temps);
                }
            }
            catch { }
            return list;
        }

        #endregion

        #region 文件File

        /// <summary>
        /// 创建目录，如果有则不再创建，没有就创建一个
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool CreateDirectory(string url)
        {
            bool res = true;
            //判断目录是否存在
            if (!System.IO.Directory.Exists(url))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(url);
                }
                catch
                {
                    res = false;
                }

            }
            return res;
        }

        /// <summary>
        /// 创建一个txt文件，如果有这个文件就直接返回这个文件的流
        /// </summary>
        /// <param name="fileurl">文件的绝对路径</param>
        /// <returns></returns>
        public static StreamWriter CreateFile(string fileurl)
        {
            StreamWriter sw = null;
            //如果没有文件就创建一个
            if (!System.IO.File.Exists(fileurl))
            {
                sw = System.IO.File.CreateText(fileurl);
            }
            else
            {
                //如果有这个文件就直接读取
                sw = System.IO.File.AppendText(fileurl);
            }
            return sw;
        }

        /// <summary>
        /// 查看一个文件是否存在
        /// </summary>
        /// <param name="fileurl">文件的绝对路径</param>
        /// <returns></returns>
        public static bool fileFind(string fileurl)
        {
            return System.IO.File.Exists(fileurl);
        }

        /// <summary>
        /// 创建一个txt文件，并创建相关目录，如果有这个文件就直接返回这个文件的流
        /// </summary>
        /// <param name="fileurl">文件的绝对路径</param>
        /// <returns></returns>
        public static StreamWriter CreateFile(string directory, string filename)
        {
            CreateDirectory(directory);
            string fileurl = directory + "\\" + filename;
            StreamWriter sw = null;
            //如果没有文件就创建一个
            if (!System.IO.File.Exists(fileurl))
            {
                sw = System.IO.File.CreateText(fileurl);
            }
            else
            {
                //如果有这个文件就直接读取
                sw = System.IO.File.AppendText(fileurl);
            }
            return sw;
        }


        #region WriteEntry_PDD
        public static void WriteEntry_PDD(string str)
        {
            string path = Environment.CurrentDirectory;
            //string path = System.Environment.CurrentDirectory;
            //string logDir = path + "自动回复内容\\";
            string logDir = path + "\\Log";
            //您好，顾客暂时比较多，客服MM正在逐一回复，请稍等一下哦
            string logFile = logDir + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + "拼多多客户问题.log";
            if (!System.IO.Directory.Exists(logDir))
            {
                System.IO.Directory.CreateDirectory(logDir);
            }
            System.IO.StreamWriter sw;
            if (System.IO.File.Exists(logFile))
            {
                sw = System.IO.File.AppendText(logFile);
            }
            else
            {
                sw = System.IO.File.CreateText(logFile);
            }
            sw.WriteLine(str);
            //sw.WriteLine("发生时间:" + DateTime.Now.ToString());
            //sw.WriteLine("信息内容:" + str);
            //sw.WriteLine();
            //sw.WriteLine("******************************************************************************************");
            sw.Close();
        }
        #endregion

        #region WriteLog
        public static void WriteLog(string str)
        {
            string path = Environment.CurrentDirectory;
            //string path = System.Environment.CurrentDirectory;
            //string logDir = path + "自动回复内容\\";
            string logDir = path + "\\Log";
            //您好，顾客暂时比较多，客服MM正在逐一回复，请稍等一下哦
            string logFile = logDir + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if (!System.IO.Directory.Exists(logDir))
            {
                System.IO.Directory.CreateDirectory(logDir);
            }
            System.IO.StreamWriter sw;
            if (System.IO.File.Exists(logFile))
            {
                sw = System.IO.File.AppendText(logFile);
            }
            else
            {
                sw = System.IO.File.CreateText(logFile);
            }
            //sw.WriteLine(str);
            sw.WriteLine("发生时间:" + DateTime.Now.ToString());
            sw.WriteLine("信息内容:" + str);
            sw.WriteLine();
            sw.WriteLine("******************************************************************************************");
            sw.Close();
        }
        #endregion

        #endregion

        #region BrowserEmulationSet IE WebBrowser内核设置

        /// <summary>
        /// IE WebBrowser内核设置
        /// </summary>
        public static void BrowserEmulationSet()
        {


            //NTAccount name = new NTAccount(Environment.UserName);
            //RegistrySecurity rs = Registry.LocalMachine.OpenSubKey("software").OpenSubKey("test").GetAccessControl();
            //rs.AddAccessRule(new RegistryAccessRule(name, RegistryRights.SetValue, AccessControlType.Deny));
            //Registry.LocalMachine.OpenSubKey("software").OpenSubKey("test", true).SetAccessControl(rs);

            string path = @"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION";

            ////获取当前系统用户
            //NTAccount name = new NTAccount(Environment.UserDomainName, Environment.UserName);
            ////获取注册表的节点
            //using (RegistryKey regKey = Registry.LocalMachine.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree, RegistryRights.ChangePermissions))
            //{
            //    //获取当前节点的安全性设置
            //    RegistrySecurity rs = regKey.GetAccessControl();
            //    //获取当前节点的访问权限
            //    RegistryAccessRule denyRule = rs
            //        .GetAccessRules(true, false, typeof(NTAccount))
            //        .OfType<RegistryAccessRule>()
            //        .FirstOrDefault(r => r.AccessControlType == AccessControlType.Deny && (r.IdentityReference as NTAccount) == name);
            //    //如果没有权限，或者访问被拒绝
            //    if (denyRule != null && rs.RemoveAccessRule(denyRule))
            //    {
            //        //向节点添加设置权限
            //        regKey.SetAccessControl(rs);
            //    }
            //}


            //当前程序名称
            var exeName = Process.GetCurrentProcess().ProcessName + ".exe";
            //系统注册表信息
            var mreg = Registry.LocalMachine;
            //IE注册表信息
            var ie = mreg.OpenSubKey(path, RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (ie != null)
            {
                try
                {
                    if (ie.GetValue(exeName) == null)
                    {

                        //var val = ieVersionEmulation(ieVersion());
                        var val = ieVersionEmulation((new WebBrowser()).Version.Major);
                        if (val != 0)
                        {
                            ie.SetValue(exeName, val);
                        }
                        mreg.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }

        /// <summary>
        /// IE版本号
        /// </summary>
        /// <returns></returns>
        static int ieVersion()
        {
            //IE版本号
            RegistryKey mreg = Registry.LocalMachine;
            mreg = mreg.CreateSubKey("SOFTWARE\\Microsoft\\Internet Explorer");

            //更新版本
            var svcVersion = mreg.GetValue("svcVersion");
            if (svcVersion != null)
            {
                mreg.Close();
                var v = svcVersion.ToString().Split('.')[0];
                return int.Parse(v);
            }
            else
            {
                //默认版本
                var ieVersion = mreg.GetValue("Version");
                mreg.Close();
                if (ieVersion != null)
                {
                    var v = ieVersion.ToString().Split('.')[0];
                    return int.Parse(v);
                }
            }
            return 0;
        }

        /// <summary>
        /// 根据IE版本号 返回Emulation值
        /// </summary>
        /// <param name="ieVersion"></param>
        /// <returns></returns>
        static int ieVersionEmulation(int ieVersion)
        {
            //IE7 7000 (0x1B58)
            if (ieVersion < 8)
            {
                return 0;
            }
            if (ieVersion == 8)
            {
                return 0x1F40;//8000 (0x1F40)、8888 (0x22B8)
            }
            if (ieVersion == 9)
            {
                return 0x2328;//9000 (0x2328)、9999 (0x270F)
            }
            else if (ieVersion == 10)
            {
                return 0x02710;//10000 (0x02710)、10001 (0x2711)
            }
            else if (ieVersion == 11)
            {
                return 0x2AF8;//11000 (0x2AF8)、11001 (0x2AF9
            }
            return 0;
        }


        #endregion

        #region DataGridView方法

        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        public static void dgv_add_hanghao(DataGridView dgv, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);
        }

        /// <summary>
        /// 设置显示的内容，仅支持状态、时间，最后两个参数，如果为空则不设置
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        /// <param name="col_state">dgv中的字段名</param>
        /// <param name="col_date">dgv中的字段名</param>
        public static void dgv_set_show(DataGridView dgv, DataGridViewCellFormattingEventArgs e, string col_state, string col_date)
        {
            //设置单元格内容&转换
            try
            {
                if (e.Value != null)
                {
                    if (dgv.DataSource != null)
                    {
                        if (!string.IsNullOrEmpty(col_state))
                        {
                            if (dgv.Columns[e.ColumnIndex].Name.Equals(col_state))
                            {
                                string name = e.Value.ToString();
                                e.Value = name == "1" ? "启用" : "禁用";
                            }
                        }
                        if (!string.IsNullOrEmpty(col_date))
                        {
                            if (dgv.Columns[e.ColumnIndex].Name.Equals(col_date))
                            {
                                string temp = e.Value.ToString();
                                DateTime temp_date;
                                if (DateTime.TryParse(temp, out temp_date))
                                {
                                    e.Value = temp_date.ToString("yyyy-MM-dd");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString().ToLog();
            }
        }

        /// <summary>
        /// 设置全选
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="e"></param>
        public static void dgv_set_selectall(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            //如果点击页头
            if (e.RowIndex == -1)
            {
                //如果是全选
                if (e.ColumnIndex == 0)
                {
                    bool isclose = false;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            if (cbx.Value == null)
                            {
                                cbx.Value = true;
                            }
                            else
                            {
                                isclose = true;
                                break;
                            }
                        }
                    }
                    if (isclose)
                    {
                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            if (row.Index != -1)
                            {
                                DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                                cbx.Value = null;
                            }
                        }
                    }
                }

                //排序事件
                try
                {
                    //dgv1.Sort(dgv1.Columns[e.ColumnIndex], ListSortDirection.Descending);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("排序出错=========================" + ex.Message);
                }
            }
        }

        #endregion

        #region 打开选择文件窗口，返回流
        /// <summary>
        /// 打开选择文件窗口，返回流
        /// </summary>
        /// <param name="filter">显示的文件格式 Execl files (*.xls)|*.xls</param>
        /// <returns></returns>
        public static Stream OpenFileDialog(string filter)
        {
            Stream myStream = null;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //txt files(*.txt)|*.txt|All files(*.*)|*.*
            //Execl files (*.xls)|*.xls
            saveFileDialog.Filter = filter;
            saveFileDialog.FilterIndex = 0;
            //设置对话关闭前，还原当前目录
            saveFileDialog.RestoreDirectory = true;
            //如果文件不存在，则创建
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "请选择";
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr != DialogResult.OK)
            {
                return myStream;
            }
            //获得文件路径
            //localFilePath = saveFileDialog1.FileName.ToString();

            //获取文件名，不带路径
            //fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);

            //获取文件路径，不带文件名
            //FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("\\"));

            //给文件名前加上时间
            //newFileName = DateTime.Now.ToString("yyyyMMdd") + fileNameExt;

            //在文件名里加字符
            //saveFileDialog1.FileName.Insert(1,"dameng");

            //System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();//输出文件

            myStream = saveFileDialog.OpenFile();
            return myStream;
        }

        /// <summary>
        /// 选择文件夹，返回路径
        /// </summary>
        /// <param name="SelectedPath">获取其开始浏览的根目录，空则默认原来的文件夹</param>
        /// <returns></returns>
        public static string OpenFolderDialog(string SelectedPath)
        {
            string path = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            //获取其开始浏览的根目录
            //folderBrowserDialog1.RootFolder = Environment.SpecialFolder.AdminTools;
            if (!string.IsNullOrEmpty(SelectedPath))
            {
                folderBrowserDialog1.SelectedPath = SelectedPath;
            }
            else
            {
                folderBrowserDialog1.SelectedPath = CS.XMLHelper.GetValue("OpenFolderDialog_SelectedPath");
            }
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                if (folderBrowserDialog1.SelectedPath.Trim() != "")
                {
                    path = folderBrowserDialog1.SelectedPath.Trim();
                    CS.XMLHelper.SetValue("OpenFolderDialog_SelectedPath", path);
                }
            }
            return path;
        }
        #endregion


        #region String

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="str"></param>
        public static void ToLog(this string str)
        {
            WriteLog(str);
        }

        /// <summary>
        /// 填出窗口
        /// </summary>
        /// <param name="str"></param>
        public static void ToShow(this string str)
        {
            MessageBox.Show(str);
        }

        /// <summary>
        /// 把文字保存到txt
        /// </summary>
        /// <param name="str"></param>
        public static void ToSave(this string str, string path, string filename)
        {
            StreamWriter sw = Manager.CreateFile(path, filename + ".txt");
            sw.WriteLine(str);
            sw.Close();
        }

        #endregion

        #region ListView



        /// <summary>
        /// 添加ListView控件方法，直接显示文件夹图片
        /// </summary>
        /// <param name="listView1"></param>
        /// <param name="fileurl">文件夹路径</param>
        /// <param name="size">图片显示的大小默认是200</param>
        /// <returns></returns>
        public static bool ToShowImages(this ListView listView1, string fileurl, Size size)
        {
            bool res = false;
            if (string.IsNullOrEmpty(fileurl))
                return res;
            if (size == null)
                size = new Size(200, 200);
            try
            {
                DirectoryInfo TheFolder = new DirectoryInfo(fileurl);//文件路径
                ImageList imageList1 = new ImageList();
                //解决ListView中图片显示失真的问题
                imageList1.ColorDepth = ColorDepth.Depth32Bit;

                imageList1.ImageSize = size;
                List<string> tifNames = new List<string>();
                for (int i = 0; i < TheFolder.GetFiles().Length; i++)//遍历文件夹
                {
                    if (TheFolder.GetFiles()[i].Length > 0)//或者jpg,png 文件大小要大于0且是图片文件
                    {
                        string houzhui = TheFolder.GetFiles()[i].Extension.ToLower();
                        if (houzhui == ".jpg" || houzhui == ".png" || houzhui == ".gif" || houzhui == ".tbi")//或者jpg,png 文件大小要大于0且是图片文件
                        {
                            string fp = TheFolder.GetFiles()[i].DirectoryName + "\\" + TheFolder.GetFiles()[i].Name;
                            Image image = Image.FromFile(fp);    //获取图片文件                
                            tifNames.Add(fp);//添加文件名
                            imageList1.Images.Add(image);//添加图片
                        }
                    }
                }
                //初始化设置
                listView1.View = View.LargeIcon;
                listView1.LargeImageList = imageList1;

                //listView1.View = View.Tile;
                //listView1.StateImageList = imageList1;


                //开始绑定
                listView1.BeginUpdate();

                for (int i = 0; i < tifNames.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();

                    lvi.ImageIndex = i;

                    lvi.Text = tifNames[i];

                    listView1.Items.Add(lvi);
                }

                listView1.EndUpdate();
            }
            catch
            {
                res = false;
            }
            res = true;
            return res;
        }

        /// <summary>
        /// 添加ListView控件方法，追加显示一张图片
        /// </summary>
        /// <param name="listView1"></param>
        /// <param name="filepath"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool ToShowImage(this ListView listView1, string filepath, Size size)
        {
            if (string.IsNullOrEmpty(filepath))
                return false;
            if (size == null)
                size = new Size(200, 200);
            try
            {
                //DirectoryInfo TheFolder = new DirectoryInfo(fileurl);//文件路径
                ImageList imageList1 = listView1.LargeImageList == null ? new ImageList() : listView1.LargeImageList;
                imageList1.ColorDepth = ColorDepth.Depth32Bit;
                imageList1.ImageSize = size;
                Image image = Image.FromFile(filepath);
                imageList1.Images.Add(image);//添加图片
                //获取图片名称
                FileInfo file = new FileInfo(filepath);
                string filename = file.Name;

                //初始化设置
                listView1.View = View.LargeIcon;

                listView1.LargeImageList = imageList1;

                //开始绑定
                listView1.BeginUpdate();

                ListViewItem lvi = new ListViewItem();
                lvi.ImageIndex = listView1.Items.Count;
                lvi.Text = filepath;
                listView1.Items.Add(lvi);

                listView1.EndUpdate();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除某个图片
        /// </summary>
        /// <param name="listView1"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool ToDeleteImage(this ListView listView1, ListViewItem item)
        {
            try
            {
                //string filepath = CS.XMLHelper.GetValue("OpenFolderDialog_SelectedPath") + "//" + item.Text;
                //DirectoryInfo TheFolder = new DirectoryInfo(fileurl);//文件路径
                ImageList imageList1 = listView1.LargeImageList == null ? new ImageList() : listView1.LargeImageList;
                //Image image = Image.FromFile(filepath);
                //imageList1.Images.Add(image);//添加图片
                ImageList imageList2 = new ImageList();//新的图片列表
                imageList2.ImageSize = imageList1.ImageSize;

                //foreach (Image img in imageList1.Images)
                //{
                //    if (img!= image)
                //        imageList2.Images.Add(img);
                //}

                //for (int i = 0; i < imageList1.Images.Count; i++)
                //{
                //    if (i != item.Index)
                //    {
                //        imageList2.Images.Add(imageList1.Images[i]);
                //    }
                //}

                //获取图片名称
                //FileInfo file = new FileInfo(filepath);
                //string filename = file.Name;


                //从新获取文件名列表
                List<string> tifNames = new List<string>();
                foreach (ListViewItem it in listView1.Items)
                {
                    if (it.Text != item.Text)
                    {
                        tifNames.Add(it.Text);
                        Image image2 = Image.FromFile(it.Text);  //获取图片文件                
                        imageList2.Images.Add(image2);//添加图片
                    }
                }
                //初始化设置
                listView1.View = View.LargeIcon;
                listView1.LargeImageList = imageList2;
                //清空
                listView1.Items.Clear();

                //删除item
                //listView1.Items.Remove(item);
                //开始绑定
                listView1.BeginUpdate();

                for (int i = 0; i < tifNames.Count; i++)
                {
                    ListViewItem lvi = new ListViewItem();

                    lvi.ImageIndex = i;

                    lvi.Text = tifNames[i];

                    listView1.Items.Add(lvi);
                }

                listView1.EndUpdate();




            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region PictureBox

        /// <summary>
        /// PictureBox添加自适应尺寸的背景图片
        /// </summary>
        /// <param name="pb"></param>
        /// <param name="img"></param>
        /// <returns></returns>
        public static bool ToShowBackgroundImage_Auto(this PictureBox pb, Image img)
        {
            if (img == null)
                return false;
            pb.BackgroundImageLayout = ImageLayout.Stretch;
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.BackgroundImage = img;
            return true;
        }

        #endregion

        #region Controls

        #region 根据指定容器和控件名字，获得控件
        /// <summary>
        /// 根据指定容器和控件名字，获得控件
        /// </summary>
        /// <param name="cc">Control.ControlCollection,就是比如this.Controls或者span.Controls,所有空间集合</param>
        /// <param name="strControlName">控件名字</param>
        /// <returns>控件</returns>
        public static object GetControlByName(this Control.ControlCollection cc, string strControlName)
        {
            IEnumerator Controls = null;//所有控件
            Control c = null;//当前控件
            Object cResult = null;//查找结果

            Controls = cc.GetEnumerator();
            //if (obj.GetType() == this.GetType())//窗体
            //{
            //    Controls = this.Controls.GetEnumerator();
            //}
            //else//控件
            //{
            //    Controls = ((Control)obj).Controls.GetEnumerator();
            //}
            while (Controls.MoveNext())//遍历操作
            {
                c = (Control)Controls.Current;//当前控件
                if (c.HasChildren)//当前控件是个容器
                {
                    if (c.Name == strControlName)//是容器，返回
                    {
                        return c;
                    }

                    cResult = GetControlByName(c.Controls, strControlName);//递归查找
                    if (cResult == null)//当前容器中没有，跳出，继续查找
                    {
                        continue;
                    }
                    else//找到控件，返回
                        return cResult;
                }
                else if (c.Name == strControlName)//不是容器，同时找到控件，返回
                {
                    return c;
                }
            }
            return null;//控件不存在
        }
        #endregion

        #region 网上原始方法


        /// <summary>
        /// 根据指定容器和控件名字，获得控件
        /// </summary>
        /// <param name="obj">容器</param>
        /// <param name="strControlName">控件名字</param>
        /// <returns>控件</returns>
        private static object GetControlByNames(object obj, string strControlName)
        {
            //IEnumerator Controls = null;//所有控件
            //Control c = null;//当前控件
            //Object cResult = null;//查找结果
            //if (obj.GetType() == this.GetType())//窗体
            //{
            //    Controls = this.Controls.GetEnumerator();
            //}
            //else//控件
            //{
            //    Controls = ((Control)obj).Controls.GetEnumerator();
            //}
            //while (Controls.MoveNext())//遍历操作
            //{
            //    c = (Control)Controls.Current;//当前控件
            //    if (c.HasChildren)//当前控件是个容器
            //    {
            //        if (c.Name == strControlName)//是容器，返回
            //        {
            //            return c;
            //        }

            //        cResult = GetControlInstance(c, strControlName);//递归查找
            //        if (cResult == null)//当前容器中没有，跳出，继续查找
            //        {
            //            continue;
            //        }
            //        else//找到控件，返回
            //            return cResult;
            //    }
            //    else if (c.Name == strControlName)//不是容器，同时找到控件，返回
            //    {
            //        return c;
            //    }
            //}
            return null;//控件不存在
        }
        #endregion

        #region 获取所有PictureBox
        /// <summary>
        /// 获取所有PictureBox控件
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public static List<PictureBox> GetPictureBoxs(this Control.ControlCollection cc)
        {
            List<PictureBox> list = new List<PictureBox>();
            foreach (Control control in cc)
            {
                if (control is PictureBox)
                {
                    list.Add((PictureBox)control);
                }
                if (control.Controls.Count > 0)
                {
                    GetPictureBoxs(control.Controls);
                }
            }
            return list;
        }
        #endregion

        #endregion

        #region DataTable


        #region MyRegion

        #region toDelete
        /// <summary>
        /// 删除符合条件的数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable toDelete(this DataTable dt, List<DataRow> list)
        {
            DataTable dt_res = dt.Clone();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!list.Contains(dr))
                    {

                        DataRow dr_res = dt_res.NewRow();
                        int i = 0;
                        foreach (object cell in dr.ItemArray)
                        {
                            dr_res[i] = cell;
                            i++;
                        }
                        if (!string.IsNullOrEmpty(dr_res[0].ToString()))
                            dt_res.Rows.Add(dr_res);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("excel删除数据时出错" + e.Message + e.Source);
            }
            return dt_res;
        }
        #endregion

        #region toDelete
        /// <summary>
        /// 删除符合条件的数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable toDelete(this DataTable dt, DataRow drs)
        {
            DataTable dt_res = dt.Clone();
            try
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (drs != dr)
                    {
                        DataRow dr_res = dt_res.NewRow();
                        int i = 0;
                        foreach (object cell in dr.ItemArray)
                        {
                            dr_res[i] = cell;
                            i++;
                        }
                        if (!string.IsNullOrEmpty(dr_res[0].ToString()))
                            dt_res.Rows.Add(dr_res);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("excel删除数据时出错" + e.Message + e.Source);
            }
            return dt_res;
        }
        #endregion


        #endregion

        #endregion

        #region Image

        /// <summary>
        /// Image直接提取MD5
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string ToGetMD5Hash(this Image img)
        {
            ImageConverter imgconv = new ImageConverter();
            byte[] b = (byte[])imgconv.ConvertTo(img, typeof(byte[]));
            Stream stream = new MemoryStream(b);
            try
            {
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(stream);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail, error:" + ex.Message);
            }

        }

        #region ToChangeMD5
        /// <summary>
        /// 更换MD5
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Image ToChangeMD5(this Image img)
        {
            Bitmap bmp = (Bitmap)img;
            //创建3个随机位置
            Random random = new Random();
            int w1 = random.Next(1, img.Width - 1);
            int w2 = random.Next(1, img.Width - 1);
            int w3 = random.Next(1, img.Width - 1);
            int h1 = random.Next(1, img.Height - 1);
            int h2 = random.Next(1, img.Height - 1);
            int h3 = random.Next(1, img.Height - 1);

            //创建3个随机像素颜色
            Color c1 = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            Color c2 = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
            Color c3 = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));

            //绘制到img中
            bmp.SetPixel(w1, h1, c1);
            bmp.SetPixel(w2, h2, c2);
            bmp.SetPixel(w3, h3, c3);

            img = (Image)bmp;
            //Bitmap bmp = new Bitmap(700, 550);                      //改图只显示最近输入的700个点的数据曲线。
            //                                                        //  Graphics graphics = Graphics.FromImage(bmp);
            //                                                        //   SolidBrush brush1 = new SolidBrush(Color.FromArgb(255, 0, 0));
            //                                                        //   graphics.FillRectangle(brush1, 0, 0, 700, 550);//Brushes.Sienna
            //for (int i = 0; i < bmp.Width; i++)
            //    for (int j = 0; j < bmp.Height; j++)
            //    {
            //        Color c = Color.FromArgb((i / 400) * 255, (j / 300) * 255, 0);
            //        bmp.SetPixel(i, j, c);
            //        bmp.SetPixel(i,j,)
            //    }
            //bmp.Save("c:\\11.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);//指定图片格式   
            //bmp.Dispose();
            ////    graphics.Dispose();
            ////    brush1.Dispose();//一定释放内存。
            return img;
        }
        #endregion

        /// <summary>
        /// 根据图片src地址,获得图片,然后保存
        /// </summary>
        /// <param name="url"></param>
        /// <param name="allname"></param>
        public static void ToImageSave(this string url, string allname, int flag = 85)
        {
            try
            {
                Image img = url.ToImageByWebBrowser();
                if (img != null)
                {
                    if (flag != 100)
                    {
                        img = Common.ImageClass.ImageMake(img, 0, 0, flag, false, false);
                    }
                    img.ToChangeMD5().Save(allname);

                }
            }
            catch (Exception ex)
            {
                ("通过webBrowser保存图片报错" + ex.ToString()).ToShow();
            }
        }

        #endregion

        #region 窗口显示


        #region RunningInstance
        /// <summary>
        /// 获取当前运行的实例
        /// </summary>
        /// <returns></returns>
        public static Process RunningInstance()
        {
            var currentProcess = Process.GetCurrentProcess();
            var processes = Process.GetProcessesByName(currentProcess.ProcessName);
            foreach (var process in processes)
            {
                if (process.Id == currentProcess.Id)
                {
                    return process;
                    //continue;
                }
                if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == currentProcess.MainModule.FileName)
                {
                    //return process;
                }
            }
            return null;
        }
        #endregion

        /// <summary>
        /// 展示实例
        /// </summary>
        /// <param name="instance"></param>
        private static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, SwShownomal);   //显示    
            SetForegroundWindow(instance.MainWindowHandle); //当到最前端    
        }

        /// <summary>
        /// 该函数设置由不同线程产生的窗口的显示状态
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="cmdShow">指定窗口如何显示。查看允许值列表，请查阅ShowWlndow函数的说明部分</param>
        /// <returns>如果函数原来可见，返回值为非零；如果函数原来被隐藏，返回值为零</returns>
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);

        /// <summary>    
        ///  该函数将创建指定窗口的线程设置到前台，并且激活该窗口。键盘输入转向该窗口，并为用户改各种可视的记号。    
        ///  系统给创建前台窗口的线程分配的权限稍高于其他线程。     
        /// </summary>    
        /// <param name="hWnd">将被激活并被调入前台的窗口句柄</param>    
        /// <returns>如果窗口设入了前台，返回值为非零；如果窗口未被设入前台，返回值为零</returns>    
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int SwShownomal = 1;

        /// <summary>
        /// 设置窗口置顶显示
        /// </summary>
        public static void SetShowAndTop()
        {
            var process = RunningInstance();
            if (process != null)
            {
                HandleRunningInstance(process);
                //Environment.Exit(1);
            }
        }

        #endregion

        #region Email

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="email"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public static void EmailSend(string email, string title, string content)
        {
            try
            {
                SmtpClient smtp = new SmtpClient(); //实例化一个SmtpClient
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; //将smtp的出站方式设为 Network
                smtp.EnableSsl = false;//smtp服务器是否启用SSL加密
                smtp.Host = "smtp.163.com"; //指定 smtp 服务器地址
                smtp.Port = 25;             //指定 smtp 服务器的端口，默认是25，如果采用默认端口，可省去
                                            //如果你的SMTP服务器不需要身份认证，则使用下面的方式，不过，目前基本没有不需要认证的了
                smtp.UseDefaultCredentials = true;
                //如果需要认证，则用下面的方式
                smtp.Credentials = new NetworkCredential(CS.XMLHelper.GetValue("Email_Account"), CS.XMLHelper.GetValue("Email_Pwd"));
                MailMessage mm = new MailMessage(); //实例化一个邮件类
                mm.Priority = MailPriority.High; //邮件的优先级，分为 Low, Normal, High，通常用 Normal即可
                mm.From = new MailAddress(CS.XMLHelper.GetValue("Email_Account"), title, Encoding.GetEncoding(936));
                //收件方看到的邮件来源；
                //第一个参数是发信人邮件地址
                //第二参数是发信人显示的名称
                //第三个参数是 第二个参数所使用的编码，如果指定不正确，则对方收到后显示乱码
                //936是简体中文的codepage值
                //mm.ReplyTo = new MailAddress(CS.XMLHelper.GetValue("Email_Account"), "我的接收邮箱", Encoding.GetEncoding(936));
                mm.To.Add(new MailAddress(email, "接收者g", Encoding.GetEncoding(936)));
                mm.Subject = title; //邮件标题
                mm.SubjectEncoding = Encoding.GetEncoding(936);
                // 这里非常重要，如果你的邮件标题包含中文，这里一定要指定，否则对方收到的极有可能是乱码。
                // 936是简体中文的pagecode，如果是英文标题，这句可以忽略不用
                mm.IsBodyHtml = true; //邮件正文是否是HTML格式
                mm.BodyEncoding = Encoding.GetEncoding(936);
                //邮件正文的编码， 设置不正确， 接收者会收到乱码

                mm.Body = content;
                //邮件正文
                // mm.Attachments.Add(new Attachment(@"d:a.doc", System.Net.Mime.MediaTypeNames.Application.Rtf));
                //添加附件，第二个参数，表示附件的文件类型，可以不用指定
                //可以添加多个附件
                //mm.Attachments.Add(new Attachment(@"d:b.doc"));
                smtp.Send(mm); //发送邮件，如果不返回异常， 则大功告成了。
            }
            catch (Exception ex)
            {
                CS.ErrorLog.WriteEntry(ex);
                //MessageBox.Show("Email发送失败: " + ex.ToString());
            }
        }
        #endregion 

        #region List
        /// <summary>
        /// 去除列表中的重复数据
        /// </summary>
        /// <param name="list_temp"></param>
        /// <returns></returns>
        public static List<string> RemoveRepeat(this List<string> list_temp)
        {
            //获取操作过的字段集合
            List<string> list_ok = new List<string>();

            int num = 0;

            //开始遍历清除重复数据
            //遍历要操作的集合
            foreach (string obj in list_temp)
            {
                num++;
                //是否应该添加该字段
                bool isadd = true;
                //判断操作集合里是否有这个字段，如果没有则加入，如果有则跳过
                foreach (string obj2 in list_ok)
                {
                    //如果有则跳出，不添加
                    if (obj == obj2)
                    {
                        isadd = false;
                        break;
                    }
                }
                //根据字段判断是否应该添加
                if (isadd)
                {
                    list_ok.Add(obj);
                }
            }
            return list_ok;
        }



        /// <summary>
        /// 去除列表中的重复数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list_temp"></param>
        /// <returns></returns>
        public static List<T> RemoveRepeat<T>(this List<T> list_temp) where T : class, new()
        {
            //获取操作过的字段集合
            List<T> list_ok = new List<T>();

            int num = 0;

            //开始遍历清除重复数据
            //遍历要操作的集合
            foreach (T obj in list_temp)
            {
                num++;
                //是否应该添加该字段
                bool isadd = true;
                //判断操作集合里是否有这个字段，如果没有则加入，如果有则跳过
                foreach (T obj2 in list_ok)
                {
                    //如果有则跳出，不添加
                    if (obj == obj2)
                    {
                        isadd = false;
                        break;
                    }
                }
                //根据字段判断是否应该添加
                if (isadd)
                {
                    list_ok.Add(obj);
                }
            }
            return list_ok;

        }

        /// <summary>
        /// 反转排序
        /// </summary>
        /// <param name="list_temp"></param>
        /// <returns></returns>
        public static List<string> ToSortReverse(this List<string> list_temp)
        {
            //获取操作过的字段集合
            List<string> list_ok = new List<string>();

            //遍历要操作的集合
            foreach (string obj in list_temp)
            {
                list_ok.Add(obj);
            }
            return list_ok;
        }

        /// <summary>
        /// 把decimal类型的列表直接输出出来
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToStringZJ(this List<decimal> list)
        {
            string res = "";
            foreach (decimal d in list)
            {
                res += "-" + d.ToString();
            }
            return res;
        }

        #endregion

        #region ChromiumWebBrowser

        /// <summary>
        /// 在 ChromiumWebBrowser 中操作JS代码
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="js"></param>
        /// <returns></returns>
        public static string ToJs(this ChromiumWebBrowser wb, string js)
        {
            return Browser.JS_CEFBrowser(js, wb);
        }

        /// <summary>
        /// 在 ChromiumWebBrowser 中鼠标点击元素
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="js"></param>
        /// <returns></returns>
        public static void ToMouseClick(this ChromiumWebBrowser wb, string element)
        {
            Browser.MouseLeftByHtmlElement(element, wb);
        }

        /// <summary>
        /// 在 ChromiumWebBrowser 中操作JS代码,返回Int
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="js"></param>
        /// <returns></returns>
        public static int ToJsInt(this ChromiumWebBrowser wb, string js)
        {
            return Browser.JS_CEFBrowserToInt(js, wb);
        }

        /// <summary>
        /// 在 ChromiumWebBrowser 中操作JS代码,返回datetime
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="js"></param>
        /// <returns></returns>
        public static DateTime ToJsDate(this ChromiumWebBrowser wb, string js)
        {
            return Browser.JS_CEFBrowserToDate(js, wb);
        }

        /// <summary>
        /// 在 ChromiumWebBrowser 中 判断是否有该元素
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="js"></param>
        /// <returns></returns>
        public static bool ToJsHasElementToBool(this ChromiumWebBrowser wb, string js)
        {
            return Browser.JS_CEFBrowserHasElementToBool(js, wb);
        }

        /// <summary>
        /// 在 ChromiumWebBrowser 中 判断是js 是否返回Bool
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="js"></param>
        /// <returns></returns>
        public static bool ToBool(this ChromiumWebBrowser wb, string js)
        {
            return Browser.JS_CEFBrowserToBool(js, wb);
        }

        /// <summary>
        /// 初始化ChromiumWebBrowser
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="c"></param>
        public static void ToInit(this ChromiumWebBrowser wb)
        {
            //wb = new CefSharp.WinForms.ChromiumWebBrowser("http://www.baidu.com");
            //wb.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //wb.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //wb.Size = new Size(c.Size.Width - 20, c.Size.Height - 110); //new Size(1070, 500);
            //wb.Location = new Point(10, 100);
            //wb.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        }

        /// <summary>
        /// 初始化ChromiumWebBrowser
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="c"></param>
        public static void ToInit(this ChromiumWebBrowser wb, Control c)
        {
            //wb = new CefSharp.WinForms.ChromiumWebBrowser("http://www.baidu.com");
            wb.FrameLoadStart += Browser.BrowserFrameLoadStart;
            wb.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            wb.Size = new Size(c.Size.Width - 20, c.Size.Height - 110); //new Size(1070, 500);
            wb.Location = new Point(10, 100);
            wb.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            c.Controls.Add(wb);
        }

        /// <summary>
        /// 选中元素
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="wb"></param>
        public static void ToSelectElement(this ChromiumWebBrowser wb, string ele)
        {
            try
            {
                Browser.JS_CEFBrowser("setSelectRange(" + ele + ")", wb);
                wb.Parent.Focus();
                wb.Focus();
            }
            catch (Exception e)
            {
                Manager.WriteLog("谷歌浏览器执行不返回值的JS脚本出错：" + e.ToString());
            }
        }

        /// <summary>
        /// 等在浏览器加载完毕
        /// </summary>
        /// <param name="wb"></param>
        public static bool ToWait(this ChromiumWebBrowser wb)
        {
            return Browser.WaitWebPageLoad(wb);
        }

        /// <summary>
        /// 等在浏览器加载完毕
        /// </summary>
        /// <param name="wb"></param>
        public static bool ToWait(this ChromiumWebBrowser wb, string ele, int times = 5000)
        {
            return Browser.WaitWebPageLoad(ele, times, wb);
        }

        /// <summary>
        /// 等在浏览器加载完毕
        /// </summary>
        /// <param name="wb"></param>
        public static bool ToWait(this ChromiumWebBrowser wb, string ele, string judge, int times = 5000)
        {
            if (Browser.WaitWebPageLoad(ele, times, wb))
            {
                DateTime dt = DateTime.Now.AddSeconds(times / 1000);
                while (!wb.ToBool(judge))
                {
                    if (dt < DateTime.Now)
                    {
                        return false;
                    }
                    Delay(500);
                }
            }
            return true;
        }

        /// <summary>
        /// 等在浏览器加载完毕
        /// </summary>
        /// <param name="wb"></param>
        public static bool ToWaitBool(this ChromiumWebBrowser wb, string judge, int times = 5000)
        {
            DateTime dt = DateTime.Now.AddSeconds(times / 1000);
            while (!wb.ToBool(judge))
            {
                if (dt < DateTime.Now)
                {
                    return false;
                }
                Delay(500);
            }
            return true;
        }

        /// <summary>
        /// 判断图片是否加载完成
        /// </summary>
        /// <param name="wb"></param>
        public static bool ToImageComplete(this ChromiumWebBrowser wb, string ele)
        {
            bool res = false;
            string ress = wb.ToJs(ele + ".complete");
            if (!string.IsNullOrEmpty(ress))
            {
                if (ress.ToUpper() == "TRUE")
                {
                    res = true;
                }
            }
            return res;
        }

        /// <summary>
        /// 采用剪贴板复制的方法,获取浏览器中的图片
        /// </summary>
        /// <param name="wb"></param>
        public static Image ToImage(this ChromiumWebBrowser wb, string ele)
        {
            Image img = null;
            //wb.ToImageComplete(ele);
            //等待图片加载完成
            if (wb.ToImageWaitLoad(ele))
            {
                //选中图片复制
                wb.ToSelectElement(ele);
                //等待图片复制完成
                ClipboardToWaitHasHtml();
                //获取图片
                img = ClipboardGetImgFromHTML();
            }
            return img;
        }

        /// <summary>
        /// 等待图片加载
        /// </summary>
        /// <param name="wb"></param>
        public static bool ToImageWaitLoad(this ChromiumWebBrowser wb, string ele, int times = 5000)
        {
            bool res = false;
            DateTime dt = DateTime.Now;
            try
            {
                while (true)
                {
                    Browser.Delay(200);
                    if (wb.ToImageComplete(ele))
                    {
                        return true;
                    }
                    else if (dt.AddMilliseconds(times) < DateTime.Now)
                    {
                        "时间已到,但图片没有加载完,跳出".ToLog();
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString().ToLog();
            }
            return res;
        }

        /// <summary>
        /// 移动鼠标到元素
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="ele"></param>
        public static void ToMouseMoveByHtmlElement(this ChromiumWebBrowser wb, string ele)
        {
            Browser.MouseMoveByHtmlElement(ele, wb);
        }

        /// <summary>
        /// 移动滑动条到显示元素
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="ele"></param>
        public static void ToShowElement(this ChromiumWebBrowser wb, string ele)
        {
            Browser.SetScrollByHtmlElement(ele, wb);
        }

        /// <summary>
        /// 移动滑动条到页面底部
        /// </summary>
        /// <param name="wb"></param>
        public static void ToBottom(this ChromiumWebBrowser wb)
        {
            wb.ToJs(" window.scrollTo(0," + wb.ToJsInt("document.body.clientHeight") + ") ");
        }

        /// <summary>
        /// 移动滑动条到页面底部
        /// </summary>
        /// <param name="wb"></param>
        public static void ToBottom(this ChromiumWebBrowser wb, int times, int count)
        {
            Browser.ScrollToBottom(times, count, wb);
        }

        /// <summary>
        /// 移动滑动条到页面底部
        /// </summary>
        /// <param name="wb"></param>
        /// <param name="times"></param>
        /// <param name="count"></param>
        /// <param name="height"></param>
        public static void ToBottom(this ChromiumWebBrowser wb, int times, int count, int height)
        {
            int temp = 100;
            for (int i = 0; i < count; i++)
            {
                temp = temp + height;
                wb.ToJs(" window.scrollTo(0," + temp.ToString() + ") ");
                Browser.Delay(times);
            }
        }



        #endregion

        #region Clipboard
        /// <summary>
        /// 等待剪贴板中是否有HTML数据,如果没有则等待,默认5000,如果有则返回String 数据,如果没有返回空
        /// </summary>
        /// <param name="times"></param>
        /// <returns></returns>
        public static string ClipboardToWaitHasHtml(int times = 5000)
        {
            string res = "";
            DateTime dt = DateTime.Now;
            try
            {
                while (true)
                {
                    Browser.Delay(200);
                    if (Clipboard.ContainsData(DataFormats.Html))
                    {
                        res = Clipboard.GetData(DataFormats.Html).ToString();
                        return res;
                    }
                    else if (dt.AddMilliseconds(times) < DateTime.Now)
                    {
                        WriteLog("时间已到,但剪贴板中无HTML数据,跳出");
                        return res;
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex.ToString());
            }
            return res;
        }

        /// <summary>
        /// 根据剪贴板中的HTML代码,提取Image
        /// </summary>
        /// <returns></returns>
        public static Image ClipboardGetImgFromHTML()
        {
            Image img = null;
            if (Clipboard.ContainsData(DataFormats.Html))
            {
                //将剪切板中的内容先转为HTML,再转成图片
                string html = Clipboard.GetData(DataFormats.Html).ToString();
                string[] res = CS.HTMLHelper.GetHtmlImageUrlList(html);
                string ss = res[0];
                img = CS.ImageClass.Base64StringToImage(ss);
            }
            return img;
        }


        /// <summary>
        /// 把内存中的html类型的数据转化成image
        /// </summary>
        public static Image ClipboardToImageByHTML()
        {
            Image image = null;

            try
            {
                WebBrowser wb = new WebBrowser();
                //将剪切板中的内容先转为HTML,再转成图片
                string html = Clipboard.GetData(DataFormats.Html).ToString();
                //去除HTML文件中的文件源信息部分
                html = html.Substring(html.IndexOf("<html"));
                //webBrowser = new System.Windows.Forms.WebBrowser();
                //是否显式滚动条
                wb.ScrollBarsEnabled = false;
                //加载 html
                wb.DocumentText = html;
                //加载完成
                Browser.WaitWebPageLoad(wb);
                //提取image
                HtmlDocument doc = wb.Document;
                HtmlElementCollection hec = doc.GetElementsByTagName("img");
                HtmlElement current = hec[0];
                image = wb.GetImage(current);
            }
            catch
            {

            }
            return image;
        }

        #endregion

        #region WebBrowser

        /// <summary>
        /// 获取图像内容
        /// </summary>
        /// <param name="browser">显示图像的浏览器控件</param>
        /// <param name="imgElement">从浏览器中读取到的img</param>
        public static Image GetImage(this WebBrowser browser, HtmlElement imgElement)
        {
            HTMLDocument doc = (HTMLDocument)browser.Document.DomDocument;
            HTMLBody body = (HTMLBody)doc.body;
            IHTMLControlRange rang = (IHTMLControlRange)body.createControlRange();
            IHTMLControlElement img = (IHTMLControlElement)(imgElement.DomElement);
            rang.add(img);
            rang.execCommand("Copy", false, null);
            Image regImg = Clipboard.GetImage();
            Clipboard.Clear();
            return regImg;
        }

        /// <summary>
        /// 等在浏览器加载完毕
        /// </summary>
        /// <param name="wb"></param>
        public static bool ToWait(this WebBrowser wb)
        {
            return Browser.WaitWebPageLoad(wb);
        }

        /// <summary>
        /// 根据图片的src,显示到WebBrowser中,然后提取Image
        /// </summary>
        /// <param name="src">图片的src</param>
        /// <returns></returns>
        public static Image ToImageByWebBrowser(this string src)
        {
            Image image = null;

            try
            {
                WebBrowser wb = new WebBrowser();
                wb.Navigate(src);
                //是否显式滚动条
                wb.ScrollBarsEnabled = false;
                wb.ToWait();

                //提取image
                HtmlDocument doc = wb.Document;
                HtmlElementCollection hec = doc.GetElementsByTagName("img");
                HtmlElement current = hec[0];
                image = wb.GetImage(current);
            }
            catch (Exception ex)
            {
                ("根据图片的src,显示到WebBrowser中,然后提取Image,失败;;" + ex.ToString()).ToLog();
            }
            return image;
        }

        #endregion

        #region ClearCache

        /// <summary>
        /// 清空缓存
        /// </summary>
        public static void ClearCache()
        {
            //清空缓存
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        #endregion

        #region Delay
        /// <summary>
        /// 延迟系统时间，但系统又能同时能执行其它任务； 
        /// </summary>
        /// <param name="Millisecond">毫秒数</param>
        public static void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；  
        {
            DateTime current = DateTime.Now;
            while (current.AddMilliseconds(Millisecond) > DateTime.Now)
            {
                Application.DoEvents();//转让控制权              
            }
            return;
        }


        #endregion



    }
}

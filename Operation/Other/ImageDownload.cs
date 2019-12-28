using CefSharp.WinForms;
using Operation.CS;
using mshtml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.Other
{
    public partial class ImageDownload : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1 ;

        public ImageDownload()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            
            webBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser("http://www.baidu.com");
            //webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //webBrowser1.Size = new Size(this.Size.Width - 20, this.Size.Height - 110); //new Size(1070, 500);
            //webBrowser1.Location = new Point(10, 100);
            //webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //this.Controls.Add(webBrowser1);

            webBrowser1.ToInit(this);
            txt_save.Text = XMLHelper.GetValue("Pic_Save");
        }



        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //获取页面链接
                string weburl = txt_url_down.Text.Trim();
                if (string.IsNullOrEmpty(weburl))
                {
                    "请输入淘宝宝贝网址".ToShow();
                    return;
                }
                //获取页面保存地址
                string temp_save = txt_save.Text.Trim();
                if (string.IsNullOrEmpty(temp_save))
                {
                    "请输入文件保存路径".ToShow();
                    return;
                }

                //把保存地址存储到xml文件中
                XMLHelper.SetValue("Pic_Save", temp_save);

                webBrowser1.Load(weburl);
                webBrowser1.ToWait();
                string path_temp = "";

                //获取链接中是否有yangkeduo字样，如果有则就是拼多多的页面
                if (weburl.IndexOf("yangkeduo") > -1)
                {
                    path_temp = CS.PinDuoDuo.DownloadImgByWebBrowser(temp_save, weburl, webBrowser1);
                }
                else if (weburl.IndexOf("taobao") > -1)
                {
                    path_temp = CS.Taobao.DownLoadImg_TaoBao(temp_save, weburl, webBrowser1, true);
                }
                else if (weburl.IndexOf("tmall") > -1)
                {
                    //天猫
                    path_temp = CS.Taobao.DownLoadImg_Tmall(temp_save, weburl, webBrowser1);
                }
                else if (weburl.IndexOf("1688") > -1)
                {
                    //1688
                }
                else if (weburl.IndexOf("bao66") > -1)
                {
                    //包牛牛
                    //path_temp = CS.BaoNiuNiu.DownloadImg(temp_save, weburl, webBrowser1);
                }

                //保存截图
                //if (!string.IsNullOrEmpty(path_temp))
                //{
                //    ImageClass.GetScreen(bm, 50, path_temp, "屏幕截图.jpg");
                //}


                MessageBox.Show("保存完成");
                Manager.OpenProgram_Directory(path_temp);






            }
            catch (Exception ex)
            {
                MessageBox.Show("保存图片失败，原因是：" + ex.Message);
            }
        }

        #region 用WebBrowser获取图片对象 可以执行 但是用不上 有更好的办法


        /// <summary>
        /// 获取图像内容
        /// </summary>
        /// <param name="browser">显示图像的浏览器控件</param>
        /// <param name="imgElement">从浏览器中读取到的img</param>
        private static Image GetImage(WebBrowser browser, HtmlElement imgElement)
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
        #endregion

        #region 判断剪贴板中是否有图片(HTML类型数据)
        /// <summary>
        /// 判断CefSharp浏览器加载完毕
        /// </summary>
        /// <param name="element">HTML元素</param>
        /// <param name="times">多久超时，单位毫秒（千分之一秒）</param>
        /// <param name="webBrowser1"></param>
        /// <returns></returns>
        public static bool WaitClipboardHasHtml( int times)
        {
            
            try
            {
                DateTime dt1 = DateTime.Now;
                while (true)
                {
                    #region 
                    Browser.Delay(200);  //系统延迟50毫秒，够少了吧！
                    //if (Clipboard.ContainsData(DataFormats.Html))
                    //{
                    //    //将剪切板中的内容先转为HTML,再转成图片
                    //    string html = Clipboard.GetData(DataFormats.Html).ToString();

                    //    string[] res = CS.HTMLHelper.GetHtmlImageUrlList(html);
                    //    string ss = res[0];
                    //}
                    //如果剪贴板中有HTML的数据
                    if (Clipboard.ContainsData(DataFormats.Html))
                    {
                        return true;
                    }
                    else if (dt1.AddMilliseconds(times) < DateTime.Now)
                    {
                        Manager.WriteLog("到时间了，但是剪贴板中没有数据，现在继续程序");
                        return false;
                    }
                    
                    #endregion
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                Manager.WriteLog(e.ToString());
            }
            finally
            {
            }
            return false;
        }

        #endregion

        #region button1_Click
        private void button1_Click(object sender, EventArgs e)
        {
            Manager.dianpu_huan(webBrowser1);
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion

        #region 图片识别

        
        private void button2_Click(object sender, EventArgs e)
        {
            string path = txt_towords.Text;
            if (string.IsNullOrEmpty(path))
            {
                "请输入文件夹".ToShow();
                return;
            }
            CS.BaiduHelper.FolderToWord(path);
            "操作成功".ToShow();
        }
        #endregion


    }
}

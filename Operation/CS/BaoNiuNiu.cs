using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.CS
{
    public class BaoNiuNiu
    {
        #region DownloadImg
        /// <summary>
        /// 下载拼多多图片，返回图片保存位置
        /// </summary>
        /// <param name="saveurl">保存的网址</param>
        /// <param name="weburl">网址</param>
        /// <param name="webBrowser1">浏览器</param>
        public static string DownloadImg(string saveurl, string weburl, ChromiumWebBrowser webBrowser1)
        {
            string path = "";
            if (weburl.IndexOf("bao66") > -1)
            {
                #region 包牛牛处理
                //检测首发日期
                if (Browser.WaitWebPageLoad2("document.getElementsByClassName('starting_time')[0]", webBrowser1))
                {
                    //获取首发日期
                    DateTime shoufadate = Browser.JS_CEFBrowserToDate("document.getElementsByClassName('starting_time')[0].getElementsByTagName('span')[1].innerText", webBrowser1);
                    //判断是否是6个月之前的款式
                    if (DateTime.Compare(shoufadate.AddMonths(6), DateTime.Now) < 0)
                    {
                        MessageBox.Show("该款式首发时间超过6个月，请留意");
                    }
                    //移动到最下面
                    Browser.ScrollToBottom(webBrowser1);
                    try
                    {

                        //获取宝贝标题
                        string babyname = Browser.JS_CEFBrowser("document.getElementsByClassName('huohao')[0].innerText", webBrowser1);
                        //店铺名称
                        string wgname = Browser.JS_CEFBrowser("document.getElementsByClassName('name')[0].innerText", webBrowser1);
                        //宝贝价格
                        string babyprice = Browser.JS_CEFBrowser("document.getElementsByClassName('msg_price')[0].innerText", webBrowser1);
                        wgname = wgname.Replace("\n", "");
                        //文件名
                        string filename = wgname + "_" + babyname + "_" + babyprice;
                        filename = filename.Replace(" ", "");




                        //下载主图
                        int zhutulength = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('tb-thumb')[0].getElementsByTagName('img').length", webBrowser1);
                        for (int i = 0; i < zhutulength; i++)
                        {
                            string imgurl = Browser.JS_CEFBrowser("document.getElementsByClassName('tb-thumb')[0].getElementsByTagName('img')[" + i.ToString() + "].src", webBrowser1);
                            string imgname = i.ToString() + filename + ".jpg";
                            path = saveurl + "\\" + filename;
                            Manager.DownloadFile(imgurl, path + "\\主图", imgname, 5000);
                        }
                        //创建快捷方式
                        ShortcutCreator.CreateShortcut(saveurl, filename, weburl, null, null);

                        Browser.ScrollToTop(webBrowser1);
                        //下载详情图片
                        //移动到最下面
                        Browser.ScrollToBottom(10, webBrowser1);
                        Browser.Delay(3000);
                        int xiangqinglength = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('product_details')[0].getElementsByTagName('img').length", webBrowser1);
                        for (int i = 0; i < xiangqinglength; i++)
                        {
                            string imgurl = Browser.JS_CEFBrowser("document.getElementsByClassName('product_details')[0].getElementsByTagName('img')[" + i.ToString() + "].src", webBrowser1);
                            string imgname = i.ToString() + filename + ".jpg";
                            Manager.DownloadFile(imgurl, path + "\\详情图", imgname, 5000);
                            Browser.Delay(100);
                        }
                        Browser.ScrollToTop(webBrowser1);
                        //下载视频
                        if (Browser.JS_CEFBrowserHasElementToBool("document.getElementsByClassName('prism-big-play-btn')[0]", webBrowser1))
                        {
                            webBrowser1.Focus();
                            //点击播放视频
                            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('prism-big-play-btn')[0]", webBrowser1);
                            //获取视频地址
                            string videourl = Browser.JS_CEFBrowser("document.getElementsByTagName('video')[0].src", webBrowser1);
                            if (!string.IsNullOrEmpty(videourl))
                                Manager.DownloadFile(videourl, saveurl + "\\" + filename, babyname + ".mp4", 10000);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                #endregion
            }
            return path;

        }
        #endregion
    }
}

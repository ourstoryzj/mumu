using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using excel_operation.CS;
using System.Threading;
using System.Drawing.Imaging;
using mshtml;

namespace excel_operation
{
    public partial class test_download : Form
    {

        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;

        public test_download()
        {
            InitializeComponent();

            webBrowser2.Url = new Uri("http://image.baidu.com/search/index?tn=baiduimage&ps=1&ct=201326592&lm=-1&cl=2&nc=1&ie=utf-8&word=webbrowser+复制图片");
            if (Browser.WaitWebPageLoad(webBrowser2))
            {
                MessageBox.Show("加载完成");
            }
            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser("http://image.baidu.com/search/index?tn=baiduimage&ps=1&ct=201326592&lm=-1&cl=2&nc=1&ie=utf-8&word=webbrowser+复制图片");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(1070, 500);
            webBrowser1.Location = new Point(10, 100);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            this.Controls.Add(webBrowser1);
            Browser.WaitWebPageLoad(webBrowser1);
        }



        #region MyRegion
        private void button1_Click(object sender, EventArgs e)
        {
            string url = txt_url.Text;
            if (string.IsNullOrEmpty(url))
            {
                url = "https://gd2.alicdn.com/imgextra/i2/TB1dg.DNVXXXXXrXXXXYXGcGpXX_M2.SS2_50x50.jpg";
                url = "http://www.testtest.site/oa/upload/page/file/20160730/20160730010321_9218.xlsx";
            }

            int timeOut = 5000;
            string savePath = "D:\\Image\\123";
            string fileName = "9218.xlsx";


            if (!string.IsNullOrEmpty(url))
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
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
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
                    Debug.WriteLine(DateTime.Now.ToShortDateString() + "======================================================");
                    Debug.WriteLine("文件下载失败：" + ex.Message);
                }
                finally
                {
                    if (reader != null) reader.Close();
                    if (webResponse != null) webResponse.Close();

                }



            }
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
      

       
        private void button2_Click(object sender, EventArgs e)
        {
            string url = txt_url.Text.Trim();
            WebBrowser web = new WebBrowser();

            web.Navigate(url);

            if (Browser.WaitWebPageLoad(web))
            {

                Debug.WriteLine(CaiJi.GetShopType(web).ToString());

            }
        }
        #endregion

        #region 测试浏览器直接保存图片到内存中

        
        private void button3_Click(object sender, EventArgs e)
        {
            Browser.JS_CEFBrowser("setSelectRange(document.getElementsByTagName('img')[10])", webBrowser1);
            this.Focus();
            webBrowser1.Focus();
            Auto.Ctrl_C();

            //获取代码中图片的数据
            //Image img =Image.FromFile("c:\\1.jpg");
            
            //string str =  ImageClass.ImgToBase64String("c:\\1.jpg");
            //string res = str;

            //Bitmap bmp = GetCaptureBitmap();

            //Image img = Clipboard.GetImage();
            Browser.Delay(3000);
            test3();
            //Manager.DownloadFile
            //if (bmp == null)
            //{ 
            //    MessageBox.Show("没有图片");
            //    return;
            //}
            //bmp.Save("c:\\1.jpg");

            //Thread th_wordprocess = new Thread(new ThreadStart(WordOperate));
            //th_wordprocess.SetApartmentState(ApartmentState.STA);//这句是关键
            //th_wordprocess.Start();
            //Image img = ClipboardToImage();
            //if (img != null)
            //    img.Save("c:\\1.jpg");
        }

        /// <summary>
        /// 测试新的方法
        /// </summary>
        void test3()
        {
            if (Clipboard.ContainsData(DataFormats.Html))
            {
                //将剪切板中的内容先转为HTML,再转成图片
                string html = Clipboard.GetData(DataFormats.Html).ToString();

                string[] res = CS.HTMLHelper.GetHtmlImageUrlList(html);
                string ss = res[0];
                Image img = ImageClass.Base64StringToImage(ss);
                if(img!=null)
                 img.Save("c:\\2.jpg");



                //去除HTML文件中的文件源信息部分
                //html = html.Substring(html.IndexOf("<html"));
                //webBrowser = new System.Windows.Forms.WebBrowser();
                //是否显式滚动条
                //webBrowser2.ScrollBarsEnabled = false;
                //加载 html
                // webBrowser2.DocumentText = html;
                //页面加载完成执行事件
                //webBrowser2.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(webBrowser_DocumentCompleted);
            }

        }
        /// <summary>
        /// 表格html加载完毕事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            ////获取解析后HTML的大小
            //System.Drawing.Rectangle rectangle = webBrowser2.Document.Body.ScrollRectangle;
            //int width = rectangle.Width;
            //int height = rectangle.Height;

            ////设置解析后HTML的可视区域
            //webBrowser2.Width = width;
            //webBrowser2.Height = height;

            //string filePath = string.Empty;
            //using (System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(width, height))
            //{
            //    webBrowser2.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 0, width, height));

            //    //设置图片文件保存路径和图片格式，格式可以自定义
            //    //string dir = new StringBuilder(AppDomain.CurrentDomain.BaseDirectory).Append(ICTResources.ICTUser.Session.useraccount).Append("\\Image").ToString();
            //    if (!Directory.Exists(dir))
            //    {
            //        Directory.CreateDirectory(dir);
            //    }

            //    filePath = new StringBuilder(dir).Append("\\").Append(DateTime.Now.ToString("yyyyMMddHHmmss.")).Append("png").ToString();
            //    bitmap.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
            //}

            //if (File.Exists(filePath))
            //{
            //    //messageMethods.SendChosenPicture(filePath);
            //}
        }


        void WordOperate()
        {
            //Browser.Delay(3000);
           bool res =   Clipboard.GetDataObject().GetDataPresent(DataFormats.Html);
            Clipboard.GetDataObject().GetData(DataFormats.Html);
            //System.Windows.Forms.IDataObject data = Clipboard.GetDataObject();
            //if (data.GetDataPresent(DataFormats.MetafilePict))
            //{
            //    object obj = data.GetData(DataFormats.MetafilePict);
            //    Metafile metafile = MetafileHelper.GetEnhMetafileOnClipboard(IntPtr.Zero);
            //    Bitmap bm = new Bitmap(metafile.Width, metafile.Height);
            //    using (Graphics g = Graphics.FromImage(bm))
            //    {
            //        g.Clear(Color.White);
            //        g.DrawImage(metafile, 0, 0, bm.Width, bm.Height);
            //    }
            //    //imageLst.Add(bm);
            //    //Clipboard.Clear();
            //}

            Bitmap bmp =  test();
            bmp.Save("c:\\1.jpg");

            //Image img = Clipboard.GetImage();
            ////Browser.Delay(3000);
            //if(img == null)
            //{
            //    MessageBox.Show("没有图片");
            //    return;
            //}
            //img.Save("c:\\1.jpg");
        }

        Bitmap test()
        {
            IDataObject iData = Clipboard.GetDataObject();
            Bitmap bmp = null;
            if (iData.GetDataPresent(DataFormats.Html))
            {
                bmp = (Bitmap)iData.GetData(DataFormats.Html);
            }
            return bmp;
        }


        //public System.Drawing.Imaging.Metafile GetEnhMetafileOnClipboard(IntPtr hWnd)
        //{
        //    System.Drawing.Imaging.Metafile meta = null;
        //    if (OpenClipboard(hWnd))
        //    {
        //        try
        //        {
        //            if (IsClipboardFormatAvailable(CF_ENHMETAFILE) != 0)
        //            {
        //                IntPtr hmeta = GetClipboardData(CF_ENHMETAFILE);
        //                meta = new System.Drawing.Imaging.Metafile(hmeta, true);
        //                metaFileList.Add(meta);
        //            }
        //        }
        //        finally
        //        {
        //            CloseClipboard();
        //        }
        //    }
        //    return meta;
        //}


        private Bitmap GetCaptureBitmap()
        {
            
            IDataObject iData = Clipboard.GetDataObject();
            Bitmap bmp = null;
            if (iData != null)
            {
                if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    bmp = (Bitmap)iData.GetData(DataFormats.Bitmap);
                }
                else if (iData.GetDataPresent(DataFormats.Dib))
                {
                    bmp = (Bitmap)iData.GetData(DataFormats.Dib);
                }
            }
            return bmp;
        }

        private Image GetCaptureImage()
        {
            IDataObject iData = Clipboard.GetDataObject();
            Image bmp = null;
            if (iData != null)
            {
                //iData.GetFormats;
                if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    bmp = (Bitmap)iData.GetData(DataFormats.Bitmap);
                }
                else if (iData.GetDataPresent(DataFormats.Dib))
                {
                    bmp = (Bitmap)iData.GetData(DataFormats.Dib);
                }
            }
            return bmp;
        }

        #endregion


        #region 测试浏览器直接保存图片到内存中2
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                //ContextMenuStrip cms = (ContextMenuStrip)((ToolStripMenuItem)sender).GetCurrentParent();
                WebBrowser browser = webBrowser2;
                //Point cpoint = browser.PointToClient(cms.Bounds.Location);
                HtmlDocument doc = webBrowser2.Document;
                
                HtmlElementCollection hec = doc.GetElementsByTagName("img");
                HtmlElement current = hec[10];
                Image img = GetImage(browser, current);
                img.Save("c:\\1.jpg");

                //string src = current.GetAttribute("src");
                //string fileFormat = src.Substring(src.LastIndexOf('.') + 1);
                //string filter = fileFormat.ToUpper() + "|*." + fileFormat + "|所有文件|*.*";
                //string fName = src.Substring(src.LastIndexOf('/') + 1);
                //sfd.Filter = filter;
                //sfd.FileName = fName;
                //if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                //{
                //    Image img = GetImage(browser, current);
                //    img.Save(sfd.FileName);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存图片失败，原因是：" + ex.Message);
            }
        }
        #endregion


        /// <summary>
        /// 把内存中的html类型的数据转化成image
        /// </summary>
        Image ClipboardToImage()
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
                image = GetImage(wb, current);
            }
            catch (Exception ex)
            {

            }
            return image;
        }


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

        private void button5_Click(object sender, EventArgs e)
        {
            string url = txt_url.Text;

            webBrowser2.Navigate(url);

            Image img =  url.ToImageByWebBrowser();
            if (img != null)
                img.Save("c:\\2.jpg");
        }
    }
}

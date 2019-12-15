using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel_operation.TaoBao
{
    public partial class ZhuTu : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        public ZhuTu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            try
            {
                webBrowser1 = new ChromiumWebBrowser("http://www.taobao.com");
                webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
                webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;

                webBrowser1.Size = new Size(900, 550);
                webBrowser1.Location = new Point(10, 60);
                webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                this.Controls.Add(webBrowser1);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string key = txt_key.Text.Trim();
            string sort = cb_order.Text;
            string url = "";
            string str_num = txt_ye.Text.Trim();
            int num = 0;
            if (!int.TryParse(str_num, out num))
            {
                MessageBox.Show("请输入正确的采集页数");
                return;
            }
            if (sort == "销量")
            {
                sort = "&sort=sale-desc";
            }
            else if (sort == "人气")
            {
                sort = "&sort=renqi-desc";
            }
            else if (sort == "综合")
            {
                sort = "&sort=default";
            }
            else
            {
                MessageBox.Show("请选择正确的排序方式");
                return;
            }
            //https://s.taobao.com/search?q=%E5%8F%8C%E8%82%A9%E5%8C%85%E5%A5%B3&sort=renqi-desc&s=132
            key = geturl(key);

            try
            {
                for (int j = 0; j < num; j++)
                {
                    url = "https://s.taobao.com/search?q=" + key + sort + "&s=" + (j * 44).ToString();


                    webBrowser1.Load(url);
                    if (Browser.WaitWebPageLoad(webBrowser1))
                    {
                        ScrollToBottom(webBrowser1);

                        string str_count = Browser.JS_CEFBrowser(" document.getElementsByClassName('J_MouserOnverReq').length ", webBrowser1);
                        int count = 0;
                        int.TryParse(str_count, out count);

                        for (int i = 0; i < count; i++)
                        {
                            //https://g-search1.alicdn.com/img/bao/uploaded/i4/imgextra/i4/1310605002038795879/TB2OyjCd.hnpuFjSZFEXXX0PFXa_!!0-saturn_solar.jpg_230x230.jpg
                            string imgurl = Browser.JS_CEFBrowser(" document.getElementsByClassName('J_ItemPic')[" + i.ToString() + "].src ", webBrowser1);
                            imgurl = imgurl.Replace("_.webp", "");
                            imgurl = imgurl.Replace("230x230", "800x800");
                            imgurl = imgurl.Replace("180x180", "800x800");
                            imgurl = imgurl.Replace("250x250", "800x800");

                            string id = Browser.JS_CEFBrowser(" document.getElementsByClassName('pic-link')[" + i.ToString() + "].id ", webBrowser1);
                            string[] strs = id.Split('_');
                            id = strs[strs.Count() - 1];
                            string imgname = j.ToString("00") + i.ToString("00") + "_" + DateTime.Now.ToString("yyyyMMdd") + "_" + id + ".jpg";
                            string path = Application.StartupPath + "\\Image\\ZhuTu\\" + DateTime.Now.ToString("yyyyMMdd");
                            Manager.DownloadFile(imgurl, path, imgname, 5000);

                        }


                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return;
            }

        }


        string geturl(string str)
        {
            string code = "";
            foreach (byte b in Encoding.UTF8.GetBytes(str))
            {
                code += '%' + b.ToString("X");
            }
            return code;
        }

        void ScrollToBottom(ChromiumWebBrowser webBrowser2)
        {
            int clientHeight = 0;
            int.TryParse(Browser.JS_CEFBrowser(" document.body.clientHeight ", webBrowser2), out clientHeight);
            for (int i = 0; i < clientHeight; i++)
            {
                i = i + 200;
                Browser.JS_CEFBrowser_NoReturn(" window.scrollTo(0," + i.ToString() + ") ", webBrowser2);
                Browser.Delay(20);
            }
        }
    }
}

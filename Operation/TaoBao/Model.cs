using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using excel_operation.Common;
using excel_operation.CS;
using System.IO;
using System.Diagnostics;

namespace excel_operation.TaoBao
{
    public partial class Model : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser2;
        /// <summary>
        /// 采集商品列表
        /// </summary>
        List<string> GoodsList = new List<string>();
        /// <summary>
        /// 要操作的商品列表
        /// </summary>
        string[] GoodsList2;


        public Model()
        {
            Login tb = new Login();
            tb.Show();
            if (Manager.WaitLogin(tb))
            {
                tb.Hide();
                InitializeComponent();

                this.StartPosition = FormStartPosition.CenterScreen;
                webBrowser1 = new ChromiumWebBrowser("http://www.taobao.com");
                webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
                webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
                webBrowser1.Size = new Size(990, 725);
                //webBrowser1.Location = new Point(180, 12);
                webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                tabPage1.Controls.Add(webBrowser1);
                webBrowser1.RequestContext = tb.webBrowser1.RequestContext;
                tb.Close();
                tb.Dispose();


                webBrowser2 = new ChromiumWebBrowser("http://www.taobao.com");
                webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
                webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
                webBrowser2.Size = new Size(990, 400);
                webBrowser2.Location = new Point(0, 325);
                webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                webBrowser2.RequestContext = webBrowser1.RequestContext;
                txt_url.Controls.Add(webBrowser2);


             
            }

           

        }

        #region bind

        void bind()
        {

        }


   

        #endregion



        #region btn_xiaofeizhe_Click
        private void btn_xiaofeizhe_Click(object sender, System.EventArgs e)
        {
            //webBrowser1.Load("https://xiaobao.taobao.com/contract/user_contract.htm");
            //打开退货承诺页面
            webBrowser1.Load("https://xiaobao.taobao.com/contract/item_contract.htm?crtId=2");
            if (Browser.WaitWebPageLoad(" getClassName('J_CatSearch')[0] ", webBrowser1))
            {
                //打开类目下拉菜单
                Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('J_CatSearch')[0].click(); ", webBrowser1);
                //下拉列表容器class=bf-contentbox，选择箱包类目
                Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('bf-contentbox')[0].getElementsByTagName('div')[78].click(); ", webBrowser1);
                //点击搜索
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('search-btn')[0].click();", webBrowser1);
                Browser.Delay(500);
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    //判断是否有商品
                    if (Browser.JS_CEFBrowser(" document.getElementById('J_GoodsList').getElementsByTagName('tr').length ", webBrowser1) != "1")
                    {
                        //选择全部
                        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('all-goods')[0].getElementsByTagName('input')[0].click(); ", webBrowser1);
                        //选择批量操作
                        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('batch-ctr')[0].click(); ", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('J_Sure')[0].click(); ", webBrowser1);
                    }
                }
            }
        }



        #endregion

        #region btn_chushouzhong_Click
        private void btn_chushouzhong_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://sell.taobao.com/auction/merchandise/auction_list.htm");
        }
        #endregion

        #region btn_dingdan_Click
        private void btn_dingdan_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://trade.taobao.com/trade/itemlist/list_sold_items.htm");
            //if (Browser.WaitWebPageLoad(" document.getElementsByClassName('rc-select-selection__rendered')[0]", webBrowser1))
            //{
            //    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('rc-select-selection__rendered')[0].click(); ", webBrowser1);
            //    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('rc-select-dropdown-menu-item')[2].click(); ", webBrowser1);
            //    Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.0.0.0.0.a.0.1.0')[0] ", webBrowser1);
            //}
        }
        #endregion

        #region btn_tuihuo_Click
        private void btn_tuihuo_Click(object sender, System.EventArgs e)
        {
            webBrowser1.Load("https://myseller.taobao.com/seller_admin.htm");
            //if (Browser.WaitWebPageLoad(webBrowser1))
            //{
            //    Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d79')[0] ", webBrowser1);
            //}
        }

        #endregion

        #region btn_shouhou_Click
        private void btn_shouhou_Click(object sender, System.EventArgs e)
        {
            webBrowser1.Load("https://myseller.taobao.com/seller_admin.htm");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d8')[0] ", webBrowser1);
            }
        }

        #endregion

        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {
            Manager.dianpu_huan(webBrowser1);
        }

        #endregion

        #region 基础


        #region btn_addjs_Click
        private void btn_addjs_Click(object sender, EventArgs e)
        {
            Browser.SetJSFile(webBrowser1);
        }
        #endregion

        #region btn_test_Click
        private void btn_test_Click(object sender, System.EventArgs e)
        {
            string js = txt_js.Text;
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion

        #region btn_savehtml_Click
        private void btn_savehtml_Click(object sender, EventArgs e)
        {
            //string html = webBrowser1.RequestContext.ToString();
            string html = Browser.JS_CEFBrowser("document.body.innerHTML", webBrowser1);
            //// 创建文件
            //System.IO.FileStream fs = new FileStream("test.doc", FileMode.OpenOrCreate, FileAccess.ReadWrite); //可以指定盘符，也可以指定任意文件名，还可以为word等文件
            //StreamWriter sw = new StreamWriter(fs); // 创建写入流
            //sw.WriteLine("bob hu"); // 写入Hello World
            //sw.Close(); //关闭文件
            string path = "d:\\html" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            FileHelper.Write(path, html);
            System.Diagnostics.Process.Start(path);
        }
        #endregion

        #endregion








 

    }





}

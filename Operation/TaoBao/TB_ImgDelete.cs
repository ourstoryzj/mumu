using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using Operation.Other;
using Operation.CS;
using System.IO;
using System.Diagnostics;
using Common;

namespace Operation.TaoBao
{
    public partial class TB_ImgDelete : Form
    {
        //CefSharp.WinForms.ChromiumWebBrowser webBrowser3;
        //CefSharp.WinForms.ChromiumWebBrowser webBrowser2;
        /// <summary>
        /// 采集商品列表
        /// </summary>
        List<string> GoodsList = new List<string>();
        /// <summary>
        /// 要操作的商品列表
        /// </summary>
        //string[] GoodsList2;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;

        bool state = true;

        public TB_ImgDelete()
        {

            //InitializeComponent();
            Taobao_Login tb = new Taobao_Login();
            tb.Show();
            if (Manager.WaitTaobaoLogin(tb))
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


                //webBrowser2 = new ChromiumWebBrowser("http://www.taobao.com");
                //webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
                //webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
                //webBrowser2.Size = new Size(990, 400);
                //webBrowser2.Location = new Point(0, 325);
                //webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                //webBrowser2.RequestContext = webBrowser1.RequestContext;
                //txt_url.Controls.Add(webBrowser2);


                //txt_chengfa.Text = XMLHelper.GetValue("TaoBao_Copy_ChengFa");
                //txt_jiafa.Text = XMLHelper.GetValue("TaoBao_Copy_JiaFa");
            }


        }

        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {
            //Manager.dianpu_huan(webBrowser3);
            webBrowser1.Load("https://login.taobao.com/member/login.jhtml?f=top&redirectURL=https%3A%2F%2Fwww.taobao.com%2F&style=mini");
        }

        #endregion

        #region btn_img_Click
        private void btn_img_Click(object sender, System.EventArgs e)
        {
            webBrowser1.Load("https://tadget.taobao.com/redaction/manager.htm");
        }

        #endregion

        #region btn_test_Click
        private void btn_test_Click(object sender, System.EventArgs e)
        {
            Browser.JS_CEFBrowser_NoReturn("alert(navigator.appVersion .split(\"; \")[1].replace(/[ ]/g,\"\"))", webBrowser1);
            string js = txt_js.Text;
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion

        #region btn_savehtml_Click
        private void btn_savehtml_Click(object sender, EventArgs e)
        {
            //string html = webBrowser3.RequestContext.ToString();
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

        #region btn_delete_Click
        private void btn_delete_Click(object sender, EventArgs e)
        {
            while (state)
            {
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    ////判断全选
                    //if (Browser.JS_CEFBrowserToHasElement("document.getElementById('J_SelectAll')", webBrowser1))
                    //{
                    //    //点击全选
                    //    Browser.JS_CEFBrowser_NoReturn("document.getElementById('J_SelectAll').click()", webBrowser1);
                    //    //判断删除
                    //    if (Browser.JS_CEFBrowserToHasElement("document.getElementsByClassName('delete')[0].getElementsByTagName('a')[0]", webBrowser1))
                    //    {
                    //        //点击删除
                    //        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('delete')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                    //    }
                    //    else
                    //    {
                    //        break;
                    //    }
                    //}
                    //else
                    //{
                    //    break;
                    //}

                    //点击全选
                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('J_SelectAll').click()", webBrowser1);
                    Browser.Delay(1500);
                    //点击删除
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('delete')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                    Browser.Delay(1500);
                    //点击确定
                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('J_ModalSure').click()", webBrowser1);
                    Browser.Delay(2000);

                    //if (Browser.WaitWebPageLoad2("document.getElementById('J_SelectAllDelete')", webBrowser1))
                    //{

                    Browser.JS_CEFBrowser_NoReturn(" document.getElementById('J_SelectAllDelete').click()", webBrowser1);
                    Browser.Delay(1500);

                    //点击确定
                    Browser.JS_CEFBrowser_NoReturn("document.getElementById('J_ForceDelete').click()", webBrowser1);
                    Browser.Delay(2000);
                    //}

                }

            }
        }
        #endregion

        #region btn_state_Click
        private void btn_state_Click(object sender, EventArgs e)
        {
            if (state == true)
            {
                btn_state.Text = "状态：禁用";
                state = false;
            }
            else
            {
                btn_state.Text = "状态：启用";
                state = true;
            }
        }
        #endregion


    }





}

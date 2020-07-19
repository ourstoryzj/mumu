using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;

using System.IO;
using System.Diagnostics;
using Operation.CS;
using Common;

namespace Operation
{
    public partial class PDDKeyData : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        //CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        //CefSharp.WinForms.ChromiumWebBrowser webBrowser3;
        //CefSharp.WinForms.ChromiumWebBrowser webBrowser4;
        string token = "";
        string phone;

        Common.XMLHelpers xmlpdd = new Common.XMLHelpers("PDD");

        /// <summary>
        /// 全选开关
        /// </summary>
        //int allselect = 0;

        /// <summary>
        /// 自动回复开关
        /// </summary>
        int auto_answer = 0;

        public PDDKeyData()
        {

            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("https://mms.pinduoduo.com/login/");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(990, 725);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tp_kefus.Controls.Add(webBrowser1);


            //webBrowser1 = new ChromiumWebBrowser("https://mms.pinduoduo.com/Pdd.html#/index");
            //webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //webBrowser1.Size = new Size(990, 725);
            ////webBrowser1.Location = new Point(0, 60);
            //webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            

            //webBrowser3 = new ChromiumWebBrowser("https://baidu.com");
            //webBrowser3.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //webBrowser3.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //webBrowser3.Size = new Size(990, 725);
            ////webBrowser1.Location = new Point(0, 60);
            //webBrowser3.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //tabPage2.Controls.Add(webBrowser3);

            //timer1.Interval = XMLHelper.GetValue("PinDuoDuo_AutoAnswerTime").ToInt();
            //bind_Account();

        }

         

        #region 基础


        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {



        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            webBrowser1.Load("https://mms.pinduoduo.com/exp/tools/index");
        }


        #region btn_chushouzhong_Click
        private void btn_chushouzhong_Click(object sender, EventArgs e)
        {

            //window.location.href = "https://mms.pinduoduo.com/windows-mms/"
            webBrowser1.Load("https://mms.pinduoduo.com/windows-mms/");
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            
            webBrowser1.Load("https://mms.pinduoduo.com/exp/tools/dataAnalysis");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            
            webBrowser1.Load("https://mms.pinduoduo.com/exp/search/index");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://mms.pinduoduo.com/exp/pro/index");
        }


        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://mms.pinduoduo.com/sycm/goods_effect");

        }

        #region btn_unsalable_Click
        private void btn_unsalable_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectedTab = tp_houtai;
            //进入商品列表
            //webBrowser1.Load("https://mms.pinduoduo.com/goods/goods_list");
            ////判断商品数量大于0
            //if (webBrowser1.ToWait("document.getElementsByClassName('table-content')[0]", "document.getElementsByClassName('table-content')[0].getElementsByTagName('tbody')[0].getElementsByTagName('tr').length>0"))
            //{
            //设置每页显示100条信息
            webBrowser1.ToJs("getElementsByClassName_Vague('BeastCoreCssSelect___head-input')[2].click()");//点击条数
            webBrowser1.ToJs("getElementsByClassName_Vague('eastCoreCssSelect___dropdown-panel')[0].getElementsByTagName('li')[3].click();");//点击每页显示100条
                                                                                                                                             //获取商品数量
            int count = webBrowser1.ToJsInt("document.getElementsByClassName('table-content')[0].getElementsByTagName('tbody')[0].getElementsByTagName('tr').length");

            for (int i = 0; i < count; i++)
            {
                //获取每条商品创建时间
                string temp = webBrowser1.ToJs("document.getElementsByClassName('table-content')[0].getElementsByTagName('tbody')[0].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[8].innerText");
                string[] temps = Manager.Str_Split(temp, "销售中");
                if (temps.Length > 0)
                {
                    temp = temps[0].Replace("<br>", "");
                    DateTime dt_start = temps[0].ToDateTime();
                    if (dt_start != new DateTime())
                    {
                        //对比时间，如果超过25日没有销量则勾选
                        if (dt_start.AddDays(25) < DateTime.Now)
                        {
                            //如果是滞销品,勾选
                            webBrowser1.ToJs("document.getElementsByClassName('table-content')[0].getElementsByTagName('tbody')[0].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[0].getElementsByTagName('input')[0].click()");

                        }
                    }
                }
                //}


                //翻页

            }


        }
        #endregion


        #region btn_dingdan_Click
        private void btn_dingdan_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://mms.pinduoduo.com/aftersales/aftersale_list");
            //if (Browser.WaitWebPageLoad(" document.getElementsByClassName('rc-select-selection__rendered')[0]", webBrowser1))
            //{
            //    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('rc-select-selection__rendered')[0].click(); ", webBrowser1);
            //    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('rc-select-dropdown-menu-item')[2].click(); ", webBrowser1);
            //    Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.0.0.0.0.a.0.1.0')[0] ", webBrowser1);
            //}
        }
        #endregion




        #region btn_shouhou_Click
        private void btn_shouhou_Click(object sender, System.EventArgs e)
        {
            webBrowser1.Load("https://mms.pinduoduo.com/Pdd.html#/FundManagement/AccountBalance");
            //if (Browser.WaitWebPageLoad(webBrowser1))
            //{
            //    Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d8')[0] ", webBrowser1);
            //}
        }

        #endregion


        private void btn_budanfahuo_Click(object sender, EventArgs e)
        {
            //webBrowser4.Load("http://www.uu338.com/Member/DanHaoSearch.aspx");
        }









        #endregion


        #region 基础2

        #region btn_addjs_Click
        private void btn_addjs_Click(object sender, EventArgs e)
        {
            Browser.SetJSFile(webBrowser1);
            //设置推广计划里的数据,不显示滚动条
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ant-table-scroll')[0].classList.remove('ant-table-scroll')", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ant-table-body')[0].style=''", webBrowser1);
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
            Common.FileHelper.Write(path, html);
            System.Diagnostics.Process.Start(path);
        }









        #endregion

        #endregion




        
    }


}

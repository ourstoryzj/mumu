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
using Operation.CefsharpHelpers;

namespace Operation
{
    public partial class PDDKeyData : Form
    {

        //浏览器
        private CefsharpHelper chrome = null;
        //浏览器
        private ChromiumWebBrowser browser = null;
        //主关键词实体
        List<Entity_KeyData> list_kd = new List<Entity_KeyData>();
        //关键词搜索结果实体
        List<Entity_KeyData> list_kdres = new List<Entity_KeyData>();
        //xml
        Common.XMLHelpers xml = new Common.XMLHelpers("PDD");


        public PDDKeyData()
        {

            InitializeComponent();

            bind();
        }


        #region bind
        void bind()
        {
            string token = xml.GetValue("shop_token");
            txt_tonken.Text = token;


            if (chrome == null)
            {
                chrome = new CefsharpHelper("https://mms.pinduoduo.com/home");
                chrome.Init();
                browser = chrome.CreateBrowser();
                tp_kefus.Controls.Add(chrome.browser);
                tp_kefus.Update();
            }
            else
            {
                browser = chrome.browser;
                tp_kefus.Controls.Add(chrome.browser);
                tp_kefus.Update();
            }

            //添加token
            //if (!string.IsNullOrEmpty(token))
            //{
            //    try
            //    {
            //        string[] cookies = token.ToSplit(";");
            //        var domain = "mms.pinduoduo.com";
            //        foreach (var item in cookies)
            //        {
            //            string[] cookie = item.ToSplit("=");
            //            string value = item.IndexOf("==") > -1 ? cookie[1] + "==" : cookie[1];
            //            chrome.SetCookies(domain, cookie[0], value);
            //        }
            //        chrome.JumpUrl("https://mms.pinduoduo.com/home");
            //    }
            //    catch (Exception ex)
            //    {
            //        ex.ToShow();
            //    }
            //}


        }
        #endregion


        #region 基础


        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {
            chrome.JumpUrl("https://mms.pinduoduo.com/home");


        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            chrome.JumpUrl("https://mms.pinduoduo.com/exp/tools/index");
        }

        #region btn_chushouzhong_Click
        private void btn_chushouzhong_Click(object sender, EventArgs e)
        {

            //window.location.href = "https://mms.pinduoduo.com/windows-mms/"
            chrome.JumpUrl("https://mms.pinduoduo.com/windows-mms/");
        }
        #endregion



        private void button3_Click(object sender, EventArgs e)
        {

            chrome.JumpUrl("https://mms.pinduoduo.com/exp/search/index");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chrome.JumpUrl("https://mms.pinduoduo.com/exp/pro/index");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            chrome.JumpUrl("https://mms.pinduoduo.com/sycm/goods_effect");

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
            chrome.browser.ToJs("getElementsByClassName_Vague('BeastCoreCssSelect___head-input')[2].click()");//点击条数
            chrome.browser.ToJs("getElementsByClassName_Vague('eastCoreCssSelect___dropdown-panel')[0].getElementsByTagName('li')[3].click();");//点击每页显示100条
                                                                                                                                                //获取商品数量
            int count = chrome.browser.ToJsInt("document.getElementsByClassName('table-content')[0].getElementsByTagName('tbody')[0].getElementsByTagName('tr').length");

            for (int i = 0; i < count; i++)
            {
                //获取每条商品创建时间
                string temp = chrome.browser.ToJs("document.getElementsByClassName('table-content')[0].getElementsByTagName('tbody')[0].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[8].innerText");
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
                            chrome.browser.ToJs("document.getElementsByClassName('table-content')[0].getElementsByTagName('tbody')[0].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[0].getElementsByTagName('input')[0].click()");

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
            chrome.JumpUrl("https://mms.pinduoduo.com/aftersales/aftersale_list");
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
            chrome.JumpUrl("https://mms.pinduoduo.com/Pdd.html#/FundManagement/AccountBalance");
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
            Browser.SetJSFile(chrome.browser);
            //设置推广计划里的数据,不显示滚动条
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ant-table-scroll')[0].classList.remove('ant-table-scroll')", chrome.browser);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ant-table-body')[0].style=''", chrome.browser);
        }
        #endregion

        #region btn_test_Click
        private void btn_test_Click(object sender, System.EventArgs e)
        {
            string js = txt_js.Text;
            Browser.JS_CEFBrowser_NoReturn(js, chrome.browser);
        }
        #endregion

        #region btn_savehtml_Click
        private void btn_savehtml_Click(object sender, EventArgs e)
        {
            //string html = webBrowser1.RequestContext.ToString();
            string html = Browser.JS_CEFBrowser("document.body.innerHTML", chrome.browser);
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


        #region 页面 主关键词


        #region btn_daochu_zhu_Click

        private void btn_daochu_zhu_Click(object sender, EventArgs e)
        {
            try
            {
                dgv1.ToExcel();
            }
            catch (Exception ex)
            {
                ex.ToShow();
            }
        }

        #endregion


        #region dgv1_DoubleClick
        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            Point hit = this.dgv1.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo hitTest = this.dgv1.HitTest(hit.X, hit.Y);
            //判断不是首行
            if (hitTest.RowIndex != -1)
            {
                DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)dgv1.Rows[hitTest.RowIndex].Cells[0];
                cbx.Value = true;
            }
        }
        #endregion


        #region btn_search_zhu_Click
        private void btn_search_zhu_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_kefus;

            //获取选择的关键词
            List<int> list = dgv1.GetCheckedIndex("确定要查询选中关键词吗?");

            //需要查询的关键词
            List<string> strs = new List<string>();

            foreach (var item in list)
            {
                strs.Add(dgv1.Rows[item].Cells[1].Value.ToString());
            }



            //遍历搜索关键词

            list_kdres = new List<Entity_KeyData>();


            foreach (var item in strs)
            {
                browser.ToJs("document.getElementsByClassName('keyword-search-input-box')[0].getElementsByTagName('input')[0].focus();");
                Common.Manager.Delay(500);
                Auto.Ctrl_A();
                Auto.Ctrl_V(item);
                Common.Manager.Delay(500);
                //browser.ToJs("getElementsByInnerText('查询')[0].click()");
                browser.ToMouseClick("getElementsByInnerText_NoChildren('查询')[0]");
                Common.Manager.Delay(4500);
                //开始获取关键词信息


                //获取关键词条数
                int length = browser.ToJsInt("document.getElementsByTagName('table')[3].getElementsByTagName('tr').length");
                //遍历获取关键词信息
                for (int i = 0; i < length; i++)
                {
                    string key = browser.ToJs("document.getElementsByTagName('table')[3].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[1].innerText");
                    string xiangguan = browser.ToJs("document.getElementsByTagName('table')[3].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[2].innerText"); ;
                    string sousuoredu = browser.ToJs("document.getElementsByTagName('table')[3].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[3].innerText");
                    string dianjiredu = browser.ToJs("document.getElementsByTagName('table')[3].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[4].innerText");
                    string dianjilv = browser.ToJs("document.getElementsByTagName('table')[3].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[5].innerText");
                    string zhuanhualv = browser.ToJs("document.getElementsByTagName('table')[3].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[6].innerText");
                    string jingzhengqiangdu = browser.ToJs("document.getElementsByTagName('table')[3].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[7].innerText");
                    string chujia = browser.ToJs("document.getElementsByTagName('table')[3].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[8].innerText");

                    Entity_KeyData kd = new Entity_KeyData();

                    try
                    {
                        kd.Key = key;
                        kd.Xiangguan = xiangguan;
                        kd.Sousuoredu = sousuoredu.ToInt();
                        kd.Dianjiredu = dianjiredu.ToInt();
                        kd.Dianjilv = dianjilv.Replace("%", "").ToDecimal() / 100;
                        kd.Zhuanhualv = zhuanhualv.Replace("%", "").ToDecimal() / 100;
                        kd.Jingzhengqiangdu = jingzhengqiangdu.ToInt();
                        kd.Chujia = chujia.ToDecimal();
                        kd.Dianjisousuo = Convert.ToDecimal(kd.Dianjiredu) / Convert.ToDecimal(kd.Sousuoredu);
                        kd.Zonghezhi = kd.Sousuoredu * kd.Dianjilv * kd.Zhuanhualv;
                        kd.Zonghejingzheng = kd.Zonghezhi / kd.Jingzhengqiangdu;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                    list_kdres.Add(kd);


                }
            }


            dgv2.DataSource = list_kdres.ToDataTable();
            tabControl1.SelectedTab = tabPage2;

        }
        #endregion


        #endregion



        #region 功能 关键词采集


        #region button2_Click
        private void button2_Click(object sender, EventArgs e)
        {

            chrome.JumpUrl("https://mms.pinduoduo.com/exp/tools/dataAnalysis");
        }
        #endregion

        #region btn_getkeydata_zhu_Click

        private void btn_getkeydata_zhu_Click(object sender, EventArgs e)
        {
            list_kd = new List<Entity_KeyData>();
            //获取关键词条数
            int length = browser.ToJsInt("document.getElementsByTagName('table')[1].getElementsByTagName('tr').length");
            //遍历获取关键词信息
            for (int i = 0; i < length; i++)
            {
                string key = browser.ToJs("document.getElementsByTagName('table')[1].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[1].innerText");
                string xiangguan = "";
                string sousuoredu = browser.ToJs("document.getElementsByTagName('table')[1].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[2].innerText");
                string dianjiredu = browser.ToJs("document.getElementsByTagName('table')[1].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[3].innerText");
                string dianjilv = browser.ToJs("document.getElementsByTagName('table')[1].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[4].innerText");
                string zhuanhualv = browser.ToJs("document.getElementsByTagName('table')[1].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[5].innerText");
                string jingzhengqiangdu = browser.ToJs("document.getElementsByTagName('table')[1].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[6].innerText");
                string chujia = browser.ToJs("document.getElementsByTagName('table')[1].getElementsByTagName('tr')[" + i + "].getElementsByTagName('td')[7].innerText");

                Entity_KeyData kd = new Entity_KeyData();

                try
                {
                    kd.Key = key;
                    kd.Xiangguan = xiangguan;
                    kd.Sousuoredu = sousuoredu.ToInt();
                    kd.Dianjiredu = dianjiredu.ToInt();
                    kd.Dianjilv = dianjilv.Replace("%", "").ToDecimal() / 100;
                    kd.Zhuanhualv = zhuanhualv.Replace("%", "").ToDecimal() / 100;
                    kd.Jingzhengqiangdu = jingzhengqiangdu.ToInt();
                    kd.Chujia = chujia.ToDecimal();
                    kd.Dianjisousuo = Convert.ToDecimal(kd.Dianjiredu) / Convert.ToDecimal(kd.Sousuoredu);
                    kd.Zonghezhi = kd.Sousuoredu * kd.Dianjilv * kd.Zhuanhualv;
                    kd.Zonghejingzheng = kd.Zonghezhi / kd.Jingzhengqiangdu;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }

                list_kd.Add(kd);
            }

            //附加到dgv
            dgv1.DataSource = list_kd.ToDataTable();
            tabControl1.SelectedTab = tabPage1;
        }






        #endregion


        #region btn_output_Click

        private void btn_output_Click(object sender, EventArgs e)
        {
            dgv2.ToExcel();
        }

        #endregion


        #endregion



        #region 页面 TOKEN

        private void btn_savetoken_Click(object sender, EventArgs e)
        {

        }










        #endregion




        private void button6_Click(object sender, EventArgs e)
        {
            Browser.SetScrollByHtmlElement("getElementsByInnerText_NoChildren('查询')[0]", browser);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Browser.MouseMoveByHtmlElement("getElementsByInnerText_NoChildren('查询')[0]", browser);
        }
    }


}

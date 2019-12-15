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
    public partial class TB_Often3 : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser2;
        /// <summary>
        /// 直通车关键词
        /// </summary>
        List<keyurls> List_keys = new List<keyurls>();

        /// <summary>
        /// 正删除的关键词
        /// </summary>
        List<string> List_Deleteing = new List<string>();

        //最高出价
        decimal zuigao = 0;
        //最低出价
        decimal zuidi = 0;
        //每次出价
        decimal meici = 0;
        //设置出价
        decimal chujia = 0;
        //设置最低展现指数
        decimal zuidizhanxian = 0;
        //开关
        bool kaiguan = true;


        public TB_Often3()
        {
            Login tb = new Login();
            tb.Show();
            if (Manager.WaitLogin(tb))
            {
                tb.Hide();
                InitializeComponent();

                this.StartPosition = FormStartPosition.CenterScreen;
                webBrowser1 = new ChromiumWebBrowser("http://zhitongche.taobao.com/");
                webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
                webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
                webBrowser1.Size = new Size(990, 725);
                //webBrowser1.Location = new Point(180, 12);
                webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                tp_zhitongche.Controls.Add(webBrowser1);
                webBrowser1.RequestContext = tb.webBrowser1.RequestContext;
                tb.Close();
                tb.Dispose();


                webBrowser2 = new ChromiumWebBrowser("http://subway.simba.taobao.com/#!/tools/insight/index");
                webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
                webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
                webBrowser2.Size = new Size(990, 725);
                //webBrowser2.Location = new Point(0, 325);
                webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                webBrowser2.RequestContext = webBrowser1.RequestContext;
                tp_remark.Controls.Add(webBrowser2);


                //txt_chengfa.Text = XMLHelper.GetValue("TaoBao_Copy_ChengFa");
                //txt_jiafa.Text = XMLHelper.GetValue("TaoBao_Copy_JiaFa");
            }
            bind();
        }

        #region bind
        void bind()
        {
            txt_gao.Text = XMLHelper.GetValue("ZhiTongChe_ZuiGaoPrice");
            string temp = XMLHelper.GetValue("ZhiTongChe_PaiMing");
            if (temp == "1")
            {
                rb_shoutao.Checked = true;
            }
            else if (temp == "2")
            {
                rb_3.Checked = true;
            }
            else if (temp == "3")
            {
                rb_46.Checked = true;
            }
            else if (temp == "4")
            {
                rb_710.Checked = true;
            }
            else if (temp == "5")
            {
                rb_1015.Checked = true;
            }
            else if (temp == "6")
            {
                rb_1620.Checked = true;
            }

            txt_di.Text = XMLHelper.GetValue("ZhiTongChe_ZuiDiPrice");
            txt_meiciprice.Text = XMLHelper.GetValue("ZhiTongChe_MeiCiPrice");
            txt_zhanxian_di.Text = XMLHelper.GetValue("ZhiTongChe_ZuiDiZhanXian");

            decimal.TryParse(txt_gao.Text, out zuigao);
            decimal.TryParse(txt_di.Text, out zuidi);
            decimal.TryParse(txt_meiciprice.Text, out meici);
            decimal.TryParse(txt_zhanxian_di.Text, out zuidizhanxian);
        }
        #endregion

        #region btn_canmou_Click

        private void btn_canmou_Click(object sender, EventArgs e)
        {
            //卖家中心
            webBrowser1.Load("https://myseller.taobao.com/seller_admin.htm");
            if (Browser.WaitWebPageLoad("getElementsByDataSpm('d58')[0]", webBrowser1))
            {
                //在卖家中心找到生意参谋
                Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d58')[0]", webBrowser1);
                //第一次点击进入浏览器，第二次点击开始操作
                Auto.Mouse_Left();
                if (Browser.WaitWebPageLoad("getElementsByDataSpm('d18')[0]", webBrowser1))
                {
                    //关闭提示窗口dialog-show
                    Browser.MouseLeftByHtmlElement(" getClassName('dialog-show')[0].getElementsByTagName('i')[0] ", webBrowser1);
                    //点击市场行情
                    Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d18')[0]", webBrowser1);
                    //延迟-商品店铺榜
                    if (Browser.WaitWebPageLoad("getElementsByDataSpm('d342')[0]", webBrowser1))
                    {
                        //点击商品店铺榜
                        Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d342')[0]", webBrowser1);
                        //点击行业粒度
                        Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d343')[0]", webBrowser1);
                    }
                }
            }
        }
        #endregion

        #region btn_tuiguang_Click

        private void btn_tuiguang_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://myseller.taobao.com/app.htm?aid=23&cid=65");
        }
        #endregion

        #region btn_shangtu_Click
        private void btn_shangtu_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_zhitongche;
            //直通车
            webBrowser1.Load("https://subway.simba.taobao.com/#!/campaigns/standards/index");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                Browser.SetJSFile(webBrowser1);
            }
        }


        #endregion

        #region btn_test_Click
        private void btn_test_Click(object sender, EventArgs e)
        {
            Browser.JS_CEFBrowser(txt_js.Text, webBrowser1);
        }
        #endregion

        #region btn_savehtml_Click
        private void btn_savehtml_Click(object sender, EventArgs e)
        {

        }
        #endregion



        #region btn_save_Click
        private void btn_save_Click(object sender, EventArgs e)
        {
            string zuigaoprice = txt_gao.Text.Trim();
            string zuidioprice = txt_di.Text.Trim();
            string meiciprice = txt_meiciprice.Text.Trim();
            string zhanxianzhishu = txt_zhanxian_di.Text.Trim();

            string paiming = "1";
            if (rb_1015.Checked == true)
            {
                paiming = "5";
            }
            else if (rb_1620.Checked == true)
            {
                paiming = "6";
            }
            else if (rb_3.Checked == true)
            {
                paiming = "2";
            }
            else if (rb_46.Checked == true)
            {
                paiming = "3";
            }
            else if (rb_710.Checked == true)
            {
                paiming = "4";
            }
            else if (rb_shoutao.Checked == true)
            {
                paiming = "1";
            }

            XMLHelper.SetValue("ZhiTongChe_ZuiGaoPrice", zuigaoprice);
            XMLHelper.SetValue("ZhiTongChe_PaiMing", paiming);
            XMLHelper.SetValue("ZhiTongChe_ZuiDiPrice", zuidioprice);
            XMLHelper.SetValue("ZhiTongChe_MeiCiPrice", meiciprice);
            XMLHelper.SetValue("ZhiTongChe_ZuiDiZhanXian", zhanxianzhishu);
            bind();
        }
        #endregion

        #region btn_reset_Click
        private void btn_reset_Click(object sender, EventArgs e)
        {
            bind();

        }
        #endregion

        #region btn_noopen_Click
        private void btn_noopen_Click(object sender, EventArgs e)
        {
            Browser.SetJSFile(webBrowser1);
        }
        #endregion



        #region btn_kaiguan_Click
        private void btn_kaiguan_Click(object sender, EventArgs e)
        {
            if (kaiguan)
            {

                kaiguan = false;
                btn_kaiguan.BackColor = Color.Red;
                btn_kaiguan.Text = "开关-关闭";
            }
            else
            {
                kaiguan = true;
                btn_kaiguan.BackColor = Color.Green;
                btn_kaiguan.Text = "开关-打开";
            }
        }
        #endregion


        #region btn_chuci_Click 设置初次添加的关键词的出价
        private void btn_chuci_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_zhitongche;
            //关键词数量
            int keynum = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr').length", webBrowser1);
            if (keynum > 1)
            {
                //循环次数，第一栏是标题栏不处理
                for (int i = 1; i < keynum; i++)
                {
                    //获取手机端出价
                    string temp_phone_price = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByClassName('cp')[2].innerText", webBrowser1);
                    //如果不是初次设置则不设置
                    if (temp_phone_price != (zuidi + "元"))
                    {
                        //MessageBox.Show("");
                        continue;
                        /*break*/
                        ;
                    }
                    //跳转到目标
                    Browser.SetScrollByHtmlElement("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "]", webBrowser1);
                    //打开编辑价格窗口
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByClassName('icon-edit')[2].click()", webBrowser1);
                    Browser.Delay(2500);



                    //获取弹出窗口内容
                    //窗口变量
                    string boxindex = "1";

                    string temp_editboxinfo = Browser.JS_CEFBrowser("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].innerText", webBrowser1);
                    if (string.IsNullOrEmpty(temp_editboxinfo))
                    {
                        boxindex = "0";
                    }

                    //获取进入移动16～20建议出价:进入移动16～20建议出价：2.63元
                    string temp = Browser.JS_CEFBrowser("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('radio')[2].innerText", webBrowser1);
                    string temp_16_20 = Manager.SubString2(temp, "建议出价：", "元");
                    decimal temp_16_20_res = 0;
                    if (decimal.TryParse(temp_16_20, out temp_16_20_res))
                    {
                        //如果
                        if (temp_16_20_res < zuigao)
                        {
                            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('radio')[2].click()", webBrowser1);
                            Browser.Delay(1500);
                            //点击确定
                            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('btn-orange')[0].click()", webBrowser1);
                            Browser.Delay(1500);
                        }
                        else
                        {
                            //点击自定义
                            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('radio')[4].click()", webBrowser1);
                            //设置价格
                            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('input')[0].value='" + zuigao.ToString() + "'", webBrowser1);
                            Browser.Delay(1500);
                            //点击确定
                            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('btn-orange')[0].click()", webBrowser1);
                            Browser.Delay(1500);
                        }
                    }
                    if (!kaiguan)
                    {
                        return;
                    }

                }
            }

        }
        #endregion

        #region btn_setzhitongche_Click 拖价法
        private void btn_setzhitongche_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tp_zhitongche;
            //关键词数量
            int keynum = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr').length", webBrowser1);
            if (keynum > 1)
            {
                //循环次数，第一栏是标题栏不处理
                for (int i = 1; i < keynum; i++)
                {
                    //获取手机端出价
                    string temp_phone_price = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByClassName('cp')[2].innerText", webBrowser1);
                    //如果是初次设置则不设置
                    if (temp_phone_price == (zuidi + "元"))
                    {
                        //MessageBox.Show("");
                        continue;
                        /*break*/
                        ;
                    }
                    //跳转到目标
                    Browser.SetScrollByHtmlElement("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "]", webBrowser1);
                    //打开编辑价格窗口
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByClassName('icon-edit')[2].click()", webBrowser1);
                    Browser.Delay(2500);



                    //获取弹出窗口内容
                    //窗口变量
                    string boxindex = "1";

                    string temp_editboxinfo = Browser.JS_CEFBrowser("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].innerText", webBrowser1);
                    if (string.IsNullOrEmpty(temp_editboxinfo))
                    {
                        boxindex = "0";
                    }

                    //获取进入移动16～20建议出价:进入移动16～20建议出价：2.63元
                    string temp = Browser.JS_CEFBrowser("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('radio')[2].innerText", webBrowser1);
                    string temp_16_20 = Manager.SubString2(temp, "建议出价：", "元");
                    decimal temp_16_20_res = 0;
                    if (decimal.TryParse(temp_16_20, out temp_16_20_res))
                    {
                        //如果
                        if (temp_16_20_res < zuigao)
                        {
                            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('radio')[2].click()", webBrowser1);
                            Browser.Delay(1500);
                            //点击确定
                            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('btn-orange')[0].click()", webBrowser1);
                            Browser.Delay(1500);
                        }
                        else
                        {
                            //点击自定义
                            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('radio')[4].click()", webBrowser1);
                            //设置价格
                            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('input')[0].value='" + zuigao.ToString() + "'", webBrowser1);
                            Browser.Delay(1500);
                            //点击确定
                            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('dialog-contentbox')[" + boxindex + "].getElementsByClassName('btn-orange')[0].click()", webBrowser1);
                            Browser.Delay(1500);
                        }
                    }
                    if (!kaiguan)
                    {
                        return;
                    }

                }
            }
        }





        #endregion

        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, EventArgs e)
        {
            Manager.dianpu_huan(webBrowser1);
        }

        #endregion

        #region btn_keys_Click 关键词审查




        private void btn_keys_Click(object sender, EventArgs e)
        {
            //获取关键词
            tabControl1.SelectedTab = tp_zhitongche;
            //关键词数量
            int keynum = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr').length", webBrowser1);
            if (keynum > 1)
            {
                List_keys = new List<keyurls>();
                List_Deleteing = new List<string>();
                //循环次数，第一栏是标题栏不处理
                for (int i = 1; i < keynum; i++)
                {
                    //获取关键词
                    //tabControl1.SelectedTab = tp_zhitongche;
                    //显示关键词居中
                    Browser.SetScrollByHtmlElement("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "]", webBrowser1);
                    //关键词
                    string temp_key = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('a')[0].innerText", webBrowser1);
                    //关键词网址
                    string temp_url = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('a')[0].href", webBrowser1);
                    //如果没有关键词跳出
                    if (string.IsNullOrEmpty(temp_key) || string.IsNullOrEmpty(temp_url))
                    {
                        continue;
                    }
                    ////添加到数据组
                    //keyurls ku = new keyurls();
                    //ku.Keyname = temp_key;
                    //ku.Keyurl = temp_url;
                    //List_keys.Add(ku);

                    //tabControl1.SelectedTab = tp_remark;
                    webBrowser2.Load(temp_url);
                    if (Browser.WaitWebPageLoad("document.getElementsByClassName('tabs-text')[3]", webBrowser2))
                    {
                        Browser.Delay(1500);
                        //点击数据透视
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('tabs-text')[3].click()", webBrowser2);
                        if (Browser.WaitWebPageLoad("document.getElementById('ot_impression2')", webBrowser2))
                        {
                            Browser.Delay(1500);
                            Browser.SetScrollByHtmlElement("document.getElementById('ot_impression2')", webBrowser2);
                            //获取展现指数
                            string temp_zhanxian = Browser.JS_CEFBrowser(" document.getElementById('ot_impression2').innerText", webBrowser2);
                            temp_zhanxian = temp_zhanxian.Replace(",", "");
                            int temp_zhanxian_res = 0;
                            if (int.TryParse(temp_zhanxian, out temp_zhanxian_res))
                            {
                                if (temp_zhanxian_res < zuidizhanxian)
                                {
                                    KeyClicked(i);
                                    //选中关键词
                                    KeyColor(i);
                                    List_Deleteing.Add(temp_key);
                                }

                                //关键词显示展现指数
                                KeyEdit(i, temp_zhanxian);
                            }
                        }
                    }

                    //如果开关关闭则跳出
                    if (!kaiguan)
                    {
                        tabControl1.SelectedTab = tp_zhitongche;
                        DeleteKey_JiLu();
                        return;
                    }
                }
            }
            DeleteKey_JiLu();
            tabControl1.SelectedTab = tp_zhitongche;
        }
        #endregion


        #region btn_liuliangjiexi_Click
        private void btn_liuliangjiexi_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_remark;
            webBrowser1.Load("http://subway.simba.taobao.com/#!/tools/insight/index");
        }
        #endregion

        #region 基础方法

        /// <summary>
        /// 选中关键词
        /// </summary>
        /// <param name="indexx">第几个</param>
        void KeyClicked(int indexx)
        {
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + indexx.ToString() + "].getElementsByTagName('input')[0].click() ", webBrowser1);
        }

        /// <summary>
        /// 关键词添加文字
        /// </summary>
        /// <param name="indexx"></param>
        /// <param name="str">要添加的文字</param>
        void KeyEdit(int indexx, string str)
        {
            //关键词
            string temp_key = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + indexx.ToString() + "].getElementsByTagName('a')[0].innerText", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + indexx.ToString() + "].getElementsByTagName('a')[0].innerText='" + temp_key + "_" + str + "'", webBrowser1);
        }

        /// <summary>
        /// 修改关键词的颜色
        /// </summary>
        /// <param name="indexx"></param>
        void KeyColor(int indexx)
        {
            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + indexx.ToString() + "].getElementsByTagName('a')[0].style.backgroundColor='#ff9999'", webBrowser1);
        }

        /// <summary>
        /// 记录要删除的关键词
        /// </summary>
        void DeleteKey_JiLu()
        {
            if (List_Deleteing.Count > 0)
            {
                //操作对比添加
            }
        }


        #endregion



    }

    #region 关键词类-临时
    /// <summary>
    /// 关键词类-临时
    /// </summary>
    class keyurls
    {
        /// <summary>
        /// 关键词
        /// </summary>
        private string keyname;
        /// <summary>
        /// 关键词链接
        /// </summary>
        private string keyurl;

        public string Keyname
        {
            get
            {
                return keyname;
            }

            set
            {
                keyname = value;
            }
        }

        public string Keyurl
        {
            get
            {
                return keyurl;
            }

            set
            {
                keyurl = value;
            }
        }
    }
    #endregion


}

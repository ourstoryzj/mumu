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

namespace Operation.TaoBao
{
    public partial class TB_ZhiTongChe : Form
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
        //decimal chujia = 0;
        //设置最低展现指数
        decimal zuidizhanxian = 0;
        //开关
        bool kaiguan = true;
        /// <summary>
        /// 全选开关
        /// </summary>
        int allselect = 0;


        public TB_ZhiTongChe()
        {
            #region 取消先登录淘宝功能
            //Login tb = new Login();
            //tb.Show();
            //if (Manager.WaitLogin(tb))
            //{
            //    tb.Hide();
            //    InitializeComponent();

            //    this.StartPosition = FormStartPosition.CenterScreen;
            //    webBrowser1 = new ChromiumWebBrowser("http://zhitongche.taobao.com/");
            //    webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //    webBrowser1.FrameLoadEnd += WebBrowser1_FrameLoadEnd;
            //    webBrowser1.Size = new Size(990, 725);
            //    //webBrowser1.Location = new Point(180, 12);
            //    webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //    tp_zhitongche.Controls.Add(webBrowser1);
            //    webBrowser1.RequestContext = tb.webBrowser1.RequestContext;
            //    //跳转运行这个代码
            //    //webBrowser1.LoadingStateChanged += WebBrowser1_LoadingStateChanged;
            //    tb.Close();
            //    tb.Dispose();


            //    webBrowser2 = new ChromiumWebBrowser("http://subway.simba.taobao.com/#!/tools/insight/index");
            //    webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //    webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //    webBrowser2.Size = new Size(990, 725);
            //    //webBrowser2.Location = new Point(0, 325);
            //    webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //    webBrowser2.RequestContext = webBrowser1.RequestContext;
            //    tp_remark.Controls.Add(webBrowser2);


            //    //txt_chengfa.Text = XMLHelper.GetValue("TaoBao_Copy_ChengFa");
            //    //txt_jiafa.Text = XMLHelper.GetValue("TaoBao_Copy_JiaFa");
            //}
            #endregion


            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("http://zhitongche.taobao.com/");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += WebBrowser1_FrameLoadEnd;
            webBrowser1.Size = new Size(990, 725);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tp_zhitongche.Controls.Add(webBrowser1);

            webBrowser2 = new ChromiumWebBrowser("http://subway.simba.taobao.com/#!/tools/insight/index");
            webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser2.Size = new Size(990, 725);
            webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tp_remark.Controls.Add(webBrowser2);


            dgv_goods.AutoGenerateColumns = false;
            dgv_keys.AutoGenerateColumns = false;

            bind();
            bind_goods();
            bind_goods_combobox();




        }

        #region WebBrowser1_FrameLoadEnd


        private void WebBrowser1_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            try
            {
                //ChromiumWebBrowser web = (ChromiumWebBrowser)sender;
                //string url = web.Address;
                ////string url = Browser.JS_CEFBrowser("document.location.href", web);
                //////"https://subway.simba.taobao.com/#!/campaigns/standards/adgroups/items/detail?tab=bidword&campaignId=46750245&adGroupId=858488207"
                //if (url.IndexOf("detail") != -1)
                //{
                //    btn_add_goods.Visible = true;
                //}
                //else
                //{
                //    btn_add_goods.Visible = false;
                //}

            }
            catch
            { }
        }

        #endregion

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


        void bind_goods()
        {
            string key_temp = txt_searchgoods.Text;
            string state_temp = cb_state_goods.Text == "请选择" ? "" : (cb_state_goods.Text == "启用" ? "1" : "2");

            IList<Entity.subway_goods> list = BLL2.subway_goodsManager.Search(1, 1000, key_temp, state_temp, "", new DateTime(), new DateTime(), "");
            dgv_goods.DataSource = list;


        }


        void bind_key()
        {
            string goodsid = cb_goods.SelectedValue.ToString();
            int gsid = 0;
            int.TryParse(goodsid, out gsid);

            string key = txt_searchkey.Text;
            DateTime temp_date1 = new DateTime();
            if (dateTimePicker1.Text != "请选择")
            {
                temp_date1 = dateTimePicker1.Value;
            }
            DateTime temp_date2 = new DateTime();
            if (dateTimePicker2.Text != "请选择")
            {
                temp_date2 = dateTimePicker2.Value;
            }
            string state = cb_state.Text;
            if (state == "正常")
            {
                state = "1";
            }
            else if (state == "删除")
            {
                state = "2";
            }
            else
            {
                state = "";
            }
            string tag = cb_tag.Text;
            if (tag == "观察")
            {
                tag = "1";
            }
            else if (tag == "优秀")
            {
                tag = "2";
            }
            else if (tag == "重点")
            {
                tag = "3";
            }
            else
            {
                tag = "";
            }
            string youhua = cb_makeprice.Text;
            if (youhua == "已优化")
            {
                youhua = "1";
            }
            else if (youhua == "未优化")
            {
                youhua = "2";
            }
            else
            {
                youhua = "";
            }

            IList<subway_key> list = BLL2.subway_keyManager.Search(1, 10000, key, state, gsid, tag, youhua, temp_date1, temp_date2, "");
            dgv_keys.DataSource = list;

        }

        void bind_goods_combobox()
        {
            IList<subway_goods> list = BLL2.subway_goodsManager.Search(1, 1000, "", "1", "", new DateTime(), new DateTime(), "sgdate");
            //cb_dianpu.DataSource = list;
            subway_goods sg = new subway_goods();
            sg.sgname = "请选择";
            sg.sgid = 0;
            list.Insert(0, sg);
            cb_goods.DataSource = list;
            cb_goods.DisplayMember = "sgname";
            cb_goods.ValueMember = "sgid";


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
            webBrowser2.RequestContext = webBrowser1.RequestContext;
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
            webBrowser2.Load("http://subway.simba.taobao.com/#!/tools/insight/index");
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



        #region dateTimePicker1_CloseUp

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }
        private void dateTimePicker2_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Long;
        }




        #endregion

        #region btn_reset_dgv_Click

        private void btn_reset_dgv_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "请选择";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "请选择";
            cb_tag.Text = "请选择";
            cb_makeprice.Text = "请选择";
            cb_state.Text = "请选择";
            //cb_kongbao.Text = "请选择";
        }

        #endregion


        #region dgv_keys
        private void dgv_keys_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1)
                {
                    string colname = dgv_keys.Columns[e.ColumnIndex].Name;
                    subway_key sr = (subway_key)dgv_keys.CurrentRow.DataBoundItem;

                    //if (dgv_title.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                    //{
                    //}
                    if (colname == "col_kongbao")
                    {

                    }


                }
                #region 全选



                else if (e.RowIndex == -1)
                {
                    //如果是全选
                    if (e.ColumnIndex == 0)
                    {
                        foreach (DataGridViewRow row in dgv_keys.Rows)
                        {
                            if (row.Index != -1)
                            {
                                DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                                cbx.Value = allselect == 0 ? true : false;
                            }
                        }
                        allselect = allselect == 1 ? 0 : 1;
                    }
                    else
                    {
                        try
                        {
                            //dgv_title.Sort(dgv_title.Columns[e.ColumnIndex], ListSortDirection.Descending);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("排序出错=========================" + ex.Message);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 动态显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_keys_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
        /// <summary>
        /// 修改保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_keys_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_keys_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv_keys.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv_keys.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 10);

        }

        #endregion


        #region btn_deletekey_Click

        private void btn_deletekey_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("是否要删除选中关键词?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    foreach (DataGridViewRow row in dgv_keys.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            if ((bool)cbx.FormattedValue)
                            {
                                subway_key key = (subway_key)row.DataBoundItem;
                                BLL2.subway_keyManager.Delete(key.skid);
                            }
                        }
                    }

                    dgv_keys.Refresh();
                    MessageBox.Show("批量删除关键词成功");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #endregion


        #region btn_search_Click
        private void btn_search_Click(object sender, EventArgs e)
        {
            bind_key();
        }
        #endregion




        #region btn_delete_goods_Click
        private void btn_delete_goods_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要删除选中关键词?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    foreach (DataGridViewRow row in dgv_goods.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            if ((bool)cbx.FormattedValue)
                            {
                                subway_goods key = (subway_goods)row.DataBoundItem;
                                BLL2.subway_goodsManager.Delete(key.sgid);
                            }
                        }
                    }

                    dgv_goods.Refresh();
                    MessageBox.Show("批量删除关键词成功");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #endregion


        #region btn_add_goods_Click
        private void btn_add_goods_Click(object sender, EventArgs e)
        {
            addGoods();
        }
        #endregion

        #region btn_search_goods_Click


        private void btn_search_goods_Click(object sender, EventArgs e)
        {
            bind_goods();
        }


        #endregion

        #region btn_keys_add_Click

        private void btn_keys_add_Click(object sender, EventArgs e)
        {
            try
            {

                List<subway_key> list = caijiKeys();
                if (list == null)
                {
                    return;
                }
                int okcount = 0;
                int errorcount = 0;
                string mess = " 添加失败关键词： ";
                foreach (subway_key sk in list)
                {
                    if (BLL2.subway_keyManager.Insert(sk) == 1)
                    {
                        okcount++;
                    }
                    else
                    {
                        errorcount++;
                        mess += " " + sk.skname;
                    }

                }

                if (errorcount > 0)
                {
                    MessageBox.Show("共" + list.Count.ToString() + "个关键词，其中有" + errorcount.ToString() + " 个关键词添加失败。 " + mess);
                }
                else
                {
                    MessageBox.Show("共" + list.Count.ToString() + "个关键词，全部添加成功");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        #endregion




        #region 私有方法

        #region addGoods
        /// <summary>
        /// 添加商品
        /// </summary>
        void addGoods()
        {
            try
            {
                string url = webBrowser1.Address;
                ////"https://subway.simba.taobao.com/#!/campaigns/standards/adgroups/items/detail?tab=bidword&campaignId=46750245&adGroupId=858488207"
                ///https://subway.simba.taobao.com/#!/campaigns/standards/adgroups/items/detail?tab=bidword&campaignId=46750245&adGroupId=871163459
                if (url.IndexOf("detail") != -1)
                {

                    subway_goods sg = new subway_goods();



                    //获取商品直通车ID
                    string adGroupId = Manager.GetURLParam(url, "adGroupId");
                    //获取商品名称
                    string name = Browser.JS_CEFBrowser("document.getElementsByClassName('adgroup-details-text')[0].getElementsByTagName('span')[0].innerText", webBrowser1);
                    //获取商品链接
                    string href = Browser.JS_CEFBrowser("document.getElementsByClassName('adgroup-details-text')[0].getElementsByTagName('a')[0].href", webBrowser1);
                    //获取商品类目
                    string goodstype = Browser.JS_CEFBrowser("document.getElementsByClassName('adgroup-details-text')[0].getElementsByTagName('span')[1].innerText", webBrowser1);
                    DateTime dt = DateTime.Now;


                    if (BLL2.subway_goodsManager.SearchNum("", "", adGroupId, new DateTime(), new DateTime()) > 0)
                    {
                        MessageBox.Show("该商品已经存在");
                        return;
                    }


                    sg.sgcampaignid = adGroupId;
                    sg.sgdate = dt;
                    sg.sgname = name;
                    sg.sgremark = goodstype;
                    sg.sgremark2 = href;
                    sg.sgstate = "1";



                    if (BLL2.subway_goodsManager.Insert(sg) == 1)
                    {
                        MessageBox.Show("保存成功");
                        bind_goods();
                        bind_goods_combobox();
                    }
                    else
                    {
                        MessageBox.Show("保存失败");
                    }


                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion


        #region caijiKeys
        /// <summary>
        /// 采集关键词
        /// </summary>
        List<subway_key> caijiKeys()
        {
            List<subway_key> list = new List<subway_key>();
            try
            {
                string url = webBrowser1.Address;
                ////"https://subway.simba.taobao.com/#!/campaigns/standards/adgroups/items/detail?tab=bidword&campaignId=46750245&adGroupId=858488207"
                ///https://subway.simba.taobao.com/#!/campaigns/standards/adgroups/items/detail?tab=bidword&campaignId=46750245&adGroupId=871163459
                if (url.IndexOf("detail") != -1)
                {


                    int sgid = 0;
                    //获取商品直通车ID
                    string adGroupId = Manager.GetURLParam(url, "adGroupId");
                    if (BLL2.subway_goodsManager.SearchNum("", "", adGroupId, new DateTime(), new DateTime()) == 0)
                    {
                        addGoods();
                    }
                    IList<subway_goods> list_temp = BLL2.subway_goodsManager.Search(1, 10, "", "", adGroupId, new DateTime(), new DateTime(), "");
                    if (list_temp.Count > 0)
                    {
                        sgid = list_temp[0].sgid;
                    }
                    //获取获取不到商品编号则跳出
                    if (sgid == 0)
                    {
                        MessageBox.Show("获取商品id 失败");
                        return null;
                    }


                    #region 采集数据日期 备份

                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('time-sel')[0].click()", webBrowser1);
                    //Browser.Delay(500);

                    ////数据日期1
                    //string temp_datadate1 = Browser.JS_CEFBrowser("document.getElementsByClassName('datepicker-bd')[0].getElementsByTagName('input')[0].value", webBrowser1);
                    ////数据日期2
                    //string temp_datadate2 = Browser.JS_CEFBrowser("document.getElementsByClassName('datepicker-bd')[0].getElementsByTagName('input')[1].value", webBrowser1);


                    //if (temp_datadate1 != temp_datadate2)
                    //{
                    //    MessageBox.Show("暂时只能采集一天的数据，您选择了多天");
                    //    return null;
                    //}

                    //DateTime temp_datatate = new DateTime();
                    //if (!DateTime.TryParse(temp_datadate1, out temp_datatate))
                    //{
                    //    MessageBox.Show("获取数据日期错误！");
                    //    return null;
                    //}
                    #endregion


                    DateTime temp_datatate = getDataDate();
                    if (temp_datatate == new DateTime())
                    {
                        return null;
                    }



                    //关键词数量
                    int keynum = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr').length", webBrowser1);
                    if (keynum > 1)
                    {
                        //List_keys = new List<keyurls>();
                        //List_Deleteing = new List<string>();
                        //循环次数，第一栏是标题栏不处理
                        for (int i = 1; i < keynum; i++)
                        {

                            #region 方法分离-备份



                            ////实体化
                            //subway_key sk = new subway_key();


                            //sk.sgid = sgid;


                            ////获取关键词
                            ////tabControl1.SelectedTab = tp_zhitongche;
                            ////显示关键词居中
                            //Browser.SetScrollByHtmlElement("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "]", webBrowser1);
                            ////关键词
                            //string temp_key = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('a')[0].innerText", webBrowser1);
                            ////关键词网址
                            //string temp_url = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('a')[0].href", webBrowser1);
                            ////如果没有关键词跳出
                            //if (string.IsNullOrEmpty(temp_key) || string.IsNullOrEmpty(temp_url))
                            //{
                            //    continue;
                            //}

                            ////移动质量分
                            //string temp_zhiliangfen = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[5].innerText", webBrowser1);
                            ////移动排名
                            //string temp_paiming = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[7].innerText", webBrowser1);
                            ////PC出价
                            //string temp_pcprice = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[8].innerText", webBrowser1);
                            ////移动出价
                            //string temp_phoneprice = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[9].innerText", webBrowser1);
                            ////展现量
                            //string temp_zhanxian = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[10].innerText", webBrowser1);
                            ////点击量
                            //string temp_dianji = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[11].innerText", webBrowser1);
                            ////点击率
                            //string temp_dianjilv = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[12].innerText", webBrowser1);
                            ////花费
                            //string temp_zonghuafei = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[13].innerText", webBrowser1);
                            ////平均点击花费
                            //string temp_pingjunhuafei = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[14].innerText", webBrowser1);
                            ////总购物车
                            //string temp_gouwuche = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[15].innerText", webBrowser1);
                            ////总收藏
                            //string temp_shoucang = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[16].innerText", webBrowser1);
                            ////成交笔数
                            //string temp_chengjiao = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[17].innerText", webBrowser1);
                            ////投入产出比ROI
                            //string temp_roi = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[18].innerText", webBrowser1);
                            ////转化率
                            //string temp_zhuanhualv = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[19].innerText", webBrowser1);




                            //sk.skconverage = temp_zhuanhualv;
                            //sk.skcar = temp_gouwuche;
                            //sk.skclick = temp_dianji;
                            //sk.skcost = temp_zonghuafei;
                            //sk.skcpc = temp_pingjunhuafei;
                            //sk.skctr = temp_dianjilv;
                            //sk.skdateadd = DateTime.Now;
                            //sk.skdatedata = temp_datatate;
                            //sk.skfav = temp_shoucang;
                            //sk.skimpression = temp_zhanxian;
                            //sk.skmakeprice = "1";
                            //sk.skmobileprice = temp_phoneprice;
                            //sk.skname = temp_key;
                            //sk.skpcprice = temp_pcprice;
                            //sk.skrank = temp_paiming;
                            //sk.skroi = temp_roi;
                            //sk.skscore = temp_zhiliangfen;
                            //sk.skstate = "1";
                            //sk.skvol = temp_zonghuafei;


                            #endregion

                            subway_key sk = caijiOneKey(i, sgid, temp_datatate);
                            if (sk != null)
                            {
                                list.Add(sk);
                            }

                            //如果开关关闭则跳出
                            if (!kaiguan)
                            {
                                tabControl1.SelectedTab = tp_zhitongche;
                                DeleteKey_JiLu();
                                return null;
                            }
                        }
                    }


                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return list;

        }
        #endregion


        #region 采集一行数据
        /// <summary>
        /// 采集一行的数据
        /// </summary>
        /// <param name="i">第几行</param>
        /// <param name="sgid">商品id</param>
        /// <param name="temp_datatate">数据日期</param>
        /// <returns></returns>
        subway_key caijiOneKey(int i, int sgid, DateTime temp_datatate)
        {

            //实体化
            subway_key sk = new subway_key();


            sk.sgid = sgid;


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
                return null;
            }

            //移动质量分
            string temp_zhiliangfen = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[5].innerText", webBrowser1);
            //移动排名
            string temp_paiming = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[7].innerText", webBrowser1);
            //PC出价
            string temp_pcprice = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[8].innerText", webBrowser1);
            //移动出价
            string temp_phoneprice = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[9].innerText", webBrowser1);
            //展现量
            string temp_zhanxian = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[10].innerText", webBrowser1);
            //点击量
            string temp_dianji = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[11].innerText", webBrowser1);
            //点击率
            string temp_dianjilv = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[12].innerText", webBrowser1);
            //花费
            string temp_zonghuafei = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[13].innerText", webBrowser1);
            //平均点击花费
            string temp_pingjunhuafei = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[14].innerText", webBrowser1);
            //总购物车
            string temp_gouwuche = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[15].innerText", webBrowser1);
            //总收藏
            string temp_shoucang = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[16].innerText", webBrowser1);
            //成交笔数
            string temp_chengjiao = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[17].innerText", webBrowser1);
            //投入产出比ROI
            string temp_roi = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[18].innerText", webBrowser1);
            //转化率
            string temp_zhuanhualv = Browser.JS_CEFBrowser("document.getElementsByClassName('bp-table')[1].getElementsByTagName('tr')[" + i.ToString() + "].getElementsByTagName('td')[19].innerText", webBrowser1);




            sk.skconverage = temp_zhuanhualv;
            sk.skcar = temp_gouwuche;
            sk.skclick = temp_dianji;
            sk.skcost = temp_zonghuafei;
            sk.skcpc = temp_pingjunhuafei;
            sk.skctr = temp_dianjilv;
            sk.skdateadd = DateTime.Now;
            sk.skdatedata = temp_datatate;
            sk.skfav = temp_shoucang;
            sk.skimpression = temp_zhanxian;
            sk.skmakeprice = "1";
            sk.skmobileprice = temp_phoneprice;
            sk.skname = temp_key;
            sk.skpcprice = temp_pcprice;
            sk.skrank = temp_paiming;
            sk.skroi = temp_roi;
            sk.skscore = temp_zhiliangfen;
            sk.skstate = "1";
            sk.skvol = temp_chengjiao;

            return sk;

        }
        #endregion

        #region 获取数据日期
        /// <summary>
        /// 获取数据日期
        /// </summary>
        /// <returns></returns>
        DateTime getDataDate()
        {
            DateTime datatate1 = new DateTime();
            DateTime datatate2 = new DateTime();

            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('time-sel')[0].click()", webBrowser1);
            Browser.Delay(500);






            //数据日期1
            string temp_datadate1 = Browser.JS_CEFBrowser("document.getElementsByClassName('datepicker-bd')[0].getElementsByTagName('input')[0].value", webBrowser1);
            //数据日期2
            string temp_datadate2 = Browser.JS_CEFBrowser("document.getElementsByClassName('datepicker-bd')[0].getElementsByTagName('input')[1].value", webBrowser1);

            if (!DateTime.TryParse(temp_datadate1, out datatate1))
            {
                MessageBox.Show("获取数据日期错误！");
                return new DateTime();
            }


            if (!DateTime.TryParse(temp_datadate2, out datatate2))
            {
                MessageBox.Show("获取数据日期错误！");
                return new DateTime();
            }


            if (datatate1 != datatate2)
            {
                MessageBox.Show("暂时只能采集一天的数据，您选择了多天");
                return datatate1;
            }



            return datatate1;
        }

        #endregion



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

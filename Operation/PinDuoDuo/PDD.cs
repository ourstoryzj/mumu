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
    public partial class PDD : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser2;
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

        public PDD()
        {

            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("https://mms.pinduoduo.com/login/");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(990, 725);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tp_kefus.Controls.Add(webBrowser1);


            webBrowser1 = new ChromiumWebBrowser("https://mms.pinduoduo.com/Pdd.html#/index");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(990, 725);
            //webBrowser1.Location = new Point(0, 60);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tp_houtai.Controls.Add(webBrowser1);

            //webBrowser3 = new ChromiumWebBrowser("https://baidu.com");
            //webBrowser3.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //webBrowser3.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //webBrowser3.Size = new Size(990, 725);
            ////webBrowser1.Location = new Point(0, 60);
            //webBrowser3.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //tabPage2.Controls.Add(webBrowser3);

            //timer1.Interval = XMLHelper.GetValue("PinDuoDuo_AutoAnswerTime").ToInt();
            bind_Account();
            bind();

        }

        #region bind

        void bind()
        {
            auto_answer = 0;
            btn_message.Text = "自动回复-已关闭";
            btn_message.BackColor = Color.Red;
        }

        void bind_Account()
        {
            string typesum = XMLHelper.GetValue("PinDuoDuoAccountNum");
            int tempsum_temp = 0;
            if (int.TryParse(typesum, out tempsum_temp))
            {
                for (int i = 0; i < tempsum_temp; i++)
                {
                    cb_account.Items.Add(XMLHelper.GetValue("PinDuoDuo_Account" + (i + 1), "title"));
                }
                cb_account.SelectedIndex = 0;
            }
        }


        #endregion

        #region 基础

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
            tabControl1.SelectedTab = tp_houtai;
            //window.location.href = "https://mms.pinduoduo.com/windows-mms/"
            webBrowser1.Load("https://mms.pinduoduo.com/windows-mms/");
        }
        #endregion

        #region btn_dingdan_Click
        private void btn_dingdan_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_houtai;
            webBrowser1.Load("https://mms.pinduoduo.com/aftersales/aftersale_list");
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
            tabControl1.SelectedTab = tp_kefus;
            webBrowser1.Load("https://mms.pinduoduo.com/assets/chat-merchant/dist/index.html?r=0.5309851365977418");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                Browser.Delay(10000);
                //取消对话框提示框
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('modal')[0].remove();", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('content-list-item-msg')[0].remove();", webBrowser1);
            }
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

        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {

            int accountindex = cb_account.SelectedIndex;
            string access = XMLHelper.GetValue("PinDuoDuo_Account" + (accountindex + 1));
            string pwd = XMLHelper.GetValue("PinDuoDuo_Pwd" + (accountindex + 1));
            if (CS.PinDuoDuo.LoginKeFu(access, pwd, webBrowser1))
            {
                btn_message.PerformClick();
            }

        }

        #endregion





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

        #region bak-刷单发货功能





        #region btn_index_Click
        private void btn_index_Click(object sender, EventArgs e)
        {
            //webBrowser3.Load("http://mobile.yangkeduo.com/");
        }
        #endregion

        #region btn_geren_Click


        private void btn_geren_Click(object sender, EventArgs e)
        {
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('footer-item-icon')[4].click()", webBrowser3);
            //webBrowser3.Load(" http://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_sn=10002");

        }
        #endregion

        #region btn_pddorders_Click


        private void btn_pddorders_Click(object sender, EventArgs e)
        {
            //webBrowser3.Load("http://mobile.yangkeduo.com/orders.html?type=0&refer_page_name=personal&&refer_page_sn=10001");
        }

        #endregion



        private void btn_getphone_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(phone))
            {
                Common.MessageAPI.AddBlack(token, phone);
                Common.MessageAPI.ClearPhone(token, phone);
            }
            string res = Common.MessageAPI.GetPhone(token);
            txt_phone.Text = res;
            phone = res;
            Auto.Ctrl_C(phone);

        }

        private void btn_phone_open_Click(object sender, EventArgs e)
        {
            string p = txt_phone.Text.Trim();
            string res = Common.MessageAPI.GetPhone(token, p);
            txt_phone.Text = res;
            phone = res;
            MessageBox.Show(res);
        }

        private void btn_Phone_Click(object sender, EventArgs e)
        {
            btn_Phone.Enabled = false;
            string res = "";
            int i = 0;
            //每3秒循环获取验证码
            do
            {

                txt_yanzhengma.Text = "正在获取验证码，请稍后。。。 " + Manager.RandomNumber(1000, 99999).ToString();
                res = Common.MessageAPI.GetMessage(token);
                if (res.IndexOf("验证码") == -1)
                {
                    //Thread.Sleep(3000);
                    Browser.Delay(3000);
                }
                //获取10次
                i++;
                if (i == 10)
                {
                    btn_Phone.Enabled = true;
                    MessageBox.Show("没有获取到验证码");
                    return;
                }
            } while (res.IndexOf("验证码") == -1);
            //得到验证码
            txt_yanzhengma.Text = res;
            string str = txt_yanzhengma.Text;
            if (!string.IsNullOrEmpty(str))
            {
                Auto.Ctrl_C(CS.PinDuoDuo.GetYanZhengMa(str));
                //Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('telcode')[0].value=" + Mogujie.getYanZhengMa(str), webBrowser1);
                //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('sub')[0]", webBrowser1);
            }
            //webBrowser1.Focus();
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('telcode')[0].value=" + Mogujie.getYanZhengMa(res), webBrowser1);
            ////MessageBox.Show(getYanZhengMa(res));
            //Browser.Delay(1000);
            //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('sub')[0]", webBrowser1);
            btn_Phone.Enabled = true;
            //txt_yanzhengma.Text = res + " 如需再次获取验证码，请5秒后操作 " + Manager.RandomNumber(1000, 99999).ToString();
            //MessageBox.Show("如需再次获取验证码，请5秒后操作");
        }

        private void btn_yanzhengma_Click(object sender, EventArgs e)
        {
            string str = txt_yanzhengma.Text;
            if (!string.IsNullOrEmpty(str))
            {
                Auto.Ctrl_C(CS.PinDuoDuo.GetYanZhengMa(str));
                //Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('telcode')[0].value=" + Mogujie.getYanZhengMa(str), webBrowser1);
                //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('sub')[0]", webBrowser1);
            }
        }

        private void btn_pddlogin_Click(object sender, EventArgs e)
        {
            //Browser.ClearData();
            //Browser.ClearContext(webBrowser3);
            //webBrowser3.Load("http://mobile.yangkeduo.com/login.html");

        }

        private void txt_phone_Click(object sender, EventArgs e)
        {
            string str = txt_phone.Text.Trim();
            Auto.Ctrl_C(str);
        }

        private void btn_budanfahuo_Click(object sender, EventArgs e)
        {
            //webBrowser4.Load("http://www.uu338.com/Member/DanHaoSearch.aspx");
        }

        private void btn_weifahuo_Click(object sender, EventArgs e)
        {

        }


        #endregion

        #region btn_message_Click 自动回复开关
        private void btn_message_Click(object sender, EventArgs e)
        {
            if (auto_answer == 1)
            {
                auto_answer = 0;
                btn_message.Text = "自动回复-已关闭";
                btn_message.BackColor = Color.Red;
            }
            else
            {
                auto_answer = 1;
                btn_message.Text = "自动回复-已开启";
                btn_message.BackColor = Color.Green;
            }



        }
        #endregion

        #region 自动回复方法
        /// <summary>
        /// 自动回复
        /// </summary>
        void Auto_Answers()
        {
            //判断是否开启自动回复
            if (auto_answer == 1)
            {
                //判断是否需要重新登录客服系统，根据网址，断网，异地登录等情况
                //document.getElementsByTagName('body')[0].innerText ：断网后登录不成功，会显示空白页
                //账户在别处登录 ： 异地登录或者断网后登录失败提示
                //正在尝试第n次登录 ：断网后自动重新登录的提示窗口显示内容
                string url = webBrowser1.Address;
                if (url.IndexOf("chat") == -1 || webBrowser1.ToJsHasElementToBool("getElementsByInnerText2('账户在别处登录')[0]") || webBrowser1.ToJsHasElementToBool("getElementsByInnerText2('正在尝试第')[0]") || webBrowser1.ToJsHasElementToBool("getElementsByInnerText2('登录过期')[0]") || string.IsNullOrEmpty(webBrowser1.ToJs("document.getElementsByTagName('body')[0].innerText")))
                {
                    timer1.Stop();
                    Common.Manager.EmailSend("ourstoryzj@163.com", "拼多多客服断开提示", "拼多多客服断开提示");
                    //登陆客服
                    webBrowser1.Load("https://mms.pinduoduo.com/assets/chat-merchant/dist/index.html?r=0.5309851365977418");
                    //Browser.Delay(20000);
                    if (Browser.WaitWebPageLoad(webBrowser1))
                    {

                        Browser.Delay(20000);

                        //Browser.JS_CEFBrowser_NoReturn("alert('开始关闭广告')", webBrowser1);
                        //取消对话框提示框
                        CS.PinDuoDuo.ClearAP(webBrowser1);
                    }
                    timer1.Start();
                }
                else
                {
                    //获取是否有正在回复的客户,如果有则跳出
                    if (xmlpdd.GetValue("answering") == "1")
                        return;

                    //判断是否有需要回复的内容
                    if (Browser.JS_CEFBrowserHasElementToBool(xmlpdd.GetValue("client_five"), webBrowser1))
                    {
                        this.Focus();
                        webBrowser1.Focus();
                        CS.PinDuoDuo.ClearAP(webBrowser1);
                        //自动回复等待时间
                        timer1.Stop();
                        Browser.Delay(XMLHelper.GetValue("PinDuoDuo_AutoAnswerTime").ToInt());
                        timer1.Start();
                        //如果没有需要回复的,代表已经人工回复,则退出
                        if (!Browser.JS_CEFBrowserHasElementToBool(xmlpdd.GetValue("client_five"), webBrowser1))
                        {
                            return;
                        }


                        //打开客服页面
                        tabControl1.SelectedTab = tp_kefus;
                        //设置xml文件中，正在回复
                        xmlpdd.SetValue("answering", "1");
                        //点击需要回复的内容
                        Browser.JS_CEFBrowser_NoReturn("ElementClickPDD(" + xmlpdd.GetValue("client_five") + ");", webBrowser1);
                        Browser.Delay(1000);
                        //获取需要回复的内容
                        string ask = Browser.JS_CEFBrowser(xmlpdd.GetValue("client_message_last"), webBrowser1);
                        //等待显示时间大概200ms
                        Browser.Delay(200);

                        //判断需要回复的内容，如果没有则添加问题，同时屏蔽不添加问题的关键词,然后没有的话自动回复统一内容，发邮件信息
                        string answer = ToDo_AutoContent(ask);
                        //string answer = "您好，本店于1月14日开始休年假，2月11日上班，期间订单上班后会尽快发出发出，有需要可以直接下单，其他问题可留言，我们会不定期上线回复。给您带来不便，请见谅。";
                        if (string.IsNullOrEmpty(answer))
                        {
                            answer = xmlpdd.GetValue("client_answerInfo");
                        }
                        //显示窗口到第一屏
                        Manager.SetShowAndTop();
                        this.MdiParent.WindowState = FormWindowState.Maximized;
                        this.MdiParent.TopMost = true;
                        this.WindowState = FormWindowState.Maximized;
                        this.TopMost = true;
                        this.Show();
                        Browser.Delay(300);
                        //开始回复-复制粘贴
                        //点击输入窗口
                        webBrowser1.Focus();
                        Browser.MouseLeftByHtmlElement(xmlpdd.GetValue("client_replyText"), webBrowser1);
                        Browser.MouseLeftByHtmlElement(xmlpdd.GetValue("client_replyText"), webBrowser1);
                        //复制粘贴
                        Auto.Ctrl_V(answer);
                        //回车
                        Auto.Key_Enter();
                        //关闭显示窗口到第一屏
                        this.TopMost = false;
                        this.MdiParent.TopMost = false;
                        //设置xml文件中，关闭正在回复
                        xmlpdd.SetValue("answering", "0");

                    }

                }
            }
        }

        #endregion

        #region 处理自动回复的内容
        string ToDo_AutoContent(string ask)
        {

            string answer = "";



            //获取拼多多自动回复话术id
            IList<huashu> list = BLL.huashuManager.Search(1, 100, "拼多多自动回复", "", "0", new DateTime(), new DateTime());
            huashu fu = new huashu();
            if (list.Count == 0)
                return answer;
            fu = list[0];
            //根据id获取所有话术
            IList<huashu> list2 = BLL.huashuManager.Search(1, 100, "", "", fu.hid.ToString(), new DateTime(), new DateTime());
            //用于检查是否已经有该问题
            //bool isok = false;
            //判断问题中是否有答案
            foreach (huashu hs in list2)
            {
                //if (isok)
                //{
                //    break;
                //}
                //多个标题用同一个答案时，标题可以用|隔开
                string[] titles = hs.htitle.Split('|');
                foreach (string str in titles)
                {
                    if (ask.IndexOf(str) > -1)
                    {
                        //如果有答案则返回答案，如果没有就过掉，因为会有自动登记的问题
                        if (!string.IsNullOrEmpty(hs.hcontext))
                        {
                            answer = hs.hcontext;
                        }
                        //如果有问题，没有答案，设置不用再次登记，然后问题的次数+1,更新数据
                        //isok = true;
                        hs.hcount = hs.hcount + 1;
                        BLL.huashuManager.Update(hs);
                        if (hs.hsendemail == "1")
                        {
                            Manager.EmailSend("181193051@qq.com", "拼多多客服:" + ask, ask);
                        }
                        //break;
                        return answer;
                    }
                }

            }
            //如果没有答案则登记
            //如果没有答案，则记录在txt文本中，返回默认通用答案
            //if (!isok)
            //{
            int count = BLL.huashuManager.SearchNum(ask, "", fu.hid.ToString(), new DateTime(), new DateTime());
            if (count == 0)
            {
                huashu hss = new huashu();
                hss.htitle = ask;
                hss.hcount = 1;
                hss.hdate = DateTime.Now;
                hss.hfid = fu.hid;
                hss.hsort = 10000;
                hss.hstate = "2";
                hss.hsendemail = "2";
                BLL.huashuManager.Insert(hss);
            }

            return answer;
        }
        #endregion

        #region timer1_Tick


        DateTime chongzhi1 = DateTime.Now;
        //是否正在重置中，（如果xml 中一直显示占用，则开启重置，一分钟后重置为）
        bool chongzhiing = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //判断是否有正在回复，如果有则跳出，如果没有则执行自动回复
            if (xmlpdd.GetValue("answering") == "0")
            {
                Auto_Answers();
            }
            else
            {
                if (!chongzhiing)
                {
                    chongzhiing = true;
                    //开始计时1分钟如果一直是占用则，重置为0
                    chongzhi1 = DateTime.Now;
                }
                else
                {
                    if (DateTime.Now.ToString("HHmmss").ToInt() > chongzhi1.AddMinutes(1).ToString("HHmmss").ToInt())
                    {
                        xmlpdd.SetValue("answering", "0");
                        chongzhiing = false;
                    }
                }

            }

        }


        #endregion

        #region 链接



        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_houtai;
            webBrowser1.Load("https://mms.pinduoduo.com/exp/tools/index");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_houtai;
            webBrowser1.Load("https://mms.pinduoduo.com/exp/tools/dataAnalysis");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_houtai;
            webBrowser1.Load("https://mms.pinduoduo.com/exp/search/index");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_houtai;
            webBrowser1.Load("https://mms.pinduoduo.com/exp/pro/index");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_houtai;
            webBrowser1.Load("https://mms.pinduoduo.com/sycm/goods_effect");

        }


        #endregion


        #region button6_Click
        //登录淘集集客服
        private void button6_Click(object sender, EventArgs e)
        {
            //string shopid = XMLHelper.GetValue("TaoJiJi_ShopID1");
            //string account = XMLHelper.GetValue("TaoJiJi_Account1");
            //string pwd = XMLHelper.GetValue("TaoJiJi_Pwd1");
            //TaoJiJiHelper.LoginKeFu(shopid, account, pwd, webBrowser3);
        }
        #endregion


        #region btn_unsalable_Click
        private void btn_unsalable_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_houtai;
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

        #region btn_closead_Click

        private void btn_closead_Click(object sender, EventArgs e)
        {
            CS.PinDuoDuo.ClearAP(webBrowser1);
        }
        #endregion

        private void btn_messageone_Click(object sender, EventArgs e)
        {

        }
    }


}

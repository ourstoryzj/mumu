using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Operation.CefsharpHelpers;
using CefSharp;
using Common;
using CefSharp.WinForms;
using System.Data.SqlClient;
using Entity;

namespace Operation
{
    public partial class CefBrowser : Form
    {

        CefsharpHelper chrome = null;

        Entity.shuadan_records sr = null;

        /// <summary>
        /// 是否自动下单(根据链接)
        /// </summary>
        bool isauto = false;

        /// <summary>
        /// 是否设置付款状态为已付款
        /// </summary>
        bool ispayed = false;

        public CefBrowser()
        {
            InitializeComponent();
            Cef.EnableHighDPISupport();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//用于多线程访问控件
            //获取启动参数
            string[] CmdArgs = System.Environment.GetCommandLineArgs();


            #region bak
            //for (int i = 0; i < CmdArgs.Length; i++)
            //{
            //    //参数0是它本身的路径
            //    MessageBox.Show(CmdArgs[i]);
            //}

            //测试
            //string args = "{'sdid':0,'sdgoodsname':null,'sdgoodsurl':'mobile.yangkeduo.com/duo_coupon_landing.html?goods_id=2586741146&pid=9648809_137935113&cpsSign=CC_200423_9648809_137935113_15965411c45e29c13611906b9a2940fa&duoduo_type=3','sddptype':'3','sddate':'0001-01-01T00:00:00','sdorderid':null,'sdphone':'4412705686695','sdvpn':'58.218.214.132:8063','sdaddress':'T5QQT6PDG2ZZ2NREK3VTJ2PUTW6XRVRSGFHQ4CY5NAPWIUYA4AQQ110a782','sdwuliu':null,'sdremark1':null,'sdremark3':null,'sdremark2':null,'sdremark4':null,'sdremark5':null,'sdremark6':'2'}";
            //sr = Newtonsoft.Json.JsonConvert.DeserializeObject<Entity.shuadan_records>(args);
            //if (sr != null)
            //{
            //    sr.sddate = DateTime.Now;
            //}
            //return;

            //string args = "{sdid:0,sdgoodsname:null,sdgoodsurl:mobile.yangkeduo.com/duo_coupon_landing.html?goods_id=2586741146&pid=9648809_137935113&cpsSign=CC_200423_9648809_137935113_15965411c45e29c13611906b9a2940fa&duoduo_type=3,sddptype:3,sddate:0001-01-01T00:00:00,sdorderid:null,sdphone:4412705686695,sdvpn:58.218.214.132:8063,sdaddress:T5QQT6PDG2ZZ2NREK3VTJ2PUTW6XRVRSGFHQ4CY5NAPWIUYA4AQQ110a782,sdwuliu:null,sdremark1:null,sdremark3:null,sdremark2:null,sdremark4:null,sdremark5:null,sdremark6:2}";

            //sr = new Entity.shuadan_records();
            //string[] agrs = args.ToSplit(",");

            //foreach (var item in agrs)
            //{
            //    string[] agrs2 = item.ToSplit(":");
            //    string temp = agrs2[0];
            //    if (agrs2[0] == "sdgoodsurl")
            //    {
            //        sr.sdgoodsurl = agrs2[1];
            //    }
            //    else if (agrs2[0] == "sddptype")
            //    {
            //        sr.sddptype = agrs2[1];
            //    }
            //    else if (agrs2[0] == "sdphone")
            //    {
            //        sr.sdphone = agrs2[1];
            //    }
            //    else if (agrs2[0] == "sdvpn")
            //    {
            //        sr.sdvpn = agrs2[1];
            //    }
            //    else if (agrs2[0] == "sdaddress")
            //    {
            //sr.sdaddress = agrs2[1];
            //    }
            //}

            //测试插入数据
            //sr = new Entity.shuadan_records();
            //sr.sdgoodsurl = "";
            //sr.sddptype = "3";
            //sr.sdphone = "5472535098";
            //sr.sdvpn = "";
            //sr.sdaddress = "OTGXAXDS5ICX4SEZBBTK5GPG7B3GW6K7KBVRYF5RXSVEIOSMLBJQ1123a4a";
            //bind();
            //return; 
            #endregion

            //CmdArgs.Length.ToString().ToShow();
            if (CmdArgs.Length > 1)
            {
                // txt_url.Text = CmdArgs[1];
                //CmdArgs[1].ToShow();
                try
                {
                    sr = new Entity.shuadan_records();
                    string[] agrs = CmdArgs[1].ToSplit(",");
                    foreach (var item in agrs)
                    {
                        //item.ToShow();
                        string[] agrs2 = item.ToSplit(":");
                        if (agrs2.Length > 1)
                        {

                            string temp = agrs2[0];
                            if (temp == "sdgoodsurl")
                            {
                                sr.sdgoodsurl = agrs2[1];
                            }
                            else if (temp == "sddptype")
                            {
                                sr.sddptype = agrs2[1];
                            }
                            else if (temp == "sdphone")
                            {
                                sr.sdphone = agrs2[1];
                            }
                            else if (temp == "sdvpn")
                            {
                                try
                                {
                                    sr.sdvpn = agrs2[1] + ":" + agrs2[2];
                                }
                                catch { }
                            }
                            else if (temp == "sdaddress")
                            {
                                sr.sdaddress = agrs2[1];
                            }
                        }
                    }
                    sr.sddate = DateTime.Now;
                    sr.sdremark6 = "2";

                    //sr = Newtonsoft.Json.JsonConvert.DeserializeObject<Entity.shuadan_records>(CmdArgs[1].Replace("\"","'"));
                    //if (sr != null)
                    //{
                    //    sr.sddate = DateTime.Now;
                    //}
                }
                catch (Exception ex)
                {
                    ex.ToShow();
                    sr = null;
                }
            }
            if (CmdArgs.Length > 2)
            {
                try
                {
                    string temp = CmdArgs[2];
                    bool.TryParse(temp, out isauto);
                }
                catch 
                {
                }
            }
            if (CmdArgs.Length > 3)
            {
                try
                {
                    string temp = CmdArgs[3];
                    bool.TryParse(temp, out ispayed);
                }
                catch
                {
                }
            }

            //MessageBox.Show(isauto.ToString());
            if (sr != null)
            {
                bind(sr.sdgoodsurl);
                txt_url.Text = sr.sdgoodsurl;
            }
            else
            {
                bind();
            }
        }

        #region bind
        void bind()
        {
            bind("th://empty");
        }

        void bind(string url)
        {
            if (chrome == null)
            {
                chrome = new CefsharpHelper(url);
                //处理代理ip
                if (sr != null)
                {
                    //chrome.Init(sr.sdvpn);
                    if (string.IsNullOrEmpty(sr.sdvpn))
                    {
                        chrome.Init("", true);
                    }
                    else
                    {
                        chrome.Init(sr.sdvpn, true);
                        //sr.sdvpn.ToShow();
                    }
                }
                else
                {
                    chrome.Init("", true);
                }
                //IBrowserHost.NotifyScreenInfoChanged();
                var browser = chrome.CreateBrowser();
                panel1.Controls.Add(browser);
                panel1.Update();
                //chrome.SetHeader();
                if (sr != null)
                {
                    var domain = "mobile.yangkeduo.com";
                    chrome.SetCookies(domain, "pdd_user_id", sr.sdphone);
                    chrome.SetCookies(domain, "PDDAccessToken", sr.sdaddress);
                    //chrome.SetHeader();
                    //chrome.JumpUrl("www.baidu.com/s?wd=ip");
                    //chrome.JumpUrl(sr.sdgoodsurl);
                }
                else
                {
                    "未获取账户信息".ToShow();
                }

                browser.FrameLoadEnd += Browser_FrameLoadEnd;

            }
        }
        #endregion


        #region bind Browser_FrameLoadEnd

        private void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;
            //浏览器缩放比例
            browser.SetZoomLevel(0.1);
            //Browser.SetJSFile(browser);

        }



        #endregion

        #region 私有方法


        /// <summary>
        /// 是否执行第三个方法
        /// </summary>
        bool autobuy_3 = true;

        void AutoBuy()
        {
            timer1.Stop();
            try
            {
                #region 自动下单
                //bool isauto = true;
                var browser = chrome.browser;
                int delay = 500;
                if (isauto)
                {

                    if (browser.Address.IndexOf("mobile.yangkeduo.com/goods.html?") != -1)
                    {
                        //timer1.Stop();
                        Common.Browser.Delay(delay);
                        browser.ToJs("getElementsByInnerText('收藏')[0].click()");
                        Common.Browser.Delay(delay);
                        if (browser.ToJsInt("getElementsByInnerText('去拼单').length") > 6)
                        {
                            browser.ToJs("getElementsByInnerText('去拼单')[0].click()");
                            Common.Browser.Delay(delay);
                            browser.ToJs("getElementsByInnerText('参与拼单')[1].click()");
                        }
                        else
                        {
                            //如果拼单数量不到6则发起拼单
                            browser.ToJs("getElementsByInnerText('发起拼单')[0].click()");
                        }

                        Common.Browser.Delay(2000);

                        //点击sku
                        //Auto.Mouse_Left(new Point(80, 480));
                        //chrome.click(80, 480);
                        //模拟点击sku
                        //browser.ToJs("document.getElementsByClassName('sku-spec-value')[0].click()");
                        browser.ToJs("document.getElementsByClassName('sku-spec-value')[document.getElementsByClassName('sku-spec-value').length-1].click()");

                        Common.Browser.Delay(delay);
                        //chrome.click(panel1.Width / 2, panel1.Height - 30);
                        //模拟点击确定
                        browser.ToJs("getElementsByInnerText('确定')[0].click()");
                        //点击确定
                        //timer1.Start();
                    }

                }
                if (browser.Address.IndexOf("mobile.yangkeduo.com/order_checkout.html?") != -1)
                {
                    //timer1.Stop();
                    Common.Browser.Delay(delay);
                    browser.ToJs("getElementsByInnerText_Vague_NoChildren('支付宝')[0].click()");
                    Common.Browser.Delay(delay);
                    browser.ToJs("getElementsByInnerText('立即支付')[0].click()");
                    //timer1.Start();
                }

                if (browser.Address.IndexOf("psnl_verification.html") != -1)
                {
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('所有','')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('请点击','')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText.replace('侧',' 侧 ')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('全部',' ')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('对着你的',' ')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('字母',' 字母 ')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('位于','')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('上面的','')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('数字',' 数字 ')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('正下方',' 下方 ')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('的','')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('物体','')");
                    browser.ToJs("document.getElementsByClassName('picture-text')[0].innerText=document.getElementsByClassName('picture-text')[0].innerText.replace('小型',' 小型 ')");

                }

                #region 自动保存订单
                //如果是支付宝页面自动生成二维码，如果不是则清空
                if (browser.Address.IndexOf("mclient.alipay.com/home/exterfaceAssign.htm?") != -1)
                {

                    if (sr != null)
                    {
                        pan_pay.BackgroundImage = CS.AlipayHelper.CreateQRCode(browser.Address, 200);
                        pan_pay.Visible = true;

                        autobuy_3 = false;
                        sr.sdgoodsname = browser.Address;
                        string orderid = CS.PinDuoDuo.GetOrderIDByURL(browser.Address);
                        //只保存一次订单
                        if (sr.sdstatepay != "2")
                        {
                            if (!string.IsNullOrEmpty(orderid))
                            {
                                sr.sdorderid = orderid;
                                this.Text = "已经获取orderid";
                                //如果不是自动保存
                                if (!isauto)
                                {
                                    if (MessageBox.Show("是否要保存订单?", "确定", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        btn_save.PerformClick();
                                    }
                                }
                                else
                                {
                                    if (autobuy_3)
                                    {
                                        //sr.sdstatepay = "1";
                                        btn_save.PerformClick();
                                    }
                                    //自动保存
                                    
                                }
                            }
                        }
                    }
                }
                else
                {
                    //隐藏二维码
                    pan_pay.BackgroundImage = null;
                    pan_pay.Refresh();
                    pan_pay.Visible = false;
                }

                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                ex.ToShow();
            }
            timer1.Start();
        }


        private void btn_back_Click(object sender, EventArgs e)
        {
            chrome.Back();
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            chrome.Forward();
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            bind();
            chrome.JumpUrl(txt_url.Text);
        }

        private void btn_f12_Click(object sender, EventArgs e)
        {
            //chrome.ShowTools();
            chrome.JumpUrl("mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");
        }

        #endregion

        #region btn_save_Click
        private void btn_save_Click(object sender, EventArgs e)
        {
            //保存刷单记录
            if (sr != null)
            {
                sr.sddate = DateTime.Now;
                sr.sdremark2 = "1";
                sr.sdremark3 = "1";
                sr.sdremark4 = "1";
                sr.sdremark6 = "2";
                sr.sdstatepay = isauto ? "1" : "2";
                if (ispayed)
                    sr.sdstatepay = "1";
                try
                {
                    string sqlcom = "server=sqloledb;data source=qds16257965.my3w.com;User ID=qds16257965;pwd=QW013368zj@;Initial Catalog=qds16257965_db";
                    SqlConnection com = new SqlConnection(sqlcom);
                    com.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = com;
                    if (!string.IsNullOrEmpty(sr.sdorderid))
                    {
                        cmd.CommandText = "select count(*) from shuadan_records where sdorderid = '" + sr.sdorderid + "'";
                        int res = (int)cmd.ExecuteScalar();
                        if (res != 0)
                        {
                            res.ToString().ToShow();
                        }
                        if (res > 0)
                        {

                            this.Text = "订单" + sr.sdorderid + "已经存储";
                            return;
                        }
                    }

                    cmd.CommandText = "insert into  shuadan_records (sdgoodsname,sdgoodsurl,sddptype,sddate,sdorderid,sdphone,sdvpn,sdaddress,sdwuliu,sdremark1,sdremark3,sdremark2,sdremark4,sdremark5,sdremark6,sdstatepay,sdremark7,sdremark8,sdremark9,sdremark10)values(@sdgoodsname,@sdgoodsurl,@sddptype,@sddate,@sdorderid,@sdphone,@sdvpn,@sdaddress,@sdwuliu,@sdremark1,@sdremark3,@sdremark2,@sdremark4,@sdremark5,@sdremark6,@sdstatepay,@sdremark7,@sdremark8,@sdremark9,@sdremark10)";
                    SqlParameter[] sp = GetSqlParameters(sr);
                    cmd.Parameters.AddRange(sp);
                    int result = cmd.ExecuteNonQuery();
                    com.Close();

                }
                catch (Exception ex)
                {
                    ex.ToShow();
                }

                if (isauto)
                {
                    this.Text = "保存成功,付款成功";
                }
                else
                    "添加记录成功".ToShow();

                sr = null;
            }

        }
        #endregion


        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameters(shuadan_records shuadan_recordsExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdgoodsname))
            {
                list_param.Add(new SqlParameter("@sdgoodsname", shuadan_recordsExample.sdgoodsname));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdgoodsname", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdgoodsurl))
            {
                list_param.Add(new SqlParameter("@sdgoodsurl", shuadan_recordsExample.sdgoodsurl));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdgoodsurl", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sddptype))
            {
                list_param.Add(new SqlParameter("@sddptype", shuadan_recordsExample.sddptype));
            }
            else
            {
                list_param.Add(new SqlParameter("@sddptype", DBNull.Value));
            }
            if (shuadan_recordsExample.sddate != new DateTime() && shuadan_recordsExample.sddate != null)
            {
                list_param.Add(new SqlParameter("@sddate", shuadan_recordsExample.sddate.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else
            {
                list_param.Add(new SqlParameter("@sddate", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdorderid))
            {
                list_param.Add(new SqlParameter("@sdorderid", shuadan_recordsExample.sdorderid));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdorderid", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdphone))
            {
                list_param.Add(new SqlParameter("@sdphone", shuadan_recordsExample.sdphone));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdphone", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdvpn))
            {
                list_param.Add(new SqlParameter("@sdvpn", shuadan_recordsExample.sdvpn));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdvpn", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdaddress))
            {
                list_param.Add(new SqlParameter("@sdaddress", shuadan_recordsExample.sdaddress));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdaddress", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdwuliu))
            {
                list_param.Add(new SqlParameter("@sdwuliu", shuadan_recordsExample.sdwuliu));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdwuliu", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark1))
            {
                list_param.Add(new SqlParameter("@sdremark1", shuadan_recordsExample.sdremark1));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark1", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark3))
            {
                list_param.Add(new SqlParameter("@sdremark3", shuadan_recordsExample.sdremark3));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark3", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark2))
            {
                list_param.Add(new SqlParameter("@sdremark2", shuadan_recordsExample.sdremark2));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark2", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark4))
            {
                list_param.Add(new SqlParameter("@sdremark4", shuadan_recordsExample.sdremark4));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark4", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark5))
            {
                list_param.Add(new SqlParameter("@sdremark5", shuadan_recordsExample.sdremark5));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark5", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark6))
            {
                list_param.Add(new SqlParameter("@sdremark6", shuadan_recordsExample.sdremark6));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark6", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdstatepay))
            {
                list_param.Add(new SqlParameter("@sdstatepay", shuadan_recordsExample.sdstatepay));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdstatepay", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark7))
            {
                list_param.Add(new SqlParameter("@sdremark7", shuadan_recordsExample.sdremark7));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark7", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark8))
            {
                list_param.Add(new SqlParameter("@sdremark8", shuadan_recordsExample.sdremark8));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark8", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark9))
            {
                list_param.Add(new SqlParameter("@sdremark9", shuadan_recordsExample.sdremark9));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark9", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark10))
            {
                list_param.Add(new SqlParameter("@sdremark10", shuadan_recordsExample.sdremark10));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark10", DBNull.Value));
            }
            SqlParameter[] param = new SqlParameter[list_param.Count];
            int index = 0;
            foreach (SqlParameter p in list_param)
            {
                param[index] = p;
                index++;
            }
            return param;
        }
        #endregion

        #region CefBrowser_FormClosing

        private void CefBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭浏览器CefSharp.BrowserSubprocess
            try
            {
                //Common.Manager.ProcessKillByName("CefSharp.BrowserSubprocess");
                Cef.Shutdown();
            }
            catch (Exception ex)
            {
                this.Text = ex.Message;
            }
        }
        #endregion

        #region 私有方法

        private void 个人中心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chrome.ShowTools();
            //chrome.JumpUrl("mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");
        }

        private void 查询IPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chrome.JumpUrl("m.ip138.com/");
        }

        private void pan_pay_Paint(object sender, PaintEventArgs e)
        {

        }


        


        private void timer1_Tick(object sender, EventArgs e)
        {
            AutoBuy();
        }

        private void 查看参数ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] CmdArgs = System.Environment.GetCommandLineArgs();
            foreach (var str in CmdArgs)
            {
                str.ToShow();
            }
        }

        #endregion



    }
}

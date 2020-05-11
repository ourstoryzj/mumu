using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using System.Net;
using System.IO;
using CefSharp.WinForms;
using CefSharp;
using Entity;
using BLL;
using Newtonsoft.Json;

namespace Operation.PinDuoDuo
{
    public partial class PDD_DaiFa : Form
    {
        ChromiumWebBrowser webBrowser1;
        XMLHelpers xml = new XMLHelpers("PDD");

        #region PDD_DaiFa
        public PDD_DaiFa()
        {
            InitializeComponent();

            webBrowser1 = new ChromiumWebBrowser("https://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");
            
            bind();
            bind_cb();

            Cef.EnableHighDPISupport();
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += webbrowser_FrameLoadEnd;
            webBrowser1.Size = new Size(990, 725);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            webBrowser1.Dock = DockStyle.Fill;

            panel1.Controls.Add(webBrowser1);

            txt_address.GotFocus += Txt_address_GotFocus;

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

        }

        private void Txt_address_GotFocus(object sender, EventArgs e)
        {
            txt_address.SelectAll();
        }
        #endregion

        #region bind
        void bind()
        {
            //setcookies("api_uid", "rBQEGVyEcqajxSXXHdgWAg==");
            //setcookies("Hm_lvt_96d9d92b8a4aac83bc206b6c9fb2844a", "1557407896,1557408269,1557499888,1557544239");
            //setcookies("UM_distinctid", "16c90459b2227-0151cd9b7dd60e-43450521-1fa400-16c90459b24c7");
            //setcookies("ua", "Mozilla%2F5.0%20(Windows%20NT%206.1%3B%20WOW64)%20AppleWebKit%2F537.36%20(KHTML%2C%20like%20Gecko)%20Chrome%2F69.0.3497.100%20Safari%2F537.36");
            //setcookies("webp", "1");
            //setcookies("CNZZDATA1256793290", "1526114749-1566392675-https%253A%252F%252Fmobile.yangkeduo.com%252F%7C1574561620");
            //setcookies("msec", "1800000");
            //setcookies("rec_list_mall_bottom", "rec_list_mall_bottom_hjpSJh");//测试是否需要
            //setcookies("rec_list_orders", "rec_list_orders_Lm90jL");//测试是否需要
            //setcookies("group_rec_list", "group_rec_list_EJkdal");//测试是否需要
            //setcookies("group_rec_list", "group_rec_list_EJkdal");//测试是否需要







            //setcookies("JSESSIONID", "B115F172C0F9B3C67121C14B91022390");//测试是否需要

            //需要改变的
            //setcookies("_nano_fp", "XpdYXp9JXpmbXqdynC_wnc3izkRTuCCIwjlXTMPM");
            //setcookies("pdd_user_uin", "S2BYMXSYU3H7XKJEZP64VHHA6A_GEXDA");

            string pdd_user_id = xml.GetValue("pdd_user_id");
            string PDDAccessToken = xml.GetValue("PDDAccessToken");
            //string pdd_user_id = "4844821835342";
            //string PDDAccessToken = "6AAB6XWY2A2SCTWGAY3OW7T5IN44SZ7KEXRHNG6F7XAGF4X7AUPQ1124e6e";
            setcookies("pdd_user_id", pdd_user_id);
            setcookies("PDDAccessToken", PDDAccessToken);
            txt_token.Text = PDDAccessToken;
            //setcookies("pdd_user_id", "4897104401726");
            //setcookies("PDDAccessToken", "PTTIVUXHCETYNBRBRDUXMU4ZBKS27DL5KIHUOS5CCWHVBGVC2NNQ1113e9e");



        }
        #endregion

        #region webbrowser_FrameLoadEnd
        void webbrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {

            ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;
            //浏览器缩放比例
            browser.SetZoomLevel(0.5);
            //Browser.SetJSFile(browser);

            try
            {
                //如果是支付宝页面自动生成二维码，如果不是则清空
                if (browser.Address.IndexOf("mclient.alipay.com/home/exterfaceAssign.htm?") != -1)
                { 
                    pan_tool.BackgroundImage = CS.AlipayHelper.CreateQRCode(browser.Address, 200);
                    //CS.PinDuoDuo.GetOrderIDByURL(browser.Address).ToShow();
                }
                else
                    pan_tool.BackgroundImage = null;
                //showurl();
                txt_goodsurl.Text = webBrowser1.Address;
            }
            catch (Exception ex)
            {
                ex.ToString().ToShow();
            }


        }


        //void showurl()
        //{
        //    ThreadFunDelegate tfd = new ThreadFunDelegate(ThreadFun);
        //    tfd.Invoke();
        //}

        //delegate void ThreadFunDelegate();
        //void ThreadFun()
        //{
        //    txt_goodsurl.Text = webBrowser1.Address;
        //}


        #endregion

        #region setcookies
        void setcookies(string name, string value)
        {
            var domain = "mobile.yangkeduo.com";
            var cookieManager = CefSharp.Cef.GetGlobalCookieManager();
            cookieManager.SetCookieAsync("http://" + domain, new CefSharp.Cookie()
            {
                Domain = domain,
                Name = name,
                Value = value,
                Expires = DateTime.MinValue
            });
        }


        public static void SetCefCookies(string url, CookieCollection cookies)
        {
            //Cef.GetGlobalCookieManager().SetStoragePath(Environment.CurrentDirectory, true);
            //foreach (System.Net.Cookie c in cookies)
            //{
            //    var cookie = new CefSharp.Cookie
            //    {
            //        Creation = DateTime.Now,
            //        Domain = c.Domain,
            //        Name = c.Name,
            //        Value = c.Value,
            //        Expires = c.Expires
            //    };
            //    Task<bool> task = Cef.GetGlobalCookieManager().SetCookieAsync(url, cookie);
            //    while (!task.IsCompleted)
            //    {
            //        continue;
            //    }
            //    bool b = task.Result;
            //}
        }
        #endregion

        #region txt_url_TextChanged
        private void txt_url_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region button1_Click_1

        private void button1_Click_1(object sender, EventArgs e)
        {
            bind();
            webBrowser1.Load("https://mobile.yangkeduo.com/personal.html?refer_page_name=index&refer_page_id=10002_1574496288865_ZKZKA8HgWJ&refer_page_sn=10002&page_id=10001_1577246196934_4h0wdL6yBD&is_back=1");

        }
        #endregion

        #region button2_Click
        private void button2_Click(object sender, EventArgs e)
        {


            if (webBrowser1.Address.IndexOf("mobile.yangkeduo.com/addresses.html") == -1)
            {
                "请打开地址页面".ToShow();
                return;
            }

            string sheng = txt_sheng.Text.Trim();
            string shi = txt_shi.Text.Trim();
            string xian = txt_xian.Text.Trim();
            string name = txt_name.Text;
            string phonecode = txt_phone.Text;
            string address = txt_dizhi.Text;

            webBrowser1.ToWait();

            //点击编辑
            webBrowser1.ToJs("getElementsByInnerText_Vague_NoChildren('编辑')[0].click();");
            Manager.Delay(1000);


            //点击地址，打开选择地区
            webBrowser1.ToJs("document.getElementsByClassName('m-addr-region')[0].click();");
            //点击省
            webBrowser1.ToJs("document.getElementsByClassName('mars-ph-province')[0].click();");

            string[] ssx = { sheng, shi, xian };
            foreach (string temp in ssx)
            {
                Manager.Delay(1500);
                //循环遍历选择省
                int length = webBrowser1.ToJsInt("document.getElementsByClassName('mars-regions')[0].getElementsByTagName('li').length");
                for (int i = 0; i < length; i++)
                {
                    string name_temp = webBrowser1.ToJs("document.getElementsByClassName('mars-regions')[0].getElementsByTagName('li')[" + i + "].innerText");
                    if (name_temp.IndexOf(temp) > -1)
                    {
                        webBrowser1.ToJs("document.getElementsByClassName('mars-regions')[0].getElementsByTagName('li')[" + i + "].click()");
                        break;
                    }
                }
            }


            Manager.Delay(1000);
            //设置姓名
            //webBrowser1.ToMouseClick("document.getElementsByClassName('m-addr-name')[0]");
            webBrowser1.Focus();
            webBrowser1.ToJs(xml.GetValue("fh_SetNameFocus"));
            Auto.Ctrl_A();
            Auto.Ctrl_V(name);
            Manager.Delay(500);

            //设置电话
            //webBrowser1.ToMouseClick("document.getElementsByClassName('m-addr-mobile')[0]");
            webBrowser1.ToJs(xml.GetValue("fh_SetMobileFocus"));
            Auto.Ctrl_A();
            Auto.Ctrl_V(phonecode);
            Manager.Delay(500);
            //设置地址
            //webBrowser1.ToMouseClick("document.getElementById('address')");
            webBrowser1.ToJs(xml.GetValue("fh_SetAddressFocus"));
            Auto.Ctrl_A();
            Auto.Ctrl_V(address);


        }
        #endregion

        #region btn_jiexi_Click

        private void btn_jiexi_Click(object sender, EventArgs e)
        {
            string address_temp = txt_address.Text.Trim().Replace("，", ",").Replace("86-", "");

            //解析地址 孙凌美,13756089797,吉林省长春市其它区吉林省长春市汽车厂47街区31栋102室彩票站
            string[] address_temps = address_temp.Split(new char[] { ',' });
            foreach (string temp in address_temps)
            {
                if (temp.Trim().Length == 6)
                {
                    //如果是邮编
                }
                else if (temp.Trim().Length == 11)
                {
                    //如果是手机号码
                    txt_phone.Text = temp;
                }
                else if (temp.Trim().Length > 8)
                {
                    //如果是地址
                    if (temp.IndexOf("省") > -1)
                        txt_sheng.Text = temp.ToSubString("", "省");
                    else if (temp.IndexOf("自治区") > -1)
                        txt_sheng.Text = temp.ToSubString("", "自治区");
                    if (temp.IndexOf("市") > -1 && temp.IndexOf("省") > -1)
                        txt_shi.Text = temp.ToSubString("省", "市");
                    if (temp.IndexOf("市") > -1 && temp.IndexOf("区") > -1)
                        txt_xian.Text = temp.ToSubString("市", "区");
                    else if (temp.IndexOf("市") > -1 && temp.IndexOf("县") > -1)
                        txt_xian.Text = temp.ToSubString("市", "县");
                    else if (temp.IndexOf("市") > -1 && temp.IndexOf("镇") > -1)
                        txt_xian.Text = temp.ToSubString("市", "镇");

                    txt_dizhi.Text = temp;
                }
                else
                {
                    txt_name.Text = temp;
                }
            }
        }
        #endregion

        #region txt_address_Click
        private void txt_address_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_address_Click(object sender, EventArgs e)
        {
            //txt_address.SelectAll();

        }
        private void txt_address_DoubleClick(object sender, EventArgs e)
        {
            txt_address.SelectAll();
        }
        #endregion

        #region button3_Click
        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://mobile.yangkeduo.com/hub_monthly_card.html?_pdd_fs=1&_pdd_nc=ffffff&_pdd_tc=ffffff&cid=usercenter&refer_page_name=personal&refer_page_id=10001_1578666603060_doq93gubjb&refer_page_sn=10001");
        }



        #endregion

        #region 生成二维码
        private void btn_totool_Click(object sender, EventArgs e)
        {
            try
            {
                string url = webBrowser1.Address;
                pan_tool.BackgroundImage = CS.AlipayHelper.CreateQRCode(url, 200);
            }
            catch
            {
                "二维码生成失败".ToShow();
            }
        }


        #endregion

        #region button4_Click
        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.ToJs(txt_js.Text);
        }

        #endregion


        #region 商品管理


        #region btn_goodsadd_Click
        private void btn_goodsadd_Click(object sender, EventArgs e)
        {
            string goodsname = txt_goodsname.Text;
            string goodsurl = txt_goodsurl.Text;
            if (string.IsNullOrEmpty(goodsname))
            {
                "请输入商品名称".ToShow();
                return;
            }
            if (string.IsNullOrEmpty(goodsurl))
            {
                "请输入商品网址".ToShow();
                return;
            }

            //IList<Entity.Basic> list = BLL.BasicManager.Search(1, 10, "pdd_daifa_goods", "", 0, "");
            //if (list.Count > 0)
            //{
            //    Entity.Basic b = list[0];
            //    //GoodsUrls gu = Newtonsoft.Json.JsonConvert.DeserializeObject<GoodsUrls>(b.Sign2);

            //    List<GoodsUrls> list_goods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GoodsUrls>>(b.Sign2);
            //}
            List<GoodsUrls> list_goods = GetPDDGoods();
            if (list_goods != null)
            {
                GoodsUrls g = new GoodsUrls();
                g.goods = goodsname + "-" + goodsurl;
                list_goods.Add(g);
                string jn = Newtonsoft.Json.JsonConvert.SerializeObject(list_goods);

                IList<Entity.Basic> list = BLL.BasicManager.Search(1, 10, "pdd_daifa_goods", "", 0, "");
                if (list.Count > 0)
                {
                    Entity.Basic b = list[0];
                    b.Sign2 = jn;
                    BLL.BasicManager.Update(b);
                    "保存成功".ToShow();
                    bind_cb();
                }
            }


        }
        #endregion


        #region bind_cb
        void bind_cb()
        {
            try
            {
                List<GoodsInfo> list = GetPDDGoodsInfo();
                GoodsInfo gi = new GoodsInfo();
                gi.name = "请选择";
                gi.url = "";
                list.Insert(0, gi);

                cb_goods.DataSource = list;
                cb_goods.ValueMember = "url";
                cb_goods.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
        }

        #endregion

        #region GetPDDGoods
        List<GoodsUrls> GetPDDGoods()
        {
            List<GoodsUrls> list_goods = new List<GoodsUrls>();
            try
            {
                IList<Entity.Basic> list = BLL.BasicManager.Search(1, 10, "pdd_daifa_goods", "", 0, "");
                if (list.Count > 0)
                {
                    Entity.Basic b = list[0];
                    GoodsUrls g = new GoodsUrls();
                    list_goods = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GoodsUrls>>(b.Sign2);
                }
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
            return list_goods;
        }
        #endregion

        #region GetPDDGoodsInfo
        List<GoodsInfo> GetPDDGoodsInfo()
        {
            List<GoodsUrls> list = GetPDDGoods();
            List<GoodsInfo> res = new List<GoodsInfo>();
            try
            {
                foreach (GoodsUrls gu in list)
                {
                    string[] temp = gu.goods.ToSplit("-");
                    if (temp.Length > 1)
                    {
                        GoodsInfo g = new GoodsInfo();
                        g.name = temp[0];
                        g.url = temp[1];
                        res.Add(g);
                    }
                }
            }
            catch (Exception ex)
            {

                ex.ToLog();
            }
            return res;
        }

        #endregion

        #region button5_Click
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string url = cb_goods.SelectedValue.ToString();
                webBrowser1.Load(url);
            }
            catch (Exception ex)
            {

                ex.ToLog();
            }
        }

        #endregion

        #endregion

        #region 浏览器返回前进

        
        private void btn_back_Click(object sender, EventArgs e)
        {
            webBrowser1.ToJs("window.history.back()");
        }

        private void btn_go_Click(object sender, EventArgs e)
        {
            webBrowser1.ToJs("window.history.forward()");
        }
        #endregion

        private void btn_token_save_Click(object sender, EventArgs e)
        {
            string token = txt_token.Text.Trim();
            xml.SetValue("PDDAccessToken", token);
        }
    }







    public class GoodsUrls
    {
        public string goods { get; set; }
    }


    public class GoodsInfo
    {
        public string name { get; set; }
        public string url { get; set; }
    }

   



}

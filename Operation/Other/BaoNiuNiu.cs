using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using excel_operation.CS;
using System.IO;
using System.Diagnostics;


namespace excel_operation.Other
{
    public partial class BaoNiuNiu : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        //CefSharp.WinForms.ChromiumWebBrowser webBrowser2;
        string goodsname = "";
        string url = "";
        //string goodsname = "";
        string name = "";
        string phone = "";
        string sheng = "";
        string shi = "";
        string xian = "";
        string address = "";
        //搜索关键词
        //string key = "";
        string color = "";
        string remark = "";
        string num = "";


        public BaoNiuNiu()
        {
            //Login tb = new Login();
            //tb.Show();
            //if (Manager.WaitLogin(tb))
            //{
            //tb.Hide();
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("http://www.bao66.cn/web/");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(990, 725);
            //webBrowser1.Location = new Point(180, 12);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage1.Controls.Add(webBrowser1);
            //webBrowser1.RequestContext = tb.webBrowser1.RequestContext;
            //tb.Close();
            //tb.Dispose();


            //webBrowser2 = new ChromiumWebBrowser("http://www.taobao.com");
            //webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //webBrowser2.Size = new Size(990, 400);
            //webBrowser2.Location = new Point(0, 325);
            //webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            //webBrowser2.RequestContext = webBrowser1.RequestContext;
            //txt_url.Controls.Add(webBrowser2);



            //}

        }

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

        #region btn_addjs_Click
        private void btn_addjs_Click(object sender, EventArgs e)
        {
            Browser.SetJSFile(webBrowser1);
        }
        #endregion

        #region  btn_login_Click
        private void btn_login_Click(object sender, EventArgs e)
        {
            string access = CS.XMLHelper.GetValue("BaoNiuNiu_Access");
            string pwd = CS.XMLHelper.GetValue("BaoNiuNiu_Pwd");

            webBrowser1.Load("http://www.bao66.cn/user/login");
            if (Browser.WaitWebPageLoad2("document.getElementById('username')", webBrowser1))
            {
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('bao66_login_nav')[0].getElementsByTagName('li')[1].click()", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('username').value='" + access + "'", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('password').value='" + pwd + "'", webBrowser1);
                Browser.MouseLeftByHtmlElement("document.getElementById('inputcode')", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('inputcode').focus() ", webBrowser1);
            }
        }

        #endregion

        #region  GoDaiFaPage
        /// <summary>
        /// 进入代发订单页面
        /// </summary>
        /// <returns></returns>
        bool GoDaiFaPage()
        {
            bool res = false;
            webBrowser1.Load("http://www.bao66.cn/api/jump/daifa");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                //判断是否已经进入
                if (Browser.JS_CEFBrowser("document.getElementById('createbyurl')==null", webBrowser1) == "False")
                {
                    return true;
                }
            }
            //webBrowser1.Load("http://bao66.51daifa.com/seller/order_list");
            //if (Browser.WaitWebPageLoad(webBrowser1))
            //{
            //    if (Browser.JS_CEFBrowser("document.getElementById('createbyurl')==null", webBrowser1) == "False")
            //    {
            //        return true;
            //    }
            //}
            return res;
        }
        #endregion

        #region btn_jiexi_Click
        private void btn_jiexi_Click(object sender, EventArgs e)
        {
            ClearTxt();
            string datas = txt_data.Text;
            if (string.IsNullOrEmpty(datas))
            {
                MessageBox.Show("请输入大数据，直接复制订单详细页面即可");
                return;
            }
            //解析数据
            if (datas.IndexOf("淘宝") != -1)
            {
                #region 解析淘宝数据:订单详情页源码

                //goodsname = Manager.Substring(datas, "title\":\"", "\",\"serviceIcons\"");
                //color = Manager.Substring(datas, "颜色分类：\",\"value\":\"", "\"}}]}],\"auctionUrl");
                //remark = Manager.Substring(datas, "buyMessage\":\"", "\", \"orderBar");
                //num = Manager.Substring(datas, "quantity\":\"", "\",\"service\"");

                //string temp = Manager.Substring(datas, "address\":\"", "\",\"shipType");
                //string[] strs = temp.Split(new char[] { '，' });
                ////判断是否是有三个或4个
                //if (strs.Length >= 3)
                //{
                //    name = strs[0];
                //    //Debug.WriteLine(name);
                //    txt_name.Text = name;

                //    phone = strs[1];
                //    //Debug.WriteLine(phone);
                //    txt_phone.Text = phone;

                //    temp = strs[2];
                //    string[] strs2 = temp.Split(new char[] { ' ' });
                //    //Debug.WriteLine(strs2.Length.ToString());

                //    txt_address.Text = temp;
                //    if (strs2.Length >= 3)
                //    {
                //        sheng = strs2[0];
                //        shi = strs2[1];
                //        xian = strs2[2];
                //        address = strs2[3];
                //        if (strs2.Length >= 5)
                //            address = address + strs2[4];
                //        if (strs2.Length >= 6)
                //            address = address + strs2[5];
                //        if (strs2.Length >= 7)
                //            address = address + strs2[6];
                //    }

                //}

                #endregion

                #region 解析淘宝数据:点击发货后页面数据


                goodsname = Manager.Substring(datas, "创建时间：", "颜色分类");
                goodsname = goodsname.Substring(16, goodsname.Length - 16);
                goodsname = Manager.NoHTML(goodsname);
                goodsname = goodsname.Trim();
                goodsname = goodsname.Substring(0, 30);

                color = Manager.Substring(datas, "颜色分类：", "商家编码");
                color = Manager.NoHTML(color);

                num = Manager.Substring(datas, "×", "买家选择");
                num = Manager.NoHTML(num);

                if (datas.IndexOf("买家留言：") > -1)
                {
                    remark = Manager.Substring(datas, "买家留言：", "我的备忘");
                    remark = Manager.NoHTML(remark);
                }

                /* 修改地址版本一*/
                string temp = Manager.Substring(datas, "买家收货信息：", "修改收货信息");
                temp = Manager.NoHTML(temp);
                string[] strs = temp.Split(new char[] { '，' });
                
                if (strs.Length > 3)
                {
                    name = strs[2];
                    name = name.Trim();

                    phone = strs[3];
                    phone = phone.Trim();

                    address = strs[0];
                    if (address.IndexOf("省") != -1)
                    {
                        sheng = Manager.Substring(address, "", "省") + "省";
                        sheng = sheng.Trim();
                    }
                    else if (address.IndexOf("自治区") != -1)
                    {
                        sheng = Manager.Substring(address, "", "自治区") + "自治区";
                        sheng = sheng.Trim();
                    }
                }
                



                #endregion
            }
            else if (datas.IndexOf("蘑菇") != -1)
            {
                #region 解析蘑菇街数据



                goodsname = Manager.Substring(datas, "订单状态", "颜色");
                goodsname = Manager.NoHTML(goodsname);
                color = Manager.Substring(datas, "颜色：", "尺寸");
                color = Manager.NoHTML(color);

                num = Manager.Substring(datas, "¥", "买家信息");
                num = Manager.NoHTML(num);
                num = num.Substring(5, num.Length - 5);

                remark = Manager.Substring(datas, "买家备注：", "用户备注");
                remark = Manager.NoHTML(remark);
                name = Manager.Substring(datas, "收货人：", "收货地址");
                name = Manager.NoHTML(name);
                phone = Manager.Substring(datas, "联系电话：", "修改地址");
                phone = Manager.NoHTML(phone);
                address = Manager.Substring(datas, "收货地址：", "收货邮编");
                address = Manager.NoHTML(address);

                if (address.IndexOf("省") != -1)
                {
                    sheng = Manager.Substring(address, "", "省") + "省";
                }
                else if (address.IndexOf("自治区") != -1)
                {
                    sheng = Manager.Substring(address, "", "自治区") + "自治区";
                }


                #endregion
            }

            txt_goodsname.Text = goodsname;
            txt_address.Text = address;
            txt_name.Text = name;
            txt_phone.Text = phone;
            txt_qu.Text = xian;
            txt_sheng.Text = sheng;
            txt_shi.Text = shi;
            txt_color.Text = color;
            txt_remark.Text = remark;
            txt_num.Text = num;

            url = XMLHelper_FaHuo.GetValue(goodsname);
            if (string.IsNullOrEmpty(url))
            {
                txt_url.Text = "NULL:空";
            }
            else
            {
                txt_url.Text = url;
            }

            //GoDaiFaPage();
            //是否进入代发页面
            //if (!GoDaiFaPage())
            //{
            //    MessageBox.Show("请先登录，并进入代发页面");
            //    return;
            //}

            //鼠标移动到下一个按钮
            Auto.MoveMouseToPoint(btn_submit.PointToScreen(new Point(0, 0)));
        }
        #endregion

        #region txt_data_DoubleClick
        private void txt_data_DoubleClick(object sender, EventArgs e)
        {
            txt_data.SelectAll();
        }
        #endregion

        #region btn_clear_Click
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_data.Text = "";
            ClearTxt();
        }
        #endregion

        #region ClearTxt
        /// <summary>
        /// 清空文本信息，大数据除外
        /// </summary>
        void ClearTxt()
        {
            //txt_data.Text = "";
            txt_address.Text = "";
            txt_name.Text = "";
            txt_phone.Text = "";
            txt_qu.Text = "";
            txt_sheng.Text = "";
            txt_shi.Text = "";
            txt_url.Text = "";
            txt_color.Text = "";
            txt_remark.Text = "";
            txt_num.Text = "";

            name = "";
            phone = "";
            sheng = "";
            shi = "";
            xian = "";
            address = "";
            //搜索关键词
            //key = "";
            color = "";
            remark = "";
            num = "";
        }
        #endregion

        #region btn_submit_Click
        private void btn_submit_Click(object sender, EventArgs e)
        {
            url = txt_url.Text;
            name = txt_name.Text;
            phone = txt_phone.Text;
            sheng = txt_sheng.Text;
            shi = txt_shi.Text;
            xian = txt_qu.Text;
            address = txt_address.Text;
            color = txt_color.Text;
            num = txt_num.Text;

            //是否进入代发页面
            if (!GoDaiFaPage())
            {
                MessageBox.Show("请先登录，并进入代发页面");
                return;
            }


            //判断是否已经下单
            //Browser.JS_CEFBrowser_NoReturn("document.getElementById('keywords').value='" + name + "'", webBrowser1);
            //Browser.JS_CEFBrowser_NoReturn("document.getElementById('btnSearch').click();", webBrowser1);
            //Browser.Delay(1000);
            webBrowser1.Load("http://bao66.51daifa.com/seller/order_list?state=&keywords=" + phone);
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                string temp = Browser.JS_CEFBrowser("document.getElementsByClassName('table-condensed')[0].getElementsByClassName('receiver-address')[0].innerText", webBrowser1);
                if (!string.IsNullOrEmpty(temp))
                {
                    if (temp.IndexOf(name) > -1)
                    {
                        MessageBox.Show("该订单已经是多次下单！请留意！");
                    }
                }
            }



            //弹出通过网址创建订单
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('createbyurl').click()", webBrowser1);
            Browser.Delay(1000);
            //如果是网址
            if (url.IndexOf("http") != -1)
            {
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('new-url')[0].value='" + url + "'", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('add-product')[0].click()", webBrowser1);
                Browser.Delay(500);
                if (!string.IsNullOrEmpty(goodsname))
                {
                    XMLHelper_FaHuo.SetValue(goodsname, url);
                }
            }
            //数量
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('unit')[1].value='" + num + "'", webBrowser1);
            //姓名
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('receiver_title').value='" + name + "'", webBrowser1);
            //电话
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('receiver-mobile').value='" + phone + "'", webBrowser1);
            //地址：省市县+地址
            //string temp_address = sheng + " " + shi + " " + xian + " " + address;
            string temp_address = address;
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('receiver_address').value='" + temp_address + "'", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('address-parse')[0].click()", webBrowser1);
            Browser.Delay(500);
            Browser.JS_CEFBrowser_NoReturn("document.getElementById('receiver_address').value='" + temp_address + "'", webBrowser1);
            /* 修改地址版本一
            if (!string.IsNullOrEmpty(sheng))
            {
                ClearSheng(sheng);
                Browser.Delay(1000);
                //Browser.MouseLeftByHtmlElement("document.getElementById('receiver_address')", webBrowser1);
                //选择省位置
                Point p = Browser.GetPointScreenByHtmlElement("document.getElementById('receiver_address')", webBrowser1);
                p.Offset(0, -15);
                //点击选择省
                Auto.Mouse_Left(p);
                Auto.Mouse_Left();
                Browser.Delay(500);
                //点击要选择的省
                Point temp_p2 = p;
                temp_p2.Offset(0, 25);
                Auto.Mouse_Left(temp_p2);
                Browser.Delay(500);
                //点击选择省
                Auto.Mouse_Left(p);
                Browser.Delay(500);
                //点击要选择的省
                Point temp_p = p;
                temp_p.Offset(0, 40);
                Auto.Mouse_Left(temp_p);
            }
            */



        }
        #endregion

        #region ClearSheng
        /// <summary>
        /// 清除其他省
        /// </summary>
        /// <param name="str">省名称</param>
        void ClearSheng(string str)
        {
            string js = @"var ops= document.getElementById('receiver_state').options;var tempi=document.getElementById('receiver_state').options.length;var tempo=null;for(var i=0 ;i<tempi;i++){ if(ops[i].value=='" + str + "'){ tempo=ops[i] }}if(tempo!=null){ops.length = 0;ops.add(new Option(' 请选择省/市/其它...', '0')); ops.add(tempo);} ";
            //string js = @"var ops= document.getElementById('receiver_state').options;var tempi=document.getElementById('receiver_state').options.length;var tempo=null;for(var i=0 ;i<tempi;i++){ if(ops[i].value=='" + str + "'){ tempo=ops[i] }}if(tempo!=null){ops.length = 0; ops.add(tempo);ops.add(new Option(' 请选择省/市/其它...', '0'));} ";
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion


        #region 点击全选
        private void txt_data_Click(object sender, EventArgs e)
        {
            txt_data.SelectAll();
            //Auto.Ctrl_C();
        }

        private void txt_url_Click(object sender, EventArgs e)
        {
            txt_url.SelectAll();
            Auto.Ctrl_C();
        }

        private void txt_name_Click(object sender, EventArgs e)
        {
            txt_name.SelectAll();
            Auto.Ctrl_C();
        }

        private void txt_phone_Click(object sender, EventArgs e)
        {
            txt_phone.SelectAll();
            Auto.Ctrl_C();
        }

        private void txt_sheng_Click(object sender, EventArgs e)
        {
            txt_sheng.SelectAll();
            Auto.Ctrl_C();
        }

        private void txt_shi_Click(object sender, EventArgs e)
        {
            txt_shi.SelectAll();
            Auto.Ctrl_C();
        }

        private void txt_qu_Click(object sender, EventArgs e)
        {
            txt_qu.SelectAll();
            Auto.Ctrl_C();
        }

        private void txt_address_Click(object sender, EventArgs e)
        {
            txt_address.SelectAll();
            Auto.Ctrl_C();
        }

        private void txt_search_Click(object sender, EventArgs e)
        {
            txt_search.SelectAll();
            Auto.Ctrl_C();
        }

        private void txt_key_Click(object sender, EventArgs e)
        {
            txt_key.SelectAll();
            Auto.Ctrl_C();
        }

        #endregion

        #region  btn_search_Click
        private void btn_search_Click(object sender, EventArgs e)
        {
            string key = txt_search.Text;
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("请输入搜索关键词");
                txt_search.Focus();
                return;
            }
            //if (GoDaiFaPage())
            //{
            //Browser.JS_CEFBrowser_NoReturn("document.getElementById('keywords').value='" + key + "'", webBrowser1);
            //Browser.JS_CEFBrowser_NoReturn("document.getElementById('btnSearch').click();", webBrowser1);
            //Browser.Delay(1000);
            webBrowser1.Load("http://bao66.51daifa.com/seller/order_list?state=&keywords=" + key);
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                GetKuaiDiDanHao();
            }
            //}
        }
        #endregion

        #region 提取复制快递单号
        /// <summary>
        /// 提取复制快递单号
        /// </summary>
        void GetKuaiDiDanHao()
        {
            string danhao = Browser.JS_CEFBrowser("document.getElementsByClassName('table-condensed')[0].getElementsByClassName('text-danger')[0].innerText", webBrowser1);
            if (string.IsNullOrEmpty(danhao))
            {
                txt_kuaididanhao.Text = "";
            }
            else
            {
                danhao = danhao.Replace("(", "");
                danhao = danhao.Replace(")", "");
                txt_kuaididanhao.Text = danhao;
                Auto.Clipboard_In(danhao);
            }
        }
        #endregion

        #region btn_fuzhidanhao_Click
        private void btn_fuzhidanhao_Click(object sender, EventArgs e)
        {
            //GetKuaiDiDanHao();

            string key = txt_key.Text;
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("请输入搜索关键词");
                txt_key.Focus();
                return;
            }

            string temp = "http://www.bao66.cn/search/web,all," + key + ",,1,0.html";
            Manager.OpenProgram(temp);
            //webBrowser1.Load(temp);

        }
        #endregion

        #region txt_kuaididanhao_Click
        private void txt_kuaididanhao_Click(object sender, EventArgs e)
        {
            string danhao = txt_kuaididanhao.Text;
            if (!string.IsNullOrEmpty(danhao))
            {
                Auto.Clipboard_In(danhao);
            }
        }

        #endregion

        private void txt_data_TextChanged(object sender, EventArgs e)
        {

        }
    }



}

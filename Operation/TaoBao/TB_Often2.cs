using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using excel_operation.Other;
using excel_operation.CS;
using System.IO;
using System.Diagnostics;

namespace excel_operation.TaoBao
{
    public partial class TB_Often2 : Form
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


        public TB_Often2()
        {

            InitializeComponent();
            webBrowser3.Navigate("https://login.taobao.com/member/login.jhtml?f=top&redirectURL=https%3A%2F%2Fwww.taobao.com%2F&style=mini");



            //txt_chengfa.Text = XMLHelper.GetValue("TaoBao_Copy_ChengFa");
            //txt_jiafa.Text = XMLHelper.GetValue("TaoBao_Copy_JiaFa");
            //Login tb = new Login();
            //tb.Show();
            //if (Manager.WaitLogin(tb))
            //{
            //tb.Hide();


            //this.StartPosition = FormStartPosition.CenterScreen;
            //webBrowser3 = new ChromiumWebBrowser("http://www.taobao.com");
            //webBrowser3.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //webBrowser3.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //webBrowser3.Size = new Size(990, 725);
            ////webBrowser3.Location = new Point(180, 12);
            //webBrowser3.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //tabPage1.Controls.Add(webBrowser3);
            //webBrowser3.RequestContext = tb.webBrowser3.RequestContext;
            //tb.Close();
            //tb.Dispose();


            //webBrowser2 = new ChromiumWebBrowser("http://www.taobao.com");
            //webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //webBrowser2.Size = new Size(990, 400);
            //webBrowser2.Location = new Point(0, 325);
            //webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            //webBrowser2.RequestContext = webBrowser3.RequestContext;
            //txt_url.Controls.Add(webBrowser2);



            //}

        }

        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {
            //Manager.dianpu_huan(webBrowser3);
            webBrowser3.Navigate("https://login.taobao.com/member/login.jhtml?f=top&redirectURL=https%3A%2F%2Fwww.taobao.com%2F&style=mini");
        }

        #endregion

        #region btn_fenlei_Click
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fenlei_Click(object sender, System.EventArgs e)
        {
            webBrowser3.Navigate("https://siteadmin.taobao.com/category/index.htm");
            //webBrowser3.Load("https://siteadmin.taobao.com/category/index.htm");
            if (Browser.WaitWebPageLoad(webBrowser3))
            {
                Browser.JS_WebBrowser_NoReturn("getClassName('J_FoldTrigger')[1].click();  ", webBrowser3);
                Browser.Delay(300);
                Browser.JS_WebBrowser_NoReturn("document.getElementsByClassName('add-cat')[1].click();  ", webBrowser3);
                string name = DateTime.Today.ToString("MM-dd") + " NEWS";
                Browser.Delay(300);
                Browser.JS_WebBrowser_NoReturn("document.getElementsByClassName('look-me')[0].getElementsByTagName('input')[1].value='" + name + "'  ", webBrowser3);
                Browser.Delay(300);
                Browser.JS_WebBrowser_NoReturn("document.getElementsByClassName('release')[0].click();  ", webBrowser3);
                Browser.Delay(1500);
                Browser.JS_WebBrowser_NoReturn("getClassName('J_FoldTrigger')[1].click();  ", webBrowser3);
            }
        }
        #endregion


        #region btn_img_Click
        private void btn_img_Click(object sender, System.EventArgs e)
        {
            webBrowser3.Navigate("https://tadget.taobao.com/redaction/manager.htm");
        }

        #endregion

        #region btn_upnew_Click
        private void btn_upnew_Click(object sender, System.EventArgs e)
        {
            webBrowser3.Navigate("https://myseller.taobao.com/seller_admin.htm");
            webBrowser3.Focus();
            if (Browser.WaitWebPageLoad(" getElementsByDataSpm('d48')[0] ", webBrowser3))
            {
                //点击发布新品
                Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d48')[0] ", webBrowser3);
                if (Browser.WaitWebPageLoad(" document.getElementsByClassName('cc-tree-item')[3] ", webBrowser3))
                {
                    //Browser.Delay(100);
                    //点击“箱包皮具/热卖女包/男包”类目
                    Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('cc-tree-item')[3].click() ", webBrowser3);
                    Browser.Delay(500);
                    if (Browser.WaitWebPageLoad(" document.getElementsByClassName('cc-cbox-group')[4].getElementsByTagName('li')[1] ", webBrowser3))
                    {
                        //点击“双肩背包”类目
                        Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('cc-cbox-group')[4].getElementsByTagName('li')[1].click(); ", webBrowser3);


                        //Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('cc-cbox-group')[4].getElementsByTagName('li')[1] ", webBrowser3);
                        //等待刷新数据
                        Browser.Delay(100);
                        //点击发布
                        if (Browser.WaitWebPageLoad(" document.getElementById('J_CatePubBtn') ", webBrowser3))
                        {
                            Browser.MouseLeftByHtmlElement(" document.getElementById('J_CatePubBtn') ", webBrowser3);

                            //打开发布页面，设置默认选项
                            if (Browser.WaitWebPageLoad(" document.getElementsByName('radio0')[0] ", webBrowser3))
                            {
                                Browser.Delay(200);
                                //点击宝贝类型为全新
                                //Browser.MouseLeftByHtmlElement_Wait(" document.getElementsByName('radio0')[0] ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByName('radio0')[0].click(); ", webBrowser3);



                                //宝贝卖点
                                string maidian = XMLHelper.GetValue("TaoBao_MaiDian");
                                Auto.Clipboard_In(maidian);
                                Browser.MouseLeftByHtmlElement(" document.getElementById('subTitle').getElementsByTagName('textarea')[0]", webBrowser3);
                                Auto.Ctrl_V();
                                //Browser.JS_WebBrowser_NoReturn(" document.getElementById('subTitle').getElementsByTagName('textarea')[0].value='" + maidian + "' ", webBrowser3);


                                //货号
                                string huohao = "ZZD" + DateTime.Now.ToString("MMdd");//+ Manager.RandomNumber(1, 9).ToString();
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('inputbox')[2].getElementsByTagName('input')[0].value='" + huohao + "' ", webBrowser3);


                                //大小：小
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[1].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[1].getElementsByTagName('li')[3].click(); ", webBrowser3);

                                //容纳电脑尺寸：8寸
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[2].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[2].getElementsByTagName('li')[1].click(); ", webBrowser3);

                                //是否有背部缓冲棉：否
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[3].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[3].getElementsByTagName('li')[1].click(); ", webBrowser3);

                                //适用对象：儿童
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[4].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[4].getElementsByTagName('li')[4].click(); ", webBrowser3);

                                //防水程度：防泼水
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[5].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[5].getElementsByTagName('li')[3].click(); ", webBrowser3);

                                //性别：女
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[6].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[6].getElementsByTagName('li')[2].click(); ", webBrowser3);

                                //质地：帆布
                                //Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[7].click(); ", webBrowser3);
                                //Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[7].getElementsByTagName('li')[11].click(); ", webBrowser3);

                                //质地：PU
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[7].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[7].getElementsByTagName('li')[1].click(); ", webBrowser3);

                                Browser.Delay(1500);

                                //材质工艺：软面
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[8].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[8].getElementsByTagName('li')[5].click(); ", webBrowser3);




                                //提拎部件类型：软把
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[9].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[9].getElementsByTagName('li')[3].click(); ", webBrowser3);

                                //闭合方式：拉链
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[10].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[10].getElementsByTagName('li')[1].click(); ", webBrowser3);

                                //箱包外袋种类：内贴袋
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[11].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[11].getElementsByTagName('li')[2].click(); ", webBrowser3);

                                //流行元素：绣花
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[12].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[12].getElementsByTagName('li')[14].click(); ", webBrowser3);

                                //图案：纯色
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[13].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[13].getElementsByTagName('li')[1].click(); ", webBrowser3);

                                //夹层：无
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[14].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[14].getElementsByTagName('li')[2].click(); ", webBrowser3);

                                //箱包软硬：软
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[15].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[15].getElementsByTagName('li')[1].click(); ", webBrowser3);

                                //是否可折叠：否
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[16].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[16].getElementsByTagName('li')[2].click(); ", webBrowser3);

                                //成色：全新
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[17].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[17].getElementsByTagName('li')[1].click(); ", webBrowser3);

                                //适用场景：校园
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[18].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[18].getElementsByTagName('li')[2].click(); ", webBrowser3);

                                //风格：日韩
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[19].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[19].getElementsByTagName('li')[2].click(); ", webBrowser3);

                                //形状：
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[20].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[20].getElementsByTagName('li')[14].click(); ", webBrowser3);

                                //肩带样式：双根
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[21].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[21].getElementsByTagName('li')[2].click(); ", webBrowser3);

                                //里料素材：软把
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[22].click(); ", webBrowser3);
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[22].getElementsByTagName('li')[8].click(); ", webBrowser3);


                                //************************************************


                                //采购地：国内
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByName('radio3')[0].click(); ", webBrowser3);

                                //手机端描述：使用神笔模板编辑
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByName('radio11')[1].click(); ", webBrowser3);

                                //电脑端描述
                                string miaoshu = XMLHelper.GetValue("TaoBao_MiaoShu");
                                Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('ks-editor')[0].innerHTML=" + miaoshu, webBrowser3);


                                //********************************************
                                //品牌选择其他***
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[0].click(); ", webBrowser3);
                                //点选品牌查询框
                                //Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-search')[0].getElementsByTagName('input')[0].focus(); ", webBrowser3);
                                Browser.MouseLeftByHtmlElement_Wait(" document.getElementsByClassName('combobox-search')[0].getElementsByTagName('input')[0] ", webBrowser3);
                                Browser.Delay(500);
                                //系统粘贴
                                Auto.Clipboard_In("其他");
                                Auto.Clipboard_Out();
                                Browser.Delay(800);
                                //选择“other/其他”选项
                                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[0].getElementsByTagName('li')[0].click(); ", webBrowser3);
                                //********************************************
                                MessageBox.Show("可以开始上架新品了！");


                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region btn_dabiao_Click
        private void btn_dabiao_Click(object sender, System.EventArgs e)
        {
            webBrowser3.Navigate("https://myseller.taobao.com/seller_admin.htm");
            if (Browser.WaitWebPageLoad(webBrowser3))
            {
                //点击出售中的商品
                Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d45')[0] ", webBrowser3);
                Auto.Mouse_Left();
                if (Browser.WaitWebPageLoad(webBrowser3))
                {
                    //选择全选
                    //Browser.MouseLeftByHtmlElement(" getClassName('all-selector')[0] ", webBrowser3);
                    Browser.JS_WebBrowser_NoReturn(" getClassName('all-selector')[0].click();  ", webBrowser3);
                    //点击设置公益活动
                    Browser.JS_WebBrowser_NoReturn(" getClassName('operations')[1].getElementsByTagName('button')[5].click() ", webBrowser3);
                    //if (Browser.WaitWebPageLoad(webBrowser3))
                    //{
                    //    //选择公益项目
                    //    Browser.MouseLeftByHtmlElement(" getClassName('subTypeTabNav')[0].getElementsByTagName('li')[0]  ", webBrowser3);
                    //    //设置捐赠百分比J_baiText
                    //    Browser.JS_WebBrowser_NoReturn(" getClassName('J_baiText')[0].value='0.1'  ", webBrowser3);
                    //    //点击确定
                    //    Browser.MouseLeftByHtmlElement(" getClassName('J_submit')[0] ", webBrowser3);

                    //}
                }
            }
        }
        #endregion

        #region btn_xiaofeizhe_Click
        private void btn_xiaofeizhe_Click(object sender, System.EventArgs e)
        {
            //webBrowser3.Load("https://xiaobao.taobao.com/contract/user_contract.htm");
            //打开退货承诺页面
            webBrowser3.Navigate("https://xiaobao.taobao.com/contract/item_contract.htm?crtId=2");
            if (Browser.WaitWebPageLoad(" getClassName('J_CatSearch')[0] ", webBrowser3))
            {
                //打开类目下拉菜单
                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('J_CatSearch')[0].click(); ", webBrowser3);
                //下拉列表容器class=bf-contentbox，选择箱包类目
                Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('bf-contentbox')[0].getElementsByTagName('div')[64].click(); ", webBrowser3);
                //点击搜索
                Browser.JS_WebBrowser_NoReturn("document.getElementsByClassName('search-btn')[0].click();", webBrowser3);
                Browser.Delay(500);
                if (Browser.WaitWebPageLoad(webBrowser3))
                {
                    //判断是否有商品
                    if (Browser.JS_WebBrowser(" document.getElementById('J_GoodsList').getElementsByTagName('tr').length ", webBrowser3) != "1")
                    {
                        //选择全部
                        Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('all-goods')[0].getElementsByTagName('input')[0].click(); ", webBrowser3);
                        //选择批量操作
                        Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('batch-ctr')[0].click(); ", webBrowser3);
                        //点击确定
                        Browser.JS_WebBrowser_NoReturn(" document.getElementsByClassName('J_Sure')[0].click(); ", webBrowser3);
                    }
                }
            }
        }



        #endregion

        #region btn_dazhe_Click
        private void btn_dazhe_Click(object sender, EventArgs e)
        {
            //if (GoChaoJiDianZhang())
            //{
            //    if (Browser.WaitWebPageLoad(webBrowser3))
            //    {
            //        webBrowser3.Load("http://f.superboss.cc/ProductUsingServlet?kind=105&ftrace=0");
            //    }
            //}
            //app - ordered
            //卖家中心
            //webBrowser3.Load("https://myseller.taobao.com/seller_admin.htm");
            //if (Browser.WaitWebPageLoad(webBrowser3))
            //{
            //点击我订购的应用
            //Browser.MouseLeftByHtmlElement(" getClassName('app-ordered')[0] ", webBrowser3);
            //Auto.Mouse_Left();
            ////等待刷新数据
            //Browser.Delay(100);
            ////点击超级店长
            //Browser.MouseLeftByHtmlElement(" getElementsByTitle('超级店长')[0] ", webBrowser3);
            //Auto.Mouse_Left();
            //if (Browser.WaitWebPageLoad(webBrowser3))
            //{
            //webBrowser3.Load("http://f.superboss.cc/home.jsp?ftrace=0");
            //if (Browser.WaitWebPageLoad(webBrowser3))
            //{
            //if (Browser.JS_WebBrowser(" getClassName('btn-success')[0]!=null ", webBrowser3).ToLower() == "true")
            //{
            //    Browser.JS_WebBrowser_NoReturn(" getClassName('btn-success')[0].click(); ", webBrowser3);

            //}

            //}
            //}
            //}
        }
        #endregion

        #region btn_test_Click
        private void btn_test_Click(object sender, System.EventArgs e)
        {
            Browser.JS_WebBrowser_NoReturn("alert(navigator.appVersion .split(\"; \")[1].replace(/[ ]/g,\"\"))", webBrowser3);
            string js = txt_js.Text;
            Browser.JS_WebBrowser_NoReturn(js, webBrowser3);
        }
        #endregion

        #region btn_savehtml_Click
        private void btn_savehtml_Click(object sender, EventArgs e)
        {
            //string html = webBrowser3.RequestContext.ToString();
            string html = Browser.JS_WebBrowser("document.body.innerHTML", webBrowser3);
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

        #region 上传SKU图片
        private void btn_shangtu_Click(object sender, EventArgs e)
        {
            //SKU图片名称规范：SKU名称_网供名称_商品型号_价格_其他
            string skufilename = "test";
            if (string.IsNullOrEmpty(skufilename))
            {
                MessageBox.Show("请输入SKU文件目录");
                return;
            }

            //点击第一个SKU的上传图片
            Browser.JS_WebBrowser_NoReturn("document.getElementsByClassName('row')[0].getElementsByTagName('a')[0].click()", webBrowser3);
            //点击上传图片
            //Browser.JS_WebBrowser_NoReturn("document.getElementsByClassName('upload-tab-title')[0].click()", webBrowser1);
            //点击图片目录
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('search')[0]", webBrowser3);
            Auto.Clipboard_In(skufilename);
            Auto.Ctrl_V();
            //选择第一个目录
            Browser.JS_WebBrowser_NoReturn("document.getElementsByClassName('auto-complete-list')[0].getElementsByTagName('li')[0].click()", webBrowser3);
            //选择文件名升序排序
            Browser.MouseLeftByHtmlElement("document.getElementById('order')", webBrowser3);
            Browser.MouseLeftByHtmlElement("document.getElementById('order').getElementsByTagName('option')[4]", webBrowser3);
            //Browser.JS_WebBrowser_NoReturn("document.getElementById('order').getElementsByTagName('option')[4].click()", webBrowser1);


            //获取图片数量
            string skunum_temp = Browser.JS_WebBrowser("document.getElementsByClassName('mod-img').length", webBrowser3);
            int skunum = 0;
            if (int.TryParse(skunum_temp, out skunum))
            {
                //skunum = skunum - 1;
                for (int i = 1; i < skunum; i++)
                {
                    //获取图片名字
                    string skunum_name = Browser.JS_WebBrowser("document.getElementsByClassName('mod-img')[" + i + "].getElementsByTagName('a')[0].title", webBrowser3);
                    //点击选择图片
                    Browser.JS_WebBrowser_NoReturn("document.getElementsByClassName('mod-img')[" + i + "].getElementsByTagName('a')[0].click()", webBrowser3);

                }
            }

        }
        #endregion
    }





}

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
    public partial class TB_Often : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser2;
        /// <summary>
        /// 采集商品列表
        /// </summary>
        List<string> GoodsList = new List<string>();
        /// <summary>
        /// 要操作的商品列表
        /// </summary>
        //string[] GoodsList2;


        public TB_Often()
        {
            
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


                webBrowser2 = new ChromiumWebBrowser("http://www.taobao.com");
                webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
                webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
                webBrowser2.Size = new Size(990, 400);
                webBrowser2.Location = new Point(0, 325);
                webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                webBrowser2.RequestContext = webBrowser1.RequestContext;
                txt_url.Controls.Add(webBrowser2);


                txt_chengfa.Text = XMLHelper.GetValue("TaoBao_Copy_ChengFa");
                txt_jiafa.Text = XMLHelper.GetValue("TaoBao_Copy_JiaFa");
            }

            bind_sku();

        }

        #region bind

        void bind()
        {

        }


        void bind_sku()
        {
            //IList<opponent_dianpu> list = BLL2.opponent_dianpuManager.SearchAll();
            ////cb_dianpu.DataSource = list;
            //opponent_dianpu dp = new opponent_dianpu();
            //dp.odpname = "请选择";
            //dp.odTBID = "";
            //dp.oid = 0;
            //list.Insert(0, dp);
            //cb_sku_type.DataSource = list;

            string typesum = XMLHelper_SKU.GetValue("TypeSum");
            int tempsum_temp = 0;
            if (int.TryParse(typesum, out tempsum_temp))
            {
                //ComboBoxItem cbi1 = new ComboBoxItem();
                //ComboBox.ObjectCollection item = new ComboBox.ObjectCollection();
                //item. = "请选择";
                //item.Value = 0;
                cb_sku_type.Items.Add("请选择");

                for (int i = 0; i < tempsum_temp; i++)
                {
                    cb_sku_type.Items.Add("方案" + (i + 1).ToString());
                }
                cb_sku_type.SelectedIndex = 0;
            }
        }

        #endregion



        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {
            Manager.dianpu_huan(webBrowser1);
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
            webBrowser1.Load("https://siteadmin.taobao.com/category/index.htm");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                Browser.JS_CEFBrowser_NoReturn("getClassName('J_FoldTrigger')[1].click();  ", webBrowser1);
                Browser.Delay(300);
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('add-cat')[1].click();  ", webBrowser1);
                string name = DateTime.Today.ToString("MM-dd") + " NEWS";
                Browser.Delay(300);
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('look-me')[0].getElementsByTagName('input')[1].value='" + name + "'  ", webBrowser1);
                Browser.Delay(300);
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('release')[0].click();  ", webBrowser1);
                Browser.Delay(1500);
                Browser.JS_CEFBrowser_NoReturn("getClassName('J_FoldTrigger')[1].click();  ", webBrowser1);
            }
        }
        #endregion

        #region btn_tuihuo_Click
        private void btn_tuihuo_Click(object sender, System.EventArgs e)
        {
            webBrowser1.Load("https://myseller.taobao.com/seller_admin.htm");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d79')[0] ", webBrowser1);
            }
        }

        #endregion

        #region btn_shouhou_Click
        private void btn_shouhou_Click(object sender, System.EventArgs e)
        {
            webBrowser1.Load("https://myseller.taobao.com/seller_admin.htm");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d8')[0] ", webBrowser1);
            }
        }

        #endregion

        #region btn_img_Click
        private void btn_img_Click(object sender, System.EventArgs e)
        {
            webBrowser1.Load("https://tadget.taobao.com/redaction/manager.htm");
        }

        #endregion

        #region btn_dabiao_Click
        private void btn_dabiao_Click(object sender, System.EventArgs e)
        {
            //webBrowser1.Load("https://myseller.taobao.com/seller_admin.htm");
            //if (Browser.WaitWebPageLoad(webBrowser1))
            //{
            //    //点击出售中的商品
            //    Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d45')[0] ", webBrowser1);
            //    Auto.Mouse_Left();
            //    if (Browser.WaitWebPageLoad(webBrowser1))
            //    {
            //        //选择全选
            //        //Browser.MouseLeftByHtmlElement(" getClassName('all-selector')[0] ", webBrowser1);
            //        Browser.JS_CEFBrowser_NoReturn(" getClassName('all-selector')[0].click();  ", webBrowser1);
            //        //点击设置公益活动
            //        Browser.JS_CEFBrowser_NoReturn(" getClassName('operations')[1].getElementsByTagName('button')[5].click() ", webBrowser1);
            //        //if (Browser.WaitWebPageLoad(webBrowser1))
            //        //{
            //        //    //选择公益项目
            //        //    Browser.MouseLeftByHtmlElement(" getClassName('subTypeTabNav')[0].getElementsByTagName('li')[0]  ", webBrowser1);
            //        //    //设置捐赠百分比J_baiText
            //        //    Browser.JS_CEFBrowser_NoReturn(" getClassName('J_baiText')[0].value='0.1'  ", webBrowser1);
            //        //    //点击确定
            //        //    Browser.MouseLeftByHtmlElement(" getClassName('J_submit')[0] ", webBrowser1);

            //        //}
            //    }
            //}
            webBrowser1.Load("https://sell.taobao.com/auction/merchandise/auction_list.htm?spm=686.1000925.category.d45.2575a30aZVV6fr");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                string temp_count = Browser.JS_CEFBrowser("document.getElementsByClassName('photo').length", webBrowser1);
                int count = 0;
                if (int.TryParse(temp_count, out count))
                {
                    //获取本页面ID
                    List<string> idlist = new List<string>();
                    string ids = "";
                    for (int i = 0; i < count; i++)
                    {
                        //string tempid = Browser.JS_CEFBrowser("document.getElementsByClassName('photo')[" + i.ToString() + "].getElementsByTagName('a')[0].href", webBrowser1);
                        //ids = ids + Manager.GetValueByURL(tempid, "id") + ",";
                    }
                    //跳转设置公益宝贝
                    //https://gy.taobao.com/list_charity.htm?is_from_my=true&auctionids=599287967627,599288179294,599288211341,598680924205,598680900401,598680832317,598680496691,599104930031,599104954691,599105018167,598676852090,599105034099,599105070915,599105638335,599099870179,598676652253,598912141144,598912209188,598676556407,598676332252
                    webBrowser1.Load("https://gy.taobao.com/list_charity.htm?is_from_my=true&auctionids=" + ids);
                    if (Browser.WaitWebPageLoad(webBrowser1))
                    {
                        Browser.Delay(1000);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('subTypeTabNav')[0].getElementsByTagName('li')[0].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('donation')[1].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('text J_baiText')[0].value='0.1'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('J_submit submitBtn')[0].click()", webBrowser1);
                    }
                }
            }
        }
        #endregion


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


        #region btn_xiaobaoertong_Click
        /// <summary>
        /// 消费者保障-儿童
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_xiaobaoertong_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://xiaobao.taobao.com/contract/item_contract.htm?crtId=2");
            if (Browser.WaitWebPageLoad(" getClassName('J_CatSearch')[0] ", webBrowser1))
            {
                //打开类目下拉菜单
                Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('J_CatSearch')[0].click(); ", webBrowser1);
                //下拉列表容器class=bf-contentbox，选择玩具类目
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('bf-contentbox')[0].getElementsByTagName('div')[42].click(); ", webBrowser1);
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





        #region btn_upnew_Click
        private void btn_upnew_Click(object sender, System.EventArgs e)
        {



            if (CS.Taobao.GoToPublish(webBrowser1))
            {
                Taobao.ToDoPublish_Type(webBrowser1, "1");
                Taobao.SetShuangJian(webBrowser1);
                MessageBox.Show("可以开始上架新品了！");
            }


            return;



            //webBrowser1.Load("https://upload.taobao.com/auction/sell.jhtml?spm=a313o.201708ban.category.d48.10c322bTarY6y&mytmenu=wym");
            //webBrowser1.Focus();
            ////if (Browser.WaitWebPageLoad(" getElementsByDataSpm('d48')[0] ", webBrowser1))
            ////{
            ////    //点击发布新品
            ////    Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d48')[0] ", webBrowser1);
            //if (Browser.WaitWebPageLoad(" document.getElementsByClassName('cc-tree-item')[3] ", webBrowser1))
            //{
            //    //Browser.Delay(100);
            //    //点击“箱包皮具/热卖女包/男包”类目
            //    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('cc-tree-item')[3].click() ", webBrowser1);
            //    Browser.Delay(500);
            //    if (Browser.WaitWebPageLoad(" document.getElementsByClassName('cc-cbox-group')[4].getElementsByTagName('li')[1] ", webBrowser1))
            //    {
            //        //点击“双肩背包”类目
            //        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('cc-cbox-group')[4].getElementsByTagName('li')[1].click(); ", webBrowser1);


            //        //Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('cc-cbox-group')[4].getElementsByTagName('li')[1] ", webBrowser1);
            //        //等待刷新数据
            //        Browser.Delay(100);
            //        //点击发布
            //        if (Browser.WaitWebPageLoad(" document.getElementById('J_CatePubBtn') ", webBrowser1))
            //        {
            //            Browser.MouseLeftByHtmlElement(" document.getElementById('J_CatePubBtn') ", webBrowser1);

            //            //打开发布页面，设置默认选项
            //            if (Browser.WaitWebPageLoad(" document.getElementsByClassName('next-radio')[0] ", webBrowser1))
            //            {
            //                Browser.Delay(200);

            //                #region 备用2018-11-29



            //                ////点击宝贝类型为全新
            //                ////Browser.MouseLeftByHtmlElement_Wait(" document.getElementsByName('radio0')[0] ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByName('radio0')[0].click(); ", webBrowser1);



            //                ////宝贝卖点
            //                //string maidian = XMLHelper.GetValue("TaoBao_MaiDian");
            //                //Auto.Clipboard_In(maidian);
            //                //Browser.MouseLeftByHtmlElement(" document.getElementById('subTitle').getElementsByTagName('textarea')[0]", webBrowser1);
            //                //Auto.Ctrl_V();
            //                ////Browser.JS_CEFBrowser_NoReturn(" document.getElementById('subTitle').getElementsByTagName('textarea')[0].value='" + maidian + "' ", webBrowser1);


            //                ////货号
            //                //string huohao = "ZZD" + DateTime.Now.ToString("MMdd");//+ Manager.RandomNumber(1, 9).ToString();
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('inputbox')[2].getElementsByTagName('input')[0].value='" + huohao + "' ", webBrowser1);


            //                ////大小：小
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[1].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[1].getElementsByTagName('li')[3].click(); ", webBrowser1);

            //                ////容纳电脑尺寸：8寸
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[2].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[2].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////是否有背部缓冲棉：否
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[3].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[3].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////适用对象：青年
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[4].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[4].getElementsByTagName('li')[6].click(); ", webBrowser1);

            //                ////防水程度：防泼水
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[5].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[5].getElementsByTagName('li')[3].click(); ", webBrowser1);

            //                ////性别：女
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[6].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[6].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////质地：帆布
            //                ////Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[7].click(); ", webBrowser1);
            //                ////Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[7].getElementsByTagName('li')[11].click(); ", webBrowser1);

            //                ////质地：PU
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[7].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[7].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                //Browser.Delay(1500);

            //                ////材质工艺：软面
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[8].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[8].getElementsByTagName('li')[5].click(); ", webBrowser1);




            //                ////提拎部件类型：软把
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[9].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[9].getElementsByTagName('li')[3].click(); ", webBrowser1);

            //                ////闭合方式：拉链
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[10].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[10].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////箱包外袋种类：内贴袋
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[11].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[11].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////流行元素：绣花
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[12].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[12].getElementsByTagName('li')[13].click(); ", webBrowser1);

            //                ////图案：纯色
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[13].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[13].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////夹层：无
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[14].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[14].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////箱包软硬：软
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[15].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[15].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////是否可折叠：否
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[16].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[16].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////成色：全新
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[17].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[17].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////适用场景：校园
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[18].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[18].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////风格：日韩
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[19].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[19].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////形状：
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[20].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[20].getElementsByTagName('li')[14].click(); ", webBrowser1);

            //                ////肩带样式：双根
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[21].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[21].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////里料素材：软把
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[22].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[22].getElementsByTagName('li')[8].click(); ", webBrowser1);


            //                ////************************************************


            //                ////采购地：国内
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByName('radio3')[0].click(); ", webBrowser1);

            //                ////手机端描述：使用神笔模板编辑
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByName('radio11')[1].click(); ", webBrowser1);

            //                ////电脑端描述
            //                //string miaoshu = XMLHelper.GetValue("TaoBao_MiaoShu");
            //                //Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('ks-editor')[0].innerHTML=" + miaoshu, webBrowser1);


            //                ////********************************************
            //                ////品牌选择其他***
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[0].click(); ", webBrowser1);
            //                ////点选品牌查询框
            //                ////Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-search')[0].getElementsByTagName('input')[0].focus(); ", webBrowser1);
            //                //Browser.MouseLeftByHtmlElement_Wait(" document.getElementsByClassName('combobox-search')[0].getElementsByTagName('input')[0] ", webBrowser1);
            //                //Browser.Delay(500);
            //                ////系统粘贴
            //                //Auto.Clipboard_In("其他");
            //                //Auto.Clipboard_Out();
            //                //Browser.Delay(800);
            //                ////选择“other/其他”选项
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[0].getElementsByTagName('li')[0].click(); ", webBrowser1);
            //                ////********************************************

            //                #endregion

            //                Taobao.SetShuangJian(webBrowser1);

            //                MessageBox.Show("可以开始上架新品了！");


            //            }
            //        }
            //    }
            //}
            //}
        }
        #endregion


        #region btn_upnew_danjian_Click


        private void btn_upnew_danjian_Click(object sender, System.EventArgs e)
        {



            if (CS.Taobao.GoToPublish(webBrowser1))
            {
                Taobao.ToDoPublish_Type(webBrowser1, "2");
                Taobao.SetNvBao(webBrowser1);
                MessageBox.Show("可以开始上架新品了！");
            }


            return;

            //webBrowser1.Load("https://upload.taobao.com/auction/sell.jhtml?spm=a313o.201708ban.category.d48.10c322bTarY6y&mytmenu=wym");
            //webBrowser1.Focus();
            ////if (Browser.WaitWebPageLoad(" getElementsByDataSpm('d48')[0] ", webBrowser1))
            ////{
            ////    //点击发布新品
            ////    Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d48')[0] ", webBrowser1);
            //if (Browser.WaitWebPageLoad(" document.getElementsByClassName('cc-tree-item')[3] ", webBrowser1))
            //{
            //    //Browser.Delay(100);
            //    //点击“箱包皮具/热卖女包/男包”类目
            //    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('cc-tree-item')[3].click() ", webBrowser1);
            //    Browser.Delay(500);
            //    if (Browser.WaitWebPageLoad(" document.getElementsByClassName('cc-cbox-group')[4].getElementsByTagName('li')[1] ", webBrowser1))
            //    {
            //        //点击“女式包袋”类目
            //        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('cc-cbox-group')[2].getElementsByTagName('li')[0].click(); ", webBrowser1);
            //        //等待刷新数据
            //        Browser.Delay(100);
            //        //点击发布
            //        if (Browser.WaitWebPageLoad(" document.getElementById('J_CatePubBtn') ", webBrowser1))
            //        {
            //            Browser.MouseLeftByHtmlElement(" document.getElementById('J_CatePubBtn') ", webBrowser1);

            //            //打开发布页面，设置默认选项
            //            if (Browser.WaitWebPageLoad("document.getElementsByClassName('next-radio')[0] ", webBrowser1))
            //            {
            //                Taobao.SetNvBao(webBrowser1);

            //                #region 备份2018-11-29



            //                //Browser.Delay(200);
            //                ////点击宝贝类型为全新
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByName('radio0')[0].click(); ", webBrowser1);


            //                ////货号
            //                //string huohao = DateTime.Now.ToString("yyMMdd") + Manager.RandomNumber(1000, 9999).ToString();
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('inputbox')[2].getElementsByTagName('input')[0].value='" + huohao + "' ", webBrowser1);


            //                ////大小：小
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[1].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[1].getElementsByTagName('li')[3].click(); ", webBrowser1);

            //                ////流行款式：小方包
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[2].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[2].getElementsByTagName('li')[7].click(); ", webBrowser1);

            //                ////适用对象：青年
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[3].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[3].getElementsByTagName('li')[6].click(); ", webBrowser1);

            //                ////款式：单肩包
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[4].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[4].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                //Browser.Delay(1200);

            //                ////背包方式：单肩斜跨
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[5].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[5].getElementsByTagName('li')[5].click(); ", webBrowser1);

            //                ////质地：PU
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[6].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[6].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                //Browser.Delay(1200);

            //                ////材质工艺：软面
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[7].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[7].getElementsByTagName('li')[4].click(); ", webBrowser1);

            //                ////提拎部件类型：装卸式提把
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[8].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[8].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////闭合方式：拉链
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[9].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[9].getElementsByTagName('li')[3].click(); ", webBrowser1);

            //                ////箱包外袋种类：内贴袋
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[10].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[10].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////流行元素：字母
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[11].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[11].getElementsByTagName('li')[19].click(); ", webBrowser1);

            //                ////图案：纯色
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[12].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[12].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////夹层：无
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[13].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[13].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////箱包软硬：软
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[14].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[14].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////是否可折叠：否
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[15].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[15].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////成色：全新
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[16].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[16].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////适用场景：休闲
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[17].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[17].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////风格：日韩
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[18].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[18].getElementsByTagName('li')[2].click(); ", webBrowser1);

            //                ////形状：横款方形
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[19].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[19].getElementsByTagName('li')[13].click(); ", webBrowser1);

            //                ////肩带样式：双根
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[20].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[20].getElementsByTagName('li')[1].click(); ", webBrowser1);

            //                ////里料素材：涤棉
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[21].click(); ", webBrowser1);
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[21].getElementsByTagName('li')[11].click(); ", webBrowser1);


            //                ////************************************************


            //                ////采购地：国内
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByName('radio3')[0].click(); ", webBrowser1);

            //                ////手机端描述：使用神笔模板编辑
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByName('radio11')[1].click(); ", webBrowser1);

            //                ////********************************************
            //                ////品牌选择其他***
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[0].click(); ", webBrowser1);
            //                ////点选品牌查询框
            //                ////Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-search')[0].getElementsByTagName('input')[0].focus(); ", webBrowser1);
            //                //Browser.MouseLeftByHtmlElement_Wait(" document.getElementsByClassName('combobox-search')[0].getElementsByTagName('input')[0] ", webBrowser1);
            //                //Browser.Delay(200);
            //                ////系统粘贴
            //                //Auto.Clipboard_In("其他");
            //                //Auto.Clipboard_Out();
            //                //Browser.Delay(200);
            //                ////选择“other/其他”选项
            //                //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[0].getElementsByTagName('li')[0].click(); ", webBrowser1);
            //                ////********************************************

            //                #endregion

            //                MessageBox.Show("可以开始上架新品了！");


            //            }
            //        }
            //    }
            //}
            //}
        }

        #endregion



        #region btn_test_Click
        private void btn_test_Click(object sender, System.EventArgs e)
        {
            string js = txt_js.Text;
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion

        #region btn_dazhe_Click
        private void btn_dazhe_Click(object sender, EventArgs e)
        {

            if (CS.Taobao.GoChaoJiDianZhang(webBrowser1))
            {
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    webBrowser1.Load("http://f.superboss.cc/ProductUsingServlet?kind=105&ftrace=0");

                }
            }
            //app - ordered
            //卖家中心
            //webBrowser1.Load("https://myseller.taobao.com/seller_admin.htm");
            //if (Browser.WaitWebPageLoad(webBrowser1))
            //{
            //点击我订购的应用
            //Browser.MouseLeftByHtmlElement(" getClassName('app-ordered')[0] ", webBrowser1);
            //Auto.Mouse_Left();
            ////等待刷新数据
            //Browser.Delay(100);
            ////点击超级店长
            //Browser.MouseLeftByHtmlElement(" getElementsByTitle('超级店长')[0] ", webBrowser1);
            //Auto.Mouse_Left();
            //if (Browser.WaitWebPageLoad(webBrowser1))
            //{
            //webBrowser1.Load("http://f.superboss.cc/home.jsp?ftrace=0");
            //if (Browser.WaitWebPageLoad(webBrowser1))
            //{
            //if (Browser.JS_CEFBrowser(" getClassName('btn-success')[0]!=null ", webBrowser1).ToLower() == "true")
            //{
            //    Browser.JS_CEFBrowser_NoReturn(" getClassName('btn-success')[0].click(); ", webBrowser1);

            //}

            //}
            //}
            //}
        }
        #endregion


        #region btn_chushouzhong_Click
        private void btn_chushouzhong_Click(object sender, EventArgs e)
        {
            //webBrowser1.Load("https://sell.taobao.com/auction/merchandise/auction_list.htm");
            webBrowser1.Load("https://item.publish.taobao.com/taobao/manager/render.htm?tab=on_sale");
        }
        #endregion

        #region btn_dingdan_Click
        private void btn_dingdan_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://trade.taobao.com/trade/itemlist/list_sold_items.htm");
            if (Browser.WaitWebPageLoad(" document.getElementsByClassName('rc-select-selection__rendered')[0]", webBrowser1))
            {
                Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('rc-select-selection__rendered')[0].click(); ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('rc-select-dropdown-menu-item')[2].click(); ", webBrowser1);
                Browser.MouseLeftByHtmlElement(" getElementsByDataReactid('.0.0.0.0.a.0.1.0')[0] ", webBrowser1);
            }
        }
        #endregion


        #region btn_canmou_Click
        private void btn_cangku_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://sell.taobao.com/auction/merchandise/auction_list.htm?type=1");
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

        #region btn_tijian_Click
        private void btn_tijian_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://healthcenter.taobao.com/home/health_home.htm");
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


        #region
        private void btn_searchgoods_Click(object sender, EventArgs e)
        {
            GoodsList.Clear();


            string url = txt_goodsurl.Text.Trim();
            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("请输入网址");
                txt_goodsurl.Focus();
                return;
            }

            webBrowser2.Load(url);
            if (Browser.WaitWebPageLoad(webBrowser2))
            {
                string shopid = CaiJi.GetShopIDByMate(webBrowser2);
                //string shopid = "";
                //string shopid_data = Browser.JS_CEFBrowser("document.getElementsByName('microscope-data')[0].content", webBrowser2);



                //string url_shop = CaiJi.GetShopUrlByWangWang(str, webBrowser1);

                //默认查询20页
                for (int i = 0; i < 20; i++)
                {


                    string url_goodslist = CaiJi.GetShopGoodsListURL_NewOn(shopid, i + 1);
                    webBrowser2.Load(url_goodslist);
                    //判断所有宝贝链接是否存在
                    if (Browser.WaitWebPageLoad2("document.getElementById('J_HesperCats')", webBrowser2))
                    {
                        Browser.urlstr = url_goodslist;

                        //判断是否还有商品
                        Browser.jsstr = "  getClassName('no-result-new').length;  ";
                        if (Browser.JS_CEFBrowser(Browser.jsstr, webBrowser2) == "1")
                        {
                            break;
                        }
                        else
                        {
                            //开始采集商品

                            string res = Browser.JS_CEFBrowser(" getClassName('photo').length; ", webBrowser2);
                            Debug.WriteLine("本页面商品数量为：" + res);//输出
                            int list_count1 = 0;
                            //如果没有商品，则返回空
                            if (!int.TryParse(res, out list_count1))
                            {
                                Debug.WriteLine("没有获取到商品");//输出
                                break;
                            }
                            else
                            {
                                //开始采集商品
                                //遍历每个商品
                                for (int j = 0; j < list_count1; j++)
                                {
                                    string temp = CaiJi.SearchPage_GetGoodsUrl(j, webBrowser2);
                                    GoodsList.Add(temp);
                                }
                            }
                            if (list_count1 < 24)
                            {
                                //采集完成跳出
                                break;
                            }
                        }
                    }
                    //模拟真实翻页
                    Browser.Delay(1500);
                    //string page1 = Browser.JS_CEFBrowser("document.getElementsByClassName('page-cur')[0].innerText", webBrowser2);
                    //string page2 = Browser.JS_CEFBrowser("document.getElementsByName('pageNo')[0].value", webBrowser2);

                    //if (page1 == page2)
                    //{
                    //    break;
                    //}

                }

                if (GoodsList.Count > 0)
                {
                    string res = "";
                    foreach (string s in GoodsList)
                    {
                        res = res + s + "\r\n";
                    }
                    txt_goodslist.Text = res;
                }

            }


        }
        #endregion


        #region btn_fuzhi_Click

        private void btn_fuzhi_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清理本店铺的滞销商品吗?", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //开始清理滞销商品
                //进入出售中的商品
                webBrowser1.Load("https://item.publish.taobao.com/taobao/manager/render.htm?tab=on_sale");
                //等待加载完成
                if (webBrowser1.ToWait("getElementsByClassName_Vague('indexseller-info-wrapper')[0]"))
                {
                    Common.Manager.Delay(2000);
                    Browser.MouseMoveByHtmlElement("getElementsByClassName_Vague('indexseller-info-wrapper')[0]", webBrowser1);
                    Browser.Delay(500);
                    //获取店铺链接
                    string myshop_url = webBrowser1.ToJs("getElementsByClassName_Vague('indexbtn')[1].origin");
                    if (string.IsNullOrEmpty(myshop_url))
                    {
                        "没有找到店铺链接".ToShow();
                        return;
                    }

                    //获取店铺所有商品页面
                    myshop_url = myshop_url + "//search.htm?search=y&orderType=hotsell_desc";
                    //进入店铺页面
                    webBrowser1.Load(myshop_url);
                    webBrowser1.ToWait("document.getElementsByClassName('sale-num')");
                    Common.Manager.Delay(3000);
                    List<string> idlist = new List<string>();//用于存放所有销量为0的商品id

                    int temp_count = 0;
                    do
                    {
                        //是否需要翻页
                        if (temp_count != 0)
                        {
                            //webBrowser1.Load(myshop_url + "&pageNo=" + (temp_count + 2));
                            webBrowser1.ToJs("getElementsByInnerText_Vague_NoChildren('下一页')[1].click()");
                            webBrowser1.ToWait("document.getElementsByClassName('sale-num')");
                            Common.Manager.Delay(5000);
                        }
                        temp_count++;
                        //采集所有销量为0的商品
                        //获取商品数量
                        int goods_count = webBrowser1.ToJsInt("document.getElementsByClassName('sale-num').length");
                        for (int i = 0; i < goods_count; i++)
                        {
                            //如果销量为0
                            if (webBrowser1.ToJs("document.getElementsByClassName('sale-num')[" + i + "].innerText") == "0")
                            {
                                //获取id
                                string temp_url = webBrowser1.ToJs("document.getElementsByClassName('item-name')[" + i + "].href");
                                idlist.Add(Manager.GetURLParam(temp_url, "id"));
                            }
                        }
                    } while (webBrowser1.ToJs("getElementsByInnerText_Vague_NoChildren('下一页')[1].getAttribute('class')").IndexOf("next")!=-1);


                    //进入出售中的商品
                    webBrowser1.Load("https://item.publish.taobao.com/taobao/manager/render.htm?tab=on_sale");
                    //等待加载完称
                    webBrowser1.ToWait("document.getElementsByName('queryItemId')[0]");
                    Common.Manager.Delay(2000);
                    //根据id查询每个商品
                    foreach (string strid in idlist)
                    {
                        //下架滞销商品
                        webBrowser1.ToMouseClick("document.getElementsByName('queryItemId')[0]");
                        //找到商品
                        Auto.Ctrl_A();
                        Auto.Ctrl_V(strid);
                        webBrowser1.ToMouseClick("getElementsByInnerText_Vague_NoChildren('查询')[1]");
                        //webBrowser1.ToJs("getElementsByInnerText_Vague_NoChildren('查询')[1].click()");
                        Common.Manager.Delay(3000);
                        string getid = webBrowser1.ToJs("document.getElementsByClassName('product-desc-span')[1].innerText");
                        if (getid.IndexOf(strid) != -1)
                        {
                            Debug.WriteLine(strid+"商品已经找到");
                            //获取创建时间
                            DateTime temp_dt = webBrowser1.ToJsDate("document.getElementsByClassName('list-table-cell-status')[0].getElementsByTagName('span')[0].innerText");
                            if (temp_dt == null || temp_dt == new DateTime())
                            {
                                "获取商品创建时间失败".ToShow();
                                return;
                            }
                            Debug.WriteLine("商品为滞销品");
                            //如果创建时间超过了25天则下架商品
                            if (temp_dt.AddDays(25) < DateTime.Now)
                            {
                                //下架
                                webBrowser1.ToJs("document.getElementsByClassName('next-table-row')[0].getElementsByTagName('input')[0].click()");
                                Common.Manager.Delay(2000);
                                webBrowser1.ToJs("getElementsByInnerText_Vague_NoChildren('批量下架')[0].click();");
                                Common.Manager.Delay(2000);
                                webBrowser1.ToJs("document.getElementsByClassName('next-btn next-btn-primary next-btn-medium')[4].click()");
                                Debug.WriteLine(strid + "已经下架到仓库");
                                Common.Manager.Delay(3000);
                            }
                        }
                    }
                    //提示完成
                }


            }
        }
        #endregion


        #region btn_caijigoodsreset_Click
        private void btn_caijigoodsreset_Click(object sender, EventArgs e)
        {
            if (GoodsList.Count > 0)
            {
                string res = "";
                foreach (string s in GoodsList)
                {
                    res = res + s + "\r\n";
                }
                txt_goodslist.Text = res;
            }
        }
        #endregion

        #region btn_fuzhi2_Click
        private void btn_fuzhi2_Click(object sender, EventArgs e)
        {

            XMLHelper.SetValue("TaoBao_Copy_ChengFa", txt_chengfa.Text);
            XMLHelper.SetValue("TaoBao_Copy_JiaFa", txt_jiafa.Text);

            tabControl1.SelectedTab = tabPage1;

            //获取数据框内的商品链接
            string goods_str = txt_goodslist.Text.Trim();

            string[] goods_zu = Manager.Str_Split(goods_str, "\r\n");
            //foreach (string s in goods_zu)
            //{
            //    GoodsList2.Add(s);
            //}
            if (goods_zu.Length == 0)
            {
                MessageBox.Show("没有商品链接");
                return;
            }




            //进入复制宝贝
            if (GoBaoBeiFuZhi())
            {



                //操作数据每次10个
                //List<string> list_res = new List<string>();
                //string temp_i = "";
                //int j = 0;

                //for (int i = 0; i < goods_zu.Length; i++)
                //{
                //    j++;
                //    temp_i = temp_i + goods_zu[i];
                //    if (j < 10)
                //    {
                //        temp_i = temp_i + "\r\n";
                //    }
                //    else
                //    {
                //        list_res.Add(temp_i);
                //        j = 0;
                //        temp_i = "";
                //    }
                //    if ((i + 1) == goods_zu.Length)
                //    {
                //        list_res.Add(temp_i);
                //    }
                //}




                //设置价格
                //string chengfa = txt_chengfa.Text.Trim();
                //string jiafa = txt_jiafa.Text.Trim();
                //Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('priceMultiply')[0].value='" + chengfa + "'", webBrowser1);
                //Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('pricePlus')[0].value='" + jiafa + "'", webBrowser1);
                ////其他设置
                ////点击过滤已复制宝贝
                //Browser.JS_CEFBrowser("document.getElementsByClassName('iCheck-helper')[9].click()", webBrowser1);
                ////设置邮费模板
                //Browser.JS_CEFBrowser("document.getElementsByClassName('ui-select-group')[1].getElementsByTagName('dd')[1].click()", webBrowser1);
                //Browser.Delay(1000);

                foreach (string str in goods_zu)
                {
                    if (Browser.WaitWebPageLoad(webBrowser1))
                    {

                        //设置宝贝链接
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('keywords')[0].value ='" + str + "'", webBrowser1);
                        Browser.Delay(1000);
                        //点击直接复制宝贝
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('J-copyItem')[0].click() ", webBrowser1);
                        Browser.Delay(2000);

                    }
                }

                MessageBox.Show("复制全部完成");

            }
        }
        #endregion







        #region 进入宝贝复制
        /// <summary>
        /// 进入超级店长
        /// </summary>
        /// <returns></returns>
        bool GoBaoBeiFuZhi()
        {
            bool res = false;
            tabControl1.SelectedTab = tabPage1;
            if (Browser.JS_CEFBrowser("document.getElementsByClassName('iCheck-helper')[9]!=null", webBrowser1) == "True")
            {
                return true;
            }
            //进入超级店长
            if (Taobao.GoChaoJiDianZhang(webBrowser1))
            {

                if (Browser.WaitWebPageLoad2(" document.getElementsByClassName('site-nav-item')[0] ", webBrowser1))
                {
                    //Browser.Delay(2000);
                    //直接链接不行
                    //document.getElementsByClassName("site-nav-item")[3]
                    //document.getElementsByClassName("site-nav-item")[3].getElementsByTagName('a')[10]
                    //Browser.MouseMoveByHtmlElement("document.getElementsByClassName('site-nav-item')[3]", webBrowser1);
                    //Browser.Delay(2000);
                    //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('site-nav-item')[3].getElementsByTagName('a')[10]", webBrowser1);
                    webBrowser1.Load("http://jump.superboss.cc/jump.jsp?gotourl=http%3A%2F%2Ff.superboss.cc%2FProductUsingServlet%3Fkind%3D1001%26ftrace%3D3&amp;tj_cookie=1&amp;trace_tag=dz_iner_gg&amp;app_type=dianzhang&amp;ad_id=341&amp;ad_slot=66");
                    Browser.Delay(2000);
                    if (Browser.WaitWebPageLoad2(" document.getElementsByName('priceMultiply')[0] ", webBrowser1))
                    {
                        string chengfa = txt_chengfa.Text.Trim();
                        string jiafa = txt_jiafa.Text.Trim();
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('priceMultiply')[0].value='" + chengfa + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByName('pricePlus')[0].value='" + jiafa + "'", webBrowser1);
                        //点击过滤已复制宝贝
                        Browser.JS_CEFBrowser("document.getElementsByClassName('iCheck-helper')[9].click()", webBrowser1);

                        //设置邮费模板
                        Browser.JS_CEFBrowser("document.getElementsByClassName('ui-select-group')[1].getElementsByTagName('dd')[1].click()", webBrowser1);
                        res = true;

                    }
                }
            }

            return res;
        }

        #endregion


        #region 上传SKU图片
        private void btn_shangtu_Click(object sender, EventArgs e)
        {
            ////SKU图片名称规范：SKU名称_网供名称_商品型号_价格_其他
            //string skufilename = "test";
            //if (string.IsNullOrEmpty(skufilename))
            //{
            //    MessageBox.Show("请输入SKU文件目录");
            //    return;
            //}

            ////点击第一个SKU的上传图片
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('row')[0].getElementsByTagName('a')[0].click()", webBrowser1);
            ////点击上传图片
            ////Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('upload-tab-title')[0].click()", webBrowser1);
            ////点击图片目录
            //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('search')[0]", webBrowser1);
            //Auto.Clipboard_In(skufilename);
            //Auto.Ctrl_V();
            ////选择第一个目录
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('auto-complete-list')[0].getElementsByTagName('li')[0].click()", webBrowser1);
            ////选择文件名升序排序
            //Browser.MouseLeftByHtmlElement("document.getElementById('order')", webBrowser1);
            //Browser.MouseLeftByHtmlElement("document.getElementById('order').getElementsByTagName('option')[4]", webBrowser1);
            ////Browser.JS_CEFBrowser_NoReturn("document.getElementById('order').getElementsByTagName('option')[4].click()", webBrowser1);


            ////获取图片数量
            //string skunum_temp = Browser.JS_CEFBrowser("document.getElementsByClassName('mod-img').length", webBrowser1);
            //int skunum = 0;
            //if (int.TryParse(skunum_temp, out skunum))
            //{
            //    //skunum = skunum - 1;
            //    for (int i = 1; i < skunum; i++)
            //    {
            //        //获取图片名字
            //        string skunum_name = Browser.JS_CEFBrowser("document.getElementsByClassName('mod-img')[" + i + "].getElementsByTagName('a')[0].title", webBrowser1);
            //        //点击选择图片
            //        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('mod-img')[" + i + "].getElementsByTagName('a')[0].click()", webBrowser1);

            //    }
            //}

            //直通车
            webBrowser1.Load("https://subway.simba.taobao.com/#!/home");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {

            }



        }
        #endregion

        #region 上传主图

        void img_zhutu()
        {
            //SKU图片名称规范：SKU名称_网供名称_商品型号_价格_其他
            string skufilename = "test";
            if (string.IsNullOrEmpty(skufilename))
            {
                MessageBox.Show("请输入SKU文件目录");
                return;
            }

            //首图上新
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('image-list')[0].getElementsByTagName('li')[0].click()", webBrowser1);
            //点击上传图片
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('upload-tab-title')[0].click()", webBrowser1);
            //点击图片目录
            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('search')[0]", webBrowser1);
            Auto.Clipboard_In(skufilename);
            Auto.Ctrl_V();
            //选择第一个目录
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('auto-complete-list')[0].getElementsByTagName('li')[0].click()", webBrowser1);
            //选择文件名升序排序
            Browser.MouseLeftByHtmlElement("document.getElementById('order')", webBrowser1);
            Browser.MouseLeftByHtmlElement("document.getElementById('order').getElementsByTagName('option')[4]", webBrowser1);
            //Browser.JS_CEFBrowser_NoReturn("document.getElementById('order').getElementsByTagName('option')[4].click()", webBrowser1);


            //获取图片数量
            string skunum_temp = Browser.JS_CEFBrowser("document.getElementsByClassName('mod-img').length", webBrowser1);
            int skunum = 0;
            if (int.TryParse(skunum_temp, out skunum))
            {
                //skunum = skunum - 1;
                for (int i = 1; i < skunum; i++)
                {
                    //获取图片名字
                    string skunum_name = Browser.JS_CEFBrowser("document.getElementsByClassName('mod-img')[" + i + "].getElementsByTagName('a')[0].title", webBrowser1);
                    //点击选择图片
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('mod-img')[" + i + "].getElementsByTagName('a')[0].click()", webBrowser1);

                }
            }

        }

        #endregion


        #region btn_addjs_Click
        private void btn_addjs_Click(object sender, EventArgs e)
        {
            //Browser.SetJSFile(webBrowser1);
            CS.Taobao.SetShuangJian(webBrowser1);
        }
        #endregion


        #region btn_fayouhuiquan_Click
        private void btn_fayouhuiquan_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://ecrm.taobao.com/p/market/initiative/directMarketing.htm?spm=a1za3.8455275.0.0.308bc03b0vqfZL");
            if (Browser.WaitWebPageLoad2("document.getElementsByClassName('next-table-row')[0]", webBrowser1))
            {
                Browser.Delay(3000);
                string count_temp = Browser.JS_CEFBrowser("document.getElementsByClassName('next-table-body')[0].getElementsByClassName('next-table-row').length", webBrowser1);
                int count = 0;
                if (int.TryParse(count_temp, out count))
                {
                    for (int i = 0; i < count; i++)
                    {
                        //点击人群
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('next-table-body')[0].getElementsByClassName('next-table-row')[" + i.ToString() + "].getElementsByTagName('input')[0].click()", webBrowser1);
                        //点击优惠券
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('next-radio')[document.getElementsByClassName('next-radio').length-1].getElementsByTagName('input')[0].click()", webBrowser1);
                        //点击创建计划
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('submit-btn')[0].getElementsByClassName('next-btn')[0].click()", webBrowser1);
                        //创建后跳转回页面
                        if (Browser.WaitWebPageLoad(webBrowser1))
                        {
                            webBrowser1.Load("https://ecrm.taobao.com/p/market/initiative/directMarketing.htm?spm=a1za3.8455275.0.0.308bc03b0vqfZL");
                            if (Browser.WaitWebPageLoad2("document.getElementsByClassName('next-table-row')[0]", webBrowser1))
                            {
                                Browser.Delay(3000);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region btn_maijiaxiu_Click
        private void btn_maijiaxiu_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://xiangqing.taobao.com/my/item_list.html?spm=a2o1b.8197351.0.0.10c98ff0k74Quz");
        }


        #endregion

        #region btn_shenbi_Click
        private void btn_shenbi_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://xiangqing.taobao.com/my/operation.html?spm=a2o1b.8098953.0.0.5e01316bWX3Zmb");
        }


        #endregion



        #region SKU

        #region cb_sku_type_SelectedIndexChanged
        private void cb_sku_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_cb_sku(sku_selectindex());
        }
        #endregion





        #region bind_cb_sku
        /// <summary>
        /// 绑定SKU信息
        /// </summary>
        /// <param name="typeindex">方案编号</param>
        void bind_cb_sku(string typeindex)
        {
            try
            {
                if (!string.IsNullOrEmpty(typeindex))
                {

                    for (int i = 0; i < 24; i++)
                    {
                        //获取xml文件中的数据
                        string values = XMLHelper_SKU.GetValue("SKU" + typeindex + "_" + (i + 1).ToString());

                        //设置sku中name属性
                        string control_name = "txt_skuname" + (i + 1).ToString();
                        TextBox TB = (TextBox)tabPage2.Controls.Find(control_name, false)[0];
                        TB.Text = values.Split(new char[] { '|' })[0];

                        //设置sku中price属性
                        control_name = "txt_skuprice" + (i + 1).ToString();
                        TextBox TB2 = (TextBox)tabPage2.Controls.Find(control_name, false)[0];
                        TB2.Text = values.Split(new char[] { '|' })[1];
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("绑定sku信息失败，" + e.ToString());
            }
        }
        #endregion

        #region sku_selectindex
        /// <summary>
        /// 获取SKU的选项编号
        /// </summary>
        string sku_selectindex()
        {
            string res = "";
            string select_text = cb_sku_type.Text;
            if (select_text.IndexOf("方案") != -1)
            {
                res = select_text.Replace("方案", "");
            }
            return res;
        }
        #endregion


        #region btn_sku_reset_Click
        private void btn_sku_reset_Click(object sender, EventArgs e)
        {
            bind_cb_sku(sku_selectindex());
            MessageBox.Show("重置成功!");
        }
        #endregion

        #region btn_sku_save_Click
        private void btn_sku_save_Click(object sender, EventArgs e)
        {
            try
            {
                string typeindex = sku_selectindex();

                if (!string.IsNullOrEmpty(typeindex))
                {
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_1", txt_skuname1.Text + "|" + txt_skuprice1.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_2", txt_skuname2.Text + "|" + txt_skuprice2.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_3", txt_skuname3.Text + "|" + txt_skuprice3.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_4", txt_skuname4.Text + "|" + txt_skuprice4.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_5", txt_skuname5.Text + "|" + txt_skuprice5.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_6", txt_skuname6.Text + "|" + txt_skuprice6.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_7", txt_skuname7.Text + "|" + txt_skuprice7.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_8", txt_skuname8.Text + "|" + txt_skuprice8.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_9", txt_skuname9.Text + "|" + txt_skuprice9.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_10", txt_skuname10.Text + "|" + txt_skuprice10.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_11", txt_skuname11.Text + "|" + txt_skuprice11.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_12", txt_skuname12.Text + "|" + txt_skuprice12.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_13", txt_skuname13.Text + "|" + txt_skuprice13.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_14", txt_skuname14.Text + "|" + txt_skuprice14.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_15", txt_skuname15.Text + "|" + txt_skuprice15.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_16", txt_skuname16.Text + "|" + txt_skuprice16.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_17", txt_skuname17.Text + "|" + txt_skuprice17.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_18", txt_skuname18.Text + "|" + txt_skuprice18.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_19", txt_skuname19.Text + "|" + txt_skuprice19.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_20", txt_skuname20.Text + "|" + txt_skuprice20.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_21", txt_skuname21.Text + "|" + txt_skuprice21.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_22", txt_skuname22.Text + "|" + txt_skuprice22.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_23", txt_skuname23.Text + "|" + txt_skuprice23.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_24", txt_skuname24.Text + "|" + txt_skuprice24.Text);

                    MessageBox.Show("保存成功!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存sku信息失败，" + ex.ToString());
            }
        }





        #endregion

        #region btn_sku_doset_Click
        private void btn_sku_doset_Click(object sender, EventArgs e)
        {

            try
            {

                //如果SKU编号不为空
                if (!string.IsNullOrEmpty(sku_selectindex()))
                {
                    tabControl1.SelectedTab = tabPage1;
                    //是否有SKU输入框
                    if (!Browser.ElementIsNull("document.getElementsByClassName('input-with-warning')[0].getElementsByTagName('input')[0]", webBrowser1))
                    {

                        for (int i = 0; i < 24; i++)
                        {
                            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('input-with-warning')['" + i.ToString() + "'].getElementsByTagName('input')[0]", webBrowser1);
                            string control_name = "txt_skuname" + (i + 1).ToString();
                            TextBox TB = (TextBox)tabPage2.Controls.Find(control_name, false)[0];
                            string values = TB.Text;
                            Auto.Ctrl_V(values);
                            Browser.Delay(200);
                        }
                        #region 2019年3月7日10:07:36备注


                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('input-with-warning')[0].getElementsByTagName('input')[0].value='" + txt_skuname1.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[0].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[1].value='" + txt_skuname2.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[1].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[2].value='" + txt_skuname3.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[2].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[3].value='" + txt_skuname4.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[3].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[4].value='" + txt_skuname5.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[4].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[5].value='" + txt_skuname6.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[5].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[6].value='" + txt_skuname7.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[6].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[7].value='" + txt_skuname8.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[7].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[8].value='" + txt_skuname9.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[8].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[9].value='" + txt_skuname10.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[9].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[10].value='" + txt_skuname11.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[10].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[11].value='" + txt_skuname12.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[11].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[12].value='" + txt_skuname13.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[12].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[13].value='" + txt_skuname14.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[13].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[14].value='" + txt_skuname15.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[14].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[15].value='" + txt_skuname16.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[15].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[16].value='" + txt_skuname17.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[16].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[17].value='" + txt_skuname18.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[17].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[18].value='" + txt_skuname19.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[18].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[19].value='" + txt_skuname20.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[19].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[20].value='" + txt_skuname21.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[20].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[21].value='" + txt_skuname22.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[21].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[22].value='" + txt_skuname23.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[22].click()", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[23].value='" + txt_skuname24.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[23].click()", webBrowser1);
                        #endregion


                        //激活SKUJS
                        //for (int i = 23; i >= 0; i--)
                        //{
                        //    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('picker-text')[" + i.ToString() + "]", webBrowser1);
                        //}
                        //激活SKU价格JS
                        //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[1].getElementsByTagName('input')[0]", webBrowser1);
                        //Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[1].getElementsByTagName('input')[0]", webBrowser1);


                        //设置SKU价格和数量设置的表格隐藏的部分显示出来
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ver-scroll-wrap')[0].style = '' ", webBrowser1);



                        //等待1s
                        Browser.Delay(1000);

                        //设置第一个SKU价格和数量

                        string skunum = "100";

                        //设置sku价格和属性
                        for (int i = 1; i <= 24; i++)
                        {
                            //设置价格
                            Browser.MouseLeftByHtmlElement("document.getElementsByName('skuPrice')['" + i.ToString() + "']", webBrowser1);
                            string control_name = "txt_skuprice" + i.ToString();
                            TextBox TB = (TextBox)tabPage2.Controls.Find(control_name, false)[0];
                            string values = TB.Text;
                            Auto.Ctrl_V(values);
                            Browser.Delay(100);

                            //设置数量
                            Browser.MouseLeftByHtmlElement("document.getElementsByName('skuStock')['" + i.ToString() + "']", webBrowser1);
                            Auto.Ctrl_V(skunum);
                            Browser.Delay(100);

                        }




                        #region 备份
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[1].getElementsByTagName('input')[0].value='" + txt_skuprice1.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[1].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[2].getElementsByTagName('input')[0].value='" + txt_skuprice2.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[2].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[3].getElementsByTagName('input')[0].value='" + txt_skuprice3.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[3].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[4].getElementsByTagName('input')[0].value='" + txt_skuprice4.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[4].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[5].getElementsByTagName('input')[0].value='" + txt_skuprice5.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[5].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[6].getElementsByTagName('input')[0].value='" + txt_skuprice6.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[6].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[7].getElementsByTagName('input')[0].value='" + txt_skuprice7.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[7].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[8].getElementsByTagName('input')[0].value='" + txt_skuprice8.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[8].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[9].getElementsByTagName('input')[0].value='" + txt_skuprice9.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[9].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[10].getElementsByTagName('input')[0].value='" + txt_skuprice10.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[10].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[11].getElementsByTagName('input')[0].value='" + txt_skuprice11.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[11].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[12].getElementsByTagName('input')[0].value='" + txt_skuprice12.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[12].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[13].getElementsByTagName('input')[0].value='" + txt_skuprice13.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[13].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[14].getElementsByTagName('input')[0].value='" + txt_skuprice14.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[14].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[15].getElementsByTagName('input')[0].value='" + txt_skuprice15.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[15].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[16].getElementsByTagName('input')[0].value='" + txt_skuprice16.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[16].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[17].getElementsByTagName('input')[0].value='" + txt_skuprice17.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[17].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[18].getElementsByTagName('input')[0].value='" + txt_skuprice18.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[18].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[19].getElementsByTagName('input')[0].value='" + txt_skuprice19.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[19].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[20].getElementsByTagName('input')[0].value='" + txt_skuprice20.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[20].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[21].getElementsByTagName('input')[0].value='" + txt_skuprice21.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[21].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[22].getElementsByTagName('input')[0].value='" + txt_skuprice22.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[22].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[23].getElementsByTagName('input')[0].value='" + txt_skuprice23.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[23].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);

                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[24].getElementsByTagName('input')[0].value='" + txt_skuprice24.Text + "'", webBrowser1);
                        //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[24].getElementsByTagName('input')[1].value='" + skunum + "'", webBrowser1);
                        #endregion

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("设置SKU出错！" + ex.ToString());
            }


        }

        #endregion

        #endregion


        #region btn_upgoods_ertong_Click
        private void btn_upgoods_ertong_Click(object sender, EventArgs e)
        {

            if (CS.Taobao.GoToPublish(webBrowser1))
            {
                Taobao.ToDoPublish_Type(webBrowser1, "3");
                Taobao.SetErTongBao(webBrowser1);
                MessageBox.Show("可以开始上架新品了！");
            }


            return;

            //webBrowser1.Load("https://upload.taobao.com/auction/sell.jhtml?spm=a313o.201708ban.category.d48.10c322bTarY6y&mytmenu=wym");
            //webBrowser1.Focus();
            ////if (Browser.WaitWebPageLoad(" getElementsByDataSpm('d48')[0] ", webBrowser1))
            ////{
            ////    //点击发布新品
            ////    Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d48')[0] ", webBrowser1);
            //if (Browser.WaitWebPageLoad(" document.getElementsByClassName('cc-tree-item')[39] ", webBrowser1))
            //{
            //    //Browser.Delay(100);
            //    //点击“玩具/童车/益智/积木/模型”类目
            //    Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('cc-tree-item')[39].click() ", webBrowser1);
            //    Browser.Delay(500);
            //    if (Browser.WaitWebPageLoad(" document.getElementsByClassName('cc-cbox-group')[3].getElementsByTagName('li')[0] ", webBrowser1))
            //    {
            //        //点击“儿童包/背包/箱包”类目
            //        Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('cc-cbox-group')[3].getElementsByTagName('li')[0].click(); ", webBrowser1);
            //        Browser.Delay(500);
            //        if (Browser.WaitWebPageLoad(" document.getElementsByClassName('cc-cbox-group')[3].getElementsByTagName('li')[0] ", webBrowser1))
            //        {
            //            //点击“书包”类目
            //            Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('cc-list-item')[2].getElementsByClassName('cc-cbox-gcont')[1].getElementsByTagName('li')[0].click(); ", webBrowser1);

            //            //等待刷新数据
            //            Browser.Delay(500);
            //            //点击发布
            //            if (Browser.WaitWebPageLoad(" document.getElementById('J_CatePubBtn') ", webBrowser1))
            //            {
            //                Browser.MouseLeftByHtmlElement(" document.getElementById('J_CatePubBtn') ", webBrowser1);

            //                //打开发布页面，设置默认选项
            //                if (Browser.WaitWebPageLoad(" document.getElementsByClassName('next-radio')[0] ", webBrowser1))
            //                {
            //                    Taobao.SetErTongBao(webBrowser1);

            //                    #region bak 20181129


            //                    //Browser.Delay(200);


            //                    ////宝贝卖点
            //                    //string maidian = XMLHelper.GetValue("TaoBao_MaiDian");
            //                    //Auto.Clipboard_In(maidian);
            //                    //Browser.MouseLeftByHtmlElement(" document.getElementById('subTitle').getElementsByTagName('textarea')[0]", webBrowser1);
            //                    //Auto.Ctrl_V();


            //                    ////设置货号
            //                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('props clearfix')[0].getElementsByClassName('inputbox')[0].getElementsByTagName('input')[0].value='" + DateTime.Now.ToString("MMdd") + "'", webBrowser1);








            //                    ////设置适用年龄*******************************
            //                    ////点击选择
            //                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('select-button')[0].click()", webBrowser1);
            //                    //Browser.Delay(1000);
            //                    //int agecount = 0;
            //                    //string agecount_temp = Browser.JS_CEFBrowser("document.getElementsByClassName('J_popSelectBox')[0].getElementsByTagName('input').length", webBrowser1);
            //                    //if (int.TryParse(agecount_temp, out agecount))
            //                    //{
            //                    //    for (int i = 0; i < agecount; i++)
            //                    //    {
            //                    //        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('J_popSelectBox')[0].getElementsByTagName('input')[" + i.ToString() + "].click()", webBrowser1);
            //                    //    }
            //                    //    Browser.Delay(1000);
            //                    //    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('confirm-button ')[0].click()", webBrowser1);
            //                    //}
            //                    //Browser.Delay(1000);




            //                    ////********************************************
            //                    ////品牌选择其他***
            //                    //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-inputbox')[0].click(); ", webBrowser1);
            //                    ////点选品牌查询框
            //                    ////Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-search')[0].getElementsByTagName('input')[0].focus(); ", webBrowser1);
            //                    //Browser.MouseLeftByHtmlElement_Wait(" document.getElementsByClassName('combobox-search')[0].getElementsByTagName('input')[0] ", webBrowser1);
            //                    //Browser.Delay(500);
            //                    ////系统粘贴
            //                    //Auto.Clipboard_In("其他");
            //                    //Auto.Clipboard_Out();
            //                    //Browser.Delay(800);
            //                    ////选择“other/其他”选项
            //                    //Browser.JS_CEFBrowser_NoReturn(" document.getElementsByClassName('combobox-opts')[0].getElementsByTagName('li')[0].click(); ", webBrowser1);
            //                    ////********************************************
            //                    ////设置型号
            //                    ////Browser.MouseLeftByHtmlElement("document.getElementsByClassName('props clearfix')[0].getElementsByClassName('combobox-inputbox')[1]", webBrowser1);
            //                    ////Auto.Ctrl_V(DateTime.Now.ToString("MMdd"));
            //                    ////********************************************

            //                    ////设置图案
            //                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('props clearfix')[0].getElementsByClassName('combobox-list')[2].getElementsByTagName('li')[19].click()", webBrowser1);

            //                    ////Browser.MouseLeftByHtmlElement("document.getElementsByClassName('props clearfix')[0].getElementsByClassName('combobox-inputbox')[2]", webBrowser1);
            //                    ////Browser.Delay(200);
            //                    ////Browser.MouseLeftByHtmlElement("document.getElementsByClassName('props clearfix')[0].getElementsByClassName('combobox-list')[2].getElementsByTagName('li')[19]", webBrowser1);
            //                    ////Browser.Delay(500);






            //                    ////设置是否有导购视频
            //                    ////Browser.MouseLeftByHtmlElement("document.getElementsByClassName('props clearfix')[0].getElementsByClassName('combobox-inputbox')[3]", webBrowser1);
            //                    ////Browser.Delay(200);
            //                    //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('props clearfix')[0].getElementsByClassName('combobox-list')[3].getElementsByTagName('li')[2].click();", webBrowser1);
            //                    ////Browser.Delay(500);
            //                    #endregion

            //                    MessageBox.Show("可以开始上架新品了！");

            //                }
            //            }
            //        }
            //    }
            //}
        }
        #endregion

        private void txt_url_Click(object sender, EventArgs e)
        {

        }
    }





}

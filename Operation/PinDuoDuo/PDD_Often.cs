using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;

using excel_operation.CS;
using System.IO;
using System.Diagnostics;

namespace excel_operation.PinDuoDuo
{
    public partial class PDD_Often : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser2;
        CefSharp.WinForms.ChromiumWebBrowser webBrowser3;
        /// <summary>
        /// 采集商品列表
        /// </summary>
        List<string> GoodsList = new List<string>();
        /// <summary>
        /// 要操作的商品列表
        /// </summary>
        //string[] GoodsList2;


        public PDD_Often()
        {
            //Login tb = new Login();
            //tb.Show();
            //if (Manager.WaitLogin(tb))
            //{
            //    tb.Hide();
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("http://mms.pinduoduo.com/Pdd.html#/login");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(990, 725);
            //webBrowser1.Location = new Point(180, 12);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage1.Controls.Add(webBrowser1);
            //webBrowser1.RequestContext = tb.webBrowser1.RequestContext;
            //tb.Close();
            //tb.Dispose();


            //webBrowser2 = new ChromiumWebBrowser("http://mms.pinduoduo.com/Pdd.html#/login");
            //webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
            //webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            //webBrowser2.Size = new Size(990, 400);
            //webBrowser2.Location = new Point(0, 325);
            //webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            //webBrowser2.RequestContext = webBrowser1.RequestContext;
            //txt_url.Controls.Add(webBrowser2);


            //txt_chengfa.Text = XMLHelper.GetValue("TaoBao_Copy_ChengFa");
            //txt_jiafa.Text = XMLHelper.GetValue("TaoBao_Copy_JiaFa");
            //}

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


        #region 框架基础功能

        #region btn_test_Click
        private void btn_test_Click(object sender, System.EventArgs e)
        {
            string js = txt_js.Text;
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion


        #region btn_addjs_Click
        private void btn_addjs_Click(object sender, EventArgs e)
        {
            Browser.SetJSFile(webBrowser1);
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

        #endregion

        #region 转换xls
        private void btn_searchfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            this.txt_csvfilepath.Text = file.FileName;
        }

        private void btn_csvtoxls_Click(object sender, EventArgs e)
        {
            string path = txt_csvfilepath.Text;
            if (!string.IsNullOrEmpty(path))
            {
                string savepath = "C:\\Users\\mac\\Desktop\\" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".xls";
                ExcelHelper.CSVSaveasXLS(path, savepath);
                MessageBox.Show("转换完成");
            }
            else
            {
                MessageBox.Show("请选择文件");
            }
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
            webBrowser1.Load("http://mms.pinduoduo.com/Pdd.html#/login");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                string access = XMLHelper.GetValue("PinDuoDuo_Access1");
                string pwd = XMLHelper.GetValue("PinDuoDuo_Pwd1");

                Browser.JS_CEFBrowser_NoReturn("document.getElementById('usernameId').value='" + access + "'  ", webBrowser1);
                Browser.Delay(300);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('passwordId').value='" + pwd + "'  ", webBrowser1);
                //Browser.MouseLeftByHtmlElement("document.getElementById('tuxing')  ", webBrowser1);
                //Browser.MouseMoveByHtmlElement("document.getElementById('loginBtnId')  ", webBrowser1);
                //Browser.JS_CEFBrowser_NoReturn("document.getElementById('tuxing').focus()  ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginBtnId').setAttribute('data-click','true')  ", webBrowser1);
                Browser.JS_CEFBrowser_NoReturn("document.getElementById('loginBtnId').setAttribute('class','pdd-btn l-c-c-c-btn')  ", webBrowser1);
                //Browser.Delay(300);
                //Browser.MouseLeftByHtmlElement("document.getElementById('tuxing')", webBrowser1);
                //Browser.Delay(300);
                //Browser.MouseMoveByHtmlElement("document.getElementById('loginBtnId')", webBrowser1);

            }
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
                    txt_skuname1.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_1").Split(new char[] { '|' })[0];
                    txt_skuname2.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_2").Split(new char[] { '|' })[0];
                    txt_skuname3.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_3").Split(new char[] { '|' })[0];
                    txt_skuname4.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_4").Split(new char[] { '|' })[0];
                    txt_skuname5.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_5").Split(new char[] { '|' })[0];
                    txt_skuname6.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_6").Split(new char[] { '|' })[0];
                    txt_skuname7.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_7").Split(new char[] { '|' })[0];
                    txt_skuname8.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_8").Split(new char[] { '|' })[0];
                    txt_skuname9.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_9").Split(new char[] { '|' })[0];
                    txt_skuname10.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_10").Split(new char[] { '|' })[0];
                    txt_skuname11.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_11").Split(new char[] { '|' })[0];
                    txt_skuname12.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_12").Split(new char[] { '|' })[0];
                    txt_skuname13.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_13").Split(new char[] { '|' })[0];
                    txt_skuname14.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_14").Split(new char[] { '|' })[0];
                    txt_skuname15.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_15").Split(new char[] { '|' })[0];
                    txt_skuname16.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_16").Split(new char[] { '|' })[0];
                    txt_skuname17.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_17").Split(new char[] { '|' })[0];
                    txt_skuname18.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_18").Split(new char[] { '|' })[0];
                    txt_skuname19.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_19").Split(new char[] { '|' })[0];
                    txt_skuname20.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_20").Split(new char[] { '|' })[0];
                    txt_skuname21.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_21").Split(new char[] { '|' })[0];
                    txt_skuname22.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_22").Split(new char[] { '|' })[0];
                    txt_skuname23.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_23").Split(new char[] { '|' })[0];
                    txt_skuname24.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_24").Split(new char[] { '|' })[0];

                    txt_skuprice1.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_1").Split(new char[] { '|' })[1];
                    txt_skuprice2.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_2").Split(new char[] { '|' })[1];
                    txt_skuprice3.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_3").Split(new char[] { '|' })[1];
                    txt_skuprice4.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_4").Split(new char[] { '|' })[1];
                    txt_skuprice5.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_5").Split(new char[] { '|' })[1];
                    txt_skuprice6.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_6").Split(new char[] { '|' })[1];
                    txt_skuprice7.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_7").Split(new char[] { '|' })[1];
                    txt_skuprice8.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_8").Split(new char[] { '|' })[1];
                    txt_skuprice9.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_9").Split(new char[] { '|' })[1];
                    txt_skuprice10.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_10").Split(new char[] { '|' })[1];
                    txt_skuprice11.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_11").Split(new char[] { '|' })[1];
                    txt_skuprice12.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_12").Split(new char[] { '|' })[1];
                    txt_skuprice13.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_13").Split(new char[] { '|' })[1];
                    txt_skuprice14.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_14").Split(new char[] { '|' })[1];
                    txt_skuprice15.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_15").Split(new char[] { '|' })[1];
                    txt_skuprice16.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_16").Split(new char[] { '|' })[1];
                    txt_skuprice17.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_17").Split(new char[] { '|' })[1];
                    txt_skuprice18.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_18").Split(new char[] { '|' })[1];
                    txt_skuprice19.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_19").Split(new char[] { '|' })[1];
                    txt_skuprice20.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_20").Split(new char[] { '|' })[1];
                    txt_skuprice21.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_21").Split(new char[] { '|' })[1];
                    txt_skuprice22.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_22").Split(new char[] { '|' })[1];
                    txt_skuprice23.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_23").Split(new char[] { '|' })[1];
                    txt_skuprice24.Text = XMLHelper_SKU.GetValue("SKU" + typeindex + "_24").Split(new char[] { '|' })[1];
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
                    //是否有添加按钮
                    if (!Browser.ElementIsNull("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0]", webBrowser1))
                    {

                        //1
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname1.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //2
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname2.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //3
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname3.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //4
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname4.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //5
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname5.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //6
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname6.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //7
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname7.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //8
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname8.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //9
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname9.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //10
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname10.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //11
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname11.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //12
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname12.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //13
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname13.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //14
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname14.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //15
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname15.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //16
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname16.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //17
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname17.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //18
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname18.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //19
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname19.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //20
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname20.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //21
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname21.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //22
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname22.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //23
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname23.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //24
                        //点击添加按钮
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-o-s-a-btn')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        //输入SKU名称
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('input')[0].value='" + txt_skuname24.Text + "'", webBrowser1);
                        //点击确定
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-add-spec-add-dialog')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //点击批量上传图片
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('mmscheckbox')[0].getElementsByTagName('i')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //不拼团加价
                        int price_jiajia = 0;
                        string temp = XMLHelper.GetValue("PinDuoDuo_Price_BuPinTuan");
                        int.TryParse(temp, out price_jiajia);
                        decimal price_tuangou = 0;

                        //设置库存
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-form-input')[14].value='" + XMLHelper.GetValue("PinDuoDuo_GoodsNum") + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pull-left')[0].click()", webBrowser1);
                        Browser.Delay(300);

                        //设置价格
                        //设置团购价格
                        //temp = txt_skuprice1.Text;
                        //if (decimal.TryParse(temp, out price_tuangou))
                        //{
                        //    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-dui-table')[0].getElementsByTagName('tr')[1].getElementsByTagName('input')[1].value='" + (price_tuangou + price_jiajia).ToString() + "'", webBrowser1);
                        //    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-dui-table')[0].getElementsByTagName('tr')[1].getElementsByTagName('input')[1].value='" + (price_tuangou + price_jiajia).ToString() + "'", webBrowser1);
                        //}

                        for (int i = 0; i < 24; i++)
                        {
                            //获取SKU值
                            temp = XMLHelper_SKU.GetValue("SKU5_" + (i + 1).ToString());
                            if (!string.IsNullOrEmpty(temp))
                            {
                                string temp_name = temp.Split(new char[] { '|' })[0];
                                string temp_price = temp.Split(new char[] { '|' })[1];
                                if (decimal.TryParse(temp_price, out price_tuangou))
                                {
                                    //开始赋值
                                    //团购价格
                                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-dui-table')[0].getElementsByTagName('tr')["+(i+1).ToString()+"].getElementsByTagName('input')[1].value='" + price_tuangou.ToString()  + "'", webBrowser1);
                                    //单买价格
                                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-dui-table')[0].getElementsByTagName('tr')[" + (i + 1).ToString() + "].getElementsByTagName('input')[2].value='" + (price_tuangou + price_jiajia).ToString() + "'", webBrowser1);
                                    //商家编码
                                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-dui-table')[0].getElementsByTagName('tr')[" + (i + 1).ToString() + "].getElementsByTagName('input')[3].value='" + temp_name + "'", webBrowser1);
                                    Browser.Delay(300);
                                }
                            }
                        }


                        #region 备份
                        /* 备份
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[0].value='" + txt_skuname1.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[0].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[1].value='" + txt_skuname2.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[1].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[2].value='" + txt_skuname3.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[2].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[3].value='" + txt_skuname4.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[3].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[4].value='" + txt_skuname5.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[4].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[5].value='" + txt_skuname6.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[5].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[6].value='" + txt_skuname7.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[6].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[7].value='" + txt_skuname8.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[7].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[8].value='" + txt_skuname9.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[8].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[9].value='" + txt_skuname10.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[9].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[10].value='" + txt_skuname11.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[10].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[11].value='" + txt_skuname12.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[11].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[12].value='" + txt_skuname13.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[12].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[13].value='" + txt_skuname14.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[13].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[14].value='" + txt_skuname15.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[14].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[15].value='" + txt_skuname16.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[15].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[16].value='" + txt_skuname17.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[16].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[17].value='" + txt_skuname18.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[17].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[18].value='" + txt_skuname19.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[18].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[19].value='" + txt_skuname20.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[19].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[20].value='" + txt_skuname21.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[20].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[21].value='" + txt_skuname22.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[21].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[22].value='" + txt_skuname23.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[22].click()", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('picker-text')[23].value='" + txt_skuname24.Text + "'", webBrowser1);
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('color-select')[23].click()", webBrowser1);


                        //激活SKUJS
                        for (int i = 23; i >= 0; i--)
                        {
                            Browser.MouseLeftByHtmlElement("document.getElementsByClassName('picker-text')[" + i.ToString() + "]", webBrowser1);
                        }
                        //激活SKU价格JS
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[1].getElementsByTagName('input')[0]", webBrowser1);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[1].getElementsByTagName('input')[0]", webBrowser1);


                        //等待1s
                        Browser.Delay(1000);

                        //设置第一个SKU价格和数量

                        string skunum = "100";


                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[1].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice1.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[1].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);


                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[2].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice2.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[2].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);


                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[3].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice3.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[3].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);


                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[4].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice4.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[4].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);


                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[5].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice5.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[5].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);

                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[6].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice6.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[6].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);

                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[7].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice7.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[7].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[8].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice8.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[8].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[9].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice9.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[9].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[10].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice10.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[10].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[11].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice11.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[11].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[12].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice12.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[12].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[13].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice13.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[13].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[14].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice14.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[14].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[15].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice15.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[15].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[16].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice16.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[16].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[17].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice17.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[17].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[18].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice18.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[18].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[19].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice19.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[19].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[20].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice20.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[20].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[21].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice21.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[21].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[22].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice22.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[22].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[23].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice23.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[23].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);

                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[24].getElementsByTagName('input')[0]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(txt_skuprice24.Text);
                        Browser.MouseLeftByHtmlElement("document.getElementsByClassName('list')[0].getElementsByTagName('tr')[24].getElementsByTagName('input')[1]", 10, 10, webBrowser1);
                        Auto.Ctrl_V(skunum);
                        */
                        #endregion

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

        #region btn_showmessage_Click
        private void btn_showmessage_Click(object sender, EventArgs e)
        {
            //显示
            //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('important-message')[0].style.display = 'block'", webBrowser1);
            //隐藏
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('important-message')[0].style.display = 'none'", webBrowser1);
        }
        #endregion

        #region btn_indexpage_Click
        private void btn_indexpage_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("http://mms.pinduoduo.com/Pdd.html#/index");
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('important-message')[0].style.display = 'none'", webBrowser1);
        }
        #endregion

        #region btn_daifahuo_Click
        private void btn_daifahuo_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("http://mms.pinduoduo.com/Pdd.html#/orders/search/index?type=0");
        }
        #endregion







        #region btn_shangxin_shuangjianbao_Click
        private void btn_shangxin_shuangjianbao_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("http://mms.pinduoduo.com/Pdd.html#/goods/goods_list/index");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-btn')[1].click()", webBrowser1);
                Browser.Delay(5000);
                //点击查询
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-btn')[2].click()", webBrowser1);


                //ChromiumWebBrowser
            }
        }
        #endregion

        private void btn_shangxin2_Click(object sender, EventArgs e)
        {
            string gid = Browser.JS_CEFBrowser("document.getElementsByClassName('pdd-dui-table')[0].getElementsByTagName('td')[0].innerText", webBrowser1);
            webBrowser1.Load("http://mms.pinduoduo.com/Pdd.html#/goods/category?id=" + gid + "&type=add");
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                webBrowser1.Focus();
                //选择分类
                //Browser.Delay(1000);
                //Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('goods-k-i-b-row')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                Browser.Delay(1000);
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('bottom-select')[0].getElementsByTagName('a')[1].click()", webBrowser1);
                Browser.Delay(1000);
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('bottom-select')[1].getElementsByTagName('a')[3].click()", webBrowser1);
                Browser.Delay(1000);
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('bottom-select')[2].getElementsByTagName('a')[0].click()", webBrowser1);
                Browser.Delay(1000);
                Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-btn')[2].click()", webBrowser1);

                //等待商品编辑页面

                if (Browser.WaitWebPageLoad("document.getElementsByClassName('goods-name-normal') ", webBrowser1))
                {
                    webBrowser1.Focus();
                    Browser.Delay(1000);
                    //设置价格
                    string jiage = XMLHelper.GetValue("PinDuoDuo_Price");
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-form-input')[3].value = '" + jiage + "'", webBrowser1);
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-form-input')[3].value = '" + jiage + "'", webBrowser1);
                    Browser.Delay(1000);
                    //设置邮费
                    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-dui-select')[10]", webBrowser1);
                    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-dui-select')[10]", 5, 30, webBrowser1);
                    Browser.Delay(1000);
                    //设置重量
                    string zhongliang = XMLHelper.GetValue("PinDuoDuo_ZhongLiang");
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-form-input')[4].value = '" + zhongliang + "'", webBrowser1);
                    Browser.Delay(1000);
                    //设置描述
                    string miaoshu = XMLHelper.GetValue("PinDuoDuo_JieShao");
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-form-input')[5].value = '" + miaoshu + "'", webBrowser1);
                    Browser.Delay(1000);
                    //设置SKU规格
                    //点击一种规格
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('g-s-s-b-r-c-btn')[0].getElementsByTagName('li')[1].click()", webBrowser1);
                    Browser.Delay(1000);
                    //点击确定
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-confirm-content')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                    Browser.Delay(1000);

                    //点击确定
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-confirm-content')[0].getElementsByTagName('a')[0].click()", webBrowser1);
                    Browser.Delay(1000);
                    //点击规格
                    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-dui-select-text')[13]", webBrowser1);
                    Browser.Delay(1000);
                    //点击款式
                    Browser.MouseLeftByHtmlElement("document.getElementsByClassName('pdd-dui-select-text')[13]", 10, 120, webBrowser1);
                    Browser.Delay(1000);

                    //设置商家编码
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('pdd-form-input')[18].value = '" + DateTime.Now.ToString("yyyyMMddHHmm") + "'", webBrowser1);
                    Browser.Delay(1000);

                }

            }
        }

        private void btn_kefu_Click(object sender, EventArgs e)
        {
            //PinDuoDuo.PDD_KeFu kefu = new PDD_KeFu();
            //kefu.Show();
            webBrowser2 = new ChromiumWebBrowser("http://mms.pinduoduo.com/assets/chat-merchant/dist/index.html");
            webBrowser2.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser2.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser2.Size = new Size(990, 725);
            //webBrowser2.Location = new Point(0, 325);
            webBrowser2.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            webBrowser2.RequestContext = webBrowser1.RequestContext;
            tabPage3.Controls.Add(webBrowser2);

        }

        private void btn_kefu2_Click(object sender, EventArgs e)
        {
            webBrowser3 = new ChromiumWebBrowser("http://mms.pinduoduo.com/assets/chat-merchant/dist/index.html");
            webBrowser3.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser3.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser3.Size = new Size(990, 725);
            //webBrowser3.Location = new Point(0, 325);
            webBrowser3.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            webBrowser3.RequestContext = webBrowser1.RequestContext;
            tabPage4.Controls.Add(webBrowser3);
        }
    }





}

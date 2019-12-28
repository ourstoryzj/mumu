using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using Operation.Other;
using System.Diagnostics;
using System.ComponentModel;
using Operation.CS;
using System.Data;

namespace Operation.TaoBao
{
    public partial class TB_Keys_bak : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        /// <summary>
        /// 操作后的数据
        /// </summary>
        List<Entity.keys> list_key = new List<keys>();
        /// <summary>
        /// 临时数据
        /// </summary>
        List<Entity.keys> list_key_temp = new List<keys>();
        /// <summary>
        /// 删除的数据
        /// </summary>
        List<Entity.keys> list_key_delete = new List<keys>();
        /// <summary>
        /// 原始数据
        /// </summary>
        List<Entity.keys> list_key_yuan = new List<keys>();
        /// <summary>
        /// 词库ID
        /// </summary>
        int ckid = 0;
        /// <summary>
        /// 全选开关
        /// </summary>
        int allselect = 0;
        /// <summary>
        /// 是否第一次搜索
        /// </summary>
        bool isfirst = true;


        public TB_Keys_bak()
        {
            //Login tb = new Login();
            //tb.Show();
            //if (Manager.WaitLogin(tb))
            //{
            //tb.Hide();
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("https://www.baidu.com");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(980, 660);
            webBrowser1.Location = new Point(6, 70);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //this.Controls.Add(webBrowser1);
            tabPage1.Controls.Add(webBrowser1);
            //webBrowser1.RequestContext = tb.webBrowser1.RequestContext;
            //tb.Close();
            //tb.Dispose();


            //}
            //list_key = new List<keys>();
            this.StartPosition = FormStartPosition.CenterScreen;
            //绑定数据后不会自动创建列
            dgv1.AutoGenerateColumns = false;
            //不显示空白行
            dgv1.AllowUserToAddRows = false;
            //绑定数据后不会自动创建列
            dgv2.AutoGenerateColumns = false;
            //不显示空白行
            dgv2.AllowUserToAddRows = false;

            Bind();
            bind_zaoci();
            bind_ciku();

            //tabControl1.SelectedTab = tabPage4;

        }

        #region Bind 
        void Bind()
        {
            txt_changdu1.Text = XMLHelper.GetValue("Key_KeyLength1");
            txt_changdu2.Text = XMLHelper.GetValue("Key_KeyLength2");

            txt_dianjilv1.Text = XMLHelper.GetValue("Key_DianJiLv1");
            txt_dianjilv2.Text = XMLHelper.GetValue("Key_DianJiLv2");

            txt_dianjishu1.Text = XMLHelper.GetValue("Key_DianJiShu1");
            txt_dianjishu2.Text = XMLHelper.GetValue("Key_DianJiShu2");

            txt_goodsnum1.Text = XMLHelper.GetValue("Key_GoodsNum1");
            txt_goodsnum2.Text = XMLHelper.GetValue("Key_GoodsNum2");

            txt_renshu1.Text = XMLHelper.GetValue("Key_RenQi1");
            txt_renshu2.Text = XMLHelper.GetValue("Key_RenQi2");

            txt_shangcheng1.Text = XMLHelper.GetValue("Key_SangCheng1");
            txt_shangcheng2.Text = XMLHelper.GetValue("Key_SangCheng2");

            txt_ZTCprice1.Text = XMLHelper.GetValue("Key_ZTCPrice1");
            txt_ZTCprice2.Text = XMLHelper.GetValue("Key_ZTCPrice2");

            txt_zhuanhualv1.Text = XMLHelper.GetValue("Key_ZhuanHuaLv1");
            txt_zhuanhualv2.Text = XMLHelper.GetValue("Key_ZhuanHuaLv2");

            txt_key.Text = XMLHelper.GetValue("TaoBao_KeyHelper_Key");
        }

        /// <summary>
        /// 绑定噪词库
        /// </summary>
        void bind_zaoci()
        {
            IList<yh_zaoci> list = BLL2.yh_zaociManager.Search(1, 100, "", "1", 0, new DateTime(), new DateTime(), "");
            cb_zaoci.DataSource = list;
            cb_zaoci.DisplayMember = "zname";
            cb_zaoci.ValueMember = "zid";
        }

        void bind_ciku()
        {
            List<keys_lexicon> list = (List<keys_lexicon>)BLL2.keys_lexiconManager.Search(1, 1000, "", "", new DateTime(), new DateTime(), "");
            dgv2.DataSource = list.ToDataTable();

            //List<keys_lexicon> list = (List<keys_lexicon>)BLL2.keys_lexiconManager.Search(1, 1000, "", "", new DateTime(), new DateTime(), "");
            //dgv2.DataSource = list;
        }

        #endregion

        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {
            Manager.dianpu_huan(webBrowser1);
            this.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region btn_test_Click
        private void btn_test_Click(object sender, System.EventArgs e)
        {
            string js = txt_js.Text;
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion

        #region btn_canmou_Click

        private void btn_canmou_Click(object sender, EventArgs e)
        {

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

        #region btn_searh_Click


        private void btn_searh_Click(object sender, EventArgs e)
        {

            //保存搜索词到xml
            string key_temp = txt_key.Text.Trim();
            XMLHelper.SetValue("TaoBao_KeyHelper_Key", key_temp);

            ckid = 0;

            CaiJi_Data();

            dgv1.DataSource = list_key.ToDataTable();
            list_key_yuan.Clear();
            list_key_yuan.AddRange(list_key);
            //list_key_yuan = list_key;
            //数据采集完毕
            tabControl1.SelectedTab = tabPage2;
            MessageBox.Show("采集成功");
            CaiJi_IsFirst();//采集完后设置已经采集了一次
        }





        #endregion

        #region  采集辅助方法

        /// <summary>
        /// 设置采集条件
        /// </summary>
        void CaiJi_Set()
        {
            if (isfirst)
            {

                //点击最近一天
                Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('num')[0] ", webBrowser1);
                Browser.Delay(1000);
                //点击最近七天
                Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('dtpicker-menu')[0].getElementsByTagName('li')[1] ", webBrowser1);
                Browser.Delay(1000);
                //点击搜索终端
                Browser.MouseLeftByHtmlElement(" document.getElementsByClassName(' btn-dropdown')[0] ", webBrowser1);
                Browser.Delay(1000);
                //点击无线端
                Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('ui-dropdown-menu-left')[0].getElementsByTagName('li')[2] ", webBrowser1);
                Browser.Delay(1000);
                //等待搜索结果
                //Browser.Delay(500);

                //点击显示条数
                Browser.MouseLeftByHtmlElement(" document.getElementsByClassName(' btn-dropdown')[1] ", webBrowser1);
                Browser.Delay(1000);
                //点击100条
                Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('ui-dropdown-menu-left')[1].getElementsByTagName('li')[3] ", webBrowser1);
                Browser.Delay(1000);


            }
        }

        void CaiJi_Set2()
        {
            //点击搜索人数占比
            Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('combo-panel-inline')[0].getElementsByTagName('span')[4] ", webBrowser1);
            Browser.Delay(1000);
            //点击点击人气
            Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('combo-panel-block')[0].getElementsByTagName('span')[1] ", webBrowser1);
            Browser.Delay(1000);
            //点击搜索热度
            Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('combo-panel-inline')[0].getElementsByTagName('span')[7] ", webBrowser1);
            Browser.Delay(1000);
            //点击支付转化率
            Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('combo-panel-block')[0].getElementsByTagName('span')[10] ", webBrowser1);
            Browser.Delay(1000);
        }

        /// <summary>
        /// 是否是第一次查询
        /// </summary>
        bool CaiJi_IsFirst()
        {
            //bool isfirst = true;
            //if (!string.IsNullOrEmpty(webBrowser1.Address))
            //{
            //    if (webBrowser1.Address.IndexOf("search_words") != -1)
            //    {
            //        isfirst = false;
            //    }
            //}
            isfirst = false;
            return isfirst;
        }

        /// <summary>
        /// 跳转到生意参谋-市场行情-商品店铺榜-搜索词查询
        /// </summary>
        void Caiji_GOTO()
        {

            #region 2017年10月11日11:33:40修改
            /*
            if (isfirst)
            {
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
                        Browser.Delay(1500);
                        //延迟-搜索词查询
                        if (Browser.WaitWebPageLoad("getElementsByDataSpm('d380')[0]", webBrowser1))
                        {
                            Browser.Delay(1000);
                            //删除广告
                            Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('ds-left-act-close')[0] ", webBrowser1);
                            //点击搜索词查询
                            //Browser.JS_CEFBrowser_NoReturn(" alert(getElementsByDataSpm('d380')[0]) ", webBrowser1);
                            Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d380')[0]", webBrowser1);
                            Browser.Delay(1000);
                            if (Browser.WaitWebPageLoad("getClassName('main-search-input')[0]", webBrowser1))
                            {
                                return;
                            }
                        }
                    }
                }
            }*/
            #endregion


            if (isfirst)
            {
                webBrowser1.Load("https://myseller.taobao.com/seller_admin.htm");
                if (Browser.WaitWebPageLoad("getElementsByDataSpm('" + XMLHelper.GetValue("DataSpm_CanMou") + "')[0]", webBrowser1))
                {
                    //在卖家中心找到生意参谋
                    Browser.MouseLeftByHtmlElement("getElementsByDataSpm('" + XMLHelper.GetValue("DataSpm_CanMou") + "')[0]", webBrowser1);
                    //第一次点击进入浏览器，第二次点击开始操作
                    Auto.Mouse_Left();
                    //d1057市场
                    if (Browser.WaitWebPageLoad("getElementsByDataSpm('" + XMLHelper.GetValue("DataSpm_ShiChang") + "')[0]", webBrowser1))
                    {
                        //关闭提示窗口dialog-show
                        Browser.MouseLeftByHtmlElement(" getClassName('dialog-show')[0].getElementsByTagName('i')[0] ", webBrowser1);
                        //点击市场行情
                        Browser.MouseLeftByHtmlElement("getElementsByDataSpm('" + XMLHelper.GetValue("DataSpm_ShiChang") + "')[0]", webBrowser1);
                        Browser.Delay(2000);
                        //延迟-搜索词查询d1078
                        if (Browser.WaitWebPageLoad("getElementsByDataSpm('" + XMLHelper.GetValue("DataSpm_SouSuoCi") + "')[0]", webBrowser1))
                        {
                            Browser.Delay(1000);
                            //删除广告
                            Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('ds-left-act-close')[0] ", webBrowser1);
                            //点击搜索词查询
                            //Browser.JS_CEFBrowser_NoReturn(" alert(getElementsByDataSpm('d380')[0]) ", webBrowser1);
                            Browser.MouseLeftByHtmlElement("getElementsByDataSpm('" + XMLHelper.GetValue("DataSpm_SouSuoCi") + "')[0]", webBrowser1);
                            Browser.Delay(1500);
                            if (Browser.WaitWebPageLoad("getClassName('main-search-input')[0]", webBrowser1))
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 采集数据
        /// </summary>
        void CaiJi_Data()
        {
            string key = txt_key.Text.Trim();
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("请输入要搜索的关键词");
                return;
            }
            else
            {
                txt_keysname.Text = key;
                //清空缓存数据
                list_key.Clear();
                list_key_temp.Clear();
                list_key_delete.Clear();
                list_key_yuan.Clear();
            }


            Caiji_GOTO();

            //设置浏览器焦点
            webBrowser1.Focus();
            Auto.Clipboard_In(key);

            //设置关键词
            //删除之前的关键词
            //Browser.MouseLeftByHtmlElement(" getClassName('main-search-del')[0] ", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn(" getClassName('main-search-input')[0].value=''; ", webBrowser1);
            //点击输入框
            Browser.MouseLeftByHtmlElement(" getClassName('main-search-input')[0] ", webBrowser1);
            Auto.Ctrl_V();
            Browser.Delay(1000);
            //点击搜索
            Browser.MouseLeftByHtmlElement(" getClassName('main-search-btn')[0] ", webBrowser1);
            //等待搜索结果
            Browser.Delay(500);

            zhijiecaiji();


        }


        #endregion

        #region 直接复制
        void zhijiecaiji()
        {


            //点击相关搜索词
            Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('ui-tab-head')[0].getElementsByTagName('li')[1] ", webBrowser1);
            Browser.Delay(5000);
            //判断等待 相关搜索词
            if (Browser.WaitWebPageLoad("document.getElementsByClassName('ui-tab-head')[0].getElementsByTagName('li')[1]", webBrowser1))
            {
                CaiJi_Set();

                CaiJi_Set2();


                //模拟100页数据
                for (int i = 0; i < 100; i++)
                {
                    //获取数据，处理数据
                    string datas = Browser.JS_CEFBrowser(" document.getElementsByClassName('related-word-table')[0].getElementsByTagName('tbody')[0].innerHTML ", webBrowser1);
                    //txt_js.Text = datas;
                    CaiJi_XiangGuan(datas);

                    //判断，点击下一页
                    //如果还有下一页
                    if (Browser.JS_CEFBrowser(" document.getElementsByClassName('ui-pagination-next').length ", webBrowser1) != "0")
                    {
                        //点击下一页
                        Browser.MouseLeftByHtmlElement(" document.getElementsByClassName('ui-pagination-next')[0] ", webBrowser1);
                        Browser.Delay(1300);
                    }
                    else
                    {
                        //如果没有下一页，跳出循环
                        break;
                    }
                }
            }
        }
        #endregion

        #region CaiJi_XiangGuan
        /// <summary>
        /// 把页面代码转化成数据
        /// </summary>
        /// <param name="datas"></param>
        void CaiJi_XiangGuan(string datas)
        {
            try
            {
                datas = datas.Replace("</tr>", "");
                datas = datas.Replace("<tr>", "|");
                string[] trs = datas.Split('|');
                foreach (string td in trs)
                {
                    if (string.IsNullOrEmpty(td))
                    {
                        continue;
                    }

                    keys k = new keys();
                    string temp = td.Replace("</td>", "|");
                    string[] tds = temp.Split('|');
                    for (int i = 0; i < tds.Length; i++)
                    {
                        string html_res = tds[i];
                        string res = "";
                        if (string.IsNullOrEmpty(html_res))
                        {
                            continue;
                        }
                        //判断如果是关键词
                        if (html_res.IndexOf("</a>") > -1)
                        {
                            //<td class="text keyword-row" width="16%" type="text"><a href="//sycm.taobao.com/mq/words/search_words.htm#/?keyword=%E5%8F%8C%E8%82%A9%E5%8C%85%E5%A5%B3%E5%B8%86%E5%B8%83" title="双肩包女帆布" target="_self">双肩包女帆布</a>
                            //temp = html_res.Replace(">", "|");
                            string[] temp_res = html_res.Split('>');
                            res = temp_res[2].Replace("</a", "");
                        }
                        else
                        {
                            //string[] temp_res = html_res.Split('>');
                            //string[] ress = temp_res[1].Split('<');
                            //res = ress[0];
                            string[] temp_res = html_res.Split('>');
                            res = temp_res[1];
                        }

                        //去掉，和%
                        res = res.Replace(",", "");
                        res = res.Replace("%", "");
                        res = res.Replace("-", "");
                        //判断是否为空
                        if (string.IsNullOrEmpty(res))
                        {
                            continue;
                        }
                        try
                        {
                            //数据添加到keys实体中
                            if (i == 0)
                            {
                                //关键词
                                k.kname = res;
                            }
                            else if (i == 1)
                            {
                                //人气
                                k.krenqi = Convert.ToInt32(res);
                            }
                            else if (i == 2)
                            {
                                //点击率
                                k.kdianjilv = Convert.ToDecimal(res);
                            }
                            else if (i == 3)
                            {
                                //商城占比
                                k.kSCzhanbi = Convert.ToDecimal(res);
                            }
                            else if (i == 4)
                            {
                                //商品数量
                                k.kgoodsnum = Convert.ToInt32(res);
                            }
                            else if (i == 5)
                            {
                                //直通车价格
                                k.kZTCjiage = Convert.ToDecimal(res);
                            }
                            else if (i == 6)
                            {
                                //点击人气
                                k.kSSzhanbi = Convert.ToInt32(res);
                            }
                            else if (i == 7)
                            {
                                //转化率
                                k.kzhuanhualv = Convert.ToDecimal(res);
                            }
                            k.kremark1 = k.krenqi / k.kgoodsnum * 1000;
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("数据添加到keys实体中：" + ex.ToString());
                        }

                    }
                    list_key.Add(k);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("采集相关搜索词失败：" + e.ToString());
                //throw new Exception();
            }
        }

        #endregion

        #region dgv1_CellContentClick 排序
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {

            }
            else if (e.RowIndex == -1)
            {
                //如果是全选
                if (e.ColumnIndex == 0)
                {
                    foreach (DataGridViewRow row in dgv1.Rows)
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
                        dgv1.Sort(dgv1.Columns[e.ColumnIndex], ListSortDirection.Descending);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("排序出错=========================" + ex.Message);
                    }
                }
            }
        }
        #endregion

        #region dgv1_RowPostPaint 添加行号

        private void dgv1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 10);
        }


        #endregion

        #region btn_ToDo_Click
        /// <summary>
        /// 操作生意参谋数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ToDo_Click(object sender, EventArgs e)
        {
            SaveXml();

            int changdu1 = 0;
            int.TryParse(txt_changdu1.Text.Trim(), out changdu1);
            int changdu2 = 0;
            int.TryParse(txt_changdu2.Text.Trim(), out changdu2);

            int renshu1 = 0;
            int.TryParse(txt_renshu1.Text.Trim(), out renshu1);
            int renshu2 = 0;
            int.TryParse(txt_renshu2.Text.Trim(), out renshu2);

            int dianjishu1 = 0;
            int.TryParse(txt_dianjishu1.Text.Trim(), out dianjishu1);
            int dianjishu2 = 0;
            int.TryParse(txt_dianjishu2.Text.Trim(), out dianjishu2);

            decimal dianjilv1 = 0;
            decimal.TryParse(txt_dianjilv1.Text.Trim(), out dianjilv1);
            decimal dianjilv2 = 0;
            decimal.TryParse(txt_dianjilv2.Text.Trim(), out dianjilv2);

            decimal shangcheng1 = 0;
            decimal.TryParse(txt_shangcheng1.Text.Trim(), out shangcheng1);
            decimal shangcheng2 = 0;
            decimal.TryParse(txt_shangcheng2.Text.Trim(), out shangcheng2);

            int goodsnum1 = 0;
            int.TryParse(txt_goodsnum1.Text.Trim(), out goodsnum1);
            int goodsnum2 = 0;
            int.TryParse(txt_goodsnum2.Text.Trim(), out goodsnum2);

            decimal ZTCprice1 = 0;
            decimal.TryParse(txt_ZTCprice1.Text.Trim(), out ZTCprice1);
            decimal ZTCprice2 = 0;
            decimal.TryParse(txt_ZTCprice2.Text.Trim(), out ZTCprice2);

            decimal zhuanhualv1 = 0;
            decimal.TryParse(txt_zhuanhualv1.Text.Trim(), out zhuanhualv1);
            decimal zhuanhualv2 = 0;
            decimal.TryParse(txt_zhuanhualv2.Text.Trim(), out zhuanhualv2);
            list_key_temp.Clear();
            list_key_temp.AddRange(list_key);
            list_key = new List<keys>();
            foreach (keys k in list_key_temp)
            {
                if (changdu1 != 0)
                {
                    if (k.kname.Length < changdu1)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (changdu2 != 0)
                {
                    if (k.kname.Length > changdu2)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (renshu1 != 0)
                {
                    if (k.krenqi < renshu1)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (renshu2 != 0)
                {
                    if (k.krenqi > renshu2)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (dianjishu1 != 0)
                {
                    if (k.kSSzhanbi < dianjishu1)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (dianjishu2 != 0)
                {
                    if (k.kSSzhanbi > dianjishu2)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (dianjilv1 != 0)
                {
                    if (k.kdianjilv < dianjilv1)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (dianjilv2 != 0)
                {
                    if (k.kdianjilv > dianjilv2)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (shangcheng1 != 0)
                {
                    if (k.kSCzhanbi < shangcheng1)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (shangcheng2 != 0)
                {
                    if (k.kSCzhanbi > shangcheng2)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (goodsnum1 != 0)
                {
                    if (k.kgoodsnum < goodsnum1)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (goodsnum2 != 0)
                {
                    if (k.kgoodsnum > goodsnum2)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (ZTCprice1 != 0)
                {
                    if (k.kZTCjiage < ZTCprice1)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (ZTCprice2 != 0)
                {
                    if (k.kZTCjiage > ZTCprice2)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (zhuanhualv1 != 0)
                {
                    if (k.kzhuanhualv < zhuanhualv1)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }
                if (zhuanhualv2 != 0)
                {
                    if (k.kzhuanhualv > zhuanhualv2)
                    {
                        list_key_delete.Add(k);
                        continue;
                    }
                }


                list_key.Add(k);

            }
            dgv1.DataBindings.Clear();
            dgv1.DataSource = list_key.ToDataTable();
            dgv1.Refresh();
            MessageBox.Show("删选生意参谋数据成功");

        }
        #endregion

        #region SaveXml
        /// <summary>
        /// 保存xml文件
        /// </summary>
        void SaveXml()
        {
            XMLHelper.SetValue("Key_KeyLength1", txt_changdu1.Text);
            XMLHelper.SetValue("Key_KeyLength2", txt_changdu2.Text);

            XMLHelper.SetValue("Key_DianJiLv1", txt_dianjilv1.Text);
            XMLHelper.SetValue("Key_DianJiLv2", txt_dianjilv2.Text);

            XMLHelper.SetValue("Key_DianJiShu1", txt_dianjishu1.Text);
            XMLHelper.SetValue("Key_DianJiShu2", txt_dianjishu2.Text);

            XMLHelper.SetValue("Key_GoodsNum1", txt_goodsnum1.Text);
            XMLHelper.SetValue("Key_GoodsNum2", txt_goodsnum2.Text);

            XMLHelper.SetValue("Key_RenQi1", txt_renshu1.Text);
            XMLHelper.SetValue("Key_RenQi2", txt_renshu2.Text);

            XMLHelper.SetValue("Key_SangCheng1", txt_shangcheng1.Text);
            XMLHelper.SetValue("Key_SangCheng2", txt_shangcheng2.Text);

            XMLHelper.SetValue("Key_ZTCPrice1", txt_ZTCprice1.Text);
            XMLHelper.SetValue("Key_ZTCPrice2", txt_ZTCprice2.Text);

            XMLHelper.SetValue("Key_ZhuanHuaLv1", txt_zhuanhualv1.Text);
            XMLHelper.SetValue("Key_ZhuanHuaLv2", txt_zhuanhualv2.Text);
        }


        #endregion

        #region btn_clearzao_Click
        /// <summary>
        /// 去噪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_clearzao_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cb_zaoci.SelectedValue);
                IList<yh_zaoci> list = BLL2.yh_zaociManager.Search(1, 5000, "", "", id, new DateTime(), new DateTime(), "");
                list_key_temp = list_key;
                list_key = new List<keys>();

                //为零则不删除，为1则删除
                int state = 0;

                foreach (keys k in list_key_temp)
                {

                    //设置关键词状态为正常0
                    state = 0;
                    foreach (yh_zaoci zc in list)
                    {
                        try
                        {

                            //if (zc.zname == "圣罗兰")
                            //{
                            //    state = 1;
                            //}
                            if (k.kname.IndexOf(zc.zname) > -1)
                            {
                                //设置关键词状态为删除1
                                state = 1;
                                list_key_delete.Add(k);
                                break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("去噪库出现问题");
                        }

                    }
                    if (state == 0)
                        list_key.Add(k);
                }
                dgv1.DataBindings.Clear();
                dgv1.DataSource = list_key.ToDataTable();
                dgv1.Refresh();
                MessageBox.Show("去噪成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("去噪出现问题:" + ex.ToString());
            }

        }


        #endregion

        #region btn_del_Click

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                keys zc = null;
                if (MessageBox.Show("是否要删除所有勾选关键词数据?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    list_key_temp = new List<keys>();
                    foreach (DataGridViewRow row in dgv1.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            if ((bool)cbx.FormattedValue)
                            {
                                //int ssss = 1;
                                //row.Cells[]
                                zc = (Entity.keys)row.DataBoundItem;
                                if (zc != null)
                                {
                                    list_key_temp.Add(zc);
                                    list_key_delete.Add(zc);
                                }
                            }
                        }
                    }
                }

                //dgv1.DataSource = null;
                //dgv1.DataBindings.Clear();

                dgv1.DataSource = list_key_temp.ToDataTable();

                foreach (keys k in list_key_temp)
                {
                    list_key.Remove(k);
                }

                dgv1.DataSource = list_key.ToDataTable();
                dgv1.Refresh();
                MessageBox.Show("删除成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除数据出错" + ex.ToString());
            }
        }
        #endregion

        #region btn_zaociupdate_Click
        /// <summary>
        /// 更新噪词库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_zaociupdate_Click(object sender, EventArgs e)
        {
            bind_zaoci();
        }
        #endregion

        #region btn_huifu_Click
        /// <summary>
        /// 恢复原始数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_huifu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要恢复原始数据吗?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                //list_key = list_key_yuan;
                list_key.Clear();
                list_key.AddRange(list_key_yuan);
                dgv1.DataBindings.Clear();
                dgv1.DataSource = null;
                dgv1.DataSource = list_key.ToDataTable();
                dgv1.Refresh();
            }
        }
        #endregion

        #region btn_save_Click
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txt_keysname.Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("请输入词库名称");
                    return;
                }


                keys_lexicon kl = new keys_lexicon();

                if (ckid == 0)
                {
                    kl.kldate = DateTime.Now;
                    kl.klname = name;
                    kl.klsort = 100;
                    kl.klstate = "1";
                    keys temp_k = list_key[0];
                    kl.klremark = "共" + list_key.Count + "条数据,第一条数据为：【关键词：" + temp_k.kname + "，人气指数：" + temp_k.kSSzhanbi.ToString() + "，商品数量：" + temp_k.kgoodsnum.ToString() + "，点击率：" + temp_k.kdianjilv.ToString() + "，转化率：" + temp_k.kzhuanhualv.ToString() + "】";

                    BLL2.keys_lexiconManager.Insert(kl);

                    IList<keys_lexicon> list = BLL2.keys_lexiconManager.Search(1, 100, name, "", new DateTime(), new DateTime(), "");
                    if (list.Count > 0)
                    {
                        kl = list[0];
                        ckid = kl.klid;
                    }
                    else
                    {
                        MessageBox.Show("保存词库失败：词库信息没有找到");
                        return;
                    }
                }

                BLL2.keysManager.DeleteByKLID(ckid);

                foreach (keys k in list_key)
                {
                    k.klid = ckid;
                    k.kdate = DateTime.Now;
                    BLL2.keysManager.Insert(k);
                }
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据失败" + ex.ToString());
            }
        }
        #endregion


        private void btn_test22_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectedTab = tabPage2;
            if (isfirst)
            {
                MessageBox.Show("第一次");
            }
            else
            {
                MessageBox.Show("第2次");
            }
        }

        #region dgv2_CellContentClick
        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv2.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
                {
                    string tempid = ((DataRowView)dgv2.CurrentRow.DataBoundItem)[0].ToString();
                    int idd = 0;
                    //如果是打开
                    if (e.ColumnIndex == 1)
                    {
                        //keys_lexicon kl = (Entity.keys_lexicon)dgv2.CurrentRow.DataBoundItem;
                        if (int.TryParse(tempid, out idd))
                        {

                            list_key = (List<keys>)BLL2.keysManager.Search(1, 9999, "", "", idd, new DateTime(), new DateTime(), "");
                            dgv1.DataSource = list_key.ToDataTable();
                            tabControl1.SelectedTab = tabPage2;
                            list_key_yuan.Clear();
                            list_key_yuan.AddRange(list_key);
                            txt_keysname.Text = ((DataRowView)dgv2.CurrentRow.DataBoundItem)[1].ToString();
                        }
                    }
                    else if (e.ColumnIndex == 6)
                    {
                        //keys_lexicon kl = (Entity.keys_lexicon)dgv2.CurrentRow.DataBoundItem;
                        if (int.TryParse(tempid, out idd))
                        {
                            if (MessageBox.Show("确定要删除么?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                BLL2.keysManager.DeleteByKLID(idd);
                                BLL2.keys_lexiconManager.Delete(idd);
                                bind_ciku();
                                MessageBox.Show("删除成功");
                            }
                        }
                    }
                }
                else if (e.RowIndex == -1)
                {
                    //如果是全选
                    if (e.ColumnIndex == 0)
                    {
                        foreach (DataGridViewRow row in dgv2.Rows)
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
                            dgv2.Sort(dgv2.Columns[e.ColumnIndex], ListSortDirection.Descending);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("排序出错=========================" + ex.Message);
                        }
                    }
                }
            }
            catch { }
        }
        #endregion

        #region dgv2_RowPostPaint
        private void dgv2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv2.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 10);
        }
        #endregion

        #region btn_ciku_search_Click
        private void btn_ciku_search_Click(object sender, EventArgs e)
        {
            string key = txt_ciku_key.Text.Trim();
            List<keys_lexicon> list = (List<keys_lexicon>)BLL2.keys_lexiconManager.Search(1, 1000, key, "", new DateTime(), new DateTime(), "");
            dgv2.DataSource = list.ToDataTable();
            //dgv2.DataSource = new BindingCollection1<keys_lexicon>(list);
        }
        #endregion

        #region btn_ciku_del_Click
        private void btn_ciku_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要删除所有勾选关键词词库?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dgv2.Rows)
                {
                    if (row.Index != -1)
                    {
                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                        if ((bool)cbx.FormattedValue)
                        {
                            string temp_1 = ((DataRowView)row.DataBoundItem)[1].ToString();
                            int temp_id = 0;
                            //keys_lexicon kl = (Entity.keys_lexicon)row.DataBoundItem;
                            //if (kl != null)
                            if (int.TryParse(temp_1, out temp_id))
                            {
                                BLL2.keysManager.DeleteByKLID(temp_id);
                                BLL2.keys_lexiconManager.Delete(temp_id);
                                bind_ciku();
                                MessageBox.Show("删除成功");

                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region btn_openmore_Click
        /// <summary>
        /// 打开多个词库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_openmore_Click(object sender, EventArgs e)
        {
            List<int> res_list = new List<int>();
            foreach (DataGridViewRow row in dgv2.Rows)
            {
                if (row.Index != -1)
                {
                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                    if ((bool)cbx.FormattedValue)
                    {
                        string temp_1 = ((DataRowView)row.DataBoundItem)[0].ToString();
                        int temp_id = 0;
                        if (int.TryParse(temp_1, out temp_id))
                        {
                            res_list.Add(temp_id);
                        }
                    }
                }
            }

            list_key = (List<keys>)BLL2.keysManager.SearchByKlids(res_list);
            dgv1.DataSource = list_key.ToDataTable();
            tabControl1.SelectedTab = tabPage2;
            list_key_yuan.Clear();
            list_key_yuan.AddRange(list_key);

        }
        #endregion

        #region btn_zhitongche_Click

        private void btn_zhitongche_Click(object sender, EventArgs e)
        {
            this.dgv1.Sort(this.col_renqi, ListSortDirection.Descending);
        }
        #endregion

        #region btn_search_Click
        /// <summary>
        /// 搜索关键词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click(object sender, EventArgs e)
        {

            tabControl1.SelectedTab = tabPage1;
            txt_key.Text = txt_searchkey.Text;


            ckid = 0;

            CaiJi_Data();

            dgv1.DataSource = list_key.ToDataTable();
            list_key_yuan.Clear();
            list_key_yuan.AddRange(list_key);
            //list_key_yuan = list_key;
            //数据采集完毕
            tabControl1.SelectedTab = tabPage2;
            MessageBox.Show("采集成功");
            CaiJi_IsFirst();//采集完后设置已经采集了一次
        }
        #endregion

        #region dgv1_CellFormatting
        private void dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (dgv1.DataSource != null)
                {

                    //if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_jignzheng"))
                    //{
                    //    decimal temp_renqi = Convert.ToDecimal(dgv1.Rows[e.RowIndex].Cells[2].Value);
                    //    decimal temp_num = Convert.ToDecimal(dgv1.Rows[e.RowIndex].Cells[6].Value);
                    //    e.Value = (temp_renqi / temp_num * 1000).ToString("00.00");
                    //}
                }
            }
            catch  
            {
                //Debug.WriteLine("======================================================================");
                //Debug.WriteLine(DateTime.Now.ToString());
                //Debug.WriteLine("信息绑定失败：" + ex.Message);
            }

        }

        #endregion

        #region btn_zhijiecaiji_Click
        private void btn_zhijiecaiji_Click(object sender, EventArgs e)
        {
            zhijiecaiji();
        }
        #endregion


        /// <summary>
        /// 标题关键词处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_jisuan_Click(object sender, EventArgs e)
        {
            string temp = txt_key_biaoti.Text;
            if (string.IsNullOrEmpty(temp))
            {
                MessageBox.Show("请输入要计算的标题关键词");
                return;
            }
            List<string> list = Manager.StrToList(temp);
            if (list.Count == 0)
            {
                MessageBox.Show("请输入计算的标题关键词");
                return;
            }


            //int doubleorder = 0;
            //分析结果
            List<keyss> list_res = new List<keyss>();

            foreach (string str in list)
            {
                if (string.IsNullOrEmpty(str))
                    break;
                List<string> list_char = Manager.StrOneToList(str.Replace(" ", ""));
                foreach (string c in list_char)
                {
                    //实例化每个字符
                    keyss temp_key = new keyss();
                    temp_key.Kname = c;
                    temp_key.Knum = 1;

                    ///如果是第一次添加字符，则直接添加
                    if (list_res.Count == 0)
                    {
                        list_res.Add(temp_key);
                    }
                    else
                    {
                        //如果是有数据
                        List<keyss> list_res2 = list_res;
                        list_res = new List<keyss>();


                        bool ishas = false;

                        //判断结果里面有没有这个字符
                        foreach (keyss k in list_res2)
                        {
                            //对比数据
                            if (k.Kname == c)
                            {
                                //如果已经存在则+1
                                k.Knum = k.Knum + 1;

                                //设置已经存在
                                ishas = true;
                            }
                            //添加
                            list_res.Add(k);
                        }
                        //如果没有对比到数据=》添加
                        if (!ishas)
                        {
                            list_res.Add(temp_key);
                        }

                    }
                }

            }

            //排序
            list_res.Sort(delegate (keyss k1, keyss k2) { return k2.Knum.CompareTo(k1.Knum); });

            dgv_key_biaoti.DataSource = list_res;

            //if (doubleorder > 0)
            //{
            //    MessageBox.Show("共 " + doubleorder.ToString() + " 个账号多次下单，请留意");
            //}
            MessageBox.Show("成功添加共 " + list_res.Count.ToString() + " 条记录");
        }

        #region 行号


        private void dgv_key_biaoti_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv_key_biaoti.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv_key_biaoti.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 10);
        }

        #endregion

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btn_searchkey_Click(object sender, EventArgs e)
        {
            string keys = txt_searchkey_key.Text;
            string num = txt_searchkey_pagenum.Text;
            int temp_num = 3;
            int.TryParse(num, out temp_num);
            if (string.IsNullOrEmpty(keys))
            {
                MessageBox.Show("请输入要查询的关键词");
                txt_searchkey_key.Focus();
                return;
            }
            tabControl1.SelectedTab = tabPage1;
            webBrowser1.Load("https://s.taobao.com/search?q=" + keys+ "&sort=sale-desc");
            if (Browser.WaitWebPageLoad("document.getElementsByClassName('title')[6]", webBrowser1))
            {
                //采集第一页
                int pagenum = 1;
                while (true)
                {
                    //获取商品数量
                    int count = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('title').length", webBrowser1);
                    //开始采集信息
                    for (int i = 6; i < count; i++)
                    {
                        string titles = Browser.JS_CEFBrowser("document.getElementsByClassName('title')[" + i.ToString() + "].innerText", webBrowser1);
                        txt_key_biaoti.Text += titles + "\r\n";
                        //txt_searchkey.Text += titles + "\r\n";
                    }
                    //判断是否继续采集，如果采集完成则跳出
                    if (pagenum == temp_num)
                    {
                        MessageBox.Show("采集完成");
                        tabControl1.SelectedTab = tabPage4;
                        return;
                    }
                    else
                    {
                        //点击下一页继续采集
                        Browser.JS_CEFBrowser("document.getElementsByClassName('wraper')[1].getElementsByTagName('a')[document.getElementsByClassName('wraper')[1].getElementsByTagName('a').length-1].click()",webBrowser1);
                        Browser.WaitWebPageLoad("document.getElementsByClassName('title')[6]", webBrowser1);
                        Browser.Delay(1500);
                    }
                    pagenum++;
                }
                
            }
        }
    }



    #region 关键词处理临时表2018年8月12日15


    /// <summary>
    /// 关键词处理临时表2018年8月12日15:54:08
    /// </summary>
    public class keyss
    {
        /// <summary>
        /// 关键词名称
        /// </summary>
        private string kname;
        /// <summary>
        /// 关键词数量
        /// </summary>
        private int knum;

        /// <summary>
        /// 关键词名称
        /// </summary>
        public string Kname
        {
            get
            {
                return kname;
            }

            set
            {
                kname = value;
            }
        }
        /// <summary>
        /// 关键词数量
        /// </summary>
        public int Knum
        {
            get
            {
                return knum;
            }

            set
            {
                knum = value;
            }
        }
    }
    #endregion


}


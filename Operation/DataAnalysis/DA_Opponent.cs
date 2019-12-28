using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;
using BLL2;
using System.Diagnostics;
using Operation.CS;
//using Operation.CS;
using Common;

namespace Operation.DataAnalysis
{
    public partial class DA_Opponent : Form
    {
        public DA_Opponent()
        {
            InitializeComponent();

            //Manager.AnimateWindow(this.Handle, 2000, Manager.AW_SLIDE | Manager.AW_ACTIVE | Manager.AW_VER_NEGATIVE);
            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1.ScriptErrorsSuppressed = true;
            //绑定数据后不会自动创建列
            dgv1.AutoGenerateColumns = false;
            //不显示空白行
            dgv1.AllowUserToAddRows = false;
            bind();
            bind_dianpu();
            //Browser.ClearData();
        }

        #region btn_caiji1_Click
        private void btn_caiji1_Click(object sender, EventArgs e)
        {
            GC.Collect();
            dgv1.Rows.Clear();
            string str = txt_key.Text.Trim();


            //判断是否已经选择采集店铺
            string temp_dp = cb_dianpu.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(temp_dp))
            {
                IList<opponent_dianpu> temp_listdp2 = BLL2.opponent_dianpuManager.Search(1, 100, temp_dp, "");
                if (temp_listdp2.Count > 0)
                {
                    str = temp_listdp2[0].odwangwang;
                }
            }



            //str = "https://item.taobao.com/item.htm?spm=a1z10.3-c-s.w4002-14460596614.23.XM7KUF&id=540733715384";//sunny家网址
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("请输入要分析的店铺");
                return;
                //str = "miss原创定制";
            }
            //判断是否是网址
            int temp_isurl = str.IndexOf("http");
            string id = Manager.GetValueByURL(str, "id");
            string datenow = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分");

            //如果是网址
            if (temp_isurl > -1 && !string.IsNullOrEmpty(id))
            {
                //string url = Manager.GetDPurlByWangwang(str);
                Browser.urlstr = str;
                webBrowser1.Navigate(Browser.urlstr);
                //判断是否加载完成
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    try
                    {
                        if (webBrowser1.Document != null)
                        {
                            //判断是否是邮费链接
                            HtmlElementCollection elem1 = webBrowser1.Document.GetElementById("attributes").GetElementsByTagName("ul")[0].GetElementsByTagName("li");

                            if (elem1.Count > 0)
                            {
                                //string datenow = DateTime.Now.ToString("yyyy年MM月dd日HH时mm分");
                                //先采集商品
                                opponent_goods og = CaiJi.CaijiGoods(datenow, webBrowser1);
                                List<opponent_goods> list = new List<opponent_goods>();
                                if (og != null)
                                {
                                    list.Add(og);
                                    dgv1.DataSource = Manager.BindingSort_opponent_goods(list);
                                    //再采集店铺信息，需要跳转页面
                                    Entity.opponent_dianpu dp = CaiJi.CaijiDP(datenow, webBrowser1);
                                    BLL2.opponent_dianpuManager.Insert(dp);

                                    opponent_dianpu_info dpinfo = CaiJi.CaijiDPSDR(datenow, webBrowser1);
                                    dpinfo = bind_dianpu_info(list, dpinfo);
                                    BLL2.opponent_dianpu_infoManager.Insert(dpinfo);

                                    BLL2.opponent_goodsManager.Insert(og);
                                    GC.Collect();//释放内存
                                }
                            }
                            else
                            {
                                Debug.WriteLine("======================================================================");
                                Debug.WriteLine("网址：" + Browser.urlstr);
                                Debug.WriteLine("该商品可能是 邮费链接 ");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("采集信息失败：" + ex.Message);
                        Debug.WriteLine("======================================================================");
                        Debug.WriteLine("网址：" + Browser.urlstr);
                        Debug.WriteLine(DateTime.Now.ToString());
                        Debug.WriteLine("单品采集信息失败：" + ex.Message);
                    }
                }


            }
            else
            {


                //如果不是网址
                string url = CaiJi.GetShopSearchURL(str);
                url = Browser.UrlEncode(url, Encoding.UTF8);
                //Debug.WriteLine(url);
                //跳转到搜索店铺页面
                Browser.urlstr = url;
                webBrowser1.Navigate(Browser.urlstr);
                //判断是否加载完成
                if (Browser.WaitWebPageLoad(webBrowser1))
                {
                    try
                    {
                        if (webBrowser1.Document != null)
                        {
                            string url_shop = CaiJi.GetShopUrlByWangWang(str, webBrowser1);
                            //如果没有找到店铺网址，或者没有开店信息
                            if (string.IsNullOrEmpty(url_shop))
                            {
                                Debug.WriteLine("采集店铺时，没有找到店铺网址，或者没有开店信息");
                                MessageBox.Show("没有采集到该店铺信息");
                                return;
                            }
                            List<string> list_url = new List<string>();
                            List<opponent_goods> list_goods = new List<opponent_goods>();

                            //默认查询20页
                            for (int i = 0; i < 20; i++)
                            {

                                string url_goodslist = CaiJi.GetShopGoodsListURL(url_shop, i + 1);
                                Browser.urlstr = url_goodslist;
                                //跳转到商品列表页面
                                webBrowser1.Navigate(Browser.urlstr);
                                //break;
                                //判断是否加载完成
                                if (Browser.WaitWebPageLoad(webBrowser1))
                                {
                                    if (webBrowser1.Document != null)
                                    {
                                        //判断是否还有商品
                                        Browser.jsstr = "  getClassName('no-result-new').length;  ";
                                        if (Browser.JS_WebBrowser(webBrowser1) == "1")
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            //================
                                            //list_url = CaiJi.GetGoodsUrlList(webBrowser1);
                                            //获取本页面商品网址List
                                            List<string> temp_list_url = CaiJi.GetGoodsUrlList(webBrowser1);
                                            Debug.WriteLine("获取本页面商品网址List" + temp_list_url.Count.ToString());
                                            if (temp_list_url.Count > 0)
                                            {
                                                foreach (string temp_url1 in temp_list_url)
                                                {
                                                    Browser.urlstr = temp_url1;
                                                    //跳转到商品页面
                                                    webBrowser1.Navigate(Browser.urlstr);
                                                    if (Browser.WaitWebPageLoad(webBrowser1))
                                                    {
                                                        if (webBrowser1.Document != null)
                                                        {
                                                            //判断是否是邮费链接
                                                            HtmlElementCollection elem1 = webBrowser1.Document.GetElementById("attributes").GetElementsByTagName("ul")[0].GetElementsByTagName("li");

                                                            if (elem1.Count > 0)
                                                            {
                                                                opponent_goods og = CaiJi.CaijiGoods(datenow, webBrowser1);
                                                                if (og != null)
                                                                {
                                                                    list_goods.Add(og);
                                                                    dgv1.DataSource = Manager.BindingSort_opponent_goods(list_goods);
                                                                    BLL2.opponent_goodsManager.Insert(og);
                                                                    Debug.WriteLine("添加商品：" + og.ogtittle);

                                                                    //绑定店铺信息
                                                                    opponent_dianpu_info dpinfo2 = new opponent_dianpu_info();
                                                                    dpinfo2 = bind_dianpu_info(list_goods, dpinfo2);

                                                                    GC.Collect();//释放内存
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Debug.WriteLine("======================================================================");
                                                                Debug.WriteLine("网址：" + Browser.urlstr);
                                                                Debug.WriteLine("该商品可能是 邮费链接 ");
                                                            }

                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            dgv1.DataSource = Manager.BindingSort_opponent_goods(list_goods);

                            //在本页获取店铺信息
                            opponent_dianpu dp = CaiJi.CaijiDP(datenow, webBrowser1);
                            //在本页获取店铺信息
                            opponent_dianpu_info dpinfo = CaiJi.CaijiDPSDR(datenow, webBrowser1);
                            //从商品列表获取店铺信息

                            dpinfo = bind_dianpu_info(list_goods, dpinfo);


                            BLL2.opponent_dianpu_infoManager.Insert(dpinfo);
                            BLL2.opponent_dianpuManager.Insert(dp);


                            GC.Collect();//释放内存
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("======================================================================");
                        Debug.WriteLine("网址：" + Browser.urlstr);
                        Debug.WriteLine(DateTime.Now.ToString());
                        Debug.WriteLine("全店采集信息失败：" + ex.Message);
                        MessageBox.Show("全店采集信息失败：" + ex.Message);
                    }
                }

            }

            bind_dianpu();
            MessageBox.Show("采集完成");

        }
        #endregion

        #region dgv1_CellFormatting
        private void dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value != null)
                {
                    if (dgv1.DataSource != null)
                    {
                        if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_img"))
                        {

                            string name = e.Value.ToString();
                            string path = Application.StartupPath + "\\" + "Image" + "\\" + name;
                            e.Value = Manager.GetImage(path);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================================");
                Debug.WriteLine("网址：" + Browser.urlstr);
                Debug.WriteLine(DateTime.Now.ToString());
                Debug.WriteLine("信息绑定失败：" + ex.Message);
            }
        }
        #endregion

        #region bind

        void bind()
        {
            try
            {
                opponent_dianpu dp = BLL2.opponent_dianpuManager.SearchLastOne();

                if (dp != null)
                {
                    IList<opponent_dianpu_info> list = BLL2.opponent_dianpu_infoManager.Search(1, 100, "", "", dp.odcollectdate, "");
                    if (list.Count > 0)
                    {
                        bind_dianpu_info(list[0]);
                    }
                    IList<opponent_goods> list2 = BLL2.opponent_goodsManager.Search(1, 9999, "", "", "", dp.odcollectdate, "");
                    dgv1.DataSource = Manager.BindingSort_opponent_goods(list2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("绑定失败" + ex.Message);
            }

        }

        void bind_dianpu_info(opponent_dianpu_info di)
        {
            if (di != null)
            {
                lbl_caijidate.Text = di.ocollectdate;
                lbl_dongxiao.Text = di.odidongxiao;
                lbl_dpsales.Text = di.odisalescount;
                lbl_dpsell.Text = di.odisellcount;
                lbl_goodsnum.Text = di.odigoodsnum == 0 ? "0" : di.odigoodsnum.ToString();
                lbl_miaoshu.Text = di.odiDSRmiaoshu;
                lbl_zhiliang.Text = di.odiDSRzhiliang;
                lbl_wuliu.Text = di.odiDSRwuliu;
                lbl_pricedi.Text = di.odipricelowset;
                lbl_pricegao.Text = di.odipricehigh;
                lbl_pricepingjun.Text = di.odipriceaverage;
                lbl_salesdi.Text = di.odiselllowset;
                lbl_salesgao.Text = di.odisellhigh;
                lbl_salespingjun.Text = di.odisellaverage;
                lbl_sell0.Text = di.odisell0 == 0 ? "0" : di.odisell0.ToString();
                lbl_skunum.Text = di.odiSKUcount;
                lbl_baozhengjin.Text = di.odibaozhangjin;
                lbl_shopid.Text = di.oshopid;
            }
        }

        void bind_dianpu()
        {
            IList<opponent_dianpu> list = BLL2.opponent_dianpuManager.SearchAll();
            //cb_dianpu.DataSource = list;
            opponent_dianpu dp = new opponent_dianpu();
            dp.odpname = "请选择";
            dp.odTBID = "";
            dp.oid = 0;
            list.Insert(0, dp);
            cb_dianpu.DataSource = list;
        }

        opponent_dianpu_info bind_dianpu_info(List<opponent_goods> list, opponent_dianpu_info info)
        {
            opponent_dianpu_info dpinfo = new opponent_dianpu_info();

            try
            {

                int sell0 = 0;
                decimal priceCount = 0;//总价格
                decimal priceHigh = 0;//最高价格
                decimal priceLowset = 99999;//最低价格
                decimal salesCount = 0;//成交总额
                int sellCount = 0;//总销量
                int sellHigh = 0;//最高销量
                int sellLowset = 99999;//最低销量
                int SKUCount = 0;//SKU总数
                int goodsCount = list.Count;//商品总数


                foreach (opponent_goods og in list)
                {
                    if (og != null)
                    {
                        int temp = 0;
                        decimal temp1 = 0;

                        if (og.ogsales == "0" || string.IsNullOrEmpty(og.ogsales))
                        {
                            sell0++;
                        }
                        if (Decimal.TryParse(og.ogprice2, out temp1))
                        {
                            priceCount = priceCount + temp1;
                            if (priceHigh < temp1)
                            {
                                priceHigh = temp1;
                            }
                            if (priceLowset > temp1)
                            {
                                priceLowset = temp1;
                            }
                        }
                        if (int.TryParse(og.ogsales, out temp))
                        {
                            try
                            {
                                string temp_price = og.ogprice2;
                                if (temp_price.IndexOf("-") > -1)
                                {
                                    temp_price = temp_price.Split(new char[] { '-' })[0];
                                }

                                salesCount = salesCount + (Convert.ToDecimal(temp) * Convert.ToDecimal(temp_price));//
                                sellCount = sellCount + temp;
                                if (sellHigh < temp)
                                {
                                    sellHigh = temp;
                                }
                                if (sellLowset > temp)
                                {
                                    sellLowset = temp;
                                }
                            }
                            catch { }
                        }
                        if (int.TryParse(og.ogSKU, out temp))
                        {
                            SKUCount = SKUCount + temp;
                        }
                    }
                }

                dpinfo.odidongxiao = ((goodsCount - sell0) / goodsCount * 100).ToString();
                dpinfo.odigoodsnum = goodsCount;
                dpinfo.odipriceaverage = (priceCount / goodsCount).ToString();
                dpinfo.odipricehigh = priceHigh.ToString();
                dpinfo.odipricelowset = priceLowset.ToString();
                dpinfo.odisalescount = salesCount.ToString();
                dpinfo.odisell0 = sell0;
                dpinfo.odisellaverage = (sellCount / goodsCount).ToString();
                dpinfo.odisellcount = sellCount.ToString();
                dpinfo.odisellhigh = sellHigh.ToString();
                dpinfo.odiselllowset = sellLowset.ToString();
                dpinfo.odiSKUcount = SKUCount.ToString();

                dpinfo.odibaozhangjin = info.odibaozhangjin;
                dpinfo.odiDSRmiaoshu = info.odiDSRmiaoshu;
                dpinfo.odiDSRwuliu = info.odiDSRwuliu;
                dpinfo.odiDSRzhiliang = info.odiDSRzhiliang;
                dpinfo.ocollectdate = info.ocollectdate;
                dpinfo.oshopid = info.oshopid;

                bind_dianpu_info(dpinfo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("计算店铺信息报错：" + ex.Message);
            }
            return dpinfo;
        }

        #endregion

        #region AddRow

        void AddRow(opponent_goods goods)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell txt1 = new DataGridViewTextBoxCell();
                txt1.Value = goods.ogTBid;
                row.Cells.Add(txt1);
                DataGridViewImageCell img1 = new DataGridViewImageCell();
                img1.Value = goods.ogimg;
                row.Cells.Add(img1);
                DataGridViewTextBoxCell txt2 = new DataGridViewTextBoxCell();
                txt2.Value = goods.ogtittle;
                row.Cells.Add(txt2);
                DataGridViewTextBoxCell txt3 = new DataGridViewTextBoxCell();
                txt3.Value = goods.ogsales;
                row.Cells.Add(txt3);
                DataGridViewTextBoxCell txt4 = new DataGridViewTextBoxCell();
                txt4.Value = goods.ogshoucang;
                row.Cells.Add(txt4);
                DataGridViewTextBoxCell txt5 = new DataGridViewTextBoxCell();
                txt5.Value = goods.ogxiaoliang;
                row.Cells.Add(txt5);
                DataGridViewTextBoxCell txt6 = new DataGridViewTextBoxCell();
                txt6.Value = goods.ogprice1;
                row.Cells.Add(txt6);
                DataGridViewTextBoxCell txt7 = new DataGridViewTextBoxCell();
                txt7.Value = goods.ogprice2;
                row.Cells.Add(txt7);
                DataGridViewTextBoxCell txt8 = new DataGridViewTextBoxCell();
                txt8.Value = Manager.GetZheKou(goods.ogprice1, goods.ogprice2).ToString();
                row.Cells.Add(txt8);
                DataGridViewTextBoxCell txt9 = new DataGridViewTextBoxCell();
                txt9.Value = goods.ogpostage;
                row.Cells.Add(txt9);
                DataGridViewTextBoxCell txt10 = new DataGridViewTextBoxCell();
                txt10.Value = goods.ogSKU;
                row.Cells.Add(txt10);
                DataGridViewTextBoxCell txt11 = new DataGridViewTextBoxCell();
                txt11.Value = goods.ocollectdate;
                row.Cells.Add(txt11);
                //DataGridViewComboBoxCell comboxcell = new DataGridViewComboBoxCell();
                //row.Cells.Add(comboxcell);
                dgv1.Rows.Add(row);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("======================================================================");
                Debug.WriteLine("网址：" + Browser.urlstr);
                Debug.WriteLine(DateTime.Now.ToString());
                Debug.WriteLine("全店采集信息失败：" + ex.Message);
                MessageBox.Show("全店采集信息失败：" + ex.Message);
            }
        }

        #endregion

        #region btn_lishi_Click
        private void btn_lishi_Click(object sender, EventArgs e)
        {
            string temp_shopid = cb_dianpu.SelectedValue.ToString();
            DateTime temp_date2 = new DateTime();
            DateTime.TryParse(date1.Text, out temp_date2);
            string temp_date = date1.Text == "请选择" ? "" : (temp_date2 == new DateTime() ? date1.Value.Date.ToString("yyyy年MM月dd日") : temp_date2.ToString("yyyy年MM月dd日"));
            string key = txt_key2.Text.Trim();

            IList<opponent_dianpu_info> list = BLL2.opponent_dianpu_infoManager.Search(1, 3, key, temp_shopid, temp_date, "");
            if (list.Count > 0)
            {
                bind_dianpu_info(list[0]);
            }
            IList<opponent_goods> list2 = BLL2.opponent_goodsManager.Search(1, 9999, key, temp_shopid, "", temp_date, "");
            dgv1.DataSource = Manager.BindingSort_opponent_goods(list2);

        }
        #endregion

        #region dgv1_DoubleClick
        private void dgv1_DoubleClick(object sender, EventArgs e)
        {

            Point hit = this.dgv1.PointToClient(Cursor.Position);
            DataGridView.HitTestInfo hitTest = this.dgv1.HitTest(hit.X, hit.Y);
            //MessageBox.Show(hitTest.Type + " Row=" + hitTest.RowIndex + " Col" + hitTest.ColumnIndex);
            //判断不是首行
            if (hitTest.RowIndex != -1)
            {
                int a = dgv1.CurrentRow.Index;
                opponent_goods og = (opponent_goods)dgv1.CurrentRow.DataBoundItem;
                if (og != null)
                {
                    Manager.OpenProgram(og.ogurl);
                }
                //string str = dgv1.Rows[a].Cells["strName"].Value.ToString();
            }


            //if (dgv1.FocusedRowHandle >= 0)
            //{

            //}
        }
        #endregion

        #region dgv1_CellContentClick
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //注释：

            //dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn 说明点击的列是DataGridViewButtonColumn列，当然你也根据e.ColumnIndex == 你的按钮列的索引来做
            // e.RowIndex > -1 ，说明点击的不是列头
            if (dgv1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                opponent_goods og = (opponent_goods)dgv1.CurrentRow.DataBoundItem;
                if (og != null)
                {
                    //BindingCollection<object> objList = new BindingCollection<object>();
                    //objList = 你的结果集;
                    //this.dataGridView1.DataSource = objList;

                    IList<opponent_goods> list = BLL2.opponent_goodsManager.Search(1, 99999, "", "", og.ogTBid, "", "");

                    dgv1.DataSource = Manager.BindingSort_opponent_goods(list);
                    //var bindingList = new BindingList<opponent_goods>();
                    //var source = new BindingSource(bindingList, null);
                    //dgv1.DataSource = source;
                    //dgv1.DataSource = 
                }

                //获取当前被点击的单元格 
                //DataGridViewButtonCell vCell = (DataGridViewButtonCell)dgv1.CurrentCell;
                //if (vCell.Tag == null)
                //{
                //    vCell.Value = "停用";
                //    vCell.Tag = true;
                //}
                //else
                //{
                //    vCell.Value = "停用1";
                //    vCell.Tag = null;
                //}

            }
            else if (e.RowIndex == -1)
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
        #endregion

        #region btn_chongzhi_Click
        private void btn_chongzhi_Click(object sender, EventArgs e)
        {
            date1.Format = DateTimePickerFormat.Custom;
            date1.CustomFormat = "请选择";
        }
        #endregion

        #region dgv1_RowPostPaint
        private void dgv1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 20);
        }
        #endregion

        #region cb_dianpu_SelectedIndexChanged
        private void cb_dianpu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Debug.WriteLine(cb_dianpu.SelectedIndex.ToString());
            //if (cb_dianpu.SelectedIndex == -1)
            //    return;
            //string temp = cb_dianpu.SelectedValue.ToString();
            //int id = 0;
            //if (int.TryParse(temp, out id))
            //{
            //    opponent_dianpu dp = BLL2.opponent_dianpuManager.SearchByID(id);
            //    if (dp != null)
            //    {
            //        IList<opponent_dianpu_info> list = BLL2.opponent_dianpu_infoManager.Search(1, 100, "", 0, dp.odcollectdate, "");
            //        if (list.Count > 0)
            //        {
            //            bind_dianpu_info(list[0]);
            //        }
            //        IList<opponent_goods> list2 = BLL2.opponent_goodsManager.Search(1, 9999, "", 0, "", dp.odcollectdate, "");
            //        dgv1.DataSource = Manager.BindingSort_opponent_goods(list2);
            //    }
            //}

        }
        #endregion

        #region  date1_CloseUp
        private void date1_CloseUp(object sender, EventArgs e)
        {
            (sender as DateTimePicker).Format = DateTimePickerFormat.Long;
        }


        #endregion

        #region  btn_jisuan_Click
        private void btn_jisuan_Click(object sender, EventArgs e)
        {
            List<opponent_goods> list = Manager.BindingSort_opponent_goods_ToList((BindingCollection<opponent_goods>)dgv1.DataSource);
            opponent_dianpu_info info = new opponent_dianpu_info();
            bind_dianpu_info(list, info);
        }
        #endregion

        #region btn_img_Click
        private void btn_img_Click(object sender, EventArgs e)
        {

            toolStripProgressBar1.Value = 0;


            BindingCollection<opponent_goods> list = (BindingCollection<opponent_goods>)dgv1.DataSource;
            //设置状态栏的最大值
            toolStripProgressBar1.Maximum = list.Count;
            //判断图片文件夹是否存在
            if (!System.IO.Directory.Exists(Manager.imgsite_duishou))
            {
                //新建图片文件夹
                System.IO.Directory.CreateDirectory(Manager.imgsite_duishou);
            }
            foreach (opponent_goods goods in list)
            {
                toolStripProgressBar1.PerformStep();

                if (!string.IsNullOrEmpty(goods.ogimg))
                {
                    //判断是否有该图片
                    if (!System.IO.File.Exists(Manager.imgsite_duishou + "\\" + goods.ogremark))
                    {
                        if (string.IsNullOrEmpty(goods.ogremark))
                        {
                            goods.ogremark = DateTime.Now.ToString("yyyyMMddhhmmss") + Manager.RandomNumber(111, 9999).ToString();
                            BLL2.opponent_goodsManager.Update(goods);
                        }
                        Manager.DownloadFile(goods.ogimg, Manager.imgsite_duishou, goods.ogremark, 5000);
                    }
                }
            }
            //设置状态栏全部完成
            while (toolStripProgressBar1.Value < toolStripProgressBar1.Maximum)
            {
                toolStripProgressBar1.PerformStep();//按照Step的值进行递增！
            }
            dgv1.DataBindings.Clear();
            dgv1.DataSource = list;
            MessageBox.Show("图片采集完成");

        }
        #endregion


    }
}

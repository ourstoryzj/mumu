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

namespace Operation.WangGong
{
    public partial class WG_Goods : Form
    {
        private DateTime DateCaiJi;

        public WG_Goods()
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

        }

        #region btn_caiji1_Click
        private void btn_caiji1_Click(object sender, EventArgs e)
        {
            //Browser.ClearData();
            CaiJiWG();
            MessageBox.Show("采集完成");
        }
        #endregion

        #region dgv1_CellFormatting
        /// <summary>
        /// 动态显示单元格的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                            string path = Manager.imgsite_wanggong + "\\" + name;
                            e.Value = Manager.GetImage(path);
                            //(sender as DataGridViewImageColumn).ImageLayout
                        }
                        if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_wgname"))
                        {
                            string wid = e.Value.ToString();
                            IList<wanggong_dianpu> list = Manager.List_dianpu;
                            //string wid = dgv1.Rows[e.RowIndex].Cells[1].Value == null ? "" : dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                            int temp = 0;
                            if (int.TryParse(wid, out temp))
                            {
                                foreach (wanggong_dianpu dp in list)
                                {
                                    if (dp.wid == temp)
                                    {
                                        e.Value = dp.wdpname;
                                    }
                                }
                            }
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
            //try
            //{
            //    wanggong_dianpu dp = BLL2.wanggong_dianpuManager.SearchLastOne();

            //    if (dp != null)
            //    {

            //        IList<wanggong_goods> list2 = BLL2.wanggong_goodsManager.Search(1, 9999, "", "", "", dp.odcollectdate, "");
            //        dgv1.DataSource = Manager.BindingSort_wanggong_goods(list2);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("绑定失败" + ex.Message);
            //}

        }



        void bind_dianpu()
        {
            IList<wanggong_dianpu> list = BLL2.wanggong_dianpuManager.SearchAll();
            //cb_dianpu.DataSource = list;
            wanggong_dianpu dp = new wanggong_dianpu();
            dp.wdpname = "请选择";
            dp.wdTBID = "";
            dp.wid = 0;
            list.Insert(0, dp);
            cb_dianpu.DataSource = list;
            cb_dianpu.DisplayMember = "wdpname";//绑定泛型中类的属性
            cb_dianpu.ValueMember = "wid";
        }

        #endregion

        #region AddRow
        /*
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
        */
        #endregion

        #region btn_lishi_Click
        private void btn_lishi_Click(object sender, EventArgs e)
        {
            string temp_shopid = cb_dianpu.SelectedValue.ToString();
            DateTime temp_date = new DateTime();
            DateTime.TryParse(date1.Text, out temp_date);
            //DateTime temp_date = date1.Text == "请选择" ? new DateTime() : (temp_date2 == new DateTime() ? date1.Value.Date : temp_date2);
            string key = txt_key2.Text.Trim();
            int wid = 0;
            int.TryParse(temp_shopid, out wid);

            //IList<opponent_dianpu_info> list = BLL2.
            //.Search(1, 3, key, temp_shopid, temp_date, "");
            //if (list.Count > 0)
            //{
            //    bind_dianpu_info(list[0]);
            //}
            IList<wanggong_goods> list2 = BLL2.wanggong_goodsManager.Search(1, 9999, key, wid, temp_date, temp_date, "");
            dgv1.DataSource = Manager.BindingSort_wanggong_goods(list2);

        }
        #endregion

        #region dgv1_DoubleClick
        //双击打开网址
        private void dgv1_DoubleClick(object sender, EventArgs e)
        {

            //Point hit = this.dgv1.PointToClient(Cursor.Position);
            //DataGridView.HitTestInfo hitTest = this.dgv1.HitTest(hit.X, hit.Y);
            //MessageBox.Show(hitTest.Type + " Row=" + hitTest.RowIndex + " Col" + hitTest.ColumnIndex);
            //判断不是首行
            //if (hitTest.RowIndex != -1)
            //{
            //    int a = dgv1.CurrentRow.Index;
            //    wanggong_goods og = (wanggong_goods)dgv1.CurrentRow.DataBoundItem;
            //    if (og != null)
            //    {
            //        Manager.OpenProgram(og.wgurl);
            //    }
            //    //string str = dgv1.Rows[a].Cells["strName"].Value.ToString();
            //}


            //if (dgv1.FocusedRowHandle >= 0)
            //{

            //}
        }
        #endregion

        #region dgv1_CellContentClick
        //排序和Button按钮事件
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //注释：
            if (dgv1.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                wanggong_goods og = (wanggong_goods)dgv1.CurrentRow.DataBoundItem;
                if (og != null)
                {
                    //IList<wanggong_goods> list = wanggong_goodsManager.Search(1, 99999, "", new DateTime(), new DateTime(), "");
                    //dgv1.DataSource = Manager.BindingSort_wanggong_goods(list);
                    Manager.OpenProgram(og.wgurl);
                }
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
        //添加行号
        private void dgv1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 20);
        }
        #endregion

        #region  date1_CloseUp
        //设置时间控件格式
        private void date1_CloseUp(object sender, EventArgs e)
        {

            (sender as DateTimePicker).Format = DateTimePickerFormat.Long;
        }
        #endregion

        #region btn_img_Click
        private void btn_img_Click(object sender, EventArgs e)
        {

            toolStripProgressBar1.Value = 0;


            Common.BindingCollection<wanggong_goods> list = (BindingCollection<wanggong_goods>)dgv1.DataSource;
            //设置状态栏的最大值
            toolStripProgressBar1.Maximum = list.Count;
            //判断图片文件夹是否存在
            if (!System.IO.Directory.Exists(Manager.imgsite_wanggong))
            {
                //新建图片文件夹
                System.IO.Directory.CreateDirectory(Manager.imgsite_wanggong);
            }
            foreach (wanggong_goods goods in list)
            {
                toolStripProgressBar1.PerformStep();

                if (!string.IsNullOrEmpty(goods.wgimg))
                {
                    //判断是否有该图片
                    if (!System.IO.File.Exists(Manager.imgsite_wanggong + "\\" + goods.wgremark))
                    {
                        if (string.IsNullOrEmpty(goods.wgremark))
                        {
                            goods.wgremark = DateTime.Now.ToString("yyyyMMddhhmmss") + Manager.RandomNumber(111, 9999).ToString();
                            BLL2.wanggong_goodsManager.Update(goods);
                        }
                        string imgurl = CaiJi.GetImgSizeByUrl(goods.wgimg, 150);
                        Manager.DownloadFile(imgurl, Manager.imgsite_wanggong, goods.wgremark, 5000);
                    }
                }
            }
            //设置状态栏全部完成
            toolStripProgressBar1.Value = list.Count;
            dgv1.DataBindings.Clear();
            dgv1.DataSource = Manager.BindingSort_wanggong_goods(list);
            MessageBox.Show("图片采集完成");

        }
        #endregion

        #region CaiJiWG
        /// <summary>
        /// 采集网供数据
        /// </summary>
        void CaiJiWG()
        {
            GC.Collect();
            dgv1.Rows.Clear();
            //设置采集时间
            DateCaiJi = DateTime.Now;
            //设置店铺ID
            int dpid = 0;
            string str = cb_dianpu.Text.Trim();
            string temp_shopid = cb_dianpu.SelectedValue == null ? "" : cb_dianpu.SelectedValue.ToString();
            //判断是否是网址
            int temp_isurl = str.IndexOf("http");
            //string id = Manager.GetValueByURL(str, "id");
            if (temp_isurl > -1 || str == "请选择")
            {
                MessageBox.Show("请输入正确的旺旺名称或者店铺名称");
                return;
            }
            //如果是选择下拉菜单中的店铺
            if (temp_shopid != "0")
            {
                if (int.TryParse(temp_shopid, out dpid))
                {
                    try
                    {
                        wanggong_dianpu temp_dp = BLL2.wanggong_dianpuManager.SearchByID(dpid);
                        //wanggong_dianpu temp_dp = BLL2.wanggong_dianpuManager.Search(1, 10, temp_shopid, "", new DateTime(), new DateTime(), "")[0];
                        str = temp_dp.wdwangwang;
                    }
                    catch
                    { }
                }
            }

            string pagenum = txt_page.Text.Trim();
            int page_temp = 0;
            if (!int.TryParse(pagenum, out page_temp))
            {
                MessageBox.Show("请输入正确的采集页数");
                return;
            }
            //设置进度条
            toolStripProgressBar1.Maximum = page_temp * 24;
            toolStripProgressBar1.Value = 0;
            //根据旺旺查询店铺ID
            string url = CaiJi.GetShopSearchURL(str);
            //url = Browser.UrlEncode(url, Encoding.UTF8);
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
                        List<wanggong_goods> list_goods = new List<wanggong_goods>();



                        //默认查询20页
                        for (int i = 0; i < page_temp; i++)
                        {

                            string url_goodslist = CaiJi.GetShopGoodsListURL_NewOn(url_shop, i + 1);
                            Browser.urlstr = url_goodslist;
                            //跳转到商品列表页面
                            webBrowser1.Navigate(Browser.urlstr);
                            //判断是否加载完成
                            if (Browser.WaitWebPageLoad(webBrowser1))
                            {
                                if (webBrowser1.Document != null)
                                {
                                    //设置店铺ID
                                    if (dpid == 0)
                                    {
                                        //在本页获取店铺信息
                                        wanggong_dianpu dp = CaiJi.SearchPage_DianPu(DateCaiJi, webBrowser1);
                                        BLL2.wanggong_dianpuManager.Insert(dp);
                                        IList<wanggong_dianpu> list_dianpu = BLL2.wanggong_dianpuManager.Search(1, 1, dp.wdTBID, "", DateCaiJi, DateCaiJi, "");
                                        if (list_dianpu.Count > 0)
                                        {
                                            dpid = list_dianpu[0].wid;
                                        }
                                        else
                                        {
                                            MessageBox.Show("采集失败，获取店铺信息失败");
                                            return;
                                        }
                                    }

                                    //判断是否还有商品
                                    Browser.jsstr = "  getClassName('no-result-new').length;  ";
                                    if (Browser.JS_WebBrowser(webBrowser1) == "1")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        //开始采集商品
                                        //List<Entity.wanggong_goods> list_wg = SearchPage_GetWangGongGoods(DateCaiJi, webBrowser1);

                                        #region
                                        //开始采集
                                        //List<wanggong_goods> list_wg = new List<wanggong_goods>();

                                        Browser.jsstr = " getClassName('photo').length; ";
                                        string res = Browser.JS_WebBrowser(webBrowser1);
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
                                            //遍历每个商品
                                            for (int j = 0; j < list_count1; j++)
                                            {
                                                //进度条+1
                                                toolStripProgressBar1.PerformStep();
                                                wanggong_goods wg = new wanggong_goods();
                                                string tbid = CaiJi.SearchPage_GetTBID(j, webBrowser1);
                                                IList<wanggong_goods> list_temp = BLL2.wanggong_goodsManager.Search(1, 10, tbid, 0, new DateTime(), new DateTime(), "");
                                                if (list_temp.Count > 0)
                                                {
                                                    wg = list_temp[0];
                                                }

                                                wg.wgcollectdate = DateCaiJi;
                                                wg.wgimg = CaiJi.SearchPage_GetImgUrl(j, webBrowser1);
                                                wg.wgprice2 = CaiJi.SearchPage_GetPrice(j, webBrowser1);
                                                wg.wgtittle = CaiJi.SearchPage_GetTitle(j, webBrowser1);
                                                wg.wgurl = CaiJi.SearchPage_GetGoodsUrl(j, webBrowser1);
                                                wg.wgxiaoliang = CaiJi.SearchPage_GetSales(j, webBrowser1);
                                                wg.wgTBid = CaiJi.SearchPage_GetTBID(j, webBrowser1);
                                                //下载图片

                                                string imgurl = CaiJi.GetImgSizeByUrl(wg.wgimg, 150);
                                                string imgname = !string.IsNullOrEmpty(wg.wgremark) ? wg.wgremark : DateTime.Now.ToString("yyyyMMddhhmmss") + Manager.RandomNumber(1000, 99999).ToString() + ".jpg";
                                                Manager.DownloadFile(imgurl, Manager.imgsite_wanggong, imgname, 1000);
                                                wg.wgremark = imgname;

                                                list_goods.Add(wg);
                                                dgv1.DataSource = Manager.BindingSort_wanggong_goods(list_goods);
                                            }

                                        }


                                        #endregion


                                    }
                                }
                            }
                        }
                        foreach (wanggong_goods wg in list_goods)
                        {
                            wg.wid = dpid;
                            //把每个采集到的商品添加到数据库
                            BLL2.wanggong_goodsManager.Insert(wg);
                            //dgv1.DataSource = Manager.BindingSort_wanggong_goods(list_goods);
                        }
                        dgv1.DataSource = Manager.BindingSort_wanggong_goods(list_goods);
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
            toolStripProgressBar1.Value = page_temp * 24;
            bind_dianpu();

        }

        #endregion

        #region 根据店铺商品搜索页面获取商品基本信息
        /// <summary>
        /// 根据店铺商品搜索页面获取商品基本信息
        /// </summary>
        /// <param name="DateCaiJi">采集时间</param>
        /// <param name="webBrowser1">浏览器</param>
        /// <returns>List<Entity.wanggong_goods></returns>
        List<Entity.wanggong_goods> SearchPage_GetWangGongGoods(DateTime DateCaiJi, WebBrowser webBrowser1)
        {
            List<wanggong_goods> list = new List<wanggong_goods>();

            Browser.jsstr = " getClassName('photo').length; ";
            string res = Browser.JS_WebBrowser(webBrowser1);
            Debug.WriteLine("本页面商品数量为：" + res);//输出
            int list_count1 = 0;
            //如果没有商品，则返回空
            if (!int.TryParse(res, out list_count1))
            {
                Debug.WriteLine("没有获取到商品");//输出
                return list;
            }
            else
            {
                //遍历每个商品
                for (int i = 0; i < list_count1; i++)
                {
                    //进度条+1
                    toolStripProgressBar1.PerformStep();
                    wanggong_goods wg = new wanggong_goods();
                    string tbid = CaiJi.SearchPage_GetTBID(i, webBrowser1);
                    IList<wanggong_goods> list_temp = BLL2.wanggong_goodsManager.Search(1, 10, tbid, 0, new DateTime(), new DateTime(), "");
                    if (list_temp.Count > 0)
                    {
                        wg = list_temp[0];
                    }

                    wg.wgcollectdate = DateCaiJi;
                    wg.wgimg = CaiJi.SearchPage_GetImgUrl(i, webBrowser1);
                    wg.wgprice2 = CaiJi.SearchPage_GetPrice(i, webBrowser1);
                    wg.wgtittle = CaiJi.SearchPage_GetTitle(i, webBrowser1);
                    wg.wgurl = CaiJi.SearchPage_GetGoodsUrl(i, webBrowser1);
                    wg.wgxiaoliang = CaiJi.SearchPage_GetSales(i, webBrowser1);
                    wg.wgTBid = CaiJi.SearchPage_GetTBID(i, webBrowser1);
                    //下载图片

                    string imgurl = CaiJi.GetImgSizeByUrl(wg.wgimg, 150);
                    string imgname = !string.IsNullOrEmpty(wg.wgremark) ? wg.wgremark : DateTime.Now.ToString("yyyyMMddhhmmss") + Manager.RandomNumber(1000, 99999).ToString() + ".jpg";
                    Manager.DownloadFile(imgurl, Manager.imgsite_wanggong, imgname, 1000);
                    wg.wgremark = imgname;

                    list.Add(wg);
                    dgv1.DataSource = Manager.BindingSort_wanggong_goods(list);
                }

            }

            return list;

        }

        #endregion

        #region dgv1_CellParsing
        /// <summary>
        /// 数据修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

            try
            {
                if (dgv1.CurrentCell.ColumnIndex == 4 || dgv1.CurrentCell.ColumnIndex == 6)
                {
                    wanggong_goods og = (wanggong_goods)dgv1.CurrentRow.DataBoundItem;
                    if (og != null)
                    {
                        //状态
                        toolStripProgressBar1.Maximum = 4;
                        //状态
                        toolStripProgressBar1.Value = 1;

                        //IList<wanggong_goods> list = wanggong_goodsManager.Search(1, 99999, "", new DateTime(), new DateTime(), "");

                        //状态
                        toolStripProgressBar1.Value = 2;

                        string remark1 = dgv1.Rows[e.RowIndex].Cells[6].EditedFormattedValue == null ? "" : dgv1.Rows[e.RowIndex].Cells[6].EditedFormattedValue.ToString();
                        string remark2 = dgv1.Rows[e.RowIndex].Cells[4].EditedFormattedValue == null ? "" : dgv1.Rows[e.RowIndex].Cells[4].EditedFormattedValue.ToString();
                        og.wgremark1 = remark1;
                        og.wgremark2 = remark2;
                        //状态
                        toolStripProgressBar1.Value = 3;
                        BLL2.wanggong_goodsManager.Update(og);

                        //状态
                        toolStripProgressBar1.Value = 4;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("修改信息失败 " + ex.Message);
            }

        }
        #endregion

        #region btn_all_Click
        private void btn_all_Click(object sender, EventArgs e)
        {
            //Browser.ClearData();
            IList<wanggong_dianpu> list = BLL2.wanggong_dianpuManager.Search(1, 100, "", "1", new DateTime(), new DateTime(), "");
            foreach (wanggong_dianpu wd in list)
            {
                cb_dianpu.SelectedValue = wd.wid;
                CaiJiWG();
            }
            MessageBox.Show("采集完成");
        }
        #endregion

    }
}

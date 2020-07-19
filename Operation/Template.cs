using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using Operation.Other;
using Operation.CS;
using System.IO;
using System.Diagnostics;

namespace Operation
{
    public partial class Template : Form
    {
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        //CefSharp.WinForms.ChromiumWebBrowser webBrowser2;


        /// <summary>
        /// 全选开关
        /// </summary>
        int allselect = 0;


        public Template()
        {
            //Login tb = new Login();
            //tb.Show();
            //if (Manager.WaitLogin(tb))
            //{
            //tb.Hide();
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("http://www.taobao.com");
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
            //tabPage3.Controls.Add(webBrowser2);



            //}

            //绑定数据后不会自动创建列
            dgv1.AutoGenerateColumns = false;
            //不显示空白行
            dgv1.AllowUserToAddRows = false;

        }

        #region bind

        void bind()
        {

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

        #region btn_chushouzhong_Click
        private void btn_chushouzhong_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://sell.taobao.com/auction/merchandise/auction_list.htm");
        }
        #endregion

        #region btn_dingdan_Click
        private void btn_dingdan_Click(object sender, EventArgs e)
        {
            webBrowser1.Load("https://trade.taobao.com/trade/itemlist/list_sold_items.htm");
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
            webBrowser1.Load("https://myseller.taobao.com/seller_admin.htm");
            //if (Browser.WaitWebPageLoad(webBrowser1))
            //{
            //    Browser.MouseLeftByHtmlElement(" getElementsByDataSpm('d79')[0] ", webBrowser1);
            //}
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

        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {
            Manager.dianpu_huan(webBrowser1);
        }

        #endregion

        #region 基础



        #region btn_addjs_Click
        private void btn_addjs_Click(object sender, EventArgs e)
        {
            Browser.SetJSFile(webBrowser1);
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
            FileHelper.Write(path, html);
            System.Diagnostics.Process.Start(path);
        }









        #endregion

        #endregion



        #region btn_dazhe_Click
        private void btn_dazhe_Click(object sender, EventArgs e)
        {
            if (CS.Taobao.GoChaoJiDianZhang(webBrowser1))
            {
                string url = Browser.JS_CEFBrowser("document.getElementsByClassName('site-nav-item')[5].getElementsByTagName('a')[0].href", webBrowser1);
                webBrowser1.Load(url);


                //webBrowser1.Load("http://f.superboss.cc/ProductUsingServlet?kind=105&ftrace=0");
                //ProductUsingServlet?kind=106&ftrace=3#/trade/list/?pKuaidiStatus=0&isElec=0&status=SELLER_CONSIGNED_PART,WAIT_SELLER_SEND_GOODS&current=pKuaidiStatus&refundStatus=WAIT_SELLER_AGREE
                //ProductUsingServlet?kind=106&ftrace=3#/trade/list/?pKuaidiStatus=0&isElec=0&status=SELLER_CONSIGNED_PART,WAIT_SELLER_SEND_GOODS&current=pKuaidiStatus&refundStatus=WAIT_SELLER_AGREE
                webBrowser1.Load("ProductUsingServlet?kind=106&ftrace=3#/trade/list/?pKuaidiStatus=0&isElec=0&status=SELLER_CONSIGNED_PART,WAIT_SELLER_SEND_GOODS&current=pKuaidiStatus&refundStatus=WAIT_SELLER_AGREE");
                //https://nfh9.superboss.cc/v8.html#/trade/list/?pKuaidiStatus=0&isElec=0&status=SELLER_CONSIGNED_PART,WAIT_SELLER_SEND_GOODS&current=pKuaidiStatus&refundStatus=WAIT_SELLER_AGREE
            }
        }

        #endregion




        #region datagridview 方法

        #region btn_reset_dgv_Click
        /// <summary>
        /// 重置时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_reset_dgv_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "请选择";
            cb_fahuo.Text = "请选择";
            cb_kongbao.Text = "请选择";
        }
        #endregion

        #region btn_search_Click
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_search_Click(object sender, EventArgs e)
        {
            DateTime temp_date2 = new DateTime();
            if (dateTimePicker1.Text != "请选择")
            {
                temp_date2 = dateTimePicker1.Value;
            }
            string key = txt_key.Text.Trim();

            string dptype = cb_type.Text;
            if (dptype == "蘑菇街")
                dptype = "1";
            else if (dptype == "淘宝")
                dptype = "2";
            else if (dptype == "拼多多")
                dptype = "3";
            else
                dptype = "";

            string state_kongbao = cb_kongbao.Text;
            if (state_kongbao == "未获取")
                state_kongbao = "1";
            else if (state_kongbao == "已获取")
                state_kongbao = "2";
            else
                state_kongbao = "";

            string state_fahuo = cb_fahuo.Text;
            if (state_fahuo == "未发货")
                state_fahuo = "1";
            else if (state_fahuo == "已发货")
                state_fahuo = "2";
            else
                state_fahuo = "";

            string state_shoucai = cb_shoucai.Text;
            if (state_shoucai == "未收菜")
                state_shoucai = "1";
            else if (state_shoucai == "已收菜")
                state_shoucai = "2";
            else if (state_shoucai == "有问题")
                state_shoucai = "3";
            else
                state_shoucai = "";

            //dgv1.DataSource = BLL2.shuadan_recordsManager.Search(1, 1000, key, dptype, state_kongbao, state_fahuo, state_shoucai, temp_date2, temp_date2, "");
        }



        #endregion

        #region dateTimePicker1_CloseUp

        /// <summary>
        /// 设置时间显示格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }
        #endregion

        #region btn_delete_Click
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要删除选中数据?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {

                    foreach (DataGridViewRow row in dgv1.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            if ((bool)cbx.FormattedValue)
                            {
                                //shuadan_records sr = (shuadan_records)row.DataBoundItem;
                                //BLL2.shuadan_recordsManager.Delete(sr.sdid);
                            }
                        }
                    }

                    dgv1.Refresh();
                    MessageBox.Show("批量删除关键词成功");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #endregion


        #region dgv1_CellContentClick

        /// <summary>
        /// 点击单元格内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //如果不是首行
                if (e.RowIndex > -1)
                {
                    string colname = dgv1.Columns[e.ColumnIndex].Name;
                    //shuadan_records sr = (shuadan_records)dgv1.CurrentRow.DataBoundItem;

                    if (colname == "test")
                    {
                        #region 修改订单类型
                        //sr.sdremark6 = sr.sdremark6 == "1" ? "2" : (sr.sdremark6 == "2" ? "3" : "1");
                        //BLL2.shuadan_recordsManager.Update(sr);
                        ////取消选中
                        ////dgv1.Columns[e.ColumnIndex].Selected = false;
                        //dgv1.CurrentCell = null;
                        ////DataGridView.CurrentCell = null;
                        //dgv1.Refresh();
                        #endregion
                    }
                    else if (colname == "test2")
                    {

                    }


                }
                else if (e.RowIndex == -1)
                {
                    //如果是首行
                    #region 全选
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
                    #endregion
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region dgv1_CellFormatting
        /// <summary>
        /// 修改单元格显示格式
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

                        if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_test"))
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "蘑菇街";
                                e.CellStyle.ForeColor = Color.Green;
                            }
                            else if (name == "2")
                            {
                                e.Value = "淘宝";
                                e.CellStyle.ForeColor = Color.Blue;
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

        #region dgv1_CellParsing
        /// <summary>
        /// 自动保存 用户离开单元格时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                //int i = dgv_title.CurrentCell.ColumnIndex;
                string colname = dgv1.Columns[dgv1.CurrentCell.ColumnIndex].Name;


                if (colname.Equals("col_phone") || colname.Equals("col_orderid") || colname.Equals("col_wuliu") || colname.Equals("col_vpn") || colname.Equals("col_address") || colname.Equals("col_remark"))
                {
                    shuadan_records og = (shuadan_records)dgv1.CurrentRow.DataBoundItem;
                    if (og != null)
                    {


                        string phone = dgv1["col_phone", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_phone", e.RowIndex].EditedFormattedValue.ToString();
                        string wuliu = dgv1["col_wuliu", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_wuliu", e.RowIndex].EditedFormattedValue.ToString();
                        string address = dgv1["col_address", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_address", e.RowIndex].EditedFormattedValue.ToString();



                        og.sdaddress = address;
                        og.sdphone = phone;
                        og.sdwuliu = wuliu;


                        //BLL2.shuadan_recordsManager.Update(og);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("修改信息失败 " + ex.Message);
            }
        }
        #endregion

        #region dgv1_RowPostPaint
        /// <summary>
        /// 添加行号-表格绘制完成之后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 10);
        }






        #endregion

        #endregion


    }


}

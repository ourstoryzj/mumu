using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using excel_operation.Other;
using System.Diagnostics;
using System.ComponentModel;
using excel_operation.CS;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace excel_operation.TaoBao
{
    public partial class TB_Keys2 : Form
    {

        /// <summary>
        /// 蓝海市场行情浏览器
        /// </summary>
        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        /// <summary>
        /// 采集的原始数据
        /// </summary>
        List<lh_keydata> list_yuanshi = new List<lh_keydata>();
        /// <summary>
        /// 可以操作的数据
        /// </summary>
        List<lh_keydata> list_caozuo = new List<lh_keydata>();

        public TB_Keys2()
        {

            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("https://sycm.taobao.com/mc/mq/market_monitor");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(980, 700);
            webBrowser1.Location = new Point(6, 6);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            webBrowser1.Dock = DockStyle.Fill;
            tp_schq.Controls.Add(webBrowser1);
            tabControl1.SelectedTab = tp_hangye;



            #region 蓝海
            dgv_lh_hangye.AutoGenerateColumns = false;
            dgv_lh_rankinglist.AutoGenerateColumns = false;
            dgv_key.AutoGenerateColumns = false;
            bind_hangye();
            Bind_TiaoJian();
            bind_zaoci();
            dgv_key.AllowUserToAddRows = false;
            dgv_lh_hangye.AllowUserToAddRows = false;
            dgv_lh_rankinglist.AllowUserToAddRows = false;
            #endregion

            //图片保存地址
            txt_save.Text = XMLHelper.GetValue("Pic_Save");

            bind();
        }


        #region Bind 

        void bind()
        {
            txt_caijiKeyTime.Text = XMLHelper.GetValue("CaijiKeyTime");
        }

        void Bind_TiaoJian()
        {
            txt_changdu1.Text = XMLHelper.GetValue("Key_KeyLength1");
            txt_changdu2.Text = XMLHelper.GetValue("Key_KeyLength2");

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

            txt_jingzheng1.Text = XMLHelper.GetValue("Key_JingZheng1");
            txt_jingzheng2.Text = XMLHelper.GetValue("Key_JingZheng2");


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
            cb_zaoci2.DataSource = list;
            cb_zaoci2.DisplayMember = "zname";
            cb_zaoci2.ValueMember = "zid";
        }

        void bind_ciku()
        {
            List<keys_lexicon> list = (List<keys_lexicon>)BLL2.keys_lexiconManager.Search(1, 1000, "", "", new DateTime(), new DateTime(), "");
            dgv2.DataSource = list.ToDataTable();

            //List<keys_lexicon> list = (List<keys_lexicon>)BLL2.keys_lexiconManager.Search(1, 1000, "", "", new DateTime(), new DateTime(), "");
            //dgv2.DataSource = list;
        }

        #endregion

        #region 蓝海词管理系统

        #region 添加行业
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        #region btn_hangyeadd_Click
        private void btn_hangyeadd_Click(object sender, EventArgs e)
        {
            Entity.lh_hangye hangye = new lh_hangye();
            string name = txt_lh_hangye_name.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入正确的行业名称");
                return;
            }

            hangye.hname = name;
            hangye.hdate = DateTime.Now;
            hangye.hstate = "1";

            BLL2.lh_hangyeManager.Insert(hangye);
            //刷新列表
            bind_hangye();
        }
        #endregion
        #endregion

        #region 绑定行业表&绑定行业下拉菜单

        void bind_hangye()
        {
            IList<Entity.lh_hangye> list = BLL2.lh_hangyeManager.Search(1, 1000, "", "", new DateTime(), new DateTime(), " hdate desc ");
            dgv_lh_hangye.DataSource = list.ToDataTable();
            IList<Entity.lh_hangye> list2 = BLL2.lh_hangyeManager.Search(1, 1000, "", "1", new DateTime(), new DateTime(), " hdate desc ");
            cb_lh_hangye.DataSource = list2;
            cb_lh_hangye.DisplayMember = "hname";
            cb_lh_hangye.ValueMember = "hid";

            cb_hangye.DataSource = list2;
            cb_hangye.DisplayMember = "hname";
            cb_hangye.ValueMember = "hid";
        }


        #endregion



        #region 绑定排行榜关键词

        void bind_rankinglist()
        {
            try
            {
                int zid = Convert.ToInt32(cb_lh_hangye.SelectedValue);
                IList<lh_rankinglist> list = BLL2.lh_rankinglistManager.Search(1, 9999, "", "", zid, new DateTime(), new DateTime(), "  rid asc ");
                dgv_lh_rankinglist.DataSource = list.ToDataTable(); ;
            }
            catch (Exception e)
            {
                ("绑定数据失败" + e.ToString()).ToLog();
            }
        }

        #endregion

        #region 下拉菜单联动
        private void cb_lh_hangye_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_rankinglist();
        }


        #endregion

        #region 清空输入框-排行榜

        private void txt_rankinglist_Click(object sender, EventArgs e)
        {
            if (txt_rankinglist.Text == "请在此输入噪词")
                txt_rankinglist.Text = "";
        }

        #endregion

        #region 添加关键词排行榜

        private void btn_lh_rankinglist_add_Click(object sender, EventArgs e)
        {
            string names = txt_rankinglist.Text;
            if (!string.IsNullOrEmpty(names))
            {
                string[] datas = System.Text.RegularExpressions.Regex.Split(names, "\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                lh_rankinglist rl = new lh_rankinglist();
                rl.hid = Convert.ToInt32(cb_lh_hangye.SelectedValue);
                rl.rdate = DateTime.Now;
                rl.rstate = "1";
                foreach (string temp in datas)
                {
                    if (!string.IsNullOrEmpty(temp.Trim()))
                    {
                        rl.rkey = temp.Replace("\r", "");
                        rl.rkey = temp.Replace(".", ""); ;
                        BLL2.lh_rankinglistManager.Insert(rl);
                    }
                }
                MessageBox.Show("关键词排行榜添加成功");
                bind_rankinglist();
                txt_rankinglist.Text = "";
            }
        }
        #endregion

        #region 批量删除排行榜关键词


        private void btn_lh_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要删除所有勾选排行榜关键词吗?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dgv_lh_rankinglist.Rows)
                {
                    if (row.Index != -1)
                    {
                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                        if ((bool)cbx.FormattedValue)
                        {
                            lh_rankinglist zc = row.ToModel<lh_rankinglist>();
                            if (zc != null)
                            {
                                //先删除下面的关键词
                                //然后删除排行榜关键词
                                BLL2.lh_rankinglistManager.Delete(zc.rid);
                            }
                        }
                    }
                }
            }
            bind_rankinglist();
            MessageBox.Show("删除成功");
        }
        #endregion

        #region DGV搜索词排行榜表操作

        private void dgv_lh_rankinglist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Manager.dgv_set_selectall(dgv_lh_rankinglist, e);
            //如果点击页头
            if (e.RowIndex == -1)
            {

                //排序事件
                try
                {
                    //dgv1.Sort(dgv1.Columns[e.ColumnIndex], ListSortDirection.Descending);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("排序出错=========================" + ex.Message);
                }
            }
            else if (dgv_lh_rankinglist.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                //删除搜索排行榜
                lh_rankinglist zc = dgv_lh_rankinglist.CurrentRow.ToModel<lh_rankinglist>();
                if (zc != null)
                {

                    //显示市场行情网页
                    tabControl1.SelectedTab = tp_schq;
                    //进入搜索分析 ，判断是否进入了搜索词
                    Taobao.Go_ShiChangHangQing_SouSuoFenXi(webBrowser1);
                    //输入关键词，搜索
                    //点击相关分析
                    Taobao.Set_SouSuoFenXi_Key(webBrowser1, zc.rkey);
                    //选择搜索人气、支付转化率、在线商品数、商城点击占比、直通车参考价格--已经设置好
                    //设置每页显示100条
                    //循环采集5页
                    //把采集的数据追加到集合中
                    List<lh_keydata> list = Taobao.CaiJi_SouSuoFenXi_Data(webBrowser1, zc.hid, zc.rid);
                    dgv_key.DataSource = list.ToDataTable();
                    list_yuanshi = list;
                    //list.ForEach(key_temp => BLL2.lh_keydataManager.Insert(key_temp));
                    tabControl1.SelectedTab = tp_keydata;
                    MessageBox.Show("数据采集成功");

                }
            }
            else if (dgv_lh_rankinglist.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                //修改状态
                lh_rankinglist zc = dgv_lh_rankinglist.CurrentRow.ToModel<lh_rankinglist>();
                if (zc != null)
                {
                    zc.rstate = zc.rstate == "1" ? "2" : "1";
                    BLL2.lh_rankinglistManager.Update(zc);
                    dgv_lh_rankinglist[e.ColumnIndex, e.RowIndex].Value = zc.rstate;
                    dgv_lh_rankinglist.Refresh();

                }
            }
        }

        private void dgv_lh_rankinglist_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            //修改表格内容
            try
            {
                //判断是否修改了？如果没有修改则跳出
                if (dgv_lh_rankinglist.Rows[e.RowIndex].Cells[1].EditedFormattedValue == null)
                    return;
                //判断如果是第一列表格点击了
                if (dgv_lh_rankinglist.CurrentCell.ColumnIndex == 1)
                {
                    lh_rankinglist zc = dgv_lh_rankinglist.CurrentRow.ToModel<lh_rankinglist>();
                    if (zc != null)
                    {
                        string name = dgv_lh_rankinglist.Rows[e.RowIndex].Cells[1].EditedFormattedValue == null ? zc.rkey : dgv_lh_rankinglist.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
                        zc.rkey = name;
                        BLL2.lh_rankinglistManager.Update(zc);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("修改信息失败 " + ex.Message);
            }
        }

        private void dgv_lh_rankinglist_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Manager.dgv_add_hanghao(dgv_lh_rankinglist, e);
        }

        private void dgv_lh_rankinglist_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            Manager.dgv_set_show(dgv_lh_rankinglist, e, "col_state1", "col_date1");
        }




        #endregion

        #endregion


        #region 基础功能

        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {
            Manager.dianpu_huan(webBrowser1);
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion

        #region btn_canmou_Click

        private void btn_canmou_Click(object sender, EventArgs e)
        {
            CS.Taobao.Go_ShiChangHangQing(webBrowser1);
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

            XMLHelper.SetValue("Key_JingZheng1", txt_jingzheng1.Text);
            XMLHelper.SetValue("Key_JingZheng2", txt_jingzheng2.Text);

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

        #endregion








        #region btn_shaixuan_Click
        private void btn_shaixuan_Click(object sender, EventArgs e)
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

            decimal jingzheng1 = 0;
            decimal.TryParse(txt_jingzheng1.Text.Trim(), out jingzheng1);
            decimal jingzheng2 = 0;
            decimal.TryParse(txt_jingzheng2.Text.Trim(), out jingzheng2);

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

            //获取datagridview中的数据
            //list_caozuo = (dgv_key.DataSource as DataTable).ToList<lh_keydata>();
            list_caozuo = dgv_key.ToList<lh_keydata>();

            //开始删除数据
            //list_caozuo = new List<lh_keydata>();
            //结果集
            List<lh_keydata> list_key = new List<lh_keydata>();
            foreach (lh_keydata k in list_caozuo)
            {
                if (changdu1 != 0)
                {
                    if (k.kname.Length < changdu1)
                    {
                        continue;
                    }
                }
                if (changdu2 != 0)
                {
                    if (k.kname.Length > changdu2)
                    {
                        continue;
                    }
                }
                if (renshu1 != 0)
                {
                    if (k.ksousuorenqi < renshu1)
                    {
                        continue;
                    }
                }
                if (renshu2 != 0)
                {
                    if (k.ksousuorenqi > renshu2)
                    {
                        continue;
                    }
                }
                if (shangcheng1 != 0)
                {
                    if (k.kshangchengzhanbi < shangcheng1)
                    {
                        continue;
                    }
                }
                if (shangcheng2 != 0)
                {
                    if (k.kshangchengzhanbi > shangcheng2)
                    {
                        continue;
                    }
                }
                if (goodsnum1 != 0)
                {
                    if (k.kzaixianshangpinshu < goodsnum1)
                    {
                        continue;
                    }
                }
                if (goodsnum2 != 0)
                {
                    if (k.kzaixianshangpinshu > goodsnum2)
                    {
                        continue;
                    }
                }
                if (ZTCprice1 != 0)
                {
                    if (k.kzhitongchejiage < ZTCprice1)
                    {
                        continue;
                    }
                }
                if (ZTCprice2 != 0)
                {
                    if (k.kzhitongchejiage > ZTCprice2)
                    {
                        continue;
                    }
                }
                if (zhuanhualv1 != 0)
                {
                    if (k.kzhifuzhuanhualv < zhuanhualv1)
                    {
                        continue;
                    }
                }
                if (zhuanhualv2 != 0)
                {
                    if (k.kzhifuzhuanhualv > zhuanhualv2)
                    {
                        continue;
                    }
                }

                if (jingzheng1 != 0)
                {
                    if (k.kjingzheng < jingzheng1)
                    {
                        continue;
                    }
                }
                if (jingzheng2 != 0)
                {
                    if (k.kjingzheng > jingzheng2)
                    {
                        continue;
                    }
                }


                list_key.Add(k);

            }
            list_caozuo.Clear();
            list_caozuo.AddRange(list_key);
            dgv_key.DataBindings.Clear();
            dgv_key.DataSource = list_caozuo.ToDataTable();
            dgv_key.Refresh();
            MessageBox.Show("筛选市场行情数据成功");
        }
        #endregion

        #region btn_huifu_Click


        private void btn_huifu_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要恢复原始数据吗?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                list_caozuo.Clear();
                list_caozuo.AddRange(list_yuanshi);
                dgv_key.DataBindings.Clear();
                dgv_key.DataSource = null;
                dgv_key.DataSource = list_caozuo.ToDataTable();
                dgv_key.Refresh();
            }
        }

        #endregion

        #region 保存数据
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                int ok = 0;
                int no = 0;

                if (list_caozuo.Count > 0)
                {
                    //判断是新添加的关键词 ，还是从数据库中查询的关键词
                    if (list_caozuo[0].kid == 0)
                    {
                        //如果是新添加的关键词则，直接插入信息

                        foreach (lh_keydata k in list_caozuo)
                        {
                            if (BLL2.lh_keydataManager.Insert(k) == 1)
                            {
                                ok++;
                                lbl_message.Text = "操作：已经成功保存 " + ok + " 条数据,共 " + list_caozuo.Count + " 条数据";
                            }
                            else
                            {
                                no++;
                                lbl_message.Text = "操作：保存失败 " + no + " 条数据,共 " + list_caozuo.Count + " 条数据";
                            }
                        }

                    }
                    else
                    {
                        //如果是查询的数据，则删除筛选后的数据
                        foreach (lh_keydata k in list_yuanshi)
                        {
                            ok++;
                            lbl_message.Text = "[删除中]正在操作第" + ok + "个关键词";
                            //判断是否删除的字段
                            bool isdel = true;
                            foreach (lh_keydata kk in list_caozuo)
                            {
                                //如果有这个数据，则不删除
                                if (kk.kid == k.kid)
                                {
                                    isdel = false;
                                    break;
                                }
                            }
                            if (isdel)
                            {
                                BLL2.lh_keydataManager.Delete(k.kid);
                            }
                        }
                    }
                }
                MessageBox.Show("保存成功");

            }
            catch (Exception ex)
            {
                MessageBox.Show("保存数据失败" + ex.ToString());
            }
        }
        #endregion

        #region 批量删除


        private void btn_del_Click(object sender, EventArgs e)
        {
            try
            {
                lh_keydata kd = null;
                list_caozuo.Clear();
                list_caozuo = new List<lh_keydata>();
                if (MessageBox.Show("是否要删除所有勾选关键词数据?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    List<lh_keydata> list = new List<lh_keydata>();
                    foreach (DataGridViewRow row in dgv_key.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            kd = row.ToModel<lh_keydata>();
                            //判断是否勾选，如果没有勾选则留下数据
                            if (!(bool)cbx.FormattedValue)
                            {
                                if (kd != null)
                                {
                                    list_caozuo.Add(kd);
                                }
                            }
                            else
                            {
                                //如果勾选了，看是否有id，如果有id 则删除
                                if (kd.kid != 0)
                                {
                                    BLL2.lh_keydataManager.Delete(kd.kid);
                                }
                            }
                        }
                    }
                }

                dgv_key.DataSource = list_caozuo.ToDataTable();
                dgv_key.Refresh();
                MessageBox.Show("删除成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除数据出错" + ex.ToString());
            }
        }

        #endregion

        #region 去噪


        private void btn_clearzao_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cb_zaoci.SelectedValue);
                IList<yh_zaoci> list = BLL2.yh_zaociManager.Search(1, 50000, "", "", id, new DateTime(), new DateTime(), "");

                //获取表格中的数据
                IList<lh_keydata> list_dgv = dgv_key.ToList<lh_keydata>();
                //重置操作list
                list_caozuo.Clear();
                list_caozuo = new List<lh_keydata>();

                //为零则不删除，为1则删除
                int state = 0;

                foreach (lh_keydata k in list_dgv)
                {

                    //设置关键词状态为正常0
                    state = 0;
                    foreach (yh_zaoci zc in list)
                    {
                        try
                        {
                            if (k.kname.IndexOf(zc.zname) > -1)
                            {
                                //设置关键词状态为删除1
                                state = 1;
                                if (k.kid != 0)
                                {
                                    BLL2.lh_keydataManager.Delete(k.kid);
                                }
                                break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("去噪库出现问题");
                        }

                    }
                    if (state == 0)
                        list_caozuo.Add(k);
                }
                dgv_key.DataBindings.Clear();
                dgv_key.DataSource = list_caozuo.ToDataTable();
                dgv_key.Refresh();
                MessageBox.Show("去噪成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("去噪出现问题:" + ex.ToString());
            }
        }
        #endregion

        #region 更新噪词


        private void btn_zaociupdate_Click(object sender, EventArgs e)
        {
            bind_zaoci();
        }
        #endregion

        #region 双击打开行业关键词数据


        private void dgv_lh_hangye_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                lh_hangye hy = dgv_lh_hangye.Rows[e.RowIndex].ToModel<lh_hangye>();
                if (hy != null)
                {
                    tabControl1.SelectedTab = tp_keydata;
                    IList<lh_keydata> list = BLL2.lh_keydataManager.Search(1, 50000, "", "", hy.hid, 0, new DateTime(), new DateTime(), " kbackup1  DESC,kjingzheng DESC ");
                    _clearlist(list);
                }
            }

        }
        #endregion

        #region 通用方法
        /// <summary>
        /// 搜索的数据，自动处理？？？
        /// </summary>
        /// <param name="list"></param>
        private void _clearlist(IList<lh_keydata> list)
        {
            list_caozuo.Clear();
            list_yuanshi.Clear();
            list_caozuo.AddRange(list);
            list_yuanshi.AddRange(list);
            dgv_key.DataSource = list_caozuo.ToDataTable();
        }
        #endregion

        #region 双击打开排行榜关键词数据


        private void dgv_lh_rankinglist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                lh_rankinglist hy = dgv_lh_rankinglist.Rows[e.RowIndex].ToModel<lh_rankinglist>();
                if (hy != null)
                {
                    tabControl1.SelectedTab = tp_keydata;
                    IList<lh_keydata> list = BLL2.lh_keydataManager.Search(1, 50000, "", "", 0, hy.rid, new DateTime(), new DateTime(), " kbackup1  DESC,kjingzheng DESC");
                    _clearlist(list);
                }
            }
        }

        #endregion

        #region btn_test_Click
        private void btn_test_Click(object sender, EventArgs e)
        {
            string js = txt_js.Text;
            Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion



        #region 去重

        private void btn_chongfu_Click(object sender, EventArgs e)
        {
            try
            {
                List<lh_keydata> list = removeRepeat(dgv_key.ToList<lh_keydata>());
                dgv_key.DataSource = list.ToDataTable();
                MessageBox.Show("去重成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现问题:" + ex.ToString());
            }
        }


        /// <summary>
        /// 去除重复的关键词
        /// </summary>
        /// <param name="list_temp"></param>
        /// <returns></returns>
        private List<lh_keydata> removeRepeat(List<lh_keydata> list_temp)
        {
            //结果集合
            list_caozuo.Clear();
            list_caozuo = new List<lh_keydata>();

            //获取操作过的字段集合
            List<lh_keydata> list_ok = new List<lh_keydata>();

            int num = 0;

            //开始遍历清除重复数据
            //遍历要操作的集合
            foreach (lh_keydata k in list_temp)
            {
                num++;
                lbl_message.Text = "正在操作第" + num + "个关键词";
                //是否应该添加该字段
                bool isadd = true;
                //判断操作集合里是否有这个字段，如果没有则加入，如果有则跳过
                foreach (lh_keydata kk in list_ok)
                {
                    //如果有则跳出，不添加
                    if (k.kname == kk.kname)
                    {
                        isadd = false;
                        break;
                    }
                }
                //根据字段判断是否应该添加
                if (isadd)
                {
                    list_ok.Add(k);
                }
                else
                {
                    //如果有id则直接删除数据库
                    if (k.kid != 0)
                    {
                        BLL2.lh_keydataManager.Delete(k.kid);
                    }
                }
            }

            //赋值到list_caozuo中
            list_caozuo.AddRange(list_ok);
            return list_caozuo;
        }



        #endregion

        #region 导出到Excel
        /// <summary>
        /// 导出到Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_excel_Click(object sender, EventArgs e)
        {
            if (DataGridViewHelper.ToExcel(dgv_key))
            {
                MessageBox.Show("导出成功");
            }
            //ExcelHelper.DataGridViewToExcel(dgv_key, "");
        }
        #endregion


        #region 根据关键词查找数据


        private void btn_search_Click(object sender, EventArgs e)
        {
            string key = txt_searchkey.Text;
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("请输入正确的关键词");
                txt_searchkey.Focus();
                return;
            }
            dgv_key.DataSource = ToHasKeyList(key).ToDataTable<lh_keydata>();
        }

        /// <summary>
        /// 查找包含关键词的数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        List<lh_keydata> ToHasKeyList(string key)
        {
            list_caozuo.Clear();
            //List<lh_keydata> list_temp = dgv_key.ToList<lh_keydata>();
            foreach (var k in list_yuanshi)
            {
                if (k.kname.IndexOf(key) != -1)
                {
                    list_caozuo.Add(k);
                    continue;
                }
                if (!string.IsNullOrEmpty(k.kremark))
                {
                    if (k.kremark.IndexOf(key) != -1)
                    {
                        list_caozuo.Add(k);
                        continue;
                    }
                }
            }
            return list_caozuo;
        }



        #endregion



        #region 采集关键词的相关数据，包括，销量高于1000的商品 图片 信息，销量排序第一页所有商品标题等
        private void btn_selectlanhai_Click(object sender, EventArgs e)
        {
            try
            {
                lh_keydata kd = null;


                foreach (DataGridViewRow row in dgv_key.Rows)
                {
                    if (row.Index != -1)
                    {
                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                        kd = row.ToModel<lh_keydata>();
                        if (!string.IsNullOrEmpty(kd.kbackup1))
                        {
                            if (kd.kbackup1 != "0")
                            {
                                cbx.Value = true;
                            }
                        }
                        //判断是否勾选，如果没有勾选则留下数据


                    }
                }
                MessageBox.Show("已勾选所有非普通词");
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择蓝海词失败" + ex.ToString());
            }
        }
        #endregion

        #region 下载图片 btn_downloadimg_Click
        /// <summary>
        /// 下载图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_downloadimg_Click(object sender, EventArgs e)
        {
            //获取页面链接
            string weburl = txt_url_down.Text.Trim();
            if (string.IsNullOrEmpty(weburl))
            {
                MessageBox.Show("请输入淘宝宝贝网址");
                return;
            }
            //获取页面保存地址
            string temp_save = txt_save.Text.Trim();
            if (string.IsNullOrEmpty(temp_save))
            {
                MessageBox.Show("请输入文件保存路径");
                return;
            }

            tabControl1.SelectedTab = tp_schq;

            //把保存地址存储到xml文件中
            XMLHelper.SetValue("Pic_Save", temp_save);

            webBrowser1.Load(weburl);

            //平台截图
            Bitmap bm = null;
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                bm = ImageClass.GetScreen(webBrowser1);
            }

            //图片返回保存地址
            string path_temp = "";

            //获取链接中是否有yangkeduo字样，如果有则就是拼多多的页面

            if (weburl.IndexOf("yangkeduo") > -1)
            {
                path_temp = CS.PinDuoDuo.DownloadImg(temp_save, weburl, webBrowser1);
            }
            else if (weburl.IndexOf("taobao") > -1)
            {
                path_temp = CS.Taobao.DownLoadImg_TaoBao(temp_save, weburl, webBrowser1);
            }
            else if (weburl.IndexOf("tmall") > -1)
            {
                //天猫
                path_temp = CS.Taobao.DownLoadImg_Tmall(temp_save, weburl, webBrowser1);
            }
            else if (weburl.IndexOf("1688") > -1)
            {
                //1688
            }
            else if (weburl.IndexOf("bao66") > -1)
            {
                //包牛牛
                path_temp = CS.BaoNiuNiu.DownloadImg(temp_save, weburl, webBrowser1);
            }

            //保存截图
            if (!string.IsNullOrEmpty(path_temp))
            {
                ImageClass.GetScreen(bm, 50, path_temp, "屏幕截图.jpg");
            }

            tabControl1.SelectedTab = tp_other;

            MessageBox.Show("保存完成");
            if (!string.IsNullOrEmpty(path_temp))
                Process.Start(path_temp);
        }


        #endregion

        #region 根据关键词，采集淘宝信息
        private void btn_caijitaobaobykey_Click(object sender, EventArgs e)
        {
            string key = txt_other_key.Text;
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("请输入正确的关键词");
                txt_other_key.Focus();
                return;
            }
            string path = Manager.OpenFolderDialog("");
            path = CaiJiByKey(key, path);
            MessageBox.Show("采集完成");
            Process.Start(path);

        }
        #endregion

        #region CaiJiByKey

        /// <summary>
        /// 文件夹名称规则
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string CaiJiByKey_GetFileName(string key)
        {
            string name = key;
            IList<lh_keydata> list = BLL2.lh_keydataManager.Search(1, 1000, key, "", 0, 0, new DateTime(), new DateTime(), "");
            if (list.Count > 0)
            {
                foreach (lh_keydata kd in list)
                {
                    if (kd.kname.Trim() == key.Trim())
                    {
                        //name = kd.kjingzheng + "_" + kd.ksousuorenqi + "_" + kd.kzaixianshangpinshu + "_" + key;
                        name = key + "_竞争" + kd.kjingzheng + "_人数" + kd.ksousuorenqi + "_商品" + kd.kzaixianshangpinshu;
                    }
                }
            }
            return name;
        }


        /// <summary>
        /// 根据关键词采集数据
        /// </summary>
        /// <param name="key"></param>
        string CaiJiByKey(string key, string path)
        {
            //标题
            string titles = "";
            //网址
            string urls = "";
            List<string> list_id = new List<string>();
            tabControl1.SelectedTab = tp_schq;
            Browser.Delay(500);
            //打开选择文件夹窗口
            //string path = Manager.OpenFolderDialog("");
            //path = path + "\\" + CaiJiByKey_GetFileName(key);
            path = path + "\\" + key;

            //打开网站
            webBrowser1.Load(Taobao.Go_Sale_Url(key));
            //加载完成后
            if (Browser.WaitWebPageLoad("document.getElementsByClassName('title')[6]", webBrowser1))
            {
                //移动到商品位置
                Browser.ScrollToElement("document.getElementsByClassName('m-itemlist')[0]", webBrowser1);
                Browser.Delay(500);
                //截图屏幕
                Bitmap bmp = ImageClass.GetScreen(webBrowser1);
                //获取商品数量
                int count = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('title').length", webBrowser1);
                //开始采集信息
                for (int i = 6; i < count; i++)
                {
                    string title_temp = Browser.JS_CEFBrowser("document.getElementsByClassName('title')[" + i.ToString() + "].innerText", webBrowser1);
                    //采集所有商品标题
                    titles += title_temp + "\r\n";
                    //采集所有商品销量
                    string _sale_temp = Browser.JS_CEFBrowser("document.getElementsByClassName('deal-cnt')[" + (i - 6).ToString() + "].innerText", webBrowser1);
                    _sale_temp = _sale_temp.Replace("人收货", "");
                    int salenum = 0;
                    if (int.TryParse(_sale_temp, out salenum))
                    {
                        //如果销量大于500
                        if (salenum > 500)
                        {
                            //获取链接
                            string id_temp = Browser.JS_CEFBrowser("document.getElementsByClassName('title')[" + i.ToString() + "].getElementsByTagName('a')[0].href", webBrowser1);

                            id_temp = Manager.GetURLParam(id_temp, "id");
                            if (!string.IsNullOrEmpty(id_temp))
                                list_id.Add(id_temp);
                            //采集主图
                            string img_url = Browser.JS_CEFBrowser("document.getElementsByClassName('pic')[" + (i - 6).ToString() + "].getElementsByTagName('img')[0].src", webBrowser1);
                            img_url = CaiJi.GetImgSizeByUrl(img_url, 800);
                            //Task t = new Task(Manager.DownloadFile);
                            //多线程下载图片
                            Action<string, string, string, int> at = Manager.DownloadFile_Action;
                            at.BeginInvoke(img_url, path, (i - 5) + "_" + title_temp + ".jpg", 5000, null, null);

                        }

                    }

                }
                //保存商品标题和图片
                ImageClass.GetScreen(bmp, 50, path, "屏幕截图.jpg");
                FileHelper.Write(path + "\\标题.txt", titles);


                //开始采集淘宝商品数据
                foreach (string id in list_id)
                {
                    //采集所有销量1000+的商品图片
                    string urlss = Taobao.Go_GoodsUrl(id);
                    urls += urlss + "\r\n";
                    //先不下载淘宝图片，多次被淘宝封ip，可以尝试使用浏览器自动保存图片
                    //webBrowser1.Load(urlss);
                    //Taobao.DownLoadGoodsImg(path, urlss, webBrowser1);
                }
                FileHelper.Write(path + "\\爆款链接.txt", urls);
            }
            return path;
        }
        #endregion

        #region btn_searchkey_Click

        private void btn_searchkey_Click(object sender, EventArgs e)
        {
            string key = txt_searchkey_key.Text;
            string res = TaoBaoHelper.ReadCommodity(key);
            txt_key_biaoti.Text = res;
        }
        #endregion


        #region 荧光棒


        private void dgv_key_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv_key.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(87, 166, 74);
                dgv_key.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }
        }

        private void dgv_key_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgv_key.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                dgv_key.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                Debug.Write(ex.ToString());
            }

        }
        #endregion



        #region btn_jisuan_Click



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
            //MessageBox.Show("成功添加共 " + list_res.Count.ToString() + " 条记录");
        }

        #endregion


        #region txt_searchkey_KeyPress


        private void txt_searchkey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btn_search.PerformClick();
            }

        }
        #endregion


        #region txt_title_TextChanged
        private void txt_title_TextChanged(object sender, EventArgs e)
        {
            //中文字符数量
            int resnum = 0;
            //英文和数字数量
            int resnum2 = 0;
            //计算后标题的数量
            int res = 0;

            string str = txt_title.Text;
            if (string.IsNullOrEmpty(str))
                return;
            Char[] strs = str.ToCharArray();
            foreach (char temp in strs)
            {
                if (Manager.String_CheckChinese(temp.ToString()))
                    resnum++;
                else
                    resnum2++;
            }

            if (resnum2 > 0)
                res = (resnum2 / 2) + ((resnum2 % 2) > 0 ? 1 : 0);
            res = res + resnum;

            lbl_titlenum.Text = "还可输入【" + (30 - res) + "】个字";
        }
        #endregion

        #region btn_clear_Click
        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_key_biaoti.Text = "";
        }
        #endregion



        #region txt_price_TextChanged


        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            decimal res = 0;
            string str = txt_price.Text;
            if (string.IsNullOrEmpty(str))
                return;
            decimal.TryParse(str, out res);
            lbl_price.Text = (res * 2).ToString();
            Auto.Clipboard_In(lbl_price.Text);

        }

        #endregion


        #region lbl_price_Click
        private void lbl_price_Click(object sender, EventArgs e)
        {
            string str = lbl_price.Text;
            Auto.Clipboard_In(str);
        }


        #endregion



        #region 标题起名

        /// <summary>
        /// 判断是否是txt文件，并设置拖入状态,鼠标拖过来的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_key_biaoti_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                //获取文件路径
                var filenames = (string[])e.Data.GetData(DataFormats.FileDrop);
                var hz = filenames[0].LastIndexOf('.') + 1;
                var houzhui = filenames[0].Substring(hz);//文件后缀名
                if (houzhui == "txt")
                {
                    //设置拖拽状态，如果不设置则不会触发DragDrop事件
                    e.Effect = DragDropEffects.All;
                }

            }
        }

        /// <summary>
        /// 读取txt文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_key_biaoti_DragDrop(object sender, DragEventArgs e)
        {
            var filenames = (string[])e.Data.GetData(DataFormats.FileDrop);
            using (StreamReader sr = new StreamReader(filenames[0], Encoding.UTF8))
            {
                txt_key_biaoti.Text = sr.ReadToEnd();
            }

            btn_jisuan.PerformClick();
        }
        #endregion












        #region 设置每页采集时间


        private void txt_caijiKeyTime_TextChanged(object sender, EventArgs e)
        {
            int time = txt_caijiKeyTime.Text.ToInt();
            if (time == 0)
            {
                txt_caijiKeyTime.Select();
                return;
            }
            XMLHelper.SetValue("CaijiKeyTime", time.ToString());
        }
        #endregion


        #region 主面板功能


        #region btn_setcaijitiaojian_Click
        private void btn_setcaijitiaojian_Click(object sender, EventArgs e)
        {
            //进入搜索分析 ，判断是否进入了搜索词
            Taobao.Go_ShiChangHangQing_SouSuoFenXi(webBrowser1);
        }
        #endregion

        #region btn_caiji_byhangye_Click
        private void btn_caiji_byhangye_Click(object sender, EventArgs e)
        {
            try
            {
                list_caozuo.Clear();
                list_yuanshi.Clear();


                //显示市场行情网页
                tabControl1.SelectedTab = tp_schq;
                //找到选择行业的信息ID
                int hid = Convert.ToInt32(cb_hangye.SelectedValue);
                //根据行业ID查询搜索词排行榜
                IList<lh_rankinglist> list = BLL2.lh_rankinglistManager.Search(1, 9999, "", "", hid, new DateTime(), new DateTime(), "  rid asc ");
                //进入搜索分析 ，判断是否进入了搜索词
                Taobao.Go_ShiChangHangQing_SouSuoFenXi(webBrowser1);
                //遍历所有搜索词，采集所有相关词数据
                foreach (lh_rankinglist rl in list)
                {
                    //输入关键词，搜索
                    //点击相关分析
                    Taobao.Set_SouSuoFenXi_Key(webBrowser1, rl.rkey);
                    //等待数据更新
                    Taobao.DelayUpdateKey(webBrowser1);
                    //选择搜索人气、支付转化率、在线商品数、商城点击占比、直通车参考价格--已经设置好
                    //设置每页显示100条
                    //循环采集5页
                    //把采集的数据追加到集合中
                    list_yuanshi.AddRange(Taobao.CaiJi_SouSuoFenXi_Data(webBrowser1, hid, rl.rid));
                }
                //展示采集的数据到表中，然后通过筛选后，保存数据
                list_caozuo.Clear();
                list_caozuo.AddRange(list_yuanshi);
                dgv_key.DataSource = list_caozuo.ToDataTable(); ;
                //切换到数据操作界面
                tabControl1.SelectedTab = tp_keydata;
                Manager.EmailSend("ourstoryzj@163.com", "数据采集完毕,共采集了" + list_caozuo.Count + "个关键词", "数据采集完毕了亲");
            }
            catch (Exception ex)
            {
                MessageBox.Show("采集数据失败" + ex.ToString());
            }
        }



        #endregion

        #region btn_SearchByTop_Click
        /// <summary>
        /// 搜索排行榜关键词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SearchByTop_Click(object sender, EventArgs e)
        {
            List<lh_rankinglist> list = new List<lh_rankinglist>();
            string res = "";

            CS.Taobao.Go_ShiChangHangQing_SouSuoPaiHang(webBrowser1);
            Browser.Delay(5000);
            //先采集搜索词
            //点击搜索
            Browser.JS_CEFBrowser("document.getElementsByClassName('oui-card-header-item-pull-left')[0].getElementsByClassName('oui-tab-switch-item')[0].click()", webBrowser1);
            Browser.Delay(2000);
            list.AddRange(caiji_RankingKey());
            //然后采集飙升词
            //点击飙升
            //Browser.JS_CEFBrowser("document.getElementsByClassName('oui-card-header-item-pull-left')[0].getElementsByClassName('oui-tab-switch-item')[1].click()", webBrowser1);
            //Browser.Delay(2000);
            //list.AddRange(caiji_RankingKey());
            //去掉重复
            list = RemoveRepeat(list);

            //复制添加到输入框
            //遍历所有排行榜，然后保存到内存中
            foreach (lh_rankinglist rl in list)
            {
                if (!string.IsNullOrEmpty(rl.rkey))
                {
                    res += rl.rkey + "\r\n";
                }
            }
            txt_rankinglist.Text = res;
            Auto.Ctrl_C(res);
            MessageBox.Show("采集排行榜成功");


            #region 只采集当前页面的
            //List<string> list_id = new List<string>();
            ////一级类目-箱包
            //list_id.Add("50006842");
            ////二级类目-箱包皮具/...箱包相关配件
            //list_id.Add("50026617");
            ////二级类目-箱包皮具/双肩背包
            //list_id.Add("122690003");
            ////二级类目-箱包皮具/胸包
            //list_id.Add("201241402");
            ////二级类目-箱包皮具/...箱包相关配件
            //list_id.Add("50026617");
            ////二级类目-箱包皮具/...箱包相关配件
            //list_id.Add("50026617");
            ////二级类目-箱包皮具/...箱包相关配件
            //list_id.Add("50026617");




            //IList<lh_rankinglist> list = Taobao.CaiJi_SouSuoPaiHang_Data(webBrowser1);
            //string res = "";
            ////遍历所有排行榜，然后保存到内存中
            //foreach (lh_rankinglist rl in list)
            //{
            //    if (!string.IsNullOrEmpty(rl.rkey))
            //    {
            //        res += rl.rkey + "\r\n";
            //    }
            //}
            //Auto.Ctrl_C(res);
            //MessageBox.Show("采集排行榜成功");

            #endregion


        }

        #region caiji_RankingKey 自动采集 搜索排行三级关键词,可重复采集 搜索词和 飙升词


        /// <summary>
        /// 自动采集 搜索排行三级关键词,可重复采集 搜索词和 飙升词
        /// </summary>
        /// <returns></returns>
        List<lh_rankinglist> caiji_RankingKey()
        {
            List<lh_rankinglist> list = new List<lh_rankinglist>();
            //设置100条
            //设置每页显示100条
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ant-select-selection__rendered')[1].click()", webBrowser1);
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('ant-select-dropdown-menu-item')[3].click()", webBrowser1);
            Browser.Delay(2000);
            //点击类目选择
            Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('common-picker-header')[0].click()", webBrowser1);
            //选择一级类目循环
            int len_level1 = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('tree-menu common-menu tree-scroll-menu-level-1')[0].getElementsByTagName('li').length", webBrowser1);
            for (int i = 0; i < len_level1; i++)
            {
                //点击一级类目
                Browser.JS_CEFBrowser("document.getElementsByClassName('tree-menu common-menu tree-scroll-menu-level-1')[0].getElementsByTagName('li')[" + i + "].click()", webBrowser1);
                //等待
                Browser.WaitWebPageLoad(webBrowser1);
                Browser.Delay(5000);
                //采集
                list.AddRange(Taobao.CaiJi_SouSuoPaiHang_Data(webBrowser1));

                if (MessageBox.Show("是否需要采集二级和三级类目?", "确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //嵌套-选择二级类目循环
                    //准备采集二级类目
                    //点击类目选择
                    Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('common-picker-header')[0].click()", webBrowser1);
                    int len_level2 = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('tree-menu common-menu tree-scroll-menu-level-2')[0].getElementsByTagName('li').length", webBrowser1);
                    for (int j = 0; j < len_level2; j++)
                    {
                        //点击二级类目
                        Browser.JS_CEFBrowser("document.getElementsByClassName('tree-menu common-menu tree-scroll-menu-level-2')[0].getElementsByTagName('li')[" + j + "].click()", webBrowser1);
                        //等待
                        Browser.WaitWebPageLoad(webBrowser1);
                        Browser.Delay(3000);
                        //采集
                        list.AddRange(Taobao.CaiJi_SouSuoPaiHang_Data(webBrowser1));

                        //嵌套-选择三级类目循环
                        //准备采集三级类目
                        //点击类目选择
                        Browser.JS_CEFBrowser_NoReturn("document.getElementsByClassName('common-picker-header')[0].click()", webBrowser1);
                        int len_level3 = Browser.JS_CEFBrowserToInt("document.getElementsByClassName('tree-menu common-menu tree-scroll-menu-level-3')[0].getElementsByTagName('li').length", webBrowser1);
                        for (int k = 0; k < len_level3; k++)
                        {
                            //点击二级类目
                            Browser.JS_CEFBrowser("document.getElementsByClassName('tree-menu common-menu tree-scroll-menu-level-3')[0].getElementsByTagName('li')[" + k + "].click()", webBrowser1);
                            //等待
                            Browser.WaitWebPageLoad(webBrowser1);
                            Browser.Delay(3000);
                            //采集
                            list.AddRange(Taobao.CaiJi_SouSuoPaiHang_Data(webBrowser1));

                        }
                    }
                }
            }

            return list;
        }
        #endregion

        #region RemoveRepeat 删除重复排行信息


        /// <summary>
        /// 删除重复排行信息
        /// </summary>
        /// <param name="list_temp"></param>
        /// <returns></returns>
        List<lh_rankinglist> RemoveRepeat(List<lh_rankinglist> list_temp)
        {
            //获取操作过的字段集合
            List<lh_rankinglist> list_ok = new List<lh_rankinglist>();

            int num = 0;

            //开始遍历清除重复数据
            //遍历要操作的集合
            foreach (lh_rankinglist obj in list_temp)
            {
                num++;
                //是否应该添加该字段
                bool isadd = true;
                //判断操作集合里是否有这个字段，如果没有则加入，如果有则跳过
                foreach (lh_rankinglist obj2 in list_ok)
                {
                    //如果有则跳出，不添加
                    if (obj.rkey == obj2.rkey)
                    {
                        isadd = false;
                        break;
                    }
                }
                //根据字段判断是否应该添加
                if (isadd)
                {
                    list_ok.Add(obj);
                }
            }
            return list_ok;
        }
        #endregion

        #endregion

        #endregion


        #region 行业类目管理功能

        #region btn_top_searchindex_Click 快速选中排行榜
        private void btn_top_searchindex_Click(object sender, EventArgs e)
        {

            //先关闭所有选中
            foreach (DataGridViewRow row in dgv_lh_rankinglist.Rows)
            {
                if (row.Index != -1)
                {
                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                    cbx.Value = null;
                }
            }
            //然后打开指定的项目
            int index1 = txt_top_search1.Text.ToInt();
            int index2 = txt_top_search2.Text.ToInt();

            foreach (DataGridViewRow row in dgv_lh_rankinglist.Rows)
            {
                if (row.Index != -1)
                {
                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (row.Index + 1 >= index1 && row.Index + 1 <= index2)
                    {
                        if (cbx.Value == null)
                        {
                            cbx.Value = true;
                        }
                    }
                }
            }

        }
        #endregion

        #region 批量关键词采集
        private void btn_caijibykeys_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要采集选择的关键词吗?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                //开始设置网页
                try
                {
                    list_yuanshi.Clear();
                    //显示市场行情网页
                    tabControl1.SelectedTab = tp_schq;
                    //找到选择行业的信息ID
                    int hid = Convert.ToInt32(cb_hangye.SelectedValue);
                    //根据行业ID查询搜索词排行榜
                    IList<lh_rankinglist> list = BLL2.lh_rankinglistManager.Search(1, 9999, "", "", hid, new DateTime(), new DateTime(), "  rid asc ");
                    //进入搜索分析 ，判断是否进入了搜索词
                    Taobao.Go_ShiChangHangQing_SouSuoFenXi(webBrowser1);
                    //正在采集的关键词位置
                    int indexx = 0;
                    //遍历所有搜索词，采集所有相关词数据
                    foreach (DataGridViewRow row in dgv_lh_rankinglist.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            if ((bool)cbx.FormattedValue)
                            {
                                lh_rankinglist rl = row.ToModel<lh_rankinglist>();
                                if (rl != null)
                                {
                                    indexx++;
                                    lbl_message.Text = "正在采集第 " + indexx + " 个关键词";
                                    //输入关键词，搜索
                                    //点击相关分析
                                    Taobao.Set_SouSuoFenXi_Key(webBrowser1, rl.rkey);
                                    //等待数据更新
                                    Taobao.DelayUpdateKey(webBrowser1);
                                    //选择搜索人气、支付转化率、在线商品数、商城点击占比、直通车参考价格--已经设置好
                                    //设置每页显示100条
                                    //循环采集5页
                                    //把采集的数据追加到集合中
                                    list_yuanshi.AddRange(Taobao.CaiJi_SouSuoFenXi_Data(webBrowser1, hid, rl.rid));
                                }
                            }
                        }
                    }
                    //展示采集的数据到表中，然后通过筛选后，保存数据
                    list_caozuo.Clear();
                    list_caozuo.AddRange(list_yuanshi);
                    dgv_key.DataSource = list_caozuo.ToDataTable(); ;
                    //切换到数据操作界面
                    tabControl1.SelectedTab = tp_keydata;
                    Manager.EmailSend("ourstoryzj@163.com", "数据采集完毕,共采集了" + list_caozuo.Count + "个关键词", "数据采集完毕了亲");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("批量采集数据失败" + ex.ToString());
                }

            }
            bind_rankinglist();
            MessageBox.Show("采集成功");
        }
        #endregion

        #region 排行榜去噪


        private void btn_clearzao2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(cb_zaoci2.SelectedValue);
                IList<yh_zaoci> list = BLL2.yh_zaociManager.Search(1, 50000, "", "", id, new DateTime(), new DateTime(), "");

                //获取表格中的数据
                IList<lh_rankinglist> list_dgv = dgv_lh_rankinglist.ToList<lh_rankinglist>();
                //重置操作list

                List<lh_rankinglist> list_test = new List<lh_rankinglist>();

                //为零则不删除，为1则删除
                //int state = 0;

                foreach (lh_rankinglist k in list_dgv)
                {

                    //设置关键词状态为正常0
                    //state = 0;
                    foreach (yh_zaoci zc in list)
                    {
                        try
                        {
                            if (k.rkey.IndexOf(zc.zname) > -1)
                            {
                                //设置关键词状态为删除1
                                BLL2.lh_rankinglistManager.Delete(k.rid);
                                //state = 1;
                                break;
                            }
                        }
                        catch
                        {
                            MessageBox.Show("去噪库出现问题");
                        }

                    }
                    //if (state == 0)
                    //    list_test.Add(k);
                }
                //dgv_lh_rankinglist.DataBindings.Clear();
                //dgv_lh_rankinglist.DataSource = list_test.ToDataTable();
                //dgv_lh_rankinglist.Refresh();
                bind_rankinglist();
                MessageBox.Show("去噪成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("去噪出现问题:" + ex.ToString());
            }
        }

        #endregion



        #region DGV行业表操作
        private void dgv_lh_hangye_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //如果点击页头
            if (e.RowIndex == -1)
            {
                //排序事件
                try
                {
                    //dgv1.Sort(dgv1.Columns[e.ColumnIndex], ListSortDirection.Descending);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("排序出错=========================" + ex.Message);
                }
            }
            else if (dgv_lh_hangye.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                //暂时不支持删除行业
                MessageBox.Show("暂时不支持删除行业");
                return;
                //lh_hangye zc = (Entity.lh_hangye)dgv_lh_hangye.CurrentRow.DataBoundItem;
                //if (zc != null)
                //{
                //    if (MessageBox.Show("确定要删除  【" + zc.hname + "】么?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //    {
                //        if (BLL2.lh_hangyeManager.Delete(zc.hid) == 1)
                //        {
                //            //删除二级数据
                //            //foreach (lh_hangye z in BLL2.lh_hangyeManager.Search(1, 9999, "", "", zc.zid, new DateTime(), new DateTime(), ""))
                //            //{
                //            //    BLL2.yh_zaociManager.Delete(z.zid);
                //            //}
                //            //MessageBox.Show("删除成功");
                //            //bind_hangye();

                //        }
                //        else
                //        {
                //            MessageBox.Show("删除失败");
                //        }
                //    }
                //}
            }
            else if (dgv_lh_hangye.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                //修改状态
                lh_hangye zc = dgv_lh_hangye.CurrentRow.ToModel<lh_hangye>();
                if (zc != null)
                {
                    zc.hstate = zc.hstate == "1" ? "2" : "1";
                    BLL2.lh_hangyeManager.Update(zc);
                    dgv_lh_hangye[e.ColumnIndex, e.RowIndex].Value = zc.hstate;
                    dgv_lh_hangye.Refresh();
                }
            }
        }

        private void dgv_lh_hangye_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value != null)
                {
                    if (dgv_lh_hangye.DataSource != null)
                    {
                        if (dgv_lh_hangye.Columns[e.ColumnIndex].Name.Equals("col_state"))
                        {
                            string name = e.Value.ToString();
                            e.Value = name == "1" ? "启用" : "禁用";
                        }
                        if (dgv_lh_hangye.Columns[e.ColumnIndex].Name.Equals("col_date"))
                        {
                            string temp = e.Value.ToString();
                            DateTime temp_date;
                            if (DateTime.TryParse(temp, out temp_date))
                            {
                                e.Value = temp_date.ToString("yyyy-MM-dd");
                            }
                        }
                    }
                }
            }
            catch 
            {
            }
        }

        private void dgv_lh_hangye_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                if (dgv_lh_hangye.CurrentCell.ColumnIndex == 0)
                {
                    lh_hangye zc = dgv_lh_hangye.CurrentRow.ToModel<lh_hangye>();
                    if (zc != null)
                    {
                        string name = dgv_lh_hangye.Rows[e.RowIndex].Cells[0].EditedFormattedValue == null ? zc.hname : dgv_lh_hangye.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString();
                        zc.hname = name;
                        BLL2.lh_hangyeManager.Update(zc);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("修改信息失败 " + ex.Message);
            }
        }

        private void dgv_lh_hangye_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv_lh_hangye.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv_lh_hangye.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);
        }


        #region btn_clear_zaocitxt_Click


        private void btn_clear_zaocitxt_Click(object sender, EventArgs e)
        {
            txt_rankinglist.Text = "";
        }



        #endregion

        #endregion

        #endregion

        #region 数据处理功能



        #region DGV 搜索词操作表格


        private void dgv_key_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Manager.dgv_add_hanghao(dgv_key, e);
        }
        private void dgv_key_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            Manager.dgv_set_selectall(dgv_key, e);
            if (e.RowIndex != -1)
            {
                if (dgv_key.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
                {

                    //修改状态
                    lh_keydata zc = dgv_key.CurrentRow.ToModel<lh_keydata>();
                    if (zc != null)
                    {
                        //如果是修改是否蓝海
                        if (e.ColumnIndex == 6)
                        {
                            zc.kbackup1 = zc.kbackup1 == "1" ? "2" : (zc.kbackup1 == "2" ? "0" : "1");
                            dgv_key[e.ColumnIndex, e.RowIndex].Value = zc.kbackup1;
                        }
                        else if (e.ColumnIndex == 7)
                        {
                            zc.kbackup2 = zc.kbackup2 == "1" ? "0" : "1";
                            dgv_key[e.ColumnIndex, e.RowIndex].Value = zc.kbackup2;
                        }
                        BLL2.lh_keydataManager.Update(zc);
                        dgv_key.Refresh();
                    }


                }
                else if (dgv_key.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    //判断一个关键词是否是假词
                    lh_keydata zc = dgv_key.CurrentRow.ToModel<lh_keydata>();
                    if (zc != null)
                    {
                        #region 采集一个关键词-bak



                        ////显示市场行情网页
                        //tabControl1.SelectedTab = tp_schq;
                        //Browser.Delay(500);
                        //string path = Manager.OpenFolderDialog("");
                        //path = CaiJiByKey(zc.kname, path);
                        ////list.ForEach(key_temp => BLL2.lh_keydataManager.Insert(key_temp));
                        //tabControl1.SelectedTab = tp_keydata;
                        //MessageBox.Show("数据采集成功");
                        ////path = path.Replace("\\\\","\\");
                        ////Manager.OpenProgram(@path);
                        #endregion

                        //显示网页
                        tabControl1.SelectedTab = tp_schq;

                        #region 采集并判断关键词bak

                        ////进入搜索分析
                        //Taobao.Go_ShiChangHangQing_SouSuoFenXi_GaiKuo(webBrowser1);
                        ////输入关键词，搜索
                        //Taobao.Set_SouSuoFenXi_Key(webBrowser1, zc.kname);
                        ////等待数据更新
                        //CS.Taobao.DelayUpdateKey2(webBrowser1, false);
                        ////点击搜索人气
                        ////TaoBao.SCHQ_Click_SSRQ(webBrowser1);
                        //CS.Taobao.SCHQ_Click_SSRQ(webBrowser1);

                        //List<decimal> list_RQ = CS.Taobao.GetKeyData10(webBrowser1);
                        ////判断10组数字
                        //int res_RQ = CS.Taobao.judge_SSRQ(list_RQ);

                        //zc.kremark = "搜索人气："+ list_RQ.ToStringZJ()+";" + zc.kremark;




                        ////转化率思路:
                        ////以第一个数据为准,如果大部分是高于第一个则是好词,如果是低于第一个则是坏词
                        ////如果第一个或前几个是0,有数据的第一个为准,如果大部分高于,则是大好词,如果后面还有0的则肯定是假词
                        ////如果都为0则肯定是假词

                        ////点击支付转化率
                        //CS.Taobao.SCHQ_Click_ZFZHL(webBrowser1);
                        ////获取数据
                        //List<decimal> list_ZFZHL = CS.Taobao.GetKeyData10(webBrowser1);
                        ////判断数据
                        //int res_ZFZHL = CS.Taobao.judge_SSRQ(list_ZFZHL);
                        //zc.kremark = "转化率：" + list_ZFZHL.ToStringZJ() + ";" + zc.kremark;


                        ////判断类目
                        ////点击类目构成
                        //Browser.JS_CEFBrowser("document.getElementsByClassName('oui-tab-switch-item')[2].click()", webBrowser1);
                        //Browser.Delay(1000);
                        ////获取类目名称
                        //string leimu = Browser.JS_CEFBrowser("document.getElementsByClassName('oui-tab-switch-item-custom oui-tab-switch-item-custom-active default')[0].getElementsByClassName('title')[0].innerText", webBrowser1);
                        //zc.kremark = "类目：" + leimu + ";" + zc.kremark;

                        ////点击概括，然后才可以继续判断下一个词
                        //Browser.JS_CEFBrowser("document.getElementsByClassName('oui-tab-switch-item')[0].click()", webBrowser1);


                        ////处理结果
                        //if (res_RQ == 0 || res_ZFZHL==0)
                        //{
                        //    zc.kbackup1 = "0";
                        //    zc.kbackup2 = "1";
                        //    zc.kremark = "假词;" + zc.kremark;

                        //}
                        //else if (res_RQ == 2 && res_ZFZHL==2)
                        //{
                        //    zc.kbackup1 = "2";
                        //    zc.kbackup2 = "0";
                        //    zc.kremark = "大好词;" + zc.kremark;
                        //}
                        //else if (res_RQ == 1 || res_ZFZHL == 1)
                        //{
                        //    zc.kbackup1 = "1";
                        //    zc.kbackup2 = "0";
                        //    zc.kremark = "待检查词;" + zc.kremark;
                        //}


                        //BLL2.lh_keydataManager.Update(zc);

                        #endregion

                        zc = CS.Taobao.JudgeKey(zc, webBrowser1);

                        dgv_key[6, e.RowIndex].Value = zc.kbackup1;
                        dgv_key[7, e.RowIndex].Value = zc.kbackup2;
                        dgv_key[2, e.RowIndex].Value = zc.kremark;
                        dgv_key.Refresh();

                    }
                }

            }
        }







        private void dgv_key_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value != null)
                {
                    if (dgv_key.DataSource != null)
                    {
                        if (dgv_key.Columns[e.ColumnIndex].Name.Equals("col_zhongdian"))
                        {
                            string name = e.Value.ToString();
                            //e.Value = name == "1" ? "优质" :(name == "2"?"重点":"普通");
                            if (name == "1")
                            {
                                e.Value = "优质";
                                //dgv_key.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(214, 157, 133);
                                //dgv_key.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
                            }
                            else if (name == "2")
                            {
                                e.Value = "重点";
                                //dgv_key.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(87, 166, 74);
                                //dgv_key.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.FromArgb(30, 30, 30);
                            }
                            else
                            {
                                e.Value = "普通";
                                //dgv_key.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                //dgv_key.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                            }
                        }
                        if (dgv_key.Columns[e.ColumnIndex].Name.Equals("col_state2"))
                        {
                            string name = e.Value.ToString();

                            //e.Value = name == "1" ? "优质" :(name == "2"?"重点":"普通");

                            if (name == "1")
                            {
                                //DataGridViewLinkColumn linkcolumn = dgv_key.Columns[e.ColumnIndex] as DataGridViewLinkColumn;
                                //linkcolumn.TrackVisitedState = false;
                                e.Value = "ok";
                                //linkcolumn.LinkColor = Color.Green;
                            }
                            else
                            {
                                //DataGridViewLinkColumn linkcolumn = dgv_key.Columns[e.ColumnIndex] as DataGridViewLinkColumn;
                                //linkcolumn.TrackVisitedState = false;
                                e.Value = "未处理";
                                //linkcolumn.LinkColor = Color.Red;
                            }
                        }
                        if (dgv_key.Columns[e.ColumnIndex].Name.Equals("col_kdate"))
                        {
                            string temp = e.Value.ToString();
                            DateTime temp_date;
                            if (DateTime.TryParse(temp, out temp_date))
                            {
                                e.Value = temp_date.ToString("yyyy-MM-dd");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgv_key_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                //判断如果是第一列表格点击了
                if (dgv_key.CurrentCell.ColumnIndex == 1)
                {
                    lh_keydata key = dgv_key.Rows[e.RowIndex].ToModel<lh_keydata>();
                    Manager.OpenProgram(Taobao.Go_Sale_Url(key.kname));
                }
            }
        }

        private void dgv_key_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            //修改表格内容
            try
            {
                //判断是否修改了？如果没有修改则跳出
                if (dgv_key.Rows[e.RowIndex].Cells[2].EditedFormattedValue == null)
                    return;
                //判断如果是第一列表格点击了
                if (dgv_key.CurrentCell.ColumnIndex == 2)
                {
                    lh_keydata zc = dgv_key.CurrentRow.ToModel<lh_keydata>();
                    if (zc != null)
                    {
                        string name = dgv_key.Rows[e.RowIndex].Cells[2].EditedFormattedValue == null ? zc.kremark : dgv_key.Rows[e.RowIndex].Cells[2].EditedFormattedValue.ToString();
                        zc.kremark = name;
                        BLL2.lh_keydataManager.Update(zc);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("修改信息失败 " + ex.Message);
            }
        }

        #endregion


        #region btn_keychecks_Click
        private void btn_keychecks_Click(object sender, EventArgs e)
        {

            //先关闭所有选中
            foreach (DataGridViewRow row in dgv_key.Rows)
            {
                if (row.Index != -1)
                {
                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                    cbx.Value = null;
                }
            }
            //然后打开指定的项目
            int index1 = txt_key_check1.Text.ToInt();
            int index2 = txt_key_check2.Text.ToInt();

            foreach (DataGridViewRow row in dgv_key.Rows)
            {
                if (row.Index != -1)
                {
                    DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (row.Index + 1 >= index1 && row.Index + 1 <= index2)
                    {
                        if (cbx.Value == null)
                        {
                            cbx.Value = true;
                        }
                    }
                }
            }

        }
        #endregion

        #region 批量采集判断关键词

        /// <summary>
        /// 批量采集勾选蓝海词图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_downtop3_Click(object sender, EventArgs e)
        {

            #region bak采集销量1000商品


            //try
            //{
            //    lh_keydata kd = null;
            //    if (MessageBox.Show("是否要采集所有勾选关键词图片?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //    {
            //        string path = Manager.OpenFolderDialog("");
            //        List<lh_keydata> list = new List<lh_keydata>();
            //        foreach (DataGridViewRow row in dgv_key.Rows)
            //        {
            //            if (row.Index != -1)
            //            {
            //                DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
            //                kd = row.ToModel<lh_keydata>();
            //                //判断是否勾选，如果有勾选则留下数据
            //                if ((bool)cbx.FormattedValue)
            //                {
            //                    CaiJiByKey(kd.kname, path);
            //                }
            //            }
            //        }
            //    }
            //    MessageBox.Show("批量采集成功");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("删除数据出错" + ex.ToString());
            //}

            #endregion

            //批量采集判断关键词
            if (MessageBox.Show("确定要判断选择的关键词吗?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                //开始设置网页
                try
                {
                    //list_yuanshi.Clear();
                    //显示市场行情网页
                    tabControl1.SelectedTab = tp_schq;

                    int count = 0;
                    //遍历所有搜索词，采集所有相关词数据
                    foreach (DataGridViewRow row in dgv_key.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            if ((bool)cbx.FormattedValue)
                            {
                                lh_keydata kd = row.ToModel<lh_keydata>();
                                if (kd != null)
                                {
                                    kd = CS.Taobao.JudgeKey(kd, webBrowser1);
                                    //更新显示的数据
                                    row.Cells[6].Value = kd.kbackup1;
                                    row.Cells[7].Value = kd.kbackup2;
                                    row.Cells[2].Value = kd.kremark;
                                    dgv_key.Refresh();
                                    count++;
                                }
                            }
                        }
                    }

                    //切换到数据操作界面
                    tabControl1.SelectedTab = tp_keydata;
                    Manager.EmailSend("ourstoryzj@163.com", "数据判断完毕,共判断了" + count + "个关键词", "数据采集完毕了亲");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("批量采集数据失败" + ex.ToString());
                }

            }
            MessageBox.Show("采集成功");

        }
        #endregion

        #endregion


    }

}


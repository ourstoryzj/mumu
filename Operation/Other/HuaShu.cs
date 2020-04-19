using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;

using Operation.CS;
using System.IO;
using System.Diagnostics;
using Common;

namespace Operation.Other
{
    public partial class HuaShu : Form
    {

        //话术id
        int hid = 0;

        public HuaShu()
        {
            InitializeComponent();
            bind();
            bind_typelist();
            bind_cb();
        }



        #region bind

        void bind()
        {
            dgv1.DataSource = BLL.huashuManager.Search(1, 1000, "", "", "", new DateTime(), new DateTime());
            //dgv1.RowPostPaint += Common.DataGridViewHelper.Dgv_RowPostPaint;
            //dgv1.CellContentClick += Common.DataGridViewHelper.Dgv_CellContentClick;
        }

        void bind_cb()
        {
            IList<huashu> list = BLL.huashuManager.Search(1, 1000, "", "", "0", new DateTime(), new DateTime());
            cb_huashutype.DataSource = list;
            cb_huashutype.DisplayMember = "htitle";
            cb_huashutype.ValueMember = "hid";
            cb_typesearch.DataSource = list;
            cb_typesearch.DisplayMember = "htitle";
            cb_typesearch.ValueMember = "hid";
            cb_typesearch.ToAddItemOne();
        }

        void bind_typelist()
        {
            dgv_type.DataSource = BLL.huashuManager.Search(1, 1000, "", "", "0", new DateTime(), new DateTime());
            //dgv_type.RowPostPaint += Common.DataGridViewHelper.Dgv_RowPostPaint;
            //dgv_type.CellContentClick += Common.DataGridViewHelper.Dgv_CellContentClick;
        }




        #endregion

        #region 话术列表


        #region datagridview 方法

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
                    huashu hs = (huashu)dgv1.CurrentRow.DataBoundItem;

                     if (colname == "col_state")
                    {
                        #region 修改状态
                        hs.hstate = hs.hstate == "1" ? "2" : "1";
                        BLL.huashuManager.Update(hs);
                        dgv1.ToClearChecked();
                        #endregion
                    }
                    else if (colname == "col_edit")
                    {
                        #region 修改状态
                        //bindedit(hs);
                        if (MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            BLL.huashuManager.Delete(hs.hid);
                            dgv1.ToAfterDelete(e.RowIndex);
                            bind_cb();
                        }
                        #endregion
                    }


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgv1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //如果不是首行
                if (e.RowIndex > -1)
                {
                    huashu sr = (huashu)dgv1.CurrentRow.DataBoundItem;
                    tabControl1.SelectedTab = tabPage3;
                    bindedit(sr);
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
                string colname = dgv1.Columns[dgv1.CurrentCell.ColumnIndex].Name;
                if (colname.Equals("col_title") || colname.Equals("col_sort") || colname.Equals("col_context"))
                {
                    huashu hs = (huashu)dgv1.CurrentRow.DataBoundItem;
                    if (hs != null)
                    {
                        string htitle = dgv1["col_title", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_title", e.RowIndex].EditedFormattedValue.ToString();
                        string hcontext = dgv1["col_context", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_context", e.RowIndex].EditedFormattedValue.ToString();
                        string hsort = dgv1["col_sort", e.RowIndex].EditedFormattedValue == null ? "" : dgv1["col_sort", e.RowIndex].EditedFormattedValue.ToString();
                        hs.htitle = htitle;
                        hs.hsort = hsort.ToInt();
                        hs.hcontext = hcontext;
                        BLL.huashuManager.Update(hs);
                        //dgv_type.ToClearChecked();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
        }
        #endregion


        #endregion


        #region 其他功能


        #region btn_delete_Click
        private void btn_delete_Click(object sender, EventArgs e)
        {
            List<int> list = dgv1.GetDeleteCheckedIndex();
            if (list.Count > 0)
            {
                foreach (int i in list)
                {
                    huashu hs = (huashu)dgv1.Rows[i].DataBoundItem;
                    BLL.huashuManager.Delete(hs.hid);
                    dgv1.ToAfterDelete(i);
                }
                "删除成功".ToShow();
            }
            else
            {
                "请选择需要删除的信息".ToShow();
            }

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

            string key = txt_key.Text.Trim();

            string _typetemp = cb_typesearch.Text;
            if (_typetemp == "请选择")
                _typetemp = "";
            else 
                 _typetemp = cb_typesearch.SelectedValue.ToString();

            string state = cb_state1.Text;
            if (state == "启用")
                state = "1";
            else if (state == "禁用")
                state = "2";
            else
                state = "";

            string sort = cb_sort.Text;
            if (sort == "请选择")
                sort = "0";

            dgv1.DataSource = BLL.huashuManager.Search2(1, 100000, key, state, _typetemp,sort.ToInt(), new DateTime(), new DateTime(),"  hid desc ");

        }
        #endregion

        #region btn_weifahuo_Click
        private void btn_weifahuo_Click(object sender, EventArgs e)
        {
            bind();
        }
        #endregion

        #region btn_add_Click
        private void btn_add_Click(object sender, EventArgs e)
        {
            hid = 0;
            reset();
            tabControl1.SelectedTab = tabPage3;
        }
        #endregion

        #endregion 


        #endregion

        #region 添加话术
        #region btn_save_Click


        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string fid = cb_huashutype.SelectedValue != null ? cb_huashutype.SelectedValue.ToString() : "";
                if (string.IsNullOrEmpty(fid))
                {
                    "请选择类型".ToShow();
                    return;
                }
                string context = txt_context.Text.Trim();
                string title = txt_name.Text.Trim();
                string sort = txt_sort.Text.Trim();
                string email = cb_email.Text == "是" ? "1" : "2";
                string state = cb_state.Text == "启用" ? "1" : "2";

                huashu hs = new huashu();
                if (hid != 0)
                {
                    hs = BLL.huashuManager.SearchByID(hid);
                }

                hs.hcontext = context;
                hs.hcount = 0;
                hs.hdate = DateTime.Now;
                hs.hfid = fid.ToInt();
                hs.hsendemail = email;
                hs.hsort = sort.ToInt();
                hs.hstate = state;
                hs.htitle = title;
                if (hid == 0)
                    BLL.huashuManager.Insert(hs);
                else
                    BLL.huashuManager.Update(hs);
                "保存成功".ToShow();
                bind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存错误" + ex.ToString());
            }
        }
        #endregion

        #region bindedit
        void bindedit(huashu hs)
        {
            tabControl1.SelectedTab = tabPage3;
            if (hs != null)
            {
                cb_huashutype.ToSelectComboBoxItem(BLL.huashuManager.SearchByID(hs.hfid).htitle);

                txt_context.Text = hs.hcontext;
                txt_name.Text = hs.htitle;
                txt_sort.Text = hs.hsort.ToString();
                cb_email.Text = hs.hsendemail == "1" ? "是" : "否";
                cb_state.Text = hs.hstate == "1" ? "启用" : "禁用";
                lbl_count.Text = hs.hcount.ToString();
                lbl_date.Text = hs.hdate.ToString();

                hid = hs.hid;
            }
        }
        #endregion

        #region reset
        void reset()
        {
            tabControl1.SelectedTab = tabPage3;

            cb_huashutype.Text = "请选择";

            txt_context.Text = "";
            txt_name.Text = "";
            txt_sort.Text = "1000";
            cb_email.Text = "请选择";
            cb_state.Text = "请选择";
            lbl_count.Text = "";
            lbl_date.Text = "";

            hid = 0;
        }
        #endregion 

        #endregion

        /*2020年4月14日 17:33:05新加*/

        #region 添加话术类型

        private void btn_typesave_Click(object sender, EventArgs e)
        {
            string name = txt_typename.Text.Trim();
            string temp_sort = txt_typesort.Text.Trim();
            int sort = temp_sort.ToInt();
            string state = cb_typestate.Text == "启用" ? "1" : "2";
            huashu hs = new huashu();
            hs.hfid = 0;
            hs.hdate = DateTime.Now;
            hs.hsort = sort;
            hs.hstate = state;
            hs.htitle = name;
            hs.hcount = 1;

            BLL.huashuManager.Insert(hs);
            "保存成功".ToShow();
            txt_typename.Text = "";
            txt_typesort.Text = "1000";
            cb_typestate.Text = "启用";
            bind_typelist();
            bind_cb();
        }
        #endregion

        #region 话术类型列表
        private void btn_typeadd_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tp_typeadd;
        }



        private void dgv_type_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //DataGridView dgv_type = (DataGridView)sender;
                Common.DataGridViewHelper dgv_type = (Common.DataGridViewHelper)sender;
                //如果不是首行
                if (e.RowIndex > -1)
                {
                    string colname = dgv_type.Columns[e.ColumnIndex].Name;
                    huashu hs = (huashu)dgv_type.CurrentRow.DataBoundItem;
                    if (colname == "col_typestate")
                    {
                        #region 修改状态
                        hs.hstate = hs.hstate == "1" ? "2" : "1";
                        BLL.huashuManager.Update(hs);
                        dgv_type.ToClearChecked();
                        bind_cb();
                        #endregion
                    }
                    else if (colname == "col_del")
                    {
                        #region 修改状态
                        if (MessageBox.Show("确定要删除吗?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            BLL.huashuManager.Delete(hs.hid);
                            dgv_type.ToAfterDelete(e.RowIndex);
                            bind_cb();
                        }
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_type_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (dgv_type.DataSource != null)
                {

                    if (dgv_type.Columns[e.ColumnIndex].Name.Equals("col_typestate"))
                    {
                        string name = e.Value.ToString();
                        if (name == "1")
                        {
                            e.Value = "启用";
                            e.CellStyle.ForeColor = Color.Green;
                        }
                        else
                        {
                            e.Value = "禁用";
                            e.CellStyle.ForeColor = Color.Red;
                        }

                    }
                }
            }
        }

        private void dgv_type_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                string colname = dgv_type.Columns[dgv_type.CurrentCell.ColumnIndex].Name;
                if (colname.Equals("col_typename") || colname.Equals("col_typesort"))
                {
                    huashu hs = (huashu)dgv_type.CurrentRow.DataBoundItem;
                    if (hs != null)
                    {
                        string htitle = dgv_type["col_typename", e.RowIndex].EditedFormattedValue == null ? "" : dgv_type["col_typename", e.RowIndex].EditedFormattedValue.ToString();
                        string hsort = dgv_type["col_typesort", e.RowIndex].EditedFormattedValue == null ? "" : dgv_type["col_typesort", e.RowIndex].EditedFormattedValue.ToString();
                        hs.htitle = htitle;
                        hs.hsort = hsort.ToInt();
                        BLL.huashuManager.Update(hs);
                        //dgv_type.ToClearChecked();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToLog();
            }
        }



        #endregion


    }


}

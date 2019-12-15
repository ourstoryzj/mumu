using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using System.Diagnostics;

namespace excel_operation.TaoBao
{
    public partial class TB_ZaoCi : Form
    {
        public TB_ZaoCi()
        {
            InitializeComponent();
            dgv1.AutoGenerateColumns = false;
            //不显示空白行
            dgv1.AllowUserToAddRows = false;
            dgv2.AutoGenerateColumns = false;
            //不显示空白行
            dgv2.AllowUserToAddRows = false;

            bind();
        }

        #region Bind
        void bind()
        {
            IList<Entity.yh_zaoci> list = BLL2.yh_zaociManager.Search(1, 100, "", "", 0, new DateTime(), new DateTime(), "");
            dgv1.DataSource = list;
            cb_type.DataSource = list;
            cb_type.DisplayMember = "zname";
            cb_type.ValueMember = "zid";
        }

        /// <summary>
        /// 绑定二级数据
        /// </summary>
        void bind2()
        {
            try
            {
                int zid = Convert.ToInt32(cb_type.SelectedValue);
                IList<yh_zaoci> list = BLL2.yh_zaociManager.Search(1, 9999, "", "", zid, new DateTime(), new DateTime(), "");
                dgv2.DataSource = list;
            }
            catch (Exception e)
            {
                //MessageBox.Show("绑定数据失败" + e.ToString());
            }
        }

        #endregion

        #region btn_fuadd_Click
        private void btn_fuadd_Click(object sender, EventArgs e)
        {
            string name = txt_funame.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入正确的名称");
                txt_funame.Focus();
                return;
            }
            else
            {
                yh_zaoci zc = new yh_zaoci();
                zc.zname = name;
                zc.zdate = DateTime.Now;
                zc.zsort = 100;
                zc.zstate = "1";
                zc.gtid = 0;
                BLL2.yh_zaociManager.Insert(zc);
                bind();
            }
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
                        if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_state"))
                        {
                            string name = e.Value.ToString();
                            e.Value = name == "1" ? "启用" : "禁用";
                        }
                        if (dgv1.Columns[e.ColumnIndex].Name.Equals("col_date"))
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
                Debug.WriteLine("======================================================================");
                Debug.WriteLine("网址：" + Browser.urlstr);
                Debug.WriteLine(DateTime.Now.ToString());
                Debug.WriteLine("信息绑定失败：" + ex.Message);
            }
        }
        #endregion

        #region dgv1_CellContentClick
        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
            else if (dgv1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                yh_zaoci zc = (Entity.yh_zaoci)dgv1.CurrentRow.DataBoundItem;
                if (zc != null)
                {
                    if (MessageBox.Show("确定要删除  【" + zc.zname + "】么?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (BLL2.yh_zaociManager.Delete(zc.zid) == 1)
                        {
                            //删除二级数据
                            foreach (yh_zaoci z in BLL2.yh_zaociManager.Search(1, 9999, "", "", zc.zid, new DateTime(), new DateTime(), ""))
                            {
                                BLL2.yh_zaociManager.Delete(z.zid);
                            }
                            MessageBox.Show("删除成功");
                            bind();

                        }
                        else
                        {
                            MessageBox.Show("删除失败");
                        }
                    }
                }
            }
            else if (dgv1.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                yh_zaoci zc = (Entity.yh_zaoci)dgv1.CurrentRow.DataBoundItem;
                if (zc != null)
                {
                    zc.zstate = zc.zstate == "1" ? "2" : "1";
                    BLL2.yh_zaociManager.Update(zc);
                    bind();
                }
            }

        }

        #endregion

        #region dgv1_RowPostPaint
        //添加行号
        private void dgv1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv1.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);
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
                if (dgv1.CurrentCell.ColumnIndex == 0 || dgv1.CurrentCell.ColumnIndex == 1)
                {
                    yh_zaoci zc = (yh_zaoci)dgv1.CurrentRow.DataBoundItem;
                    if (zc != null)
                    {
                        string name = dgv1.Rows[e.RowIndex].Cells[0].EditedFormattedValue == null ? zc.zname : dgv1.Rows[e.RowIndex].Cells[0].EditedFormattedValue.ToString();
                        int sort = dgv1.Rows[e.RowIndex].Cells[1].EditedFormattedValue == null ? zc.zsort : Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells[1].EditedFormattedValue);
                        zc.zname = name;
                        zc.zsort = sort;

                        BLL2.yh_zaociManager.Update(zc);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("修改信息失败 " + ex.Message);
            }
        }

        #endregion

        #region txt_names_Click
        private void txt_names_Click(object sender, EventArgs e)
        {
            if (txt_names.Text == "请在此输入噪词")
                txt_names.Text = "";
        }

        #endregion

        #region btn_add_Click
        /// <summary>
        /// 添加噪词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_add_Click(object sender, EventArgs e)
        {
            string names = txt_names.Text;
            if (!string.IsNullOrEmpty(names))
            {
                string[] datas = System.Text.RegularExpressions.Regex.Split(names, "\n", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                yh_zaoci zc = new yh_zaoci();
                zc.gtid = Convert.ToInt32(cb_type.SelectedValue);
                zc.zdate = DateTime.Now;
                zc.zsort = 100;
                zc.zstate = "1";
                foreach (string temp in datas)
                {
                    if (!string.IsNullOrEmpty(temp))
                    {
                        zc.zname = temp.Replace("\r", ""); ;
                        BLL2.yh_zaociManager.Insert(zc);
                    }
                }
                MessageBox.Show("噪词添加成功");
                bind2();
            }
        }
        #endregion

        #region cb_type_SelectedIndexChanged
        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind2();
        }
        #endregion

        #region dgv2_CellContentClick
        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //如果点击页头
            if (e.RowIndex == -1)
            {
                //如果是全选
                if (e.ColumnIndex == 0)
                {
                    foreach (DataGridViewRow row in dgv2.Rows)
                    {
                        if (row.Index != -1)
                        {
                            DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                            cbx.Value = true;
                        }
                    }
                }

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
            else if (dgv1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                yh_zaoci zc = (Entity.yh_zaoci)dgv2.CurrentRow.DataBoundItem;
                if (zc != null)
                {
                    if (MessageBox.Show("确定要删除  【" + zc.zname + "】么?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (BLL2.yh_zaociManager.Delete(zc.zid) == 1)
                        {
                            MessageBox.Show("删除成功");
                            bind();
                        }
                        else
                        {
                            MessageBox.Show("删除失败");
                        }
                    }
                }
            }
            else if (dgv1.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                yh_zaoci zc = (Entity.yh_zaoci)dgv2.CurrentRow.DataBoundItem;
                if (zc != null)
                {
                    zc.zstate = zc.zstate == "1" ? "2" : "1";
                    BLL2.yh_zaociManager.Update(zc);
                }
            }
        }
        #endregion

        #region dgv2_CellFormatting
        private void dgv2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value != null)
                {
                    if (dgv1.DataSource != null)
                    {
                        if (dgv2.Columns[e.ColumnIndex].Name.Equals("col_state1"))
                        {
                            string name = e.Value.ToString();
                            e.Value = name == "1" ? "启用" : "禁用";
                        }
                        if (dgv2.Columns[e.ColumnIndex].Name.Equals("col_date1"))
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
                Debug.WriteLine("======================================================================");
                Debug.WriteLine("网址：" + Browser.urlstr);
                Debug.WriteLine(DateTime.Now.ToString());
                Debug.WriteLine("信息绑定失败：" + ex.Message);
            }
        }
        #endregion

        #region dgv2_CellParsing
        private void dgv2_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                if (dgv2.CurrentCell.ColumnIndex == 1)
                {
                    yh_zaoci zc = (yh_zaoci)dgv2.CurrentRow.DataBoundItem;
                    if (zc != null)
                    {
                        string name = dgv2.Rows[e.RowIndex].Cells[1].EditedFormattedValue == null ? zc.zname : dgv2.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
                        zc.zname = name;

                        BLL2.yh_zaociManager.Update(zc);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("修改信息失败 " + ex.Message);
            }
        }
        #endregion

        #region dgv2_RowPostPaint
        private void dgv2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //添加行号
            SolidBrush b = new SolidBrush(this.dgv1.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgv2.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + 5);
        }
        #endregion

        #region btn_del_Click
        private void btn_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要删除所有勾选噪词?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dgv2.Rows)
                {
                    if (row.Index != -1)
                    {
                        DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                        if ((bool)cbx.FormattedValue)
                        {
                            yh_zaoci zc = (Entity.yh_zaoci)row.DataBoundItem;
                            if (zc != null)
                            {
                                BLL2.yh_zaociManager.Delete(zc.zid);
                            }
                        }
                    }
                }
            }
            bind2();
            MessageBox.Show("删除成功");
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txt_funame_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

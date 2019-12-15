using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entity;

namespace excel_operation
{
    public partial class fanxianFrom : Form
    {
        public fanxianFrom()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            bind();
            bind_dianpu();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string id = lbl_id.Text.Trim();
                string account = txt_account.Text.Trim();
                string num = txt_num.Text.Trim();
                string zhifubao = txt_zhifubao.Text.Trim();
                string remark = txt_remark.Text.Trim();
                string dianpu = cb_dianpu.SelectedValue != null ? cb_dianpu.SelectedValue.ToString() : "";
                string state = cb_state.Text == "未返现" ? "1" : "2";
                int num_temp = 2;

                fanxian fx = new fanxian();

                if (!string.IsNullOrEmpty(id))
                {
                    fx = BLL2.fanxianManager.SearchByfx_id(Convert.ToInt32(id));
                }

                if (string.IsNullOrEmpty(zhifubao))
                {
                    MessageBox.Show("请输入支付宝账号！");
                    txt_zhifubao.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(num))
                {
                    MessageBox.Show("请输入返现金额！");
                    txt_num.Focus();
                    return;
                }
                else if (!int.TryParse(num, out num_temp))
                {
                    MessageBox.Show("请输入正确的返现金额！");
                    txt_num.Focus();
                    txt_num.SelectAll();
                    return;
                }
                if (string.IsNullOrEmpty(dianpu))
                {
                    MessageBox.Show("请选择店铺！");
                    cb_dianpu.Focus();
                    return;
                }

                fx.dpid = dianpu;
                fx.fx_account = account;
                fx.fx_num = num_temp;
                fx.fx_remark = remark;
                fx.fx_state = state;
                fx.fx_zhifubao = zhifubao;

                int res = 0;
                if (string.IsNullOrEmpty(lbl_id.Text.Trim()))
                {
                    fx.fx_date = DateTime.Now;
                    res = BLL2.fanxianManager.Insert(fx);
                    bind();
                }
                else
                {
                    string rIndex = lbl_RowIndex.Text.Trim();
                    string cIndex = lbl_CellIndex.Text.Trim();
                    int ci;
                    int ri;
                    if (int.TryParse(cIndex, out ci) && int.TryParse(rIndex, out ri))
                    {
                        string temp_state = dataGridView1.Rows[ri].Cells[4].Value.ToString();
                        if (temp_state == "1" && fx.fx_state == "2")
                        {
                            fx.fx_date2 = DateTime.Now;
                        }

                        res = BLL2.fanxianManager.Update(fx);
                        if (res == 1)
                        {
                            dataGridView1.Rows[ri].Cells[0].Value = fx.fx_id;
                            dataGridView1.Rows[ri].Cells[1].Value = fx.fx_account;
                            dataGridView1.Rows[ri].Cells[2].Value = fx.fx_zhifubao;
                            dataGridView1.Rows[ri].Cells[3].Value = fx.fx_num;
                            dataGridView1.Rows[ri].Cells[4].Value = fx.fx_state == "1" ? "未返现" : "已返现";
                            dataGridView1.Rows[ri].Cells[5].Value = fx.fx_remark;
                            dataGridView1.Rows[ri].Cells[6].Value = fx.fx_date.ToString();
                        }
                    }
                }
                if (res == 1)
                {
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("保存失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            clears();
        }

        void bind()
        {
            IList<fanxian> list = BLL2.fanxianManager.SearchAll();
            dataGridView1.DataSource = list;
        }

        void bind_dianpu()
        {

            IList<dianpu> list_dp = BLL2.dianpuManager.SearchAll();
            cb_dianpu.DataSource = list_dp;
            IList<dianpu> list_dp2 = BLL2.dianpuManager.SearchAll();
            dianpu dp = new dianpu();
            dp.dpname = "请选择";
            dp.dpid = 0;
            list_dp2.Insert(0, dp);
            cb_dianpu2.DataSource = list_dp2;

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            date_1.Format = DateTimePickerFormat.Custom;
            date_1.CustomFormat = "请选择";
            date_2.Format = DateTimePickerFormat.Custom;
            date_2.CustomFormat = "请选择";
            date_3.Format = DateTimePickerFormat.Custom;
            date_3.CustomFormat = "请选择";
            date_4.Format = DateTimePickerFormat.Custom;
            date_4.CustomFormat = "请选择";
        }


        void clears()
        {
            lbl_date1.Text = "";
            lbl_date2.Text = "";
            lbl_id.Text = "";
            txt_account.Text = "";
            txt_remark.Text = "";
            txt_zhifubao.Text = "";
            txt_remark.Text = "";
            lbl_CellIndex.Text = "";
            lbl_RowIndex.Text = "";

        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clears();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            string id = lbl_id.Text.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("请选择一条信息");
                return;
            }
            else
            {
                DialogResult resault = MessageBox.Show("确定要删除他么？亲", "删除", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (resault == DialogResult.OK)
                {
                    if (BLL2.fanxianManager.Delete(Convert.ToInt32(id)) == 1)
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

        private void date_1_CloseUp(object sender, EventArgs e)
        {
            //date_1.Format = DateTimePickerFormat.Long;
            (sender as DateTimePicker).Format = DateTimePickerFormat.Long;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string key = txt_key.Text.Trim();
            DateTime start = date_1.Text == "请选择" ? new DateTime() : Convert.ToDateTime(date_1.Text);
            DateTime end = date_2.Text == "请选择" ? new DateTime() : Convert.ToDateTime(date_2.Text);
            DateTime start2 = date_3.Text == "请选择" ? new DateTime() : Convert.ToDateTime(date_3.Text);
            DateTime end2 = date_4.Text == "请选择" ? new DateTime() : Convert.ToDateTime(date_4.Text);
            int dp = Convert.ToInt32(cb_dianpu2.SelectedValue);
            string state = cb_state2.Text == "请选择" ? "" : (cb_state2.Text == "未返现" ? "1" : "2");
            IList<fanxian> list = BLL2.fanxianManager.Search(1,1,key, state,dp, start, end, start2, end2, "");
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int temp = e.ColumnIndex;
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                int idid;
                if (temp == 4)
                {
                    if (int.TryParse(id, out idid))
                    {
                        fanxian fx = BLL2.fanxianManager.SearchByfx_id(idid);
                        if (fx.fx_state == "1")
                        {
                            fx.fx_state = fx.fx_state == "1" ? "2" : "1";
                            fx.fx_date2 = DateTime.Now;
                            if (BLL2.fanxianManager.Update(fx) == 1)
                            {
                                if (fx.fx_state == "1")
                                {
                                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "未返现";
                                }
                                else if (fx.fx_state == "2")
                                {
                                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "已返现";
                                }

                            }
                            else
                            {
                                MessageBox.Show("系统出错，请联系我");
                            }
                        }
                        else
                        {
                            MessageBox.Show("该返现已经处理，请慎重操作！");
                        }
                    }
                }
                else if (temp == 0)
                {
                    //object kdcode = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    //if (kdcode != null)
                    //{
                    //    if (!string.IsNullOrEmpty(kdcode.ToString()))
                    //    {
                    //        System.Diagnostics.Process.Start("http://www.kiees.cn/yto.php?wen=" + kdcode);

                    //    }
                    //}
                }
                else
                {
                    if (int.TryParse(id, out idid))
                    {
                        Entity.fanxian sh = BLL2.fanxianManager.SearchByfx_id(idid);
                        txt_account.Text = sh.fx_account;
                        txt_remark.Text = sh.fx_remark;
                        lbl_id.Text = sh.fx_id.ToString();
                        lbl_date1.Text = sh.fx_date.ToString();
                        lbl_date2.Text = sh.fx_date2.ToString();
                        lbl_CellIndex.Text = e.ColumnIndex.ToString();
                        lbl_RowIndex.Text = e.RowIndex.ToString();
                        txt_zhifubao.Text = sh.fx_zhifubao;

                        try
                        {
                            int i = 1;
                            int.TryParse(sh.dpid, out i);
                            cb_dianpu.SelectedValue = i;
                            cb_state.Text = sh.fx_state == "1" ? "未返现" : "已返现";
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (object.Equals(e.Value, "1"))
                {
                    e.Value = "未返现";
                }
                else if (object.Equals(e.Value, "2"))
                {
                    e.Value = "已返现";
                }
            }
        }

    }
}

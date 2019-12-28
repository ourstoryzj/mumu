using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;

namespace Operation
{
    public partial class shouhouFrom : Form
    {


        public shouhouFrom()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            bind();
            bind_dianpu();
        }


        void bind()
        {
            IList<shouhou> list = BLL2.shouhouManager.SearchAll();
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



        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string id = lbl_id.Text.Trim();
                DateTime dt = DateTime.Now;
                string account = txt_account.Text.Trim();
                string because = txt_because.Text.Trim();
                string name = txt_name.Text.Trim();
                string phone = txt_phone.Text.Trim();
                string remark = txt_remark.Text.Trim();
                string state = cb_state.Text == "未处理" ? "0" : (cb_state.Text == "已投诉" ? "2" : "1");
                string dianpu = cb_dianpu.SelectedValue != null ? cb_dianpu.SelectedValue.ToString() : "";
                string code = txt_code.Text.Trim();
                string ytphone = txt_ytphone.Text.Trim();
                string kdcode = txt_kdcode.Text.Trim();

                shouhou sh = new shouhou();

                if (!string.IsNullOrEmpty(id))
                {
                    sh = BLL2.shouhouManager.SearchByshid(Convert.ToInt32(id));
                }

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("请输入买家姓名");
                    txt_name.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(account))
                {
                    MessageBox.Show("请输入买家账号");
                    txt_account.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(phone))
                {
                    MessageBox.Show("请输入买家电话号码");
                    txt_phone.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(code))
                {
                    MessageBox.Show("请输入订单号码");
                    txt_code.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(dianpu))
                {
                    MessageBox.Show("请选择店铺");
                    cb_dianpu.Show();
                    return;
                }



                sh.shaccount = account;
                sh.dpid = Convert.ToInt32(dianpu);
                sh.shname = name;
                sh.shordercode = code;
                sh.shphone = phone;
                sh.shremark = remark;
                sh.shstate = state;
                sh.shyuanyin = because;
                sh.shdate = dt;
                sh.shytphone = ytphone;
                sh.shkdcode = kdcode;

                int res;
                if (string.IsNullOrEmpty(lbl_id.Text.Trim()))
                {
                    res = BLL2.shouhouManager.Insert(sh);
                    bind();
                }
                else
                {
                    res = BLL2.shouhouManager.Update(sh);
                    if (res == 1)
                    {
                        string rIndex = lbl_RowIndex.Text.Trim();
                        string cIndex = lbl_CellIndex.Text.Trim();
                        int ci;
                        int ri;
                        if (int.TryParse(cIndex, out ci) && int.TryParse(rIndex, out ri))
                        {
                            dataGridView1.Rows[ri].Cells[1].Value = sh.shordercode;
                            dataGridView1.Rows[ri].Cells[2].Value = sh.shaccount;
                            dataGridView1.Rows[ri].Cells[3].Value = sh.shname;
                            dataGridView1.Rows[ri].Cells[4].Value = sh.shphone;
                            dataGridView1.Rows[ri].Cells[5].Value = sh.shytphone;
                            dataGridView1.Rows[ri].Cells[6].Value = sh.shstate == "0" ? "未处理" : (sh.shstate == "1" ? "已处理" : "已投诉");
                            dataGridView1.Rows[ri].Cells[7].Value = sh.shyuanyin;
                            dataGridView1.Rows[ri].Cells[8].Value = sh.shdate.ToString();
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
            //bind();
            clears();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clears();
        }




        void clears()
        {
            lbl_date.Text = "";
            lbl_id.Text = "";
            txt_account.Text = "";
            txt_because.Text = "";
            txt_name.Text = "";
            txt_phone.Text = "";
            txt_remark.Text = "";
            txt_code.Text = "";
            txt_ytphone.Text = "";
            lbl_CellIndex.Text = "";
            lbl_RowIndex.Text = "";
            txt_name.Focus();
            txt_kdcode.Text = "";
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
                    if (BLL2.shouhouManager.Delete(Convert.ToInt32(id)) == 1)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int temp = e.ColumnIndex;
                string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                int idid;
                if (temp == 7)
                {
                    if (int.TryParse(id, out idid))
                    {
                        shouhou sh = BLL2.shouhouManager.SearchByshid(idid);
                        sh.shstate = sh.shstate == "0" ? "2" : (sh.shstate == "2" ? "1" : "0");
                        if (BLL2.shouhouManager.Update(sh) == 1)
                        {
                            //bind();
                            if (sh.shstate == "0")
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "未处理";
                            }
                            else if (sh.shstate == "1")
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "已处理";
                            }
                            else if (sh.shstate == "2")
                            {
                                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "已投诉";
                            }
                        }
                        else
                        {
                            MessageBox.Show("系统出错，请联系我");
                        }
                    }
                }
                else if (temp == 6)
                {
                    object kdcode = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (kdcode != null)
                    {
                        if (!string.IsNullOrEmpty(kdcode.ToString()))
                        {
                            System.Diagnostics.Process.Start("http://www.kiees.cn/yto.php?wen=" + kdcode);

                        }
                    }
                }
                else
                {
                    if (int.TryParse(id, out idid))
                    {
                        Entity.shouhou sh = BLL2.shouhouManager.SearchByshid(idid);
                        txt_name.Text = sh.shname;
                        txt_remark.Text = sh.shremark;
                        lbl_id.Text = sh.shid.ToString();
                        txt_account.Text = sh.shaccount;
                        txt_because.Text = sh.shyuanyin;
                        txt_code.Text = sh.shordercode;
                        txt_phone.Text = sh.shphone;
                        txt_remark.Text = sh.shremark;
                        lbl_date.Text = sh.shdate.ToString();
                        txt_ytphone.Text = sh.shytphone;
                        lbl_CellIndex.Text = e.ColumnIndex.ToString();
                        lbl_RowIndex.Text = e.RowIndex.ToString();
                        txt_kdcode.Text = sh.shkdcode;
                        try
                        {
                            cb_dianpu.SelectedValue = sh.dpid;
                            cb_state.Text = sh.shstate == "0" ? "未处理" : (sh.shstate == "1" ? "已处理" : "已投诉");
                        }
                        catch { }
                    }
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (object.Equals(e.Value, "1"))
                {
                    e.Value = "已处理";
                }
                else if (object.Equals(e.Value, "0"))
                {
                    e.Value = "未处理";
                }
                else if (object.Equals(e.Value, "2"))
                {
                    e.Value = "已投诉";
                }
            }

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            string key = txt_key.Text.Trim();
            DateTime start = date_start.Text == "请选择" ? new DateTime() : Convert.ToDateTime(date_start.Text);
            DateTime end = date_end.Text == "请选择" ? new DateTime() : Convert.ToDateTime(date_end.Text);
            int dp = Convert.ToInt32(cb_dianpu2.SelectedValue);
            string state = cb_state2.Text == "请选择" ? "" : (cb_state2.Text == "未处理" ? "0" : (cb_state2.Text == "已投诉" ? "2" : "1"));
            IList<shouhou> list = BLL2.shouhouManager.Search(1,1,key, dp, start, end, state, "");
            dataGridView1.DataSource = list;
        }

        private void date_start_CloseUp(object sender, EventArgs e)
        {
            date_start.Format = DateTimePickerFormat.Long;
        }

        private void date_end_CloseUp(object sender, EventArgs e)
        {
            date_end.Format = DateTimePickerFormat.Long;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            date_start.Format = DateTimePickerFormat.Custom;
            date_start.CustomFormat = "请选择";
            date_end.Format = DateTimePickerFormat.Custom;
            date_end.CustomFormat = "请选择";
        }



    }
}

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

namespace Operation
{
    public partial class dianpuFrom : Form
    {
        public dianpuFrom()
        {
            InitializeComponent();
            bind();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
        }



        #region btn_ok_Click
        private void btn_ok_Click(object sender, EventArgs e)
        {

            string name = txt_name.Text.Trim();
            string remark = txt_remark.Text.Trim();
            string state = lbl_db.Text.Trim();
            string id = lbl_id.Text.Trim();
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入店铺名称");
                txt_name.Focus();
                return;
            }
            Entity.dianpu dp = string.IsNullOrEmpty(id) ? new dianpu() : dianpuManager.SearchBydpid(Convert.ToInt32(id));
            dp.dpname = name;
            dp.dpremark = remark;
            dp.dpstate = state == "0" ? "0" : "1";
            dp.dpsort = string.IsNullOrEmpty(id) ? 100 : dp.dpsort;
            try
            {
                if ((string.IsNullOrEmpty(id) ? dianpuManager.Insert(dp) : dianpuManager.Update(dp)) == 1)
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
                MessageBox.Show(ex.Message);
                return;
            }
            bind();
            clears();
        }
        #endregion

        void bind()
        {
            IList<dianpu> list = dianpuManager.SearchAll();
            dataGridView1.DataSource = list;
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            string temp = lbl_id.Text.Trim();
            if (!string.IsNullOrEmpty(temp))
            {
                if (dianpuManager.Delete(Convert.ToInt32(temp)) == 1)
                {
                    MessageBox.Show("删除成功");
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
                bind();
                clears();
            }
            else
            {
                MessageBox.Show("请选择店铺");
            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //如果不是首行
                if (e.RowIndex > -1)
                {
                    string colname = dataGridView1.Columns[e.ColumnIndex].Name;
                    dianpu dp = (dianpu)dataGridView1.CurrentRow.DataBoundItem;

                    txt_name.Text = dp.dpname;
                    txt_remark.Text = dp.dpremark;
                    lbl_id.Text = dp.dpid.ToString();
                    lbl_db.Text = dp.dpstate;

                    if (colname == "col_state")
                    {
                        #region 修改状态
                        dp.dpstate = dp.dpstate == "1" ? "0" : "1";
                        BLL2.dianpuManager.Update(dp);
                        //取消选中
                        //dgv1.Columns[e.ColumnIndex].Selected = false;
                        dataGridView1.CurrentCell = null;
                        //DataGridView.CurrentCell = null;
                        dataGridView1.Refresh();
                        #endregion
                    }
                    else if (colname == "test2")
                    {

                    }


                }
                //else if (e.RowIndex == -1)
                //{
                //    //如果是首行
                //    #region 全选
                //    //如果是全选
                //    if (e.ColumnIndex == 0)
                //    {
                //        foreach (DataGridViewRow row in dgv1.Rows)
                //        {
                //            if (row.Index != -1)
                //            {
                //                DataGridViewCheckBoxCell cbx = (DataGridViewCheckBoxCell)row.Cells[0];
                //                cbx.Value = allselect == 0 ? true : false;
                //            }
                //        }
                //        allselect = allselect == 1 ? 0 : 1;
                //    }
                //    #endregion
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //if (e.RowIndex != -1)
            //{
            //    int temp = e.ColumnIndex;
            //    string id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //    int idid;
            //    if (temp ==4)
            //    {
            //        if (int.TryParse(id, out idid))
            //        {
            //            Entity.dianpu dp = dianpuManager.SearchBydpid(idid);
            //            dp.dpstate = dp.dpstate == "1" ? "0" : "1";
            //            dianpuManager.Update(dp);
            //            bind();
            //        }
            //    }
            //    if (temp == 3)
            //    {
            //        if (e.RowIndex != 0)
            //        {
            //            string id2 = dataGridView1.Rows[e.RowIndex - 1].Cells[0].Value.ToString();
            //            int temp_id2;
            //            if (int.TryParse(id, out idid) && int.TryParse(id2, out temp_id2))
            //            {
            //                Entity.dianpu dp1 = dianpuManager.SearchBydpid(idid);
            //                Entity.dianpu dp2 = dianpuManager.SearchBydpid(temp_id2);
            //                string temp_sort = dp1.dpsort;
            //                dp1.dpsort = dp2.dpsort;
            //                dp2.dpsort = temp_sort;
            //                dianpuManager.Update(dp1);
            //                dianpuManager.Update(dp2);
            //                bind();
            //            }

            //        }
            //    }
            //    else
            //    {
            //        if (int.TryParse(id, out idid))
            //        {
            //            Entity.dianpu dp = dianpuManager.SearchBydpid(idid);
            //            txt_name.Text = dp.dpname;
            //            txt_remark.Text = dp.dpremark;
            //            lbl_id.Text = dp.dpid.ToString();
            //            lbl_db.Text = dp.dpstate;
            //        }
            //    }
            //}
        }


        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value != null)
                {
                    if (dataGridView1.DataSource != null)
                    {

                        if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("col_state"))
                        {
                            string name = e.Value.ToString();
                            if (name == "1")
                            {
                                e.Value = "启用";
                                e.CellStyle.ForeColor = Color.Green;
                            }
                            else if (name == "0")
                            {
                                e.Value = "禁用";
                                e.CellStyle.ForeColor = Color.Red;
                            }
                        }
                        else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("dpsort"))
                        {

                            //e.Value = "上移";
                            //e.CellStyle.ForeColor = Color.Blue;
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

            //if (e.ColumnIndex == 4)
            //{
            //    if (object.Equals(e.Value, "1"))
            //    {
            //        e.Value = "启用";

            //    }
            //    else if (object.Equals(e.Value, "0"))
            //    {
            //        e.Value = "禁用";
            //    }
            //}
            //else if (e.ColumnIndex == 3)
            //{
            //    e.Value = "上移";
            //}
        }

        private void btn_sort_Click(object sender, EventArgs e)
        {
            IList<dianpu> list = dianpuManager.SearchAll();
            int temp = 1;
            foreach (dianpu dp in list)
            {
                dp.dpsort = temp;
                dianpuManager.Update(dp);
                temp++;
            }
            bind();
            MessageBox.Show("排序成功");
        }


        void clears()
        {
            lbl_db.Text = "";
            lbl_id.Text = "";
            txt_name.Text = "";
            txt_remark.Text = "";
            txt_name.Focus();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clears();
            MessageBox.Show("数据已成功释放！");
        }

        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                //int i = dgv_title.CurrentCell.ColumnIndex;
                string colname = dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name;
                string dataname=dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].DataPropertyName;


                if (dataname.Equals("dpname") || dataname.Equals("dpremark") || dataname.Equals("dpaccount") || dataname.Equals("dppwd") || dataname.Equals("dpremark1") || dataname.Equals("dpremark2") || dataname.Equals("dpsort"))
                {
                    dianpu dp = (dianpu)dataGridView1.CurrentRow.DataBoundItem;
                    if (dp != null)
                    {


                        string c_name = dataGridView1["c_name", e.RowIndex].EditedFormattedValue == null ? "" : dataGridView1["c_name", e.RowIndex].EditedFormattedValue.ToString();
                        string col_account = dataGridView1["col_account", e.RowIndex].EditedFormattedValue == null ? "" : dataGridView1["col_account", e.RowIndex].EditedFormattedValue.ToString();
                        string col_pwd = dataGridView1["col_pwd", e.RowIndex].EditedFormattedValue == null ? "" : dataGridView1["col_pwd", e.RowIndex].EditedFormattedValue.ToString();
                        string col_phone = dataGridView1["col_phone", e.RowIndex].EditedFormattedValue == null ? "" : dataGridView1["col_phone", e.RowIndex].EditedFormattedValue.ToString();
                        string col_remark = dataGridView1["col_remark", e.RowIndex].EditedFormattedValue == null ? "" : dataGridView1["col_remark", e.RowIndex].EditedFormattedValue.ToString();
                        string c_remark = dataGridView1["c_remark", e.RowIndex].EditedFormattedValue == null ? "" : dataGridView1["c_remark", e.RowIndex].EditedFormattedValue.ToString();
                        string col_sort = dataGridView1["col_sort", e.RowIndex].EditedFormattedValue == null ? "" : dataGridView1["col_sort", e.RowIndex].EditedFormattedValue.ToString();

                        dp.dpaccount = col_account;
                        dp.dpname = c_name;
                        dp.dppwd = col_pwd;
                        dp.dpremark1 = col_phone;
                        dp.dpremark2 = col_remark;
                        dp.dpremark = c_remark;
                        int temp = 0;
                        int.TryParse(col_sort, out temp);
                        dp.dpsort = temp;





                        BLL2.dianpuManager.Update(dp);
                    }
                }

                
            }
            catch (Exception ex)
            {
                Debug.WriteLine("修改信息失败 " + ex.Message);
            }
        }
    }
}

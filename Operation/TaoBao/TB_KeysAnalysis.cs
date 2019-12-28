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
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Operation.TaoBao
{
    public partial class TB_KeysAnalysis : Form
    {



        public TB_KeysAnalysis()
        {

            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

        }

        #region btn_dp_huan_Click
        private void btn_dp_huan_Click(object sender, System.EventArgs e)
        {
            //Manager.dianpu_huan(webBrowser1);
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion

        #region btn_test_Click
        private void btn_test_Click(object sender, EventArgs e)
        {
            string js = txt_js.Text;
            //Browser.JS_CEFBrowser_NoReturn(js, webBrowser1);
        }
        #endregion

        #region btn_jisuan_Click



        private void btn_jisuan_Click(object sender, EventArgs e)
        {
            string temp = txt_key.Text;
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

            //核心词
            List<string> list_hexin = Manager.StrToList(txt_hexinci.Text);


            //int doubleorder = 0;
            //分析结果
            List<keyss> list_res = new List<keyss>();

            foreach (string str in list)
            {
                if (string.IsNullOrEmpty(str))
                    break;
                //不检测核心词
                bool iscontinue = false;
                foreach (string c in list_hexin)
                {
                    if (str.IndexOf(c) > -1)
                    {
                        iscontinue = true;
                        break;
                    }
                }
                if (iscontinue)
                {
                    continue;
                }
                //开始分析数据
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

            dgv_key.DataSource = list_res;


        }

        #endregion

        #region btn_clear_Click
        private void btn_clear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清空关键词吗?", "删除关键词", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                txt_key.Text = "";
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
                txt_key.Text = sr.ReadToEnd();
            }

            btn_jisuan.PerformClick();
        }







        #endregion

        #region dgv_key_CellContentClick



        private void dgv_key_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgv_key.Columns[e.ColumnIndex] is DataGridViewColumn || e.ColumnIndex == 0)
                {

                    object obj = dgv_key[e.ColumnIndex, e.RowIndex].Value;

                    List<string> list = Manager.StrToList(txt_key.Text);


                    foreach (string str in list)
                    {
                        if (str.IndexOf(obj.ToString()) > -1)
                        {
                            txt_baohanci.Text = str;
                            txt_hexinci.Text = txt_hexinci.Text + "\r\n" + str;
                            DeleteKey(str);
                            return;
                        }
                    }
                }
            }
        }



        #endregion

        /// <summary>
        /// 删除关键词
        /// </summary>
        /// <param name="key"></param>
        void DeleteKey(string key)
        {
            List<string> list = Manager.StrToList(txt_key.Text);
            txt_key.Text = "";
            list.ForEach(item => txt_key.Text = (item == key ? txt_key.Text : txt_key.Text + item + "\r\n"));

        }



        private void btn_clear_hexinci_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清空核心词吗?", "删除核心词", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                txt_hexinci.Text = "";
        }

        private void btn_jisuanqingchu_Click(object sender, EventArgs e)
        {
            string temp = txt_key.Text;
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

            //核心词
            List<string> list_hexin = Manager.StrToList(txt_hexinci.Text);


            //int doubleorder = 0;
            //分析结果
            List<keyss> list_res = new List<keyss>();
            //删除包含核心词后的结果
            List<string> list_key_res = new List<string>();

            foreach (string str in list)
            {
                if (string.IsNullOrEmpty(str))
                    break;
                //不检测核心词
                bool iscontinue = false;
                foreach (string c in list_hexin)
                {
                    if (str.IndexOf(c) > -1)
                    {
                        iscontinue = true;
                        break;
                    }
                }
                if (iscontinue)
                {
                    continue;
                }
                list_key_res.Add(str);

                //开始分析数据
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

            dgv_key.DataSource = list_res;
            txt_key.Text = "";
            list_key_res.ForEach(item => txt_key.Text = (txt_key.Text + item + "\r\n"));
            txt_key.Text = txt_key.Text + "ok";
            MessageBox.Show("操作完成,还剩" + list_key_res.Count + "个词");

        }

        private void btn_quchonghexinci_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list_hexinci = Manager.StrToList(txt_hexinci.Text);
                list_hexinci = list_hexinci.RemoveRepeat();
                txt_hexinci.Text = "";
                list_hexinci.ForEach(item => txt_hexinci.Text = txt_hexinci.Text + item + "\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现问题:" + ex.ToString());
            }

        }

        private void btn_clearbaohan_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> list_hexinci = Manager.StrToList(txt_hexinci.Text);
                List<string> list_res = new List<string>();
                foreach (string hxc in list_hexinci)
                {
                    if (!string.IsNullOrEmpty(hxc))
                    {

                        //判断这个词是否有词根,就是有没有基础词,例如:高中书包女韩版  这个词,可以有书包女 这个词根
                        bool add = true;
                        foreach (string temp in list_hexinci)
                        {
                            if (hxc == temp)
                            {
                                continue;
                            }
                            //如果原集合内有词根,则不添加
                            string temp2 = hxc.ToCheckRoot(temp);
                            if (temp2==temp)
                            {
                                add = false;
                                break;
                            }
                        }
                        if (add)
                            list_res.Add(hxc);

                    }
                }

                txt_hexinci.Text = "";
                list_res.ForEach(item => txt_hexinci.Text = txt_hexinci.Text + item + "\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现问题:" + ex.ToString());
            }
        }
    }

}


using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace Operation.Other
{
    public partial class BaiduPanFrom : Form
    {

        int pageNum = 1;
        List<Baiduxinxi> list = new List<Baiduxinxi>();
        string key = "";

        public BaiduPanFrom()
        {
            InitializeComponent();
        }




        private void Button1_Click(object sender, EventArgs e)
        {
            key = textBox1.Text;
            if (string.IsNullOrEmpty(key))
            {
                "请输入关键词".ToShow();
                textBox1.Focus();
                return;
            }

            pageNum = 1;
            list = new List<Baiduxinxi>();



            SearchShiLaiMu();
            pageNum ++;
            SearchShiLaiMu();
            pageNum++;
            SearchShiLaiMu();

            dataGridView1.DataSource = list;


        }

        /// <summary>
        /// 查询史莱姆
        /// </summary>
        private void SearchShiLaiMu()
        {
            if (!string.IsNullOrEmpty(key))
            {

                try
                {
                    HtmlWeb html = new HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = html.Load("http://www.slimego.cn/search.html?q=" + key + "&page=" + pageNum + "&rows=40");

                    HtmlNodeCollection htmlnodecol = doc.DocumentNode.SelectNodes("//div[@class='searchRow']");
                    foreach (var hn in htmlnodecol)
                    {
                        try
                        {
                            Baiduxinxi baidu = new Baiduxinxi();

                            string url = hn.SelectSingleNode(".//a[@rel]").Attributes["href"].Value;
                            //string name = hn.SelectSingleNode(".//span[@class='one-pan-tip']").InnerText;
                            string name = hn.SelectSingleNode(".//a[@rel]").InnerText;
                            string size = hn.SelectSingleNode(".//span[@class='size']").InnerText;
                            string upload = hn.SelectSingleNode(".//span[@class='upload']").InnerText;
                            //textBox1.Text += url + name + size + upload + "\r\n";

                            upload = upload.Replace("上传:", "");

                            baidu.Url = url;
                            baidu.Name = name;
                            baidu.Size = size;
                            baidu.Upload = upload;

                            list.Add(baidu);
                        }
                        catch
                        {

                        }
                    }
                }
                catch
                {


                }
            }
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv1 = (DataGridView)sender;
                //如果不是首行
                if (e.RowIndex > -1)
                {

                    string colname = dgv1.Columns[e.ColumnIndex].Name;
                    Baiduxinxi sr = (Baiduxinxi)dgv1.CurrentRow.DataBoundItem;
                    if (colname == "col_url")
                    {
                        #region 修改状态
                        Common.Manager.OpenProgram(sr.Url);
                        dgv1.CurrentCell = null;
                        dgv1.Refresh();
                        #endregion
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            pageNum++;

            SearchShiLaiMu();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = list;

        }

        private void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll &&
      (e.NewValue + dataGridView1.DisplayedRowCount(false) == dataGridView1.Rows.Count))//垂直滚动条滚动到底部，数据为加载完，则再次加载
            {
                //设置当前光标为忙碌状态
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    pageNum++;

                    SearchShiLaiMu();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //设置当前光标为正常状态
                this.Cursor = Cursors.Default;
            }
        }
    }



    class Baiduxinxi
    {
        string url;
        string name;
        string size;
        string upload;

        public string Url { get => url; set => url = value; }
        public string Name { get => name; set => name = value; }
        public string Size { get => size; set => size = value; }
        public string Upload { get => upload; set => upload = value; }
    }


}

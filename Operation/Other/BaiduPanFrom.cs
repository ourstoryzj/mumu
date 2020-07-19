using Common;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Operation.Other
{
    public partial class BaiduPanFrom : Form
    {

        int pageNum = 1;
        List<Baiduxinxi> list = new List<Baiduxinxi>();
        /// <summary>
        /// 搜索关键词
        /// </summary>
        string key = "";
        /// <summary>
        /// 站点名称
        /// </summary>
        string site = "";
        //一页可以显示18条信息
        /// <summary>
        /// 线程锁
        /// </summary>
        object locker = new object();
        /// <summary>
        /// 搜索网址
        /// </summary>
        string webUrl = string.Empty;
        /// <summary>
        /// 选取节点集合的xpath语法
        /// </summary>
        string xpathNodes = string.Empty;
        /// <summary>
        /// 选取资源地址的xpath语法
        /// </summary>
        string xpathUrl = string.Empty;
        /// <summary>
        /// 选取资源名称的xpath语法
        /// </summary>
        string xpathName = string.Empty;
        /// <summary>
        /// 选取资源大小的xpath语法
        /// </summary>
        string xpathSize = string.Empty;
        /// <summary>
        /// 选取上传时间的xpath语法
        /// </summary>
        string xpathUpload = string.Empty;

        public BaiduPanFrom()
        {
            InitializeComponent();
            BindSite();
        }


        #region 网盘搜索
        /// <summary>
        /// 查询下一页
        /// </summary>
        private void SearchNextPage()
        {
            if (!string.IsNullOrEmpty(key))
            {
                lock (locker)
                {
                    try
                    {
                        if (GetXml())
                        {
                            SetMessage("开始加载数据");
                            SetProgressBar(30);
                            HtmlWeb html = new HtmlWeb();
                            // HtmlAgilityPack 设置 请求超时
                            SetTimeout(html);
                            HtmlAgilityPack.HtmlDocument doc = html.Load(webUrl);
                            HtmlNodeCollection htmlnodecol = doc.DocumentNode.SelectNodes(xpathNodes);
                            SetMessage("数据加载成功，正在显示");
                            if (htmlnodecol == null)
                            {
                                SetMessage("没有采集到数据");
                            }
                            else
                            {


                                foreach (var hn in htmlnodecol)
                                {
                                    try
                                    {
                                        //如果没有标题和链接则跳出
                                        if (hn.SelectSingleNode(xpathName) == null || hn.SelectSingleNode(xpathUrl) == null)
                                        {
                                            continue;
                                        }
                                        Baiduxinxi baidu = new Baiduxinxi();

                                        string url = hn.SelectSingleNode(xpathUrl)!=null? hn.SelectSingleNode(xpathUrl).Attributes["href"].Value:"";
                                        string name = hn.SelectSingleNode(xpathName) != null ? hn.SelectSingleNode(xpathName).InnerText : "";
                                        string size = hn.SelectSingleNode(xpathSize) != null ? hn.SelectSingleNode(xpathSize).InnerText : "";
                                        string upload = hn.SelectSingleNode(xpathUpload) != null ? hn.SelectSingleNode(xpathUpload).InnerText : "";

                                        //如果链接没有主机地址，则添加
                                        if (url.IndexOf("http") == -1)
                                        {
                                            Uri uri = new Uri(webUrl);
                                            url = uri.Scheme + "://" + uri.Host + url;
                                        }

                                        upload = upload.Replace("上传", "").Replace("时间", "").Replace("大小", "").Replace("发布", "").Replace(":", "").Replace("：", "");
                                        size = size.Replace("上传", "").Replace("时间", "").Replace("大小", "").Replace("发布", "").Replace(":", "").Replace("：", "");

                                        url = (!string.IsNullOrEmpty(url)) ? url.Trim().Replace(" ", "").Replace("&nbsp;", "") : url;
                                        name = (!string.IsNullOrEmpty(name)) ? name.Trim() : name;
                                        size = (!string.IsNullOrEmpty(size)) ? size.Trim().Replace(" ", "").Replace("&nbsp;", "") : size;
                                        upload = (!string.IsNullOrEmpty(upload)) ? upload.Trim().Replace(" ", "").Replace("&nbsp;", "") : upload;

                                        baidu.Url = url;
                                        baidu.Name = name;
                                        baidu.Size = size;
                                        baidu.Upload = upload;

                                        AddRow(baidu);
                                        AddProgressBar();

                                    }
                                    catch (Exception ex)
                                    {
                                        ex.ToString().ToShow();
                                    }
                                }
                                pageNum++;//页面增加
                                AddProgressBarAll();
                                SetMessage("数据加载完成");
                            }
                        }
                    }
                    catch (Exception ex) { ex.ToShow(); }
                }
            }
        }
        #endregion



        #region 私有方法
        private void Button1_Click(object sender, EventArgs e)
        {
            key = txt_key.Text;
            if (string.IsNullOrEmpty(key))
            {
                "请输入关键词".ToShow();
                txt_key.Focus();
                return;
            }
            site = cb_site.Text;
            if (string.IsNullOrEmpty(site))
            {
                "选择搜索引擎".ToShow();
                cb_site.Focus();
                return;
            }
            dgv1.Rows.Clear();
            pageNum = 1;

            new Thread(() => SearchNextPage()).Start();


        }

        void BindSite()
        {
            try
            {
                XMLHelpers xML = new XMLHelpers("BaiduPanSearch");
                string temp = xML.GetValue("WebNameList");
                if (!string.IsNullOrEmpty(temp))
                {
                    string[] siteList = temp.ToSplit("|");
                    cb_site.Items.Clear();
                    foreach (var item in siteList)
                    {
                        cb_site.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToShow();
            }
        }

        /// <summary>
        /// 进度条增加1
        /// </summary>
        void AddRow(Baiduxinxi xx)
        {
            //解决 线程间操作无效: 从不是创建控件“dgv1”的线程访问它。 的问题

            //使用委托执行添加一行数据
            Action action = new Action(() =>
            {
                int index = this.dgv1.Rows.Add();
                this.dgv1.Rows[index].Cells[0].Value = xx.Name;
                this.dgv1.Rows[index].Cells[1].Value = xx.Url;
                this.dgv1.Rows[index].Cells[2].Value = xx.Upload;
                this.dgv1.Rows[index].Cells[3].Value = xx.Size;
            });
            //在控件线程中执行代码，添加行
            Invoke(action);

        }

        /// <summary>
        /// 进度条增加1
        /// </summary>
        void SetProgressBar(int count)
        {
            //简便写法
            Invoke(new Action(() =>
            {
                toolStripProgressBar1.Value = 0;
                toolStripProgressBar1.Maximum = count;
            }));
        }

        /// <summary>
        /// 进度条增加1
        /// </summary>
        void AddProgressBar()
        {
            //简便写法
            Invoke(new Action(() =>
            {
                toolStripProgressBar1.PerformStep();
            }));
        }

        /// <summary>
        /// 进度条增加满
        /// </summary>
        void AddProgressBarAll()
        {
            //简便写法
            Invoke(new Action(() =>
            {
                toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            }));
        }


        /// <summary>
        /// 设置状态栏文字
        /// </summary>
        /// <param name="str"></param>
        void SetMessage(string str)
        {
            Invoke(new Action(() =>
            {
                toolStripStatusLabel1.Text = str;
            }));
        }

        /// <summary>
        /// 设置Timeout  HtmlAgilityPack 设置 请求超时
        /// </summary>
        /// <param name="html"></param>
        void SetTimeout(HtmlWeb html)
        {
            html.PreRequest = request =>
            {
                request.Timeout = 8000;
                return true;
            };
        }


        bool GetXml()
        {
            try
            {
                if (!string.IsNullOrEmpty(site))
                {
                    XMLHelpers xml = new XMLHelpers("BaiduPanSearch");
                    webUrl = xml.GetValue(site + "WebUrl");
                    webUrl = webUrl.Replace("SearchKey", key).Replace("PageIndex", pageNum.ToString());
                    xpathNodes = xml.GetValue(site + "Nodes");
                    xpathUrl = xml.GetValue(site + "Url");
                    xpathName = xml.GetValue(site + "Name");
                    xpathSize = xml.GetValue(site + "Size");
                    xpathUpload = xml.GetValue(site + "Upload");
                    if (string.IsNullOrEmpty(webUrl))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToShow();
                return false;
            }
            return true;
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    DataGridView dgv1 = (DataGridView)sender;
            //    //如果不是首行
            //    if (e.RowIndex > -1)
            //    {

            //        string colname = dgv1.Columns[e.ColumnIndex].Name;
            //        Baiduxinxi sr = (Baiduxinxi)dgv1.CurrentRow.DataBoundItem;
            //        if (colname == "col_url")
            //        {
            //            #region 修改状态
            //            Common.Manager.OpenProgram(sr.Url);
            //            dgv1.CurrentCell = null;
            //            dgv1.Refresh();
            //            #endregion
            //        }


            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Button2_Click(object sender, EventArgs e)
        {

            new Thread(() => SearchNextPage()).Start();

            #region bak
            /*
                if (site == "史莱姆")
                {
                    new Thread(() =>
                    {
                        SearchShiLaiMu();
                    }).Start();
                }
                else if (site == "如风搜")
                {
                    new Thread(() =>
                    {
                        SearchRuFengSou();
                    }).Start();

                }
                else if (site == "51网盘搜索手机版")
                {
                    new Thread(() =>
                    {
                        Search51();
                    }).Start();
                }
                else if (site == "Fastsoso")
                {
                    new Thread(() =>
                    {
                        SearchFastsoso();
                    }).Start();
                }
                */
            #endregion

        }


        //设置刷新后滚动条的位置
        int VerticalScrollIndex = 0, HorizontalOffset = 0;
        private void DataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            //取消滚动滑轮采集
            return;
            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll &&
      (e.NewValue + dgv1.DisplayedRowCount(false) == dgv1.Rows.Count))//垂直滚动条滚动到底部，数据为加载完，则再次加载
            {
                //设置当前光标为忙碌状态
                //this.Cursor = Cursors.WaitCursor;
                try
                {




                    //记录滚动条的位置
                    if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                    {
                        VerticalScrollIndex = e.NewValue;
                    }
                    else if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
                    {
                        HorizontalOffset = e.NewValue;
                    }


                    //dataGridView1.ScrollBars = ScrollBars.None;
                    //刷新数据
                    string site = cb_site.Text;
                    //if (site == "史莱姆")
                    //{
                    //    //pageNum++;
                    //    //SearchShiLaiMu();
                    //    new Thread(() =>
                    //    {
                    //        SearchShiLaiMu();
                    //    }).Start();
                    //}
                    //else if (site == "如风搜")
                    //{
                    //    pageNum++;
                    //    SearchRuFengSou();
                    //}
                    //else if (site == "51网盘搜索手机版")
                    //{
                    //    pageNum++;
                    //    Search51();
                    //}
                    //else if (site == "Fastsoso")
                    //{
                    //    pageNum++;
                    //    SearchFastsoso();
                    //}

                    //dgv1.DataSource = null;
                    //dgv1.DataSource = list;

                    //dataGridView1.ScrollBars = ScrollBars.Vertical;

                    //设置垂直滚动条位置
                    dgv1.FirstDisplayedScrollingRowIndex = VerticalScrollIndex;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //设置当前光标为正常状态
                //this.Cursor = Cursors.Default;
            }
        }

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {
            (toolStripProgressBar1.Value + " " + toolStripProgressBar1.Maximum).ToShow();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Point hit = this.dgv1.PointToClient(Cursor.Position);
                DataGridView.HitTestInfo hitTest = this.dgv1.HitTest(hit.X, hit.Y);
                //MessageBox.Show(hitTest.Type + " Row=" + hitTest.RowIndex + " Col" + hitTest.ColumnIndex);
                //判断不是首行
                if (hitTest.RowIndex != -1)
                {

                    //Baiduxinxi sr = (Baiduxinxi)dgv1.CurrentRow.DataBoundItem;

                    string url = dgv1[1, hitTest.RowIndex].Value.ToString();
                    #region 修改状态
                    Manager.OpenProgram(url);
                    dgv1.CurrentCell = null;
                    dgv1.Refresh();
                    #endregion

                }
            }
            catch
            {

            }
        }
        #endregion
    }


    #region Baiduxinxi

    class Baiduxinxi
    {
        string url;
        string name;
        string size;
        string upload;

        public string Url
        {
            get
            {
                return url;
            }

            set
            {
                url = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public string Upload
        {
            get
            {
                return upload;
            }

            set
            {
                upload = value;
            }
        }

        //public string Url { get => url; set => url = value; }
        //public string Name { get => name; set => name = value; }
        //public string Size { get => size; set => size = value; }
        //public string Upload { get => upload; set => upload = value; }
    }

    #endregion

}

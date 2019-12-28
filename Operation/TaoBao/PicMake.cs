using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Operation.CS;
using CefSharp.WinForms;
using System.Diagnostics;
using Common;

namespace Operation.TaoBao
{
    public partial class PicMake : Form
    {


        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        /// <summary>
        /// 需要操作的图片数量
        /// </summary>
        int picnum = 0;
        /// <summary>
        /// 正在操作的图片index
        /// </summary>
        int picindex = 0;

        string dataPackageName = DateTime.Now.ToString("yyyyMMddHHmmss");

        //主图双击截图调色功能
        //public static Bitmap curBitmap;
        //处理主图截图调色功能的窗口
        private TaoBao.TB_ScreenForm sf = new TaoBao.TB_ScreenForm();
        //处理主图截图调色功能的窗口
        //private TaoBao.TB_ScreenDemo sd = new TaoBao.TB_ScreenDemo();


        //主图的MD5图片名称  
        //string mian1 = "";
        //string mian2 = "";
        //string mian3 = "";
        //string mian4 = "";
        //string mian5 = "";
        List<string> List_mian_make = new List<string>();

        //SKU的MD5图片名称  
        //string sku11 = "";
        //string sku22 = "";
        //string sku33 = "";
        //string sku44 = "";
        //string sku55 = "";
        //string sku66 = "";
        //string sku77 = "";
        //string sku88 = "";
        //string sku99 = "";
        //string sku100 = "";
        List<string> List_sku_make = new List<string>();


        public PicMake()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            webBrowser1 = new ChromiumWebBrowser("http://www.taobao.com");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(1070, 500);
            webBrowser1.Location = new Point(10, 100);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            tabPage2.Controls.Add(webBrowser1);

            txt_save.Text = Common.XMLHelper.GetValue("Pic_Save");
            Control.CheckForIllegalCrossThreadCalls = false;
            bind_hangye();
            bind_sku();
            bind_Models();
            bind_sku2();
        }


        #region Bind


        #region 绑定行业表&绑定行业下拉菜单

        void bind_hangye()
        {
            IList<Entity.lh_hangye> list = BLL2.lh_hangyeManager.Search(1, 1000, "", "", new DateTime(), new DateTime(), " hdate desc ");
            cb_hangye.DataSource = list;
            cb_hangye.DisplayMember = "hname";
            cb_hangye.ValueMember = "hid";
        }


        #endregion

        #region bind_sku

        /// <summary>
        /// 绑定sku
        /// </summary>
        void bind_sku()
        {
            string skustr = XMLHelper_TaoBaodDataPackage.GetValue("TaoBaoDataSKU");
            string[] skus = skustr.Split('|');
            string[] nameprice;
            int indexx = 1;

            foreach (string s in skus)
            {
                if (!string.IsNullOrEmpty(s))
                {
                    nameprice = s.Split('-');
                    if (nameprice.Length > 0)
                    {
                        object obj = groupBox5.Controls.GetControlByName("txt_sku" + indexx);
                        if (obj != null)
                        {
                            TextBox tb = (TextBox)obj;
                            tb.Text = nameprice[0];
                        }
                    }
                    if (nameprice.Length > 1)
                    {
                        object obj = groupBox5.Controls.GetControlByName("txt_price" + indexx);
                        if (obj != null)
                        {
                            TextBox tb = (TextBox)obj;
                            tb.Text = nameprice[1];
                        }
                    }
                    indexx++;
                }
            }
        }
        #endregion

        void bind_sku2()
        {
            //IList<opponent_dianpu> list = BLL2.opponent_dianpuManager.SearchAll();
            ////cb_dianpu.DataSource = list;
            //opponent_dianpu dp = new opponent_dianpu();
            //dp.odpname = "请选择";
            //dp.odTBID = "";
            //dp.oid = 0;
            //list.Insert(0, dp);
            //cb_sku_type.DataSource = list;

            string typesum = XMLHelper_SKU.GetValue("TypeSum");
            int tempsum_temp = 0;
            if (int.TryParse(typesum, out tempsum_temp))
            {
                //ComboBoxItem cbi1 = new ComboBoxItem();
                //ComboBox.ObjectCollection item = new ComboBox.ObjectCollection();
                //item. = "请选择";
                //item.Value = 0;
                cb_sku.Items.Add("请选择");
                cb_sku_type.Items.Add("请选择");
                for (int i = 0; i < tempsum_temp; i++)
                {
                    cb_sku.Items.Add("方案" + (i + 1).ToString());
                    cb_sku_type.Items.Add("方案" + (i + 1).ToString());
                }
                cb_sku.SelectedIndex = 0;
                cb_sku_type.SelectedIndex = 0;
            }




        }



        void bind_Models()
        {
            string typesum = XMLHelper_TaoBaodDataPackage.GetValue("TypeSum");
            int tempsum_temp = 0;
            if (int.TryParse(typesum, out tempsum_temp))
            {
                //ComboBoxItem cbi1 = new ComboBoxItem();
                //ComboBox.ObjectCollection item = new ComboBox.ObjectCollection();
                //item. = "请选择";
                //item.Value = 0;
                //cb_models.Items.Add("请选择");

                for (int i = 0; i < tempsum_temp; i++)
                {
                    cb_models.Items.Add(XMLHelper_TaoBaodDataPackage.GetValue("cateProps" + (i + 1), "title"));
                }
                cb_models.SelectedIndex = 0;
            }
        }

        #endregion

        #region btn_ok_Click
        private void btn_ok_Click(object sender, EventArgs e)
        {

            try
            {
                toolStripProgressBar1.Value = 0;

                string fileurl = txt_url.Text.Trim();
                if (string.IsNullOrEmpty(fileurl))
                {
                    MessageBox.Show("请输入文件路径");
                    return;
                }
                string frist = txt_first.Text.Trim();
                string last = txt_last.Text.Trim();
                string _zhiliang = txt_zhiliang.Text.Trim();

                //是否修改了文件名
                //bool isname = false;
                //新图尺寸
                int sizenew = 0;
                //新图质量
                int zhiliang = 99;
                int.TryParse(_zhiliang, out zhiliang);
                //尺寸
                bool chicun = rb_chicun2.Checked;
                if (chicun)
                {
                    sizenew = 750;
                }
                //边框
                bool biankuang = rb_biankuang2.Checked;
                //水印
                bool shuiyin = rb_shuiyin2.Checked;
                //水印地址
                string waterpath = Application.StartupPath + "\\shuiyin.png";
                //翻转
                bool fanzhuan = rbtn_fanzhuan2.Checked;

                picindex = 0;


                //修改图片名

                //string[] path = Directory.GetFiles(@fileurl);

                List<string> list = CS.FileHelper.FindFile2(@fileurl, "jpg|tbi");
                //int filecount = list.Count;
                //设置状态栏的最大值
                toolStripProgressBar1.Maximum = list.Count;
                picnum = list.Count;
                //lbl_message.Text = "需处理文件: " + filecount.ToString() + " 个";

                foreach (string str in list)
                {
                    //清空缓存
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    FileInfo file = new FileInfo(str);
                    //截取文件名 如 asdf.txt ->asdf
                    string f = file.Name.Substring(0, file.Name.LastIndexOf("."));
                    //原始文件地址
                    string fristname = file.DirectoryName + "\\" + (f + file.Extension);
                    //txt_message.Text = "正在处理：" + fristname;
                    //替换指定文件名 新文件地址 file.Extension指文件的后缀名
                    //修改文件名
                    if (!string.IsNullOrEmpty(frist))
                    {
                        f = frist + "_" + f;
                        //isname = true;
                    }
                    if (!string.IsNullOrEmpty(last))
                    {
                        f = f + "_" + last;
                        //isname = true;
                    }
                    //新文件名称地址
                    string lastname = file.DirectoryName + "\\" + (f + file.Extension);
                    //将指定文件移动到新的位置,并重新指定文件名

                    //水印地址

                    //开始处理图片 
                    Action<string, string, int, int, int, bool, bool, string, bool> action = PicMake_Action;
                    //CS.ImageClass.GetPicThumbnail(fristname, lastname, 0, sizenew, zhiliang, shuiyin, biankuang, waterpath);
                    action.BeginInvoke(fristname, lastname, 0, sizenew, zhiliang, shuiyin, biankuang, waterpath, fanzhuan, null, null);

                    //lbl_message2.Text = "文件剩余: " + (filecount - 1).ToString() + " 个";
                }
                //设置状态栏全部完成
                //while (toolStripProgressBar1.Value < toolStripProgressBar1.Maximum)
                //{
                //    toolStripProgressBar1.PerformStep();//按照Step的值进行递增！
                //}
                //MessageBox.Show("天天好心情^-^！ 图片处理完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }


        /// <summary>
        /// 多线程处理图片
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="dFile"></param>
        /// <param name="dHeight"></param>
        /// <param name="dWidth"></param>
        /// <param name="flag"></param>
        /// <param name="isshuiyin"></param>
        /// <param name="isbiankuang"></param>
        /// <param name="waterpath"></param>
        void PicMake_Action(string sFile, string dFile, int dHeight, int dWidth, int flag, bool isshuiyin, bool isbiankuang, string waterpath, bool isfanzhuan)
        {
            picindex++;
            txt_message.Text = "共" + picnum + "张图片需要处理\r\n正在处理第" + picindex + "张图片\r\n图片位置：" + sFile;
            //CS.ImageClass.GetPicThumbnail(sFile, dFile, dHeight, dWidth, flag, isshuiyin, isbiankuang, waterpath);
            CS.ImageClass.ImageMake(sFile, dFile, dHeight, dWidth, flag, isshuiyin, isbiankuang, waterpath, isfanzhuan);
            toolStripProgressBar1.PerformStep();
            //清空缓存
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
            if (picnum == picindex)
            {
                txt_message.Text = "共" + picnum + "张图片需要处理\r\n正在处理第" + picindex + "张图片\r\n图片位置：" + sFile + "\r\nok!";
            }
        }

        //private delegate void InvokeCallback(string msg);
        //void m_comm_MessageEvent(string msg)
        //{
        //    if (txt_message.InvokeRequired)
        //    {
        //        InvokeCallback msgCallback = new InvokeCallback(m_comm_MessageEvent);
        //        txt_message.Invoke(msgCallback, new object[] { msg });
        //    }
        //    else
        //    {
        //        txt_message.Text = msg;
        //    }
        //}



        #endregion

        #region btn_getMD5_Click
        private void btn_getMD5_Click(object sender, EventArgs e)
        {
            string fileurl = txt_url.Text.Trim();
            if (string.IsNullOrEmpty(fileurl))
            {
                MessageBox.Show("请输入文件路径");
                return;
            }
            string res = CS.ImageClass.GetMD5Hash(fileurl);
            txt_md5.Text = res;
        }




        #endregion

        #region btn_xiangqing_Click
        private void btn_xiangqing_Click(object sender, EventArgs e)
        {
            rbtn_yes.Checked = true;
            rb_biankuang2.Checked = true;
            rb_chicun2.Checked = true;
            //rb_shuiyin2.Checked = true;
        }
        #endregion

        #region btn_reset_Click
        private void btn_reset_Click(object sender, EventArgs e)
        {
            rbtn_yes.Checked = true;
            rb_biankuang1.Checked = true;
            rb_chicun1.Checked = true;
            rb_shuiyin1.Checked = true;
            rbtn_fanzhuan1.Checked = true;
            txt_first.Clear();
            txt_last.Clear();
            txt_md5.Clear();
            txt_url.Clear();
        }
        #endregion

        #region button1_Click
        private void button1_Click(object sender, EventArgs e)
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

            //把保存地址存储到xml文件中
            Common.XMLHelper.SetValue("Pic_Save", temp_save);

            webBrowser1.Load(weburl);

            //平台截图
            Bitmap bm = null;
            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                bm = CS.ImageClass.GetScreen(webBrowser1);
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
                path_temp = CS.Taobao.DownLoadImg_TaoBao(temp_save, weburl, webBrowser1, true);
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
                Common.ImageClass.GetScreen(bm, 50, path_temp, "屏幕截图.jpg");
            }


            MessageBox.Show("保存完成");
            Manager.OpenProgram_Directory(temp_save);

            
            //测试
            //System.Windows.Forms.HtmlElement;
            //HtmlElement
        }
        #endregion

        #region 拖拽修改图片及名称


        private void tabPage1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                //获取文件路径
                var filenames = (string[])e.Data.GetData(DataFormats.FileDrop);
                var hz = filenames[0].LastIndexOf('.') + 1;
                var houzhui = filenames[0].Substring(hz);//文件后缀名
                if (houzhui == "jpg" || houzhui == "gif" || houzhui == "png" || houzhui == "tbi")
                {
                    //设置拖拽状态，如果不设置则不会触发DragDrop事件
                    e.Effect = DragDropEffects.All;
                }

            }
        }
        //图片名称
        //int indexx = 1;
        private void tabPage1_DragDrop(object sender, DragEventArgs e)
        {
            //清空缓存
            GC.WaitForPendingFinalizers();
            GC.Collect();

            var filenames = (string[])e.Data.GetData(DataFormats.FileDrop);
            string filename = filenames[0].ToString();
            txt_url.Text = filename;

            #region 修改图片名称===>01.jpg 02.jpg

            /*
            try
            {
                toolStripProgressBar1.Value = 0;

                string frist = txt_first.Text.Trim();
                string last = txt_last.Text.Trim();
                string _zhiliang = txt_zhiliang.Text.Trim();

                //是否修改了文件名
                //bool isname = false;
                //新图尺寸
                int sizenew = 0;
                //新图质量
                int zhiliang = 99;
                int.TryParse(_zhiliang, out zhiliang);
                //尺寸
                bool chicun = rb_chicun2.Checked;
                if (chicun)
                {
                    sizenew = 750;
                }
                //边框
                bool biankuang = rb_biankuang2.Checked;
                //水印
                bool shuiyin = rb_shuiyin2.Checked;
                //水印地址
                string waterpath = Application.StartupPath + "\\shuiyin.png";
                //翻转
                bool fanzhuan = rbtn_fanzhuan2.Checked;

                picindex = 0;


                //修改图片名

                //int filecount = list.Count;
                string str = filename;


                FileInfo file = new FileInfo(str);
                //截取文件名 如 asdf.txt ->asdf
                //string f = file.Name.Substring(0, file.Name.LastIndexOf("."));
                //设置图片名称
                string f = indexx.ToString("00");
                indexx++;
                //原始文件地址
                //string fristname = file.DirectoryName + "\\" + (f + file.Extension);
                //替换指定文件名 新文件地址 file.Extension指文件的后缀名
                //修改文件名
                if (!string.IsNullOrEmpty(frist))
                {
                    f = frist + "_" + f;
                    //isname = true;
                }
                if (!string.IsNullOrEmpty(last))
                {
                    f = f + "_" + last;
                    //isname = true;
                }
                //新文件名称地址
                string lastname = file.DirectoryName + "\\" + (f + file.Extension);
                //将指定文件移动到新的位置,并重新指定文件名

                //水印地址

                //开始处理图片 
                Action<string, string, int, int, int, bool, bool, string, bool> action = PicMake_Action;
                action.BeginInvoke(filename, lastname, 0, sizenew, zhiliang, shuiyin, biankuang, waterpath, fanzhuan, null, null);


                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            */
            #endregion

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //indexx = 1;
        }

        #endregion

        #region btn_createtype_Click


        private void btn_createtype_Click(object sender, EventArgs e)
        {
            string fileurl = txt_url.Text.Trim();
            if (string.IsNullOrEmpty(fileurl))
            {
                MessageBox.Show("请输入文件路径");
                return;
            }

            #region 备用代码


            //try
            //{
            //    Image img1 = Image.FromFile(fileurl);
            //    img1.ToChangeMD5();
            //    //img.Dispose();
            //    //File.Delete(fileurl);
            //    Bitmap bm = (Bitmap)img1;

            //    bm.Save(fileurl);
            //    bm.Dispose();
            //    img1.Dispose();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //string fileurl = txt_url.Text.Trim();
            //if (string.IsNullOrEmpty(fileurl))
            //{
            //    MessageBox.Show("请输入文件路径");
            //    return;
            //}
            //string pc = fileurl + "//pc";
            //string app = fileurl + "//app";
            //string sku = fileurl + "//sku";
            //string main = fileurl + "//main";
            //Manager.CreateDirectory(pc);
            //Manager.CreateDirectory(app);
            //Manager.CreateDirectory(sku);
            //Manager.CreateDirectory(main);
            //MessageBox.Show("创建成功");
            //Manager.OpenProgram_Directory(fileurl);

            //this.Hide();//隐藏当前
            //this.pictureBox1.LineHistory.Clear();//清除绘制的历史线条
            //this.pictureBox1.RectHistory.Clear();
            #endregion



            //Image img1 = Image.FromFile(fileurl);
            //curBitmap = (Bitmap)img1;
            //sd.BackgroundImage = curBitmap;
            //sd.StartPosition = FormStartPosition.CenterScreen;//起始位置
            //sd.ShowDialog();


        }
        #endregion

        #region 数据包制作

        /// <summary>
        /// 重置数据包界面
        /// </summary>
        void reset()
        {
            dataPackageName = DateTime.Now.ToString("yyyyMMddHHmmss");

            imagetype = 0;
            txt_title.Text = "";
            txt_shangjiacode.Text = "";
            lb_title.DataSource = null;
            listView1.Items.Clear();
            pb_main1.BackgroundImage = null;
            pb_main2.BackgroundImage = null;
            pb_main3.BackgroundImage = null;
            pb_main4.BackgroundImage = null;
            pb_main5.BackgroundImage = null;

            //pb_sku1.BackgroundImage = null;
            //pb_sku2.BackgroundImage = null;
            //pb_sku3.BackgroundImage = null;
            //pb_sku4.BackgroundImage = null;
            //pb_sku5.BackgroundImage = null;
            //pb_sku6.BackgroundImage = null;
            //pb_sku7.BackgroundImage = null;
            //pb_sku8.BackgroundImage = null;
            //pb_sku9.BackgroundImage = null;
            //pb_sku10.BackgroundImage = null;

            for (int i = 1; i <= 24; i++)
            {
                object obj = groupBox5.Controls.GetControlByName("pb_sku" + i);
                if (obj != null)
                {
                    PictureBox pb = (PictureBox)obj;
                    pb.BackgroundImage = null;

                }
            }


            //txt_sku1.Text = "";
            //txt_sku2.Text = "";
            //txt_sku3.Text = "";
            //txt_sku4.Text = "";
            //txt_sku5.Text = "";
            //txt_sku6.Text = "";
            //txt_sku7.Text = "";
            //txt_sku8.Text = "";
            //txt_sku9.Text = "";
            //txt_sku10.Text = "";


            //txt_price1.Text = "";
            //txt_price2.Text = "";
            //txt_price3.Text = "";
            //txt_price4.Text = "";
            //txt_price5.Text = "";
            //txt_price6.Text = "";
            //txt_price7.Text = "";
            //txt_price8.Text = "";
            //txt_price9.Text = "";
            //txt_price10.Text = "";



            //主图的MD5图片名称  
            //mian1 = "";
            //mian2 = "";
            //mian3 = "";
            //mian4 = "";
            //mian5 = "";

            //SKU的MD5图片名称  
            //sku11 = "";
            //sku22 = "";
            //sku33 = "";
            //sku44 = "";
            //sku55 = "";
            //sku66 = "";
            //sku77 = "";
            //sku88 = "";
            //sku99 = "";
            //sku100 = "";

            bind_sku();


            listView2.Items.Clear();
            listView2.LargeImageList = null;
            pan_pc.Controls.Clear();
            pc_num = 0;
            groupBox6.Text = "详情图 已选择[" + pc_num + "]张图片";

        }


        /// <summary>
        /// 操作图片的类型 0则为设置 1则主图 2 则sku 3则详情图
        /// </summary>
        int imagetype = 0;

        #region btn_opendirectory_Click 打开或创建今日的数据库文件夹
        private void btn_opendirectory_Click(object sender, EventArgs e)
        {
            string paths = XMLHelper_TaoBaodDataPackage.GetValue("TaoBaoDataDirectory") + "\\" + DateTime.Now.ToString("yyyyMMdd");
            Manager.CreateDirectory(paths);
            Manager.OpenProgram_Directory(paths);
        }


        #endregion


        #region btn_data_image_main_Click 打开主图图片文件夹

        private void btn_data_image_main_Click(object sender, EventArgs e)
        {
            string fileurl = Manager.OpenFolderDialog("");
            listView1.Items.Clear();
            listView1.ToShowImages(fileurl, new Size(240, 240));
            imagetype = 1;

        }




        #endregion



        private void btn_data_image_pc_Click(object sender, EventArgs e)
        {
            string fileurl = Manager.OpenFolderDialog("");
            listView1.Items.Clear();
            listView1.ToShowImages(fileurl, new Size(240, 240));
            imagetype = 3;
        }

        private void btn_data_image_sku_Click(object sender, EventArgs e)
        {
            string fileurl = Manager.OpenFolderDialog("");
            listView1.Items.Clear();
            listView1.ToShowImages(fileurl, new Size(240, 240));
            imagetype = 2;
        }


        //pc图片展示方法

        //图片数量
        int pc_num = 0;
        //图片尺寸 
        int pc_img_size = 300;



        /// <summary>
        /// 图片双击方法,选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //获取鼠标所在位置的信息
            ListViewHitTestInfo info = this.listView1.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                //获取鼠标所在位置包含的ListViewItem
                ListViewItem item = info.Item;
                string filename = item.Text;
                //string filepath = XMLHelper.GetValue("OpenFolderDialog_SelectedPath") + "//" + filename;
                Image img = Image.FromFile(filename);

                if (imagetype == 3)
                {
                    //方案一
                    //listView2.ToShowImage(filename, new Size(200, 200));
                    //groupBox6.Text = "详情图 已选择[" + listView2.Items.Count + "]张图片";
                    //方案二，自动创建PictureBox
                    Image imgs = Image.FromFile(filename);
                    PictureBox pb = new PictureBox();
                    pb.Name = "pb_" + pc_num;
                    pb.Size = new Size(pc_img_size, pc_img_size);
                    pb.ToShowBackgroundImage_Auto(imgs);

                    //pb.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                    pb.Location = new Point(0, pc_num * pc_img_size);
                    pan_pc.Controls.Add(pb);
                    pb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(pb_MouseDoubleClick);

                    pc_num = pc_num + 1;
                    groupBox6.Text = "详情图 已选择[" + pc_num + "]张图片";

                }
                else if (imagetype == 2)
                {
                    //设置sku图片
                    for (int i = 1; i <= 24; i++)
                    {
                        object obj = groupBox5.Controls.GetControlByName("pb_sku" + i);
                        if (obj != null)
                        {
                            PictureBox pb = (PictureBox)obj;
                            if (pb.BackgroundImage == null)
                            {
                                pb.ToShowBackgroundImage_Auto(img);
                                return;
                            }
                        }
                    }

                }
                else if (imagetype == 1)
                {
                    if (pb_main1.BackgroundImage == null)
                        pb_main1.ToShowBackgroundImage_Auto(img);
                    else if (pb_main2.BackgroundImage == null)
                        pb_main2.ToShowBackgroundImage_Auto(img);
                    else if (pb_main3.BackgroundImage == null)
                        pb_main3.ToShowBackgroundImage_Auto(img);
                    else if (pb_main4.BackgroundImage == null)
                        pb_main4.ToShowBackgroundImage_Auto(img);
                    else if (pb_main5.BackgroundImage == null)
                        pb_main5.ToShowBackgroundImage_Auto(img);
                    else
                        MessageBox.Show("已经全部选择完毕");
                }
            }
        }

        /// <summary>
        /// picturebox 双击方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PictureBox pb_temp = (PictureBox)sender;
            pan_pc.Controls.Remove(pb_temp);
            //然后重新排序
            List<PictureBox> list = pan_pc.Controls.GetPictureBoxs();
            pan_pc.Controls.Clear();
            pc_num = 0;
            foreach (PictureBox picb in list)
            {
                picb.Name = "pb_" + pc_num;
                picb.Size = new Size(pc_img_size, pc_img_size);
                picb.Location = new Point(0, pc_num * pc_img_size);
                pan_pc.Controls.Add(picb);
                picb.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(pb_MouseDoubleClick);
                pc_num++;
            }
            groupBox6.Text = "详情图 已选择[" + pc_num + "]张图片";
        }



        #region listView1_MouseClick 右键编辑主图
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.Clicks == 1)
            {
                //获取鼠标所在位置的信息
                ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
                if (info.Item != null)
                {
                    //获取鼠标所在位置包含的ListViewItem
                    ListViewItem item = info.Item;
                    string filename = item.Text;
                    // string filepath = XMLHelper.GetValue("OpenFolderDialog_SelectedPath") + "//" + filename;
                    Image img = Image.FromFile(filename);

                    Manager.taobaozhutu = null;
                    TB_ScreenDemo sd = new TaoBao.TB_ScreenDemo();
                    //curBitmap = (Bitmap)img;
                    sd.BackgroundImage = img;
                    sd.StartPosition = FormStartPosition.CenterScreen;//起始位置
                    sd.ShowDialog();

                    Image imgres = Manager.taobaozhutu;
                    if (imgres != null)
                    {
                        if (imagetype == 1)
                        {
                            //设置主图
                            if (pb_main1.BackgroundImage == null)
                                pb_main1.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_main2.BackgroundImage == null)
                                pb_main2.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_main3.BackgroundImage == null)
                                pb_main3.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_main4.BackgroundImage == null)
                                pb_main4.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_main5.BackgroundImage == null)
                                pb_main5.ToShowBackgroundImage_Auto(imgres);
                            else
                                MessageBox.Show("已经全部选择完毕");
                        }
                        else if (imagetype == 2)
                        {
                            if (pb_sku1.BackgroundImage == null)
                                pb_sku1.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_sku2.BackgroundImage == null)
                                pb_sku2.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_sku3.BackgroundImage == null)
                                pb_sku3.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_sku4.BackgroundImage == null)
                                pb_sku4.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_sku5.BackgroundImage == null)
                                pb_sku5.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_sku6.BackgroundImage == null)
                                pb_sku6.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_sku7.BackgroundImage == null)
                                pb_sku7.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_sku8.BackgroundImage == null)
                                pb_sku8.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_sku9.BackgroundImage == null)
                                pb_sku9.ToShowBackgroundImage_Auto(imgres);
                            else if (pb_sku10.BackgroundImage == null)
                                pb_sku10.ToShowBackgroundImage_Auto(imgres);
                            else
                                MessageBox.Show("已经全部选择完毕");
                        }
                    }
                }
            }
        }






        #endregion

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_data_reset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要新建吗?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                reset();
            }
        }

        /// <summary>
        /// 设置每张图片点击删除图片功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_main1_Click(object sender, EventArgs e)
        {
            PictureBox pb = (sender as PictureBox);
            pb.BackgroundImage = null;
        }

        /// <summary>
        /// 详情图里双击删除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //获取鼠标所在位置的信息
            ListViewHitTestInfo info = this.listView2.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                //获取鼠标所在位置包含的ListViewItem
                ListViewItem item = info.Item;
                listView2.ToDeleteImage(item);


            }
        }


        #region 智能标题填写



        /// <summary>
        /// 标题数据框数据改变，计算还剩多少字数，并且关联效果好的关键词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_title_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string str = txt_title.Text;
                //计算后标题的数量
                int res = 0;
                res = str.GetTBTitleFontNum();
                lbl_titlefontnum.Text = "共" + (30 - res) + "个字";
                //开始关联关键词
                int num = Common.XMLHelper.GetValue("TaoBaoDataTitleSearchNum").ToInt();
                string laststr = str.Substring(str.Length - 1 - num + 1);

                if (!string.IsNullOrEmpty(laststr))
                {
                    int hid = Convert.ToInt32(cb_hangye.SelectedValue);//需要导入蓝海词列表
                    IList<Entity.lh_keydata> list = BLL2.lh_keydataManager.Search(1, 40, laststr, "", hid, 0, new DateTime(), new DateTime(), "");
                    lb_title.Visible = true;
                    lb_title.ValueMember = "kid";
                    lb_title.DisplayMember = "kname";
                    lb_title.Height = list.Count * 20;
                    lb_title.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                ex.ToString().ToLog();
            }
        }

        private void txt_title_Leave(object sender, EventArgs e)
        {

            //开始处理图片 
            Action action = closeTitleKey;
            action.BeginInvoke(null, null);
        }

        void closeTitleKey()
        {
            Browser.Delay(1000);
            //lb_title.DataSource = null;
            lb_title.Visible = false;
        }



        private void lb_title_Click(object sender, EventArgs e)
        {
            // 获取listbox1的所有选中的项
            if (this.lb_title.SelectedItems.Count > 0)
            {
                Entity.lh_keydata kd = (Entity.lh_keydata)this.lb_title.SelectedItem;
                //string str = this.lb_title.SelectedItem.ToString();
                txt_title.Text = txt_title.Text + kd.kname;
            }
            else
            {
                MessageBox.Show("未选中！");
            }
        }






        #endregion






        private void btn_makedatas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要创建数据包吗?", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            string title = txt_title.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("请输入标题");
                txt_title.Focus();
                return;
            }

            List_mian_make = new List<string>();
            List_sku_make = new List<string>();

            //设置标题为数据包名称
            dataPackageName = DateTime.Now.ToString("yyyyMMddHHmmss") + title;
            //商家编码
            string code = txt_shangjiacode.Text.Trim();
            //设置选择的模板
            int modelIndex = cb_models.SelectedIndex;
            //if (modelIndex == 0)
            //{
            //    MessageBox.Show("请选择模板");
            //    cb_models.Focus();
            //    return;
            //}

            //Image img_Main1 = pb_main1.BackgroundImage;
            //Image img_Main2 = pb_main2.BackgroundImage;
            //Image img_Main3 = pb_main3.BackgroundImage;
            //Image img_Main4 = pb_main4.BackgroundImage;
            //Image img_Main5 = pb_main5.BackgroundImage;

            //Image img_SKU1 = pb_sku1.BackgroundImage;
            //Image img_SKU2 = pb_sku2.BackgroundImage;
            //Image img_SKU3 = pb_sku3.BackgroundImage;
            //Image img_SKU4 = pb_sku4.BackgroundImage;
            //Image img_SKU5 = pb_sku5.BackgroundImage;
            //Image img_SKU6 = pb_sku6.BackgroundImage;
            //Image img_SKU7 = pb_sku7.BackgroundImage;
            //Image img_SKU8 = pb_sku8.BackgroundImage;
            //Image img_SKU9 = pb_sku9.BackgroundImage;
            //Image img_SKU10 = pb_sku10.BackgroundImage;

            string sku1 = txt_sku1.Text;
            string sku2 = txt_sku2.Text;
            string sku3 = txt_sku3.Text;
            string sku4 = txt_sku4.Text;
            string sku5 = txt_sku5.Text;
            string sku6 = txt_sku6.Text;
            string sku7 = txt_sku7.Text;
            string sku8 = txt_sku8.Text;
            string sku9 = txt_sku9.Text;
            string sku10 = txt_sku10.Text;


            string price1 = txt_price1.Text;
            string price2 = txt_price2.Text;
            string price3 = txt_price3.Text;
            string price4 = txt_price4.Text;
            string price5 = txt_price5.Text;
            string price6 = txt_price6.Text;
            string price7 = txt_price7.Text;
            string price8 = txt_price8.Text;
            string price9 = txt_price9.Text;
            string price10 = txt_price10.Text;

            ////主图的MD5图片名称  
            //string mian1 = "";
            //string mian2 = "";
            //string mian3 = "";
            //string mian4 = "";
            //string mian5 = "";

            ////SKU的MD5图片名称  
            //string sku11 = "";
            //string sku22 = "";
            //string sku33 = "";
            //string sku44 = "";
            //string sku55 = "";
            //string sku66 = "";
            //string sku77 = "";
            //string sku88 = "";
            //string sku99 = "";
            //string sku100 = "";





            #region 统一设置图片处理


            /////////////////////////////////////////////////////////////////////////
            //统一设置图片处理
            string frist = txt_first.Text.Trim();
            string last = txt_last.Text.Trim();
            string _zhiliang = txt_zhiliang.Text.Trim();

            //是否修改了文件名
            //bool isname = false;
            //新图尺寸
            //int sizenew = 0;
            //新图质量
            int zhiliang = 99;
            int.TryParse(_zhiliang, out zhiliang);
            //尺寸
            bool chicun = rb_chicun2.Checked;
            if (chicun)
            {
                //sizenew = 750;
            }
            //边框
            bool biankuang = rb_biankuang2.Checked;
            //水印
            bool shuiyin = rb_shuiyin2.Checked;
            //水印地址
            string waterpath = Application.StartupPath + "\\shuiyin.png";
            //翻转
            bool fanzhuan = rbtn_fanzhuan2.Checked;
            ///////////////////////////////////////////////////////////////////
            #endregion


            string filepath = XMLHelper_TaoBaodDataPackage.GetValue("TaoBaoDataDirectory") + "\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + dataPackageName + "\\" + title + "\\";
            Manager.CreateDirectory(filepath);
            //Action<Image, string, int, int, int, bool, bool, string, bool> action = makeDatas_Action;
            string lastname = "";


            //开始处理图片 
            #region 处理主图

            List<PictureBox> list_mian = new List<PictureBox>();

            for (int i = 0; i < 5; i++)
            {
                PictureBox pb=(PictureBox)groupBox4.Controls.Find("pb_main" + (i + 1), false)[0];
                list_mian.Add(pb);
            }

            int mainindex = 1;
            foreach (PictureBox pb in list_mian)
            {
                Image img_Main = pb.BackgroundImage;
                if (img_Main != null)
                {
                    
                    lastname = filepath + "mian" + mainindex + ".jpg";
                    makeImage(img_Main, lastname, 0, 800, zhiliang, shuiyin, biankuang, waterpath, fanzhuan, null, null);
                    string temp_main = Common.ImageClass.GetMD5Hash(lastname);
                    if (!File.Exists(filepath + temp_main + ".tbi"))
                        File.Move(lastname, filepath + temp_main + ".tbi");
                    List_mian_make.Add(temp_main);
                    mainindex++;
                }
            }

            #endregion

            //SKU图片处理
            #region SKU图片处理

            List<PictureBox> list_sku = new List<PictureBox>();
            for (int i = 0; i < 24; i++)
            {
                PictureBox pb = (PictureBox)groupBox5.Controls.Find("pb_sku" + (i + 1), false)[0];
                list_sku.Add(pb);
            }
            int skuindex = 1;
            foreach (PictureBox pb in list_sku)
            {
                Image img_SKU = pb.BackgroundImage;
                if (img_SKU != null)
                {
                    lastname = filepath + "sku" + skuindex + ".jpg";
                    makeImage(img_SKU, lastname, 0, 800, zhiliang, shuiyin, biankuang, waterpath, fanzhuan, null, null);
                    string sku_temp = Common.ImageClass.GetMD5Hash(lastname);
                    if (!File.Exists(filepath + sku_temp + ".tbi"))
                        File.Move(lastname, filepath + sku_temp + ".tbi");
                    List_sku_make.Add(sku_temp);
                }
            }

            #endregion

            #region 处理详情图


            //用于设置数据包字段 手机和电脑的详情图
            string pcstr = "<p>";
            string appstr = "<wapDesc>";

            //详情图处理
            try
            {
                int xiangqing = 1;
                //foreach (ListViewItem it in listView2.Items)
                //{
                //    string filename = it.Text;
                //    string fp = XMLHelper.GetValue("OpenFolderDialog_SelectedPath") + "\\" + filename;
                //    Image img = Image.FromFile(fp);
                //    lastname = filepath + "pc" + xiangqing + ".jpg";
                //    makeImage(img, lastname, 0, 750, zhiliang, true, true, waterpath, fanzhuan, null, null);
                //    //制作电脑详情后，设置字段
                //    pcstr += "<IMG style='MAX-WIDTH:750px' src='" + lastname + "' align=absMiddle >";

                //    lastname = filepath + "app" + xiangqing + ".jpg";
                //    makeImage(img, lastname, 0, 620, zhiliang, true, true, waterpath, fanzhuan, null, null);
                //    xiangqing++;
                //    //制作手机详情后，设置字段
                //    appstr += "<img>" + lastname + "</img>";
                //}
                //方案一
                //foreach (ListViewItem lvi in listView2.Items)
                //{
                //    string filename = lvi.Text;
                //    //string fp = XMLHelper.GetValue("OpenFolderDialog_SelectedPath") + "\\" + filename;
                //    Image img = Image.FromFile(filename);
                //    lastname = filepath + "pc" + xiangqing + ".jpg";
                //    makeImage(img, lastname, 0, 750, zhiliang, true, true, waterpath, fanzhuan, null, null);
                //    //制作电脑详情后，设置字段
                //    pcstr += "<IMG style='MAX-WIDTH:750px' src='" + lastname + "' align=absMiddle >";

                //    lastname = filepath + "app" + xiangqing + ".jpg";
                //    makeImage(img, lastname, 0, 620, zhiliang, true, true, waterpath, fanzhuan, null, null);
                //    xiangqing++;
                //    //制作手机详情后，设置字段
                //    appstr += "<img>" + lastname + " </img>";
                //}
                //方案二
                //然后重新排序
                List<PictureBox> list = pan_pc.Controls.GetPictureBoxs();
                //pan_pc.Controls.Clear();
                //pc_num = 0;
                foreach (PictureBox picb in list)
                {
                    Image img = picb.BackgroundImage;
                    lastname = filepath + "pc" + xiangqing + ".jpg";
                    makeImage(img, lastname, 0, 750, zhiliang, true, true, waterpath, fanzhuan, null, null);
                    //制作电脑详情后，设置字段
                    pcstr += "<IMG style='MAX-WIDTH:750px' src='" + lastname + "' align=absMiddle >";

                    lastname = filepath + "app" + xiangqing + ".jpg";
                    makeImage(img, lastname, 0, 620, zhiliang, true, true, waterpath, fanzhuan, null, null);
                    xiangqing++;
                    //制作手机详情后，设置字段
                    appstr += "<img>" + lastname + "</img>";
                    //appstr += "<img>" + title + "\\" + "app" + xiangqing + ".jpg" + " </img>";
                }

            }
            catch
            {

            }
            pcstr += "</p>";
            appstr += "</wapDesc>";
            #endregion

            //开始处理csv文件

            DataTable dt = Common.CSVFileHelper.OpenCSV(Application.StartupPath + "\\model.csv");
            if (dt == null)
            {
                MessageBox.Show("读取模板失败");
                return;
            }
            //添加数据行
            DataRow dr = dt.NewRow();
            //标题
            dr[0] = title; //通过索引赋值
            //宝贝类目，需要动态填写，根据模板吧
            //dr[1] = "";

            //循环采集xml文件中的默认数据
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                //获取模板中的英文列名
                string name = dt.Rows[0][i].ToString();

                if (name == "title")
                {
                    dr[i] = title;
                    continue;
                }
                else if (name == "cid")
                {
                    //获取类目ID
                    dr[i] = XMLHelper_TaoBaodDataPackage.GetValue("cateProps" + (modelIndex + 1), "cid");
                }
                else if (name == "price")
                {
                    dr[i] = getSKUPrice();
                }
                else if (name == "num")
                {
                    dr[i] = getSKUNum() * 1000;
                }
                else if (name == "cateProps")
                {
                    //设置模板宝贝属性
                    dr[i] = XMLHelper_TaoBaodDataPackage.GetValue("cateProps" + (modelIndex + 1)) + set_cateProps_sku();
                }
                else if (name == "modified")
                {
                    dr[i] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                }
                else if (name == "picture_status")
                {
                    //设置要上传多少图片
                    int num = getMainNum() + getSKUNum();
                    string res = "";
                    for (int j = 0; j < num; j++)
                    {
                        res = res + "2;";
                    }
                    dr[i] = res;
                }
                else if (name == "picture")
                {
                    //设置新图片
                    dr[i] = set_Picture();
                }
                else if (name == "skuProps")
                {
                    dr[i] = set_skuProps();
                }
                else if (name == "input_custom_cpv")
                {
                    dr[i] = set_input_custom_cpv();
                }
                else if (name == "outer_id")
                {
                    dr[i] = code;
                }
                else if (name == "description")
                {
                    dr[i] = pcstr;
                }
                else if (name == "wireless_desc")
                {
                    dr[i] = appstr;
                }

                string val = XMLHelper_TaoBaodDataPackage.GetValue(name);
                if (!string.IsNullOrEmpty(val))
                {
                    dr[i] = val;
                    Debug.WriteLine(val);
                }
            }




            dt.Rows.Add(dr);
            //string filepath = XMLHelper_TaoBaodDataPackage.GetValue("TaoBaoDataDirectory") + "\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + dataPackageName + "\\" + title + "\\";
            string p = XMLHelper_TaoBaodDataPackage.GetValue("TaoBaoDataDirectory") + "\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + dataPackageName;
            Common.CSVFileHelper.SaveCSV(dt, p + "\\" + title + ".csv");

            MessageBox.Show("数据包处理完成");
            Manager.OpenProgram_Directory(p);

        }


        #region MyRegion


        /// <summary>
        /// 用于制作数据包的新图片上新字段 
        /// </summary>
        /// <returns></returns>
        string set_Picture()
        {
            string res = "";

            //设置主图
            //5f42f5e0fa513fa4298faf37700dfd18:1:0:|;
            //List_mian_make.ToSortReverse();
            for (int i = 0; i < getMainNum(); i++)
            {

                res += List_mian_make[i] + ":1:" + (i) + ":|;";
            }
            //if (getMainNum() > 0)
            //{
            //    res += mian1 + ":1:0:|;";
            //}
            //if (getMainNum() > 1)
            //{
            //    res += mian2 + ":1:1:|;";
            //}
            //if (getMainNum() > 2)
            //{
            //    res += mian3 + ":1:2:|;";
            //}
            //if (getMainNum() > 3)
            //{
            //    res += mian4 + ":1:3:|;";
            //}
            //if (getMainNum() > 4)
            //{
            //    res += mian5 + ":1:4:|;";
            //}
            //设置SKU图片
            // e27319b95d59c2ebf94029ed51cf1e2d:2:0:1627207:-1001|;
            //List_sku_make.ToSortReverse();
            for (int i = 0; i < getSKUNum(); i++)
            {
                string temp = (i+1).ToString("00");
                res += List_sku_make[i] + ":2:0:1627207:-10"+ temp + "|;";
            }
            //if (getSKUNum() > 0)
            //{
            //    res += sku11 + ":2:0:1627207:-1001|;";
            //}
            //if (getSKUNum() > 1)
            //{
            //    res += sku22 + ":2:0:1627207:-1002|;";
            //}
            //if (getSKUNum() > 2)
            //{
            //    res += sku33 + ":2:0:1627207:-1003|;";
            //}
            //if (getSKUNum() > 3)
            //{
            //    res += sku44 + ":2:0:1627207:-1004|;";
            //}
            //if (getSKUNum() > 4)
            //{
            //    res += sku55 + ":2:0:1627207:-1005|;";
            //}
            //if (getSKUNum() > 5)
            //{
            //    res += sku66 + ":2:0:1627207:-1006|;";
            //}
            //if (getSKUNum() > 6)
            //{
            //    res += sku77 + ":2:0:1627207:-1007|;";
            //}
            //if (getSKUNum() > 7)
            //{
            //    res += sku88 + ":2:0:1627207:-1008|;";
            //}
            //if (getSKUNum() > 8)
            //{
            //    res += sku99 + ":2:0:1627207:-1009|;";
            //}
            //if (getSKUNum() > 9)
            //{
            //    res += sku100 + ":2:0:1627207:-1010|;";
            //}


            return res;
        }
        #endregion




        #region set_cateProps_sku
        /// <summary>
        /// 设置cateProps字段 例如：1627207:-1001（sku1编号-1001升序）;,在cateProps 字段最后追加上即可
        /// </summary>
        /// <returns></returns>
        string set_cateProps_sku()
        {
            string res = "";
            //设置淘宝自定义序号
            int indexx = 1001;
            for (int i = 0; i < getSKUNum(); i++)
            {
                res += "1627207:-" + indexx + ";";
                indexx++;
            }
            return res;
        }
        #endregion

        #region set_skuProps
        /// <summary>
        /// 设置skuProps字段 例如：99:100::1627207:-1001;99:100::1627207:-1002;
        /// </summary>
        /// <returns></returns>
        string set_skuProps()
        {
            string res = "";
            //设置淘宝自定义序号
            int indexx = 1001;
            for (int i = 0; i < getSKUNum(); i++)
            {
                TextBox tb = (TextBox)groupBox5.Controls.GetControlByName("txt_price" + (i + 1));
                res += tb.Text.Trim() + ":1000::1627207:-" + indexx + ";";
                indexx++;
            }
            return res;
        }
        #endregion

        #region set_input_custom_cpv
        /// <summary>
        /// 设置input_custom_cpv字段 例如：1627207:-1001:自定义白色;1627207:-1002:自定义黑色;
        /// </summary>
        /// <returns></returns>
        string set_input_custom_cpv()
        {
            string res = "";
            //设置淘宝自定义序号
            int indexx = 1001;
            for (int i = 0; i < getSKUNum(); i++)
            {
                TextBox tb = (TextBox)groupBox5.Controls.GetControlByName("txt_sku" + (i + 1));
                res += "1627207:-" + indexx + ":" + tb.Text + ";";
                indexx++;
            }
            return res;
        }
        #endregion


        #region getSKUNum
        /// <summary>
        /// 获取sku设置好的数量，条件是：图片和名称价格都要，任何一个值没有则，从该序列sku开始不计数
        /// </summary>
        /// <returns></returns>
        int getSKUNum()
        {
            int res = 24;
            for (int i = 1; i <= 24; i++)
            {
                PictureBox pb = (PictureBox)groupBox5.Controls.GetControlByName("pb_sku" + i);
                TextBox tb1 = (TextBox)groupBox5.Controls.GetControlByName("txt_sku" + i);
                TextBox tb2 = (TextBox)groupBox5.Controls.GetControlByName("txt_price" + i);
                if (pb.BackgroundImage == null || string.IsNullOrEmpty(tb1.Text) || string.IsNullOrEmpty(tb2.Text))
                    return i - 1;
            }
            return res;
        }
        #endregion

        #region getSKUPrice
        /// <summary>
        /// 获取设置好的sku中最低的出售价格
        /// </summary>
        /// <returns></returns>
        decimal getSKUPrice()
        {
            decimal res = 98;

            for (int i = 1; i <= getSKUNum(); i++)
            {
                TextBox tb2 = (TextBox)groupBox5.Controls.GetControlByName("txt_price" + i);
                decimal temp = 98;
                decimal.TryParse(tb2.Text, out temp);
                if (temp < res)
                    res = temp;
            }
            return res;
        }
        #endregion

        #region getMainNum
        /// <summary>
        /// 获取主图设置好的数量，条件是：图片为空，从该序列sku开始不计数
        /// </summary>
        /// <returns></returns>
        int getMainNum()
        {
            int res = 5;
            for (int i = 1; i <= 5; i++)
            {
                Image img_Main1 = pb_main1.BackgroundImage;
                PictureBox pb = (PictureBox)groupBox4.Controls.GetControlByName("pb_main" + i);
                if (pb.BackgroundImage == null)
                    return i - 1;
            }
            return res;
        }
        #endregion


        /// <summary>
        /// 取消异步操作后新建的统一处理图片方法
        /// </summary>
        /// <param name="img"></param>
        /// <param name="dFile"></param>
        /// <param name="dHeight"></param>
        /// <param name="dWidth"></param>
        /// <param name="flag"></param>
        /// <param name="isshuiyin"></param>
        /// <param name="isbiankuang"></param>
        /// <param name="waterpath"></param>
        /// <param name="isfanzhuan"></param>
        /// <param name="n1"></param>
        /// <param name="n2"></param>
        void makeImage(Image img, string dFile, int dHeight, int dWidth, int flag, bool isshuiyin, bool isbiankuang, string waterpath, bool isfanzhuan, DBNull n1, DBNull n2)
        {
            CS.ImageClass.ImageMake(img, dFile, dHeight, dWidth, flag, isshuiyin, isbiankuang, waterpath, isfanzhuan);
            //清空缓存
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }




        #region makeDatas_Action
        /// <summary>
        /// 多线程处理图片,因为数据不同步 所以取消异步操作
        /// </summary>
        /// <param name="sFile"></param>
        /// <param name="dFile"></param>
        /// <param name="dHeight"></param>
        /// <param name="dWidth"></param>
        /// <param name="flag"></param>
        /// <param name="isshuiyin"></param>
        /// <param name="isbiankuang"></param>
        /// <param name="waterpath"></param>
        void makeDatas_Action(Image img, string dFile, int dHeight, int dWidth, int flag, bool isshuiyin, bool isbiankuang, string waterpath, bool isfanzhuan)
        {
            CS.ImageClass.ImageMake(img, dFile, dHeight, dWidth, flag, isshuiyin, isbiankuang, waterpath, isfanzhuan);
            //清空缓存
            GC.WaitForPendingFinalizers();
            GC.Collect();

        }

        #endregion

        #region txt_sku1_TextChanged 保存sku
        /// <summary>
        /// 保存sku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_sku1_TextChanged(object sender, EventArgs e)
        {
            saveSKU();
        }

        /// <summary>
        /// 采集SKU数据到xml
        /// </summary>
        void saveSKU()
        {
            string res = "";
            for (int i = 1; i <= 24; i++)
            {
                string name = ""; ;
                string price = "";
                object obj = groupBox5.Controls.GetControlByName("txt_sku" + i);
                if (obj != null)
                {
                    TextBox tb = (TextBox)obj;
                    name = tb.Text;
                    res = res + name;
                }
                obj = groupBox5.Controls.GetControlByName("txt_price" + i);
                if (obj != null)
                {
                    TextBox tb = (TextBox)obj;
                    price = tb.Text;
                    res = res + "-" + price;
                }
                if (i < 10)
                    res += "|";
            }
            XMLHelper_TaoBaodDataPackage.SetValue("TaoBaoDataSKU", res);


        }
        #endregion

        #region btn_price_tongyi_Click
        private void btn_price_tongyi_Click(object sender, EventArgs e)
        {
            string price = txt_price_tongyi.Text.Trim();
            if (string.IsNullOrEmpty(price))
            {
                MessageBox.Show("请输入正确的sku");
                return;
            }
            for (int i = 1; i < 25; i++)
            {
                object obj = groupBox5.Controls.GetControlByName("txt_price" + i);
                if (obj != null)
                {
                    TextBox tb = (TextBox)obj;
                    tb.Text = (price.ToDecimal() * 2).ToString();
                }
            }
        }


        #endregion

        #endregion


        #region SKU


        #region sku_selectindex
        /// <summary>
        /// 获取SKU的选项编号
        /// </summary>
        string sku_selectindex()
        {
            string res = "";
            string select_text = cb_sku.Text;
            if (select_text.IndexOf("方案") != -1)
            {
                res = select_text.Replace("方案", "");
            }
            return res;
        }
        #endregion

        #region bind_cb_sku
        /// <summary>
        /// 绑定SKU信息
        /// </summary>
        /// <param name="typeindex">方案编号</param>
        void bind_cb_sku(string typeindex)
        {
            try
            {
                if (!string.IsNullOrEmpty(typeindex))
                {

                    for (int i = 0; i < 24; i++)
                    {
                        //获取xml文件中的数据
                        string values = XMLHelper_SKU.GetValue("SKU" + typeindex + "_" + (i + 1).ToString());

                        //设置sku中name属性
                        string control_name = "txt_sku" + (i + 1).ToString();
                        TextBox TB = (TextBox)groupBox5.Controls.Find(control_name, false)[0];
                        TB.Text = values.Split(new char[] { '|' })[0];

                        //设置sku中price属性
                        control_name = "txt_price" + (i + 1).ToString();
                        TextBox TB2 = (TextBox)groupBox5.Controls.Find(control_name, false)[0];
                        TB2.Text = values.Split(new char[] { '|' })[1];


                        //设置sku中name属性
                        string control_name2 = "txt_skuname" + (i + 1).ToString();
                        TextBox TB3 = (TextBox)tp_sku.Controls.Find(control_name2, false)[0];
                        TB3.Text = values.Split(new char[] { '|' })[0];

                        //设置sku中price属性
                        control_name2 = "txt_skuprice" + (i + 1).ToString();
                        TextBox TB4 = (TextBox)tp_sku.Controls.Find(control_name2, false)[0];
                        TB4.Text = values.Split(new char[] { '|' })[1];

                        //设置sku中图片
                        control_name = "pb_sku" + (i + 1).ToString();
                        PictureBox pb = (PictureBox)groupBox5.Controls.Find(control_name, false)[0];
                        if (pb != null)
                        {
                            pb.BackgroundImage = null;
                            string filepath = Application.StartupPath + "\\Image\\sku\\sku" + typeindex + "_" + (i + 1) + ".jpg";
                            if (Manager.fileFind(filepath))
                            {
                                Image img = Image.FromFile(filepath);
                                pb.ToShowBackgroundImage_Auto(img);
                            }
                        }

                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("绑定sku信息失败，" + e.ToString());
            }
        }

        /// <summary>
        /// 选择模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb_sku_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_cb_sku(sku_selectindex());
        }


        #endregion

        private void btn_sku_reset_Click(object sender, EventArgs e)
        {
            bind_cb_sku(sku_selectindex());
            MessageBox.Show("重置成功!");
        }

        private void btn_sku_save_Click(object sender, EventArgs e)
        {
            try
            {
                string typeindex = sku_selectindex();

                if (!string.IsNullOrEmpty(typeindex))
                {
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_1", txt_skuname1.Text + "|" + txt_skuprice1.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_2", txt_skuname2.Text + "|" + txt_skuprice2.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_3", txt_skuname3.Text + "|" + txt_skuprice3.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_4", txt_skuname4.Text + "|" + txt_skuprice4.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_5", txt_skuname5.Text + "|" + txt_skuprice5.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_6", txt_skuname6.Text + "|" + txt_skuprice6.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_7", txt_skuname7.Text + "|" + txt_skuprice7.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_8", txt_skuname8.Text + "|" + txt_skuprice8.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_9", txt_skuname9.Text + "|" + txt_skuprice9.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_10", txt_skuname10.Text + "|" + txt_skuprice10.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_11", txt_skuname11.Text + "|" + txt_skuprice11.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_12", txt_skuname12.Text + "|" + txt_skuprice12.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_13", txt_skuname13.Text + "|" + txt_skuprice13.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_14", txt_skuname14.Text + "|" + txt_skuprice14.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_15", txt_skuname15.Text + "|" + txt_skuprice15.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_16", txt_skuname16.Text + "|" + txt_skuprice16.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_17", txt_skuname17.Text + "|" + txt_skuprice17.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_18", txt_skuname18.Text + "|" + txt_skuprice18.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_19", txt_skuname19.Text + "|" + txt_skuprice19.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_20", txt_skuname20.Text + "|" + txt_skuprice20.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_21", txt_skuname21.Text + "|" + txt_skuprice21.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_22", txt_skuname22.Text + "|" + txt_skuprice22.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_23", txt_skuname23.Text + "|" + txt_skuprice23.Text);
                    XMLHelper_SKU.SetValue("SKU" + typeindex + "_24", txt_skuname24.Text + "|" + txt_skuprice24.Text);

                    MessageBox.Show("保存成功!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存sku信息失败，" + ex.ToString());
            }
        }


        #region cb_sku_type_SelectedIndexChanged
        private void cb_sku_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            bind_cb_sku(sku_selectindex());
        }


        #endregion

        #endregion


        #region button1_Click_2

        
        private void button1_Click_2(object sender, EventArgs e)
        {

            try
            {
                toolStripProgressBar1.Value = 0;

                string fileurl = txt_url.Text.Trim();
                if (string.IsNullOrEmpty(fileurl))
                {
                    MessageBox.Show("请输入文件路径");
                    return;
                }
                string frist = txt_first.Text.Trim();
                string last = txt_last.Text.Trim();
                string _zhiliang = txt_zhiliang.Text.Trim();

                //是否修改了文件名
                //bool isname = false;
                //新图尺寸
                int sizenew = 0;
                //新图质量
                int zhiliang = 99;
                int.TryParse(_zhiliang, out zhiliang);
                //尺寸
                bool chicun = rb_chicun2.Checked;
                if (chicun)
                {
                    sizenew = 750;
                }
                //边框
                bool biankuang = rb_biankuang2.Checked;
                //水印
                bool shuiyin = rb_shuiyin2.Checked;
                //水印地址
                string waterpath = Application.StartupPath + "\\shuiyin.png";
                //翻转
                bool fanzhuan = rbtn_fanzhuan2.Checked;

                picindex = 0;


                //修改图片名

                //string[] path = Directory.GetFiles(@fileurl);

                List<string> list = CS.FileHelper.FindFile2(@fileurl, "jpg|tbi");
                //int filecount = list.Count;
                //设置状态栏的最大值
                toolStripProgressBar1.Maximum = list.Count;
                picnum = list.Count;
                //lbl_message.Text = "需处理文件: " + filecount.ToString() + " 个";

                foreach (string str in list)
                {
                    //清空缓存
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    FileInfo file = new FileInfo(str);
                    //截取文件名 如 asdf.txt ->asdf
                    string f = file.Name.Substring(0, file.Name.LastIndexOf("."));
                    //原始文件地址
                    string fristname = file.DirectoryName + "\\" + (f + file.Extension);
                    //txt_message.Text = "正在处理：" + fristname;
                    //替换指定文件名 新文件地址 file.Extension指文件的后缀名
                    //修改文件名
                    if (!string.IsNullOrEmpty(frist))
                    {
                        f = frist + "_" + f;
                        //isname = true;
                    }
                    if (!string.IsNullOrEmpty(last))
                    {
                        f = f + "_" + last;
                        //isname = true;
                    }
                    //新文件名称地址
                    string lastname = file.DirectoryName + "\\" + (f + file.Extension);
                    //将指定文件移动到新的位置,并重新指定文件名

                    //水印地址

                    //开始处理图片 
                    //Action<string, string, int, int, int, bool, bool, string, bool> action = PicMake_Action;
                    //CS.ImageClass.GetPicThumbnail(fristname, lastname, 0, sizenew, zhiliang, shuiyin, biankuang, waterpath);
                    //action.BeginInvoke(fristname, lastname, 0, sizenew, zhiliang, shuiyin, biankuang, waterpath, fanzhuan, null, null);
                    PicMake_Action(fristname, lastname, 0, sizenew, zhiliang, shuiyin, biankuang, waterpath, fanzhuan);
                    //lbl_message2.Text = "文件剩余: " + (filecount - 1).ToString() + " 个";
                }
                //设置状态栏全部完成
                //while (toolStripProgressBar1.Value < toolStripProgressBar1.Maximum)
                //{
                //    toolStripProgressBar1.PerformStep();//按照Step的值进行递增！
                //}
                //MessageBox.Show("天天好心情^-^！ 图片处理完成！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        private void txt_url_down_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txt_save_TextChanged(object sender, EventArgs e)
        {

        }
    }



}

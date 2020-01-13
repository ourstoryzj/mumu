using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace Operation
{
    public partial class MainForm : Form
    {


        DateTime dttmep = DateTime.Now;
        //用于在状态栏显示任务信息
        string task_info = "";
        //用于截取任务信息
        int i = 0;

        public MainForm()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
            StartPosition = FormStartPosition.CenterScreen;
            //this.skinEngine1.SkinFile = System.Environment.CurrentDirectory + "\\skin\\Carlmness\\" + "CalmnessColor1.ssk";
            this.WindowState = FormWindowState.Maximized;


            #region 打开网页
            //Other.Common fm = new Other.Common();
            //fm.MdiParent = this;
            //fm.Show();
            //fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/index.aspx");
            #endregion

            CS.Music.play_1();

            //TaskShowTool();
            //TaskShow();

            //查找并删除debug.log File.Delete(sFile);
            //if (Manager.fileFind(Manager.PathAppliction() + "//debug.log"))
            //{
            //    File.Delete(Manager.PathAppliction() + "//debug.log");
            //}
        }

        #region 显示任务
        #region TaskShow
        /// <summary>
        /// 显示任务信息
        /// </summary>
        void TaskShow()
        {
            DateTime temp_date1 = new DateTime();
            DateTime temp_date2 = new DateTime();

            List<Entity.basic_task> list = (List<Entity.basic_task>)BLL.basic_taskManager.Search(1, 1000, "", "1", temp_date1, temp_date2, new DateTime(), new DateTime(), "");

            string mess = "";
            foreach (Entity.basic_task bt in list)
            {
                if (DateTime.Now.ToString("yyyyMMdd") == bt.btdate.ToString("yyyyMMdd"))
                {
                    //定时提醒
                    mess = mess + bt.btname + "\n\r" + bt.btcontent + "\n\r\n\r";
                }
                else if (bt.btspare1 == "1")
                {
                    //每天提醒
                    mess = mess + bt.btname + "\n\r" + bt.btcontent + "\n\r\n\r";
                }
                else if (bt.btspare1 == "2")
                {
                    //每月提醒
                    if (DateTime.Now.ToString("dd") == bt.btdate.ToString("dd"))
                    {
                        mess = mess + bt.btname + "\n\r" + bt.btcontent + "\n\r\n\r";
                    }
                }
                else if (bt.btspare1 == "3")
                {
                    //每年提醒
                    if (DateTime.Now.ToString("MMdd") == bt.btdate.ToString("MMdd"))
                    {
                        mess = mess + bt.btname + "\n\r" + bt.btcontent + "\n\r\n\r";
                    }
                }
            }

            if (!string.IsNullOrEmpty(mess))
            {
                MessageBox.Show(mess);
            }
        }
        #endregion

        #region TaskShowTool
        void TaskShowTool()
        {
            DateTime temp_date1 = new DateTime();
            DateTime temp_date2 = new DateTime();
            List<Entity.basic_task> list = (List<Entity.basic_task>)BLL.basic_taskManager.Search(1, 1000, "", "1", temp_date1, temp_date2, new DateTime(), new DateTime(), "");

            string mess = "";
            foreach (Entity.basic_task t in list)
            {
                string title = Manager.NoHTML(t.btname);
                string content = Manager.NoHTML(t.btcontent);
                mess = mess + title + ":" + content + " ============ ";
            }
            task_info = mess;

            //if (!string.IsNullOrEmpty(mess))
            //{
            //    tssl_task.Text = mess;
            //}
        }


        void SubTaskMess(int index)
        {
            try
            {
                int length = 100;
                int length2 = task_info.Length - index;
                if (length >= length2)
                {
                    index = 0;
                    length = task_info.Length;
                }
                //if (index == (task_info.Length - 123))
                //{
                //    index = 0;
                //}
                if (index % 3 == 0)
                {

                    tssl_task.Text = "未完成任务：" + task_info.Substring(index, length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                timer1.Stop();
            }

        }


        #endregion

        //DateTime dt = DateTime.Now.AddSeconds(5);
        //void test()
        //{
        //    if (DateTime.Now.ToString() == dt.ToString())
        //    {
        //        Manager.SetShowAndTop();
        //    }
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
            SubTaskMess(i);
            i++;
            //test();
            //DateTime dt1 = dttmep.AddSeconds(15);
            //DateTime dt2 = DateTime.Now;

            /////打开软件5秒后
            //if (dt1.Second==dt2.Second)
            //{
            //    //MessageBox.Show("");
            //    flashTaskBar(this.Handle, falshType.FLASHW_TIMERNOFG);
            //}

        }
        #endregion

        #region 退出软件
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CefSharp.Cef.Shutdown();
            System.Environment.Exit(0);
        } 
        #endregion

        #region OldBtnEvent



        private void 关键词处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void 图片采集ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imageFrom fm = new imageFrom();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 售后ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //shouhouFrom fm = new shouhouFrom();
            //fm.MdiParent = this;
            //fm.Show();
            //fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

        private void 店铺设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dianpuFrom fm = new dianpuFrom();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 返现ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fanxianFrom fm = new fanxianFrom();
            //fm.MdiParent = this;
            //fm.Show();
            //fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            #region 打开网页
            //Other.Common fm = new Other.Common();
            Other.MeiTuXiuXiu fm = new Other.MeiTuXiuXiu();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/huashu_list.aspx");
            #endregion
        }

        private void 竞争对手分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataAnalysis.DA_Opponent fm = new DataAnalysis.DA_Opponent();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 生意参谋助理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Operation.DataAnalysis.CanMou_KeysHelper fm = new DataAnalysis.CanMou_KeysHelper();
            DataAnalysis.CanMou_Keys fm = new DataAnalysis.CanMou_Keys();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 单肩包ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mogujie_danjian md = new mogujie_danjian();
            md.MdiParent = this;
            md.Show();
            md.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 双肩包ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoNew.test md = new AutoNew.test();
            //mogujie_danjian md = new mogujie_danjian();
            md.MdiParent = this;
            md.Show();
            md.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 双肩包ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Taobao_shuangjian md = new Taobao_shuangjian();
            //md.MdiParent = this;
            //md.Show();
            //md.WindowState = FormWindowState.Maximized;
        }

        private void 网供商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WangGong.WG_Goods md = new WangGong.WG_Goods();
            md.MdiParent = this;
            md.Show();
            md.WindowState = FormWindowState.Maximized;
        }

        private void 淘宝常用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoBao.TB_Often md = new TaoBao.TB_Often();
            md.MdiParent = this;
            md.Show();
            md.WindowState = FormWindowState.Maximized;
        }



        private void 登录ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Other.Login md = new Other.Login();
            md.MdiParent = this;
            md.Show();
            //md.WindowState = FormWindowState.Maximized;
        }

        private void 蘑菇街常用ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MoGuJie.MGJ_Often md = new MoGuJie.MGJ_Often();
            //md.MdiParent = this;
            //md.Show();
            //md.WindowState = FormWindowState.Maximized;
        }

        private void 主图采集精灵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoBao.ZhuTu md = new TaoBao.ZhuTu();
            md.MdiParent = this;
            md.Show();
            md.WindowState = FormWindowState.Maximized;
        }

        private void 关键词助手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoBao.TB_Keys_bak md = new TaoBao.TB_Keys_bak();
            md.MdiParent = this;
            md.Show();
            md.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void 噪词管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoBao.TB_ZaoCi fm = new TaoBao.TB_ZaoCi();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;

        }

        private void 清空缓存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Browser.ClearData();
        }




        private void 主图下载精灵ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoBao.ZhuTu zt = new TaoBao.ZhuTu();
            zt.MdiParent = this;
            zt.Show();
            zt.WindowState = FormWindowState.Maximized;
        }

        private void 蘑菇街常用2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mogujie_danjian fm = new mogujie_danjian();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        }

        private void 刷单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //MoGuJie.MGJ_ShuaDan fm = new MoGuJie.MGJ_ShuaDan();
            //fm.MdiParent = this;
            //fm.Show();
            //fm.WindowState = FormWindowState.Maximized;
        }

        private void 添加刷单记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ShuaDan.ShuaDan_Add fm = new ShuaDan.ShuaDan_Add();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        }

        private void 蘑菇街模拟刷单ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 刷单列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShuaDan.ShuaDan_List3 fm = new ShuaDan.ShuaDan_List3();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        }

        private void 短信平台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShuaDan.MessageTest fm = new ShuaDan.MessageTest();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;

        }

        private void 刷单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test.test_ip fm = new Test.test_ip();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //System.Environment.Exit(0);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
            //System.Environment.Exit(0);
        }

        private void 清空缓存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Browser.ClearData();
        }

        private void 黄金关键词ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 关键词处理旧ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_main fm = new form_main();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 蘑菇街模拟刷单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //MoGuJie.MGJ_ShuaDan3 fm = new MoGuJie.MGJ_ShuaDan3();
            //fm.MdiParent = this;
            //fm.Show();
            //fm.WindowState = FormWindowState.Maximized;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void 图片处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoBao.PicMake fm = new TaoBao.PicMake();
            //Test.test_guge fm = new Test.test_guge();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
        }

        private void 设置IEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager.BrowserEmulationSet();
        }

        private void 包牛牛代发ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Other.BaoNiuNiu zt = new Other.BaoNiuNiu();
            zt.MdiParent = this;
            zt.Show();
            zt.WindowState = FormWindowState.Maximized;
        }

        private void 话术列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/huashu_list.aspx");
            #endregion
        }

        private void 添加话术ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/huashu_add.aspx");
            #endregion
        }

        private void 话术类型列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/huashu_type_list.aspx");
            #endregion
        }

        private void 添加话术类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/huashu_type_add.aspx");
            #endregion

        }

        private void 资料列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/pages_list.aspx");
            #endregion

        }

        private void 添加资料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/pages_add.aspx");
            #endregion

        }

        private void 资料类型列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/pages_type_list.aspx");
            #endregion

        }

        private void 添加资料类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/pages_type_add.aspx");
            #endregion

        }

        private void 待处理售后ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/sh_problem_list.aspx?state=1");
            #endregion
        }

        private void 全部售后列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/sh_problem_list.aspx");
            #endregion
        }

        private void 添加售后ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/sh_problem_add.aspx");
            #endregion
        }

        private void 任务列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/basic_task_list.aspx");
            #endregion
        }

        private void 添加任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/basic_task_add.aspx");
            #endregion

        }

        private void 退货列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/return_goods_list.aspx");
            #endregion
        }

        private void 添加退货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            Other.Common fm = new Other.Common();
            fm.MdiParent = this;
            fm.Show();
            fm.webBrowser1.Load("http://qxw1590980318.my3w.com/oa/return_goods_add.aspx");
            #endregion

        }

        private void 直通车助手ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            TaoBao.TB_ZhiTongChe fm = new TaoBao.TB_ZhiTongChe();
            fm.MdiParent = this;
            fm.Show();
            #endregion
        }

        private void 图片空间清理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            TaoBao.TB_ImgDelete fm = new TaoBao.TB_ImgDelete();
            fm.MdiParent = this;
            fm.Show();
            #endregion
        }

        private void 拼多多ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            PDD fm = new PDD();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            #endregion
        }

        private void 直通车助手ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            #region 打开网页
            TaoBao.TB_ZhiTongChe fm = new TaoBao.TB_ZhiTongChe();
            fm.MdiParent = this;
            fm.Show();
            #endregion
        }

        private void 打单发货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region 打开网页
            TaoBao.TB_FaHuo fm = new TaoBao.TB_FaHuo();
            fm.MdiParent = this;
            fm.Show();
            #endregion
        }

        private void 打单发货ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            #region 打开网页
            TaoBao.TB_FaHuo fm = new TaoBao.TB_FaHuo();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
            #endregion
        }

        private void 任务管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Other.TaskWork fm = new Other.TaskWork();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tssl_task_Click(object sender, EventArgs e)
        {
            Other.TaskWork fm = new Other.TaskWork();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 蓝海词管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoBao.TB_Keys2 fm = new TaoBao.TB_Keys2();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 蓝海词管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TaoBao.TB_Keys2 fm = new TaoBao.TB_Keys2();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 行业数据分析ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaoBao.TB_KeysAnalysis fm = new TaoBao.TB_KeysAnalysis();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void 蘑菇街ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Other.ImageDownload fm = new Other.ImageDownload();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        }

        private void 拼多多代发ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PinDuoDuo.PDD_DaiFa fm = new PinDuoDuo.PDD_DaiFa();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region 测试



        private void 测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region MyRegion
            //Test.test_caiji zt = new Test.test_caiji();
            ////Common.BaoNiuNiu zt = new Common.BaoNiuNiu();
            ////Common.FaHuoFrom zt = new Common.FaHuoFrom();
            ////Test.test_meau zt = new Test.test_meau();
            ////Test.test_caiji zt = new Test.test_caiji();
            //zt.MdiParent = this;
            //zt.Show();
            //zt.WindowState = FormWindowState.Maximized;

            ////dt= DateTime.Now.AddSeconds(5);

            //test_download td = new test_download();
            //td.MdiParent = this;
            //td.Show();
            //td.WindowState = FormWindowState.Maximized;
            //try
            //{

            //}
            //catch (Exception ex)
            //{

            //}
            //Other.ImageDownload fm = new Other.ImageDownload();
            //Test.test_meau fm = new Test.test_meau();
            //Test.test_webrequest fm = new Test.test_webrequest();
            ////Test.test_pinduoduo_login fm = new Test.test_pinduoduo_login();
            ////Test.test_chrome fm = new Test.test_chrome();
            //fm.MdiParent = this;
            //fm.Show();
            //fm.WindowState = FormWindowState.Maximized; 
            #endregion

        }


        private void 诺人电商模拟ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test.test_nuoren fm = new Test.test_nuoren();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        }

        private void httpWebRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test.test_webrequest fm = new Test.test_webrequest();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        }


        private void cEFSharp测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test.test_chrome fm = new Test.test_chrome();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        }



        #endregion

        #region 生成二维码ToolStripMenuItem_Click
        private void 生成二维码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test.test_erweima fm = new Test.test_erweima();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        }


        #endregion

        #region json测试ToolStripMenuItem_Click
        private void json测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Test.test_json fm = new Test.test_json();
            fm.MdiParent = this;
            fm.Show();
            fm.WindowState = FormWindowState.Maximized;
        } 
        #endregion
    }
}

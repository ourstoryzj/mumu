using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimelyReminder
{
    public partial class TimelyRemminder : Form
    {

        //任务到达时间
        DateTime dt_ok;
        //设置多久提醒
        double longtime = 40;

        public TimelyRemminder()
        {
            InitializeComponent();
            bind();
            //this.ControlBox = false;
        }

        void bind()
        {
            //居中显示
            StartPosition = FormStartPosition.CenterScreen;
            string times = new CS.XMLHelpers("").GetValue("Times");
            txt_time.Text = times;

            if (!double.TryParse(times, out longtime))
            {
                MessageBox.Show("请输入正确的时间");
                txt_time.SelectAll();
                return;
            }

            setTimeOk();
        }

        //设定任务到达时间
        void setTimeOk()
        {
            //设定任务到达时间
            DateTime dt = DateTime.Now;
            dt_ok = dt.AddMinutes(longtime);
            lbl_timeok.Text = "下次提醒时间为："+dt_ok.ToString("HH:mm:ss") ;
        }


        private void btn_ok_Click(object sender, EventArgs e)
        {
            string times = txt_time.Text;

            if (string.IsNullOrEmpty(times))
            {
                MessageBox.Show("请输入时间");
                return;
            }
            if (!double.TryParse(times, out longtime))
            {
                MessageBox.Show("请输入正确的时间");
                txt_time.SelectAll();
                return;
            }

            //保存数据
            new CS.XMLHelpers("").SetValue("Times", times);

            //设定任务到达时间
            setTimeOk();

            //最小化 缩小窗口
            this.WindowState = FormWindowState.Minimized;
            //测试
            //ShowIMG si = new ShowIMG();
            //si.Show();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //判断是否到达指定时间
            if (dt_ok.ToString("HHmmss") == DateTime.Now.ToString("HHmmss"))
            {
                //如果到达则，重新设置到达时间，并提示
                setTimeOk();
                ShowIMG shows = new ShowIMG();
                shows.Show();
                shows.StartPosition = FormStartPosition.CenterScreen;
            }

        }

        #region 最小化
        private void notifyIcon1_MouseDown(object sender, MouseEventArgs e)
        {
            this.Show();
            //this.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Normal;
            //notifyIcon1.Visible = false;
        }

        private void TimelyRemminder_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notifyIcon1.Visible = true;
            }
        }
        #endregion

        private void TimelyRemminder_Load(object sender, EventArgs e)
        {

        }

        private void TimelyRemminder_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void TimelyRemminder_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
            return;
        }
    }
}

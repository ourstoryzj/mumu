using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.ScreenDemo
{
    public partial class ScreenForm : Form
    {
        private Point start = new Point(0,0);

        public Point Start
        {
            get { return start; }

            set { start = value; }
        }

        private Point end = new Point(0, 0);

        public Point End
        {
            get { return end; }

            set { end = value; }
        }

        public event EventHandler ScreenShotOk;

        public ScreenForm()
        {
            InitializeComponent();
            //以下采用双缓冲方式，减少闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void ScreenForm_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            //当前窗口最大化，且不显示标题栏
            Rectangle ScreenArea = Screen.GetWorkingArea(this);
            this.MaximumSize = new Size(ScreenArea.Width, ScreenArea.Height);

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //鼠标，十字键
            this.Cursor = Cursors.Cross;
            this.BackgroundImageLayout = ImageLayout.Center;
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                Pen p = Pens.Red;
                g.DrawRectangle(p, new Rectangle(Start, new Size(End.X - Start.X, End.Y - Start.Y)));
            }
        }

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenForm_MouseDown(object sender, MouseEventArgs e)
        {
            //如果就左键
            if (e.Button == MouseButtons.Left) {
                Start = e.Location;
            }
        }

        /// <summary>
        /// 鼠标起来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenForm_MouseUp(object sender, MouseEventArgs e)
        {
            //如果就左键
            if (e.Button == MouseButtons.Left)
            {
                //如果起始位置和结束位置一致，则返回
                if (e.Location == Start) {
                    return;
                }
                End = e.Location;
                if (ScreenShotOk != null) {
                    ScreenShotOk(this, null);
                }
                this.Close();
            }
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenForm_MouseMove(object sender, MouseEventArgs e)
        {
            //如果就左键
            if (e.Button == MouseButtons.Left)
            {
                End = e.Location;
                this.Refresh();
               
            }
        }
    }
}

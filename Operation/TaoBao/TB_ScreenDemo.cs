using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.TaoBao
{
    public partial class TB_ScreenDemo : Form
    {
        public TB_ScreenDemo()
        {
            InitializeComponent();
        }

        //是否操作完成要关闭窗口了
        public bool isok = false;

        //矩形宽度
        //float penWidth = 800;
        //是否开始用鼠标画矩形
        bool mousedown = false;
        //截图开始的位置
        Point startpoint;
        //截图结束的位置
        Point endpoint;

        //操作后的Bitmap
        Bitmap bmOk;

        Graphics newg;
        //需要操作的Bitmap
        Bitmap bmsave;
        //截取后的矩形
        Rectangle rectRes;


        private void button1_Click(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
            pictureBox1.Image = bmOk;
        }

        private void TB_ScreenDemo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            //当前窗口最大化，且不显示标题栏
            Rectangle ScreenArea = Screen.GetWorkingArea(this);
            this.MaximumSize = new Size(ScreenArea.Width, ScreenArea.Height);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //鼠标，十字键
            //this.Cursor = Cursors.Cross;
            pictureBox1.Cursor = Cursors.Cross;
            this.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Image = this.BackgroundImage;

            bmsave = new Bitmap(this.BackgroundImage.Width, this.BackgroundImage.Height);
            newg = Graphics.FromImage(bmsave);

        }

        private void event_Registered()
        {
            this.MouseDown += picBefore_MouseDown;
            this.MouseUp += picBefore_MouseUp;
            this.MouseMove += picBefore_MouseMove;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //重绘时显示bitmap
            base.OnPaint(e);
            //gform.DrawImage(this.bmsave, new Point(0, 0));
        }




        private void picBefore_MouseDown(object sender, MouseEventArgs e)
        {
            //设置开始绘制截图矩形
            this.mousedown = true;
            //设置记录开始点-鼠标点击
            this.startpoint = e.Location;
        }

        private void picBefore_MouseMove(object sender, MouseEventArgs e)
        {
            //记录结束点。绘制到窗口上
            if (mousedown)
            {
                //设置鼠标最后到达的位置
                this.endpoint = e.Location;
                this.Refresh();
                //在画布上先画上原图的图像
                //newg.DrawImage(BackgroundImage, new Point(0, 0));
                newg.DrawImage(BackgroundImage, new Rectangle(0, 0, BackgroundImage.Width, BackgroundImage.Height), 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel);
                //创建一个矩形
                //rectRes = new Rectangle();
                //获取矩形的数据
                MakeRect();
                //在画布上再画上矩形
                newg.DrawRectangle(new Pen(Color.Red), rectRes);
                pictureBox1.Image = bmsave;
            }
        }

        private void picBefore_MouseUp(object sender, MouseEventArgs e)
        {
            //记录结束点。绘制到bitmap上
            this.endpoint = e.Location;
            this.mousedown = false;
            //在画布上先画上原图的图像,覆盖之前操作的记录
            //newg.DrawImage(BackgroundImage, new Point(0, 0));
            newg.DrawImage(BackgroundImage, new Rectangle(0, 0, BackgroundImage.Width, BackgroundImage.Height), 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel);
            //rectRes = new Rectangle();
            MakeRect();
            newg.DrawRectangle(new Pen(Color.Red), rectRes);
            pictureBox1.Image = bmsave;

            //gform.DrawImage(this.bmsave, new Point(0, 0));
        }

        #region rect_play 计算矩形的位置和尺寸

        /// <summary>
        /// 设置一个始终是方形的矩形 其中不用返回值,是因为ref这个参数是指针,直接操作的rect
        /// </summary>
        /// <param name="rect"></param>
        private void MakeRect()
        {
            //xiaochu(ref startpoint);
            //xiaochu(ref endpoint);
            rectRes.Location = xiaochu(startpoint);
            //获取两点的X,Y距离
            rectRes.Width = Math.Abs(xiaochu(startpoint).X - xiaochu(endpoint).X);
            rectRes.Height = Math.Abs(xiaochu(startpoint).Y - xiaochu(endpoint).Y);
            if (rectRes.Width > rectRes.Height)
            {
                rectRes.Height = rectRes.Width;
            }
            else
            {
                rectRes.Width = rectRes.Height;
            }
        }

        /// <summary>
        /// 消除容差:因为图片居中显示, 方法中获取的位置是从控件的位置开始算的, 所以需要消除其中的差值
        /// </summary>
        /// <param name="p"></param>
        private Point xiaochu(Point p)
        {
            int w = (Width / 2) - (BackgroundImage.Width / 2);
            int h = (Height / 2) - (BackgroundImage.Height / 2);
            p.X = p.X - w;
            p.Y = p.Y - h;

            //鼠标的容差
            //p.X = p.X + 6;
            //p.Y = p.Y + 17;
            return p;
        }



        /// <summary>
        /// 计算矩形的位置和尺寸
        /// </summary>
        /// <param name="rect"></param>
        private void rect_play(ref Rectangle rect)
        {

            //根据两个点确定矩形的左上角点Location
            if (this.startpoint.X > this.endpoint.X && this.startpoint.Y < this.endpoint.Y)//
            {
                rect.Location = new Point(this.endpoint.X, this.startpoint.Y);
            }
            else if (this.startpoint.X < this.endpoint.X && this.startpoint.Y > this.endpoint.Y)
            {
                rect.Location = new Point(this.startpoint.X, this.endpoint.Y);

            }
            else if (this.startpoint.X > this.endpoint.X && this.startpoint.Y > this.endpoint.Y)
            {
                rect.Location = this.endpoint;
            }
            else
            {
                rect.Location = this.startpoint;
            }
            //获取两点的X,Y距离
            rect.Width = Math.Abs(this.startpoint.X - this.endpoint.X);
            rect.Height = Math.Abs(this.startpoint.Y - this.endpoint.Y);

            if (rect.Width == 0 && rect.Height == 0)
            {
                //防止误点的时候进行绘制
            }
            else if (rect.Width == 0)
            {
                rect.Width = 1;

            }
            else if (rect.Height == 0)
            {
                rect.Height = 1;
            }

        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(rectRes.Width, rectRes.Height);
            Graphics g = Graphics.FromImage(bm);
            //g.DrawImage(BackgroundImage, 0, 0, rectRes, GraphicsUnit.Pixel);
            //g.DrawImage(BackgroundImage, 0, 0, rectRes, GraphicsUnit.Pixel);
            //newg.DrawImage(BackgroundImage, new Rectangle(0, 0, BackgroundImage.Width, BackgroundImage.Height), 0, 0, BackgroundImage.Width, BackgroundImage.Height, GraphicsUnit.Pixel);
            g.DrawImage(BackgroundImage,new Rectangle(0,0,rectRes.Width,rectRes.Height),rectRes.X,rectRes.Y, rectRes.Width, rectRes.Height,GraphicsUnit.Pixel);
            g.Dispose();

            bmOk = new Bitmap(800, 800);
            Graphics gg = Graphics.FromImage(bmOk);
            Rectangle rect = new Rectangle(0, 0, 800, 800);
            //gg.DrawImage(bm, rect, 0, 0, bm.Width, bm.Height, GraphicsUnit.Pixel);
            gg.DrawImage(bm,new Rectangle(0,0,800,800),0,0, bm.Width, bm.Height,GraphicsUnit.Pixel);
            gg.Dispose();
            pictureBox1.Image = bmOk;
            bm.Dispose();

        }

        /// <summary>
        /// 双击截取图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


        }


        /// <summary>
        /// 调整对比度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (bmOk != null)
            {
                try
                {
                    int val = trackBar1.Value;
                    Bitmap bm = new Bitmap(800, 800);
                    Graphics g = Graphics.FromImage(bm);
                    g.DrawImage(pictureBox1.Image, 0, 0);
                    g.Dispose();

                    Bitmap bms = CS.ImageClass.ContrastPic(bm, val);
                    //bm.Dispose();
                    if (bms != null)
                        pictureBox1.Image = bms;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("调整亮度出错:" + ex);
                }
            }
        }

        /// <summary>
        /// 调整亮度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            if (bmOk != null)
            {
                try
                {
                    int val = trackBar2.Value;
                    Bitmap bm = new Bitmap(800, 800);
                    Graphics g = Graphics.FromImage(bm);
                    g.DrawImage(pictureBox1.Image, 0, 0);
                    g.Dispose();

                    Bitmap bms = CS.ImageClass.BrightnessP(bm, val);
                    //bm.Dispose();
                    if (bms != null)
                        pictureBox1.Image = bms;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("调整亮度出错:" + ex);
                }
            }

        }

        /// <summary>
        /// 调整锐度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            if (bmOk != null)
            {
                try
                {
                    int val = trackBar3.Value;
                    Bitmap bm = new Bitmap(800, 800);
                    Graphics g = Graphics.FromImage(bm);
                    g.DrawImage(pictureBox1.Image, 0, 0);
                    g.Dispose();

                    Bitmap bms = CS.ImageClass.Sharpen(bm, val);
                    //bm.Dispose();
                    if (bms != null)
                        pictureBox1.Image = bms;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("调整亮度出错:" + ex);
                }
            }
        }


        /// <summary>
        /// 图片操作完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //PicMake.curBitmap = (Bitmap)pictureBox1.Image;

            //isok = true;
            //Clipboard.SetImage(pictureBox1.Image);
            Manager.taobaozhutu = pictureBox1.Image;
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel_operation.ScreenDemo
{
    public partial class MainForm : Form
    {
        private ScreenForm sf = new ScreenForm();

        private Bitmap curBitmap;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            sf.ScreenShotOk += new EventHandler(ScreenShotOk_Click);
        }

        private void ScreenShotOk_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(sf.End.X - sf.Start.X, sf.End.Y - sf.Start.Y);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                int w = sf.End.X - sf.Start.X;
                int h = sf.End.Y - sf.Start.Y;
                Rectangle destRect = new Rectangle(0, 0, w + 1, h + 1);//在画布上要显示的区域（记得像素加1）
                Rectangle srcRect = new Rectangle(sf.Start.X, sf.Start.Y - 15, w + 1, h + 1);//图像上要截取的区域
                g.DrawImage(curBitmap, destRect, srcRect, GraphicsUnit.Pixel);//加图像绘制到画布上
            }
            this.pictureBox1.Image = bmp;
            this.Show();
        }

        public Bitmap GetScreen()
        {
            //获取整个屏幕图像,不包括任务栏
            Rectangle ScreenArea = Screen.GetWorkingArea(this);
            Bitmap bmp = new Bitmap(ScreenArea.Width, ScreenArea.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(ScreenArea.Width,ScreenArea.Height));
            }
            return bmp;
        }

        #region 菜单栏事件

        /// <summary>
        /// 菜单栏 新建截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiNew_Click(object sender, EventArgs e)
        {
            tsbNew_Click(sender, e);
        }

        /// <summary>
        /// 菜单栏 另存为
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiSaveOther_Click(object sender, EventArgs e)
        {
            tsbSave_Click(sender, e);
        }

        /// <summary>
        /// 菜单栏 发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiSend_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能尚未实现！");
        }

        /// <summary>
        /// 菜单栏，退出功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit ?","Info",MessageBoxButtons.OKCancel) == DialogResult.OK) {
                this.Close();
            }
        }

        /// <summary>
        /// 菜单栏 复制事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiCopy_Click(object sender, EventArgs e)
        {
            tsbCopy_Click(sender, e);
        }

        private void smiPen_Click(object sender, EventArgs e)
        {
            MessageBox.Show("使用此功能，请点击工具栏按钮！");
        }

        private void smiLightPen_Click(object sender, EventArgs e)
        {
            tsbLightPen_Click(sender, e);
        }

        private void smiEraser_Click(object sender, EventArgs e)
        {
            tsbEraser_Click(sender, e);
        }

        private void smiOperation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能尚未实现！");
        }

        private void smiHelp1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能尚未实现！");
        }

        /// <summary>
        /// About
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smiAbout_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        #endregion

        #region 鼠标事件

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.pictureBox1.StartDraw == true)
            {
                this.pictureBox1.OnMouseDown(e.Location);
            }
        }

        /// <summary>
        /// 鼠标弹起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.pictureBox1.StartDraw == true)
            {
                this.pictureBox1.OnMouseUp(e.Location);
            }
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && this.pictureBox1.StartDraw == true)
            {
                this.pictureBox1.SetPointAndRefresh(e.Location);
            }
        }

        #endregion

        #region 工具栏事件
        
        /// <summary>
        /// 新建截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbNew_Click(object sender, EventArgs e)
        {
            this.Hide();//隐藏当前
            this.pictureBox1.LineHistory.Clear();//清除绘制的历史线条
            this.pictureBox1.RectHistory.Clear();
            this.curBitmap = GetScreen();
            sf.BackgroundImage = this.curBitmap;
            sf.StartPosition = FormStartPosition.Manual;//起始位置
            sf.ShowDialog();

        }

        /// <summary>
        /// 保存功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.DefaultExt = "png";
            sfd.Filter = "PNG图片|*.png|JPG图片|*.jpg";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (sfd.ShowDialog() == DialogResult.OK) {
                string fileName = sfd.FileName;
                Image image = this.pictureBox1.Image;
                using (Graphics g = Graphics.FromImage(image)) { 
                    this.pictureBox1.DrawHistory(g);
                }
                image.Save(fileName);
            }
        }

        /// <summary>
        /// 复制功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbCopy_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.Image != null)
            {
                Clipboard.SetDataObject(this.pictureBox1.Image);
                MessageBox.Show("已复制到剪贴板！");
            }
        }

        private void tsddbPen_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            var item = e.ClickedItem;
            if (item.Selected)
            {
                Color color = Color.FromName(item.Tag.ToString());
                this.tsddbPen.BackColor = color;
                this.pictureBox1.SetPen(color);
            }
        }

        /// <summary>
        /// 荧光笔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbLightPen_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SetLightPen();
        }

        /// <summary>
        /// 用图片生成指针样式
        /// </summary>
        /// <param name="cursor"></param>
        /// <param name="hotPoint"></param>
        public void SetCursor(Bitmap cursor, Point hotPoint)
        {
            int hotX = hotPoint.X;
            int hotY = hotPoint.Y;
            Bitmap myNewCursor = new Bitmap(cursor.Width * 2 - hotX, cursor.Height * 2 - hotY);
            Graphics g = Graphics.FromImage(myNewCursor);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
            g.DrawImage(cursor, cursor.Width - hotX, cursor.Height - hotY, cursor.Width,
            cursor.Height);
            this.Cursor = new Cursor(myNewCursor.GetHicon());

            g.Dispose();
            myNewCursor.Dispose();
        }

        private void tsbDefault_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SetDefault();
        }
        
        /// <summary>
        /// 橡皮擦功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbEraser_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SetEarser();
        }

        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbRectangle_Click(object sender, EventArgs e)
        {
            this.pictureBox1.SetRectangle();
        }

        #endregion

    }
}

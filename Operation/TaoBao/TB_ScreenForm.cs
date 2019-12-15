using excel_operation.ScreenDemo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel_operation.TaoBao
{
    public partial class TB_ScreenForm : Form
    {
        public TB_ScreenForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);

            //SetRectangle();
        }


        #region 这个From里原有代码

       
        private Point start = new Point(0, 0);

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

        //public event EventHandler ScreenShotOk;

       

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

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    using (Graphics g = this.CreateGraphics())
        //    {
        //        Pen p = Pens.Red;
        //        g.DrawRectangle(p, new Rectangle(Start, new Size(End.X - Start.X, End.Y - Start.Y)));
        //    }
        //}

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenForm_MouseDown(object sender, MouseEventArgs e)
        {
            //如果就左键
            //if (e.Button == MouseButtons.Left)
            //{
            //    Start = e.Location;
            //}
            OnMouseDown(e.Location);
        }

        /// <summary>
        /// 鼠标起来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenForm_MouseUp(object sender, MouseEventArgs e)
        {
            //如果就左键
            //if (e.Button == MouseButtons.Left)
            //{
            //    //如果起始位置和结束位置一致，则返回
            //    if (e.Location == Start)
            //    {
            //        return;
            //    }
            //    End = e.Location;
            //    if (ScreenShotOk != null)
            //    {
            //        ScreenShotOk(this, null);
            //    }
            //    SetRectangle();
            //    //this.Close();
            //}
            OnMouseUp(e.Location);
        }

        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenForm_MouseMove(object sender, MouseEventArgs e)
        {
            //如果就左键
            //if (e.Button == MouseButtons.Left)
            //{
            //    End = e.Location;
            //    this.Refresh();

            //}
            SetPointAndRefresh(e.Location);
        }
        #endregion





        #region 源代码中自定义控件HexPictureBox的所需要的代码

        #region 声明所需变量

        

        private List<HLine> lineHistory = new List<HLine>();

        public List<HLine> LineHistory
        {
            get { return lineHistory; }

            private set { lineHistory = value; }
        }

        private List<HRectangle> rectHistory = new List<HRectangle>();

        public List<HRectangle> RectHistory
        {
            get { return rectHistory; }

            private set { rectHistory = value; }
        }

        private HLine curLine = new HLine() { LineColor = Color.White, LineWidth = 2, PointList = new List<Point>() };

        /// <summary>
        /// 当前绘制线
        /// </summary>
        public HLine CurLine
        {
            get { return curLine; }

            private set { curLine = value; }
        }


        private ScreenDemo.HRectangle curRect = new ScreenDemo.HRectangle() { LineColor = Color.White, LineWidth = 2, Start = new Point(0, 0), End = new Point(0, 0) };

        /// <summary>
        /// 当前需要绘制的矩形
        /// </summary>
        public ScreenDemo.HRectangle CurRect
        {
            get { return curRect; }

            set { curRect = value; }
        }


        private ScreenDemo.DrawType drawTypes = ScreenDemo.DrawType.None;

        public ScreenDemo.DrawType DrawTypes
        {
            get { return drawTypes; }

            set { drawTypes = value; }
        }

        private bool startDraw = false;

        public bool StartDraw
        {
            get { return startDraw; }

            set { startDraw = value; }
        }

        #endregion

        #region 绘制矩形的方法 SetRectangle
        /// <summary>
        /// 绘制矩形的方法
        /// </summary>
        public void SetRectangle()
        {
            StartDraw = true;
            CurRect.LineWidth = 3;
            DrawTypes = ScreenDemo.DrawType.Rect;
            CurRect.LineColor = Color.Red;
            Cursor = Cursors.Cross;
        }
        #endregion

        #region OnPaint

        
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            DrawHistory(g);
            //绘制当前线
            if (startDraw && curLine.PointList != null && this.curLine.PointList.Count > 0)
            {
                DrawLine(g, this.curLine);
            }
            if (startDraw && this.curRect.Start != null && this.curRect.End != null && this.curRect.Start != this.curRect.End)
            {
                DrawRectangle(g, this.curRect);
            }
        }
        #endregion

        #region DrawHistory 历史操作


        public void DrawHistory(Graphics g)
        {
            //绘制线历史记录
            if (LineHistory != null)
            {
                foreach (HLine lh in LineHistory)
                {
                    if (lh.PointList.Count > 10)
                    {
                        DrawLine(g, lh);
                    }
                }
            }
            //绘制矩形历史记录
            if (RectHistory != null)
            {
                foreach (HRectangle lh in RectHistory)
                {
                    if (lh.Start != null && lh.End != null && lh.Start != lh.End)
                    {
                        DrawRectangle(g, lh);
                    }
                }
            }
        }
        #endregion

        #region DrawLine 绘制线
        /// <summary>
        /// 绘制线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="line"></param>
        private void DrawLine(Graphics g, HLine line)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen p = new Pen(line.LineColor, line.LineWidth))
            {
                //设置起止点线帽  
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;

                //设置连续两段的联接样式  
                p.LineJoin = LineJoin.Round;
                g.DrawCurve(p, line.PointList.ToArray()); //画平滑曲线  
            }
        }
        #endregion


        #region 绘制矩形


        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        private void DrawRectangle(Graphics g, ScreenDemo.HRectangle rect)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen p = new Pen(rect.LineColor, rect.LineWidth))
            {
                //设置起止点线帽  
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;

                //设置连续两段的联接样式  
                p.LineJoin = LineJoin.Round;
                g.DrawRectangle(p, rect.Start.X, rect.Start.Y, rect.End.X - rect.Start.X, rect.End.Y - rect.Start.Y); //画平滑曲线  
            }
        }
        #endregion

        #region 鼠标事件响应

        /// <summary>
        /// 鼠标移动时设置点
        /// </summary>
        /// <param name="p"></param>
        public void SetPointAndRefresh(Point p)
        {
            if (drawTypes == DrawType.Line)
            {
                curLine.PointList.Add(p);
            }
            if (drawTypes == DrawType.Rect)
            {
                curRect.End = p;
            }
            Refresh();

        }

        public void OnMouseDown(Point p)
        {
            if (DrawTypes == DrawType.Line)
            {
                CurLine.PointList.Clear();
                CurLine.PointList.Add(p);
            }
            if (DrawTypes == DrawType.Rect)
            {
                CurRect.Start = p;
            }
        }

        public void OnMouseUp(Point p)
        {
            if (DrawTypes == DrawType.Line)
            {
                //右键起来时，停止绘图，并写入历史记录
                Point[] pCopy = CurLine.PointList.ToArray();
                List<Point> lstPoint = new List<Point>();
                lstPoint.AddRange(pCopy);
                LineHistory.Add(new HLine() { LineColor = CurLine.LineColor, LineWidth = CurLine.LineWidth, PointList = lstPoint });
                CurLine.PointList.Clear();
            }
            if (DrawTypes == DrawType.Rect)
            {
                RectHistory.Add(new HRectangle() { LineColor = CurRect.LineColor, LineWidth = CurRect.LineWidth, Start = CurRect.Start, End = CurRect.End });
                CurRect.Start = new Point(0, 0);
                CurRect.End = new Point(0, 0);
            }
            if (DrawTypes == DrawType.Earser)
            {
                //如果是橡皮擦功能
                //Earser(p);
                Refresh();
            }
        }

        #endregion


        

       

        #endregion


    }
}

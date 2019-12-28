using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Operation.ScreenDemo
{
    /// <summary>
    /// 重写图片控件
    /// </summary>
    [Serializable]
    public partial class HexPictureBox : PictureBox
    {
        #region 属性和构造函数

        public HexPictureBox()
        {
            InitializeComponent();
        }

        private bool startDraw = false;

        public bool StartDraw
        {
            get { return startDraw; }

            set { startDraw = value; }
        }

        private List<HLine>  lineHistory = new List<HLine>();

        public List<HLine> LineHistory
        {
            get { return lineHistory; }

            private set { lineHistory = value; }
        }

        private HLine curLine = new HLine() {LineColor=Color.White, LineWidth = 2, PointList=new List<Point>() };

        /// <summary>
        /// 当前绘制线
        /// </summary>
        public HLine CurLine
        {
            get { return curLine; }

            private set { curLine = value; }
        }

        private HRectangle curRect = new HRectangle() { LineColor = Color.White, LineWidth = 2, Start = new Point(0, 0), End = new Point(0, 0) };

        /// <summary>
        /// 当前需要绘制的矩形
        /// </summary>
        public HRectangle CurRect
        {
            get { return curRect; }

            set { curRect = value; }
        }

        private List<HRectangle> rectHistory = new List<HRectangle>();

        public List<HRectangle> RectHistory
        {
            get { return rectHistory; }

            private set { rectHistory = value; }
        }

        private DrawType drawTypes = DrawType.None;

        public DrawType DrawTypes
        {
            get { return drawTypes; }

            set { drawTypes = value; }
        }

        #endregion

        #region 绘制功能

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            DrawHistory(g);
            //绘制当前线
            if (startDraw && this.curLine.PointList != null && this.curLine.PointList.Count > 0)
            {
                DrawLine(g,this.curLine);
            }
            if (startDraw && this.curRect.Start != null && this.curRect.End != null && this.curRect.Start != this.curRect.End) {
                DrawRectangle(g, this.curRect);
            }
        }

        public void DrawHistory(Graphics g) {
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
                    if (lh.Start!=null&& lh.End!=null && lh.Start!=lh.End)
                    {
                        DrawRectangle(g, lh);
                    }
                }
            }
        }

        /// <summary>
        /// 绘制线
        /// </summary>
        /// <param name="g"></param>
        /// <param name="line"></param>
        private void DrawLine(Graphics g,HLine line) {
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

        /// <summary>
        /// 绘制矩形
        /// </summary>
        /// <param name="g"></param>
        /// <param name="rect"></param>
        private void DrawRectangle(Graphics g, HRectangle rect)
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

        public void Earser(Point p0)
        {
            for (int i = lineHistory.Count - 1; i >= 0; i--)
            {
                HLine line = lineHistory[i];
                bool flag = false;
                foreach (Point p1 in line.PointList)
                {
                    double distance = GetDistance(p0, p1);
                    if (Math.Abs(distance) < 6)
                    {
                        //需要删除
                        flag = true;
                        break;
                    }

                }
                if (flag)
                {
                    lineHistory.RemoveAt(i);
                }
            }
            //擦除矩形
            for (int i = rectHistory.Count - 1; i >= 0; i--)
            {
                HRectangle rect = rectHistory[i];
               
                if (p0.X>rect.Start.X && p0.X<rect.End.X && p0.Y > rect.Start.Y && p0.Y < rect.End.Y) {
                   
                    rectHistory.RemoveAt(i);
                }
            }
        }
 
        /// <summary>
        /// 获取两点之间的距离
        /// </summary>
        /// <param name="p0"></param>
        /// <param name="p1"></param>
        /// <returns></returns>
        private double GetDistance(Point p0, Point p1) {
            return Math.Sqrt(Math.Pow((p0.X - p1.X), 2) + Math.Pow((p0.Y - p1.Y), 2));
        }

        #endregion

        #region 鼠标事件响应

        /// <summary>
        /// 鼠标移动时设置点
        /// </summary>
        /// <param name="p"></param>
        public void SetPointAndRefresh(Point p)
        {
            if (this.drawTypes == DrawType.Line)
            {
                this.curLine.PointList.Add(p);
            }
            if (this.drawTypes == DrawType.Rect)
            {
                this.curRect.End = p;
            }
            this.Refresh();

        }

        public void OnMouseDown(Point p)
        {
            if (this.DrawTypes == DrawType.Line)
            {
                this.CurLine.PointList.Clear();
                this.CurLine.PointList.Add(p);
            }
            if (this.DrawTypes == DrawType.Rect)
            {
                this.CurRect.Start = p;
            }
        }

        public void OnMouseUp(Point p)
        {
            if (this.DrawTypes == DrawType.Line)
            {
                //右键起来时，停止绘图，并写入历史记录
                Point[] pCopy = this.CurLine.PointList.ToArray();
                List<Point> lstPoint = new List<Point>();
                lstPoint.AddRange(pCopy);
                this.LineHistory.Add(new HLine() { LineColor = this.CurLine.LineColor, LineWidth = this.CurLine.LineWidth, PointList = lstPoint });
                this.CurLine.PointList.Clear();
            }
            if (this.DrawTypes == DrawType.Rect)
            {
                this.RectHistory.Add(new HRectangle() { LineColor = this.CurRect.LineColor, LineWidth = this.CurRect.LineWidth, Start = this.CurRect.Start, End = this.CurRect.End });
                this.CurRect.Start = new Point(0, 0);
                this.CurRect.End = new Point(0, 0);
            }
            if (this.DrawTypes == DrawType.Earser)
            {
                //如果是橡皮擦功能
                this.Earser(p);
                this.Refresh();
            }
        }

        #endregion

        #region 初始设置

        public void SetPen(Color c)
        {
            this.DrawTypes = DrawType.Line;
            this.CurLine.LineWidth = 2;
            this.CurLine.LineColor = c;
            //通过图片的句柄获取指针
            //this.Cursor = new Cursor(global::Operation.Properties.Resources.pen.GetHicon());
            this.StartDraw = true;
        }

        public void SetLightPen()
        {
            this.StartDraw = true;
            this.CurLine.LineWidth = 6;
            this.DrawTypes = DrawType.Line;
            //this.Cursor = new Cursor(global::Operation.Properties.Resources.lightpen.GetHicon());
            this.CurLine.LineColor = Color.FromArgb(100, Color.Yellow);
        }

        public void SetRectangle() {
            this.StartDraw = true;
            this.CurRect.LineWidth = 3;
            this.DrawTypes = DrawType.Rect;
            this.CurRect.LineColor = Color.Red;
            this.Cursor = Cursors.Cross;
        }

        public void SetEarser() {
            this.DrawTypes = DrawType.Earser;//橡皮檫
            //this.Cursor = new Cursor(global::Operation.Properties.Resources.easer1.GetHicon());
        }

        public void SetDefault() {
            this.Cursor = Cursors.Default;
            this.StartDraw = false;
        }

        #endregion
    }
}

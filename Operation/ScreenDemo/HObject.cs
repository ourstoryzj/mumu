using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excel_operation.ScreenDemo
{
    public class HObject
    {
        public Color LineColor { get; set; }

        public int LineWidth { get; set; }
    }
    /// <summary>
    /// 线的历史记录
    /// </summary>
    [Serializable]
    public class HLine : HObject
    {
        public List<Point> PointList { get; set; }
    }

    /// <summary>
    /// 矩形历史，一个对象代表一个矩形
    /// </summary>
    public class HRectangle: HObject
    {
        public Point Start { get; set; }

        public Point End { get; set; }

    }

    /// <summary>
    /// 绘制类型
    /// </summary>
    public enum DrawType
    {
        None = -1,
        Line = 0,
        Rect = 1,
        Earser = 2
    }
}

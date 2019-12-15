using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

namespace BLL
{
    /// <summary>
    /// 给图片添加水印得类得描述
    /// </summary>
    public class WaterMark
    {
        private bool _textMark = false;
        private bool _imgMark = false;
        private string _text = "";
        private string _imgPath = "";
        private int _markX = 0;
        private int _markY = 0;
        private float _transparency = 1;
        private string _fontFamily = "宋体";
        private Color _textColor = Color.Black;
        private bool _textbold = false;
        int[] sizes = new int[] { 48, 32, 16, 8, 6, 4 };
        /// <summary>
        /// 实例化一个水印类
        /// </summary>
        public WaterMark()
        {

        }
        /// <summary>
        ///　初始化一个只添加文字水印得实例
        /// </summary>
        /// <param name="text">水印文字</param>
        /// <param name="fontFamily">文字字体</param>
        /// <param name="bold">是否粗体</param>
        /// <param name="color">字体颜色</param>
        /// <param name="markX">标记位置横坐标</param>
        /// <param name="markY">标记位置纵坐标</param>
        public WaterMark(string text, string fontFamily, bool bold, Color color, int markX, int markY)
        {
            this._imgMark = false;
            this._textMark = true;
            this._text = text;
            this._fontFamily = fontFamily;
            this._textbold = bold;
            this._textColor = color;
            this._markX = markX;
            this._markY = MarkY;
        }
        /// <summary>
        /// 实例化一个只添加图片水印得实例
        /// </summary>
        /// <param name="imagePath">水印图片路径</param>
        /// <param name="tranparence">透明度</param>
        /// <param name="markX">标记位置横坐标</param>
        /// <param name="markY">标记位置纵坐标</param>
        public WaterMark(string imagePath, float tranparence, int markX, int markY)
        {
            this._textMark = false;
            this._imgMark = true;
            this._imgPath = imagePath;
            this._markX = markX;
            this._markY = MarkY;
            this._transparency = tranparence;
        }
        /// <summary>
        /// 是否添加文字水印
        /// </summary>
        public bool TextMark
        {
            get { return _textMark; }
            set { _textMark = value; }
        }
        /// <summary>
        /// 是否添加图片水印
        /// </summary>
        public bool ImageMark
        {
            get { return _imgMark; }
            set { _imgMark = value; }
        }
        /// <summary>
        /// 文字水印得内容
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        /// <summary>
        /// 图片水印得图片地址
        /// </summary>
        public string ImagePath
        {
            get { return _imgPath; }
            set { _imgPath = value; }
        }
        /// <summary>
        /// 添加水印位置得横坐标
        /// </summary>
        public int MarkX
        {
            get { return _markX; }
            set { _markX = value; }
        }
        /// <summary>
        /// 添加水印位置得纵坐标
        /// </summary>
        public int MarkY
        {
            get { return _markY; }
            set { _markY = value; }
        }
        /// <summary>
        /// 水印得透明度
        /// </summary>
        public float Transparency
        {
            get
            {
                if (_transparency > 1.0f)
                {
                    _transparency = 1.0f;
                }
                return _transparency;
            }
            set { _transparency = value; }
        }
        /// <summary>
        /// 水印文字得颜色
        /// </summary>
        public Color TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }
        /// <summary>
        /// 水印文字得字体
        /// </summary>
        public string TextFontFamily
        {
            get { return _fontFamily; }
            set { _fontFamily = value; }
        }
        /// <summary>
        /// 水印文字是否加粗
        /// </summary>
        public bool Bold
        {
            get { return _textbold; }
            set { _textbold = value; }
        }
        /// <summary>
        /// 添加水印，此方法适用于gif格式得图片
        /// </summary>
        /// <param name="image">需要添加水印得图片</param>
        /// <returns>添加水印之后得图片</returns>
        public Image Mark(Image img)
        {
            try
            {
                //添加文字水印
                if (this.TextMark)
                {
                    //根据源图片生成新的Bitmap对象作为作图区，为了给gif图片添加水印，才有此周折
                    Bitmap newBitmap = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
                    //设置新建位图得分辨率
                    newBitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                    //创建Graphics对象，以对该位图进行操作
                    Graphics g = Graphics.FromImage(newBitmap);
                    //消除锯齿
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    //将原图拷贝到作图区
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                    //声明字体对象
                    Font cFont = null;
                    //用来测试水印文本长度得尺子
                    SizeF size = new SizeF();
                    //探测出一个适合图片大小得字体大小，以适应水印文字大小得自适应
                    for (int i = 0; i < 6; i++)
                    {
                        //创建一个字体对象
                        cFont = new Font(this.TextFontFamily, sizes[i]);
                        //是否加粗
                        if (!this.Bold)
                        {
                            cFont = new Font(this.TextFontFamily, sizes[i], FontStyle.Regular);
                        }
                        else
                        {
                            cFont = new Font(this.TextFontFamily, sizes[i], FontStyle.Bold);
                        }
                        //测量文本大小
                        size = g.MeasureString(this.Text, cFont);
                        //匹配第一个符合要求得字体大小
                        if ((ushort)size.Width < (ushort)img.Width)
                        {
                            break;
                        }
                    }
                    //创建刷子对象，准备给图片写上文字
                    Brush brush = new SolidBrush(this.TextColor);
                    //在指定得位置写上文字
                    g.DrawString(this.Text, cFont, brush, this.MarkX, this.MarkY);
                    //释放Graphics对象
                    g.Dispose();
                    //将生成得图片读入MemoryStream
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    newBitmap.Save(ms, ImageFormat.Jpeg);
                    //重新生成Image对象
                    img = System.Drawing.Image.FromStream(ms);
                    //返回新的Image对象
                    return img;

                }
                //添加图像水印
                if (this.ImageMark)
                {
                    //获得水印图像
                    Image markImg = Image.FromFile(this.ImagePath);
                    //创建颜色矩阵
                    float[][] ptsArray ={ 
                     new float[] {1, 0, 0, 0, 0},
                     new float[] {0, 1, 0, 0, 0},
                      new float[] {0, 0, 1, 0, 0},
                     new float[] {0, 0, 0, this.Transparency, 0}, //注意：此处为0.0f为完全透明，1.0f为完全不透明
                     new float[] {0, 0, 0, 0, 1}};
                    ColorMatrix colorMatrix = new ColorMatrix(ptsArray);
                    //新建一个Image属性
                    ImageAttributes imageAttributes = new ImageAttributes();
                    //将颜色矩阵添加到属性
                    imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default,
                     ColorAdjustType.Default);
                    //生成位图作图区
                    Bitmap newBitmap = new Bitmap(img.Width, img.Height, PixelFormat.Format24bppRgb);
                    //设置分辨率
                    newBitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
                    //创建Graphics
                    Graphics g = Graphics.FromImage(newBitmap);
                    //消除锯齿
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    //拷贝原图到作图区
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                    //如果原图过小
                    if (markImg.Width > img.Width || markImg.Height > img.Height)
                    {
                        System.Drawing.Image.GetThumbnailImageAbort callb = null;
                        //对水印图片生成缩略图,缩小到原图得1/4
                        System.Drawing.Image new_img = markImg.GetThumbnailImage(img.Width / 4, markImg.Height * img.Width / markImg.Width, callb, new System.IntPtr());
                        //添加水印
                        g.DrawImage(new_img, new Rectangle(this.MarkX, this.MarkY, new_img.Width, new_img.Height), 0, 0, new_img.Width, new_img.Height, GraphicsUnit.Pixel, imageAttributes);
                        //释放缩略图
                        new_img.Dispose();
                        //释放Graphics
                        g.Dispose();
                        //将生成得图片读入MemoryStream
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        newBitmap.Save(ms, ImageFormat.Jpeg);
                        //返回新的Image对象
                        img = Image.FromStream(ms);
                        return img;
                    }
                    //原图足够大
                    else
                    {
                        //添加水印
                        g.DrawImage(markImg, new Rectangle(this.MarkX, this.MarkY, markImg.Width, markImg.Height), 0, 0, markImg.Width, markImg.Height, GraphicsUnit.Pixel, imageAttributes);
                        //释放Graphics
                        g.Dispose();
                        //将生成得图片读入MemoryStream
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        newBitmap.Save(ms, ImageFormat.Jpeg);
                        //返回新的Image对象
                        img = Image.FromStream(ms);
                        return img;
                    }
                }
                return img;
            }
            catch
            {
                return img;
            }
        }

    }
}
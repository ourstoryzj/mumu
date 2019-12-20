using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Windows.Forms;
//using CefSharp.WinForms;

namespace Common
{


    public class ImageClass
    {
        /// <summary>
        /// 备用，用于存储图片
        /// </summary>
        public static Bitmap bmp_backup = null;

        public ImageClass()
        { }

        #region 缩略图  
        /// <summary>  
        /// 生成缩略图  
        /// </summary>  
        /// <param name="originalImagePath">源图路径（物理路径）</param>  
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>  
        /// <param name="width">缩略图宽度</param>  
        /// <param name="height">缩略图高度</param>  
        /// <param name="mode">生成缩略图的方式</param>      
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW":  //指定高宽缩放（可能变形）                  
                    break;
                case "W":   //指定宽，高按比例                      
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H":   //指定高，宽按比例  
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形）                  
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片  
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板  
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法  
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度  
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充  
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分  
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图  
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion

        #region 图片水印  
        /// <summary>  
        /// 图片水印处理方法  
        /// </summary>  
        /// <param name="path">需要加载水印的图片路径（绝对路径）</param>  
        /// <param name="waterpath">水印图片（绝对路径）</param>  
        /// <param name="location">水印位置（传送正确的代码）</param>  
        public static string ImageWatermark(string path, string waterpath, string location)
        {
            string kz_name = Path.GetExtension(path);
            if (kz_name == ".jpg" || kz_name == ".bmp" || kz_name == ".jpeg")
            {
                DateTime time = DateTime.Now;
                string filename = "" + time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString() + time.Millisecond.ToString();
                Image img = Bitmap.FromFile(path);
                Image waterimg = Image.FromFile(waterpath);
                Graphics g = Graphics.FromImage(img);
                ArrayList loca = GetLocation(location, img, waterimg);
                g.DrawImage(waterimg, new Rectangle(int.Parse(loca[0].ToString()), int.Parse(loca[1].ToString()), waterimg.Width, waterimg.Height));
                waterimg.Dispose();
                g.Dispose();
                string newpath = Path.GetDirectoryName(path) + filename + kz_name;
                img.Save(newpath);
                img.Dispose();
                File.Copy(newpath, path, true);
                if (File.Exists(newpath))
                {
                    File.Delete(newpath);
                }
            }
            return path;
        }




        #region 图片水印位置处理方法


        /// <summary>  
        /// 图片水印位置处理方法  
        /// </summary>  
        /// <param name="location">水印位置</param>  
        /// <param name="img">需要添加水印的图片</param>  
        /// <param name="waterimg">水印图片</param>  
        private static ArrayList GetLocation(string location, Image img, Image waterimg)
        {
            ArrayList loca = new ArrayList();
            int x = 0;
            int y = 0;

            if (location == "LT")
            {
                x = 10;
                y = 10;
            }
            else if (location == "T")
            {
                x = img.Width / 2 - waterimg.Width / 2;
                y = img.Height - waterimg.Height;
            }
            else if (location == "RT")
            {
                x = img.Width - waterimg.Width;
                y = 10;
            }
            else if (location == "LC")
            {
                x = 10;
                y = img.Height / 2 - waterimg.Height / 2;
            }
            else if (location == "C")
            {
                x = img.Width / 2 - waterimg.Width / 2;
                y = img.Height / 2 - waterimg.Height / 2;
            }
            else if (location == "RC")
            {
                x = img.Width - waterimg.Width;
                y = img.Height / 2 - waterimg.Height / 2;
            }
            else if (location == "LB")
            {
                x = 10;
                y = img.Height - waterimg.Height;
            }
            else if (location == "B")
            {
                x = img.Width / 2 - waterimg.Width / 2;
                y = img.Height - waterimg.Height;
            }
            else
            {
                x = img.Width - waterimg.Width;
                y = img.Height - waterimg.Height;
            }
            loca.Add(x);
            loca.Add(y);
            return loca;
        }
        #endregion

        #endregion

        #region 文字水印  
        /// <summary>  
        /// 文字水印处理方法  
        /// </summary>  
        /// <param name="path">图片路径（绝对路径）</param>  
        /// <param name="size">字体大小</param>  
        /// <param name="letter">水印文字</param>  
        /// <param name="color">颜色</param>  
        /// <param name="location">水印位置</param>  
        public static string LetterWatermark(string path, int size, string letter, Color color, string location)
        {
            #region  

            string kz_name = Path.GetExtension(path);
            if (kz_name == ".jpg" || kz_name == ".bmp" || kz_name == ".jpeg")
            {
                DateTime time = DateTime.Now;
                string filename = "" + time.Year.ToString() + time.Month.ToString() + time.Day.ToString() + time.Hour.ToString() + time.Minute.ToString() + time.Second.ToString() + time.Millisecond.ToString();
                Image img = Bitmap.FromFile(path);
                Graphics gs = Graphics.FromImage(img);
                ArrayList loca = GetLocation(location, img, size, letter.Length);
                Font font = new Font("宋体", size);
                Brush br = new SolidBrush(color);
                gs.DrawString(letter, font, br, float.Parse(loca[0].ToString()), float.Parse(loca[1].ToString()));
                gs.Dispose();
                string newpath = Path.GetDirectoryName(path) + filename + kz_name;
                img.Save(newpath);
                img.Dispose();
                File.Copy(newpath, path, true);
                if (File.Exists(newpath))
                {
                    File.Delete(newpath);
                }
            }
            return path;

            #endregion
        }

        /// <summary>  
        /// 文字水印位置的方法  
        /// </summary>  
        /// <param name="location">位置代码</param>  
        /// <param name="img">图片对象</param>  
        /// <param name="width">宽(当水印类型为文字时,传过来的就是字体的大小)</param>  
        /// <param name="height">高(当水印类型为文字时,传过来的就是字符的长度)</param>  
        private static ArrayList GetLocation(string location, Image img, int width, int height)
        {
            #region  

            ArrayList loca = new ArrayList();  //定义数组存储位置  
            float x = 10;
            float y = 10;

            if (location == "LT")
            {
                loca.Add(x);
                loca.Add(y);
            }
            else if (location == "T")
            {
                x = img.Width / 2 - (width * height) / 2;
                loca.Add(x);
                loca.Add(y);
            }
            else if (location == "RT")
            {
                x = img.Width - width * height;
            }
            else if (location == "LC")
            {
                y = img.Height / 2;
            }
            else if (location == "C")
            {
                x = img.Width / 2 - (width * height) / 2;
                y = img.Height / 2;
            }
            else if (location == "RC")
            {
                x = img.Width - height;
                y = img.Height / 2;
            }
            else if (location == "LB")
            {
                y = img.Height - width - 5;
            }
            else if (location == "B")
            {
                x = img.Width / 2 - (width * height) / 2;
                y = img.Height - width - 5;
            }
            else
            {
                x = img.Width - width * height;
                y = img.Height - width - 5;
            }
            loca.Add(x);
            loca.Add(y);
            return loca;

            #endregion
        }
        #endregion

        #region 调整光暗  
        /// <summary>  
        /// 调整光暗  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        /// <param name="width">原始图片的长度</param>  
        /// <param name="height">原始图片的高度</param>  
        /// <param name="val">增加或减少的光暗值</param>  
        public static Bitmap LDPic(Bitmap mybm, int width, int height, int val)
        {
            Bitmap bm = new Bitmap(width, height);//初始化一个记录经过处理后的图片对象  
            int x, y, resultR, resultG, resultB;//x、y是循环次数，后面三个是记录红绿蓝三个值的  
            Color pixel;
            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前像素的值  
                    resultR = pixel.R + val;//检查红色值会不会超出[0, 255]  
                    resultG = pixel.G + val;//检查绿色值会不会超出[0, 255]  
                    resultB = pixel.B + val;//检查蓝色值会不会超出[0, 255]  
                    bm.SetPixel(x, y, Color.FromArgb(resultR, resultG, resultB));//绘图  
                }
            }
            return bm;
        }


        /// <summary>
        /// 亮度
        /// </summary>
        /// <param name="a"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Bitmap BrightnessP(Bitmap a, int v)
        {
            //System.Drawing.Imaging.BitmapData bmpData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //int bytes = a.Width * a.Height * 3;
            //IntPtr ptr = bmpData.Scan0;
            //int stride = bmpData.Stride;
            //unsafe
            //{
            //    byte* p = (byte*)ptr;
            //    int temp;
            //    for (int j = 0; j < a.Height; j++)
            //    {
            //        for (int i = 0; i < a.Width * 3; i++, p++)
            //        {
            //            temp = (int)(p[0] + v);
            //            temp = (temp > 255) ? 255 : temp < 0 ? 0 : temp;
            //            p[0] = (byte)temp;
            //        }
            //        p += stride - a.Width * 3;
            //    }
            //}
            //a.UnlockBits(bmpData);
            return a;
        }
        #endregion

        #region 定义对比度调整函数

        //定义对比度调整函数
        public static Bitmap ContrastP(Bitmap a, double v)
        {
            //System.Drawing.Imaging.BitmapData bmpData = a.LockBits(new Rectangle(0, 0, a.Width, a.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //int bytes = a.Width * a.Height * 3;
            //IntPtr ptr = bmpData.Scan0;
            //int stride = bmpData.Stride;
            //unsafe
            //{
            //    byte* p = (byte*)ptr;
            //    int temp;
            //    for (int j = 0; j < a.Height; j++)
            //    {
            //        for (int i = 0; i < a.Width * 3; i++)
            //        {
            //            temp = (int)((p[0] - 127) * v + 127);
            //            temp = (temp > 255) ? 255 : temp < 0 ? 0 : temp;
            //            p[0] = (byte)temp;
            //            p++;
            //        }
            //        p += stride - a.Width * 3;
            //    }
            //}
            //a.UnlockBits(bmpData);
            return a;
        }

        /// <summary>
        /// 图像对比度调整
        /// </summary>
        /// <param name="b">原始图</param>
        /// <param name="degree">对比度[-100, 100]</param>
        /// <returns></returns>
        public static Bitmap ContrastPic(Bitmap b, int degree)
        {
            if (b == null)
            {
                return null;
            }

            if (degree < -100) degree = -100;
            if (degree > 100) degree = 100;

            try
            {

                //double pixel = 0;
                //double contrast = (100.0 + degree) / 100.0;
                //contrast *= contrast;
                //int width = b.Width;
                //int height = b.Height;
                //BitmapData data = b.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                //unsafe
                //{
                //    byte* p = (byte*)data.Scan0;
                //    int offset = data.Stride - width * 3;
                //    for (int y = 0; y < height; y++)
                //    {
                //        for (int x = 0; x < width; x++)
                //        {
                //            // 处理指定位置像素的对比度
                //            for (int i = 0; i < 3; i++)
                //            {
                //                pixel = ((p[i] / 255.0 - 0.5) * contrast + 0.5) * 255;
                //                if (pixel < 0) pixel = 0;
                //                if (pixel > 255) pixel = 255;
                //                p[i] = (byte)pixel;
                //            } // i
                //            p += 3;
                //        } // x
                //        p += offset;
                //    } // y
                //}
                //b.UnlockBits(data);
                return b;
            }
            catch
            {
                return null;
            }
        } // end of Contrast


        #endregion

        #region 图片锐化
        /// <summary>
        /// 定义图像锐化函数
        /// </summary>
        /// <param name="a"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public static Bitmap Sharpen(Bitmap a, double v)
        {
            int w = a.Width;
            int h = a.Height;
            try
            {
                Bitmap dstBitmap = new Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                //System.Drawing.Imaging.BitmapData srcData = a.LockBits(new Rectangle
                //(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                //System.Drawing.Imaging.BitmapData dstData = dstBitmap.LockBits(new Rectangle
                //(0, 0, w, h), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                //unsafe
                //{
                //    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                //    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                //    byte* p;
                //    int stride = srcData.Stride;
                //    for (int y = 0; y < h; y++)
                //    {
                //        for (int x = 0; x < w; x++)
                //        {
                //            //边缘八个点像素不变
                //            if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
                //            {
                //                pOut[0] = pIn[0];
                //                pOut[1] = pIn[1];
                //                pOut[2] = pIn[2];
                //            }
                //            else
                //            {
                //                int r0, r1, r2, r3, r4, r5, r6, r7, r8;
                //                int g1, g2, g3, g4, g5, g6, g7, g8, g0;
                //                int b1, b2, b3, b4, b5, b6, b7, b8, b0;
                //                double vR, vG, vB;
                //                //左上
                //                p = pIn - stride - 3;
                //                r1 = p[2];
                //                g1 = p[1];
                //                b1 = p[0];
                //                //正上
                //                p = pIn - stride;
                //                r2 = p[2];
                //                g2 = p[1];
                //                b2 = p[0];
                //                //右上
                //                p = pIn - stride + 3;
                //                r3 = p[2];
                //                g3 = p[1];
                //                b3 = p[0];
                //                //左
                //                p = pIn - 3;
                //                r4 = p[2];
                //                g4 = p[1];
                //                b4 = p[0];
                //                //右
                //                p = pIn + 3;
                //                r5 = p[2];
                //                g5 = p[1];
                //                b5 = p[0];
                //                //左下
                //                p = pIn + stride - 3;
                //                r6 = p[2];
                //                g6 = p[1];
                //                b6 = p[0];
                //                //正下
                //                p = pIn + stride;
                //                r7 = p[2];
                //                g7 = p[1];
                //                b7 = p[0];
                //                // 右下 
                //                p = pIn + stride + 3;
                //                r8 = p[2];
                //                g8 = p[1];
                //                b8 = p[0];
                //                //中心点
                //                p = pIn;
                //                r0 = p[2];
                //                g0 = p[1];
                //                b0 = p[0];
                //                vR = (double)r0 - (double)(r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8) / 8;
                //                vG = (double)g0 - (double)(g1 + g2 + g3 + g4 + g5 + g6 + g7 + g8) / 8;
                //                vB = (double)b0 - (double)(b1 + b2 + b3 + b4 + b5 + b6 + b7 + b8) / 8;
                //                vR = r0 + vR * v;
                //                vG = g0 + vG * v;
                //                vB = b0 + vB * v;
                //                if (vR > 0)
                //                {
                //                    vR = Math.Min(255, vR);
                //                }
                //                else
                //                {
                //                    vR = Math.Max(0, vR);
                //                }

                //                if (vG > 0)
                //                {
                //                    vG = Math.Min(255, vG);
                //                }
                //                else
                //                {
                //                    vG = Math.Max(0, vG);
                //                }

                //                if (vB > 0)
                //                {
                //                    vB = Math.Min(255, vB);
                //                }
                //                else
                //                {
                //                    vB = Math.Max(0, vB);
                //                }
                //                pOut[0] = (byte)vB;
                //                pOut[1] = (byte)vG;
                //                pOut[2] = (byte)vR;

                //            }
                //            pIn += 3;
                //            pOut += 3;
                //        }
                //        pIn += srcData.Stride - w * 3;
                //        pOut += srcData.Stride - w * 3;
                //    }
                //}
                //a.UnlockBits(srcData);
                //dstBitmap.UnlockBits(dstData);

                return dstBitmap;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region 反色处理  
        /// <summary>  
        /// 反色处理  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        /// <param name="width">原始图片的长度</param>  
        /// <param name="height">原始图片的高度</param>  
        public static Bitmap RePic(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);//初始化一个记录处理后的图片的对象  
            int x, y, resultR, resultG, resultB;
            Color pixel;
            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值  
                    resultR = 255 - pixel.R;//反红  
                    resultG = 255 - pixel.G;//反绿  
                    resultB = 255 - pixel.B;//反蓝  
                    bm.SetPixel(x, y, Color.FromArgb(resultR, resultG, resultB));//绘图  
                }
            }
            return bm;
        }
        #endregion

        #region 浮雕处理  
        /// <summary>  
        /// 浮雕处理  
        /// </summary>  
        /// <param name="oldBitmap">原始图片</param>  
        /// <param name="Width">原始图片的长度</param>  
        /// <param name="Height">原始图片的高度</param>  
        public static Bitmap FD(Bitmap oldBitmap, int Width, int Height)
        {
            Bitmap newBitmap = new Bitmap(Width, Height);
            Color color1, color2;
            for (int x = 0; x < Width - 1; x++)
            {
                for (int y = 0; y < Height - 1; y++)
                {
                    int r = 0, g = 0, b = 0;
                    color1 = oldBitmap.GetPixel(x, y);
                    color2 = oldBitmap.GetPixel(x + 1, y + 1);
                    r = Math.Abs(color1.R - color2.R + 128);
                    g = Math.Abs(color1.G - color2.G + 128);
                    b = Math.Abs(color1.B - color2.B + 128);
                    if (r > 255) r = 255;
                    if (r < 0) r = 0;
                    if (g > 255) g = 255;
                    if (g < 0) g = 0;
                    if (b > 255) b = 255;
                    if (b < 0) b = 0;
                    newBitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return newBitmap;
        }
        #endregion

        #region 拉伸图片  
        /// <summary>  
        /// 拉伸图片  
        /// </summary>  
        /// <param name="bmp">原始图片</param>  
        /// <param name="newW">新的宽度</param>  
        /// <param name="newH">新的高度</param>  
        public static Bitmap ResizeImage(Bitmap bmp, int newW, int newH)
        {
            try
            {
                Bitmap bap = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(bap);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bap.Width, bap.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return bap;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 滤色处理  
        /// <summary>  
        /// 滤色处理  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        /// <param name="width">原始图片的长度</param>  
        /// <param name="height">原始图片的高度</param>  
        public static Bitmap FilPic(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);//初始化一个记录滤色效果的图片对象  
            int x, y;
            Color pixel;

            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值  
                    bm.SetPixel(x, y, Color.FromArgb(0, pixel.G, pixel.B));//绘图  
                }
            }
            return bm;
        }
        #endregion

        #region 左右翻转  
        /// <summary>  
        /// 左右翻转  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        /// <param name="width">原始图片的长度</param>  
        /// <param name="height">原始图片的高度</param>  
        public static Bitmap RevPicLR(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);
            int x, y, z; //x,y是循环次数,z是用来记录像素点的x坐标的变化的  
            Color pixel;
            for (y = height - 1; y >= 0; y--)
            {
                for (x = width - 1, z = 0; x >= 0; x--)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前像素的值  
                    bm.SetPixel(z++, y, Color.FromArgb(pixel.R, pixel.G, pixel.B));//绘图  
                }
            }
            return bm;
        }
        #endregion

        #region 上下翻转  
        /// <summary>  
        /// 上下翻转  
        /// </summary>  
        /// <param name="mybm">原始图片</param>  
        /// <param name="width">原始图片的长度</param>  
        /// <param name="height">原始图片的高度</param>  
        public static Bitmap RevPicUD(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);
            int x, y, z;
            Color pixel;
            for (x = 0; x < width; x++)
            {
                for (y = height - 1, z = 0; y >= 0; y--)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前像素的值  
                    bm.SetPixel(x, z++, Color.FromArgb(pixel.R, pixel.G, pixel.B));//绘图  
                }
            }
            return bm;
        }
        #endregion

        #region 压缩图片  
        /// <summary>  
        /// 压缩到指定尺寸  
        /// </summary>  
        /// <param name="oldfile">原文件</param>  
        /// <param name="newfile">新文件</param> 
        /// <param name="writh">宽度</param> 
        /// <param name="height">高度</param> 
        public static bool Compress(string oldfile, string newfile, int writh, int height)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(oldfile);
                System.Drawing.Imaging.ImageFormat thisFormat = img.RawFormat;
                Size newSize = new Size(writh, height);
                Bitmap outBmp = new Bitmap(newSize.Width, newSize.Height);
                Graphics g = Graphics.FromImage(outBmp);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, new Rectangle(0, 0, newSize.Width, newSize.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                g.Dispose();
                EncoderParameters encoderParams = new EncoderParameters();
                long[] quality = new long[1];
                quality[0] = 100;
                EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                encoderParams.Param[0] = encoderParam;
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICI = null;
                for (int x = 0; x < arrayICI.Length; x++)
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICI = arrayICI[x]; //设置JPEG编码  
                        break;
                    }
                img.Dispose();
                if (jpegICI != null)
                    outBmp.Save(newfile, System.Drawing.Imaging.ImageFormat.Jpeg);
                outBmp.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 图片灰度化  
        public static Color Gray(Color c)
        {
            int rgb = Convert.ToInt32((double)(((0.3 * c.R) + (0.59 * c.G)) + (0.11 * c.B)));
            return Color.FromArgb(rgb, rgb, rgb);
        }
        #endregion

        #region 转换为黑白图片  
        /// <summary>  
        /// 转换为黑白图片  
        /// </summary>  
        /// <param name="mybt">要进行处理的图片</param>  
        /// <param name="width">图片的长度</param>  
        /// <param name="height">图片的高度</param>  
        public static Bitmap BWPic(Bitmap mybm, int width, int height)
        {
            Bitmap bm = new Bitmap(width, height);
            int x, y, result; //x,y是循环次数，result是记录处理后的像素值  
            Color pixel;
            for (x = 0; x < width; x++)
            {
                for (y = 0; y < height; y++)
                {
                    pixel = mybm.GetPixel(x, y);//获取当前坐标的像素值  
                    result = (pixel.R + pixel.G + pixel.B) / 3;//取红绿蓝三色的平均值  
                    bm.SetPixel(x, y, Color.FromArgb(result, result, result));
                }
            }
            return bm;
        }
        #endregion

        #region 获取图片中的各帧  
        /// <summary>  
        /// 获取图片中的各帧  
        /// </summary>  
        /// <param name="pPath">图片路径</param>  
        /// <param name="pSavePath">保存路径</param>  
        public static void GetFrames(string pPath, string pSavedPath)
        {
            Image gif = Image.FromFile(pPath);
            FrameDimension fd = new FrameDimension(gif.FrameDimensionsList[0]);
            int count = gif.GetFrameCount(fd); //获取帧数(gif图片可能包含多帧，其它格式图片一般仅一帧)  
            for (int i = 0; i < count; i++)    //以Jpeg格式保存各帧  
            {
                gif.SelectActiveFrame(fd, i);
                gif.Save(pSavedPath + "\\frame_" + i + ".jpg", ImageFormat.Jpeg);
            }
        }
        #endregion

        #region 获取图片MD5
        public static string GetMD5Hash(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail, error:" + ex.Message);
            }
        }




        #endregion

        #region 图片重绘，跟换MD5  
        /// <summary>  
        /// 图片重绘，跟换MD5  
        /// </summary>  
        /// <param name="oldfile">原文件</param>  
        /// <param name="newfile">新文件</param>  
        public static bool SetMD5Hash(string oldfile, string newfile)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(oldfile);
                System.Drawing.Imaging.ImageFormat thisFormat = img.RawFormat;
                Size newSize = new Size(img.Width, img.Height);
                Bitmap outBmp = new Bitmap(newSize.Width, newSize.Height);
                Graphics g = Graphics.FromImage(outBmp);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, new Rectangle(0, 0, newSize.Width, newSize.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                g.Dispose();
                EncoderParameters encoderParams = new EncoderParameters();
                long[] quality = new long[1];
                quality[0] = 100;
                EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                encoderParams.Param[0] = encoderParam;
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICI = null;
                for (int x = 0; x < arrayICI.Length; x++)
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICI = arrayICI[x]; //设置JPEG编码  
                        break;
                    }
                img.Dispose();
                if (jpegICI != null) outBmp.Save(newfile, System.Drawing.Imaging.ImageFormat.Jpeg);
                outBmp.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion


        #region 设置图片边框失败
        /// <summary>
        /// 设置图片边框失败
        /// </summary>
        /// <param name="filename">文件地址</param>
        /// <param name="writh">边框宽度</param>
        public static void biankuang(string filename, int writh)
        {
            try
            {
                //Image img = Bitmap.FromFile(filename);
                Image img = System.Drawing.Image.FromFile(filename);
                //img.Save(filename);
                int bordwidth = Convert.ToInt32(img.Width * 0.1);
                int bordheight = Convert.ToInt32(img.Height * 0.1);

                int newheight = img.Height + bordheight;
                int newwidth = img.Width + bordwidth;

                Color bordcolor = Color.White;
                Bitmap bmp = new Bitmap(newwidth, newheight);
                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

                int Style = 0;     //New: 绘制边框的类型, 手动修改0,1,2 可改变边框类型  
                if (Style == 0)   //New: 整个边框.  
                {
                    //Changed: 修改rec区域, 将原图缩放. 适合边框内  
                    System.Drawing.Rectangle rec = new Rectangle(bordwidth / 2, bordwidth / 2, newwidth - bordwidth / 2, newheight - bordwidth / 2);
                    g.DrawImage(img, rec, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                    g.DrawRectangle(new Pen(bordcolor, bordheight), 0, 0, newwidth, newheight);
                }
                else if (Style == 1)   //New: 上下边框.  
                {
                    System.Drawing.Rectangle rec = new Rectangle(0, bordwidth / 2, newwidth, newheight - bordwidth / 2);
                    g.DrawImage(img, rec, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                    g.DrawLine(new Pen(bordcolor, bordheight), 0, 0, newwidth, 0);
                    g.DrawLine(new Pen(bordcolor, bordheight), 0, newheight, newwidth, newheight);
                }
                else if (Style == 2)   //New: 左右边框.  
                {
                    System.Drawing.Rectangle rec = new Rectangle(bordwidth / 2, 0, newwidth - bordwidth / 2, newheight);
                    g.DrawImage(img, rec, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                    g.DrawLine(new Pen(bordcolor, bordheight), 0, 0, 0, newheight);
                    g.DrawLine(new Pen(bordcolor, bordheight), newwidth, 0, newwidth, newheight);
                }
                g.Dispose();
                bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                bmp.Dispose();
            }
            catch (Exception e)
            {
                Debug.WriteLine("添加边框错误" + e.ToString());
            }
        }
        #endregion


        #region 设置边框  
        /// <summary>  
        /// 设置边框  
        /// </summary>  
        /// <param name="oldfile">原文件</param>  
        /// <param name="newfile">新文件</param> 
        /// <param name="writh">宽度</param> 
        /// <param name="height">高度</param> 
        public static bool BianKuang(string oldfile, string newfile, Point p0, Point p1, Color RectColor, int LineWidth, DashStyle ds)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(oldfile);
                System.Drawing.Imaging.ImageFormat thisFormat = img.RawFormat;
                Size newSize = new Size(img.Width, img.Height);
                Bitmap outBmp = new Bitmap(newSize.Width, newSize.Height);
                Graphics g = Graphics.FromImage(outBmp);
                //设置边框
                //Brush brush = new SolidBrush(RectColor);
                //Pen pen = new Pen(brush, LineWidth);
                //pen.DashStyle = ds;
                //g.DrawRectangle(pen, new Rectangle(p0.X, p0.Y, Math.Abs(p0.X - p1.X), Math.Abs(p0.Y - p1.Y)));
                //设置边框
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;


                //int bordwidth = Convert.ToInt32(img.Width * 0.1);
                //int bordheight = Convert.ToInt32(img.Height * 0.1);
                int bordwidth = LineWidth;
                int bordheight = LineWidth;
                Color bordcolor = RectColor;
                int newheight = img.Height + bordheight;
                int newwidth = img.Width + bordwidth;
                //System.Drawing.Rectangle rec = new Rectangle(bordwidth / 2, bordwidth / 2, newwidth - bordwidth / 2, newheight - bordwidth / 2);
                System.Drawing.Rectangle rec = new Rectangle(0, 0, newwidth - bordwidth / 2, newheight - bordwidth / 2);
                g.DrawImage(img, rec, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                Pen pen = new Pen(bordcolor, bordheight);
                pen.DashStyle = ds;
                //g.DrawRectangle(new Pen(bordcolor, bordheight), 0, 0, 750, 750);
                g.DrawRectangle(pen, 0, 0, 750, 750);

                //g.DrawImage(img, new Rectangle(0, 0, newSize.Width, newSize.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
                g.Dispose();
                EncoderParameters encoderParams = new EncoderParameters();
                long[] quality = new long[1];
                quality[0] = 100;
                EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                encoderParams.Param[0] = encoderParam;
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICI = null;
                for (int x = 0; x < arrayICI.Length; x++)
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICI = arrayICI[x]; //设置JPEG编码  
                        break;
                    }
                img.Dispose();
                if (jpegICI != null)
                    outBmp.Save(newfile, System.Drawing.Imaging.ImageFormat.Jpeg);
                outBmp.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 设置边框失败


        /// <summary>
        /// 在图片上画框
        /// </summary>
        /// <param name="bmp">原始图</param>
        /// <param name="p0">起始点</param>
        /// <param name="p1">终止点</param>
        /// <param name="RectColor">矩形框颜色</param>
        /// <param name="LineWidth">矩形框边界</param>
        /// <returns></returns>
        public static Bitmap DrawRectangleInPicture(Bitmap bmp, Point p0, Point p1, Color RectColor, int LineWidth, DashStyle ds)
        {
            if (bmp == null) return null;


            Graphics g = Graphics.FromImage(bmp);

            Brush brush = new SolidBrush(RectColor);
            Pen pen = new Pen(brush, LineWidth);
            //ds = DashStyle.Dash;
            pen.DashStyle = ds;

            g.DrawRectangle(pen, new Rectangle(p0.X, p0.Y, Math.Abs(p0.X - p1.X), Math.Abs(p0.Y - p1.Y)));

            g.Dispose();

            return bmp;
        }


        /// <summary>
        /// 在图片上画椭圆
        /// </summary>
        /// <param name="bmp"></param>
        /// <param name="p0"></param>
        /// <param name="RectColor"></param>
        /// <param name="LineWidth"></param>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static Bitmap DrawRoundInPicture(Bitmap bmp, Point p0, Point p1, Color RectColor, int LineWidth, DashStyle ds)
        {
            if (bmp == null) return null;

            Graphics g = Graphics.FromImage(bmp);

            Brush brush = new SolidBrush(RectColor);
            Pen pen = new Pen(brush, LineWidth);
            pen.DashStyle = ds;

            g.DrawEllipse(pen, new Rectangle(p0.X, p0.Y, Math.Abs(p0.X - p1.X), Math.Abs(p0.Y - p1.Y)));

            g.Dispose();

            return bmp;
        }
        #endregion


        #region ImageProcess


        /// <summary>  
        /// 图像调整（色彩、亮度、对比度、伽马）  
        /// </summary>  
        /// <param name="bmp">原始图</param>  
        /// <param name="rVal">r增量（-255至255）</param>  
        /// <param name="gVal">g增量（-255至255）</param>  
        /// <param name="bVal">b增量（-255至255）</param>  
        /// <param name="brightVal">亮度（-255至255）</param>  
        /// <param name="contrastVal">对比度（-100至100）</param>  
        /// <param name="gammaVal">伽马（0-2,不包括边界0和2）</param>  
        /// <returns>处理后的图</returns>  
        public static Image ImageProcess(MemoryStream ms, int rVal, int gVal, int bVal, int brightVal, int contrastVal, float gammaVal)
        {
            if (ms == null)
            {
                return null;
            }
            Bitmap bmp = new Bitmap(ms);
            int h = bmp.Height;
            int w = bmp.Width;
            try
            {
                if (rVal > 255 || rVal < -255 || gVal > 255 || gVal < -255 || bVal > 255 || bVal < -255)
                {
                    return null;
                }

                contrastVal = (contrastVal < -100) ? -100 : contrastVal;
                contrastVal = (contrastVal > 100) ? 100 : contrastVal;
                brightVal = (brightVal < -255) ? -255 : brightVal;
                brightVal = (brightVal > 255) ? 255 : brightVal;
                double contrast = (100.0 + contrastVal) / 100.0;
                contrast *= contrast;
                gammaVal = (gammaVal < 0.1f) ? 0.1f : gammaVal;
                gammaVal = (gammaVal > 1.9f) ? 1.9f : gammaVal;

                BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                //unsafe
                //{
                //byte* p = (byte*)srcData.Scan0.ToPointer();
                //int nOffset = srcData.Stride - w * 3;
                //int r, g, b;
                //for (int y = 0; y < h; y++)
                //{
                //    for (int x = 0; x < w; x++)
                //    {

                //        b = p[0] + bVal + brightVal;
                //        b = Convert.ToInt32(((b / 255.0 - 0.5) * contrast + 0.5) * 255);
                //        if (bVal >= 0)
                //        {
                //            if (b > 255) b = 255;
                //        }
                //        else
                //        {
                //            if (b < 0) b = 0;
                //        }
                //        g = p[1] + gVal + brightVal;
                //        g = Convert.ToInt32(((g / 255.0 - 0.5) * contrast + 0.5) * 255);
                //        if (gVal >= 0)
                //        {
                //            if (g > 255) g = 255;
                //        }
                //        else
                //        {
                //            if (g < 0) g = 0;
                //        }
                //        r = p[2] + rVal + brightVal;
                //        r = Convert.ToInt32(((r / 255.0 - 0.5) * contrast + 0.5) * 255);
                //        if (rVal >= 0)
                //        {
                //            if (r > 255) r = 255;
                //        }
                //        else
                //        {
                //            if (r < 0) r = 0;
                //        }
                //        p[0] = (byte)b;
                //        p[1] = (byte)g;
                //        p[2] = (byte)r;
                //        p += 3;
                //    }
                //    p += nOffset;
                //}
                //}
                bmp.UnlockBits(srcData);
                if (gammaVal != 1.0000f)
                {
                    Graphics g = Graphics.FromImage(bmp);
                    ImageAttributes attr = new ImageAttributes();

                    attr.SetGamma(gammaVal, ColorAdjustType.Bitmap);
                    g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
                    g.Dispose();
                }

                ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return Image.FromStream(ms);
            }
            catch
            {
                return null;
            }
        }
        #endregion



        #region 无损压缩图片


        /// 无损压缩图片    
        /// <param name="sFile">原图片</param>    
        /// <param name="dFile">压缩后保存位置</param>    
        /// <param name="dHeight">高度</param>    
        /// <param name="dWidth"></param>    
        /// <param name="flag">压缩质量(数字越小压缩率越高) 1-100</param>    
        /// <returns></returns>    

        public static bool GetPicThumbnail(string sFile, string dFile, int dHeight, int dWidth, int flag)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int sW = 0, sH = 0;

            //按比例缩放  
            Size tem_size = new Size(iSource.Width, iSource.Height);

            if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();
            //以下代码为保存图片时，设置压缩质量    
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100    
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            //清空原img
            iSource.Dispose();
            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径    
                    //ob.Save(dFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {

                ob.Dispose();
            }
        }
        #endregion


        #region 无损压缩图片


        /// 无损压缩图片    
        /// <param name="sFile">原图片</param>    
        /// <param name="dFile">压缩后保存位置</param>    
        /// <param name="dHeight">高度</param>    
        /// <param name="dWidth"></param>    
        /// <param name="flag">压缩质量(数字越小压缩率越高) 1-100</param>    
        /// <returns></returns>    
        public static bool GetPicThumbnail(string sFile, string dFile, int dHeight, int dWidth, int flag, bool isshuiyin, bool isbiankuang, string waterpath)
        {
            //用于同一文件的md5
            //flag = new Random().Next((flag - 5) > 0 ? (flag - 5) : flag, (flag + 5) < 100 ? (flag + 5) : flag);
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            //获取文件扩展名
            string kz_name = Path.GetExtension(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int sW = 0, sH = 0;
            //边框宽度
            int LineWidth = 20;
            //边框颜色
            Color RectColor = Color.White;
            //边框类型
            //DashStyle ds = System.Drawing.Drawing2D.DashStyle.Solid;
            //int bordwidth = LineWidth;//四面边框
            //int bordheight = LineWidth;//四面边框
            int bordwidth = 0;//是否缩放边框尺寸
            int bordheight = 0;//是否缩放边框尺寸
            Color bordcolor = RectColor;
            int newheight = iSource.Height + bordheight;
            int newwidth = iSource.Width + bordwidth;
            //sW = iSource.Width;
            //sH = iSource.Height;


            if (dHeight == 0 && dWidth == 0)
            {
                dWidth = iSource.Width;
                dHeight = iSource.Height;
                sW = dWidth;
                sH = dHeight;
            }
            else if (dHeight == 0 && dWidth > 0)
            {
                //按比例缩放  
                Size tem_size = new Size(iSource.Width, iSource.Height);
                if (tem_size.Width > dWidth)
                {

                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                    dWidth = sW;
                    dHeight = sH;
                }
                else
                {
                    //如果不需要缩放
                    sW = iSource.Width;
                    sH = iSource.Height;
                    dWidth = sW;
                    dHeight = sH;
                }
            }
            else
            {
                //按比例缩放  
                Size tem_size = new Size(iSource.Width, iSource.Height);

                if (tem_size.Width > dHeight || tem_size.Width > dWidth)
                {
                    if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                    {
                        sW = dWidth;
                        sH = (dWidth * tem_size.Height) / tem_size.Width;
                    }
                    else
                    {
                        sH = dHeight;
                        sW = (tem_size.Width * dHeight) / tem_size.Height;
                    }
                }
                else
                {
                    //如果不需要缩放
                    sW = tem_size.Width;
                    sH = tem_size.Height;
                    dWidth = sW;
                    dHeight = sH;
                    //sW = dWidth;
                    //sH = dHeight;
                }
            }
            //主画图矩形尺寸
            System.Drawing.Rectangle rec = new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH);//无损压缩

            Bitmap ob = new Bitmap(dWidth, dHeight);
            #region 边框=======================================================================
            if (isbiankuang)
            {
                ob = new Bitmap(dWidth, dHeight + LineWidth * 2);
            }
            #endregion

            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;



            //g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            //修改边框前的代码2017年9月8日18
            g.DrawImage(iSource, rec, 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            //if (isbiankuang)
            //{
            //    g.DrawImage(iSource, rec, 0, LineWidth, iSource.Width, iSource.Height + LineWidth * 2, GraphicsUnit.Pixel);
            //}
            //else
            //{
            //    g.DrawImage(iSource, rec, 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            //}


            #region 边框 bak=======================================================================
            //if (isbiankuang)
            //{
            //    Pen pen = new Pen(bordcolor, bordheight);//四面边框
            //    pen.DashStyle = ds;
            //    g.DrawRectangle(pen, 0, 0, 750, 750);
            //    //Pen pen = new Pen(bordcolor, LineWidth); //设置边框尺寸
            //    //pen.DashStyle = ds;
            //    //g.DrawRectangle(pen, 0, 0, 750, 750 + LineWidth);
            //}
            #endregion




            g.Dispose();





            //以下代码为保存图片时，设置压缩质量    
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100    
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            //清空原img
            iSource.Dispose();




            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径    
                    //ob.Save(dFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }

                //如果修改名字，则删除源文件
                if (sFile != dFile)
                {
                    File.Delete(sFile);
                }



                #region 水印===========================================================================
                if (isshuiyin)
                {

                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss");
                    Image img = Bitmap.FromFile(dFile);
                    Image waterimg = Image.FromFile(waterpath);
                    Graphics gr = Graphics.FromImage(img);
                    ArrayList loca = GetLocation("C", img, waterimg);
                    gr.DrawImage(waterimg, new Rectangle(int.Parse(loca[0].ToString()), int.Parse(loca[1].ToString()), waterimg.Width, waterimg.Height));
                    waterimg.Dispose();
                    gr.Dispose();
                    string newpath = Path.GetDirectoryName(dFile) + filename + kz_name;
                    if (jpegICIinfo != null)
                    {
                        img.Save(newpath, jpegICIinfo, ep);
                    }
                    else
                    {
                        img.Save(newpath);
                    }
                    img.Dispose();
                    File.Copy(newpath, dFile, true);
                    if (File.Exists(newpath))
                    {
                        File.Delete(newpath);
                    }
                    return true;
                }
                #endregion

                //修改MD5
                SetMD5Hash(dFile, dFile);

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {

                ob.Dispose();
            }
        }
        #endregion


        #region 图片处理

        /// 无损压缩图片    
        /// <param name="sFile">原图片</param>    
        /// <param name="dFile">压缩后保存位置</param>    
        /// <param name="dHeight">高度</param>    
        /// <param name="dWidth"></param>    
        /// <param name="flag">压缩质量(数字越小压缩率越高) 1-100</param>    
        /// <returns></returns>    
        public static bool ImageMake(Image iSource, string dFile, int dHeight, int dWidth, int flag, bool isshuiyin, bool isbiankuang, string waterpath, bool isfanzhuan)
        {
            try
            {
                //flag = new Random().Next((flag - 5) > 0 ? (flag - 5) : flag, (flag + 5) < 100 ? (flag + 5) : flag);
                //System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
                //获取文件扩展名
                string kz_name = Path.GetExtension(dFile);
                ImageFormat tFormat = ImageFormat.Jpeg;
                int sW = 0, sH = 0;
                //边框宽度
                int LineWidth = 20;
                //边框颜色
                Color RectColor = Color.White;
                //边框类型
                //DashStyle ds = System.Drawing.Drawing2D.DashStyle.Solid;
                //int bordwidth = LineWidth;//四面边框
                //int bordheight = LineWidth;//四面边框
                int bordwidth = 0;//是否缩放边框尺寸
                int bordheight = 0;//是否缩放边框尺寸
                Color bordcolor = RectColor;
                int newheight = iSource.Height + bordheight;
                int newwidth = iSource.Width + bordwidth;
                //sW = iSource.Width;
                //sH = iSource.Height;


                if (dHeight == 0 && dWidth == 0)
                {
                    dWidth = iSource.Width;
                    dHeight = iSource.Height;
                    sW = dWidth;
                    sH = dHeight;
                }
                else if (dHeight == 0 && dWidth > 0)
                {
                    //按比例缩放  
                    Size tem_size = new Size(iSource.Width, iSource.Height);
                    if (tem_size.Width > dWidth)
                    {

                        sW = dWidth;
                        sH = (dWidth * tem_size.Height) / tem_size.Width;
                        dWidth = sW;
                        dHeight = sH;
                    }
                    else
                    {
                        //如果不需要缩放
                        sW = iSource.Width;
                        sH = iSource.Height;
                        dWidth = sW;
                        dHeight = sH;
                    }
                }
                else
                {
                    //按比例缩放  
                    Size tem_size = new Size(iSource.Width, iSource.Height);

                    if (tem_size.Width > dHeight || tem_size.Width > dWidth)
                    {
                        if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                        {
                            sW = dWidth;
                            sH = (dWidth * tem_size.Height) / tem_size.Width;
                        }
                        else
                        {
                            sH = dHeight;
                            sW = (tem_size.Width * dHeight) / tem_size.Height;
                        }
                    }
                    else
                    {
                        //如果不需要缩放
                        sW = tem_size.Width;
                        sH = tem_size.Height;
                        dWidth = sW;
                        dHeight = sH;
                        //sW = dWidth;
                        //sH = dHeight;
                    }
                }
                //主画图矩形尺寸
                System.Drawing.Rectangle rec = new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH);//无损压缩

                Bitmap ob = new Bitmap(dWidth, dHeight);
                #region 边框=======================================================================
                if (isbiankuang)
                {
                    ob = new Bitmap(dWidth, dHeight + LineWidth * 2);
                }
                #endregion

                Graphics g = Graphics.FromImage(ob);

                g.Clear(Color.White);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;



                //g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

                //修改边框前的代码2017年9月8日18
                g.DrawImage(iSource, rec, 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

                //if (isbiankuang)
                //{
                //    g.DrawImage(iSource, rec, 0, LineWidth, iSource.Width, iSource.Height + LineWidth * 2, GraphicsUnit.Pixel);
                //}
                //else
                //{
                //    g.DrawImage(iSource, rec, 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
                //}


                #region 边框 bak=======================================================================
                //if (isbiankuang)
                //{
                //    Pen pen = new Pen(bordcolor, bordheight);//四面边框
                //    pen.DashStyle = ds;
                //    g.DrawRectangle(pen, 0, 0, 750, 750);
                //    //Pen pen = new Pen(bordcolor, LineWidth); //设置边框尺寸
                //    //pen.DashStyle = ds;
                //    //g.DrawRectangle(pen, 0, 0, 750, 750 + LineWidth);
                //}
                #endregion




                g.Dispose();





                //以下代码为保存图片时，设置压缩质量    
                EncoderParameters ep = new EncoderParameters();
                long[] qy = new long[1];
                qy[0] = flag;//设置压缩的比例1-100    
                EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
                ep.Param[0] = eParam;
                //清空原img
                //iSource.Dispose();




                try
                {
                    ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo jpegICIinfo = null;
                    for (int x = 0; x < arrayICI.Length; x++)
                    {
                        if (arrayICI[x].FormatDescription.Equals("JPEG"))
                        {
                            jpegICIinfo = arrayICI[x];
                            break;
                        }
                    }
                    //处理翻转
                    if (isfanzhuan)
                        ob = RevPicLR(ob, ob.Width, ob.Height);

                    if (jpegICIinfo != null)
                    {
                        ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径    
                                                        //ob.Save(dFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    else
                    {
                        ob.Save(dFile, tFormat);
                    }



                    #region 水印===========================================================================
                    if (isshuiyin)
                    {

                        string filename = DateTime.Now.ToString("yyyyMMddHHmmss");
                        Image img = Bitmap.FromFile(dFile);
                        Image waterimg = Image.FromFile(waterpath);
                        Graphics gr = Graphics.FromImage(img);
                        ArrayList loca = GetLocation("C", img, waterimg);
                        gr.DrawImage(waterimg, new Rectangle(int.Parse(loca[0].ToString()), int.Parse(loca[1].ToString()), waterimg.Width, waterimg.Height));
                        waterimg.Dispose();
                        gr.Dispose();
                        string newpath = Path.GetDirectoryName(dFile) + filename + kz_name;
                        if (jpegICIinfo != null)
                        {
                            img.Save(newpath, jpegICIinfo, ep);
                        }
                        else
                        {
                            img.Save(newpath);
                        }
                        img.Dispose();
                        File.Copy(newpath, dFile, true);
                        if (File.Exists(newpath))
                        {
                            File.Delete(newpath);
                        }

                    }
                    #endregion

                    //修改MD5
                    SetMD5Hash(dFile, dFile);


                    return true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
                finally
                {

                    ob.Dispose();
                }
            }
            catch (Exception exx)
            {
                Debug.WriteLine(exx.ToString());
                return false;
            }
        }

        /// 无损压缩图片    
        /// <param name="sFile">原图片</param>    
        /// <param name="dFile">压缩后保存位置</param>    
        /// <param name="dHeight">高度</param>    
        /// <param name="dWidth"></param>    
        /// <param name="flag">压缩质量(数字越小压缩率越高) 1-100</param>    
        /// <returns></returns>    
        public static Bitmap ImageMake(Image iSource, int dHeight, int dWidth, int flag, bool isbiankuang, bool isfanzhuan)
        {
            try
            {

                ImageFormat tFormat = ImageFormat.Jpeg;
                int sW = 0, sH = 0;
                //边框宽度
                int LineWidth = 20;
                //边框颜色
                Color RectColor = Color.White;
                //边框类型
                //DashStyle ds = System.Drawing.Drawing2D.DashStyle.Solid;
                //int bordwidth = LineWidth;//四面边框
                //int bordheight = LineWidth;//四面边框
                int bordwidth = 0;//是否缩放边框尺寸
                int bordheight = 0;//是否缩放边框尺寸
                Color bordcolor = RectColor;
                int newheight = iSource.Height + bordheight;
                int newwidth = iSource.Width + bordwidth;
                //sW = iSource.Width;
                //sH = iSource.Height;


                if (dHeight == 0 && dWidth == 0)
                {
                    dWidth = iSource.Width;
                    dHeight = iSource.Height;
                    sW = dWidth;
                    sH = dHeight;
                }
                else if (dHeight == 0 && dWidth > 0)
                {
                    //按比例缩放  
                    Size tem_size = new Size(iSource.Width, iSource.Height);
                    if (tem_size.Width > dWidth)
                    {

                        sW = dWidth;
                        sH = (dWidth * tem_size.Height) / tem_size.Width;
                        dWidth = sW;
                        dHeight = sH;
                    }
                    else
                    {
                        //如果不需要缩放
                        sW = iSource.Width;
                        sH = iSource.Height;
                        dWidth = sW;
                        dHeight = sH;
                    }
                }
                else
                {
                    //按比例缩放  
                    Size tem_size = new Size(iSource.Width, iSource.Height);

                    if (tem_size.Width > dHeight || tem_size.Width > dWidth)
                    {
                        if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                        {
                            sW = dWidth;
                            sH = (dWidth * tem_size.Height) / tem_size.Width;
                        }
                        else
                        {
                            sH = dHeight;
                            sW = (tem_size.Width * dHeight) / tem_size.Height;
                        }
                    }
                    else
                    {
                        //如果不需要缩放
                        sW = tem_size.Width;
                        sH = tem_size.Height;
                        dWidth = sW;
                        dHeight = sH;
                        //sW = dWidth;
                        //sH = dHeight;
                    }
                }
                //主画图矩形尺寸
                System.Drawing.Rectangle rec = new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH);//无损压缩

                Bitmap ob = new Bitmap(dWidth, dHeight);
                #region 边框=======================================================================
                if (isbiankuang)
                {
                    ob = new Bitmap(dWidth, dHeight + LineWidth * 2);
                }
                #endregion

                Graphics g = Graphics.FromImage(ob);

                g.Clear(Color.White);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(iSource, rec, 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);


                g.Dispose();


                //以下代码为保存图片时，设置压缩质量    
                EncoderParameters ep = new EncoderParameters();
                long[] qy = new long[1];
                qy[0] = flag;//设置压缩的比例1-100    
                EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
                ep.Param[0] = eParam;
                //清空原img
                //iSource.Dispose();




                try
                {
                    ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                    ImageCodecInfo jpegICIinfo = null;
                    for (int x = 0; x < arrayICI.Length; x++)
                    {
                        if (arrayICI[x].FormatDescription.Equals("JPEG"))
                        {
                            jpegICIinfo = arrayICI[x];
                            break;
                        }
                    }



                    //处理翻转
                    if (isfanzhuan)
                        ob = RevPicLR(ob, ob.Width, ob.Height);

                    return ob;

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                    return ob;
                }

            }
            catch (Exception exx)
            {
                Debug.WriteLine(exx.ToString());
                return null;
            }
        }


        /// 无损压缩图片    
        /// <param name="sFile">原图片</param>    
        /// <param name="dFile">压缩后保存位置</param>    
        /// <param name="dHeight">高度</param>    
        /// <param name="dWidth"></param>    
        /// <param name="flag">压缩质量(数字越小压缩率越高) 1-100</param>    
        /// <returns></returns>    
        public static bool ImageMake(string sFile, string dFile, int dHeight, int dWidth, int flag, bool isshuiyin, bool isbiankuang, string waterpath, bool isfanzhuan)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            //获取文件扩展名
            string kz_name = Path.GetExtension(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int sW = 0, sH = 0;
            //边框宽度
            int LineWidth = 20;
            //边框颜色
            Color RectColor = Color.White;
            //边框类型
            //DashStyle ds = System.Drawing.Drawing2D.DashStyle.Solid;
            //int bordwidth = LineWidth;//四面边框
            //int bordheight = LineWidth;//四面边框
            int bordwidth = 0;//是否缩放边框尺寸
            int bordheight = 0;//是否缩放边框尺寸
            Color bordcolor = RectColor;
            int newheight = iSource.Height + bordheight;
            int newwidth = iSource.Width + bordwidth;
            //sW = iSource.Width;
            //sH = iSource.Height;


            if (dHeight == 0 && dWidth == 0)
            {
                dWidth = iSource.Width;
                dHeight = iSource.Height;
                sW = dWidth;
                sH = dHeight;
            }
            else if (dHeight == 0 && dWidth > 0)
            {
                //按比例缩放  
                Size tem_size = new Size(iSource.Width, iSource.Height);
                if (tem_size.Width > dWidth)
                {

                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                    dWidth = sW;
                    dHeight = sH;
                }
                else
                {
                    //如果不需要缩放
                    sW = iSource.Width;
                    sH = iSource.Height;
                    dWidth = sW;
                    dHeight = sH;
                }
            }
            else
            {
                //按比例缩放  
                Size tem_size = new Size(iSource.Width, iSource.Height);

                if (tem_size.Width > dHeight || tem_size.Width > dWidth)
                {
                    if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                    {
                        sW = dWidth;
                        sH = (dWidth * tem_size.Height) / tem_size.Width;
                    }
                    else
                    {
                        sH = dHeight;
                        sW = (tem_size.Width * dHeight) / tem_size.Height;
                    }
                }
                else
                {
                    //如果不需要缩放
                    sW = tem_size.Width;
                    sH = tem_size.Height;
                    dWidth = sW;
                    dHeight = sH;
                    //sW = dWidth;
                    //sH = dHeight;
                }
            }
            //主画图矩形尺寸
            System.Drawing.Rectangle rec = new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH);//无损压缩

            Bitmap ob = new Bitmap(dWidth, dHeight);
            #region 边框=======================================================================
            if (isbiankuang)
            {
                ob = new Bitmap(dWidth, dHeight + LineWidth * 2);
            }
            #endregion

            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;



            //g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            //修改边框前的代码2017年9月8日18
            g.DrawImage(iSource, rec, 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            //if (isbiankuang)
            //{
            //    g.DrawImage(iSource, rec, 0, LineWidth, iSource.Width, iSource.Height + LineWidth * 2, GraphicsUnit.Pixel);
            //}
            //else
            //{
            //    g.DrawImage(iSource, rec, 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            //}


            #region 边框 bak=======================================================================
            //if (isbiankuang)
            //{
            //    Pen pen = new Pen(bordcolor, bordheight);//四面边框
            //    pen.DashStyle = ds;
            //    g.DrawRectangle(pen, 0, 0, 750, 750);
            //    //Pen pen = new Pen(bordcolor, LineWidth); //设置边框尺寸
            //    //pen.DashStyle = ds;
            //    //g.DrawRectangle(pen, 0, 0, 750, 750 + LineWidth);
            //}
            #endregion




            g.Dispose();





            //以下代码为保存图片时，设置压缩质量    
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100    
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            //清空原img
            iSource.Dispose();




            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                //处理翻转
                if (isfanzhuan)
                    ob = RevPicLR(ob, ob.Width, ob.Height);

                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径    
                    //ob.Save(dFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }

                //如果修改名字，则删除源文件
                if (sFile != dFile)
                {
                    File.Delete(sFile);
                }



                #region 水印===========================================================================
                if (isshuiyin)
                {

                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss");
                    Image img = Bitmap.FromFile(dFile);
                    Image waterimg = Image.FromFile(waterpath);
                    Graphics gr = Graphics.FromImage(img);
                    ArrayList loca = GetLocation("C", img, waterimg);
                    gr.DrawImage(waterimg, new Rectangle(int.Parse(loca[0].ToString()), int.Parse(loca[1].ToString()), waterimg.Width, waterimg.Height));
                    waterimg.Dispose();
                    gr.Dispose();
                    string newpath = Path.GetDirectoryName(dFile) + filename + kz_name;
                    if (jpegICIinfo != null)
                    {
                        img.Save(newpath, jpegICIinfo, ep);
                    }
                    else
                    {
                        img.Save(newpath);
                    }
                    img.Dispose();
                    File.Copy(newpath, dFile, true);
                    if (File.Exists(newpath))
                    {
                        File.Delete(newpath);
                    }

                }
                #endregion


                //修改MD5
                SetMD5Hash(dFile, dFile);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {

                ob.Dispose();
            }
        }
        #endregion


        #region 2017年10月25日13

        #region 无损压缩图片


        /// 无损压缩图片    
        /// <param name="sFile">原图片</param>    
        /// <param name="dFile">压缩后保存位置</param>    
        /// <param name="dHeight">高度</param>    
        /// <param name="dWidth"></param>    
        /// <param name="flag">压缩质量(数字越小压缩率越高) 1-100</param>    
        /// <returns></returns>    

        public static bool GetPicThumbnail_bak(string sFile, string dFile, int dHeight, int dWidth, int flag, bool isshuiyin, bool isbiankuang, string waterpath)
        {
            System.Drawing.Image iSource = System.Drawing.Image.FromFile(sFile);
            //获取文件扩展名
            string kz_name = Path.GetExtension(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int sW = 0, sH = 0;
            //边框宽度
            int LineWidth = 20;
            //边框颜色
            Color RectColor = Color.White;
            //边框类型
            //DashStyle ds = System.Drawing.Drawing2D.DashStyle.Solid;
            //int bordwidth = LineWidth;//四面边框
            //int bordheight = LineWidth;//四面边框
            int bordwidth = 0;//是否缩放边框尺寸
            int bordheight = 0;//是否缩放边框尺寸
            Color bordcolor = RectColor;
            int newheight = iSource.Height + bordheight;
            int newwidth = iSource.Width + bordwidth;


            if (dHeight == 0)
            {
                dWidth = iSource.Width;
                dHeight = iSource.Height;
                sW = dWidth;
                sH = dHeight;
            }
            else
            {
                //按比例缩放  
                Size tem_size = new Size(iSource.Width, iSource.Height);

                if (tem_size.Width > dHeight || tem_size.Width > dWidth)
                {
                    if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                    {
                        sW = dWidth;
                        sH = (dWidth * tem_size.Height) / tem_size.Width;
                    }
                    else
                    {
                        sH = dHeight;
                        sW = (tem_size.Width * dHeight) / tem_size.Height;
                    }
                }
                else
                {
                    sW = tem_size.Width;
                    sH = tem_size.Height;
                    dWidth = sW;
                    dHeight = sH;
                    //sW = dWidth;
                    //sH = dHeight;
                }
            }
            //主画图矩形尺寸
            System.Drawing.Rectangle rec = new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH);//无损压缩

            Bitmap ob = new Bitmap(dWidth, dHeight);
            #region 边框=======================================================================
            if (isbiankuang)
            {
                ob = new Bitmap(dWidth, dHeight + LineWidth * 2);
            }
            #endregion

            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;



            //g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            //修改边框前的代码2017年9月8日18
            g.DrawImage(iSource, rec, 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            //if (isbiankuang)
            //{
            //    g.DrawImage(iSource, rec, 0, LineWidth, iSource.Width, iSource.Height + LineWidth * 2, GraphicsUnit.Pixel);
            //}
            //else
            //{
            //    g.DrawImage(iSource, rec, 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);
            //}


            #region 边框=======================================================================
            //if (isbiankuang)
            //{
            //    Pen pen = new Pen(bordcolor, bordheight);//四面边框
            //    pen.DashStyle = ds;
            //    g.DrawRectangle(pen, 0, 0, 750, 750);
            //    //Pen pen = new Pen(bordcolor, LineWidth); //设置边框尺寸
            //    //pen.DashStyle = ds;
            //    //g.DrawRectangle(pen, 0, 0, 750, 750 + LineWidth);
            //}
            #endregion




            g.Dispose();





            //以下代码为保存图片时，设置压缩质量    
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100    
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            //清空原img
            iSource.Dispose();




            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径    
                    //ob.Save(dFile, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }

                //如果修改名字，则删除源文件
                if (sFile != dFile)
                {
                    File.Delete(sFile);
                }



                #region 水印===========================================================================
                if (isshuiyin)
                {

                    string filename = DateTime.Now.ToString("yyyyMMddHHmmss");
                    Image img = Bitmap.FromFile(dFile);
                    Image waterimg = Image.FromFile(waterpath);
                    Graphics gr = Graphics.FromImage(img);
                    ArrayList loca = GetLocation("C", img, waterimg);
                    gr.DrawImage(waterimg, new Rectangle(int.Parse(loca[0].ToString()), int.Parse(loca[1].ToString()), waterimg.Width, waterimg.Height));
                    waterimg.Dispose();
                    gr.Dispose();
                    string newpath = Path.GetDirectoryName(dFile) + filename + kz_name;
                    if (jpegICIinfo != null)
                    {
                        img.Save(newpath, jpegICIinfo, ep);
                    }
                    else
                    {
                        img.Save(newpath);
                    }
                    img.Dispose();
                    File.Copy(newpath, dFile, true);
                    if (File.Exists(newpath))
                    {
                        File.Delete(newpath);
                    }
                    return true;
                }
                #endregion



                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
            finally
            {

                ob.Dispose();
            }
        }
        #endregion
        #endregion


        #region 屏幕截图 绘制 保存高低质量图片



        #region 绘制功能
        /*
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
      */
        #endregion

        #region 屏幕截图
        /// <summary>
        /// 屏幕截图
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetScreen()
        {
            //获取整个屏幕图像,不包括任务栏
            Rectangle ScreenArea = Screen.GetWorkingArea(new Point());
            Bitmap bmp = new Bitmap(ScreenArea.Width, ScreenArea.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(ScreenArea.Width, ScreenArea.Height));
            }
            return bmp;
        }
        #endregion

        #region 屏幕截图
        /// <summary>
        /// 浏览器截图
        /// </summary>
        /// <param name="wb">浏览器</param>
        /// <returns></returns>
        //public static Bitmap GetBitmapByWebBrowser(ChromiumWebBrowser wb)
        //{
        //    Point p = wb.PointToScreen(new Point());
        //    Size s = wb.Size;
        //    Bitmap bmp = new Bitmap(s.Width, s.Height);

        //    using (Graphics g = Graphics.FromImage(bmp))
        //    {
        //        g.CopyFromScreen(p.X, p.Y, 0, 0, s);
        //    }
        //    //压缩图片

        //    return bmp;
        //}
        #endregion

        #region 屏幕截图
        /// <summary>
        /// 浏览器截图
        /// </summary>
        /// <param name="wb">浏览器</param>
        /// <param name="flag">图片质量1-100</param>
        /// <param name="fileurl">保存位置</param>
        /// <returns></returns>
        //public static bool GetScreen(ChromiumWebBrowser wb, int flag, string fileurl)
        //{
        //    Bitmap bmp = GetBitmapByWebBrowser(wb);
        //    bmp.Save(fileurl, GetImgCodecInfo(), SetImgFlag(flag));
        //    return true;
        //}
        #endregion

        #region 屏幕截图
        /// <summary>
        /// 浏览器截图
        /// </summary>
        /// <param name="wb">浏览器</param>
        /// <returns></returns>
        //public static Bitmap GetScreen(ChromiumWebBrowser wb)
        //{
        //    Point p = wb.PointToScreen(new Point());
        //    Size s = wb.Size;
        //    Bitmap bmp = new Bitmap(s.Width, s.Height);

        //    using (Graphics g = Graphics.FromImage(bmp))
        //    {
        //        g.CopyFromScreen(p.X, p.Y, 0, 0, s);
        //    }
        //    //压缩图片

        //    return bmp;
        //}
        #endregion

        #region 屏幕截图
        /// <summary>
        /// 浏览器截图
        /// </summary>
        /// <param name="wb">浏览器</param>
        /// <param name="flag">图片质量1-100</param>
        /// <param name="fileurl">保存位置</param>
        /// <returns></returns>
        //public static bool GetScreen2(ChromiumWebBrowser wb, int flag, string fileurl)
        //{

        //    Bitmap bmp = GetScreen(wb);

        //    //压缩图片

        //    //以下代码为保存图片时，设置压缩质量    
        //    EncoderParameters ep = new EncoderParameters();
        //    long[] qy = new long[1];
        //    qy[0] = flag;//设置压缩的比例1-100    
        //    EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
        //    ep.Param[0] = eParam;


        //    ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
        //    ImageCodecInfo jpegICIinfo = null;
        //    for (int x = 0; x < arrayICI.Length; x++)
        //    {
        //        if (arrayICI[x].FormatDescription.Equals("JPEG"))
        //        {
        //            jpegICIinfo = arrayICI[x];
        //            break;
        //        }
        //    }
        //    bmp.Save(fileurl, jpegICIinfo, ep);
        //    bmp.Dispose();
        //    ep.Dispose();
        //    return true;
        //}
        #endregion

        #region 屏幕截图
        /// <summary>
        /// 图片保存时设置质量
        /// </summary>
        /// <param name="wb">浏览器</param>
        /// <param name="flag">图片质量1-100</param>
        /// <param name="fileurl">保存位置,需要加上文件名称//123.jpg</param>
        /// <returns></returns>
        public static bool GetScreen(Bitmap bmp, int flag, string fileurl)
        {
            //压缩图片
            bmp.Save(fileurl, GetImgCodecInfo(), SetImgFlag(flag));
            //bmp.Save(fileurl, jpegICIinfo, ep);
            return true;
        }
        #endregion

        #region 屏幕截图
        /// <summary>
        /// 图片保存时设置质量,判断文件夹是否存在，可创建，可设置文件名称
        /// </summary>
        /// <param name="wb">浏览器</param>
        /// <param name="flag">图片质量1-100</param>
        /// <param name="fileurl">保存位置,需要加上文件名称//123.jpg</param>
        /// <param name="filename">文件名称</param>
        /// <returns></returns>
        public static bool GetScreen(Bitmap bmp, int flag, string fileurl, string filename)
        {
            if (!Directory.Exists(fileurl))
                Directory.CreateDirectory(fileurl);
            //压缩图片
            bmp.Save(fileurl + "//" + filename, GetImgCodecInfo(), SetImgFlag(flag));
            return true;
        }
        #endregion

        #region 设置图片质量 SetImgFlag
        /// <summary>
        /// 设置图片质量
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static EncoderParameters SetImgFlag(int flag)
        {
            //以下代码为保存图片时，设置压缩质量    
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100    
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;
            return ep;
        }
        #endregion

        #region 获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象. GetImgCodecInfo
        /// <summary>
        /// 获得包含有关内置图像编码解码器的信息的ImageCodecInfo 对象.
        /// </summary>
        /// <returns></returns>
        public static ImageCodecInfo GetImgCodecInfo()
        {
            ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo jpegICIinfo = null;
            for (int x = 0; x < arrayICI.Length; x++)
            {
                if (arrayICI[x].FormatDescription.Equals("JPEG"))
                {
                    jpegICIinfo = arrayICI[x];
                    break;
                }
            }
            return jpegICIinfo;
        }
        #endregion

        #endregion

        #region 平移image中的一个像素修改md5值
        /*
        /// <summary>
        /// 平移图像
        /// </summary>
        /// <param name="bm"></param>
        /// <param name="nOffset">平移的方向</param>
        /// <param name="nOffset">平移的偏移量</param>
        /// <param name="nOffset">平移的填充像素</param>
        private void Translate(Bitmap bm, Direction Direction, int nOffset, Color crFill)
        {
            switch (Direction)
            {
                case Direction.Left:
                    {
                        // 向左平移 nDeep 位
                        for (int idxCol = nOffset; idxCol < bm.Width; ++idxCol)
                        {
                            int idxColDst = idxCol - nOffset;

                            for (int idxRow = 0; idxRow < bm.Height; ++idxRow)
                            {
                                Color crSrc = bm.GetPixel(idxCol, idxRow);
                                bm.SetPixel(idxColDst, idxRow, crSrc);
                            }
                        }
                        // 被移空的地方填充crFill设定的背景
                        FillRect(bm,
new Point(bm.Width - nOffset, 0),
new Point(bm.Width - 1, bm.Height - 1),
crFill);
                    }
                    break;

                case Direction.Right:
                    {
                        // 向右平移 
                        for (int idxCol = bm.Width - nOffset - 1; idxCol >= 0; --idxCol)
                        {
                            int idxColDst = idxCol + nOffset;

                            for (int idxRow = 0; idxRow < bm.Height; ++idxRow)
                            {
                                Color crSrc = bm.GetPixel(idxCol, idxRow);
                                bm.SetPixel(idxColDst, idxRow, crSrc);
                            }
                        }
                        // 填充
                        FillRect(bm,
new Point(0, 0),
new Point(nOffset - 1, bm.Height - 1),
crFill);
                    }
                    break;

                case Direction.Down:
                    {
                        // 向下平移 
                        for (int idxRow = bm.Height - nOffset - 1; idxRow >= 0; --idxRow)
                        {
                            int idxRowDst = idxRow + nOffset;

                            for (int idxCol = 0; idxCol < bm.Width; ++idxCol)
                            {
                                Color crSrc = bm.GetPixel(idxCol, idxRow);
                                bm.SetPixel(idxCol, idxRowDst, crSrc);
                            }
                        }
                        // 填充
                        FillRect(bm,
new Point(0, 0),
new Point(bm.Width - 1, nOffset - 1),
crFill);
                    }
                    break;

                case Direction.Up:
                    {
                        // 向上平移 
                        for (int idxRow = nOffset; idxRow < bm.Height; ++idxRow)
                        {
                            int idxRowDst = idxRow - nOffset;

                            for (int idxCol = 0; idxCol < bm.Width; ++idxCol)
                            {
                                Color crSrc = bm.GetPixel(idxCol, idxRow);
                                bm.SetPixel(idxCol, idxRowDst, crSrc);
                            }
                        }
                        // 填充
                        FillRect(bm,
new Point(0, bm.Height - nOffset),
new Point(bm.Width - 1, bm.Height - 1),
crFill);
                    }
                    break;

            }
        }

        /// <summary>
                /// 填充矩形
                /// </summary>
                /// <param name="bm">要填充的图像</param>
                /// <param name="ptStart">填充开始位置</param>
                /// <param name="ptEnd">填充结束位置</param>
                /// <param name="ptEnd">填充的像素值</param>
        private void FillRect(Bitmap bm, Point ptStart, Point ptEnd, Color crFill)
        {
            for (int idxCol = ptStart.X; idxCol <= ptEnd.X; ++idxCol)
            {
                for (int idxRow = ptStart.Y; idxRow <= ptEnd.Y; ++idxRow)
                {
                    bm.SetPixel(idxCol, idxRow, crFill);
                }
            }
        }*/
        #endregion


        #region 没什么用,当做案例看吧 GetThumbnail
        public static Bitmap GetThumbnail(Bitmap b, int destHeight, int destWidth)
        {
            System.Drawing.Image imgSource = b;
            System.Drawing.Imaging.ImageFormat thisFormat = imgSource.RawFormat;
            int sW = 0, sH = 0;
            //按比例缩放
            int sWidth = imgSource.Width;
            int sHeight = imgSource.Height;
            if (sHeight > destHeight || sWidth > destWidth)
            {
                if ((sWidth * destHeight) > (sHeight * destWidth))
                {
                    sW = destWidth;
                    sH = (destWidth * sHeight) / sWidth;
                }
                else
                {
                    sH = destHeight;
                    sW = (sWidth * destHeight) / sHeight;
                }
            }
            else
            {
                sW = sWidth;
                sH = sHeight;
            }
            Bitmap outBmp = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage(outBmp);
            g.Clear(Color.Transparent);
            //设置画布的描绘质量
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgSource, new Rectangle((destWidth - sW) / 2, (destHeight - sH) / 2, sW, sH), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
            g.Dispose();
            //以下代码为保存图片时，设置压缩质量
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 100;
            EncoderParameter encoderParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;
            imgSource.Dispose();
            return outBmp;
        }
        #endregion



        #region 数据流转换

       
        /// <summary>
        /// base64编码 转为    图片
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public static Bitmap Base64StringToImage(string base64)
        {
            Bitmap b = null;
            try
            {
                //Bitmap bmp = new Bitmap();
                byte[] bytes = Convert.FromBase64String(base64.Replace("data:image/jpeg;base64,",""));
                MemoryStream memStream = new MemoryStream(bytes);
                b = new Bitmap(memStream);
                //b.Save("保存位子");
                //MessageBox.Show("转换成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Base64StringToImage 转换失败\nException：" + ex.Message);
            }
            return b;
        }

        /// <summary>
        /// 图片 转为    base64编码的文本
        /// </summary>
        /// <param name="Imagefilename"></param>
        /// <returns></returns>
        public static string ImgToBase64String(string imageurl)
        {
            string res="";
            try
            {
                Bitmap bmp = new Bitmap(imageurl);
                //this.pictureBox1.Image = bmp;
                
                //FileStream fs = new FileStream(imageurl, FileMode.Create);
                //StreamWriter sw = new StreamWriter(fs);

                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                String strbaser64 = Convert.ToBase64String(arr);
                //sw.Write(strbaser64);
                res = strbaser64;
                //sw.Close();
                //fs.Close();
                // MessageBox.Show("转换成功!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ImgToBase64String 转换失败\nException:" + ex.Message);
            }
            return res;
        }




        #endregion



    }
}


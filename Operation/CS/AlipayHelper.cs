using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThoughtWorks.QRCode.Codec;

namespace Operation.CS
{
    public class AlipayHelper
    {

        /// <summary>
        /// 根据URL生成二维码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static  Bitmap CodeConversionTool(string str)
        {
            //初始化二维码生成工具
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = 4;

            //将字符串生成二维码图片
            Bitmap image = qrCodeEncoder.Encode(str, Encoding.Default);

            //保存为PNG到内存流 
            //MemoryStream ms = new MemoryStream();
            //image.Save(ms, ImageFormat.Png);

            //输出二维码图片
            //Response.BinaryWrite(ms.GetBuffer());
            //Response.End();

            return image;
        }


        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="Content">内容文本</param>
        /// <param name="size">图片尺寸（像素）</param>
        /// <param name="margin">图片白边（像素）</param>
        /// <returns></returns>
        public static Bitmap CreateQRCode(string Content, int size, int margin = 5)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeScale = 5;
            qrCodeEncoder.QRCodeVersion = 0;

            try
            {
                System.Drawing.Image image = qrCodeEncoder.Encode(Content);
                int resWidth = size + 2 * margin;
                int resHeight = size + 2 * margin;
                // 核心就是这里新建一个bitmap对象然后将image在这里渲染
                Bitmap newBit = new Bitmap(resWidth, resHeight, PixelFormat.Format32bppRgb);
                Graphics gg = Graphics.FromImage(newBit);

                // 设置背景白色
                for (int y = 0; y < resWidth; y++)
                {
                    for (int x = 0; x < resHeight; x++)
                    {
                        newBit.SetPixel(x, y, Color.White);
                    }
                }

                // 设置黑色边框
                for (int i = 0; i < resWidth; i++)
                {
                    newBit.SetPixel(i, 0, Color.Black);
                    newBit.SetPixel(i, resWidth - 1, Color.Black);

                }

                for (int j = 0; j < resHeight; j++)
                {
                    newBit.SetPixel(0, j, Color.Black);
                    newBit.SetPixel(resHeight - 1, j, Color.Black);

                }
                gg.DrawImage(image, margin, margin, size, size);
                //newBit.Save(size.ToString() + ".png");
                return newBit;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}

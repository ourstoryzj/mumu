using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class OA_Code : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // 在此处放置用户代码以初始化页面
        this.CreateCheckCodeImage(GenerateCheckCodes(4));
    }

    #region Web 窗体设计器生成的代码
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// 设计器支持所需的方法 - 不要使用代码编辑器修改
    /// 此方法的内容。
    /// </summary>
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
    }
    #endregion

    #region GenerateCheckCodes
    private string GenerateCheckCodes(int iCount)
    {
        int number;
        string checkCode = String.Empty;
        int iSeed = DateTime.Now.Millisecond;
        System.Random random = new Random(iSeed);
        for (int i = 0; i < iCount; i++)
        {
            number = random.Next(10);
            checkCode += number.ToString();
        }

        Session["CheckCode"] = checkCode;
        return checkCode;
    }
    #endregion

    #region CreateCheckCodeImage
    private void CreateCheckCodeImage(string checkCode)
    {
        if (checkCode == null || checkCode.Trim() == String.Empty)
            return;
        int iWordWidth = 15;
        int iImageWidth = checkCode.Length * iWordWidth;
        Bitmap image = new Bitmap(iImageWidth, 20);
        Graphics g = Graphics.FromImage(image);
        try
        {
            //生成随机生成器 
            Random random = new Random();
            //清空图片背景色 
            g.Clear(Color.White);

            //画图片的背景噪音点
            for (int i = 0; i < 20; i++)
            {
                int x1 = random.Next(image.Width);
                int x2 = random.Next(image.Width);
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
            }

            //画图片的背景噪音线 
            for (int i = 0; i < 2; i++)
            {
                int x1 = 0;
                int x2 = image.Width;
                int y1 = random.Next(image.Height);
                int y2 = random.Next(image.Height);
                if (i == 0)
                {
                    g.DrawLine(new Pen(Color.Gray, 2), x1, y1, x2, y2);
                }

            }


            for (int i = 0; i < checkCode.Length; i++)
            {

                string Code = checkCode[i].ToString();
                int xLeft = iWordWidth * (i);
                random = new Random(xLeft);
                int iSeed = DateTime.Now.Millisecond;
                int iValue = random.Next(iSeed) % 4;
                if (iValue == 0)
                {
                    Font font = new Font("Arial", 13, (FontStyle.Bold | System.Drawing.FontStyle.Italic));
                    Rectangle rc = new Rectangle(xLeft, 0, iWordWidth, image.Height);
                    LinearGradientBrush brush = new LinearGradientBrush(rc, Color.Blue, Color.Red, 1.5f, true);
                    g.DrawString(Code, font, brush, xLeft, 2);
                }
                else if (iValue == 1)
                {
                    Font font = new System.Drawing.Font("楷体", 13, (FontStyle.Bold));
                    Rectangle rc = new Rectangle(xLeft, 0, iWordWidth, image.Height);
                    LinearGradientBrush brush = new LinearGradientBrush(rc, Color.Blue, Color.DarkRed, 1.3f, true);
                    g.DrawString(Code, font, brush, xLeft, 2);
                }
                else if (iValue == 2)
                {
                    Font font = new System.Drawing.Font("宋体", 13, (System.Drawing.FontStyle.Bold));
                    Rectangle rc = new Rectangle(xLeft, 0, iWordWidth, image.Height);
                    LinearGradientBrush brush = new LinearGradientBrush(rc, Color.Green, Color.Blue, 1.2f, true);
                    g.DrawString(Code, font, brush, xLeft, 2);
                }
                else if (iValue == 3)
                {
                    Font font = new System.Drawing.Font("黑体", 13, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Bold));
                    Rectangle rc = new Rectangle(xLeft, 0, iWordWidth, image.Height);
                    LinearGradientBrush brush = new LinearGradientBrush(rc, Color.Blue, Color.Green, 1.8f, true);
                    g.DrawString(Code, font, brush, xLeft, 2);
                }
            }
            //////画图片的前景噪音点 
            //for (int i = 0; i < 8; i++)
            //{
            //    int x = random.Next(image.Width);
            //    int y = random.Next(image.Height);
            //    image.SetPixel(x, y, Color.FromArgb(random.Next()));
            //}
            //画图片的边框线 
            g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            Response.ClearContent();

            Response.BinaryWrite(ms.ToArray());
        }
        finally
        {
            g.Dispose();
            image.Dispose();
        }
    }
    #endregion
}
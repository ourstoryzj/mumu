using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;

public partial class OS_ImageCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.GenImg(this.GetCode(4));
        }
    }
    //产生随机字符串
    private string GetCode(int num)
    {
        string[] source ={ "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        string code = "";
        Random rd = new Random();
        for (int i = 0; i < num; i++)
        {
            code += source[rd.Next(0, source.Length)];
        }
        return code;
    }

    //生成图片
    private void GenImg(string code)
    {
        Random rd = new Random();
        Bitmap myPalette = new Bitmap(120, 60);                                                 //定义一个画板
        Graphics gh = Graphics.FromImage(myPalette);//在画板上定义绘图的实例
        Rectangle rc = new Rectangle(0, 0, 120, 60);//定义一个矩形
        //String picPath = Server.MapPath("pic/bg" + rd.Next(1, 4).ToString().Trim() + ".jpg");
        String picPath = Server.MapPath("Images/bg_code.jpg");
        Bitmap imagefile = (Bitmap)System.Drawing.Image.FromFile(picPath, true);                //得到一张位图        
        TextureBrush texture = new TextureBrush(imagefile);                                     //以图片建立绘图刷
        Color[] fontcolor = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Red, Color.Brown, Color.DarkCyan, Color.Purple };//定义8种颜色
        String[] fontname = { "Verdana", "System", "Comic Sans MS", "Arial", "宋体" };          //定义 5 种字体
        Font myfont;//字体定义
        SolidBrush mybrush;//画笔定义


        gh.FillRectangle(texture, rc);//使用绘图刷填充矩形，到此得到图片背景
        for (short i = 0; i <= code.Length - 1; i++)
        {
            myfont = new Font(fontname[rd.Next(0, 5)], 30, FontStyle.Italic);//随机字体,42号，斜体
            mybrush = new SolidBrush(fontcolor[rd.Next(0, 8)]);//随机颜色
            gh.DrawString(code.Substring(i, 1), myfont, mybrush, 3 + (i * 23), rd.Next(1, 8));//在矩形内画出字符串
        }
        myPalette.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);//将图片显示出来
        Session["ValidateCode"] = code;//将字符串保存到Session中，以便需要时进行验证
        gh.Dispose();
        myPalette.Dispose();
    }

}

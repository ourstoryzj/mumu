using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Operation.Test
{
    public partial class test_gaodingcs : Form
    {

        CefsharpHelpers.CefsharpHelper cefsharp = null;


        public test_gaodingcs()
        {
            InitializeComponent();
            bind();

        }


        void bind()
        {
            if (cefsharp == null)
            {
                cefsharp = new CefsharpHelpers.CefsharpHelper("https://www.gaoding.com/koutu");
                cefsharp.Init();
                var browser = cefsharp.CreateBrowser();
                this.Controls.Add(browser);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //var img = textBox1.Text;
            //var bytes = Encoding.UTF8.GetBytes(img);
            ////实例化一个内存流--->把从文件流中读取的内容[字节数组]放到内存流中去
            //MemoryStream ms = new MemoryStream(bytes);
            ////设置图片框 pictureBox1中的图片
            //panel1.BackgroundImage = Image.FromStream(ms);
        }





    }
}

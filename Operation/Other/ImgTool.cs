using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using Operation.Other;
using Operation.CS;
using System.IO;
using System.Diagnostics;
using Common;

namespace Operation
{
    public partial class ImgTool : Form
    {
 

        public ImgTool()
        {
          
            InitializeComponent();
 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = BaiduHelper.ImageToWordByClipboard();
            textBox1.Text = str;
        }
    }


}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.Test
{
    public partial class test_iframe : Form
    {
        public test_iframe()
        {
            InitializeComponent();
            string url = Application.StartupPath + "\\test.htm";
            webBrowser1.Navigate(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string js = textBox1.Text.Trim();
            Browser.JS_WebBrowser_NoReturn(js, webBrowser1);
        }
    }
}

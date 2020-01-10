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
    public partial class test_erweima : Form
    {
        public test_erweima()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url  = textBox1.Text;
            if (string.IsNullOrEmpty(url))
            {
                "请输入二维码".ToShow(); 
                return;
            }
            Bitmap bm = CS.AlipayHelper.CodeConversionTool(url);
            panel1.BackgroundImage = bm;
        }
    }
}

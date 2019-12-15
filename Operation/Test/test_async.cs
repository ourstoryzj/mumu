using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel_operation.Test
{
    public partial class test_async : Form
    {
        public test_async()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Task.Run((Action)test1);
            test2();
        }


        void test1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Thread.Sleep(1000);
            txt_message.Text = "第1步";
        }

        void test2()
        {
            txt_message.Text = "第2步";
        }
    }
}

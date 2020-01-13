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
    public partial class test_json : Form
    {
        public test_json()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                    return;
                string str = textBox1.Text;
                //str = "[{"goods":"test"},{"goods":"test1"},{"goods":"test2"}]";
                var sss = Newtonsoft.Json.JsonConvert.DeserializeObject<List<testtest>>(str);
                textBox2.Text = "json中的数量为" + sss.Count.ToString() + "   " + sss.ToString();
            }
            catch (Exception ex)
            {
                ex.ToString().ToShow();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<testtest> list = new List<testtest>();
            for (int i = 0; i < 3; i++)
            {
                testtest tt = new testtest();
                tt.goods = (i+1).ToString();
                list.Add(tt);
            }
            string jn = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            textBox2.Text = jn;
        }
    }

    public class testtest
    {
        public string goods { get; set; }
    }

}

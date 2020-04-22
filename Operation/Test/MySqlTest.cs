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
    public partial class MySqlTest : Form
    {
        public MySqlTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Entity.Admins ad = new Entity.Admins();
            //ad.aaccount = "test";
            //ad.alogintime = DateTime.Now;
            //ad.apassword = "test";
            //ad.astate = "1";
            //ad.atype = "1";

            //DAL.MySql.AdminsService dal = new DAL.MySql.AdminsService();
            //dal.Insert(ad);
            //"添加成功".ToShow();

            //Entity.keys_lexicon k = new Entity.keys_lexicon();
            //k.kldate = DateTime.Now;
            //k.klname = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //k.klremark = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //k.klremark1 = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //k.klremark2 = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //k.klsort = 1;
            //k.klstate = "1";
            //DAL.MySql.keys_lexiconService kl = new DAL.MySql.keys_lexiconService();
            
            //    kl.Insert(k);
            
            //"添加成功".ToShow();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Entity.keys_lexicon k = new Entity.keys_lexicon();
            //k.kldate = DateTime.Now;
            //k.klname = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //k.klremark =  "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //k.klremark1 = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //k.klremark2 = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //k.klsort = 1;
            //k.klstate = "1";
            //DAL.MySql.keys_lexiconService kl = new DAL.MySql.keys_lexiconService();
            //DateTime dt1 = DateTime.Now;
            //for (int i = 0; i < 1000; i++)
            //{
            //    kl.Insert(k);
            //}
            //DateTime dt2 = DateTime.Now;
            
            //("添加成功,用时"+(dt2-dt1).ToString()).ToShow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //List<Entity.keys_lexicon> list = new List<Entity.keys_lexicon>();
            //for (int i = 0; i < 1000; i++)
            //{
            //    Entity.keys_lexicon k = new Entity.keys_lexicon();
            //    k.kldate = DateTime.Now;
            //    k.klname = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //    k.klremark = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //    k.klremark1 = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //    k.klremark2 = "测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试测试数据测试";
            //    k.klsort = 1;
            //    k.klstate = "1";
            //    list.Add(k);
            //}
           
            //DAL.MySql.keys_lexiconService kl = new DAL.MySql.keys_lexiconService();
            //DateTime dt1 = DateTime.Now;
           
            //kl.Insert2(list);
           
            //DateTime dt2 = DateTime.Now;

            //("添加成功,用时" + (dt2 - dt1).ToString()).ToShow();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //DAL.MySql.fanxianService fx = new DAL.MySql.fanxianService();
            //dataGridView1.DataSource = fx.Search(5, 20, "", "", 0, new DateTime(), new DateTime(), new DateTime(), new DateTime(), "");
           
        }
    }
}

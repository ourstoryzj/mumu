using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entity;

namespace words
{
    public partial class huashu_add : Form
    {
        Entity.huashu hs = null;

        //public static huashu_add hsa = null;


        public huashu_add()
        {
            InitializeComponent();
            bind_cb();
            //hsa = this;
        }

        private int hid;

        public int Hid
        {
            get { return hid; }
            set { hid = value; }
        }

        public void bind_cb()
        {
            cb_type.Items.Clear();
            cb_type.DataSource = BLL.huashuManager.SearchAll("1");
            cb_type.DisplayMember = "htitle";
            cb_type.ValueMember = "hid";
        }
        public void bind()
        {
            if (hid != 0)
            {
                hs = BLL.huashuManager.SearchByID(hid);
                if (hs != null)
                {
                    //cb_type.SelectedIndex = 2;
                    for (int i = 0; i < cb_type.Items.Count; i++)
                    {
                        if ((cb_type.Items[i] as huashu).hid == hs.hfid)
                        {
                            cb_type.SelectedIndex = i;
                        }
                    }
                    txt_context.Text = hs.hcontext;
                    txt_title.Text = hs.htitle;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string _type = cb_type.SelectedValue.ToString();
            string title = txt_title.Text.Trim();
            string str_context = txt_context.Text.Trim();
            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("请输入话术标题");
                txt_title.SelectAll();
                return;
            }
            if (string.IsNullOrEmpty(str_context))
            {
                MessageBox.Show("请输入话术内容");
                txt_context.SelectAll();
                return;
            }

            if (hid == 0)
            {
                hs = new Entity.huashu();
                hs.hcount = 0;
                hs.hdate = DateTime.Now;
                hs.hid = 0;
                hs.hsort = 100;
                hs.hstate = "1";
            }
            hs.hcontext = str_context;
            hs.hfid = Convert.ToInt32(_type);
            hs.htitle = title;
            if (hid == 0)
            {
                BLL.huashuManager.Insert(hs);
            }
            else
            {
                BLL.huashuManager.Update(hs);
            }

            hid = 0;
            this.Close();
            Form1.fm.tongbu();
            Form1.fm.bind();
            //this.Visible=false;
            
        }
    }
}

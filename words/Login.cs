using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace words
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//位置居中
            //设置皮肤
            try
            {
                string skinname = ConfigurationManager.AppSettings["Style"].ToString();
                if (!string.IsNullOrEmpty(skinname))
                    this.skinEngine1.SkinFile = System.Environment.CurrentDirectory + skinname;
            }
            catch { }
            txt_account.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string account = txt_account.Text.Trim();
            string pwd = txt_pwd.Text.Trim();
            string res = BLL.AdminsManager.Login(account, pwd);
            string[] list = res.Split(new char[] { ':' });
            string res1 = list[0];
            if (res1 == "0")
            {
                MessageBox.Show(list[1]);
            }
            else
            {
                Form1.user = list[1];
                this.Hide();
                Form1 f = new Form1();
                f.Show();
            }
        }
    }
}

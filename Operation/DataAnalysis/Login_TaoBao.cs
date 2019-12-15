using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace excel_operation
{
    public partial class Login_TaoBao : Form
    {

        //public string programID = "";
        //public WebBrowser webBrowser=null;
        public bool isok = false;

        public Login_TaoBao()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            //禁止弹框
            webBrowser1.ScriptErrorsSuppressed = true;
            //Manager.WebBrowser_ClearData();
            //int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            //int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            //this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            //Manager.AnimateWindow(this.Handle, 1000, Manager.AW_SLIDE | Manager.AW_ACTIVE | Manager.AW_VER_NEGATIVE);
        }


        private void btn_logined_Click(object sender, EventArgs e)
        {
            isok = true;
            //webBrowser = webBrowser1;
            //this.Hide();
            //if (string.IsNullOrEmpty(programID))
            //{
                
            //}
        }



    }
}

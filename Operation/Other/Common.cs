using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel_operation.Other
{
    public partial class Common : Form
    {
        public CefSharp.WinForms.ChromiumWebBrowser webBrowser1;

        public Common()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(1600,800);
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //this.MdiParent = MainForm.ActiveForm;
            try
            {
                webBrowser1 = new ChromiumWebBrowser("http://qxw1635740081.my3w.com/oa/Default.aspx");
                webBrowser1.Dock = DockStyle.Fill;
                this.Controls.Add(webBrowser1);
              
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }

        }

    }
}

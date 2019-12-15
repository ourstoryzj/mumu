using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel_operation.Test
{
    public partial class test_guge : Form
    {

        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;
        public test_guge()
        {
            InitializeComponent();

            webBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser("http://www.baidu.com");
            webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
            webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;
            webBrowser1.Size = new Size(980, 660);
            webBrowser1.Location = new Point(6, 70);
            webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //this.Controls.Add(webBrowser1);
           this.Controls.Add(webBrowser1);
           
        }
    }
}

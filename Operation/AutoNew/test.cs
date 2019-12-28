using CefSharp.WinForms;
using Operation.CS;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Operation.AutoNew
{
    public partial class test : Form
    {

        CefSharp.WinForms.ChromiumWebBrowser webBrowser1;

        public test()
        {
            InitializeComponent();

            try
            {
                webBrowser1 = new ChromiumWebBrowser("http://www.xiaodian.com/goods/publish/add?cid=118u");
                webBrowser1.FrameLoadStart += Browser.BrowserFrameLoadStart;
                webBrowser1.FrameLoadEnd += Browser.BrowserFrameLoadEnd;

                webBrowser1.Size = new Size(1301, 253);
                webBrowser1.Location = new Point(12, 527);
                webBrowser1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                this.Controls.Add(webBrowser1);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
    }
}

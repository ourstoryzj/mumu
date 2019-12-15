using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpdateClient
{
    public partial class FTPTest : Form
    {
        public FTPTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FTPIP = new CS.XMLHelpers().GetValue("FTPIP");
            string FTPAccount = new CS.XMLHelpers().GetValue("FTPAccount");
            string FTPPWD = new CS.XMLHelpers().GetValue("FTPPWD");

            string  filePath = CS.Manager.OpenFileDialog2("");
            FileInfo fi = new FileInfo(filePath);
            
            CS.FTPHelper.UploadFile(fi, "UpdateDirectory",true);
            MessageBox.Show("操作成功");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string FTPIP = new CS.XMLHelpers().GetValue("FTPIP");
            string FTPAccount = new CS.XMLHelpers().GetValue("FTPAccount");
            string FTPPWD = new CS.XMLHelpers().GetValue("FTPPWD");

            //CS.FTPHelper.DownloadFile(@"c:\", "update", "AutoUpdater.xml", FTPIP, FTPAccount, FTPPWD);
            MessageBox.Show("操作成功");
        }
    }
}

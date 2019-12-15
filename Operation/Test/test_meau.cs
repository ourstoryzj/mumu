using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace excel_operation.Test
{
    public partial class test_meau : Form
    {
        public test_meau()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path1 = Application.StartupPath + "\\1.zip";
            string path2 = Application.StartupPath+"\\1" ;
            //Common.RarHelper.ExeRAR(path1, "AutoUpdater.zip");
            //Common.RarHelper.ExeRAR2(path1, path2);
            //Common.RarHelper.CondenseRarOrZip(path1, path1 + ".rar", true, "");
            MessageBox.Show("成功");
            //if (NetHelper.IsInternetAvailable())
            //    if (Common.WiFiHelper.HasNetWork())

            //    "有网络".ToShow();

            //else
            //    "无网络".ToShow();
        }
    }
}

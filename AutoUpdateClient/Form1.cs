using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AutoUpdateClient
{
    public partial class Form1 : Form
    {
        //服务器网址
        string AddressService = "http://www.baidu.com/update/";
        //文件名称
        string FileName = "AutoUpdater.xml";
        //客户端的绝对地址
        string AddressClient = Application.StartupPath;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;


            string UpdateDateService = GetTheLastUpdateTime(AddressService + FileName);
            string UpdateDateClient = GetTheLastUpdateTime(AddressClient + FileName);
            if (UpdateDateClient != "" && UpdateDateService != "")
            {
                //如果客户端将升级的应用程序的更新日期大于服务器端升级的应用程序的更新日期
                if (Convert.ToDateTime(UpdateDateClient) >= Convert.ToDateTime(UpdateDateService))
                {
                    MessageBox.Show("当前软件已经是最新的，无需更新！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            //this.labDownFile.Text = "下载更新文件";
            //this.labFileName.Refresh();
            //this.btnCancel.Enabled = true;
            //this.progressBar1.Position = 0;
            //this.progressBarTotal.Position = 0;
            //this.progressBarTotal.Refresh();
            //this.progressBar.Refresh();

            //通过动态数组获取下载文件的列表
            //ArrayList List = GetDownFileList(GetTheUpdateURL(), theFolder.FullName);
            //string[] urls = newstring[List.Count];
            //List.CopyTo(urls, 0);

        }



        #region 获取最后更新时间+GetTheLastUpdateTime


        string GetTheLastUpdateTime(string Dir)
        {
            string LastUpdateTime = "";

            string AutoUpdaterFileName = Dir + FileName;
            if (!File.Exists(AutoUpdaterFileName))
            {
                return LastUpdateTime;
            }
            //打开xml文件
            FileStream fs = new FileStream(AutoUpdaterFileName, FileMode.Open);
            //xml文件阅读器
            XmlTextReader xml = new XmlTextReader(fs);
            while (xml.Read())
            {
                if (xml.Name == "UpdateTime")
                {
                    //获取升级文档的最后一次更新日期
                    LastUpdateTime = xml.GetAttribute("Date");
                    break;
                }
            }
            xml.Close();
            fs.Close();
            return LastUpdateTime;
        }
        #endregion



        private void BatchDownload(object data)
        {
            //this.Invoke(this.activeStateChanger, new object[]{ true, false});
            //try
            //{
            //    DownloadInstructions instructions = (DownloadInstructions)data;
            //    //批量下载
            //    using (BatchDownloader bDL = newBatchDownloader())
            //    {
            //        bDL.CurrentProgressChanged += newDownloadProgressHandler(this.SingleProgressChanged);
            //        bDL.StateChanged += newDownloadProgressHandler(this.StateChanged);
            //        bDL.FileChanged += newDownloadProgressHandler(bDL_FileChanged);
            //        bDL.TotalProgressChanged += newDownloadProgressHandler(bDL_TotalProgressChanged);
            //        bDL.Download(instructions.URLs, instructions.Destination, (ManualResetEvent)this.cancelEvent);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ShowErrorMessage(ex);
            //}
            //this.Invoke(this.activeStateChanger, newobject[]{ false, false});
            //this.labFileName.Text = "";
            ////更新程序
            //if (this._Update)
            //{
            //    //关闭原有的应用程序
            //    this.labDownFile.Text = "正在关闭程序....";
            //    System.Diagnostics.Process[] proc = System.Diagnostics.Process.GetProcessesByName("TIMS");
            //    //关闭原有应用程序的所有进程
            //    foreach (System.Diagnostics.Process proinproc)
            //    {
            //        pro.Kill();
            //    }
            //    DirectoryInfo theFolder = newDirectoryInfo(Path.GetTempPath() +＂JurassicUpdate");
            //if (theFolder.Exists)
            //    {
            //        foreach (FileInfo theFileintheFolder.GetFiles())
            //        {
            //            //如果临时文件夹下存在与应用程序所在目录下的文件同名的文件，则删除应用程序目录下的文件
            //            if (File.Exists(Application.StartupPath + \\"+Path.GetFileName(theFile.FullName)))
            //            File.Delete(Application.StartupPath + "\\" + Path.GetFileName(theFile.FullName));
            //            //将临时文件夹的文件移到应用程序所在的目录下
            //            File.Move(theFile.FullName, Application.StartupPath + \\"+Path.GetFileName(theFile.FullName));
            //        }
            //    }
            //    //启动安装程序
            //    this.labDownFile.Text = "正在启动程序....";
            //    System.Diagnostics.Process.Start(Application.StartupPath + "\\" + "TIMS.exe");
            //    this.Close();
            //}
        }


    }
}

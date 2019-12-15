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
using AutoUpdateClient.CS;
using System.Diagnostics;

namespace AutoUpdateClient
{
    public partial class AutoUpdate : Form
    {

        static CS.XMLHelpers xml = new CS.XMLHelpers();

        /// <summary>
        /// 启动路径
        /// </summary>
        static string startupPath = Application.StartupPath;
        /// <summary>
        /// 临时文件夹名
        /// </summary>
        static string directoryTemp = startupPath + "\\" + FTPUpdateDirectory;
        /// <summary>
        /// FTP中存放文件的位置
        /// </summary>
        static string FTPUpdateDirectory = xml.GetValue("FTPUpdateDirectory");
        /// <summary>
        /// 源码文件夹
        /// </summary>
        static string UpdateCode = xml.GetValue("UpdateCode");
        /// <summary>
        /// 程序文件夹
        /// </summary>
        static string UpdateApp = xml.GetValue("UpdateApp");
        /// <summary>
        /// 源码更新日期
        /// </summary>
        static string UpdateDateCode = xml.GetValue("UpdateDateCode");
        /// <summary>
        /// xml文件名称
        /// </summary>
        static string FTPXmlFileName = "AutoUpdater.xml";



        public AutoUpdate()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }


        #region 上传源码 btn_upload_code_Click
        private void btn_upload_code_Click(object sender, EventArgs e)
        {


            //FTPHelper.CheckDirectoryAndMakeMyWilson3(FTPUpdateDirectory + "/"+ UpdateCode +"/" +("excel operation\\Common".Replace("\\","/")));
            //return;

            //判断是否需要更新
            //获取更新xml文件，判断是否需要上传，如果没有xml直接上传，如果有判断日期
            if (MessageBox.Show("确定要上传源码吗?", "源码上传", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                lbl_message.Text = "已停源码上传";
                return;
            }

            #region bak_2019年9月5日 17:10:58


            //获取所有要上传的文件夹
            //List<string> folder_list = xml.GetValueByNodes("Folder_Code");
            ////FTP上创建所有文件夹,太费时间,先注销
            ////GreateDirectoryFTP(folder_list);
            ////先上传文件夹里的文件
            //UploadFileByDirectory(folder_list);
            ////然后获取单独的文件
            //List<string> folder_list2 = xml.GetValueByNodes("File_Code");
            ////FTP上创建所有文件夹,太费时间,先注销
            //GreateDirectoryFTP(folder_list2);
            ////然后上传单独的文件
            //UploadFileByFile(folder_list2);
            #endregion

            UploadFile(xml.GetValueByNodes("Folder_Code"), xml.GetValueByNodes("File_Code"), 1);
            UpdateDateXml(1);

            MessageBox.Show("操作成功");
        }
        #endregion


        #region btn_download_code_Click


        private void btn_download_code_Click(object sender, EventArgs e)
        {

            DownloadFile(1);

            MessageBox.Show("操作成功");
        }





        #endregion


        #region btn_test_Click


        private void btn_test_Click(object sender, EventArgs e)
        {
            //string str = "UpdateDirectory/UpdateCode/excel operation/app.config";
            //string dir = str.Substring(0, str.LastIndexOf("/"));
            //string filename = str.Substring(str.LastIndexOf("/") + 1);
            //string filepath = Application.StartupPath + "\\AutoUpdater.xml";
            //string savepath = Application.StartupPath + "\\AutoUpdater.rar";
            //Rar.CondenseRarOrZip(filepath, savepath, true, "");
            //UploadFileBySourceCode();

            //FTPHelper.Download("c:\\", "UpdateDirectory/UpdateCode/excel operation", "app.config");


            //MessageBox.Show("操作成功 dir="+dir+" filename="+filename);
            MessageBox.Show("操作成功 ");
        }
        #endregion


        #region btn_fileupload_app_Click


        private void btn_fileupload_app_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要上传程序吗?", "程序上传", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                lbl_message.Text = "已暂停程序上传";
                return;
            }

            UploadFile(xml.GetValueByNodes("Folder_App"), xml.GetValueByNodes("File_App"), 2);
            UpdateDateXml(2);

            MessageBox.Show("操作成功");
        }
        #endregion


        #region btn_update_app_Click


        private void btn_update_app_Click(object sender, EventArgs e)
        {
            DownloadFile(2);

            MessageBox.Show("操作成功");
        }

        #endregion


        #region btn_createFTPFolder_Click
        private void btn_createFTPFolder_Click(object sender, EventArgs e)
        {
            xml.SetValue("CreateDirectory", "true");
            GreateDirectoryFTP(xml.GetValueByNodes("Folder_Code"));
            //FTP上创建所有文件夹,太费时间,先注销
            GreateDirectoryFTP(xml.GetValueByNodes("File_Code"));
            xml.SetValue("CreateDirectory", "false");
        }
        #endregion




        #region 私有方法

        #region UploadFile


        /// <summary>
        /// 上传源码
        /// </summary>
        /// <param name="folder_list">需要上传的文件夹,例如:xml.GetValueByNodes("Folder_Code")</param>
        /// <param name="file_list">需要上传的单独文件,例如:xml.GetValueByNodes("File_Code")</param>
        /// <param name="_type">上传文件的类型,1:源码,2:程序</param>
        void UploadFile(List<string> folder_list, List<string> file_list, int _type)
        {
            try
            {
                DeleteUpdateDirectory();

                //创建临时更新文件夹
                string temppath = startupPath + "\\" + FTPUpdateDirectory;
                Manager.CreateDirectory(temppath);
                //复制所有文件夹到这个目录
                //List<string> folder_list = xml.GetValueByNodes("Folder_Code");
                //复制所有文件夹
                foreach (string folderpath in folder_list)
                {
                    if (!string.IsNullOrEmpty(folderpath))
                        FileHelper.DirectoryCopy(startupPath + "\\" + folderpath, temppath + "\\" + folderpath, true, false);
                }
                //获取所有单独的文件
                //List<string> file_list = xml.GetValueByNodes("File_Code");
                //复制所有文件
                foreach (string filepath in file_list)
                {
                    if (File.Exists(startupPath + "\\" + filepath))
                    {
                        FileInfo fi = new FileInfo(startupPath + "\\" + filepath);
                        //fi.CopyTo(temppath + "\\" + fi.Name, true);
                        //复制单独的文件到单独的文件夹
                        string filePath = startupPath + "\\" + filepath;
                        //设置一个单独的文件夹
                        string copyTo = temppath + "\\" + (_type == 1 ? UpdateCode : UpdateApp) + "\\" + fi.Name;
                        FileHelper.FileCopy(filePath, copyTo, true);

                    }
                }
                //压缩文件夹
                //string rarpath = startupPath + "\\" + FTPUpdateDirectory + ".rar";
                //if (!Rar.CondenseRarOrZip(temppath, rarpath, true, ""))
                //{
                //    MessageBox.Show("压缩文件有异常");
                //    return;
                //}

                string rarpath = startupPath + "\\" + FTPUpdateDirectory + ".zip";
                Rar.ZipCompress(temppath);

                //上传压缩文件
                //如果没有则退出
                if (!File.Exists(rarpath))
                {
                    MessageBox.Show("没有zip文件");
                    return;
                }
                FileInfo fi_rar = new FileInfo(rarpath);

                //测试先取消上传
                //return;

                CS.FTPHelper.UploadFile(fi_rar, FTPUpdateDirectory + "/" + (_type == 1 ? UpdateCode : UpdateApp) + "/", true);
                //删除临时文件夹
                //fi_rar.Delete();
                //DeleteFiles();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        #endregion

        #region UploadFileByRAR


        /// <summary>
        /// 上传源码
        /// </summary>
        /// <param name="folder_list">需要上传的文件夹,例如:xml.GetValueByNodes("Folder_Code")</param>
        /// <param name="file_list">需要上传的单独文件,例如:xml.GetValueByNodes("File_Code")</param>
        /// <param name="_type">上传文件的类型,1:源码,2:程序</param>
        void UploadFileByRAR(List<string> folder_list, List<string> file_list, int _type)
        {
            try
            {
                DeleteUpdateDirectory();

                //创建临时更新文件夹
                string temppath = startupPath + "\\" + FTPUpdateDirectory;
                Manager.CreateDirectory(temppath);
                //复制所有文件夹到这个目录
                //List<string> folder_list = xml.GetValueByNodes("Folder_Code");
                //复制所有文件夹
                foreach (string folderpath in folder_list)
                {
                    if (!string.IsNullOrEmpty(folderpath))
                        FileHelper.DirectoryCopy(startupPath + "\\" + folderpath, temppath + "\\" + folderpath, true, false);
                }
                //获取所有单独的文件
                //List<string> file_list = xml.GetValueByNodes("File_Code");
                //复制所有文件
                foreach (string filepath in file_list)
                {
                    if (File.Exists(startupPath + "\\" + filepath))
                    {
                        FileInfo fi = new FileInfo(startupPath + "\\" + filepath);
                        //fi.CopyTo(temppath + "\\" + fi.Name, true);
                        //复制单独的文件到单独的文件夹
                        string filePath = startupPath + "\\" + filepath;
                        //设置一个单独的文件夹
                        string copyTo = temppath + "\\" + (_type == 1 ? UpdateCode : UpdateApp) + "\\" + fi.Name;
                        FileHelper.FileCopy(filePath, copyTo, true);

                    }
                }
                //压缩文件夹
                string rarpath = startupPath + "\\" + FTPUpdateDirectory + ".rar";
                if (!Rar.CondenseRarOrZip(temppath, rarpath, true, ""))
                {
                    MessageBox.Show("压缩文件有异常");
                    return;
                }

                //上传压缩文件
                //如果没有则退出
                if (!File.Exists(rarpath))
                {
                    MessageBox.Show("没有rar文件");
                    return;
                }
                FileInfo fi_rar = new FileInfo(rarpath);

                //测试先取消上传
                //return;

                CS.FTPHelper.UploadFile(fi_rar, FTPUpdateDirectory + "/" + (_type == 1 ? UpdateCode : UpdateApp) + "/", true);
                //删除临时文件夹
                //fi_rar.Delete();
                //DeleteFiles();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        #endregion



        #region VerificationEdition


        /// <summary>
        /// 是否需要更新,有错误
        /// </summary>
        /// <returns></returns>
        bool VerificationEdition(int _type)
        {
            //是否更新
            bool isUpdate = false;
            //创建临时文件夹
            CreateUpdateDirectory();

            string temp_filename = _type == 1 ? UpdateCode : UpdateApp;

            bool hasdir = CS.FTPHelper.DirectoryExist(FTPUpdateDirectory, temp_filename);
            if (!hasdir)
            {
                CS.FTPHelper.CreateDirectory(FTPUpdateDirectory + "/" + temp_filename);
            }
            else
            {
                //查看配置文件是否存在
                if (FTPHelper.FileExist(FTPUpdateDirectory, FTPXmlFileName))
                {
                    //CS.FTPHelper.DownloadFile(@"c:\", "update", "AutoUpdater.xml", FTPIP, FTPAccount, FTPPWD);
                    //下载配置文件
                    CS.FTPHelper.DownloadFile(directoryTemp, FTPUpdateDirectory, "AutoUpdater.xml");
                    //查看是否下载了配置文件
                    if (CS.Manager.fileFind(directoryTemp + "\\AutoUpdater.xml"))
                    {
                        //获取配置文件的更新日期
                        string updateDate = new XMLHelpers(directoryTemp + "\\AutoUpdater.xml").GetValue("UpdateDateCode");
                        //FTP配置文件对比本地配置文件,如果FTP上的时间比较大,是最新的则更新
                        if (updateDate.ToDateTime() >= xml.GetValue("UpdateDateCode").ToDateTime())
                        {
                            //替换最新的配置文件
                            FileHelper.FileCopy(directoryTemp + "\\AutoUpdater.xml", startupPath, true);
                            isUpdate = true;
                        }
                    }
                }
                else
                {
                    //如果服务器上没有配置文件则不要更新系统
                    return false;
                }
            }
            return isUpdate;
        }
        #endregion

        #region UpdateDateXml
        /// <summary>
        /// 把根目录中的xml配置文件提交到FTP中,并修改时间
        /// </summary>
        /// <param name="_type">1:修改源码更新时间,2:修改程序更新时间</param>
        void UpdateDateXml(int _type)
        {
            //修改xml文件更新日期并上传替换
            xml.SetValue(_type == 1 ? "UpdateDateCode" : "UpdateDateApp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            FileInfo fi2 = new FileInfo(startupPath + "\\" + FTPXmlFileName);
            FTPHelper.UploadFile(fi2, FTPUpdateDirectory, true);
        }
        #endregion

        #region GreateDirectoryFTP

        /// <summary>
        /// 根据列表创建文件夹
        /// </summary>
        /// <param name="folder_list"></param>
        void GreateDirectoryFTP(List<string> folder_list)
        {
            if (xml.GetValue("CreateDirectory") == "true")
            {
                lbl_message.Text = "正在部署文件环境,请稍等";
                lbl_message.Refresh();
                folder_list.ForEach(item =>
                   FTPHelper.CheckDirectoryAndMakeMyWilson3(FTPUpdateDirectory + "/" + UpdateCode + "/" + item.Replace("\\", "/"))
                );
                lbl_message.Text = "文件夹环境部署完成";
                lbl_message.Refresh();
            }
        }
        #endregion


        #region 删除临时文件夹和FTP文件
        /// <summary>
        /// 删除临时文件夹和FTP文件
        /// </summary>
        void DeleteUpdateDirectory()
        {
            try
            {
                string dirPath = startupPath + "\\" + FTPUpdateDirectory;
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
                dirPath = startupPath + "\\" + FTPUpdateDirectory + ".zip";
                if (File.Exists(dirPath))
                    File.Delete(dirPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region CreateUpdateDirectory


        /// <summary>
        /// 创建临时文件夹
        /// </summary>
        void CreateUpdateDirectory()
        {
            CS.Manager.CreateDirectory(directoryTemp);
        }
        #endregion

        void DownloadFile(int _type)
        {
            if (MessageBox.Show("确定要更新吗?", "更新", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                lbl_message.Text = "已停更新";
                return;
            }
            //获取更新xml文件，判断是否需要下载更新，如果没有xml则取消操作，如果有判断日期
            //if (!VerificationEdition(_type))
            //{
            //    lbl_message.Text = "软件已经时最新版本,无需更新";
            //    return;
            //}
            //创建临时文件夹
            //CreateDirectoryTemp();
            DeleteUpdateDirectory();

            string temp_dirname = _type == 1 ? UpdateCode : UpdateApp;

            //查询是否有更新文件，如果有则下载
            string temp_dir = FTPUpdateDirectory + "/" + temp_dirname;
            Debug.WriteLine(temp_dir);
            string temp_filename = FTPUpdateDirectory + ".zip";
            Debug.WriteLine(temp_filename);
            string filepath = startupPath + "\\" + FTPUpdateDirectory;
            Debug.WriteLine(filepath);

            if (FTPHelper.FileExist(temp_dir, temp_filename))
            {
                FTPHelper.Download(filepath, temp_dir, temp_filename);
            }
            else
            {
                MessageBox.Show("没有找到更新文件");
                return;
            }

            //解压缩
            //Rar.UnRarOrZip(filepath, filepath + "\\" + temp_filename, true, "");
            Rar.ZipDecompression(filepath + "\\" + temp_filename);

            //根据xml文件，下载后的更新文件替换到
            //Manager.OpenProgram_Directory(filepath);
            string temp_codedir = filepath + "\\" + FTPUpdateDirectory;
            //先复制所有文件夹
            List<string> dir_list = xml.GetValueByNodes(_type == 1 ? "Folder_Code" : "Folder_App");
            foreach (string temp_dirpath in dir_list)
            {
                if (!string.IsNullOrEmpty(temp_dirpath))
                {
                    //原始文件夹名称
                    string yuanshidir = temp_codedir + "\\" + temp_dirpath;
                    //需要拷贝到的目标地址
                    string copyTo = startupPath + "\\" + temp_dirpath;
                    //开始拷贝
                    FileHelper.DirectoryCopy(yuanshidir, copyTo, true);
                }
            }

            #region 复制文件夹-bak
            //foreach (string drs in Directory.GetDirectories(temp_codedir))
            //{
            //    //DirectoryInfo drinfo = new DirectoryInfo(drs);
            //    //Directory.Move(drs, startupPath);
            //    //如果是临时文件夹，存放单独文件的文件夹，则跳出
            //    string fileTemp = temp_codedir+"\\" + (_type == 1 ? UpdateCode : UpdateApp) ;
            //    if (drs == fileTemp)
            //        break;
            //    FileHelper.DirectoryCopy(drs, startupPath, true);
            //}
            #endregion

            //然后处理单个文件
            List<string> file_list = xml.GetValueByNodes(_type == 1 ? "File_Code" : "File_App");
            foreach (string temp_filepath in file_list)
            {
                //获取xml文件中的文件名称
                string _filename = temp_filepath.IndexOf("\\") > -1 ? (temp_filepath.Substring(temp_filepath.LastIndexOf("\\") + 1)) : temp_filepath;
                string temp_filename2 = temp_codedir + "\\" + (_type == 1 ? UpdateCode : UpdateApp) + "\\" + _filename;
                if (File.Exists(temp_filename2))
                {
                    try
                    {
                        //FileInfo fi = new FileInfo(temp_filename2);
                        string copyTo = startupPath + "\\" + temp_filepath.Replace("\\", "\\\\");
                        //fi.CopyTo(copyTo, true);
                        FileHelper.FileCopy(temp_filename2, copyTo, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(temp_filename2 + "该文件出错" + ex.ToString());
                    }
                }
            }

            //删除压缩包和临时文件夹
            //DeleteFiles();
            //Directory.Delete(FTPUpdateDirectory, true);
        }

        #endregion





        #region bak_之前的代码

        ///---------------------------------------------------
        /// <summary>
        /// 根据文件列表下载文件
        /// </summary>
        /// <param name="folder_list"></param>
        void DownloadFileByFilePath(List<string> file_list)
        {
            //然后上传单独的文件
            foreach (string fileName in file_list)
            {
                lbl_message.Text = "正在操作 " + fileName;
                lbl_message.Refresh();
                if ((!string.IsNullOrEmpty(fileName)) && fileName.IndexOf(".") > -1)
                    FTPHelper.Download(directoryTemp + "\\", "", fileName);
            }
        }
        ///---------------------------------------------------




        ///---------------------------------------------------
        /// <summary>
        /// 根据文件夹列表下载文件
        /// </summary>
        /// <param name="folder_list"></param>
        void DownloadFileByDirectory(List<string> folder_list)
        {
            //下载文件到临时文件夹
            foreach (string folder_path in folder_list)
            {
                if (!string.IsNullOrEmpty(folder_path))
                {
                    string temp = FTPUpdateDirectory + "/" + UpdateCode + "/" + folder_path.Replace("\\", "/");
                    //string[] file_list = FTPHelper.GetFilesDetailList(temp);
                    string[] file_list = FTPHelper.GetFileList(temp);
                    foreach (string fileName in file_list)
                    {
                        lbl_message.Text = "正在操作 " + folder_path + " 文件夹下 " + fileName + " 文件";
                        lbl_message.Refresh();
                        if ((!string.IsNullOrEmpty(fileName)) && fileName.IndexOf(".") > -1)
                            FTPHelper.DownloadFile(directoryTemp + "\\" + folder_path, temp, fileName);
                    }
                }
            }
        }
        ///---------------------------------------------------



        #region UploadFileByDirectory


        /// <summary>
        /// 根据文件夹上传文件
        /// </summary>
        /// <param name="folder_list"></param>
        void UploadFileByDirectory(List<string> folder_list)
        {
            //获取所有文件夹中的文件
            //获取所有需要上传的文件信息 例如excel operation/1.jpg|excel operation/CS/1.jpg 转化\为/
            //删除所有FTP文件夹及文件
            //遍历上传每个文件,上传时检查是否需要创建文件夹
            foreach (string folderpath in folder_list)
            {
                List<string> filepathlist = FileHelper.FindFile(startupPath + "\\" + folderpath, "", false);
                foreach (string filepath in filepathlist)
                {
                    if (!string.IsNullOrEmpty(filepath))
                    {
                        FileInfo fi = new FileInfo(filepath);
                        lbl_message.Text = "正在操作 " + folderpath + " 文件夹下 " + fi.Name + " 文件";
                        lbl_message.Refresh();
                        CS.FTPHelper.UploadFile(fi, FTPUpdateDirectory + "/" + UpdateCode + "/" + folderpath, true);
                    }
                }
            }
        }
        #endregion



        #region UploadFileByFile


        /// <summary>
        /// 根据文件地址上传文件，上传单个文件
        /// </summary>
        /// <param name="file_list"></param>
        void UploadFileByFile(List<string> file_list)
        {
            //获取所有文件夹中的文件
            //获取所有需要上传的文件信息 例如excel operation/1.jpg|excel operation/CS/1.jpg 转化\为/
            //删除所有FTP文件夹及文件
            //遍历上传每个文件,上传时检查是否需要创建文件夹
            foreach (string filepath in file_list)
            {
                if (!string.IsNullOrEmpty(filepath))
                {
                    FileInfo fi = new FileInfo(startupPath + "\\" + filepath);
                    lbl_message.Text = "正在操作 " + filepath;
                    lbl_message.Refresh();
                    CS.FTPHelper.UploadFile(fi, FTPUpdateDirectory + "/" + UpdateCode + "/" + filepath, true);
                }
            }
        }
        #endregion

        #region UpdateDateXml
        /// <summary>
        /// 更新日期
        /// </summary>
        void UpdateDateXml2()
        {
            //修改xml文件更新日期并上传替换
            string xmlpath = startupPath + "\\" + FTPXmlFileName;
            if (File.Exists(xmlpath))
            {
                File.Delete(xmlpath);
            }
            FTPHelper.Download(startupPath, "", FTPUpdateDirectory + "/" + FTPXmlFileName);

        }
        #endregion


        #endregion


    }
}

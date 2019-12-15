using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AutoUpdateClient.CS
{



    public class FTPHelper
    {

        //基本设置
        //public static string URI = @"ftp://" + new CS.XMLHelpers().GetValue("FTPIP") + "/";    //目标路径
        public static string hostname = new CS.XMLHelpers().GetValue("FTPIP");    //ftp IP地址
        public static string username = new CS.XMLHelpers().GetValue("FTPAccount");   //ftp用户名
        public static string password = new CS.XMLHelpers().GetValue("FTPPWD");   //ftp密码

        public static string GetURI()
        {
            return @"FTP://" + new CS.XMLHelpers().GetValue("FTPIP");
        }


        #region FtpWebRequest


        private static FtpWebRequest GetRequest()
        {
            FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(GetURI());
            result.Credentials = new System.Net.NetworkCredential(username, password);
            result.KeepAlive = false;
            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri">要操作的路径</param>
        /// <returns></returns>
        private static FtpWebRequest GetRequest(string uri)
        {
            FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(uri);
            result.Credentials = new System.Net.NetworkCredential(username, password);
            result.KeepAlive = false;
            return result;
        }
        #endregion

        #region UploadFile


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileinfo">需要上传的文件</param>
        /// <param name="targetDir">目标路径文件夹</param>
        /// <param name="hostname">ftp地址</param>
        /// <param name="username">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        public static void UploadFile(FileInfo fileinfo, string targetDir, bool fugai)
        {

            targetDir = targetDir.Replace("\\", "/");
            //判断是否有该文件夹
            CreateDirectory(targetDir);
            //if(DirectoryExist(targetDir,)
            //判断是否有该文件
            if (FileExist(targetDir, fileinfo.Name))
            {
                if (fugai)
                    DeleteFile(targetDir + "/" + fileinfo.Name);
                else
                    return;
            }


            //1. check target
            string target = fileinfo.Name;
            if (targetDir.Trim() == "")
            {
                return;
            }
            //target = Guid.NewGuid().ToString();  //使用临时文件名


            string URI = GetURI() + "/" + targetDir + "/" + target;
            ///WebClient webcl = new WebClient();


            System.Net.FtpWebRequest ftp = GetRequest(URI);

            //设置FTP命令
            ftp.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            ftp.UseBinary = true;
            ftp.UsePassive = true;

            //告诉ftp文件大小
            ftp.ContentLength = fileinfo.Length;

            const int BufferSize = 2048;
            byte[] content = new byte[BufferSize - 1 + 1];
            int dataRead;

            //上传文件内容
            using (FileStream fs = fileinfo.OpenRead())
            {
                try
                {
                    using (Stream rs = ftp.GetRequestStream())
                    {
                        do
                        {
                            dataRead = fs.Read(content, 0, BufferSize);
                            rs.Write(content, 0, dataRead);
                        } while (!(dataRead < BufferSize));
                        rs.Close();
                    }

                }
                catch (Exception ex) { }
                finally
                {
                    fs.Close();
                }

            }

            //ftp = null;

            ////设置FTP命令
            //ftp = GetRequest(URI);
            //ftp.Method = System.Net.WebRequestMethods.Ftp.Rename; //改名
            //ftp.RenameTo = fileinfo.Name;
            //try
            //{
            //    ftp.GetResponse();
            //}
            //catch (Exception ex)
            //{
            //    ftp = GetRequest(URI);
            //    ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile; //删除
            //    ftp.GetResponse();
            //    throw ex;
            //}
            //finally
            //{

            //    //fileinfo.Delete();
            //}


            // 可以记录一个日志  "上传" + fileinfo.FullName + "上传到" + "FTP://" + hostname + "/" + targetDir + "/" + fileinfo.Name + "成功." );
            ftp = null;
        }
        #endregion

        #region UploadFile bak


        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileinfo">需要上传的文件</param>
        /// <param name="targetDir">目标路径文件夹</param>
        /// <param name="hostname">ftp地址</param>
        /// <param name="username">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        public static void UploadFile2(FileInfo fileinfo, string targetDir, bool fugai)
        {

            targetDir = targetDir.Replace("\\", "/");
            //判断是否有该文件夹
            CreateDirectory(targetDir);
            //if(DirectoryExist(targetDir,)
            //判断是否有该文件
            if (FileExist(targetDir, fileinfo.Name))
            {
                if (fugai)
                    DeleteFile(targetDir + "/" + fileinfo.Name);
                else
                    return;
            }


            //1. check target
            string target;
            if (targetDir.Trim() == "")
            {
                return;
            }
            target = Guid.NewGuid().ToString();  //使用临时文件名


            string URI = GetURI() + "/" + targetDir + "/" + target;
            ///WebClient webcl = new WebClient();


            System.Net.FtpWebRequest ftp = GetRequest(URI);

            //设置FTP命令
            ftp.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
            ftp.UseBinary = true;
            ftp.UsePassive = true;

            //告诉ftp文件大小
            ftp.ContentLength = fileinfo.Length;

            const int BufferSize = 2048;
            byte[] content = new byte[BufferSize - 1 + 1];
            int dataRead;

            //上传文件内容
            using (FileStream fs = fileinfo.OpenRead())
            {
                try
                {
                    using (Stream rs = ftp.GetRequestStream())
                    {
                        do
                        {
                            dataRead = fs.Read(content, 0, BufferSize);
                            rs.Write(content, 0, dataRead);
                        } while (!(dataRead < BufferSize));
                        rs.Close();
                    }

                }
                catch (Exception ex) { }
                finally
                {
                    fs.Close();
                }

            }

            ftp = null;

            //设置FTP命令
            ftp = GetRequest(URI);
            ftp.Method = System.Net.WebRequestMethods.Ftp.Rename; //改名
            ftp.RenameTo = fileinfo.Name;
            try
            {
                ftp.GetResponse();
            }
            catch (Exception ex)
            {
                ftp = GetRequest(URI);
                ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile; //删除
                ftp.GetResponse();
                throw ex;
            }
            finally
            {

                //fileinfo.Delete();
            }


            // 可以记录一个日志  "上传" + fileinfo.FullName + "上传到" + "FTP://" + hostname + "/" + targetDir + "/" + fileinfo.Name + "成功." );
            ftp = null;
        }
        #endregion

        #region DownloadFile

        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        public static void Download(string filePath,string FtpDir, string fileName)
        {
            //判断如果没有该文件则删除
            string filePathtemp = GetURI() + "/" + FtpDir.Replace("\\", "/") + "/" + fileName.Replace("\\", "/");
            if (!FileExist(FtpDir, fileName))
            {
                return;
            }

            Manager.CreateDirectory(filePath);

            FtpWebRequest reqFTP;
            try
            {
                FileStream outputStream = new FileStream(filePath + "\\" + fileName.Replace("/","\\"), FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(filePathtemp));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.UsePassive = false;
                reqFTP.Credentials = new NetworkCredential(username, password);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("FtpHelper Download Error --> " + ex.Message);
            }
        }


        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="localDir">本地路径</param>
        /// <param name="FtpDir">ftp路径</param>
        /// <param name="FtpFile">ftp文件名</param>
        /// <param name="hostname">ftp地址</param>
        /// <param name="username">ftp用户名</param>
        /// <param name="password">ftp密码</param>
        public static void DownloadFile(string localDir, string FtpDir, string FtpFile)
        {

            try
            {

                string URI = GetURI() + "/" + FtpDir + "/" + FtpFile;
                string tmpname = Guid.NewGuid().ToString();
                string localfile = localDir + @"\" + tmpname;

                Manager.CreateDirectory(localDir);

                System.Net.FtpWebRequest ftp = GetRequest(URI);
                ftp.Method = System.Net.WebRequestMethods.Ftp.DownloadFile;
                ftp.UseBinary = true;
                ftp.UsePassive = false;

                using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
                {
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        //loop to read & write to file
                        using (FileStream fs = new FileStream(localfile, FileMode.CreateNew))
                        {
                            try
                            {
                                byte[] buffer = new byte[2048];
                                int read = 0;
                                do
                                {
                                    read = responseStream.Read(buffer, 0, buffer.Length);
                                    fs.Write(buffer, 0, read);
                                } while (!(read == 0));
                                responseStream.Close();
                                fs.Flush();
                                fs.Close();
                            }
                            catch (Exception)
                            {
                                //catch error and delete file only partially downloaded
                                fs.Close();
                                //delete target file as it's incomplete
                                File.Delete(localfile);
                                throw;
                            }
                        }

                        responseStream.Close();
                    }

                    response.Close();
                }



                try
                {
                    File.Delete(localDir + @"\" + FtpFile);
                    File.Move(localfile, localDir + @"\" + FtpFile);


                    //ftp = null;
                    //ftp = GetRequest(URI);
                    //ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile;
                    //ftp.GetResponse();

                }
                catch (Exception ex)
                {
                    File.Delete(localfile);
                    throw ex;
                }

                // 记录日志 "从" + URI.ToString() + "下载到" + localDir + @"\" + FtpFile + "成功." );
                ftp = null;

            }
            catch (Exception exx)
            {
                Debug.WriteLine("下载文件出错" + exx.ToString());
            }
        }
        #endregion

        #region ListDirectory

        #region ListDirectory
        /// <summary>
        /// 搜索远程文件
        /// </summary>
        /// <param name="targetDir"></param>
        /// <param name="hostname"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="SearchPattern"></param>
        /// <returns></returns>
        public static List<string> ListDirectory(string targetDir, string SearchPattern)
        {
            List<string> result = new List<string>();
            try
            {
                string URI = GetURI() + "/" + targetDir + "/" + SearchPattern;

                System.Net.FtpWebRequest ftp = GetRequest(URI);
                ftp.Method = System.Net.WebRequestMethods.Ftp.ListDirectory;
                ftp.UsePassive = true;
                ftp.UseBinary = true;


                string str = GetStringResponse(ftp);
                str = str.Replace("\r\n", "\r").TrimEnd('\r');
                str = str.Replace("\n", "\r");
                if (str != string.Empty)
                    result.AddRange(str.Split('\r'));

                return result;
            }
            catch { }
            return null;
        }
        #endregion


        #region GetStringResponse
        private static string GetStringResponse(FtpWebRequest ftp)
        {
            //Get the result, streaming to a string
            string result = "";
            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                long size = response.ContentLength;
                using (Stream datastream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(datastream, System.Text.Encoding.Default))
                    {
                        result = sr.ReadToEnd();
                        sr.Close();
                    }

                    datastream.Close();
                }

                response.Close();
            }

            return result;
        }
        #endregion


        #endregion

        #region CreateDirectory
        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="targetDir">需要创建的文件夹名称，例如update/folder1</param>
        /// <param name="hostname">ftp地址</param>
        /// <param name="username">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool CreateDirectory(string targetDir)
        {
            bool res = false;
            try
            {
                string URI = GetURI() + "/" + targetDir;

                System.Net.FtpWebRequest ftp = GetRequest(URI);
                ftp.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
                res = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                //MessageBox.Show(ex.StackTrace);
            }
            return res;
        }
        #endregion

        #region DeleteFile
        /// <summary>
        /// 删除文件，不能删文件夹
        /// </summary>
        /// <param name="targetDir">需要创建的文件名称，例如update/folder1/1.jpg</param>
        /// <param name="hostname">ftp地址</param>
        /// <param name="username">账号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public static bool DeleteFile(string targetDir)
        {
            bool res = false;
            try
            {
                string URI = "FTP://" + hostname + "/" + targetDir;

                System.Net.FtpWebRequest ftp = GetRequest(URI);
                ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
                res = true;
            }
            catch { }
            return res;
        }
        #endregion

        #region DeleteDirectory
        /// <summary>
        /// 删除目录 上一级必须先存在，并且需删除文件夹下所有文件
        /// </summary>
        /// <param name="dirName">服务器下的相对路径</param>
        public static void DeleteDirectory(string targetDir)
        {
            try
            {
                string URI = GetURI() + "/" + targetDir;
                System.Net.FtpWebRequest ftp = GetRequest(URI);
                ftp.Method = WebRequestMethods.Ftp.RemoveDirectory;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除目录出错：" + ex.Message);
            }
        }
        #endregion

        #region GetDirctorys
        /// <summary>
        /// 从ftp服务器上获得文件夹列表
        /// </summary>
        /// <param name="RequedstPath">服务器下的相对路径</param>
        /// <returns></returns>
        public static List<string> GetDirctorys(string targetDir)
        {
            List<string> strs = new List<string>();
            try
            {
                string URI = GetURI() + "/" + targetDir; //目标路径 path为服务器地址
                FtpWebRequest reqFTP = GetRequest(URI);
                // ftp用户名和密码
                reqFTP.Credentials = new NetworkCredential(username, password);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());//中文文件名

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line.Contains("<DIR>"))
                    {
                        string msg = line.Substring(line.LastIndexOf("<DIR>") + 5).Trim();
                        strs.Add(msg);
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
                response.Close();
                return strs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取目录出错：" + ex.Message);
            }
            return strs;
        }
        #endregion


        #region GetFiles



        /// <summary>
        /// 从ftp服务器上获得文件列表
        /// </summary>
        /// <param name="RequedstPath">服务器下的相对路径</param>
        /// <returns></returns>
        public static List<string> GetFiles(string targetDir)
        {
            List<string> strs = new List<string>();
            try
            {
                string URI = GetURI() + "/" + targetDir; //目标路径 path为服务器地址
                FtpWebRequest reqFTP = GetRequest(URI);
                // ftp用户名和密码
                reqFTP.Credentials = new NetworkCredential(username, password);
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());//中文文件名

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!line.Contains("<DIR>"))
                    {
                        string msg = line.Substring(39).Trim();
                        strs.Add(msg);
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
                response.Close();
                return strs;
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取文件出错：" + ex.Message);
            }
            return strs;
        }
        #endregion

        #region FileExist
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="dir">需要操作的目录</param>
        /// <param name="fileName">文件名称</param>
        /// <returns></returns>
        public static bool FileExist(string dir, string fileName)
        {
            List<string> dirList = GetFiles(dir);//获取子目录
            if (dirList.Count > 0)
            {
                foreach (string str in dirList)
                {
                    if (str.Trim() == fileName.Trim())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region FileExist
        /// <summary>
        /// 判断文件是否存在,不能用，需要改进
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <returns></returns>
        private static bool FileExist(string str)
        {
            string dir = str.Substring(0, str.LastIndexOf("/"));
            string filename = str.Substring(str.LastIndexOf("/") + 1);
            return FileExist(dir,filename);
        }
        #endregion

        #region FileExist
        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="dir">需要操作的目录</param>
        /// <param name="fileName">文件名称</param>
        /// <returns></returns>
        private static bool FileExist2(string dir, string fileName)
        {
            string[] dirList = GetFileList(dir);//获取子目录
            if (dirList.Length > 0)
            {
                foreach (string str in dirList)
                {
                    if (str.Trim() == fileName.Trim())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion



        #region GetFileList


        //获取ftp上面的文件和文件夹
        public static string[] GetFileList(string targetDir)
        {
            string[] downloadFiles;
            StringBuilder result = new StringBuilder();
            FtpWebRequest request;
            try
            {
                string URI = GetURI() + "/" + targetDir; //目标路径 path为服务器地址
                //FtpWebRequest reqFTP = GetRequest(URI, username, password);
                request = (FtpWebRequest)FtpWebRequest.Create(new Uri(URI));
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(username, password);//设置用户名和密码
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.UseBinary = true;

                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string line = reader.ReadLine();
                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    Console.WriteLine(line);
                    line = reader.ReadLine();
                }
                // to remove the trailing '\n'
                result.Remove(result.ToString().LastIndexOf('\n'), 1);
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取ftp上面的文件和文件夹：" + ex.Message);
                downloadFiles = null;
                return downloadFiles;
            }
        }
        #endregion


        #region GetFileSize



        /// <summary>
        /// 获取文件大小
        /// </summary>
        /// <param name="targetDir">ip服务器下的相对路径</param>
        /// <returns>文件大小</returns>
        public static int GetFileSize(string targetDir)
        {
            StringBuilder result = new StringBuilder();
            FtpWebRequest request;
            try
            {
                string URI = GetURI() + "/" + targetDir; //目标路径 path为服务器地址
                request = (FtpWebRequest)FtpWebRequest.Create(new Uri(URI));
                request.UseBinary = true;
                request.Credentials = new NetworkCredential(username, password);//设置用户名和密码
                request.Method = WebRequestMethods.Ftp.GetFileSize;

                int dataLength = (int)request.GetResponse().ContentLength;

                return dataLength;
            }
            catch (Exception ex)
            {
                Console.WriteLine("获取文件大小出错：" + ex.Message);
                return -1;
            }
        }
        #endregion



        #region FileUpLoad


        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="filePath">原路径（绝对路径）包括文件名</param>
        /// <param name="objPath">目标文件夹：服务器下的相对路径 不填为根目录</param>
        public static void FileUpLoad(string filePath, bool fugai, string objPath = "")
        {
            try
            {
                objPath = objPath.Replace("\\", "/");
                //判断是否有该文件
                FileInfo fileInfo = new FileInfo(filePath);
                if (FileExist(objPath, fileInfo.Name))
                {
                    if (fugai)
                        DeleteFile(objPath + "/" + fileInfo.Name);
                    else
                        return;
                }

                string url = GetURI();
                if (objPath != "")
                    url += objPath + "/";
                try
                {

                    FtpWebRequest reqFTP = null;
                    //待上传的文件 （全路径）
                    try
                    {
                        //FileInfo fileInfo = new FileInfo(filePath);
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            long length = fs.Length;
                            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(url + fileInfo.Name));

                            //设置连接到FTP的帐号密码
                            reqFTP.Credentials = new NetworkCredential(username, password);
                            //设置请求完成后是否保持连接
                            reqFTP.KeepAlive = false;
                            //指定执行命令
                            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
                            //指定数据传输类型
                            reqFTP.UseBinary = true;

                            using (Stream stream = reqFTP.GetRequestStream())
                            {
                                //设置缓冲大小
                                int BufferLength = 5120;
                                byte[] b = new byte[BufferLength];
                                int i;
                                while ((i = fs.Read(b, 0, BufferLength)) > 0)
                                {
                                    stream.Write(b, 0, i);
                                }
                                Console.WriteLine("上传文件成功");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("上传文件失败错误为" + ex.Message);
                    }
                    finally
                    {

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("上传文件失败错误为" + ex.Message);
                }
                finally
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("上传文件失败错误为" + ex.Message);
            }
        }
        #endregion



        #region DeleteFileName


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">服务器下的相对路径 包括文件名</param>
        public static void DeleteFileName(string fileName)
        {
            try
            {
                string URI = GetURI() + "/" + fileName;
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(URI));
                // 指定数据传输类型
                reqFTP.UseBinary = true;
                // ftp用户名和密码
                reqFTP.Credentials = new NetworkCredential(username, password);
                // 默认为true，连接不会被关闭
                // 在一个命令之后被执行
                reqFTP.KeepAlive = false;
                // 指定执行什么命令
                reqFTP.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除文件出错：" + ex.Message);
            }
        }
        #endregion



        #region MakeDir


        /// <summary>
        /// 新建目录 上一级必须先存在
        /// </summary>
        /// <param name="dirName">服务器下的相对路径</param>
        public static void MakeDir(string dirName)
        {
            try
            {
                string URI = GetURI() + "/" + dirName;
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(URI));
                // 指定数据传输类型
                reqFTP.UseBinary = true;
                // ftp用户名和密码
                reqFTP.Credentials = new NetworkCredential(username, password);
                reqFTP.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("创建目录出错：" + ex.Message);
            }
        }
        #endregion



        #region DelDir


        /// <summary>
        /// 删除目录 上一级必须先存在
        /// </summary>
        /// <param name="dirName">服务器下的相对路径</param>
        public static void DelDir(string dirName)
        {
            try
            {
                string URI = GetURI() + "/" + dirName;
                FtpWebRequest reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(URI));
                // ftp用户名和密码
                reqFTP.Credentials = new NetworkCredential(username, password);
                reqFTP.Method = WebRequestMethods.Ftp.RemoveDirectory;
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除目录出错：" + ex.Message);
            }
        }
        #endregion


        #region 判断文件&文件夹的目录是否存,不存则创建



        /// <summary>
        /// 判断文件的目录是否存,不存则创建
        /// </summary>
        /// <param name="destFilePath">本地文件目录</param>
        public static void CheckDirectoryAndMakeMyWilson3(string destFilePath)
        {
            string fullDir = destFilePath.IndexOf(':') > 0 ? destFilePath.Substring(destFilePath.IndexOf(':') + 1) : destFilePath;
            fullDir = fullDir.Replace('\\', '/');
            string[] dirs = fullDir.Split('/');//解析出路径上所有的文件名
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)//循环查询每一个文件夹
            {
                string dir = dirs[i];
                if (dir == "") continue;//为空跳出
                if (dir.IndexOf(".") > -1) continue;//是文件名跳出

                //如果是以/开始的路径,第一个为空 
                if (dir != null && dir.Length > 0)
                {
                    try
                    {

                        CheckDirectoryAndMakeMyWilson2(curDir, dir);
                        curDir += dir + "/";
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        /// <summary>
        /// 判断文件的目录是否存,不存则创建
        /// </summary>
        /// <param name="rootDir">需要操作的文件夹</param>
        /// <param name="remoteDirName">需要查询的文件夹名称</param>
        public static void CheckDirectoryAndMakeMyWilson2(string rootDir, string remoteDirName)
        {
            if (!DirectoryExist(rootDir, remoteDirName))//判断当前目录下子目录是否存在
                MakeDir(rootDir + "\\" + remoteDirName);
        }


        /// <summary>
        /// 判断当前目录下指定的子目录是否存在
        /// </summary>
        /// <param name="rootDir">操作的目录(在哪个文件夹查询)</param>
        /// <param name="RemoteDirectoryName">指定的目录名(需要查找的文件夹名称)</param>
        public static bool DirectoryExist(string rootDir, string RemoteDirectoryName)
        {
            string[] dirList = GetDirectoryList(rootDir);//获取子目录
            if (dirList.Length > 0)
            {
                foreach (string str in dirList)
                {
                    if (str.Trim() == RemoteDirectoryName.Trim())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //获取子目录
        public static string[] GetDirectoryList(string dirName)
        {
            string[] drectory = GetFilesDetailList(dirName);
            List<string> strList = new List<string>();
            if (drectory.Length > 0)
            {
                foreach (string str in drectory)
                {
                    if (str.Trim().Length == 0)
                        continue;
                    //会有两种格式的详细信息返回
                    //一种包含<DIR>
                    //一种第一个字符串是drwxerwxx这样的权限操作符号
                    //现在写代码包容两种格式的字符串
                    if (str.Trim().Contains("<DIR>"))
                    {
                        strList.Add(str.Substring(39).Trim());
                    }
                    else
                    {
                        if (str.Trim().Substring(0, 1).ToUpper() == "D")
                        {
                            strList.Add(str.Substring(55).Trim());
                        }
                    }
                }
            }
            return strList.ToArray();
        }

        /// <summary>
        /// 获得文件明晰
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetFilesDetailList(string path)
        {
            return GetFileList(GetURI() + "/" + path, WebRequestMethods.Ftp.ListDirectoryDetails);
        }


        //都调用这个
        //上面的代码示例了如何从ftp服务器上获得文件列表
        public static string[] GetFileList(string path, string WRMethods)
        {
            StringBuilder result = new StringBuilder();
            try
            {
                string URI = path; //目标路径 path为服务器地址
                FtpWebRequest reqFTP = GetRequest(URI);
                reqFTP.Method = WRMethods;
                reqFTP.KeepAlive = false;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default);//中文文件名
                string line = reader.ReadLine();

                while (line != null)
                {
                    result.Append(line);
                    result.Append("\n");
                    line = reader.ReadLine();
                }

                // to remove the trailing '' '' 
                if (result.ToString() != "")
                {
                    result.Remove(result.ToString().LastIndexOf("\n"), 1);
                }
                reader.Close();
                response.Close();
                return result.ToString().Split('\n');
            }

            catch (Exception ex)
            {
                throw new Exception("获取文件列表失败。原因： " + ex.Message);
            }
        }
        #endregion





    }



















}



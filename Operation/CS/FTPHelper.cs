using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace excel_operation.CS
{
 

 
        public class FTPHelper
        {
            private static FtpWebRequest GetRequest(string URI, string username, string password)
            {
                FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
                result.Credentials = new System.Net.NetworkCredential(username, password);
                result.KeepAlive = false;
                return result;
            }

            /// <summary>
            /// 上传文件
            /// </summary>
            /// <param name="fileinfo">需要上传的文件</param>
            /// <param name="targetDir">目标路径</param>
            /// <param name="hostname">ftp地址</param>
            /// <param name="username">ftp用户名</param>
            /// <param name="password">ftp密码</param>
            public static void UploadFile(FileInfo fileinfo, string targetDir, string hostname, string username, string password)
            {
                //1. check target
                string target;
                if (targetDir.Trim() == "")
                {
                    return;
                }
                target = Guid.NewGuid().ToString();  //使用临时文件名


                string URI = "FTP://" + hostname + "/" + targetDir + "/" + target;
                ///WebClient webcl = new WebClient();


                System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);

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
                    catch (Exception ex) { ex.ToString(); }
                    finally
                    {
                        fs.Close();
                    }

                }

                ftp = null;

                //设置FTP命令
                ftp = GetRequest(URI, username, password);
                ftp.Method = System.Net.WebRequestMethods.Ftp.Rename; //改名
                ftp.RenameTo = fileinfo.Name;
                try
                {
                    ftp.GetResponse();
                }
                catch (Exception ex)
                {
                    ftp = GetRequest(URI, username, password);
                    ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile; //删除
                    ftp.GetResponse();
                    throw ex;
                }
                finally
                {

                    fileinfo.Delete();
                }


                // 可以记录一个日志  "上传" + fileinfo.FullName + "上传到" + "FTP://" + hostname + "/" + targetDir + "/" + fileinfo.Name + "成功." );
                ftp = null;
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
            public static void DownloadFile(string localDir, string FtpDir, string FtpFile, string hostname, string username, string password)
            {


                string URI = "FTP://" + hostname + "/" + FtpDir + "/" + FtpFile;
                string tmpname = Guid.NewGuid().ToString();
                string localfile = localDir + @"\" + tmpname;

                System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
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


                    ftp = null;
                    ftp = GetRequest(URI, username, password);
                    ftp.Method = System.Net.WebRequestMethods.Ftp.DeleteFile;
                    ftp.GetResponse();

                }
                catch (Exception ex)
                {
                    File.Delete(localfile);
                    throw ex;
                }

                // 记录日志 "从" + URI.ToString() + "下载到" + localDir + @"\" + FtpFile + "成功." );
                ftp = null;


            }


            /// <summary>
            /// 搜索远程文件
            /// </summary>
            /// <param name="targetDir"></param>
            /// <param name="hostname"></param>
            /// <param name="username"></param>
            /// <param name="password"></param>
            /// <param name="SearchPattern"></param>
            /// <returns></returns>
            public static List<string> ListDirectory(string targetDir, string hostname, string username, string password, string SearchPattern)
            {
                List<string> result = new List<string>();
                try
                {
                    string URI = "FTP://" + hostname + "/" + targetDir + "/" + SearchPattern;

                    System.Net.FtpWebRequest ftp = GetRequest(URI, username, password);
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


        }
  
}

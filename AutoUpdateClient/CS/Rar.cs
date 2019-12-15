using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoUpdateClient.CS
{
    public class Rar
    {
        /// <summary>
        /// 解压RAR和ZIP文件(需存在Winrar.exe(只要自己电脑上可以解压或压缩文件就存在Winrar.exe))
        /// </summary>
        /// <param name="UnPath">解压后文件保存目录</param>
        /// <param name="rarPathName">待解压文件存放绝对路径（包括文件名称）</param>
        /// <param name="IsCover">所解压的文件是否会覆盖已存在的文件(如果不覆盖,所解压出的文件和已存在的相同名称文件不会共同存在,只保留原已存在文件)</param>
        /// <param name="PassWord">解压密码(如果不需要密码则为空)</param>
        /// <returns>true(解压成功);false(解压失败)</returns>
        public static bool UnRarOrZip(string UnPath, string rarPathName, bool IsCover, string PassWord)
        {
            if (!Directory.Exists(UnPath))
                Directory.CreateDirectory(UnPath);
            Process Process1 = new Process();
            Process1.StartInfo.FileName = "Winrar.exe";
            Process1.StartInfo.CreateNoWindow = true;
            string cmd = "";
            if (!string.IsNullOrEmpty(PassWord) && IsCover)
                //解压加密文件且覆盖已存在文件( -p密码 )
                cmd = string.Format(" x -p{0} -o+ {1} {2} -y", PassWord, rarPathName, UnPath);
            else if (!string.IsNullOrEmpty(PassWord) && !IsCover)
                //解压加密文件且不覆盖已存在文件( -p密码 )
                cmd = string.Format(" x -p{0} -o- {1} {2} -y", PassWord, rarPathName, UnPath);
            else if (IsCover)
                //覆盖命令( x -o+ 代表覆盖已存在的文件)
                cmd = string.Format(" x -o+ {0} {1} -y", rarPathName, UnPath);
            else
                //不覆盖命令( x -o- 代表不覆盖已存在的文件)
                cmd = string.Format(" x -o- {0} {1} -y", rarPathName, UnPath);
            //命令
            Process1.StartInfo.Arguments = cmd;
            Process1.Start();
            Process1.WaitForExit();//无限期等待进程 winrar.exe 退出
                                   //Process1.ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行
            if (Process1.ExitCode == 0)
            {
                Process1.Close();
                return true;
            }
            else
            {
                Process1.Close();
                return false;
            }

        }

        /// <summary>
        /// 压缩文件成RAR或ZIP文件(需存在Winrar.exe(只要自己电脑上可以解压或压缩文件就存在Winrar.exe))
        /// </summary>
        /// <param name="filesPath">将要压缩的文件夹或文件的绝对路径</param>
        /// <param name="rarPathName">压缩后的压缩文件保存绝对路径（包括文件名称）</param>
        /// <param name="IsCover">所压缩文件是否会覆盖已有的压缩文件(如果不覆盖,所压缩文件和已存在的相同名称的压缩文件不会共同存在,只保留原已存在压缩文件)</param>
        /// <param name="PassWord">压缩密码(如果不需要密码则为空)</param>
        /// <returns>true(压缩成功);false(压缩失败)</returns>
        public static bool CondenseRarOrZip(string filesPath, string rarPathName, bool IsCover, string PassWord)
        {
            //测试
            //Manager.WriteLog(filesPath+""+rarPathName);
            //return false;
            
            string rarPath = Path.GetDirectoryName(rarPathName);
            if (!Directory.Exists(rarPath))
                Directory.CreateDirectory(rarPath);
            Process Process1 = new Process();
            Process1.StartInfo.FileName = "Winrar.exe";
            Process1.StartInfo.CreateNoWindow = true;
            string cmd = "";
            if (!string.IsNullOrEmpty(PassWord) && IsCover)
                //压缩加密文件且覆盖已存在压缩文件( -p密码 -o+覆盖 )
                cmd = string.Format(" a -ep1 -p{0} -o+ {1} {2} -r", PassWord, rarPathName, filesPath);
            else if (!string.IsNullOrEmpty(PassWord) && !IsCover)
                //压缩加密文件且不覆盖已存在压缩文件( -p密码 -o-不覆盖 )
                cmd = string.Format(" a -ep1 -p{0} -o- {1} {2} -r", PassWord, rarPathName, filesPath);
            else if (string.IsNullOrEmpty(PassWord) && IsCover)
                //压缩且覆盖已存在压缩文件( -o+覆盖 )
                cmd = string.Format(" a -ep1 -o+ {0} {1} -r", rarPathName, filesPath);
            else
                //压缩且不覆盖已存在压缩文件( -o-不覆盖 )
                cmd = string.Format(" a -ep1 -o- {0} {1} -r", rarPathName, filesPath);
            //命令
            Process1.StartInfo.Arguments = cmd;

            //测试
            //Manager.WriteLog(filesPath+" "+rarPathName+" "+cmd);
            //return false;

            Process1.Start();
            Process1.WaitForExit();//无限期等待进程 winrar.exe 退出
                                   //Process1.ExitCode==0指正常执行，Process1.ExitCode==1则指不正常执行
            if (Process1.ExitCode == 0)
            {
                Process1.Close();
                return true;
            }
            else
            {
                Process1.Close();
                return false;
            }
        }




        /// <summary>
        /// 使用Ionic.Zip.dll压缩文件夹, 只能操作zip
        /// </summary>
        /// <param name="folderPath">需要压缩的文件夹或者文件</param>
        /// <param name="savePath">保存到的位置,需要有文件名.rar</param>
        /// <param name="password">如果有密码,可以设置</param>
        public static void ZipCompress(string folderPath, string savePath, string password = "")
        {
            try
            {
                //string FileName = DateTime.Now.ToString("yyMMddHHmmssff");
                //ZipFile实例化一个压缩文件保存路径的一个对象zip
                using (ZipFile zip = new ZipFile(savePath, Encoding.Default))
                {
                    //加密压缩
                    if (!string.IsNullOrEmpty(password))
                        zip.Password = password;
                    //将要压缩的文件夹添加到zip对象中去(要压缩的文件夹路径和名称)
                    if (Directory.Exists(folderPath))
                        zip.AddDirectory(folderPath);
                    else if (File.Exists(folderPath))
                        zip.AddFile(folderPath);
                    else
                        return;
                    //将要压缩的文件添加到zip对象中去,如果文件不存在抛错FileNotFoundExcept
                    //zip.AddFile(@"E:\\yangfeizai\\12051214544443\\"+"Jayzai.xml");
                    zip.Save();
                }
            }
            catch (Exception ex)
            {
                //ex.ToString().ToString();
            }
        }

        /// <summary>
        /// 使用Ionic.Zip.dll压缩文件夹, 只能操作zip
        /// </summary>
        /// <param name="folderPath">需要压缩的文件夹或者文件</param>
        public static void ZipCompress(string folderPath)
        {
            ZipCompress(folderPath, folderPath + ".zip");
        }

        /// <summary>
        /// 使用Ionic.Zip.dll解压, 只能操作zip
        /// </summary>
        /// <param name="zipPath">rar文件地址</param>
        /// <param name="savePath">需要解压到的地址,需要添加解压的文件夹名</param>
        /// <param name="password"></param>
        public static void ZipDecompression(string zipPath, string savePath, string password = "")
        {
            try
            {
                //判断是否有zip文件
                if (!File.Exists(zipPath))
                    return;
                string strZipPath = zipPath; //需要解压的文件
                string strUnZipPath = savePath; //解压的路径
                bool overWrite = true;//设置是否覆盖文件
                                      //ZipFile.Read("", Encoding.Default);
                                      //ReadOptions options = new ReadOptions();
                                      //options.Encoding = Encoding.Default;//设置编码，解决解压文件时中文乱码
                using (ZipFile zip = ZipFile.Read(strZipPath, Encoding.Default))
                {
                    foreach (ZipEntry entry in zip)
                    {
                        if (string.IsNullOrEmpty(strUnZipPath))
                        {
                            strUnZipPath = strZipPath.Split('.')[0];
                        }
                        if (overWrite)
                        {
                            entry.Extract(strUnZipPath, ExtractExistingFileAction.OverwriteSilently);//解压文件，如果已存在就覆盖
                        }
                        else
                        {
                            entry.Extract(strUnZipPath, ExtractExistingFileAction.DoNotOverwrite);//解压文件，如果已存在不覆盖
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // ex.ToString().ToLog();
            }
        }

        /// <summary>
        /// 使用Ionic.Zip.dll解压, 只能操作zip
        /// </summary>
        /// <param name="zipPath">rar文件地址</param>
        public static void ZipDecompression(string zipPath)
        {
            string savePath = zipPath.Replace(".zip", "");
            ZipDecompression(zipPath, savePath);
        }

    }
}

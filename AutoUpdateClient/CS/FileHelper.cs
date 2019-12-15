using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoUpdateClient.CS
{
    public class FileHelper
    {

        #region FindFile
        /// <summary>
        /// 根据文件夹地址，获取里面所有文件
        /// </summary>
        /// <param name="dirPath">文件夹地址</param>
        /// <param name="houzhui">文件后缀,例如jpg|png|gif</param>
        public static List<string> FindFile(string dirPath, string houzhui) //参数dirPath为指定的目录
        {
            return FindFile(dirPath, houzhui, true);
        }
        #endregion

        #region FindFile
        /// <summary>
        /// 根据文件夹地址，获取里面所有文件
        /// </summary>
        /// <param name="dirPath">文件夹地址</param>
        /// <param name="houzhui">文件后缀,例如jpg|png|gif,为空则全部文件类型</param>
        /// <param name="children">是否检查子文件夹</param>
        public static List<string> FindFile(string dirPath, string houzhui, bool children) //参数dirPath为指定的目录
        {
            //在指定目录及子目录下查找文件,在listBox1中列出子目录及文件
            DirectoryInfo Dir = new DirectoryInfo(dirPath);
            List<string> list = new List<string>();
            try
            {
                if (children)
                {
                    //查找子目录
                    foreach (DirectoryInfo d in Dir.GetDirectories())
                    {
                        list.AddRange(FindFile(Dir + "\\" + d.ToString(), houzhui));
                        //listBox1.Items.Add(Dir + d.ToString() + "\"); //listBox1中填加目录名
                    }
                }
                FileInfo[] fis = null;
                if (string.IsNullOrEmpty(houzhui))
                {
                    fis = Dir.GetFiles();
                }
                else
                {
                    fis = Dir.GetFiles("*." + houzhui);
                }
                foreach (FileInfo f in fis) //查找文件
                {
                    list.Add(Dir + "\\" + f.ToString()); //listBox1中填加文件名
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                //MessageBox.Show(e.Message);
            }
            return list;
        }
        #endregion

        #region FindFile2
        /// <summary>
        /// 根据文件夹地址，获取里面所有文件，可以选择多种后缀
        /// </summary>
        /// <param name="dirPath">文件夹地址</param>
        /// <param name="houzhuis">文件后缀,用分号隔开,例如jpg|png|gif</param>
        public static List<string> FindFile2(string dirPath, string houzhuis) //参数dirPath为指定的目录
        {

            List<string> list = new List<string>();
            string[] houzhui = houzhuis.Split('|');
            foreach (string hz in houzhui)
            {
                if (!string.IsNullOrEmpty(hz))
                {
                    list.AddRange(FindFile(dirPath, hz));
                }
            }
            return list;
        }
        #endregion

        #region Write
        /// <summary>
        /// 创建文件并写入内容
        /// </summary>
        /// <param name="path">E:\\test.txt</param>
        /// <param name="txt"></param>
        public static void Write(string path, string txt)
        {
            try
            {
                // 创建文件
                System.IO.FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite); //可以指定盘符，也可以指定任意文件名，还可以为word等文件
                StreamWriter sw = new StreamWriter(fs); // 创建写入流
                sw.WriteLine(txt); // 写入Hello World
                sw.Close(); //关闭文件
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region ReadToChar
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path">E:\\test.txt</param>
        public static char[] ReadToChar(string path)
        {
            byte[] byData = new byte[100];
            char[] charData = new char[1000];
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                file.Seek(0, SeekOrigin.Begin);
                file.Read(byData, 0, 100); //byData传进来的字节数组,用以接受FileStream对象中的数据,第2个参数是字节数组中开始写入数据的位置,它通常是0,表示从数组的开端文件中向数组写数据,最后一个参数规定从文件读多少字符.
                Decoder d = Encoding.Default.GetDecoder();
                d.GetChars(byData, 0, byData.Length, charData, 0);
                file.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
            return charData;
        }
        #endregion

        #region ReadToString
        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadToString(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            //String line;
            string res = sr.ReadToEnd();
            //while ((line = sr.ReadLine()) != null)
            //{
            //    Console.WriteLine(line.ToString());
            //}
            return res;
        }
        #endregion


        #region Delete


        public static bool Delete(string pathFile)
        {
            bool res = true;

            if (File.Exists(pathFile))
            {
                File.Delete(pathFile);
            }
            return res;
        }
        #endregion

        #region DelectDir


        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                    }
                    else
                    {
                        //如果 使用了 streamreader 在删除前 必须先关闭流 ，否则无法删除 sr.close();
                        File.Delete(i.FullName);      //删除指定文件
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion


        #region DirectoryCopy

        /// <summary>
        /// 拷贝文件夹
        /// </summary>
        /// <param name="SourcePath">原始文件夹</param>
        /// <param name="DestinationPath">要保存的文件夹</param>
        /// <param name="overwriteexisting">允许覆盖</param>
        /// <returns></returns>
        public static bool DirectoryCopy(string SourcePath, string DestinationPath, bool overwriteexisting)
        {
            bool ret = false;
            try
            {
                SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
                DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";

                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                        Directory.CreateDirectory(DestinationPath);

                    foreach (string fls in Directory.GetFiles(SourcePath))
                    {
                        FileInfo flinfo = new FileInfo(fls);
                        flinfo.CopyTo(DestinationPath + flinfo.Name, overwriteexisting);
                    }
                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo drinfo = new DirectoryInfo(drs);
                        if (DirectoryCopy(drs, DestinationPath + drinfo.Name, overwriteexisting) == false)
                            ret = false;
                    }
                }
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }
        #endregion

        #region DirectoryCopy

        /// <summary>
        /// 拷贝文件夹
        /// </summary>
        /// <param name="SourcePath">原始文件夹,当前文件夹可能不拷贝，只是复制当前文件夹内部的文件</param>
        /// <param name="DestinationPath">要保存的文件夹</param>
        /// <param name="overwriteexisting">允许覆盖</param>
        /// <returns></returns>
        public static bool DirectoryCopy(string SourcePath, string DestinationPath, bool overwriteexisting, bool HasChildren)
        {
            bool ret = false;
            try
            {
                SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
                DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";

                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                        Directory.CreateDirectory(DestinationPath);

                    foreach (string fls in Directory.GetFiles(SourcePath))
                    {
                        FileInfo flinfo = new FileInfo(fls);
                        flinfo.CopyTo(DestinationPath + flinfo.Name, overwriteexisting);
                    }
                    if (HasChildren)
                    {
                        foreach (string drs in Directory.GetDirectories(SourcePath))
                        {
                            DirectoryInfo drinfo = new DirectoryInfo(drs);
                            if (DirectoryCopy(drs, DestinationPath + drinfo.Name, overwriteexisting) == false)
                                ret = false;
                        }
                    }
                }
                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
            }
            return ret;
        }
        #endregion

        #region 直接删除指定目录下的所有文件及文件夹(保留目录)

        /// <summary>
        ///直接删除指定目录下的所有文件及文件夹(保留目录)
        /// </summary>
        /// <param name="strPath">文件夹路径</param>
        /// <returns>执行结果</returns>

        public static void DeleteDir(string file)
        {
            try
            {
                //去除文件夹和子文件的只读属性
                //去除文件夹的只读属性
                System.IO.DirectoryInfo fileInfo = new DirectoryInfo(file);
                fileInfo.Attributes = FileAttributes.Normal & FileAttributes.Directory;
                //去除文件的只读属性
                System.IO.File.SetAttributes(file, System.IO.FileAttributes.Normal);
                //判断文件夹是否还存在
                if (Directory.Exists(file))
                {
                    foreach (string f in Directory.GetFileSystemEntries(file))
                    {
                        if (File.Exists(f))
                        {
                            //如果有子文件删除文件
                            File.Delete(f);
                            Console.WriteLine(f);
                        }
                        else
                        {
                            //循环递归删除子文件夹
                            DeleteDir(f);
                        }
                    }
                    //删除空文件夹
                    Directory.Delete(file);
                }

            }
            catch (Exception ex) // 异常处理
            {
                Console.WriteLine(ex.Message.ToString());// 异常信息
            }

        }

        #endregion


        #region CreateDirectory
        /// <summary>
        /// 根据文件路径创建文件夹,判断文件夹是否存在，不存在则创建
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateDirectory(string filePath)
        {
            bool res = false;

            try
            {

                //判断文件夹是否存在，不存在则创建
                string directory = filePath.Substring(0, filePath.LastIndexOf("\\"));
                //创建文件夹
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("文件夹创建失败 " + ex.Message);
            }
            return res;
        }

        #endregion


        #region FileCopy
        /// <summary>
        /// 文件拷贝，并创建文件夹
        /// </summary>
        /// <param name="filePath">原始文件路径</param>
        /// <param name="copyTo">拷贝到路径</param>
        /// <param name="overwrite">是否覆盖</param>
        public static bool FileCopy(string filePath, string copyTo, bool overwrite)
        {
            bool res = false;

            try
            {
                //判断文件是否存在
                if (File.Exists(filePath))
                {

                    CreateDirectory(copyTo);
                    //复制文件到目标文件夹
                    FileInfo fi = new FileInfo(filePath);
                    fi.CopyTo(copyTo, overwrite);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件复制移动出错 " + ex.Message);
            }
            return res;
        }

        #endregion

    }
}

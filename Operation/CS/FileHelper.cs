using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.CS
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
            //在指定目录及子目录下查找文件,在listBox1中列出子目录及文件
            DirectoryInfo Dir = new DirectoryInfo(dirPath);
            List<string> list = new List<string>();
            try
            {
                //查找子目录
                foreach (DirectoryInfo d in Dir.GetDirectories())
                {
                    list.AddRange(FindFile(Dir + "\\" + d.ToString(), houzhui));
                    //listBox1.Items.Add(Dir + d.ToString() + "\"); //listBox1中填加目录名
                }
                foreach (FileInfo f in Dir.GetFiles("*." + houzhui)) //查找文件
                {
                    list.Add(Dir + "\\" + f.ToString()); //listBox1中填加文件名
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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


       

    }
}

using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Operation.CS
{
    /// <summary> 
    ///  Http操作类 
    /// </summary> 
    public class RARHelper
    {

        #region Ionic.Zip压缩文件
        //压缩方法一
        public static void ExeRAR(string folderPath,string savePath,string password="")
        {
            //string FileName = DateTime.Now.ToString("yyMMddHHmmssff");
            //ZipFile实例化一个压缩文件保存路径的一个对象zip
            using (ZipFile zip = new ZipFile(savePath, Encoding.Default))
            {
                //加密压缩
                if(!string.IsNullOrEmpty(password))
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
        //压缩方法二
        public void ExeCompTwo()
        {
            string FileName = DateTime.Now.ToString("yyMMddHHmmssff");
            //ZipFile实例化一个对象zip
            using (ZipFile zip = new ZipFile())
            {
                //加密压缩
                zip.Password = "123456";
                //将要压缩的文件夹添加到zip对象中去(要压缩的文件夹路径和名称)
                zip.AddDirectory(@"E:\\yangfeizai\\" + "12051214544443");
                //将要压缩的文件添加到zip对象中去,如果文件不存在抛错FileNotFoundExcept
                //zip.AddFile(@"E:\\yangfeizai\\12051214544443\\"+"Jayzai.xml");
                //用zip对象中Save重载方法保存压缩的文件，参数为保存压缩文件的路径
                zip.Save(@"E:\\yangfeizai\\" + FileName + ".zip");
            }
        }
        #endregion

        #region //删除压缩包中的文件
        //3.从zip文件中删除一个文件,注意无法直接删除一个文件夹
        public void ExeDelete(string FileName)
        {
            using (ZipFile zip = ZipFile.Read(@"E:\\yangfeizai\\" + FileName + ".zip"))
            {
                //zip["Jayzai.xml"] = null;
                //删除zip对象中的一个文件
                zip.RemoveEntry("Jayzai.xml");
                zip.Save();
            }
        }
        #endregion


    }
}
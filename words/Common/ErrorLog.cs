using System;
using System.IO;
using System.Web;

namespace Common
{
    public class ErrorLog
    {
        public ErrorLog() { }

        #region WriteEntry
        public static void WriteEntry(Exception e)
        {
            return;
            Exception error = e;
            string path = HttpContext.Current.Request.PhysicalApplicationPath;
            //string path = System.Environment.CurrentDirectory;
            string logDir = path + "Log\\";
            string logFile = logDir + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if (!System.IO.Directory.Exists(logDir))
            {
                System.IO.Directory.CreateDirectory(logDir);
            }
            System.IO.StreamWriter sw;
            if (System.IO.File.Exists(logFile))
            {
                sw = System.IO.File.AppendText(logFile);
            }
            else
            {
                sw = System.IO.File.CreateText(logFile);
            }
            sw.WriteLine("����ҳ��:"+HttpContext.Current.Request.Url.ToString());
            sw.WriteLine("����ʱ��:" + DateTime.Now.ToString());
            sw.WriteLine("�쳣��Ϣ:"+error.Message);
            sw.WriteLine("Source:"+error.Source);
            sw.WriteLine("StackTrace:" + error.StackTrace);
            sw.WriteLine();
            sw.WriteLine("******************************************************************************************");
            sw.Close();
        }
        #endregion

        #region WriteEntry
        public static void WriteEntry(string str)
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath;
            //string path = System.Environment.CurrentDirectory;
            string logDir = path + "Log\\";
            string logFile = logDir + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            if (!System.IO.Directory.Exists(logDir))
            {
                System.IO.Directory.CreateDirectory(logDir);
            }
            System.IO.StreamWriter sw;
            if (System.IO.File.Exists(logFile))
            {
                sw = System.IO.File.AppendText(logFile);
            }
            else
            {
                sw = System.IO.File.CreateText(logFile);
            }
            sw.WriteLine("��¼ҳ��:" + HttpContext.Current.Request.Url.ToString());
            sw.WriteLine("����ʱ��:" + DateTime.Now.ToString());
            sw.WriteLine("��Ϣ����:" + str);
            sw.WriteLine();
            sw.WriteLine("******************************************************************************************");
            sw.Close();
        }
        #endregion
    }
}

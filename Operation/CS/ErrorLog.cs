using System;
using System.Windows.Forms;

namespace Operation.CS
{
    public class ErrorLog
    {
        public ErrorLog() { }

        #region WriteEntry
        public static void WriteEntry(Exception error)
        {
            string path = Application.StartupPath;
            //string path = System.Environment.CurrentDirectory;
            string logDir = path + "\\Log\\";
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
            sw.WriteLine("发生时间:" + DateTime.Now.ToString());
            sw.WriteLine("异常信息:"+error.Message);
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
            string path = Application.StartupPath;
            //string path = System.Environment.CurrentDirectory;
            string logDir = path + "\\Log\\";
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
            sw.WriteLine("发生时间:" + DateTime.Now.ToString());
            sw.WriteLine("信息内容:" + str);
            sw.WriteLine();
            sw.WriteLine("******************************************************************************************");
            sw.Close();
        }
        #endregion
    }
}

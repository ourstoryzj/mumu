using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excel_operation.CS
{
    /// <summary>
    /// Web采集类
    /// </summary>
    public class WebService
    {

        #region GetHtml
        /// <summary> 
        ///  获取网址HTML 
        /// </summary> 
        /// <param name="URL">网址 </param> 
        /// <returns> </returns> 
        public static string GetHtml(string URL)
        {
            string reader = "";
            try
            {
                WebRequest wrt;
                wrt = WebRequest.Create(URL);
                wrt.Credentials = CredentialCache.DefaultCredentials;
                WebResponse wrp;
                wrp = wrt.GetResponse();
                reader = new StreamReader(wrp.GetResponseStream(), Encoding.GetEncoding("gb2312")).ReadToEnd();
                wrt.GetResponse().Close();
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return reader;
        }
        #endregion

        #region GetHtml
        /// <summary> 
        ///  获取网址HTML 
        /// </summary> 
        /// <param name="URL">网址 </param> 
        /// <returns> </returns> 
        public static string GetHtml2(string URL)
        {
            string reader = "";
            try
            {
                WebRequest wrt;
                wrt = WebRequest.Create(URL);
                wrt.Credentials = CredentialCache.DefaultCredentials;
                WebResponse wrp;
                wrp = wrt.GetResponse();
                reader = new StreamReader(wrp.GetResponseStream(), Encoding.GetEncoding("utf-8")).ReadToEnd();
                wrt.GetResponse().Close();
            }
            catch (WebException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return reader;
        }
        #endregion

        #region SubString
        /// <summary>
        /// 根据两个字符串 截取信息
        /// </summary>
        /// <param name="str">要截取的字符串</param>
        /// <param name="str1">分割字符串的起始位置</param>
        /// <param name="str2">分割字符串的结束位置</param>
        /// <returns></returns>
        public static string SubString(string str, string str1, string str2)
        {
            string res = "";
            string[] sArray = str.Split(new string[] { str1, str2 }, StringSplitOptions.RemoveEmptyEntries);
            if (sArray.Length > 1)
            {
                res = sArray[1];
            }
            return res;
        }
        #endregion


        #region GetIP
        public static string GetIP()
        {
            //string res = "";
            //string hostName = Dns.GetHostName();//本机名  
                                                //System.Net.IPAddress[] addressList = Dns.GetHostByName(hostName).AddressList;//会警告GetHostByName()已过期，我运行时且只返回了一个IPv4的地址  
            
            //System.Net.IPAddress[] addressList = Dns.GetHostAddresses(hostName);//会返回所有地址，包括IPv4和IPv6  
            //foreach (IPAddress ip in addressList)
            //{
            //    res += ip.ToString();
            //}
            System.Net.IPHostEntry myEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            string ipAddress = myEntry.AddressList[2].ToString();
            return ipAddress;
        }
        #endregion


    }
}

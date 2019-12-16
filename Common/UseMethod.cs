using System;
using System.Data;
using System.Collections.Generic;
//using Entity;

namespace Common
{
    public class UseMethod
    {
        

        #region ���캯��

        static UseMethod() { }

        #endregion

        #region ���ؿͻ�IP

        /// <summary>
        /// ���ؿͻ�IP
        /// </summary>
        /// <returns>string</returns>
        public static string getIP()
        {
            string Ip = System.Web.HttpContext.Current.Request.UserHostAddress;
            return Ip;
        }

        #endregion

        #region MD5����

        /// <summary>
        /// MD5����
        /// </summary>
        /// <param name="password">�ַ���</param>
        /// <returns>�ַ���</returns>
        public static string MD5(string sString)
        {
            
            if (string.IsNullOrEmpty(sString.Trim()))
                return "";

            byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(sString);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(data);
            return BitConverter.ToString(result).Replace("-", "");
        }

        #endregion 

        #region GetHistoryUrl

        /// <summary>
        /// ������Դ��ַ
        /// </summary>
        /// <returns></returns>
        public static string GetHistoryUrl()
        {
            return System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
        }

        #endregion

        #region GetCurrUrl

        /// <summary>
        /// ���ص�ǰ��ַ
        /// </summary>
        /// <returns></returns>
        public static string GetCurrUrl()
        {
            return System.Web.HttpContext.Current.Request.Url.ToString();
        }

        #endregion

        #region EntriesToTable

        public static DataTable EntriesToTable<T>(IList<T> objlist)
        {
            if (objlist == null || objlist.Count <= 0)
            {
                return null;
            }
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;
            System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (T t in objlist)
            {
                if (t == null)
                {
                    continue;
                }
                row = dt.NewRow();
                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];
                    string name = pi.Name;
                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }
                    row[name] = pi.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        } 

        #endregion

        #region GetCharGroup

        public static string GetCharGroup(string strChar, string strInput)
        {
            System.Text.Encoding temp = System.Text.Encoding.GetEncoding(strChar);
            byte[] Cbyte = null;
            byte[] bytInput = System.Text.Encoding.Default.GetBytes(strInput);
            Cbyte = System.Text.Encoding.Convert(temp, System.Text.Encoding.Default, bytInput);
            return (temp.GetString(Cbyte));
        }  
        #endregion

        #region IsChina
        public bool IsChina(string CString)
        {
            bool BoolValue = false;
            for (int i = 0; i < CString.Length; i++)
            {
                if (Convert.ToInt32(Convert.ToChar(CString.Substring(i, 1))) < Convert.ToInt32(Convert.ToChar(128)))
                {
                    BoolValue = false;
                }
                else
                {
                    BoolValue = true;
                }
            }
            return BoolValue;
        }
        #endregion

    }

   
}

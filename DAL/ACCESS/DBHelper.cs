using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web;

namespace DAL.Access
{
    public class DBHelper
    {
        //static string Access2 = System.Configuration.ConfigurationManager.ConnectionStrings["MySql"].ToString();
        static string Access1 = System.Configuration.ConfigurationManager.ConnectionStrings["Access"].ToString();
        static string dbPath = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.ConnectionStrings["dbPath"].ToString()) + ";";
        //static string dbPath = System.Web.HttpContext.Current.Server.MapPath("db/db.mdb") + ";";
        //static string dbPath = System.Environment.CurrentDirectory + ConfigurationManager.ConnectionStrings["dbPath"].ToString();
        //static string dbWeb = System.Environment.CurrentDirectory + ConfigurationManager.ConnectionStrings["dbWeb"].ToString();
        //static string dbPathWeb = System.Environment.CurrentDirectory + ConfigurationManager.ConnectionStrings["dbPathWeb"].ToString();
        static string con1 = Access1 + dbPath;
        //static string con2 = Access2;
        private static readonly string sqlcom = con1;
        private static OleDbConnection con = null;
        public static string sqlstr;


        #region OleDbConnection
        /// <summary>
        /// 获取连接
        /// </summary>
        public static OleDbConnection Con
        {
            get
            {
                if (con == null)
                {
                    con = new OleDbConnection(sqlcom);
                    con.Open();
                }
                else if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                else if (con.State == System.Data.ConnectionState.Broken)
                {
                    con.Close();
                    con.Open();
                }
                return con;
            }
        }
        #endregion

        #region ExecuteNonQuery

        /// <summary>
        /// 执行普通sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery()
        {
            try
            {
                OleDbCommand com = new OleDbCommand(sqlstr, Con);
                return com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Common.ErrorLog.WriteEntry(e);
                Common.ErrorLog.WriteEntry(sqlstr);
                return -1;
            }
        }

        /// <summary>
        /// 执行普通sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(OleDbParameter[] param)
        {
            try
            {
                OleDbCommand comm = new OleDbCommand();
                comm.CommandText = sqlstr;
                comm.Parameters.AddRange(param);
                comm.Connection = Con;
                return comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Common.ErrorLog.WriteEntry(e);
                return -1;
            }
        }
        #endregion

        #region GetDataSet
        /// <summary>
        /// 得到表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataSet()
        {
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(sqlstr, Con);
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception e)
            {
                Common.ErrorLog.WriteEntry(e);
                Common.ErrorLog.WriteEntry(sqlstr);
                return null;
            }
        }

        /// <summary>
        /// 得到表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataSet(OleDbParameter[] param)
        {
            try
            {
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlstr, Con);
                dataAdapter.SelectCommand.Parameters.AddRange(param);
                DataSet ds = new DataSet();
                dataAdapter.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region ExecuteScalar
        /// <summary>
        /// 执行查询返回一行一列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar(OleDbParameter[] param)
        {
            try
            {
                OleDbCommand com = new OleDbCommand();
                com.CommandText = sqlstr;
                com.Parameters.AddRange(param);
                com.Connection = Con;
                return com.ExecuteScalar();
            }
            catch (Exception e)
            {
                Common.ErrorLog.WriteEntry(e);
                Common.ErrorLog.WriteEntry(sqlstr);
                return null;
            }
        }

        /// <summary>
        /// 执行查询返回一行一列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object ExecuteScalar()
        {
            try
            {
                OleDbCommand com = new OleDbCommand(sqlstr, Con);
                return com.ExecuteScalar();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

        #region ExecuteReader
        /// <summary>
        /// 得到一行数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader()
        {
            try
            {
                OleDbCommand com = new OleDbCommand(sqlstr, Con);
                return com.ExecuteReader();
            }
            catch (Exception e)
            {
                Common.ErrorLog.WriteEntry(e);
                Common.ErrorLog.WriteEntry(sqlstr);
                return null;
            }
        }

        /// <summary>
        /// 得到一行数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static OleDbDataReader ExecuteReader(OleDbParameter[] param)
        {
            try
            {
                OleDbCommand com = new OleDbCommand();
                com.CommandText = sqlstr;
                com.Parameters.AddRange(param);
                com.Connection = Con;
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                Common.ErrorLog.WriteEntry(e);
                Common.ErrorLog.WriteEntry(sqlstr);
                return null;
            }
        }
        #endregion



    }
}

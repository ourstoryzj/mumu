﻿using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace DAL.Mysql
{
    public class DBHelper
    {

        static string mysql = System.Configuration.ConfigurationManager.ConnectionStrings["MySql"].ToString();
        static string con1 = mysql;
        private static readonly string sqlcom = con1;
        private static MySqlConnection con = null;
        public static string sqlstr = null;


        #region OleDbConnection
        /// <summary>
        /// 获取连接
        /// </summary>
        public static MySqlConnection Con
        {
            get
            {
                if (con == null)
                {
                    con = new MySqlConnection(sqlcom);
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
                MySqlCommand com = new MySqlCommand(sqlstr, Con);
                return com.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        /// 执行普通sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(MySqlParameter[] param)
        {
            try
            {
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = sqlstr;
                comm.Parameters.AddRange(param);
                comm.Connection = Con;
                return comm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        /// <summary>
        /// 插入多条数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static void ExecuteSqlTran(List<MySqlParameter[]> list_param)
        {
            using (MySqlConnection conn = new MySqlConnection(mysql))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < list_param.Count; n++)
                    {
                        cmd.Parameters.Clear();
                        cmd.CommandText = sqlstr;
                        cmd.Parameters.AddRange(list_param[n]);
                        cmd.ExecuteNonQuery();

                        //后来加上的  
                        if (n > 0 && (n % 500 == 0 || n == list_param.Count - 1))
                        {
                            tx.Commit();
                            tx = conn.BeginTransaction();
                        }
                    }
                    //tx.Commit();//原来一次性提交  
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
            }
        }
        public static void ExecuteSqlTran(List<string> SQLStringList)
        {
            using (MySqlConnection conn = new MySqlConnection(mysql))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                MySqlTransaction tx = conn.BeginTransaction();
                cmd.Transaction = tx;
                try
                {
                    for (int n = 0; n < SQLStringList.Count; n++)
                    {
                        string strsql = SQLStringList[n].ToString();
                        if (strsql.Trim().Length > 1)
                        {
                            cmd.CommandText = strsql;
                            cmd.ExecuteNonQuery();
                        }
                        //后来加上的  
                        if (n > 0 && (n % 500 == 0 || n == SQLStringList.Count - 1))
                        {
                            tx.Commit();
                            tx = conn.BeginTransaction();
                        }
                    }
                    //tx.Commit();//原来一次性提交  
                }
                catch (System.Data.SqlClient.SqlException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
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
                MySqlDataAdapter da = new MySqlDataAdapter(sqlstr, Con);
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 得到表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable GetDataSet(MySqlParameter[] param)
        {
            try
            {
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sqlstr, Con);
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
        public static object ExecuteScalar(MySqlParameter[] param)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.CommandText = sqlstr;
                com.Parameters.AddRange(param);
                com.Connection = Con;
                return com.ExecuteScalar();
            }
            catch (Exception e)
            {
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
                MySqlCommand com = new MySqlCommand(sqlstr, Con);
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
        public static MySqlDataReader ExecuteReader()
        {
            try
            {
                MySqlCommand com = new MySqlCommand(sqlstr, Con);
                return com.ExecuteReader();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一行数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static MySqlDataReader ExecuteReader(MySqlParameter[] param)
        {
            try
            {
                MySqlCommand com = new MySqlCommand();
                com.CommandText = sqlstr;
                com.Parameters.AddRange(param);
                com.Connection = Con;
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        #endregion

    }
}

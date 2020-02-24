using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using Common;

namespace DAL
{
    public class DBHelper
    {

        #region Common
        /// <summary>
        /// sqlcom:获取MSSQL的连接字符串
        /// </summary>
        private static readonly string sqlcom = ConfigurationManager.ConnectionStrings["SQL"].ToString();

        private static SqlConnection com = null;
        private static SqlCommand cmd = null;
        private static SqlDataReader reader = null;
        private static int result = 0;
        private static object obj = null;
        private static DataSet dataSet = null;
        private static SqlDataAdapter adapter = null;

        /// <summary>
        /// sqlstr:要执行的SQL语句
        /// </summary>
        public static string sqlstr = null;
        #endregion

        #region SqlConnection

        #region GetConnection
        /// <summary>
        /// 获取并打开SqlConnection
        /// </summary>
        private static SqlConnection GetConnection()
        {
            if (com == null)
            {
                com = new SqlConnection(sqlcom);
                com.Open();
            }
            else if (com.State == System.Data.ConnectionState.Closed)
            {
                com.Open();
            }
            else if (com.State == System.Data.ConnectionState.Broken)
            {
                com.Close();
                com.Open();
            }
            return com;
        }
        #endregion

        #region CloseConnection()
        /// <summary>
        /// CloseConnection()
        /// </summary>
        private static void  CloseConnection()
        {
            if (com.State == System.Data.ConnectionState.Open)
            {
                com.Close();
            }
            else if (com.State == System.Data.ConnectionState.Broken)
            {
                com.Close();
            }
        }
        #endregion

        #endregion

        #region SqlCommand

        #region Createcommand()
        /// <summary>
        /// SqlCommand赋值:不带参
        /// </summary>
        /// <returns></returns>
        public static void Createcommand()
        {
            cmd = new SqlCommand();
            cmd.Connection = GetConnection();
            cmd.CommandText = sqlstr;
        }
        #endregion

        #region Createcommand(params SqlParameter[] values)
        /// <summary>
        /// SqlCommand赋值:带参
        /// </summary>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public static SqlCommand Createcommand(params SqlParameter[] values)
        {
            cmd = new SqlCommand();
            cmd.Connection = GetConnection();
            cmd.CommandText = sqlstr;
            cmd.Parameters.AddRange(values);
            return cmd;
        }
        #endregion

        #region Createcommand(string procName, params SqlParameter[] values)
        /// <summary>
        /// SqlCommand赋值:用于使用存储过程+参数
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="values">参数,可以为空</param>
        /// <returns></returns>
        public static SqlCommand Createcommand(string procName, params SqlParameter[] values)
        {
            cmd = new SqlCommand();
            cmd.Connection = GetConnection();
            cmd.CommandText = procName;
            cmd.CommandType = CommandType.StoredProcedure;
            if (values != null)
            {
                cmd.Parameters.AddRange(values);
            }
            return cmd;
        }
        #endregion

        #region Createcommand(CommandType cmdType, SqlTransaction trans, params SqlParameter[] values)
        /// <summary>
        /// SqlCommand赋值:命令类型+是否回滚+是否有参数
        /// </summary>
        /// <param name="cmdType">命令类型,可为空</param>
        /// <param name="trans">是否回滚,可为空</param>
        /// <param name="values">是否有参数,可为空</param>
        /// <returns>SqlCommand对象</returns>
        private static SqlCommand Createcommand(CommandType cmdType, SqlTransaction trans, params SqlParameter[] values)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = GetConnection();

            cmd.CommandType = cmdType;

            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            if (values != null)
            {
                cmd.Parameters.AddRange(values);
            }
            cmd.CommandText = sqlstr;
            return cmd;
        }
        #endregion
        #endregion

        #region SqlDataReader

        #region ExecuteReader()
        /// <summary>
        /// 执行T-SQL语句返回一个SqlDataReader
        /// </summary>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader()
        {
            try
            {
                Createcommand();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                reader.Close();
                //throw e;
            }
            return reader;
        }
        #endregion

        #region ExecuteReader(SqlParameter[] values)
        /// <summary>
        /// 执行带参数的T-SQL语句返回一个SqlDataReader
        /// </summary>
        /// <param name="values">参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(params SqlParameter[] values)
        {
            try
            {
                Createcommand(values);
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                reader.Close();
                //throw e;
            }
            return reader;
        }
        #endregion

        #region ExecuteReader(string procName, params SqlParameter[] values)
        /// <summary>
        /// 执行存储过程返回一个SqlDataReader
        /// </summary>
        /// <param name="procName">存数过程的名称</param>
        /// <param name="values">参数</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string procName, params SqlParameter[] values)
        {
            try
            {
                Createcommand(procName, values);
                reader = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                reader.Close();
                //throw e;
            }
            return reader;
        }
        #endregion

        

        #endregion

        #region ExecuteNonQuery

        #region ExecuteNonQuery()
        /// <summary>
        /// 执行T-SQL语句返回受影响的行数
        /// </summary>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery()
        {
            try
            {
                Createcommand();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #endregion

        #region ExecuteNonQuery(params SqlParameter[] values)
        /// <summary>
        /// 执行带参数的T-SQL语句并返回受影响的行数
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(params SqlParameter[] values)
        {
            try
            {
                Createcommand(values);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #endregion

        #region ExecuteNonQuery(string procName, params SqlParameter[] values)
        /// <summary>
        /// 执行存数过程返回受影响的行数?
        /// </summary>
        /// <param name="procName">存数过程名称</param>
        /// <param name="values">参数</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string procName, params SqlParameter[] values)
        {
            try
            {
                Createcommand(procName,values);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #endregion

        #region ExecuteNonQuery(string procName, string output, ParameterDirection param_Direction, params SqlParameter[] values)
        /// <summary>
        /// 执行存数过程返回受影响的行数
        /// </summary>
        /// <param name="procName">存数过程名称</param>
        /// <param name="output">要返回的参数名</param>
        /// <param name="param_Direction"></param>
        /// <param name="values">参数</param>
        /// <returns></returns>
        public static object ExecuteNonQuery(string procName, string output, ParameterDirection param_Direction, params SqlParameter[] values)
        {
            object res_obj = null;
            try
            {
                Createcommand(procName, values);
                cmd.Parameters[output].Direction = param_Direction;
                result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    res_obj = cmd.Parameters[output].Value;
                }
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return res_obj;
        }
        #endregion

        #region ExecuteNonQuery(CommandType cmdType,SqlTransaction trans, params SqlParameter[] values)
        /// <summary>
        /// 根据条件执行命令,返回受影响的行数,所有条件都可为null
        /// </summary>
        /// <param name="cmdType">命令类型,可为空</param>
        /// <param name="trans">是否有回滚,可为空</param>
        /// <param name="values">是否有参数,可为空</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(CommandType cmdType,SqlTransaction trans, params SqlParameter[] values)
        {
            try
            {
                Createcommand(cmdType,trans, values);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        #endregion

        #endregion

        #region ExecuteScalar

        #region ExecuteScalar()
        /// <summary>
        /// 执行查询并返回结果集的第一行第一列
        /// </summary>
        /// <returns></returns>
        public static object ExecuteScalar()
        {
            try
            {
                Createcommand();
                obj = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return obj;
        }
        #endregion

        #region ExecuteScalar(params SqlParameter[] values)
        /// <summary>
        /// 执行查询并返回结果集的第一行第一列
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static object ExecuteScalar(params SqlParameter[] values)
        {
            try
            {
                Createcommand(values);
                obj = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return obj;
        }
        #endregion

        #region ExecuteScalar(string procName, params SqlParameter[] values)
        /// <summary>
        /// 执行存储过程,并返回结果集的第一行第一列
        /// </summary>
        /// <param name="procName">存储过程的名称</param>
        /// <param name="values">参数</param>
        /// <returns>结果集的第一行第一列</returns>
        public static object ExecuteScalar(string procName, params SqlParameter[] values)
        {
            try
            {
                Createcommand(procName,values);
                obj = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return obj;
        }
        #endregion

        #endregion

        #region DataTable

        #region GetDateSet()
        /// <summary>
        /// 执行T-SQL语句并返回一个DataTable
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetDateSet()
        {
            dataSet = new DataSet();
            try
            {
                Createcommand();
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return dataSet.Tables[0];
        }
        #endregion

        #region GetDateSet(params SqlParameter[] values)
        /// <summary>
        /// 执行单参数的T-SQL语句,并返回一个DataTable
        /// </summary>
        /// <param name="values">参数</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDateSet(params SqlParameter[] values)
        {
            dataSet = new DataSet();
            try
            {
                Createcommand(values);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return dataSet.Tables[0];
        }
        #endregion

        #region GetDateSet(string procName, params SqlParameter[] values)
        /// <summary>
        /// 执行存储过程并返回一个DataTable
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="values">参数</param>
        /// <returns>DataTable</returns>
        public static DataTable GetDateSet(string procName, params SqlParameter[] values)
        {
            dataSet = new DataSet();
            try
            {
                Createcommand(procName,values);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                ErrorLog.WriteEntry(e);
                //throw e;
            }
            finally
            {
                CloseConnection();
            }
            return dataSet.Tables[0];
        }
        #endregion

        #endregion
    }
}

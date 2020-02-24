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
        /// sqlcom:��ȡMSSQL�������ַ���
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
        /// sqlstr:Ҫִ�е�SQL���
        /// </summary>
        public static string sqlstr = null;
        #endregion

        #region SqlConnection

        #region GetConnection
        /// <summary>
        /// ��ȡ����SqlConnection
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
        /// SqlCommand��ֵ:������
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
        /// SqlCommand��ֵ:����
        /// </summary>
        /// <param name="values">����</param>
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
        /// SqlCommand��ֵ:����ʹ�ô洢����+����
        /// </summary>
        /// <param name="procName">�洢��������</param>
        /// <param name="values">����,����Ϊ��</param>
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
        /// SqlCommand��ֵ:��������+�Ƿ�ع�+�Ƿ��в���
        /// </summary>
        /// <param name="cmdType">��������,��Ϊ��</param>
        /// <param name="trans">�Ƿ�ع�,��Ϊ��</param>
        /// <param name="values">�Ƿ��в���,��Ϊ��</param>
        /// <returns>SqlCommand����</returns>
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
        /// ִ��T-SQL��䷵��һ��SqlDataReader
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
        /// ִ�д�������T-SQL��䷵��һ��SqlDataReader
        /// </summary>
        /// <param name="values">����</param>
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
        /// ִ�д洢���̷���һ��SqlDataReader
        /// </summary>
        /// <param name="procName">�������̵�����</param>
        /// <param name="values">����</param>
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
        /// ִ��T-SQL��䷵����Ӱ�������
        /// </summary>
        /// <returns>��Ӱ�������</returns>
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
        /// ִ�д�������T-SQL��䲢������Ӱ�������
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
        /// ִ�д������̷�����Ӱ�������?
        /// </summary>
        /// <param name="procName">������������</param>
        /// <param name="values">����</param>
        /// <returns>��Ӱ�������</returns>
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
        /// ִ�д������̷�����Ӱ�������
        /// </summary>
        /// <param name="procName">������������</param>
        /// <param name="output">Ҫ���صĲ�����</param>
        /// <param name="param_Direction"></param>
        /// <param name="values">����</param>
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
        /// ��������ִ������,������Ӱ�������,������������Ϊnull
        /// </summary>
        /// <param name="cmdType">��������,��Ϊ��</param>
        /// <param name="trans">�Ƿ��лع�,��Ϊ��</param>
        /// <param name="values">�Ƿ��в���,��Ϊ��</param>
        /// <returns>��Ӱ�������</returns>
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
        /// ִ�в�ѯ�����ؽ�����ĵ�һ�е�һ��
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
        /// ִ�в�ѯ�����ؽ�����ĵ�һ�е�һ��
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
        /// ִ�д洢����,�����ؽ�����ĵ�һ�е�һ��
        /// </summary>
        /// <param name="procName">�洢���̵�����</param>
        /// <param name="values">����</param>
        /// <returns>������ĵ�һ�е�һ��</returns>
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
        /// ִ��T-SQL��䲢����һ��DataTable
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
        /// ִ�е�������T-SQL���,������һ��DataTable
        /// </summary>
        /// <param name="values">����</param>
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
        /// ִ�д洢���̲�����һ��DataTable
        /// </summary>
        /// <param name="procName">�洢��������</param>
        /// <param name="values">����</param>
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

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.OleDb;
using System.Configuration;
using System.Data;

namespace DAL.Access
{


    //表名称：shuadan_phone
    //实体类名称：shuadan_phoneExample
    //主键：sdpid

    public class addressService : IaddressService
    {


        static string Access = System.Configuration.ConfigurationManager.ConnectionStrings["Access"].ToString();
        static string dbPath = System.Web.HttpContext.Current.Server.MapPath(ConfigurationManager.ConnectionStrings["dbPath2"].ToString()) + ";";
        static string con1 = Access + dbPath;
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

        #region ExecuteScalar
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
                Common.ErrorLog.WriteEntry(e);
                return null;
            }
        }
        #endregion

        #region SearchByaid
        /// <summary>
        /// 根据主键,查询一条数据
        /// </summary>
        /// <param name="主键"></param>
        /// <returns></returns>
        public address SearchByaid(int aid)
        {
            sqlstr = "select * from address where aid = @aid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@aid",aid)
			};
            OleDbDataReader reader = ExecuteReader(param);
            address Obj = null;
            if (reader.Read())
            {
                Obj = GetByReader(reader);
            }
            reader.Close();
            return Obj;
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="address">address表实例</param>
        /// <returns>int</returns>
        public int Insert(address addressExample)
        {
            sqlstr = "insert into  address (aAddress,aCity,aDistrict,aid,aPostNumber,aProvince,aremark,astate)values(@aAddress,@aCity,@aDistrict,@aid,@aPostNumber,@aProvince,@aremark,@astate)";
            return ExecuteNonQuery(GetOleDbParameter(addressExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="address">address表实例</param>
        /// <returns>int</returns>
        public int Update(address addressExample)
        {
            sqlstr = "update address set aAddress=@aAddress,aCity=@aCity,aDistrict=@aDistrict,aPostNumber=@aPostNumber,aProvince=@aProvince,aremark=@aremark,astate=@astate where aid=" + addressExample.aid;
            return ExecuteNonQuery(GetOleDbParameter(addressExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="主键"></param>
        /// <returns>int</returns>
        public int Delete(int aid)
        {
            sqlstr = "delete from address where aid =@aid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@aid",aid)
			};
            return ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public int SearchNum(string key, string state)
        {
            string sql1 = "select count(aid) from address where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  aAddress like '%" + key + "%'  or  aCity like '%" + key + "%'  or  aDistrict like '%" + key + "%'   or  aPostNumber like '%" + key + "%'   or  aProvince like '%" + key + "%'  or  aremark like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and astate='" + state + "' ";
            sqlstr = sql1 + sql2 + sql3;
            return Convert.ToInt32(ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索(高效率分页查询)
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        public IList<address> Search(int s, int e, string key, string state, string _top)
        {
            string sql = string.IsNullOrEmpty(_top) ? " address " : "( select top " + _top + " * from address order by aid desc,aPostNumber asc )";
            string sql1 = "select top " + e.ToString() + " * from " + sql + " where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  aAddress like '%" + key + "%'  or  aCity like '%" + key + "%'  or  aDistrict like '%" + key + "%'   or  aPostNumber like '%" + key + "%'   or  aProvince like '%" + key + "%'  or  aremark like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and astate='" + state + "' ";
            string sql4 = " order by aid asc,aPostNumber desc ";
            sqlstr = "select top " + (e - s + 1).ToString() + " * from " + "( " + sql1 + sql2 + sql3 + " order by aid desc,aPostNumber asc ) " + sql4;
            List<address> list = new List<address>();
            OleDbDataReader reader = ExecuteReader();
            while (reader.Read())
            {
                address Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchRND
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<address> SearchRND(string num)
        {
            sqlstr = "select top " + num + " * from address where astate='1'  order by rnd(aid) ";
            List<address> list = new List<address>();
            OleDbDataReader reader = ExecuteReader();
            while (reader.Read())
            {
                address Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region 公共方法

        #region GetOleDbParameter
        /// <summary>
        /// 根据表,获取一个OleDbParameter数组
        /// </summary>
        /// <returns>OleDbParameter[]</returns>
        public static OleDbParameter[] GetOleDbParameter(address addressExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(addressExample.aAddress))
            {
                list_param.Add(new OleDbParameter("@aAddress", addressExample.aAddress));
            }
            else
            {
                list_param.Add(new OleDbParameter("@aAddress", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(addressExample.aCity))
            {
                list_param.Add(new OleDbParameter("@aCity", addressExample.aCity));
            }
            else
            {
                list_param.Add(new OleDbParameter("@aCity", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(addressExample.aDistrict))
            {
                list_param.Add(new OleDbParameter("@aDistrict", addressExample.aDistrict));
            }
            else
            {
                list_param.Add(new OleDbParameter("@aDistrict", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(addressExample.aPostNumber))
            {
                list_param.Add(new OleDbParameter("@aPostNumber", addressExample.aPostNumber));
            }
            else
            {
                list_param.Add(new OleDbParameter("@aPostNumber", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(addressExample.aProvince))
            {
                list_param.Add(new OleDbParameter("@aProvince", addressExample.aProvince));
            }
            else
            {
                list_param.Add(new OleDbParameter("@aProvince", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(addressExample.aremark))
            {
                list_param.Add(new OleDbParameter("@aremark", addressExample.aremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@aremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(addressExample.astate))
            {
                list_param.Add(new OleDbParameter("@astate", addressExample.astate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@astate", DBNull.Value));
            }
            OleDbParameter[] param = new OleDbParameter[list_param.Count];
            int index = 0;
            foreach (OleDbParameter p in list_param)
            {
                param[index] = p;
                index++;
            }
            return param;
        }
        #endregion

        #region GetByReader
        /// <summary>
        /// 从一个OleDbDataReader里读数据
        /// </summary>
        /// <param name="Reader">OleDbDataReader</param>
        /// <returns>addressExample</returns>
        public static address GetByReader(OleDbDataReader Reader)
        {
            address addressExample = new address();
            addressExample.aAddress = Reader["aAddress"] == DBNull.Value ? null : Reader["aAddress"].ToString();
            addressExample.aCity = Reader["aCity"] == DBNull.Value ? null : Reader["aCity"].ToString();
            addressExample.aDistrict = Reader["aDistrict"] == DBNull.Value ? null : Reader["aDistrict"].ToString();
            addressExample.aid = Reader["aid"] == DBNull.Value ? 0 : (int)Reader["aid"];
            addressExample.aPostNumber = Reader["aPostNumber"] == DBNull.Value ? null : Reader["aPostNumber"].ToString();
            addressExample.aProvince = Reader["aProvince"] == DBNull.Value ? null : Reader["aProvince"].ToString();
            addressExample.aremark = Reader["aremark"] == DBNull.Value ? null : Reader["aremark"].ToString();
            addressExample.astate = Reader["astate"] == DBNull.Value ? null : Reader["astate"].ToString();
            return addressExample;
        }
        #endregion





        #endregion
    }


}

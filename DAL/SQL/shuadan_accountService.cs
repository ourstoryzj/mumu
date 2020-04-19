using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{


    //表名称：shuadan_account
    //实体类名称：shuadan_accountExample
    //主键：sdaid
 

    public class shuadan_accountService : Ishuadan_accountService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_account> SearchAll()
        {
            DBHelper.sqlstr = "select * from shuadan_account ";
            List<shuadan_account> list = new List<shuadan_account>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_account Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据sdaid,查询一条数据
        /// </summary>
        /// <param name="sdaid"></param>
        /// <returns></returns>
        /*查看是否为视图*/

        public shuadan_account SearchByID(int sdaid)
        {
            DBHelper.sqlstr = "select * from shuadan_account where sdaid = @sdaid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@sdaid",sdaid)
            };
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            shuadan_account Obj = null;
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
        /// <param name="shuadan_account">shuadan_account表实例</param>
        /// <returns>int</returns>
        public int Insert(shuadan_account shuadan_accountExample)
        {
            DBHelper.sqlstr = "insert into  shuadan_account (sdaccount,sdapwd,sdastate,sdadate,sdaphone,sdaremark,sdaremark1)values(@sdaccount,@sdapwd,@sdastate,@sdadate,@sdaphone,@sdaremark,@sdaremark1)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(shuadan_accountExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_account">shuadan_account表实例</param>
        /// <returns>int</returns>
        public int Update(shuadan_account shuadan_accountExample)
        {
            DBHelper.sqlstr = "update shuadan_account set sdaccount=@sdaccount,sdapwd=@sdapwd,sdastate=@sdastate,sdadate=@sdadate,sdaphone=@sdaphone,sdaremark=@sdaremark,sdaremark1=@sdaremark1 where sdaid=" + shuadan_accountExample.sdaid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(shuadan_accountExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdaid"></param>
        /// <returns>int</returns>
        public int Delete(int sdaid)
        {
            DBHelper.sqlstr = "delete shuadan_account where sdaid =@sdaid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@sdaid",sdaid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询数据条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="id">int字段</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns>IList</returns>
        public int SearchNum(string key, string state, int id, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(sdaid) from shuadan_account where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( sdaccount like '%" + key + "%' or sdapwd like '%" + key + "%' or sdastate like '%" + key + "%' or sdaphone like '%" + key + "%' or sdaremark like '%" + key + "%' or sdaremark1 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sdastate= '" + state + "' ";//状态字段，无用删除
            //string sql4 = id == 0 ? "" : " and id字段='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',sdadate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',sdadate)<=0 ";//时间字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3  + sql5 + sql6;
            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="id">int字段</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序</param>
        /// <returns>IList<shuadan_account></returns>
        public IList<shuadan_account> Search(int s, int e, string key, string state, int id, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select top " + (e - s + 1).ToString() + " * from shuadan_account where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( sdaccount like '%" + key + "%' or sdapwd like '%" + key + "%' or sdastate like '%" + key + "%' or sdaphone like '%" + key + "%' or sdaremark like '%" + key + "%' or sdaremark1 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sdastate= '" + state + "' ";//状态字段，无用删除
            //string sql4 = id == 0 ? "" : " and id字段='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',sdadate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',sdadate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by sdaid desc " : " order by " + orderby;
            string sql8 = s == 1 ? "" : " and sdaid not in ( select top " + (s - 1).ToString() + " sdaid from shuadan_account where " + sql2 + sql3  + sql5 + sql6 + sql7 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3  + sql5 + sql6 + sql8 + sql7;
            List<shuadan_account> list = new List<shuadan_account>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_account Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion





        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameters(shuadan_account shuadan_accountExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(shuadan_accountExample.sdaccount))
            {
                list_param.Add(new SqlParameter("@sdaccount", shuadan_accountExample.sdaccount));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdaccount", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_accountExample.sdapwd))
            {
                list_param.Add(new SqlParameter("@sdapwd", shuadan_accountExample.sdapwd));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdapwd", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_accountExample.sdastate))
            {
                list_param.Add(new SqlParameter("@sdastate", shuadan_accountExample.sdastate));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdastate", DBNull.Value));
            }
            if (shuadan_accountExample.sdadate != new DateTime() && shuadan_accountExample.sdadate != null)
            {
                list_param.Add(new SqlParameter("@sdadate", shuadan_accountExample.sdadate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdadate", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_accountExample.sdaphone))
            {
                list_param.Add(new SqlParameter("@sdaphone", shuadan_accountExample.sdaphone));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdaphone", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_accountExample.sdaremark))
            {
                list_param.Add(new SqlParameter("@sdaremark", shuadan_accountExample.sdaremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdaremark", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(shuadan_accountExample.sdaremark1))
            {
                list_param.Add(new SqlParameter("@sdaremark1", shuadan_accountExample.sdaremark1));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdaremark1", DBNull.Value));
            }
            SqlParameter[] param = new SqlParameter[list_param.Count];
            int index = 0;
            foreach (SqlParameter p in list_param)
            {
                param[index] = p;
                index++;
            }
            return param;
        }
        #endregion

        #region GetByReader
        /// <summary>
        /// 从一个SqlDataReader里读数据
        /// </summary>
        /// <param name="Reader">SqlDataReader</param>
        /// <returns>shuadan_accountExample</returns>
        public static shuadan_account GetByReader(SqlDataReader Reader)
        {
            shuadan_account shuadan_accountExample = new shuadan_account();
            shuadan_accountExample.sdaid = Reader["sdaid"] == DBNull.Value ? 0 : (int)Reader["sdaid"];
            shuadan_accountExample.sdaccount = Reader["sdaccount"] == DBNull.Value ? null : Reader["sdaccount"].ToString();
            shuadan_accountExample.sdapwd = Reader["sdapwd"] == DBNull.Value ? null : Reader["sdapwd"].ToString();
            shuadan_accountExample.sdastate = Reader["sdastate"] == DBNull.Value ? null : Reader["sdastate"].ToString();
            shuadan_accountExample.sdadate = Reader["sdadate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sdadate"]);
            shuadan_accountExample.sdaphone = Reader["sdaphone"] == DBNull.Value ? null : Reader["sdaphone"].ToString();
            shuadan_accountExample.sdaremark = Reader["sdaremark"] == DBNull.Value ? null : Reader["sdaremark"].ToString();
            shuadan_accountExample.sdaremark1 = Reader["sdaremark1"] == DBNull.Value ? null : Reader["sdaremark1"].ToString();
            return shuadan_accountExample;
        }
        #endregion





        #endregion
    }
   
    




}

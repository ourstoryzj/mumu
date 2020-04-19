using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql
{


    public class lh_rankinglistService : Ilh_rankinglistService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<lh_rankinglist> SearchAll()
        {
            DBHelper.sqlstr = "select * from lh_rankinglist ";
            List<lh_rankinglist> list = new List<lh_rankinglist>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                lh_rankinglist Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据rid,查询一条数据
        /// </summary>
        /// <param name="rid">排行榜id</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public lh_rankinglist SearchByID(int rid)
        {
            DBHelper.sqlstr = "select * from lh_rankinglist where rid = @rid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@rid",rid)
            };
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            lh_rankinglist Obj = null;
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
        /// <param name="lh_rankinglist">lh_rankinglist表实例</param>
        /// <returns>int</returns>
        public int Insert(lh_rankinglist lh_rankinglistExample)
        {
            DBHelper.sqlstr = "insert into  lh_rankinglist (rkey,rstate,rdate,hid,hremark)values(@rkey,@rstate,@rdate,@hid,@hremark)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(lh_rankinglistExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="lh_rankinglist">lh_rankinglist表实例</param>
        /// <returns>int</returns>
        public int Update(lh_rankinglist lh_rankinglistExample)
        {
            DBHelper.sqlstr = "update lh_rankinglist set rkey=@rkey,rstate=@rstate,rdate=@rdate,hid=@hid,hremark=@hremark where rid=" + lh_rankinglistExample.rid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(lh_rankinglistExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="rid">排行榜id</param>
        /// <returns>int</returns>
        public int Delete(int rid)
        {
            DBHelper.sqlstr = "delete lh_rankinglist where rid =@rid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@rid",rid)
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
            string sql1 = "select count(rid) from lh_rankinglist where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( rkey like '%" + key + "%' or rstate like '%" + key + "%' or hremark like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and rstate= '" + state + "' ";//状态字段，无用删除
            string sql4 = id == 0 ? "" : " and hid='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',rdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',rdate)<=0 ";//时间字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6;
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
        /// <returns>IList<lh_rankinglist></returns>
        public IList<lh_rankinglist> Search(int s, int e, string key, string state, int id, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select * from lh_rankinglist where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( rkey like '%" + key + "%' or rstate like '%" + key + "%' or hremark like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and rstate= '" + state + "' ";//状态字段，无用删除
            string sql4 = id == 0 ? "" : " and hid='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',rdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',rdate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by rid desc " : " order by " + orderby;
            //string sql8 = s == 1 ? "" : " and rid not in ( select top " + (s - 1).ToString() + " rid from lh_rankinglist where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + " ) ";
            string sql9 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6  + sql7+ sql9;
            List<lh_rankinglist> list = new List<lh_rankinglist>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                lh_rankinglist Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion


        #region DeleteByHid
        /// <summary>
        /// 根据行业删除关键词
        /// </summary>
        /// <param name="rid">排行榜id</param>
        /// <returns>int</returns>
        public int DeleteByHid(int hid)
        {
            DBHelper.sqlstr = "delete lh_rankinglist where hid =@hid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@hid",hid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion



        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个MySqlParameter数组
        /// </summary>
        /// <returns>MySqlParameter[]</returns>
        public static MySqlParameter[] GetSqlParameters(lh_rankinglist lh_rankinglistExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(lh_rankinglistExample.rkey))
            {
                list_param.Add(new MySqlParameter("@rkey", lh_rankinglistExample.rkey));
            }
            else
            {
                list_param.Add(new MySqlParameter("@rkey", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_rankinglistExample.rstate))
            {
                list_param.Add(new MySqlParameter("@rstate", lh_rankinglistExample.rstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@rstate", DBNull.Value));
            }
            if (lh_rankinglistExample.rdate != new DateTime() && lh_rankinglistExample.rdate != null)
            {
                list_param.Add(new MySqlParameter("@rdate", lh_rankinglistExample.rdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@rdate", DBNull.Value));
            }
            if (lh_rankinglistExample.hid != 0)
            {
                list_param.Add(new MySqlParameter("@hid", lh_rankinglistExample.hid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@hid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_rankinglistExample.hremark))
            {
                list_param.Add(new MySqlParameter("@hremark", lh_rankinglistExample.hremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@hremark", DBNull.Value));
            }
            MySqlParameter[] param = new MySqlParameter[list_param.Count];
            int index = 0;
            foreach (MySqlParameter p in list_param)
            {
                param[index] = p;
                index++;
            }
            return param;
        }
        #endregion

        #region GetByReader
        /// <summary>
        /// 从一个MySqlDataReader里读数据
        /// </summary>
        /// <param name="Reader">MySqlDataReader</param>
        /// <returns>lh_rankinglistExample</returns>
        public static lh_rankinglist GetByReader(MySqlDataReader Reader)
        {
            lh_rankinglist lh_rankinglistExample = new lh_rankinglist();
            lh_rankinglistExample.rid = Reader["rid"] == DBNull.Value ? 0 : (int)Reader["rid"];
            lh_rankinglistExample.rkey = Reader["rkey"] == DBNull.Value ? null : Reader["rkey"].ToString();
            lh_rankinglistExample.rstate = Reader["rstate"] == DBNull.Value ? null : Reader["rstate"].ToString();
            lh_rankinglistExample.rdate = Reader["rdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["rdate"]);
            lh_rankinglistExample.hid = Reader["hid"] == DBNull.Value ? 0 : (int)Reader["hid"];
            lh_rankinglistExample.hremark = Reader["hremark"] == DBNull.Value ? null : Reader["hremark"].ToString();
            return lh_rankinglistExample;
        }
        #endregion





        #endregion
    }
    
   







}

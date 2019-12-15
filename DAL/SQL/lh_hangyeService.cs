using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{


    public class lh_hangyeService : Ilh_hangyeService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<lh_hangye> SearchAll()
        {
            DBHelper.sqlstr = "select * from lh_hangye ";
            List<lh_hangye> list = new List<lh_hangye>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                lh_hangye Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据hid,查询一条数据
        /// </summary>
        /// <param name="hid">行业ID</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public lh_hangye SearchByID(int hid)
        {
            DBHelper.sqlstr = "select * from lh_hangye where hid = @hid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@hid",hid)
            };
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            lh_hangye Obj = null;
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
        /// <param name="lh_hangye">lh_hangye表实例</param>
        /// <returns>int</returns>
        public int Insert(lh_hangye lh_hangyeExample)
        {
            DBHelper.sqlstr = "insert into  lh_hangye (hname,hstate,hdate,hremark)values(@hname,@hstate,@hdate,@hremark)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(lh_hangyeExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="lh_hangye">lh_hangye表实例</param>
        /// <returns>int</returns>
        public int Update(lh_hangye lh_hangyeExample)
        {
            DBHelper.sqlstr = "update lh_hangye set hname=@hname,hstate=@hstate,hdate=@hdate,hremark=@hremark where hid=" + lh_hangyeExample.hid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(lh_hangyeExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="hid">行业ID</param>
        /// <returns>int</returns>
        public int Delete(int hid)
        {
            DBHelper.sqlstr = "delete lh_hangye where hid =@hid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@hid",hid)
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
        public int SearchNum(string key, string state,  DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(hid) from lh_hangye where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( hname like '%" + key + "%' or hstate like '%" + key + "%' or hremark like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and hstate= '" + state + "' ";//状态字段，无用删除
            //string sql4 = id == 0 ? "" : " and id字段='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',hdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',hdate)<=0 ";//时间字段，无用删除
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
        /// <returns>IList<lh_hangye></returns>
        public IList<lh_hangye> Search(int s, int e, string key, string state,  DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select top " + (e - s + 1).ToString() + " * from lh_hangye where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( hname like '%" + key + "%' or hstate like '%" + key + "%' or hremark like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and hstate= '" + state + "' ";//状态字段，无用删除
            //string sql4 = id == 0 ? "" : " and id字段='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',hdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',hdate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by hid desc " : " order by " + orderby;
            string sql8 = s == 1 ? "" : " and hid not in ( select top " + (s - 1).ToString() + " hid from lh_hangye where " + sql2 + sql3  + sql5 + sql6 + sql7 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql5 + sql6 + sql8 + sql7;
            List<lh_hangye> list = new List<lh_hangye>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                lh_hangye Obj = GetByReader(reader);
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
        public static SqlParameter[] GetSqlParameters(lh_hangye lh_hangyeExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(lh_hangyeExample.hname))
            {
                list_param.Add(new SqlParameter("@hname", lh_hangyeExample.hname));
            }
            else
            {
                list_param.Add(new SqlParameter("@hname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_hangyeExample.hstate))
            {
                list_param.Add(new SqlParameter("@hstate", lh_hangyeExample.hstate));
            }
            else
            {
                list_param.Add(new SqlParameter("@hstate", DBNull.Value));
            }
            if (lh_hangyeExample.hdate != new DateTime() && lh_hangyeExample.hdate != null)
            {
                list_param.Add(new SqlParameter("@hdate", lh_hangyeExample.hdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@hdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_hangyeExample.hremark))
            {
                list_param.Add(new SqlParameter("@hremark", lh_hangyeExample.hremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@hremark", DBNull.Value));
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
        /// <returns>lh_hangyeExample</returns>
        public static lh_hangye GetByReader(SqlDataReader Reader)
        {
            lh_hangye lh_hangyeExample = new lh_hangye();
            lh_hangyeExample.hid = Reader["hid"] == DBNull.Value ? 0 : (int)Reader["hid"];
            lh_hangyeExample.hname = Reader["hname"] == DBNull.Value ? null : Reader["hname"].ToString();
            lh_hangyeExample.hstate = Reader["hstate"] == DBNull.Value ? null : Reader["hstate"].ToString();
            lh_hangyeExample.hdate = Reader["hdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["hdate"]);
            lh_hangyeExample.hremark = Reader["hremark"] == DBNull.Value ? null : Reader["hremark"].ToString();
            return lh_hangyeExample;
        }
        #endregion





        #endregion
    }
    
   










}

using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql
{



    public class yh_zaociService : Iyh_zaociService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<yh_zaoci> SearchAll()
        {
            DBHelper.sqlstr = "select * from yh_zaoci ";
            List<yh_zaoci> list = new List<yh_zaoci>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                yh_zaoci Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据zid,查询一条数据
        /// </summary>
        /// <param name="zid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public yh_zaoci SearchByID(int zid)
        {
            DBHelper.sqlstr = "select * from yh_zaoci where zid = @zid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@zid",zid)
            };
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            yh_zaoci Obj = null;
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
        /// <param name="yh_zaoci">yh_zaoci表实例</param>
        /// <returns>int</returns>
        public int Insert(yh_zaoci yh_zaociExample)
        {
            DBHelper.sqlstr = "insert into  yh_zaoci (zname,zdate,zstate,gtid,gtname,zsort)values(@zname,@zdate,@zstate,@gtid,@gtname,@zsort)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(yh_zaociExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_zaoci">yh_zaoci表实例</param>
        /// <returns>int</returns>
        public int Update(yh_zaoci yh_zaociExample)
        {
            DBHelper.sqlstr = "update yh_zaoci set zname=@zname,zdate=@zdate,zstate=@zstate,gtid=@gtid,gtname=@gtname,zsort=@zsort where zid=" + yh_zaociExample.zid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(yh_zaociExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="zid">编号</param>
        /// <returns>int</returns>
        public int Delete(int zid)
        {
            DBHelper.sqlstr = "delete yh_zaoci where zid =@zid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@zid",zid)
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
            string sql1 = "select count(zid) from yh_zaoci where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( zname like '%" + key + "%' or zstate like '%" + key + "%' or gtname like '%" + key + "%' )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and zstate= '" + state + "' ";//状态字段，无用删除
            string sql4 = " and gtid='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',zdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',zdate)<=0 ";//时间字段，无用删除
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
        /// <returns>IList<yh_zaoci></returns>
        public IList<yh_zaoci> Search(int s, int e, string key, string state, int id, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select * from yh_zaoci where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( zname like '%" + key + "%' or zstate like '%" + key + "%' or gtname like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and zstate= '" + state + "' ";//状态字段，无用删除
            string sql4 = " and gtid='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',zdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',zdate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by zsort asc " : " order by " + orderby;
            //string sql8 = s == 1 ? "" : " and zid not in ( select top " + (s - 1).ToString() + " zid from yh_zaoci where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + " ) ";
            string sql10 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7+ sql10 ;
            List<yh_zaoci> list = new List<yh_zaoci>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                yh_zaoci Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion





        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个MySqlParameter数组
        /// </summary>
        /// <returns>MySqlParameter[]</returns>
        public static MySqlParameter[] GetSqlParameters(yh_zaoci yh_zaociExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(yh_zaociExample.zname))
            {
                list_param.Add(new MySqlParameter("@zname", yh_zaociExample.zname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@zname", DBNull.Value));
            }
            if (yh_zaociExample.zdate != new DateTime() && yh_zaociExample.zdate != null)
            {
                list_param.Add(new MySqlParameter("@zdate", yh_zaociExample.zdate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@zdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_zaociExample.zstate))
            {
                list_param.Add(new MySqlParameter("@zstate", yh_zaociExample.zstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@zstate", DBNull.Value));
            }
            //if (yh_zaociExample.gtid != 0)
            //{
            list_param.Add(new MySqlParameter("@gtid", yh_zaociExample.gtid));
            //}
            //else
            //{
            //    list_param.Add(new MySqlParameter("@gtid", DBNull.Value));
            //}

            if (!string.IsNullOrEmpty(yh_zaociExample.gtname))
            {
                list_param.Add(new MySqlParameter("@gtname", yh_zaociExample.gtname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gtname", DBNull.Value));
            }
            if (yh_zaociExample.zsort != 0)
            {
                list_param.Add(new MySqlParameter("@zsort", yh_zaociExample.zsort));
            }
            else
            {
                list_param.Add(new MySqlParameter("@zsort", DBNull.Value));
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
        /// <returns>yh_zaociExample</returns>
        public static yh_zaoci GetByReader(MySqlDataReader Reader)
        {
            yh_zaoci yh_zaociExample = new yh_zaoci();
            yh_zaociExample.zid = Reader["zid"] == DBNull.Value ? 0 : (int)Reader["zid"];
            yh_zaociExample.zname = Reader["zname"] == DBNull.Value ? null : Reader["zname"].ToString();
            yh_zaociExample.zdate = Reader["zdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["zdate"]);
            yh_zaociExample.zstate = Reader["zstate"] == DBNull.Value ? null : Reader["zstate"].ToString();
            yh_zaociExample.gtid = Reader["gtid"] == DBNull.Value ? 0 : (int)Reader["gtid"];
            yh_zaociExample.gtname = Reader["gtname"] == DBNull.Value ? null : Reader["gtname"].ToString();
            yh_zaociExample.zsort = Reader["zsort"] == DBNull.Value ? 0 : (int)Reader["zsort"];
            return yh_zaociExample;
        }
        #endregion





        #endregion
    }









}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{




    //表名称：yh_zaoci
    //实体类名称：yh_zaociExample
    //主键：zid



    public class basic_taskService : Ibasic_taskService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<basic_task> SearchAll()
        {
            DBHelper.sqlstr = "select * from basic_task ";
            List<basic_task> list = new List<basic_task>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_task Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据btid,查询一条数据
        /// </summary>
        /// <param name="btid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public basic_task SearchByID(int btid)
        {
            DBHelper.sqlstr = "select * from basic_task where btid = @btid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@btid",btid)
            };
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            basic_task Obj = null;
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
        /// <param name="basic_task">basic_task表实例</param>
        /// <returns>int</returns>
        public int Insert(basic_task basic_taskExample)
        {
            DBHelper.sqlstr = "insert into  basic_task (btname,btcontent,btstate,btdate,btdate2,btspare1,btspare2,btspare3,btspare4,btspare5)values(@btname,@btcontent,@btstate,@btdate,@btdate2,@btspare1,@btspare2,@btspare3,@btspare4,@btspare5)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_taskExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_task">basic_task表实例</param>
        /// <returns>int</returns>
        public int Update(basic_task basic_taskExample)
        {
            DBHelper.sqlstr = "update basic_task set btname=@btname,btcontent=@btcontent,btstate=@btstate,btdate=@btdate,btdate2=@btdate2,btspare1=@btspare1,btspare2=@btspare2,btspare3=@btspare3,btspare4=@btspare4,btspare5=@btspare5 where btid=" + basic_taskExample.btid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_taskExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="btid">编号</param>
        /// <returns>int</returns>
        public int Delete(int btid)
        {
            DBHelper.sqlstr = "delete basic_task where btid =@btid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@btid",btid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="opid">订单计划编号</param>
        /// <param name="hdid">活动编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="state">状态</param>
        /// <param name="bgkey">是否重点</param>
        /// <param name="dt1_up">上架时间</param>
        /// <param name="dt2_up">上架时间</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <returns></returns>
        public int SearchNum(string key, string state, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add)
        {
            string sql1 = "select count(btid) from basic_task where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  btname like '%" + key + "%' or  btcontent     like '%" + key + "%' or  btspare1     like '%" + key + "%' or  btspare2     like '%" + key + "%'  or  btspare3     like '%" + key + "%'  or  btspare4     like '%" + key + "%'  or  btspare5     like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and btstate= '" + state + "' ";
            string sql4 = dt1_up == new DateTime() ? "" : " and datediff(day,'" + dt1_up.ToString("yyyy/MM/dd") + "',btdate)>=0 ";
            string sql5 = dt2_up == new DateTime() ? "" : " and datediff(day,'" + dt2_up.ToString("yyyy/MM/dd") + "',btdate)<=0 ";
            string sql6 = dt1_add == new DateTime() ? "" : " and datediff(day,'" + dt1_add.ToString("yyyy/MM/dd") + "',btdate2)>=0 ";
            string sql7 = dt2_add == new DateTime() ? "" : " and datediff(day,'" + dt2_add.ToString("yyyy/MM/dd") + "',btdate2)<=0 ";

            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7;

            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="s">开始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="opid">补单计划编号</param>
        /// <param name="hdid">活动编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="state">状态 1是 2否</param>
        /// <param name="bgkey">知否重点 1是 2否</param>
        /// <param name="dt1_up">上架时间</param>
        /// <param name="dt2_up">上架时间2</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间2</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_goods></returns>
        public IList<basic_task> Search(int s, int e, string key, string state, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            string sql1 = "select   top " + (e - s + 1).ToString() + " *    from basic_task where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  btname like '%" + key + "%' or  btcontent     like '%" + key + "%' or  btspare1     like '%" + key + "%' or  btspare2     like '%" + key + "%'  or  btspare3     like '%" + key + "%'  or  btspare4     like '%" + key + "%'  or  btspare5     like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and btstate= '" + state + "' ";
            string sql4 = dt1_up == new DateTime() ? "" : " and datediff(day,'" + dt1_up.ToString("yyyy/MM/dd") + "',btdate)>=0 ";
            string sql5 = dt2_up == new DateTime() ? "" : " and datediff(day,'" + dt2_up.ToString("yyyy/MM/dd") + "',btdate)<=0 ";
            string sql6 = dt1_add == new DateTime() ? "" : " and datediff(day,'" + dt1_add.ToString("yyyy/MM/dd") + "',btdate2)>=0 ";
            string sql7 = dt2_add == new DateTime() ? "" : " and datediff(day,'" + dt2_add.ToString("yyyy/MM/dd") + "',btdate2)<=0 ";
            string sql12 = string.IsNullOrEmpty(orderby) ? " order by  btdate2 desc " : " order by " + orderby;
            string sql13 = s == 1 ? "" : " and btid not in ( select top " + (s - 1).ToString() + " btid from basic_task where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql12 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql13 + sql12;
            List<basic_task> list = new List<basic_task>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_task Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region Search
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="s">开始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="opid">补单计划编号</param>
        /// <param name="hdid">活动编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="state">状态 1是 2否</param>
        /// <param name="chongfu">是否重复每日每月每年</param>
        /// <param name="dt1_up">上架时间</param>
        /// <param name="dt2_up">上架时间2</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间2</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_goods></returns>
        public IList<basic_task> Search(int s, int e, string key, string state, string chongfu, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            string sql1 = "select   top " + (e - s + 1).ToString() + " *    from basic_task where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  btname like '%" + key + "%' or  btcontent     like '%" + key + "%' or  btspare1     like '%" + key + "%' or  btspare2     like '%" + key + "%'  or  btspare3     like '%" + key + "%'  or  btspare4     like '%" + key + "%'  or  btspare5     like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and btstate= '" + state + "' ";
            string sql99 = string.IsNullOrEmpty(chongfu) ? "" : " and btspare1= '" + chongfu + "' ";
            string sql4 = dt1_up == new DateTime() ? "" : " and datediff(day,'" + dt1_up.ToString("yyyy/MM/dd") + "',btdate)>=0 ";
            string sql5 = dt2_up == new DateTime() ? "" : " and datediff(day,'" + dt2_up.ToString("yyyy/MM/dd") + "',btdate)<=0 ";
            string sql6 = dt1_add == new DateTime() ? "" : " and datediff(day,'" + dt1_add.ToString("yyyy/MM/dd") + "',btdate2)>=0 ";
            string sql7 = dt2_add == new DateTime() ? "" : " and datediff(day,'" + dt2_add.ToString("yyyy/MM/dd") + "',btdate2)<=0 ";
            string sql12 = string.IsNullOrEmpty(orderby) ? " order by  btdate2 desc " : " order by " + orderby;
            string sql13 = s == 1 ? "" : " and btid not in ( select top " + (s - 1).ToString() + " btid from basic_task where " + sql2 + sql3 + sql99 + sql4 + sql5 + sql6 + sql7 + sql12 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql99 + sql4 + sql5 + sql6 + sql7 + sql13 + sql12;
            List<basic_task> list = new List<basic_task>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_task Obj = GetByReader(reader);
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
        public static SqlParameter[] GetSqlParameters(basic_task basic_taskExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(basic_taskExample.btname))
            {
                list_param.Add(new SqlParameter("@btname", basic_taskExample.btname));
            }
            else
            {
                list_param.Add(new SqlParameter("@btname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_taskExample.btcontent))
            {
                list_param.Add(new SqlParameter("@btcontent", basic_taskExample.btcontent));
            }
            else
            {
                list_param.Add(new SqlParameter("@btcontent", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_taskExample.btstate))
            {
                list_param.Add(new SqlParameter("@btstate", basic_taskExample.btstate));
            }
            else
            {
                list_param.Add(new SqlParameter("@btstate", DBNull.Value));
            }
            if (basic_taskExample.btdate != new DateTime() && basic_taskExample.btdate != null)
            {
                list_param.Add(new SqlParameter("@btdate", basic_taskExample.btdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@btdate", DBNull.Value));
            }
            if (basic_taskExample.btdate2 != new DateTime() && basic_taskExample.btdate2 != null)
            {
                list_param.Add(new SqlParameter("@btdate2", basic_taskExample.btdate2.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@btdate2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_taskExample.btspare1))
            {
                list_param.Add(new SqlParameter("@btspare1", basic_taskExample.btspare1));
            }
            else
            {
                list_param.Add(new SqlParameter("@btspare1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_taskExample.btspare2))
            {
                list_param.Add(new SqlParameter("@btspare2", basic_taskExample.btspare2));
            }
            else
            {
                list_param.Add(new SqlParameter("@btspare2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_taskExample.btspare3))
            {
                list_param.Add(new SqlParameter("@btspare3", basic_taskExample.btspare3));
            }
            else
            {
                list_param.Add(new SqlParameter("@btspare3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_taskExample.btspare4))
            {
                list_param.Add(new SqlParameter("@btspare4", basic_taskExample.btspare4));
            }
            else
            {
                list_param.Add(new SqlParameter("@btspare4", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_taskExample.btspare5))
            {
                list_param.Add(new SqlParameter("@btspare5", basic_taskExample.btspare5));
            }
            else
            {
                list_param.Add(new SqlParameter("@btspare5", DBNull.Value));
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
        /// <returns>basic_taskExample</returns>
        public static basic_task GetByReader(SqlDataReader Reader)
        {
            basic_task basic_taskExample = new basic_task();
            basic_taskExample.btid = Reader["btid"] == DBNull.Value ? 0 : (int)Reader["btid"];
            basic_taskExample.btname = Reader["btname"] == DBNull.Value ? null : Reader["btname"].ToString();
            basic_taskExample.btcontent = Reader["btcontent"] == DBNull.Value ? null : Reader["btcontent"].ToString();
            basic_taskExample.btstate = Reader["btstate"] == DBNull.Value ? null : Reader["btstate"].ToString();
            basic_taskExample.btdate = Reader["btdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["btdate"]);
            basic_taskExample.btdate2 = Reader["btdate2"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["btdate2"]);
            basic_taskExample.btspare1 = Reader["btspare1"] == DBNull.Value ? null : Reader["btspare1"].ToString();
            basic_taskExample.btspare2 = Reader["btspare2"] == DBNull.Value ? null : Reader["btspare2"].ToString();
            basic_taskExample.btspare3 = Reader["btspare3"] == DBNull.Value ? null : Reader["btspare3"].ToString();
            basic_taskExample.btspare4 = Reader["btspare4"] == DBNull.Value ? null : Reader["btspare4"].ToString();
            basic_taskExample.btspare5 = Reader["btspare5"] == DBNull.Value ? null : Reader["btspare5"].ToString();
            return basic_taskExample;
        }
        #endregion





        #endregion
    }








}

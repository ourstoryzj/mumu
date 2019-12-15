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



    public class basic_goodsService : Ibasic_goodsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<basic_goods> SearchAll()
        {
            DBHelper.sqlstr = "select * from basic_goods ";
            List<basic_goods> list = new List<basic_goods>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_goods Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据bgid,查询一条数据
        /// </summary>
        /// <param name="bgid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public basic_goods SearchByID(int bgid)
        {
            DBHelper.sqlstr = "select * from basic_goods where bgid = @bgid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@bgid",bgid)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            basic_goods Obj = null;
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
        /// <param name="basic_goods">basic_goods表实例</param>
        /// <returns>int</returns>
        public int Insert(basic_goods basic_goodsExample)
        {
            DBHelper.sqlstr = "insert into  basic_goods (bgname,bgurl,bgupdate,opid,hdid,dpid,dpname,bgstate,bgdate,bgremark,bgkey)values(@bgname,@bgurl,@bgupdate,@opid,@hdid,@dpid,@dpname,@bgstate,@bgdate,@bgremark,@bgkey)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_goodsExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_goods">basic_goods表实例</param>
        /// <returns>int</returns>
        public int Update(basic_goods basic_goodsExample)
        {
            DBHelper.sqlstr = "update basic_goods set bgname=@bgname,bgurl=@bgurl,bgupdate=@bgupdate,opid=@opid,hdid=@hdid,dpid=@dpid,dpname=@dpname,bgstate=@bgstate,bgdate=@bgdate,bgremark=@bgremark,bgkey=@bgkey where bgid=" + basic_goodsExample.bgid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_goodsExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bgid">编号</param>
        /// <returns>int</returns>
        public int Delete(int bgid)
        {
            DBHelper.sqlstr = "delete basic_goods where bgid =@bgid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@bgid",bgid)
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
        public int SearchNum(string key, int opid, int hdid, int dpid, string state, string bgkey, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add)
        {
            string sql1 = "select count(bgid) from basic_goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  bgname like '%" + key + "%' or  bgurl like '%" + key + "%' or  dpname like '%" + key + "%' or  bgremark like '%" + key + "%'   ) ";
            string sql3 = opid == 0 ? "" : " and opid=" + opid.ToString();
            string sql4 = hdid == 0 ? "" : " and hdid=" + hdid.ToString();
            string sql5 = dpid == 0 ? "" : " and dpid=" + dpid.ToString();
            string sql6 = string.IsNullOrEmpty(state) ? "" : " and bgstate= '" + state + "' ";
            string sql7 = string.IsNullOrEmpty(bgkey) ? "" : " and bgkey= '" + bgkey + "' ";
            string sql8 = dt1_up == new DateTime() ? "" : " and datediff(d,'" + dt1_up.ToString() + "',bgupdate)>=0 ";
            string sql9 = dt2_up == new DateTime() ? "" : " and datediff(d,'" + dt2_up.ToString() + "',bgupdate)<=0 ";
            string sql10 = dt1_add == new DateTime() ? "" : " and datediff(d,'" + dt1_add.ToString() + "',bgdate)>=0 ";
            string sql11 = dt2_add == new DateTime() ? "" : " and datediff(d,'" + dt2_add.ToString() + "',bgdate)<=0 ";

            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + sql9 + sql10 + sql11;

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
        public IList<basic_goods> Search(int s, int e, string key, int opid, int hdid, int dpid, string state, string bgkey, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            string sql1 = "select  top " + (e - s + 1).ToString() + " *   from basic_goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  bgname like '%" + key + "%' or  bgurl like '%" + key + "%' or  dpname like '%" + key + "%' or  bgremark like '%" + key + "%'   ) ";
            string sql3 = opid == 0 ? "" : " and opid=" + opid.ToString();
            string sql4 = hdid == 0 ? "" : " and hdid=" + hdid.ToString();
            string sql5 = dpid == 0 ? "" : " and dpid=" + dpid.ToString();
            string sql6 = string.IsNullOrEmpty(state) ? "" : " and bgstate= '" + state + "' ";
            string sql7 = string.IsNullOrEmpty(bgkey) ? "" : " and bgkey= '" + bgkey + "' ";
            string sql8 = dt1_up == new DateTime() ? "" : " and datediff(d,'" + dt1_up.ToString() + "',bgupdate)>=0 ";
            string sql9 = dt2_up == new DateTime() ? "" : " and datediff(d,'" + dt2_up.ToString() + "',bgupdate)<=0 ";
            string sql10 = dt1_add == new DateTime() ? "" : " and datediff(d,'" + dt1_add.ToString() + "',bgdate)>=0 ";
            string sql11 = dt2_add == new DateTime() ? "" : " and datediff(d,'" + dt2_add.ToString() + "',bgdate)<=0 ";
            string sql12 = string.IsNullOrEmpty(orderby) ? " order by bgkey asc,bgdate desc " : " order by " + orderby;
            string sql13 = s == 1 ? "" : " and bgid not in ( select top " + (s - 1).ToString() + " bgid from basic_goods where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql8 + sql7 + sql9 + sql10 + sql11 + sql12 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + sql9 + sql10 + sql11 + sql13 + sql12;
            List<basic_goods> list = new List<basic_goods>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_goods Obj = GetByReader(reader);
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
        public static SqlParameter[] GetSqlParameters(basic_goods basic_goodsExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(basic_goodsExample.bgname))
            {
                list_param.Add(new SqlParameter("@bgname", basic_goodsExample.bgname));
            }
            else
            {
                list_param.Add(new SqlParameter("@bgname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_goodsExample.bgurl))
            {
                list_param.Add(new SqlParameter("@bgurl", basic_goodsExample.bgurl));
            }
            else
            {
                list_param.Add(new SqlParameter("@bgurl", DBNull.Value));
            }
            if (basic_goodsExample.bgupdate != new DateTime() && basic_goodsExample.bgupdate != null)
            {
                list_param.Add(new SqlParameter("@bgupdate", basic_goodsExample.bgupdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@bgupdate", DBNull.Value));
            }
            if (basic_goodsExample.opid != 0)
            {
                list_param.Add(new SqlParameter("@opid", basic_goodsExample.opid));
            }
            else
            {
                list_param.Add(new SqlParameter("@opid", DBNull.Value));
            }
            if (basic_goodsExample.hdid != 0)
            {
                list_param.Add(new SqlParameter("@hdid", basic_goodsExample.hdid));
            }
            else
            {
                list_param.Add(new SqlParameter("@hdid", DBNull.Value));
            }
            if (basic_goodsExample.dpid != 0)
            {
                list_param.Add(new SqlParameter("@dpid", basic_goodsExample.dpid));
            }
            else
            {
                list_param.Add(new SqlParameter("@dpid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_goodsExample.dpname))
            {
                list_param.Add(new SqlParameter("@dpname", basic_goodsExample.dpname));
            }
            else
            {
                list_param.Add(new SqlParameter("@dpname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_goodsExample.bgstate))
            {
                list_param.Add(new SqlParameter("@bgstate", basic_goodsExample.bgstate));
            }
            else
            {
                list_param.Add(new SqlParameter("@bgstate", DBNull.Value));
            }
            if (basic_goodsExample.bgdate != new DateTime() && basic_goodsExample.bgdate != null)
            {
                list_param.Add(new SqlParameter("@bgdate", basic_goodsExample.bgdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@bgdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_goodsExample.bgremark))
            {
                list_param.Add(new SqlParameter("@bgremark", basic_goodsExample.bgremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@bgremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_goodsExample.bgkey))
            {
                list_param.Add(new SqlParameter("@bgkey", basic_goodsExample.bgkey));
            }
            else
            {
                list_param.Add(new SqlParameter("@bgkey", DBNull.Value));
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
        /// <returns>basic_goodsExample</returns>
        public static basic_goods GetByReader(SqlDataReader Reader)
        {
            basic_goods basic_goodsExample = new basic_goods();
            basic_goodsExample.bgid = Reader["bgid"] == DBNull.Value ? 0 : (int)Reader["bgid"];
            basic_goodsExample.bgname = Reader["bgname"] == DBNull.Value ? null : Reader["bgname"].ToString();
            basic_goodsExample.bgurl = Reader["bgurl"] == DBNull.Value ? null : Reader["bgurl"].ToString();
            basic_goodsExample.bgupdate = Reader["bgupdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["bgupdate"]);
            basic_goodsExample.opid = Reader["opid"] == DBNull.Value ? 0 : (int)Reader["opid"];
            basic_goodsExample.hdid = Reader["hdid"] == DBNull.Value ? 0 : (int)Reader["hdid"];
            basic_goodsExample.dpid = Reader["dpid"] == DBNull.Value ? 0 : (int)Reader["dpid"];
            basic_goodsExample.dpname = Reader["dpname"] == DBNull.Value ? null : Reader["dpname"].ToString();
            basic_goodsExample.bgstate = Reader["bgstate"] == DBNull.Value ? null : Reader["bgstate"].ToString();
            basic_goodsExample.bgdate = Reader["bgdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["bgdate"]);
            basic_goodsExample.bgremark = Reader["bgremark"] == DBNull.Value ? null : Reader["bgremark"].ToString();
            basic_goodsExample.bgkey = Reader["bgkey"] == DBNull.Value ? null : Reader["bgkey"].ToString();
            return basic_goodsExample;
        }
        #endregion





        #endregion
    }







}

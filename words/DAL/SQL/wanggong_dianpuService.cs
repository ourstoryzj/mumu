using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{



    public class wanggong_dianpuService : Iwanggong_dianpuService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<wanggong_dianpu> SearchAll()
        {
            DBHelper.sqlstr = "select * from wanggong_dianpu ";
            List<wanggong_dianpu> list = new List<wanggong_dianpu>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                wanggong_dianpu Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据wid,查询一条数据
        /// </summary>
        /// <param name="wid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public wanggong_dianpu SearchByID(int wid)
        {
            DBHelper.sqlstr = "select * from wanggong_dianpu where wid = @wid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@wid",wid)
            };
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            wanggong_dianpu Obj = null;
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
        /// <param name="wanggong_dianpu">wanggong_dianpu表实例</param>
        /// <returns>int</returns>
        public int Insert(wanggong_dianpu wanggong_dianpuExample)
        {
            DBHelper.sqlstr = "insert into  wanggong_dianpu (wdpname,wdTBID,wdcollectdate,wdwangwang,wdstate,wdremark1,wdremark2,wdremark3,wdremark4)values(@wdpname,@wdTBID,@wdcollectdate,@wdwangwang,@wdstate,@wdremark1,@wdremark2,@wdremark3,@wdremark4)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(wanggong_dianpuExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="wanggong_dianpu">wanggong_dianpu表实例</param>
        /// <returns>int</returns>
        public int Update(wanggong_dianpu wanggong_dianpuExample)
        {
            DBHelper.sqlstr = "update wanggong_dianpu set wdpname=@wdpname,wdTBID=@wdTBID,wdcollectdate=@wdcollectdate,wdwangwang=@wdwangwang,wdstate=@wdstate,wdremark1=@wdremark1,wdremark2=@wdremark2,wdremark3=@wdremark3,wdremark4=@wdremark4 where wid=" + wanggong_dianpuExample.wid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(wanggong_dianpuExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="wid">编号</param>
        /// <returns>int</returns>
        public int Delete(int wid)
        {
            DBHelper.sqlstr = "delete wanggong_dianpu where wid =@wid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@wid",wid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public int SearchNum(string key, string state, DateTime begin, DateTime end)
        {
            string sql1 = "select count(wid) from wanggong_dianpu where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( wdpname  like '%" + key + "%' or  wdTBID like '%" + key + "%' or  wdwangwang like '%" + key + "%'  or  wdremark1  like '%" + key + "%' or  wdremark2  like '%" + key + "%'or  wdremark3  like '%" + key + "%'or  wdremark4  like '%" + key + "%' ) ";
            DBHelper.sqlstr = sql1 + sql2;
            string sql3 = string.IsNullOrEmpty(state) ? " " : " and wdstate='" + state + "' ";
            string sql4 = begin == new DateTime() ? "" : " and datediff(d,'" + begin.ToString("yyyy-MM-dd") + "',wdcollectdate)>=0 ";
            string sql5 = end == new DateTime() ? "" : " and datediff(d,'" + end.ToString("yyyy-MM-dd") + "',wdcollectdate)<=0 ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5;
            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 高级搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="orderby">排序方式</param>
        /// <returns></returns>
        public IList<wanggong_dianpu> Search(int s, int e, string key, string state, DateTime begin, DateTime end, string orderby)
        {
            string sql1 = "select  top " + (e - s + 1).ToString() + " *   from wanggong_dianpu where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( wdpname  like '%" + key + "%' or  wdTBID like '%" + key + "%' or  wdwangwang like '%" + key + "%'  or  wdremark1  like '%" + key + "%' or  wdremark2  like '%" + key + "%'or  wdremark3  like '%" + key + "%'or  wdremark4  like '%" + key + "%' ) ";
            DBHelper.sqlstr = sql1 + sql2;
            string sql3 = string.IsNullOrEmpty(state) ? " " : " and wdstate='" + state + "' ";
            string sql4 = begin == new DateTime() ? "" : " and datediff(d,'" + begin.ToString("yyyy-MM-dd") + "',wdcollectdate)>=0 ";
            string sql5 = end == new DateTime() ? "" : " and datediff(d,'" + end.ToString("yyyy-MM-dd") + "',wdcollectdate)<=0 ";
            string sql6 = string.IsNullOrEmpty(orderby) ? " order by wdcollectdate desc " : " order by " + orderby;
            string sql7 = s == 1 ? "" : " and wid not in ( select top " + (s - 1).ToString() + " wid from wanggong_dianpu where " + sql2 + sql3 + sql4 + sql5 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql4 + sql3;
            List<wanggong_dianpu> list = new List<wanggong_dianpu>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                wanggong_dianpu Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchLastOne
        /// <summary>
        /// 查询时间排序最后一条店铺信息
        /// </summary>
        /// <returns></returns>
        public wanggong_dianpu SearchLastOne()
        {
            DBHelper.sqlstr = "SELECT TOP 1 * FROM wanggong_dianpu ORDER BY wdcollectdate desc";

            SqlDataReader reader = DBHelper.ExecuteReader();
            wanggong_dianpu Obj = null;
            if (reader.Read())
            {
                Obj = GetByReader(reader);
            }
            reader.Close();
            return Obj;
        }
        #endregion


        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameters(wanggong_dianpu wanggong_dianpuExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(wanggong_dianpuExample.wdpname))
            {
                list_param.Add(new SqlParameter("@wdpname", wanggong_dianpuExample.wdpname));
            }
            else
            {
                list_param.Add(new SqlParameter("@wdpname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_dianpuExample.wdTBID))
            {
                list_param.Add(new SqlParameter("@wdTBID", wanggong_dianpuExample.wdTBID));
            }
            else
            {
                list_param.Add(new SqlParameter("@wdTBID", DBNull.Value));
            }
            if (wanggong_dianpuExample.wdcollectdate != new DateTime() && wanggong_dianpuExample.wdcollectdate != null)
            {
                list_param.Add(new SqlParameter("@wdcollectdate", wanggong_dianpuExample.wdcollectdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@wdcollectdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_dianpuExample.wdwangwang))
            {
                list_param.Add(new SqlParameter("@wdwangwang", wanggong_dianpuExample.wdwangwang));
            }
            else
            {
                list_param.Add(new SqlParameter("@wdwangwang", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_dianpuExample.wdstate))
            {
                list_param.Add(new SqlParameter("@wdstate", wanggong_dianpuExample.wdstate));
            }
            else
            {
                list_param.Add(new SqlParameter("@wdstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_dianpuExample.wdremark1))
            {
                list_param.Add(new SqlParameter("@wdremark1", wanggong_dianpuExample.wdremark1));
            }
            else
            {
                list_param.Add(new SqlParameter("@wdremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_dianpuExample.wdremark2))
            {
                list_param.Add(new SqlParameter("@wdremark2", wanggong_dianpuExample.wdremark2));
            }
            else
            {
                list_param.Add(new SqlParameter("@wdremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_dianpuExample.wdremark3))
            {
                list_param.Add(new SqlParameter("@wdremark3", wanggong_dianpuExample.wdremark3));
            }
            else
            {
                list_param.Add(new SqlParameter("@wdremark3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_dianpuExample.wdremark4))
            {
                list_param.Add(new SqlParameter("@wdremark4", wanggong_dianpuExample.wdremark4));
            }
            else
            {
                list_param.Add(new SqlParameter("@wdremark4", DBNull.Value));
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
        /// <returns>wanggong_dianpuExample</returns>
        public static wanggong_dianpu GetByReader(SqlDataReader Reader)
        {
            wanggong_dianpu wanggong_dianpuExample = new wanggong_dianpu();
            wanggong_dianpuExample.wid = Reader["wid"] == DBNull.Value ? 0 : (int)Reader["wid"];
            wanggong_dianpuExample.wdpname = Reader["wdpname"] == DBNull.Value ? null : Reader["wdpname"].ToString();
            wanggong_dianpuExample.wdTBID = Reader["wdTBID"] == DBNull.Value ? null : Reader["wdTBID"].ToString();
            wanggong_dianpuExample.wdcollectdate = Reader["wdcollectdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["wdcollectdate"]);
            wanggong_dianpuExample.wdwangwang = Reader["wdwangwang"] == DBNull.Value ? null : Reader["wdwangwang"].ToString();
            wanggong_dianpuExample.wdstate = Reader["wdstate"] == DBNull.Value ? null : Reader["wdstate"].ToString();
            wanggong_dianpuExample.wdremark1 = Reader["wdremark1"] == DBNull.Value ? null : Reader["wdremark1"].ToString();
            wanggong_dianpuExample.wdremark2 = Reader["wdremark2"] == DBNull.Value ? null : Reader["wdremark2"].ToString();
            wanggong_dianpuExample.wdremark3 = Reader["wdremark3"] == DBNull.Value ? null : Reader["wdremark3"].ToString();
            wanggong_dianpuExample.wdremark4 = Reader["wdremark4"] == DBNull.Value ? null : Reader["wdremark4"].ToString();
            return wanggong_dianpuExample;
        }
        #endregion





        #endregion
    }










}

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




    public class basic_goods_wordService : Ibasic_goods_wordService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<basic_goods_word> SearchAll()
        {
            DBHelper.sqlstr = "select * from basic_goods_word ";
            List<basic_goods_word> list = new List<basic_goods_word>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_goods_word Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据gwid,查询一条数据
        /// </summary>
        /// <param name="gwid">补单关键词编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public basic_goods_word SearchByID(int gwid)
        {
            DBHelper.sqlstr = "select * from basic_goods_word where gwid = @gwid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@gwid",gwid)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            basic_goods_word Obj = null;
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
        /// <param name="basic_goods_word">basic_goods_word表实例</param>
        /// <returns>int</returns>
        public int Insert(basic_goods_word basic_goods_wordExample)
        {
            DBHelper.sqlstr = "insert into  basic_goods_word (gwname,bgid,bgname,gwdate,gwnum,gwstate,gwremark)values(@gwname,@bgid,@bgname,@gwdate,@gwnum,@gwstate,@gwremark)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_goods_wordExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_goods_word">basic_goods_word表实例</param>
        /// <returns>int</returns>
        public int Update(basic_goods_word basic_goods_wordExample)
        {
            DBHelper.sqlstr = "update basic_goods_word set gwname=@gwname,bgid=@bgid,bgname=@bgname,gwdate=@gwdate,gwnum=@gwnum,gwstate=@gwstate,gwremark=@gwremark where gwid=" + basic_goods_wordExample.gwid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_goods_wordExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gwid">补单关键词编号</param>
        /// <returns>int</returns>
        public int Delete(int gwid)
        {
            DBHelper.sqlstr = "delete basic_goods_word where gwid =@gwid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@gwid",gwid)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="bgid">商品编号</param>
        /// <param name="state">状态</param>
        /// <param name="bgkey">是否重点</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <returns>int</returns>
        public int SearchNum(string key, int bgid, string state, string bgkey, DateTime dt1_add, DateTime dt2_add)
        {
            string sql1 = "select count(gwid) from basic_goods_word where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  gwname like '%" + key + "%' or  bgname like '%" + key + "%' or  gwremark like '%" + key + "%'  ) ";
            string sql3 = bgid == 0 ? "" : " and bgid=" + bgid.ToString();
            string sql4 = string.IsNullOrEmpty(state) ? "" : " and gwstate= '" + state + "' ";
            string sql5 = dt1_add == new DateTime() ? "" : " and datediff(d,'" + dt1_add.ToString() + "',gwdate)>=0 ";
            string sql6 = dt2_add == new DateTime() ? "" : " and datediff(d,'" + dt2_add.ToString() + "',gwdate)<=0 ";

            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6;

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
        /// <param name="bgid">商品编号</param>
        /// <param name="state">状态</param>
        /// <param name="bgkey">是否重点</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_goods_word></returns>
        public IList<basic_goods_word> Search(int s, int e, string key, int bgid, string state, string bgkey, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            string sql1 = "select  top " + (e - s + 1).ToString() + " *   from basic_goods_word where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  gwname like '%" + key + "%' or  bgname like '%" + key + "%' or  gwremark like '%" + key + "%'  ) ";
            string sql3 = bgid == 0 ? "" : " and bgid=" + bgid.ToString();
            string sql4 = string.IsNullOrEmpty(state) ? "" : " and gwstate= '" + state + "' ";
            string sql5 = dt1_add == new DateTime() ? "" : " and datediff(d,'" + dt1_add.ToString() + "',gwdate)>=0 ";
            string sql6 = dt2_add == new DateTime() ? "" : " and datediff(d,'" + dt2_add.ToString() + "',gwdate)<=0 ";
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by gwdate desc " : " order by " + orderby;
            string sql8 = s == 1 ? "" : " and gwid not in ( select top " + (s - 1).ToString() + " gwid from basic_goods_word where " + sql2 + sql3 + sql4 + sql5 + sql6 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql8 + sql7;
            List<basic_goods_word> list = new List<basic_goods_word>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_goods_word Obj = GetByReader(reader);
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
        public static SqlParameter[] GetSqlParameters(basic_goods_word basic_goods_wordExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(basic_goods_wordExample.gwname))
            {
                list_param.Add(new SqlParameter("@gwname", basic_goods_wordExample.gwname));
            }
            else
            {
                list_param.Add(new SqlParameter("@gwname", DBNull.Value));
            }
            if (basic_goods_wordExample.bgid != 0)
            {
                list_param.Add(new SqlParameter("@bgid", basic_goods_wordExample.bgid));
            }
            else
            {
                list_param.Add(new SqlParameter("@bgid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_goods_wordExample.bgname))
            {
                list_param.Add(new SqlParameter("@bgname", basic_goods_wordExample.bgname));
            }
            else
            {
                list_param.Add(new SqlParameter("@bgname", DBNull.Value));
            }
            if (basic_goods_wordExample.gwdate != new DateTime() && basic_goods_wordExample.gwdate != null)
            {
                list_param.Add(new SqlParameter("@gwdate", basic_goods_wordExample.gwdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@gwdate", DBNull.Value));
            }
            if (basic_goods_wordExample.gwnum != 0)
            {
                list_param.Add(new SqlParameter("@gwnum", basic_goods_wordExample.gwnum));
            }
            else
            {
                list_param.Add(new SqlParameter("@gwnum", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_goods_wordExample.gwstate))
            {
                list_param.Add(new SqlParameter("@gwstate", basic_goods_wordExample.gwstate));
            }
            else
            {
                list_param.Add(new SqlParameter("@gwstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_goods_wordExample.gwremark))
            {
                list_param.Add(new SqlParameter("@gwremark", basic_goods_wordExample.gwremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@gwremark", DBNull.Value));
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
        /// <returns>basic_goods_wordExample</returns>
        public static basic_goods_word GetByReader(SqlDataReader Reader)
        {
            basic_goods_word basic_goods_wordExample = new basic_goods_word();
            basic_goods_wordExample.gwid = Reader["gwid"] == DBNull.Value ? 0 : (int)Reader["gwid"];
            basic_goods_wordExample.gwname = Reader["gwname"] == DBNull.Value ? null : Reader["gwname"].ToString();
            basic_goods_wordExample.bgid = Reader["bgid"] == DBNull.Value ? 0 : (int)Reader["bgid"];
            basic_goods_wordExample.bgname = Reader["bgname"] == DBNull.Value ? null : Reader["bgname"].ToString();
            basic_goods_wordExample.gwdate = Reader["gwdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["gwdate"]);
            basic_goods_wordExample.gwnum = Reader["gwnum"] == DBNull.Value ? 0 : (int)Reader["gwnum"];
            basic_goods_wordExample.gwstate = Reader["gwstate"] == DBNull.Value ? null : Reader["gwstate"].ToString();
            basic_goods_wordExample.gwremark = Reader["gwremark"] == DBNull.Value ? null : Reader["gwremark"].ToString();
            return basic_goods_wordExample;
        }
        #endregion





        #endregion
    }





}

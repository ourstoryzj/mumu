using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
{




    //表名称：yh_zaoci
    //实体类名称：yh_zaociExample
    //主键：zid

    public class yh_zaociService 
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<yh_zaoci> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from yh_zaoci ";
            List<yh_zaoci> list = new List<yh_zaoci>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                yh_zaoci Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByzid
        /// <summary>
        /// 根据zid,查询一条数据
        /// </summary>
        /// <param name="zid">噪词ID</param>
        /// <returns></returns>
        public yh_zaoci SearchByzid(int zid)
        {
            Access.DBHelper.sqlstr = "select * from yh_zaoci where zid = @zid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@zid",zid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
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
            Access.DBHelper.sqlstr = "insert into  yh_zaoci (gtid,gtname,zdate,zname,zstate)values(@gtid,@gtname,'" + yh_zaociExample.zdate.ToString() + "',@zname,@zstate)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(yh_zaociExample));
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
            Access.DBHelper.sqlstr = "update yh_zaoci set gtid=@gtid,gtname=@gtname,zdate='" + yh_zaociExample.zdate.ToString() + "',zname=@zname,zstate=@zstate where zid=" + yh_zaociExample.zid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(yh_zaociExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="zid">噪词ID</param>
        /// <returns>int</returns>
        public int Delete(int zid)
        {
            Access.DBHelper.sqlstr = "delete from yh_zaoci where zid =@zid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@zid",zid)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
        }
        #endregion


        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state">状态 空:不查,1:启用,2:禁用</param>
        /// <param name="dt1_add">添加商品起始时间</param>
        /// <param name="dt2_add">添加商品结束时间</param>
        /// <returns>int</returns>
        public int SearchNum(string key, int gt, string state, DateTime dt1_add, DateTime dt2_add)
        {
            string sql1 = "select count(zid) from yh_zaoci where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  zname like '%" + key + "%' or  gtname like '%" + key + "%'   ) ";
            string sql3 = gt == 0 ? "" : " and gtid=" + gt.ToString();
            string sql4 = string.IsNullOrEmpty(state) ? "" : " and zstate= '" + state + "' ";
            string sql5 = dt1_add == new DateTime() ? "" : " and datediff('d','" + dt1_add.ToString() + "',zdate)>=0 ";
            string sql6 = dt2_add == new DateTime() ? "" : " and datediff('d','" + dt2_add.ToString() + "',zdate)<=0 ";
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6;

            return Convert.ToInt32(Access.DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 条件搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state">状态 空:不查,1:启用,2:禁用</param>
        /// <param name="dt1_add">添加起始时间</param>
        /// <param name="dt2_add">添加结束时间</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<yh_zaoci></returns>
        public IList<yh_zaoci> Search(int s, int e, string key, int gt, string state, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            string sql1 = "select  top " + (e - s + 1).ToString() + " *   from yh_zaoci where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  zname like '%" + key + "%' or  gtname like '%" + key + "%'   ) ";
            string sql3 = gt == 0 ? "" : " and gtid=" + gt.ToString();
            string sql4 = string.IsNullOrEmpty(state) ? "" : " and zstate= '" + state + "' ";
            string sql5 = dt1_add == new DateTime() ? "" : " and datediff('d','" + dt1_add.ToString() + "',zdate)>=0 ";
            string sql6 = dt2_add == new DateTime() ? "" : " and datediff('d','" + dt2_add.ToString() + "',zdate)<=0 ";
            string sql8 = string.IsNullOrEmpty(orderby) ? " order by zdate desc,zid asc " : " order by " + orderby;
            string sql7 = s == 1 ? "" : " and zid not in ( select top " + (s - 1).ToString() + " zid from yh_zaoci where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql8 + " ) ";
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8;
            List<yh_zaoci> list = new List<yh_zaoci>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
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

        #region GetOleDbParameter
        /// <summary>
        /// 根据表,获取一个OleDbParameter数组
        /// </summary>
        /// <returns>OleDbParameter[]</returns>
        public static OleDbParameter[] GetOleDbParameter(yh_zaoci yh_zaociExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();
            if (yh_zaociExample.gtid != 0)
            {
                list_param.Add(new OleDbParameter("@gtid", yh_zaociExample.gtid));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gtid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_zaociExample.gtname))
            {
                list_param.Add(new OleDbParameter("@gtname", yh_zaociExample.gtname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gtname", DBNull.Value));
            }
            if (yh_zaociExample.zdate != new DateTime() && yh_zaociExample.zdate != null)
            {
                list_param.Add(new OleDbParameter("@zdate", yh_zaociExample.zdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new OleDbParameter("@zdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_zaociExample.zname))
            {
                list_param.Add(new OleDbParameter("@zname", yh_zaociExample.zname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@zname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_zaociExample.zstate))
            {
                list_param.Add(new OleDbParameter("@zstate", yh_zaociExample.zstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@zstate", DBNull.Value));
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
        /// <returns>yh_zaociExample</returns>
        public static yh_zaoci GetByReader(OleDbDataReader Reader)
        {
            yh_zaoci yh_zaociExample = new yh_zaoci();
            yh_zaociExample.gtid = Reader["gtid"] == DBNull.Value ? 0 : (int)Reader["gtid"];
            yh_zaociExample.gtname = Reader["gtname"] == DBNull.Value ? null : Reader["gtname"].ToString();
            yh_zaociExample.zdate = Reader["zdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["zdate"]);
            yh_zaociExample.zid = Reader["zid"] == DBNull.Value ? 0 : (int)Reader["zid"];
            yh_zaociExample.zname = Reader["zname"] == DBNull.Value ? null : Reader["zname"].ToString();
            yh_zaociExample.zstate = Reader["zstate"] == DBNull.Value ? null : Reader["zstate"].ToString();
            return yh_zaociExample;
        }
        #endregion





        #endregion
    }







}

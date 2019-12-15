using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{


    public class subway_goodsService : Isubway_goodsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<subway_goods> SearchAll()
        {
            DBHelper.sqlstr = "select * from subway_goods ";
            List<subway_goods> list = new List<subway_goods>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                subway_goods Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据sgid,查询一条数据
        /// </summary>
        /// <param name="sgid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public subway_goods SearchByID(int sgid)
        {
            DBHelper.sqlstr = "select * from subway_goods where sgid = @sgid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@sgid",sgid)
            };
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            subway_goods Obj = null;
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
        /// 插入方法2
        /// </summary>
        /// <param name="subway_goods">subway_goods表实例</param>
        /// <returns>int</returns>
        public int Insert(subway_goods subway_goodsExample)
        {
            DBHelper.sqlstr = "insert into  subway_goods (sgcampaignid,sgname,sgremark,sgdate,sgstate,sgremark2)values(@sgcampaignid,@sgname,@sgremark,@sgdate,@sgstate,@sgremark2)";
            //DBHelper.sqlstr = "insert into  subway_goods (sgcampaignid,sgname,sgremark,sgdate,sgstate,sgremark2)values(@sgcampaignid,@sgname,@sgremark,'" + subway_goodsExample.sgdate.ToString() + "',@sgstate,@sgremark2)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(subway_goodsExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="subway_goods">subway_goods表实例</param>
        /// <returns>int</returns>
        public int Update(subway_goods subway_goodsExample)
        {
            //DBHelper.sqlstr = "update subway_goods set sgcampaignid=@sgcampaignid,sgname=@sgname,sgremark=@sgremark,sgdate='" + subway_goodsExample.sgdate.ToString() + "',sgstate=@sgstate,sgremark2=@sgremark2 where sgid=" + subway_goodsExample.sgid;
            DBHelper.sqlstr = "update subway_goods set sgcampaignid=@sgcampaignid,sgname=@sgname,sgremark=@sgremark,sgdate=@sgdate,sgstate=@sgstate,sgremark2=@sgremark2 where sgid=" + subway_goodsExample.sgid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(subway_goodsExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sgid">编号</param>
        /// <returns>int</returns>
        public int Delete(int sgid)
        {
            DBHelper.sqlstr = "delete subway_goods where sgid =@sgid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@sgid",sgid)
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
        public int SearchNum(string key, string state, string sgcampaignid, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(sgid) from subway_goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( sgcampaignid like '%" + key + "%' or sgname like '%" + key + "%' or sgremark like '%" + key + "%' or sgstate like '%" + key + "%' or sgremark2 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sgstate= '" + state + "' ";//状态字段，无用删除
            string sql4 = string.IsNullOrEmpty(sgcampaignid) ? "" : " and sgcampaignid= '" + sgcampaignid + "' ";//状态字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',sgdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',sgdate)<=0 ";//时间字段，无用删除
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
        /// <returns>IList<subway_goods></returns>
        public IList<subway_goods> Search(int s, int e, string key, string state, string sgcampaignid, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select top " + (e - s + 1).ToString() + " * from subway_goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( sgcampaignid like '%" + key + "%' or sgname like '%" + key + "%' or sgremark like '%" + key + "%' or sgstate like '%" + key + "%' or sgremark2 like '%" + key + "%'   )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sgstate= '" + state + "' ";//状态字段，无用删除
            string sql4 = string.IsNullOrEmpty(sgcampaignid) ? "" : " and sgcampaignid= '" + sgcampaignid + "' ";//状态字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',sgdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',sgdate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by sgid desc " : " order by " + orderby;
            string sql8 = s == 1 ? "" : " and sgid not in ( select top " + (s - 1).ToString() + " sgid from subway_goods where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql8 + sql7;
            List<subway_goods> list = new List<subway_goods>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                subway_goods Obj = GetByReader(reader);
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
        public static SqlParameter[] GetSqlParameters(subway_goods subway_goodsExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(subway_goodsExample.sgcampaignid))
            {
                list_param.Add(new SqlParameter("@sgcampaignid", subway_goodsExample.sgcampaignid));
            }
            else
            {
                list_param.Add(new SqlParameter("@sgcampaignid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_goodsExample.sgname))
            {
                list_param.Add(new SqlParameter("@sgname", subway_goodsExample.sgname));
            }
            else
            {
                list_param.Add(new SqlParameter("@sgname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_goodsExample.sgremark))
            {
                list_param.Add(new SqlParameter("@sgremark", subway_goodsExample.sgremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@sgremark", DBNull.Value));
            }
            if (subway_goodsExample.sgdate != new DateTime() && subway_goodsExample.sgdate != null)
            {
                list_param.Add(new SqlParameter("@sgdate", subway_goodsExample.sgdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@sgdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_goodsExample.sgstate))
            {
                list_param.Add(new SqlParameter("@sgstate", subway_goodsExample.sgstate));
            }
            else
            {
                list_param.Add(new SqlParameter("@sgstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_goodsExample.sgremark2))
            {
                list_param.Add(new SqlParameter("@sgremark2", subway_goodsExample.sgremark2));
            }
            else
            {
                list_param.Add(new SqlParameter("@sgremark2", DBNull.Value));
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
        /// <returns>subway_goodsExample</returns>
        public static subway_goods GetByReader(SqlDataReader Reader)
        {
            subway_goods subway_goodsExample = new subway_goods();
            subway_goodsExample.sgid = Reader["sgid"] == DBNull.Value ? 0 : (int)Reader["sgid"];
            subway_goodsExample.sgcampaignid = Reader["sgcampaignid"] == DBNull.Value ? null : Reader["sgcampaignid"].ToString();
            subway_goodsExample.sgname = Reader["sgname"] == DBNull.Value ? null : Reader["sgname"].ToString();
            subway_goodsExample.sgremark = Reader["sgremark"] == DBNull.Value ? null : Reader["sgremark"].ToString();
            subway_goodsExample.sgdate = Reader["sgdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sgdate"]);
            subway_goodsExample.sgstate = Reader["sgstate"] == DBNull.Value ? null : Reader["sgstate"].ToString();
            subway_goodsExample.sgremark2 = Reader["sgremark2"] == DBNull.Value ? null : Reader["sgremark2"].ToString();
            return subway_goodsExample;
        }
        #endregion





        #endregion
    }











}

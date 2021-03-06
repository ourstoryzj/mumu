﻿using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{




    //表名称：fanxian
    //实体类名称：fanxianExample
    //主键：fx_id

    public class fanxianService 
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<fanxian> SearchAll()
        {
            DBHelper.sqlstr = "select * from fanxian where fx_state='1' order by fx_date desc ";
            List<fanxian> list = new List<fanxian>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                fanxian Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByfx_id
        /// <summary>
        /// 根据fx_id,查询一条数据
        /// </summary>
        /// <param name="fx_id"></param>
        /// <returns></returns>
        public fanxian SearchByfx_id(int fx_id)
        {
            DBHelper.sqlstr = "select * from fanxian where fx_id = @fx_id";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@fx_id",fx_id)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            fanxian Obj = null;
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
        /// <param name="fanxian">fanxian表实例</param>
        /// <returns>int</returns>
        public int Insert(fanxian fanxianExample)
        {
            DBHelper.sqlstr = "insert into  fanxian (dpid,fx_account,fx_date,fx_date2,fx_num,fx_remark,fx_state,fx_zhifubao)values(@dpid,@fx_account,'" + fanxianExample.fx_date.ToString() + "','" + fanxianExample.fx_date2.ToString() + "',fx_num,@fx_remark,@fx_state,@fx_zhifubao)";
            return DBHelper.ExecuteNonQuery(GetSqlParameter(fanxianExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="fanxian">fanxian表实例</param>
        /// <returns>int</returns>
        public int Update(fanxian fanxianExample)
        {
            DBHelper.sqlstr = "update fanxian set dpid=@dpid,fx_account=@fx_account,fx_date='" + fanxianExample.fx_date.ToString() + "',fx_date2='" + fanxianExample.fx_date2.ToString() + "',fx_num=@fx_num,fx_remark=@fx_remark,fx_state=@fx_state,fx_zhifubao=@fx_zhifubao where fx_id=" + fanxianExample.fx_id;
            return DBHelper.ExecuteNonQuery(GetSqlParameter(fanxianExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fx_id"></param>
        /// <returns>int</returns>
        public int Delete(int fx_id)
        {
            DBHelper.sqlstr = "delete from fanxian where fx_id =@fx_id";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@fx_id",fx_id)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public int SearchNum(string key, string state, int dpid, DateTime startdate, DateTime enddate, DateTime startdate2, DateTime enddate2)
        {
            string sql1 = "select count(fx_id) from fanxian where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  fx_account like '%" + key + "%' or  fx_remark like '%" + key + "%' or  fx_zhifubao like '%" + key + "%' or  fx_num like '" + key + "' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and fx_state= '" + state + "' ";
            string sql9 = dpid == 0 ? "" : " and dpid='" + dpid.ToString() + "' ";
            string sql4 = startdate == new DateTime() ? "" : " and datediff(d,'" + startdate.ToString() + "',fx_date)>=0 ";
            string sql5 = enddate == new DateTime() ? "" : " and datediff(d,'" + enddate.ToString() + "',fx_date)<=0 ";
            string sql6 = startdate2 == new DateTime() ? "" : " and datediff(d,'" + startdate2.ToString() + "',fx_date2)>=0 ";
            string sql7 = enddate2 == new DateTime() ? "" : " and datediff(d,'" + enddate2.ToString() + "',fx_date2)<=0 ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql9;
            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public IList<fanxian> Search(int s, int e, string key, string state, int dpid, DateTime startdate, DateTime enddate, DateTime startdate2, DateTime enddate2, string orderby)
        {
            string sql1 = "select top " + (e - s + 1).ToString() + " * from fanxian where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  fx_account like '%" + key + "%' or  fx_remark like '%" + key + "%' or  fx_zhifubao like '%" + key + "%'  or  fx_num like '" + key + "' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and fx_state= '" + state + "' ";
            string sql9 = dpid == 0 ? "" : " and dpid='" + dpid.ToString() + "' ";
            string sql4 = startdate == new DateTime() ? "" : " and datediff(d,'" + startdate.ToString() + "',fx_date)>=0 ";
            string sql5 = enddate == new DateTime() ? "" : " and datediff(d,'" + enddate.ToString() + "',fx_date)<=0 ";
            string sql6 = startdate2 == new DateTime() ? "" : " and datediff(d,'" + startdate2.ToString() + "',fx_date2)>=0 ";
            string sql7 = enddate2 == new DateTime() ? "" : " and datediff(d,'" + enddate2.ToString() + "',fx_date2)<=0 ";
            string sql8 = string.IsNullOrEmpty(orderby) ? " order by fx_date desc " : " order by " + orderby;
            string sql10 = s == 1 ? "" : " and fx_id not in ( select top " + (s - 1).ToString() + " fx_id from fanxian where " + sql2 + sql3 + sql4 + sql5 + sql7 + sql9 + sql8 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql9 + sql4 + sql5 + sql6 + sql7 + sql9 + sql10 + sql8;
            List<fanxian> list = new List<fanxian>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                fanxian Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion


        #region 公共方法

        #region GetSqlParameter
        /// <summary>
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameter(fanxian fanxianExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(fanxianExample.dpid))
            {
                list_param.Add(new SqlParameter("@dpid", fanxianExample.dpid));
            }
            else
            {
                list_param.Add(new SqlParameter("@dpid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(fanxianExample.fx_account))
            {
                list_param.Add(new SqlParameter("@fx_account", fanxianExample.fx_account));
            }
            else
            {
                list_param.Add(new SqlParameter("@fx_account", DBNull.Value));
            }
            if (fanxianExample.fx_date != new DateTime() && fanxianExample.fx_date != null)
            {
                list_param.Add(new SqlParameter("@fx_date", fanxianExample.fx_date.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@fx_date", DBNull.Value));
            }
            if (fanxianExample.fx_date2 != new DateTime() && fanxianExample.fx_date2 != null)
            {
                list_param.Add(new SqlParameter("@fx_date2", fanxianExample.fx_date2.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@fx_date2", DBNull.Value));
            }
            if (fanxianExample.fx_num != new decimal())
            {
                list_param.Add(new SqlParameter("@fx_num", fanxianExample.fx_num));
            }
            else
            {
                list_param.Add(new SqlParameter("@fx_num", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(fanxianExample.fx_remark))
            {
                list_param.Add(new SqlParameter("@fx_remark", fanxianExample.fx_remark));
            }
            else
            {
                list_param.Add(new SqlParameter("@fx_remark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(fanxianExample.fx_state))
            {
                list_param.Add(new SqlParameter("@fx_state", fanxianExample.fx_state));
            }
            else
            {
                list_param.Add(new SqlParameter("@fx_state", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(fanxianExample.fx_zhifubao))
            {
                list_param.Add(new SqlParameter("@fx_zhifubao", fanxianExample.fx_zhifubao));
            }
            else
            {
                list_param.Add(new SqlParameter("@fx_zhifubao", DBNull.Value));
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
        /// <returns>fanxianExample</returns>
        public static fanxian GetByReader(SqlDataReader Reader)
        {
            fanxian fanxianExample = new fanxian();
            fanxianExample.dpid = Reader["dpid"] == DBNull.Value ? null : Reader["dpid"].ToString();
            fanxianExample.fx_account = Reader["fx_account"] == DBNull.Value ? null : Reader["fx_account"].ToString();
            fanxianExample.fx_date = Reader["fx_date"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["fx_date"]);
            fanxianExample.fx_date2 = Reader["fx_date2"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["fx_date2"]);
            fanxianExample.fx_id = Reader["fx_id"] == DBNull.Value ? 0 : (int)Reader["fx_id"];
            fanxianExample.fx_num = Reader["fx_num"] == DBNull.Value ? 0 : Convert.ToDecimal(Reader["fx_num"]);
            fanxianExample.fx_remark = Reader["fx_remark"] == DBNull.Value ? null : Reader["fx_remark"].ToString();
            fanxianExample.fx_state = Reader["fx_state"] == DBNull.Value ? null : Reader["fx_state"].ToString();
            fanxianExample.fx_zhifubao = Reader["fx_zhifubao"] == DBNull.Value ? null : Reader["fx_zhifubao"].ToString();
            return fanxianExample;
        }
        #endregion





        #endregion
    }


}

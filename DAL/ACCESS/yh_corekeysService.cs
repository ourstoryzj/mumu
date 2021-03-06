﻿using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
{




    //表名称：yh_corekeys
    //实体类名称：yh_corekeysExample
    //主键：ckid

    public class yh_corekeysService : Iyh_corekeysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<yh_corekeys> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from yh_corekeys  order by cksort asc,ckdate desc ";
            List<yh_corekeys> list = new List<yh_corekeys>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                yh_corekeys Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByckid
        /// <summary>
        /// 根据ckid,查询一条数据
        /// </summary>
        /// <param name="ckid">核心关键词ID</param>
        /// <returns></returns>
        public yh_corekeys SearchByckid(int ckid)
        {
            Access.DBHelper.sqlstr = "select * from yh_corekeys where ckid = @ckid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@ckid",ckid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            yh_corekeys Obj = null;
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
        /// <param name="yh_corekeys">yh_corekeys表实例</param>
        /// <returns>int</returns>
        public int Insert(yh_corekeys yh_corekeysExample)
        {
            Access.DBHelper.sqlstr = "insert into  yh_corekeys (ckdate,ckname,ckremark,cksort,ckstate,gtid)values('" + yh_corekeysExample.ckdate.ToString() + "',@ckname,@ckremark,@cksort,@ckstate,@gtid)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(yh_corekeysExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_corekeys">yh_corekeys表实例</param>
        /// <returns>int</returns>
        public int Update(yh_corekeys yh_corekeysExample)
        {
            Access.DBHelper.sqlstr = "update yh_corekeys set ckdate='" + yh_corekeysExample.ckdate.ToString() + "',ckname=@ckname,ckremark=@ckremark,cksort=@cksort,ckstate=@ckstate,gtid=@gtid where ckid=" + yh_corekeysExample.ckid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(yh_corekeysExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ckid">核心关键词ID</param>
        /// <returns>int</returns>
        public int Delete(int ckid)
        {
            Access.DBHelper.sqlstr = "delete from yh_corekeys where ckid =@ckid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@ckid",ckid)
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
            string sql1 = "select count(ckid) from yh_corekeys where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  ckname like '%" + key + "%' or  ckremark like '%" + key + "%'   ) ";
            string sql3 = gt == 0 ? "" : " and gtid='" + gt.ToString() + "' ";
            string sql4 = string.IsNullOrEmpty(state) ? "" : " and ckstate= '" + state + "' ";
            string sql5 = dt1_add == new DateTime() ? "" : " and datediff('d','" + dt1_add.ToString() + "',ckdate)>=0 ";
            string sql6 = dt2_add == new DateTime() ? "" : " and datediff('d','" + dt2_add.ToString() + "',ckdate)<=0 ";
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
        /// <param name="dt1_add">添加商品起始时间</param>
        /// <param name="dt2_add">添加商品结束时间</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<goods></returns>
        public IList<yh_corekeys> Search(int s, int e, string key, int gt, string state, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            string sql1 = "select  top " + (e - s + 1).ToString() + " *   from yh_corekeys where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  ckname like '%" + key + "%' or  ckremark like '%" + key + "%'   ) ";
            string sql3 = gt == 0 ? "" : " and gtid='" + gt.ToString() + "' ";
            string sql4 = string.IsNullOrEmpty(state) ? "" : " and ckstate= '" + state + "' ";
            string sql5 = dt1_add == new DateTime() ? "" : " and datediff('d','" + dt1_add.ToString() + "',ckdate)>=0 ";
            string sql6 = dt2_add == new DateTime() ? "" : " and datediff('d','" + dt2_add.ToString() + "',ckdate)<=0 ";
            string sql8 = string.IsNullOrEmpty(orderby) ? " order by cksort asc,ckdate desc " : " order by " + orderby;
            string sql7 = s == 1 ? "" : " and ckid not in ( select top " + (s - 1).ToString() + " ckid from yh_corekeys where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql8 + " ) ";

            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8;
            List<yh_corekeys> list = new List<yh_corekeys>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                yh_corekeys Obj = GetByReader(reader);
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
        public static OleDbParameter[] GetOleDbParameter(yh_corekeys yh_corekeysExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(yh_corekeysExample.ckname))
            {
                list_param.Add(new OleDbParameter("@ckname", yh_corekeysExample.ckname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ckname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_corekeysExample.ckremark))
            {
                list_param.Add(new OleDbParameter("@ckremark", yh_corekeysExample.ckremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ckremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_corekeysExample.cksort))
            {
                list_param.Add(new OleDbParameter("@cksort", yh_corekeysExample.cksort));
            }
            else
            {
                list_param.Add(new OleDbParameter("@cksort", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_corekeysExample.ckstate))
            {
                list_param.Add(new OleDbParameter("@ckstate", yh_corekeysExample.ckstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ckstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_corekeysExample.gtid))
            {
                list_param.Add(new OleDbParameter("@gtid", yh_corekeysExample.gtid));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gtid", DBNull.Value));
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
        /// <returns>yh_corekeysExample</returns>
        public static yh_corekeys GetByReader(OleDbDataReader Reader)
        {
            yh_corekeys yh_corekeysExample = new yh_corekeys();
            yh_corekeysExample.ckdate = Reader["ckdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["ckdate"]);
            yh_corekeysExample.ckid = Reader["ckid"] == DBNull.Value ? 0 : (int)Reader["ckid"];
            yh_corekeysExample.ckname = Reader["ckname"] == DBNull.Value ? null : Reader["ckname"].ToString();
            yh_corekeysExample.ckremark = Reader["ckremark"] == DBNull.Value ? null : Reader["ckremark"].ToString();
            yh_corekeysExample.cksort = Reader["cksort"] == DBNull.Value ? null : Reader["cksort"].ToString();
            yh_corekeysExample.ckstate = Reader["ckstate"] == DBNull.Value ? null : Reader["ckstate"].ToString();
            yh_corekeysExample.gtid = Reader["gtid"] == DBNull.Value ? null : Reader["gtid"].ToString();
            return yh_corekeysExample;
        }
        #endregion





        #endregion
    }

}

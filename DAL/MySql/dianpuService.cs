﻿using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.Mysql
{




    //表名称：dianpu
    //实体类名称：dianpuExample
    //主键：dpid

    public class dianpuService : IdianpuService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<dianpu> SearchAll()
        {
            DBHelper.sqlstr = "select * from dianpu order by dpsort asc ";
            List<dianpu> list = new List<dianpu>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                dianpu Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<dianpu> SearchAll(bool isState)
        {
            DBHelper.sqlstr = "select * from dianpu " + (isState ? " where dpstate = '1' " : "") + " order by dpsort asc ";
            List<dianpu> list = new List<dianpu>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                dianpu Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;

        }
        #endregion

        #region SearchBydpid
        /// <summary>
        /// 根据dpid,查询一条数据
        /// </summary>
        /// <param name="dpid"></param>
        /// <returns></returns>
        public dianpu SearchBydpid(int dpid)
        {
            DBHelper.sqlstr = "select * from dianpu where dpid = @dpid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@dpid",dpid)
            };
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            dianpu Obj = null;
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
        /// <param name="dianpu">dianpu表实例</param>
        /// <returns>int</returns>
        public int Insert(dianpu dianpuExample)
        {
            DBHelper.sqlstr = "insert into  dianpu (dpname,dpremark,dpstate,dpsort,dpaccount,dppwd,dpremark1,dpremark2,dpremark3,dpremark4)values(@dpname,@dpremark,@dpstate,@dpsort,@dpaccount,@dppwd,@dpremark1,@dpremark2,@dpremark3,@dpremark4)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(dianpuExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dianpu">dianpu表实例</param>
        /// <returns>int</returns>
        public int Update(dianpu dianpuExample)
        {
            DBHelper.sqlstr = "update dianpu set dpname=@dpname,dpremark=@dpremark,dpstate=@dpstate,dpsort=@dpsort,dpaccount=@dpaccount,dppwd=@dppwd,dpremark1=@dpremark1,dpremark2=@dpremark2,dpremark3=@dpremark3,dpremark4=@dpremark4 where dpid=" + dianpuExample.dpid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(dianpuExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dpid"></param>
        /// <returns>int</returns>
        public int Delete(int dpid)
        {
            DBHelper.sqlstr = "delete dianpu where dpid =@dpid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@dpid",dpid)
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
        public int SearchNum(string key, string state)
        {
            string sql1 = "select count(dpid) from dianpu where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( dpname like '%" + key + "%' or dpremark like '%" + key + "%' or dpstate like '%" + key + "%' or dpaccount like '%" + key + "%' or dppwd like '%" + key + "%' or dpremark1 like '%" + key + "%' or dpremark2 like '%" + key + "%' or dpremark3 like '%" + key + "%' or dpremark4 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and dpstate= '" + state + "' ";//状态字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3 ;
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
        /// <returns>IList<dianpu></returns>
        public IList<dianpu> Search(int s, int e, string key, string state,  string orderby)
        {
            string sql1 = "select * from dianpu where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( dpname like '%" + key + "%' or dpremark like '%" + key + "%' or dpstate like '%" + key + "%' or dpaccount like '%" + key + "%' or dppwd like '%" + key + "%' or dpremark1 like '%" + key + "%' or dpremark2 like '%" + key + "%' or dpremark3 like '%" + key + "%' or dpremark4 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and dpstate= '" + state + "' ";//状态字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by dpsort asc " : " order by " + orderby;
            string sql8 = s == 1 ? "" : " and dpid not in ( select top " + (s - 1).ToString() + " dpid from dianpu where " + sql2 + sql3 + sql7 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3  + sql8 + sql7;
            List<dianpu> list = new List<dianpu>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                dianpu Obj = GetByReader(reader);
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
        public static MySqlParameter[] GetSqlParameters(dianpu dianpuExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(dianpuExample.dpname))
            {
                list_param.Add(new MySqlParameter("@dpname", dianpuExample.dpname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpremark))
            {
                list_param.Add(new MySqlParameter("@dpremark", dianpuExample.dpremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpstate))
            {
                list_param.Add(new MySqlParameter("@dpstate", dianpuExample.dpstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpstate", DBNull.Value));
            }
            if (dianpuExample.dpsort != 0)
            {
                list_param.Add(new MySqlParameter("@dpsort", dianpuExample.dpsort));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpsort", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpaccount))
            {
                list_param.Add(new MySqlParameter("@dpaccount", dianpuExample.dpaccount));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpaccount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dppwd))
            {
                list_param.Add(new MySqlParameter("@dppwd", dianpuExample.dppwd));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dppwd", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpremark1))
            {
                list_param.Add(new MySqlParameter("@dpremark1", dianpuExample.dpremark1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpremark2))
            {
                list_param.Add(new MySqlParameter("@dpremark2", dianpuExample.dpremark2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpremark3))
            {
                list_param.Add(new MySqlParameter("@dpremark3", dianpuExample.dpremark3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpremark3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpremark4))
            {
                list_param.Add(new MySqlParameter("@dpremark4", dianpuExample.dpremark4));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpremark4", DBNull.Value));
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
        /// <returns>dianpuExample</returns>
        public static dianpu GetByReader(MySqlDataReader Reader)
        {
            dianpu dianpuExample = new dianpu();
            dianpuExample.dpid = Reader["dpid"] == DBNull.Value ? 0 : (int)Reader["dpid"];
            dianpuExample.dpname = Reader["dpname"] == DBNull.Value ? null : Reader["dpname"].ToString();
            dianpuExample.dpremark = Reader["dpremark"] == DBNull.Value ? null : Reader["dpremark"].ToString();
            dianpuExample.dpstate = Reader["dpstate"] == DBNull.Value ? null : Reader["dpstate"].ToString();
            dianpuExample.dpsort = Reader["dpsort"] == DBNull.Value ? 0 : (int)Reader["dpsort"];
            dianpuExample.dpaccount = Reader["dpaccount"] == DBNull.Value ? null : Reader["dpaccount"].ToString();
            dianpuExample.dppwd = Reader["dppwd"] == DBNull.Value ? null : Reader["dppwd"].ToString();
            dianpuExample.dpremark1 = Reader["dpremark1"] == DBNull.Value ? null : Reader["dpremark1"].ToString();
            dianpuExample.dpremark2 = Reader["dpremark2"] == DBNull.Value ? null : Reader["dpremark2"].ToString();
            dianpuExample.dpremark3 = Reader["dpremark3"] == DBNull.Value ? null : Reader["dpremark3"].ToString();
            dianpuExample.dpremark4 = Reader["dpremark4"] == DBNull.Value ? null : Reader["dpremark4"].ToString();
            return dianpuExample;
        }
        #endregion





        #endregion
    }




    
   






}

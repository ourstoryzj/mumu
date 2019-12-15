using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
{




    //表名称：shuadan_pingjia
    //实体类名称：shuadan_pingjiaExample
    //主键：spid

    public class shuadan_pingjiaService : Ishuadan_pingjiaService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_pingjia> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from shuadan_pingjia ";
            List<shuadan_pingjia> list = new List<shuadan_pingjia>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_pingjia Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByspid
        /// <summary>
        /// 根据spid,查询一条数据
        /// </summary>
        /// <param name="spid">编号</param>
        /// <returns></returns>
        public shuadan_pingjia SearchByspid(int spid)
        {
            Access.DBHelper.sqlstr = "select * from shuadan_pingjia where spid = @spid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@spid",spid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            shuadan_pingjia Obj = null;
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
        /// <param name="shuadan_pingjia">shuadan_pingjia表实例</param>
        /// <returns>int</returns>
        public int Insert(shuadan_pingjia shuadan_pingjiaExample)
        {
            Access.DBHelper.sqlstr = "insert into  shuadan_pingjia (spdate,spname,spremark,spstandby1,spstate,sptype)values('" + shuadan_pingjiaExample.spdate.ToString() + "',@spname,@spremark,@spstandby1,@spstate,@sptype)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadan_pingjiaExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_pingjia">shuadan_pingjia表实例</param>
        /// <returns>int</returns>
        public int Update(shuadan_pingjia shuadan_pingjiaExample)
        {
            Access.DBHelper.sqlstr = "update shuadan_pingjia set spdate='" + shuadan_pingjiaExample.spdate.ToString() + "',spname=@spname,spremark=@spremark,spstandby1=@spstandby1,spstate=@spstate,sptype=@sptype where spid=" + shuadan_pingjiaExample.spid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadan_pingjiaExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spid">编号</param>
        /// <returns>int</returns>
        public int Delete(int spid)
        {
            Access.DBHelper.sqlstr = "delete from shuadan_pingjia where spid =@spid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@spid",spid)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 根据条件查询全部数据总条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="date1">起始时间</param>
        /// <param name="date2">结束时间</param>
        /// <returns>int</returns>
        public int SearchNum(string key, string state, string _type, DateTime date1, DateTime date2)
        {
            string sql1 = "select count(spid) from shuadan_pingjia where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  spname like '%" + key + "%' or  spremark like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and spstate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(_type) ? "" : " and sptype= '" + _type + "' ";
            string sql5 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',spdate)>=0 ";
            string sql6 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',spdate)<=0 ";
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6;
            return Convert.ToInt32(Access.DBHelper.ExecuteScalar());
        }
        #endregion


        #region Search
        /// <summary>
        /// 根据条件查询全部数据
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="date1">起始时间</param>
        /// <param name="date2">结束时间</param>
        /// <returns>IList<shuadan_pingjia></returns>
        public IList<shuadan_pingjia> Search(int s, int e, string key, string state, string _type, DateTime date1, DateTime date2, string top)
        {
            //string sql1 = "select top " + e.ToString() + " * from shuadan_pingjia where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  spname like '%" + key + "%' or  spremark like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and spstate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(_type) ? "" : " and sptype= '" + _type + "' ";
            string sql5 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',spdate)>=0 ";
            string sql6 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',spdate)<=0 ";
            string sql7 = " order by spdate asc,spid desc ";//排序两个字段,否则数据容易错误
            string sql1 = "select top " + e.ToString() + " * from " + (string.IsNullOrEmpty(top) ? " shuadan_pingjia where " : " ( select top " + top + " * from shuadan_pingjia where " + sql2 + sql3 + sql4 + sql5 + sql6 + " order by spdate desc,spid asc   ) ") + (string.IsNullOrEmpty(top) ? (sql2 + sql3 + sql4 + sql5 + sql6) : "");
            //DBHelper.sqlstr = "select * from(select top " + (e - s + 1).ToString() + " * from  ( " + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + " order by spdate desc,spid asc ) " + sql7 + ") order by  spdate desc,spid asc ";
            DBHelper.sqlstr = "select top " + (e - s + 1).ToString() + " * from " + "( " + sql1 + " order by spdate desc,spid asc )  order by spdate asc,spid desc ";

            List<shuadan_pingjia> list = new List<shuadan_pingjia>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_pingjia Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchRnd
        /// <summary>
        /// 随机查询名字
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_pingjia> SearchRnd(int num, string key, string state, string _type, DateTime date1, DateTime date2)
        {
            string sql1 = "SELECT top " + num.ToString() + " * FROM shuadan_pingjia where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  spname like '%" + key + "%' or  spremark like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and spstate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(_type) ? "" : " and sptype= '" + _type + "' ";
            string sql5 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',spdate)>=0 ";
            string sql6 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',spdate)<=0 ";
            string sql7 = " order by Rnd(spid) ";//排序两个字段,否则数据容易错误
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7;
            List<shuadan_pingjia> list = new List<shuadan_pingjia>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_pingjia Obj = GetByReader(reader);
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
        public static OleDbParameter[] GetOleDbParameter(shuadan_pingjia shuadan_pingjiaExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(shuadan_pingjiaExample.spname))
            {
                list_param.Add(new OleDbParameter("@spname", shuadan_pingjiaExample.spname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@spname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_pingjiaExample.spremark))
            {
                list_param.Add(new OleDbParameter("@spremark", shuadan_pingjiaExample.spremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@spremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_pingjiaExample.spstandby1))
            {
                list_param.Add(new OleDbParameter("@spstandby1", shuadan_pingjiaExample.spstandby1));
            }
            else
            {
                list_param.Add(new OleDbParameter("@spstandby1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_pingjiaExample.spstate))
            {
                list_param.Add(new OleDbParameter("@spstate", shuadan_pingjiaExample.spstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@spstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_pingjiaExample.sptype))
            {
                list_param.Add(new OleDbParameter("@sptype", shuadan_pingjiaExample.sptype));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sptype", DBNull.Value));
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
        /// <returns>shuadan_pingjiaExample</returns>
        public static shuadan_pingjia GetByReader(OleDbDataReader Reader)
        {
            shuadan_pingjia shuadan_pingjiaExample = new shuadan_pingjia();
            shuadan_pingjiaExample.spdate = Reader["spdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["spdate"]);
            shuadan_pingjiaExample.spid = Reader["spid"] == DBNull.Value ? 0 : (int)Reader["spid"];
            shuadan_pingjiaExample.spname = Reader["spname"] == DBNull.Value ? null : Reader["spname"].ToString();
            shuadan_pingjiaExample.spremark = Reader["spremark"] == DBNull.Value ? null : Reader["spremark"].ToString();
            shuadan_pingjiaExample.spstandby1 = Reader["spstandby1"] == DBNull.Value ? null : Reader["spstandby1"].ToString();
            shuadan_pingjiaExample.spstate = Reader["spstate"] == DBNull.Value ? null : Reader["spstate"].ToString();
            shuadan_pingjiaExample.sptype = Reader["sptype"] == DBNull.Value ? null : Reader["sptype"].ToString();
            return shuadan_pingjiaExample;
        }
        #endregion





        #endregion
    }

















}

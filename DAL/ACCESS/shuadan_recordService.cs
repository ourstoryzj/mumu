using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
{




    //表名称：shuadan_record
    //实体类名称：shuadan_recordExample
    //主键：srid

    public class shuadan_recordService : Ishuadan_recordService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_record> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from shuadan_record ";
            List<shuadan_record> list = new List<shuadan_record>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_record Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBysrid
        /// <summary>
        /// 根据srid,查询一条数据
        /// </summary>
        /// <param name="srid">编号</param>
        /// <returns></returns>
        public shuadan_record SearchBysrid(int srid)
        {
            Access.DBHelper.sqlstr = "select * from shuadan_record where srid = @srid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@srid",srid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            shuadan_record Obj = null;
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
        /// <param name="shuadan_record">shuadan_record表实例</param>
        /// <returns>int</returns>
        public int Insert(shuadan_record shuadan_recordExample)
        {
            Access.DBHelper.sqlstr = "insert into  shuadan_record (srcount,srdate,srname,srnum,srpath,srremark,srstate,srtype)values(@srcount,'" + shuadan_recordExample.srdate.ToString() + "',@srname,@srnum,@srpath,@srremark,@srstate,@srtype)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadan_recordExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_record">shuadan_record表实例</param>
        /// <returns>int</returns>
        public int Update(shuadan_record shuadan_recordExample)
        {
            Access.DBHelper.sqlstr = "update shuadan_record set srcount=@srcount,srdate='" + shuadan_recordExample.srdate.ToString() + "',srname=@srname,srnum=@srnum,srpath=@srpath,srremark=@srremark,srstate=@srstate,srtype=@srtype where srid=" + shuadan_recordExample.srid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadan_recordExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="srid">编号</param>
        /// <returns>int</returns>
        public int Delete(int srid)
        {
            Access.DBHelper.sqlstr = "delete from shuadan_record where srid =@srid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@srid",srid)
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
            string sql1 = "select count(srid) from shuadan_record where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  srname like '%" + key + "%' or  srpath like '%" + key + "%' or  srremark like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and srstate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(_type) ? "" : " and srtype= '" + _type + "' ";
            string sql5 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',srdate)>=0 ";
            string sql6 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',srdate)<=0 ";
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
        /// <returns>IList<shuadan_record></returns>
        public IList<shuadan_record> Search(int s, int e, string key, string state, string _type, DateTime date1, DateTime date2)
        {
            string sql1 = "select top " + e.ToString() + " * from shuadan_record where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  srname like '%" + key + "%' or  srpath like '%" + key + "%' or  srremark like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and srstate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(_type) ? "" : " and srtype= '" + _type + "' ";
            string sql5 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',srdate)>=0 ";
            string sql6 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',srdate)<=0 ";
            string sql7 = " order by srdate asc,srid desc ";//排序两个字段,否则数据容易错误
            DBHelper.sqlstr = "select * from(select top " + (e - s + 1).ToString() + " * from  ( " + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + " order by srdate desc,srid asc ) " + sql7 + ") order by  srdate desc,srid asc ";
            List<shuadan_record> list = new List<shuadan_record>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_record Obj = GetByReader(reader);
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
        public static OleDbParameter[] GetOleDbParameter(shuadan_record shuadan_recordExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();
            if (shuadan_recordExample.srcount != 0)
            {
                list_param.Add(new OleDbParameter("@srcount", shuadan_recordExample.srcount));
            }
            else
            {
                list_param.Add(new OleDbParameter("@srcount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordExample.srname))
            {
                list_param.Add(new OleDbParameter("@srname", shuadan_recordExample.srname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@srname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordExample.srnum))
            {
                list_param.Add(new OleDbParameter("@srnum", shuadan_recordExample.srnum));
            }
            else
            {
                list_param.Add(new OleDbParameter("@srnum", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordExample.srpath))
            {
                list_param.Add(new OleDbParameter("@srpath", shuadan_recordExample.srpath));
            }
            else
            {
                list_param.Add(new OleDbParameter("@srpath", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordExample.srremark))
            {
                list_param.Add(new OleDbParameter("@srremark", shuadan_recordExample.srremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@srremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordExample.srstate))
            {
                list_param.Add(new OleDbParameter("@srstate", shuadan_recordExample.srstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@srstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordExample.srtype))
            {
                list_param.Add(new OleDbParameter("@srtype", shuadan_recordExample.srtype));
            }
            else
            {
                list_param.Add(new OleDbParameter("@srtype", DBNull.Value));
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
        /// <returns>shuadan_recordExample</returns>
        public static shuadan_record GetByReader(OleDbDataReader Reader)
        {
            shuadan_record shuadan_recordExample = new shuadan_record();
            shuadan_recordExample.srcount = Reader["srcount"] == DBNull.Value ? 0 : (int)Reader["srcount"];
            shuadan_recordExample.srdate = Reader["srdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["srdate"]);
            shuadan_recordExample.srid = Reader["srid"] == DBNull.Value ? 0 : (int)Reader["srid"];
            shuadan_recordExample.srname = Reader["srname"] == DBNull.Value ? null : Reader["srname"].ToString();
            shuadan_recordExample.srnum = Reader["srnum"] == DBNull.Value ? null : Reader["srnum"].ToString();
            shuadan_recordExample.srpath = Reader["srpath"] == DBNull.Value ? null : Reader["srpath"].ToString();
            shuadan_recordExample.srremark = Reader["srremark"] == DBNull.Value ? null : Reader["srremark"].ToString();
            shuadan_recordExample.srstate = Reader["srstate"] == DBNull.Value ? null : Reader["srstate"].ToString();
            shuadan_recordExample.srtype = Reader["srtype"] == DBNull.Value ? null : Reader["srtype"].ToString();
            return shuadan_recordExample;
        }
        #endregion





        #endregion
    }

   











}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
{


    //表名称：pages_type
    //实体类名称：pages_typeExample
    //主键：ptid

    public class pages_typeService : Ipages_typeService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<pages_type> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from pages_type   order by ptsort asc ";
            List<pages_type> list = new List<pages_type>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                pages_type Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据ptid,查询一条数据
        /// </summary>
        /// <param name="ptid">编号</param>
        /// <returns></returns>
        public pages_type SearchByID(int ptid)
        {
            Access.DBHelper.sqlstr = "select * from pages_type where ptid = @ptid ";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@ptid",ptid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            pages_type Obj = null;
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
        /// <param name="pages_type">pages_type表实例</param>
        /// <returns>int</returns>
        public int Insert(pages_type pages_typeExample)
        {
            Access.DBHelper.sqlstr = "insert into  pages_type (ptdate,ptname,ptremark,ptsort,ptstate)values('" + pages_typeExample.ptdate.ToString() + "',@ptname,@ptremark,@ptsort,@ptstate)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(pages_typeExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="pages_type">pages_type表实例</param>
        /// <returns>int</returns>
        public int Update(pages_type pages_typeExample)
        {
            Access.DBHelper.sqlstr = "update pages_type set ptdate='" + pages_typeExample.ptdate.ToString() + "',ptname=@ptname,ptremark=@ptremark,ptsort=@ptsort,ptstate=@ptstate where ptid=" + pages_typeExample.ptid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(pages_typeExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ptid">编号</param>
        /// <returns>int</returns>
        public int Delete(int ptid)
        {
            Access.DBHelper.sqlstr = "delete from pages_type where ptid =@ptid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@ptid",ptid)
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
        public int SearchNum(string key, string state, DateTime date1, DateTime date2)
        {
            string sql1 = "select count(ptid) from pages_type where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  ptname like '%" + key + "%' or  ptremark like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and ptstate= '" + state + "' ";
            string sql4 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',ptdate)>=0 ";
            string sql5 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',ptdate)<=0 ";
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 ;
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
        /// <returns>IList<pages_type></returns>
        public IList<pages_type> Search(int s, int e, string key, string state, DateTime date1, DateTime date2)
        {
            string sql1 = "select top " + e.ToString() + " * from pages_type where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  ptname like '%" + key + "%' or  ptremark like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and ptstate= '" + state + "' ";
            string sql4 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',ptdate)>=0 ";
            string sql5 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',ptdate)<=0 ";
            string sql6 = " order by ptsort desc,ptdate asc ";//排序两个字段,否则数据容易错误
            DBHelper.sqlstr = "select * from(select top " + (e - s + 1).ToString() + " * from  ( " + sql1 + sql2 + sql3 + sql4 + sql5 + " order by ptsort asc,ptdate desc ) " + sql6 + ") order by  ptsort asc,ptdate desc ";
            List<pages_type> list = new List<pages_type>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                pages_type Obj = GetByReader(reader);
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
        public static OleDbParameter[] GetOleDbParameter(pages_type pages_typeExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(pages_typeExample.ptname))
            {
                list_param.Add(new OleDbParameter("@ptname", pages_typeExample.ptname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ptname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(pages_typeExample.ptremark))
            {
                list_param.Add(new OleDbParameter("@ptremark", pages_typeExample.ptremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ptremark", DBNull.Value));
            }
            if (pages_typeExample.ptsort != 0)
            {
                list_param.Add(new OleDbParameter("@ptsort", pages_typeExample.ptsort));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ptsort", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(pages_typeExample.ptstate))
            {
                list_param.Add(new OleDbParameter("@ptstate", pages_typeExample.ptstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ptstate", DBNull.Value));
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
        /// <returns>pages_typeExample</returns>
        public static pages_type GetByReader(OleDbDataReader Reader)
        {
            pages_type pages_typeExample = new pages_type();
            pages_typeExample.ptdate = Reader["ptdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["ptdate"]);
            pages_typeExample.ptid = Reader["ptid"] == DBNull.Value ? 0 : (int)Reader["ptid"];
            pages_typeExample.ptname = Reader["ptname"] == DBNull.Value ? null : Reader["ptname"].ToString();
            pages_typeExample.ptremark = Reader["ptremark"] == DBNull.Value ? null : Reader["ptremark"].ToString();
            pages_typeExample.ptsort = Reader["ptsort"] == DBNull.Value ? 0 : (int)Reader["ptsort"];
            pages_typeExample.ptstate = Reader["ptstate"] == DBNull.Value ? null : Reader["ptstate"].ToString();
            return pages_typeExample;
        }
        #endregion





        #endregion
    }
   





}

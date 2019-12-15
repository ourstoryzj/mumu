using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
{




    //表名称：pages
    //实体类名称：pagesExample
    //主键：pid

    public class pagesService : IpagesService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<pages> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from pages  order by psort asc  ";
            List<pages> list = new List<pages>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                pages Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据pid,查询一条数据
        /// </summary>
        /// <param name="pid">页面编号</param>
        /// <returns></returns>
        public pages SearchByID(int pid)
        {
            Access.DBHelper.sqlstr = "select * from pages where pid = @pid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@pid",pid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            pages Obj = null;
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
        /// <param name="pages">pages表实例</param>
        /// <returns>int</returns>
        public int Insert(pages pagesExample)
        {
            Access.DBHelper.sqlstr = "insert into  pages (pcontext,pdate,pname,psort,pstate,ptid)values(@pcontext,'" + pagesExample.pdate.ToString() + "',@pname,@psort,@pstate,@ptid)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(pagesExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="pages">pages表实例</param>
        /// <returns>int</returns>
        public int Update(pages pagesExample)
        {
            Access.DBHelper.sqlstr = "update pages set pcontext=@pcontext,pdate='" + pagesExample.pdate.ToString() + "',pname=@pname,psort=@psort,pstate=@pstate,ptid=@ptid where pid=" + pagesExample.pid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(pagesExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pid">页面编号</param>
        /// <returns>int</returns>
        public int Delete(int pid)
        {
            Access.DBHelper.sqlstr = "delete from pages where pid =@pid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@pid",pid)
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
        public int SearchNum(string key, string state, int ptid, DateTime date1, DateTime date2)
        {
            string sql1 = "select count(pid) from pages where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  pname like '%" + key + "%' or  pcontext like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and pstate= '" + state + "' ";
            string sql4 = ptid == 0 ? "" : " and ptid= " + ptid + " ";
            string sql5 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',pdate)>=0 ";
            string sql6 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',pdate)<=0 ";
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
        /// <returns>IList<pages></returns>
        public IList<pages> Search(int s, int e, string key, string state, int ptid, DateTime date1, DateTime date2)
        {
            string sql1 = "select top " + e.ToString() + " * from pages where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  pname like '%" + key + "%' or  pcontext like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and pstate= '" + state + "' ";
            string sql4 = ptid == 0 ? "" : " and ptid= " + ptid + " ";
            string sql5 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',pdate)>=0 ";
            string sql6 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',pdate)<=0 ";
            string sql7 = " order by psort desc,pdate asc ";//排序两个字段,否则数据容易错误
            DBHelper.sqlstr = "select * from(select top " + (e - s + 1).ToString() + " * from  ( " + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + " order by psort asc,pdate desc ) " + sql7 + ") order by  psort asc,pdate desc ";
            List<pages> list = new List<pages>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                pages Obj = GetByReader(reader);
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
        public static OleDbParameter[] GetOleDbParameter(pages pagesExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(pagesExample.pcontext))
            {
                list_param.Add(new OleDbParameter("@pcontext", pagesExample.pcontext));
            }
            else
            {
                list_param.Add(new OleDbParameter("@pcontext", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(pagesExample.pname))
            {
                list_param.Add(new OleDbParameter("@pname", pagesExample.pname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@pname", DBNull.Value));
            }
            if (pagesExample.psort != 0)
            {
                list_param.Add(new OleDbParameter("@psort", pagesExample.psort));
            }
            else
            {
                list_param.Add(new OleDbParameter("@psort", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(pagesExample.pstate))
            {
                list_param.Add(new OleDbParameter("@pstate", pagesExample.pstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@pstate", DBNull.Value));
            }
            if (pagesExample.ptid != 0)
            {
                list_param.Add(new OleDbParameter("@ptid", pagesExample.ptid));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ptid", DBNull.Value));
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
        /// <returns>pagesExample</returns>
        public static pages GetByReader(OleDbDataReader Reader)
        {
            pages pagesExample = new pages();
            pagesExample.pcontext = Reader["pcontext"] == DBNull.Value ? null : Reader["pcontext"].ToString();
            pagesExample.pdate = Reader["pdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["pdate"]);
            pagesExample.pid = Reader["pid"] == DBNull.Value ? 0 : (int)Reader["pid"];
            pagesExample.pname = Reader["pname"] == DBNull.Value ? null : Reader["pname"].ToString();
            pagesExample.psort = Reader["psort"] == DBNull.Value ? 0 : (int)Reader["psort"];
            pagesExample.pstate = Reader["pstate"] == DBNull.Value ? null : Reader["pstate"].ToString();
            pagesExample.ptid = Reader["ptid"] == DBNull.Value ? 0 : (int)Reader["ptid"];
            return pagesExample;
        }
        #endregion





        #endregion
    }
    
   








}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{



    public class huashuService
    {
        #region SearchAll
        /// <summary>
        /// 搜索全部父类
        /// </summary>
        /// <returns></returns>
        public IList<huashu> SearchAll(string state)
        {
            DBHelper.sqlstr = "select * from huashu where hfid=0 " + (string.IsNullOrEmpty(state) ? "" : " and hstate='" + state + "' ") + " order by hsort asc,hcount desc,hid asc ";
            List<huashu> list = new List<huashu>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                huashu Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion



        #region SearchByID
        /// <summary>
        /// 根据hid,查询一条数据
        /// </summary>
        /// <param name="hid"></param>
        /// <returns></returns>
        /*查看是否为视图*/

        public huashu SearchByID(int hid)
        {
            DBHelper.sqlstr = "select * from huashu where hid = @hid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@hid",hid)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            huashu Obj = null;
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
        /// <param name="huashu">huashu表实例</param>
        /// <returns>int</returns>
        public int Insert(huashu huashuExample)
        {
            DBHelper.sqlstr = "insert into  huashu (hfid,hcontext,hsort,hcount,hdate,htitle,hstate,hsendemail,hremark)values(@hfid,@hcontext,@hsort,@hcount,@hdate,@htitle,@hstate,@hsendemail,@hremark)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(huashuExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="huashu">huashu表实例</param>
        /// <returns>int</returns>
        public int Update(huashu huashuExample)
        {
            DBHelper.sqlstr = "update huashu set hfid=@hfid,hcontext=@hcontext,hsort=@hsort,hcount=@hcount,hdate=@hdate,htitle=@htitle,hstate=@hstate,hsendemail=@hsendemail,hremark=@hremark where hid=" + huashuExample.hid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(huashuExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="hid"></param>
        /// <returns>int</returns>
        public int Delete(int hid)
        {
            DBHelper.sqlstr = "delete huashu where hid =@hid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@hid",hid)
			};
            return DBHelper.ExecuteNonQuery(param);
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
            string sql1 = "select count(hid) from huashu where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  htitle like '%" + key + "%' or  hcontext like '%" + key + "%' or hremark like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and hstate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(_type) ? "  and hfid!= 0 " : " and hfid= " + _type + " ";
            string sql5 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',hdate)>=0 ";
            string sql6 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',hdate)<=0 ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6;
            return Convert.ToInt32(DBHelper.ExecuteScalar());
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
        /// <returns>IList<huashu></returns>
        public IList<huashu> Search(int s, int e, string key, string state, string _type, DateTime date1, DateTime date2)
        {
            List<huashu> list = new List<huashu>();
            //string sql1 = "select top " + e.ToString() + " * from shuadan_pingjia where ";
            try
            {
                string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  htitle like '%" + key + "%' or  hcontext like '%" + key + "%' or hremark like '%" + key + "%' ) ";
                string sql3 = string.IsNullOrEmpty(state) ? "" : " and hstate= '" + state + "' ";
                string sql4 = string.IsNullOrEmpty(_type) ? " and hfid!= 0 " : " and hfid= " + _type + " ";
                string sql5 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',hdate)>=0 ";
                string sql6 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',hdate)<=0 ";
                string sql1 = "select top " + e.ToString() + " * from   huashu where " + sql2 + sql3 + sql4 + sql5 + sql6;
                DBHelper.sqlstr = "select * from ( select top " + (e - s + 1).ToString() + " * from " + "( " + sql1 + " order by hsort asc,hcount desc,hid asc  ) as table1  order by hsort desc,hcount asc  ,hid desc )as table2  order by hsort asc,hcount desc,hid asc ";

                SqlDataReader reader = DBHelper.ExecuteReader();
                while (reader.Read())
                {
                    huashu Obj = GetByReader(reader);
                    list.Add(Obj);
                }
                reader.Close();
            }
            catch (Exception)
            {
                //throw;
            }
            return list;
        }
        #endregion

        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameters(huashu huashuExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();
            if (huashuExample.hfid != 0)
            {
                list_param.Add(new SqlParameter("@hfid", huashuExample.hfid));
            }
            else
            {
                list_param.Add(new SqlParameter("@hfid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(huashuExample.hcontext))
            {
                list_param.Add(new SqlParameter("@hcontext", huashuExample.hcontext));
            }
            else
            {
                list_param.Add(new SqlParameter("@hcontext", DBNull.Value));
            }
            if (huashuExample.hsort != 0)
            {
                list_param.Add(new SqlParameter("@hsort", huashuExample.hsort));
            }
            else
            {
                list_param.Add(new SqlParameter("@hsort", DBNull.Value));
            }
            if (huashuExample.hcount != 0)
            {
                list_param.Add(new SqlParameter("@hcount", huashuExample.hcount));
            }
            else
            {
                list_param.Add(new SqlParameter("@hcount", DBNull.Value));
            }
            if (huashuExample.hdate != new DateTime() && huashuExample.hdate != null)
            {
                list_param.Add(new SqlParameter("@hdate", huashuExample.hdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@hdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(huashuExample.htitle))
            {
                list_param.Add(new SqlParameter("@htitle", huashuExample.htitle));
            }
            else
            {
                list_param.Add(new SqlParameter("@htitle", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(huashuExample.hstate))
            {
                list_param.Add(new SqlParameter("@hstate", huashuExample.hstate));
            }
            else
            {
                list_param.Add(new SqlParameter("@hstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(huashuExample.hsendemail))
            {
                list_param.Add(new SqlParameter("@hsendemail", huashuExample.hsendemail));
            }
            else
            {
                list_param.Add(new SqlParameter("@hsendemail", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(huashuExample.hremark))
            {
                list_param.Add(new SqlParameter("@hremark", huashuExample.hremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@hremark", DBNull.Value));
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
        /// <returns>huashuExample</returns>
        public static huashu GetByReader(SqlDataReader Reader)
        {
            huashu huashuExample = new huashu();
            huashuExample.hid = Reader["hid"] == DBNull.Value ? 0 : (int)Reader["hid"];
            huashuExample.hfid = Reader["hfid"] == DBNull.Value ? 0 : (int)Reader["hfid"];
            huashuExample.hcontext = Reader["hcontext"] == DBNull.Value ? null : Reader["hcontext"].ToString();
            huashuExample.hsort = Reader["hsort"] == DBNull.Value ? 0 : (int)Reader["hsort"];
            huashuExample.hcount = Reader["hcount"] == DBNull.Value ? 0 : (int)Reader["hcount"];
            huashuExample.hdate = Reader["hdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["hdate"]);
            huashuExample.htitle = Reader["htitle"] == DBNull.Value ? null : Reader["htitle"].ToString();
            huashuExample.hstate = Reader["hstate"] == DBNull.Value ? null : Reader["hstate"].ToString();
            huashuExample.hsendemail = Reader["hsendemail"] == DBNull.Value ? null : Reader["hsendemail"].ToString();
            huashuExample.hremark = Reader["hremark"] == DBNull.Value ? null : Reader["hremark"].ToString();
            return huashuExample;
        }
        #endregion





        #endregion
    }

    
 


}



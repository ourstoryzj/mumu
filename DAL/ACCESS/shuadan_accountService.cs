using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.OleDb;

namespace DAL.Access
{


    //表名称：shuadan_account
    //实体类名称：shuadan_accountExample
    //主键：sdaid

    public class shuadan_accountService : Ishuadan_accountService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_account> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from shuadan_account ";
            List<shuadan_account> list = new List<shuadan_account>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_account Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBysdaid
        /// <summary>
        /// 根据sdaid,查询一条数据
        /// </summary>
        /// <param name="sdaid">编号</param>
        /// <returns></returns>
        public shuadan_account SearchBysdaid(int sdaid)
        {
            Access.DBHelper.sqlstr = "select * from shuadan_account where sdaid = @sdaid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@sdaid",sdaid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            shuadan_account Obj = null;
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
        /// <param name="shuadan_account">shuadan_account表实例</param>
        /// <returns>int</returns>
        public int Insert(shuadan_account shuadan_accountExample)
        {
            Access.DBHelper.sqlstr = "insert into  shuadan_account (sdaccount,sdadate,sdapwd,sdastandby,sdastate,sdastate_phone)values(@sdaccount,'" + shuadan_accountExample.sdadate.ToString() + "',@sdapwd,@sdastandby,@sdastate,@sdastate_phone)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadan_accountExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_account">shuadan_account表实例</param>
        /// <returns>int</returns>
        public int Update(shuadan_account shuadan_accountExample)
        {
            Access.DBHelper.sqlstr = "update shuadan_account set sdaccount=@sdaccount,sdadate='" + shuadan_accountExample.sdadate.ToString() + "',sdapwd=@sdapwd,sdastandby=@sdastandby,sdastate=@sdastate,sdastate_phone=@sdastate_phone where sdaid=" + shuadan_accountExample.sdaid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadan_accountExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdaid">编号</param>
        /// <returns>int</returns>
        public int Delete(int sdaid)
        {
            Access.DBHelper.sqlstr = "delete from shuadan_account where sdaid =@sdaid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@sdaid",sdaid)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public int SearchNum(string key, string state, string state_phone, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(sdaid) from shuadan_account where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  sdaccount like '%" + key + "%' or  sdapwd like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sdastate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(state_phone) ? "" : " and sdastate_phone= '" + state_phone + "' ";
            string sql5 = startdate == new DateTime() ? "" : " and datediff('d','" + startdate.ToString() + "',sdadate)>=0 ";
            string sql6 = enddate == new DateTime() ? "" : " and datediff('d','" + enddate.ToString() + "',sdadate)<=0 ";
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6;
            return Convert.ToInt32(Access.DBHelper.ExecuteScalar());
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
        public IList<shuadan_account> Search(int s, int e, string key, string state, string state_phone, DateTime startdate, DateTime enddate, string top)
        {
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  sdaccount like '%" + key + "%' or  sdapwd like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sdastate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(state_phone) ? "" : " and sdastate_phone= '" + state_phone + "' ";
            string sql5 = startdate == new DateTime() ? "" : " and datediff('d','" + startdate.ToString() + "',sdadate)>=0 ";
            string sql6 = enddate == new DateTime() ? "" : " and datediff('d','" + enddate.ToString() + "',sdadate)<=0 ";
            //string sql7 = string.IsNullOrEmpty(orderby) ? " order by sdadate asc,sdaid asc " : " order by " + orderby;
            string sql1 = "select top " + e.ToString() + " * from " + (string.IsNullOrEmpty(top) ? " shuadan_account where " : " ( select top " + top + " * from shuadan_account where " + sql2 + sql3 + sql4 + sql5 + sql6 + " order by sdadate desc,sdaid desc   ) ") + (string.IsNullOrEmpty(top) ? (sql2 + sql3 + sql4 + sql5 + sql6) : "");
            DBHelper.sqlstr = "select top " + (e - s + 1).ToString() + " * from " + "( " + sql1 + " order by sdadate desc,sdaid desc )  order by sdadate asc,sdaid asc ";

            List<shuadan_account> list = new List<shuadan_account>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_account Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion


        #region SearchPhone
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_account> SearchPhone(string top, DateTime date1, DateTime date2)
        {
            string sql1 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',sdadate)>=0 ";
            string sql2 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',sdadate)<=0 ";
            Access.DBHelper.sqlstr = "select " + (string.IsNullOrEmpty(top) ? "" : " top " + top + " ") + " * from shuadan_account where 1=1 " + sql1 + sql2 + " order by sdastate_phone	asc,sdadate desc  ";
            List<shuadan_account> list = new List<shuadan_account>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_account Obj = GetByReader(reader);
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
        public static OleDbParameter[] GetOleDbParameter(shuadan_account shuadan_accountExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(shuadan_accountExample.sdaccount))
            {
                list_param.Add(new OleDbParameter("@sdaccount", shuadan_accountExample.sdaccount));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdaccount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_accountExample.sdapwd))
            {
                list_param.Add(new OleDbParameter("@sdapwd", shuadan_accountExample.sdapwd));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdapwd", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_accountExample.sdastandby))
            {
                list_param.Add(new OleDbParameter("@sdastandby", shuadan_accountExample.sdastandby));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdastandby", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_accountExample.sdastate))
            {
                list_param.Add(new OleDbParameter("@sdastate", shuadan_accountExample.sdastate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdastate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_accountExample.sdastate_phone))
            {
                list_param.Add(new OleDbParameter("@sdastate_phone", shuadan_accountExample.sdastate_phone));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdastate_phone", DBNull.Value));
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
        /// <returns>shuadan_accountExample</returns>
        public static shuadan_account GetByReader(OleDbDataReader Reader)
        {
            shuadan_account shuadan_accountExample = new shuadan_account();
            shuadan_accountExample.sdaccount = Reader["sdaccount"] == DBNull.Value ? null : Reader["sdaccount"].ToString();
            shuadan_accountExample.sdadate = Reader["sdadate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sdadate"]);
            shuadan_accountExample.sdaid = Reader["sdaid"] == DBNull.Value ? 0 : (int)Reader["sdaid"];
            shuadan_accountExample.sdapwd = Reader["sdapwd"] == DBNull.Value ? null : Reader["sdapwd"].ToString();
            shuadan_accountExample.sdastandby = Reader["sdastandby"] == DBNull.Value ? null : Reader["sdastandby"].ToString();
            shuadan_accountExample.sdastate = Reader["sdastate"] == DBNull.Value ? null : Reader["sdastate"].ToString();
            shuadan_accountExample.sdastate_phone = Reader["sdastate_phone"] == DBNull.Value ? null : Reader["sdastate_phone"].ToString();
            return shuadan_accountExample;
        }
        #endregion





        #endregion
    }

}

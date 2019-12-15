using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.OleDb;

namespace DAL.Access
{





    //表名称：shouhou
    //实体类名称：shouhouExample
    //主键：shid

    public class shouhouService : IshouhouService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shouhou> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from shouhou  order by shdate desc,shid asc  ";
            List<shouhou> list = new List<shouhou>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shouhou Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByshid
        /// <summary>
        /// 根据shid,查询一条数据
        /// </summary>
        /// <param name="shid"></param>
        /// <returns></returns>
        public shouhou SearchByshid(int shid)
        {
            Access.DBHelper.sqlstr = "select * from shouhou where shid = @shid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@shid",shid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            shouhou Obj = null;
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
        /// <param name="shouhou">shouhou表实例</param>
        /// <returns>int</returns>
        public int Insert(shouhou shouhouExample)
        {
            Access.DBHelper.sqlstr = "insert into  shouhou (dpid,shaccount,shdate,shkdcode,shname,shordercode,shphone,shremark,shstate,shytphone,shyuanyin)values(@dpid,@shaccount,'" + shouhouExample.shdate.ToString() + "',@shkdcode,@shname,@shordercode,@shphone,@shremark,@shstate,@shytphone,@shyuanyin)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shouhouExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shouhou">shouhou表实例</param>
        /// <returns>int</returns>
        public int Update(shouhou shouhouExample)
        {
            Access.DBHelper.sqlstr = "update shouhou set dpid=@dpid,shaccount=@shaccount,shdate='" + shouhouExample.shdate.ToString() + "',shkdcode=@shkdcode,shname=@shname,shordercode=@shordercode,shphone=@shphone,shremark=@shremark,shstate=@shstate,shytphone=@shytphone,shyuanyin=@shyuanyin where shid=" + shouhouExample.shid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shouhouExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="shid"></param>
        /// <returns>int</returns>
        public int Delete(int shid)
        {
            Access.DBHelper.sqlstr = "delete from shouhou where shid =@shid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@shid",shid)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        //#region  Search
        ///// <summary>
        ///// 高级查询
        ///// </summary>
        ///// <param name="start">起始序号</param>
        ///// <param name="end">结束序号</param>
        ///// <param name="key">关键词</param>
        ///// <param name="uid">负责人id</param>
        ///// <param name="sstart">启动开始时间</param>
        ///// <param name="send">启动结束时间</param>
        ///// <param name="nstart">发布开始时间</param>
        ///// <param name="nend">发布结束时间</param>
        ///// <param name="flag">状态 1启用 2 禁用</param>
        ///// <param name="orderby">排序方式</param>
        ///// <returns>IList<Project></returns>
        //public IList<Project> Search(int start, int end, string key, int uid, DateTime sstart, DateTime send, DateTime nstart, DateTime nend, string flag, string orderby)
        //{
        //    string sql = " select top " + (end - start + 1).ToString() + "  * from Project where ";
        //    string sql1 = string.IsNullOrEmpty(key) ? " 1=1" : " ( [Name] like '%" + key + "%' or [Content] like '%" + key + "%' or Remark like '%" + key + "%' or  UName like '%" + key + "%' )  ";
        //    string sql2 = uid == 0 ? "" : " and uid= " + uid.ToString();
        //    string sql3 = sstart == (new DateTime()) ? "" : " and datediff(d,'" + sstart.ToString() + "',Sdate)<=0 ";
        //    string sql4 = send == (new DateTime()) ? "" : " and datediff(d,'" + send.ToString() + "',Sdate)>=0 ";
        //    string sql5 = nstart == (new DateTime()) ? "" : " and datediff(d,'" + nstart.ToString() + "',Ndate)<=0 ";
        //    string sql6 = nend == (new DateTime()) ? "" : " and datediff(d,'" + nend.ToString() + "',Ndate)>=0 ";
        //    string sql7 = string.IsNullOrEmpty(flag) ? "" : " and flag=" + flag;
        //    string sql8 = string.IsNullOrEmpty(orderby) ? " order by ndate desc " : " order by  " + orderby;
        //    DBHelper.sqlstr = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + " and id not in ( select top " + (start - 1).ToString() + " id from Project where " + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + " )" + sql8;
        //    List<Project> list = new List<Project>();
        //    SqlDataReader reader = DBHelper.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        Project Obj = GetByReader(reader);
        //        list.Add(Obj);
        //    }
        //    reader.Close();
        //    return list;
        //}
        //#endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public int SearchNum(string key, int dpid, DateTime start, DateTime end, string state)
        {
            string sql = "select count(shid) from shouhou where ";
            string sql1 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( shaccount like '%" + key + "%' or  shname like '%" + key + "%'  or  shordercode like '%" + key + "%'  or  shphone like '%" + key + "%'  or  shremark like '%" + key + "%'  or  shyuanyin like '%" + key + "%'  or  shytphone like '%" + key + "%'  or  shkdcode like '%" + key + "%' ) ";
            string sql2 = dpid == 0 ? "" : " and dpid=" + dpid.ToString() + " ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and shstate= '" + state + "' ";
            string sql4 = start == (new DateTime()) ? "" : " and datediff('d','" + start.ToString() + "',shdate)>=0 ";
            string sql5 = end == (new DateTime()) ? "" : " and datediff('d','" + end.ToString() + "',shdate)<=0 ";
            Access.DBHelper.sqlstr = sql + sql1 + sql2 + sql3 + sql4 + sql5;
            return Convert.ToInt32(Access.DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="dpid">店铺ID</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="state">状态</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public IList<shouhou> Search(int s, int e, string key, int dpid, DateTime start, DateTime end, string state, string orderby)
        {
            string sql = "select  top " + (e - s + 1).ToString() + "  * from shouhou where ";
            string sql1 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( shaccount like '%" + key + "%' or  shname like '%" + key + "%'  or  shordercode like '%" + key + "%'  or  shphone like '%" + key + "%'  or  shremark like '%" + key + "%'  or  shyuanyin like '%" + key + "%'  or  shytphone like '%" + key + "%'  or  shkdcode like '%" + key + "%' ) ";
            string sql2 = dpid == 0 ? "" : " and dpid=" + dpid.ToString() + " ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and shstate= '" + state + "' ";
            string sql4 = start == (new DateTime()) ? "" : " and datediff('d','" + start.ToString() + "',shdate)>=0 ";
            string sql5 = end == (new DateTime()) ? "" : " and datediff('d','" + end.ToString() + "',shdate)<=0 ";
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by shdate desc,shid asc " : " order by  " + orderby;
            string sql6 = s == 1 ? "" : " and shid not in ( select top " + (s - 1).ToString() + " shid from shouhou where " +sql1+ sql2 + sql3 + sql4 + sql5 + sql7 + " ) ";

            Access.DBHelper.sqlstr = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7;
            List<shouhou> list = new List<shouhou>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shouhou Obj = GetByReader(reader);
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
        public static OleDbParameter[] GetOleDbParameter(shouhou shouhouExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();
            if (shouhouExample.dpid != 0)
            {
                list_param.Add(new OleDbParameter("@dpid", shouhouExample.dpid));
            }
            else
            {
                list_param.Add(new OleDbParameter("@dpid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shouhouExample.shaccount))
            {
                list_param.Add(new OleDbParameter("@shaccount", shouhouExample.shaccount));
            }
            else
            {
                list_param.Add(new OleDbParameter("@shaccount", DBNull.Value));
            }
            if (shouhouExample.shdate != new DateTime() && shouhouExample.shdate != null)
            {
                list_param.Add(new OleDbParameter("@shdate", shouhouExample.shdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new OleDbParameter("@shdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shouhouExample.shkdcode))
            {
                list_param.Add(new OleDbParameter("@shkdcode", shouhouExample.shkdcode));
            }
            else
            {
                list_param.Add(new OleDbParameter("@shkdcode", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shouhouExample.shname))
            {
                list_param.Add(new OleDbParameter("@shname", shouhouExample.shname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@shname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shouhouExample.shordercode))
            {
                list_param.Add(new OleDbParameter("@shordercode", shouhouExample.shordercode));
            }
            else
            {
                list_param.Add(new OleDbParameter("@shordercode", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shouhouExample.shphone))
            {
                list_param.Add(new OleDbParameter("@shphone", shouhouExample.shphone));
            }
            else
            {
                list_param.Add(new OleDbParameter("@shphone", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shouhouExample.shremark))
            {
                list_param.Add(new OleDbParameter("@shremark", shouhouExample.shremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@shremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shouhouExample.shstate))
            {
                list_param.Add(new OleDbParameter("@shstate", shouhouExample.shstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@shstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shouhouExample.shytphone))
            {
                list_param.Add(new OleDbParameter("@shytphone", shouhouExample.shytphone));
            }
            else
            {
                list_param.Add(new OleDbParameter("@shytphone", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shouhouExample.shyuanyin))
            {
                list_param.Add(new OleDbParameter("@shyuanyin", shouhouExample.shyuanyin));
            }
            else
            {
                list_param.Add(new OleDbParameter("@shyuanyin", DBNull.Value));
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
        /// <returns>shouhouExample</returns>
        public static shouhou GetByReader(OleDbDataReader Reader)
        {
            shouhou shouhouExample = new shouhou();
            shouhouExample.dpid = Reader["dpid"] == DBNull.Value ? 0 : (int)Reader["dpid"];
            shouhouExample.shaccount = Reader["shaccount"] == DBNull.Value ? null : Reader["shaccount"].ToString();
            shouhouExample.shdate = Reader["shdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["shdate"]);
            shouhouExample.shid = Reader["shid"] == DBNull.Value ? 0 : (int)Reader["shid"];
            shouhouExample.shkdcode = Reader["shkdcode"] == DBNull.Value ? null : Reader["shkdcode"].ToString();
            shouhouExample.shname = Reader["shname"] == DBNull.Value ? null : Reader["shname"].ToString();
            shouhouExample.shordercode = Reader["shordercode"] == DBNull.Value ? null : Reader["shordercode"].ToString();
            shouhouExample.shphone = Reader["shphone"] == DBNull.Value ? null : Reader["shphone"].ToString();
            shouhouExample.shremark = Reader["shremark"] == DBNull.Value ? null : Reader["shremark"].ToString();
            shouhouExample.shstate = Reader["shstate"] == DBNull.Value ? null : Reader["shstate"].ToString();
            shouhouExample.shytphone = Reader["shytphone"] == DBNull.Value ? null : Reader["shytphone"].ToString();
            shouhouExample.shyuanyin = Reader["shyuanyin"] == DBNull.Value ? null : Reader["shyuanyin"].ToString();
            return shouhouExample;
        }
        #endregion





        #endregion
    }






}

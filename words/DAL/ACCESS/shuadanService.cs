using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using IDAL;
using System.Data.OleDb;

namespace DAL.Access
{



    //表名称：shuadan
    //实体类名称：shuadanExample
    //主键：sdid

    public class shuadanService : IshuadanService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from shuadan ";
            List<shuadan> list = new List<shuadan>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBysdid
        /// <summary>
        /// 根据sdid,查询一条数据
        /// </summary>
        /// <param name="sdid">编号</param>
        /// <returns></returns>
        public shuadan SearchBysdid(int sdid)
        {
            Access.DBHelper.sqlstr = "select * from shuadan where sdid = @sdid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@sdid",sdid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            shuadan Obj = null;
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
        /// <param name="shuadan">shuadan表实例</param>
        /// <returns>int</returns>
        public int Insert(shuadan shuadanExample)
        {
            Access.DBHelper.sqlstr = "insert into  shuadan (dpidfrom,dpidto,gid,gname,scity,sdaccount,sdaddress,sdaid,sdapwd,sddate,sdinfofrom,sdistrict,sdkdcode,sdkdname,sdname,sdnumber,sdordercode,sdphone,sdpingjiadate,sdpingjiastate,sdpostname,sdprovince,sdremark,sdsenddate,sdsendstate,sdstandby,sdstandby1,sdstandby2,sdstandby3,sdstate)values(@dpidfrom,@dpidto,@gid,@gname,@scity,@sdaccount,@sdaddress,@sdaid,@sdapwd,'" + shuadanExample.sddate.ToString() + "',@sdinfofrom,@sdistrict,@sdkdcode,@sdkdname,@sdname,@sdnumber,@sdordercode,@sdphone,'" + shuadanExample.sdpingjiadate.ToString() + "',@sdpingjiastate,@sdpostname,@sdprovince,@sdremark,'" + shuadanExample.sdsenddate.ToString() + "',@sdsendstate,@sdstandby,@sdstandby1,@sdstandby2,@sdstandby3,@sdstate)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadanExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan">shuadan表实例</param>
        /// <returns>int</returns>
        public int Update(shuadan shuadanExample)
        {
            Access.DBHelper.sqlstr = "update shuadan set dpidfrom=@dpidfrom,dpidto=@dpidto,gid=@gid,gname=@gname,scity=@scity,sdaccount=@sdaccount,sdaddress=@sdaddress,sdaid=@sdaid,sdapwd=@sdapwd,sddate='" + shuadanExample.sddate.ToString() + "',sdinfofrom=@sdinfofrom,sdistrict=@sdistrict,sdkdcode=@sdkdcode,sdkdname=@sdkdname,sdname=@sdname,sdnumber=@sdnumber,sdordercode=@sdordercode,sdphone=@sdphone,sdpingjiadate='" + shuadanExample.sdpingjiadate.ToString() + "',sdpingjiastate=@sdpingjiastate,sdpostname=@sdpostname,sdprovince=@sdprovince,sdremark=@sdremark,sdsenddate='" + shuadanExample.sdsenddate.ToString() + "',sdsendstate=@sdsendstate,sdstandby=@sdstandby,sdstandby1=@sdstandby1,sdstandby2=@sdstandby2,sdstandby3=@sdstandby3,sdstate=@sdstate where sdid=" + shuadanExample.sdid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadanExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdid">编号</param>
        /// <returns>int</returns>
        public int Delete(int sdid)
        {
            Access.DBHelper.sqlstr = "delete from shuadan where sdid =@sdid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@sdid",sdid)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 根据条件查询全部数据总条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="gid">商品ID</param>
        /// <param name="aid">账号ID</param>
        /// <param name="state">刷单状态 1正常 2作废</param>
        /// <param name="state_send">发货状态 1未发货 2已发货</param>
        /// <param name="state_pingjia">评价状态 1未评价 2已评价</param>
        /// <param name="date1">刷单时间</param>
        /// <param name="date2">刷单时间</param>
        /// <param name="date_send1">发货时间</param>
        /// <param name="date_send2">发货时间</param>
        /// <param name="date_pingjia1">评价时间</param>
        /// <param name="date_pingjia2">评价时间</param>
        /// <returns>int</returns>
        public int SearchNum(string key, int gid, int aid, string state, string state_send, string state_pingjia, DateTime date1, DateTime date2, DateTime date_send1, DateTime date_send2, DateTime date_pingjia1, DateTime date_pingjia2)
        {
            string sql1 = "select count(sdid) from shuadan where  ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  sdordercode like '%" + key + "%' or  sdaccount like '%" + key + "%' or  sdapwd like '%" + key + "%' or  sdremark like '%" + key + "%' or  sdname like '%" + key + "%' or  sdphone like '%" + key + "%' or  sdpostname like '%" + key + "%' or  sdprovince like '%" + key + "%' or  scity like '%" + key + "%' or  sdistrict like '%" + key + "%' or  sdaddress like '%" + key + "%' or  gname like '%" + key + "%'  or  sdkdname like '%" + key + "%'  or  sdkdcode like '%" + key + "%'  or  sdnumber like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sdstate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(state_send) ? "" : " and sdsendstate= '" + state_send + "' ";
            string sql5 = string.IsNullOrEmpty(state_pingjia) ? "" : " and sdpingjiastate= '" + state_pingjia + "' ";
            string sql6 = gid == 0 ? "" : " and gid= " + gid.ToString() + " ";
            string sql7 = aid == 0 ? "" : " and sdaid= " + aid.ToString() + " ";
            string sql8 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',sddate)>=0 ";
            string sql9 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',sddate)<=0 ";
            string sql10 = date_send1 == new DateTime() ? "" : " and datediff('d','" + date_send1.ToString() + "',sddate)>=0 ";
            string sql11 = date_send2 == new DateTime() ? "" : " and datediff('d','" + date_send2.ToString() + "',sddate)<=0 ";
            string sql12 = date_pingjia1 == new DateTime() ? "" : " and datediff('d','" + date_pingjia1.ToString() + "',sddate)>=0 ";
            string sql13 = date_pingjia2 == new DateTime() ? "" : " and datediff('d','" + date_pingjia2.ToString() + "',sddate)<=0 ";
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + sql9 + sql10 + sql11 + sql12 + sql13;
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
        /// <param name="gid">商品ID</param>
        /// <param name="aid">账号ID</param>
        /// <param name="state">刷单状态 1正常 2作废</param>
        /// <param name="state_send">发货状态 1未发货 2已发货</param>
        /// <param name="state_pingjia">评价状态 1未评价 2已评价</param>
        /// <param name="date1">刷单时间</param>
        /// <param name="date2">刷单时间</param>
        /// <param name="date_send1">发货时间</param>
        /// <param name="date_send2">发货时间</param>
        /// <param name="date_pingjia1">评价时间</param>
        /// <param name="date_pingjia2">评价时间</param>
        /// <param name="_top">查询数量</param>
        /// <returns>IList<shuadan></returns>
        public IList<shuadan> Search(int s, int e, string key, int gid, int aid, string state, string state_send, string state_pingjia, DateTime date1, DateTime date2, DateTime date_send1, DateTime date_send2, DateTime date_pingjia1, DateTime date_pingjia2, string _top)
        {
            string sql = string.IsNullOrEmpty(_top) ? " shuadan " : "( select top " + _top + " * from shuadan order by sddate desc,sdid asc )";
            string sql1 = "select top " + e.ToString() + " * from " + sql + " where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  sdordercode like '%" + key + "%' or  sdaccount like '%" + key + "%' or  sdapwd like '%" + key + "%' or  sdremark like '%" + key + "%' or  sdname like '%" + key + "%' or  sdphone like '%" + key + "%' or  sdpostname like '%" + key + "%' or  sdprovince like '%" + key + "%' or  scity like '%" + key + "%' or  sdistrict like '%" + key + "%' or  sdaddress like '%" + key + "%' or  gname like '%" + key + "%'  or  sdkdname like '%" + key + "%'  or  sdkdcode like '%" + key + "%'  or  sdnumber like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sdstate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(state_send) ? "" : " and sdsendstate= '" + state_send + "' ";
            string sql5 = string.IsNullOrEmpty(state_pingjia) ? "" : " and sdpingjiastate= '" + state_pingjia + "' ";
            string sql6 = gid == 0 ? "" : " and gid= " + gid.ToString() + " ";
            string sql7 = aid == 0 ? "" : " and sdaid= " + aid.ToString() + " ";
            string sql8 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',sddate)>=0 ";
            string sql9 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',sddate)<=0 ";
            string sql10 = date_send1 == new DateTime() ? "" : " and datediff('d','" + date_send1.ToString() + "',sddate)>=0 ";
            string sql11 = date_send2 == new DateTime() ? "" : " and datediff('d','" + date_send2.ToString() + "',sddate)<=0 ";
            string sql12 = date_pingjia1 == new DateTime() ? "" : " and datediff('d','" + date_pingjia1.ToString() + "',sddate)>=0 ";
            string sql13 = date_pingjia2 == new DateTime() ? "" : " and datediff('d','" + date_pingjia2.ToString() + "',sddate)<=0 ";
            string sql14 = " order by sddate asc,sdid asc ";//排序两个字段,否则数据容易错误
            DBHelper.sqlstr = "select * from(select top " + (e - s + 1).ToString() + " * from  ( " + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + sql9 + sql10 + sql11 + sql12 + sql13 + " order by sddate desc,sdid asc ) " + sql14 + ") order by  sddate desc,sdid asc ";
            List<shuadan> list = new List<shuadan>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan Obj = GetByReader(reader);
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
        public static OleDbParameter[] GetOleDbParameter(shuadan shuadanExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(shuadanExample.dpidfrom))
            {
                list_param.Add(new OleDbParameter("@dpidfrom", shuadanExample.dpidfrom));
            }
            else
            {
                list_param.Add(new OleDbParameter("@dpidfrom", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.dpidto))
            {
                list_param.Add(new OleDbParameter("@dpidto", shuadanExample.dpidto));
            }
            else
            {
                list_param.Add(new OleDbParameter("@dpidto", DBNull.Value));
            }
            if (shuadanExample.gid != 0)
            {
                list_param.Add(new OleDbParameter("@gid", shuadanExample.gid));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.gname))
            {
                list_param.Add(new OleDbParameter("@gname", shuadanExample.gname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.scity))
            {
                list_param.Add(new OleDbParameter("@scity", shuadanExample.scity));
            }
            else
            {
                list_param.Add(new OleDbParameter("@scity", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdaccount))
            {
                list_param.Add(new OleDbParameter("@sdaccount", shuadanExample.sdaccount));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdaccount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdaddress))
            {
                list_param.Add(new OleDbParameter("@sdaddress", shuadanExample.sdaddress));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdaddress", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdaid))
            {
                list_param.Add(new OleDbParameter("@sdaid", shuadanExample.sdaid));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdaid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdapwd))
            {
                list_param.Add(new OleDbParameter("@sdapwd", shuadanExample.sdapwd));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdapwd", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdinfofrom))
            {
                list_param.Add(new OleDbParameter("@sdinfofrom", shuadanExample.sdinfofrom));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdinfofrom", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdistrict))
            {
                list_param.Add(new OleDbParameter("@sdistrict", shuadanExample.sdistrict));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdistrict", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdkdcode))
            {
                list_param.Add(new OleDbParameter("@sdkdcode", shuadanExample.sdkdcode));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdkdcode", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdkdname))
            {
                list_param.Add(new OleDbParameter("@sdkdname", shuadanExample.sdkdname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdkdname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdname))
            {
                list_param.Add(new OleDbParameter("@sdname", shuadanExample.sdname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdnumber))
            {
                list_param.Add(new OleDbParameter("@sdnumber", shuadanExample.sdnumber));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdnumber", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdordercode))
            {
                list_param.Add(new OleDbParameter("@sdordercode", shuadanExample.sdordercode));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdordercode", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdphone))
            {
                list_param.Add(new OleDbParameter("@sdphone", shuadanExample.sdphone));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdphone", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdpingjiastate))
            {
                list_param.Add(new OleDbParameter("@sdpingjiastate", shuadanExample.sdpingjiastate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdpingjiastate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdpostname))
            {
                list_param.Add(new OleDbParameter("@sdpostname", shuadanExample.sdpostname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdpostname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdprovince))
            {
                list_param.Add(new OleDbParameter("@sdprovince", shuadanExample.sdprovince));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdprovince", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdremark))
            {
                list_param.Add(new OleDbParameter("@sdremark", shuadanExample.sdremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdsendstate))
            {
                list_param.Add(new OleDbParameter("@sdsendstate", shuadanExample.sdsendstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdsendstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdstandby))
            {
                list_param.Add(new OleDbParameter("@sdstandby", shuadanExample.sdstandby));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdstandby", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdstandby1))
            {
                list_param.Add(new OleDbParameter("@sdstandby1", shuadanExample.sdstandby1));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdstandby1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdstandby2))
            {
                list_param.Add(new OleDbParameter("@sdstandby2", shuadanExample.sdstandby2));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdstandby2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdstandby3))
            {
                list_param.Add(new OleDbParameter("@sdstandby3", shuadanExample.sdstandby3));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdstandby3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdstate))
            {
                list_param.Add(new OleDbParameter("@sdstate", shuadanExample.sdstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdstate", DBNull.Value));
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
        /// <returns>shuadanExample</returns>
        public static shuadan GetByReader(OleDbDataReader Reader)
        {
            shuadan shuadanExample = new shuadan();
            shuadanExample.dpidfrom = Reader["dpidfrom"] == DBNull.Value ? null : Reader["dpidfrom"].ToString();
            shuadanExample.dpidto = Reader["dpidto"] == DBNull.Value ? null : Reader["dpidto"].ToString();
            shuadanExample.gid = Reader["gid"] == DBNull.Value ? 0 : (int)Reader["gid"];
            shuadanExample.gname = Reader["gname"] == DBNull.Value ? null : Reader["gname"].ToString();
            shuadanExample.scity = Reader["scity"] == DBNull.Value ? null : Reader["scity"].ToString();
            shuadanExample.sdaccount = Reader["sdaccount"] == DBNull.Value ? null : Reader["sdaccount"].ToString();
            shuadanExample.sdaddress = Reader["sdaddress"] == DBNull.Value ? null : Reader["sdaddress"].ToString();
            shuadanExample.sdaid = Reader["sdaid"] == DBNull.Value ? null : Reader["sdaid"].ToString();
            shuadanExample.sdapwd = Reader["sdapwd"] == DBNull.Value ? null : Reader["sdapwd"].ToString();
            shuadanExample.sddate = Reader["sddate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sddate"]);
            shuadanExample.sdid = Reader["sdid"] == DBNull.Value ? 0 : (int)Reader["sdid"];
            shuadanExample.sdinfofrom = Reader["sdinfofrom"] == DBNull.Value ? null : Reader["sdinfofrom"].ToString();
            shuadanExample.sdistrict = Reader["sdistrict"] == DBNull.Value ? null : Reader["sdistrict"].ToString();
            shuadanExample.sdkdcode = Reader["sdkdcode"] == DBNull.Value ? null : Reader["sdkdcode"].ToString();
            shuadanExample.sdkdname = Reader["sdkdname"] == DBNull.Value ? null : Reader["sdkdname"].ToString();
            shuadanExample.sdname = Reader["sdname"] == DBNull.Value ? null : Reader["sdname"].ToString();
            shuadanExample.sdnumber = Reader["sdnumber"] == DBNull.Value ? null : Reader["sdnumber"].ToString();
            shuadanExample.sdordercode = Reader["sdordercode"] == DBNull.Value ? null : Reader["sdordercode"].ToString();
            shuadanExample.sdphone = Reader["sdphone"] == DBNull.Value ? null : Reader["sdphone"].ToString();
            shuadanExample.sdpingjiadate = Reader["sdpingjiadate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sdpingjiadate"]);
            shuadanExample.sdpingjiastate = Reader["sdpingjiastate"] == DBNull.Value ? null : Reader["sdpingjiastate"].ToString();
            shuadanExample.sdpostname = Reader["sdpostname"] == DBNull.Value ? null : Reader["sdpostname"].ToString();
            shuadanExample.sdprovince = Reader["sdprovince"] == DBNull.Value ? null : Reader["sdprovince"].ToString();
            shuadanExample.sdremark = Reader["sdremark"] == DBNull.Value ? null : Reader["sdremark"].ToString();
            shuadanExample.sdsenddate = Reader["sdsenddate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sdsenddate"]);
            shuadanExample.sdsendstate = Reader["sdsendstate"] == DBNull.Value ? null : Reader["sdsendstate"].ToString();
            shuadanExample.sdstandby = Reader["sdstandby"] == DBNull.Value ? null : Reader["sdstandby"].ToString();
            shuadanExample.sdstandby1 = Reader["sdstandby1"] == DBNull.Value ? null : Reader["sdstandby1"].ToString();
            shuadanExample.sdstandby2 = Reader["sdstandby2"] == DBNull.Value ? null : Reader["sdstandby2"].ToString();
            shuadanExample.sdstandby3 = Reader["sdstandby3"] == DBNull.Value ? null : Reader["sdstandby3"].ToString();
            shuadanExample.sdstate = Reader["sdstate"] == DBNull.Value ? null : Reader["sdstate"].ToString();
            return shuadanExample;
        }
        #endregion





        #endregion
    }
   
   







}

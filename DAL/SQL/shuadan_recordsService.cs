using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{



    public class shuadan_recordsService : Ishuadan_recordsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_records> SearchAll()
        {
            DBHelper.sqlstr = "select * from shuadan_records order by sddate desc ";
            List<shuadan_records> list = new List<shuadan_records>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_records Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据sdid,查询一条数据
        /// </summary>
        /// <param name="sdid"></param>
        /// <returns></returns>
        /*查看是否为视图*/

        public shuadan_records SearchByID(int sdid)
        {
            DBHelper.sqlstr = "select * from shuadan_records where sdid = @sdid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@sdid",sdid)
            };
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            shuadan_records Obj = null;
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
        /// <param name="shuadan_records">shuadan_records表实例</param>
        /// <returns>int</returns>
        public int Insert(shuadan_records shuadan_recordsExample)
        {
            DBHelper.sqlstr = "insert into  shuadan_records (sdgoodsname,sdgoodsurl,sddptype,sddate,sdorderid,sdphone,sdvpn,sdaddress,sdwuliu,sdremark1,sdremark3,sdremark2,sdremark4,sdremark5,sdremark6)values(@sdgoodsname,@sdgoodsurl,@sddptype,@sddate,@sdorderid,@sdphone,@sdvpn,@sdaddress,@sdwuliu,@sdremark1,@sdremark3,@sdremark2,@sdremark4,@sdremark5,@sdremark6)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(shuadan_recordsExample));
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan_records">shuadan_records表实例</param>
        /// <returns>int</returns>
        //public int Insert(shuadan_records shuadan_recordsExample)
        //{
        //    DBHelper.sqlstr = "insert into  shuadan_records (sdgoodsname,sdgoodsurl,sddptype,sddate,sdorderid,sdphone,sdvpn,sdaddress,sdwuliu,sdremark1,sdremark3,sdremark2,sdremark4,sdremark5,sdremark6)values(@sdgoodsname,@sdgoodsurl,@sddptype,'" + shuadan_recordsExample.sddate.ToString("yyyy-MM-dd") + "',@sdorderid,@sdphone,@sdvpn,@sdaddress,@sdwuliu,@sdremark1,@sdremark3,@sdremark2,@sdremark4,@sdremark5,@sdremark6)";
        //    return DBHelper.ExecuteNonQuery(GetSqlParameters(shuadan_recordsExample));
        //}
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_records">shuadan_records表实例</param>
        /// <returns>int</returns>
        public int Update(shuadan_records shuadan_recordsExample)
        {
            DBHelper.sqlstr = "update shuadan_records set sdgoodsname=@sdgoodsname,sdgoodsurl=@sdgoodsurl,sddptype=@sddptype,sddate='" + shuadan_recordsExample.sddate.ToString("yyyy-MM-dd") + "',sdorderid=@sdorderid,sdphone=@sdphone,sdvpn=@sdvpn,sdaddress=@sdaddress,sdwuliu=@sdwuliu,sdremark1=@sdremark1,sdremark3=@sdremark3,sdremark2=@sdremark2,sdremark4=@sdremark4,sdremark5=@sdremark5,sdremark6=@sdremark6 where sdid=" + shuadan_recordsExample.sdid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(shuadan_recordsExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdid"></param>
        /// <returns>int</returns>
        public int Delete(int sdid)
        {
            DBHelper.sqlstr = "delete shuadan_records where sdid =@sdid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@sdid",sdid)
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
        public int SearchNum(string key, string state, string state_kongbao, string state_fahuo, string state_shoucai, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(sdid) from shuadan_records where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( sdgoodsname like '%" + key + "%' or sdgoodsurl like '%" + key + "%'  or sdorderid like '%" + key + "%' or sdphone like '%" + key + "%' or sdvpn like '%" + key + "%' or sdaddress like '%" + key + "%' or sdwuliu like '%" + key + "%' or sdremark1 like '%" + key + "%' or sdremark3 like '%" + key + "%' or sdremark2 like '%" + key + "%' or sdremark4 like '%" + key + "%' or sdremark5 like '%" + key + "%' or sdremark6 like '%" + key + "%' )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sddptype= '" + state + "' ";//状态字段，无用删除
            string sql4 = string.IsNullOrEmpty(state_kongbao) ? "" : " and sdremark3= '" + state_kongbao + "' ";
            string sql44 = string.IsNullOrEmpty(state_fahuo) ? "" : " and sdremark4= '" + state_fahuo + "' ";
            string sql45 = string.IsNullOrEmpty(state_shoucai) ? "" : " and sdremark2= '" + state_shoucai + "' ";
            //string sql4 = id == 0 ? "" : " and id字段='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',sddate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',sddate)<=0 ";//时间字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql44+ sql45 + sql5 + sql6;
            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="s">起始位置1</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">店铺类型</param>
        /// <param name="state_kongbao">空包状态</param>
        /// <param name="state_fahuo">发货状态</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序方式</param>
        /// <returns></returns>
        public IList<shuadan_records> Search(int s, int e, string key, string state, string state_kongbao, string state_shoucai, string state_fahuo, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select top " + (e - s + 1).ToString() + " * from shuadan_records where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( sdgoodsname like '%" + key + "%' or sdgoodsurl like '%" + key + "%' or sdorderid like '%" + key + "%' or sdphone like '%" + key + "%' or sdvpn like '%" + key + "%' or sdaddress like '%" + key + "%' or sdwuliu like '%" + key + "%' or sdremark1 like '%" + key + "%' or sdremark3 like '%" + key + "%' or sdremark2 like '%" + key + "%' or sdremark4 like '%" + key + "%' or sdremark5 like '%" + key + "%' or sdremark6 like '%" + key + "%' )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sddptype= '" + state + "' ";//状态字段，无用删除
            string sql4 = string.IsNullOrEmpty(state_kongbao) ? "" : " and sdremark3= '" + state_kongbao + "' ";
            string sql44 = string.IsNullOrEmpty(state_fahuo) ? "" : " and sdremark4= '" + state_fahuo + "' ";
            string sql45 = string.IsNullOrEmpty(state_shoucai) ? "" : " and sdremark2= '" + state_shoucai + "' ";
            //string sql4 = id == 0 ? "" : " and id字段='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',sddate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',sddate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by sddate asc " : " order by " + orderby;
            string sql8 = s == 1 ? "" : " and sdid not in ( select top " + (s - 1).ToString() + " sdid from shuadan_records where " + sql2 + sql3 + sql4 + sql44 + sql45 + sql5 + sql6 + sql7 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql44 + sql45 + sql5 + sql6 + sql8 + sql7;
            List<shuadan_records> list = new List<shuadan_records>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_records Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="s">起始位置1</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">店铺类型</param>
        /// <param name="state_kongbao">空包状态</param>
        /// <param name="state_fahuo">发货状态</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序方式</param>
        /// <returns></returns>
        public IList<shuadan_records> Search(int s, int e, string key, string state,string orderstate, string state_kongbao, string state_shoucai, string state_fahuo, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select top " + (e - s + 1).ToString() + " * from shuadan_records where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( sdgoodsname like '%" + key + "%' or sdgoodsurl like '%" + key + "%' or sdorderid like '%" + key + "%' or sdphone like '%" + key + "%' or sdvpn like '%" + key + "%' or sdaddress like '%" + key + "%' or sdwuliu like '%" + key + "%' or sdremark1 like '%" + key + "%' or sdremark3 like '%" + key + "%' or sdremark2 like '%" + key + "%' or sdremark4 like '%" + key + "%' or sdremark5 like '%" + key + "%' or sdremark6 like '%" + key + "%' )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and sddptype= '" + state + "' ";//状态字段，无用删除
            string sql33 = string.IsNullOrEmpty(orderstate) ? "" : " and sdremark6= '" + orderstate + "' ";//状态字段，无用删除
            string sql4 = string.IsNullOrEmpty(state_kongbao) ? "" : " and sdremark3= '" + state_kongbao + "' ";
            string sql44 = string.IsNullOrEmpty(state_fahuo) ? "" : " and sdremark4= '" + state_fahuo + "' ";
            string sql45 = string.IsNullOrEmpty(state_shoucai) ? "" : " and sdremark2= '" + state_shoucai + "' ";
            //string sql4 = id == 0 ? "" : " and id字段='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',sddate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',sddate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by sddate asc " : " order by " + orderby;
            string sql8 = s == 1 ? "" : " and sdid not in ( select top " + (s - 1).ToString() + " sdid from shuadan_records where " + sql2 + sql3+ sql33 + sql4 + sql44 + sql45 + sql5 + sql6 + sql7 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3+ sql33 + sql4 + sql44 + sql45 + sql5 + sql6 + sql8 + sql7;
            List<shuadan_records> list = new List<shuadan_records>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_records Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchToBuDan_GetAddress
        /// <summary>
        /// 获取补单需要的地址信息
        /// </summary>
        /// <param name="num">获取的条数</param>
        /// <param name="indexx">从这里开始</param>
        /// <returns></returns>
        public IList<shuadan_records> SearchToBuDan_GetAddress(int num, int indexx)
        {
            string sql1 = "select top " + num.ToString() + " * from shuadan_records where ";
            string sql2= " [sdaddress] <>'' and [sdaddress] IS NOT NULL AND [sdid] NOT IN (select top " + indexx.ToString() + " [sdid]  from  [shuadan_records] WHERE [sdaddress] <>'' and [sdaddress] IS NOT NULL  ) order by [sdid]  ASC ";
            DBHelper.sqlstr = sql1 + sql2;
            List<shuadan_records> list = new List<shuadan_records>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_records Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion


        //

        #region SearchWeiFaHuo
        /// <summary>
        /// 查询未发货信息
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_records> SearchWeiFaHuo(string t)
        {
            //DBHelper.sqlstr = "SELECT * FROM shuadan_records where 1=1 and ( sdwuliu ='' or sdwuliu is null ) " + (string.IsNullOrEmpty(t) ? "" : " and sddptype ='" + t + "' ");
            DBHelper.sqlstr = "SELECT * FROM shuadan_records where 1=1 and   sdremark4 ='1'   and sddptype ='" + t + "'"  ;
            List<shuadan_records> list = new List<shuadan_records>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_records Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion


        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameters(shuadan_records shuadan_recordsExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdgoodsname))
            {
                list_param.Add(new SqlParameter("@sdgoodsname", shuadan_recordsExample.sdgoodsname));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdgoodsname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdgoodsurl))
            {
                list_param.Add(new SqlParameter("@sdgoodsurl", shuadan_recordsExample.sdgoodsurl));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdgoodsurl", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sddptype))
            {
                list_param.Add(new SqlParameter("@sddptype", shuadan_recordsExample.sddptype));
            }
            else
            {
                list_param.Add(new SqlParameter("@sddptype", DBNull.Value));
            }
            if (shuadan_recordsExample.sddate != new DateTime() && shuadan_recordsExample.sddate != null)
            {
                //DateTime dt = new DateTime();
                //DateTime.TryParse(shuadan_recordsExample.sddate.ToString("yyyy-MM-dd HH:mm:ss"), out dt);
                list_param.Add(new SqlParameter("@sddate", shuadan_recordsExample.sddate.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else
            {
                list_param.Add(new SqlParameter("@sddate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdorderid))
            {
                list_param.Add(new SqlParameter("@sdorderid", shuadan_recordsExample.sdorderid));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdorderid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdphone))
            {
                list_param.Add(new SqlParameter("@sdphone", shuadan_recordsExample.sdphone));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdphone", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdvpn))
            {
                list_param.Add(new SqlParameter("@sdvpn", shuadan_recordsExample.sdvpn));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdvpn", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdaddress))
            {
                list_param.Add(new SqlParameter("@sdaddress", shuadan_recordsExample.sdaddress));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdaddress", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdwuliu))
            {
                list_param.Add(new SqlParameter("@sdwuliu", shuadan_recordsExample.sdwuliu));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdwuliu", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark1))
            {
                list_param.Add(new SqlParameter("@sdremark1", shuadan_recordsExample.sdremark1));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark3))
            {
                list_param.Add(new SqlParameter("@sdremark3", shuadan_recordsExample.sdremark3));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark2))
            {
                list_param.Add(new SqlParameter("@sdremark2", shuadan_recordsExample.sdremark2));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark4))
            {
                list_param.Add(new SqlParameter("@sdremark4", shuadan_recordsExample.sdremark4));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark4", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark5))
            {
                list_param.Add(new SqlParameter("@sdremark5", shuadan_recordsExample.sdremark5));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark5", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdremark6))
            {
                list_param.Add(new SqlParameter("@sdremark6", shuadan_recordsExample.sdremark6));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark6", DBNull.Value));
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
        /// <returns>shuadan_recordsExample</returns>
        public static shuadan_records GetByReader(SqlDataReader Reader)
        {
            shuadan_records shuadan_recordsExample = new shuadan_records();
            shuadan_recordsExample.sdid = Reader["sdid"] == DBNull.Value ? 0 : (int)Reader["sdid"];
            shuadan_recordsExample.sdgoodsname = Reader["sdgoodsname"] == DBNull.Value ? null : Reader["sdgoodsname"].ToString();
            shuadan_recordsExample.sdgoodsurl = Reader["sdgoodsurl"] == DBNull.Value ? null : Reader["sdgoodsurl"].ToString();
            shuadan_recordsExample.sddptype = Reader["sddptype"] == DBNull.Value ? null : Reader["sddptype"].ToString();
            shuadan_recordsExample.sddate = Reader["sddate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sddate"]);
            shuadan_recordsExample.sdorderid = Reader["sdorderid"] == DBNull.Value ? null : Reader["sdorderid"].ToString();
            shuadan_recordsExample.sdphone = Reader["sdphone"] == DBNull.Value ? null : Reader["sdphone"].ToString();
            shuadan_recordsExample.sdvpn = Reader["sdvpn"] == DBNull.Value ? null : Reader["sdvpn"].ToString();
            shuadan_recordsExample.sdaddress = Reader["sdaddress"] == DBNull.Value ? null : Reader["sdaddress"].ToString();
            shuadan_recordsExample.sdwuliu = Reader["sdwuliu"] == DBNull.Value ? null : Reader["sdwuliu"].ToString();
            shuadan_recordsExample.sdremark1 = Reader["sdremark1"] == DBNull.Value ? null : Reader["sdremark1"].ToString();
            shuadan_recordsExample.sdremark3 = Reader["sdremark3"] == DBNull.Value ? null : Reader["sdremark3"].ToString();
            shuadan_recordsExample.sdremark2 = Reader["sdremark2"] == DBNull.Value ? null : Reader["sdremark2"].ToString();
            shuadan_recordsExample.sdremark4 = Reader["sdremark4"] == DBNull.Value ? null : Reader["sdremark4"].ToString();
            shuadan_recordsExample.sdremark5 = Reader["sdremark5"] == DBNull.Value ? null : Reader["sdremark5"].ToString();
            shuadan_recordsExample.sdremark6 = Reader["sdremark6"] == DBNull.Value ? null : Reader["sdremark6"].ToString();
            return shuadan_recordsExample;
        }
        #endregion





        #endregion
    }








}

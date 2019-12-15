using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using IDAL;
using System.Data.SqlClient;

namespace DAL
{


    //表名称：shuadan
    //实体类名称：shuadanExample
    //主键：sdid

    public class shuadanService 
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan> SearchAll()
        {
            DBHelper.sqlstr = "select * from shuadan ";
            List<shuadan> list = new List<shuadan>();
            SqlDataReader reader = DBHelper.ExecuteReader();
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
        /// <param name="sdid"></param>
        /// <returns></returns>
        public shuadan SearchBysdid(int sdid)
        {
            DBHelper.sqlstr = "select * from shuadan where sdid = @sdid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@sdid",sdid)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
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
            DBHelper.sqlstr = "insert into  shuadan (dpidfrom,dpidto,sdaccount,sdaddress,sdaid,sdapwd,sddate,sdkdcode,sdordercode,sdpingjiadate,sdpingjiastate,sdremark,sdsenddate,sdsendstate,sdstandby,sdstate)values('" + shuadanExample.dpidfrom.ToString() + "',@dpidto,@sdaccount,@sdaddress,@sdaid,@sdapwd,'" + shuadanExample.sddate.ToString() + "',@sdkdcode,@sdordercode,'" + shuadanExample.sdpingjiadate.ToString() + "',@sdpingjiastate,@sdremark,'" + shuadanExample.sdsenddate.ToString() + "',@sdsendstate,@sdstandby,@sdstate)";
            return DBHelper.ExecuteNonQuery(GetSqlParameter(shuadanExample));
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
            DBHelper.sqlstr = "update shuadan set dpidfrom='" + shuadanExample.dpidfrom.ToString() + "',dpidto=@dpidto,sdaccount=@sdaccount,sdaddress=@sdaddress,sdaid=@sdaid,sdapwd=@sdapwd,sddate='" + shuadanExample.sddate.ToString() + "',sdkdcode=@sdkdcode,sdordercode=@sdordercode,sdpingjiadate='" + shuadanExample.sdpingjiadate.ToString() + "',sdpingjiastate=@sdpingjiastate,sdremark=@sdremark,sdsenddate='" + shuadanExample.sdsenddate.ToString() + "',sdsendstate=@sdsendstate,sdstandby=@sdstandby,sdstate=@sdstate where sdid=" + shuadanExample.sdid;
            return DBHelper.ExecuteNonQuery(GetSqlParameter(shuadanExample));
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
            DBHelper.sqlstr = "delete from shuadan where sdid =@sdid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@sdid",sdid)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion




        #region 公共方法

        #region GetSqlParameter
        /// <summary>
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameter(shuadan shuadanExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(shuadanExample.dpidfrom))
            {
                list_param.Add(new SqlParameter("@dpidfrom", shuadanExample.dpidfrom));
            }
            else
            {
                list_param.Add(new SqlParameter("@dpidfrom", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.dpidto))
            {
                list_param.Add(new SqlParameter("@dpidto", shuadanExample.dpidto));
            }
            else
            {
                list_param.Add(new SqlParameter("@dpidto", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdaccount))
            {
                list_param.Add(new SqlParameter("@sdaccount", shuadanExample.sdaccount));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdaccount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdaddress))
            {
                list_param.Add(new SqlParameter("@sdaddress", shuadanExample.sdaddress));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdaddress", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdaid))
            {
                list_param.Add(new SqlParameter("@sdaid", shuadanExample.sdaid));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdaid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdapwd))
            {
                list_param.Add(new SqlParameter("@sdapwd", shuadanExample.sdapwd));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdapwd", DBNull.Value));
            }
            if (shuadanExample.sddate != new DateTime() && shuadanExample.sddate != null)
            {
                list_param.Add(new SqlParameter("@sddate", shuadanExample.sddate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@sddate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdkdcode))
            {
                list_param.Add(new SqlParameter("@sdkdcode", shuadanExample.sdkdcode));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdkdcode", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdordercode))
            {
                list_param.Add(new SqlParameter("@sdordercode", shuadanExample.sdordercode));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdordercode", DBNull.Value));
            }
            if (shuadanExample.sdpingjiadate != new DateTime() && shuadanExample.sdpingjiadate != null)
            {
                list_param.Add(new SqlParameter("@sdpingjiadate", shuadanExample.sdpingjiadate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdpingjiadate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdpingjiastate))
            {
                list_param.Add(new SqlParameter("@sdpingjiastate", shuadanExample.sdpingjiastate));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdpingjiastate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdremark))
            {
                list_param.Add(new SqlParameter("@sdremark", shuadanExample.sdremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdremark", DBNull.Value));
            }
            if (shuadanExample.sdsenddate != new DateTime() && shuadanExample.sdsenddate != null)
            {
                list_param.Add(new SqlParameter("@sdsenddate", shuadanExample.sdsenddate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdsenddate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdsendstate))
            {
                list_param.Add(new SqlParameter("@sdsendstate", shuadanExample.sdsendstate));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdsendstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdstandby))
            {
                list_param.Add(new SqlParameter("@sdstandby", shuadanExample.sdstandby));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdstandby", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdstate))
            {
                list_param.Add(new SqlParameter("@sdstate", shuadanExample.sdstate));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdstate", DBNull.Value));
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
        /// <returns>shuadanExample</returns>
        public static shuadan GetByReader(SqlDataReader Reader)
        {
            shuadan shuadanExample = new shuadan();
            shuadanExample.dpidfrom = Reader["dpidfrom"] == DBNull.Value ? null : Reader["dpidfrom"].ToString();
            shuadanExample.dpidto = Reader["dpidto"] == DBNull.Value ? null : Reader["dpidto"].ToString();
            shuadanExample.sdaccount = Reader["sdaccount"] == DBNull.Value ? null : Reader["sdaccount"].ToString();
            shuadanExample.sdaddress = Reader["sdaddress"] == DBNull.Value ? null : Reader["sdaddress"].ToString();
            shuadanExample.sdaid = Reader["sdaid"] == DBNull.Value ? null : Reader["sdaid"].ToString();
            shuadanExample.sdapwd = Reader["sdapwd"] == DBNull.Value ? null : Reader["sdapwd"].ToString();
            shuadanExample.sddate = Reader["sddate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sddate"]);
            shuadanExample.sdid = Reader["sdid"] == DBNull.Value ? 0 : (int)Reader["sdid"];
            shuadanExample.sdkdcode = Reader["sdkdcode"] == DBNull.Value ? null : Reader["sdkdcode"].ToString();
            shuadanExample.sdordercode = Reader["sdordercode"] == DBNull.Value ? null : Reader["sdordercode"].ToString();
            shuadanExample.sdpingjiadate = Reader["sdpingjiadate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sdpingjiadate"]);
            shuadanExample.sdpingjiastate = Reader["sdpingjiastate"] == DBNull.Value ? null : Reader["sdpingjiastate"].ToString();
            shuadanExample.sdremark = Reader["sdremark"] == DBNull.Value ? null : Reader["sdremark"].ToString();
            shuadanExample.sdsenddate = Reader["sdsenddate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sdsenddate"]);
            shuadanExample.sdsendstate = Reader["sdsendstate"] == DBNull.Value ? null : Reader["sdsendstate"].ToString();
            shuadanExample.sdstandby = Reader["sdstandby"] == DBNull.Value ? null : Reader["sdstandby"].ToString();
            shuadanExample.sdstate = Reader["sdstate"] == DBNull.Value ? null : Reader["sdstate"].ToString();
            return shuadanExample;
        }
        #endregion





        #endregion
    }
  
   
	
	
	
	

}

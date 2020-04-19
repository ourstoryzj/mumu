using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using IDAL;
using MySql.Data.MySqlClient;

namespace DAL.MySql
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
            MySqlDataReader reader = DBHelper.ExecuteReader();
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
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@sdid",sdid)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
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
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@sdid",sdid)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion




        #region 公共方法

        #region GetSqlParameter
        /// <summary>
        /// 根据表,获取一个MySqlParameter数组
        /// </summary>
        /// <returns>MySqlParameter[]</returns>
        public static MySqlParameter[] GetSqlParameter(shuadan shuadanExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();
            if (!string.IsNullOrEmpty(shuadanExample.dpidfrom))
            {
                list_param.Add(new MySqlParameter("@dpidfrom", shuadanExample.dpidfrom));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpidfrom", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.dpidto))
            {
                list_param.Add(new MySqlParameter("@dpidto", shuadanExample.dpidto));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpidto", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdaccount))
            {
                list_param.Add(new MySqlParameter("@sdaccount", shuadanExample.sdaccount));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdaccount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdaddress))
            {
                list_param.Add(new MySqlParameter("@sdaddress", shuadanExample.sdaddress));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdaddress", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdaid))
            {
                list_param.Add(new MySqlParameter("@sdaid", shuadanExample.sdaid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdaid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdapwd))
            {
                list_param.Add(new MySqlParameter("@sdapwd", shuadanExample.sdapwd));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdapwd", DBNull.Value));
            }
            if (shuadanExample.sddate != new DateTime() && shuadanExample.sddate != null)
            {
                list_param.Add(new MySqlParameter("@sddate", shuadanExample.sddate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sddate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdkdcode))
            {
                list_param.Add(new MySqlParameter("@sdkdcode", shuadanExample.sdkdcode));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdkdcode", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdordercode))
            {
                list_param.Add(new MySqlParameter("@sdordercode", shuadanExample.sdordercode));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdordercode", DBNull.Value));
            }
            if (shuadanExample.sdpingjiadate != new DateTime() && shuadanExample.sdpingjiadate != null)
            {
                list_param.Add(new MySqlParameter("@sdpingjiadate", shuadanExample.sdpingjiadate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdpingjiadate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdpingjiastate))
            {
                list_param.Add(new MySqlParameter("@sdpingjiastate", shuadanExample.sdpingjiastate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdpingjiastate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdremark))
            {
                list_param.Add(new MySqlParameter("@sdremark", shuadanExample.sdremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdremark", DBNull.Value));
            }
            if (shuadanExample.sdsenddate != new DateTime() && shuadanExample.sdsenddate != null)
            {
                list_param.Add(new MySqlParameter("@sdsenddate", shuadanExample.sdsenddate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdsenddate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdsendstate))
            {
                list_param.Add(new MySqlParameter("@sdsendstate", shuadanExample.sdsendstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdsendstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdstandby))
            {
                list_param.Add(new MySqlParameter("@sdstandby", shuadanExample.sdstandby));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdstandby", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadanExample.sdstate))
            {
                list_param.Add(new MySqlParameter("@sdstate", shuadanExample.sdstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdstate", DBNull.Value));
            }
            MySqlParameter[] param = new MySqlParameter[list_param.Count];
            int index = 0;
            foreach (MySqlParameter p in list_param)
            {
                param[index] = p;
                index++;
            }
            return param;
        }
        #endregion

        #region GetByReader
        /// <summary>
        /// 从一个MySqlDataReader里读数据
        /// </summary>
        /// <param name="Reader">MySqlDataReader</param>
        /// <returns>shuadanExample</returns>
        public static shuadan GetByReader(MySqlDataReader Reader)
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

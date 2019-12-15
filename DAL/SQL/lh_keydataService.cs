using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{

    public class lh_keydataService : Ilh_keydataService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<lh_keydata> SearchAll()
        {
            DBHelper.sqlstr = "select * from lh_keydata ";
            List<lh_keydata> list = new List<lh_keydata>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                lh_keydata Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据kid,查询一条数据
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public lh_keydata SearchByID(int kid)
        {
            DBHelper.sqlstr = "select * from lh_keydata where kid = @kid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@kid",kid)
            };
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            lh_keydata Obj = null;
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
        /// <param name="lh_keydata">lh_keydata表实例</param>
        /// <returns>int</returns>
        public int Insert(lh_keydata lh_keydataExample)
        {
            DBHelper.sqlstr = "insert into  lh_keydata (kname,kstate,kdate,hid,rid,kremark,kbackup1,kbackup2,kbackup3,kbackup4,kbackup5,ksousuorenqi,kzhifuzhuanhualv,kzaixianshangpinshu,kshangchengzhanbi,kzhitongchejiage,kjingzheng)values(@kname,@kstate,@kdate,@hid,@rid,@kremark,@kbackup1,@kbackup2,@kbackup3,@kbackup4,@kbackup5,@ksousuorenqi,@kzhifuzhuanhualv,@kzaixianshangpinshu,@kshangchengzhanbi,@kzhitongchejiage,@kjingzheng)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(lh_keydataExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="lh_keydata">lh_keydata表实例</param>
        /// <returns>int</returns>
        public int Update(lh_keydata lh_keydataExample)
        {
            DBHelper.sqlstr = "update lh_keydata set kname=@kname,kstate=@kstate,kdate=@kdate,hid=@hid,rid=@rid,kremark=@kremark,kbackup1=@kbackup1,kbackup2=@kbackup2,kbackup3=@kbackup3,kbackup4=@kbackup4,kbackup5=@kbackup5,ksousuorenqi=@ksousuorenqi,kzhifuzhuanhualv=@kzhifuzhuanhualv,kzaixianshangpinshu=@kzaixianshangpinshu,kshangchengzhanbi=@kshangchengzhanbi,kzhitongchejiage=@kzhitongchejiage,kjingzheng=@kjingzheng where kid=" + lh_keydataExample.kid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(lh_keydataExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        public int Delete(int kid)
        {
            DBHelper.sqlstr = "delete lh_keydata where kid =@kid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@kid",kid)
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
        public int SearchNum(string key, string state, int hid, int rid, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(kid) from lh_keydata where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( kname like '%" + key + "%' or kstate like '%" + key + "%' or kremark like '%" + key + "%' or kbackup1 like '%" + key + "%' or kbackup2 like '%" + key + "%' or kbackup3 like '%" + key + "%' or kbackup4 like '%" + key + "%' or kbackup5 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and kstate= '" + state + "' ";//状态字段，无用删除
            string sql4 = hid == 0 ? "" : " and hid='" + hid.ToString() + "' ";//Int字段，无用删除
            string sql41 = rid == 0 ? "" : " and rid='" + rid.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',kdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',kdate)<=0 ";//时间字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql41 + sql5 + sql6;
            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="id">int字段</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序</param>
        /// <returns>IList<lh_keydata></returns>
        public IList<lh_keydata> Search(int s, int e, string key, string state, int hid, int rid, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select top " + (e - s + 1).ToString() + " * from lh_keydata where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( kname like '%" + key + "%' or kstate like '%" + key + "%' or kremark like '%" + key + "%' or kbackup1 like '%" + key + "%' or kbackup2 like '%" + key + "%' or kbackup3 like '%" + key + "%' or kbackup4 like '%" + key + "%' or kbackup5 like '%" + key + "%' )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and kstate= '" + state + "' ";//状态字段，无用删除
            string sql4 = hid == 0 ? "" : " and hid='" + hid.ToString() + "' ";//Int字段，无用删除
            string sql41 = rid == 0 ? "" : " and rid='" + rid.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',kdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',kdate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by kjingzheng desc " : " order by " + orderby;
            string sql8 = s == 1 ? "" : " and kid not in ( select top " + (s - 1).ToString() + " kid from lh_keydata where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql41 + sql5 + sql6 + sql8 + sql7;
            List<lh_keydata> list = new List<lh_keydata>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                lh_keydata Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region DeleteByRid
        /// <summary>
        /// 删除排行榜的所有关键词
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        public int DeleteByRid(int rid)
        {
            DBHelper.sqlstr = "delete lh_keydata where rid =@rid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@rid",rid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region DeleteByHid
        /// <summary>
        /// 根据行业删除关键词
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        public int DeleteByHid(int hid)
        {
            DBHelper.sqlstr = "delete lh_keydata where hid =@hid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@hid",hid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region DeleteByDate
        /// <summary>
        /// 根据日期删除关键词
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        public int DeleteByDate(DateTime dt)
        { 
            //如果不行就用SELECT * FROM [keys] WHERE [kdate] = '2018-08-12' 
            DBHelper.sqlstr = "delete lh_keydata where kdate =@kdate";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@kdate",dt)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion





        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameters(lh_keydata lh_keydataExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(lh_keydataExample.kname))
            {
                list_param.Add(new SqlParameter("@kname", lh_keydataExample.kname));
            }
            else
            {
                list_param.Add(new SqlParameter("@kname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_keydataExample.kstate))
            {
                list_param.Add(new SqlParameter("@kstate", lh_keydataExample.kstate));
            }
            else
            {
                list_param.Add(new SqlParameter("@kstate", DBNull.Value));
            }
            if (lh_keydataExample.kdate != new DateTime() && lh_keydataExample.kdate != null)
            {
                list_param.Add(new SqlParameter("@kdate", lh_keydataExample.kdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@kdate", DBNull.Value));
            }
            if (lh_keydataExample.hid != 0)
            {
                list_param.Add(new SqlParameter("@hid", lh_keydataExample.hid));
            }
            else
            {
                list_param.Add(new SqlParameter("@hid", DBNull.Value));
            }
            if (lh_keydataExample.rid != 0)
            {
                list_param.Add(new SqlParameter("@rid", lh_keydataExample.rid));
            }
            else
            {
                list_param.Add(new SqlParameter("@rid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_keydataExample.kremark))
            {
                list_param.Add(new SqlParameter("@kremark", lh_keydataExample.kremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@kremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_keydataExample.kbackup1))
            {
                list_param.Add(new SqlParameter("@kbackup1", lh_keydataExample.kbackup1));
            }
            else
            {
                list_param.Add(new SqlParameter("@kbackup1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_keydataExample.kbackup2))
            {
                list_param.Add(new SqlParameter("@kbackup2", lh_keydataExample.kbackup2));
            }
            else
            {
                list_param.Add(new SqlParameter("@kbackup2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_keydataExample.kbackup3))
            {
                list_param.Add(new SqlParameter("@kbackup3", lh_keydataExample.kbackup3));
            }
            else
            {
                list_param.Add(new SqlParameter("@kbackup3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_keydataExample.kbackup4))
            {
                list_param.Add(new SqlParameter("@kbackup4", lh_keydataExample.kbackup4));
            }
            else
            {
                list_param.Add(new SqlParameter("@kbackup4", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(lh_keydataExample.kbackup5))
            {
                list_param.Add(new SqlParameter("@kbackup5", lh_keydataExample.kbackup5));
            }
            else
            {
                list_param.Add(new SqlParameter("@kbackup5", DBNull.Value));
            }
            if (lh_keydataExample.ksousuorenqi != 0)
            {
                list_param.Add(new SqlParameter("@ksousuorenqi", lh_keydataExample.ksousuorenqi));
            }
            else
            {
                list_param.Add(new SqlParameter("@ksousuorenqi", DBNull.Value));
            }
            if (lh_keydataExample.kzhifuzhuanhualv != new decimal())
            {
                list_param.Add(new SqlParameter("@kzhifuzhuanhualv", lh_keydataExample.kzhifuzhuanhualv));
            }
            else
            {
                list_param.Add(new SqlParameter("@kzhifuzhuanhualv", DBNull.Value));
            }
            if (lh_keydataExample.kzaixianshangpinshu != 0)
            {
                list_param.Add(new SqlParameter("@kzaixianshangpinshu", lh_keydataExample.kzaixianshangpinshu));
            }
            else
            {
                list_param.Add(new SqlParameter("@kzaixianshangpinshu", DBNull.Value));
            }
            if (lh_keydataExample.kshangchengzhanbi != new decimal())
            {
                list_param.Add(new SqlParameter("@kshangchengzhanbi", lh_keydataExample.kshangchengzhanbi));
            }
            else
            {
                list_param.Add(new SqlParameter("@kshangchengzhanbi", DBNull.Value));
            }
            if (lh_keydataExample.kzhitongchejiage != new decimal())
            {
                list_param.Add(new SqlParameter("@kzhitongchejiage", lh_keydataExample.kzhitongchejiage));
            }
            else
            {
                list_param.Add(new SqlParameter("@kzhitongchejiage", DBNull.Value));
            }
            if (lh_keydataExample.kjingzheng != new decimal())
            {
                list_param.Add(new SqlParameter("@kjingzheng", lh_keydataExample.kjingzheng));
            }
            else
            {
                list_param.Add(new SqlParameter("@kjingzheng", DBNull.Value));
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
        /// <returns>lh_keydataExample</returns>
        public static lh_keydata GetByReader(SqlDataReader Reader)
        {
            lh_keydata lh_keydataExample = new lh_keydata();
            try
            {
                lh_keydataExample.kid = Reader["kid"] == DBNull.Value ? 0 : (int)Reader["kid"];
                lh_keydataExample.kname = Reader["kname"] == DBNull.Value ? null : Reader["kname"].ToString();
                lh_keydataExample.kstate = Reader["kstate"] == DBNull.Value ? null : Reader["kstate"].ToString();
                lh_keydataExample.kdate = Reader["kdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["kdate"]);
                lh_keydataExample.hid = Reader["hid"] == DBNull.Value ? 0 : (int)Reader["hid"];
                lh_keydataExample.rid = Reader["rid"] == DBNull.Value ? 0 : (int)Reader["rid"];
                lh_keydataExample.kremark = Reader["kremark"] == DBNull.Value ? null : Reader["kremark"].ToString();
                lh_keydataExample.kbackup1 = Reader["kbackup1"] == DBNull.Value ? null : Reader["kbackup1"].ToString();
                lh_keydataExample.kbackup2 = Reader["kbackup2"] == DBNull.Value ? null : Reader["kbackup2"].ToString();
                lh_keydataExample.kbackup3 = Reader["kbackup3"] == DBNull.Value ? null : Reader["kbackup3"].ToString();
                lh_keydataExample.kbackup4 = Reader["kbackup4"] == DBNull.Value ? null : Reader["kbackup4"].ToString();
                lh_keydataExample.kbackup5 = Reader["kbackup5"] == DBNull.Value ? null : Reader["kbackup5"].ToString();
                lh_keydataExample.ksousuorenqi = Reader["ksousuorenqi"] == DBNull.Value ? 0 : (int)Reader["ksousuorenqi"];
                lh_keydataExample.kzhifuzhuanhualv = Reader["kzhifuzhuanhualv"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kzhifuzhuanhualv"]);
                lh_keydataExample.kzaixianshangpinshu = Reader["kzaixianshangpinshu"] == DBNull.Value ? 0 : (int)Reader["kzaixianshangpinshu"];
                lh_keydataExample.kshangchengzhanbi = Reader["kshangchengzhanbi"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kshangchengzhanbi"]);
                lh_keydataExample.kzhitongchejiage = Reader["kzhitongchejiage"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kzhitongchejiage"]);
                lh_keydataExample.kjingzheng = Reader["kjingzheng"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kjingzheng"]);
            }
            catch (Exception ex)
            {
                string mess = ex.ToString();
                mess.ToString();
            }
            return lh_keydataExample;
        }
        #endregion





        #endregion
    }

 


}

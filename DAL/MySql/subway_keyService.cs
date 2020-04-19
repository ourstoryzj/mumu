using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql
{

  


    public class subway_keyService : Isubway_keyService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<subway_key> SearchAll()
        {
            DBHelper.sqlstr = "select * from subway_key ";
            List<subway_key> list = new List<subway_key>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                subway_key Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据skid,查询一条数据
        /// </summary>
        /// <param name="skid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public subway_key SearchByID(int skid)
        {
            DBHelper.sqlstr = "select * from subway_key where skid = @skid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@skid",skid)
            };
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            subway_key Obj = null;
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
        /// <param name="subway_key">subway_key表实例</param>
        /// <returns>int</returns>
        public int Insert(subway_key subway_keyExample)
        {
            DBHelper.sqlstr = "insert into  subway_key (sgid,skname,skscore,skrank,skmobileprice,skpcprice,skimpression,skclick,skctr,skcost,skcpc,skcar,skfav,skvol,skroi,skconverage,skavgpos,skstate,skdateadd,skdatedata,skdatedelete,sktag,skfangan,skmakeprice,skremark,skremark1,skremark2,skremark3,skremark4,skremark5)values(@sgid,@skname,@skscore,@skrank,@skmobileprice,@skpcprice,@skimpression,@skclick,@skctr,@skcost,@skcpc,@skcar,@skfav,@skvol,@skroi,@skconverage,@skavgpos,@skstate,@skdateadd,@skdatedata,@skdatedelete,@sktag,@skfangan,@skmakeprice,@skremark,@skremark1,@skremark2,@skremark3,@skremark4,@skremark5)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(subway_keyExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="subway_key">subway_key表实例</param>
        /// <returns>int</returns>
        public int Update(subway_key subway_keyExample)
        {
            DBHelper.sqlstr = "update subway_key set sgid=@sgid,skname=@skname,skscore=@skscore,skrank=@skrank,skmobileprice=@skmobileprice,skpcprice=@skpcprice,skimpression=@skimpression,skclick=@skclick,skctr=@skctr,skcost=@skcost,skcpc=@skcpc,skcar=@skcar,skfav=@skfav,skvol=@skvol,skroi=@skroi,skconverage=@skconverage,skavgpos=@skavgpos,skstate=@skstate,skdateadd=@skdateadd,skdatedata=@skdatedata,skdatedelete=@skdatedelete,sktag=@sktag,skfangan=@skfangan,skmakeprice=@skmakeprice,skremark=@skremark,skremark1=@skremark1,skremark2=@skremark2,skremark3=@skremark3,skremark4=@skremark4,skremark5=@skremark5 where skid=" + subway_keyExample.skid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(subway_keyExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="skid">编号</param>
        /// <returns>int</returns>
        public int Delete(int skid)
        {
            DBHelper.sqlstr = "delete subway_key where skid =@skid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@skid",skid)
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
        public int SearchNum(string key, string state, int sgid, string tag, string skmakeprice, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(skid) from subway_key where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( skname like '%" + key + "%' or skscore like '%" + key + "%' or skrank like '%" + key + "%' or skmobileprice like '%" + key + "%' or skpcprice like '%" + key + "%' or skimpression like '%" + key + "%' or skclick like '%" + key + "%' or skctr like '%" + key + "%' or skcost like '%" + key + "%' or skcpc like '%" + key + "%' or skcar like '%" + key + "%' or skfav like '%" + key + "%' or skvol like '%" + key + "%' or skroi like '%" + key + "%' or skconverage like '%" + key + "%' or skavgpos like '%" + key + "%' or skstate like '%" + key + "%' or sktag like '%" + key + "%' or skfangan like '%" + key + "%' or skmakeprice like '%" + key + "%' or skremark like '%" + key + "%' or skremark1 like '%" + key + "%' or skremark2 like '%" + key + "%' or skremark3 like '%" + key + "%' or skremark4 like '%" + key + "%' or skremark5 like '%" + key + "%'   )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and skstate= '" + state + "' ";//状态字段，无用删除
            string sql11 = string.IsNullOrEmpty(tag) ? "" : " and sktag	= '" + tag + "' ";
            string sql12 = string.IsNullOrEmpty(skmakeprice) ? "" : " and skmakeprice= '" + skmakeprice + "' ";
            string sql4 = sgid == 0 ? "" : " and sgid='" + sgid.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',skdatedata)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',skdatedata)<=0 ";//时间字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql11 + sql12 + sql4 + sql5 + sql6;
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
        /// <returns>IList<subway_key></returns>
        public IList<subway_key> Search(int s, int e, string key, string state, int sgid, string tag, string skmakeprice, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select * from subway_key where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( skname like '%" + key + "%' or skscore like '%" + key + "%' or skrank like '%" + key + "%' or skmobileprice like '%" + key + "%' or skpcprice like '%" + key + "%' or skimpression like '%" + key + "%' or skclick like '%" + key + "%' or skctr like '%" + key + "%' or skcost like '%" + key + "%' or skcpc like '%" + key + "%' or skcar like '%" + key + "%' or skfav like '%" + key + "%' or skvol like '%" + key + "%' or skroi like '%" + key + "%' or skconverage like '%" + key + "%' or skavgpos like '%" + key + "%' or skstate like '%" + key + "%' or sktag like '%" + key + "%' or skfangan like '%" + key + "%' or skmakeprice like '%" + key + "%' or skremark like '%" + key + "%' or skremark1 like '%" + key + "%' or skremark2 like '%" + key + "%' or skremark3 like '%" + key + "%' or skremark4 like '%" + key + "%' or skremark5 like '%" + key + "%'   )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and skstate= '" + state + "' ";//状态字段，无用删除
            string sql11 = string.IsNullOrEmpty(tag) ? "" : " and sktag	= '" + tag + "' ";
            string sql12 = string.IsNullOrEmpty(skmakeprice) ? "" : " and skmakeprice= '" + skmakeprice + "' ";
            string sql4 = sgid == 0 ? "" : " and sgid='" + sgid.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',skdatedata)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',skdatedata)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by skdatedata desc " : " order by " + orderby;
            string sql10 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql11 + sql12 + sql4 + sql5 + sql6  + sql7+ sql10;
            List<subway_key> list = new List<subway_key>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                subway_key Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

       

         




        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个MySqlParameter数组
        /// </summary>
        /// <returns>MySqlParameter[]</returns>
        public static MySqlParameter[] GetSqlParameters(subway_key subway_keyExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();
            if (subway_keyExample.sgid != 0)
            {
                list_param.Add(new MySqlParameter("@sgid", subway_keyExample.sgid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sgid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skname))
            {
                list_param.Add(new MySqlParameter("@skname", subway_keyExample.skname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skscore))
            {
                list_param.Add(new MySqlParameter("@skscore", subway_keyExample.skscore));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skscore", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skrank))
            {
                list_param.Add(new MySqlParameter("@skrank", subway_keyExample.skrank));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skrank", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skmobileprice))
            {
                list_param.Add(new MySqlParameter("@skmobileprice", subway_keyExample.skmobileprice));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skmobileprice", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skpcprice))
            {
                list_param.Add(new MySqlParameter("@skpcprice", subway_keyExample.skpcprice));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skpcprice", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skimpression))
            {
                list_param.Add(new MySqlParameter("@skimpression", subway_keyExample.skimpression));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skimpression", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skclick))
            {
                list_param.Add(new MySqlParameter("@skclick", subway_keyExample.skclick));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skclick", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skctr))
            {
                list_param.Add(new MySqlParameter("@skctr", subway_keyExample.skctr));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skctr", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skcost))
            {
                list_param.Add(new MySqlParameter("@skcost", subway_keyExample.skcost));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skcost", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skcpc))
            {
                list_param.Add(new MySqlParameter("@skcpc", subway_keyExample.skcpc));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skcpc", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skcar))
            {
                list_param.Add(new MySqlParameter("@skcar", subway_keyExample.skcar));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skcar", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skfav))
            {
                list_param.Add(new MySqlParameter("@skfav", subway_keyExample.skfav));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skfav", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skvol))
            {
                list_param.Add(new MySqlParameter("@skvol", subway_keyExample.skvol));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skvol", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skroi))
            {
                list_param.Add(new MySqlParameter("@skroi", subway_keyExample.skroi));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skroi", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skconverage))
            {
                list_param.Add(new MySqlParameter("@skconverage", subway_keyExample.skconverage));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skconverage", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skavgpos))
            {
                list_param.Add(new MySqlParameter("@skavgpos", subway_keyExample.skavgpos));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skavgpos", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skstate))
            {
                list_param.Add(new MySqlParameter("@skstate", subway_keyExample.skstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skstate", DBNull.Value));
            }
            if (subway_keyExample.skdateadd != new DateTime() && subway_keyExample.skdateadd != null)
            {
                list_param.Add(new MySqlParameter("@skdateadd", subway_keyExample.skdateadd.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skdateadd", DBNull.Value));
            }
            if (subway_keyExample.skdatedata != new DateTime() && subway_keyExample.skdatedata != null)
            {
                list_param.Add(new MySqlParameter("@skdatedata", subway_keyExample.skdatedata.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skdatedata", DBNull.Value));
            }
            if (subway_keyExample.skdatedelete != new DateTime() && subway_keyExample.skdatedelete != null)
            {
                list_param.Add(new MySqlParameter("@skdatedelete", subway_keyExample.skdatedelete.ToString("yyyy-MM-dd HH:mm:ss")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skdatedelete", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.sktag))
            {
                list_param.Add(new MySqlParameter("@sktag", subway_keyExample.sktag));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sktag", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skfangan))
            {
                list_param.Add(new MySqlParameter("@skfangan", subway_keyExample.skfangan));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skfangan", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skmakeprice))
            {
                list_param.Add(new MySqlParameter("@skmakeprice", subway_keyExample.skmakeprice));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skmakeprice", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skremark))
            {
                list_param.Add(new MySqlParameter("@skremark", subway_keyExample.skremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skremark1))
            {
                list_param.Add(new MySqlParameter("@skremark1", subway_keyExample.skremark1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skremark2))
            {
                list_param.Add(new MySqlParameter("@skremark2", subway_keyExample.skremark2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skremark3))
            {
                list_param.Add(new MySqlParameter("@skremark3", subway_keyExample.skremark3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skremark3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skremark4))
            {
                list_param.Add(new MySqlParameter("@skremark4", subway_keyExample.skremark4));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skremark4", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(subway_keyExample.skremark5))
            {
                list_param.Add(new MySqlParameter("@skremark5", subway_keyExample.skremark5));
            }
            else
            {
                list_param.Add(new MySqlParameter("@skremark5", DBNull.Value));
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
        /// <returns>subway_keyExample</returns>
        public static subway_key GetByReader(MySqlDataReader Reader)
        {
            subway_key subway_keyExample = new subway_key();
            subway_keyExample.skid = Reader["skid"] == DBNull.Value ? 0 : (int)Reader["skid"];
            subway_keyExample.sgid = Reader["sgid"] == DBNull.Value ? 0 : (int)Reader["sgid"];
            subway_keyExample.skname = Reader["skname"] == DBNull.Value ? null : Reader["skname"].ToString();
            subway_keyExample.skscore = Reader["skscore"] == DBNull.Value ? null : Reader["skscore"].ToString();
            subway_keyExample.skrank = Reader["skrank"] == DBNull.Value ? null : Reader["skrank"].ToString();
            subway_keyExample.skmobileprice = Reader["skmobileprice"] == DBNull.Value ? null : Reader["skmobileprice"].ToString();
            subway_keyExample.skpcprice = Reader["skpcprice"] == DBNull.Value ? null : Reader["skpcprice"].ToString();
            subway_keyExample.skimpression = Reader["skimpression"] == DBNull.Value ? null : Reader["skimpression"].ToString();
            subway_keyExample.skclick = Reader["skclick"] == DBNull.Value ? null : Reader["skclick"].ToString();
            subway_keyExample.skctr = Reader["skctr"] == DBNull.Value ? null : Reader["skctr"].ToString();
            subway_keyExample.skcost = Reader["skcost"] == DBNull.Value ? null : Reader["skcost"].ToString();
            subway_keyExample.skcpc = Reader["skcpc"] == DBNull.Value ? null : Reader["skcpc"].ToString();
            subway_keyExample.skcar = Reader["skcar"] == DBNull.Value ? null : Reader["skcar"].ToString();
            subway_keyExample.skfav = Reader["skfav"] == DBNull.Value ? null : Reader["skfav"].ToString();
            subway_keyExample.skvol = Reader["skvol"] == DBNull.Value ? null : Reader["skvol"].ToString();
            subway_keyExample.skroi = Reader["skroi"] == DBNull.Value ? null : Reader["skroi"].ToString();
            subway_keyExample.skconverage = Reader["skconverage"] == DBNull.Value ? null : Reader["skconverage"].ToString();
            subway_keyExample.skavgpos = Reader["skavgpos"] == DBNull.Value ? null : Reader["skavgpos"].ToString();
            subway_keyExample.skstate = Reader["skstate"] == DBNull.Value ? null : Reader["skstate"].ToString();
            subway_keyExample.skdateadd = Reader["skdateadd"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["skdateadd"]);
            subway_keyExample.skdatedata = Reader["skdatedata"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["skdatedata"]);
            subway_keyExample.skdatedelete = Reader["skdatedelete"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["skdatedelete"]);
            subway_keyExample.sktag = Reader["sktag"] == DBNull.Value ? null : Reader["sktag"].ToString();
            subway_keyExample.skfangan = Reader["skfangan"] == DBNull.Value ? null : Reader["skfangan"].ToString();
            subway_keyExample.skmakeprice = Reader["skmakeprice"] == DBNull.Value ? null : Reader["skmakeprice"].ToString();
            subway_keyExample.skremark = Reader["skremark"] == DBNull.Value ? null : Reader["skremark"].ToString();
            subway_keyExample.skremark1 = Reader["skremark1"] == DBNull.Value ? null : Reader["skremark1"].ToString();
            subway_keyExample.skremark2 = Reader["skremark2"] == DBNull.Value ? null : Reader["skremark2"].ToString();
            subway_keyExample.skremark3 = Reader["skremark3"] == DBNull.Value ? null : Reader["skremark3"].ToString();
            subway_keyExample.skremark4 = Reader["skremark4"] == DBNull.Value ? null : Reader["skremark4"].ToString();
            subway_keyExample.skremark5 = Reader["skremark5"] == DBNull.Value ? null : Reader["skremark5"].ToString();
            return subway_keyExample;
        }
        #endregion





        #endregion
    }
   
  

}

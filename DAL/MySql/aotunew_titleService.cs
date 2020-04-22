using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.Mysql
{


    public class aotunew_titleService : Iaotunew_titleService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<aotunew_title> SearchAll()
        {
            DBHelper.sqlstr = "select * from aotunew_title ";
            List<aotunew_title> list = new List<aotunew_title>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                aotunew_title Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据atid,查询一条数据
        /// </summary>
        /// <param name="atid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public aotunew_title SearchByID(int atid)
        {
            DBHelper.sqlstr = "select * from aotunew_title where atid = @atid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@atid",atid)
            };
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            aotunew_title Obj = null;
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
        /// <param name="aotunew_title">aotunew_title表实例</param>
        /// <returns>int</returns>
        public int Insert(aotunew_title aotunew_titleExample)
        {
            DBHelper.sqlstr = "insert into  aotunew_title (attitle,atjieshao,attype1,attype2,atremark1,atremark2,atdate,atprice,atsell,aturl,atlike)values(@attitle,@atjieshao,@attype1,@attype2,@atremark1,@atremark2,@atdate,@atprice,@atsell,@aturl,@atlike)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(aotunew_titleExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="aotunew_title">aotunew_title表实例</param>
        /// <returns>int</returns>
        public int Update(aotunew_title aotunew_titleExample)
        {
            DBHelper.sqlstr = "update aotunew_title set attitle=@attitle,atjieshao=@atjieshao,attype1=@attype1,attype2=@attype2,atremark1=@atremark1,atremark2=@atremark2,atdate=@atdate,atprice=@atprice,atsell=@atsell,aturl=@aturl,atlike=@atlike where atid=" + aotunew_titleExample.atid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(aotunew_titleExample));
        }
        #endregion


        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="atid">编号</param>
        /// <returns>int</returns>
        public int Delete(int atid)
        {
            DBHelper.sqlstr = "delete aotunew_title where atid =@atid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@atid",atid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state">状态 空:不查,1:启用,2:禁用</param>
        /// <param name="dt1_add">添加商品起始时间</param>
        /// <param name="dt2_add">添加商品结束时间</param>
        /// <returns>int</returns>
        public int SearchNum(string key, string type1, string type2, DateTime dt1_add, DateTime dt2_add)
        {
            string sql1 = "select count(atid) from aotunew_title where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  attitle like '%" + key + "%' or  atjieshao like '%" + key + "%'  or  atremark1 like '%" + key + "%'  or  atremark2 like '%" + key + "%'  or  atprice like '%" + key + "%'  or  atsell like '%" + key + "%'  or  aturl like '%" + key + "%'  or  atlike  like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(type1) ? "" : " and attype1=" + type1;
            string sql4 = string.IsNullOrEmpty(type2) ? "" : " and attype2= '" + type2 + "' ";
            string sql5 = dt1_add == new DateTime() ? "" : " and datediff(d,'" + dt1_add.ToString() + "',atdate)>=0 ";
            string sql6 = dt2_add == new DateTime() ? "" : " and datediff(d,'" + dt2_add.ToString() + "',atdate)<=0 ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6;

            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 条件搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state">状态 空:不查,1:启用,2:禁用</param>
        /// <param name="dt1_add">添加起始时间</param>
        /// <param name="dt2_add">添加结束时间</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<yh_zaoci></returns>
        public IList<aotunew_title> Search(int startindex, int searchnum, string key, string type1, string type2, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            string sql1 = "select   *   from aotunew_title where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  attitle like '%" + key + "%' or  atjieshao like '%" + key + "%'  or  atremark1 like '%" + key + "%'  or  atremark2 like '%" + key + "%'  or  atprice like '%" + key + "%'  or  atsell like '%" + key + "%'  or  aturl like '%" + key + "%'  or  atlike  like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(type1) ? "" : " and attype1=" + type1;
            string sql4 = string.IsNullOrEmpty(type2) ? "" : " and attype2= '" + type2 + "' ";
            string sql5 = dt1_add == new DateTime() ? "" : " and datediff(d,'" + dt1_add.ToString("yyyy-MM-dd") + "',atdate)>=0 ";
            string sql6 = dt2_add == new DateTime() ? "" : " and datediff(d,'" + dt2_add.ToString("yyyy-MM-dd") + "',atdate)<=0 ";
            string sql8 = string.IsNullOrEmpty(orderby) ? " order by atdate desc " : " order by " + orderby;
            //string sql7 = s == 1 ? "" : " and atid not in ( select top " + (s - 1).ToString() + " atid from aotunew_title where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql8 + " ) ";
            string sql10 = searchnum == 0 ? " " : " limit " + startindex + "," + searchnum;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6  + sql8+ sql10;
            List<aotunew_title> list = new List<aotunew_title>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                aotunew_title Obj = GetByReader(reader);
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
        public static MySqlParameter[] GetSqlParameters(aotunew_title aotunew_titleExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(aotunew_titleExample.attitle))
            {
                list_param.Add(new MySqlParameter("@attitle", aotunew_titleExample.attitle));
            }
            else
            {
                list_param.Add(new MySqlParameter("@attitle", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(aotunew_titleExample.atjieshao))
            {
                list_param.Add(new MySqlParameter("@atjieshao", aotunew_titleExample.atjieshao));
            }
            else
            {
                list_param.Add(new MySqlParameter("@atjieshao", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(aotunew_titleExample.attype1))
            {
                list_param.Add(new MySqlParameter("@attype1", aotunew_titleExample.attype1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@attype1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(aotunew_titleExample.attype2))
            {
                list_param.Add(new MySqlParameter("@attype2", aotunew_titleExample.attype2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@attype2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(aotunew_titleExample.atremark1))
            {
                list_param.Add(new MySqlParameter("@atremark1", aotunew_titleExample.atremark1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@atremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(aotunew_titleExample.atremark2))
            {
                list_param.Add(new MySqlParameter("@atremark2", aotunew_titleExample.atremark2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@atremark2", DBNull.Value));
            }
            if (aotunew_titleExample.atdate != new DateTime() && aotunew_titleExample.atdate != null)
            {
                list_param.Add(new MySqlParameter("@atdate", aotunew_titleExample.atdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@atdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(aotunew_titleExample.atprice))
            {
                list_param.Add(new MySqlParameter("@atprice", aotunew_titleExample.atprice));
            }
            else
            {
                list_param.Add(new MySqlParameter("@atprice", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(aotunew_titleExample.atsell))
            {
                list_param.Add(new MySqlParameter("@atsell", aotunew_titleExample.atsell));
            }
            else
            {
                list_param.Add(new MySqlParameter("@atsell", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(aotunew_titleExample.aturl))
            {
                list_param.Add(new MySqlParameter("@aturl", aotunew_titleExample.aturl));
            }
            else
            {
                list_param.Add(new MySqlParameter("@aturl", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(aotunew_titleExample.atlike))
            {
                list_param.Add(new MySqlParameter("@atlike", aotunew_titleExample.atlike));
            }
            else
            {
                list_param.Add(new MySqlParameter("@atlike", DBNull.Value));
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
        /// <returns>aotunew_titleExample</returns>
        public static aotunew_title GetByReader(MySqlDataReader Reader)
        {
            aotunew_title aotunew_titleExample = new aotunew_title();
            aotunew_titleExample.atid = Reader["atid"] == DBNull.Value ? 0 : (int)Reader["atid"];
            aotunew_titleExample.attitle = Reader["attitle"] == DBNull.Value ? null : Reader["attitle"].ToString();
            aotunew_titleExample.atjieshao = Reader["atjieshao"] == DBNull.Value ? null : Reader["atjieshao"].ToString();
            aotunew_titleExample.attype1 = Reader["attype1"] == DBNull.Value ? null : Reader["attype1"].ToString();
            aotunew_titleExample.attype2 = Reader["attype2"] == DBNull.Value ? null : Reader["attype2"].ToString();
            aotunew_titleExample.atremark1 = Reader["atremark1"] == DBNull.Value ? null : Reader["atremark1"].ToString();
            aotunew_titleExample.atremark2 = Reader["atremark2"] == DBNull.Value ? null : Reader["atremark2"].ToString();
            aotunew_titleExample.atdate = Reader["atdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["atdate"]);
            aotunew_titleExample.atprice = Reader["atprice"] == DBNull.Value ? null : Reader["atprice"].ToString();
            aotunew_titleExample.atsell = Reader["atsell"] == DBNull.Value ? null : Reader["atsell"].ToString();
            aotunew_titleExample.aturl = Reader["aturl"] == DBNull.Value ? null : Reader["aturl"].ToString();
            aotunew_titleExample.atlike = Reader["atlike"] == DBNull.Value ? null : Reader["atlike"].ToString();
            return aotunew_titleExample;
        }
        #endregion





        #endregion
    }
     
 







}

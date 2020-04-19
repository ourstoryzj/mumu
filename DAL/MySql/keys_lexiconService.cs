using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql.MySql
{




    public class keys_lexiconService : Ikeys_lexiconService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<keys_lexicon> SearchAll()
        {
            DBHelper.sqlstr = "select * from keys_lexicon ";
            List<keys_lexicon> list = new List<keys_lexicon>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                keys_lexicon Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据klid,查询一条数据
        /// </summary>
        /// <param name="klid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public keys_lexicon SearchByID(int klid)
        {
            DBHelper.sqlstr = "select * from keys_lexicon where klid = @klid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@klid",klid)
            };
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            keys_lexicon Obj = null;
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
        /// <param name="keys_lexicon">keys_lexicon表实例</param>
        /// <returns>int</returns>
        public int Insert(keys_lexicon keys_lexiconExample)
        {
            DBHelper.sqlstr = "insert into  keys_lexicon (klname,klsort,kldate,klstate,klremark,klremark1,klremark2)values(@klname,@klsort,@kldate,@klstate,@klremark,@klremark1,@klremark2)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(keys_lexiconExample));
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="keys_lexicon">keys_lexicon表实例</param>
        /// <returns>int</returns>
        public int Insert2(List<keys_lexicon> list)
        {
             
            DBHelper.sqlstr = "insert into  keys_lexicon (klname,klsort,kldate,klstate,klremark,klremark1,klremark2)values(@klname,@klsort,@kldate,@klstate,@klremark,@klremark1,@klremark2)";
            List<MySqlParameter[]> list_param = new List<MySqlParameter[]>();
            foreach (keys_lexicon kl in list)
            {
                list_param.Add(GetSqlParameters(kl));
            }
            DBHelper.ExecuteSqlTran(list_param);
            return 1;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="keys_lexicon">keys_lexicon表实例</param>
        /// <returns>int</returns>
        public int Update(keys_lexicon keys_lexiconExample)
        {
            DBHelper.sqlstr = "update keys_lexicon set klname=@klname,klsort=@klsort,kldate=@kldate,klstate=@klstate,klremark=@klremark,klremark1=@klremark1,klremark2=@klremark2 where klid=" + keys_lexiconExample.klid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(keys_lexiconExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="klid">编号</param>
        /// <returns>int</returns>
        public int Delete(int klid)
        {
            DBHelper.sqlstr = "delete keys_lexicon where klid =@klid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@klid",klid)
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
        public int SearchNum(string key, string state, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(klid) from keys_lexicon where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( klname like '%" + key + "%' or klstate like '%" + key + "%' or klremark like '%" + key + "%' or klremark1 like '%" + key + "%' or klremark2 like '%" + key + "%' )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and klstate= '" + state + "' ";//状态字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',kldate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',kldate)<=0 ";//时间字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql5 + sql6;
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
        /// <returns>IList<keys_lexicon></returns>
        public IList<keys_lexicon> Search(int s, int e, string key, string state, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select * from keys_lexicon where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( klname like '%" + key + "%' or klstate like '%" + key + "%' or klremark like '%" + key + "%' or klremark1 like '%" + key + "%' or klremark2 like '%" + key + "%' )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and klstate= '" + state + "' ";//状态字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',kldate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',kldate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by klid desc " : " order by " + orderby;
            //string sql8 = s == 1 ? "" : " and klid not in ( select top " + (s - 1).ToString() + " klid from keys_lexicon where " + sql2 + sql3 + sql5 + sql6 + sql7 + " ) ";
            string sql9 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql5 + sql6  + sql7+ sql9;
            List<keys_lexicon> list = new List<keys_lexicon>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                keys_lexicon Obj = GetByReader(reader);
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
        public static MySqlParameter[] GetSqlParameters(keys_lexicon keys_lexiconExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(keys_lexiconExample.klname))
            {
                list_param.Add(new MySqlParameter("@klname", keys_lexiconExample.klname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klname", DBNull.Value));
            }
            if (keys_lexiconExample.klsort != 0)
            {
                list_param.Add(new MySqlParameter("@klsort", keys_lexiconExample.klsort));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klsort", DBNull.Value));
            }
            if (keys_lexiconExample.kldate != new DateTime() && keys_lexiconExample.kldate != null)
            {
                list_param.Add(new MySqlParameter("@kldate", keys_lexiconExample.kldate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kldate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_lexiconExample.klstate))
            {
                list_param.Add(new MySqlParameter("@klstate", keys_lexiconExample.klstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_lexiconExample.klremark))
            {
                list_param.Add(new MySqlParameter("@klremark", keys_lexiconExample.klremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_lexiconExample.klremark1))
            {
                list_param.Add(new MySqlParameter("@klremark1", keys_lexiconExample.klremark1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_lexiconExample.klremark2))
            {
                list_param.Add(new MySqlParameter("@klremark2", keys_lexiconExample.klremark2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klremark2", DBNull.Value));
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
        /// <returns>keys_lexiconExample</returns>
        public static keys_lexicon GetByReader(MySqlDataReader Reader)
        {
            keys_lexicon keys_lexiconExample = new keys_lexicon();
            keys_lexiconExample.klid = Reader["klid"] == DBNull.Value ? 0 : (int)Reader["klid"];
            keys_lexiconExample.klname = Reader["klname"] == DBNull.Value ? null : Reader["klname"].ToString();
            keys_lexiconExample.klsort = Reader["klsort"] == DBNull.Value ? 0 : (int)Reader["klsort"];
            keys_lexiconExample.kldate = Reader["kldate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["kldate"]);
            keys_lexiconExample.klstate = Reader["klstate"] == DBNull.Value ? null : Reader["klstate"].ToString();
            keys_lexiconExample.klremark = Reader["klremark"] == DBNull.Value ? null : Reader["klremark"].ToString();
            keys_lexiconExample.klremark1 = Reader["klremark1"] == DBNull.Value ? null : Reader["klremark1"].ToString();
            keys_lexiconExample.klremark2 = Reader["klremark2"] == DBNull.Value ? null : Reader["klremark2"].ToString();
            return keys_lexiconExample;
        }
        #endregion





        #endregion
    }










}

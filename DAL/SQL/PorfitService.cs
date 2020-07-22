using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{


    public class PorfitService : IPorfitService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<Porfit> SearchAll()
        {
            DBHelper.sqlstr = "select * from Porfit ";
            List<Porfit> list = new List<Porfit>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                Porfit Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据pid,查询一条数据
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        /*查看是否为视图*/

        public Porfit SearchByID(int pid)
        {
            DBHelper.sqlstr = "select * from Porfit where pid = @pid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@pid",pid)
            };
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            Porfit Obj = null;
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
        /// <param name="Porfit">Porfit表实例</param>
        /// <returns>int</returns>
        public int Insert(Porfit PorfitExample)
        {
            DBHelper.sqlstr = "insert into  Porfit (pprice,pdate,pbeiyong)values(@pprice,@pdate,@pbeiyong)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(PorfitExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Porfit">Porfit表实例</param>
        /// <returns>int</returns>
        public int Update(Porfit PorfitExample)
        {
            DBHelper.sqlstr = "update Porfit set pprice=@pprice,pdate=@pdate,pbeiyong=@pbeiyong where pid=" + PorfitExample.pid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(PorfitExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pid"></param>
        /// <returns>int</returns>
        public int Delete(int pid)
        {
            DBHelper.sqlstr = "delete Porfit where pid =@pid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@pid",pid)
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
        public int SearchNum(string key, string state, int id, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(pid) from Porfit where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( pbeiyong like '%" + key + "%' or )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and 状态字段= '" + state + "' ";//状态字段，无用删除
            string sql4 = id == 0 ? "" : " and id字段='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',时间字段)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',时间字段)<=0 ";//时间字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6;
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
        /// <returns>IList<Porfit></returns>
        public IList<Porfit> Search(int s, int e, string key,  DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select top " + (e - s + 1).ToString() + " * from Porfit where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( pbeiyong like '%" + key + "%' or )";//删除无用字段，删除最后一个or
            //string sql3 = string.IsNullOrEmpty(state) ? "" : " and 状态字段= '" + state + "' ";//状态字段，无用删除
            //string sql4 = id == 0 ? "" : " and id字段='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',pdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',pdate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by pid desc " : " order by " + orderby;
            string sql8 = s == 1 ? "" : " and pid not in ( select top " + (s - 1).ToString() + " pid from Porfit where " + sql2 + sql5 + sql6 + sql7 + " ) ";
            DBHelper.sqlstr = sql1 + sql2  + sql5 + sql6 + sql8 + sql7;
            List<Porfit> list = new List<Porfit>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                Porfit Obj = GetByReader(reader);
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
        public static SqlParameter[] GetSqlParameters(Porfit PorfitExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();
            

            if (PorfitExample.pprice!= new double())
            {
                list_param.Add(new SqlParameter("@pprice", PorfitExample.pprice));
            }
            else
            {
                list_param.Add(new SqlParameter("@pprice", DBNull.Value));
            }
            if (PorfitExample.pdate != new DateTime() && PorfitExample.pdate != null)
            {
                list_param.Add(new SqlParameter("@pdate", PorfitExample.pdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@pdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(PorfitExample.pbeiyong))
            {
                list_param.Add(new SqlParameter("@pbeiyong", PorfitExample.pbeiyong));
            }
            else
            {
                list_param.Add(new SqlParameter("@pbeiyong", DBNull.Value));
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
        /// <returns>PorfitExample</returns>
        public static Porfit GetByReader(SqlDataReader Reader)
        {
            Porfit PorfitExample = new Porfit();
            try
            {
                PorfitExample.pid = Reader["pid"] == DBNull.Value ? 0 : (int)Reader["pid"];
                double price = new double();
                double.TryParse(Reader["pprice"].ToString(), out price);
                PorfitExample.pprice = price;
                PorfitExample.pdate = Reader["pdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["pdate"]);
                PorfitExample.pbeiyong = Reader["pbeiyong"] == DBNull.Value ? null : Reader["pbeiyong"].ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            return PorfitExample;
        }
        #endregion





        #endregion
    }
   
   








}

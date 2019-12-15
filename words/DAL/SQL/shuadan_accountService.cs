using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{


    //表名称：shuadan_account
    //实体类名称：shuadan_accountExample
    //主键：sdaid

    public class shuadan_accountService 
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_account> SearchAll()
        {
            DBHelper.sqlstr = "select * from shuadan_account ";
            List<shuadan_account> list = new List<shuadan_account>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_account Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBysdaid
        /// <summary>
        /// 根据sdaid,查询一条数据
        /// </summary>
        /// <param name="sdaid"></param>
        /// <returns></returns>
        public shuadan_account SearchBysdaid(int sdaid)
        {
            DBHelper.sqlstr = "select * from shuadan_account where sdaid = @sdaid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@sdaid",sdaid)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            shuadan_account Obj = null;
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
        /// <param name="shuadan_account">shuadan_account表实例</param>
        /// <returns>int</returns>
        public int Insert(shuadan_account shuadan_accountExample)
        {
            DBHelper.sqlstr = "insert into  shuadan_account (sdaccount,sdadate,sdapwd,sdastate)values(@sdaccount,'" + shuadan_accountExample.sdadate.ToString() + "',@sdapwd,@sdastate)";
            return DBHelper.ExecuteNonQuery(GetSqlParameter(shuadan_accountExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_account">shuadan_account表实例</param>
        /// <returns>int</returns>
        public int Update(shuadan_account shuadan_accountExample)
        {
            DBHelper.sqlstr = "update shuadan_account set sdaccount=@sdaccount,sdadate='" + shuadan_accountExample.sdadate.ToString() + "',sdapwd=@sdapwd,sdastate=@sdastate where sdaid=" + shuadan_accountExample.sdaid;
            return DBHelper.ExecuteNonQuery(GetSqlParameter(shuadan_accountExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdaid"></param>
        /// <returns>int</returns>
        public int Delete(int sdaid)
        {
            DBHelper.sqlstr = "delete from shuadan_account where sdaid =@sdaid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@sdaid",sdaid)
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
        public static SqlParameter[] GetSqlParameter(shuadan_account shuadan_accountExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(shuadan_accountExample.sdaccount))
            {
                list_param.Add(new SqlParameter("@sdaccount", shuadan_accountExample.sdaccount));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdaccount", DBNull.Value));
            }
            if (shuadan_accountExample.sdadate != new DateTime() && shuadan_accountExample.sdadate != null)
            {
                list_param.Add(new SqlParameter("@sdadate", shuadan_accountExample.sdadate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdadate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_accountExample.sdapwd))
            {
                list_param.Add(new SqlParameter("@sdapwd", shuadan_accountExample.sdapwd));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdapwd", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_accountExample.sdastate))
            {
                list_param.Add(new SqlParameter("@sdastate", shuadan_accountExample.sdastate));
            }
            else
            {
                list_param.Add(new SqlParameter("@sdastate", DBNull.Value));
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
        /// <returns>shuadan_accountExample</returns>
        public static shuadan_account GetByReader(SqlDataReader Reader)
        {
            shuadan_account shuadan_accountExample = new shuadan_account();
            shuadan_accountExample.sdaccount = Reader["sdaccount"] == DBNull.Value ? null : Reader["sdaccount"].ToString();
            shuadan_accountExample.sdadate = Reader["sdadate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sdadate"]);
            shuadan_accountExample.sdaid = Reader["sdaid"] == DBNull.Value ? 0 : (int)Reader["sdaid"];
            shuadan_accountExample.sdapwd = Reader["sdapwd"] == DBNull.Value ? null : Reader["sdapwd"].ToString();
            shuadan_accountExample.sdastate = Reader["sdastate"] == DBNull.Value ? null : Reader["sdastate"].ToString();
            return shuadan_accountExample;
        }
        #endregion





        #endregion
    }
   
   
	
	
	
	

}

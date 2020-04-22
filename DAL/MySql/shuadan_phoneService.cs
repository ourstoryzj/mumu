using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.Mysql
{


    //表名称：shuadan_phone
    //实体类名称：shuadan_phoneExample
    //主键：sdpid

    public class shuadan_phoneService : Ishuadan_phoneService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_phone> SearchAll()
        {
            DBHelper.sqlstr = "select * from shuadan_phone ";
            List<shuadan_phone> list = new List<shuadan_phone>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_phone Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBysdpid
        /// <summary>
        /// 根据sdpid,查询一条数据
        /// </summary>
        /// <param name="sdpid"></param>
        /// <returns></returns>
        public shuadan_phone SearchBysdpid(int sdpid)
        {
            DBHelper.sqlstr = "select * from shuadan_phone where sdpid = @sdpid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@sdpid",sdpid)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            shuadan_phone Obj = null;
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
        /// <param name="shuadan_phone">shuadan_phone表实例</param>
        /// <returns>int</returns>
        public int Insert(shuadan_phone shuadan_phoneExample)
        {
            DBHelper.sqlstr = "insert into  shuadan_phone (sdpcode,sdpdate,sdpstate)values(@sdpcode,'" + shuadan_phoneExample.sdpdate.ToString() + "',@sdpstate)";
            return DBHelper.ExecuteNonQuery(GetSqlParameter(shuadan_phoneExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_phone">shuadan_phone表实例</param>
        /// <returns>int</returns>
        public int Update(shuadan_phone shuadan_phoneExample)
        {
            DBHelper.sqlstr = "update shuadan_phone set sdpcode=@sdpcode,sdpdate='" + shuadan_phoneExample.sdpdate.ToString() + "',sdpstate=@sdpstate where sdpid=" + shuadan_phoneExample.sdpid;
            return DBHelper.ExecuteNonQuery(GetSqlParameter(shuadan_phoneExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdpid"></param>
        /// <returns>int</returns>
        public int Delete(int sdpid)
        {
            DBHelper.sqlstr = "delete from shuadan_phone where sdpid =@sdpid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@sdpid",sdpid)
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
        public static MySqlParameter[] GetSqlParameter(shuadan_phone shuadan_phoneExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(shuadan_phoneExample.sdpcode))
            {
                list_param.Add(new MySqlParameter("@sdpcode", shuadan_phoneExample.sdpcode));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdpcode", DBNull.Value));
            }
            if (shuadan_phoneExample.sdpdate != new DateTime() && shuadan_phoneExample.sdpdate != null)
            {
                list_param.Add(new MySqlParameter("@sdpdate", shuadan_phoneExample.sdpdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdpdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_phoneExample.sdpstate))
            {
                list_param.Add(new MySqlParameter("@sdpstate", shuadan_phoneExample.sdpstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@sdpstate", DBNull.Value));
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
        /// <returns>shuadan_phoneExample</returns>
        public static shuadan_phone GetByReader(MySqlDataReader Reader)
        {
            shuadan_phone shuadan_phoneExample = new shuadan_phone();
            shuadan_phoneExample.sdpcode = Reader["sdpcode"] == DBNull.Value ? null : Reader["sdpcode"].ToString();
            shuadan_phoneExample.sdpdate = Reader["sdpdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sdpdate"]);
            shuadan_phoneExample.sdpid = Reader["sdpid"] == DBNull.Value ? 0 : (int)Reader["sdpid"];
            shuadan_phoneExample.sdpstate = Reader["sdpstate"] == DBNull.Value ? null : Reader["sdpstate"].ToString();
            return shuadan_phoneExample;
        }
        #endregion





        #endregion
    }


 
    
	
	
	
	

	

}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql
{


    public class SignsService : ISignsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<Signs> SearchAll()
        {
            DBHelper.sqlstr = "select * from Signs ";
            List<Signs> list = new List<Signs>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                Signs Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchById
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /*查看是否为视图*/

        public Signs SearchById(int Id)
        {
            DBHelper.sqlstr = "select * from Signs where Id = @Id";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@Id",Id)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            Signs Obj = null;
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
        /// <param name="Signs">Signs表实例</param>
        /// <returns>int</returns>
        public int Insert(Signs SignsExample)
        {
            DBHelper.sqlstr = "insert into  Signs (SignTime,Remark,UId,UName,UState,UType)values(@SignTime,@Remark,@UId,@UName,@UState,@UType)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(SignsExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Signs">Signs表实例</param>
        /// <returns>int</returns>
        public int Update(Signs SignsExample)
        {
            DBHelper.sqlstr = "update Signs set SignTime=@SignTime,Remark=@Remark,UId=@UId,UName=@UName,UState=@UState,UType=@UType where Id=" + SignsExample.Id;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(SignsExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>int</returns>
        public int Delete(int Id)
        {
            DBHelper.sqlstr = "delete Signs where Id =@Id";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@Id",Id)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion


        #region searchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public int searchNum(string key, DateTime start, DateTime end, int uid, int state, int type)
        {
            string sql = " select count(id) from Signs where ";
            string sql1 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( Remark like '%" + key + "%' or UName like '%" + key + "%' ) ";
            string sql2 = start == new DateTime() ? "" : " and datediff(d,'" + start.ToString() + "',SignTime)>=0 ";
            string sql3 = end == new DateTime() ? "" : " and datediff(d,'" + end.ToString() + "',SignTime)<=0 ";
            string sql4 = uid == 0 ? "" : " and UId= " + uid.ToString();
            string sql5 = state == 0 ? "" : " and UState= " + state.ToString();
            string sql6 = type == 0 ? "" : " and UType= " + type.ToString();
            DBHelper.sqlstr = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6;
            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region search
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<Signs> search(int s, int e, string key, DateTime start, DateTime end, int uid, int state, int type, string orderby)
        {
            string sql = " select * from Signs where ";
            string sql1 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( Remark like '%" + key + "%' or UName like '%" + key + "%' ) ";
            string sql2 = start == new DateTime() ? "" : " and datediff(d,'" + start.ToString() + "',SignTime)>=0 ";
            string sql3 = end == new DateTime() ? "" : " and datediff(d,'" + end.ToString() + "',SignTime)<=0 ";
            string sql4 = uid == 0 ? "" : " and UId= " + uid.ToString();
            string sql5 = state == 0 ? "" : " and UState= " + state.ToString();
            string sql6 = type == 0 ? "" : " and UType= " + type.ToString();
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by SignTime desc " : " order by " + orderby;
            string sql10 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 +  sql7+sql10;
            List<Signs> list = new List<Signs>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                Signs Obj = GetByReader(reader);
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
        public static MySqlParameter[] GetSqlParameters(Signs SignsExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();
            if (SignsExample.SignTime != new DateTime() && SignsExample.SignTime != null)
            {
                list_param.Add(new MySqlParameter("@SignTime", SignsExample.SignTime.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@SignTime", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(SignsExample.Remark))
            {
                list_param.Add(new MySqlParameter("@Remark", SignsExample.Remark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@Remark", DBNull.Value));
            }
            if (SignsExample.UId != 0)
            {
                list_param.Add(new MySqlParameter("@UId", SignsExample.UId));
            }
            else
            {
                list_param.Add(new MySqlParameter("@UId", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(SignsExample.UName))
            {
                list_param.Add(new MySqlParameter("@UName", SignsExample.UName));
            }
            else
            {
                list_param.Add(new MySqlParameter("@UName", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(SignsExample.UState))
            {
                list_param.Add(new MySqlParameter("@UState", SignsExample.UState));
            }
            else
            {
                list_param.Add(new MySqlParameter("@UState", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(SignsExample.UType))
            {
                list_param.Add(new MySqlParameter("@UType", SignsExample.UType));
            }
            else
            {
                list_param.Add(new MySqlParameter("@UType", DBNull.Value));
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
        /// <returns>SignsExample</returns>
        public static Signs GetByReader(MySqlDataReader Reader)
        {
            Signs SignsExample = new Signs();
            SignsExample.Id = Reader["Id"] == DBNull.Value ? 0 : (int)Reader["Id"];
            SignsExample.SignTime = Reader["SignTime"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["SignTime"]);
            SignsExample.Remark = Reader["Remark"] == DBNull.Value ? null : Reader["Remark"].ToString();
            SignsExample.UId = Reader["UId"] == DBNull.Value ? 0 : (int)Reader["UId"];
            SignsExample.UName = Reader["UName"] == DBNull.Value ? null : Reader["UName"].ToString();
            SignsExample.UState = Reader["UState"] == DBNull.Value ? null : Reader["UState"].ToString();
            SignsExample.UType = Reader["UType"] == DBNull.Value ? null : Reader["UType"].ToString();
            return SignsExample;
        }
        #endregion





        #endregion
    }
    
   

   

	

}

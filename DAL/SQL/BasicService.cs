using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{


    public class BasicService : IBasicService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<Basic> SearchAll()
        {
            DBHelper.sqlstr = "select * from Basic ";
            List<Basic> list = new List<Basic>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                Basic Obj = GetByReader(reader);
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

        public Basic SearchById(int Id)
        {
            DBHelper.sqlstr = "select * from Basic where Id = @Id";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id",Id)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            Basic Obj = null;
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
        /// <param name="Basic">Basic表实例</param>
        /// <returns>int</returns>
        public int Insert(Basic BasicExample)
        {
            DBHelper.sqlstr = "insert into  Basic (Sign1,Sign2,Sign3,Sign4,State)values(@Sign1,@Sign2,@Sign3,@Sign4,@State)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(BasicExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Basic">Basic表实例</param>
        /// <returns>int</returns>
        public int Update(Basic BasicExample)
        {
            DBHelper.sqlstr = "update Basic set Sign1=@Sign1,Sign2=@Sign2,Sign3=@Sign3,Sign4=@Sign4,State=@State where Id=" + BasicExample.Id;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(BasicExample));
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
            DBHelper.sqlstr = "delete Basic where Id =@Id";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@Id",Id)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region searchByState
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public Basic searchByState(string State)
        {
            DBHelper.sqlstr = "select * from Basic where State = @State";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@State",State)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            Basic Obj = null;
            if (reader.Read())
            {
                Obj = GetByReader(reader);
            }
            reader.Close();
            return Obj;
        }
        #endregion


        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="id">int字段</param>
        /// <param name="orderby">排序</param>
        /// <returns>IList<Basic></returns>
        public IList<Basic> Search(int s, int e, string key, string state, int id, string orderby)
        {
            string sql1 = "select top " + (e - s + 1).ToString() + " * from Basic where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( Sign1 like '%" + key + "%' or Sign2 like '%" + key + "%' or Sign3 like '%" + key + "%' or Sign4 like '%" + key + "%' or State like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and State= '" + state + "' ";//状态字段，无用删除
            string sql4 = id == 0 ? "" : " and id字段='" + id.ToString() + "' ";//Int字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by ID desc " : " order by " + orderby;
            string sql8 = s == 1 ? "" : " and ID not in ( select top " + (s - 1).ToString() + " ID from Basic where " + sql2 + sql3 + sql4  + sql7 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4  + sql8 + sql7;
            List<Basic> list = new List<Basic>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                Basic Obj = GetByReader(reader);
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
        public static SqlParameter[] GetSqlParameters(Basic BasicExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(BasicExample.Sign1))
            {
                list_param.Add(new SqlParameter("@Sign1", BasicExample.Sign1));
            }
            else
            {
                list_param.Add(new SqlParameter("@Sign1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(BasicExample.Sign2))
            {
                list_param.Add(new SqlParameter("@Sign2", BasicExample.Sign2));
            }
            else
            {
                list_param.Add(new SqlParameter("@Sign2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(BasicExample.Sign3))
            {
                list_param.Add(new SqlParameter("@Sign3", BasicExample.Sign3));
            }
            else
            {
                list_param.Add(new SqlParameter("@Sign3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(BasicExample.Sign4))
            {
                list_param.Add(new SqlParameter("@Sign4", BasicExample.Sign4));
            }
            else
            {
                list_param.Add(new SqlParameter("@Sign4", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(BasicExample.State))
            {
                list_param.Add(new SqlParameter("@State", BasicExample.State));
            }
            else
            {
                list_param.Add(new SqlParameter("@State", DBNull.Value));
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
        /// <returns>BasicExample</returns>
        public static Basic GetByReader(SqlDataReader Reader)
        {
            Basic BasicExample = new Basic();
            BasicExample.Id = Reader["Id"] == DBNull.Value ? 0 : (int)Reader["Id"];
            BasicExample.Sign1 = Reader["Sign1"] == DBNull.Value ? null : Reader["Sign1"].ToString();
            BasicExample.Sign2 = Reader["Sign2"] == DBNull.Value ? null : Reader["Sign2"].ToString();
            BasicExample.Sign3 = Reader["Sign3"] == DBNull.Value ? null : Reader["Sign3"].ToString();
            BasicExample.Sign4 = Reader["Sign4"] == DBNull.Value ? null : Reader["Sign4"].ToString();
            BasicExample.State = Reader["State"] == DBNull.Value ? null : Reader["State"].ToString();
            return BasicExample;
        }
        #endregion





        #endregion
    }
    
   

	

}

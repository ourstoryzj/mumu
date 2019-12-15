using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.OleDb;

namespace DAL.Access
{




    //表名称：Signs
    //实体类名称：SignsExample
    //主键：Id

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
            Access.DBHelper.sqlstr = "select * from Signs ";
            List<Signs> list = new List<Signs>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
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
        public Signs SearchById(int Id)
        {
            Access.DBHelper.sqlstr = "select * from Signs where Id = @Id";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@Id",Id)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
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
            Access.DBHelper.sqlstr = "insert into  Signs (Remark,SignTime,UId,UName,UState,UType)values(@Remark,'" + SignsExample.SignTime.ToString() + "',@UId,@UName,@UState,@UType)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(SignsExample));
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
            Access.DBHelper.sqlstr = "update Signs set Remark=@Remark,SignTime='" + SignsExample.SignTime.ToString() + "',UId=@UId,UName=@UName,UState=@UState,UType=@UType where Id=" + SignsExample.Id;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(SignsExample));
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
            Access.DBHelper.sqlstr = "delete from Signs where Id =@Id";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@Id",Id)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
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
            string sql2 = start == new DateTime() ? "" : " and datediff('d','" + start.ToString() + "',SignTime)>=0 ";
            string sql3 = end == new DateTime() ? "" : " and datediff('d','" + end.ToString() + "',SignTime)<=0 ";
            string sql4 = uid == 0 ? "" : " and UId= " + uid.ToString();
            string sql5 = state == 0 ? "" : " and UState= " + state.ToString();
            string sql6 = type == 0 ? "" : " and UType= " + type.ToString();
            Access.DBHelper.sqlstr = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6;
            return Convert.ToInt32(Access.DBHelper.ExecuteScalar());
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
            string sql = " select top " + (e - s + 1).ToString() + " * from Signs where ";
            string sql1 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( Remark like '%" + key + "%' or UName like '%" + key + "%' ) ";
            string sql2 = start == new DateTime() ? "" : " and datediff('d','" + start.ToString() + "',SignTime)>=0 ";
            string sql3 = end == new DateTime() ? "" : " and datediff('d','" + end.ToString() + "',SignTime)<=0 ";
            string sql4 = uid == 0 ? "" : " and UId= " + uid.ToString();
            string sql5 = state == 0 ? "" : " and UState= " + state.ToString();
            string sql6 = type == 0 ? "" : " and UType= " + type.ToString();
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by SignTime desc " : " order by " + orderby;
            Access.DBHelper.sqlstr = sql + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + " and id not in ( select top " + (s - 1).ToString() + " id from Signs where " + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + " ) " + sql7;
            List<Signs> list = new List<Signs>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
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

        #region GetOleDbParameter
        /// <summary>
        /// 根据表,获取一个OleDbParameter数组
        /// </summary>
        /// <returns>OleDbParameter[]</returns>
        public static OleDbParameter[] GetOleDbParameter(Signs SignsExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(SignsExample.Remark))
            {
                list_param.Add(new OleDbParameter("@Remark", SignsExample.Remark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Remark", DBNull.Value));
            }
            if (SignsExample.SignTime != new DateTime() && SignsExample.SignTime != null)
            {
                list_param.Add(new OleDbParameter("@SignTime", SignsExample.SignTime.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new OleDbParameter("@SignTime", DBNull.Value));
            }
            if (SignsExample.UId != 0)
            {
                list_param.Add(new OleDbParameter("@UId", SignsExample.UId));
            }
            else
            {
                list_param.Add(new OleDbParameter("@UId", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(SignsExample.UName))
            {
                list_param.Add(new OleDbParameter("@UName", SignsExample.UName));
            }
            else
            {
                list_param.Add(new OleDbParameter("@UName", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(SignsExample.UState))
            {
                list_param.Add(new OleDbParameter("@UState", SignsExample.UState));
            }
            else
            {
                list_param.Add(new OleDbParameter("@UState", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(SignsExample.UType))
            {
                list_param.Add(new OleDbParameter("@UType", SignsExample.UType));
            }
            else
            {
                list_param.Add(new OleDbParameter("@UType", DBNull.Value));
            }
            OleDbParameter[] param = new OleDbParameter[list_param.Count];
            int index = 0;
            foreach (OleDbParameter p in list_param)
            {
                param[index] = p;
                index++;
            }
            return param;
        }
        #endregion

        #region GetByReader
        /// <summary>
        /// 从一个OleDbDataReader里读数据
        /// </summary>
        /// <param name="Reader">OleDbDataReader</param>
        /// <returns>SignsExample</returns>
        public static Signs GetByReader(OleDbDataReader Reader)
        {
            Signs SignsExample = new Signs();
            SignsExample.Id = Reader["Id"] == DBNull.Value ? 0 : (int)Reader["Id"];
            SignsExample.Remark = Reader["Remark"] == DBNull.Value ? null : Reader["Remark"].ToString();
            SignsExample.SignTime = Reader["SignTime"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["SignTime"]);
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

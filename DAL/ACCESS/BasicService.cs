using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.OleDb;

namespace DAL.Access
{



    //表名称：Basic
    //实体类名称：BasicExample
    //主键：Id

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
            Access.DBHelper.sqlstr = "select * from Basic ";
            List<Basic> list = new List<Basic>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
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
        public Basic SearchById(int Id)
        {
            Access.DBHelper.sqlstr = "select * from Basic where Id = @Id";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@Id",Id)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
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
            Access.DBHelper.sqlstr = "insert into  Basic (Sign1,Sign2,Sign3,Sign4,State)values(@Sign1,@Sign2,@Sign3,@Sign4,@State)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(BasicExample));
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
            Access.DBHelper.sqlstr = "update Basic set Sign1=@Sign1,Sign2=@Sign2,Sign3=@Sign3,Sign4=@Sign4,State=@State where Id=" + BasicExample.Id;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(BasicExample));
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
            Access.DBHelper.sqlstr = "delete from Basic where Id =@Id";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@Id",Id)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
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
            Access.DBHelper.sqlstr = "select * from Basic where State = @State";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@State",State)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            Basic Obj = null;
            if (reader.Read())
            {
                Obj = GetByReader(reader);
            }
            reader.Close();
            return Obj;
        }
        #endregion


        #region 公共方法

        #region GetOleDbParameter
        /// <summary>
        /// 根据表,获取一个OleDbParameter数组
        /// </summary>
        /// <returns>OleDbParameter[]</returns>
        public static OleDbParameter[] GetOleDbParameter(Basic BasicExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(BasicExample.Sign1))
            {
                list_param.Add(new OleDbParameter("@Sign1", BasicExample.Sign1));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Sign1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(BasicExample.Sign2))
            {
                list_param.Add(new OleDbParameter("@Sign2", BasicExample.Sign2));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Sign2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(BasicExample.Sign3))
            {
                list_param.Add(new OleDbParameter("@Sign3", BasicExample.Sign3));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Sign3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(BasicExample.Sign4))
            {
                list_param.Add(new OleDbParameter("@Sign4", BasicExample.Sign4));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Sign4", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(BasicExample.State))
            {
                list_param.Add(new OleDbParameter("@State", BasicExample.State));
            }
            else
            {
                list_param.Add(new OleDbParameter("@State", DBNull.Value));
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
        /// <returns>BasicExample</returns>
        public static Basic GetByReader(OleDbDataReader Reader)
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

        public IList<Basic> Search(int s, int e, string key, string state, int id, string orderby)
        {
            throw new NotImplementedException();
        }
        #endregion





        #endregion
    }
 
	


	

}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql
{



    public class UsersService : IUsersService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<Users> SearchAll()
        {
            DBHelper.sqlstr = "select * from Users ";
            List<Users> list = new List<Users>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                Users Obj = GetByReader(reader);
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

        public Users SearchById(int Id)
        {
            DBHelper.sqlstr = "select * from Users where Id = @Id";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@Id",Id)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            Users Obj = null;
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
        /// <param name="Users">Users表实例</param>
        /// <returns>int</returns>
        public int Insert(Users UsersExample)
        {
            DBHelper.sqlstr = "insert into  Users (Account,Password,LoginTime,State,Name,Birthday,Phone,Address,Remark,Sex)values(@Account,@Password,@LoginTime,@State,@Name,@Birthday,@Phone,@Address,@Remark,@Sex)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(UsersExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Users">Users表实例</param>
        /// <returns>int</returns>
        public int Update(Users UsersExample)
        {
            DBHelper.sqlstr = "update Users set Account=@Account,Password=@Password,LoginTime=@LoginTime,State=@State,Name=@Name,Birthday=@Birthday,Phone=@Phone,Address=@Address,Remark=@Remark,Sex=@Sex where Id=" + UsersExample.Id;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(UsersExample));
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
            DBHelper.sqlstr = "delete Users where Id =@Id";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@Id",Id)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region searchByAcc
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public Users searchByAcc(string acc)
        {
            DBHelper.sqlstr = "select * from Users where Account = @Account";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@Account",acc)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            Users Obj = null;
            if (reader.Read())
            {
                Obj = GetByReader(reader);
            }
            reader.Close();
            return Obj;
        }
        #endregion


        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个MySqlParameter数组
        /// </summary>
        /// <returns>MySqlParameter[]</returns>
        public static MySqlParameter[] GetSqlParameters(Users UsersExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(UsersExample.Account))
            {
                list_param.Add(new MySqlParameter("@Account", UsersExample.Account));
            }
            else
            {
                list_param.Add(new MySqlParameter("@Account", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Password))
            {
                list_param.Add(new MySqlParameter("@Password", UsersExample.Password));
            }
            else
            {
                list_param.Add(new MySqlParameter("@Password", DBNull.Value));
            }
            if (UsersExample.LoginTime != new DateTime() && UsersExample.LoginTime != null)
            {
                list_param.Add(new MySqlParameter("@LoginTime", UsersExample.LoginTime.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@LoginTime", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.State))
            {
                list_param.Add(new MySqlParameter("@State", UsersExample.State));
            }
            else
            {
                list_param.Add(new MySqlParameter("@State", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Name))
            {
                list_param.Add(new MySqlParameter("@Name", UsersExample.Name));
            }
            else
            {
                list_param.Add(new MySqlParameter("@Name", DBNull.Value));
            }
            if (UsersExample.Birthday != new DateTime() && UsersExample.Birthday != null)
            {
                list_param.Add(new MySqlParameter("@Birthday", UsersExample.Birthday));
            }
            else
            {
                list_param.Add(new MySqlParameter("@Birthday", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Phone))
            {
                list_param.Add(new MySqlParameter("@Phone", UsersExample.Phone));
            }
            else
            {
                list_param.Add(new MySqlParameter("@Phone", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Address))
            {
                list_param.Add(new MySqlParameter("@Address", UsersExample.Address));
            }
            else
            {
                list_param.Add(new MySqlParameter("@Address", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Remark))
            {
                list_param.Add(new MySqlParameter("@Remark", UsersExample.Remark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@Remark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Sex))
            {
                list_param.Add(new MySqlParameter("@Sex", UsersExample.Sex));
            }
            else
            {
                list_param.Add(new MySqlParameter("@Sex", DBNull.Value));
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
        /// <returns>UsersExample</returns>
        public static Users GetByReader(MySqlDataReader Reader)
        {
            Users UsersExample = new Users();
            UsersExample.Id = Reader["Id"] == DBNull.Value ? 0 : (int)Reader["Id"];
            UsersExample.Account = Reader["Account"] == DBNull.Value ? null : Reader["Account"].ToString();
            UsersExample.Password = Reader["Password"] == DBNull.Value ? null : Reader["Password"].ToString();
            UsersExample.LoginTime = Reader["LoginTime"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["LoginTime"]);
            UsersExample.State = Reader["State"] == DBNull.Value ? null : Reader["State"].ToString();
            UsersExample.Name = Reader["Name"] == DBNull.Value ? null : Reader["Name"].ToString();
            UsersExample.Birthday = Reader["Birthday"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["Birthday"]);
            UsersExample.Phone = Reader["Phone"] == DBNull.Value ? null : Reader["Phone"].ToString();
            UsersExample.Address = Reader["Address"] == DBNull.Value ? null : Reader["Address"].ToString();
            UsersExample.Remark = Reader["Remark"] == DBNull.Value ? null : Reader["Remark"].ToString();
            UsersExample.Sex = Reader["Sex"] == DBNull.Value ? null : Reader["Sex"].ToString();
            return UsersExample;
        }
        #endregion





        #endregion
    }
    
   

   

	

}

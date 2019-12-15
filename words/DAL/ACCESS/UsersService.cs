using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.OleDb;

namespace DAL.Access
{




    //表名称：Users
    //实体类名称：UsersExample
    //主键：Id

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
            Access.DBHelper.sqlstr = "select * from Users ";
            List<Users> list = new List<Users>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
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
        public Users SearchById(int Id)
        {
            Access.DBHelper.sqlstr = "select * from Users where Id = @Id";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@Id",Id)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
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
            Access.DBHelper.sqlstr = "insert into  Users (Account,Address,Birthday,LoginTime,Name,Password,Phone,Remark,Sex,State)values(@Account,@Address,'" + UsersExample.Birthday.ToString() + "','" + UsersExample.LoginTime.ToString() + "',@Name,@Password,@Phone,@Remark,@Sex,@State)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(UsersExample));
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
            string sql1 = "update Users set Account=@Account,Address=@Address,";
            string sql2 = UsersExample.Birthday == new DateTime() ? "" : "Birthday='" + UsersExample.Birthday.ToString() + "',";
            string sql3 = "LoginTime='" + UsersExample.LoginTime.ToString() + "',Name=@Name,Password=@Password,Phone=@Phone,Remark=@Remark,Sex=@Sex,State=@State where Id=" + UsersExample.Id;
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3;
            
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(UsersExample));
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
            Access.DBHelper.sqlstr = "delete from Users where Id =@Id";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@Id",Id)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
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
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@Account",acc)
			};
            OleDbDataReader reader = DBHelper.ExecuteReader(param);
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

        #region GetOleDbParameter
        /// <summary>
        /// 根据表,获取一个OleDbParameter数组
        /// </summary>
        /// <returns>OleDbParameter[]</returns>
        public static OleDbParameter[] GetOleDbParameter(Users UsersExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(UsersExample.Account))
            {
                list_param.Add(new OleDbParameter("@Account", UsersExample.Account));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Account", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Address))
            {
                list_param.Add(new OleDbParameter("@Address", UsersExample.Address));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Address", DBNull.Value));
            }
            if (UsersExample.Birthday != new DateTime() && UsersExample.Birthday != null)
            {
                list_param.Add(new OleDbParameter("@Birthday", UsersExample.Birthday.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Birthday", DBNull.Value));
            }
            if (UsersExample.LoginTime != new DateTime() && UsersExample.LoginTime != null)
            {
                list_param.Add(new OleDbParameter("@LoginTime", UsersExample.LoginTime.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new OleDbParameter("@LoginTime", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Name))
            {
                list_param.Add(new OleDbParameter("@Name", UsersExample.Name));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Name", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Password))
            {
                list_param.Add(new OleDbParameter("@Password", UsersExample.Password));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Password", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Phone))
            {
                list_param.Add(new OleDbParameter("@Phone", UsersExample.Phone));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Phone", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Remark))
            {
                list_param.Add(new OleDbParameter("@Remark", UsersExample.Remark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Remark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.Sex))
            {
                list_param.Add(new OleDbParameter("@Sex", UsersExample.Sex));
            }
            else
            {
                list_param.Add(new OleDbParameter("@Sex", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(UsersExample.State))
            {
                list_param.Add(new OleDbParameter("@State", UsersExample.State));
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
        /// <returns>UsersExample</returns>
        public static Users GetByReader(OleDbDataReader Reader)
        {
            Users UsersExample = new Users();
            UsersExample.Account = Reader["Account"] == DBNull.Value ? null : Reader["Account"].ToString();
            UsersExample.Address = Reader["Address"] == DBNull.Value ? null : Reader["Address"].ToString();
            UsersExample.Birthday = Reader["Birthday"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["Birthday"]);
            UsersExample.Id = Reader["Id"] == DBNull.Value ? 0 : (int)Reader["Id"];
            UsersExample.LoginTime = Reader["LoginTime"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["LoginTime"]);
            UsersExample.Name = Reader["Name"] == DBNull.Value ? null : Reader["Name"].ToString();
            UsersExample.Password = Reader["Password"] == DBNull.Value ? null : Reader["Password"].ToString();
            UsersExample.Phone = Reader["Phone"] == DBNull.Value ? null : Reader["Phone"].ToString();
            UsersExample.Remark = Reader["Remark"] == DBNull.Value ? null : Reader["Remark"].ToString();
            UsersExample.Sex = Reader["Sex"] == DBNull.Value ? null : Reader["Sex"].ToString();
            UsersExample.State = Reader["State"] == DBNull.Value ? null : Reader["State"].ToString();
            return UsersExample;
        }
        #endregion





        #endregion
    }







}

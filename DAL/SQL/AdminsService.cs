﻿using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{


 

    public class AdminsService : IAdminsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<Admins> SearchAll()
        {
            DBHelper.sqlstr = "select * from Admins ";
            List<Admins> list = new List<Admins>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                Admins Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByaid
        /// <summary>
        /// 根据aid,查询一条数据
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        /*查看是否为视图*/

        public Admins SearchByaid(int aid)
        {
            DBHelper.sqlstr = "select * from Admins where aid = @aid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@aid",aid)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            Admins Obj = null;
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
        /// <param name="Admins">Admins表实例</param>
        /// <returns>int</returns>
        public int Insert(Admins AdminsExample)
        {
            DBHelper.sqlstr = "insert into  Admins (aaccount,apassword,alogintime,astate,atype)values(@aaccount,@apassword,@alogintime,@astate,@atype)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(AdminsExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Admins">Admins表实例</param>
        /// <returns>int</returns>
        public int Update(Admins AdminsExample)
        {
            DBHelper.sqlstr = "update Admins set aaccount=@aaccount,apassword=@apassword,alogintime=@alogintime,astate=@astate,atype=@atype where aid=" + AdminsExample.aid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(AdminsExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="aid"></param>
        /// <returns>int</returns>
        public int Delete(int aid)
        {
            DBHelper.sqlstr = "delete Admins where aid =@aid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@aid",aid)
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

        public Admins searchByAcc(string acc)
        {
            DBHelper.sqlstr = "select * from Admins where aaccount = @aaccount";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@aaccount",acc)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            Admins Obj = null;
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
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameters(Admins AdminsExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(AdminsExample.aaccount))
            {
                list_param.Add(new SqlParameter("@aaccount", AdminsExample.aaccount));
            }
            else
            {
                list_param.Add(new SqlParameter("@aaccount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(AdminsExample.apassword))
            {
                list_param.Add(new SqlParameter("@apassword", AdminsExample.apassword));
            }
            else
            {
                list_param.Add(new SqlParameter("@apassword", DBNull.Value));
            }
            if (AdminsExample.alogintime != new DateTime() && AdminsExample.alogintime != null)
            {
                list_param.Add(new SqlParameter("@alogintime", AdminsExample.alogintime.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@alogintime", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(AdminsExample.astate))
            {
                list_param.Add(new SqlParameter("@astate", AdminsExample.astate));
            }
            else
            {
                list_param.Add(new SqlParameter("@astate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(AdminsExample.atype))
            {
                list_param.Add(new SqlParameter("@atype", AdminsExample.atype));
            }
            else
            {
                list_param.Add(new SqlParameter("@atype", DBNull.Value));
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
        /// <returns>AdminsExample</returns>
        public static Admins GetByReader(SqlDataReader Reader)
        {
            Admins AdminsExample = new Admins();
            AdminsExample.aid = Reader["aid"] == DBNull.Value ? 0 : (int)Reader["aid"];
            AdminsExample.aaccount = Reader["aaccount"] == DBNull.Value ? null : Reader["aaccount"].ToString();
            AdminsExample.apassword = Reader["apassword"] == DBNull.Value ? null : Reader["apassword"].ToString();
            AdminsExample.alogintime = Reader["alogintime"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["alogintime"]);
            AdminsExample.astate = Reader["astate"] == DBNull.Value ? null : Reader["astate"].ToString();
            AdminsExample.atype = Reader["atype"] == DBNull.Value ? null : Reader["atype"].ToString();
            return AdminsExample;
        }
        #endregion





        #endregion
    }
    
   


	

}

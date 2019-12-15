using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{




    //表名称：yh_goods_corekeys
    //实体类名称：yh_goods_corekeysExample
    //主键：gcid

    public class yh_goods_corekeysService : Iyh_goods_corekeysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<yh_goods_corekeys> SearchAll()
        {
            DBHelper.sqlstr = "select * from yh_goods_corekeys ";
            List<yh_goods_corekeys> list = new List<yh_goods_corekeys>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                yh_goods_corekeys Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBygcid
        /// <summary>
        /// 根据gcid,查询一条数据
        /// </summary>
        /// <param name="gcid">关联表ID</param>
        /// <returns></returns>
        public yh_goods_corekeys SearchBygcid(int gcid)
        {
            DBHelper.sqlstr = "select * from yh_goods_corekeys where gcid = @gcid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@gcid",gcid)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            yh_goods_corekeys Obj = null;
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
        /// <param name="yh_goods_corekeys">yh_goods_corekeys表实例</param>
        /// <returns>int</returns>
        public int Insert(yh_goods_corekeys yh_goods_corekeysExample)
        {
            DBHelper.sqlstr = "insert into  yh_goods_corekeys (cid,gcdate,gcremark,gid)values(@cid,'" + yh_goods_corekeysExample.gcdate.ToString() + "',@gcremark,@gid)";
            return DBHelper.ExecuteNonQuery(GetSqlParameter(yh_goods_corekeysExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_goods_corekeys">yh_goods_corekeys表实例</param>
        /// <returns>int</returns>
        public int Update(yh_goods_corekeys yh_goods_corekeysExample)
        {
            DBHelper.sqlstr = "update yh_goods_corekeys set cid=@cid,gcdate='" + yh_goods_corekeysExample.gcdate.ToString() + "',gcremark=@gcremark,gid=@gid where gcid=" + yh_goods_corekeysExample.gcid;
            return DBHelper.ExecuteNonQuery(GetSqlParameter(yh_goods_corekeysExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gcid">关联表ID</param>
        /// <returns>int</returns>
        public int Delete(int gcid)
        {
            DBHelper.sqlstr = "delete from yh_goods_corekeys where gcid =@gcid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@gcid",gcid)
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
        public static SqlParameter[] GetSqlParameter(yh_goods_corekeys yh_goods_corekeysExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();
            if (yh_goods_corekeysExample.cid != 0)
            {
                list_param.Add(new SqlParameter("@cid", yh_goods_corekeysExample.cid));
            }
            else
            {
                list_param.Add(new SqlParameter("@cid", DBNull.Value));
            }
            //if (yh_goods_corekeysExample.gcdate != new DateTime() && yh_goods_corekeysExample.gcdate != null)
            //{
            //    list_param.Add(new SqlParameter("@gcdate", yh_goods_corekeysExample.gcdate));
            //}
            //else
            //{
            //    list_param.Add(new SqlParameter("@gcdate", DBNull.Value));
            //}

            if (!string.IsNullOrEmpty(yh_goods_corekeysExample.gcremark))
            {
                list_param.Add(new SqlParameter("@gcremark", yh_goods_corekeysExample.gcremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@gcremark", DBNull.Value));
            }
            if (yh_goods_corekeysExample.gid != 0)
            {
                list_param.Add(new SqlParameter("@gid", yh_goods_corekeysExample.gid));
            }
            else
            {
                list_param.Add(new SqlParameter("@gid", DBNull.Value));
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
        /// <returns>yh_goods_corekeysExample</returns>
        public static yh_goods_corekeys GetByReader(SqlDataReader Reader)
        {
            yh_goods_corekeys yh_goods_corekeysExample = new yh_goods_corekeys();
            yh_goods_corekeysExample.cid = Reader["cid"] == DBNull.Value ? 0 : (int)Reader["cid"];
            yh_goods_corekeysExample.gcdate = Reader["gcdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["gcdate"]);
            yh_goods_corekeysExample.gcid = Reader["gcid"] == DBNull.Value ? 0 : (int)Reader["gcid"];
            yh_goods_corekeysExample.gcremark = Reader["gcremark"] == DBNull.Value ? null : Reader["gcremark"].ToString();
            yh_goods_corekeysExample.gid = Reader["gid"] == DBNull.Value ? 0 : (int)Reader["gid"];
            return yh_goods_corekeysExample;
        }
        #endregion





        #endregion
    }
   
   
	
	
	


 
}

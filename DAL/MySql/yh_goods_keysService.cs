using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.Mysql
{





    //表名称：yh_goods_keys
    //实体类名称：yh_goods_keysExample
    //主键：gkid

    public class yh_goods_keysService : Iyh_goods_keysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<yh_goods_keys> SearchAll()
        {
            DBHelper.sqlstr = "select * from yh_goods_keys ";
            List<yh_goods_keys> list = new List<yh_goods_keys>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                yh_goods_keys Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBygkid
        /// <summary>
        /// 根据gkid,查询一条数据
        /// </summary>
        /// <param name="gkid">商品-黄金关键词ID</param>
        /// <returns></returns>
        public yh_goods_keys SearchBygkid(int gkid)
        {
            DBHelper.sqlstr = "select * from yh_goods_keys where gkid = @gkid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@gkid",gkid)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            yh_goods_keys Obj = null;
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
        /// <param name="yh_goods_keys">yh_goods_keys表实例</param>
        /// <returns>int</returns>
        public int Insert(yh_goods_keys yh_goods_keysExample)
        {
            DBHelper.sqlstr = "insert into  yh_goods_keys (gid,gkremark,gkstate,kid)values(@gid,@gkremark,@gkstate,@kid)";
            return DBHelper.ExecuteNonQuery(GetSqlParameter(yh_goods_keysExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_goods_keys">yh_goods_keys表实例</param>
        /// <returns>int</returns>
        public int Update(yh_goods_keys yh_goods_keysExample)
        {
            DBHelper.sqlstr = "update yh_goods_keys set gid=@gid,gkremark=@gkremark,gkstate=@gkstate,kid=@kid where gkid=" + yh_goods_keysExample.gkid;
            return DBHelper.ExecuteNonQuery(GetSqlParameter(yh_goods_keysExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gkid">商品-黄金关键词ID</param>
        /// <returns>int</returns>
        public int Delete(int gkid)
        {
            DBHelper.sqlstr = "delete from yh_goods_keys where gkid =@gkid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@gkid",gkid)
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
        public static MySqlParameter[] GetSqlParameter(yh_goods_keys yh_goods_keysExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();
            if (yh_goods_keysExample.gid != 0)
            {
                list_param.Add(new MySqlParameter("@gid", yh_goods_keysExample.gid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_goods_keysExample.gkremark))
            {
                list_param.Add(new MySqlParameter("@gkremark", yh_goods_keysExample.gkremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gkremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_goods_keysExample.gkstate))
            {
                list_param.Add(new MySqlParameter("@gkstate", yh_goods_keysExample.gkstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gkstate", DBNull.Value));
            }
            if (yh_goods_keysExample.kid != 0)
            {
                list_param.Add(new MySqlParameter("@kid", yh_goods_keysExample.kid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kid", DBNull.Value));
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
        /// <returns>yh_goods_keysExample</returns>
        public static yh_goods_keys GetByReader(MySqlDataReader Reader)
        {
            yh_goods_keys yh_goods_keysExample = new yh_goods_keys();
            yh_goods_keysExample.gid = Reader["gid"] == DBNull.Value ? 0 : (int)Reader["gid"];
            yh_goods_keysExample.gkid = Reader["gkid"] == DBNull.Value ? 0 : (int)Reader["gkid"];
            yh_goods_keysExample.gkremark = Reader["gkremark"] == DBNull.Value ? null : Reader["gkremark"].ToString();
            yh_goods_keysExample.gkstate = Reader["gkstate"] == DBNull.Value ? null : Reader["gkstate"].ToString();
            yh_goods_keysExample.kid = Reader["kid"] == DBNull.Value ? 0 : (int)Reader["kid"];
            return yh_goods_keysExample;
        }
        #endregion





        #endregion
    }
 
	
	
	


}

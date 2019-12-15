using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
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
            Access.DBHelper.sqlstr = "select * from yh_goods_keys ";
            List<yh_goods_keys> list = new List<yh_goods_keys>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
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
            Access.DBHelper.sqlstr = "select * from yh_goods_keys where gkid = @gkid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@gkid",gkid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
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
            Access.DBHelper.sqlstr = "insert into  yh_goods_keys (gid,gkremark,gkstate,kid)values(@gid,@gkremark,@gkstate,@kid)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(yh_goods_keysExample));
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
            Access.DBHelper.sqlstr = "update yh_goods_keys set gid=@gid,gkremark=@gkremark,gkstate=@gkstate,kid=@kid where gkid=" + yh_goods_keysExample.gkid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(yh_goods_keysExample));
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
            Access.DBHelper.sqlstr = "delete from yh_goods_keys where gkid =@gkid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@gkid",gkid)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
        }
        #endregion




        #region 公共方法

        #region GetOleDbParameter
        /// <summary>
        /// 根据表,获取一个OleDbParameter数组
        /// </summary>
        /// <returns>OleDbParameter[]</returns>
        public static OleDbParameter[] GetOleDbParameter(yh_goods_keys yh_goods_keysExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();
            if (yh_goods_keysExample.gid != 0)
            {
                list_param.Add(new OleDbParameter("@gid", yh_goods_keysExample.gid));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_goods_keysExample.gkremark))
            {
                list_param.Add(new OleDbParameter("@gkremark", yh_goods_keysExample.gkremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gkremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_goods_keysExample.gkstate))
            {
                list_param.Add(new OleDbParameter("@gkstate", yh_goods_keysExample.gkstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gkstate", DBNull.Value));
            }
            if (yh_goods_keysExample.kid != 0)
            {
                list_param.Add(new OleDbParameter("@kid", yh_goods_keysExample.kid));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kid", DBNull.Value));
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
        /// <returns>yh_goods_keysExample</returns>
        public static yh_goods_keys GetByReader(OleDbDataReader Reader)
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

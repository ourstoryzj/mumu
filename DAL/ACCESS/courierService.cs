using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
{




    //表名称：courier
    //实体类名称：courierExample
    //主键：cid

    public class courierService : IcourierService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<courier> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from courier order by csort asc  ";
            List<courier> list = new List<courier>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                courier Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据cid,查询一条数据
        /// </summary>
        /// <param name="cid">快递编号</param>
        /// <returns></returns>
        public courier SearchByID(int cid)
        {
            Access.DBHelper.sqlstr = "select * from courier where cid = @cid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@cid",cid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            courier Obj = null;
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
        /// <param name="courier">courier表实例</param>
        /// <returns>int</returns>
        public int Insert(courier courierExample)
        {
            Access.DBHelper.sqlstr = "insert into  courier (cname,cremark,csort)values(@cname,@cremark,@csort)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(courierExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="courier">courier表实例</param>
        /// <returns>int</returns>
        public int Update(courier courierExample)
        {
            Access.DBHelper.sqlstr = "update courier set cname=@cname,cremark=@cremark,csort=@csort where cid=" + courierExample.cid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(courierExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid">快递编号</param>
        /// <returns>int</returns>
        public int Delete(int cid)
        {
            Access.DBHelper.sqlstr = "delete from courier where cid =@cid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@cid",cid)
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
        public static OleDbParameter[] GetOleDbParameter(courier courierExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(courierExample.cname))
            {
                list_param.Add(new OleDbParameter("@cname", courierExample.cname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@cname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(courierExample.cremark))
            {
                list_param.Add(new OleDbParameter("@cremark", courierExample.cremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@cremark", DBNull.Value));
            }
            if (courierExample.csort != 0)
            {
                list_param.Add(new OleDbParameter("@csort", courierExample.csort));
            }
            else
            {
                list_param.Add(new OleDbParameter("@csort", DBNull.Value));
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
        /// <returns>courierExample</returns>
        public static courier GetByReader(OleDbDataReader Reader)
        {
            courier courierExample = new courier();
            courierExample.cid = Reader["cid"] == DBNull.Value ? 0 : (int)Reader["cid"];
            courierExample.cname = Reader["cname"] == DBNull.Value ? null : Reader["cname"].ToString();
            courierExample.cremark = Reader["cremark"] == DBNull.Value ? null : Reader["cremark"].ToString();
            courierExample.csort = Reader["csort"] == DBNull.Value ? 0 : (int)Reader["csort"];
            return courierExample;
        }
        #endregion





        #endregion
    }









}

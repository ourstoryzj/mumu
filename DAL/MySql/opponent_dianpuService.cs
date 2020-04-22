using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.Mysql
{



    public class opponent_dianpuService : Iopponent_dianpuService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<opponent_dianpu> SearchAll()
        {
            DBHelper.sqlstr = "select * from opponent_dianpu  ORDER BY odcollectdate desc ";
            List<opponent_dianpu> list = new List<opponent_dianpu>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                opponent_dianpu Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据oid,查询一条数据
        /// </summary>
        /// <param name="oid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public opponent_dianpu SearchByID(int oid)
        {
            DBHelper.sqlstr = "select * from opponent_dianpu where oid = @oid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@oid",oid)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            opponent_dianpu Obj = null;
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
        /// <param name="opponent_dianpu">opponent_dianpu表实例</param>
        /// <returns>int</returns>
        public int Insert(opponent_dianpu opponent_dianpuExample)
        {
            DBHelper.sqlstr = "insert into  opponent_dianpu (odpname,odcollectdate,odTBID,odwangwang)values(@odpname,@odcollectdate,@odTBID,@odwangwang)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(opponent_dianpuExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="opponent_dianpu">opponent_dianpu表实例</param>
        /// <returns>int</returns>
        public int Update(opponent_dianpu opponent_dianpuExample)
        {
            DBHelper.sqlstr = "update opponent_dianpu set odpname=@odpname,odcollectdate=@odcollectdate,odTBID=@odTBID,odwangwang=@odwangwang where oid=" + opponent_dianpuExample.oid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(opponent_dianpuExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oid">编号</param>
        /// <returns>int</returns>
        public int Delete(int oid)
        {
            DBHelper.sqlstr = "delete opponent_dianpu where oid =@oid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@oid",oid)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 高级搜索数量
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        public int SearchNum(string key)
        {
            string sql1 = "select count(oid) from opponent_dianpu where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( odpname  like '%" + key + "%' or  odTBID like '%" + key + "%' or  odcollectdate like '%" + key + "%'  or  odwangwang  like '%" + key + "%'  ) ";
            DBHelper.sqlstr = sql1 + sql2;
            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 高级搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束为止</param>
        /// <param name="key">关键词</param>
        /// <param name="orderby">排序</param>
        /// <returns>IList<opponent_dianpu></returns>
        public IList<opponent_dianpu> Search(int s, int e, string key, string orderby)
        {
            string sql1 = "select  *   from opponent_dianpu where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( odpname  like '%" + key + "%' or  odTBID like '%" + key + "%' or  odcollectdate like '%" + key + "%'  or  odwangwang  like '%" + key + "%'     ) ";
            string sql3 = string.IsNullOrEmpty(orderby) ? " order by odcollectdate desc " : " order by " + orderby;
            string sql9 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2  + sql3+ sql9;
            List<opponent_dianpu> list = new List<opponent_dianpu>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                opponent_dianpu Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchLastOne
        /// <summary>
        /// 获取最后一条信息
        /// </summary>
        /// <param name="oid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public opponent_dianpu SearchLastOne()
        {
            DBHelper.sqlstr = "SELECT TOP 1 * FROM opponent_dianpu ORDER BY odcollectdate desc";

            MySqlDataReader reader = DBHelper.ExecuteReader();
            opponent_dianpu Obj = null;
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
        public static MySqlParameter[] GetSqlParameters(opponent_dianpu opponent_dianpuExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(opponent_dianpuExample.odpname))
            {
                list_param.Add(new MySqlParameter("@odpname", opponent_dianpuExample.odpname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odpname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpuExample.odcollectdate))
            {
                list_param.Add(new MySqlParameter("@odcollectdate", opponent_dianpuExample.odcollectdate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odcollectdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpuExample.odTBID))
            {
                list_param.Add(new MySqlParameter("@odTBID", opponent_dianpuExample.odTBID));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odTBID", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpuExample.odwangwang))
            {
                list_param.Add(new MySqlParameter("@odwangwang", opponent_dianpuExample.odwangwang));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odwangwang", DBNull.Value));
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
        /// <returns>opponent_dianpuExample</returns>
        public static opponent_dianpu GetByReader(MySqlDataReader Reader)
        {
            opponent_dianpu opponent_dianpuExample = new opponent_dianpu();
            opponent_dianpuExample.oid = Reader["oid"] == DBNull.Value ? 0 : (int)Reader["oid"];
            opponent_dianpuExample.odpname = Reader["odpname"] == DBNull.Value ? null : Reader["odpname"].ToString();
            opponent_dianpuExample.odcollectdate = Reader["odcollectdate"] == DBNull.Value ? null : Reader["odcollectdate"].ToString();
            opponent_dianpuExample.odTBID = Reader["odTBID"] == DBNull.Value ? null : Reader["odTBID"].ToString();
            opponent_dianpuExample.odwangwang = Reader["odwangwang"] == DBNull.Value ? null : Reader["odwangwang"].ToString();
            return opponent_dianpuExample;
        }
        #endregion





        #endregion
    }



}

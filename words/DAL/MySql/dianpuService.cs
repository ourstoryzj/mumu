using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql
{




    //表名称：dianpu
    //实体类名称：dianpuExample
    //主键：dpid

    public class dianpuService : IdianpuService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<dianpu> SearchAll()
        {
            MySql.DBHelper.sqlstr = "select * from dianpu order by dpsort asc ";
            List<dianpu> list = new List<dianpu>();
            MySqlDataReader reader = MySql.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                dianpu Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBydpid
        /// <summary>
        /// 根据dpid,查询一条数据
        /// </summary>
        /// <param name="dpid"></param>
        /// <returns></returns>
        public dianpu SearchBydpid(int dpid)
        {
            MySql.DBHelper.sqlstr = "select * from dianpu where dpid = @dpid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@dpid",dpid)
			};
            MySqlDataReader reader = MySql.DBHelper.ExecuteReader(param);
            dianpu Obj = null;
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
        /// <param name="dianpu">dianpu表实例</param>
        /// <returns>int</returns>
        public int Insert(dianpu dianpuExample)
        {
            MySql.DBHelper.sqlstr = "insert into  dianpu (dpname,dpremark,dpsort,dpstate)values(@dpname,@dpremark,@dpsort,@dpstate)";
            return MySql.DBHelper.ExecuteNonQuery(GetMySqlParameter(dianpuExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dianpu">dianpu表实例</param>
        /// <returns>int</returns>
        public int Update(dianpu dianpuExample)
        {
            MySql.DBHelper.sqlstr = "update dianpu set dpname=@dpname,dpremark=@dpremark,dpsort=@dpsort,dpstate=@dpstate where dpid=" + dianpuExample.dpid;
            return MySql.DBHelper.ExecuteNonQuery(GetMySqlParameter(dianpuExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dpid"></param>
        /// <returns>int</returns>
        public int Delete(int dpid)
        {
            MySql.DBHelper.sqlstr = "delete from dianpu where dpid ="+dpid.ToString();
            return MySql.DBHelper.ExecuteNonQuery();
        }
        #endregion




        #region 公共方法

        #region GetMySqlParameter
        /// <summary>
        /// 根据表,获取一个MySqlParameter数组
        /// </summary>
        /// <returns>MySqlParameter[]</returns>
        public static MySqlParameter[] GetMySqlParameter(dianpu dianpuExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(dianpuExample.dpname))
            {
                list_param.Add(new MySqlParameter("@dpname", dianpuExample.dpname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpremark))
            {
                list_param.Add(new MySqlParameter("@dpremark", dianpuExample.dpremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpsort))
            {
                list_param.Add(new MySqlParameter("@dpsort", dianpuExample.dpsort));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpsort", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpstate))
            {
                list_param.Add(new MySqlParameter("@dpstate", dianpuExample.dpstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpstate", DBNull.Value));
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
        /// <returns>dianpuExample</returns>
        public static dianpu GetByReader(MySqlDataReader Reader)
        {
            dianpu dianpuExample = new dianpu();
            dianpuExample.dpid = Reader["dpid"] == DBNull.Value ? 0 : (int)Reader["dpid"];
            dianpuExample.dpname = Reader["dpname"] == DBNull.Value ? null : Reader["dpname"].ToString();
            dianpuExample.dpremark = Reader["dpremark"] == DBNull.Value ? null : Reader["dpremark"].ToString();
            dianpuExample.dpsort = Reader["dpsort"] == DBNull.Value ? null : Reader["dpsort"].ToString();
            dianpuExample.dpstate = Reader["dpstate"] == DBNull.Value ? null : Reader["dpstate"].ToString();
            return dianpuExample;
        }
        #endregion





        #endregion
    }
    
  
	
	
	
	

	
	
	

	

}

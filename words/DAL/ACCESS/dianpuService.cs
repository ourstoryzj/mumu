using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.OleDb;

namespace DAL.Access
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
            DBHelper.sqlstr = "select * from dianpu order by dpsort asc ";
            List<dianpu> list = new List<dianpu>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                dianpu Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;

        }
        #endregion

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<dianpu> SearchAll(bool isState)
        {
            DBHelper.sqlstr = "select * from dianpu " + (isState ? " where dpstate = '1' " : "") + " order by dpsort asc ";
            List<dianpu> list = new List<dianpu>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
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
            Access.DBHelper.sqlstr = "select * from dianpu where dpid = @dpid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@dpid",dpid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
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
            Access.DBHelper.sqlstr = "insert into  dianpu (dpname,dpremark,dpsort,dpstate)values(@dpname,@dpremark,@dpsort,@dpstate)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(dianpuExample));
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
            Access.DBHelper.sqlstr = "update dianpu set dpname=@dpname,dpremark=@dpremark,dpsort=@dpsort,dpstate=@dpstate where dpid=" + dianpuExample.dpid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(dianpuExample));
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
            Access.DBHelper.sqlstr = "delete from dianpu where dpid =" + dpid.ToString();
            return Access.DBHelper.ExecuteNonQuery();
        }
        #endregion




        #region 公共方法

        #region GetOleDbParameter
        /// <summary>
        /// 根据表,获取一个OleDbParameter数组
        /// </summary>
        /// <returns>OleDbParameter[]</returns>
        public static OleDbParameter[] GetOleDbParameter(dianpu dianpuExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(dianpuExample.dpname))
            {
                list_param.Add(new OleDbParameter("@dpname", dianpuExample.dpname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@dpname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpremark))
            {
                list_param.Add(new OleDbParameter("@dpremark", dianpuExample.dpremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@dpremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpsort))
            {
                list_param.Add(new OleDbParameter("@dpsort", dianpuExample.dpsort));
            }
            else
            {
                list_param.Add(new OleDbParameter("@dpsort", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(dianpuExample.dpstate))
            {
                list_param.Add(new OleDbParameter("@dpstate", dianpuExample.dpstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@dpstate", DBNull.Value));
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
        /// <returns>dianpuExample</returns>
        public static dianpu GetByReader(OleDbDataReader Reader)
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

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.OleDb;

namespace DAL.Access
{




    //表名称：shuadan_phone
    //实体类名称：shuadan_phoneExample
    //主键：sdpid

    public class shuadan_phoneService : Ishuadan_phoneService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_phone> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from shuadan_phone ";
            List<shuadan_phone> list = new List<shuadan_phone>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_phone Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBysdpid
        /// <summary>
        /// 根据sdpid,查询一条数据
        /// </summary>
        /// <param name="sdpid"></param>
        /// <returns></returns>
        public shuadan_phone SearchBysdpid(int sdpid)
        {
            Access.DBHelper.sqlstr = "select * from shuadan_phone where sdpid = @sdpid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@sdpid",sdpid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            shuadan_phone Obj = null;
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
        /// <param name="shuadan_phone">shuadan_phone表实例</param>
        /// <returns>int</returns>
        public int Insert(shuadan_phone shuadan_phoneExample)
        {
            Access.DBHelper.sqlstr = "insert into  shuadan_phone (sdpcode,sdpdate,sdpstate)values(@sdpcode,'" + shuadan_phoneExample.sdpdate.ToString() + "',@sdpstate)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadan_phoneExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_phone">shuadan_phone表实例</param>
        /// <returns>int</returns>
        public int Update(shuadan_phone shuadan_phoneExample)
        {
            Access.DBHelper.sqlstr = "update shuadan_phone set sdpcode=@sdpcode,sdpdate='" + shuadan_phoneExample.sdpdate.ToString() + "',sdpstate=@sdpstate where sdpid=" + shuadan_phoneExample.sdpid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadan_phoneExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdpid"></param>
        /// <returns>int</returns>
        public int Delete(int sdpid)
        {
            Access.DBHelper.sqlstr = "delete from shuadan_phone where sdpid =@sdpid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@sdpid",sdpid)
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
        public static OleDbParameter[] GetOleDbParameter(shuadan_phone shuadan_phoneExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(shuadan_phoneExample.sdpcode))
            {
                list_param.Add(new OleDbParameter("@sdpcode", shuadan_phoneExample.sdpcode));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdpcode", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_phoneExample.sdpstate))
            {
                list_param.Add(new OleDbParameter("@sdpstate", shuadan_phoneExample.sdpstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@sdpstate", DBNull.Value));
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
        /// <returns>shuadan_phoneExample</returns>
        public static shuadan_phone GetByReader(OleDbDataReader Reader)
        {
            shuadan_phone shuadan_phoneExample = new shuadan_phone();
            shuadan_phoneExample.sdpcode = Reader["sdpcode"] == DBNull.Value ? null : Reader["sdpcode"].ToString();
            shuadan_phoneExample.sdpdate = Reader["sdpdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["sdpdate"]);
            shuadan_phoneExample.sdpid = Reader["sdpid"] == DBNull.Value ? 0 : (int)Reader["sdpid"];
            shuadan_phoneExample.sdpstate = Reader["sdpstate"] == DBNull.Value ? null : Reader["sdpstate"].ToString();
            return shuadan_phoneExample;
        }
        #endregion





        #endregion
    }
   
 
	
	
	
	

 
    
	
	
	
	

	

}

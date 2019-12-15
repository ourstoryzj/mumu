using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.OleDb;
using System.Configuration;

namespace DAL.Access
{




    //表名称：shuadan_names
    //实体类名称：shuadan_namesExample
    //主键：nid

    public class shuadan_namesService : Ishuadan_namesService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_names> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from shuadan_names ";
            List<shuadan_names> list = new List<shuadan_names>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_names Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBynid
        /// <summary>
        /// 根据nid,查询一条数据
        /// </summary>
        /// <param name="nid">编号</param>
        /// <returns></returns>
        public shuadan_names SearchBynid(int nid)
        {
            Access.DBHelper.sqlstr = "select * from shuadan_names where nid = @nid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@nid",nid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            shuadan_names Obj = null;
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
        /// <param name="shuadan_names">shuadan_names表实例</param>
        /// <returns>int</returns>
        public int Insert(shuadan_names shuadan_namesExample)
        {
            Access.DBHelper.sqlstr = "insert into  shuadan_names (ncount,nname)values(@ncount,@nname)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadan_namesExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_names">shuadan_names表实例</param>
        /// <returns>int</returns>
        public int Update(shuadan_names shuadan_namesExample)
        {
            Access.DBHelper.sqlstr = "update shuadan_names set ncount=@ncount,nname=@nname where nid=" + shuadan_namesExample.nid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(shuadan_namesExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="nid">编号</param>
        /// <returns>int</returns>
        public int Delete(int nid)
        {
            Access.DBHelper.sqlstr = "delete from shuadan_names where nid =@nid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@nid",nid)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public int SearchNum(string key)
        {
            string sql1 = "select count(nid) from shuadan_names where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  nname like '%" + key + "%'   ) ";
            Access.DBHelper.sqlstr = sql1 + sql2;
            return Convert.ToInt32(Access.DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索(高效率分页查询)
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        public IList<shuadan_names> Search(int s, int e, string key)
        {
            string sql1 = "select top " + e.ToString() + " * from shuadan_names where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  nname like '%" + key + "%'   ) ";
            string sql3 = " order by ncount desc,nid desc ";
            DBHelper.sqlstr = "select top " + (e - s + 1).ToString() + " * from " + "( " + sql1 + sql2 + " order by ncount asc,nid asc ) " + sql3;
            List<shuadan_names> list = new List<shuadan_names>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_names Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchRnd
        /// <summary>
        /// 随机查询名字
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<shuadan_names> SearchRnd(int num)
        {
            Access.DBHelper.sqlstr = "SELECT top " + num.ToString() + " * FROM shuadan_names   order by ncount asc, Rnd(nid) ";
            List<shuadan_names> list = new List<shuadan_names>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                shuadan_names Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion



        #region 公共方法

        #region GetOleDbParameter
        /// <summary>
        /// 根据表,获取一个OleDbParameter数组
        /// </summary>
        /// <returns>OleDbParameter[]</returns>
        public static OleDbParameter[] GetOleDbParameter(shuadan_names shuadan_namesExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(shuadan_namesExample.ncount))
            {
                list_param.Add(new OleDbParameter("@ncount", shuadan_namesExample.ncount));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ncount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(shuadan_namesExample.nname))
            {
                list_param.Add(new OleDbParameter("@nname", shuadan_namesExample.nname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@nname", DBNull.Value));
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
        /// <returns>shuadan_namesExample</returns>
        public static shuadan_names GetByReader(OleDbDataReader Reader)
        {
            shuadan_names shuadan_namesExample = new shuadan_names();
            shuadan_namesExample.ncount = Reader["ncount"] == DBNull.Value ? null : Reader["ncount"].ToString();
            shuadan_namesExample.nid = Reader["nid"] == DBNull.Value ? 0 : (int)Reader["nid"];
            shuadan_namesExample.nname = Reader["nname"] == DBNull.Value ? null : Reader["nname"].ToString();
            return shuadan_namesExample;
        }
        #endregion

        #endregion


    }
















}

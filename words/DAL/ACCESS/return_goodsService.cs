using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
{






    //表名称：return_goods
    //实体类名称：return_goodsExample
    //主键：rgid

    public class return_goodsService : Ireturn_goodsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<return_goods> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from return_goods ";
            List<return_goods> list = new List<return_goods>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                return_goods Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据rgid,查询一条数据
        /// </summary>
        /// <param name="rgid">退货编号</param>
        /// <returns></returns>
        public return_goods SearchByID(int rgid)
        {
            Access.DBHelper.sqlstr = "select * from return_goods where rgid = @rgid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@rgid",rgid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            return_goods Obj = null;
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
        /// <param name="return_goods">return_goods表实例</param>
        /// <returns>int</returns>
        public int Insert(return_goods return_goodsExample)
        {
            Access.DBHelper.sqlstr = "insert into  return_goods (cid,cname,rgcode,rgdate,rgremark)values(@cid,@cname,@rgcode,'" + return_goodsExample.rgdate.ToString() + "',@rgremark)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(return_goodsExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="return_goods">return_goods表实例</param>
        /// <returns>int</returns>
        public int Update(return_goods return_goodsExample)
        {
            Access.DBHelper.sqlstr = "update return_goods set cid=@cid,cname=@cname,rgcode=@rgcode,rgdate='" + return_goodsExample.rgdate.ToString() + "',rgremark=@rgremark where rgid=" + return_goodsExample.rgid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(return_goodsExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="rgid">退货编号</param>
        /// <returns>int</returns>
        public int Delete(int rgid)
        {
            Access.DBHelper.sqlstr = "delete from return_goods where rgid =@rgid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@rgid",rgid)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 根据条件查询全部数据总条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="date1">起始时间</param>
        /// <param name="date2">结束时间</param>
        /// <returns>int</returns>
        public int SearchNum(string key, string cid, DateTime date1, DateTime date2)
        {
            string sql1 = "select count(rgid) from return_goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  cname	 like '%" + key + "%' or  rgcode like '%" + key + "%' or  rgremark like '%" + key + "%' ) ";
            string sql3 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',rgdate)>=0 ";
            string sql4 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',rgdate)<=0 ";
            string sql5 = string.IsNullOrEmpty(cid) ? "" : " and cid= " + cid;
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5;
            return Convert.ToInt32(Access.DBHelper.ExecuteScalar());
        }
        #endregion


        #region Search
        /// <summary>
        /// 根据条件查询全部数据
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="date1">起始时间</param>
        /// <param name="date2">结束时间</param>
        /// <returns>IList<return_goods></returns>
        public IList<return_goods> Search(int s, int e, string key, string cid, DateTime date1, DateTime date2)
        {
            string sql1 = "select top " + e.ToString() + " * from return_goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  cname	 like '%" + key + "%' or  rgcode like '%" + key + "%' or  rgremark like '%" + key + "%' ) ";
            string sql3 = date1 == new DateTime() ? "" : " and datediff('d','" + date1.ToString() + "',rgdate)>=0 ";
            string sql4 = date2 == new DateTime() ? "" : " and datediff('d','" + date2.ToString() + "',rgdate)<=0 ";
            string sql6 = string.IsNullOrEmpty(cid) ? "" : " and cid= " + cid;
            string sql5 = " order by rgid asc,rgdate asc ";//排序两个字段,否则数据容易错误
            DBHelper.sqlstr = "select * from(select top " + (e - s + 1).ToString() + " * from  ( " + sql1 + sql2 + sql3 + sql4 + sql6 + " order by rgid desc,rgdate asc ) " + sql5 + ") order by  rgid desc,rgdate asc ";
            List<return_goods> list = new List<return_goods>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                return_goods Obj = GetByReader(reader);
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
        public static OleDbParameter[] GetOleDbParameter(return_goods return_goodsExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();
            if (return_goodsExample.cid != 0)
            {
                list_param.Add(new OleDbParameter("@cid", return_goodsExample.cid));
            }
            else
            {
                list_param.Add(new OleDbParameter("@cid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(return_goodsExample.cname))
            {
                list_param.Add(new OleDbParameter("@cname", return_goodsExample.cname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@cname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(return_goodsExample.rgcode))
            {
                list_param.Add(new OleDbParameter("@rgcode", return_goodsExample.rgcode));
            }
            else
            {
                list_param.Add(new OleDbParameter("@rgcode", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(return_goodsExample.rgremark))
            {
                list_param.Add(new OleDbParameter("@rgremark", return_goodsExample.rgremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@rgremark", DBNull.Value));
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
        /// <returns>return_goodsExample</returns>
        public static return_goods GetByReader(OleDbDataReader Reader)
        {
            return_goods return_goodsExample = new return_goods();
            return_goodsExample.cid = Reader["cid"] == DBNull.Value ? 0 : (int)Reader["cid"];
            return_goodsExample.cname = Reader["cname"] == DBNull.Value ? null : Reader["cname"].ToString();
            return_goodsExample.rgcode = Reader["rgcode"] == DBNull.Value ? null : Reader["rgcode"].ToString();
            return_goodsExample.rgdate = Reader["rgdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["rgdate"]);
            return_goodsExample.rgid = Reader["rgid"] == DBNull.Value ? 0 : (int)Reader["rgid"];
            return_goodsExample.rgremark = Reader["rgremark"] == DBNull.Value ? null : Reader["rgremark"].ToString();
            return return_goodsExample;
        }
        #endregion





        #endregion
    }












}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{




    //表名称：yh_zaoci
    //实体类名称：yh_zaociExample
    //主键：zid

    public class basic_order_planService : Ibasic_order_planService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<basic_order_plan> SearchAll()
        {
            DBHelper.sqlstr = "select * from basic_order_plan ";
            List<basic_order_plan> list = new List<basic_order_plan>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_order_plan Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据opid,查询一条数据
        /// </summary>
        /// <param name="opid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public basic_order_plan SearchByID(int opid)
        {
            DBHelper.sqlstr = "select * from basic_order_plan where opid = @opid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@opid",opid)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            basic_order_plan Obj = null;
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
        /// <param name="basic_order_plan">basic_order_plan表实例</param>
        /// <returns>int</returns>
        public int Insert(basic_order_plan basic_order_planExample)
        {
            DBHelper.sqlstr = "insert into  basic_order_plan (opday1,opday2,opday3,opday4,opday5,opday6,opday7,opday8,opday9,opday10,opday11,opday12,opday13,opday14,opnum,optype,opremark,opname)values(@opday1,@opday2,@opday3,@opday4,@opday5,@opday6,@opday7,@opday8,@opday9,@opday10,@opday11,@opday12,@opday13,@opday14,@opnum,@optype,@opremark,@opname)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_order_planExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_order_plan">basic_order_plan表实例</param>
        /// <returns>int</returns>
        public int Update(basic_order_plan basic_order_planExample)
        {
            DBHelper.sqlstr = "update basic_order_plan set opday1=@opday1,opday2=@opday2,opday3=@opday3,opday4=@opday4,opday5=@opday5,opday6=@opday6,opday7=@opday7,opday8=@opday8,opday9=@opday9,opday10=@opday10,opday11=@opday11,opday12=@opday12,opday13=@opday13,opday14=@opday14,opnum=@opnum,optype=@optype,opremark=@opremark,opname=@opname where opid=" + basic_order_planExample.opid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_order_planExample));
        }
        #endregion


        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="opid">编号</param>
        /// <returns>int</returns>
        public int Delete(int opid)
        {
            DBHelper.sqlstr = "delete basic_order_plan where opid =@opid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@opid",opid)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <returns>int</returns>
        public int SearchNum(string key, string state)
        {
            string sql1 = "select count(opid) from basic_order_plan where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  opremark like '%" + key + "%' or   opname like '%" + key + "%' ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and optype= '" + state + "' ";

            DBHelper.sqlstr = sql1 + sql2 + sql3;

            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="s">开始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_order_plan></returns>
        public IList<basic_order_plan> Search(int s, int e, string key, string state, string orderby)
        {
            string sql1 = "select  top " + (e - s + 1).ToString() + " *   from basic_order_plan where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( opremark like '%" + key + "%' or   opname like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and optype= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(orderby) ? " order by opid desc " : " order by " + orderby;
            string sql5 = s == 1 ? "" : " and opid not in ( select top " + (s - 1).ToString() + " opid from basic_order_plan where " + sql2 + sql3 + sql4 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql5 + sql4;
            List<basic_order_plan> list = new List<basic_order_plan>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_order_plan Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion


        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameters(basic_order_plan basic_order_planExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();
            if (basic_order_planExample.opday1 != 0)
            {
                list_param.Add(new SqlParameter("@opday1", basic_order_planExample.opday1));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday1", DBNull.Value));
            }
            if (basic_order_planExample.opday2 != 0)
            {
                list_param.Add(new SqlParameter("@opday2", basic_order_planExample.opday2));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday2", DBNull.Value));
            }
            if (basic_order_planExample.opday3 != 0)
            {
                list_param.Add(new SqlParameter("@opday3", basic_order_planExample.opday3));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday3", DBNull.Value));
            }
            if (basic_order_planExample.opday4 != 0)
            {
                list_param.Add(new SqlParameter("@opday4", basic_order_planExample.opday4));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday4", DBNull.Value));
            }
            if (basic_order_planExample.opday5 != 0)
            {
                list_param.Add(new SqlParameter("@opday5", basic_order_planExample.opday5));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday5", DBNull.Value));
            }
            if (basic_order_planExample.opday6 != 0)
            {
                list_param.Add(new SqlParameter("@opday6", basic_order_planExample.opday6));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday6", DBNull.Value));
            }
            if (basic_order_planExample.opday7 != 0)
            {
                list_param.Add(new SqlParameter("@opday7", basic_order_planExample.opday7));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday7", DBNull.Value));
            }
            if (basic_order_planExample.opday8 != 0)
            {
                list_param.Add(new SqlParameter("@opday8", basic_order_planExample.opday8));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday8", DBNull.Value));
            }
            if (basic_order_planExample.opday9 != 0)
            {
                list_param.Add(new SqlParameter("@opday9", basic_order_planExample.opday9));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday9", DBNull.Value));
            }
            if (basic_order_planExample.opday10 != 0)
            {
                list_param.Add(new SqlParameter("@opday10", basic_order_planExample.opday10));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday10", DBNull.Value));
            }
            if (basic_order_planExample.opday11 != 0)
            {
                list_param.Add(new SqlParameter("@opday11", basic_order_planExample.opday11));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday11", DBNull.Value));
            }
            if (basic_order_planExample.opday12 != 0)
            {
                list_param.Add(new SqlParameter("@opday12", basic_order_planExample.opday12));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday12", DBNull.Value));
            }
            if (basic_order_planExample.opday13 != 0)
            {
                list_param.Add(new SqlParameter("@opday13", basic_order_planExample.opday13));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday13", DBNull.Value));
            }
            if (basic_order_planExample.opday14 != 0)
            {
                list_param.Add(new SqlParameter("@opday14", basic_order_planExample.opday14));
            }
            else
            {
                list_param.Add(new SqlParameter("@opday14", DBNull.Value));
            }
            if (basic_order_planExample.opnum != 0)
            {
                list_param.Add(new SqlParameter("@opnum", basic_order_planExample.opnum));
            }
            else
            {
                list_param.Add(new SqlParameter("@opnum", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_planExample.optype))
            {
                list_param.Add(new SqlParameter("@optype", basic_order_planExample.optype));
            }
            else
            {
                list_param.Add(new SqlParameter("@optype", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_planExample.opremark))
            {
                list_param.Add(new SqlParameter("@opremark", basic_order_planExample.opremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@opremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_planExample.opname))
            {
                list_param.Add(new SqlParameter("@opname", basic_order_planExample.opname));
            }
            else
            {
                list_param.Add(new SqlParameter("@opname", DBNull.Value));
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
        /// <returns>basic_order_planExample</returns>
        public static basic_order_plan GetByReader(SqlDataReader Reader)
        {
            basic_order_plan basic_order_planExample = new basic_order_plan();
            basic_order_planExample.opid = Reader["opid"] == DBNull.Value ? 0 : (int)Reader["opid"];
            basic_order_planExample.opday1 = Reader["opday1"] == DBNull.Value ? 0 : (int)Reader["opday1"];
            basic_order_planExample.opday2 = Reader["opday2"] == DBNull.Value ? 0 : (int)Reader["opday2"];
            basic_order_planExample.opday3 = Reader["opday3"] == DBNull.Value ? 0 : (int)Reader["opday3"];
            basic_order_planExample.opday4 = Reader["opday4"] == DBNull.Value ? 0 : (int)Reader["opday4"];
            basic_order_planExample.opday5 = Reader["opday5"] == DBNull.Value ? 0 : (int)Reader["opday5"];
            basic_order_planExample.opday6 = Reader["opday6"] == DBNull.Value ? 0 : (int)Reader["opday6"];
            basic_order_planExample.opday7 = Reader["opday7"] == DBNull.Value ? 0 : (int)Reader["opday7"];
            basic_order_planExample.opday8 = Reader["opday8"] == DBNull.Value ? 0 : (int)Reader["opday8"];
            basic_order_planExample.opday9 = Reader["opday9"] == DBNull.Value ? 0 : (int)Reader["opday9"];
            basic_order_planExample.opday10 = Reader["opday10"] == DBNull.Value ? 0 : (int)Reader["opday10"];
            basic_order_planExample.opday11 = Reader["opday11"] == DBNull.Value ? 0 : (int)Reader["opday11"];
            basic_order_planExample.opday12 = Reader["opday12"] == DBNull.Value ? 0 : (int)Reader["opday12"];
            basic_order_planExample.opday13 = Reader["opday13"] == DBNull.Value ? 0 : (int)Reader["opday13"];
            basic_order_planExample.opday14 = Reader["opday14"] == DBNull.Value ? 0 : (int)Reader["opday14"];
            basic_order_planExample.opnum = Reader["opnum"] == DBNull.Value ? 0 : (int)Reader["opnum"];
            basic_order_planExample.optype = Reader["optype"] == DBNull.Value ? null : Reader["optype"].ToString();
            basic_order_planExample.opremark = Reader["opremark"] == DBNull.Value ? null : Reader["opremark"].ToString();
            basic_order_planExample.opname = Reader["opname"] == DBNull.Value ? null : Reader["opname"].ToString();
            return basic_order_planExample;
        }
        #endregion





        #endregion
    }






}

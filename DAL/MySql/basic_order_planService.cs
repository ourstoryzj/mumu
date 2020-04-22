using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.Mysql
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
            MySqlDataReader reader = DBHelper.ExecuteReader();
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
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@opid",opid)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
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
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@opid",opid)
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
            string sql1 = "select  *   from basic_order_plan where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( opremark like '%" + key + "%' or   opname like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and optype= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(orderby) ? " order by opid desc " : " order by " + orderby;
            string sql10 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4+ sql10 ;
            List<basic_order_plan> list = new List<basic_order_plan>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
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
        /// 根据表,获取一个MySqlParameter数组
        /// </summary>
        /// <returns>MySqlParameter[]</returns>
        public static MySqlParameter[] GetSqlParameters(basic_order_plan basic_order_planExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();
            if (basic_order_planExample.opday1 != 0)
            {
                list_param.Add(new MySqlParameter("@opday1", basic_order_planExample.opday1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday1", DBNull.Value));
            }
            if (basic_order_planExample.opday2 != 0)
            {
                list_param.Add(new MySqlParameter("@opday2", basic_order_planExample.opday2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday2", DBNull.Value));
            }
            if (basic_order_planExample.opday3 != 0)
            {
                list_param.Add(new MySqlParameter("@opday3", basic_order_planExample.opday3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday3", DBNull.Value));
            }
            if (basic_order_planExample.opday4 != 0)
            {
                list_param.Add(new MySqlParameter("@opday4", basic_order_planExample.opday4));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday4", DBNull.Value));
            }
            if (basic_order_planExample.opday5 != 0)
            {
                list_param.Add(new MySqlParameter("@opday5", basic_order_planExample.opday5));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday5", DBNull.Value));
            }
            if (basic_order_planExample.opday6 != 0)
            {
                list_param.Add(new MySqlParameter("@opday6", basic_order_planExample.opday6));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday6", DBNull.Value));
            }
            if (basic_order_planExample.opday7 != 0)
            {
                list_param.Add(new MySqlParameter("@opday7", basic_order_planExample.opday7));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday7", DBNull.Value));
            }
            if (basic_order_planExample.opday8 != 0)
            {
                list_param.Add(new MySqlParameter("@opday8", basic_order_planExample.opday8));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday8", DBNull.Value));
            }
            if (basic_order_planExample.opday9 != 0)
            {
                list_param.Add(new MySqlParameter("@opday9", basic_order_planExample.opday9));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday9", DBNull.Value));
            }
            if (basic_order_planExample.opday10 != 0)
            {
                list_param.Add(new MySqlParameter("@opday10", basic_order_planExample.opday10));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday10", DBNull.Value));
            }
            if (basic_order_planExample.opday11 != 0)
            {
                list_param.Add(new MySqlParameter("@opday11", basic_order_planExample.opday11));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday11", DBNull.Value));
            }
            if (basic_order_planExample.opday12 != 0)
            {
                list_param.Add(new MySqlParameter("@opday12", basic_order_planExample.opday12));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday12", DBNull.Value));
            }
            if (basic_order_planExample.opday13 != 0)
            {
                list_param.Add(new MySqlParameter("@opday13", basic_order_planExample.opday13));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday13", DBNull.Value));
            }
            if (basic_order_planExample.opday14 != 0)
            {
                list_param.Add(new MySqlParameter("@opday14", basic_order_planExample.opday14));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opday14", DBNull.Value));
            }
            if (basic_order_planExample.opnum != 0)
            {
                list_param.Add(new MySqlParameter("@opnum", basic_order_planExample.opnum));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opnum", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_planExample.optype))
            {
                list_param.Add(new MySqlParameter("@optype", basic_order_planExample.optype));
            }
            else
            {
                list_param.Add(new MySqlParameter("@optype", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_planExample.opremark))
            {
                list_param.Add(new MySqlParameter("@opremark", basic_order_planExample.opremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_planExample.opname))
            {
                list_param.Add(new MySqlParameter("@opname", basic_order_planExample.opname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@opname", DBNull.Value));
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
        /// <returns>basic_order_planExample</returns>
        public static basic_order_plan GetByReader(MySqlDataReader Reader)
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

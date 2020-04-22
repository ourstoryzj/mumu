using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.Mysql
{




    public class keys_tiaojianService : Ikeys_tiaojianService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<keys_tiaojian> SearchAll()
        {
            DBHelper.sqlstr = "select * from keys_tiaojian ";
            List<keys_tiaojian> list = new List<keys_tiaojian>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                keys_tiaojian Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据ktid,查询一条数据
        /// </summary>
        /// <param name="ktid"></param>
        /// <returns></returns>
        /*查看是否为视图*/

        public keys_tiaojian SearchByID(int ktid)
        {
            DBHelper.sqlstr = "select * from keys_tiaojian where ktid = @ktid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@ktid",ktid)
            };
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            keys_tiaojian Obj = null;
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
        /// <param name="keys_tiaojian">keys_tiaojian表实例</param>
        /// <returns>int</returns>
        public int Insert(keys_tiaojian keys_tiaojianExample)
        {
            DBHelper.sqlstr = "insert into  keys_tiaojian (klength1,klength2,kdianjilv1,kdianjilv2,kdianjishu1,kdianjishu2,kgoodsnum1,kgoodsnum2,krenqi1,krenqi2,kshangcheng1,kshangcheng2,kZTCprice1,kZTCprice2,kzhuanhualv1,kzhuanhualv2,kZTCzhanxian1,kZTCzhanxian2,kZTCdianjishu1,kZTCdianjishu2,kZTCdianjilv1,kZTCdianjilv2,kZTCzhuanhualv1,kZTCzhuanhualv2,kZTCjunjia1,kZTCjunjia2,kZTCjingzhengdu1,kZTCjingzhengdu2,kdate,kstate,klevel,kname,kremark1,kremark2,kremark3,kremark4)values(@klength1,@klength2,@kdianjilv1,@kdianjilv2,@kdianjishu1,@kdianjishu2,@kgoodsnum1,@kgoodsnum2,@krenqi1,@krenqi2,@kshangcheng1,@kshangcheng2,@kZTCprice1,@kZTCprice2,@kzhuanhualv1,@kzhuanhualv2,@kZTCzhanxian1,@kZTCzhanxian2,@kZTCdianjishu1,@kZTCdianjishu2,@kZTCdianjilv1,@kZTCdianjilv2,@kZTCzhuanhualv1,@kZTCzhuanhualv2,@kZTCjunjia1,@kZTCjunjia2,@kZTCjingzhengdu1,@kZTCjingzhengdu2,@kdate,@kstate,@klevel,@kname,@kremark1,@kremark2,@kremark3,@kremark4)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(keys_tiaojianExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="keys_tiaojian">keys_tiaojian表实例</param>
        /// <returns>int</returns>
        public int Update(keys_tiaojian keys_tiaojianExample)
        {
            DBHelper.sqlstr = "update keys_tiaojian set klength1=@klength1,klength2=@klength2,kdianjilv1=@kdianjilv1,kdianjilv2=@kdianjilv2,kdianjishu1=@kdianjishu1,kdianjishu2=@kdianjishu2,kgoodsnum1=@kgoodsnum1,kgoodsnum2=@kgoodsnum2,krenqi1=@krenqi1,krenqi2=@krenqi2,kshangcheng1=@kshangcheng1,kshangcheng2=@kshangcheng2,kZTCprice1=@kZTCprice1,kZTCprice2=@kZTCprice2,kzhuanhualv1=@kzhuanhualv1,kzhuanhualv2=@kzhuanhualv2,kZTCzhanxian1=@kZTCzhanxian1,kZTCzhanxian2=@kZTCzhanxian2,kZTCdianjishu1=@kZTCdianjishu1,kZTCdianjishu2=@kZTCdianjishu2,kZTCdianjilv1=@kZTCdianjilv1,kZTCdianjilv2=@kZTCdianjilv2,kZTCzhuanhualv1=@kZTCzhuanhualv1,kZTCzhuanhualv2=@kZTCzhuanhualv2,kZTCjunjia1=@kZTCjunjia1,kZTCjunjia2=@kZTCjunjia2,kZTCjingzhengdu1=@kZTCjingzhengdu1,kZTCjingzhengdu2=@kZTCjingzhengdu2,kdate=@kdate,kstate=@kstate,klevel=@klevel,kname=@kname,kremark1=@kremark1,kremark2=@kremark2,kremark3=@kremark3,kremark4=@kremark4 where ktid=" + keys_tiaojianExample.ktid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(keys_tiaojianExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ktid"></param>
        /// <returns>int</returns>
        public int Delete(int ktid)
        {
            DBHelper.sqlstr = "delete keys_tiaojian where ktid =@ktid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@ktid",ktid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询数据条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="id">int字段</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns>IList</returns>
        public int SearchNum(string key, string state, int id, string level, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(ktid) from keys_tiaojian where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( kstate like '%" + key + "%' or klevel like '%" + key + "%' or kname like '%" + key + "%' or kremark1 like '%" + key + "%' or kremark2 like '%" + key + "%' or kremark3 like '%" + key + "%' or kremark4 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and kstate= '" + state + "' ";//状态字段，无用删除
            string sql33 = string.IsNullOrEmpty(level) ? "" : " and klevel= '" + level + "' ";
            string sql4 = id == 0 ? "" : " and ktid='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',kdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',kdate)<=0 ";//时间字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql33 + sql4 + sql5 + sql6;
            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="id">int字段</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序</param>
        /// <returns>IList<keys_tiaojian></returns>
        public IList<keys_tiaojian> Search(int s, int e, string key, string state, int id, string level, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select * from keys_tiaojian where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( kstate like '%" + key + "%' or klevel like '%" + key + "%' or kname like '%" + key + "%' or kremark1 like '%" + key + "%' or kremark2 like '%" + key + "%' or kremark3 like '%" + key + "%' or kremark4 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and kstate= '" + state + "' ";//状态字段，无用删除
            string sql33 = string.IsNullOrEmpty(level) ? "" : " and klevel= '" + level + "' ";
            string sql4 = id == 0 ? "" : " and ktid='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',kdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',kdate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by ktid desc " : " order by " + orderby;
            //string sql8 = s == 1 ? "" : " and ktid not in ( select top " + (s - 1).ToString() + " ktidfrom keys_tiaojian where " + sql2 + sql3 + sql33 + sql4 + sql5 + sql6 + sql7 + " ) ";
            string sql9 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql33 + sql4 + sql5 + sql6  + sql7+ sql9;
            List<keys_tiaojian> list = new List<keys_tiaojian>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                keys_tiaojian Obj = GetByReader(reader);
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
        public static MySqlParameter[] GetSqlParameters(keys_tiaojian keys_tiaojianExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();
            if (keys_tiaojianExample.klength1 != 0)
            {
                list_param.Add(new MySqlParameter("@klength1", keys_tiaojianExample.klength1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klength1", DBNull.Value));
            }
            if (keys_tiaojianExample.klength2 != 0)
            {
                list_param.Add(new MySqlParameter("@klength2", keys_tiaojianExample.klength2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klength2", DBNull.Value));
            }
            if (keys_tiaojianExample.kdianjilv1 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kdianjilv1", keys_tiaojianExample.kdianjilv1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kdianjilv1", DBNull.Value));
            }
            if (keys_tiaojianExample.kdianjilv2 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kdianjilv2", keys_tiaojianExample.kdianjilv2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kdianjilv2", DBNull.Value));
            }
            if (keys_tiaojianExample.kdianjishu1 != 0)
            {
                list_param.Add(new MySqlParameter("@kdianjishu1", keys_tiaojianExample.kdianjishu1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kdianjishu1", DBNull.Value));
            }
            if (keys_tiaojianExample.kdianjishu2 != 0)
            {
                list_param.Add(new MySqlParameter("@kdianjishu2", keys_tiaojianExample.kdianjishu2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kdianjishu2", DBNull.Value));
            }
            if (keys_tiaojianExample.kgoodsnum1 != 0)
            {
                list_param.Add(new MySqlParameter("@kgoodsnum1", keys_tiaojianExample.kgoodsnum1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kgoodsnum1", DBNull.Value));
            }
            if (keys_tiaojianExample.kgoodsnum2 != 0)
            {
                list_param.Add(new MySqlParameter("@kgoodsnum2", keys_tiaojianExample.kgoodsnum2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kgoodsnum2", DBNull.Value));
            }
            if (keys_tiaojianExample.krenqi1 != 0)
            {
                list_param.Add(new MySqlParameter("@krenqi1", keys_tiaojianExample.krenqi1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@krenqi1", DBNull.Value));
            }
            if (keys_tiaojianExample.krenqi2 != 0)
            {
                list_param.Add(new MySqlParameter("@krenqi2", keys_tiaojianExample.krenqi2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@krenqi2", DBNull.Value));
            }
            if (keys_tiaojianExample.kshangcheng1 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kshangcheng1", keys_tiaojianExample.kshangcheng1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kshangcheng1", DBNull.Value));
            }
            if (keys_tiaojianExample.kshangcheng2 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kshangcheng2", keys_tiaojianExample.kshangcheng2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kshangcheng2", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCprice1 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCprice1", keys_tiaojianExample.kZTCprice1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCprice1", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCprice2 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCprice2", keys_tiaojianExample.kZTCprice2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCprice2", DBNull.Value));
            }
            if (keys_tiaojianExample.kzhuanhualv1 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kzhuanhualv1", keys_tiaojianExample.kzhuanhualv1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kzhuanhualv1", DBNull.Value));
            }
            if (keys_tiaojianExample.kzhuanhualv2 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kzhuanhualv2", keys_tiaojianExample.kzhuanhualv2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kzhuanhualv2", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCzhanxian1 != 0)
            {
                list_param.Add(new MySqlParameter("@kZTCzhanxian1", keys_tiaojianExample.kZTCzhanxian1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCzhanxian1", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCzhanxian2 != 0)
            {
                list_param.Add(new MySqlParameter("@kZTCzhanxian2", keys_tiaojianExample.kZTCzhanxian2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCzhanxian2", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCdianjishu1 != 0)
            {
                list_param.Add(new MySqlParameter("@kZTCdianjishu1", keys_tiaojianExample.kZTCdianjishu1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCdianjishu1", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCdianjishu2 != 0)
            {
                list_param.Add(new MySqlParameter("@kZTCdianjishu2", keys_tiaojianExample.kZTCdianjishu2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCdianjishu2", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCdianjilv1 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCdianjilv1", keys_tiaojianExample.kZTCdianjilv1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCdianjilv1", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCdianjilv2 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCdianjilv2", keys_tiaojianExample.kZTCdianjilv2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCdianjilv2", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCzhuanhualv1 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCzhuanhualv1", keys_tiaojianExample.kZTCzhuanhualv1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCzhuanhualv1", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCzhuanhualv2 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCzhuanhualv2", keys_tiaojianExample.kZTCzhuanhualv2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCzhuanhualv2", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCjunjia1 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCjunjia1", keys_tiaojianExample.kZTCjunjia1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCjunjia1", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCjunjia2 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCjunjia2", keys_tiaojianExample.kZTCjunjia2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCjunjia2", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCjingzhengdu1 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCjingzhengdu1", keys_tiaojianExample.kZTCjingzhengdu1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCjingzhengdu1", DBNull.Value));
            }
            if (keys_tiaojianExample.kZTCjingzhengdu2 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCjingzhengdu2", keys_tiaojianExample.kZTCjingzhengdu2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCjingzhengdu2", DBNull.Value));
            }
            if (keys_tiaojianExample.kdate != new DateTime() && keys_tiaojianExample.kdate != null)
            {
                list_param.Add(new MySqlParameter("@kdate", keys_tiaojianExample.kdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_tiaojianExample.kstate))
            {
                list_param.Add(new MySqlParameter("@kstate", keys_tiaojianExample.kstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_tiaojianExample.klevel))
            {
                list_param.Add(new MySqlParameter("@klevel", keys_tiaojianExample.klevel));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klevel", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_tiaojianExample.kname))
            {
                list_param.Add(new MySqlParameter("@kname", keys_tiaojianExample.kname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_tiaojianExample.kremark1))
            {
                list_param.Add(new MySqlParameter("@kremark1", keys_tiaojianExample.kremark1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_tiaojianExample.kremark2))
            {
                list_param.Add(new MySqlParameter("@kremark2", keys_tiaojianExample.kremark2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_tiaojianExample.kremark3))
            {
                list_param.Add(new MySqlParameter("@kremark3", keys_tiaojianExample.kremark3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keys_tiaojianExample.kremark4))
            {
                list_param.Add(new MySqlParameter("@kremark4", keys_tiaojianExample.kremark4));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark4", DBNull.Value));
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
        /// <returns>keys_tiaojianExample</returns>
        public static keys_tiaojian GetByReader(MySqlDataReader Reader)
        {
            keys_tiaojian keys_tiaojianExample = new keys_tiaojian();
            keys_tiaojianExample.ktid = Reader["ktid"] == DBNull.Value ? 0 : (int)Reader["ktid"];
            keys_tiaojianExample.klength1 = Reader["klength1"] == DBNull.Value ? 0 : (int)Reader["klength1"];
            keys_tiaojianExample.klength2 = Reader["klength2"] == DBNull.Value ? 0 : (int)Reader["klength2"];
            keys_tiaojianExample.kdianjilv1 = Reader["kdianjilv1"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kdianjilv1"]);
            keys_tiaojianExample.kdianjilv2 = Reader["kdianjilv2"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kdianjilv2"]);
            keys_tiaojianExample.kdianjishu1 = Reader["kdianjishu1"] == DBNull.Value ? 0 : (int)Reader["kdianjishu1"];
            keys_tiaojianExample.kdianjishu2 = Reader["kdianjishu2"] == DBNull.Value ? 0 : (int)Reader["kdianjishu2"];
            keys_tiaojianExample.kgoodsnum1 = Reader["kgoodsnum1"] == DBNull.Value ? 0 : (int)Reader["kgoodsnum1"];
            keys_tiaojianExample.kgoodsnum2 = Reader["kgoodsnum2"] == DBNull.Value ? 0 : (int)Reader["kgoodsnum2"];
            keys_tiaojianExample.krenqi1 = Reader["krenqi1"] == DBNull.Value ? 0 : (int)Reader["krenqi1"];
            keys_tiaojianExample.krenqi2 = Reader["krenqi2"] == DBNull.Value ? 0 : (int)Reader["krenqi2"];
            keys_tiaojianExample.kshangcheng1 = Reader["kshangcheng1"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kshangcheng1"]);
            keys_tiaojianExample.kshangcheng2 = Reader["kshangcheng2"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kshangcheng2"]);
            keys_tiaojianExample.kZTCprice1 = Reader["kZTCprice1"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCprice1"]);
            keys_tiaojianExample.kZTCprice2 = Reader["kZTCprice2"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCprice2"]);
            keys_tiaojianExample.kzhuanhualv1 = Reader["kzhuanhualv1"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kzhuanhualv1"]);
            keys_tiaojianExample.kzhuanhualv2 = Reader["kzhuanhualv2"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kzhuanhualv2"]);
            keys_tiaojianExample.kZTCzhanxian1 = Reader["kZTCzhanxian1"] == DBNull.Value ? 0 : (int)Reader["kZTCzhanxian1"];
            keys_tiaojianExample.kZTCzhanxian2 = Reader["kZTCzhanxian2"] == DBNull.Value ? 0 : (int)Reader["kZTCzhanxian2"];
            keys_tiaojianExample.kZTCdianjishu1 = Reader["kZTCdianjishu1"] == DBNull.Value ? 0 : (int)Reader["kZTCdianjishu1"];
            keys_tiaojianExample.kZTCdianjishu2 = Reader["kZTCdianjishu2"] == DBNull.Value ? 0 : (int)Reader["kZTCdianjishu2"];
            keys_tiaojianExample.kZTCdianjilv1 = Reader["kZTCdianjilv1"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCdianjilv1"]);
            keys_tiaojianExample.kZTCdianjilv2 = Reader["kZTCdianjilv2"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCdianjilv2"]);
            keys_tiaojianExample.kZTCzhuanhualv1 = Reader["kZTCzhuanhualv1"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCzhuanhualv1"]);
            keys_tiaojianExample.kZTCzhuanhualv2 = Reader["kZTCzhuanhualv2"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCzhuanhualv2"]);
            keys_tiaojianExample.kZTCjunjia1 = Reader["kZTCjunjia1"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCjunjia1"]);
            keys_tiaojianExample.kZTCjunjia2 = Reader["kZTCjunjia2"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCjunjia2"]);
            keys_tiaojianExample.kZTCjingzhengdu1 = Reader["kZTCjingzhengdu1"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCjingzhengdu1"]);
            keys_tiaojianExample.kZTCjingzhengdu2 = Reader["kZTCjingzhengdu2"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCjingzhengdu2"]);
            keys_tiaojianExample.kdate = Reader["kdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["kdate"]);
            keys_tiaojianExample.kstate = Reader["kstate"] == DBNull.Value ? null : Reader["kstate"].ToString();
            keys_tiaojianExample.klevel = Reader["klevel"] == DBNull.Value ? null : Reader["klevel"].ToString();
            keys_tiaojianExample.kname = Reader["kname"] == DBNull.Value ? null : Reader["kname"].ToString();
            keys_tiaojianExample.kremark1 = Reader["kremark1"] == DBNull.Value ? null : Reader["kremark1"].ToString();
            keys_tiaojianExample.kremark2 = Reader["kremark2"] == DBNull.Value ? null : Reader["kremark2"].ToString();
            keys_tiaojianExample.kremark3 = Reader["kremark3"] == DBNull.Value ? null : Reader["kremark3"].ToString();
            keys_tiaojianExample.kremark4 = Reader["kremark4"] == DBNull.Value ? null : Reader["kremark4"].ToString();
            return keys_tiaojianExample;
        }
        #endregion





        #endregion
    }








}

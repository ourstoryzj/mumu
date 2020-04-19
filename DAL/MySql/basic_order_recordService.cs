using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql
{




    //表名称：yh_zaoci
    //实体类名称：yh_zaociExample
    //主键：zid
    public class basic_order_recordService : Ibasic_order_recordService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<basic_order_record> SearchAll()
        {
            DBHelper.sqlstr = "select * from basic_order_record ";
            List<basic_order_record> list = new List<basic_order_record>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_order_record Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据orid,查询一条数据
        /// </summary>
        /// <param name="orid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public basic_order_record SearchByID(int orid)
        {
            DBHelper.sqlstr = "select * from basic_order_record where orid = @orid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@orid",orid)
            };
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            basic_order_record Obj = null;
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
        /// <param name="basic_order_record">basic_order_record表实例</param>
        /// <returns>int</returns>
        public int Insert(basic_order_record basic_order_recordExample)
        {
            DBHelper.sqlstr = "insert into  basic_order_record (bgid,bgname,dpid,dpname,gkid,gkname,ormaijiaxiu,ordate,orremark,orqq,orprepare1,orprepare2,orprepare3,orwangwang,orprice,orcode,bgurl,bgwuliu)values(@bgid,@bgname,@dpid,@dpname,@gkid,@gkname,@ormaijiaxiu,@ordate,@orremark,@orqq,@orprepare1,@orprepare2,@orprepare3,@orwangwang,@orprice,@orcode,@bgurl,@bgwuliu)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_order_recordExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_order_record">basic_order_record表实例</param>
        /// <returns>int</returns>
        public int Update(basic_order_record basic_order_recordExample)
        {
            DBHelper.sqlstr = "update basic_order_record set bgid=@bgid,bgname=@bgname,dpid=@dpid,dpname=@dpname,gkid=@gkid,gkname=@gkname,ormaijiaxiu=@ormaijiaxiu,ordate=@ordate,orremark=@orremark,orqq=@orqq,orprepare1=@orprepare1,orprepare2=@orprepare2,orprepare3=@orprepare3,orwangwang=@orwangwang,orprice=@orprice,orcode=@orcode,bgurl=@bgurl,bgwuliu=@bgwuliu where orid=" + basic_order_recordExample.orid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_order_recordExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="orid">编号</param>
        /// <returns>int</returns>
        public int Delete(int orid)
        {
            DBHelper.sqlstr = "delete basic_order_record where orid =@orid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@orid",orid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="bgid">商品编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="gkid">关键词编号</param>
        /// <param name="ormaijiaxiu">状态</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <returns></returns>
        public int SearchNum(string key, int bgid, int dpid, int gkid, string ormaijiaxiu, string state, DateTime dt1_add, DateTime dt2_add)
        {
            string sql1 = "select count(orid) from basic_order_record where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  bgname like '%" + key + "%' or  dpname like '%" + key + "%' or  gkname like '%" + key + "%' or  orremark like '%" + key + "%'  or  orqq like '%" + key + "%'     or  orprepare2 like '%" + key + "%'  or  orprepare3 like '%" + key + "%'  or  orwangwang like '%" + key + "%'  or  orprice like '%" + key + "%'  or  bgurl like '%" + key + "%'  or  bgwuliu like '%" + key + "%'    ) ";
            string sql3 = bgid == 0 ? "" : " and bgid=" + bgid.ToString();
            string sql4 = dpid == 0 ? "" : " and dpid=" + dpid.ToString();
            string sql5 = gkid == 0 ? "" : " and gkid=" + dpid.ToString();
            string sql6 = string.IsNullOrEmpty(ormaijiaxiu) ? "" : " and ormaijiaxiu= '" + ormaijiaxiu + "' ";
            string sql11 = string.IsNullOrEmpty(state) ? "" : " and orprepare1= '" + state + "' ";
            string sql7 = dt1_add == new DateTime() ? "" : " and datediff(day,'" + dt1_add.ToString("yyyy/MM/dd") + "',ordate)>=0 ";
            string sql8 = dt2_add == new DateTime() ? "" : " and datediff(day,'" + dt2_add.ToString("yyyy/MM/dd") + "',ordate)<=0 ";

            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql11 + sql7 + sql8;

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
        /// <param name="bgid">商品编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="gkid">关键词编号</param>
        /// <param name="ormaijiaxiu">状态</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_order_record></returns>
        public IList<basic_order_record> Search(int s, int e, string key, int bgid, int dpid, int gkid, string ormaijiaxiu, string state, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            string sql1 = "select  *   from basic_order_record where ";

            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  bgname like '%" + key + "%' or  dpname like '%" + key + "%' or  gkname like '%" + key + "%' or  orremark like '%" + key + "%'  or  orqq like '%" + key + "%'     or  orprepare2 like '%" + key + "%'  or  orprepare3 like '%" + key + "%'  or  orwangwang like '%" + key + "%'  or  orprice like '%" + key + "%'  or  bgurl like '%" + key + "%'  or  bgwuliu like '%" + key + "%'    ) ";
            string sql3 = bgid == 0 ? "" : " and bgid=" + bgid.ToString();
            string sql4 = dpid == 0 ? "" : " and dpid=" + dpid.ToString();
            string sql5 = gkid == 0 ? "" : " and gkid=" + dpid.ToString();
            string sql6 = string.IsNullOrEmpty(ormaijiaxiu) ? "" : " and ormaijiaxiu= '" + ormaijiaxiu + "' ";
            string sql11 = string.IsNullOrEmpty(state) ? "" : " and orprepare1= '" + state + "' ";
            string sql7 = dt1_add == new DateTime() ? "" : " and datediff(day,'" + dt1_add.ToString("yyyy/MM/dd") + "',ordate)>=0 ";
            string sql8 = dt2_add == new DateTime() ? "" : " and datediff(day,'" + dt2_add.ToString("yyyy/MM/dd") + "',ordate)<=0 ";

            string sql9 = string.IsNullOrEmpty(orderby) ? " order by ordate desc " : " order by " + orderby;
            //string sql10 = s == 1 ? "" : " and orid not in ( select top " + (s - 1).ToString() + " orid from basic_order_record where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql11 + sql8 + sql7 + sql9 + " ) ";
            string sql10 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql11 + sql7 + sql8 + sql9+ sql10 ;
            List<basic_order_record> list = new List<basic_order_record>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_order_record Obj = GetByReader(reader);
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
        public static MySqlParameter[] GetSqlParameters(basic_order_record basic_order_recordExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();
            if (basic_order_recordExample.bgid != 0)
            {
                list_param.Add(new MySqlParameter("@bgid", basic_order_recordExample.bgid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@bgid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.bgname))
            {
                list_param.Add(new MySqlParameter("@bgname", basic_order_recordExample.bgname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@bgname", DBNull.Value));
            }
            if (basic_order_recordExample.dpid != 0)
            {
                list_param.Add(new MySqlParameter("@dpid", basic_order_recordExample.dpid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.dpname))
            {
                list_param.Add(new MySqlParameter("@dpname", basic_order_recordExample.dpname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@dpname", DBNull.Value));
            }
            if (basic_order_recordExample.gkid != 0)
            {
                list_param.Add(new MySqlParameter("@gkid", basic_order_recordExample.gkid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gkid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.gkname))
            {
                list_param.Add(new MySqlParameter("@gkname", basic_order_recordExample.gkname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gkname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.ormaijiaxiu))
            {
                list_param.Add(new MySqlParameter("@ormaijiaxiu", basic_order_recordExample.ormaijiaxiu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@ormaijiaxiu", DBNull.Value));
            }
            if (basic_order_recordExample.ordate != new DateTime() && basic_order_recordExample.ordate != null)
            {
                list_param.Add(new MySqlParameter("@ordate", basic_order_recordExample.ordate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@ordate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.orremark))
            {
                list_param.Add(new MySqlParameter("@orremark", basic_order_recordExample.orremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@orremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.orqq))
            {
                list_param.Add(new MySqlParameter("@orqq", basic_order_recordExample.orqq));
            }
            else
            {
                list_param.Add(new MySqlParameter("@orqq", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.orprepare1))
            {
                list_param.Add(new MySqlParameter("@orprepare1", basic_order_recordExample.orprepare1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@orprepare1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.orprepare2))
            {
                list_param.Add(new MySqlParameter("@orprepare2", basic_order_recordExample.orprepare2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@orprepare2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.orprepare3))
            {
                list_param.Add(new MySqlParameter("@orprepare3", basic_order_recordExample.orprepare3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@orprepare3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.orwangwang))
            {
                list_param.Add(new MySqlParameter("@orwangwang", basic_order_recordExample.orwangwang));
            }
            else
            {
                list_param.Add(new MySqlParameter("@orwangwang", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.orprice))
            {
                list_param.Add(new MySqlParameter("@orprice", basic_order_recordExample.orprice));
            }
            else
            {
                list_param.Add(new MySqlParameter("@orprice", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.orcode))
            {
                list_param.Add(new MySqlParameter("@orcode", basic_order_recordExample.orcode));
            }
            else
            {
                list_param.Add(new MySqlParameter("@orcode", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.bgurl))
            {
                list_param.Add(new MySqlParameter("@bgurl", basic_order_recordExample.bgurl));
            }
            else
            {
                list_param.Add(new MySqlParameter("@bgurl", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_order_recordExample.bgwuliu))
            {
                list_param.Add(new MySqlParameter("@bgwuliu", basic_order_recordExample.bgwuliu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@bgwuliu", DBNull.Value));
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
        /// <returns>basic_order_recordExample</returns>
        public static basic_order_record GetByReader(MySqlDataReader Reader)
        {
            basic_order_record basic_order_recordExample = new basic_order_record();
            basic_order_recordExample.orid = Reader["orid"] == DBNull.Value ? 0 : (int)Reader["orid"];
            basic_order_recordExample.bgid = Reader["bgid"] == DBNull.Value ? 0 : (int)Reader["bgid"];
            basic_order_recordExample.bgname = Reader["bgname"] == DBNull.Value ? null : Reader["bgname"].ToString();
            basic_order_recordExample.dpid = Reader["dpid"] == DBNull.Value ? 0 : (int)Reader["dpid"];
            basic_order_recordExample.dpname = Reader["dpname"] == DBNull.Value ? null : Reader["dpname"].ToString();
            basic_order_recordExample.gkid = Reader["gkid"] == DBNull.Value ? 0 : (int)Reader["gkid"];
            basic_order_recordExample.gkname = Reader["gkname"] == DBNull.Value ? null : Reader["gkname"].ToString();
            basic_order_recordExample.ormaijiaxiu = Reader["ormaijiaxiu"] == DBNull.Value ? null : Reader["ormaijiaxiu"].ToString();
            basic_order_recordExample.ordate = Reader["ordate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["ordate"]);
            basic_order_recordExample.orremark = Reader["orremark"] == DBNull.Value ? null : Reader["orremark"].ToString();
            basic_order_recordExample.orqq = Reader["orqq"] == DBNull.Value ? null : Reader["orqq"].ToString();
            basic_order_recordExample.orprepare1 = Reader["orprepare1"] == DBNull.Value ? null : Reader["orprepare1"].ToString();
            basic_order_recordExample.orprepare2 = Reader["orprepare2"] == DBNull.Value ? null : Reader["orprepare2"].ToString();
            basic_order_recordExample.orprepare3 = Reader["orprepare3"] == DBNull.Value ? null : Reader["orprepare3"].ToString();
            basic_order_recordExample.orwangwang = Reader["orwangwang"] == DBNull.Value ? null : Reader["orwangwang"].ToString();
            basic_order_recordExample.orprice = Reader["orprice"] == DBNull.Value ? null : Reader["orprice"].ToString();
            basic_order_recordExample.orcode = Reader["orcode"] == DBNull.Value ? null : Reader["orcode"].ToString();
            basic_order_recordExample.bgurl = Reader["bgurl"] == DBNull.Value ? null : Reader["bgurl"].ToString();
            basic_order_recordExample.bgwuliu = Reader["bgwuliu"] == DBNull.Value ? null : Reader["bgwuliu"].ToString();
            return basic_order_recordExample;
        }
        #endregion





        #endregion
    }






}

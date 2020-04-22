using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.Mysql
{



    public class wanggong_goodsService : Iwanggong_goodsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<wanggong_goods> SearchAll()
        {
            DBHelper.sqlstr = "select * from wanggong_goods ";
            List<wanggong_goods> list = new List<wanggong_goods>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                wanggong_goods Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据wgid,查询一条数据
        /// </summary>
        /// <param name="wgid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public wanggong_goods SearchByID(int wgid)
        {
            DBHelper.sqlstr = "select * from wanggong_goods where wgid = @wgid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@wgid",wgid)
            };
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            wanggong_goods Obj = null;
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
        /// <param name="wanggong_goods">wanggong_goods表实例</param>
        /// <returns>int</returns>
        public int Insert(wanggong_goods wanggong_goodsExample)
        {
            DBHelper.sqlstr = "insert into  wanggong_goods (wid,wgcollectdate,wgTBid,wgurl,wgtittle,wgprice1,wgprice2,wgimg,wgxiaoliang,wgUPdate,wgDowndate,wgremark,wgremark1,wgremark2,wgremark3)values(@wid,@wgcollectdate,@wgTBid,@wgurl,@wgtittle,@wgprice1,@wgprice2,@wgimg,@wgxiaoliang,@wgUPdate,@wgDowndate,@wgremark,@wgremark1,@wgremark2,@wgremark3)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(wanggong_goodsExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="wanggong_goods">wanggong_goods表实例</param>
        /// <returns>int</returns>
        public int Update(wanggong_goods wanggong_goodsExample)
        {
            DBHelper.sqlstr = "update wanggong_goods set wid=@wid,wgcollectdate=@wgcollectdate,wgTBid=@wgTBid,wgurl=@wgurl,wgtittle=@wgtittle,wgprice1=@wgprice1,wgprice2=@wgprice2,wgimg=@wgimg,wgxiaoliang=@wgxiaoliang,wgUPdate=@wgUPdate,wgDowndate=@wgDowndate,wgremark=@wgremark,wgremark1=@wgremark1,wgremark2=@wgremark2,wgremark3=@wgremark3 where wgid=" + wanggong_goodsExample.wgid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(wanggong_goodsExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="wgid">编号</param>
        /// <returns>int</returns>
        public int Delete(int wgid)
        {
            DBHelper.sqlstr = "delete wanggong_goods where wgid =@wgid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@wgid",wgid)
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
        public int SearchNum(string key, int wid, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(wgid) from wanggong_goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( wgTBid like '%" + key + "%' or wgurl like '%" + key + "%' or wgtittle like '%" + key + "%' or wgprice1 like '%" + key + "%' or wgprice2 like '%" + key + "%' or wgimg like '%" + key + "%' or wgxiaoliang like '%" + key + "%' or wgUPdate like '%" + key + "%' or wgDowndate like '%" + key + "%' or wgremark like '%" + key + "%' or wgremark1 like '%" + key + "%' or wgremark2 like '%" + key + "%' or wgremark3 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = wid == 0 ? "" : " and wid=" + wid.ToString() + " ";
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',wgcollectdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',wgcollectdate)<=0 ";//时间字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql5 + sql6;
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
        /// <returns>IList<wanggong_goods></returns>
        public IList<wanggong_goods> Search(int s, int e, string key, int wid, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select * from wanggong_goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( wgTBid like '%" + key + "%' or wgurl like '%" + key + "%' or wgtittle like '%" + key + "%' or wgprice1 like '%" + key + "%' or wgprice2 like '%" + key + "%' or wgimg like '%" + key + "%' or wgxiaoliang like '%" + key + "%' or wgUPdate like '%" + key + "%' or wgDowndate like '%" + key + "%' or wgremark like '%" + key + "%' or wgremark1 like '%" + key + "%' or wgremark2 like '%" + key + "%' or wgremark3 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = wid == 0 ? "" : " and wid=" + wid.ToString() + " ";
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',wgcollectdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',wgcollectdate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by wgcollectdate desc " : " order by " + orderby;
            //ring sql8 = s == 1 ? "" : " and wgid not in ( select top " + (s - 1).ToString() + " wgid from wanggong_goods where " + sql2 + sql3 + sql5 + sql6 + sql7 + " ) ";
            string sql10 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql5 + sql6 + sql7+ sql10 ;
            List<wanggong_goods> list = new List<wanggong_goods>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                wanggong_goods Obj = GetByReader(reader);
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
        public static MySqlParameter[] GetSqlParameters(wanggong_goods wanggong_goodsExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();
            if (wanggong_goodsExample.wid != 0)
            {
                list_param.Add(new MySqlParameter("@wid", wanggong_goodsExample.wid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wid", DBNull.Value));
            }
            if (wanggong_goodsExample.wgcollectdate != new DateTime() && wanggong_goodsExample.wgcollectdate != null)
            {
                list_param.Add(new MySqlParameter("@wgcollectdate", wanggong_goodsExample.wgcollectdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgcollectdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgTBid))
            {
                list_param.Add(new MySqlParameter("@wgTBid", wanggong_goodsExample.wgTBid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgTBid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgurl))
            {
                list_param.Add(new MySqlParameter("@wgurl", wanggong_goodsExample.wgurl));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgurl", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgtittle))
            {
                list_param.Add(new MySqlParameter("@wgtittle", wanggong_goodsExample.wgtittle));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgtittle", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgprice1))
            {
                list_param.Add(new MySqlParameter("@wgprice1", wanggong_goodsExample.wgprice1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgprice1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgprice2))
            {
                list_param.Add(new MySqlParameter("@wgprice2", wanggong_goodsExample.wgprice2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgprice2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgimg))
            {
                list_param.Add(new MySqlParameter("@wgimg", wanggong_goodsExample.wgimg));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgimg", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgxiaoliang))
            {
                list_param.Add(new MySqlParameter("@wgxiaoliang", wanggong_goodsExample.wgxiaoliang));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgxiaoliang", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgUPdate))
            {
                list_param.Add(new MySqlParameter("@wgUPdate", wanggong_goodsExample.wgUPdate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgUPdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgDowndate))
            {
                list_param.Add(new MySqlParameter("@wgDowndate", wanggong_goodsExample.wgDowndate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgDowndate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgremark))
            {
                list_param.Add(new MySqlParameter("@wgremark", wanggong_goodsExample.wgremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgremark1))
            {
                list_param.Add(new MySqlParameter("@wgremark1", wanggong_goodsExample.wgremark1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgremark2))
            {
                list_param.Add(new MySqlParameter("@wgremark2", wanggong_goodsExample.wgremark2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(wanggong_goodsExample.wgremark3))
            {
                list_param.Add(new MySqlParameter("@wgremark3", wanggong_goodsExample.wgremark3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@wgremark3", DBNull.Value));
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
        /// <returns>wanggong_goodsExample</returns>
        public static wanggong_goods GetByReader(MySqlDataReader Reader)
        {
            wanggong_goods wanggong_goodsExample = new wanggong_goods();
            wanggong_goodsExample.wgid = Reader["wgid"] == DBNull.Value ? 0 : (int)Reader["wgid"];
            wanggong_goodsExample.wid = Reader["wid"] == DBNull.Value ? 0 : (int)Reader["wid"];
            wanggong_goodsExample.wgcollectdate = Reader["wgcollectdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["wgcollectdate"]);
            wanggong_goodsExample.wgTBid = Reader["wgTBid"] == DBNull.Value ? null : Reader["wgTBid"].ToString();
            wanggong_goodsExample.wgurl = Reader["wgurl"] == DBNull.Value ? null : Reader["wgurl"].ToString();
            wanggong_goodsExample.wgtittle = Reader["wgtittle"] == DBNull.Value ? null : Reader["wgtittle"].ToString();
            wanggong_goodsExample.wgprice1 = Reader["wgprice1"] == DBNull.Value ? null : Reader["wgprice1"].ToString();
            wanggong_goodsExample.wgprice2 = Reader["wgprice2"] == DBNull.Value ? null : Reader["wgprice2"].ToString();
            wanggong_goodsExample.wgimg = Reader["wgimg"] == DBNull.Value ? null : Reader["wgimg"].ToString();
            wanggong_goodsExample.wgxiaoliang = Reader["wgxiaoliang"] == DBNull.Value ? null : Reader["wgxiaoliang"].ToString();
            wanggong_goodsExample.wgUPdate = Reader["wgUPdate"] == DBNull.Value ? null : Reader["wgUPdate"].ToString();
            wanggong_goodsExample.wgDowndate = Reader["wgDowndate"] == DBNull.Value ? null : Reader["wgDowndate"].ToString();
            wanggong_goodsExample.wgremark = Reader["wgremark"] == DBNull.Value ? null : Reader["wgremark"].ToString();
            wanggong_goodsExample.wgremark1 = Reader["wgremark1"] == DBNull.Value ? null : Reader["wgremark1"].ToString();
            wanggong_goodsExample.wgremark2 = Reader["wgremark2"] == DBNull.Value ? null : Reader["wgremark2"].ToString();
            wanggong_goodsExample.wgremark3 = Reader["wgremark3"] == DBNull.Value ? null : Reader["wgremark3"].ToString();
            return wanggong_goodsExample;
        }
        #endregion





        #endregion
    }








}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{


    public class opponent_goodsService : Iopponent_goodsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<opponent_goods> SearchAll()
        {
            DBHelper.sqlstr = "select * from opponent_goods ";
            List<opponent_goods> list = new List<opponent_goods>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                opponent_goods Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据ogid,查询一条数据
        /// </summary>
        /// <param name="ogid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public opponent_goods SearchByID(int ogid)
        {
            DBHelper.sqlstr = "select * from opponent_goods where ogid = @ogid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ogid",ogid)
			};
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            opponent_goods Obj = null;
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
        /// <param name="opponent_goods">opponent_goods表实例</param>
        /// <returns>int</returns>
        public int Insert(opponent_goods opponent_goodsExample)
        {
            DBHelper.sqlstr = "insert into  opponent_goods (odpid,ocollectdate,ogurl,ogtittle,ogprice1,ogprice2,ogdiscount,ogimg,ogsales,ogpostage,ogSKU,ogUPdate,ogDowndate,ogTBid,ogxiaoliang,ogshoucang,ogremark,ogremark1,oshopid,ogremark2,ogremark3,ogremark4,ogremark5)values(@odpid,@ocollectdate,@ogurl,@ogtittle,@ogprice1,@ogprice2,@ogdiscount,@ogimg,@ogsales,@ogpostage,@ogSKU,@ogUPdate,@ogDowndate,@ogTBid,@ogxiaoliang,@ogshoucang,@ogremark,@ogremark1,@oshopid,@ogremark2,@ogremark3,@ogremark4,@ogremark5)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(opponent_goodsExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="opponent_goods">opponent_goods表实例</param>
        /// <returns>int</returns>
        public int Update(opponent_goods opponent_goodsExample)
        {
            DBHelper.sqlstr = "update opponent_goods set odpid=@odpid,ocollectdate=@ocollectdate,ogurl=@ogurl,ogtittle=@ogtittle,ogprice1=@ogprice1,ogprice2=@ogprice2,ogdiscount=@ogdiscount,ogimg=@ogimg,ogsales=@ogsales,ogpostage=@ogpostage,ogSKU=@ogSKU,ogUPdate=@ogUPdate,ogDowndate=@ogDowndate,ogTBid=@ogTBid,ogxiaoliang=@ogxiaoliang,ogshoucang=@ogshoucang,ogremark=@ogremark,ogremark1=@ogremark1,oshopid=@oshopid,ogremark2=@ogremark2,ogremark3=@ogremark3,ogremark4=@ogremark4,ogremark5=@ogremark5 where ogid=" + opponent_goodsExample.ogid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(opponent_goodsExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ogid">编号</param>
        /// <returns>int</returns>
        public int Delete(int ogid)
        {
            DBHelper.sqlstr = "delete opponent_goods where ogid =@ogid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ogid",ogid)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion


        #region SearchNum
       /// <summary>
       /// 搜索条数
       /// </summary>
       /// <param name="key">关键词</param>
       /// <param name="dpid">店铺编号</param>
       /// <param name="TBid">商品编号</param>
       /// <param name="caijidate">采集时间字符串</param>
       /// <returns></returns>
        public int SearchNum(string key, string shopid,string TBid ,string caijidate)
        {
            string sql1 = "select count(ogid) from opponent_goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  ogurl like '%" + key + "%' or  ogtittle like '%" + key + "%'   or  ogprice1 like '%" + key + "%'   or  ogprice2 like '%" + key + "%'   or  ogdiscount like '%" + key + "%'   or  ogimg like '%" + key + "%'   or  ogsales like '%" + key + "%'   or  ogpostage like '%" + key + "%'   or  ogSKU like '%" + key + "%'   or  ogUPdate like '%" + key + "%'   or  ogDowndate like '%" + key + "%'    or  ogxiaoliang like '%" + key + "%'   or  ogshoucang like '%" + key + "%'   or  ogremark like '%" + key + "%'   or  ogremark1 like '%" + key + "%'   or  oshopid like '%" + key + "%'   or  ogremark2 like '%" + key + "%'   or  ogremark3 like '%" + key + "%'   or  ogremark4 like '%" + key + "%'   or  ogremark5 like '%" + key + "%'    ) ";
            string sql3 = string.IsNullOrEmpty(shopid) ? "" : " and oshopid = '" + shopid + "' ";
            string sql4 = string.IsNullOrEmpty(caijidate) ? "" : " and ocollectdate like '%" + caijidate + "%' ";
            string sql5 = string.IsNullOrEmpty(TBid) ? "" : " and ogTBid = '" + TBid + "' ";
            
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 ;

            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束为止</param>
        /// <param name="key">关键词</param>
        /// <param name="dpid">店铺ID</param>
        /// <param name="TBid">淘宝商品ID</param>
        /// <param name="caijidate">采集时间</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public IList<opponent_goods> Search(int s, int e, string key, string shopid, string TBid, string caijidate, string orderby)
        {
            string sql1 = "select  top " + (e - s + 1).ToString() + " *   from opponent_goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  ogurl like '%" + key + "%' or  ogtittle like '%" + key + "%'   or  ogprice1 like '%" + key + "%'   or  ogprice2 like '%" + key + "%'   or  ogdiscount like '%" + key + "%'   or  ogimg like '%" + key + "%'   or  ogsales like '%" + key + "%'   or  ogpostage like '%" + key + "%'   or  ogSKU like '%" + key + "%'   or  ogUPdate like '%" + key + "%'   or  ogDowndate like '%" + key + "%'    or  ogxiaoliang like '%" + key + "%'   or  ogshoucang like '%" + key + "%'   or  ogremark like '%" + key + "%'   or  ogremark1 like '%" + key + "%'   or  oshopid like '%" + key + "%'   or  ogremark2 like '%" + key + "%'   or  ogremark3 like '%" + key + "%'   or  ogremark4 like '%" + key + "%'   or  ogremark5 like '%" + key + "%'    ) ";
            string sql3 = string.IsNullOrEmpty(shopid) ? "" : " and oshopid = '" + shopid + "' ";
            string sql4 = string.IsNullOrEmpty(caijidate) ? "" : " and ocollectdate like '%" + caijidate + "%' ";
            string sql5 = string.IsNullOrEmpty(TBid) ? "" : " and ogTBid = '" + TBid + "' ";
            string sql8 = string.IsNullOrEmpty(orderby) ? " order by ocollectdate desc " : " order by " + orderby;
            string sql7 = s == 1 ? "" : " and ogid not in ( select top " + (s - 1).ToString() + " ogid from opponent_goods where " + sql2 + sql3 + sql4 + sql5  + sql8 + " ) ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5  + sql7 + sql8;
            List<opponent_goods> list = new List<opponent_goods>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                opponent_goods Obj = GetByReader(reader);
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
        public static SqlParameter[] GetSqlParameters(opponent_goods opponent_goodsExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();
            if (opponent_goodsExample.odpid != 0)
            {
                list_param.Add(new SqlParameter("@odpid", opponent_goodsExample.odpid));
            }
            else
            {
                list_param.Add(new SqlParameter("@odpid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ocollectdate))
            {
                list_param.Add(new SqlParameter("@ocollectdate", opponent_goodsExample.ocollectdate));
            }
            else
            {
                list_param.Add(new SqlParameter("@ocollectdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogurl))
            {
                list_param.Add(new SqlParameter("@ogurl", opponent_goodsExample.ogurl));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogurl", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogtittle))
            {
                list_param.Add(new SqlParameter("@ogtittle", opponent_goodsExample.ogtittle));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogtittle", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogprice1))
            {
                list_param.Add(new SqlParameter("@ogprice1", opponent_goodsExample.ogprice1));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogprice1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogprice2))
            {
                list_param.Add(new SqlParameter("@ogprice2", opponent_goodsExample.ogprice2));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogprice2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogdiscount))
            {
                list_param.Add(new SqlParameter("@ogdiscount", opponent_goodsExample.ogdiscount));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogdiscount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogimg))
            {
                list_param.Add(new SqlParameter("@ogimg", opponent_goodsExample.ogimg));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogimg", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogsales))
            {
                list_param.Add(new SqlParameter("@ogsales", opponent_goodsExample.ogsales));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogsales", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogpostage))
            {
                list_param.Add(new SqlParameter("@ogpostage", opponent_goodsExample.ogpostage));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogpostage", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogSKU))
            {
                list_param.Add(new SqlParameter("@ogSKU", opponent_goodsExample.ogSKU));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogSKU", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogUPdate))
            {
                list_param.Add(new SqlParameter("@ogUPdate", opponent_goodsExample.ogUPdate));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogUPdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogDowndate))
            {
                list_param.Add(new SqlParameter("@ogDowndate", opponent_goodsExample.ogDowndate));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogDowndate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogTBid))
            {
                list_param.Add(new SqlParameter("@ogTBid", opponent_goodsExample.ogTBid));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogTBid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogxiaoliang))
            {
                list_param.Add(new SqlParameter("@ogxiaoliang", opponent_goodsExample.ogxiaoliang));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogxiaoliang", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogshoucang))
            {
                list_param.Add(new SqlParameter("@ogshoucang", opponent_goodsExample.ogshoucang));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogshoucang", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogremark))
            {
                list_param.Add(new SqlParameter("@ogremark", opponent_goodsExample.ogremark));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogremark1))
            {
                list_param.Add(new SqlParameter("@ogremark1", opponent_goodsExample.ogremark1));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.oshopid))
            {
                list_param.Add(new SqlParameter("@oshopid", opponent_goodsExample.oshopid));
            }
            else
            {
                list_param.Add(new SqlParameter("@oshopid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogremark2))
            {
                list_param.Add(new SqlParameter("@ogremark2", opponent_goodsExample.ogremark2));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogremark3))
            {
                list_param.Add(new SqlParameter("@ogremark3", opponent_goodsExample.ogremark3));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogremark3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogremark4))
            {
                list_param.Add(new SqlParameter("@ogremark4", opponent_goodsExample.ogremark4));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogremark4", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_goodsExample.ogremark5))
            {
                list_param.Add(new SqlParameter("@ogremark5", opponent_goodsExample.ogremark5));
            }
            else
            {
                list_param.Add(new SqlParameter("@ogremark5", DBNull.Value));
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
        /// <returns>opponent_goodsExample</returns>
        public static opponent_goods GetByReader(SqlDataReader Reader)
        {
            opponent_goods opponent_goodsExample = new opponent_goods();
            opponent_goodsExample.ogid = Reader["ogid"] == DBNull.Value ? 0 : (int)Reader["ogid"];
            opponent_goodsExample.odpid = Reader["odpid"] == DBNull.Value ? 0 : (int)Reader["odpid"];
            opponent_goodsExample.ocollectdate = Reader["ocollectdate"] == DBNull.Value ? null : Reader["ocollectdate"].ToString();
            opponent_goodsExample.ogurl = Reader["ogurl"] == DBNull.Value ? null : Reader["ogurl"].ToString();
            opponent_goodsExample.ogtittle = Reader["ogtittle"] == DBNull.Value ? null : Reader["ogtittle"].ToString();
            opponent_goodsExample.ogprice1 = Reader["ogprice1"] == DBNull.Value ? null : Reader["ogprice1"].ToString();
            opponent_goodsExample.ogprice2 = Reader["ogprice2"] == DBNull.Value ? null : Reader["ogprice2"].ToString();
            opponent_goodsExample.ogdiscount = Reader["ogdiscount"] == DBNull.Value ? null : Reader["ogdiscount"].ToString();
            opponent_goodsExample.ogimg = Reader["ogimg"] == DBNull.Value ? null : Reader["ogimg"].ToString();
            opponent_goodsExample.ogsales = Reader["ogsales"] == DBNull.Value ? null : Reader["ogsales"].ToString();
            opponent_goodsExample.ogpostage = Reader["ogpostage"] == DBNull.Value ? null : Reader["ogpostage"].ToString();
            opponent_goodsExample.ogSKU = Reader["ogSKU"] == DBNull.Value ? null : Reader["ogSKU"].ToString();
            opponent_goodsExample.ogUPdate = Reader["ogUPdate"] == DBNull.Value ? null : Reader["ogUPdate"].ToString();
            opponent_goodsExample.ogDowndate = Reader["ogDowndate"] == DBNull.Value ? null : Reader["ogDowndate"].ToString();
            opponent_goodsExample.ogTBid = Reader["ogTBid"] == DBNull.Value ? null : Reader["ogTBid"].ToString();
            opponent_goodsExample.ogxiaoliang = Reader["ogxiaoliang"] == DBNull.Value ? null : Reader["ogxiaoliang"].ToString();
            opponent_goodsExample.ogshoucang = Reader["ogshoucang"] == DBNull.Value ? null : Reader["ogshoucang"].ToString();
            opponent_goodsExample.ogremark = Reader["ogremark"] == DBNull.Value ? null : Reader["ogremark"].ToString();
            opponent_goodsExample.ogremark1 = Reader["ogremark1"] == DBNull.Value ? null : Reader["ogremark1"].ToString();
            opponent_goodsExample.oshopid = Reader["oshopid"] == DBNull.Value ? null : Reader["oshopid"].ToString();
            opponent_goodsExample.ogremark2 = Reader["ogremark2"] == DBNull.Value ? null : Reader["ogremark2"].ToString();
            opponent_goodsExample.ogremark3 = Reader["ogremark3"] == DBNull.Value ? null : Reader["ogremark3"].ToString();
            opponent_goodsExample.ogremark4 = Reader["ogremark4"] == DBNull.Value ? null : Reader["ogremark4"].ToString();
            opponent_goodsExample.ogremark5 = Reader["ogremark5"] == DBNull.Value ? null : Reader["ogremark5"].ToString();
            return opponent_goodsExample;
        }
        #endregion





        #endregion
    }

 
  


}

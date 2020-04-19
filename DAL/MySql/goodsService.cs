using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql
{

    //表名称：goods
    //实体类名称：goodsExample
    //主键：gid

    public class goodsService : IgoodsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<goods> SearchAll()
        {
            DBHelper.sqlstr = "select * from goods ";
            List<goods> list = new List<goods>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                goods Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBygid
        /// <summary>
        /// 根据gid,查询一条数据
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <returns></returns>
        public goods SearchBygid(int gid)
        {
            DBHelper.sqlstr = "select * from goods where gid = @gid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@gid",gid)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            goods Obj = null;
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
        /// <param name="goods">goods表实例</param>
        /// <returns>int</returns>
        public int Insert(goods goodsExample)
        {
            DBHelper.sqlstr = "insert into  goods (g_price_yuan,g_standby1,g_standby2,g_standby3,gdate,gdate1,gdate2,gdate3,gimg,gimg2,gname,gprice1,gprice2,gremark1,gremark2,gstate,gstate1,gstate2,gstate3,gtid,gtitle,gurl,gurl_yuan,gurl2)values(@g_price_yuan,@g_standby1,@g_standby2,@g_standby3,'" + goodsExample.gdate.ToString("yyyy-MM-dd") + "','" + goodsExample.gdate1.ToString("yyyy-MM-dd") + "','" + goodsExample.gdate2.ToString("yyyy-MM-dd") + "','" + goodsExample.gdate3.ToString("yyyy-MM-dd") + "',@gimg,@gimg2,@gname,@gprice1,@gprice2,@gremark1,@gremark2,@gstate,@gstate1,@gstate2,@gstate3,@gtid,@gtitle,@gurl,@gurl_yuan,@gurl2)";
            return DBHelper.ExecuteNonQuery(GetSqlParameter(goodsExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="goods">goods表实例</param>
        /// <returns>int</returns>
        public int Update(goods goodsExample)
        {
            DBHelper.sqlstr = "update goods set g_price_yuan=@g_price_yuan,g_standby1=@g_standby1,g_standby2=@g_standby2,g_standby3=@g_standby3,gdate='" + goodsExample.gdate.ToString("yyyy-MM-dd") + "',gdate1='" + goodsExample.gdate1.ToString("yyyy-MM-dd") + "',gdate2='" + goodsExample.gdate2.ToString("yyyy-MM-dd") + "',gdate3='" + goodsExample.gdate3.ToString("yyyy-MM-dd") + "',gimg=@gimg,gimg2=@gimg2,gname=@gname,gprice1=@gprice1,gprice2=@gprice2,gremark1=@gremark1,gremark2=@gremark2,gstate=@gstate,gstate1=@gstate1,gstate2=@gstate2,gstate3=@gstate3,gtid=@gtid,gtitle=@gtitle,gurl=@gurl,gurl_yuan=@gurl_yuan,gurl2=@gurl2 where gid=" + goodsExample.gid;
            return DBHelper.ExecuteNonQuery(GetSqlParameter(goodsExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <returns>int</returns>
        public int Delete(int gid)
        {
            DBHelper.sqlstr = "delete from goods where gid =@gid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@gid",gid)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state_img">图片状态 0:不查,1:未上传,2:已上传</param>
        /// <param name="state_up">上架状态 0:不查,1:未上架,2:已上架</param>
        /// <param name="state_title">图片状态 0:不查,1:未上传,2:已上传</param>
        /// <param name="hasImg_tb">是否有淘宝图片 空:不查询,1:不是空,0:空</param>
        /// <param name="hasImg_mgj">是否有蘑菇街图片 空:不查询,1:不是空,0:空</param>
        /// <param name="dt1_add">添加商品起始时间</param>
        /// <param name="dt2_add">添加商品结束时间</param>
        /// <param name="important">是否是重点商品 1是 0不是</param>
        /// <returns>int</returns>
        public int SearchNum(string key, int gt, string state_img, string state_up, string state_title, string hasImg_tb, string hasImg_mgj, DateTime dt1_add, DateTime dt2_add, string important)
        {
            string sql1 = "select count(gid) from goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  gname like '%" + key + "%' or  gtitle like '%" + key + "%' or  gurl like '%" + key + "%' or  gimg like '%" + key + "%' or  gremark1 like '%" + key + "%' or  gremark2 like '%" + key + "%'  or  gprice1 like '%" + key + "%'  or  gprice2 like '%" + key + "%'   or  gimg2 like '%" + key + "%'  or  gurl2 like '%" + key + "%'   or  g_price_yuan like '%" + key + "%'   or  g_standby1 like '%" + key + "%'   or  g_standby2 like '%" + key + "%'   or  g_standby3 like '%" + key + "%') ";
            string sql3 = gt == 0 ? "" : " and gtid='" + gt.ToString() + "' ";
            string sql4 = string.IsNullOrEmpty(state_img) ? "" : " and gstate1= '" + state_img + "' ";
            string sql5 = string.IsNullOrEmpty(state_up) ? "" : " and gstate2= '" + state_up + "' ";
            string sql6 = string.IsNullOrEmpty(state_title) ? "" : " and gstate3= '" + state_title + "' ";
            string sql7 = string.IsNullOrEmpty(hasImg_tb) ? "" : (hasImg_tb == "1" ? " and gimg is not null " : " and gimg is null ");
            string sql8 = string.IsNullOrEmpty(hasImg_mgj) ? "" : (hasImg_mgj == "1" ? " and gimg2 is not null " : " and gimg2 is null ");
            string sql9 = dt1_add == new DateTime() ? "" : " and datediff('d','" + dt1_add.ToString() + "',gdate)>=0 ";
            string sql10 = dt2_add == new DateTime() ? "" : " and datediff('d','" + dt2_add.ToString() + "',gdate)<=0 ";
            string sql11 = string.IsNullOrEmpty(important) ? "" : " and g_standby1= '" + important + "' ";
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + sql9 + sql10;

            return Convert.ToInt32(Access.DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 条件搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state_img">图片状态 0:不查,1:未上传,2:已上传</param>
        /// <param name="state_up">上架状态 0:不查,1:未上架,2:已上架</param>
        /// <param name="state_title">图片状态 0:不查,1:未上传,2:已上传</param>
        /// <param name="hasImg_tb">是否有淘宝图片 空:不查询,1:不是空,0:空</param>
        /// <param name="hasImg_mgj">是否有蘑菇街图片 空:不查询,1:不是空,0:空</param>
        /// <param name="dt1_add">添加商品起始时间</param>
        /// <param name="dt2_add">添加商品结束时间</param>
        /// <param name="important">是否是重点商品 1是 0不是</param>
        /// <returns>IList<goods></returns>
        public IList<goods> Search(int s, int e, string key, int gt, string state_img, string state_up, string state_title, string hasImg_tb, string hasImg_mgj, DateTime dt1_add, DateTime dt2_add, string important)
        {
            string sql1 = "select top " + e.ToString() + " *  from goods where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  gname like '%" + key + "%' or  gtitle like '%" + key + "%' or  gurl like '%" + key + "%' or  gimg like '%" + key + "%' or  gremark1 like '%" + key + "%' or  gremark2 like '%" + key + "%'  or  gprice1 like '%" + key + "%'  or  gprice2 like '%" + key + "%'   or  gimg2 like '%" + key + "%'  or  gurl2 like '%" + key + "%'   or  g_price_yuan like '%" + key + "%'   or  g_standby1 like '%" + key + "%'   or  g_standby2 like '%" + key + "%'   or  g_standby3 like '%" + key + "%') ";
            string sql3 = gt == 0 ? "" : " and gtid='" + gt.ToString() + "' ";
            string sql4 = string.IsNullOrEmpty(state_img) ? "" : " and gstate1= '" + state_img + "' ";
            string sql5 = string.IsNullOrEmpty(state_up) ? "" : " and gstate2= '" + state_up + "' ";
            string sql6 = string.IsNullOrEmpty(state_title) ? "" : " and gstate3= '" + state_title + "' ";
            string sql7 = string.IsNullOrEmpty(hasImg_tb) ? "" : (hasImg_tb == "1" ? " and gimg is not null " : " and gimg is null ");
            string sql8 = string.IsNullOrEmpty(hasImg_mgj) ? "" : (hasImg_mgj == "1" ? " and gimg2 is not null " : " and gimg2 is null ");
            string sql9 = dt1_add == new DateTime() ? "" : " and datediff('d','" + dt1_add.ToString() + "',gdate)>=0 ";
            string sql10 = dt2_add == new DateTime() ? "" : " and datediff('d','" + dt2_add.ToString() + "',gdate)<=0 ";
            string sql11 = string.IsNullOrEmpty(important) ? "" : " and g_standby1= '" + important + "' ";
            DBHelper.sqlstr = "selct * from (select * from " + "( " + sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + sql9 + sql10 + sql11 + " order by gdate desc,gid asc ) order by gdate asc, gid asc) order by gdate desc,gid asc ";
            List<goods> list = new List<goods>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                goods Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion



        #region 公共方法

        #region GetSqlParameter
        /// <summary>
        /// 根据表,获取一个MySqlParameter数组
        /// </summary>
        /// <returns>MySqlParameter[]</returns>
        public static MySqlParameter[] GetSqlParameter(goods goodsExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(goodsExample.g_price_yuan))
            {
                list_param.Add(new MySqlParameter("@g_price_yuan", goodsExample.g_price_yuan));
            }
            else
            {
                list_param.Add(new MySqlParameter("@g_price_yuan", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.g_standby1))
            {
                list_param.Add(new MySqlParameter("@g_standby1", goodsExample.g_standby1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@g_standby1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.g_standby2))
            {
                list_param.Add(new MySqlParameter("@g_standby2", goodsExample.g_standby2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@g_standby2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.g_standby3))
            {
                list_param.Add(new MySqlParameter("@g_standby3", goodsExample.g_standby3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@g_standby3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gimg))
            {
                list_param.Add(new MySqlParameter("@gimg", goodsExample.gimg));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gimg", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gimg2))
            {
                list_param.Add(new MySqlParameter("@gimg2", goodsExample.gimg2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gimg2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gname))
            {
                list_param.Add(new MySqlParameter("@gname", goodsExample.gname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gprice1))
            {
                list_param.Add(new MySqlParameter("@gprice1", goodsExample.gprice1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gprice1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gprice2))
            {
                list_param.Add(new MySqlParameter("@gprice2", goodsExample.gprice2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gprice2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gremark1))
            {
                list_param.Add(new MySqlParameter("@gremark1", goodsExample.gremark1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gremark2))
            {
                list_param.Add(new MySqlParameter("@gremark2", goodsExample.gremark2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gstate))
            {
                list_param.Add(new MySqlParameter("@gstate", goodsExample.gstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gstate1))
            {
                list_param.Add(new MySqlParameter("@gstate1", goodsExample.gstate1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gstate1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gstate2))
            {
                list_param.Add(new MySqlParameter("@gstate2", goodsExample.gstate2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gstate2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gstate3))
            {
                list_param.Add(new MySqlParameter("@gstate3", goodsExample.gstate3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gstate3", DBNull.Value));
            }
            if (goodsExample.gtid != 0)
            {
                list_param.Add(new MySqlParameter("@gtid", goodsExample.gtid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gtid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gtitle))
            {
                list_param.Add(new MySqlParameter("@gtitle", goodsExample.gtitle));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gtitle", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gurl))
            {
                list_param.Add(new MySqlParameter("@gurl", goodsExample.gurl));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gurl", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gurl_yuan))
            {
                list_param.Add(new MySqlParameter("@gurl_yuan", goodsExample.gurl_yuan));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gurl_yuan", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(goodsExample.gurl2))
            {
                list_param.Add(new MySqlParameter("@gurl2", goodsExample.gurl2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@gurl2", DBNull.Value));
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
        /// <returns>goodsExample</returns>
        public static goods GetByReader(MySqlDataReader Reader)
        {
            goods goodsExample = new goods();
            goodsExample.g_price_yuan = Reader["g_price_yuan"] == DBNull.Value ? null : Reader["g_price_yuan"].ToString();
            goodsExample.g_standby1 = Reader["g_standby1"] == DBNull.Value ? null : Reader["g_standby1"].ToString();
            goodsExample.g_standby2 = Reader["g_standby2"] == DBNull.Value ? null : Reader["g_standby2"].ToString();
            goodsExample.g_standby3 = Reader["g_standby3"] == DBNull.Value ? null : Reader["g_standby3"].ToString();
            goodsExample.gdate = Reader["gdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["gdate"]);
            goodsExample.gdate1 = Reader["gdate1"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["gdate1"]);
            goodsExample.gdate2 = Reader["gdate2"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["gdate2"]);
            goodsExample.gdate3 = Reader["gdate3"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["gdate3"]);
            goodsExample.gid = Reader["gid"] == DBNull.Value ? 0 : (int)Reader["gid"];
            goodsExample.gimg = Reader["gimg"] == DBNull.Value ? null : Reader["gimg"].ToString();
            goodsExample.gimg2 = Reader["gimg2"] == DBNull.Value ? null : Reader["gimg2"].ToString();
            goodsExample.gname = Reader["gname"] == DBNull.Value ? null : Reader["gname"].ToString();
            goodsExample.gprice1 = Reader["gprice1"] == DBNull.Value ? null : Reader["gprice1"].ToString();
            goodsExample.gprice2 = Reader["gprice2"] == DBNull.Value ? null : Reader["gprice2"].ToString();
            goodsExample.gremark1 = Reader["gremark1"] == DBNull.Value ? null : Reader["gremark1"].ToString();
            goodsExample.gremark2 = Reader["gremark2"] == DBNull.Value ? null : Reader["gremark2"].ToString();
            goodsExample.gstate = Reader["gstate"] == DBNull.Value ? null : Reader["gstate"].ToString();
            goodsExample.gstate1 = Reader["gstate1"] == DBNull.Value ? null : Reader["gstate1"].ToString();
            goodsExample.gstate2 = Reader["gstate2"] == DBNull.Value ? null : Reader["gstate2"].ToString();
            goodsExample.gstate3 = Reader["gstate3"] == DBNull.Value ? null : Reader["gstate3"].ToString();
            goodsExample.gtid = Reader["gtid"] == DBNull.Value ? 0 : (int)Reader["gtid"];
            goodsExample.gtitle = Reader["gtitle"] == DBNull.Value ? null : Reader["gtitle"].ToString();
            goodsExample.gurl = Reader["gurl"] == DBNull.Value ? null : Reader["gurl"].ToString();
            goodsExample.gurl_yuan = Reader["gurl_yuan"] == DBNull.Value ? null : Reader["gurl_yuan"].ToString();
            goodsExample.gurl2 = Reader["gurl2"] == DBNull.Value ? null : Reader["gurl2"].ToString();
            return goodsExample;
        }
        #endregion





        #endregion
    }




 
  
 
}

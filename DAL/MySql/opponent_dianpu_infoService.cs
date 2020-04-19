using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql
{



    public class opponent_dianpu_infoService : Iopponent_dianpu_infoService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<opponent_dianpu_info> SearchAll()
        {
            DBHelper.sqlstr = "select * from opponent_dianpu_info ";
            List<opponent_dianpu_info> list = new List<opponent_dianpu_info>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                opponent_dianpu_info Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据odiid,查询一条数据
        /// </summary>
        /// <param name="odiid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public opponent_dianpu_info SearchByID(int odiid)
        {
            DBHelper.sqlstr = "select * from opponent_dianpu_info where odiid = @odiid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@odiid",odiid)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            opponent_dianpu_info Obj = null;
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
        /// <param name="opponent_dianpu_info">opponent_dianpu_info表实例</param>
        /// <returns>int</returns>
        public int Insert(opponent_dianpu_info opponent_dianpu_infoExample)
        {
            DBHelper.sqlstr = "insert into  opponent_dianpu_info (odigoodsnum,odisell0,odiSKUcount,odipricehigh,odipricelowset,odipriceaverage,odisellhigh,odiselllowset,odisellaverage,odisalescount,odisellcount,odidongxiao,odibaozhangjin,odiDSRmiaoshu,odiDSRzhiliang,odiDSRwuliu,odpid,ocollectdate,oshopid,oremark1,oremark2,oremark3)values(@odigoodsnum,@odisell0,@odiSKUcount,@odipricehigh,@odipricelowset,@odipriceaverage,@odisellhigh,@odiselllowset,@odisellaverage,@odisalescount,@odisellcount,@odidongxiao,@odibaozhangjin,@odiDSRmiaoshu,@odiDSRzhiliang,@odiDSRwuliu,@odpid,@ocollectdate,@oshopid,@oremark1,@oremark2,@oremark3)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(opponent_dianpu_infoExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="opponent_dianpu_info">opponent_dianpu_info表实例</param>
        /// <returns>int</returns>
        public int Update(opponent_dianpu_info opponent_dianpu_infoExample)
        {
            DBHelper.sqlstr = "update opponent_dianpu_info set odigoodsnum=@odigoodsnum,odisell0=@odisell0,odiSKUcount=@odiSKUcount,odipricehigh=@odipricehigh,odipricelowset=@odipricelowset,odipriceaverage=@odipriceaverage,odisellhigh=@odisellhigh,odiselllowset=@odiselllowset,odisellaverage=@odisellaverage,odisalescount=@odisalescount,odisellcount=@odisellcount,odidongxiao=@odidongxiao,odibaozhangjin=@odibaozhangjin,odiDSRmiaoshu=@odiDSRmiaoshu,odiDSRzhiliang=@odiDSRzhiliang,odiDSRwuliu=@odiDSRwuliu,odpid=@odpid,ocollectdate=@ocollectdate,oshopid=@oshopid,oremark1=@oremark1,oremark2=@oremark2,oremark3=@oremark3 where odiid=" + opponent_dianpu_infoExample.odiid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(opponent_dianpu_infoExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="odiid">编号</param>
        /// <returns>int</returns>
        public int Delete(int odiid)
        {
            DBHelper.sqlstr = "delete opponent_dianpu_info where odiid =@odiid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@odiid",odiid)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion


        #region SearchNum
        /// <summary>
        /// 高级搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="caijidate">最后采集时间</param>
        /// <returns>int</returns>
        public int SearchNum(string key, string shopid, string caijidate)
        {
            string sql1 = "select count(odiid) from opponent_dianpu_info where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  odigoodsnum like '%" + key + "%' or  odisell0 like '%" + key + "%'  or  odiSKUcount like '%" + key + "%'  or  odipricehigh like '%" + key + "%'  or  odipricelowset like '%" + key + "%'  or  odipriceaverage like '%" + key + "%'  or  odisellhigh like '%" + key + "%'  or  odiselllowset like '%" + key + "%'  or  odisellaverage like '%" + key + "%'  or  odisalescount like '%" + key + "%'  or  odisellcount like '%" + key + "%'  or  odidongxiao like '%" + key + "%'  or  odibaozhangjin like '%" + key + "%'  or  odiDSRmiaoshu like '%" + key + "%'  or  odiDSRzhiliang like '%" + key + "%'  or  odiDSRwuliu like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(shopid) ? "" : " and oshopid = '" + shopid + "' ";
            string sql4 = string.IsNullOrEmpty(caijidate) ? "" : " and ocollectdate like '%" + caijidate + "%' ";

            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4;

            return Convert.ToInt32(DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 高级搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束为止</param>
        /// <param name="key">关键词</param>
        /// <param name="dpid">店铺ID</param>
        /// <param name="caijidate">最后采集时间</param>
        /// <param name="orderby">排序方式</param>
        /// <returns>IList<opponent_dianpu_info></returns>
        public IList<opponent_dianpu_info> Search(int s, int e, string key, string shopid, string caijidate, string orderby)
        {
            string sql1 = "select  *   from opponent_dianpu_info where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  odigoodsnum like '%" + key + "%' or  odisell0 like '%" + key + "%'  or  odiSKUcount like '%" + key + "%'  or  odipricehigh like '%" + key + "%'  or  odipricelowset like '%" + key + "%'  or  odipriceaverage like '%" + key + "%'  or  odisellhigh like '%" + key + "%'  or  odiselllowset like '%" + key + "%'  or  odisellaverage like '%" + key + "%'  or  odisalescount like '%" + key + "%'  or  odisellcount like '%" + key + "%'  or  odidongxiao like '%" + key + "%'  or  odibaozhangjin like '%" + key + "%'  or  odiDSRmiaoshu like '%" + key + "%'  or  odiDSRzhiliang like '%" + key + "%'  or  odiDSRwuliu like '%" + key + "%'  or  oshopid like '%" + key + "%'  or  oremark1 like '%" + key + "%'  or  oremark2 like '%" + key + "%'  or  oremark3 like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(shopid) ? "" : " and oshopid = '" + shopid + "' ";
            string sql4 = string.IsNullOrEmpty(caijidate) ? "" : " and ocollectdate like '%" + caijidate + "%' ";
            string sql8 = string.IsNullOrEmpty(orderby) ? " order by ocollectdate desc " : " order by " + orderby;
            ///string sql7 = s == 1 ? "" : " and odiid not in ( select top " + (s - 1).ToString() + " odiid from opponent_dianpu_info where " + sql2 + sql3 + sql4 + sql8 + " ) ";
            string sql9 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4+ sql8 + sql9;
            List<opponent_dianpu_info> list = new List<opponent_dianpu_info>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                opponent_dianpu_info Obj = GetByReader(reader);
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
        public static MySqlParameter[] GetSqlParameters(opponent_dianpu_info opponent_dianpu_infoExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();
            if (opponent_dianpu_infoExample.odigoodsnum != 0)
            {
                list_param.Add(new MySqlParameter("@odigoodsnum", opponent_dianpu_infoExample.odigoodsnum));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odigoodsnum", DBNull.Value));
            }
            if (opponent_dianpu_infoExample.odisell0 != 0)
            {
                list_param.Add(new MySqlParameter("@odisell0", opponent_dianpu_infoExample.odisell0));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odisell0", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odiSKUcount))
            {
                list_param.Add(new MySqlParameter("@odiSKUcount", opponent_dianpu_infoExample.odiSKUcount));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odiSKUcount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odipricehigh))
            {
                list_param.Add(new MySqlParameter("@odipricehigh", opponent_dianpu_infoExample.odipricehigh));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odipricehigh", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odipricelowset))
            {
                list_param.Add(new MySqlParameter("@odipricelowset", opponent_dianpu_infoExample.odipricelowset));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odipricelowset", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odipriceaverage))
            {
                list_param.Add(new MySqlParameter("@odipriceaverage", opponent_dianpu_infoExample.odipriceaverage));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odipriceaverage", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odisellhigh))
            {
                list_param.Add(new MySqlParameter("@odisellhigh", opponent_dianpu_infoExample.odisellhigh));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odisellhigh", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odiselllowset))
            {
                list_param.Add(new MySqlParameter("@odiselllowset", opponent_dianpu_infoExample.odiselllowset));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odiselllowset", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odisellaverage))
            {
                list_param.Add(new MySqlParameter("@odisellaverage", opponent_dianpu_infoExample.odisellaverage));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odisellaverage", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odisalescount))
            {
                list_param.Add(new MySqlParameter("@odisalescount", opponent_dianpu_infoExample.odisalescount));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odisalescount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odisellcount))
            {
                list_param.Add(new MySqlParameter("@odisellcount", opponent_dianpu_infoExample.odisellcount));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odisellcount", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odidongxiao))
            {
                list_param.Add(new MySqlParameter("@odidongxiao", opponent_dianpu_infoExample.odidongxiao));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odidongxiao", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odibaozhangjin))
            {
                list_param.Add(new MySqlParameter("@odibaozhangjin", opponent_dianpu_infoExample.odibaozhangjin));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odibaozhangjin", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odiDSRmiaoshu))
            {
                list_param.Add(new MySqlParameter("@odiDSRmiaoshu", opponent_dianpu_infoExample.odiDSRmiaoshu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odiDSRmiaoshu", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odiDSRzhiliang))
            {
                list_param.Add(new MySqlParameter("@odiDSRzhiliang", opponent_dianpu_infoExample.odiDSRzhiliang));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odiDSRzhiliang", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.odiDSRwuliu))
            {
                list_param.Add(new MySqlParameter("@odiDSRwuliu", opponent_dianpu_infoExample.odiDSRwuliu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odiDSRwuliu", DBNull.Value));
            }
            if (opponent_dianpu_infoExample.odpid != 0)
            {
                list_param.Add(new MySqlParameter("@odpid", opponent_dianpu_infoExample.odpid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@odpid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.ocollectdate))
            {
                list_param.Add(new MySqlParameter("@ocollectdate", opponent_dianpu_infoExample.ocollectdate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@ocollectdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.oshopid))
            {
                list_param.Add(new MySqlParameter("@oshopid", opponent_dianpu_infoExample.oshopid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@oshopid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.oremark1))
            {
                list_param.Add(new MySqlParameter("@oremark1", opponent_dianpu_infoExample.oremark1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@oremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.oremark2))
            {
                list_param.Add(new MySqlParameter("@oremark2", opponent_dianpu_infoExample.oremark2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@oremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(opponent_dianpu_infoExample.oremark3))
            {
                list_param.Add(new MySqlParameter("@oremark3", opponent_dianpu_infoExample.oremark3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@oremark3", DBNull.Value));
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
        /// <returns>opponent_dianpu_infoExample</returns>
        public static opponent_dianpu_info GetByReader(MySqlDataReader Reader)
        {
            opponent_dianpu_info opponent_dianpu_infoExample = new opponent_dianpu_info();
            opponent_dianpu_infoExample.odiid = Reader["odiid"] == DBNull.Value ? 0 : (int)Reader["odiid"];
            opponent_dianpu_infoExample.odigoodsnum = Reader["odigoodsnum"] == DBNull.Value ? 0 : (int)Reader["odigoodsnum"];
            opponent_dianpu_infoExample.odisell0 = Reader["odisell0"] == DBNull.Value ? 0 : (int)Reader["odisell0"];
            opponent_dianpu_infoExample.odiSKUcount = Reader["odiSKUcount"] == DBNull.Value ? null : Reader["odiSKUcount"].ToString();
            opponent_dianpu_infoExample.odipricehigh = Reader["odipricehigh"] == DBNull.Value ? null : Reader["odipricehigh"].ToString();
            opponent_dianpu_infoExample.odipricelowset = Reader["odipricelowset"] == DBNull.Value ? null : Reader["odipricelowset"].ToString();
            opponent_dianpu_infoExample.odipriceaverage = Reader["odipriceaverage"] == DBNull.Value ? null : Reader["odipriceaverage"].ToString();
            opponent_dianpu_infoExample.odisellhigh = Reader["odisellhigh"] == DBNull.Value ? null : Reader["odisellhigh"].ToString();
            opponent_dianpu_infoExample.odiselllowset = Reader["odiselllowset"] == DBNull.Value ? null : Reader["odiselllowset"].ToString();
            opponent_dianpu_infoExample.odisellaverage = Reader["odisellaverage"] == DBNull.Value ? null : Reader["odisellaverage"].ToString();
            opponent_dianpu_infoExample.odisalescount = Reader["odisalescount"] == DBNull.Value ? null : Reader["odisalescount"].ToString();
            opponent_dianpu_infoExample.odisellcount = Reader["odisellcount"] == DBNull.Value ? null : Reader["odisellcount"].ToString();
            opponent_dianpu_infoExample.odidongxiao = Reader["odidongxiao"] == DBNull.Value ? null : Reader["odidongxiao"].ToString();
            opponent_dianpu_infoExample.odibaozhangjin = Reader["odibaozhangjin"] == DBNull.Value ? null : Reader["odibaozhangjin"].ToString();
            opponent_dianpu_infoExample.odiDSRmiaoshu = Reader["odiDSRmiaoshu"] == DBNull.Value ? null : Reader["odiDSRmiaoshu"].ToString();
            opponent_dianpu_infoExample.odiDSRzhiliang = Reader["odiDSRzhiliang"] == DBNull.Value ? null : Reader["odiDSRzhiliang"].ToString();
            opponent_dianpu_infoExample.odiDSRwuliu = Reader["odiDSRwuliu"] == DBNull.Value ? null : Reader["odiDSRwuliu"].ToString();
            opponent_dianpu_infoExample.odpid = Reader["odpid"] == DBNull.Value ? 0 : (int)Reader["odpid"];
            opponent_dianpu_infoExample.ocollectdate = Reader["ocollectdate"] == DBNull.Value ? null : Reader["ocollectdate"].ToString();
            opponent_dianpu_infoExample.oshopid = Reader["oshopid"] == DBNull.Value ? null : Reader["oshopid"].ToString();
            opponent_dianpu_infoExample.oremark1 = Reader["oremark1"] == DBNull.Value ? null : Reader["oremark1"].ToString();
            opponent_dianpu_infoExample.oremark2 = Reader["oremark2"] == DBNull.Value ? null : Reader["oremark2"].ToString();
            opponent_dianpu_infoExample.oremark3 = Reader["oremark3"] == DBNull.Value ? null : Reader["oremark3"].ToString();
            return opponent_dianpu_infoExample;
        }
        #endregion





        #endregion
    }





}

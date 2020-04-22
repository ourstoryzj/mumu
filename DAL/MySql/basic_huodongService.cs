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

    public class basic_huodongService : Ibasic_huodongService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<basic_huodong> SearchAll()
        {
            DBHelper.sqlstr = "select * from basic_huodong ";
            List<basic_huodong> list = new List<basic_huodong>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_huodong Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据hdid,查询一条数据
        /// </summary>
        /// <param name="hdid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public basic_huodong SearchByID(int hdid)
        {
            DBHelper.sqlstr = "select * from basic_huodong where hdid = @hdid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@hdid",hdid)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            basic_huodong Obj = null;
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
        /// <param name="basic_huodong">basic_huodong表实例</param>
        /// <returns>int</returns>
        public int Insert(basic_huodong basic_huodongExample)
        {
            DBHelper.sqlstr = "insert into  basic_huodong (hdone,hdtwo,hddate1,hddate2,hdtype,hdremark,hdname)values(@hdone,@hdtwo,@hddate1,@hddate2,@hdtype,@hdremark,@hdname)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_huodongExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_huodong">basic_huodong表实例</param>
        /// <returns>int</returns>
        public int Update(basic_huodong basic_huodongExample)
        {
            DBHelper.sqlstr = "update basic_huodong set hdone=@hdone,hdtwo=@hdtwo,hddate1=@hddate1,hddate2=@hddate2,hdtype=@hdtype,hdremark=@hdremark,hdname=@hdname where hdid=" + basic_huodongExample.hdid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(basic_huodongExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="hdid">编号</param>
        /// <returns>int</returns>
        public int Delete(int hdid)
        {
            DBHelper.sqlstr = "delete basic_huodong where hdid =@hdid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@hdid",hdid)
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
            string sql1 = "select count(hdid) from basic_huodong where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  hdremark like '%" + key + "%' or  hdname  like '%" + key + "%'  ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and hdtype= '" + state + "' ";

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
        /// <returns>IList<basic_huodong></returns>
        public IList<basic_huodong> Search(int s, int e, string key, string state, string orderby)
        {
            string sql1 = "select   *   from basic_huodong where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  hdremark like '%" + key + "%'  or  hdname  like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and hdtype= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(orderby) ? " order by hdid desc " : " order by " + orderby;
            string sql10 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3  + sql4+ sql10;
            List<basic_huodong> list = new List<basic_huodong>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                basic_huodong Obj = GetByReader(reader);
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
        public static MySqlParameter[] GetSqlParameters(basic_huodong basic_huodongExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();
            if (basic_huodongExample.hdone != 0)
            {
                list_param.Add(new MySqlParameter("@hdone", basic_huodongExample.hdone));
            }
            else
            {
                list_param.Add(new MySqlParameter("@hdone", DBNull.Value));
            }
            if (basic_huodongExample.hdtwo != 0)
            {
                list_param.Add(new MySqlParameter("@hdtwo", basic_huodongExample.hdtwo));
            }
            else
            {
                list_param.Add(new MySqlParameter("@hdtwo", DBNull.Value));
            }
            if (basic_huodongExample.hddate1 != new DateTime() && basic_huodongExample.hddate1 != null)
            {
                list_param.Add(new MySqlParameter("@hddate1", basic_huodongExample.hddate1.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@hddate1", DBNull.Value));
            }
            if (basic_huodongExample.hddate2 != new DateTime() && basic_huodongExample.hddate2 != null)
            {
                list_param.Add(new MySqlParameter("@hddate2", basic_huodongExample.hddate2.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@hddate2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_huodongExample.hdtype))
            {
                list_param.Add(new MySqlParameter("@hdtype", basic_huodongExample.hdtype));
            }
            else
            {
                list_param.Add(new MySqlParameter("@hdtype", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_huodongExample.hdremark))
            {
                list_param.Add(new MySqlParameter("@hdremark", basic_huodongExample.hdremark));
            }
            else
            {
                list_param.Add(new MySqlParameter("@hdremark", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(basic_huodongExample.hdname))
            {
                list_param.Add(new MySqlParameter("@hdname", basic_huodongExample.hdname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@hdname", DBNull.Value));
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
        /// <returns>basic_huodongExample</returns>
        public static basic_huodong GetByReader(MySqlDataReader Reader)
        {
            basic_huodong basic_huodongExample = new basic_huodong();
            basic_huodongExample.hdid = Reader["hdid"] == DBNull.Value ? 0 : (int)Reader["hdid"];
            basic_huodongExample.hdone = Reader["hdone"] == DBNull.Value ? 0 : (int)Reader["hdone"];
            basic_huodongExample.hdtwo = Reader["hdtwo"] == DBNull.Value ? 0 : (int)Reader["hdtwo"];
            basic_huodongExample.hddate1 = Reader["hddate1"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["hddate1"]);
            basic_huodongExample.hddate2 = Reader["hddate2"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["hddate2"]);
            basic_huodongExample.hdtype = Reader["hdtype"] == DBNull.Value ? null : Reader["hdtype"].ToString();
            basic_huodongExample.hdremark = Reader["hdremark"] == DBNull.Value ? null : Reader["hdremark"].ToString();
            basic_huodongExample.hdname = Reader["hdname"] == DBNull.Value ? null : Reader["hdname"].ToString();
            return basic_huodongExample;
        }
        #endregion





        #endregion
    }
 


}

using System;
using System.Collections.Generic;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.MySql
{



    public class keysService : IkeysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<keys> SearchAll()
        {
            DBHelper.sqlstr = "select * from keys ";
            List<keys> list = new List<keys>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                keys Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据kid,查询一条数据
        /// </summary>
        /// <param name="kid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public keys SearchByID(int kid)
        {
            DBHelper.sqlstr = "select * from keys where kid = @kid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@kid",kid)
            };
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            keys Obj = null;
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
        /// <param name="keys">keys表实例</param>
        /// <returns>int</returns>
        public int Insert(keys keysExample)
        {
            DBHelper.sqlstr = "insert into  keys (kname,krenqi,kSSzhanbi,kdianjilv,kSCzhanbi,kgoodsnum,kZTCjiage,kzhuanhualv,kZTCzhanxian,kZTCdianji,kZTCdianjilv,kZTCzhuanhualv,kZTCjunjia,kZTCjingzhengdu,kZTCDY_dianjilv,kZTCDY_zhanxian,kZTCDY_dianji,kZTCDY_zhuanhua,kZTCDY_junjia,ktype,kstate,klevel,kremark1,kremark2,kremark3,kremark4,kremark5,kremark6,kremark7,kremark8,kremark9,kdate,klid)values(@kname,@krenqi,@kSSzhanbi,@kdianjilv,@kSCzhanbi,@kgoodsnum,@kZTCjiage,@kzhuanhualv,@kZTCzhanxian,@kZTCdianji,@kZTCdianjilv,@kZTCzhuanhualv,@kZTCjunjia,@kZTCjingzhengdu,@kZTCDY_dianjilv,@kZTCDY_zhanxian,@kZTCDY_dianji,@kZTCDY_zhuanhua,@kZTCDY_junjia,@ktype,@kstate,@klevel,@kremark1,@kremark2,@kremark3,@kremark4,@kremark5,@kremark6,@kremark7,@kremark8,@kremark9,@kdate,@klid)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(keysExample));

            //DBHelper.sqlstr = "insert into  keys (kname,krenqi,kSSzhanbi,kdianjilv,kSCzhanbi,kgoodsnum,kZTCjiage,kzhuanhualv,kZTCzhanxian,kZTCdianji,kZTCdianjilv,kZTCzhuanhualv,kZTCjunjia,kZTCjingzhengdu,kZTCDY_dianjilv,kZTCDY_zhanxian,kZTCDY_dianji,kZTCDY_zhuanhua,kZTCDY_junjia,ktype,kstate,klevel,kremark1,kremark2,kremark3,kremark4,kremark5,kremark6,kremark7,kremark8,kremark9,kdate,klid)values(" + keysExample.kname + "," + keysExample.krenqi + "," + keysExample.kSSzhanbi + "," + keysExample.kdianjilv + "," + keysExample.kSCzhanbi + "," + keysExample.kgoodsnum + "," + keysExample.kZTCjiage + "," + keysExample.kzhuanhualv + "," + keysExample.kZTCzhanxian + "," + keysExample.kZTCdianji + "," + keysExample.kZTCdianjilv + "," + keysExample.kZTCzhuanhualv + "," + keysExample.kZTCjunjia + "," + keysExample.kZTCjingzhengdu + "," + keysExample.kZTCDY_dianjilv + "," + keysExample.kZTCDY_zhanxian + "," + keysExample.kZTCDY_dianji + "," + keysExample.kZTCDY_zhuanhua + "," + keysExample.kZTCDY_junjia + "," + keysExample.ktype + "," + keysExample.kstate + "," + keysExample.klevel + "," + keysExample.kremark1 + "," + keysExample.kremark2 + "," + keysExample.kremark3 + "," + keysExample.kremark4 + "," + keysExample.kremark5 + "," + keysExample.kremark6 + "," + keysExample.kremark7 + "," + keysExample.kremark8 + "," + keysExample.kremark9 + "," + keysExample.kdate + "," + keysExample.klid + ")";
            //return DBHelper.ExecuteNonQuery();
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="keys">keys表实例</param>
        /// <returns>int</returns>
        public int Update(keys keysExample)
        {
            DBHelper.sqlstr = "update keys set kname=@kname,krenqi=@krenqi,kSSzhanbi=@kSSzhanbi,kdianjilv=@kdianjilv,kSCzhanbi=@kSCzhanbi,kgoodsnum=@kgoodsnum,kZTCjiage=@kZTCjiage,kzhuanhualv=@kzhuanhualv,kZTCzhanxian=@kZTCzhanxian,kZTCdianji=@kZTCdianji,kZTCdianjilv=@kZTCdianjilv,kZTCzhuanhualv=@kZTCzhuanhualv,kZTCjunjia=@kZTCjunjia,kZTCjingzhengdu=@kZTCjingzhengdu,kZTCDY_dianjilv=@kZTCDY_dianjilv,kZTCDY_zhanxian=@kZTCDY_zhanxian,kZTCDY_dianji=@kZTCDY_dianji,kZTCDY_zhuanhua=@kZTCDY_zhuanhua,kZTCDY_junjia=@kZTCDY_junjia,ktype=@ktype,kstate=@kstate,klevel=@klevel,kremark1=@kremark1,kremark2=@kremark2,kremark3=@kremark3,kremark4=@kremark4,kremark5=@kremark5,kremark6=@kremark6,kremark7=@kremark7,kremark8=@kremark8,kremark9=@kremark9,kdate=@kdate,klid=@klid where kid=" + keysExample.kid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(keysExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="kid">编号</param>
        /// <returns>int</returns>
        public int Delete(int kid)
        {
            DBHelper.sqlstr = "delete keys where kid =@kid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@kid",kid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion

        #region DeleteByKLID
        /// <summary>
        /// 根据词库批量删除数据
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        public int DeleteByKLID(int klid)
        {
            DBHelper.sqlstr = "delete keys where klid =@klid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@klid",klid)
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
        public int SearchNum(string key, string state, int id, DateTime startdate, DateTime enddate)
        {
            string sql1 = "select count(kid) from keys where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( kname like '%" + key + "%' or kZTCDY_dianjilv like '%" + key + "%' or kZTCDY_zhanxian like '%" + key + "%' or kZTCDY_dianji like '%" + key + "%' or kZTCDY_zhuanhua like '%" + key + "%' or kZTCDY_junjia like '%" + key + "%' or ktype like '%" + key + "%' or kstate like '%" + key + "%' or klevel like '%" + key + "%' or kremark1 like '%" + key + "%' or kremark2 like '%" + key + "%' or kremark3 like '%" + key + "%' or kremark4 like '%" + key + "%' or kremark5 like '%" + key + "%' or kremark6 like '%" + key + "%' or kremark7 like '%" + key + "%' or kremark8 like '%" + key + "%' or kremark9 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and kstate= '" + state + "' ";//状态字段，无用删除
            string sql4 = id == 0 ? "" : " and klid='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',kdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',kdate)<=0 ";//时间字段，无用删除
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6;
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
        /// <returns>IList<keys></returns>
        public IList<keys> Search(int s, int e, string key, string state, int id, DateTime startdate, DateTime enddate, string orderby)
        {
            string sql1 = "select * from keys where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " ( kname like '%" + key + "%' or kZTCDY_dianjilv like '%" + key + "%' or kZTCDY_zhanxian like '%" + key + "%' or kZTCDY_dianji like '%" + key + "%' or kZTCDY_zhuanhua like '%" + key + "%' or kZTCDY_junjia like '%" + key + "%' or ktype like '%" + key + "%' or kstate like '%" + key + "%' or klevel like '%" + key + "%' or kremark1 like '%" + key + "%' or kremark2 like '%" + key + "%' or kremark3 like '%" + key + "%' or kremark4 like '%" + key + "%' or kremark5 like '%" + key + "%' or kremark6 like '%" + key + "%' or kremark7 like '%" + key + "%' or kremark8 like '%" + key + "%' or kremark9 like '%" + key + "%'  )";//删除无用字段，删除最后一个or
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and kstate= '" + state + "' ";//状态字段，无用删除
            string sql4 = id == 0 ? "" : " and klid='" + id.ToString() + "' ";//Int字段，无用删除
            string sql5 = startdate == new DateTime() ? "" : " and DATEDIFF(D,'" + startdate.ToString("yyyy-MM-dd") + "',kdate)>=0 ";//时间字段，无用删除
            string sql6 = enddate == new DateTime() ? "" : " and DATEDIFF(D,'" + enddate.ToString("yyyy-MM-dd") + "',kdate)<=0 ";//时间字段，无用删除
            string sql7 = string.IsNullOrEmpty(orderby) ? " order by kid desc " : " order by " + orderby;
           // string sql8 = s == 1 ? "" : " and kid not in ( select top " + (s - 1).ToString() + " kid from keys where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + " ) ";
            string sql9 = e == 0 ? " " : " limit " + s + "," + e;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7+ sql9 ;
            List<keys> list = new List<keys>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                keys Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByKlids
        /// <summary>
        /// 根据klid打开选中词库
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<keys> SearchByKlids(List<int> listid)
        {
            DBHelper.sqlstr = "select* from keys where  ";

            foreach (int temp in listid)
            {
                DBHelper.sqlstr += " klid= " + temp.ToString() + "  or ";
            }

            DBHelper.sqlstr = DBHelper.sqlstr.Substring(0, DBHelper.sqlstr.Length - 5);

            List<keys> list = new List<keys>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                keys Obj = GetByReader(reader);
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
        public static MySqlParameter[] GetSqlParameters(keys keysExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(keysExample.kname))
            {
                list_param.Add(new MySqlParameter("@kname", keysExample.kname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kname", DBNull.Value));
            }
            if (keysExample.krenqi != 0)
            {
                list_param.Add(new MySqlParameter("@krenqi", keysExample.krenqi));
            }
            else
            {
                list_param.Add(new MySqlParameter("@krenqi", DBNull.Value));
            }
            if (keysExample.kSSzhanbi != new decimal())
            {
                list_param.Add(new MySqlParameter("@kSSzhanbi", keysExample.kSSzhanbi));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kSSzhanbi", DBNull.Value));
            }
            if (keysExample.kdianjilv != new decimal())
            {
                list_param.Add(new MySqlParameter("@kdianjilv", keysExample.kdianjilv));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kdianjilv", DBNull.Value));
            }
            if (keysExample.kSCzhanbi != new decimal())
            {
                list_param.Add(new MySqlParameter("@kSCzhanbi", keysExample.kSCzhanbi));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kSCzhanbi", DBNull.Value));
            }
            if (keysExample.kgoodsnum != 0)
            {
                list_param.Add(new MySqlParameter("@kgoodsnum", keysExample.kgoodsnum));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kgoodsnum", DBNull.Value));
            }
            if (keysExample.kZTCjiage != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCjiage", keysExample.kZTCjiage));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCjiage", DBNull.Value));
            }
            if (keysExample.kzhuanhualv != new decimal())
            {
                list_param.Add(new MySqlParameter("@kzhuanhualv", keysExample.kzhuanhualv));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kzhuanhualv", DBNull.Value));
            }
            if (keysExample.kZTCzhanxian != 0)
            {
                list_param.Add(new MySqlParameter("@kZTCzhanxian", keysExample.kZTCzhanxian));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCzhanxian", DBNull.Value));
            }
            if (keysExample.kZTCdianji != 0)
            {
                list_param.Add(new MySqlParameter("@kZTCdianji", keysExample.kZTCdianji));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCdianji", DBNull.Value));
            }
            if (keysExample.kZTCdianjilv != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCdianjilv", keysExample.kZTCdianjilv));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCdianjilv", DBNull.Value));
            }
            if (keysExample.kZTCzhuanhualv != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCzhuanhualv", keysExample.kZTCzhuanhualv));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCzhuanhualv", DBNull.Value));
            }
            if (keysExample.kZTCjunjia != new decimal())
            {
                list_param.Add(new MySqlParameter("@kZTCjunjia", keysExample.kZTCjunjia));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCjunjia", DBNull.Value));
            }
            if (keysExample.kZTCjingzhengdu != 0)
            {
                list_param.Add(new MySqlParameter("@kZTCjingzhengdu", keysExample.kZTCjingzhengdu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCjingzhengdu", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kZTCDY_dianjilv))
            {
                list_param.Add(new MySqlParameter("@kZTCDY_dianjilv", keysExample.kZTCDY_dianjilv));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCDY_dianjilv", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kZTCDY_zhanxian))
            {
                list_param.Add(new MySqlParameter("@kZTCDY_zhanxian", keysExample.kZTCDY_zhanxian));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCDY_zhanxian", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kZTCDY_dianji))
            {
                list_param.Add(new MySqlParameter("@kZTCDY_dianji", keysExample.kZTCDY_dianji));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCDY_dianji", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kZTCDY_zhuanhua))
            {
                list_param.Add(new MySqlParameter("@kZTCDY_zhuanhua", keysExample.kZTCDY_zhuanhua));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCDY_zhuanhua", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kZTCDY_junjia))
            {
                list_param.Add(new MySqlParameter("@kZTCDY_junjia", keysExample.kZTCDY_junjia));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kZTCDY_junjia", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.ktype))
            {
                list_param.Add(new MySqlParameter("@ktype", keysExample.ktype));
            }
            else
            {
                list_param.Add(new MySqlParameter("@ktype", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kstate))
            {
                list_param.Add(new MySqlParameter("@kstate", keysExample.kstate));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kstate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.klevel))
            {
                list_param.Add(new MySqlParameter("@klevel", keysExample.klevel));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klevel", DBNull.Value));
            }

            if (keysExample.kremark1 != new decimal())
            {
                list_param.Add(new MySqlParameter("@kremark1", keysExample.kremark1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kremark2))
            {
                list_param.Add(new MySqlParameter("@kremark2", keysExample.kremark2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kremark3))
            {
                list_param.Add(new MySqlParameter("@kremark3", keysExample.kremark3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kremark4))
            {
                list_param.Add(new MySqlParameter("@kremark4", keysExample.kremark4));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark4", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kremark5))
            {
                list_param.Add(new MySqlParameter("@kremark5", keysExample.kremark5));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark5", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kremark6))
            {
                list_param.Add(new MySqlParameter("@kremark6", keysExample.kremark6));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark6", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kremark7))
            {
                list_param.Add(new MySqlParameter("@kremark7", keysExample.kremark7));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark7", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kremark8))
            {
                list_param.Add(new MySqlParameter("@kremark8", keysExample.kremark8));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark8", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(keysExample.kremark9))
            {
                list_param.Add(new MySqlParameter("@kremark9", keysExample.kremark9));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kremark9", DBNull.Value));
            }
            if (keysExample.kdate != new DateTime() && keysExample.kdate != null)
            {
                list_param.Add(new MySqlParameter("@kdate", keysExample.kdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new MySqlParameter("@kdate", DBNull.Value));
            }
            if (keysExample.klid != 0)
            {
                list_param.Add(new MySqlParameter("@klid", keysExample.klid));
            }
            else
            {
                list_param.Add(new MySqlParameter("@klid", DBNull.Value));
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
        /// <returns>keysExample</returns>
        public static keys GetByReader(MySqlDataReader Reader)
        {
            keys keysExample = new keys();
            keysExample.kid = Reader["kid"] == DBNull.Value ? 0 : (int)Reader["kid"];
            keysExample.kname = Reader["kname"] == DBNull.Value ? null : Reader["kname"].ToString();
            keysExample.krenqi = Reader["krenqi"] == DBNull.Value ? 0 : (int)Reader["krenqi"];
            keysExample.kSSzhanbi = Reader["kSSzhanbi"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kSSzhanbi"]);
            keysExample.kdianjilv = Reader["kdianjilv"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kdianjilv"]);
            keysExample.kSCzhanbi = Reader["kSCzhanbi"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kSCzhanbi"]);
            keysExample.kgoodsnum = Reader["kgoodsnum"] == DBNull.Value ? 0 : (int)Reader["kgoodsnum"];
            keysExample.kZTCjiage = Reader["kZTCjiage"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCjiage"]);
            keysExample.kzhuanhualv = Reader["kzhuanhualv"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kzhuanhualv"]);
            keysExample.kZTCzhanxian = Reader["kZTCzhanxian"] == DBNull.Value ? 0 : (int)Reader["kZTCzhanxian"];
            keysExample.kZTCdianji = Reader["kZTCdianji"] == DBNull.Value ? 0 : (int)Reader["kZTCdianji"];
            keysExample.kZTCdianjilv = Reader["kZTCdianjilv"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCdianjilv"]);
            keysExample.kZTCzhuanhualv = Reader["kZTCzhuanhualv"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCzhuanhualv"]);
            keysExample.kZTCjunjia = Reader["kZTCjunjia"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kZTCjunjia"]);
            keysExample.kZTCjingzhengdu = Reader["kZTCjingzhengdu"] == DBNull.Value ? 0 : (int)Reader["kZTCjingzhengdu"];
            keysExample.kZTCDY_dianjilv = Reader["kZTCDY_dianjilv"] == DBNull.Value ? null : Reader["kZTCDY_dianjilv"].ToString();
            keysExample.kZTCDY_zhanxian = Reader["kZTCDY_zhanxian"] == DBNull.Value ? null : Reader["kZTCDY_zhanxian"].ToString();
            keysExample.kZTCDY_dianji = Reader["kZTCDY_dianji"] == DBNull.Value ? null : Reader["kZTCDY_dianji"].ToString();
            keysExample.kZTCDY_zhuanhua = Reader["kZTCDY_zhuanhua"] == DBNull.Value ? null : Reader["kZTCDY_zhuanhua"].ToString();
            keysExample.kZTCDY_junjia = Reader["kZTCDY_junjia"] == DBNull.Value ? null : Reader["kZTCDY_junjia"].ToString();
            keysExample.ktype = Reader["ktype"] == DBNull.Value ? null : Reader["ktype"].ToString();
            keysExample.kstate = Reader["kstate"] == DBNull.Value ? null : Reader["kstate"].ToString();
            keysExample.klevel = Reader["klevel"] == DBNull.Value ? null : Reader["klevel"].ToString();
            keysExample.kremark1 = Reader["kremark1"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kremark1"]);
            keysExample.kremark2 = Reader["kremark2"] == DBNull.Value ? null : Reader["kremark2"].ToString();
            keysExample.kremark3 = Reader["kremark3"] == DBNull.Value ? null : Reader["kremark3"].ToString();
            keysExample.kremark4 = Reader["kremark4"] == DBNull.Value ? null : Reader["kremark4"].ToString();
            keysExample.kremark5 = Reader["kremark5"] == DBNull.Value ? null : Reader["kremark5"].ToString();
            keysExample.kremark6 = Reader["kremark6"] == DBNull.Value ? null : Reader["kremark6"].ToString();
            keysExample.kremark7 = Reader["kremark7"] == DBNull.Value ? null : Reader["kremark7"].ToString();
            keysExample.kremark8 = Reader["kremark8"] == DBNull.Value ? null : Reader["kremark8"].ToString();
            keysExample.kremark9 = Reader["kremark9"] == DBNull.Value ? null : Reader["kremark9"].ToString();
            keysExample.kdate = Reader["kdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["kdate"]);
            keysExample.klid = Reader["klid"] == DBNull.Value ? 0 : (int)Reader["klid"];
            return keysExample;
        }
        #endregion





        #endregion
    }







}

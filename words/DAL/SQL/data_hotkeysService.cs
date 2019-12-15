using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;

namespace DAL
{




    public class data_hotkeysService : Idata_hotkeysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<data_hotkeys> SearchAll()
        {
            DBHelper.sqlstr = "select * from data_hotkeys ";
            List<data_hotkeys> list = new List<data_hotkeys>();
            SqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                data_hotkeys Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据dhid,查询一条数据
        /// </summary>
        /// <param name="dhid"></param>
        /// <returns></returns>
        /*查看是否为视图*/

        public data_hotkeys SearchByID(int dhid)
        {
            DBHelper.sqlstr = "select * from data_hotkeys where dhid = @dhid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@dhid",dhid)
            };
            SqlDataReader reader = DBHelper.ExecuteReader(param);
            data_hotkeys Obj = null;
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
        /// <param name="data_hotkeys">data_hotkeys表实例</param>
        /// <returns>int</returns>
        public int Insert(data_hotkeys data_hotkeysExample)
        {
            DBHelper.sqlstr = "insert into  data_hotkeys (dhdate,dhtypebag,dhtypekey,dhrank,dhkey,dhsearchtimes,dhmall,dhclickrate,dhclicktimes,dhconverrate,dhzhitongche,dhtypebiaosheng,dhxiangguanci,dhremark1,dhremark2,dhremark3,dhremark4)values(@dhdate,@dhtypebag,@dhtypekey,@dhrank,@dhkey,@dhsearchtimes,@dhmall,@dhclickrate,@dhclicktimes,@dhconverrate,@dhzhitongche,@dhtypebiaosheng,@dhxiangguanci,@dhremark1,@dhremark2,@dhremark3,@dhremark4)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(data_hotkeysExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="data_hotkeys">data_hotkeys表实例</param>
        /// <returns>int</returns>
        public int Update(data_hotkeys data_hotkeysExample)
        {
            DBHelper.sqlstr = "update data_hotkeys set dhdate=@dhdate,dhtypebag=@dhtypebag,dhtypekey=@dhtypekey,dhrank=@dhrank,dhkey=@dhkey,dhsearchtimes=@dhsearchtimes,dhmall=@dhmall,dhclickrate=@dhclickrate,dhclicktimes=@dhclicktimes,dhconverrate=@dhconverrate,dhzhitongche=@dhzhitongche,dhtypebiaosheng=@dhtypebiaosheng,dhxiangguanci=@dhxiangguanci,dhremark1=@dhremark1,dhremark2=@dhremark2,dhremark3=@dhremark3,dhremark4=@dhremark4 where dhid=" + data_hotkeysExample.dhid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(data_hotkeysExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dhid"></param>
        /// <returns>int</returns>
        public int Delete(int dhid)
        {
            DBHelper.sqlstr = "delete data_hotkeys where dhid =@dhid";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@dhid",dhid)
            };
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion




        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个SqlParameter数组
        /// </summary>
        /// <returns>SqlParameter[]</returns>
        public static SqlParameter[] GetSqlParameters(data_hotkeys data_hotkeysExample)
        {
            List<SqlParameter> list_param = new List<SqlParameter>();
            if (data_hotkeysExample.dhdate != new DateTime() && data_hotkeysExample.dhdate != null)
            {
                list_param.Add(new SqlParameter("@dhdate", data_hotkeysExample.dhdate.ToString("yyyy-MM-dd")));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhdate", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(data_hotkeysExample.dhtypebag))
            {
                list_param.Add(new SqlParameter("@dhtypebag", data_hotkeysExample.dhtypebag));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhtypebag", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(data_hotkeysExample.dhtypekey))
            {
                list_param.Add(new SqlParameter("@dhtypekey", data_hotkeysExample.dhtypekey));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhtypekey", DBNull.Value));
            }
            if (data_hotkeysExample.dhrank != 0)
            {
                list_param.Add(new SqlParameter("@dhrank", data_hotkeysExample.dhrank));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhrank", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(data_hotkeysExample.dhkey))
            {
                list_param.Add(new SqlParameter("@dhkey", data_hotkeysExample.dhkey));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhkey", DBNull.Value));
            }
            if (data_hotkeysExample.dhsearchtimes != 0)
            {
                list_param.Add(new SqlParameter("@dhsearchtimes", data_hotkeysExample.dhsearchtimes));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhsearchtimes", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(data_hotkeysExample.dhmall))
            {
                list_param.Add(new SqlParameter("@dhmall", data_hotkeysExample.dhmall));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhmall", DBNull.Value));
            }

            if (data_hotkeysExample.dhclickrate != new Double())
            {
                list_param.Add(new SqlParameter("@dhclickrate", data_hotkeysExample.dhclickrate));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhclickrate", DBNull.Value));
            }
            if (data_hotkeysExample.dhclicktimes != 0)
            {
                list_param.Add(new SqlParameter("@dhclicktimes", data_hotkeysExample.dhclicktimes));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhclicktimes", DBNull.Value));
            }


            if (data_hotkeysExample.dhconverrate != new Double())
            {
                list_param.Add(new SqlParameter("@dhconverrate", data_hotkeysExample.dhconverrate));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhconverrate", DBNull.Value));
            }


            if (data_hotkeysExample.dhzhitongche != new Double())
            {
                list_param.Add(new SqlParameter("@dhzhitongche", data_hotkeysExample.dhzhitongche));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhzhitongche", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(data_hotkeysExample.dhtypebiaosheng))
            {
                list_param.Add(new SqlParameter("@dhtypebiaosheng", data_hotkeysExample.dhtypebiaosheng));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhtypebiaosheng", DBNull.Value));
            }
            if (data_hotkeysExample.dhxiangguanci != 0)
            {
                list_param.Add(new SqlParameter("@dhxiangguanci", data_hotkeysExample.dhxiangguanci));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhxiangguanci", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(data_hotkeysExample.dhremark1))
            {
                list_param.Add(new SqlParameter("@dhremark1", data_hotkeysExample.dhremark1));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(data_hotkeysExample.dhremark2))
            {
                list_param.Add(new SqlParameter("@dhremark2", data_hotkeysExample.dhremark2));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(data_hotkeysExample.dhremark3))
            {
                list_param.Add(new SqlParameter("@dhremark3", data_hotkeysExample.dhremark3));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhremark3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(data_hotkeysExample.dhremark4))
            {
                list_param.Add(new SqlParameter("@dhremark4", data_hotkeysExample.dhremark4));
            }
            else
            {
                list_param.Add(new SqlParameter("@dhremark4", DBNull.Value));
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
        /// <returns>data_hotkeysExample</returns>
        public static data_hotkeys GetByReader(SqlDataReader Reader)
        {
            data_hotkeys data_hotkeysExample = new data_hotkeys();
            data_hotkeysExample.dhid = Reader["dhid"] == DBNull.Value ? 0 : (int)Reader["dhid"];
            data_hotkeysExample.dhdate = Reader["dhdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["dhdate"]);
            data_hotkeysExample.dhtypebag = Reader["dhtypebag"] == DBNull.Value ? null : Reader["dhtypebag"].ToString();
            data_hotkeysExample.dhtypekey = Reader["dhtypekey"] == DBNull.Value ? null : Reader["dhtypekey"].ToString();
            data_hotkeysExample.dhrank = Reader["dhrank"] == DBNull.Value ? 0 : (int)Reader["dhrank"];
            data_hotkeysExample.dhkey = Reader["dhkey"] == DBNull.Value ? null : Reader["dhkey"].ToString();
            data_hotkeysExample.dhsearchtimes = Reader["dhsearchtimes"] == DBNull.Value ? 0 : (int)Reader["dhsearchtimes"];
            data_hotkeysExample.dhmall = Reader["dhmall"] == DBNull.Value ? null : Reader["dhmall"].ToString();
            data_hotkeysExample.dhclickrate = Reader["dhclickrate"] == DBNull.Value ? 0 : Convert.ToDouble(Reader["dhclickrate"]);
            data_hotkeysExample.dhclicktimes = Reader["dhclicktimes"] == DBNull.Value ? 0 : (int)Reader["dhclicktimes"];
            data_hotkeysExample.dhconverrate = Reader["dhconverrate"] == DBNull.Value ? 0 : Convert.ToDouble(Reader["dhconverrate"]); ;
            data_hotkeysExample.dhzhitongche = Reader["dhzhitongche"] == DBNull.Value ? 0 : Convert.ToDouble(Reader["dhzhitongche"]); ;
            data_hotkeysExample.dhtypebiaosheng = Reader["dhtypebiaosheng"] == DBNull.Value ? null : Reader["dhtypebiaosheng"].ToString();
            data_hotkeysExample.dhxiangguanci = Reader["dhxiangguanci"] == DBNull.Value ? 0 : (int)Reader["dhxiangguanci"];
            data_hotkeysExample.dhremark1 = Reader["dhremark1"] == DBNull.Value ? null : Reader["dhremark1"].ToString();
            data_hotkeysExample.dhremark2 = Reader["dhremark2"] == DBNull.Value ? null : Reader["dhremark2"].ToString();
            data_hotkeysExample.dhremark3 = Reader["dhremark3"] == DBNull.Value ? null : Reader["dhremark3"].ToString();
            data_hotkeysExample.dhremark4 = Reader["dhremark4"] == DBNull.Value ? null : Reader["dhremark4"].ToString();
            return data_hotkeysExample;
        }
        #endregion





        #endregion
    }






}

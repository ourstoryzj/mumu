﻿using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
{





    //表名称：yh_goodstype
    //实体类名称：yh_goodstypeExample
    //主键：gtid

    public class yh_goodstypeService : Iyh_goodstypeService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<yh_goodstype> SearchAll(bool isall)
        {

            Access.DBHelper.sqlstr = "select * from yh_goodstype " + (isall ? "" : " where gtstate='1' ") + "  order by gtsort asc  ";
            List<yh_goodstype> list = new List<yh_goodstype>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                yh_goodstype Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBygtid
        /// <summary>
        /// 根据gtid,查询一条数据
        /// </summary>
        /// <param name="gtid">商品类型</param>
        /// <returns></returns>
        public yh_goodstype SearchBygtid(int gtid)
        {
            Access.DBHelper.sqlstr = "select * from yh_goodstype where gtid = @gtid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@gtid",gtid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            yh_goodstype Obj = null;
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
        /// <param name="yh_goodstype">yh_goodstype表实例</param>
        /// <returns>int</returns>
        public int Insert(yh_goodstype yh_goodstypeExample)
        {
            Access.DBHelper.sqlstr = "insert into  yh_goodstype (gtanme,gtdate,gtsort,gtstate)values(@gtanme,'" + yh_goodstypeExample.gtdate.ToString() + "',@gtsort,@gtstate)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(yh_goodstypeExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_goodstype">yh_goodstype表实例</param>
        /// <returns>int</returns>
        public int Update(yh_goodstype yh_goodstypeExample)
        {
            Access.DBHelper.sqlstr = "update yh_goodstype set gtanme=@gtanme,gtdate='" + yh_goodstypeExample.gtdate.ToString() + "',gtsort=@gtsort,gtstate=@gtstate where gtid=" + yh_goodstypeExample.gtid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(yh_goodstypeExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gtid">商品类型</param>
        /// <returns>int</returns>
        public int Delete(int gtid)
        {
            Access.DBHelper.sqlstr = "delete from yh_goodstype where gtid =@gtid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@gtid",gtid)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
        }
        #endregion




        #region 公共方法

        #region GetOleDbParameter
        /// <summary>
        /// 根据表,获取一个OleDbParameter数组
        /// </summary>
        /// <returns>OleDbParameter[]</returns>
        public static OleDbParameter[] GetOleDbParameter(yh_goodstype yh_goodstypeExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(yh_goodstypeExample.gtanme))
            {
                list_param.Add(new OleDbParameter("@gtanme", yh_goodstypeExample.gtanme));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gtanme", DBNull.Value));
            }
            if (!string.IsNullOrEmpty(yh_goodstypeExample.gtsort))
            {
                list_param.Add(new OleDbParameter("@gtsort", yh_goodstypeExample.gtsort));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gtsort", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_goodstypeExample.gtstate))
            {
                list_param.Add(new OleDbParameter("@gtstate", yh_goodstypeExample.gtstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@gtstate", DBNull.Value));
            }
            OleDbParameter[] param = new OleDbParameter[list_param.Count];
            int index = 0;
            foreach (OleDbParameter p in list_param)
            {
                param[index] = p;
                index++;
            }
            return param;
        }
        #endregion

        #region GetByReader
        /// <summary>
        /// 从一个OleDbDataReader里读数据
        /// </summary>
        /// <param name="Reader">OleDbDataReader</param>
        /// <returns>yh_goodstypeExample</returns>
        public static yh_goodstype GetByReader(OleDbDataReader Reader)
        {
            yh_goodstype yh_goodstypeExample = new yh_goodstype();
            yh_goodstypeExample.gtanme = Reader["gtanme"] == DBNull.Value ? null : Reader["gtanme"].ToString();
            yh_goodstypeExample.gtdate = Reader["gtdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["gtdate"]);
            yh_goodstypeExample.gtid = Reader["gtid"] == DBNull.Value ? 0 : (int)Reader["gtid"];
            yh_goodstypeExample.gtsort = Reader["gtsort"] == DBNull.Value ? null : Reader["gtsort"].ToString();
            yh_goodstypeExample.gtstate = Reader["gtstate"] == DBNull.Value ? null : Reader["gtstate"].ToString();
            return yh_goodstypeExample;
        }
        #endregion





        #endregion
    }



}

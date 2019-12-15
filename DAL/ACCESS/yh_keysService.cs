using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace DAL.Access
{




    //表名称：yh_keys
    //实体类名称：yh_keysExample
    //主键：kid

    public class yh_keysService : Iyh_keysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<yh_keys> SearchAll()
        {
            Access.DBHelper.sqlstr = "select * from yh_keys ";
            List<yh_keys> list = new List<yh_keys>();
            OleDbDataReader reader = Access.DBHelper.ExecuteReader();
            while (reader.Read())
            {
                yh_keys Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchBykid
        /// <summary>
        /// 根据kid,查询一条数据
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns></returns>
        public yh_keys SearchBykid(int kid)
        {
            Access.DBHelper.sqlstr = "select * from yh_keys where kid = @kid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@kid",kid)
			};
            OleDbDataReader reader = Access.DBHelper.ExecuteReader(param);
            yh_keys Obj = null;
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
        /// <param name="yh_keys">yh_keys表实例</param>
        /// <returns>int</returns>
        public int Insert(yh_keys yh_keysExample)
        {
            Access.DBHelper.sqlstr = "insert into  yh_keys (ckid,k_standby1,k_standby2,k_standby3,kcishu,kdate,kdgbbsscs,kdianjilv,kdianjizhishu,kgoodsnum,kname,kqgbbcjcs,kremark,krenshu,kscdianjizhanbi,ksousuozhanbi,kstate,kzhitongche,kzhuanhualv)values(@ckid,@k_standby1,@k_standby2,@k_standby3,@kcishu,'" + yh_keysExample.kdate.ToString() + "',@kdgbbsscs,@kdianjilv,@kdianjizhishu,@kgoodsnum,@kname,@kqgbbcjcs,@kremark,@krenshu,@kscdianjizhanbi,@ksousuozhanbi,@kstate,@kzhitongche,@kzhuanhualv)";
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(yh_keysExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_keys">yh_keys表实例</param>
        /// <returns>int</returns>
        public int Update(yh_keys yh_keysExample)
        {
            Access.DBHelper.sqlstr = "update yh_keys set ckid=@ckid,k_standby1=@k_standby1,k_standby2=@k_standby2,k_standby3=@k_standby3,kcishu=@kcishu,kdate='" + yh_keysExample.kdate.ToString() + "',kdgbbsscs=@kdgbbsscs,kdianjilv=@kdianjilv,kdianjizhishu=@kdianjizhishu,kgoodsnum=@kgoodsnum,kname=@kname,kqgbbcjcs=@kqgbbcjcs,kremark=@kremark,krenshu=@krenshu,kscdianjizhanbi=@kscdianjizhanbi,ksousuozhanbi=@ksousuozhanbi,kstate=@kstate,kzhitongche=@kzhitongche,kzhuanhualv=@kzhuanhualv where kid=" + yh_keysExample.kid;
            return Access.DBHelper.ExecuteNonQuery(GetOleDbParameter(yh_keysExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        public int Delete(int kid)
        {
            Access.DBHelper.sqlstr = "delete from yh_keys where kid =@kid";
            OleDbParameter[] param = new OleDbParameter[] {
                new OleDbParameter("@kid",kid)
			};
            return Access.DBHelper.ExecuteNonQuery(param);
        }
        #endregion


        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词：查询关键词和备注信息</param>
        /// <param name="ckid">核心关键词：核心关键词ID</param>
        /// <param name="kdgbbsscs1">单个宝贝搜索次数（搜索次数/商品数量）</param>
        /// <param name="kdgbbsscs2">单个宝贝搜索次数（搜索次数/商品数量）</param>
        /// <param name="kdianjilv1">点击率</param>
        /// <param name="kdianjilv2">点击率</param>
        /// <param name="kdianjizhishu1">点击指数</param>
        /// <param name="kdianjizhishu2">点击指数</param>
        /// <param name="kgoodsnum1">商品数量</param>
        /// <param name="kgoodsnum2">商品数量</param>
        /// <param name="kqgbbcjcs1">千个宝贝成交次数（点击指数*转化率/当前宝贝数*1000）</param>
        /// <param name="kqgbbcjcs2">千个宝贝成交次数（点击指数*转化率/当前宝贝数*1000）</param>
        /// <param name="krenshu1">搜索人数</param>
        /// <param name="krenshu2">搜索人数</param>
        /// <param name="kscdianjizhanbi1">点击占比</param>
        /// <param name="kscdianjizhanbi2">点击占比</param>
        /// <param name="ksousuozhanbi1">搜索占比</param>
        /// <param name="ksousuozhanbi2">搜索占比</param>
        /// <param name="kzhitongche1">直通车出价</param>
        /// <param name="kzhitongche2">直通车出价</param>
        /// <param name="kzhuanhualv1">转化率</param>
        /// <param name="kzhuanhualv2">转化率</param>
        /// <param name="kcishu1">搜索次数</param>
        /// <param name="kcishu2">搜索次数</param>
        /// <param name="state">状态</param>
        /// <param name="state2">状态(备用)</param>
        /// <param name="state3">状态(备用)</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <returns></returns>
        public int SearchNum(string key, int ckid, decimal kdgbbsscs1, decimal kdgbbsscs2, decimal kdianjilv1, decimal kdianjilv2, int kdianjizhishu1, int kdianjizhishu2, int kgoodsnum1, int kgoodsnum2, decimal kqgbbcjcs1, decimal kqgbbcjcs2, int krenshu1, int krenshu2, decimal kscdianjizhanbi1, decimal kscdianjizhanbi2, decimal ksousuozhanbi1, decimal ksousuozhanbi2, decimal kzhitongche1, decimal kzhitongche2, decimal kzhuanhualv1, decimal kzhuanhualv2, int kcishu1, int kcishu2, string state, string state2, string state3, DateTime dt1_add, DateTime dt2_add)
        {
            string sql1 = "select count(kid) from yh_keys where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  kname like '%" + key + "%' or  kremark like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and kstate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(state2) ? "" : " and kstate2= '" + state2 + "' ";
            string sql5 = string.IsNullOrEmpty(state3) ? "" : " and kstate3= '" + state3 + "' ";
            string sql6 = dt1_add == new DateTime() ? "" : " and datediff('d','" + dt1_add.ToString() + "',kdate)>=0 ";
            string sql7 = dt2_add == new DateTime() ? "" : " and datediff('d','" + dt2_add.ToString() + "',kdate)<=0 ";
            string sql8 = kdgbbsscs1 == new decimal() ? "" : " and  kdgbbsscs >= " + kdgbbsscs1.ToString();
            string sql9 = kdgbbsscs2 == new decimal() ? "" : " and  kdgbbsscs <= " + kdgbbsscs2.ToString();
            string sql10 = kdianjilv1 == new decimal() ? "" : " and  kdianjilv >= " + kdianjilv1.ToString();
            string sql11 = kdianjilv2 == new decimal() ? "" : " and  kdianjilv <= " + kdianjilv2.ToString();
            string sql12 = kqgbbcjcs1 == new decimal() ? "" : " and  kqgbbcjcs >= " + kqgbbcjcs1.ToString();
            string sql13 = kqgbbcjcs2 == new decimal() ? "" : " and  kqgbbcjcs <= " + kqgbbcjcs2.ToString();
            string sql14 = kscdianjizhanbi1 == new decimal() ? "" : " and  kscdianjizhanbi >= " + kscdianjizhanbi1.ToString();
            string sql15 = kscdianjizhanbi2 == new decimal() ? "" : " and  kscdianjizhanbi <= " + kscdianjizhanbi2.ToString();
            string sql16 = ksousuozhanbi1 == new decimal() ? "" : " and  ksousuozhanbi >= " + ksousuozhanbi1.ToString();
            string sql17 = ksousuozhanbi2 == new decimal() ? "" : " and  ksousuozhanbi <= " + ksousuozhanbi2.ToString();
            string sql18 = kzhitongche1 == new decimal() ? "" : " and  kzhitongche >= " + kzhitongche1.ToString();
            string sql19 = kzhitongche2 == new decimal() ? "" : " and  kzhitongche <= " + kzhitongche2.ToString();
            string sql20 = kzhuanhualv1 == new decimal() ? "" : " and  kzhuanhualv >= " + kzhuanhualv1.ToString();
            string sql21 = kzhuanhualv2 == new decimal() ? "" : " and  kzhuanhualv <= " + kzhuanhualv2.ToString();
            string sql22 = kdianjizhishu1 == 0 ? "" : " and  kdianjizhishu >= " + kdianjizhishu1.ToString();
            string sql23 = kdianjizhishu2 == 0 ? "" : " and  kdianjizhishu <= " + kdianjizhishu2.ToString();
            string sql24 = kgoodsnum1 == 0 ? "" : " and  kgoodsnum >= " + kgoodsnum1.ToString();
            string sql25 = kgoodsnum2 == 0 ? "" : " and  kgoodsnum <= " + kgoodsnum2.ToString();
            string sql26 = krenshu1 == 0 ? "" : " and  krenshu >= " + krenshu1.ToString();
            string sql27 = kcishu2 == 0 ? "" : " and  krenshu <= " + kcishu2.ToString();
            string sql28 = ckid == 0 ? "" : " and  ckid = " + ckid.ToString();
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + sql9 + sql10 + sql11 + sql12 + sql13 + sql14 + sql15 + sql16 + sql17 + sql18 + sql19 + sql20 + sql21 + sql22 + sql23 + sql24 + sql25 + sql26 + sql27 + sql28;
            return Convert.ToInt32(Access.DBHelper.ExecuteScalar());
        }
        #endregion

        #region Search
        /// <summary>
        /// 条件搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词：查询关键词和备注信息</param>
        /// <param name="ckid">核心关键词：核心关键词ID</param>
        /// <param name="kdgbbsscs1">单个宝贝搜索次数（搜索次数/商品数量）</param>
        /// <param name="kdgbbsscs2">单个宝贝搜索次数（搜索次数/商品数量）</param>
        /// <param name="kdianjilv1">点击率</param>
        /// <param name="kdianjilv2">点击率</param>
        /// <param name="kdianjizhishu1">点击指数</param>
        /// <param name="kdianjizhishu2">点击指数</param>
        /// <param name="kgoodsnum1">商品数量</param>
        /// <param name="kgoodsnum2">商品数量</param>
        /// <param name="kqgbbcjcs1">千个宝贝成交次数（点击指数*转化率/当前宝贝数*1000）</param>
        /// <param name="kqgbbcjcs2">千个宝贝成交次数（点击指数*转化率/当前宝贝数*1000）</param>
        /// <param name="krenshu1">搜索人数</param>
        /// <param name="krenshu2">搜索人数</param>
        /// <param name="kscdianjizhanbi1">点击占比</param>
        /// <param name="kscdianjizhanbi2">点击占比</param>
        /// <param name="ksousuozhanbi1">搜索占比</param>
        /// <param name="ksousuozhanbi2">搜索占比</param>
        /// <param name="kzhitongche1">直通车出价</param>
        /// <param name="kzhitongche2">直通车出价</param>
        /// <param name="kzhuanhualv1">转化率</param>
        /// <param name="kzhuanhualv2">转化率</param>
        /// <param name="kcishu1">搜索次数</param>
        /// <param name="kcishu2">搜索次数</param>
        /// <param name="state">状态</param>
        /// <param name="state2">状态(备用)</param>
        /// <param name="state3">状态(备用)</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<yh_keys></returns>
        public IList<yh_keys> Search(int s, int e, string key, int ckid, decimal kdgbbsscs1, decimal kdgbbsscs2, decimal kdianjilv1, decimal kdianjilv2, int kdianjizhishu1, int kdianjizhishu2, int kgoodsnum1, int kgoodsnum2, decimal kqgbbcjcs1, decimal kqgbbcjcs2, int krenshu1, int krenshu2, decimal kscdianjizhanbi1, decimal kscdianjizhanbi2, decimal ksousuozhanbi1, decimal ksousuozhanbi2, decimal kzhitongche1, decimal kzhitongche2, decimal kzhuanhualv1, decimal kzhuanhualv2, int kcishu1, int kcishu2, string state, string state2, string state3, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            string sql1 = "select  top " + (e - s + 1).ToString() + " *   from yh_keys where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  kname like '%" + key + "%' or  kremark like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(state) ? "" : " and kstate= '" + state + "' ";
            string sql4 = string.IsNullOrEmpty(state2) ? "" : " and kstate2= '" + state2 + "' ";
            string sql5 = string.IsNullOrEmpty(state3) ? "" : " and kstate3= '" + state3 + "' ";
            string sql6 = dt1_add == new DateTime() ? "" : " and datediff('d','" + dt1_add.ToString() + "',kdate)>=0 ";
            string sql7 = dt2_add == new DateTime() ? "" : " and datediff('d','" + dt2_add.ToString() + "',kdate)<=0 ";
            string sql8 = kdgbbsscs1 == new decimal() ? "" : " and  kdgbbsscs >= " + kdgbbsscs1.ToString();
            string sql9 = kdgbbsscs2 == new decimal() ? "" : " and  kdgbbsscs <= " + kdgbbsscs2.ToString();
            string sql10 = kdianjilv1 == new decimal() ? "" : " and  kdianjilv >= " + kdianjilv1.ToString();
            string sql11 = kdianjilv2 == new decimal() ? "" : " and  kdianjilv <= " + kdianjilv2.ToString();
            string sql12 = kqgbbcjcs1 == new decimal() ? "" : " and  kqgbbcjcs >= " + kqgbbcjcs1.ToString();
            string sql13 = kqgbbcjcs2 == new decimal() ? "" : " and  kqgbbcjcs <= " + kqgbbcjcs2.ToString();
            string sql14 = kscdianjizhanbi1 == new decimal() ? "" : " and  kscdianjizhanbi >= " + kscdianjizhanbi1.ToString();
            string sql15 = kscdianjizhanbi2 == new decimal() ? "" : " and  kscdianjizhanbi <= " + kscdianjizhanbi2.ToString();
            string sql16 = ksousuozhanbi1 == new decimal() ? "" : " and  ksousuozhanbi >= " + ksousuozhanbi1.ToString();
            string sql17 = ksousuozhanbi2 == new decimal() ? "" : " and  ksousuozhanbi <= " + ksousuozhanbi2.ToString();
            string sql18 = kzhitongche1 == new decimal() ? "" : " and  kzhitongche >= " + kzhitongche1.ToString();
            string sql19 = kzhitongche2 == new decimal() ? "" : " and  kzhitongche <= " + kzhitongche2.ToString();
            string sql20 = kzhuanhualv1 == new decimal() ? "" : " and  kzhuanhualv >= " + kzhuanhualv1.ToString();
            string sql21 = kzhuanhualv2 == new decimal() ? "" : " and  kzhuanhualv <= " + kzhuanhualv2.ToString();
            string sql22 = kdianjizhishu1 == 0 ? "" : " and  kdianjizhishu >= " + kdianjizhishu1.ToString();
            string sql23 = kdianjizhishu2 == 0 ? "" : " and  kdianjizhishu <= " + kdianjizhishu2.ToString();
            string sql24 = kgoodsnum1 == 0 ? "" : " and  kgoodsnum >= " + kgoodsnum1.ToString();
            string sql25 = kgoodsnum2 == 0 ? "" : " and  kgoodsnum <= " + kgoodsnum2.ToString();
            string sql26 = krenshu1 == 0 ? "" : " and  krenshu >= " + krenshu1.ToString();
            string sql27 = kcishu2 == 0 ? "" : " and  krenshu <= " + kcishu2.ToString();
            string sql30 = ckid == 0 ? "" : " and  ckid = " + ckid.ToString();
            string sql28 = string.IsNullOrEmpty(orderby) ? " order by kdate desc,kid asc " : " order by " + orderby;
            string sql29 = s == 1 ? "" : " and kid not in ( select top " + (s - 1).ToString() + " kid from yh_keys where " + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + sql9 + sql10 + sql11 + sql12 + sql13 + sql14 + sql15 + sql16 + sql17 + sql18 + sql19 + sql20 + sql21 + sql22 + sql23 + sql24 + sql25 + sql26 + sql27 + sql30 + sql28 + " ) ";
            Access.DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4 + sql5 + sql6 + sql7 + sql8 + sql9 + sql10 + sql11 + sql12 + sql13 + sql14 + sql15 + sql16 + sql17 + sql18 + sql19 + sql20 + sql21 + sql22 + sql23 + sql24 + sql25 + sql26 + sql27 + sql30 + sql29 + sql28;
            List<yh_keys> list = new List<yh_keys>();
            OleDbDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                yh_keys Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion









        #region 公共方法

        #region GetOleDbParameter
        /// <summary>
        /// 根据表,获取一个OleDbParameter数组
        /// </summary>
        /// <returns>OleDbParameter[]</returns>
        public static OleDbParameter[] GetOleDbParameter(yh_keys yh_keysExample)
        {
            List<OleDbParameter> list_param = new List<OleDbParameter>();
            if (yh_keysExample.ckid != 0)
            {
                list_param.Add(new OleDbParameter("@ckid", yh_keysExample.ckid));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ckid", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_keysExample.k_standby1))
            {
                list_param.Add(new OleDbParameter("@k_standby1", yh_keysExample.k_standby1));
            }
            else
            {
                list_param.Add(new OleDbParameter("@k_standby1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_keysExample.k_standby2))
            {
                list_param.Add(new OleDbParameter("@k_standby2", yh_keysExample.k_standby2));
            }
            else
            {
                list_param.Add(new OleDbParameter("@k_standby2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_keysExample.k_standby3))
            {
                list_param.Add(new OleDbParameter("@k_standby3", yh_keysExample.k_standby3));
            }
            else
            {
                list_param.Add(new OleDbParameter("@k_standby3", DBNull.Value));
            }
            if (yh_keysExample.kcishu != 0)
            {
                list_param.Add(new OleDbParameter("@kcishu", yh_keysExample.kcishu));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kcishu", DBNull.Value));
            }
            if (yh_keysExample.kdgbbsscs != new decimal())
            {
                list_param.Add(new OleDbParameter("@kdgbbsscs", yh_keysExample.kdgbbsscs));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kdgbbsscs", DBNull.Value));
            }
            if (yh_keysExample.kdianjilv != new decimal())
            {
                list_param.Add(new OleDbParameter("@kdianjilv", yh_keysExample.kdianjilv));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kdianjilv", DBNull.Value));
            }
            if (yh_keysExample.kdianjizhishu != 0)
            {
                list_param.Add(new OleDbParameter("@kdianjizhishu", yh_keysExample.kdianjizhishu));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kdianjizhishu", DBNull.Value));
            }
            if (yh_keysExample.kgoodsnum != 0)
            {
                list_param.Add(new OleDbParameter("@kgoodsnum", yh_keysExample.kgoodsnum));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kgoodsnum", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_keysExample.kname))
            {
                list_param.Add(new OleDbParameter("@kname", yh_keysExample.kname));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kname", DBNull.Value));
            }
            if (yh_keysExample.kqgbbcjcs != new decimal())
            {
                list_param.Add(new OleDbParameter("@kqgbbcjcs", yh_keysExample.kqgbbcjcs));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kqgbbcjcs", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_keysExample.kremark))
            {
                list_param.Add(new OleDbParameter("@kremark", yh_keysExample.kremark));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kremark", DBNull.Value));
            }
            if (yh_keysExample.krenshu != 0)
            {
                list_param.Add(new OleDbParameter("@krenshu", yh_keysExample.krenshu));
            }
            else
            {
                list_param.Add(new OleDbParameter("@krenshu", DBNull.Value));
            }
            if (yh_keysExample.kscdianjizhanbi != new decimal())
            {
                list_param.Add(new OleDbParameter("@kscdianjizhanbi", yh_keysExample.kscdianjizhanbi));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kscdianjizhanbi", DBNull.Value));
            }
            if (yh_keysExample.ksousuozhanbi != new decimal())
            {
                list_param.Add(new OleDbParameter("@ksousuozhanbi", yh_keysExample.ksousuozhanbi));
            }
            else
            {
                list_param.Add(new OleDbParameter("@ksousuozhanbi", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(yh_keysExample.kstate))
            {
                list_param.Add(new OleDbParameter("@kstate", yh_keysExample.kstate));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kstate", DBNull.Value));
            }
            if (yh_keysExample.kzhitongche != new decimal())
            {
                list_param.Add(new OleDbParameter("@kzhitongche", yh_keysExample.kzhitongche));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kzhitongche", DBNull.Value));
            }
            if (yh_keysExample.kzhuanhualv != new decimal())
            {
                list_param.Add(new OleDbParameter("@kzhuanhualv", yh_keysExample.kzhuanhualv));
            }
            else
            {
                list_param.Add(new OleDbParameter("@kzhuanhualv", DBNull.Value));
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
        /// <returns>yh_keysExample</returns>
        public static yh_keys GetByReader(OleDbDataReader Reader)
        {
            yh_keys yh_keysExample = new yh_keys();
            yh_keysExample.ckid = Reader["ckid"] == DBNull.Value ? 0 : (int)Reader["ckid"];
            yh_keysExample.k_standby1 = Reader["k_standby1"] == DBNull.Value ? null : Reader["k_standby1"].ToString();
            yh_keysExample.k_standby2 = Reader["k_standby2"] == DBNull.Value ? null : Reader["k_standby2"].ToString();
            yh_keysExample.k_standby3 = Reader["k_standby3"] == DBNull.Value ? null : Reader["k_standby3"].ToString();
            yh_keysExample.kcishu = Reader["kcishu"] == DBNull.Value ? 0 : (int)Reader["kcishu"];
            yh_keysExample.kdate = Reader["kdate"] == DBNull.Value ? new DateTime() : Convert.ToDateTime(Reader["kdate"]);
            yh_keysExample.kdgbbsscs = Reader["kdgbbsscs"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kdgbbsscs"]);
            yh_keysExample.kdianjilv = Reader["kdianjilv"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kdianjilv"]);
            yh_keysExample.kdianjizhishu = Reader["kdianjizhishu"] == DBNull.Value ? 0 : (int)Reader["kdianjizhishu"];
            yh_keysExample.kgoodsnum = Reader["kgoodsnum"] == DBNull.Value ? 0 : (int)Reader["kgoodsnum"];
            yh_keysExample.kid = Reader["kid"] == DBNull.Value ? 0 : (int)Reader["kid"];
            yh_keysExample.kname = Reader["kname"] == DBNull.Value ? null : Reader["kname"].ToString();
            yh_keysExample.kqgbbcjcs = Reader["kqgbbcjcs"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kqgbbcjcs"]);
            yh_keysExample.kremark = Reader["kremark"] == DBNull.Value ? null : Reader["kremark"].ToString();
            yh_keysExample.krenshu = Reader["krenshu"] == DBNull.Value ? 0 : (int)Reader["krenshu"];
            yh_keysExample.kscdianjizhanbi = Reader["kscdianjizhanbi"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kscdianjizhanbi"]);
            yh_keysExample.ksousuozhanbi = Reader["ksousuozhanbi"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["ksousuozhanbi"]);
            yh_keysExample.kstate = Reader["kstate"] == DBNull.Value ? null : Reader["kstate"].ToString();
            yh_keysExample.kzhitongche = Reader["kzhitongche"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kzhitongche"]);
            yh_keysExample.kzhuanhualv = Reader["kzhuanhualv"] == DBNull.Value ? new Decimal() : Convert.ToDecimal(Reader["kzhuanhualv"]);
            return yh_keysExample;
        }
        #endregion





        #endregion
    }



}

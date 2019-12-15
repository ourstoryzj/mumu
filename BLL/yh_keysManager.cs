using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{



    /*BLL*/
    public class yh_keysManager
    {

        private static Iyh_keysService Service = Manager.factory.Createyh_keysService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<yh_keys> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchBykid
        /// <summary>
        /// 根据kid,查询一条数据
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static yh_keys SearchBykid(int kid)
        {
            return Service.SearchBykid(kid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="yh_keys">yh_keys表实例</param>
        /// <returns>int</returns>
        public static int Insert(yh_keys yh_keysExample)
        {
            return Service.Insert(yh_keysExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_keys">yh_keys表实例</param>
        /// <returns>int</returns>
        public static int Update(yh_keys yh_keysExample)
        {
            return Service.Update(yh_keysExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        public static int Delete(int kid)
        {
            return Service.Delete(kid);
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
        public static int SearchNum(string key, int ckid, decimal kdgbbsscs1, decimal kdgbbsscs2, decimal kdianjilv1, decimal kdianjilv2, int kdianjizhishu1, int kdianjizhishu2, int kgoodsnum1, int kgoodsnum2, decimal kqgbbcjcs1, decimal kqgbbcjcs2, int krenshu1, int krenshu2, decimal kscdianjizhanbi1, decimal kscdianjizhanbi2, decimal ksousuozhanbi1, decimal ksousuozhanbi2, decimal kzhitongche1, decimal kzhitongche2, decimal kzhuanhualv1, decimal kzhuanhualv2, int kcishu1, int kcishu2, string state, string state2, string state3, DateTime dt1_add, DateTime dt2_add)
        {
            return Service.SearchNum(key, ckid, kdgbbsscs1, kdgbbsscs2, kdianjilv1, kdianjilv2, kdianjizhishu1, kdianjizhishu2, kgoodsnum1, kgoodsnum2, kqgbbcjcs1, kqgbbcjcs2, krenshu1, krenshu2, kscdianjizhanbi1, kscdianjizhanbi2, ksousuozhanbi1, ksousuozhanbi2, kzhitongche1, kzhitongche2, kzhuanhualv1, kzhuanhualv2, kcishu1, kcishu2, state, state2, state3, dt1_add, dt2_add);
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
        public static IList<yh_keys> Search(int s, int e, string key, int ckid, decimal kdgbbsscs1, decimal kdgbbsscs2, decimal kdianjilv1, decimal kdianjilv2, int kdianjizhishu1, int kdianjizhishu2, int kgoodsnum1, int kgoodsnum2, decimal kqgbbcjcs1, decimal kqgbbcjcs2, int krenshu1, int krenshu2, decimal kscdianjizhanbi1, decimal kscdianjizhanbi2, decimal ksousuozhanbi1, decimal ksousuozhanbi2, decimal kzhitongche1, decimal kzhitongche2, decimal kzhuanhualv1, decimal kzhuanhualv2, int kcishu1, int kcishu2, string state, string state2, string state3, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            return Service.Search(s, e, key, ckid, kdgbbsscs1, kdgbbsscs2, kdianjilv1, kdianjilv2, kdianjizhishu1, kdianjizhishu2, kgoodsnum1, kgoodsnum2, kqgbbcjcs1, kqgbbcjcs2, krenshu1, krenshu2, kscdianjizhanbi1, kscdianjizhanbi2, ksousuozhanbi1, ksousuozhanbi2, kzhitongche1, kzhitongche2, kzhuanhualv1, kzhuanhualv2, kcishu1, kcishu2, state, state2, state3, dt1_add, dt2_add, orderby);
        }
        #endregion


    }







}

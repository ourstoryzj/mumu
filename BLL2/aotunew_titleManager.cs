using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL2
{
    /*BLL*/
    public class aotunew_titleManager
    {

        private static Iaotunew_titleService Service = Manager1.factory.Createaotunew_titleService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<aotunew_title> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据atid,查询一条数据
        /// </summary>
        /// <param name="atid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static aotunew_title SearchByID(int atid)
        {
            return Service.SearchByID(atid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="aotunew_title">aotunew_title表实例</param>
        /// <returns>int</returns>
        public static int Insert(aotunew_title aotunew_titleExample)
        {
            return Service.Insert(aotunew_titleExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="aotunew_title">aotunew_title表实例</param>
        /// <returns>int</returns>
        public static int Update(aotunew_title aotunew_titleExample)
        {
            return Service.Update(aotunew_titleExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="atid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int atid)
        {
            return Service.Delete(atid);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state">状态 空:不查,1:启用,2:禁用</param>
        /// <param name="dt1_add">添加商品起始时间</param>
        /// <param name="dt2_add">添加商品结束时间</param>
        /// <returns>int</returns>
        public static int SearchNum(string key, string type1, string type2, DateTime dt1_add, DateTime dt2_add)
        {
            return Service.SearchNum(key, type1, type2, dt1_add, dt2_add);
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
        /// <param name="state">状态 空:不查,1:启用,2:禁用</param>
        /// <param name="dt1_add">添加起始时间</param>
        /// <param name="dt2_add">添加结束时间</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<yh_zaoci></returns>
        public static IList<aotunew_title> Search(int s, int e, string key, string type1, string type2, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            return Service.Search(s, e, key, type1, type2, dt1_add, dt2_add, orderby);
        }
        #endregion

    }




}

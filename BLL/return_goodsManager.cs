using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{
    /*BLL*/
    public class return_goodsManager
    {

        private static Ireturn_goodsService Service = Manager.factory.Createreturn_goodsService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<return_goods> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据rgid,查询一条数据
        /// </summary>
        /// <param name="rgid">退货编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static return_goods SearchByID(int rgid)
        {
            return Service.SearchByID(rgid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="return_goods">return_goods表实例</param>
        /// <returns>int</returns>
        public static int Insert(return_goods return_goodsExample)
        {
            return Service.Insert(return_goodsExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="return_goods">return_goods表实例</param>
        /// <returns>int</returns>
        public static int Update(return_goods return_goodsExample)
        {
            return Service.Update(return_goodsExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="rgid">退货编号</param>
        /// <returns>int</returns>
        public static int Delete(int rgid)
        {
            return Service.Delete(rgid);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 根据条件查询全部数据总条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="date1">起始时间</param>
        /// <param name="date2">结束时间</param>
        /// <returns>int</returns>
        public static int SearchNum(string key, string cid, DateTime date1, DateTime date2)
        {
            return Service.SearchNum(key,cid, date1, date2);
        }
        #endregion


        #region Search
        /// <summary>
        /// 根据条件查询全部数据
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="date1">起始时间</param>
        /// <param name="date2">结束时间</param>
        /// <returns>IList<return_goods></returns>
        public static IList<return_goods> Search(int s, int e, string key, string cid, DateTime date1, DateTime date2)
        {
            return Service.Search(s, e, key,cid, date1, date2);
        }
        #endregion

    }

}

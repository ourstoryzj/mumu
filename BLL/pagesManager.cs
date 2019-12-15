using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{

    /*BLL*/
    public class pagesManager
    {

        private static IpagesService Service = Manager.factory.CreatepagesService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<pages> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据pid,查询一条数据
        /// </summary>
        /// <param name="pid">页面编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static pages SearchByID(int pid)
        {
            return Service.SearchByID(pid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="pages">pages表实例</param>
        /// <returns>int</returns>
        public static int Insert(pages pagesExample)
        {
            return Service.Insert(pagesExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="pages">pages表实例</param>
        /// <returns>int</returns>
        public static int Update(pages pagesExample)
        {
            return Service.Update(pagesExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pid">页面编号</param>
        /// <returns>int</returns>
        public static int Delete(int pid)
        {
            return Service.Delete(pid);
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
        public static int SearchNum(string key, string state, int ptid, DateTime date1, DateTime date2)
        {
            return Service.SearchNum(key, state, ptid, date1, date2);
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
        /// <returns>IList<pages></returns>
        public static IList<pages> Search(int s, int e, string key, string state, int ptid, DateTime date1, DateTime date2)
        {
            return Service.Search(s, e, key, state, ptid, date1, date2);
        }
        #endregion

    }

}

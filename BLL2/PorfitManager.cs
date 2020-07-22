using Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL2
{
    /*BLL*/
    public class PorfitManager
    {

        private static IPorfitService Service = Manager1.factory.CreatePorfitService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<Porfit> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据pid,查询一条数据
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static Porfit SearchByID(int pid)
        {
            return Service.SearchByID(pid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="Porfit">Porfit表实例</param>
        /// <returns>int</returns>
        public static int Insert(Porfit PorfitExample)
        {
            return Service.Insert(PorfitExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Porfit">Porfit表实例</param>
        /// <returns>int</returns>
        public static int Update(Porfit PorfitExample)
        {
            return Service.Update(PorfitExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pid"></param>
        /// <returns>int</returns>
        public static int Delete(int pid)
        {
            return Service.Delete(pid);
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
        public static int SearchNum(string key, string state, int id, DateTime startdate, DateTime enddate)
        {
            return Service.SearchNum(key, state, id, startdate, enddate);
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
        /// <returns>IList<Porfit></returns>
        public static IList<Porfit> Search(int s, int e, string key,  DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, startdate, enddate, orderby);
        }
        #endregion

    }
}

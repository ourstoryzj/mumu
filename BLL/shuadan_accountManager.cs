using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using IDAL;

namespace BLL
{
    /*BLL*/
    public class shuadan_accountManager
    {

        private static Ishuadan_accountService Service = Manager.factory.Createshuadan_accountService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shuadan_account> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据sdaid,查询一条数据
        /// </summary>
        /// <param name="sdaid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static shuadan_account SearchByID(int sdaid)
        {
            return Service.SearchByID(sdaid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan_account">shuadan_account表实例</param>
        /// <returns>int</returns>
        public static int Insert(shuadan_account shuadan_accountExample)
        {
            return Service.Insert(shuadan_accountExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_account">shuadan_account表实例</param>
        /// <returns>int</returns>
        public static int Update(shuadan_account shuadan_accountExample)
        {
            return Service.Update(shuadan_accountExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdaid"></param>
        /// <returns>int</returns>
        public static int Delete(int sdaid)
        {
            return Service.Delete(sdaid);
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
        /// <returns>IList<shuadan_account></returns>
        public static IList<shuadan_account> Search(int s, int e, string key, string state, int id, DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, state, id, startdate, enddate, orderby);
        }
        #endregion

    }
}

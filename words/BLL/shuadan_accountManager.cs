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

        #region SearchBysdaid
        /// <summary>
        /// 根据sdaid,查询一条数据
        /// </summary>
        /// <param name="sdaid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static shuadan_account SearchBysdaid(int sdaid)
        {
            return Service.SearchBysdaid(sdaid);
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
        /// <param name="sdaid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int sdaid)
        {
            return Service.Delete(sdaid);
        }
        #endregion


        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static int SearchNum(string key, string state, string state_phone, DateTime startdate, DateTime enddate)
        {
            return Service.SearchNum(key, state, state_phone, startdate, enddate);
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public static IList<shuadan_account> Search(int s, int e, string key, string state, string state_phone, DateTime startdate, DateTime enddate, string top)
        {
            return Service.Search(s, e, key, state, state_phone, startdate, enddate, top);
        }
        #endregion


        #region SearchPhone
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shuadan_account> SearchPhone(string top, int num)
        {
            DateTime date1 = DateTime.Now.AddDays(-num);
            DateTime date2 = DateTime.Now;
            return Service.SearchPhone(top, date1, date2);
        }
        #endregion

        #region SearchPhone
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shuadan_account> SearchPhone(string top, DateTime date1, DateTime date2)
        {
            return Service.SearchPhone(top, date1, date2);
        }
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL2
{
    /*BLL*/
    public class shouhouManager
    {

        private static IshouhouService Service = Manager1.factory.CreateshouhouService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shouhou> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByshid
        /// <summary>
        /// 根据shid,查询一条数据
        /// </summary>
        /// <param name="shid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static shouhou SearchByshid(int shid)
        {
            return Service.SearchByshid(shid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shouhou">shouhou表实例</param>
        /// <returns>int</returns>
        public static int Insert(shouhou shouhouExample)
        {
            return Service.Insert(shouhouExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shouhou">shouhou表实例</param>
        /// <returns>int</returns>
        public static int Update(shouhou shouhouExample)
        {
            return Service.Update(shouhouExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="shid"></param>
        /// <returns>int</returns>
        public static int Delete(int shid)
        {
            return Service.Delete(shid);
        }
        #endregion



        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static int SearchNum(string key, int dpid, DateTime start, DateTime end, string state)
        {
            return Service.SearchNum(key, dpid, start, end, state);
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="dpid">店铺ID</param>
        /// <param name="start">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="state">状态</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public static IList<shouhou> Search(int s, int e, string key, int dpid, DateTime start, DateTime end, string state, string orderby)
        {
            return Service.Search(s, e, key, dpid, start, end, state, orderby);
        }
        #endregion

        #region get_sdnum
        /// <summary>
        /// 随机生成批号
        /// </summary>
        /// <returns></returns>
        public static string get_sdnum()
        {
            string res = "sd";
            Random random = new Random(10000);
            res = res + DateTime.Now.ToString("yyyyMMddhhmm") + random.Next(1000, 9999);
            return res;
        }
        #endregion

    }




}

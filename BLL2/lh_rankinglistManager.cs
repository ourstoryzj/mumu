using Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL2
{
    /*BLL*/
    public class lh_rankinglistManager
    {

        private static Ilh_rankinglistService Service = Manager1.factory.Createlh_rankinglistService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<lh_rankinglist> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据rid,查询一条数据
        /// </summary>
        /// <param name="rid">排行榜id</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static lh_rankinglist SearchByID(int rid)
        {
            return Service.SearchByID(rid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="lh_rankinglist">lh_rankinglist表实例</param>
        /// <returns>int</returns>
        public static int Insert(lh_rankinglist lh_rankinglistExample)
        {
            return Service.Insert(lh_rankinglistExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="lh_rankinglist">lh_rankinglist表实例</param>
        /// <returns>int</returns>
        public static int Update(lh_rankinglist lh_rankinglistExample)
        {
            return Service.Update(lh_rankinglistExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 先删除关键词然后删除排行榜
        /// </summary>
        /// <param name="rid">排行榜id</param>
        /// <returns>int</returns>
        public static int Delete(int rid)
        {
            //先删除关键词
            BLL2.lh_keydataManager.DeleteByRid(rid);
            //然后删除排行榜
            return Service.Delete(rid);
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
        /// <returns>IList<lh_rankinglist></returns>
        public static IList<lh_rankinglist> Search(int s, int e, string key, string state, int id, DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, state, id, startdate, enddate, orderby);
        }
        #endregion

        #region DeleteByHid
        /// <summary>
        /// 根据行业删除关键词，先删除关键词然后删除排行榜
        /// </summary>
        /// <param name="rid">排行榜id</param>
        /// <returns>int</returns>
        public static int DeleteByHid(int hid)
        {
            //先删除关键词
            BLL2.lh_keydataManager.DeleteByHid(hid);
            //然后删除排行榜
            return Service.DeleteByHid(hid);
        }
        #endregion

    }

}

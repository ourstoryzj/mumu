using Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL2
{
    /*BLL*/
    public class subway_goodsManager
    {

        private static Isubway_goodsService Service = Manager1.factory.Createsubway_goodsService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<subway_goods> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据sgid,查询一条数据
        /// </summary>
        /// <param name="sgid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static subway_goods SearchByID(int sgid)
        {
            return Service.SearchByID(sgid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="subway_goods">subway_goods表实例</param>
        /// <returns>int</returns>
        public static int Insert(subway_goods subway_goodsExample)
        {
            return Service.Insert(subway_goodsExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="subway_goods">subway_goods表实例</param>
        /// <returns>int</returns>
        public static int Update(subway_goods subway_goodsExample)
        {
            return Service.Update(subway_goodsExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sgid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int sgid)
        {
            return Service.Delete(sgid);
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
        public static int SearchNum(string key, string state, string sgcampaignid, DateTime startdate, DateTime enddate)
        {
            return Service.SearchNum( key, state, sgcampaignid, startdate, enddate);
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
        /// <returns>IList<subway_goods></returns>
        public static IList<subway_goods> Search(int s, int e, string key, string state, string sgcampaignid, DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, state, sgcampaignid, startdate, enddate, orderby);
        }
        #endregion

    }



}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL2
{
    /*BLL*/
    public class fanxianManager
    {

        private static IfanxianService Service = Manager1.factory.CreatefanxianService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<fanxian> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByfx_id
        /// <summary>
        /// 根据fx_id,查询一条数据
        /// </summary>
        /// <param name="fx_id"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static fanxian SearchByfx_id(int fx_id)
        {
            return Service.SearchByfx_id(fx_id);
        }
        #endregion

        #region SearchSum
        /// <summary>
        /// 查询全部数据总金额
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static double SearchSum()
        {
            return Service.SearchSum();
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="fanxian">fanxian表实例</param>
        /// <returns>int</returns>
        public static int Insert(fanxian fanxianExample)
        {
            return Service.Insert(fanxianExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="fanxian">fanxian表实例</param>
        /// <returns>int</returns>
        public static int Update(fanxian fanxianExample)
        {
            return Service.Update(fanxianExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fx_id"></param>
        /// <returns>int</returns>
        public static int Delete(int fx_id)
        {
            return Service.Delete(fx_id);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static int SearchNum(string key, string state, int dpid, DateTime startdate, DateTime enddate, DateTime startdate2, DateTime enddate2)
        {
            return Service.SearchNum(key, state, dpid, startdate, enddate, startdate2, enddate2);
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
        public static IList<fanxian> Search(int s, int e, string key, string state, int dpid, DateTime startdate, DateTime enddate, DateTime startdate2, DateTime enddate2, string orderby)
        {
            return Service.Search(s, e, key, state, dpid, startdate, enddate, startdate2, enddate2, orderby);
        }
        #endregion

        #region SearchLast_FanxianDate
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public static fanxian SearchLast_FanxianDate()
        {
            return Service.SearchLast_FanxianDate();
        }
        #endregion

    }


}

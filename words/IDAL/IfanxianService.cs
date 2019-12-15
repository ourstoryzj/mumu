using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IfanxianService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<fanxian> SearchAll();
        #endregion

        #region SearchByfx_id
        /// <summary>
        /// 根据fx_id,查询一条数据
        /// </summary>
        /// <param name="fx_id"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        fanxian SearchByfx_id(int fx_id);
        #endregion

        #region SearchSum
        /// <summary>
        /// 查询全部数据总金额
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        double SearchSum();
         
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="fanxian">fanxian表实例</param>
        /// <returns>int</returns>
        int Insert(fanxian fanxianExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="fanxian">fanxian表实例</param>
        /// <returns>int</returns>
        int Update(fanxian fanxianExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="fx_id"></param>
        /// <returns>int</returns>
        int Delete(int fx_id);
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        int SearchNum(string key, string state, int dpid, DateTime startdate, DateTime enddate, DateTime startdate2, DateTime enddate2);
        
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
        IList<fanxian> Search(int s, int e, string key, string state, int dpid, DateTime startdate, DateTime enddate, DateTime startdate2, DateTime enddate2, string orderby);
      
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
        fanxian SearchLast_FanxianDate();
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IshouhouService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<shouhou> SearchAll();
        #endregion

        #region SearchByshid
        /// <summary>
        /// 根据shid,查询一条数据
        /// </summary>
        /// <param name="shid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        shouhou SearchByshid(int shid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shouhou">shouhou表实例</param>
        /// <returns>int</returns>
        int Insert(shouhou shouhouExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shouhou">shouhou表实例</param>
        /// <returns>int</returns>
        int Update(shouhou shouhouExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="shid"></param>
        /// <returns>int</returns>
        int Delete(int shid);
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        int SearchNum(string key, int dpid, DateTime start, DateTime end, string state);
       
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
        IList<shouhou> Search(int s, int e, string key, int dpid, DateTime start, DateTime end, string state, string orderby);
        
        #endregion
    }
}

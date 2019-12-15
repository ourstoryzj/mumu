using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Ireturn_goodsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<return_goods> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据rgid,查询一条数据
        /// </summary>
        /// <param name="rgid">退货编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        return_goods SearchByID(int rgid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="return_goods">return_goods表实例</param>
        /// <returns>int</returns>
        int Insert(return_goods return_goodsExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="return_goods">return_goods表实例</param>
        /// <returns>int</returns>
        int Update(return_goods return_goodsExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="rgid">退货编号</param>
        /// <returns>int</returns>
        int Delete(int rgid);
        #endregion

        #region SearchNum
        /// <summary>
        /// 根据条件查询全部数据总条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="date1">起始时间</param>
        /// <param name="date2">结束时间</param>
        /// <returns>int</returns>
        int SearchNum(string key, string cid, DateTime date1, DateTime date2);
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
        /// <returns>IList<return_goods></returns>
        IList<return_goods> Search(int s, int e, string key, string cid, DateTime date1, DateTime date2);
        #endregion


    }
}

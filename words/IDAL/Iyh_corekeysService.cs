using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Iyh_corekeysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<yh_corekeys> SearchAll();
        #endregion

        #region SearchByckid
        /// <summary>
        /// 根据ckid,查询一条数据
        /// </summary>
        /// <param name="ckid">核心关键词ID</param>
        /// <returns></returns>
        /*查看是否为视图*/
        yh_corekeys SearchByckid(int ckid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="yh_corekeys">yh_corekeys表实例</param>
        /// <returns>int</returns>
        int Insert(yh_corekeys yh_corekeysExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_corekeys">yh_corekeys表实例</param>
        /// <returns>int</returns>
        int Update(yh_corekeys yh_corekeysExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ckid">核心关键词ID</param>
        /// <returns>int</returns>
        int Delete(int ckid);
        #endregion


        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state">状态 空:不查,1:启用,2:禁用</param>
        /// <param name="dt1_add">添加商品起始时间</param>
        /// <param name="dt2_add">添加商品结束时间</param>
        /// <returns>int</returns>
        int SearchNum(string key, int gt, string state, DateTime dt1_add, DateTime dt2_add);
        
        #endregion

        #region Search
        /// <summary>
        /// 条件搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state">状态 空:不查,1:启用,2:禁用</param>
        /// <param name="dt1_add">添加商品起始时间</param>
        /// <param name="dt2_add">添加商品结束时间</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<goods></returns>
        IList<yh_corekeys> Search(int s, int e, string key, int gt, string state, DateTime dt1_add, DateTime dt2_add, string orderby);
        
        #endregion
    }
}

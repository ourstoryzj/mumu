using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Iwanggong_dianpuService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<wanggong_dianpu> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据wid,查询一条数据
        /// </summary>
        /// <param name="wid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        wanggong_dianpu SearchByID(int wid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="wanggong_dianpu">wanggong_dianpu表实例</param>
        /// <returns>int</returns>
        int Insert(wanggong_dianpu wanggong_dianpuExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="wanggong_dianpu">wanggong_dianpu表实例</param>
        /// <returns>int</returns>
        int Update(wanggong_dianpu wanggong_dianpuExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="wid">编号</param>
        /// <returns>int</returns>
        int Delete(int wid);
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        int SearchNum(string key, string state, DateTime begin, DateTime end);
        
        #endregion

        #region Search
        /// <summary>
        /// 高级搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="orderby">排序方式</param>
        /// <returns></returns>
        IList<wanggong_dianpu> Search(int s, int e, string key, string state, DateTime begin, DateTime end, string orderby);
        
        #endregion

        #region SearchLastOne
        /// <summary>
        /// 查询时间排序最后一条店铺信息
        /// </summary>
        /// <returns></returns>
        wanggong_dianpu SearchLastOne();
         
        #endregion
    }
}

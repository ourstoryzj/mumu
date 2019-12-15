using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Iopponent_dianpu_infoService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<opponent_dianpu_info> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据odiid,查询一条数据
        /// </summary>
        /// <param name="odiid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        opponent_dianpu_info SearchByID(int odiid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="opponent_dianpu_info">opponent_dianpu_info表实例</param>
        /// <returns>int</returns>
        int Insert(opponent_dianpu_info opponent_dianpu_infoExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="opponent_dianpu_info">opponent_dianpu_info表实例</param>
        /// <returns>int</returns>
        int Update(opponent_dianpu_info opponent_dianpu_infoExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="odiid">编号</param>
        /// <returns>int</returns>
        int Delete(int odiid);
        #endregion



        #region SearchNum
        /// <summary>
        /// 高级搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="caijidate">最后采集时间</param>
        /// <returns>int</returns>
        int SearchNum(string key, string shopid, string caijidate);
        #endregion


        #region Search
        /// <summary>
        /// 高级搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束为止</param>
        /// <param name="key">关键词</param>
        /// <param name="dpid">店铺ID</param>
        /// <param name="caijidate">最后采集时间</param>
        /// <param name="orderby">排序方式</param>
        /// <returns>IList<opponent_dianpu_info></returns>
        IList<opponent_dianpu_info> Search(int s, int e, string key, string shopid, string caijidate, string orderby);
        
        #endregion


    }
}

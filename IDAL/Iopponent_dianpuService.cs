using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Iopponent_dianpuService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<opponent_dianpu> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据oid,查询一条数据
        /// </summary>
        /// <param name="oid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        opponent_dianpu SearchByID(int oid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="opponent_dianpu">opponent_dianpu表实例</param>
        /// <returns>int</returns>
        int Insert(opponent_dianpu opponent_dianpuExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="opponent_dianpu">opponent_dianpu表实例</param>
        /// <returns>int</returns>
        int Update(opponent_dianpu opponent_dianpuExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oid">编号</param>
        /// <returns>int</returns>
        int Delete(int oid);
        #endregion



        #region SearchNum
        /// <summary>
        /// 高级搜索数量
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        int SearchNum(string key);

        #endregion

        #region Search
        /// <summary>
        /// 高级搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束为止</param>
        /// <param name="key">关键词</param>
        /// <param name="orderby">排序</param>
        /// <returns>IList<opponent_dianpu></returns>
        IList<opponent_dianpu> Search(int s, int e, string key, string orderby);

        #endregion

        #region SearchLastOne
        /// <summary>
        /// 获取最后一条信息
        /// </summary>
        /// <param name="oid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        opponent_dianpu SearchLastOne();

        #endregion

    }
}

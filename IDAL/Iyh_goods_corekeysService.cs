using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Iyh_goods_corekeysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<yh_goods_corekeys> SearchAll();
        #endregion

        #region SearchBygcid
        /// <summary>
        /// 根据gcid,查询一条数据
        /// </summary>
        /// <param name="gcid">关联表ID</param>
        /// <returns></returns>
        /*查看是否为视图*/
        yh_goods_corekeys SearchBygcid(int gcid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="yh_goods_corekeys">yh_goods_corekeys表实例</param>
        /// <returns>int</returns>
        int Insert(yh_goods_corekeys yh_goods_corekeysExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_goods_corekeys">yh_goods_corekeys表实例</param>
        /// <returns>int</returns>
        int Update(yh_goods_corekeys yh_goods_corekeysExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gcid">关联表ID</param>
        /// <returns>int</returns>
        int Delete(int gcid);
        #endregion
    }
}

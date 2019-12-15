using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Iyh_goods_keysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<yh_goods_keys> SearchAll();
        #endregion

        #region SearchBygkid
        /// <summary>
        /// 根据gkid,查询一条数据
        /// </summary>
        /// <param name="gkid">商品-黄金关键词ID</param>
        /// <returns></returns>
        /*查看是否为视图*/
        yh_goods_keys SearchBygkid(int gkid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="yh_goods_keys">yh_goods_keys表实例</param>
        /// <returns>int</returns>
        int Insert(yh_goods_keys yh_goods_keysExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_goods_keys">yh_goods_keys表实例</param>
        /// <returns>int</returns>
        int Update(yh_goods_keys yh_goods_keysExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gkid">商品-黄金关键词ID</param>
        /// <returns>int</returns>
        int Delete(int gkid);
        #endregion
    }
}

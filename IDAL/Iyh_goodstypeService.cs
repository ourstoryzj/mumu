using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Iyh_goodstypeService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<yh_goodstype> SearchAll(bool isall);
        #endregion

        #region SearchBygtid
        /// <summary>
        /// 根据gtid,查询一条数据
        /// </summary>
        /// <param name="gtid">商品类型</param>
        /// <returns></returns>
        /*查看是否为视图*/
        yh_goodstype SearchBygtid(int gtid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="yh_goodstype">yh_goodstype表实例</param>
        /// <returns>int</returns>
        int Insert(yh_goodstype yh_goodstypeExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_goodstype">yh_goodstype表实例</param>
        /// <returns>int</returns>
        int Update(yh_goodstype yh_goodstypeExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gtid">商品类型</param>
        /// <returns>int</returns>
        int Delete(int gtid);
        #endregion
    }
}

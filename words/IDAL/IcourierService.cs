using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IcourierService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<courier> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据cid,查询一条数据
        /// </summary>
        /// <param name="cid">快递编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        courier SearchByID(int cid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="courier">courier表实例</param>
        /// <returns>int</returns>
        int Insert(courier courierExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="courier">courier表实例</param>
        /// <returns>int</returns>
        int Update(courier courierExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid">快递编号</param>
        /// <returns>int</returns>
        int Delete(int cid);
        #endregion

        

    }
}

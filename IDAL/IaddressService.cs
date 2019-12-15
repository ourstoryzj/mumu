using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IaddressService
    {
        #region Search
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<address> SearchRND(string num);

        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        int SearchNum(string key, string state);

        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索(高效率分页查询)
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        IList<address> Search(int s, int e, string key, string state, string _top);

        #endregion

        #region SearchByaid
        /// <summary>
        /// 根据主键,查询一条数据
        /// </summary>
        /// <param name="主键"></param>
        /// <returns></returns>
        address SearchByaid(int aid);

        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="address">address表实例</param>
        /// <returns>int</returns>
        int Insert(address addressExample);

        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="address">address表实例</param>
        /// <returns>int</returns>
        int Update(address addressExample);

        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="主键"></param>
        /// <returns>int</returns>
        int Delete(int aid);

        #endregion
    }
}

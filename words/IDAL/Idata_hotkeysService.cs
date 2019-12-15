using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Idata_hotkeysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<data_hotkeys> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据dhid,查询一条数据
        /// </summary>
        /// <param name="dhid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        data_hotkeys SearchByID(int dhid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="data_hotkeys">data_hotkeys表实例</param>
        /// <returns>int</returns>
        int Insert(data_hotkeys data_hotkeysExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="data_hotkeys">data_hotkeys表实例</param>
        /// <returns>int</returns>
        int Update(data_hotkeys data_hotkeysExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dhid"></param>
        /// <returns>int</returns>
        int Delete(int dhid);
        #endregion
    }
}

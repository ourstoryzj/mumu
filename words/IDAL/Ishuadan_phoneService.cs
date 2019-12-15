using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Ishuadan_phoneService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<shuadan_phone> SearchAll();
        #endregion

        #region SearchBysdpid
        /// <summary>
        /// 根据sdpid,查询一条数据
        /// </summary>
        /// <param name="sdpid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        shuadan_phone SearchBysdpid(int sdpid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan_phone">shuadan_phone表实例</param>
        /// <returns>int</returns>
        int Insert(shuadan_phone shuadan_phoneExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_phone">shuadan_phone表实例</param>
        /// <returns>int</returns>
        int Update(shuadan_phone shuadan_phoneExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdpid"></param>
        /// <returns>int</returns>
        int Delete(int sdpid);
        #endregion
    }
}

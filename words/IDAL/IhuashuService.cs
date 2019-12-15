using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IhuashuService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<huashu> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据hid,查询一条数据
        /// </summary>
        /// <param name="hid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        huashu SearchByID(int hid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="huashu">huashu表实例</param>
        /// <returns>int</returns>
        int Insert(huashu huashuExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="huashu">huashu表实例</param>
        /// <returns>int</returns>
        int Update(huashu huashuExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="hid"></param>
        /// <returns>int</returns>
        int Delete(int hid);
        #endregion
    }
}

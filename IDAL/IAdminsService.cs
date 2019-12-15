using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IAdminsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<Admins> SearchAll();
        #endregion

        #region SearchByaid
        /// <summary>
        /// 根据aid,查询一条数据
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        Admins SearchByaid(int aid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="Admins">Admins表实例</param>
        /// <returns>int</returns>
        int Insert(Admins AdminsExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Admins">Admins表实例</param>
        /// <returns>int</returns>
        int Update(Admins AdminsExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="aid"></param>
        /// <returns>int</returns>
        int Delete(int aid);
        #endregion

        #region searchByAcc
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        Admins searchByAcc(string acc);
         
        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IUsersService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<Users> SearchAll();
        #endregion

        #region SearchById
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        Users SearchById(int Id);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="Users">Users表实例</param>
        /// <returns>int</returns>
        int Insert(Users UsersExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Users">Users表实例</param>
        /// <returns>int</returns>
        int Update(Users UsersExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>int</returns>
        int Delete(int Id);
        #endregion

        #region searchByAcc
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        Users searchByAcc(string acc);
       
        #endregion
    }
}

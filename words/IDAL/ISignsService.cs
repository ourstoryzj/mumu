using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface ISignsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<Signs> SearchAll();
        #endregion

        #region SearchById
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        Signs SearchById(int Id);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="Signs">Signs表实例</param>
        /// <returns>int</returns>
        int Insert(Signs SignsExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Signs">Signs表实例</param>
        /// <returns>int</returns>
        int Update(Signs SignsExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>int</returns>
        int Delete(int Id);
        #endregion

        #region searchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        int searchNum(string key, DateTime start, DateTime end, int uid, int state, int type);
      
        #endregion

        #region search
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<Signs> search(int s, int e, string key, DateTime start, DateTime end, int uid, int state, int type, string orderby);
        
        #endregion

    }
}

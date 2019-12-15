using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IkeysService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<keys> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据kid,查询一条数据
        /// </summary>
        /// <param name="kid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        keys SearchByID(int kid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="keys">keys表实例</param>
        /// <returns>int</returns>
        int Insert(keys keysExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="keys">keys表实例</param>
        /// <returns>int</returns>
        int Update(keys keysExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="kid">编号</param>
        /// <returns>int</returns>
        int Delete(int kid);
        #endregion

        #region DeleteByKLID
        /// <summary>
        /// 根据词库批量删除数据
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        int DeleteByKLID(int klid);

        #endregion


        #region SearchNum
        /// <summary>
        /// 查询数据条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="id">int字段</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns>IList</returns>
        int SearchNum(string key, string state, int id, DateTime startdate, DateTime enddate);

        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="id">int字段</param>
        /// <param name="startdate">起始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序</param>
        /// <returns>IList<keys></returns>
        IList<keys> Search(int s, int e, string key, string state, int id, DateTime startdate, DateTime enddate, string orderby);

        #endregion

        #region SearchByKlids
        /// <summary>
        /// 根据klid打开选中词库
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<keys> SearchByKlids(List<int> listid);
         
        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IPorfitService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<Porfit> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据pid,查询一条数据
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        Porfit SearchByID(int pid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="Porfit">Porfit表实例</param>
        /// <returns>int</returns>
        int Insert(Porfit PorfitExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Porfit">Porfit表实例</param>
        /// <returns>int</returns>
        int Update(Porfit PorfitExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="pid"></param>
        /// <returns>int</returns>
        int Delete(int pid);
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
        /// <returns>IList<Porfit></returns>
        IList<Porfit> Search(int s, int e, string key,  DateTime startdate, DateTime enddate, string orderby);

        #endregion





    }
}

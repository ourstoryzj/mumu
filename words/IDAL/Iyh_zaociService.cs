using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Iyh_zaociService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<yh_zaoci> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据zid,查询一条数据
        /// </summary>
        /// <param name="zid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        yh_zaoci SearchByID(int zid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="yh_zaoci">yh_zaoci表实例</param>
        /// <returns>int</returns>
        int Insert(yh_zaoci yh_zaociExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_zaoci">yh_zaoci表实例</param>
        /// <returns>int</returns>
        int Update(yh_zaoci yh_zaociExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="zid">编号</param>
        /// <returns>int</returns>
        int Delete(int zid);
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
        /// <returns>IList<yh_zaoci></returns>
        IList<yh_zaoci> Search(int s, int e, string key, string state, int id, DateTime startdate, DateTime enddate, string orderby);

        #endregion





    }
}

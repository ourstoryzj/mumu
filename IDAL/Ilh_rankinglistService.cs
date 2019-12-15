using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Ilh_rankinglistService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<lh_rankinglist> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据rid,查询一条数据
        /// </summary>
        /// <param name="rid">排行榜id</param>
        /// <returns></returns>
        /*查看是否为视图*/
        lh_rankinglist SearchByID(int rid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="lh_rankinglist">lh_rankinglist表实例</param>
        /// <returns>int</returns>
        int Insert(lh_rankinglist lh_rankinglistExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="lh_rankinglist">lh_rankinglist表实例</param>
        /// <returns>int</returns>
        int Update(lh_rankinglist lh_rankinglistExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="rid">排行榜id</param>
        /// <returns>int</returns>
        int Delete(int rid);
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
        /// <returns>IList<lh_rankinglist></returns>
        IList<lh_rankinglist> Search(int s, int e, string key, string state, int id, DateTime startdate, DateTime enddate, string orderby);

        #endregion

        #region DeleteByHid
        /// <summary>
        /// 根据行业删除关键词
        /// </summary>
        /// <param name="rid">排行榜id</param>
        /// <returns>int</returns>
        int DeleteByHid(int hid);
         
        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Ilh_keydataService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<lh_keydata> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据kid,查询一条数据
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns></returns>
        /*查看是否为视图*/
        lh_keydata SearchByID(int kid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="lh_keydata">lh_keydata表实例</param>
        /// <returns>int</returns>
        int Insert(lh_keydata lh_keydataExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="lh_keydata">lh_keydata表实例</param>
        /// <returns>int</returns>
        int Update(lh_keydata lh_keydataExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        int Delete(int kid);
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
        int SearchNum(string key, string state, int hid, int rid, DateTime startdate, DateTime enddate);

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
        /// <returns>IList<lh_keydata></returns>
        IList<lh_keydata> Search(int s, int e, string key, string state, int hid, int rid, DateTime startdate, DateTime enddate, string orderby);

        #endregion


        #region DeleteByRid
        /// <summary>
        /// 删除排行榜的所有关键词
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        int DeleteByRid(int rid);

        #endregion

        #region DeleteByDate
        /// <summary>
        /// 根据日期删除关键词
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        int DeleteByDate(DateTime dt);

        #endregion

        #region DeleteByHid
        /// <summary>
        /// 根据行业删除关键词
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        int DeleteByHid(int hid);
       
        #endregion


    }
}

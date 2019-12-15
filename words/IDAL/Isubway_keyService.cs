using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Isubway_keyService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<subway_key> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据skid,查询一条数据
        /// </summary>
        /// <param name="skid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        subway_key SearchByID(int skid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="subway_key">subway_key表实例</param>
        /// <returns>int</returns>
        int Insert(subway_key subway_keyExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="subway_key">subway_key表实例</param>
        /// <returns>int</returns>
        int Update(subway_key subway_keyExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="skid">编号</param>
        /// <returns>int</returns>
        int Delete(int skid);
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
        int SearchNum(string key, string state, int sgid, string tag, string skmakeprice, DateTime startdate, DateTime enddate);

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
        /// <returns>IList<subway_key></returns>
        IList<subway_key> Search(int s, int e, string key, string state, int sgid, string tag, string skmakeprice, DateTime startdate, DateTime enddate, string orderby);
        
        #endregion





    }
}

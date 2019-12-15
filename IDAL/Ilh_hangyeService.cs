using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Ilh_hangyeService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<lh_hangye> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据hid,查询一条数据
        /// </summary>
        /// <param name="hid">行业ID</param>
        /// <returns></returns>
        /*查看是否为视图*/
        lh_hangye SearchByID(int hid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="lh_hangye">lh_hangye表实例</param>
        /// <returns>int</returns>
        int Insert(lh_hangye lh_hangyeExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="lh_hangye">lh_hangye表实例</param>
        /// <returns>int</returns>
        int Update(lh_hangye lh_hangyeExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="hid">行业ID</param>
        /// <returns>int</returns>
        int Delete(int hid);
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
        int SearchNum(string key, string state,  DateTime startdate, DateTime enddate);

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
        /// <returns>IList<lh_hangye></returns>
        IList<lh_hangye> Search(int s, int e, string key, string state,DateTime startdate, DateTime enddate, string orderby);

        #endregion





    }
}

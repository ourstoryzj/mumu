using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Iwanggong_goodsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<wanggong_goods> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据wgid,查询一条数据
        /// </summary>
        /// <param name="wgid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        wanggong_goods SearchByID(int wgid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="wanggong_goods">wanggong_goods表实例</param>
        /// <returns>int</returns>
        int Insert(wanggong_goods wanggong_goodsExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="wanggong_goods">wanggong_goods表实例</param>
        /// <returns>int</returns>
        int Update(wanggong_goods wanggong_goodsExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="wgid">编号</param>
        /// <returns>int</returns>
        int Delete(int wgid);
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
        int SearchNum(string key, int wid, DateTime startdate, DateTime enddate);
         
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
        /// <returns>IList<wanggong_goods></returns>
        IList<wanggong_goods> Search(int s, int e, string key, int wid, DateTime startdate, DateTime enddate, string orderby);
         
         
        #endregion
    }
}

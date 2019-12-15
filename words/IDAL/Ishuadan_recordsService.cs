using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Ishuadan_recordsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<shuadan_records> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据sdid,查询一条数据
        /// </summary>
        /// <param name="sdid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        shuadan_records SearchByID(int sdid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan_records">shuadan_records表实例</param>
        /// <returns>int</returns>
        int Insert(shuadan_records shuadan_recordsExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_records">shuadan_records表实例</param>
        /// <returns>int</returns>
        int Update(shuadan_records shuadan_recordsExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdid"></param>
        /// <returns>int</returns>
        int Delete(int sdid);
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
        int SearchNum(string key, string state, string state_kongbao, string state_fahuo, string state_shoucai, DateTime startdate, DateTime enddate);
         
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="s">起始位置1</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">店铺类型</param>
        /// <param name="state_kongbao">空包状态</param>
        /// <param name="state_fahuo">发货状态</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序方式</param>
        /// <returns></returns>
        IList<shuadan_records> Search(int s, int e, string key, string state, string state_kongbao, string state_fahuo, string state_shoucai, DateTime startdate, DateTime enddate, string orderby);
        
        #endregion

        #region SearchWeiFaHuo
        /// <summary>
        /// 查询未发货信息
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<shuadan_records> SearchWeiFaHuo(string t);

        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="s">起始位置1</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">店铺类型</param>
        /// <param name="state_kongbao">空包状态</param>
        /// <param name="state_fahuo">发货状态</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="orderby">排序方式</param>
        /// <returns></returns>
        IList<shuadan_records> Search(int s, int e, string key, string state, string orderstate, string state_kongbao, string state_shoucai, string state_fahuo, DateTime startdate, DateTime enddate, string orderby);
         
        #endregion

    }
}

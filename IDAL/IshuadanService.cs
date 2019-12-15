using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IshuadanService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<shuadan> SearchAll();
        #endregion

        #region SearchBysdid
        /// <summary>
        /// 根据sdid,查询一条数据
        /// </summary>
        /// <param name="sdid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        shuadan SearchBysdid(int sdid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan">shuadan表实例</param>
        /// <returns>int</returns>
        int Insert(shuadan shuadanExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan">shuadan表实例</param>
        /// <returns>int</returns>
        int Update(shuadan shuadanExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdid">编号</param>
        /// <returns>int</returns>
        int Delete(int sdid);
        #endregion

        #region SearchNum
        /// <summary>
        /// 根据条件查询全部数据总条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="gid">商品ID</param>
        /// <param name="aid">账号ID</param>
        /// <param name="state">刷单状态 1正常 2作废</param>
        /// <param name="state_send">发货状态 1未发货 2已发货</param>
        /// <param name="state_pingjia">评价状态 1未评价 2已评价</param>
        /// <param name="date1">刷单时间</param>
        /// <param name="date2">刷单时间</param>
        /// <param name="date_send1">发货时间</param>
        /// <param name="date_send2">发货时间</param>
        /// <param name="date_pingjia1">评价时间</param>
        /// <param name="date_pingjia2">评价时间</param>
        /// <returns>int</returns>
        int SearchNum(string key, int gid, int aid, string state, string state_send, string state_pingjia, DateTime date1, DateTime date2, DateTime date_send1, DateTime date_send2, DateTime date_pingjia1, DateTime date_pingjia2);

        #endregion


        #region Search
        /// <summary>
        /// 根据条件查询全部数据
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="gid">商品ID</param>
        /// <param name="aid">账号ID</param>
        /// <param name="state">刷单状态 1正常 2作废</param>
        /// <param name="state_send">发货状态 1未发货 2已发货</param>
        /// <param name="state_pingjia">评价状态 1未评价 2已评价</param>
        /// <param name="date1">刷单时间</param>
        /// <param name="date2">刷单时间</param>
        /// <param name="date_send1">发货时间</param>
        /// <param name="date_send2">发货时间</param>
        /// <param name="date_pingjia1">评价时间</param>
        /// <param name="date_pingjia2">评价时间</param>
        /// <param name="_top">查询数量</param>
        /// <returns>IList<shuadan></returns>
        IList<shuadan> Search(int s, int e, string key, int gid, int aid, string state, string state_send, string state_pingjia, DateTime date1, DateTime date2, DateTime date_send1, DateTime date_send2, DateTime date_pingjia1, DateTime date_pingjia2, string _top);

        #endregion


    }
}

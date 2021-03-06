﻿using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Ibasic_goodsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<basic_goods> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据bgid,查询一条数据
        /// </summary>
        /// <param name="bgid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        basic_goods SearchByID(int bgid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="basic_goods">basic_goods表实例</param>
        /// <returns>int</returns>
        int Insert(basic_goods basic_goodsExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_goods">basic_goods表实例</param>
        /// <returns>int</returns>
        int Update(basic_goods basic_goodsExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bgid">编号</param>
        /// <returns>int</returns>
        int Delete(int bgid);
        #endregion




        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="opid">订单计划编号</param>
        /// <param name="hdid">活动编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="state">状态</param>
        /// <param name="bgkey">是否重点</param>
        /// <param name="dt1_up">上架时间</param>
        /// <param name="dt2_up">上架时间</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <returns></returns>
        int SearchNum(string key, int opid, int hdid, int dpid, string state, string bgkey, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add);

        #endregion

        #region Search
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        /// <param name="key"></param>
        /// <param name="opid"></param>
        /// <param name="hdid"></param>
        /// <param name="dpid"></param>
        /// <param name="state"></param>
        /// <param name="bgkey"></param>
        /// <param name="dt1_up"></param>
        /// <param name="dt2_up"></param>
        /// <param name="dt1_add"></param>
        /// <param name="dt2_add"></param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_goods></returns>
        IList<basic_goods> Search(int s, int e, string key, int opid, int hdid, int dpid, string state, string bgkey, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add, string orderby);

        #endregion



    }
}

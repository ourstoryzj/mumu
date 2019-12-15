using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{

    /*IDAL*/
    public interface Ibasic_order_planService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<basic_order_plan> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据opid,查询一条数据
        /// </summary>
        /// <param name="opid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        basic_order_plan SearchByID(int opid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="basic_order_plan">basic_order_plan表实例</param>
        /// <returns>int</returns>
        int Insert(basic_order_plan basic_order_planExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_order_plan">basic_order_plan表实例</param>
        /// <returns>int</returns>
        int Update(basic_order_plan basic_order_planExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="opid">编号</param>
        /// <returns>int</returns>
        int Delete(int opid);
        #endregion


        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <returns>int</returns>
        int SearchNum(string key, string state);
        
        #endregion

        #region Search
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="s">开始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_order_plan></returns>
          IList<basic_order_plan> Search(int s, int e, string key, string state, string orderby);
        
        #endregion

    }
   


  
}

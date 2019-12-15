using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Ibasic_order_recordService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<basic_order_record> SearchAll();
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据orid,查询一条数据
        /// </summary>
        /// <param name="orid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        basic_order_record SearchByID(int orid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="basic_order_record">basic_order_record表实例</param>
        /// <returns>int</returns>
        int Insert(basic_order_record basic_order_recordExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_order_record">basic_order_record表实例</param>
        /// <returns>int</returns>
        int Update(basic_order_record basic_order_recordExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="orid">编号</param>
        /// <returns>int</returns>
        int Delete(int orid);
        #endregion



        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="bgid">商品编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="gkid">关键词编号</param>
        /// <param name="ormaijiaxiu">状态</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <returns></returns>
        int SearchNum(string key, int bgid, int dpid, int gkid, string ormaijiaxiu, string state, DateTime dt1_add, DateTime dt2_add);

        #endregion

        #region Search
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="s">开始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="bgid">商品编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="gkid">关键词编号</param>
        /// <param name="ormaijiaxiu">状态</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_order_record></returns>
        IList<basic_order_record> Search(int s, int e, string key, int bgid, int dpid, int gkid, string ormaijiaxiu, string state, DateTime dt1_add, DateTime dt2_add, string orderby);

        #endregion


    }
}

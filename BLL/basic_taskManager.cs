using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{
    /*BLL*/
    public class basic_taskManager
    {

        private static Ibasic_taskService Service = new DAL.basic_taskService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<basic_task> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据btid,查询一条数据
        /// </summary>
        /// <param name="btid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static basic_task SearchByID(int btid)
        {
            return Service.SearchByID(btid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="basic_task">basic_task表实例</param>
        /// <returns>int</returns>
        public static int Insert(basic_task basic_taskExample)
        {
            return Service.Insert(basic_taskExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_task">basic_task表实例</param>
        /// <returns>int</returns>
        public static int Update(basic_task basic_taskExample)
        {
            return Service.Update(basic_taskExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="btid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int btid)
        {
            return Service.Delete(btid);
        }
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
        public static int SearchNum(string key, string state,  DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add)
        {
            return Service.SearchNum(key, state, dt1_up, dt2_up, dt1_add, dt2_add);
        }
        #endregion

        #region Search
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="s">开始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="opid">补单计划编号</param>
        /// <param name="hdid">活动编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="state">状态 1是 2否</param>
        /// <param name="bgkey">知否重点 1是 2否</param>
        /// <param name="dt1_up">上架时间</param>
        /// <param name="dt2_up">上架时间2</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间2</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_goods></returns>
        public static IList<basic_task> Search(int s, int e, string key, string state, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            return Service.Search(s, e, key, state, dt1_up, dt2_up, dt1_add, dt2_add, orderby);
        }
        #endregion

        #region Search
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="s">开始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="opid">补单计划编号</param>
        /// <param name="hdid">活动编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="state">状态 1是 2否</param>
        /// <param name="chongfu">是否重复每日每月每年</param>
        /// <param name="dt1_up">上架时间</param>
        /// <param name="dt2_up">上架时间2</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间2</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_goods></returns>
        public static IList<basic_task> Search(int s, int e, string key, string state, string chongfu, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            return Service.Search(s, e, key, state, chongfu, dt1_up, dt2_up, dt1_add, dt2_add, orderby);
        }
        #endregion




    }




}

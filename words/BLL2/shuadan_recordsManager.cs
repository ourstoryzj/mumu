using Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL2
{
    /*BLL*/
    public class shuadan_recordsManager
    {

        private static Ishuadan_recordsService Service = Manager1.factory.Createshuadan_recordsService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shuadan_records> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据sdid,查询一条数据
        /// </summary>
        /// <param name="sdid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static shuadan_records SearchByID(int sdid)
        {
            return Service.SearchByID(sdid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan_records">shuadan_records表实例</param>
        /// <returns>int</returns>
        public static int Insert(shuadan_records shuadan_recordsExample)
        {
            //判断是否已经存在如果已经有了则不保存
            if (!string.IsNullOrEmpty(shuadan_recordsExample.sdorderid))
            {
                int count = SearchNum(shuadan_recordsExample.sdorderid, "", "", "", "", new DateTime(), new DateTime());
                if (count > 0)
                {
                    return 0;
                }
            }

            return Service.Insert(shuadan_recordsExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_records">shuadan_records表实例</param>
        /// <returns>int</returns>
        public static int Update(shuadan_records shuadan_recordsExample)
        {
            return Service.Update(shuadan_recordsExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdid"></param>
        /// <returns>int</returns>
        public static int Delete(int sdid)
        {
            return Service.Delete(sdid);
        }
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
        public static int SearchNum(string key, string state, string state_kongbao, string state_fahuo, string state_shoucai, DateTime startdate, DateTime enddate)
        {
            return Service.SearchNum(key, state, state_kongbao, state_fahuo, state_shoucai, startdate, enddate);
        }
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
        public static IList<shuadan_records> Search(int s, int e, string key, string state, string state_kongbao, string state_shoucai, string state_fahuo, DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, state, state_kongbao, state_fahuo, state_shoucai, startdate, enddate, orderby);
        }
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
        public static IList<shuadan_records> Search(int s, int e, string key, string state, string orderstate, string state_kongbao, string state_shoucai, string state_fahuo, DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, state, orderstate, state_kongbao, state_fahuo, state_shoucai, startdate, enddate, orderby);
        }
        #endregion

        #region SearchWeiFaHuo
        /// <summary>
        /// 查询未发货信息
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shuadan_records> SearchWeiFaHuo(string t)
        {
            return Service.SearchWeiFaHuo(t);
        }
        #endregion
    }

}

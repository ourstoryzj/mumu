using Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL2
{
    /*BLL*/
    public class lh_hangyeManager
    {

        private static Ilh_hangyeService Service = Manager1.factory.Createlh_hangyeService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<lh_hangye> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据hid,查询一条数据
        /// </summary>
        /// <param name="hid">行业ID</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static lh_hangye SearchByID(int hid)
        {
            return Service.SearchByID(hid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="lh_hangye">lh_hangye表实例</param>
        /// <returns>int</returns>
        public static int Insert(lh_hangye lh_hangyeExample)
        {
            return Service.Insert(lh_hangyeExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="lh_hangye">lh_hangye表实例</param>
        /// <returns>int</returns>
        public static int Update(lh_hangye lh_hangyeExample)
        {
            return Service.Update(lh_hangyeExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="hid">行业ID</param>
        /// <returns>int</returns>
        public static int Delete(int hid)
        {
            return Service.Delete(hid);
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
        public static int SearchNum(string key, string state,  DateTime startdate, DateTime enddate)
        {
            return Service.SearchNum(key, state,startdate, enddate);
        }
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
        public static IList<lh_hangye> Search(int s, int e, string key, string state,  DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, state,startdate, enddate, orderby);
        }
        #endregion

    }
}

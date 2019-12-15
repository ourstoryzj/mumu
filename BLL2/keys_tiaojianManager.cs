using System;
using System.Collections.Generic;
using IDAL;
using Entity;

namespace BLL2
{



    /*BLL*/
    public class keys_tiaojianManager
    {

        private static Ikeys_tiaojianService Service = Manager1.factory.Createkeys_tiaojianService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<keys_tiaojian> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据ktid,查询一条数据
        /// </summary>
        /// <param name="ktid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static keys_tiaojian SearchByID(int ktid)
        {
            return Service.SearchByID(ktid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="keys_tiaojian">keys_tiaojian表实例</param>
        /// <returns>int</returns>
        public static int Insert(keys_tiaojian keys_tiaojianExample)
        {
            return Service.Insert(keys_tiaojianExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="keys_tiaojian">keys_tiaojian表实例</param>
        /// <returns>int</returns>
        public static int Update(keys_tiaojian keys_tiaojianExample)
        {
            return Service.Update(keys_tiaojianExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ktid"></param>
        /// <returns>int</returns>
        public static int Delete(int ktid)
        {
            return Service.Delete(ktid);
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
        public static int SearchNum(string key, string state, int id, string level, DateTime startdate, DateTime enddate)
        {
            return Service.SearchNum(key, state, id, level, startdate, enddate);
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
        /// <returns>IList<keys_tiaojian></returns>
        public static IList<keys_tiaojian> Search(int s, int e, string key, string state, int id, string level, DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, state, id, level, startdate, enddate, orderby);
        }
        #endregion

    }




}

using Entity;
using IDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL2
{
    /*BLL*/
    public class subway_keyManager
    {

        private static Isubway_keyService Service = Manager1.factory.Createsubway_keyService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<subway_key> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据skid,查询一条数据
        /// </summary>
        /// <param name="skid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static subway_key SearchByID(int skid)
        {
            return Service.SearchByID(skid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="subway_key">subway_key表实例</param>
        /// <returns>int</returns>
        public static int Insert(subway_key subway_keyExample)
        {
            return Service.Insert(subway_keyExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="subway_key">subway_key表实例</param>
        /// <returns>int</returns>
        public static int Update(subway_key subway_keyExample)
        {
            return Service.Update(subway_keyExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="skid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int skid)
        {
            return Service.Delete(skid);
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
        public static int SearchNum(string key, string state, int sgid, string tag, string skmakeprice, DateTime startdate, DateTime enddate)
        {
            return Service.SearchNum(key, state, sgid, tag, skmakeprice, startdate, enddate);
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
        /// <returns>IList<subway_key></returns>
        public static IList<subway_key> Search(int s, int e, string key, string state, int sgid, string tag, string skmakeprice, DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, state, sgid, tag, skmakeprice, startdate, enddate, orderby);
        }
        #endregion

    }


}

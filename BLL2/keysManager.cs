using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL2
{
    /*BLL*/
    public class keysManager
    {

        private static IkeysService Service = Manager1.factory.CreatekeysService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<keys> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据kid,查询一条数据
        /// </summary>
        /// <param name="kid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static keys SearchByID(int kid)
        {
            return Service.SearchByID(kid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="keys">keys表实例</param>
        /// <returns>int</returns>
        public static int Insert(keys keysExample)
        {
            return Service.Insert(keysExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="keys">keys表实例</param>
        /// <returns>int</returns>
        public static int Update(keys keysExample)
        {
            return Service.Update(keysExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="kid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int kid)
        {
            return Service.Delete(kid);
        }
        #endregion

        #region DeleteByKLID
        /// <summary>
        /// 根据词库批量删除数据
        /// </summary>
        /// <param name="kid">关键词ID</param>
        /// <returns>int</returns>
        public static int DeleteByKLID(int klid)
        {
            return Service.DeleteByKLID(klid);
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
        public static int SearchNum(string key, string state, int id, DateTime startdate, DateTime enddate)
        {
            return Service.SearchNum(key, state, id, startdate, enddate);
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
        /// <returns>IList<keys></returns>
        public static IList<keys> Search(int s, int e, string key, string state, int id, DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, state, id, startdate, enddate, orderby);
        }
        #endregion

        #region SearchByKlids
        /// <summary>
        /// 根据klid打开选中词库
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<keys> SearchByKlids(List<int> listid)
        {
            return Service.SearchByKlids(listid);
        }
        #endregion

    }





}

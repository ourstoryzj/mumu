using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{
    /*BLL*/
    public class BasicManager
    {

        private static IBasicService Service = Manager.factory.CreateBasicService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<Basic> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchById
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static Basic SearchById(int Id)
        {
            return Service.SearchById(Id);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="Basic">Basic表实例</param>
        /// <returns>int</returns>
        public static int Insert(Basic BasicExample)
        {
            return Service.Insert(BasicExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Basic">Basic表实例</param>
        /// <returns>int</returns>
        public static int Update(Basic BasicExample)
        {
            return Service.Update(BasicExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>int</returns>
        public static int Delete(int Id)
        {
            return Service.Delete(Id);
        }
        #endregion


        #region searchByState
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public static Basic searchByState(string State)
        {
            return Service.searchByState(State);
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="id">int字段</param>
        /// <param name="orderby">排序</param>
        /// <returns>IList<Basic></returns>
        public static IList<Basic> Search(int s, int e, string key, string state, int id, string orderby)
        {
            return Service.Search(s, e, key, state, id, orderby);
        }
        #endregion


    }



}

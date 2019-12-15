using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{
    /*BLL*/
    public class SignsManager
    {

        private static ISignsService Service = Manager.factory.CreateSignsService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<Signs> SearchAll()
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
        public static Signs SearchById(int Id)
        {
            return Service.SearchById(Id);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="Signs">Signs表实例</param>
        /// <returns>int</returns>
        public static int Insert(Signs SignsExample)
        {
            return Service.Insert(SignsExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Signs">Signs表实例</param>
        /// <returns>int</returns>
        public static int Update(Signs SignsExample)
        {
            return Service.Update(SignsExample);
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


        #region searchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static int searchNum(string key, DateTime start, DateTime end, int uid, int state, int type)
        {

            return Service.searchNum(key, start, end, uid, state, type);
        }
        #endregion

        #region search
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<Signs> search(int s, int e, string key, DateTime start, DateTime end, int uid, int state, int type, string orderby)
        {
            return Service.search(s, e, key, start, end, uid, state, type, orderby);
        }
        #endregion


    }

}

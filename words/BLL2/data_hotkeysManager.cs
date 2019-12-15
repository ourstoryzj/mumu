using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL2
{
    /*BLL*/
    public class data_hotkeysManager
    {

        private static Idata_hotkeysService Service = Manager1.factory.Createdata_hotkeysService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<data_hotkeys> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据dhid,查询一条数据
        /// </summary>
        /// <param name="dhid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static data_hotkeys SearchByID(int dhid)
        {
            return Service.SearchByID(dhid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="data_hotkeys">data_hotkeys表实例</param>
        /// <returns>int</returns>
        public static int Insert(data_hotkeys data_hotkeysExample)
        {
            return Service.Insert(data_hotkeysExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="data_hotkeys">data_hotkeys表实例</param>
        /// <returns>int</returns>
        public static int Update(data_hotkeys data_hotkeysExample)
        {
            return Service.Update(data_hotkeysExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dhid"></param>
        /// <returns>int</returns>
        public static int Delete(int dhid)
        {
            return Service.Delete(dhid);
        }
        #endregion

    }



}

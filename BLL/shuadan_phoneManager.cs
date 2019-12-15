using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{
    /*BLL*/
    public class shuadan_phoneManager
    {

        private static Ishuadan_phoneService Service = Manager.factory.Createshuadan_phoneService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shuadan_phone> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchBysdpid
        /// <summary>
        /// 根据sdpid,查询一条数据
        /// </summary>
        /// <param name="sdpid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static shuadan_phone SearchBysdpid(int sdpid)
        {
            return Service.SearchBysdpid(sdpid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan_phone">shuadan_phone表实例</param>
        /// <returns>int</returns>
        public static int Insert(shuadan_phone shuadan_phoneExample)
        {
            return Service.Insert(shuadan_phoneExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_phone">shuadan_phone表实例</param>
        /// <returns>int</returns>
        public static int Update(shuadan_phone shuadan_phoneExample)
        {
            return Service.Update(shuadan_phoneExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sdpid"></param>
        /// <returns>int</returns>
        public static int Delete(int sdpid)
        {
            return Service.Delete(sdpid);
        }
        #endregion

    }
	
}

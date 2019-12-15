using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{
    /*BLL*/
    public class yh_goods_corekeysManager
    {

        private static Iyh_goods_corekeysService Service = Manager.factory.Createyh_goods_corekeysService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<yh_goods_corekeys> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchBygcid
        /// <summary>
        /// 根据gcid,查询一条数据
        /// </summary>
        /// <param name="gcid">关联表ID</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static yh_goods_corekeys SearchBygcid(int gcid)
        {
            return Service.SearchBygcid(gcid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="yh_goods_corekeys">yh_goods_corekeys表实例</param>
        /// <returns>int</returns>
        public static int Insert(yh_goods_corekeys yh_goods_corekeysExample)
        {
            return Service.Insert(yh_goods_corekeysExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_goods_corekeys">yh_goods_corekeys表实例</param>
        /// <returns>int</returns>
        public static int Update(yh_goods_corekeys yh_goods_corekeysExample)
        {
            return Service.Update(yh_goods_corekeysExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gcid">关联表ID</param>
        /// <returns>int</returns>
        public static int Delete(int gcid)
        {
            return Service.Delete(gcid);
        }
        #endregion

    }
	

}

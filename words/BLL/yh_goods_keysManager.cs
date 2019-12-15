using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{


   
 
    /*BLL*/
    public class yh_goods_keysManager
    {

        private static Iyh_goods_keysService Service = Manager.factory.Createyh_goods_keysService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<yh_goods_keys> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchBygkid
        /// <summary>
        /// 根据gkid,查询一条数据
        /// </summary>
        /// <param name="gkid">商品-黄金关键词ID</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static yh_goods_keys SearchBygkid(int gkid)
        {
            return Service.SearchBygkid(gkid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="yh_goods_keys">yh_goods_keys表实例</param>
        /// <returns>int</returns>
        public static int Insert(yh_goods_keys yh_goods_keysExample)
        {
            return Service.Insert(yh_goods_keysExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_goods_keys">yh_goods_keys表实例</param>
        /// <returns>int</returns>
        public static int Update(yh_goods_keys yh_goods_keysExample)
        {
            return Service.Update(yh_goods_keysExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gkid">商品-黄金关键词ID</param>
        /// <returns>int</returns>
        public static int Delete(int gkid)
        {
            return Service.Delete(gkid);
        }
        #endregion

    }
	
	
	
	


}

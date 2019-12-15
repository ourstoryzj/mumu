using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL2
{
    /*BLL*/
    public class opponent_goodsManager
    {

        private static Iopponent_goodsService Service = Manager1.factory.Createopponent_goodsService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<opponent_goods> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据ogid,查询一条数据
        /// </summary>
        /// <param name="ogid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static opponent_goods SearchByID(int ogid)
        {
            return Service.SearchByID(ogid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="opponent_goods">opponent_goods表实例</param>
        /// <returns>int</returns>
        public static int Insert(opponent_goods opponent_goodsExample)
        {
            return Service.Insert(opponent_goodsExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="opponent_goods">opponent_goods表实例</param>
        /// <returns>int</returns>
        public static int Update(opponent_goods opponent_goodsExample)
        {
            return Service.Update(opponent_goodsExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ogid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int ogid)
        {
            return Service.Delete(ogid);
        }
        #endregion


        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="shopid">店铺编号</param>
        /// <param name="TBid">商品编号</param>
        /// <param name="caijidate">采集时间字符串</param>
        /// <returns></returns>
        public static int SearchNum(string key, string shopid, string TBid, string caijidate)
        {
            return Service.SearchNum(key, shopid, TBid, caijidate);
        }
        #endregion

        #region Search
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束为止</param>
        /// <param name="key">关键词</param>
        /// <param name="shopid">店铺ID</param>
        /// <param name="TBid">淘宝商品ID</param>
        /// <param name="caijidate">采集时间</param>
        /// <param name="orderby">排序</param>
        /// <returns></returns>
        public static IList<opponent_goods> Search(int s, int e, string key, string shopid, string TBid, string caijidate, string orderby)
        {
            return Service.Search(s, e, key, shopid, TBid, caijidate, orderby);
        }
        #endregion




    }



}

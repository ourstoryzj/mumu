using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL2
{
    /*BLL*/
    public class wanggong_goodsManager
    {

        private static Iwanggong_goodsService Service = Manager1.factory.Createwanggong_goodsService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<wanggong_goods> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据wgid,查询一条数据
        /// </summary>
        /// <param name="wgid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static wanggong_goods SearchByID(int wgid)
        {
            return Service.SearchByID(wgid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="wanggong_goods">wanggong_goods表实例</param>
        /// <returns>int</returns>
        public static int Insert(wanggong_goods wanggong_goodsExample)
        {
            int temp = SearchNum(wanggong_goodsExample.wgTBid, 0, new DateTime(), new DateTime());
            if (temp == 0)
            {
                return Service.Insert(wanggong_goodsExample);
            }
            else
            {
                IList<wanggong_goods> list = Search(1, 99, wanggong_goodsExample.wgTBid, 0, new DateTime(), new DateTime(), "");
                wanggong_goods gg = list[0];
                gg.wgcollectdate = wanggong_goodsExample.wgcollectdate;
                gg.wgimg = wanggong_goodsExample.wgimg;
                gg.wgprice2 = wanggong_goodsExample.wgprice2;
                gg.wgremark = wanggong_goodsExample.wgremark;
                gg.wgTBid = wanggong_goodsExample.wgTBid;
                gg.wgtittle = wanggong_goodsExample.wgtittle;
                gg.wgurl = wanggong_goodsExample.wgurl;
                gg.wgxiaoliang = wanggong_goodsExample.wgxiaoliang;
                return Service.Update(gg);
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="wanggong_goods">wanggong_goods表实例</param>
        /// <returns>int</returns>
        public static int Update(wanggong_goods wanggong_goodsExample)
        {
            return Service.Update(wanggong_goodsExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="wgid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int wgid)
        {
            return Service.Delete(wgid);
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
        public static int SearchNum(string key, int wid, DateTime startdate, DateTime enddate)
        {
            return Service.SearchNum(key, wid, startdate, enddate);
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
        /// <returns>IList<wanggong_goods></returns>
        public static IList<wanggong_goods> Search(int s, int e, string key, int wid, DateTime startdate, DateTime enddate, string orderby)
        {
            return Service.Search(s, e, key, wid, startdate, enddate, orderby);
        }
        #endregion

    }





}

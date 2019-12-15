using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL2
{
    /*BLL*/
    public class wanggong_dianpuManager
    {

        private static Iwanggong_dianpuService Service = Manager1.factory.Createwanggong_dianpuService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<wanggong_dianpu> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据wid,查询一条数据
        /// </summary>
        /// <param name="wid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static wanggong_dianpu SearchByID(int wid)
        {
            return Service.SearchByID(wid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="wanggong_dianpu">wanggong_dianpu表实例</param>
        /// <returns>int</returns>
        public static int Insert(wanggong_dianpu wanggong_dianpuExample)
        {
            int temp = SearchNum(wanggong_dianpuExample.wdTBID, "", new DateTime(), new DateTime());
            if (temp == 0)
            {
                return Service.Insert(wanggong_dianpuExample);
            }
            else
            {
                IList<wanggong_dianpu> list = Search(1, 99, wanggong_dianpuExample.wdTBID, "", new DateTime(), new DateTime(), "");
                wanggong_dianpu dp = list[0];
                dp.wdcollectdate = wanggong_dianpuExample.wdcollectdate;
                dp.wdpname = wanggong_dianpuExample.wdpname;
                dp.wdTBID = wanggong_dianpuExample.wdTBID;
                dp.wdwangwang = wanggong_dianpuExample.wdwangwang;
                return Service.Update(dp);
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="wanggong_dianpu">wanggong_dianpu表实例</param>
        /// <returns>int</returns>
        public static int Update(wanggong_dianpu wanggong_dianpuExample)
        {
            return Service.Update(wanggong_dianpuExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="wid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int wid)
        {
            return Service.Delete(wid);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询数量
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <returns></returns>
        public static int SearchNum(string key, string state, DateTime begin, DateTime end)
        {
            return Service.SearchNum(key, state, begin, end);
        }
        #endregion

        #region Search
        /// <summary>
        /// 高级搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="begin">开始时间</param>
        /// <param name="end">结束时间</param>
        /// <param name="orderby">排序方式</param>
        /// <returns></returns>
        public static IList<wanggong_dianpu> Search(int s, int e, string key, string state, DateTime begin, DateTime end, string orderby)
        {
            return Service.Search(s, e, key, state, begin, end, orderby);
        }
        #endregion

        #region SearchLastOne
        /// <summary>
        /// 查询时间排序最后一条店铺信息
        /// </summary>
        /// <returns></returns>
        public static wanggong_dianpu SearchLastOne()
        {
            return Service.SearchLastOne();
        }
        #endregion

    }




}

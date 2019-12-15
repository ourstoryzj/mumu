using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL2
{
    /*BLL*/
    public class opponent_dianpuManager
    {

        private static Iopponent_dianpuService Service = Manager1.factory.Createopponent_dianpuService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<opponent_dianpu> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据oid,查询一条数据
        /// </summary>
        /// <param name="oid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static opponent_dianpu SearchByID(int oid)
        {
            return Service.SearchByID(oid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="opponent_dianpu">opponent_dianpu表实例</param>
        /// <returns>int</returns>
        public static int Insert(opponent_dianpu opponent_dianpuExample)
        {

            int temp = SearchNum(opponent_dianpuExample.odTBID);
            if (temp == 0)
            {
                return Service.Insert(opponent_dianpuExample);
            }
            else
            {
                IList<opponent_dianpu> list = Search(1, 99, opponent_dianpuExample.odTBID, "");
                opponent_dianpu dp = list[0];
                opponent_dianpuExample.oid = dp.oid;
                return Service.Update(opponent_dianpuExample);
            }


        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="opponent_dianpu">opponent_dianpu表实例</param>
        /// <returns>int</returns>
        public static int Update(opponent_dianpu opponent_dianpuExample)
        {
            return Service.Update(opponent_dianpuExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="oid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int oid)
        {
            return Service.Delete(oid);
        }
        #endregion


        #region SearchNum
        /// <summary>
        /// 高级搜索数量
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        public static int SearchNum(string key)
        {
            return Service.SearchNum(key);
        }
        #endregion

        #region Search
        /// <summary>
        /// 高级搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束为止</param>
        /// <param name="key">关键词</param>
        /// <param name="orderby">排序</param>
        /// <returns>IList<opponent_dianpu></returns>
        public static IList<opponent_dianpu> Search(int s, int e, string key, string orderby)
        {
            return Service.Search(s, e, key, orderby);
        }
        #endregion

        #region SearchLastOne
        /// <summary>
        /// 获取最后一条信息
        /// </summary>
        /// <param name="oid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public static opponent_dianpu SearchLastOne()
        {
            return Service.SearchLastOne();
        }
        #endregion

    }



}

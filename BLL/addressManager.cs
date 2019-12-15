using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Web.UI.WebControls;

namespace BLL
{

    /*BLL*/
    public class addressManager
    {

        private static IaddressService Service = Manager.factory.CreateaddressService();


        #region Search
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<address> SearchRND(string num)
        {
            IList<address> list=Service.SearchRND(num);
            foreach (address a in list)
            {
                a.astate = "2";
                Update(a);
            }
            return list;
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static int SearchNum(string key, string state)
        {
            return Service.SearchNum(key, state);

        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索(高效率分页查询)
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        public static IList<address> Search(int s, int e, string key, string state, string _top)
        {
            return Service.Search(s, e, key, state, _top);
        }
        #endregion


        #region SearchByaid
        /// <summary>
        /// 根据主键,查询一条数据
        /// </summary>
        /// <param name="主键"></param>
        /// <returns></returns>
        public static address SearchByaid(int aid)
        {
            return Service.SearchByaid(aid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="address">address表实例</param>
        /// <returns>int</returns>
        public static int Insert(address addressExample)
        {
            return Service.Insert(addressExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="address">address表实例</param>
        /// <returns>int</returns>
        public static int Update(address addressExample)
        {
            return Service.Update(addressExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="主键"></param>
        /// <returns>int</returns>
        public static int Delete(int aid)
        {
            return Service.Delete(aid);
        }
        #endregion

    }
}

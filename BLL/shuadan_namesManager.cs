using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Web.UI.WebControls;

namespace BLL
{
    /*BLL*/
    public class shuadan_namesManager
    {

        private static Ishuadan_namesService Service = Manager.factory.Createshuadan_namesService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shuadan_names> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchBynid
        /// <summary>
        /// 根据nid,查询一条数据
        /// </summary>
        /// <param name="nid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static shuadan_names SearchBynid(int nid)
        {
            return Service.SearchBynid(nid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan_names">shuadan_names表实例</param>
        /// <returns>int</returns>
        public static int Insert(shuadan_names shuadan_namesExample)
        {
            return Service.Insert(shuadan_namesExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_names">shuadan_names表实例</param>
        /// <returns>int</returns>
        public static int Update(shuadan_names shuadan_namesExample)
        {
            return Service.Update(shuadan_namesExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="nid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int nid)
        {
            return Service.Delete(nid);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static int SearchNum(string key)
        {
            return Service.SearchNum(key);
        }
        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        public static IList<shuadan_names> Search(int s, int e, string key)
        {
            return Service.Search(s, e, key);
        }
        #endregion

        #region SearchRnd
        /// <summary>
        /// 随机查询名字
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shuadan_names> SearchRnd(int num)
        {
            IList<shuadan_names> list = Service.SearchRnd(num);
            foreach (shuadan_names a in list)
            {
                int count = 0;
                int.TryParse(a.ncount, out count);
                a.ncount = (count + 1).ToString();
                Update(a);
            }
            return list;
        }
        #endregion

    }

}

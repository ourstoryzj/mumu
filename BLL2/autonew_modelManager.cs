using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL2
{
    /*BLL*/
    public class autonew_modelManager
    {

        private static Iautonew_modelService Service = Manager1.factory.Createautonew_modelService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<autonew_model> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据amid,查询一条数据
        /// </summary>
        /// <param name="amid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static autonew_model SearchByID(int amid)
        {
            return Service.SearchByID(amid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="autonew_model">autonew_model表实例</param>
        /// <returns>int</returns>
        public static int Insert(autonew_model autonew_modelExample)
        {
            return Service.Insert(autonew_modelExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="autonew_model">autonew_model表实例</param>
        /// <returns>int</returns>
        public static int Update(autonew_model autonew_modelExample)
        {
            return Service.Update(autonew_modelExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="amid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int amid)
        {
            return Service.Delete(amid);
        }
        #endregion

        #region search
        /// <summary>
        /// 高级查询 
        /// </summary>
        /// <param name="key">关键词，只查询模板名称和标题</param>
        /// <param name="atype">模板类型</param>
        /// <returns></returns>
        public static autonew_model search(string key, string atype)
        {
            return Service.search(key, atype);
        }
        #endregion


         

    }




}

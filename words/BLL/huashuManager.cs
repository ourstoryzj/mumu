using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Web.UI.WebControls;

namespace BLL
{

    /*BLL*/
    public class huashuManager
    {

        private static DAL.huashuService Service = new DAL.huashuService();

        #region SearchAll
        /// <summary>
        /// 搜索全部父类
        /// </summary>
        /// <returns></returns>
        public static IList<huashu> SearchAll(string state)
        {
            return Service.SearchAll(state);
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据hid,查询一条数据
        /// </summary>
        /// <param name="hid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static huashu SearchByID(int hid)
        {
            return Service.SearchByID(hid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="huashu">huashu表实例</param>
        /// <returns>int</returns>
        public static int Insert(huashu huashuExample)
        {
            return Service.Insert(huashuExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="huashu">huashu表实例</param>
        /// <returns>int</returns>
        public static int Update(huashu huashuExample)
        {
            huashuExample.hdate = DateTime.Now;
            return Service.Update(huashuExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="hid"></param>
        /// <returns>int</returns>
        public static int Delete(int hid)
        {
            return Service.Delete(hid);
        }
        #endregion

        #region SearchNum
        /// <summary>
        /// 根据条件查询全部数据总条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="date1">起始时间</param>
        /// <param name="date2">结束时间</param>
        /// <returns>int</returns>
        public static int SearchNum(string key, string state, string _type, DateTime date1, DateTime date2)
        {
            return Service.SearchNum(key, state, _type, date1, date2);
        }
        #endregion

        #region Search
        /// <summary>
        /// 根据条件查询全部数据
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="date1">起始时间</param>
        /// <param name="date2">结束时间</param>
        /// <returns>IList<huashu></returns>
        public static IList<huashu> Search(int s, int e, string key, string state, string _type, DateTime date1, DateTime date2)
        {
            return Service.Search(s, e, key, state, _type, date1, date2);
        }
        #endregion

        #region ddl_bind
        public static void ddl_bind(DropDownList ddl, bool havefrist)
        {
            ddl.Items.Clear();
            ddl.AppendDataBoundItems = true;
            if (havefrist)
            {
                Manager.DDL_BindFrist(ddl);
            }
            ddl.DataTextField = "htitle";
            ddl.DataValueField = "hid";
            ddl.DataSource = SearchAll("");
            ddl.DataBind();
        }
        #endregion

        #region GetList
        /// <summary>
        /// 获取店铺
        /// </summary>
        /// <returns></returns>
        public static IList<huashu> GetList()
        {
            IList<huashu> list = Manager.List_huashu;
            if (list == null)
            {
                list = SearchAll("");
                Manager.List_huashu = list;
            }
            return list;
        }
        #endregion

    }


}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Web.UI.WebControls;

namespace BLL
{


    /*BLL*/
    public class pages_typeManager
    {

        private static Ipages_typeService Service = Manager.factory.Createpages_typeService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<pages_type> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据ptid,查询一条数据
        /// </summary>
        /// <param name="ptid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static pages_type SearchByID(int ptid)
        {
            return Service.SearchByID(ptid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="pages_type">pages_type表实例</param>
        /// <returns>int</returns>
        public static int Insert(pages_type pages_typeExample)
        {
            return Service.Insert(pages_typeExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="pages_type">pages_type表实例</param>
        /// <returns>int</returns>
        public static int Update(pages_type pages_typeExample)
        {
            return Service.Update(pages_typeExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ptid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int ptid)
        {
            return Service.Delete(ptid);
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
        public static int SearchNum(string key, string state, DateTime date1, DateTime date2)
        {
            return Service.SearchNum(key, state, date1, date2);
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
        /// <returns>IList<pages_type></returns>
        public static IList<pages_type> Search(int s, int e, string key, string state, DateTime date1, DateTime date2)
        {
            return Service.Search(s,e,key,state,date1,date2);
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
            ddl.DataTextField = "ptname";
            ddl.DataValueField = "ptid";
            ddl.DataSource = Search(1, 1000, "", "1", new DateTime(), new DateTime());
            ddl.DataBind();
        }
        #endregion


        #region GetList
        /// <summary>
        /// 获取店铺
        /// </summary>
        /// <returns></returns>
        public static IList<pages_type> GetList(string state)
        {
            IList<pages_type> list = Manager.List_pagestype;
            if (list == null)
            {
                list = Search(1, 1000, "", state, new DateTime(), new DateTime());
                Manager.List_pagestype = list;
            }
            return list;
        }
        #endregion



    }



}

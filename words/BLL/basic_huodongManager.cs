using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Web.UI.WebControls;

namespace BLL
{

    /*BLL*/
    public class basic_huodongManager
    {

        private static Ibasic_huodongService Service = new DAL.basic_huodongService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<basic_huodong> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据hdid,查询一条数据
        /// </summary>
        /// <param name="hdid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static basic_huodong SearchByID(int hdid)
        {
            return Service.SearchByID(hdid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="basic_huodong">basic_huodong表实例</param>
        /// <returns>int</returns>
        public static int Insert(basic_huodong basic_huodongExample)
        {
            return Service.Insert(basic_huodongExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_huodong">basic_huodong表实例</param>
        /// <returns>int</returns>
        public static int Update(basic_huodong basic_huodongExample)
        {
            return Service.Update(basic_huodongExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="hdid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int hdid)
        {
            return Service.Delete(hdid);
        }
        #endregion



        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <returns>int</returns>
        public static int SearchNum(string key, string state)
        {
            return Service.SearchNum(key, state);
        }
        #endregion

        #region Search
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="s">开始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="state">状态</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_huodong></returns>
        public static IList<basic_huodong> Search(int s, int e, string key, string state, string orderby)
        {
            return Service.Search(s, e, key, state, orderby);
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
            ddl.DataTextField = "hdname";
            ddl.DataValueField = "hdid";
            ddl.DataSource = SearchAll();
            ddl.DataBind();
        }
        #endregion



        #region GetList
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <returns></returns>
        public static IList<basic_huodong> GetList()
        {
            IList<basic_huodong> list = Manager.List_huodong_plan;
            if (list == null)
            {
                list = SearchAll();
                Manager.List_huodong_plan = list;
            }
            return list;
        }
        #endregion


        #region 根据编号获取补单方案GetInList
        /// <summary>
        /// 根据编号获取补单方案
        /// </summary>
        /// <param name="opid"></param>
        /// <returns></returns>
        public static basic_huodong GetInList(string opid)
        {
            basic_huodong op = null;
            IList<basic_huodong> list = GetList();
            foreach (basic_huodong dp in list)
            {
                if (dp.hdid.ToString() == opid)
                {
                    op = dp;
                    break;
                }
            }
            return op;
        }
        #endregion

    }

}

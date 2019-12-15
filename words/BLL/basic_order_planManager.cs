using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Web.UI.WebControls;

namespace BLL
{



    /*BLL*/
    public class basic_order_planManager
    {

        private static Ibasic_order_planService Service = new DAL.basic_order_planService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<basic_order_plan> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据opid,查询一条数据
        /// </summary>
        /// <param name="opid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static basic_order_plan SearchByID(int opid)
        {
            return Service.SearchByID(opid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="basic_order_plan">basic_order_plan表实例</param>
        /// <returns>int</returns>
        public static int Insert(basic_order_plan basic_order_planExample)
        {
            return Service.Insert(basic_order_planExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_order_plan">basic_order_plan表实例</param>
        /// <returns>int</returns>
        public static int Update(basic_order_plan basic_order_planExample)
        {
            return Service.Update(basic_order_planExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="opid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int opid)
        {
            return Service.Delete(opid);
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
        /// <returns>IList<basic_order_plan></returns>
        public static IList<basic_order_plan> Search(int s, int e, string key, string state, string orderby)
        {
            return Service.Search(s, e, key, state, orderby);
        }
        #endregion


        #region ddl_bind
        public static void ddl_bind(DropDownList ddl, bool havefrist)
        {
            try
            {
                ddl.Items.Clear();
                ddl.AppendDataBoundItems = true;
                if (havefrist)
                {
                    Manager.DDL_BindFrist(ddl);
                }
                ddl.DataTextField = "opname";
                ddl.DataValueField = "opid";
                ddl.DataSource = SearchAll();
                ddl.DataBind();
            }
            catch { }
        }
        #endregion

        #region GetList
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <returns></returns>
        public static IList<basic_order_plan> GetList()
        {
            IList<basic_order_plan> list = Manager.List_order_plan;
            if (list == null)
            {
                list = SearchAll();
                Manager.List_order_plan = list;
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
        public static basic_order_plan GetInList(string opid)
        {
            basic_order_plan op = null;
            IList<basic_order_plan> list = GetList();
            foreach (basic_order_plan dp in list)
            {
                if (dp.opid.ToString() == opid)
                {
                    op = dp;
                    break;
                }
            }
            return op;
        }
        #endregion

        #region GetNumInPlan
        /// <summary>
        /// 根据上架时间获取补单计划中需要补单数量
        /// </summary>
        /// <param name="dt">上架时间</param>
        /// <param name="id">补单方案编号</param>
        /// <returns>补单数量</returns>
        public static int GetNumInPlan(DateTime dt, int id)
        {
            int res = 0;
            basic_order_plan bg = GetInList(id.ToString());
            if (bg != null)
            {
                //int temp_day = Manager.DateDiff_GetInt(DateTime.Now, dt);
                DateTime dt1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd"));
                DateTime dt2 = Convert.ToDateTime(dt.ToString("yyyy/MM/dd"));
                TimeSpan ts = dt1 - dt2;
                int temp_day = ts.Days;
                if (temp_day == 0)
                {
                    res = bg.opday1;
                }
                if (temp_day == 1)
                {
                    res = bg.opday2;
                }
                if (temp_day == 2)
                {
                    res = bg.opday3;
                }
                if (temp_day == 3)
                {
                    res = bg.opday4;
                }
                if (temp_day == 4)
                {
                    res = bg.opday5;
                }
                if (temp_day == 5)
                {
                    res = bg.opday6;
                }
                if (temp_day == 6)
                {
                    res = bg.opday7;
                }
                if (temp_day == 7)
                {
                    res = bg.opday8;
                }
                if (temp_day == 8)
                {
                    res = bg.opday9;
                }
                if (temp_day == 9)
                {
                    res = bg.opday10;
                }
                if (temp_day == 10)
                {
                    res = bg.opday11;
                }
                if (temp_day == 11)
                {
                    res = bg.opday12;
                }
                if (temp_day == 12)
                {
                    res = bg.opday13;
                }
                if (temp_day == 13)
                {
                    res = bg.opday14;
                }
            }
            return res;
        }
        #endregion

    }


}

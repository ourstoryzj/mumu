using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Web.UI.WebControls;

namespace BLL
{
    /*BLL*/
    public class yh_goodstypeManager
    {

        private static Iyh_goodstypeService Service = Manager.factory.Createyh_goodstypeService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<yh_goodstype> SearchAll()
        {
            return Service.SearchAll(false);
        }
        #endregion

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<yh_goodstype> SearchAll(bool isall)
        {
            return Service.SearchAll(isall);
        }
        #endregion

        #region SearchBygtid
        /// <summary>
        /// 根据gtid,查询一条数据
        /// </summary>
        /// <param name="gtid">商品类型</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static yh_goodstype SearchBygtid(int gtid)
        {
            return Service.SearchBygtid(gtid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="yh_goodstype">yh_goodstype表实例</param>
        /// <returns>int</returns>
        public static int Insert(yh_goodstype yh_goodstypeExample)
        {
            return Service.Insert(yh_goodstypeExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="yh_goodstype">yh_goodstype表实例</param>
        /// <returns>int</returns>
        public static int Update(yh_goodstype yh_goodstypeExample)
        {
            return Service.Update(yh_goodstypeExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gtid">商品类型</param>
        /// <returns>int</returns>
        public static int Delete(int gtid)
        {
            return Service.Delete(gtid);
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
            ddl.DataTextField = "gtanme";
            ddl.DataValueField = "gtid";
            ddl.DataSource = GetList(true);
            ddl.DataBind();
        }
        #endregion


        #region GetList
        /// <summary>
        /// 获取店铺
        /// </summary>
        /// <returns></returns>
        public static IList<yh_goodstype> GetList(bool isSession)
        {
            IList<yh_goodstype> list = null;
            if (isSession)
            {
                list = Manager.List_goodstype;
            }
            if (list == null)
            {
                list = SearchAll();
                Manager.List_goodstype = list;
            }
            return list;
        }
        #endregion

    }





}

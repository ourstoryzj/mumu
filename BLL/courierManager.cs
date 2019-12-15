using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Web.UI.WebControls;

namespace BLL
{

    /*BLL*/
    public class courierManager
    {

        private static IcourierService Service = Manager.factory.CreatecourierService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<courier> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据cid,查询一条数据
        /// </summary>
        /// <param name="cid">快递编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static courier SearchByID(int cid)
        {
            return Service.SearchByID(cid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="courier">courier表实例</param>
        /// <returns>int</returns>
        public static int Insert(courier courierExample)
        {
            return Service.Insert(courierExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="courier">courier表实例</param>
        /// <returns>int</returns>
        public static int Update(courier courierExample)
        {
            return Service.Update(courierExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="cid">快递编号</param>
        /// <returns>int</returns>
        public static int Delete(int cid)
        {
            return Service.Delete(cid);
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
            ddl.DataTextField = "cname";
            ddl.DataValueField = "cid";
            ddl.DataSource = SearchAll();
            ddl.DataBind();
        }
        #endregion


        #region GetList
        /// <summary>
        /// 获取店铺
        /// </summary>
        /// <returns></returns>
        public static IList<courier> GetList()
        {
            IList<courier> list = Manager.List_courier;
            if (list == null)
            {
                list = SearchAll();
                Manager.List_courier = list;
            }
            return list;
        }
        #endregion

 
    }


}

using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Web.UI.WebControls;

namespace BLL
{

    /*BLL*/
    public class dianpuManager
    {

        private static IdianpuService Service = Manager.factory.CreatedianpuService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<dianpu> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<dianpu> SearchAll(bool isState)
        {
            return Service.SearchAll(isState);

        }
        #endregion

        #region SearchBydpid
        /// <summary>
        /// 根据dpid,查询一条数据
        /// </summary>
        /// <param name="dpid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static dianpu SearchBydpid(int dpid)
        {
            return Service.SearchBydpid(dpid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="dianpu">dianpu表实例</param>
        /// <returns>int</returns>
        public static int Insert(dianpu dianpuExample)
        {
            return Service.Insert(dianpuExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="dianpu">dianpu表实例</param>
        /// <returns>int</returns>
        public static int Update(dianpu dianpuExample)
        {
            return Service.Update(dianpuExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dpid"></param>
        /// <returns>int</returns>
        public static int Delete(int dpid)
        {
            return Service.Delete(dpid);
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
            ddl.DataTextField = "dpname";
            ddl.DataValueField = "dpid";
            ddl.DataSource = SearchAll(true);
            ddl.DataBind();
        }
        #endregion

        #region GetList
        /// <summary>
        /// 获取店铺
        /// </summary>
        /// <returns></returns>
        public static IList<dianpu> GetList(bool isState)
        {
            IList<dianpu> list = Manager.List_dianpu;
            if (list == null)
            {
                list = SearchAll(isState);
                Manager.List_dianpu = list;
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
        public static dianpu GetInList(string opid)
        {
            dianpu op = null;
            IList<dianpu> list = GetList(false);
            foreach (dianpu dp in list)
            {
                if (dp.dpid.ToString() == opid)
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

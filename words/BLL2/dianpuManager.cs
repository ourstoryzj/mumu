using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Windows.Forms;


namespace BLL2
{

    /*BLL*/
    public class dianpuManager
    {

        private static IdianpuService Service = Manager1.factory.CreatedianpuService();

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


        #region bind_dianpu
        /// <summary>
        /// 绑定店铺
        /// </summary>
        /// <param name="cb_dianpu">ComboBox控件</param>
        /// <param name="has">是否添加‘请选择’选项</param>
        public static void bind_dianpu(ComboBox cb_dianpu, bool has)
        {
            IList<dianpu> list_dp2 = BLL2.dianpuManager.SearchAll();
            if (has)
            {
                dianpu dp = new dianpu();
                dp.dpname = "请选择";
                dp.dpid = 0;
                list_dp2.Insert(0, dp);
            }
            cb_dianpu.DataSource = list_dp2;

        }
        #endregion






    }
}

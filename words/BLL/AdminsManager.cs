using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{

    /*BLL*/
    public class AdminsManager
    {

        private static IAdminsService Service = new DAL.AdminsService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<Admins> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByaid
        /// <summary>
        /// 根据aid,查询一条数据
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static Admins SearchByaid(int aid)
        {
            return Service.SearchByaid(aid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="Admins">Admins表实例</param>
        /// <returns>int</returns>
        public static int Insert(Admins AdminsExample)
        {
            return Service.Insert(AdminsExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Admins">Admins表实例</param>
        /// <returns>int</returns>
        public static int Update(Admins AdminsExample)
        {
            return Service.Update(AdminsExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="aid"></param>
        /// <returns>int</returns>
        public static int Delete(int aid)
        {
            return Service.Delete(aid);
        }
        #endregion


        #region searchByAcc
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public static Admins searchByAcc(string acc)
        {
            return Service.searchByAcc(acc);
        }
        #endregion

        #region Login

        public static string Login(string account, string pwd)
        {
            string res = "0:账号密码错误！";
            if (!string.IsNullOrEmpty(account) || !string.IsNullOrEmpty(pwd))
            {
                Admins admin = searchByAcc(account);
                if (admin == null)
                {
                    res = "0:没有此账号";
                }
                else if (admin.astate == "2")
                {
                    res = "0:没有此账号2";
                }
                else if (admin.apassword != pwd)
                {
                    res = "0:密码错误！";
                }
                else
                {
                    admin.alogintime = DateTime.Now;
                    if (Update(admin) == 1)
                    {
                        res = "1:" + admin.atype;
                    }
                }
            }
            return res;
        }
        #endregion

    }

}

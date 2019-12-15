using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Web;

namespace BLL
{
    /*BLL*/
    public class UsersManager
    {

        private static IUsersService Service = Manager.factory.CreateUsersService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<Users> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchById
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static Users SearchById(int Id)
        {
            return Service.SearchById(Id);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="Users">Users表实例</param>
        /// <returns>int</returns>
        public static int Insert(Users UsersExample)
        {
            return Service.Insert(UsersExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="Users">Users表实例</param>
        /// <returns>int</returns>
        public static int Update(Users UsersExample)
        {
            return Service.Update(UsersExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>int</returns>
        public static int Delete(int Id)
        {
            return Service.Delete(Id);
        }
        #endregion

        #region searchByAcc
        /// <summary>
        /// 根据Id,查询一条数据
        /// </summary>
        /// <param name="Id">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public static Users searchByAcc(string acc)
        {
            return Service.searchByAcc(acc);
        }
        #endregion

        #region User_Exit
        /// <summary>
        /// 注销系统
        /// </summary>
        /// <param name="timeover">是否为登陆时间到期</param>
        public static void User_Exit(bool timeover)
        {
            if (timeover)
            {
                if (HttpContext.Current.Session[Manager.decl_User] != null)
                {
                    return;
                }
            }
            HttpContext.Current.Session.Clear();
            Manager.ResponseJS("window.parent.location.href='Login.aspx';");
            System.Web.HttpContext.Current.Response.End();
        }
        #endregion

        #region User_Exit2
        /// <summary>
        /// 关闭页面
        /// </summary>
        /// <param name="timeover">是否为登陆时间到期</param>
        public static void User_Exit2(bool timeover)
        {
            if (timeover)
            {
                if (HttpContext.Current.Session[Manager.decl_User] != null)
                {
                    return;
                }
            }
            HttpContext.Current.Session.Clear();
            Manager.ResponseJS("window.opener=null;window.close();");
            System.Web.HttpContext.Current.Response.End();
        }
        #endregion

    }

}

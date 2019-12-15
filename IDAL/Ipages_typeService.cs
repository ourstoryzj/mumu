using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{

    /*IDAL*/
    public interface Ipages_typeService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<pages_type> SearchAll();
        #endregion

        #region SearchByptid
        /// <summary>
        /// 根据ptid,查询一条数据
        /// </summary>
        /// <param name="ptid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        pages_type SearchByID(int ptid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="pages_type">pages_type表实例</param>
        /// <returns>int</returns>
        int Insert(pages_type pages_typeExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="pages_type">pages_type表实例</param>
        /// <returns>int</returns>
        int Update(pages_type pages_typeExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="ptid">编号</param>
        /// <returns>int</returns>
        int Delete(int ptid);
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
        int SearchNum(string key, string state, DateTime date1, DateTime date2);
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
        IList<pages_type> Search(int s, int e, string key, string state, DateTime date1, DateTime date2);
        #endregion


    }
	
	
	
	

}

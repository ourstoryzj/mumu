using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Ishuadan_namesService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<shuadan_names> SearchAll();
        #endregion

        #region SearchBynid
        /// <summary>
        /// 根据nid,查询一条数据
        /// </summary>
        /// <param name="nid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        shuadan_names SearchBynid(int nid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan_names">shuadan_names表实例</param>
        /// <returns>int</returns>
        int Insert(shuadan_names shuadan_namesExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_names">shuadan_names表实例</param>
        /// <returns>int</returns>
        int Update(shuadan_names shuadan_namesExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="nid">编号</param>
        /// <returns>int</returns>
        int Delete(int nid);
        #endregion

        #region SearchNum
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        int SearchNum(string key);

        #endregion

        #region Search
        /// <summary>
        /// 模糊搜索
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns></returns>
        IList<shuadan_names> Search(int s, int e, string key);

        #endregion

        #region SearchRnd
        /// <summary>
        /// 随机查询名字
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<shuadan_names> SearchRnd(int num);
       
        #endregion
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface Ishuadan_recordService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<shuadan_record> SearchAll();
        #endregion

        #region SearchBysrid
        /// <summary>
        /// 根据srid,查询一条数据
        /// </summary>
        /// <param name="srid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        shuadan_record SearchBysrid(int srid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan_record">shuadan_record表实例</param>
        /// <returns>int</returns>
        int Insert(shuadan_record shuadan_recordExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_record">shuadan_record表实例</param>
        /// <returns>int</returns>
        int Update(shuadan_record shuadan_recordExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="srid">编号</param>
        /// <returns>int</returns>
        int Delete(int srid);
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
        int SearchNum(string key, string state, string _type, DateTime date1, DateTime date2);

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
        /// <returns>IList<shuadan_record></returns>
        IList<shuadan_record> Search(int s, int e, string key, string state, string _type, DateTime date1, DateTime date2);

        #endregion


    }
}

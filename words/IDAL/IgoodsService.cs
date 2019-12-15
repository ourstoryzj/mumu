using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace IDAL
{
    /*IDAL*/
    public interface IgoodsService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        IList<goods> SearchAll();
        #endregion

        #region SearchBygid
        /// <summary>
        /// 根据gid,查询一条数据
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <returns></returns>
        /*查看是否为视图*/
        goods SearchBygid(int gid);
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="goods">goods表实例</param>
        /// <returns>int</returns>
        int Insert(goods goodsExample);
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="goods">goods表实例</param>
        /// <returns>int</returns>
        int Update(goods goodsExample);
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gid">商品ID</param>
        /// <returns>int</returns>
        int Delete(int gid);
        #endregion


        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state_img">图片状态 0:不查,1:未上传,2:已上传</param>
        /// <param name="state_up">上架状态 0:不查,1:未上架,2:已上架</param>
        /// <param name="state_title">图片状态 0:不查,1:未上传,2:已上传</param>
        /// <param name="hasImg_tb">是否有淘宝图片 空:不查询,1:不是空,0:空</param>
        /// <param name="hasImg_mgj">是否有蘑菇街图片 空:不查询,1:不是空,0:空</param>
        /// <param name="dt1_add">添加商品起始时间</param>
        /// <param name="dt2_add">添加商品结束时间</param>
        /// <param name="important">是否是重点商品 1是 0不是</param>
        /// <returns>int</returns>
        int SearchNum(string key, int gt, string state_img, string state_up, string state_title, string hasImg_tb, string hasImg_mgj, DateTime dt1_add, DateTime dt2_add, string important);

        #endregion

        #region Search
        /// <summary>
        /// 条件搜索
        /// </summary>
        /// <param name="s">起始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="gt">商品类型</param>
        /// <param name="state_img">图片状态 0:不查,1:未上传,2:已上传</param>
        /// <param name="state_up">上架状态 0:不查,1:未上架,2:已上架</param>
        /// <param name="state_title">图片状态 0:不查,1:未上传,2:已上传</param>
        /// <param name="hasImg_tb">是否有淘宝图片 空:不查询,1:不是空,0:空</param>
        /// <param name="hasImg_mgj">是否有蘑菇街图片 空:不查询,1:不是空,0:空</param>
        /// <param name="dt1_add">添加商品起始时间</param>
        /// <param name="dt2_add">添加商品结束时间</param>
        /// <param name="important">是否是重点商品 1是 0不是</param>
        /// <returns>IList<goods></returns>
        IList<goods> Search(int s, int e, string key, int gt, string state_img, string state_up, string state_title, string hasImg_tb, string hasImg_mgj, DateTime dt1_add, DateTime dt2_add, string important);

        #endregion
    }
}

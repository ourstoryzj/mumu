using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{

    /*BLL*/
    public class basic_goods_wordManager
    {

        private static Ibasic_goods_wordService Service = new DAL.basic_goods_wordService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<basic_goods_word> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据gwid,查询一条数据
        /// </summary>
        /// <param name="gwid">补单关键词编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static basic_goods_word SearchByID(int gwid)
        {
            return Service.SearchByID(gwid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="basic_goods_word">basic_goods_word表实例</param>
        /// <returns>int</returns>
        public static int Insert(basic_goods_word basic_goods_wordExample)
        {
            return Service.Insert(basic_goods_wordExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_goods_word">basic_goods_word表实例</param>
        /// <returns>int</returns>
        public static int Update(basic_goods_word basic_goods_wordExample)
        {
            return Service.Update(basic_goods_wordExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="gwid">补单关键词编号</param>
        /// <returns>int</returns>
        public static int Delete(int gwid)
        {
            return Service.Delete(gwid);
        }
        #endregion



        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="bgid">商品编号</param>
        /// <param name="state">状态</param>
        /// <param name="bgkey">是否重点</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <returns>int</returns>
        public static int SearchNum(string key, int bgid, string state, string bgkey, DateTime dt1_add, DateTime dt2_add)
        {
            return Service.SearchNum(key, bgid, state, bgkey, dt1_add, dt2_add);
        }
        #endregion

        #region Search
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="s">开始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="bgid">商品编号</param>
        /// <param name="state">状态</param>
        /// <param name="bgkey">是否重点</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_goods_word></returns>
        public static IList<basic_goods_word> Search(int s, int e, string key, int bgid, string state, string bgkey, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            return Service.Search(s, e, key, bgid, state, bgkey, dt1_add, dt2_add, orderby);
        }
        #endregion

    }



}

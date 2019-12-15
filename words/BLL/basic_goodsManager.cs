using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;

namespace BLL
{

    /*BLL*/
    public class basic_goodsManager
    {

        private static Ibasic_goodsService Service = new DAL.basic_goodsService();

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<basic_goods> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据bgid,查询一条数据
        /// </summary>
        /// <param name="bgid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static basic_goods SearchByID(int bgid)
        {
            return Service.SearchByID(bgid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="basic_goods">basic_goods表实例</param>
        /// <returns>int</returns>
        public static int Insert(basic_goods basic_goodsExample)
        {
            return Service.Insert(basic_goodsExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="basic_goods">basic_goods表实例</param>
        /// <returns>int</returns>
        public static int Update(basic_goods basic_goodsExample)
        {
            return Service.Update(basic_goodsExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="bgid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int bgid)
        {
            return Service.Delete(bgid);
        }
        #endregion


        #region SearchNum
        /// <summary>
        /// 搜索条数
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="opid">订单计划编号</param>
        /// <param name="hdid">活动编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="state">状态</param>
        /// <param name="bgkey">是否重点</param>
        /// <param name="dt1_up">上架时间</param>
        /// <param name="dt2_up">上架时间</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间</param>
        /// <returns></returns>
        public static int SearchNum(string key, int opid, int hdid, int dpid, string state, string bgkey, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add)
        {
            return Service.SearchNum(key, opid, hdid, dpid, state, bgkey, dt1_up, dt2_up, dt1_add, dt2_add);
        }
        #endregion

        #region Search
        /// <summary>
        /// 搜索条件
        /// </summary>
        /// <param name="s">开始位置</param>
        /// <param name="e">结束位置</param>
        /// <param name="key">关键词</param>
        /// <param name="opid">补单计划编号</param>
        /// <param name="hdid">活动编号</param>
        /// <param name="dpid">店铺编号</param>
        /// <param name="state">状态 1是 2否</param>
        /// <param name="bgkey">知否重点 1是 2否</param>
        /// <param name="dt1_up">上架时间</param>
        /// <param name="dt2_up">上架时间2</param>
        /// <param name="dt1_add">添加时间</param>
        /// <param name="dt2_add">添加时间2</param>
        /// <param name="orderby">排序方式,直接输入order by后面的语句</param>
        /// <returns>IList<basic_goods></returns>
        public static IList<basic_goods> Search(int s, int e, string key, int opid, int hdid, int dpid, string state, string bgkey, DateTime dt1_up, DateTime dt2_up, DateTime dt1_add, DateTime dt2_add, string orderby)
        {
            return Service.Search(s, e, key, opid, hdid, dpid, state, bgkey, dt1_up, dt2_up, dt1_add, dt2_add, orderby);
        }
        #endregion


        #region GetListByOrder
        /// <summary>
        /// 获取需要补单或者需要报名活动的商品列表
        /// </summary>
        /// <returns></returns>
        public static IList<basic_goods> GetListByOrder()
        {
            DateTime temp_date1 = new DateTime();
            DateTime temp_date2 = new DateTime();
            DateTime temp_date3 = new DateTime();
            DateTime temp_date4 = new DateTime();
            int temp_dp = 0;
            int temp_op = 0;
            int temp_hp = 0;
            string state = "1";
            string key = "";
            string iskey = "";

            IList<basic_goods> list = BLL.basic_goodsManager.Search(1, 10000, key, temp_op, temp_hp, temp_dp, state, iskey, temp_date1, temp_date2, temp_date3, temp_date4, "");
            List<basic_goods> list_res = new List<basic_goods>();

            foreach (basic_goods bg in list)
            {
                //补单
                int temp_order = basic_order_planManager.GetNumInPlan(bg.bgupdate, bg.opid); ;
                if (temp_order != 0)
                {
                    int _order_count = BLL.basic_order_recordManager.SearchNum("", bg.bgid, 0, 0, "", "", DateTime.Now, DateTime.Now);
                    if (temp_order - _order_count > 0)
                    {
                        list_res.Add(bg);
                        continue;
                    }
                }


                //活动提示
                basic_huodong hd = basic_huodongManager.SearchByID(bg.hdid);
                int temp_huodong = Manager.DateDiff_GetInt(DateTime.Now, bg.bgupdate) + 1;
                if (temp_huodong == hd.hdone || temp_huodong == hd.hdtwo)
                {
                    list_res.Add(bg);
                    continue;
                }
            }


            return list_res;
        }
        #endregion

    }

}

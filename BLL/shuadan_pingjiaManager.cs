using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.Threading;

namespace BLL
{

    /*BLL*/
    public class shuadan_pingjiaManager
    {

        private static Ishuadan_pingjiaService Service = Manager.factory.Createshuadan_pingjiaService();
        
       

        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shuadan_pingjia> SearchAll()
        {
            return Service.SearchAll();
        }
        #endregion

        #region SearchByspid
        /// <summary>
        /// 根据spid,查询一条数据
        /// </summary>
        /// <param name="spid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/
        public static shuadan_pingjia SearchByspid(int spid)
        {
            return Service.SearchByspid(spid);
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="shuadan_pingjia">shuadan_pingjia表实例</param>
        /// <returns>int</returns>
        public static int Insert(shuadan_pingjia shuadan_pingjiaExample)
        {
            return Service.Insert(shuadan_pingjiaExample);
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="shuadan_pingjia">shuadan_pingjia表实例</param>
        /// <returns>int</returns>
        public static int Update(shuadan_pingjia shuadan_pingjiaExample)
        {
            return Service.Update(shuadan_pingjiaExample);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spid">编号</param>
        /// <returns>int</returns>
        public static int Delete(int spid)
        {
            return Service.Delete(spid);
        }
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
        public static int SearchNum(string key, string state, string _type, DateTime date1, DateTime date2)
        {
            return Service.SearchNum(key, state, _type, date1, date2);
        }
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
        /// <returns>IList<shuadan_pingjia></returns>
        public static IList<shuadan_pingjia> Search(int s, int e, string key, string state, string _type, DateTime date1, DateTime date2, string top)
        {
            return Service.Search(s, e, key, state, _type, date1, date2, top);
        }
        #endregion

        #region SearchRnd
        /// <summary>
        /// 随机查询名字
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public static IList<shuadan_pingjia> SearchRnd(int num, string key, string state, string _type, DateTime date1, DateTime date2)
        {
            return Service.SearchRnd(num, key, state, _type, date1, date2);
        }
        #endregion

        #region GetPingjia
        /// <summary>
        /// 获取评价数组
        /// </summary>
        /// <param name="num">评价条数</param>
        /// <param name="s">评价句数</param>
        /// <param name="e">评价句数</param>
        /// <param name="sTime">评价起始时间</param>
        /// <param name="eTime">评价结束时间</param>
        /// <returns>List<string></returns>
        public static List<string> GetPingjia(int num, int s, int e, DateTime sTime, DateTime eTime)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < num; i++)
            {

                int temp = Manager.RandomNumber(s, e);
                string temp_str = "";
                IList<shuadan_pingjia> list2 = SearchRnd(temp, "", "1", "1", sTime, eTime);

                
                //获取质量评语随机位置
                int temp_zhiliang = Manager.RandomNumber(1, temp);

                int zhiliang = 1;
                foreach (shuadan_pingjia sp in list2)
                {
                    if (temp % 2 == 0)
                    {
                        if (zhiliang == temp_zhiliang)
                        {
                            //判断是否为偶数,如果是偶数则添加质量评语
                            shuadan_pingjia sp_zhiliang = new shuadan_pingjia();
                            IList<shuadan_pingjia> temp_list = SearchRnd(1, "", "1", "2", new DateTime(), new DateTime());
                            if (temp_list.Count > 0)
                            {
                                sp_zhiliang = temp_list[0];
                                temp_str = temp_str + sp_zhiliang.spname + ",";
                            }
                        }
                        zhiliang++;
                    }

                    temp_str = temp_str + sp.spname + ",";
                }
                IList<shuadan_pingjia> list3 = SearchRnd(1, "", "1", "3", sTime, eTime);
                temp_str = temp_str + (list3.Count > 0 ? list3[0].spname : "");
                list.Add(temp_str);
            }
            return list;
        }
        #endregion



        //private static readonly ThreadLocal<Random> appRandom = new ThreadLocal<Random>(() => new Random());

        //public static int GetRandomNumber()
        //{
        //    return appRandom.Value.Next();
        //}

       


    }


}

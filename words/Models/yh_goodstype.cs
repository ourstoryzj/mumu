/*
系统名称：Entity
作    者：张建
完成日期：2015-03-27
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: yh_goodstype
    /// </summary>
    [Serializable]
    public class yh_goodstype
    {
        //商品类型名称		
        private string m_gtanme;

        //商品类型时间		
        private DateTime m_gtdate;

        //商品类型		
        private int m_gtid;

        //商品类型排序		
        private string m_gtsort;

        //商品类型状态		
        private string m_gtstate;



        /// <summary>
        /// 商品类型名称
        /// </summary>
        public string gtanme
        {
            get { return m_gtanme; }
            set { m_gtanme = value; }
        }
        /// <summary>
        /// 商品类型时间
        /// </summary>
        public DateTime gtdate
        {
            get { return m_gtdate; }
            set { m_gtdate = value; }
        }
        /// <summary>
        /// 商品类型
        /// </summary>
        public int gtid
        {
            get { return m_gtid; }
            set { m_gtid = value; }
        }
        /// <summary>
        /// 商品类型排序
        /// </summary>
        public string gtsort
        {
            get { return m_gtsort; }
            set { m_gtsort = value; }
        }
        /// <summary>
        /// 商品类型状态
        /// </summary>
        public string gtstate
        {
            get { return m_gtstate; }
            set { m_gtstate = value; }
        }
    }
}





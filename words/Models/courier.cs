/*
系统名称：Entity
作    者：张建
完成日期：2015-06-30
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: courier
    /// </summary>
    [Serializable]
    public class courier
    {
        //快递编号		
        private int m_cid;

        //快递名称		
        private string m_cname;

        //备注		
        private string m_cremark;

        //排序		
        private int m_csort;



        /// <summary>
        /// 快递编号
        /// </summary>
        public int cid
        {
            get { return m_cid; }
            set { m_cid = value; }
        }
        /// <summary>
        /// 快递名称
        /// </summary>
        public string cname
        {
            get { return m_cname; }
            set { m_cname = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string cremark
        {
            get { return m_cremark; }
            set { m_cremark = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int csort
        {
            get { return m_csort; }
            set { m_csort = value; }
        }
    }
}





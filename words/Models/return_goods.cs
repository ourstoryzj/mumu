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
    /// class: return_goods
    /// </summary>
    [Serializable]
    public class return_goods
    {
        //快递编号		
        private int m_cid;

        //快递名称		
        private string m_cname;

        //快递单号		
        private string m_rgcode;

        //登记时间		
        private DateTime m_rgdate;

        //退货编号		
        private int m_rgid;

        //备注		
        private string m_rgremark;



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
        /// 快递单号
        /// </summary>
        public string rgcode
        {
            get { return m_rgcode; }
            set { m_rgcode = value; }
        }
        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime rgdate
        {
            get { return m_rgdate; }
            set { m_rgdate = value; }
        }
        /// <summary>
        /// 退货编号
        /// </summary>
        public int rgid
        {
            get { return m_rgid; }
            set { m_rgid = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string rgremark
        {
            get { return m_rgremark; }
            set { m_rgremark = value; }
        }
    }
}





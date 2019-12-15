/*
系统名称：Entity
作    者：张建
完成日期：2017-02-06
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: wanggong_dianpu
    /// </summary>
    [Serializable]
    public class wanggong_dianpu
    {
        //编号		
        private int m_wid;

        //网供名称		
        private string m_wdpname;

        //网供店铺ID		
        private string m_wdTBID;

        //采集时间		
        private DateTime m_wdcollectdate;

        //旺旺		
        private string m_wdwangwang;

        //状态 1 启用 2 禁用		
        private string m_wdstate;

        //备用字段1		
        private string m_wdremark1;

        //备用字段2		
        private string m_wdremark2;

        //备用字段3		
        private string m_wdremark3;

        //备用字段4		
        private string m_wdremark4;



        /// <summary>
        /// 编号
        /// </summary>
        public int wid
        {
            get { return m_wid; }
            set { m_wid = value; }
        }
        /// <summary>
        /// 网供名称
        /// </summary>
        public string wdpname
        {
            get { return m_wdpname; }
            set { m_wdpname = value; }
        }
        /// <summary>
        /// 网供店铺ID
        /// </summary>
        public string wdTBID
        {
            get { return m_wdTBID; }
            set { m_wdTBID = value; }
        }
        /// <summary>
        /// 采集时间
        /// </summary>
        public DateTime wdcollectdate
        {
            get { return m_wdcollectdate; }
            set { m_wdcollectdate = value; }
        }
        /// <summary>
        /// 旺旺
        /// </summary>
        public string wdwangwang
        {
            get { return m_wdwangwang; }
            set { m_wdwangwang = value; }
        }
        /// <summary>
        /// 状态 1 启用 2 禁用
        /// </summary>
        public string wdstate
        {
            get { return m_wdstate; }
            set { m_wdstate = value; }
        }
        /// <summary>
        /// 备用字段1
        /// </summary>
        public string wdremark1
        {
            get { return m_wdremark1; }
            set { m_wdremark1 = value; }
        }
        /// <summary>
        /// 备用字段2
        /// </summary>
        public string wdremark2
        {
            get { return m_wdremark2; }
            set { m_wdremark2 = value; }
        }
        /// <summary>
        /// 备用字段3
        /// </summary>
        public string wdremark3
        {
            get { return m_wdremark3; }
            set { m_wdremark3 = value; }
        }
        /// <summary>
        /// 备用字段4
        /// </summary>
        public string wdremark4
        {
            get { return m_wdremark4; }
            set { m_wdremark4 = value; }
        }

    }
}

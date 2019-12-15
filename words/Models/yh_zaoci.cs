/*
系统名称：Entity
作    者：张建
完成日期：2017-02-25
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: yh_zaoci
    /// </summary>
    [Serializable]
    public class yh_zaoci
    {
        //编号		
        private int m_zid;

        //噪词名称		
        private string m_zname;

        //添加时间		
        private DateTime m_zdate;

        //状态 1 启用 2 禁用		
        private string m_zstate;

        //父ID		
        private int m_gtid;

        //备用		
        private string m_gtname;

        //排序		
        private int m_zsort;



        /// <summary>
        /// 编号
        /// </summary>
        public int zid
        {
            get { return m_zid; }
            set { m_zid = value; }
        }
        /// <summary>
        /// 噪词名称
        /// </summary>
        public string zname
        {
            get { return m_zname; }
            set { m_zname = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime zdate
        {
            get { return m_zdate; }
            set { m_zdate = value; }
        }
        /// <summary>
        /// 状态 1 启用 2 禁用
        /// </summary>
        public string zstate
        {
            get { return m_zstate; }
            set { m_zstate = value; }
        }
        /// <summary>
        /// 父ID
        /// </summary>
        public int gtid
        {
            get { return m_gtid; }
            set { m_gtid = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string gtname
        {
            get { return m_gtname; }
            set { m_gtname = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int zsort
        {
            get { return m_zsort; }
            set { m_zsort = value; }
        }

    }
}

/*
系统名称：Entity
作    者：张建
完成日期：2016-10-18
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: basic_task
    /// </summary>
    [Serializable]
    public class basic_task
    {
        //编号		
        private int m_btid;

        //任务名称		
        private string m_btname;

        //任务内容		
        private string m_btcontent;

        //任务状态		
        private string m_btstate;

        //执行时间		
        private DateTime m_btdate;

        //记录时间		
        private DateTime m_btdate2;

        //备用		
        private string m_btspare1;

        //备用		
        private string m_btspare2;

        //备用		
        private string m_btspare3;

        //备用		
        private string m_btspare4;

        //备用		
        private string m_btspare5;



        /// <summary>
        /// 编号
        /// </summary>
        public int btid
        {
            get { return m_btid; }
            set { m_btid = value; }
        }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string btname
        {
            get { return m_btname; }
            set { m_btname = value; }
        }
        /// <summary>
        /// 任务内容
        /// </summary>
        public string btcontent
        {
            get { return m_btcontent; }
            set { m_btcontent = value; }
        }
        /// <summary>
        /// 任务状态
        /// </summary>
        public string btstate
        {
            get { return m_btstate; }
            set { m_btstate = value; }
        }
        /// <summary>
        /// 执行时间
        /// </summary>
        public DateTime btdate
        {
            get { return m_btdate; }
            set { m_btdate = value; }
        }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime btdate2
        {
            get { return m_btdate2; }
            set { m_btdate2 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string btspare1
        {
            get { return m_btspare1; }
            set { m_btspare1 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string btspare2
        {
            get { return m_btspare2; }
            set { m_btspare2 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string btspare3
        {
            get { return m_btspare3; }
            set { m_btspare3 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string btspare4
        {
            get { return m_btspare4; }
            set { m_btspare4 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string btspare5
        {
            get { return m_btspare5; }
            set { m_btspare5 = value; }
        }

    }
}

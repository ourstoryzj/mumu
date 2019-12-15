/*
系统名称：Entity
作    者：张建
完成日期：2015-05-04
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: pages
    /// </summary>
    [Serializable]
    public class pages
    {
        //页面内容		
        private string m_pcontext;

        //更新时间		
        private DateTime m_pdate;

        //页面编号		
        private int m_pid;

        //页面标题		
        private string m_pname;

        //页面排序		
        private int m_psort;

        //状态 1:启用2禁用		
        private string m_pstate;

        //页面类型编号		
        private int m_ptid;



        /// <summary>
        /// 页面内容
        /// </summary>
        public string pcontext
        {
            get { return m_pcontext; }
            set { m_pcontext = value; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime pdate
        {
            get { return m_pdate; }
            set { m_pdate = value; }
        }
        /// <summary>
        /// 页面编号
        /// </summary>
        public int pid
        {
            get { return m_pid; }
            set { m_pid = value; }
        }
        /// <summary>
        /// 页面标题
        /// </summary>
        public string pname
        {
            get { return m_pname; }
            set { m_pname = value; }
        }
        /// <summary>
        /// 页面排序
        /// </summary>
        public int psort
        {
            get { return m_psort; }
            set { m_psort = value; }
        }
        /// <summary>
        /// 状态 1:启用2禁用
        /// </summary>
        public string pstate
        {
            get { return m_pstate; }
            set { m_pstate = value; }
        }
        /// <summary>
        /// 页面类型编号
        /// </summary>
        public int ptid
        {
            get { return m_ptid; }
            set { m_ptid = value; }
        }
    }
}





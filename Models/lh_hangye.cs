/*
系统名称：Entity
作    者：张建
完成日期：2019-06-24
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: lh_hangye
    /// </summary>
    [Serializable]
    public class lh_hangye
    {
        //行业ID		
        private int m_hid;

        //行业名称		
        private string m_hname;

        //状态		
        private string m_hstate;

        //时间		
        private DateTime m_hdate;

        //备注		
        private string m_hremark;



        /// <summary>
        /// 行业ID
        /// </summary>
        public int hid
        {
            get { return m_hid; }
            set { m_hid = value; }
        }
        /// <summary>
        /// 行业名称
        /// </summary>
        public string hname
        {
            get { return m_hname; }
            set { m_hname = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string hstate
        {
            get { return m_hstate; }
            set { m_hstate = value; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime hdate
        {
            get { return m_hdate; }
            set { m_hdate = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string hremark
        {
            get { return m_hremark; }
            set { m_hremark = value; }
        }

    }
}

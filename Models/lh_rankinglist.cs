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
    /// class: lh_rankinglist
    /// </summary>
    [Serializable]
    public class lh_rankinglist
    {
        //排行榜id		
        private int m_rid;

        //关键词名称		
        private string m_rkey;

        //状态		
        private string m_rstate;

        //时间		
        private DateTime m_rdate;

        //行业ID		
        private int m_hid;

        //备注

        private string m_hremark;



        /// <summary>
        /// 排行榜id
        /// </summary>
        public int rid
        {
            get { return m_rid; }
            set { m_rid = value; }
        }
        /// <summary>
        /// 关键词名称
        /// </summary>
        public string rkey
        {
            get { return m_rkey; }
            set { m_rkey = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string rstate
        {
            get { return m_rstate; }
            set { m_rstate = value; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime rdate
        {
            get { return m_rdate; }
            set { m_rdate = value; }
        }
        /// <summary>
        /// 行业ID
        /// </summary>
        public int hid
        {
            get { return m_hid; }
            set { m_hid = value; }
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

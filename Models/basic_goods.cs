/*
系统名称：Entity
作    者：张建
完成日期：2016-09-19
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: basic_goods
    /// </summary>
    [Serializable]
    public class basic_goods
    {
        //编号		
        private int m_bgid;

        //Name:bgname Type:varchar		
        private string m_bgname;

        //Name:bgurl Type:varchar		
        private string m_bgurl;

        //Name:bgupdate Type:datetime		
        private DateTime m_bgupdate;

        //补单计划编号		
        private int m_opid;

        //活动规划编号		
        private int m_hdid;

        //店铺编号		
        private int m_dpid;

        //店铺名称		
        private string m_dpname;

        //状态 1有效 2无效		
        private string m_bgstate;

        //添加时间		
        private DateTime m_bgdate;

        //备注		
        private string m_bgremark;

        //是否关键 1是 2 不是		
        private string m_bgkey;



        /// <summary>
        /// 编号
        /// </summary>
        public int bgid
        {
            get { return m_bgid; }
            set { m_bgid = value; }
        }
        /// <summary>
        /// Name:bgname Type:varchar
        /// </summary>
        public string bgname
        {
            get { return m_bgname; }
            set { m_bgname = value; }
        }
        /// <summary>
        /// Name:bgurl Type:varchar
        /// </summary>
        public string bgurl
        {
            get { return m_bgurl; }
            set { m_bgurl = value; }
        }
        /// <summary>
        /// Name:bgupdate Type:datetime
        /// </summary>
        public DateTime bgupdate
        {
            get { return m_bgupdate; }
            set { m_bgupdate = value; }
        }
        /// <summary>
        /// 补单计划编号
        /// </summary>
        public int opid
        {
            get { return m_opid; }
            set { m_opid = value; }
        }
        /// <summary>
        /// 活动规划编号
        /// </summary>
        public int hdid
        {
            get { return m_hdid; }
            set { m_hdid = value; }
        }
        /// <summary>
        /// 店铺编号
        /// </summary>
        public int dpid
        {
            get { return m_dpid; }
            set { m_dpid = value; }
        }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string dpname
        {
            get { return m_dpname; }
            set { m_dpname = value; }
        }
        /// <summary>
        /// 状态 1有效 2无效
        /// </summary>
        public string bgstate
        {
            get { return m_bgstate; }
            set { m_bgstate = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime bgdate
        {
            get { return m_bgdate; }
            set { m_bgdate = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string bgremark
        {
            get { return m_bgremark; }
            set { m_bgremark = value; }
        }
        /// <summary>
        /// 是否关键 1是 2 不是
        /// </summary>
        public string bgkey
        {
            get { return m_bgkey; }
            set { m_bgkey = value; }
        }

    }
}

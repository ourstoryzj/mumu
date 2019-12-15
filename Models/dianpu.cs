/*
系统名称：Entity
作    者：张建
完成日期：2019-07-02
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: dianpu
    /// </summary>
    [Serializable]
    public class dianpu
    {
        //Name:dpid Type:int		
        private int m_dpid;

        //Name:dpname Type:nvarchar		
        private string m_dpname;

        //Name:dpremark Type:nvarchar		
        private string m_dpremark;

        //Name:dpstate Type:nvarchar		
        private string m_dpstate;

        //Name:dpsort Type:int		
        private int m_dpsort;

        //Name:dpaccount Type:varchar		
        private string m_dpaccount;

        //Name:dppwd Type:varchar		
        private string m_dppwd;

        //Name:dpremark1 Type:varchar		
        private string m_dpremark1;

        //Name:dpremark2 Type:varchar		
        private string m_dpremark2;

        //Name:dpremark3 Type:varchar		
        private string m_dpremark3;

        //Name:dpremark4 Type:varchar		
        private string m_dpremark4;



        /// <summary>
        /// Name:dpid Type:int
        /// </summary>
        public int dpid
        {
            get { return m_dpid; }
            set { m_dpid = value; }
        }
        /// <summary>
        /// Name:dpname Type:nvarchar
        /// </summary>
        public string dpname
        {
            get { return m_dpname; }
            set { m_dpname = value; }
        }
        /// <summary>
        /// Name:dpremark Type:nvarchar
        /// </summary>
        public string dpremark
        {
            get { return m_dpremark; }
            set { m_dpremark = value; }
        }
        /// <summary>
        /// Name:dpstate Type:nvarchar
        /// </summary>
        public string dpstate
        {
            get { return m_dpstate; }
            set { m_dpstate = value; }
        }
        /// <summary>
        /// Name:dpsort Type:int
        /// </summary>
        public int dpsort
        {
            get { return m_dpsort; }
            set { m_dpsort = value; }
        }
        /// <summary>
        /// Name:dpaccount Type:varchar
        /// </summary>
        public string dpaccount
        {
            get { return m_dpaccount; }
            set { m_dpaccount = value; }
        }
        /// <summary>
        /// Name:dppwd Type:varchar
        /// </summary>
        public string dppwd
        {
            get { return m_dppwd; }
            set { m_dppwd = value; }
        }
        /// <summary>
        /// Name:dpremark1 Type:varchar
        /// </summary>
        public string dpremark1
        {
            get { return m_dpremark1; }
            set { m_dpremark1 = value; }
        }
        /// <summary>
        /// Name:dpremark2 Type:varchar
        /// </summary>
        public string dpremark2
        {
            get { return m_dpremark2; }
            set { m_dpremark2 = value; }
        }
        /// <summary>
        /// Name:dpremark3 Type:varchar
        /// </summary>
        public string dpremark3
        {
            get { return m_dpremark3; }
            set { m_dpremark3 = value; }
        }
        /// <summary>
        /// Name:dpremark4 Type:varchar
        /// </summary>
        public string dpremark4
        {
            get { return m_dpremark4; }
            set { m_dpremark4 = value; }
        }

    }
}

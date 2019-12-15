/*
系统名称：Entity
作    者：张建
完成日期：2015-07-07
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: huashu
    /// </summary>
    [Serializable]
    public class huashu
    {
        //Name:hid Type:int		
        private int m_hid;

        //Name:hfid Type:int		
        private int m_hfid;

        //Name:htitle Type:varchar		
        private string m_htitle;

        //Name:hcontext Type:varchar		
        private string m_hcontext;

        //Name:hsort Type:int		
        private int m_hsort;

        //Name:hcount Type:int		
        private int m_hcount;

        //Name:hdate Type:datetime		
        private DateTime m_hdate;

        //Name:hstate Type:varchar		
        private string m_hstate;



        /// <summary>
        /// Name:hid Type:int
        /// </summary>
        public int hid
        {
            get { return m_hid; }
            set { m_hid = value; }
        }
        /// <summary>
        /// Name:hfid Type:int
        /// </summary>
        public int hfid
        {
            get { return m_hfid; }
            set { m_hfid = value; }
        }
        /// <summary>
        /// Name:htitle Type:varchar
        /// </summary>
        public string htitle
        {
            get { return m_htitle; }
            set { m_htitle = value; }
        }
        /// <summary>
        /// Name:hcontext Type:varchar
        /// </summary>
        public string hcontext
        {
            get { return m_hcontext; }
            set { m_hcontext = value; }
        }
        /// <summary>
        /// Name:hsort Type:int
        /// </summary>
        public int hsort
        {
            get { return m_hsort; }
            set { m_hsort = value; }
        }
        /// <summary>
        /// Name:hcount Type:int
        /// </summary>
        public int hcount
        {
            get { return m_hcount; }
            set { m_hcount = value; }
        }
        /// <summary>
        /// Name:hdate Type:datetime
        /// </summary>
        public DateTime hdate
        {
            get { return m_hdate; }
            set { m_hdate = value; }
        }
        /// <summary>
        /// Name:hstate Type:varchar
        /// </summary>
        public string hstate
        {
            get { return m_hstate; }
            set { m_hstate = value; }
        }

    }
}

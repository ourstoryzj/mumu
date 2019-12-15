/*
系统名称：Entity
作    者：张建
完成日期：2015-07-27
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: Admins
    /// </summary>
    [Serializable]
    public class Admins
    {
        //Name:aid Type:int		
        private int m_aid;

        //Name:aaccount Type:nvarchar		
        private string m_aaccount;

        //Name:apassword Type:nvarchar		
        private string m_apassword;

        //Name:alogintime Type:datetime		
        private DateTime m_alogintime;

        //Name:astate Type:nvarchar		
        private string m_astate;

        //Name:atype Type:varchar		
        private string m_atype;



        /// <summary>
        /// Name:aid Type:int
        /// </summary>
        public int aid
        {
            get { return m_aid; }
            set { m_aid = value; }
        }
        /// <summary>
        /// Name:aaccount Type:nvarchar
        /// </summary>
        public string aaccount
        {
            get { return m_aaccount; }
            set { m_aaccount = value; }
        }
        /// <summary>
        /// Name:apassword Type:nvarchar
        /// </summary>
        public string apassword
        {
            get { return m_apassword; }
            set { m_apassword = value; }
        }
        /// <summary>
        /// Name:alogintime Type:datetime
        /// </summary>
        public DateTime alogintime
        {
            get { return m_alogintime; }
            set { m_alogintime = value; }
        }
        /// <summary>
        /// Name:astate Type:nvarchar
        /// </summary>
        public string astate
        {
            get { return m_astate; }
            set { m_astate = value; }
        }
        /// <summary>
        /// Name:atype Type:varchar
        /// </summary>
        public string atype
        {
            get { return m_atype; }
            set { m_atype = value; }
        }

    }
}

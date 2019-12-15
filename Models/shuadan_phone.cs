/*
系统名称：Entity
作    者：张建
完成日期：2015-04-26
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: shuadan_phone
    /// </summary>
    [Serializable]
    public class shuadan_phone
    {
        //Name:sdpcode Type:adLongVarWChar		
        private string m_sdpcode;

        //Name:sdpdate Type:adDate		
        private DateTime m_sdpdate;

        //Name:sdpid Type:adInteger		
        private int m_sdpid;

        //Name:sdpstate Type:adVarWChar		
        private string m_sdpstate;



        /// <summary>
        /// Name:sdpcode Type:adLongVarWChar
        /// </summary>
        public string sdpcode
        {
            get { return m_sdpcode; }
            set { m_sdpcode = value; }
        }
        /// <summary>
        /// Name:sdpdate Type:adDate
        /// </summary>
        public DateTime sdpdate
        {
            get { return m_sdpdate; }
            set { m_sdpdate = value; }
        }
        /// <summary>
        /// Name:sdpid Type:adInteger
        /// </summary>
        public int sdpid
        {
            get { return m_sdpid; }
            set { m_sdpid = value; }
        }
        /// <summary>
        /// Name:sdpstate Type:adVarWChar
        /// </summary>
        public string sdpstate
        {
            get { return m_sdpstate; }
            set { m_sdpstate = value; }
        }
    }
}





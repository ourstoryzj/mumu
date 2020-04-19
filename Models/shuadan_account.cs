/*
系统名称：Entity
作    者：张建
完成日期：2020-04-15
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: shuadan_account
    /// </summary>
    [Serializable]
    public class shuadan_account
    {
        //Name:sdaid Type:int
        private int m_sdaid;

        //Name:sdaccount Type:varchar
        private string m_sdaccount;

        //Name:sdapwd Type:varchar
        private string m_sdapwd;

        //Name:sdastate Type:nvarchar
        private string m_sdastate;

        //Name:sdadate Type:datetime
        private DateTime m_sdadate;

        //手机或者QQ
        private string m_sdaphone;

        //Name:sdaremark Type:varchar
        private string m_sdaremark;

        //Name:sdaremark1 Type:varchar
        private string m_sdaremark1;



        ///<summary>
        ///Name:sdaid Type:int
        ///</summary>
        public int sdaid
        {
            get { return m_sdaid; }
            set { m_sdaid = value; }
        }
        ///<summary>
        ///Name:sdaccount Type:varchar
        ///</summary>
        public string sdaccount
        {
            get { return m_sdaccount; }
            set { m_sdaccount = value; }
        }
        ///<summary>
        ///Name:sdapwd Type:varchar
        ///</summary>
        public string sdapwd
        {
            get { return m_sdapwd; }
            set { m_sdapwd = value; }
        }
        ///<summary>
        ///Name:sdastate Type:nvarchar
        ///</summary>
        public string sdastate
        {
            get { return m_sdastate; }
            set { m_sdastate = value; }
        }
        ///<summary>
        ///Name:sdadate Type:datetime
        ///</summary>
        public DateTime sdadate
        {
            get { return m_sdadate; }
            set { m_sdadate = value; }
        }
        ///<summary>
        ///手机或者QQ
        ///</summary>
        public string sdaphone
        {
            get { return m_sdaphone; }
            set { m_sdaphone = value; }
        }
        ///<summary>
        ///Name:sdaremark Type:varchar
        ///</summary>
        public string sdaremark
        {
            get { return m_sdaremark; }
            set { m_sdaremark = value; }
        }
        ///<summary>
        ///Name:sdaremark1 Type:varchar
        ///</summary>
        public string sdaremark1
        {
            get { return m_sdaremark1; }
            set { m_sdaremark1 = value; }
        }

    }
}
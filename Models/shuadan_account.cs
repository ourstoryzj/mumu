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
    /// class: shuadan_account
    /// </summary>
    [Serializable]
    public class shuadan_account
    {
        //账号		
        private string m_sdaccount;

        //录入时间		
        private DateTime m_sdadate;

        //编号		
        private int m_sdaid;

        //密码		
        private string m_sdapwd;

        //备用字段		
        private string m_sdastandby;

        //账号状态		
        private string m_sdastate;

        //手机号状态(是否使用过) 1使用 0未使用(默认)		
        private string m_sdastate_phone;



        /// <summary>
        /// 账号
        /// </summary>
        public string sdaccount
        {
            get { return m_sdaccount; }
            set { m_sdaccount = value; }
        }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime sdadate
        {
            get { return m_sdadate; }
            set { m_sdadate = value; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int sdaid
        {
            get { return m_sdaid; }
            set { m_sdaid = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string sdapwd
        {
            get { return m_sdapwd; }
            set { m_sdapwd = value; }
        }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string sdastandby
        {
            get { return m_sdastandby; }
            set { m_sdastandby = value; }
        }
        /// <summary>
        /// 账号状态
        /// </summary>
        public string sdastate
        {
            get { return m_sdastate; }
            set { m_sdastate = value; }
        }
        /// <summary>
        /// 手机号状态(是否使用过) 1使用 0未使用(默认)
        /// </summary>
        public string sdastate_phone
        {
            get { return m_sdastate_phone; }
            set { m_sdastate_phone = value; }
        }
    }
}





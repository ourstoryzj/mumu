/*
系统名称：Entity
作    者：张建
完成日期：2018-06-04
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: subway_goods
    /// </summary>
    [Serializable]
    public class subway_goods
    {
        //编号		
        private int m_sgid;

        //淘宝编号		
        private string m_sgcampaignid;

        //名称		
        private string m_sgname;

        //备注		
        private string m_sgremark;

        //添加时间		
        private DateTime m_sgdate;

        //状态1启用 2 禁用		
        private string m_sgstate;

        //备用字段		
        private string m_sgremark2;



        /// <summary>
        /// 编号
        /// </summary>
        public int sgid
        {
            get { return m_sgid; }
            set { m_sgid = value; }
        }
        /// <summary>
        /// 淘宝编号
        /// </summary>
        public string sgcampaignid
        {
            get { return m_sgcampaignid; }
            set { m_sgcampaignid = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string sgname
        {
            get { return m_sgname; }
            set { m_sgname = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string sgremark
        {
            get { return m_sgremark; }
            set { m_sgremark = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime sgdate
        {
            get { return m_sgdate; }
            set { m_sgdate = value; }
        }
        /// <summary>
        /// 状态1启用 2 禁用
        /// </summary>
        public string sgstate
        {
            get { return m_sgstate; }
            set { m_sgstate = value; }
        }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string sgremark2
        {
            get { return m_sgremark2; }
            set { m_sgremark2 = value; }
        }

    }
}

/*
系统名称：Entity
作    者：张建
完成日期：2015-03-16
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: fanxian
    /// </summary>
    [Serializable]
    public class fanxian
    {
        //Name:dpid Type:adVarWChar		
        private string m_dpid;

        //Name:fx_account Type:adLongVarWChar		
        private string m_fx_account;

        //Name:fx_date Type:adDate		
        private DateTime m_fx_date;

        //Name:fx_date2 Type:adDate		
        private DateTime m_fx_date2;

        //Name:fx_id Type:adInteger		
        private int m_fx_id;

        //Name:fx_num Type:adInteger		
        private decimal m_fx_num;

        //Name:fx_remark Type:adLongVarWChar		
        private string m_fx_remark;

        //Name:fx_state Type:adVarWChar		
        private string m_fx_state;

        //Name:fx_zhifubao Type:adLongVarWChar		
        private string m_fx_zhifubao;



        /// <summary>
        /// Name:dpid Type:adVarWChar
        /// </summary>
        public string dpid
        {
            get { return m_dpid; }
            set { m_dpid = value; }
        }
        /// <summary>
        /// Name:fx_account Type:adLongVarWChar
        /// </summary>
        public string fx_account
        {
            get { return m_fx_account; }
            set { m_fx_account = value; }
        }
        /// <summary>
        /// Name:fx_date Type:adDate
        /// </summary>
        public DateTime fx_date
        {
            get { return m_fx_date; }
            set { m_fx_date = value; }
        }
        /// <summary>
        /// Name:fx_date2 Type:adDate
        /// </summary>
        public DateTime fx_date2
        {
            get { return m_fx_date2; }
            set { m_fx_date2 = value; }
        }
        /// <summary>
        /// Name:fx_id Type:adInteger
        /// </summary>
        public int fx_id
        {
            get { return m_fx_id; }
            set { m_fx_id = value; }
        }
        /// <summary>
        /// Name:fx_num Type:adInteger
        /// </summary>
        public decimal fx_num
        {
            get { return m_fx_num; }
            set { m_fx_num = value; }
        }
        /// <summary>
        /// Name:fx_remark Type:adLongVarWChar
        /// </summary>
        public string fx_remark
        {
            get { return m_fx_remark; }
            set { m_fx_remark = value; }
        }
        /// <summary>
        /// Name:fx_state Type:adVarWChar
        /// </summary>
        public string fx_state
        {
            get { return m_fx_state; }
            set { m_fx_state = value; }
        }
        /// <summary>
        /// Name:fx_zhifubao Type:adLongVarWChar
        /// </summary>
        public string fx_zhifubao
        {
            get { return m_fx_zhifubao; }
            set { m_fx_zhifubao = value; }
        }
    }
}





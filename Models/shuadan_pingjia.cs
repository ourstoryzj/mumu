/*
系统名称：Entity
作    者：张建
完成日期：2015-05-02
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: shuadan_pingjia
    /// </summary>
    [Serializable]
    public class shuadan_pingjia
    {
        //时间		
        private DateTime m_spdate;

        //编号		
        private int m_spid;

        //评价内容		
        private string m_spname;

        //备注		
        private string m_spremark;

        //备用字段		
        private string m_spstandby1;

        //评语类型:1正常2禁用		
        private string m_spstate;

        //评语类型:1普通评语2结束评语		
        private string m_sptype;



        /// <summary>
        /// 时间
        /// </summary>
        public DateTime spdate
        {
            get { return m_spdate; }
            set { m_spdate = value; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int spid
        {
            get { return m_spid; }
            set { m_spid = value; }
        }
        /// <summary>
        /// 评价内容
        /// </summary>
        public string spname
        {
            get { return m_spname; }
            set { m_spname = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string spremark
        {
            get { return m_spremark; }
            set { m_spremark = value; }
        }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string spstandby1
        {
            get { return m_spstandby1; }
            set { m_spstandby1 = value; }
        }
        /// <summary>
        /// 评语类型:1正常2禁用
        /// </summary>
        public string spstate
        {
            get { return m_spstate; }
            set { m_spstate = value; }
        }
        /// <summary>
        /// 评语类型:1普通评语2结束评语
        /// </summary>
        public string sptype
        {
            get { return m_sptype; }
            set { m_sptype = value; }
        }
    }
}





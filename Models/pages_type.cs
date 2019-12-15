/*
系统名称：Entity
作    者：张建
完成日期：2015-05-04
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: pages_type
    /// </summary>
    [Serializable]
    public class pages_type
    {
        //录入时间		
        private DateTime m_ptdate;

        //编号		
        private int m_ptid;

        //类型名称		
        private string m_ptname;

        //备注		
        private string m_ptremark;

        //排序		
        private int m_ptsort;

        //状态 1启用2禁用		
        private string m_ptstate;



        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime ptdate
        {
            get { return m_ptdate; }
            set { m_ptdate = value; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int ptid
        {
            get { return m_ptid; }
            set { m_ptid = value; }
        }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string ptname
        {
            get { return m_ptname; }
            set { m_ptname = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string ptremark
        {
            get { return m_ptremark; }
            set { m_ptremark = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int ptsort
        {
            get { return m_ptsort; }
            set { m_ptsort = value; }
        }
        /// <summary>
        /// 状态 1启用2禁用
        /// </summary>
        public string ptstate
        {
            get { return m_ptstate; }
            set { m_ptstate = value; }
        }
    }
}





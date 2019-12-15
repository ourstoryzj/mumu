/*
系统名称：Entity
作    者：张建
完成日期：2017-02-23
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: keys_lexicon
    /// </summary>
    [Serializable]
    public class keys_lexicon
    {
        //编号		
        private int m_klid;

        //词库名称		
        private string m_klname;

        //排序		
        private int m_klsort;

        //添加时间		
        private DateTime m_kldate;

        //状态		
        private string m_klstate;

        //备注		
        private string m_klremark;

        //备用1		
        private string m_klremark1;

        //备用2		
        private string m_klremark2;



        /// <summary>
        /// 编号
        /// </summary>
        public int klid
        {
            get { return m_klid; }
            set { m_klid = value; }
        }
        /// <summary>
        /// 词库名称
        /// </summary>
        public string klname
        {
            get { return m_klname; }
            set { m_klname = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int klsort
        {
            get { return m_klsort; }
            set { m_klsort = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime kldate
        {
            get { return m_kldate; }
            set { m_kldate = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string klstate
        {
            get { return m_klstate; }
            set { m_klstate = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string klremark
        {
            get { return m_klremark; }
            set { m_klremark = value; }
        }
        /// <summary>
        /// 备用1
        /// </summary>
        public string klremark1
        {
            get { return m_klremark1; }
            set { m_klremark1 = value; }
        }
        /// <summary>
        /// 备用2
        /// </summary>
        public string klremark2
        {
            get { return m_klremark2; }
            set { m_klremark2 = value; }
        }

    }
}

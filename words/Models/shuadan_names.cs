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
    /// class: shuadan_names
    /// </summary>
    [Serializable]
    public class shuadan_names
    {
        //使用次数		
        private string m_ncount;

        //编号		
        private int m_nid;

        //姓名		
        private string m_nname;



        /// <summary>
        /// 使用次数
        /// </summary>
        public string ncount
        {
            get { return m_ncount; }
            set { m_ncount = value; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int nid
        {
            get { return m_nid; }
            set { m_nid = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string nname
        {
            get { return m_nname; }
            set { m_nname = value; }
        }
    }
}





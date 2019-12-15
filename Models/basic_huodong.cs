/*
系统名称：Entity
作    者：张建
完成日期：2016-10-02
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: basic_huodong
    /// </summary>
    [Serializable]
    public class basic_huodong
    {
        //编号		
        private int m_hdid;

        //第一次报名天数		
        private int m_hdone;

        //第二次报名天数		
        private int m_hdtwo;

        //报名时间		
        private DateTime m_hddate1;

        //下架时间		
        private DateTime m_hddate2;

        //类型：1 淘宝； 2 蘑菇街；		
        private string m_hdtype;

        //备注		
        private string m_hdremark;

        //规划名称		
        private string m_hdname;



        /// <summary>
        /// 编号
        /// </summary>
        public int hdid
        {
            get { return m_hdid; }
            set { m_hdid = value; }
        }
        /// <summary>
        /// 第一次报名天数
        /// </summary>
        public int hdone
        {
            get { return m_hdone; }
            set { m_hdone = value; }
        }
        /// <summary>
        /// 第二次报名天数
        /// </summary>
        public int hdtwo
        {
            get { return m_hdtwo; }
            set { m_hdtwo = value; }
        }
        /// <summary>
        /// 报名时间
        /// </summary>
        public DateTime hddate1
        {
            get { return m_hddate1; }
            set { m_hddate1 = value; }
        }
        /// <summary>
        /// 下架时间
        /// </summary>
        public DateTime hddate2
        {
            get { return m_hddate2; }
            set { m_hddate2 = value; }
        }
        /// <summary>
        /// 类型：1 淘宝； 2 蘑菇街；
        /// </summary>
        public string hdtype
        {
            get { return m_hdtype; }
            set { m_hdtype = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string hdremark
        {
            get { return m_hdremark; }
            set { m_hdremark = value; }
        }
        /// <summary>
        /// 规划名称
        /// </summary>
        public string hdname
        {
            get { return m_hdname; }
            set { m_hdname = value; }
        }

    }
}

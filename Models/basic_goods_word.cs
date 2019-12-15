/*
系统名称：Entity
作    者：张建
完成日期：2016-09-19
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: basic_goods_word
    /// </summary>
    [Serializable]
    public class basic_goods_word
    {
        //补单关键词编号		
        private int m_gwid;

        //关键词名称		
        private string m_gwname;

        //商品编号		
        private int m_bgid;

        //商品名称		
        private string m_bgname;

        //登记时间		
        private DateTime m_gwdate;

        //使用次数		
        private int m_gwnum;

        //状态  1 是 2 否		
        private string m_gwstate;

        //备注		
        private string m_gwremark;



        /// <summary>
        /// 补单关键词编号
        /// </summary>
        public int gwid
        {
            get { return m_gwid; }
            set { m_gwid = value; }
        }
        /// <summary>
        /// 关键词名称
        /// </summary>
        public string gwname
        {
            get { return m_gwname; }
            set { m_gwname = value; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int bgid
        {
            get { return m_bgid; }
            set { m_bgid = value; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string bgname
        {
            get { return m_bgname; }
            set { m_bgname = value; }
        }
        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime gwdate
        {
            get { return m_gwdate; }
            set { m_gwdate = value; }
        }
        /// <summary>
        /// 使用次数
        /// </summary>
        public int gwnum
        {
            get { return m_gwnum; }
            set { m_gwnum = value; }
        }
        /// <summary>
        /// 状态  1 是 2 否
        /// </summary>
        public string gwstate
        {
            get { return m_gwstate; }
            set { m_gwstate = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string gwremark
        {
            get { return m_gwremark; }
            set { m_gwremark = value; }
        }

    }
}

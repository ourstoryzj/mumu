/*
系统名称：Entity
作    者：张建
完成日期：2015-03-27
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: yh_goods_keys
    /// </summary>
    [Serializable]
    public class yh_goods_keys
    {
        //商品ID		
        private int m_gid;

        //商品-黄金关键词ID		
        private int m_gkid;

        //备注		
        private string m_gkremark;

        //状态 1启用2禁用		
        private string m_gkstate;

        //关键词ID		
        private int m_kid;



        /// <summary>
        /// 商品ID
        /// </summary>
        public int gid
        {
            get { return m_gid; }
            set { m_gid = value; }
        }
        /// <summary>
        /// 商品-黄金关键词ID
        /// </summary>
        public int gkid
        {
            get { return m_gkid; }
            set { m_gkid = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string gkremark
        {
            get { return m_gkremark; }
            set { m_gkremark = value; }
        }
        /// <summary>
        /// 状态 1启用2禁用
        /// </summary>
        public string gkstate
        {
            get { return m_gkstate; }
            set { m_gkstate = value; }
        }
        /// <summary>
        /// 关键词ID
        /// </summary>
        public int kid
        {
            get { return m_kid; }
            set { m_kid = value; }
        }
    }
}





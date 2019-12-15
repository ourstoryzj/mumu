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
    /// class: yh_goods_corekeys
    /// </summary>
    [Serializable]
    public class yh_goods_corekeys
    {
        //核心关键词ID		
        private int m_cid;

        //状态 1启用 2禁用		
        private DateTime m_gcdate;

        //关联表ID		
        private int m_gcid;

        //备注		
        private string m_gcremark;

        //商品ID		
        private int m_gid;



        /// <summary>
        /// 核心关键词ID
        /// </summary>
        public int cid
        {
            get { return m_cid; }
            set { m_cid = value; }
        }
        /// <summary>
        /// 状态 1启用 2禁用
        /// </summary>
        public DateTime gcdate
        {
            get { return m_gcdate; }
            set { m_gcdate = value; }
        }
        /// <summary>
        /// 关联表ID
        /// </summary>
        public int gcid
        {
            get { return m_gcid; }
            set { m_gcid = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string gcremark
        {
            get { return m_gcremark; }
            set { m_gcremark = value; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int gid
        {
            get { return m_gid; }
            set { m_gid = value; }
        }
    }
}





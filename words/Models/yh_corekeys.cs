/*
系统名称：Entity
作    者：张建
完成日期：2015-03-30
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: yh_corekeys
    /// </summary>
    [Serializable]
    public class yh_corekeys
    {
        //添加时间		
        private DateTime m_ckdate;

        //核心关键词ID		
        private int m_ckid;

        //核心关键词		
        private string m_ckname;

        //备注		
        private string m_ckremark;

        //排序		
        private string m_cksort;

        //状态 1启用 2禁用		
        private string m_ckstate;

        //商品类型ID		
        private string m_gtid;



        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime ckdate
        {
            get { return m_ckdate; }
            set { m_ckdate = value; }
        }
        /// <summary>
        /// 核心关键词ID
        /// </summary>
        public int ckid
        {
            get { return m_ckid; }
            set { m_ckid = value; }
        }
        /// <summary>
        /// 核心关键词
        /// </summary>
        public string ckname
        {
            get { return m_ckname; }
            set { m_ckname = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string ckremark
        {
            get { return m_ckremark; }
            set { m_ckremark = value; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public string cksort
        {
            get { return m_cksort; }
            set { m_cksort = value; }
        }
        /// <summary>
        /// 状态 1启用 2禁用
        /// </summary>
        public string ckstate
        {
            get { return m_ckstate; }
            set { m_ckstate = value; }
        }
        /// <summary>
        /// 商品类型ID
        /// </summary>
        public string gtid
        {
            get { return m_gtid; }
            set { m_gtid = value; }
        }
    }
}





/*
系统名称：Entity
作    者：张建
完成日期：2016-12-25
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: opponent_dianpu
    /// </summary>
    [Serializable]
    public class opponent_dianpu
    {
        //编号		
        private int m_oid;

        //店铺名称		
        private string m_odpname;

        //最后一次采集时间（以此查询相关信息）		
        private string m_odcollectdate;

        //店铺淘宝ID		
        private string m_odTBID;

        //旺旺		
        private string m_odwangwang;



        /// <summary>
        /// 编号
        /// </summary>
        public int oid
        {
            get { return m_oid; }
            set { m_oid = value; }
        }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string odpname
        {
            get { return m_odpname; }
            set { m_odpname = value; }
        }
        /// <summary>
        /// 最后一次采集时间（以此查询相关信息）
        /// </summary>
        public string odcollectdate
        {
            get { return m_odcollectdate; }
            set { m_odcollectdate = value; }
        }
        /// <summary>
        /// 店铺淘宝ID
        /// </summary>
        public string odTBID
        {
            get { return m_odTBID; }
            set { m_odTBID = value; }
        }
        /// <summary>
        /// 旺旺
        /// </summary>
        public string odwangwang
        {
            get { return m_odwangwang; }
            set { m_odwangwang = value; }
        }

    }
}

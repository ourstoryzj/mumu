/*
系统名称：Entity
作    者：张建
完成日期：2012-05-10
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: Images
    /// </summary>
    [Serializable]
    public class Images
    {
        //编号		
        private int m_IID;

        //图片名称		
        private string m_IName;

        //数据信息ID		
        private int m_OID;



        /// <summary>
        /// 编号
        /// </summary>
        public int IID
        {
            get { return m_IID; }
            set { m_IID = value; }
        }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string IName
        {
            get { return m_IName; }
            set { m_IName = value; }
        }
        /// <summary>
        /// 数据信息ID
        /// </summary>
        public int OID
        {
            get { return m_OID; }
            set { m_OID = value; }
        }

    }
}

/*
系统名称：Entity
作    者：张建
完成日期：2015-03-18
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: Signs
    /// </summary>
    [Serializable]
    public class Signs
    {
        //Name:Id Type:int		
        private int m_Id;

        //Name:SignTime Type:datetime		
        private DateTime m_SignTime;

        //Name:Remark Type:text		
        private string m_Remark;

        //Name:UId Type:int		
        private int m_UId;

        //Name:UName Type:varchar		
        private string m_UName;

        //Name:UState Type:varchar		
        private string m_UState;

        //Name:UType Type:varchar		
        private string m_UType;



        /// <summary>
        /// Name:Id Type:int
        /// </summary>
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        /// <summary>
        /// Name:SignTime Type:datetime
        /// </summary>
        public DateTime SignTime
        {
            get { return m_SignTime; }
            set { m_SignTime = value; }
        }
        /// <summary>
        /// Name:Remark Type:text
        /// </summary>
        public string Remark
        {
            get { return m_Remark; }
            set { m_Remark = value; }
        }
        /// <summary>
        /// Name:UId Type:int
        /// </summary>
        public int UId
        {
            get { return m_UId; }
            set { m_UId = value; }
        }
        /// <summary>
        /// Name:UName Type:varchar
        /// </summary>
        public string UName
        {
            get { return m_UName; }
            set { m_UName = value; }
        }
        /// <summary>
        /// Name:UState Type:varchar
        /// </summary>
        public string UState
        {
            get { return m_UState; }
            set { m_UState = value; }
        }
        /// <summary>
        /// Name:UType Type:varchar
        /// </summary>
        public string UType
        {
            get { return m_UType; }
            set { m_UType = value; }
        }

    }
}



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
    /// class: Basic
    /// </summary>
    [Serializable]
    public class Basic
    {
        //Name:Id Type:int		
        private int m_Id;

        //Name:Sign1 Type:varchar		
        private string m_Sign1;

        //Name:Sign2 Type:varchar		
        private string m_Sign2;

        //Name:Sign3 Type:varchar		
        private string m_Sign3;

        //Name:Sign4 Type:varchar		
        private string m_Sign4;

        //Name:State Type:varchar		
        private string m_State;



        /// <summary>
        /// Name:Id Type:int
        /// </summary>
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        /// <summary>
        /// Name:Sign1 Type:varchar
        /// </summary>
        public string Sign1
        {
            get { return m_Sign1; }
            set { m_Sign1 = value; }
        }
        /// <summary>
        /// Name:Sign2 Type:varchar
        /// </summary>
        public string Sign2
        {
            get { return m_Sign2; }
            set { m_Sign2 = value; }
        }
        /// <summary>
        /// Name:Sign3 Type:varchar
        /// </summary>
        public string Sign3
        {
            get { return m_Sign3; }
            set { m_Sign3 = value; }
        }
        /// <summary>
        /// Name:Sign4 Type:varchar
        /// </summary>
        public string Sign4
        {
            get { return m_Sign4; }
            set { m_Sign4 = value; }
        }
        /// <summary>
        /// Name:State Type:varchar
        /// </summary>
        public string State
        {
            get { return m_State; }
            set { m_State = value; }
        }

    }
}

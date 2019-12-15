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
    /// class: Users
    /// </summary>
    [Serializable]
    public class Users
    {
        //Name:Id Type:int		
        private int m_Id;

        //Name:Account Type:varchar		
        private string m_Account;

        //Name:Password Type:varchar		
        private string m_Password;

        //Name:LoginTime Type:datetime		
        private DateTime m_LoginTime;

        //Name:State Type:varchar		
        private string m_State;

        //Name:Name Type:varchar		
        private string m_Name;

        //Name:Birthday Type:datetime		
        private DateTime m_Birthday;

        //Name:Phone Type:varchar		
        private string m_Phone;

        //Name:Address Type:text		
        private string m_Address;

        //Name:Remark Type:text		
        private string m_Remark;

        //Name:Sex Type:varchar		
        private string m_Sex;



        /// <summary>
        /// Name:Id Type:int
        /// </summary>
        public int Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }
        /// <summary>
        /// Name:Account Type:varchar
        /// </summary>
        public string Account
        {
            get { return m_Account; }
            set { m_Account = value; }
        }
        /// <summary>
        /// Name:Password Type:varchar
        /// </summary>
        public string Password
        {
            get { return m_Password; }
            set { m_Password = value; }
        }
        /// <summary>
        /// Name:LoginTime Type:datetime
        /// </summary>
        public DateTime LoginTime
        {
            get { return m_LoginTime; }
            set { m_LoginTime = value; }
        }
        /// <summary>
        /// Name:State Type:varchar
        /// </summary>
        public string State
        {
            get { return m_State; }
            set { m_State = value; }
        }
        /// <summary>
        /// Name:Name Type:varchar
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }
        /// <summary>
        /// Name:Birthday Type:datetime
        /// </summary>
        public DateTime Birthday
        {
            get { return m_Birthday; }
            set { m_Birthday = value; }
        }
        /// <summary>
        /// Name:Phone Type:varchar
        /// </summary>
        public string Phone
        {
            get { return m_Phone; }
            set { m_Phone = value; }
        }
        /// <summary>
        /// Name:Address Type:text
        /// </summary>
        public string Address
        {
            get { return m_Address; }
            set { m_Address = value; }
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
        /// Name:Sex Type:varchar
        /// </summary>
        public string Sex
        {
            get { return m_Sex; }
            set { m_Sex = value; }
        }

    }
}



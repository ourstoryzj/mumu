/*
系统名称：Entity
作    者：张建
完成日期：2015-04-26
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: address
    /// </summary>
    [Serializable]
    public class address
    {
        //Name:aAddress Type:adLongVarWChar		
        private string m_aAddress;

        //Name:aCity Type:adLongVarWChar		
        private string m_aCity;

        //Name:aDistrict Type:adLongVarWChar		
        private string m_aDistrict;

        //Name:aid Type:adInteger		
        private int m_aid;

        //Name:aPostNumber Type:adVarWChar		
        private string m_aPostNumber;

        //Name:aProvince Type:adLongVarWChar		
        private string m_aProvince;

        //Name:aremark Type:adVarWChar		
        private string m_aremark;

        //Name:astate Type:adVarWChar		
        private string m_astate;



        /// <summary>
        /// Name:aAddress Type:adLongVarWChar
        /// </summary>
        public string aAddress
        {
            get { return m_aAddress; }
            set { m_aAddress = value; }
        }
        /// <summary>
        /// Name:aCity Type:adLongVarWChar
        /// </summary>
        public string aCity
        {
            get { return m_aCity; }
            set { m_aCity = value; }
        }
        /// <summary>
        /// Name:aDistrict Type:adLongVarWChar
        /// </summary>
        public string aDistrict
        {
            get { return m_aDistrict; }
            set { m_aDistrict = value; }
        }
        /// <summary>
        /// Name:aid Type:adInteger
        /// </summary>
        public int aid
        {
            get { return m_aid; }
            set { m_aid = value; }
        }
        /// <summary>
        /// Name:aPostNumber Type:adVarWChar
        /// </summary>
        public string aPostNumber
        {
            get { return m_aPostNumber; }
            set { m_aPostNumber = value; }
        }
        /// <summary>
        /// Name:aProvince Type:adLongVarWChar
        /// </summary>
        public string aProvince
        {
            get { return m_aProvince; }
            set { m_aProvince = value; }
        }
        /// <summary>
        /// Name:aremark Type:adVarWChar
        /// </summary>
        public string aremark
        {
            get { return m_aremark; }
            set { m_aremark = value; }
        }
        /// <summary>
        /// Name:astate Type:adVarWChar
        /// </summary>
        public string astate
        {
            get { return m_astate; }
            set { m_astate = value; }
        }
    }
}





/*
系统名称：Entity
作    者：张建
完成日期：2015-03-14
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: shouhou
    /// </summary>
    [Serializable]
    public class shouhou
    {
        //Name:dpid Type:adInteger		
        private int m_dpid;

        //Name:shaccount Type:adLongVarWChar		
        private string m_shaccount;

        //Name:shdate Type:adDate		
        private DateTime m_shdate;

        //Name:shid Type:adInteger		
        private int m_shid;

        //Name:shkdcode Type:adLongVarWChar		
        private string m_shkdcode;

        //Name:shname Type:adVarWChar		
        private string m_shname;

        //Name:shordercode Type:adLongVarWChar		
        private string m_shordercode;

        //Name:shphone Type:adVarWChar		
        private string m_shphone;

        //Name:shremark Type:adLongVarWChar		
        private string m_shremark;

        //Name:shstate Type:adVarWChar		
        private string m_shstate;

        //Name:shytphone Type:adLongVarWChar		
        private string m_shytphone;

        //Name:shyuanyin Type:adLongVarWChar		
        private string m_shyuanyin;



        /// <summary>
        /// Name:dpid Type:adInteger
        /// </summary>
        public int dpid
        {
            get { return m_dpid; }
            set { m_dpid = value; }
        }
        /// <summary>
        /// Name:shaccount Type:adLongVarWChar
        /// </summary>
        public string shaccount
        {
            get { return m_shaccount; }
            set { m_shaccount = value; }
        }
        /// <summary>
        /// Name:shdate Type:adDate
        /// </summary>
        public DateTime shdate
        {
            get { return m_shdate; }
            set { m_shdate = value; }
        }
        /// <summary>
        /// Name:shid Type:adInteger
        /// </summary>
        public int shid
        {
            get { return m_shid; }
            set { m_shid = value; }
        }
        /// <summary>
        /// Name:shkdcode Type:adLongVarWChar
        /// </summary>
        public string shkdcode
        {
            get { return m_shkdcode; }
            set { m_shkdcode = value; }
        }
        /// <summary>
        /// Name:shname Type:adVarWChar
        /// </summary>
        public string shname
        {
            get { return m_shname; }
            set { m_shname = value; }
        }
        /// <summary>
        /// Name:shordercode Type:adLongVarWChar
        /// </summary>
        public string shordercode
        {
            get { return m_shordercode; }
            set { m_shordercode = value; }
        }
        /// <summary>
        /// Name:shphone Type:adVarWChar
        /// </summary>
        public string shphone
        {
            get { return m_shphone; }
            set { m_shphone = value; }
        }
        /// <summary>
        /// Name:shremark Type:adLongVarWChar
        /// </summary>
        public string shremark
        {
            get { return m_shremark; }
            set { m_shremark = value; }
        }
        /// <summary>
        /// Name:shstate Type:adVarWChar
        /// </summary>
        public string shstate
        {
            get { return m_shstate; }
            set { m_shstate = value; }
        }
        /// <summary>
        /// Name:shytphone Type:adLongVarWChar
        /// </summary>
        public string shytphone
        {
            get { return m_shytphone; }
            set { m_shytphone = value; }
        }
        /// <summary>
        /// Name:shyuanyin Type:adLongVarWChar
        /// </summary>
        public string shyuanyin
        {
            get { return m_shyuanyin; }
            set { m_shyuanyin = value; }
        }
    }
}





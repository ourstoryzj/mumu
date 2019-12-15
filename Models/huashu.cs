/*
系统名称：Entity
作    者：张建
完成日期：2019-08-02
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: huashu
    /// </summary>
    [Serializable]
    public class huashu
    {
        //Name:hid Type:int
        private int m_hid;

        //fuid
        private int m_hfid;

        //答案
        private string m_hcontext;

        //排序
        private int m_hsort;

        //点击次数
        private int m_hcount;

        //操作时间
        private DateTime m_hdate;

        //问题
        private string m_htitle;

        //状态1 正常 2 禁用
        private string m_hstate;

        //用于拼多多自动回复时是否发送邮件到指定邮箱
        private string m_hsendemail;

        //备用字段
        private string m_hremark;



        ///<summary>
        ///Name:hid Type:int
        ///</summary>
        public int hid
        {
            get { return m_hid; }
            set { m_hid = value; }
        }
        ///<summary>
        ///fuid
        ///</summary>
        public int hfid
        {
            get { return m_hfid; }
            set { m_hfid = value; }
        }
        ///<summary>
        ///答案
        ///</summary>
        public string hcontext
        {
            get { return m_hcontext; }
            set { m_hcontext = value; }
        }
        ///<summary>
        ///排序
        ///</summary>
        public int hsort
        {
            get { return m_hsort; }
            set { m_hsort = value; }
        }
        ///<summary>
        ///点击次数
        ///</summary>
        public int hcount
        {
            get { return m_hcount; }
            set { m_hcount = value; }
        }
        ///<summary>
        ///操作时间
        ///</summary>
        public DateTime hdate
        {
            get { return m_hdate; }
            set { m_hdate = value; }
        }
        ///<summary>
        ///问题
        ///</summary>
        public string htitle
        {
            get { return m_htitle; }
            set { m_htitle = value; }
        }
        ///<summary>
        ///状态1 正常 2 禁用
        ///</summary>
        public string hstate
        {
            get { return m_hstate; }
            set { m_hstate = value; }
        }
        ///<summary>
        ///用于拼多多自动回复时是否发送邮件到指定邮箱
        ///</summary>
        public string hsendemail
        {
            get { return m_hsendemail; }
            set { m_hsendemail = value; }
        }
        ///<summary>
        ///备用字段
        ///</summary>
        public string hremark
        {
            get { return m_hremark; }
            set { m_hremark = value; }
        }

    }
}

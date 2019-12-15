/*
系统名称：Entity
作    者：张建
完成日期：2017-01-15
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: aotunew_title
    /// </summary>
    [Serializable]
    public class aotunew_title
    {
        //编号		
        private int m_atid;

        //标题		
        private string m_attitle;

        //简述		
        private string m_atjieshao;

        // 采集类目      1 ：蘑菇街单肩包类目 2蘑菇街双肩包类目  3淘宝单肩包 4淘宝双肩包		
        private string m_attype1;

        //采集类型 1标题 2 介绍		
        private string m_attype2;

        //备注1		
        private string m_atremark1;

        //备注2		
        private string m_atremark2;

        //采集时间		
        private DateTime m_atdate;

        //价格		
        private string m_atprice;

        //销量		
        private string m_atsell;

        //网址		
        private string m_aturl;

        //喜欢数量		
        private string m_atlike;



        /// <summary>
        /// 编号
        /// </summary>
        public int atid
        {
            get { return m_atid; }
            set { m_atid = value; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string attitle
        {
            get { return m_attitle; }
            set { m_attitle = value; }
        }
        /// <summary>
        /// 简述
        /// </summary>
        public string atjieshao
        {
            get { return m_atjieshao; }
            set { m_atjieshao = value; }
        }
        /// <summary>
        ///  采集类目      1 ：蘑菇街单肩包类目 2蘑菇街双肩包类目  3淘宝单肩包 4淘宝双肩包
        /// </summary>
        public string attype1
        {
            get { return m_attype1; }
            set { m_attype1 = value; }
        }
        /// <summary>
        /// 采集类型 1标题 2 介绍
        /// </summary>
        public string attype2
        {
            get { return m_attype2; }
            set { m_attype2 = value; }
        }
        /// <summary>
        /// 备注1
        /// </summary>
        public string atremark1
        {
            get { return m_atremark1; }
            set { m_atremark1 = value; }
        }
        /// <summary>
        /// 备注2
        /// </summary>
        public string atremark2
        {
            get { return m_atremark2; }
            set { m_atremark2 = value; }
        }
        /// <summary>
        /// 采集时间
        /// </summary>
        public DateTime atdate
        {
            get { return m_atdate; }
            set { m_atdate = value; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public string atprice
        {
            get { return m_atprice; }
            set { m_atprice = value; }
        }
        /// <summary>
        /// 销量
        /// </summary>
        public string atsell
        {
            get { return m_atsell; }
            set { m_atsell = value; }
        }
        /// <summary>
        /// 网址
        /// </summary>
        public string aturl
        {
            get { return m_aturl; }
            set { m_aturl = value; }
        }
        /// <summary>
        /// 喜欢数量
        /// </summary>
        public string atlike
        {
            get { return m_atlike; }
            set { m_atlike = value; }
        }

    }
}

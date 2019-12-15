/*
系统名称：Entity
作    者：张建
完成日期：2016-10-02
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: basic_order_plan
    /// </summary>
    [Serializable]
    public class basic_order_plan
    {
        //编号		
        private int m_opid;

        //第一天		
        private int m_opday1;

        //第二天		
        private int m_opday2;

        //第三天		
        private int m_opday3;

        //第四天		
        private int m_opday4;

        //第五天		
        private int m_opday5;

        //第六天		
        private int m_opday6;

        //第七天		
        private int m_opday7;

        //第八天		
        private int m_opday8;

        //第九天		
        private int m_opday9;

        //第十天		
        private int m_opday10;

        //第十一天		
        private int m_opday11;

        //第十二天		
        private int m_opday12;

        //第十三天		
        private int m_opday13;

        //第十四天		
        private int m_opday14;

        //刷单数量		
        private int m_opnum;

        //类型 1：淘宝 ； 2： 蘑菇街		
        private string m_optype;

        //备注		
        private string m_opremark;

        //方案名称		
        private string m_opname;



        /// <summary>
        /// 编号
        /// </summary>
        public int opid
        {
            get { return m_opid; }
            set { m_opid = value; }
        }
        /// <summary>
        /// 第一天
        /// </summary>
        public int opday1
        {
            get { return m_opday1; }
            set { m_opday1 = value; }
        }
        /// <summary>
        /// 第二天
        /// </summary>
        public int opday2
        {
            get { return m_opday2; }
            set { m_opday2 = value; }
        }
        /// <summary>
        /// 第三天
        /// </summary>
        public int opday3
        {
            get { return m_opday3; }
            set { m_opday3 = value; }
        }
        /// <summary>
        /// 第四天
        /// </summary>
        public int opday4
        {
            get { return m_opday4; }
            set { m_opday4 = value; }
        }
        /// <summary>
        /// 第五天
        /// </summary>
        public int opday5
        {
            get { return m_opday5; }
            set { m_opday5 = value; }
        }
        /// <summary>
        /// 第六天
        /// </summary>
        public int opday6
        {
            get { return m_opday6; }
            set { m_opday6 = value; }
        }
        /// <summary>
        /// 第七天
        /// </summary>
        public int opday7
        {
            get { return m_opday7; }
            set { m_opday7 = value; }
        }
        /// <summary>
        /// 第八天
        /// </summary>
        public int opday8
        {
            get { return m_opday8; }
            set { m_opday8 = value; }
        }
        /// <summary>
        /// 第九天
        /// </summary>
        public int opday9
        {
            get { return m_opday9; }
            set { m_opday9 = value; }
        }
        /// <summary>
        /// 第十天
        /// </summary>
        public int opday10
        {
            get { return m_opday10; }
            set { m_opday10 = value; }
        }
        /// <summary>
        /// 第十一天
        /// </summary>
        public int opday11
        {
            get { return m_opday11; }
            set { m_opday11 = value; }
        }
        /// <summary>
        /// 第十二天
        /// </summary>
        public int opday12
        {
            get { return m_opday12; }
            set { m_opday12 = value; }
        }
        /// <summary>
        /// 第十三天
        /// </summary>
        public int opday13
        {
            get { return m_opday13; }
            set { m_opday13 = value; }
        }
        /// <summary>
        /// 第十四天
        /// </summary>
        public int opday14
        {
            get { return m_opday14; }
            set { m_opday14 = value; }
        }
        /// <summary>
        /// 刷单数量
        /// </summary>
        public int opnum
        {
            get { return m_opnum; }
            set { m_opnum = value; }
        }
        /// <summary>
        /// 类型 1：淘宝 ； 2： 蘑菇街
        /// </summary>
        public string optype
        {
            get { return m_optype; }
            set { m_optype = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string opremark
        {
            get { return m_opremark; }
            set { m_opremark = value; }
        }
        /// <summary>
        /// 方案名称
        /// </summary>
        public string opname
        {
            get { return m_opname; }
            set { m_opname = value; }
        }

    }
}

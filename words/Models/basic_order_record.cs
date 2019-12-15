/*
系统名称：Entity
作    者：张建
完成日期：2016-10-06
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: basic_order_record
    /// </summary>
    [Serializable]
    public class basic_order_record
    {
        //编号		
        private int m_orid;

        //商品编号		
        private int m_bgid;

        //商品名称		
        private string m_bgname;

        //店铺编号		
        private int m_dpid;

        //店铺名称		
        private string m_dpname;

        //关键词编号		
        private int m_gkid;

        //关键词名称		
        private string m_gkname;

        //会否是买家秀： 1 是 2 否		
        private string m_ormaijiaxiu;

        //登记时间		
        private DateTime m_ordate;

        //备注		
        private string m_orremark;

        //联系人qq		
        private string m_orqq;

        //备用1		
        private string m_orprepare1;

        //备用2		
        private string m_orprepare2;

        //备用3		
        private string m_orprepare3;

        //联系人旺旺		
        private string m_orwangwang;

        //价格		
        private string m_orprice;

        //订单编号		
        private string m_orcode;

        //商品网址		
        private string m_bgurl;

        //物流单号		
        private string m_bgwuliu;



        /// <summary>
        /// 编号
        /// </summary>
        public int orid
        {
            get { return m_orid; }
            set { m_orid = value; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int bgid
        {
            get { return m_bgid; }
            set { m_bgid = value; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string bgname
        {
            get { return m_bgname; }
            set { m_bgname = value; }
        }
        /// <summary>
        /// 店铺编号
        /// </summary>
        public int dpid
        {
            get { return m_dpid; }
            set { m_dpid = value; }
        }
        /// <summary>
        /// 店铺名称
        /// </summary>
        public string dpname
        {
            get { return m_dpname; }
            set { m_dpname = value; }
        }
        /// <summary>
        /// 关键词编号
        /// </summary>
        public int gkid
        {
            get { return m_gkid; }
            set { m_gkid = value; }
        }
        /// <summary>
        /// 关键词名称
        /// </summary>
        public string gkname
        {
            get { return m_gkname; }
            set { m_gkname = value; }
        }
        /// <summary>
        /// 会否是买家秀： 1 是 2 否
        /// </summary>
        public string ormaijiaxiu
        {
            get { return m_ormaijiaxiu; }
            set { m_ormaijiaxiu = value; }
        }
        /// <summary>
        /// 登记时间
        /// </summary>
        public DateTime ordate
        {
            get { return m_ordate; }
            set { m_ordate = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string orremark
        {
            get { return m_orremark; }
            set { m_orremark = value; }
        }
        /// <summary>
        /// 联系人qq
        /// </summary>
        public string orqq
        {
            get { return m_orqq; }
            set { m_orqq = value; }
        }
        /// <summary>
        /// 备用1
        /// </summary>
        public string orprepare1
        {
            get { return m_orprepare1; }
            set { m_orprepare1 = value; }
        }
        /// <summary>
        /// 备用2
        /// </summary>
        public string orprepare2
        {
            get { return m_orprepare2; }
            set { m_orprepare2 = value; }
        }
        /// <summary>
        /// 备用3
        /// </summary>
        public string orprepare3
        {
            get { return m_orprepare3; }
            set { m_orprepare3 = value; }
        }
        /// <summary>
        /// 联系人旺旺
        /// </summary>
        public string orwangwang
        {
            get { return m_orwangwang; }
            set { m_orwangwang = value; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public string orprice
        {
            get { return m_orprice; }
            set { m_orprice = value; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string orcode
        {
            get { return m_orcode; }
            set { m_orcode = value; }
        }
        /// <summary>
        /// 商品网址
        /// </summary>
        public string bgurl
        {
            get { return m_bgurl; }
            set { m_bgurl = value; }
        }
        /// <summary>
        /// 物流单号
        /// </summary>
        public string bgwuliu
        {
            get { return m_bgwuliu; }
            set { m_bgwuliu = value; }
        }

    }
}

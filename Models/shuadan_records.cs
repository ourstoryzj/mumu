/*
系统名称：Entity
作    者：张建
完成日期：2017-05-27
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: shuadan_records
    /// </summary>
    [Serializable]
    public class shuadan_records
    {
        //Name:sdid Type:int		
        private int m_sdid;

        //商品名称		
        private string m_sdgoodsname;

        //商品链接		
        private string m_sdgoodsurl;

        //店铺类型 1蘑菇街 2 淘宝 3 拼多多		
        private string m_sddptype;

        //刷单时间		
        private DateTime m_sddate;

        //订单编号		
        private string m_sdorderid;

        //手机号		
        private string m_sdphone;

        //vpn地址		
        private string m_sdvpn;

        //收货地址		
        private string m_sdaddress;

        //物流单号		
        private string m_sdwuliu;

        //手机号码归属地		
        private string m_sdremark1;

        //状态-空包  1未获取 2 已获取	
        private string m_sdremark3;

        //状态-收菜  1未收菜 2 已收菜		
        private string m_sdremark2;

        //状态-发货   1未发货 2已发货		
        private string m_sdremark4;

        //刷单备注
        private string m_sdremark5;

        //订单状态	 1正常单 2补单  	3问题单	
        private string m_sdremark6;


        //付款状态 1:付款成功 2 未付款
        private string m_sdstatepay;

        //Name:sdremark7 Type:varchar
        private string m_sdremark7;

        //Name:sdremark8 Type:varchar
        private string m_sdremark8;

        //Name:sdremark9 Type:varchar
        private string m_sdremark9;

        //Name:sdremark10 Type:varchar
        private string m_sdremark10;



        /// <summary>
        /// Name:sdid Type:int
        /// </summary>
        public int sdid
        {
            get { return m_sdid; }
            set { m_sdid = value; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string sdgoodsname
        {
            get { return m_sdgoodsname; }
            set { m_sdgoodsname = value; }
        }
        /// <summary>
        /// 商品链接
        /// </summary>
        public string sdgoodsurl
        {
            get { return m_sdgoodsurl; }
            set { m_sdgoodsurl = value; }
        }
        /// <summary>
        /// 店铺类型 1蘑菇街 2 淘宝 3 拼多多		
        /// </summary>
        public string sddptype
        {
            get { return m_sddptype; }
            set { m_sddptype = value; }
        }
        /// <summary>
        /// 刷单时间
        /// </summary>
        public DateTime sddate
        {
            get { return m_sddate; }
            set { m_sddate = value; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string sdorderid
        {
            get { return m_sdorderid; }
            set { m_sdorderid = value; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string sdphone
        {
            get { return m_sdphone; }
            set { m_sdphone = value; }
        }
        /// <summary>
        /// 旺旺账号(vpn地址)-拼多多SKU
        /// </summary>
        public string sdvpn
        {
            get { return m_sdvpn; }
            set { m_sdvpn = value; }
        }
        /// <summary>
        /// 收货地址
        /// </summary>
        public string sdaddress
        {
            get { return m_sdaddress; }
            set { m_sdaddress = value; }
        }
        /// <summary>
        /// 物流单号
        /// </summary>
        public string sdwuliu
        {
            get { return m_sdwuliu; }
            set { m_sdwuliu = value; }
        }
        /// <summary>
        /// 手机号归属地-拼多多数量-淘宝SKU+数量
        /// </summary>
        public string sdremark1
        {
            get { return m_sdremark1; }
            set { m_sdremark1 = value; }
        }
        /// <summary>
        /// 状态-空包  1未获取 2 已获取
        /// </summary>
        public string sdremark3
        {
            get { return m_sdremark3; }
            set { m_sdremark3 = value; }
        }
        /// <summary>
        /// 状态-收菜  1未收菜 2 已收菜
        /// </summary>
        public string sdremark2
        {
            get { return m_sdremark2; }
            set { m_sdremark2 = value; }
        }
        /// <summary>
        /// 状态-发货   1未发货 2已发货
        /// </summary>
        public string sdremark4
        {
            get { return m_sdremark4; }
            set { m_sdremark4 = value; }
        }
        /// <summary>
        /// 刷单备注
        /// </summary>
        public string sdremark5
        {
            get { return m_sdremark5; }
            set { m_sdremark5 = value; }
        }
        /// <summary>
        /// 订单状态	 1正常单 2补单 3问题单	
        /// </summary>
        public string sdremark6
        {
            get { return m_sdremark6; }
            set { m_sdremark6 = value; }
        }
        ///<summary>
		///付款状态 1:付款成功 2 未付款
        ///</summary>
		public string sdstatepay
        {
            get { return m_sdstatepay; }
            set { m_sdstatepay = value; }
        }
        ///<summary>
        ///Name:sdremark7 Type:varchar
        ///</summary>
        public string sdremark7
        {
            get { return m_sdremark7; }
            set { m_sdremark7 = value; }
        }
        ///<summary>
        ///Name:sdremark8 Type:varchar
        ///</summary>
        public string sdremark8
        {
            get { return m_sdremark8; }
            set { m_sdremark8 = value; }
        }
        ///<summary>
        ///Name:sdremark9 Type:varchar
        ///</summary>
        public string sdremark9
        {
            get { return m_sdremark9; }
            set { m_sdremark9 = value; }
        }
        ///<summary>
        ///Name:sdremark10 Type:varchar
        ///</summary>
        public string sdremark10
        {
            get { return m_sdremark10; }
            set { m_sdremark10 = value; }
        }


    }
}

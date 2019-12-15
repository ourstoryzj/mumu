/*
系统名称：Entity
作    者：张建
完成日期：2015-04-28
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: shuadan
    /// </summary>
    [Serializable]
    public class shuadan
    {
        //预留字段		
        private string m_dpidfrom;

        //预留字段		
        private string m_dpidto;

        //商品ID		
        private int m_gid;

        //商品名称		
        private string m_gname;

        //市		
        private string m_scity;

        //账号		
        private string m_sdaccount;

        //街道地址		
        private string m_sdaddress;

        //账号编号		
        private string m_sdaid;

        //密码		
        private string m_sdapwd;

        //录入时间		
        private DateTime m_sddate;

        //编号		
        private int m_sdid;

        //刷单信息来源,1生成,2淘宝,3蘑菇街		
        private string m_sdinfofrom;

        //区/县		
        private string m_sdistrict;

        //快递单号		
        private string m_sdkdcode;

        //快递名称		
        private string m_sdkdname;

        //用户姓名		
        private string m_sdname;

        //刷单批号,动态生成,以确定同一批刷单		
        private string m_sdnumber;

        //订单编号		
        private string m_sdordercode;

        //手机号码		
        private string m_sdphone;

        //评价时间		
        private DateTime m_sdpingjiadate;

        //评价状态		
        private string m_sdpingjiastate;

        //邮编		
        private string m_sdpostname;

        //省		
        private string m_sdprovince;

        //备注		
        private string m_sdremark;

        //发货时间		
        private DateTime m_sdsenddate;

        //发货状态		
        private string m_sdsendstate;

        //备用字段		
        private string m_sdstandby;

        //备用字段		
        private string m_sdstandby1;

        //备用字段		
        private string m_sdstandby2;

        //备用字段		
        private string m_sdstandby3;

        //状态		
        private string m_sdstate;



        /// <summary>
        /// 预留字段
        /// </summary>
        public string dpidfrom
        {
            get { return m_dpidfrom; }
            set { m_dpidfrom = value; }
        }
        /// <summary>
        /// 预留字段
        /// </summary>
        public string dpidto
        {
            get { return m_dpidto; }
            set { m_dpidto = value; }
        }
        /// <summary>
        /// 商品ID
        /// </summary>
        public int gid
        {
            get { return m_gid; }
            set { m_gid = value; }
        }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string gname
        {
            get { return m_gname; }
            set { m_gname = value; }
        }
        /// <summary>
        /// 市
        /// </summary>
        public string scity
        {
            get { return m_scity; }
            set { m_scity = value; }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string sdaccount
        {
            get { return m_sdaccount; }
            set { m_sdaccount = value; }
        }
        /// <summary>
        /// 街道地址
        /// </summary>
        public string sdaddress
        {
            get { return m_sdaddress; }
            set { m_sdaddress = value; }
        }
        /// <summary>
        /// 账号编号
        /// </summary>
        public string sdaid
        {
            get { return m_sdaid; }
            set { m_sdaid = value; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string sdapwd
        {
            get { return m_sdapwd; }
            set { m_sdapwd = value; }
        }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime sddate
        {
            get { return m_sddate; }
            set { m_sddate = value; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int sdid
        {
            get { return m_sdid; }
            set { m_sdid = value; }
        }
        /// <summary>
        /// 刷单信息来源,1生成,2淘宝,3蘑菇街
        /// </summary>
        public string sdinfofrom
        {
            get { return m_sdinfofrom; }
            set { m_sdinfofrom = value; }
        }
        /// <summary>
        /// 区/县
        /// </summary>
        public string sdistrict
        {
            get { return m_sdistrict; }
            set { m_sdistrict = value; }
        }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string sdkdcode
        {
            get { return m_sdkdcode; }
            set { m_sdkdcode = value; }
        }
        /// <summary>
        /// 快递名称
        /// </summary>
        public string sdkdname
        {
            get { return m_sdkdname; }
            set { m_sdkdname = value; }
        }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string sdname
        {
            get { return m_sdname; }
            set { m_sdname = value; }
        }
        /// <summary>
        /// 刷单批号,动态生成,以确定同一批刷单
        /// </summary>
        public string sdnumber
        {
            get { return m_sdnumber; }
            set { m_sdnumber = value; }
        }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string sdordercode
        {
            get { return m_sdordercode; }
            set { m_sdordercode = value; }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string sdphone
        {
            get { return m_sdphone; }
            set { m_sdphone = value; }
        }
        /// <summary>
        /// 评价时间
        /// </summary>
        public DateTime sdpingjiadate
        {
            get { return m_sdpingjiadate; }
            set { m_sdpingjiadate = value; }
        }
        /// <summary>
        /// 评价状态
        /// </summary>
        public string sdpingjiastate
        {
            get { return m_sdpingjiastate; }
            set { m_sdpingjiastate = value; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string sdpostname
        {
            get { return m_sdpostname; }
            set { m_sdpostname = value; }
        }
        /// <summary>
        /// 省
        /// </summary>
        public string sdprovince
        {
            get { return m_sdprovince; }
            set { m_sdprovince = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string sdremark
        {
            get { return m_sdremark; }
            set { m_sdremark = value; }
        }
        /// <summary>
        /// 发货时间
        /// </summary>
        public DateTime sdsenddate
        {
            get { return m_sdsenddate; }
            set { m_sdsenddate = value; }
        }
        /// <summary>
        /// 发货状态
        /// </summary>
        public string sdsendstate
        {
            get { return m_sdsendstate; }
            set { m_sdsendstate = value; }
        }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string sdstandby
        {
            get { return m_sdstandby; }
            set { m_sdstandby = value; }
        }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string sdstandby1
        {
            get { return m_sdstandby1; }
            set { m_sdstandby1 = value; }
        }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string sdstandby2
        {
            get { return m_sdstandby2; }
            set { m_sdstandby2 = value; }
        }
        /// <summary>
        /// 备用字段
        /// </summary>
        public string sdstandby3
        {
            get { return m_sdstandby3; }
            set { m_sdstandby3 = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string sdstate
        {
            get { return m_sdstate; }
            set { m_sdstate = value; }
        }
    }
}





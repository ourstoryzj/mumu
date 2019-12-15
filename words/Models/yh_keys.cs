/*
系统名称：Entity
作    者：张建
完成日期：2015-04-03
内容摘要：实体类
*/
using System;

namespace Entity
{

    /// <summary>
    /// class: yh_keys
    /// </summary>
    [Serializable]
    public class yh_keys
    {
        //核心关键词ID		
        private int m_ckid;

        //备用字段1		
        private string m_k_standby1;

        //备用字段2		
        private string m_k_standby2;

        //备用字段3		
        private string m_k_standby3;

        //搜索次数		
        private int m_kcishu;

        //添加时间		
        private DateTime m_kdate;

        //单个宝贝搜索次数（搜索次数/商品数量）		
        private decimal m_kdgbbsscs;

        //点击率		
        private decimal m_kdianjilv;

        //点击指数		
        private int m_kdianjizhishu;

        //商品数量		
        private int m_kgoodsnum;

        //关键词ID		
        private int m_kid;

        //关键词名称		
        private string m_kname;

        //千个宝贝成交次数（点击指数*转化率/当前宝贝数*1000）		
        private decimal m_kqgbbcjcs;

        //备注		
        private string m_kremark;

        //搜索人数		
        private int m_krenshu;

        //点击占比		
        private decimal m_kscdianjizhanbi;

        //搜索占比		
        private decimal m_ksousuozhanbi;

        //状态		
        private string m_kstate;

        //直通车出价		
        private decimal m_kzhitongche;

        //转化率		
        private decimal m_kzhuanhualv;



        /// <summary>
        /// 核心关键词ID
        /// </summary>
        public int ckid
        {
            get { return m_ckid; }
            set { m_ckid = value; }
        }
        /// <summary>
        /// 备用字段1
        /// </summary>
        public string k_standby1
        {
            get { return m_k_standby1; }
            set { m_k_standby1 = value; }
        }
        /// <summary>
        /// 备用字段2
        /// </summary>
        public string k_standby2
        {
            get { return m_k_standby2; }
            set { m_k_standby2 = value; }
        }
        /// <summary>
        /// 备用字段3
        /// </summary>
        public string k_standby3
        {
            get { return m_k_standby3; }
            set { m_k_standby3 = value; }
        }
        /// <summary>
        /// 搜索次数
        /// </summary>
        public int kcishu
        {
            get { return m_kcishu; }
            set { m_kcishu = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime kdate
        {
            get { return m_kdate; }
            set { m_kdate = value; }
        }
        /// <summary>
        /// 单个宝贝搜索次数（搜索次数/商品数量）
        /// </summary>
        public decimal kdgbbsscs
        {
            get { return m_kdgbbsscs; }
            set { m_kdgbbsscs = value; }
        }
        /// <summary>
        /// 点击率
        /// </summary>
        public decimal kdianjilv
        {
            get { return m_kdianjilv; }
            set { m_kdianjilv = value; }
        }
        /// <summary>
        /// 点击指数
        /// </summary>
        public int kdianjizhishu
        {
            get { return m_kdianjizhishu; }
            set { m_kdianjizhishu = value; }
        }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int kgoodsnum
        {
            get { return m_kgoodsnum; }
            set { m_kgoodsnum = value; }
        }
        /// <summary>
        /// 关键词ID
        /// </summary>
        public int kid
        {
            get { return m_kid; }
            set { m_kid = value; }
        }
        /// <summary>
        /// 关键词名称
        /// </summary>
        public string kname
        {
            get { return m_kname; }
            set { m_kname = value; }
        }
        /// <summary>
        /// 千个宝贝成交次数（点击指数*转化率/当前宝贝数*1000）
        /// </summary>
        public decimal kqgbbcjcs
        {
            get { return m_kqgbbcjcs; }
            set { m_kqgbbcjcs = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string kremark
        {
            get { return m_kremark; }
            set { m_kremark = value; }
        }
        /// <summary>
        /// 搜索人数
        /// </summary>
        public int krenshu
        {
            get { return m_krenshu; }
            set { m_krenshu = value; }
        }
        /// <summary>
        /// 点击占比
        /// </summary>
        public decimal kscdianjizhanbi
        {
            get { return m_kscdianjizhanbi; }
            set { m_kscdianjizhanbi = value; }
        }
        /// <summary>
        /// 搜索占比
        /// </summary>
        public decimal ksousuozhanbi
        {
            get { return m_ksousuozhanbi; }
            set { m_ksousuozhanbi = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string kstate
        {
            get { return m_kstate; }
            set { m_kstate = value; }
        }
        /// <summary>
        /// 直通车出价
        /// </summary>
        public decimal kzhitongche
        {
            get { return m_kzhitongche; }
            set { m_kzhitongche = value; }
        }
        /// <summary>
        /// 转化率
        /// </summary>
        public decimal kzhuanhualv
        {
            get { return m_kzhuanhualv; }
            set { m_kzhuanhualv = value; }
        }
    }
}





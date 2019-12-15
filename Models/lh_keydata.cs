/*
系统名称：Entity
作    者：张建
完成日期：2019-06-25
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: lh_keydata
    /// </summary>
    [Serializable]
    public class lh_keydata
    {
        //关键词ID		
        private int m_kid;

        //关键词名称		
        private string m_kname;

        //状态

        private string m_kstate;

        //时间		
        private DateTime m_kdate;

        //行业ID		
        private int m_hid;

        //关键词排行榜ID		
        private int m_rid;

        //备注		
        private string m_kremark;

        //备用字段1		
        private string m_kbackup1;

        //备用字段1		
        private string m_kbackup2;

        //备用字段1		
        private string m_kbackup3;

        //备用字段1		
        private string m_kbackup4;

        //备用字段1		
        private string m_kbackup5;

        //搜索人气

        private int m_ksousuorenqi;

        //支付转化率

        private decimal m_kzhifuzhuanhualv;

        //在线商品数		
        private int m_kzaixianshangpinshu;

        //商城占比数		
        private decimal m_kshangchengzhanbi;

        //直通车参考价		
        private decimal m_kzhitongchejiage;

        //竞争度=搜索人气/在线商品数*1000		
        private decimal m_kjingzheng;



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
        /// 状态

        /// </summary>
        public string kstate
        {
            get { return m_kstate; }
            set { m_kstate = value; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime kdate
        {
            get { return m_kdate; }
            set { m_kdate = value; }
        }
        /// <summary>
        /// 行业ID
        /// </summary>
        public int hid
        {
            get { return m_hid; }
            set { m_hid = value; }
        }
        /// <summary>
        /// 关键词排行榜ID
        /// </summary>
        public int rid
        {
            get { return m_rid; }
            set { m_rid = value; }
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
        /// 备用字段1
        /// </summary>
        public string kbackup1
        {
            get { return m_kbackup1; }
            set { m_kbackup1 = value; }
        }
        /// <summary>
        /// 备用字段1
        /// </summary>
        public string kbackup2
        {
            get { return m_kbackup2; }
            set { m_kbackup2 = value; }
        }
        /// <summary>
        /// 备用字段1
        /// </summary>
        public string kbackup3
        {
            get { return m_kbackup3; }
            set { m_kbackup3 = value; }
        }
        /// <summary>
        /// 备用字段1
        /// </summary>
        public string kbackup4
        {
            get { return m_kbackup4; }
            set { m_kbackup4 = value; }
        }
        /// <summary>
        /// 备用字段1
        /// </summary>
        public string kbackup5
        {
            get { return m_kbackup5; }
            set { m_kbackup5 = value; }
        }
        /// <summary>
        /// 搜索人气

        /// </summary>
        public int ksousuorenqi
        {
            get { return m_ksousuorenqi; }
            set { m_ksousuorenqi = value; }
        }
        /// <summary>
        /// 支付转化率

        /// </summary>
        public decimal kzhifuzhuanhualv
        {
            get { return m_kzhifuzhuanhualv; }
            set { m_kzhifuzhuanhualv = value; }
        }
        /// <summary>
        /// 在线商品数
        /// </summary>
        public int kzaixianshangpinshu
        {
            get { return m_kzaixianshangpinshu; }
            set { m_kzaixianshangpinshu = value; }
        }
        /// <summary>
        /// 商城占比数
        /// </summary>
        public decimal kshangchengzhanbi
        {
            get { return m_kshangchengzhanbi; }
            set { m_kshangchengzhanbi = value; }
        }
        /// <summary>
        /// 直通车参考价
        /// </summary>
        public decimal kzhitongchejiage
        {
            get { return m_kzhitongchejiage; }
            set { m_kzhitongchejiage = value; }
        }
        /// <summary>
        /// 竞争度=搜索人气/在线商品数*1000
        /// </summary>
        public decimal kjingzheng
        {
            get { return m_kjingzheng; }
            set { m_kjingzheng = value; }
        }

    }
}

/*
系统名称：Entity
作    者：张建
完成日期：2017-02-23
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: keys
    /// </summary>
    [Serializable]
    public class keys
    {
        //编号		
        private int m_kid;

        //关键词名称		
        private string m_kname;

        //人气		
        private int m_krenqi;

        //搜索人数占比		
        private decimal m_kSSzhanbi;

        //点击率		
        private decimal m_kdianjilv;

        //商城占比		
        private decimal m_kSCzhanbi;

        //商品数量		
        private int m_kgoodsnum;

        //直通车参考价格		
        private decimal m_kZTCjiage;

        //转化率		
        private decimal m_kzhuanhualv;

        //展现指数		
        private int m_kZTCzhanxian;

        //直通车点击指数		
        private int m_kZTCdianji;

        //直通车点击率		
        private decimal m_kZTCdianjilv;

        //直通车转化率		
        private decimal m_kZTCzhuanhualv;

        //直通车均价		
        private decimal m_kZTCjunjia;

        //直通车竞争度		
        private int m_kZTCjingzhengdu;

        //直通车地域-点击率排名		
        private string m_kZTCDY_dianjilv;

        // 直通车地域-展现排名		
        private string m_kZTCDY_zhanxian;

        //直通车地域-点击排名		
        private string m_kZTCDY_dianji;

        //直通车地域-转化排名		
        private string m_kZTCDY_zhuanhua;

        //直通车地域-均价排名		
        private string m_kZTCDY_junjia;

        //类型		
        private string m_ktype;

        //状态		
        private string m_kstate;

        //等级		
        private string m_klevel;

        //生意参谋-竞争度		
        private decimal m_kremark1;

        //备用		
        private string m_kremark2;

        //备用		
        private string m_kremark3;

        //备用		
        private string m_kremark4;

        //备用		
        private string m_kremark5;

        //备用		
        private string m_kremark6;

        //备用		
        private string m_kremark7;

        //备用		
        private string m_kremark8;

        //备用		
        private string m_kremark9;

        //添加时间		
        private DateTime m_kdate;

        //词库ID		
        private int m_klid;



        /// <summary>
        /// 编号
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
        /// 人气
        /// </summary>
        public int krenqi
        {
            get { return m_krenqi; }
            set { m_krenqi = value; }
        }
        /// <summary>
        /// 搜索人数占比
        /// </summary>
        public decimal kSSzhanbi
        {
            get { return m_kSSzhanbi; }
            set { m_kSSzhanbi = value; }
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
        /// 商城占比
        /// </summary>
        public decimal kSCzhanbi
        {
            get { return m_kSCzhanbi; }
            set { m_kSCzhanbi = value; }
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
        /// 直通车参考价格
        /// </summary>
        public decimal kZTCjiage
        {
            get { return m_kZTCjiage; }
            set { m_kZTCjiage = value; }
        }
        /// <summary>
        /// 转化率
        /// </summary>
        public decimal kzhuanhualv
        {
            get { return m_kzhuanhualv; }
            set { m_kzhuanhualv = value; }
        }
        /// <summary>
        /// 展现指数
        /// </summary>
        public int kZTCzhanxian
        {
            get { return m_kZTCzhanxian; }
            set { m_kZTCzhanxian = value; }
        }
        /// <summary>
        /// 直通车点击指数
        /// </summary>
        public int kZTCdianji
        {
            get { return m_kZTCdianji; }
            set { m_kZTCdianji = value; }
        }
        /// <summary>
        /// 直通车点击率
        /// </summary>
        public decimal kZTCdianjilv
        {
            get { return m_kZTCdianjilv; }
            set { m_kZTCdianjilv = value; }
        }
        /// <summary>
        /// 直通车转化率
        /// </summary>
        public decimal kZTCzhuanhualv
        {
            get { return m_kZTCzhuanhualv; }
            set { m_kZTCzhuanhualv = value; }
        }
        /// <summary>
        /// 直通车均价
        /// </summary>
        public decimal kZTCjunjia
        {
            get { return m_kZTCjunjia; }
            set { m_kZTCjunjia = value; }
        }
        /// <summary>
        /// 直通车竞争度
        /// </summary>
        public int kZTCjingzhengdu
        {
            get { return m_kZTCjingzhengdu; }
            set { m_kZTCjingzhengdu = value; }
        }
        /// <summary>
        /// 直通车地域-点击率排名
        /// </summary>
        public string kZTCDY_dianjilv
        {
            get { return m_kZTCDY_dianjilv; }
            set { m_kZTCDY_dianjilv = value; }
        }
        /// <summary>
        ///  直通车地域-展现排名
        /// </summary>
        public string kZTCDY_zhanxian
        {
            get { return m_kZTCDY_zhanxian; }
            set { m_kZTCDY_zhanxian = value; }
        }
        /// <summary>
        /// 直通车地域-点击排名
        /// </summary>
        public string kZTCDY_dianji
        {
            get { return m_kZTCDY_dianji; }
            set { m_kZTCDY_dianji = value; }
        }
        /// <summary>
        /// 直通车地域-转化排名
        /// </summary>
        public string kZTCDY_zhuanhua
        {
            get { return m_kZTCDY_zhuanhua; }
            set { m_kZTCDY_zhuanhua = value; }
        }
        /// <summary>
        /// 直通车地域-均价排名
        /// </summary>
        public string kZTCDY_junjia
        {
            get { return m_kZTCDY_junjia; }
            set { m_kZTCDY_junjia = value; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string ktype
        {
            get { return m_ktype; }
            set { m_ktype = value; }
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
        /// 等级
        /// </summary>
        public string klevel
        {
            get { return m_klevel; }
            set { m_klevel = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public decimal kremark1
        {
            get { return m_kremark1; }
            set { m_kremark1 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string kremark2
        {
            get { return m_kremark2; }
            set { m_kremark2 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string kremark3
        {
            get { return m_kremark3; }
            set { m_kremark3 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string kremark4
        {
            get { return m_kremark4; }
            set { m_kremark4 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string kremark5
        {
            get { return m_kremark5; }
            set { m_kremark5 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string kremark6
        {
            get { return m_kremark6; }
            set { m_kremark6 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string kremark7
        {
            get { return m_kremark7; }
            set { m_kremark7 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string kremark8
        {
            get { return m_kremark8; }
            set { m_kremark8 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string kremark9
        {
            get { return m_kremark9; }
            set { m_kremark9 = value; }
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
        /// 词库ID
        /// </summary>
        public int klid
        {
            get { return m_klid; }
            set { m_klid = value; }
        }

    }
}

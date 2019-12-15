/*
系统名称：Entity
作    者：张建
完成日期：2018-06-11
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: subway_key
    /// </summary>
    [Serializable]
    public class subway_key
    {
        //编号		
        private int m_skid;

        //商品编号		
        private int m_sgid;

        //关键词名称		
        private string m_skname;

        //质量分		
        private string m_skscore;

        //排名		
        private string m_skrank;

        //手机端出价		
        private string m_skmobileprice;

        //pc 出价		
        private string m_skpcprice;

        //曝光展现量		
        private string m_skimpression;

        //点击量		
        private string m_skclick;

        //点击率		
        private string m_skctr;

        //总花费		
        private string m_skcost;

        //平均点击花费		
        private string m_skcpc;

        //总购物车数		
        private string m_skcar;

        //总收藏笔数		
        private string m_skfav;

        //总成交笔数		
        private string m_skvol;

        //投入产出比		
        private string m_skroi;

        //转化率		
        private string m_skconverage;

        //平均展现排名		
        private string m_skavgpos;

        //状态 1正常；2 删除		
        private string m_skstate;

        //添加时间		
        private DateTime m_skdateadd;

        //数据的日期		
        private DateTime m_skdatedata;

        //删除时间		
        private DateTime m_skdatedelete;

        //标签 1观察 2优质  3 重点		
        private string m_sktag;

        //优化方案		
        private string m_skfangan;

        //是否已经操作出价？1未操作 2已操作		
        private string m_skmakeprice;

        //备注		
        private string m_skremark;

        //备用		
        private string m_skremark1;

        //备用		
        private string m_skremark2;

        //备用		
        private string m_skremark3;

        //备用		
        private string m_skremark4;

        //备用		
        private string m_skremark5;



        /// <summary>
        /// 编号
        /// </summary>
        public int skid
        {
            get { return m_skid; }
            set { m_skid = value; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public int sgid
        {
            get { return m_sgid; }
            set { m_sgid = value; }
        }
        /// <summary>
        /// 关键词名称
        /// </summary>
        public string skname
        {
            get { return m_skname; }
            set { m_skname = value; }
        }
        /// <summary>
        /// 质量分
        /// </summary>
        public string skscore
        {
            get { return m_skscore; }
            set { m_skscore = value; }
        }
        /// <summary>
        /// 排名
        /// </summary>
        public string skrank
        {
            get { return m_skrank; }
            set { m_skrank = value; }
        }
        /// <summary>
        /// 手机端出价
        /// </summary>
        public string skmobileprice
        {
            get { return m_skmobileprice; }
            set { m_skmobileprice = value; }
        }
        /// <summary>
        /// pc 出价
        /// </summary>
        public string skpcprice
        {
            get { return m_skpcprice; }
            set { m_skpcprice = value; }
        }
        /// <summary>
        /// 曝光展现量
        /// </summary>
        public string skimpression
        {
            get { return m_skimpression; }
            set { m_skimpression = value; }
        }
        /// <summary>
        /// 点击量
        /// </summary>
        public string skclick
        {
            get { return m_skclick; }
            set { m_skclick = value; }
        }
        /// <summary>
        /// 点击率
        /// </summary>
        public string skctr
        {
            get { return m_skctr; }
            set { m_skctr = value; }
        }
        /// <summary>
        /// 总花费
        /// </summary>
        public string skcost
        {
            get { return m_skcost; }
            set { m_skcost = value; }
        }
        /// <summary>
        /// 平均点击花费
        /// </summary>
        public string skcpc
        {
            get { return m_skcpc; }
            set { m_skcpc = value; }
        }
        /// <summary>
        /// 总购物车数
        /// </summary>
        public string skcar
        {
            get { return m_skcar; }
            set { m_skcar = value; }
        }
        /// <summary>
        /// 总收藏笔数
        /// </summary>
        public string skfav
        {
            get { return m_skfav; }
            set { m_skfav = value; }
        }
        /// <summary>
        /// 总成交笔数
        /// </summary>
        public string skvol
        {
            get { return m_skvol; }
            set { m_skvol = value; }
        }
        /// <summary>
        /// 投入产出比
        /// </summary>
        public string skroi
        {
            get { return m_skroi; }
            set { m_skroi = value; }
        }
        /// <summary>
        /// 转化率
        /// </summary>
        public string skconverage
        {
            get { return m_skconverage; }
            set { m_skconverage = value; }
        }
        /// <summary>
        /// 平均展现排名
        /// </summary>
        public string skavgpos
        {
            get { return m_skavgpos; }
            set { m_skavgpos = value; }
        }
        /// <summary>
        /// 状态 1正常；2 删除
        /// </summary>
        public string skstate
        {
            get { return m_skstate; }
            set { m_skstate = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime skdateadd
        {
            get { return m_skdateadd; }
            set { m_skdateadd = value; }
        }
        /// <summary>
        /// 数据的日期
        /// </summary>
        public DateTime skdatedata
        {
            get { return m_skdatedata; }
            set { m_skdatedata = value; }
        }
        /// <summary>
        /// 删除时间
        /// </summary>
        public DateTime skdatedelete
        {
            get { return m_skdatedelete; }
            set { m_skdatedelete = value; }
        }
        /// <summary>
        /// 标签 1观察 2优质  3 重点
        /// </summary>
        public string sktag
        {
            get { return m_sktag; }
            set { m_sktag = value; }
        }
        /// <summary>
        /// 优化方案
        /// </summary>
        public string skfangan
        {
            get { return m_skfangan; }
            set { m_skfangan = value; }
        }
        /// <summary>
        /// 是否已经操作出价？1未操作 2已操作
        /// </summary>
        public string skmakeprice
        {
            get { return m_skmakeprice; }
            set { m_skmakeprice = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string skremark
        {
            get { return m_skremark; }
            set { m_skremark = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string skremark1
        {
            get { return m_skremark1; }
            set { m_skremark1 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string skremark2
        {
            get { return m_skremark2; }
            set { m_skremark2 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string skremark3
        {
            get { return m_skremark3; }
            set { m_skremark3 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string skremark4
        {
            get { return m_skremark4; }
            set { m_skremark4 = value; }
        }
        /// <summary>
        /// 备用
        /// </summary>
        public string skremark5
        {
            get { return m_skremark5; }
            set { m_skremark5 = value; }
        }

    }
}

/*
系统名称：Entity
作    者：张建
完成日期：2016-12-30
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: opponent_dianpu_info
    /// </summary>
    [Serializable]
    public class opponent_dianpu_info
    {
        //编号		
        private int m_odiid;

        //商品数量		
        private int m_odigoodsnum;

        //销量为0的商品数量		
        private int m_odisell0;

        //SKU总数		
        private string m_odiSKUcount;

        //最高价格		
        private string m_odipricehigh;

        //最低价格		
        private string m_odipricelowset;

        //平均价格		
        private string m_odipriceaverage;

        //最高销量		
        private string m_odisellhigh;

        //最低销量		
        private string m_odiselllowset;

        //平均销量		
        private string m_odisellaverage;

        //总成交额		
        private string m_odisalescount;

        //总销量		
        private string m_odisellcount;

        //动销率		
        private string m_odidongxiao;

        //保障金		
        private string m_odibaozhangjin;

        //DSR描述		
        private string m_odiDSRmiaoshu;

        //DSR质量		
        private string m_odiDSRzhiliang;

        //DSR物流		
        private string m_odiDSRwuliu;

        //店铺父ID		
        private int m_odpid;

        //采集时间		
        private string m_ocollectdate;

        //淘宝店铺ID		
        private string m_oshopid;

        //Name:oremark1 Type:varchar		
        private string m_oremark1;

        //Name:oremark2 Type:varchar		
        private string m_oremark2;

        //Name:oremark3 Type:varchar		
        private string m_oremark3;



        /// <summary>
        /// 编号
        /// </summary>
        public int odiid
        {
            get { return m_odiid; }
            set { m_odiid = value; }
        }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int odigoodsnum
        {
            get { return m_odigoodsnum; }
            set { m_odigoodsnum = value; }
        }
        /// <summary>
        /// 销量为0的商品数量
        /// </summary>
        public int odisell0
        {
            get { return m_odisell0; }
            set { m_odisell0 = value; }
        }
        /// <summary>
        /// SKU总数
        /// </summary>
        public string odiSKUcount
        {
            get { return m_odiSKUcount; }
            set { m_odiSKUcount = value; }
        }
        /// <summary>
        /// 最高价格
        /// </summary>
        public string odipricehigh
        {
            get { return m_odipricehigh; }
            set { m_odipricehigh = value; }
        }
        /// <summary>
        /// 最低价格
        /// </summary>
        public string odipricelowset
        {
            get { return m_odipricelowset; }
            set { m_odipricelowset = value; }
        }
        /// <summary>
        /// 平均价格
        /// </summary>
        public string odipriceaverage
        {
            get { return m_odipriceaverage; }
            set { m_odipriceaverage = value; }
        }
        /// <summary>
        /// 最高销量
        /// </summary>
        public string odisellhigh
        {
            get { return m_odisellhigh; }
            set { m_odisellhigh = value; }
        }
        /// <summary>
        /// 最低销量
        /// </summary>
        public string odiselllowset
        {
            get { return m_odiselllowset; }
            set { m_odiselllowset = value; }
        }
        /// <summary>
        /// 平均销量
        /// </summary>
        public string odisellaverage
        {
            get { return m_odisellaverage; }
            set { m_odisellaverage = value; }
        }
        /// <summary>
        /// 总成交额
        /// </summary>
        public string odisalescount
        {
            get { return m_odisalescount; }
            set { m_odisalescount = value; }
        }
        /// <summary>
        /// 总销量
        /// </summary>
        public string odisellcount
        {
            get { return m_odisellcount; }
            set { m_odisellcount = value; }
        }
        /// <summary>
        /// 动销率
        /// </summary>
        public string odidongxiao
        {
            get { return m_odidongxiao; }
            set { m_odidongxiao = value; }
        }
        /// <summary>
        /// 保障金
        /// </summary>
        public string odibaozhangjin
        {
            get { return m_odibaozhangjin; }
            set { m_odibaozhangjin = value; }
        }
        /// <summary>
        /// DSR描述
        /// </summary>
        public string odiDSRmiaoshu
        {
            get { return m_odiDSRmiaoshu; }
            set { m_odiDSRmiaoshu = value; }
        }
        /// <summary>
        /// DSR质量
        /// </summary>
        public string odiDSRzhiliang
        {
            get { return m_odiDSRzhiliang; }
            set { m_odiDSRzhiliang = value; }
        }
        /// <summary>
        /// DSR物流
        /// </summary>
        public string odiDSRwuliu
        {
            get { return m_odiDSRwuliu; }
            set { m_odiDSRwuliu = value; }
        }
        /// <summary>
        /// 店铺父ID
        /// </summary>
        public int odpid
        {
            get { return m_odpid; }
            set { m_odpid = value; }
        }
        /// <summary>
        /// 采集时间
        /// </summary>
        public string ocollectdate
        {
            get { return m_ocollectdate; }
            set { m_ocollectdate = value; }
        }
        /// <summary>
        /// 淘宝店铺ID
        /// </summary>
        public string oshopid
        {
            get { return m_oshopid; }
            set { m_oshopid = value; }
        }
        /// <summary>
        /// Name:oremark1 Type:varchar
        /// </summary>
        public string oremark1
        {
            get { return m_oremark1; }
            set { m_oremark1 = value; }
        }
        /// <summary>
        /// Name:oremark2 Type:varchar
        /// </summary>
        public string oremark2
        {
            get { return m_oremark2; }
            set { m_oremark2 = value; }
        }
        /// <summary>
        /// Name:oremark3 Type:varchar
        /// </summary>
        public string oremark3
        {
            get { return m_oremark3; }
            set { m_oremark3 = value; }
        }

    }
}

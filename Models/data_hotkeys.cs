/*
系统名称：Entity
作    者：张建
完成日期：2017-01-05
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: data_hotkeys
    /// </summary>
    [Serializable]
    public class data_hotkeys
    {
        //Name:dhid Type:int		
        private int m_dhid;

        //采集时间		
        private DateTime m_dhdate;

        //包类目，女包还是双肩包		
        private string m_dhtypebag;

        //词类型，1：热门搜索词；2热门长尾词；3热门核心词；4热门品牌词，5热门修饰词		
        private string m_dhtypekey;

        //搜索排名		
        private int m_dhrank;

        //搜索词		
        private string m_dhkey;

        //搜索人气		
        private int m_dhsearchtimes;

        //商城占比		
        private string m_dhmall;

        //点击率		
        private double m_dhclickrate;

        //点击人气		
        private int m_dhclicktimes;

        //转化率		
        private double m_dhconverrate;

        //直通车参考价格		
        private double m_dhzhitongche;

        //是否是飙升词数据 1是 2否		
        private string m_dhtypebiaosheng;

        //相关搜索词数量		
        private int m_dhxiangguanci;

        //备用字段1		
        private string m_dhremark1;

        //备用字段2		
        private string m_dhremark2;

        //备用字段3		
        private string m_dhremark3;

        //备用字段4		
        private string m_dhremark4;



        /// <summary>
        /// Name:dhid Type:int
        /// </summary>
        public int dhid
        {
            get { return m_dhid; }
            set { m_dhid = value; }
        }
        /// <summary>
        /// 采集时间
        /// </summary>
        public DateTime dhdate
        {
            get { return m_dhdate; }
            set { m_dhdate = value; }
        }
        /// <summary>
        /// 包类目，女包还是双肩包
        /// </summary>
        public string dhtypebag
        {
            get { return m_dhtypebag; }
            set { m_dhtypebag = value; }
        }
        /// <summary>
        /// 词类型，1：热门搜索词；2热门长尾词；3热门核心词；4热门品牌词，5热门修饰词
        /// </summary>
        public string dhtypekey
        {
            get { return m_dhtypekey; }
            set { m_dhtypekey = value; }
        }
        /// <summary>
        /// 搜索排名
        /// </summary>
        public int dhrank
        {
            get { return m_dhrank; }
            set { m_dhrank = value; }
        }
        /// <summary>
        /// 搜索词
        /// </summary>
        public string dhkey
        {
            get { return m_dhkey; }
            set { m_dhkey = value; }
        }
        /// <summary>
        /// 搜索人气
        /// </summary>
        public int dhsearchtimes
        {
            get { return m_dhsearchtimes; }
            set { m_dhsearchtimes = value; }
        }
        /// <summary>
        /// 商城占比
        /// </summary>
        public string dhmall
        {
            get { return m_dhmall; }
            set { m_dhmall = value; }
        }
        /// <summary>
        /// 点击率
        /// </summary>
        public double dhclickrate
        {
            get { return m_dhclickrate; }
            set { m_dhclickrate = value; }
        }
        /// <summary>
        /// 点击人气
        /// </summary>
        public int dhclicktimes
        {
            get { return m_dhclicktimes; }
            set { m_dhclicktimes = value; }
        }
        /// <summary>
        /// 转化率
        /// </summary>
        public double dhconverrate
        {
            get { return m_dhconverrate; }
            set { m_dhconverrate = value; }
        }
        /// <summary>
        /// 直通车参考价格
        /// </summary>
        public double dhzhitongche
        {
            get { return m_dhzhitongche; }
            set { m_dhzhitongche = value; }
        }
        /// <summary>
        /// 是否是飙升词数据 1是 2否
        /// </summary>
        public string dhtypebiaosheng
        {
            get { return m_dhtypebiaosheng; }
            set { m_dhtypebiaosheng = value; }
        }
        /// <summary>
        /// 相关搜索词数量
        /// </summary>
        public int dhxiangguanci
        {
            get { return m_dhxiangguanci; }
            set { m_dhxiangguanci = value; }
        }
        /// <summary>
        /// 备用字段1
        /// </summary>
        public string dhremark1
        {
            get { return m_dhremark1; }
            set { m_dhremark1 = value; }
        }
        /// <summary>
        /// 备用字段2
        /// </summary>
        public string dhremark2
        {
            get { return m_dhremark2; }
            set { m_dhremark2 = value; }
        }
        /// <summary>
        /// 备用字段3
        /// </summary>
        public string dhremark3
        {
            get { return m_dhremark3; }
            set { m_dhremark3 = value; }
        }
        /// <summary>
        /// 备用字段4
        /// </summary>
        public string dhremark4
        {
            get { return m_dhremark4; }
            set { m_dhremark4 = value; }
        }

    }
}

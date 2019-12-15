/*
系统名称：Entity
作    者：张建
完成日期：2017-02-25
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: keys_tiaojian
    /// </summary>
    [Serializable]
    public class keys_tiaojian
    {
        //Name:ktid Type:int		
        private int m_ktid;

        //关键词长度1		
        private int m_klength1;

        //关键词长度2		
        private int m_klength2;

        //点击率1		
        private decimal m_kdianjilv1;

        //点击率2		
        private decimal m_kdianjilv2;

        //点击数1		
        private int m_kdianjishu1;

        //点击数2		
        private int m_kdianjishu2;

        //商品数量1		
        private int m_kgoodsnum1;

        //商品数量2		
        private int m_kgoodsnum2;

        //人气1		
        private int m_krenqi1;

        //人气2		
        private int m_krenqi2;

        //商城占比1		
        private decimal m_kshangcheng1;

        //商城占比2		
        private decimal m_kshangcheng2;

        //直通车价格1		
        private decimal m_kZTCprice1;

        //直通车价格2		
        private decimal m_kZTCprice2;

        //转化率1		
        private decimal m_kzhuanhualv1;

        //转化率2		
        private decimal m_kzhuanhualv2;

        //直通车展现1		
        private int m_kZTCzhanxian1;

        //直通车展现2		
        private int m_kZTCzhanxian2;

        //直通车点击数1		
        private int m_kZTCdianjishu1;

        //直通车点击数2		
        private int m_kZTCdianjishu2;

        //直通车点击率1		
        private decimal m_kZTCdianjilv1;

        //直通车点击率2		
        private decimal m_kZTCdianjilv2;

        //直通车转化率1		
        private decimal m_kZTCzhuanhualv1;

        //直通车转化率2		
        private decimal m_kZTCzhuanhualv2;

        //直通车均价1		
        private decimal m_kZTCjunjia1;

        //直通车均价2		
        private decimal m_kZTCjunjia2;

        //直通车竞争度1		
        private decimal m_kZTCjingzhengdu1;

        //直通车竞争度2		
        private decimal m_kZTCjingzhengdu2;

        //添加时间		
        private DateTime m_kdate;

        //状态		
        private string m_kstate;

        //等级		
        private string m_klevel;

        //条件名称		
        private string m_kname;

        //备用1		
        private string m_kremark1;

        //备用2		
        private string m_kremark2;

        //备用3		
        private string m_kremark3;

        //备用4		
        private string m_kremark4;



        /// <summary>
        /// Name:ktid Type:int
        /// </summary>
        public int ktid
        {
            get { return m_ktid; }
            set { m_ktid = value; }
        }
        /// <summary>
        /// 关键词长度1
        /// </summary>
        public int klength1
        {
            get { return m_klength1; }
            set { m_klength1 = value; }
        }
        /// <summary>
        /// 关键词长度2
        /// </summary>
        public int klength2
        {
            get { return m_klength2; }
            set { m_klength2 = value; }
        }
        /// <summary>
        /// 点击率1
        /// </summary>
        public decimal kdianjilv1
        {
            get { return m_kdianjilv1; }
            set { m_kdianjilv1 = value; }
        }
        /// <summary>
        /// 点击率2
        /// </summary>
        public decimal kdianjilv2
        {
            get { return m_kdianjilv2; }
            set { m_kdianjilv2 = value; }
        }
        /// <summary>
        /// 点击数1
        /// </summary>
        public int kdianjishu1
        {
            get { return m_kdianjishu1; }
            set { m_kdianjishu1 = value; }
        }
        /// <summary>
        /// 点击数2
        /// </summary>
        public int kdianjishu2
        {
            get { return m_kdianjishu2; }
            set { m_kdianjishu2 = value; }
        }
        /// <summary>
        /// 商品数量1
        /// </summary>
        public int kgoodsnum1
        {
            get { return m_kgoodsnum1; }
            set { m_kgoodsnum1 = value; }
        }
        /// <summary>
        /// 商品数量2
        /// </summary>
        public int kgoodsnum2
        {
            get { return m_kgoodsnum2; }
            set { m_kgoodsnum2 = value; }
        }
        /// <summary>
        /// 人气1
        /// </summary>
        public int krenqi1
        {
            get { return m_krenqi1; }
            set { m_krenqi1 = value; }
        }
        /// <summary>
        /// 人气2
        /// </summary>
        public int krenqi2
        {
            get { return m_krenqi2; }
            set { m_krenqi2 = value; }
        }
        /// <summary>
        /// 商城占比1
        /// </summary>
        public decimal kshangcheng1
        {
            get { return m_kshangcheng1; }
            set { m_kshangcheng1 = value; }
        }
        /// <summary>
        /// 商城占比2
        /// </summary>
        public decimal kshangcheng2
        {
            get { return m_kshangcheng2; }
            set { m_kshangcheng2 = value; }
        }
        /// <summary>
        /// 直通车价格1
        /// </summary>
        public decimal kZTCprice1
        {
            get { return m_kZTCprice1; }
            set { m_kZTCprice1 = value; }
        }
        /// <summary>
        /// 直通车价格2
        /// </summary>
        public decimal kZTCprice2
        {
            get { return m_kZTCprice2; }
            set { m_kZTCprice2 = value; }
        }
        /// <summary>
        /// 转化率1
        /// </summary>
        public decimal kzhuanhualv1
        {
            get { return m_kzhuanhualv1; }
            set { m_kzhuanhualv1 = value; }
        }
        /// <summary>
        /// 转化率2
        /// </summary>
        public decimal kzhuanhualv2
        {
            get { return m_kzhuanhualv2; }
            set { m_kzhuanhualv2 = value; }
        }
        /// <summary>
        /// 直通车展现1
        /// </summary>
        public int kZTCzhanxian1
        {
            get { return m_kZTCzhanxian1; }
            set { m_kZTCzhanxian1 = value; }
        }
        /// <summary>
        /// 直通车展现2
        /// </summary>
        public int kZTCzhanxian2
        {
            get { return m_kZTCzhanxian2; }
            set { m_kZTCzhanxian2 = value; }
        }
        /// <summary>
        /// 直通车点击数1
        /// </summary>
        public int kZTCdianjishu1
        {
            get { return m_kZTCdianjishu1; }
            set { m_kZTCdianjishu1 = value; }
        }
        /// <summary>
        /// 直通车点击数2
        /// </summary>
        public int kZTCdianjishu2
        {
            get { return m_kZTCdianjishu2; }
            set { m_kZTCdianjishu2 = value; }
        }
        /// <summary>
        /// 直通车点击率1
        /// </summary>
        public decimal kZTCdianjilv1
        {
            get { return m_kZTCdianjilv1; }
            set { m_kZTCdianjilv1 = value; }
        }
        /// <summary>
        /// 直通车点击率2
        /// </summary>
        public decimal kZTCdianjilv2
        {
            get { return m_kZTCdianjilv2; }
            set { m_kZTCdianjilv2 = value; }
        }
        /// <summary>
        /// 直通车转化率1
        /// </summary>
        public decimal kZTCzhuanhualv1
        {
            get { return m_kZTCzhuanhualv1; }
            set { m_kZTCzhuanhualv1 = value; }
        }
        /// <summary>
        /// 直通车转化率2
        /// </summary>
        public decimal kZTCzhuanhualv2
        {
            get { return m_kZTCzhuanhualv2; }
            set { m_kZTCzhuanhualv2 = value; }
        }
        /// <summary>
        /// 直通车均价1
        /// </summary>
        public decimal kZTCjunjia1
        {
            get { return m_kZTCjunjia1; }
            set { m_kZTCjunjia1 = value; }
        }
        /// <summary>
        /// 直通车均价2
        /// </summary>
        public decimal kZTCjunjia2
        {
            get { return m_kZTCjunjia2; }
            set { m_kZTCjunjia2 = value; }
        }
        /// <summary>
        /// 直通车竞争度1
        /// </summary>
        public decimal kZTCjingzhengdu1
        {
            get { return m_kZTCjingzhengdu1; }
            set { m_kZTCjingzhengdu1 = value; }
        }
        /// <summary>
        /// 直通车竞争度2
        /// </summary>
        public decimal kZTCjingzhengdu2
        {
            get { return m_kZTCjingzhengdu2; }
            set { m_kZTCjingzhengdu2 = value; }
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
        /// 条件名称
        /// </summary>
        public string kname
        {
            get { return m_kname; }
            set { m_kname = value; }
        }
        /// <summary>
        /// 备用1
        /// </summary>
        public string kremark1
        {
            get { return m_kremark1; }
            set { m_kremark1 = value; }
        }
        /// <summary>
        /// 备用2
        /// </summary>
        public string kremark2
        {
            get { return m_kremark2; }
            set { m_kremark2 = value; }
        }
        /// <summary>
        /// 备用3
        /// </summary>
        public string kremark3
        {
            get { return m_kremark3; }
            set { m_kremark3 = value; }
        }
        /// <summary>
        /// 备用4
        /// </summary>
        public string kremark4
        {
            get { return m_kremark4; }
            set { m_kremark4 = value; }
        }

    }
}

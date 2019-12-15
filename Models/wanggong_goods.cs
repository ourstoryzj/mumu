/*
系统名称：Entity
作    者：张建
完成日期：2017-02-06
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: wanggong_goods
    /// </summary>
    [Serializable]
    public class wanggong_goods
    {
        //编号		
        private int m_wgid;

        //网供编号		
        private int m_wid;

        //采集时间		
        private DateTime m_wgcollectdate;

        //淘宝商品编号		
        private string m_wgTBid;

        //网址		
        private string m_wgurl;

        //标题		
        private string m_wgtittle;

        //原始价格		
        private string m_wgprice1;

        //出售价格		
        private string m_wgprice2;

        //图片名称		
        private string m_wgimg;

        //销量		
        private string m_wgxiaoliang;

        //上架时间		
        private string m_wgUPdate;

        //下架时间		
        private string m_wgDowndate;

        //图片名称		
        private string m_wgremark;

        //备注		
        private string m_wgremark1;

        //商品简称		
        private string m_wgremark2;

        //备用字段3		
        private string m_wgremark3;



        /// <summary>
        /// 编号
        /// </summary>
        public int wgid
        {
            get { return m_wgid; }
            set { m_wgid = value; }
        }
        /// <summary>
        /// 网供编号
        /// </summary>
        public int wid
        {
            get { return m_wid; }
            set { m_wid = value; }
        }
        /// <summary>
        /// 采集时间
        /// </summary>
        public DateTime wgcollectdate
        {
            get { return m_wgcollectdate; }
            set { m_wgcollectdate = value; }
        }
        /// <summary>
        /// 淘宝商品编号
        /// </summary>
        public string wgTBid
        {
            get { return m_wgTBid; }
            set { m_wgTBid = value; }
        }
        /// <summary>
        /// 网址
        /// </summary>
        public string wgurl
        {
            get { return m_wgurl; }
            set { m_wgurl = value; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string wgtittle
        {
            get { return m_wgtittle; }
            set { m_wgtittle = value; }
        }
        /// <summary>
        /// 原始价格
        /// </summary>
        public string wgprice1
        {
            get { return m_wgprice1; }
            set { m_wgprice1 = value; }
        }
        /// <summary>
        /// 出售价格
        /// </summary>
        public string wgprice2
        {
            get { return m_wgprice2; }
            set { m_wgprice2 = value; }
        }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string wgimg
        {
            get { return m_wgimg; }
            set { m_wgimg = value; }
        }
        /// <summary>
        /// 销量
        /// </summary>
        public string wgxiaoliang
        {
            get { return m_wgxiaoliang; }
            set { m_wgxiaoliang = value; }
        }
        /// <summary>
        /// 上架时间
        /// </summary>
        public string wgUPdate
        {
            get { return m_wgUPdate; }
            set { m_wgUPdate = value; }
        }
        /// <summary>
        /// 下架时间
        /// </summary>
        public string wgDowndate
        {
            get { return m_wgDowndate; }
            set { m_wgDowndate = value; }
        }
        /// <summary>
        /// 本地图片名称
        /// </summary>
        public string wgremark
        {
            get { return m_wgremark; }
            set { m_wgremark = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string wgremark1
        {
            get { return m_wgremark1; }
            set { m_wgremark1 = value; }
        }
        /// <summary>
        /// 商品简称
        /// </summary>
        public string wgremark2
        {
            get { return m_wgremark2; }
            set { m_wgremark2 = value; }
        }
        /// <summary>
        /// 备用字段3
        /// </summary>
        public string wgremark3
        {
            get { return m_wgremark3; }
            set { m_wgremark3 = value; }
        }

    }
}

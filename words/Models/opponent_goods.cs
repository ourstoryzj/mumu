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
    /// class: opponent_goods
    /// </summary>
    [Serializable]
    public class opponent_goods
    {
        //编号		
        private int m_ogid;

        //店铺父ID		
        private int m_odpid;

        //采集时间		
        private string m_ocollectdate;

        //url		
        private string m_ogurl;

        //商品标题		
        private string m_ogtittle;

        //原价		
        private string m_ogprice1;

        //现价		
        private string m_ogprice2;

        //折扣		
        private string m_ogdiscount;

        //主图图片网址		
        private string m_ogimg;

        //销量		
        private string m_ogsales;

        //邮费		
        private string m_ogpostage;

        //SKU数量		
        private string m_ogSKU;

        //上架时间		
        private string m_ogUPdate;

        //下架时间		
        private string m_ogDowndate;

        //商品编号		
        private string m_ogTBid;

        //累计评论		
        private string m_ogxiaoliang;

        //收藏		
        private string m_ogshoucang;

        //本地图片名称		
        private string m_ogremark;

        //副标题		
        private string m_ogremark1;

        //淘宝店铺ID		
        private string m_oshopid;

        //Name:ogremark2 Type:varchar		
        private string m_ogremark2;

        //Name:ogremark3 Type:varchar		
        private string m_ogremark3;

        //Name:ogremark4 Type:varchar		
        private string m_ogremark4;

        //Name:ogremark5 Type:varchar		
        private string m_ogremark5;



        /// <summary>
        /// 编号
        /// </summary>
        public int ogid
        {
            get { return m_ogid; }
            set { m_ogid = value; }
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
        /// url
        /// </summary>
        public string ogurl
        {
            get { return m_ogurl; }
            set { m_ogurl = value; }
        }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string ogtittle
        {
            get { return m_ogtittle; }
            set { m_ogtittle = value; }
        }
        /// <summary>
        /// 原价
        /// </summary>
        public string ogprice1
        {
            get { return m_ogprice1; }
            set { m_ogprice1 = value; }
        }
        /// <summary>
        /// 现价
        /// </summary>
        public string ogprice2
        {
            get { return m_ogprice2; }
            set { m_ogprice2 = value; }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        public string ogdiscount
        {
            get { return m_ogdiscount; }
            set { m_ogdiscount = value; }
        }
        /// <summary>
        /// 主图图片网址
        /// </summary>
        public string ogimg
        {
            get { return m_ogimg; }
            set { m_ogimg = value; }
        }
        /// <summary>
        /// 销量
        /// </summary>
        public string ogsales
        {
            get { return m_ogsales; }
            set { m_ogsales = value; }
        }
        /// <summary>
        /// 邮费
        /// </summary>
        public string ogpostage
        {
            get { return m_ogpostage; }
            set { m_ogpostage = value; }
        }
        /// <summary>
        /// SKU数量
        /// </summary>
        public string ogSKU
        {
            get { return m_ogSKU; }
            set { m_ogSKU = value; }
        }
        /// <summary>
        /// 上架时间
        /// </summary>
        public string ogUPdate
        {
            get { return m_ogUPdate; }
            set { m_ogUPdate = value; }
        }
        /// <summary>
        /// 下架时间
        /// </summary>
        public string ogDowndate
        {
            get { return m_ogDowndate; }
            set { m_ogDowndate = value; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ogTBid
        {
            get { return m_ogTBid; }
            set { m_ogTBid = value; }
        }
        /// <summary>
        /// 累计评论
        /// </summary>
        public string ogxiaoliang
        {
            get { return m_ogxiaoliang; }
            set { m_ogxiaoliang = value; }
        }
        /// <summary>
        /// 收藏
        /// </summary>
        public string ogshoucang
        {
            get { return m_ogshoucang; }
            set { m_ogshoucang = value; }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public string ogremark
        {
            get { return m_ogremark; }
            set { m_ogremark = value; }
        }
        /// <summary>
        /// 备注2
        /// </summary>
        public string ogremark1
        {
            get { return m_ogremark1; }
            set { m_ogremark1 = value; }
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
        /// Name:ogremark2 Type:varchar
        /// </summary>
        public string ogremark2
        {
            get { return m_ogremark2; }
            set { m_ogremark2 = value; }
        }
        /// <summary>
        /// Name:ogremark3 Type:varchar
        /// </summary>
        public string ogremark3
        {
            get { return m_ogremark3; }
            set { m_ogremark3 = value; }
        }
        /// <summary>
        /// Name:ogremark4 Type:varchar
        /// </summary>
        public string ogremark4
        {
            get { return m_ogremark4; }
            set { m_ogremark4 = value; }
        }
        /// <summary>
        /// Name:ogremark5 Type:varchar
        /// </summary>
        public string ogremark5
        {
            get { return m_ogremark5; }
            set { m_ogremark5 = value; }
        }

    }
}

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
    /// class: goods
    /// </summary>
    [Serializable]
    public class goods
    {
        //进货价格		
        private string m_g_price_yuan;

        //备用字段1		
        private string m_g_standby1;

        //备用字段2		
        private string m_g_standby2;

        //备用字段3		
        private string m_g_standby3;

        //商品添加时间		
        private DateTime m_gdate;

        //商品传图时间		
        private DateTime m_gdate1;

        //商品上架时间		
        private DateTime m_gdate2;

        //商品标题优化时间		
        private DateTime m_gdate3;

        //商品ID		
        private int m_gid;

        //商品图片-淘宝		
        private string m_gimg;

        //商品图片-蘑菇街		
        private string m_gimg2;

        //商品名称		
        private string m_gname;

        //商品价格-淘宝		
        private string m_gprice1;

        //商品价格-蘑菇街		
        private string m_gprice2;

        //备注1		
        private string m_gremark1;

        //备注2		
        private string m_gremark2;

        //商品状态		
        private string m_gstate;

        //商品图片状态 1未传图 2已传图		
        private string m_gstate1;

        //商品上架状态 1未上架 2已上架		
        private string m_gstate2;

        //商品标题优化状态 1未优化标题 2已优化标题		
        private string m_gstate3;

        //商品类型ID		
        private int m_gtid;

        //商品标题		
        private string m_gtitle;

        //商品淘宝URL		
        private string m_gurl;

        //网供商品URL		
        private string m_gurl_yuan;

        //商品蘑菇街URL		
        private string m_gurl2;



        /// <summary>
        /// 进货价格
        /// </summary>
        public string g_price_yuan
        {
            get { return m_g_price_yuan; }
            set { m_g_price_yuan = value; }
        }
        /// <summary>
        /// 备用字段1
        /// </summary>
        public string g_standby1
        {
            get { return m_g_standby1; }
            set { m_g_standby1 = value; }
        }
        /// <summary>
        /// 备用字段2
        /// </summary>
        public string g_standby2
        {
            get { return m_g_standby2; }
            set { m_g_standby2 = value; }
        }
        /// <summary>
        /// 备用字段3
        /// </summary>
        public string g_standby3
        {
            get { return m_g_standby3; }
            set { m_g_standby3 = value; }
        }
        /// <summary>
        /// 商品添加时间
        /// </summary>
        public DateTime gdate
        {
            get { return m_gdate; }
            set { m_gdate = value; }
        }
        /// <summary>
        /// 商品传图时间
        /// </summary>
        public DateTime gdate1
        {
            get { return m_gdate1; }
            set { m_gdate1 = value; }
        }
        /// <summary>
        /// 商品上架时间
        /// </summary>
        public DateTime gdate2
        {
            get { return m_gdate2; }
            set { m_gdate2 = value; }
        }
        /// <summary>
        /// 商品标题优化时间
        /// </summary>
        public DateTime gdate3
        {
            get { return m_gdate3; }
            set { m_gdate3 = value; }
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
        /// 商品图片-淘宝
        /// </summary>
        public string gimg
        {
            get { return m_gimg; }
            set { m_gimg = value; }
        }
        /// <summary>
        /// 商品图片-蘑菇街
        /// </summary>
        public string gimg2
        {
            get { return m_gimg2; }
            set { m_gimg2 = value; }
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
        /// 商品价格-淘宝
        /// </summary>
        public string gprice1
        {
            get { return m_gprice1; }
            set { m_gprice1 = value; }
        }
        /// <summary>
        /// 商品价格-蘑菇街
        /// </summary>
        public string gprice2
        {
            get { return m_gprice2; }
            set { m_gprice2 = value; }
        }
        /// <summary>
        /// 备注1
        /// </summary>
        public string gremark1
        {
            get { return m_gremark1; }
            set { m_gremark1 = value; }
        }
        /// <summary>
        /// 备注2
        /// </summary>
        public string gremark2
        {
            get { return m_gremark2; }
            set { m_gremark2 = value; }
        }
        /// <summary>
        /// 商品状态
        /// </summary>
        public string gstate
        {
            get { return m_gstate; }
            set { m_gstate = value; }
        }
        /// <summary>
        /// 商品图片状态 1未传图 2已传图
        /// </summary>
        public string gstate1
        {
            get { return m_gstate1; }
            set { m_gstate1 = value; }
        }
        /// <summary>
        /// 商品上架状态 1未上架 2已上架
        /// </summary>
        public string gstate2
        {
            get { return m_gstate2; }
            set { m_gstate2 = value; }
        }
        /// <summary>
        /// 商品标题优化状态 1未优化标题 2已优化标题
        /// </summary>
        public string gstate3
        {
            get { return m_gstate3; }
            set { m_gstate3 = value; }
        }
        /// <summary>
        /// 商品类型ID
        /// </summary>
        public int gtid
        {
            get { return m_gtid; }
            set { m_gtid = value; }
        }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string gtitle
        {
            get { return m_gtitle; }
            set { m_gtitle = value; }
        }
        /// <summary>
        /// 商品淘宝URL
        /// </summary>
        public string gurl
        {
            get { return m_gurl; }
            set { m_gurl = value; }
        }
        /// <summary>
        /// 网供商品URL
        /// </summary>
        public string gurl_yuan
        {
            get { return m_gurl_yuan; }
            set { m_gurl_yuan = value; }
        }
        /// <summary>
        /// 商品蘑菇街URL
        /// </summary>
        public string gurl2
        {
            get { return m_gurl2; }
            set { m_gurl2 = value; }
        }
    }
}





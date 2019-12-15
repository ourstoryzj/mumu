/*
系统名称：Entity
作    者：张建
完成日期：2019-07-29
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: taobao_DataPackageModels
    /// </summary>
    [Serializable]
    public class taobao_DataPackageModels
    {
        //宝贝名称
        private string m_title;

        //宝贝类目
        private string m_cid;

        //店铺类目
        private string m_seller_cids;

        //新旧程度
        private string m_stuff_status;

        //省
        private string m_location_state;

        //城市
        private string m_location_city;

        //出售方式
        private string m_item_type;

        //宝贝价格
        private string m_price;

        //加价幅度
        private string m_auction_increment;

        //宝贝数量
        private string m_num;

        //有效期
        private string m_valid_thru;

        //运费承担
        private string m_freight_payer;

        //平邮
        private string m_post_fee;

        //EMS
        private string m_ems_fee;

        //快递
        private string m_express_fee;

        //发票
        private string m_has_invoice;

        //保修
        private string m_has_warranty;

        //放入仓库
        private string m_approve_status;

        //橱窗推荐
        private string m_has_showcase;

        //开始时间
        private string m_list_time;

        //宝贝描述
        private string m_description;

        //宝贝属性
        private string m_cateProps;

        //邮费模版ID
        private string m_postage_id;

        //会员打折
        private string m_has_discount;

        //修改时间
        private string m_modified;

        //上传状态
        private string m_upload_fail_msg;

        //图片状态
        private string m_picture_status;

        //返点比例
        private string m_auction_point;

        //新图片
        private string m_picture;

        //视频
        private string m_video;

        //销售属性组合
        private string m_skuProps;

        //用户输入ID串
        private string m_inputPids;

        //用户输入名-值对
        private string m_inputValues;

        //商家编码
        private string m_outer_id;

        //销售属性别名
        private string m_propAlias;

        //代充类型
        private string m_auto_fill;

        //数字ID
        private string m_num_id;

        //本地ID
        private string m_local_cid;

        //宝贝分类
        private string m_navigation_type;

        //用户名称
        private string m_user_name;

        //宝贝状态
        private string m_syncStatus;

        //闪电发货
        private string m_is_lighting_consigment;

        //新品
        private string m_is_xinpin;

        //食品专项
        private string m_foodparame;

        //尺码库
        private string m_features;

        //采购地
        private string m_buyareatype;

        //库存类型
        private string m_global_stock_type;

        //国家地区
        private string m_global_stock_country;

        //库存计数
        private string m_sub_stock_type;

        //物流体积
        private string m_item_size;

        //物流重量
        private string m_item_weight;

        //退换货承诺
        private string m_sell_promise;

        //定制工具
        private string m_custom_design_flag;

        //无线详情
        private string m_wireless_desc;

        //商品条形码
        private string m_barcode;

        //sku 条形码
        private string m_sku_barcode;

        //7天退货
        private string m_newprepay;

        //宝贝卖点
        private string m_subtitle;

        //属性值备注
        private string m_cpv_memo;

        //自定义属性值
        private string m_input_custom_cpv;

        //商品资质
        private string m_qualification;

        //增加商品资质
        private string m_add_qualification;

        //关联线下服务
        private string m_o2o_bind_service;

        //tmall扩展字段
        private string m_tmall_extend;

        //产品组合
        private string m_product_combine;

        //tmall属性组合
        private string m_tmall_item_prop_combine;

        //taoschema扩展字段
        private string m_taoschema_extend;



        ///<summary>
        ///宝贝名称
        ///</summary>
        public string title
        {
            get { return m_title; }
            set { m_title = value; }
        }
        ///<summary>
        ///宝贝类目
        ///</summary>
        public string cid
        {
            get { return m_cid; }
            set { m_cid = value; }
        }
        ///<summary>
        ///店铺类目
        ///</summary>
        public string seller_cids
        {
            get { return m_seller_cids; }
            set { m_seller_cids = value; }
        }
        ///<summary>
        ///新旧程度
        ///</summary>
        public string stuff_status
        {
            get { return m_stuff_status; }
            set { m_stuff_status = value; }
        }
        ///<summary>
        ///省
        ///</summary>
        public string location_state
        {
            get { return m_location_state; }
            set { m_location_state = value; }
        }
        ///<summary>
        ///城市
        ///</summary>
        public string location_city
        {
            get { return m_location_city; }
            set { m_location_city = value; }
        }
        ///<summary>
        ///出售方式
        ///</summary>
        public string item_type
        {
            get { return m_item_type; }
            set { m_item_type = value; }
        }
        ///<summary>
        ///宝贝价格
        ///</summary>
        public string price
        {
            get { return m_price; }
            set { m_price = value; }
        }
        ///<summary>
        ///加价幅度
        ///</summary>
        public string auction_increment
        {
            get { return m_auction_increment; }
            set { m_auction_increment = value; }
        }
        ///<summary>
        ///宝贝数量
        ///</summary>
        public string num
        {
            get { return m_num; }
            set { m_num = value; }
        }
        ///<summary>
        ///有效期
        ///</summary>
        public string valid_thru
        {
            get { return m_valid_thru; }
            set { m_valid_thru = value; }
        }
        ///<summary>
        ///运费承担
        ///</summary>
        public string freight_payer
        {
            get { return m_freight_payer; }
            set { m_freight_payer = value; }
        }
        ///<summary>
        ///平邮
        ///</summary>
        public string post_fee
        {
            get { return m_post_fee; }
            set { m_post_fee = value; }
        }
        ///<summary>
        ///EMS
        ///</summary>
        public string ems_fee
        {
            get { return m_ems_fee; }
            set { m_ems_fee = value; }
        }
        ///<summary>
        ///快递
        ///</summary>
        public string express_fee
        {
            get { return m_express_fee; }
            set { m_express_fee = value; }
        }
        ///<summary>
        ///发票
        ///</summary>
        public string has_invoice
        {
            get { return m_has_invoice; }
            set { m_has_invoice = value; }
        }
        ///<summary>
        ///保修
        ///</summary>
        public string has_warranty
        {
            get { return m_has_warranty; }
            set { m_has_warranty = value; }
        }
        ///<summary>
        ///放入仓库
        ///</summary>
        public string approve_status
        {
            get { return m_approve_status; }
            set { m_approve_status = value; }
        }
        ///<summary>
        ///橱窗推荐
        ///</summary>
        public string has_showcase
        {
            get { return m_has_showcase; }
            set { m_has_showcase = value; }
        }
        ///<summary>
        ///开始时间
        ///</summary>
        public string list_time
        {
            get { return m_list_time; }
            set { m_list_time = value; }
        }
        ///<summary>
        ///宝贝描述
        ///</summary>
        public string description
        {
            get { return m_description; }
            set { m_description = value; }
        }
        ///<summary>
        ///宝贝属性
        ///</summary>
        public string cateProps
        {
            get { return m_cateProps; }
            set { m_cateProps = value; }
        }
        ///<summary>
        ///邮费模版ID
        ///</summary>
        public string postage_id
        {
            get { return m_postage_id; }
            set { m_postage_id = value; }
        }
        ///<summary>
        ///会员打折
        ///</summary>
        public string has_discount
        {
            get { return m_has_discount; }
            set { m_has_discount = value; }
        }
        ///<summary>
        ///修改时间
        ///</summary>
        public string modified
        {
            get { return m_modified; }
            set { m_modified = value; }
        }
        ///<summary>
        ///上传状态
        ///</summary>
        public string upload_fail_msg
        {
            get { return m_upload_fail_msg; }
            set { m_upload_fail_msg = value; }
        }
        ///<summary>
        ///图片状态
        ///</summary>
        public string picture_status
        {
            get { return m_picture_status; }
            set { m_picture_status = value; }
        }
        ///<summary>
        ///返点比例
        ///</summary>
        public string auction_point
        {
            get { return m_auction_point; }
            set { m_auction_point = value; }
        }
        ///<summary>
        ///新图片
        ///</summary>
        public string picture
        {
            get { return m_picture; }
            set { m_picture = value; }
        }
        ///<summary>
        ///视频
        ///</summary>
        public string video
        {
            get { return m_video; }
            set { m_video = value; }
        }
        ///<summary>
        ///销售属性组合
        ///</summary>
        public string skuProps
        {
            get { return m_skuProps; }
            set { m_skuProps = value; }
        }
        ///<summary>
        ///用户输入ID串
        ///</summary>
        public string inputPids
        {
            get { return m_inputPids; }
            set { m_inputPids = value; }
        }
        ///<summary>
        ///用户输入名-值对
        ///</summary>
        public string inputValues
        {
            get { return m_inputValues; }
            set { m_inputValues = value; }
        }
        ///<summary>
        ///商家编码
        ///</summary>
        public string outer_id
        {
            get { return m_outer_id; }
            set { m_outer_id = value; }
        }
        ///<summary>
        ///销售属性别名
        ///</summary>
        public string propAlias
        {
            get { return m_propAlias; }
            set { m_propAlias = value; }
        }
        ///<summary>
        ///代充类型
        ///</summary>
        public string auto_fill
        {
            get { return m_auto_fill; }
            set { m_auto_fill = value; }
        }
        ///<summary>
        ///数字ID
        ///</summary>
        public string num_id
        {
            get { return m_num_id; }
            set { m_num_id = value; }
        }
        ///<summary>
        ///本地ID
        ///</summary>
        public string local_cid
        {
            get { return m_local_cid; }
            set { m_local_cid = value; }
        }
        ///<summary>
        ///宝贝分类
        ///</summary>
        public string navigation_type
        {
            get { return m_navigation_type; }
            set { m_navigation_type = value; }
        }
        ///<summary>
        ///用户名称
        ///</summary>
        public string user_name
        {
            get { return m_user_name; }
            set { m_user_name = value; }
        }
        ///<summary>
        ///宝贝状态
        ///</summary>
        public string syncStatus
        {
            get { return m_syncStatus; }
            set { m_syncStatus = value; }
        }
        ///<summary>
        ///闪电发货
        ///</summary>
        public string is_lighting_consigment
        {
            get { return m_is_lighting_consigment; }
            set { m_is_lighting_consigment = value; }
        }
        ///<summary>
        ///新品
        ///</summary>
        public string is_xinpin
        {
            get { return m_is_xinpin; }
            set { m_is_xinpin = value; }
        }
        ///<summary>
        ///食品专项
        ///</summary>
        public string foodparame
        {
            get { return m_foodparame; }
            set { m_foodparame = value; }
        }
        ///<summary>
        ///尺码库
        ///</summary>
        public string features
        {
            get { return m_features; }
            set { m_features = value; }
        }
        ///<summary>
        ///采购地
        ///</summary>
        public string buyareatype
        {
            get { return m_buyareatype; }
            set { m_buyareatype = value; }
        }
        ///<summary>
        ///库存类型
        ///</summary>
        public string global_stock_type
        {
            get { return m_global_stock_type; }
            set { m_global_stock_type = value; }
        }
        ///<summary>
        ///国家地区
        ///</summary>
        public string global_stock_country
        {
            get { return m_global_stock_country; }
            set { m_global_stock_country = value; }
        }
        ///<summary>
        ///库存计数
        ///</summary>
        public string sub_stock_type
        {
            get { return m_sub_stock_type; }
            set { m_sub_stock_type = value; }
        }
        ///<summary>
        ///物流体积
        ///</summary>
        public string item_size
        {
            get { return m_item_size; }
            set { m_item_size = value; }
        }
        ///<summary>
        ///物流重量
        ///</summary>
        public string item_weight
        {
            get { return m_item_weight; }
            set { m_item_weight = value; }
        }
        ///<summary>
        ///退换货承诺
        ///</summary>
        public string sell_promise
        {
            get { return m_sell_promise; }
            set { m_sell_promise = value; }
        }
        ///<summary>
        ///定制工具
        ///</summary>
        public string custom_design_flag
        {
            get { return m_custom_design_flag; }
            set { m_custom_design_flag = value; }
        }
        ///<summary>
        ///无线详情
        ///</summary>
        public string wireless_desc
        {
            get { return m_wireless_desc; }
            set { m_wireless_desc = value; }
        }
        ///<summary>
        ///商品条形码
        ///</summary>
        public string barcode
        {
            get { return m_barcode; }
            set { m_barcode = value; }
        }
        ///<summary>
        ///sku 条形码
        ///</summary>
        public string sku_barcode
        {
            get { return m_sku_barcode; }
            set { m_sku_barcode = value; }
        }
        ///<summary>
        ///7天退货
        ///</summary>
        public string newprepay
        {
            get { return m_newprepay; }
            set { m_newprepay = value; }
        }
        ///<summary>
        ///宝贝卖点
        ///</summary>
        public string subtitle
        {
            get { return m_subtitle; }
            set { m_subtitle = value; }
        }
        ///<summary>
        ///属性值备注
        ///</summary>
        public string cpv_memo
        {
            get { return m_cpv_memo; }
            set { m_cpv_memo = value; }
        }
        ///<summary>
        ///自定义属性值
        ///</summary>
        public string input_custom_cpv
        {
            get { return m_input_custom_cpv; }
            set { m_input_custom_cpv = value; }
        }
        ///<summary>
        ///商品资质
        ///</summary>
        public string qualification
        {
            get { return m_qualification; }
            set { m_qualification = value; }
        }
        ///<summary>
        ///增加商品资质
        ///</summary>
        public string add_qualification
        {
            get { return m_add_qualification; }
            set { m_add_qualification = value; }
        }
        ///<summary>
        ///关联线下服务
        ///</summary>
        public string o2o_bind_service
        {
            get { return m_o2o_bind_service; }
            set { m_o2o_bind_service = value; }
        }
        ///<summary>
        ///tmall扩展字段
        ///</summary>
        public string tmall_extend
        {
            get { return m_tmall_extend; }
            set { m_tmall_extend = value; }
        }
        ///<summary>
        ///产品组合
        ///</summary>
        public string product_combine
        {
            get { return m_product_combine; }
            set { m_product_combine = value; }
        }
        ///<summary>
        ///tmall属性组合
        ///</summary>
        public string tmall_item_prop_combine
        {
            get { return m_tmall_item_prop_combine; }
            set { m_tmall_item_prop_combine = value; }
        }
        ///<summary>
        ///taoschema扩展字段
        ///</summary>
        public string taoschema_extend
        {
            get { return m_taoschema_extend; }
            set { m_taoschema_extend = value; }
        }

    }
}

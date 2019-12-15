/*
系统名称：Entity
作    者：张建
完成日期：2017-01-08
内容摘要：实体类
*/

using System;

namespace Entity
{

    /// <summary>
    /// class: autonew_model
    /// </summary>
    [Serializable]
    public class autonew_model
    {
        //编号		
        private int m_amid;

        //模板名称		
        private string m_amname;

        //商品标题		
        private string m_amtitle;

        //简述		
        private string m_amjianshu;

        //编码		
        private string m_amcode;

        //颜色 多选用|隔开		
        private string m_amcolor;

        //尺寸 多选用|隔开		
        private string m_amsize;

        //数量		
        private string m_amnum;

        //是否有夹层     1有 2无		
        private string m_amjiazeng;

        //硬度     1软 2硬		
        private string m_amyingdu;

        //大小： 1迷你，2小，3中，4大		
        private string m_amdaxiao;

        //提拎部件：1装卸式提把  2伸缩式提把 3软把 4硬把 5锁链式提把		
        private string m_amtilin;

        //外袋种类：1挖袋，2内贴袋，3敞口袋，4带盖带，5立体袋		
        private string m_amwaidai;

        //内部结构：1拉链暗袋，2手机袋，3证件袋，4夹层拉链袋，5电脑插袋，6相机插袋		
        private string m_amneibu;

        //箱包场合		
        private string m_amchanghe;

        //里料		
        private string m_amliliao;

        //打开		
        private string m_amdakai;

        //图案		
        private string m_amtuan;

        //材质		
        private string m_amcaizhi;

        //外形		
        private string m_amwaixing;

        //元素		
        private string m_amyuansu;

        //分类		
        private string m_amfenlei;

        //减库存方式		
        private string m_amjiankucun;

        //出售方式		
        private string m_amchushou;

        //尺寸介绍		
        private string m_amchicun;

        //模特介绍		
        private string m_ammote;

        //静物介绍		
        private string m_amjingwu;

        //细节介绍		
        private string m_amxijie;

        //产品介绍		
        private string m_amchanpin;

        //品牌介绍		
        private string m_ampinpai;

        //保障介绍		
        private string m_ambaozhuang;

        //服务介绍		
        private string m_amfuwu;

        //资质介绍		
        private string m_amzizhi;

        //店铺介绍		
        private string m_amdianpu;

        //备注2		
        private string m_amremark2;

        //备注1		
        private string m_amremark1;

        //备注3		
        private string m_amremark3;

        //备注4		
        private string m_amremark4;

        //备注5		
        private string m_amremark5;

        //备注6		
        private string m_amremark6;

        //备注7		
        private string m_amremark7;

        //备注8		
        private string m_amremark8;

        //模板类型  1 蘑菇街单肩包  2 蘑菇街双肩包 3淘宝单肩包 4 淘宝双肩包		
        private string m_amtype;



        /// <summary>
        /// 编号
        /// </summary>
        public int amid
        {
            get { return m_amid; }
            set { m_amid = value; }
        }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string amname
        {
            get { return m_amname; }
            set { m_amname = value; }
        }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string amtitle
        {
            get { return m_amtitle; }
            set { m_amtitle = value; }
        }
        /// <summary>
        /// 简述
        /// </summary>
        public string amjianshu
        {
            get { return m_amjianshu; }
            set { m_amjianshu = value; }
        }
        /// <summary>
        /// 编码
        /// </summary>
        public string amcode
        {
            get { return m_amcode; }
            set { m_amcode = value; }
        }
        /// <summary>
        /// 颜色 多选用|隔开
        /// </summary>
        public string amcolor
        {
            get { return m_amcolor; }
            set { m_amcolor = value; }
        }
        /// <summary>
        /// 尺寸 多选用|隔开
        /// </summary>
        public string amsize
        {
            get { return m_amsize; }
            set { m_amsize = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public string amnum
        {
            get { return m_amnum; }
            set { m_amnum = value; }
        }
        /// <summary>
        /// 是否有夹层     1有 2无
        /// </summary>
        public string amjiazeng
        {
            get { return m_amjiazeng; }
            set { m_amjiazeng = value; }
        }
        /// <summary>
        /// 硬度     1软 2硬
        /// </summary>
        public string amyingdu
        {
            get { return m_amyingdu; }
            set { m_amyingdu = value; }
        }
        /// <summary>
        /// 大小： 1迷你，2小，3中，4大
        /// </summary>
        public string amdaxiao
        {
            get { return m_amdaxiao; }
            set { m_amdaxiao = value; }
        }
        /// <summary>
        /// 提拎部件：1装卸式提把  2伸缩式提把 3软把 4硬把 5锁链式提把
        /// </summary>
        public string amtilin
        {
            get { return m_amtilin; }
            set { m_amtilin = value; }
        }
        /// <summary>
        /// 外袋种类：1挖袋，2内贴袋，3敞口袋，4带盖带，5立体袋
        /// </summary>
        public string amwaidai
        {
            get { return m_amwaidai; }
            set { m_amwaidai = value; }
        }
        /// <summary>
        /// 内部结构：1拉链暗袋，2手机袋，3证件袋，4夹层拉链袋，5电脑插袋，6相机插袋
        /// </summary>
        public string amneibu
        {
            get { return m_amneibu; }
            set { m_amneibu = value; }
        }
        /// <summary>
        /// 箱包场合
        /// </summary>
        public string amchanghe
        {
            get { return m_amchanghe; }
            set { m_amchanghe = value; }
        }
        /// <summary>
        /// 里料
        /// </summary>
        public string amliliao
        {
            get { return m_amliliao; }
            set { m_amliliao = value; }
        }
        /// <summary>
        /// 打开
        /// </summary>
        public string amdakai
        {
            get { return m_amdakai; }
            set { m_amdakai = value; }
        }
        /// <summary>
        /// 图案
        /// </summary>
        public string amtuan
        {
            get { return m_amtuan; }
            set { m_amtuan = value; }
        }
        /// <summary>
        /// 材质
        /// </summary>
        public string amcaizhi
        {
            get { return m_amcaizhi; }
            set { m_amcaizhi = value; }
        }
        /// <summary>
        /// 外形
        /// </summary>
        public string amwaixing
        {
            get { return m_amwaixing; }
            set { m_amwaixing = value; }
        }
        /// <summary>
        /// 元素
        /// </summary>
        public string amyuansu
        {
            get { return m_amyuansu; }
            set { m_amyuansu = value; }
        }
        /// <summary>
        /// 分类
        /// </summary>
        public string amfenlei
        {
            get { return m_amfenlei; }
            set { m_amfenlei = value; }
        }
        /// <summary>
        /// 减库存方式
        /// </summary>
        public string amjiankucun
        {
            get { return m_amjiankucun; }
            set { m_amjiankucun = value; }
        }
        /// <summary>
        /// 出售方式
        /// </summary>
        public string amchushou
        {
            get { return m_amchushou; }
            set { m_amchushou = value; }
        }
        /// <summary>
        /// 尺寸介绍
        /// </summary>
        public string amchicun
        {
            get { return m_amchicun; }
            set { m_amchicun = value; }
        }
        /// <summary>
        /// 模特介绍
        /// </summary>
        public string ammote
        {
            get { return m_ammote; }
            set { m_ammote = value; }
        }
        /// <summary>
        /// 静物介绍
        /// </summary>
        public string amjingwu
        {
            get { return m_amjingwu; }
            set { m_amjingwu = value; }
        }
        /// <summary>
        /// 细节介绍
        /// </summary>
        public string amxijie
        {
            get { return m_amxijie; }
            set { m_amxijie = value; }
        }
        /// <summary>
        /// 产品介绍
        /// </summary>
        public string amchanpin
        {
            get { return m_amchanpin; }
            set { m_amchanpin = value; }
        }
        /// <summary>
        /// 品牌介绍
        /// </summary>
        public string ampinpai
        {
            get { return m_ampinpai; }
            set { m_ampinpai = value; }
        }
        /// <summary>
        /// 保障介绍
        /// </summary>
        public string ambaozhuang
        {
            get { return m_ambaozhuang; }
            set { m_ambaozhuang = value; }
        }
        /// <summary>
        /// 服务介绍
        /// </summary>
        public string amfuwu
        {
            get { return m_amfuwu; }
            set { m_amfuwu = value; }
        }
        /// <summary>
        /// 资质介绍
        /// </summary>
        public string amzizhi
        {
            get { return m_amzizhi; }
            set { m_amzizhi = value; }
        }
        /// <summary>
        /// 店铺介绍
        /// </summary>
        public string amdianpu
        {
            get { return m_amdianpu; }
            set { m_amdianpu = value; }
        }
        /// <summary>
        /// 备注2
        /// </summary>
        public string amremark2
        {
            get { return m_amremark2; }
            set { m_amremark2 = value; }
        }
        /// <summary>
        /// 备注1
        /// </summary>
        public string amremark1
        {
            get { return m_amremark1; }
            set { m_amremark1 = value; }
        }
        /// <summary>
        /// 备注3
        /// </summary>
        public string amremark3
        {
            get { return m_amremark3; }
            set { m_amremark3 = value; }
        }
        /// <summary>
        /// 备注4
        /// </summary>
        public string amremark4
        {
            get { return m_amremark4; }
            set { m_amremark4 = value; }
        }
        /// <summary>
        /// 备注5
        /// </summary>
        public string amremark5
        {
            get { return m_amremark5; }
            set { m_amremark5 = value; }
        }
        /// <summary>
        /// 备注6
        /// </summary>
        public string amremark6
        {
            get { return m_amremark6; }
            set { m_amremark6 = value; }
        }
        /// <summary>
        /// 备注7
        /// </summary>
        public string amremark7
        {
            get { return m_amremark7; }
            set { m_amremark7 = value; }
        }
        /// <summary>
        /// 备注8
        /// </summary>
        public string amremark8
        {
            get { return m_amremark8; }
            set { m_amremark8 = value; }
        }
        /// <summary>
        /// 模板类型  1 蘑菇街单肩包  2 蘑菇街双肩包 3淘宝单肩包 4 淘宝双肩包
        /// </summary>
        public string amtype
        {
            get { return m_amtype; }
            set { m_amtype = value; }
        }

    }
}

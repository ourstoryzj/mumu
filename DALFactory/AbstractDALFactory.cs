using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using IDAL;

namespace DALFactory
{
    public abstract class AbstractDALFactory
    {
        public static AbstractDALFactory ChooseFactory()
        {
            string DBType = ConfigurationManager.AppSettings["DBType"].ToString();
            AbstractDALFactory factory = null;
            switch (DBType)
            {
                case "SQL":
                    factory = new SQLDALFactory();
                    break;
                case "Access":
                    factory = new AccessDALService();
                    break;

            }
            return factory;
        }

        public abstract Ilh_keydataService Createlh_keydataService();
        public abstract Ilh_hangyeService Createlh_hangyeService();
        public abstract Ilh_rankinglistService Createlh_rankinglistService();
        public abstract Isubway_goodsService Createsubway_goodsService();
        public abstract Isubway_keyService Createsubway_keyService();
        public abstract Ishuadan_recordsService Createshuadan_recordsService();
        public abstract Ikeys_tiaojianService Createkeys_tiaojianService();
        public abstract Ikeys_lexiconService Createkeys_lexiconService();
        public abstract IkeysService CreatekeysService();
        public abstract Iwanggong_dianpuService Createwanggong_dianpuService();
        public abstract Iwanggong_goodsService Createwanggong_goodsService();
        public abstract Iaotunew_titleService Createaotunew_titleService();


        public abstract IdianpuService CreatedianpuService();
        public abstract IshouhouService CreateshouhouService();
        public abstract IshuadanService CreateshuadanService();
        public abstract Ishuadan_phoneService Createshuadan_phoneService();
        public abstract Ishuadan_accountService Createshuadan_accountService();
        public abstract IfanxianService CreatefanxianService();
        public abstract IUsersService CreateUsersService();
        public abstract ISignsService CreateSignsService();
        public abstract IBasicService CreateBasicService();
        public abstract IAdminsService CreateAdminsService();
        public abstract IgoodsService CreategoodsService();
        public abstract Iyh_zaociService Createyh_zaociService();
        public abstract Iyh_keysService Createyh_keysService();
        public abstract Iyh_goodstypeService Createyh_goodstypeService();
        public abstract Iyh_goods_keysService Createyh_goods_keysService();
        public abstract Iyh_goods_corekeysService Createyh_goods_corekeysService();
        public abstract Iyh_corekeysService Createyh_corekeysService();
        public abstract Ishuadan_namesService Createshuadan_namesService();
        public abstract IaddressService CreateaddressService();
        public abstract Ishuadan_recordService Createshuadan_recordService();
        public abstract Ishuadan_pingjiaService Createshuadan_pingjiaService();


        public abstract Ipages_typeService Createpages_typeService();


        public abstract IpagesService CreatepagesService();


        public abstract IcourierService CreatecourierService();


        public abstract Ireturn_goodsService Createreturn_goodsService();


        public abstract Iopponent_dianpuService Createopponent_dianpuService();


        public abstract Iopponent_dianpu_infoService Createopponent_dianpu_infoService();


        public abstract Iopponent_goodsService Createopponent_goodsService();

        public abstract Idata_hotkeysService Createdata_hotkeysService();


        public abstract Iautonew_modelService Createautonew_modelService();
         
    }
}

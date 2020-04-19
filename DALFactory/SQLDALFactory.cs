using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using IDAL;

namespace DALFactory
{
    public class SQLDALFactory : AbstractDALFactory
    {

        public override IDAL.IdianpuService CreatedianpuService()
        {
            return new DAL.dianpuService();
        }

        public override IDAL.IshouhouService CreateshouhouService()
        {
            return new DAL.shouhouService();
        }

        public override IDAL.IshuadanService CreateshuadanService()
        {
            //return new DAL.shuadanService();
            throw new NotImplementedException();
        }

        public override Ishuadan_phoneService Createshuadan_phoneService()
        {
            return new DAL.shuadan_phoneService();
        }

        public override Ishuadan_accountService Createshuadan_accountService()
        {
            return new DAL.shuadan_accountService();
            //throw new NotImplementedException();
        }

        public override IfanxianService CreatefanxianService()
        {
            //return new DAL.fanxianService();
            throw new NotImplementedException();
        }

        public override IUsersService CreateUsersService()
        {
            return new DAL.UsersService();
        }

        public override ISignsService CreateSignsService()
        {
            return new DAL.SignsService();
        }

        public override IBasicService CreateBasicService()
        {
            return new DAL.BasicService();
        }



        public override IgoodsService CreategoodsService()
        {
            return new DAL.goodsService();
        }

        public override Iyh_zaociService Createyh_zaociService()
        {
            return new DAL.yh_zaociService();
        }

        public override Iyh_keysService Createyh_keysService()
        {
            return new DAL.yh_keysService();
        }

        public override Iyh_goodstypeService Createyh_goodstypeService()
        {
            return new DAL.yh_goodstypeService();
        }

        public override Iyh_goods_keysService Createyh_goods_keysService()
        {
            return new DAL.yh_goods_keysService();
        }

        public override Iyh_goods_corekeysService Createyh_goods_corekeysService()
        {
            return new DAL.yh_goods_corekeysService();
        }

        public override Iyh_corekeysService Createyh_corekeysService()
        {
            return new DAL.yh_corekeysService();
        }

        public override Ishuadan_namesService Createshuadan_namesService()
        {
            //return new DAL.shuadan_namesService();
            throw new NotImplementedException();
        }

        public override IaddressService CreateaddressService()
        {
            //return new DAL.addressService();
            throw new NotImplementedException();

        }

        public override Ishuadan_recordService Createshuadan_recordService()
        {
            //return new DAL.shuadan_recordService();
            throw new NotImplementedException();



        }

        public override Ishuadan_pingjiaService Createshuadan_pingjiaService()
        {
            //return new DAL.shuadan_pingjiaService();
            throw new NotImplementedException();


        }

        public override Ipages_typeService Createpages_typeService()
        {
            //return new DAL.pages_typeService();
            throw new NotImplementedException();
        }

        public override IpagesService CreatepagesService()
        {
            //return new DAL.pagesService();
            throw new NotImplementedException();
        }

        public override IcourierService CreatecourierService()
        {
            //return new DAL.courierService();
            throw new NotImplementedException();
        }

        public override Ireturn_goodsService Createreturn_goodsService()
        {
            //return new DAL.return_goodsService();
            throw new NotImplementedException();
        }

        public override IAdminsService CreateAdminsService()
        {
            throw new NotImplementedException();
        }

        public override Iopponent_dianpuService Createopponent_dianpuService()
        {
            return new DAL.opponent_dianpuService();
        }

        public override Iopponent_dianpu_infoService Createopponent_dianpu_infoService()
        {
            return new DAL.opponent_dianpu_infoService();
        }

        public override Iopponent_goodsService Createopponent_goodsService()
        {
            return new DAL.opponent_goodsService();
        }

        public override Idata_hotkeysService Createdata_hotkeysService()
        {
            return new DAL.data_hotkeysService();
        }

        public override Iautonew_modelService Createautonew_modelService()
        {
            return new DAL.autonew_modelService();
        }

        public override Iaotunew_titleService Createaotunew_titleService()
        {
            return new DAL.aotunew_titleService();
        }

        public override Iwanggong_dianpuService Createwanggong_dianpuService()
        {
            return new DAL.wanggong_dianpuService();
        }

        public override Iwanggong_goodsService Createwanggong_goodsService()
        {
            return new DAL.wanggong_goodsService();
        }

        public override Ikeys_lexiconService Createkeys_lexiconService()
        {
            return new DAL.keys_lexiconService();
        }

        public override IkeysService CreatekeysService()
        {
            return new DAL.keysService();
        }

        public override Ikeys_tiaojianService Createkeys_tiaojianService()
        {
            return new DAL.keys_tiaojianService();
        }

        public override Ishuadan_recordsService Createshuadan_recordsService()
        {
            return new DAL.shuadan_recordsService();
        }

        public override Isubway_keyService Createsubway_keyService()
        {
            return new DAL.subway_keyService();
        }

        public override Isubway_goodsService Createsubway_goodsService()
        {
            return new DAL.subway_goodsService();
        }

        public override Ilh_keydataService Createlh_keydataService()
        {
            return new DAL.lh_keydataService();
        }

        public override Ilh_hangyeService Createlh_hangyeService()
        {
            return new DAL.lh_hangyeService();
        }

        public override Ilh_rankinglistService Createlh_rankinglistService()
        {
            return new DAL.lh_rankinglistService();
        }
    }
}

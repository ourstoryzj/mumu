using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using IDAL;
using DAL.Access;

namespace DALFactory
{
    public  class AccessDALService:AbstractDALFactory
    {

       

        public override IDAL.IdianpuService CreatedianpuService()
        {
            return new DAL.Access.dianpuService();
        }

        public override IDAL.IshouhouService CreateshouhouService()
        {
            return new DAL.Access.shouhouService();
        }

        public override IDAL.IshuadanService CreateshuadanService()
        {
            return new DAL.Access.shuadanService();
        }

        public override Ishuadan_phoneService Createshuadan_phoneService()
        {
            return new DAL.Access.shuadan_phoneService();
        }

        public override Ishuadan_accountService Createshuadan_accountService()
        {
            return new DAL.shuadan_accountService();
        }

        public override IfanxianService CreatefanxianService()
        {
            return new DAL.Access.fanxianService();
        }

        public override IUsersService CreateUsersService()
        {
            return new DAL.Access.UsersService();
        }

        public override ISignsService CreateSignsService()
        {
            return new DAL.Access.SignsService();
        }

        public override IBasicService CreateBasicService()
        {
            return new DAL.Access.BasicService();
        }

         

        public override IgoodsService CreategoodsService()
        {
            return new DAL.Access.goodsService();
        }

        public override Iyh_zaociService Createyh_zaociService()
        {
            throw new NotImplementedException();
        }

        public override Iyh_keysService Createyh_keysService()
        {
            return new DAL.Access.yh_keysService();
        }

        public override Iyh_goodstypeService Createyh_goodstypeService()
        {
            return new DAL.Access.yh_goodstypeService();
        }

        public override Iyh_goods_keysService Createyh_goods_keysService()
        {
            return new DAL.Access.yh_goods_keysService();
        }

        public override Iyh_goods_corekeysService Createyh_goods_corekeysService()
        {
            return new DAL.Access.yh_goods_corekeysService();
        }

        public override Iyh_corekeysService Createyh_corekeysService()
        {
            return new DAL.Access.yh_corekeysService();
        }

        public override Ishuadan_namesService Createshuadan_namesService()
        {
            return new DAL.Access.shuadan_namesService();
        }

        public override IaddressService CreateaddressService()
        {
            return new DAL.Access.AddressService();
        }

        public override Ishuadan_recordService Createshuadan_recordService()
        {
            return new DAL.Access.shuadan_recordService();
        }

        public override Ishuadan_pingjiaService Createshuadan_pingjiaService()
        {
            return new DAL.Access.shuadan_pingjiaService();
        }

        public override Ipages_typeService Createpages_typeService()
        {
            return new DAL.Access.pages_typeService();
        }

        public override IpagesService CreatepagesService()
        {
            return new DAL.Access.pagesService();
        }

        public override IcourierService CreatecourierService()
        {
            return new DAL.Access.courierService();
        }

        public override Ireturn_goodsService Createreturn_goodsService()
        {
            return new DAL.Access.return_goodsService();
        }

        public override IAdminsService CreateAdminsService()
        {
            throw new NotImplementedException();
        }

        public override Iopponent_dianpuService Createopponent_dianpuService()
        {
            throw new NotImplementedException();
        }

        public override Iopponent_dianpu_infoService Createopponent_dianpu_infoService()
        {
            throw new NotImplementedException();
        }

        public override Iopponent_goodsService Createopponent_goodsService()
        {
            throw new NotImplementedException();
        }

        public override Idata_hotkeysService Createdata_hotkeysService()
        {
            throw new NotImplementedException();
        }

        public override Iautonew_modelService Createautonew_modelService()
        {
            throw new NotImplementedException();
        }

        public override Iaotunew_titleService Createaotunew_titleService()
        {
            throw new NotImplementedException();
        }

        public override Iwanggong_dianpuService Createwanggong_dianpuService()
        {
            throw new NotImplementedException();
        }

        public override Iwanggong_goodsService Createwanggong_goodsService()
        {
            throw new NotImplementedException();
        }

        public override Ikeys_lexiconService Createkeys_lexiconService()
        {
            throw new NotImplementedException();
        }

        public override IkeysService CreatekeysService()
        {
            throw new NotImplementedException();
        }

        public override Ikeys_tiaojianService Createkeys_tiaojianService()
        {
            throw new NotImplementedException();
        }

        public override Ishuadan_recordsService Createshuadan_recordsService()
        {
            throw new NotImplementedException();
        }

        public override Isubway_keyService Createsubway_keyService()
        {
            throw new NotImplementedException();
        }

        public override Isubway_goodsService Createsubway_goodsService()
        {
            throw new NotImplementedException();
        }

        public override Ilh_keydataService Createlh_keydataService()
        {
            throw new NotImplementedException();
        }

        public override Ilh_hangyeService Createlh_hangyeService()
        {
            throw new NotImplementedException();
        }

        public override Ilh_rankinglistService Createlh_rankinglistService()
        {
            throw new NotImplementedException();
        }
    }
}

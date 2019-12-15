using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using IDAL;
using DAL.MySql;

namespace DALFactory
{
    public  class MySqlDALService:AbstractDALFactory
    {

        

        public override IDAL.IdianpuService CreatedianpuService()
        {
            return new DAL.MySql.dianpuService();
        }

        public override IDAL.IshouhouService CreateshouhouService()
        {
            return new DAL.MySql.shouhouService();
        }

        public override IDAL.IshuadanService CreateshuadanService()
        {
            return new DAL.shuadanService();
        }

        public override Ishuadan_phoneService Createshuadan_phoneService()
        {
            return new DAL.shuadan_phoneService();
        }

        public override Ishuadan_accountService Createshuadan_accountService()
        {
            return new DAL.shuadan_accountService();
        }

        public override IfanxianService CreatefanxianService()
        {
            return new DAL.fanxianService();
        }

        public override IUsersService CreateUsersService()
        {
            throw new NotImplementedException();
        }

        public override ISignsService CreateSignsService()
        {
            throw new NotImplementedException();
        }

        public override IBasicService CreateBasicService()
        {
            throw new NotImplementedException();
        }

        public override IAdminsService CreateAdminsService()
        {
            throw new NotImplementedException();
        }
    }
}

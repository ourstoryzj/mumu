using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using DALFactory;


namespace BLL2
{

    /*BLL*/
    public class test
    {
        public static AbstractDALFactory factory = AbstractDALFactory.ChooseFactory();
        private static IdianpuService Service = factory.CreatedianpuService();
       
        
        public static string haha()
        {
            return "dajiahao";
        }



    }
}

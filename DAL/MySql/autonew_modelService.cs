using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using MySql.Data.MySqlClient;

namespace DAL.Mysql
{
     

    public class autonew_modelService : Iautonew_modelService
    {
        #region SearchAll
        /// <summary>
        /// 查询全部数据
        /// </summary>
        /// <returns>IList</returns>
        /*查看是否为视图*/
        public IList<autonew_model> SearchAll()
        {
            DBHelper.sqlstr = "select * from autonew_model ";
            List<autonew_model> list = new List<autonew_model>();
            MySqlDataReader reader = DBHelper.ExecuteReader();
            while (reader.Read())
            {
                autonew_model Obj = GetByReader(reader);
                list.Add(Obj);
            }
            reader.Close();
            return list;
        }
        #endregion

        #region SearchByID
        /// <summary>
        /// 根据amid,查询一条数据
        /// </summary>
        /// <param name="amid">编号</param>
        /// <returns></returns>
        /*查看是否为视图*/

        public autonew_model SearchByID(int amid)
        {
            DBHelper.sqlstr = "select * from autonew_model where amid = @amid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@amid",amid)
			};
            MySqlDataReader reader = DBHelper.ExecuteReader(param);
            autonew_model Obj = null;
            if (reader.Read())
            {
                Obj = GetByReader(reader);
            }
            reader.Close();
            return Obj;
        }
        #endregion

        #region Insert
        /// <summary>
        /// 插入方法
        /// </summary>
        /// <param name="autonew_model">autonew_model表实例</param>
        /// <returns>int</returns>
        public int Insert(autonew_model autonew_modelExample)
        {
            DBHelper.sqlstr = "insert into  autonew_model (amname,amtitle,amjianshu,amcode,amcolor,amsize,amnum,amjiazeng,amyingdu,amdaxiao,amtilin,amwaidai,amneibu,amchanghe,amliliao,amdakai,amtuan,amcaizhi,amwaixing,amyuansu,amfenlei,amjiankucun,amchushou,amchicun,ammote,amjingwu,amxijie,amchanpin,ampinpai,ambaozhuang,amfuwu,amzizhi,amdianpu,amremark2,amremark1,amremark3,amremark4,amremark5,amremark6,amremark7,amremark8,amtype)values(@amname,@amtitle,@amjianshu,@amcode,@amcolor,@amsize,@amnum,@amjiazeng,@amyingdu,@amdaxiao,@amtilin,@amwaidai,@amneibu,@amchanghe,@amliliao,@amdakai,@amtuan,@amcaizhi,@amwaixing,@amyuansu,@amfenlei,@amjiankucun,@amchushou,@amchicun,@ammote,@amjingwu,@amxijie,@amchanpin,@ampinpai,@ambaozhuang,@amfuwu,@amzizhi,@amdianpu,@amremark2,@amremark1,@amremark3,@amremark4,@amremark5,@amremark6,@amremark7,@amremark8,@amtype)";
            return DBHelper.ExecuteNonQuery(GetSqlParameters(autonew_modelExample));
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="autonew_model">autonew_model表实例</param>
        /// <returns>int</returns>
        public int Update(autonew_model autonew_modelExample)
        {
            DBHelper.sqlstr = "update autonew_model set amname=@amname,amtitle=@amtitle,amjianshu=@amjianshu,amcode=@amcode,amcolor=@amcolor,amsize=@amsize,amnum=@amnum,amjiazeng=@amjiazeng,amyingdu=@amyingdu,amdaxiao=@amdaxiao,amtilin=@amtilin,amwaidai=@amwaidai,amneibu=@amneibu,amchanghe=@amchanghe,amliliao=@amliliao,amdakai=@amdakai,amtuan=@amtuan,amcaizhi=@amcaizhi,amwaixing=@amwaixing,amyuansu=@amyuansu,amfenlei=@amfenlei,amjiankucun=@amjiankucun,amchushou=@amchushou,amchicun=@amchicun,ammote=@ammote,amjingwu=@amjingwu,amxijie=@amxijie,amchanpin=@amchanpin,ampinpai=@ampinpai,ambaozhuang=@ambaozhuang,amfuwu=@amfuwu,amzizhi=@amzizhi,amdianpu=@amdianpu,amremark2=@amremark2,amremark1=@amremark1,amremark3=@amremark3,amremark4=@amremark4,amremark5=@amremark5,amremark6=@amremark6,amremark7=@amremark7,amremark8=@amremark8,amtype=@amtype where amid=" + autonew_modelExample.amid;
            return DBHelper.ExecuteNonQuery(GetSqlParameters(autonew_modelExample));
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="amid">编号</param>
        /// <returns>int</returns>
        public int Delete(int amid)
        {
            DBHelper.sqlstr = "delete autonew_model where amid =@amid";
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@amid",amid)
			};
            return DBHelper.ExecuteNonQuery(param);
        }
        #endregion


        #region search
        /// <summary>
        /// 高级查询 
        /// </summary>
        /// <param name="key">关键词，只查询模板名称和标题</param>
        /// <param name="atype">模板类型</param>
        /// <returns></returns>
        public autonew_model search(string key, string atype)
        {
            string sql1 = "select * from autonew_model  where ";
            string sql2 = string.IsNullOrEmpty(key) ? " 1=1 " : " (  amname  like '%" + key + "%'  or  amtitle  like '%" + key + "%'   ) ";
            string sql3 = string.IsNullOrEmpty(atype) ? " " : " and amtype= '" + atype + "'   ";
            string sql4 = " order by amid desc ";
            //string sql10 = searchnum == 0 ? " " : " limit " + startindex + "," + searchnum;
            DBHelper.sqlstr = sql1 + sql2 + sql3 + sql4;
            MySqlDataReader reader = DBHelper.ExecuteReader();
            autonew_model Obj = null;
            if (reader.Read())
            {
                Obj = GetByReader(reader);
            }
            reader.Close();
            return Obj;
        }
        #endregion




        #region 公共方法

        #region GetSqlParameters
        /// <summary>
        /// 根据表,获取一个MySqlParameter数组
        /// </summary>
        /// <returns>MySqlParameter[]</returns>
        public static MySqlParameter[] GetSqlParameters(autonew_model autonew_modelExample)
        {
            List<MySqlParameter> list_param = new List<MySqlParameter>();

            if (!string.IsNullOrEmpty(autonew_modelExample.amname))
            {
                list_param.Add(new MySqlParameter("@amname", autonew_modelExample.amname));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amname", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amtitle))
            {
                list_param.Add(new MySqlParameter("@amtitle", autonew_modelExample.amtitle));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amtitle", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amjianshu))
            {
                list_param.Add(new MySqlParameter("@amjianshu", autonew_modelExample.amjianshu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amjianshu", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amcode))
            {
                list_param.Add(new MySqlParameter("@amcode", autonew_modelExample.amcode));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amcode", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amcolor))
            {
                list_param.Add(new MySqlParameter("@amcolor", autonew_modelExample.amcolor));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amcolor", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amsize))
            {
                list_param.Add(new MySqlParameter("@amsize", autonew_modelExample.amsize));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amsize", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amnum))
            {
                list_param.Add(new MySqlParameter("@amnum", autonew_modelExample.amnum));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amnum", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amjiazeng))
            {
                list_param.Add(new MySqlParameter("@amjiazeng", autonew_modelExample.amjiazeng));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amjiazeng", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amyingdu))
            {
                list_param.Add(new MySqlParameter("@amyingdu", autonew_modelExample.amyingdu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amyingdu", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amdaxiao))
            {
                list_param.Add(new MySqlParameter("@amdaxiao", autonew_modelExample.amdaxiao));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amdaxiao", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amtilin))
            {
                list_param.Add(new MySqlParameter("@amtilin", autonew_modelExample.amtilin));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amtilin", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amwaidai))
            {
                list_param.Add(new MySqlParameter("@amwaidai", autonew_modelExample.amwaidai));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amwaidai", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amneibu))
            {
                list_param.Add(new MySqlParameter("@amneibu", autonew_modelExample.amneibu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amneibu", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amchanghe))
            {
                list_param.Add(new MySqlParameter("@amchanghe", autonew_modelExample.amchanghe));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amchanghe", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amliliao))
            {
                list_param.Add(new MySqlParameter("@amliliao", autonew_modelExample.amliliao));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amliliao", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amdakai))
            {
                list_param.Add(new MySqlParameter("@amdakai", autonew_modelExample.amdakai));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amdakai", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amtuan))
            {
                list_param.Add(new MySqlParameter("@amtuan", autonew_modelExample.amtuan));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amtuan", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amcaizhi))
            {
                list_param.Add(new MySqlParameter("@amcaizhi", autonew_modelExample.amcaizhi));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amcaizhi", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amwaixing))
            {
                list_param.Add(new MySqlParameter("@amwaixing", autonew_modelExample.amwaixing));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amwaixing", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amyuansu))
            {
                list_param.Add(new MySqlParameter("@amyuansu", autonew_modelExample.amyuansu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amyuansu", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amfenlei))
            {
                list_param.Add(new MySqlParameter("@amfenlei", autonew_modelExample.amfenlei));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amfenlei", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amjiankucun))
            {
                list_param.Add(new MySqlParameter("@amjiankucun", autonew_modelExample.amjiankucun));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amjiankucun", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amchushou))
            {
                list_param.Add(new MySqlParameter("@amchushou", autonew_modelExample.amchushou));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amchushou", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amchicun))
            {
                list_param.Add(new MySqlParameter("@amchicun", autonew_modelExample.amchicun));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amchicun", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.ammote))
            {
                list_param.Add(new MySqlParameter("@ammote", autonew_modelExample.ammote));
            }
            else
            {
                list_param.Add(new MySqlParameter("@ammote", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amjingwu))
            {
                list_param.Add(new MySqlParameter("@amjingwu", autonew_modelExample.amjingwu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amjingwu", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amxijie))
            {
                list_param.Add(new MySqlParameter("@amxijie", autonew_modelExample.amxijie));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amxijie", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amchanpin))
            {
                list_param.Add(new MySqlParameter("@amchanpin", autonew_modelExample.amchanpin));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amchanpin", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.ampinpai))
            {
                list_param.Add(new MySqlParameter("@ampinpai", autonew_modelExample.ampinpai));
            }
            else
            {
                list_param.Add(new MySqlParameter("@ampinpai", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.ambaozhuang))
            {
                list_param.Add(new MySqlParameter("@ambaozhuang", autonew_modelExample.ambaozhuang));
            }
            else
            {
                list_param.Add(new MySqlParameter("@ambaozhuang", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amfuwu))
            {
                list_param.Add(new MySqlParameter("@amfuwu", autonew_modelExample.amfuwu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amfuwu", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amzizhi))
            {
                list_param.Add(new MySqlParameter("@amzizhi", autonew_modelExample.amzizhi));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amzizhi", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amdianpu))
            {
                list_param.Add(new MySqlParameter("@amdianpu", autonew_modelExample.amdianpu));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amdianpu", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amremark2))
            {
                list_param.Add(new MySqlParameter("@amremark2", autonew_modelExample.amremark2));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amremark2", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amremark1))
            {
                list_param.Add(new MySqlParameter("@amremark1", autonew_modelExample.amremark1));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amremark1", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amremark3))
            {
                list_param.Add(new MySqlParameter("@amremark3", autonew_modelExample.amremark3));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amremark3", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amremark4))
            {
                list_param.Add(new MySqlParameter("@amremark4", autonew_modelExample.amremark4));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amremark4", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amremark5))
            {
                list_param.Add(new MySqlParameter("@amremark5", autonew_modelExample.amremark5));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amremark5", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amremark6))
            {
                list_param.Add(new MySqlParameter("@amremark6", autonew_modelExample.amremark6));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amremark6", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amremark7))
            {
                list_param.Add(new MySqlParameter("@amremark7", autonew_modelExample.amremark7));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amremark7", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amremark8))
            {
                list_param.Add(new MySqlParameter("@amremark8", autonew_modelExample.amremark8));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amremark8", DBNull.Value));
            }

            if (!string.IsNullOrEmpty(autonew_modelExample.amtype))
            {
                list_param.Add(new MySqlParameter("@amtype", autonew_modelExample.amtype));
            }
            else
            {
                list_param.Add(new MySqlParameter("@amtype", DBNull.Value));
            }
            MySqlParameter[] param = new MySqlParameter[list_param.Count];
            int index = 0;
            foreach (MySqlParameter p in list_param)
            {
                param[index] = p;
                index++;
            }
            return param;
        }
        #endregion

        #region GetByReader
        /// <summary>
        /// 从一个MySqlDataReader里读数据
        /// </summary>
        /// <param name="Reader">MySqlDataReader</param>
        /// <returns>autonew_modelExample</returns>
        public static autonew_model GetByReader(MySqlDataReader Reader)
        {
            autonew_model autonew_modelExample = new autonew_model();
            autonew_modelExample.amid = Reader["amid"] == DBNull.Value ? 0 : (int)Reader["amid"];
            autonew_modelExample.amname = Reader["amname"] == DBNull.Value ? null : Reader["amname"].ToString();
            autonew_modelExample.amtitle = Reader["amtitle"] == DBNull.Value ? null : Reader["amtitle"].ToString();
            autonew_modelExample.amjianshu = Reader["amjianshu"] == DBNull.Value ? null : Reader["amjianshu"].ToString();
            autonew_modelExample.amcode = Reader["amcode"] == DBNull.Value ? null : Reader["amcode"].ToString();
            autonew_modelExample.amcolor = Reader["amcolor"] == DBNull.Value ? null : Reader["amcolor"].ToString();
            autonew_modelExample.amsize = Reader["amsize"] == DBNull.Value ? null : Reader["amsize"].ToString();
            autonew_modelExample.amnum = Reader["amnum"] == DBNull.Value ? null : Reader["amnum"].ToString();
            autonew_modelExample.amjiazeng = Reader["amjiazeng"] == DBNull.Value ? null : Reader["amjiazeng"].ToString();
            autonew_modelExample.amyingdu = Reader["amyingdu"] == DBNull.Value ? null : Reader["amyingdu"].ToString();
            autonew_modelExample.amdaxiao = Reader["amdaxiao"] == DBNull.Value ? null : Reader["amdaxiao"].ToString();
            autonew_modelExample.amtilin = Reader["amtilin"] == DBNull.Value ? null : Reader["amtilin"].ToString();
            autonew_modelExample.amwaidai = Reader["amwaidai"] == DBNull.Value ? null : Reader["amwaidai"].ToString();
            autonew_modelExample.amneibu = Reader["amneibu"] == DBNull.Value ? null : Reader["amneibu"].ToString();
            autonew_modelExample.amchanghe = Reader["amchanghe"] == DBNull.Value ? null : Reader["amchanghe"].ToString();
            autonew_modelExample.amliliao = Reader["amliliao"] == DBNull.Value ? null : Reader["amliliao"].ToString();
            autonew_modelExample.amdakai = Reader["amdakai"] == DBNull.Value ? null : Reader["amdakai"].ToString();
            autonew_modelExample.amtuan = Reader["amtuan"] == DBNull.Value ? null : Reader["amtuan"].ToString();
            autonew_modelExample.amcaizhi = Reader["amcaizhi"] == DBNull.Value ? null : Reader["amcaizhi"].ToString();
            autonew_modelExample.amwaixing = Reader["amwaixing"] == DBNull.Value ? null : Reader["amwaixing"].ToString();
            autonew_modelExample.amyuansu = Reader["amyuansu"] == DBNull.Value ? null : Reader["amyuansu"].ToString();
            autonew_modelExample.amfenlei = Reader["amfenlei"] == DBNull.Value ? null : Reader["amfenlei"].ToString();
            autonew_modelExample.amjiankucun = Reader["amjiankucun"] == DBNull.Value ? null : Reader["amjiankucun"].ToString();
            autonew_modelExample.amchushou = Reader["amchushou"] == DBNull.Value ? null : Reader["amchushou"].ToString();
            autonew_modelExample.amchicun = Reader["amchicun"] == DBNull.Value ? null : Reader["amchicun"].ToString();
            autonew_modelExample.ammote = Reader["ammote"] == DBNull.Value ? null : Reader["ammote"].ToString();
            autonew_modelExample.amjingwu = Reader["amjingwu"] == DBNull.Value ? null : Reader["amjingwu"].ToString();
            autonew_modelExample.amxijie = Reader["amxijie"] == DBNull.Value ? null : Reader["amxijie"].ToString();
            autonew_modelExample.amchanpin = Reader["amchanpin"] == DBNull.Value ? null : Reader["amchanpin"].ToString();
            autonew_modelExample.ampinpai = Reader["ampinpai"] == DBNull.Value ? null : Reader["ampinpai"].ToString();
            autonew_modelExample.ambaozhuang = Reader["ambaozhuang"] == DBNull.Value ? null : Reader["ambaozhuang"].ToString();
            autonew_modelExample.amfuwu = Reader["amfuwu"] == DBNull.Value ? null : Reader["amfuwu"].ToString();
            autonew_modelExample.amzizhi = Reader["amzizhi"] == DBNull.Value ? null : Reader["amzizhi"].ToString();
            autonew_modelExample.amdianpu = Reader["amdianpu"] == DBNull.Value ? null : Reader["amdianpu"].ToString();
            autonew_modelExample.amremark2 = Reader["amremark2"] == DBNull.Value ? null : Reader["amremark2"].ToString();
            autonew_modelExample.amremark1 = Reader["amremark1"] == DBNull.Value ? null : Reader["amremark1"].ToString();
            autonew_modelExample.amremark3 = Reader["amremark3"] == DBNull.Value ? null : Reader["amremark3"].ToString();
            autonew_modelExample.amremark4 = Reader["amremark4"] == DBNull.Value ? null : Reader["amremark4"].ToString();
            autonew_modelExample.amremark5 = Reader["amremark5"] == DBNull.Value ? null : Reader["amremark5"].ToString();
            autonew_modelExample.amremark6 = Reader["amremark6"] == DBNull.Value ? null : Reader["amremark6"].ToString();
            autonew_modelExample.amremark7 = Reader["amremark7"] == DBNull.Value ? null : Reader["amremark7"].ToString();
            autonew_modelExample.amremark8 = Reader["amremark8"] == DBNull.Value ? null : Reader["amremark8"].ToString();
            autonew_modelExample.amtype = Reader["amtype"] == DBNull.Value ? null : Reader["amtype"].ToString();
            return autonew_modelExample;
        }
        #endregion





        #endregion
    }
    
   
   


	

}

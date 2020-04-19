using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Entity;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web;

namespace BLL
{
    /*BLL*/
    public class shuadanManager
    {
        /*
        //private static IshuadanService Service = Manager.factory.CreateshuadanService();

        //#region SearchAll
        ///// <summary>
        ///// 查询全部数据
        ///// </summary>
        ///// <returns>IList</returns>
        ///*查看是否为视图*/
        //public static IList<shuadan> SearchAll()
        //{
        //    return Service.SearchAll();
        //}
        //#endregion

        //#region SearchBysdid
        ///// <summary>
        ///// 根据sdid,查询一条数据
        ///// </summary>
        ///// <param name="sdid">编号</param>
        ///// <returns></returns>
        ///*查看是否为视图*/
        //public static shuadan SearchBysdid(int sdid)
        //{
        //    return Service.SearchBysdid(sdid);
        //}
        //#endregion

        //#region Insert
        ///// <summary>
        ///// 插入方法
        ///// </summary>
        ///// <param name="shuadan">shuadan表实例</param>
        ///// <returns>int</returns>
        //public static int Insert(shuadan shuadanExample)
        //{
        //    return Service.Insert(shuadanExample);
        //}
        //#endregion

        //#region Update
        ///// <summary>
        ///// 更新
        ///// </summary>
        ///// <param name="shuadan">shuadan表实例</param>
        ///// <returns>int</returns>
        //public static int Update(shuadan shuadanExample)
        //{
        //    return Service.Update(shuadanExample);
        //}
        //#endregion

        //#region Delete
        ///// <summary>
        ///// 删除
        ///// </summary>
        ///// <param name="sdid">编号</param>
        ///// <returns>int</returns>
        //public static int Delete(int sdid)
        //{
        //    return Service.Delete(sdid);
        //}
        //#endregion

        //#region SearchNum
        ///// <summary>
        ///// 根据条件查询全部数据总条数
        ///// </summary>
        ///// <param name="key">关键词</param>
        ///// <param name="gid">商品ID</param>
        ///// <param name="aid">账号ID</param>
        ///// <param name="state">刷单状态 1正常 2作废</param>
        ///// <param name="state_send">发货状态 1未发货 2已发货</param>
        ///// <param name="state_pingjia">评价状态 1未评价 2已评价</param>
        ///// <param name="date1">刷单时间</param>
        ///// <param name="date2">刷单时间</param>
        ///// <param name="date_send1">发货时间</param>
        ///// <param name="date_send2">发货时间</param>
        ///// <param name="date_pingjia1">评价时间</param>
        ///// <param name="date_pingjia2">评价时间</param>
        ///// <returns>int</returns>
        //public static int SearchNum(string key, int gid, int aid, string state, string state_send, string state_pingjia, DateTime date1, DateTime date2, DateTime date_send1, DateTime date_send2, DateTime date_pingjia1, DateTime date_pingjia2)
        //{
        //    return Service.SearchNum(key, gid, aid, state, state_send, state_pingjia, date1, date2, date_send1, date_send2, date_pingjia1, date_pingjia2);
        //}
        //#endregion


        //#region Search
        ///// <summary>
        ///// 根据条件查询全部数据
        ///// </summary>
        ///// <param name="s">起始位置</param>
        ///// <param name="e">结束位置</param>
        ///// <param name="key">关键词</param>
        ///// <param name="gid">商品ID</param>
        ///// <param name="aid">账号ID</param>
        ///// <param name="state">刷单状态 1正常 2作废</param>
        ///// <param name="state_send">发货状态 1未发货 2已发货</param>
        ///// <param name="state_pingjia">评价状态 1未评价 2已评价</param>
        ///// <param name="date1">刷单时间</param>
        ///// <param name="date2">刷单时间</param>
        ///// <param name="date_send1">发货时间</param>
        ///// <param name="date_send2">发货时间</param>
        ///// <param name="date_pingjia1">评价时间</param>
        ///// <param name="date_pingjia2">评价时间</param>
        ///// <param name="_top">查询数量</param>
        ///// <returns>IList<shuadan></returns>
        //public static IList<shuadan> Search(int s, int e, string key, int gid, int aid, string state, string state_send, string state_pingjia, DateTime date1, DateTime date2, DateTime date_send1, DateTime date_send2, DateTime date_pingjia1, DateTime date_pingjia2, string _top)
        //{
        //    return Service.Search(s, e, key, gid, aid, state, state_send, state_pingjia, date1, date2, date_send1, date_send2, date_pingjia1, date_pingjia2, _top);
        //}
        //#endregion



        //#region dynamic
        //public static void dynamic(int num, Page page)
        //{
        //    try
        //    {
        //        IList<Entity.address> list_address = BLL.addressManager.SearchRND(num.ToString());
        //        IList<Entity.shuadan_names> list_name = BLL.shuadan_namesManager.SearchRnd(num);
        //        List<Entity.shuadan> list = new List<Entity.shuadan>();
        //        for (int i = 0; i < num; i++)
        //        {
        //            Entity.shuadan sd = new Entity.shuadan();
        //            sd.sddate = DateTime.Now;
        //            sd.sdinfofrom = "1";
        //            sd.sdname = list_name[i].nname;
        //            sd.sdprovince = list_address[i].aProvince;
        //            sd.scity = list_address[i].aCity;
        //            sd.sdistrict = list_address[i].aDistrict;
        //            sd.sdaddress = list_address[i].aAddress;
        //            list.Add(sd);
        //        }



        //        /////Excel读取完毕,开始导入手机号码
        //        IList<Entity.shuadan_account> list_phone = BLL.shuadan_accountManager.SearchPhone(list.Count.ToString(), 7);
        //        int cishu = 0;
        //        foreach (Entity.shuadan temp_sd in list)
        //        {
        //            if (list_phone.Count > cishu + 1)
        //            {
        //                temp_sd.sdphone = list_phone[cishu].sdaccount;
        //                list_phone[cishu].sdastate_phone = (Convert.ToInt32(list_phone[cishu].sdastate_phone) + 1).ToString();
        //                BLL.shuadan_accountManager.Update(list_phone[cishu]);
        //                cishu++;
        //            }
        //            else
        //            {
        //                //AJAXManager.Alert(UpdatePanel1, "电话号码数量不够");
        //                Manager.Alert("电话号码数量不够", page);
        //                break;
        //            }
        //        }
        //        //手机号导入完毕,开始存储为txt文件
        //        string filename = DateTime.Now.ToString("yyyy年MM月dd日HHmmss") + Manager.RandomNumber(999, 99999).ToString() + ".txt";
        //        string filepath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "OA\\upload\\shuadan\\dynamic\\";
        //        if (!System.IO.Directory.Exists(filepath))
        //        {
        //            System.IO.Directory.CreateDirectory(filepath);
        //        }
        //        FileStream fs_write = new FileStream(filepath + filename, FileMode.Create, FileAccess.ReadWrite);
        //        StreamWriter strmWriter = new StreamWriter(fs_write, System.Text.Encoding.Default);
        //        //strmWriter.Write(dt.Columns[i].ColumnName + " ");
        //        //    strmWriter.WriteLine(); //换行
        //        foreach (shuadan sd_temp in list)
        //        {
        //            //插入刷单数据
        //            //BLL.shuadanManager.Insert(sd_temp);
        //            string str_write = sd_temp.sdname + "----" + sd_temp.sdphone + "----" + sd_temp.sdprovince + "----" + sd_temp.scity + "----" + sd_temp.sdistrict + "----" + sd_temp.sdaddress;
        //            strmWriter.Write(str_write);
        //            strmWriter.WriteLine(); //换行
        //        }
        //        strmWriter.Flush();
        //        strmWriter.Close();

        //        Entity.shuadan_record srr = new shuadan_record();
        //        srr.srcount = 1;
        //        srr.srdate = DateTime.Now;
        //        srr.srname = filename;
        //        srr.srnum = cishu.ToString();
        //        srr.srpath = "~/OA/upload/shuadan/dynamic/" + filename;
        //        srr.srremark = "";
        //        srr.srstate = "1";
        //        srr.srtype = "3";


        //        Manager.FileDownload("~/OA/upload/shuadan/dynamic/" + filename, filename, srr);


        //    }
        //    catch (Exception ex)
        //    {
        //        Manager.Alert(ex.ToString(), page);
        //    }
        //}
        //#endregion

        //#region import
        //public static void import(FileUpload FileUpload1, Page page)
        //{
        //    try
        //    {
        //        string _name = "";
        //        if (!FileUpload1.HasFile)
        //        {
        //            //AJAXManager.Alert(UpdatePanel1, "请选择文件");
        //            Manager.Alert("请选择文件", page);
        //            return;
        //        }
        //        else
        //        {
        //            string path = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "OA\\upload\\shuadan\\import\\";
        //            string[] strs = { ".csv" };
        //            if (!BLL.Manager.UpFile(FileUpload1, strs, path, ""))
        //            {
        //                //AJAXManager.Alert(UpdatePanel1, "文件上传错误");
        //                Manager.Alert("文件上传错误", page);
        //                return;
        //            }
        //            else
        //            {
        //                HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[Manager.decl_UploadFileName];
        //                _name = cookie.Value;

        //                FileStream fs = new FileStream(path + _name, FileMode.Open, FileAccess.Read, FileShare.None);
        //                StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding(936));
        //                List<Entity.shuadan> list = new List<Entity.shuadan>();
        //                string str = "";
        //                string s = Console.ReadLine();
        //                int j = 0;
        //                while (str != null)
        //                {
        //                    str = sr.ReadLine();
        //                    if (str == null)
        //                    {
        //                        break;
        //                    }
        //                    j++;
        //                    if (j == 1)
        //                        continue;
        //                    string[] xu = new String[2];
        //                    str = str.Replace("\"", "");
        //                    xu = str.Split(',');
        //                    if (xu[0] == "")
        //                    {
        //                        break;
        //                    }
        //                    Entity.shuadan sd = new Entity.shuadan();
        //                    sd.sddate = DateTime.Now;
        //                    sd.sdinfofrom = "2";
        //                    sd.sdkdcode = xu[21];
        //                    sd.sdkdname = xu[22];
        //                    sd.sdname = xu[12];
        //                    sd.sdordercode = xu[0];
        //                    try
        //                    {
        //                        string address = xu[13].Split('(')[0];
        //                        string[] arry = Regex.Split(address, "\\s+", RegexOptions.IgnoreCase);
        //                        int i = 0;
        //                        foreach (string temp in arry)
        //                        {
        //                            if (i == 0)
        //                            {
        //                                sd.sdprovince = temp;
        //                            }
        //                            else if (i == 1)
        //                            {
        //                                sd.scity = temp;
        //                            }
        //                            else if (i == 2)
        //                            {
        //                                sd.sdistrict = temp;
        //                            }
        //                            else
        //                            {
        //                                sd.sdaddress = sd.sdaddress + temp;
        //                            }
        //                            i++;
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Manager.Alert(ex.ToString(), page);
        //                    }
        //                    list.Add(sd);

        //                }
        //                sr.Close();
        //                /////Excel读取完毕,开始导入手机号码
        //                IList<Entity.shuadan_account> list_phone = BLL.shuadan_accountManager.SearchPhone(list.Count.ToString(), 7);
        //                int cishu = 0;
        //                foreach (Entity.shuadan temp_sd in list)
        //                {
        //                    if (list_phone.Count > cishu + 1)
        //                    {
        //                        temp_sd.sdphone = list_phone[cishu].sdaccount;
        //                        list_phone[cishu].sdastate_phone = (Convert.ToInt32(list_phone[cishu].sdastate_phone) + 1).ToString();
        //                        BLL.shuadan_accountManager.Update(list_phone[cishu]);
        //                        cishu++;
        //                    }
        //                    else
        //                    {
        //                        //AJAXManager.Alert(UpdatePanel1, "电话号码数量不够");
        //                        Manager.Alert("电话号码数量不够", page);
        //                        break;
        //                    }
        //                }
        //                //手机号导入完毕,开始存储为txt文件
        //                Random ran = new Random();
        //                string filename = DateTime.Now.ToString("yyyy年MM月dd日HHmmss") + ran.Next(999, 9999).ToString() + ".txt";
        //                string filepath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "OA\\upload\\shuadan\\import\\" + filename;
        //                FileStream fs_write = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
        //                StreamWriter strmWriter = new StreamWriter(fs_write, System.Text.Encoding.Default);
        //                //strmWriter.Write(dt.Columns[i].ColumnName + " ");
        //                //    strmWriter.WriteLine(); //换行
        //                foreach (shuadan sd_temp in list)
        //                {
        //                    //插入刷单数据
        //                    //BLL.shuadanManager.Insert(sd_temp);
        //                    string str_write = sd_temp.sdname + "----" + sd_temp.sdphone + "----" + sd_temp.sdprovince + "----" + sd_temp.scity + "----" + sd_temp.sdistrict + "----" + sd_temp.sdaddress;
        //                    strmWriter.Write(str_write);
        //                    strmWriter.WriteLine(); //换行
        //                }
        //                strmWriter.Flush();
        //                strmWriter.Close();


        //                Entity.shuadan_record srr = new shuadan_record();
        //                srr.srcount = 1;
        //                srr.srdate = DateTime.Now;
        //                srr.srname = filename;
        //                srr.srnum = cishu.ToString();
        //                srr.srpath = "~/OA/upload/shuadan/import/" + filename;
        //                srr.srremark = "";
        //                srr.srstate = "1";
        //                srr.srtype = "2";


        //                Manager.FileDownload("~/OA/upload/shuadan/import/" + filename, filename, srr);

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Manager.Alert(ex.ToString(), page);
        //    }
        //}
        //#endregion*/

        
    }

}

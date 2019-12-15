using System;
using System.Web.UI;
using System.IO;
using BLL;
using System.Web;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Entity;
using System.Web.UI.WebControls;


public partial class OA_sd_add_convert : WebPage
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            int count = BLL.shuadan_accountManager.SearchNum("", "0", "", new DateTime(), new DateTime());
            lbl_account.Text = count.ToString();
        }

    }




    #region btn_save_Click
    protected void btn_save_Click(object sender, EventArgs e)
    {
        //BLL.shuadanManager.convert_fahuo(FileUpload1, Page);
        //Manager.page_href_reload(Page);
        convert_fahuo(FileUpload1, Page);
    }
    #endregion


    #region convert_fahuo
    public static void convert_fahuo(FileUpload FileUpload1, Page page)
    {
        try
        {
            string _name = "";
            if (!FileUpload1.HasFile)
            {
                //AJAXManager.Alert(UpdatePanel1, "请选择文件");
                Manager.Alert("请选择文件", page);
                return;
            }
            else
            {
                string path = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "OA\\upload\\shuadan\\convert\\";
                string[] strs = { ".txt" };
                if (!BLL.Manager.UpFile(FileUpload1, strs, path, ""))
                {
                    //AJAXManager.Alert(UpdatePanel1, "文件上传错误");
                    Manager.Alert("文件上传错误", page);
                    return;
                }
                else
                {
                    HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[Manager.decl_UploadFileName];
                    _name = cookie.Value;
                    FileStream fs = new FileStream(path + _name, FileMode.Open, FileAccess.Read, FileShare.None);
                    StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
                    List<Entity.shuadan> list = new List<Entity.shuadan>();



                    string str = "";
                    string s = Console.ReadLine();
                    int j = 0;
                    while (str != null)
                    {
                        str = sr.ReadLine();
                        if (str == null)
                        {
                            break;
                        }
                        j++;
                        if (j == 1)
                            continue;
                        string[] xu = new String[2];
                        str = str.Replace("----", "-");
                        xu = str.Split('-');
                        if (xu[0] == "")
                        {
                            break;
                        }
                        Entity.shuadan sd = new Entity.shuadan();
                        sd.sddate = DateTime.Now;
                        sd.sdinfofrom = "4";
                        sd.sdname = xu[0];
                        sd.sdphone = xu[1];
                        sd.sdprovince = xu[2];
                        sd.scity = xu[3];
                        sd.sdistrict = xu[4];
                        sd.sdaddress = xu[5];
                        list.Add(sd);

                    }
                    sr.Close();
                    //手机号导入完毕,开始存储为txt文件
                    Random ran = new Random();
                    string filename = DateTime.Now.ToString("yyyy年MM月dd日HHmmss") + ran.Next(999, 9999).ToString() + ".txt";
                    string filepath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "OA\\upload\\shuadan\\convert\\" + filename;
                    FileStream fs_write = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite);
                    StreamWriter strmWriter = new StreamWriter(fs_write, System.Text.Encoding.Default);
                    //strmWriter.Write(dt.Columns[i].ColumnName + " ");
                    //    strmWriter.WriteLine(); //换行
                    foreach (shuadan sd_temp in list)
                    {
                        //插入刷单数据
                        //BLL.shuadanManager.Insert(sd_temp);
                        string str_write = sd_temp.sdname + "," + sd_temp.sdphone + "," + sd_temp.sdprovince + " " + sd_temp.scity + " " + sd_temp.sdistrict + " " + sd_temp.sdaddress + ",100000";
                        strmWriter.Write(str_write);
                        strmWriter.WriteLine(); //换行
                    }
                    strmWriter.Flush();
                    strmWriter.Close();


                    Entity.shuadan_record srr = new shuadan_record();
                    srr.srcount = 1;
                    srr.srdate = DateTime.Now;
                    srr.srname = filename;
                    srr.srnum = list.Count.ToString();
                    srr.srpath = "~/OA/upload/shuadan/convert/" + filename;
                    srr.srremark = "";
                    srr.srstate = "1";
                    srr.srtype = "5";


                    Manager.FileDownload("~/OA/upload/shuadan/convert/" + filename, filename, srr);

                }
            }
        }
        catch (Exception ex)
        {
            Manager.Alert(ex.ToString(), page);
        }
    }
    #endregion





}
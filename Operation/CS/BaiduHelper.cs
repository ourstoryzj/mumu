using Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Operation.CS
{
    /// <summary> 
    ///  Http操作类 
    /// </summary> 
    public class BaiduHelper
    {

        /// <summary>
        /// 根据图片地址
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static string ImageToWord(string imagePath)
        {
            string res = "";

            try
            {
                if (!File.Exists(imagePath))
                    return res;
                // 设置APPID/AK/SK
                //var APP_ID = "17767489";
                var API_KEY = "uq1WqDv14GMpouhgDRKblm6L";
                var SECRET_KEY = "xhGGclgNBKWMKVU0Uf8KZLo7N7RTwRwQ";

                //var client = new Baidu.Aip.ImageClassify.ImageClassify(API_KEY, SECRET_KEY);
                //client.Timeout = 60000;  // 修改超时时间


                var image = File.ReadAllBytes(imagePath);
                var client2 = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
                client2.Timeout = 60000;  // 修改超时时间

                var result = client2.GeneralBasic(image);        //本地图图片

                //Movie m = JsonConvert.DeserializeObject<Movie>(result);
                //string name = m.Name;
                Info info = JsonConvert.DeserializeObject<Info>(result.ToString());
                int num = info.words_result_num.ToInt();
                for (int i = 0; i < num; i++)
                {
                    res += info.words_result[i].words + "\r\n";
                }
            }
            catch (Exception ex)
            {
                ex.ToString().ToLog();
            }
            return res;
        }


        /// <summary>
        /// 根据内存粘贴板中的图片，识别文字
        /// 
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static string ImageToWordByClipboard()
        {
            string res = "";

            try
            {
                Bitmap bitmap = Manager.GetBitmapByClipboard();
                if (bitmap == null)
                {
                    "粘贴板中没有获取到图片".ToShow();
                    return res;

                }
                   
                // 设置APPID/AK/SK
                //var APP_ID = "17767489";
                var API_KEY = "uq1WqDv14GMpouhgDRKblm6L";
                var SECRET_KEY = "xhGGclgNBKWMKVU0Uf8KZLo7N7RTwRwQ";

                //var client = new Baidu.Aip.ImageClassify.ImageClassify(API_KEY, SECRET_KEY);
                //client.Timeout = 60000;  // 修改超时时间

                var image = Manager.BitmapToByte(bitmap);
                //var image = File.ReadAllBytes();
                var client2 = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
                client2.Timeout = 60000;  // 修改超时时间

                var result = client2.GeneralBasic(image);        //本地图图片

                //Movie m = JsonConvert.DeserializeObject<Movie>(result);
                //string name = m.Name;
                Info info = JsonConvert.DeserializeObject<Info>(result.ToString());
                int num = info.words_result_num.ToInt();
                for (int i = 0; i < num; i++)
                {
                    res += info.words_result[i].words + "\r\n";
                }
            }
            catch (Exception ex)
            {
                ex.ToString().ToLog();
            }
            return res;
        }



        /// <summary>
        /// 识别文件夹中的图片jpg,并保存
        /// </summary>
        /// <param name="folderPath"></param>
        public static void FolderToWord(string folderPath)
        {
            try
            {
                string res = "";
                foreach (string fls in Directory.GetFiles(folderPath))
                {
                    FileInfo flinfo = new FileInfo(fls);
                    if (flinfo.Extension.ToLower() == ".jpg" || flinfo.Extension.ToLower() == ".png")
                    {
                        res += ImageToWord(flinfo.FullName);
                    }
                }

                FileHelper.Write(folderPath + "\\文字识别.txt", res);
            }
            catch (Exception ex)
            {
                ex.ToString().ToLog();
            }
        }



        /// <summary>
        /// 根据图片地址
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static string test()
        {
            string res = "";

            string temp = "{'log_id':123321123321,'words_result_num':2,'words_result':[{'words':'豪礼'},{'words':'品牌'}]}";

            try
            {
                 
                
                Info info = JsonConvert.DeserializeObject<Info>(temp);
                int num = info.words_result_num.ToInt();
                for (int i = 0; i < num; i++)
                {
                    res += info.words_result[i].words + "\r\n";
                }
            }
            catch (Exception ex)
            {
                ex.ToString().ToLog();
            }
            return res;
        }

    }

    /// <summary>
    /// 百度识图返回数据
    /// </summary>
    public class Info
    {
        public string log_id { get; set; }
        public string words_result_num { get; set; }
        public List<words_result> words_result { get; set; }
    }

    /// <summary>
    /// 最终数据
    /// </summary>
    public class words_result
    {
        public string words { get; set; }
    }



    #region 返回数据
    /*
             {
          "log_id": 2571258640803562766,
          "words_result_num": 17,
          "words_result": [
            {
              "words": "现在下单享5重豪礼"
            },
            {
              "words": "豪礼"
            },
            {
              "words": "国际品牌品质保障(保"
            },
            {
              "words": "品牌促销,豪礼享不停"
            },
            {
              "words": "今日活动"
            },
            {
              "words": "领券立减10元"
            },
            {
              "words": "精准称重"
            },
            {
              "words": "03)感知身体每一处变化"
            },
            {
              "words": "品牌促销"
            },
            {
              "words": "享90天免费试用"
            },
            {
              "words": "试"
            },
            {
              "words": "90天内无理由退换货(官方7天)"
            },
            {
              "words": "豪礼"
            },
            {
              "words": "05"
            },
            {
              "words": "终身保修一年只换不修"
            },
            {
              "words": "换"
            },
            {
              "words": "365天内坏了不用修,直接换新机"
            }
          ]
        }
     */
    #endregion


}
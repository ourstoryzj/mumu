using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;

namespace Operation
{
    public partial class test2 : Form
    {

        private List<Product> proList = new List<Product>();
        public test2()
        {
            InitializeComponent();
            //this.dgResult.Columns["StartTime"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
            //this.dgResult.Columns["EndTime"].DefaultCellStyle.Format = "yyyy-MM-dd hh:mm:ss";
        }

        /// <summary>  
        /// 将Unix时间戳转换为DateTime类型时间(Unix时间戳指是从1970年1月1日（UTC/GMT的午夜）开始所经过的秒数)  
        /// </summary>  
        /// <param name="d">double 型数字</param>  
        /// <returns>DateTime</returns>  
        public System.DateTime UnixToDateTime(long d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }
        /// <summary>  
        /// 提取字符串里面的Unix时间戳  
        /// </summary>  
        /// <param name="input"></param>  
        /// <param name="pattern"></param>  
        /// <returns></returns>  
        private long GetUnixTick(string input, string pattern)
        {
            long result = 0;
            Regex rx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection mc = rx.Matches(input);
            string value = mc[0].Value;
            Int64.TryParse(value, out result);
            if (result > 0)//1401119998000需要去除三个0  
                result = result / 1000;
            return result;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text.Trim();
            string[] arrUrl = Regex.Split(input, "\\s+");
            foreach (string url in arrUrl)
            {
                string html = GetHtmlSource(url, Encoding.GetEncoding("GBK"));
                if (string.IsNullOrEmpty(html))
                    continue;

                HtmlNode rootNode = null;
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.LoadHtml(html);
                rootNode = document.DocumentNode;

                string unixStr = GetNodeAttr(rootNode, "//button[@id='J_listBuyerOnView']");
                if (string.IsNullOrEmpty(unixStr))
                    continue;

                //上架时间  
                long unixTickStart = GetUnixTick(unixStr, "(?<=starts=)(.*?)(?=&item_id)");
                DateTime dtStart = UnixToDateTime(unixTickStart);
                //下架时间  
                long unixTickEnd = GetUnixTick(unixStr, "(?<=ends=)(.*?)(?=&starts)");
                DateTime dtEnd = UnixToDateTime(unixTickEnd);
                //标题  
                string title = GetNodeText(rootNode, "//title");
                //价格  
                decimal price = 0;
                string priceTmp = GetNodeText(rootNode, "//em[@class='tb-rmb-num']");
                decimal.TryParse(priceTmp, out price);

                proList.Add(new Product()
                {
                    Url = url,
                    Title = title,
                    Price = price,
                    StartTime = dtStart,
                    EndTime = dtEnd
                });
            }
            if (proList.Count == 0)
            {
                MessageBox.Show("没有找到符合条件的数据，输入网址是否正确？");
                return;
            }

            var bindingList = new BindingList<Product>(proList);
            var source = new BindingSource(bindingList, null);
            dgResult.DataSource = source;
        }


        private string GetNodeAttr(HtmlNode rootNode, string path)
        {
            HtmlNode temp = rootNode.SelectSingleNode(path);
            if (temp != null)
                return temp.Attributes["data-api"].Value;
            return "";
        }
        private string GetNodeText(HtmlNode rootNode, string path)
        {
            HtmlNode temp = rootNode.SelectSingleNode(path);
            if (temp != null)
                return temp.InnerText;
            return "";
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {
            proList.Clear();
            var bindingList = new BindingList<Product>(proList);
            var source = new BindingSource(bindingList, null);
            dgResult.DataSource = source;
        }




        /// <summary>
        /// 获取网页HTML源码
        /// </summary>
        /// <param name="url">链接 eg:http://www.baidu.com/ </param>
        /// <param name="charset">编码 eg:Encoding.UTF8</param>
        /// <returns>HTML源码</returns>
        public static string GetHtmlSource(string url, Encoding charset)
        {

            string _html = string.Empty;
            try
            {
                HttpWebRequest _request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse _response = (HttpWebResponse)_request.GetResponse();
                using (Stream _stream = _response.GetResponseStream())
                {
                    using (StreamReader _reader = new StreamReader(_stream, charset))
                    {
                        _html = _reader.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                using (StreamReader sr = new StreamReader(ex.Response.GetResponseStream()))
                {
                    _html = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                _html = ex.Message;
            }
            return _html;

        }





    }



    public class Product
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }


}





using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Operation.CefsharpHelpers;

namespace Operation.Other
{
    public partial class BaoNiuNiu2 : Form
    {

        CefsharpHelper chrome = null;

        public BaoNiuNiu2()
        {
            InitializeComponent();
            bind();

        }

        void bind()
        {
            string url = "http://bao66.51daifa.com/seller/order_list";
            chrome = new CefsharpHelper(url);
            chrome.Init();
            var browser = chrome.CreateBrowser();
            panel1.Controls.Add(browser);
            panel1.Update();
            //设置cookie
            string host = "bao66.51daifa.com";
            string name = "_ati";
            string cookie = "8539990153597; user_user_id=2028657; user_login_ip=183.197.0.132; user_username=ourstoryzj; user_type=0; user_is_user_login=1; user_login_type=web; daily_login=1; user_login_time=2020-06-12+10%3A52%3A28; user_hash=d8b994af789fc806519e67348d8df738; k3cn=dXNlcl9pZD0yMDI4NjU3JnR5cGU9MCZ1c2VybmFtZT1vdXJzdG9yeXpqJnQ9MTU5MTkzMDM0OCZoYXNoPTg3ZDNjZTk5NjVkMDBiMWFlNTQzZTM4M2ZmMWFjMDhm; dcjq-accordion=1%2C2; session=a%3A5%3A%7Bs%3A10%3A%22session_id%22%3Bs%3A32%3A%22dd176639c6e7bf3f34388196d214d719%22%3Bs%3A10%3A%22ip_address%22%3Bs%3A13%3A%22183.197.0.132%22%3Bs%3A10%3A%22user_agent%22%3Bs%3A110%3A%22Mozilla%2F5.0+%28Windows+NT+10.0%3B+WOW64%29+AppleWebKit%2F537.36+%28KHTML%2C+like+Gecko%29+Chrome%2F78.0.3904.108+Safari%2F537.36%22%3Bs%3A13%3A%22last_activity%22%3Bi%3A1591933147%3Bs%3A9%3A%22user_data%22%3Bs%3A0%3A%22%22%3B%7D0ec541a76f4c0eb016c73a4e4246bb4ff482baa6";
            chrome.SetCookies(host, name, cookie);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}

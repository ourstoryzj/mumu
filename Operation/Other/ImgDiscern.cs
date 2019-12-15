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
using System.IO;

namespace excel_operation
{
    public partial class ImgDiscern : Form
    {
        public ImgDiscern()
        {
            InitializeComponent();




        }

        public void AdvancedGeneralDemo(string filepath)
        {
            // 设置APPID/AK/SK
            var APP_ID = "17767489";
            var API_KEY = "uq1WqDv14GMpouhgDRKblm6L";
            var SECRET_KEY = "xhGGclgNBKWMKVU0Uf8KZLo7N7RTwRwQ";

            var client = new Baidu.Aip.ImageClassify.ImageClassify(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间


            var image = File.ReadAllBytes(filepath);
            var client2 = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY);
            client.Timeout = 60000;  // 修改超时时间

            var result = client2.GeneralBasic(image);        //本地图图片


            //var image = File.ReadAllBytes(filepath);
            //// 调用通用物体识别，可能会抛出网络等异常，请使用try/catch捕获
            //var result = client.AdvancedGeneral(image);
            //Console.WriteLine(result);
            //// 如果有可选参数
            //var options = new Dictionary<string, object>{
            //    {"baike_num", 5}
            //};
            //// 带参数调用通用物体识别
            //result = client.AdvancedGeneral(image, options);
            //Console.WriteLine(result);
            textBox2.Text = result.ToString();
            //result.ToString().ToShow();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///AdvancedGeneralDemo(textBox1.Text);
            ///
            ///
            textBox2.Text = CS.BaiduHelper.test();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CS.BaiduHelper.FolderToWord(textBox1.Text);
            "操作成功".ToShow();
        }
    }
}

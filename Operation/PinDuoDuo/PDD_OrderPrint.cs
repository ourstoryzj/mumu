using System.Collections.Generic;
using System.Windows.Forms;
using Entity;
using CefSharp.WinForms;
using System.Drawing;
using System;
using Operation.CS;
using System.IO;
using System.Diagnostics;
using Common;
using System.Net;
using CefSharp;
using Operation.CefsharpHelpers;

namespace Operation.Other
{


    public partial class PDD_OrderPrint : Form
    {


        private CefsharpHelper chrome = null;

        /// <summary>
        /// 统一等待时间
        /// </summary>
        int waittime = 1000;

        /// <summary>
        /// input的样式名称
        /// </summary>
        string classname1 = "IPT_input_4-62-1";

        /// <summary>
        /// 下拉列表的样式名称
        /// </summary>
        string classname2 = "ST_dropdownPanel_4-62-1";


        public PDD_OrderPrint()
        {
            InitializeComponent();
        
        }



        #region bind



        void bind_chrome()
        {


            if (chrome == null)
            {
                chrome = new CefsharpHelper("th://empty");

                chrome.Init("", true);

                chrome.CreateBrowser();
                //this.Invoke(new Action<Panel>(p =>
                //{
                //    p.Controls.Add(browser);
                //    p.Update();
                //}), this.panel1);

                panel1.Controls.Add(chrome.browser);
                panel1.Update();
            }
            else
            {
                panel1.Controls.Add(chrome.browser);
                panel1.Update();
            }


        }




        #endregion


        #region wait
        void wait()
        {
            Manager.Delay(waittime);
        }
        #endregion


        /// <summary>
        /// 点击输入框的方法
        /// </summary>
        /// <param name="index"></param>
        void ClickInput(int index)
        {
            chrome.JS_CEFBrowser("document.getElementsByClassName('"+ classname1 + "')["+ index + "].click()");
        }

        /// <summary>
        /// 点击下拉列表
        /// </summary>
        /// <param name="index"></param>
        void ClickDropdown(int index)
        {
            chrome.JS_CEFBrowser("document.getElementsByClassName('" + classname2 + "')[0].getElementsByTagName('li')[" + index + "].click()");
        }




        private void btn_01_Click(object sender, EventArgs e)
        {
            //点击商品名称
            ClickInput(0);

            //等待
            wait();
            //选择豆腐丝选项

            //等待
            wait();
            //点击规格

            //等待
            wait();
            //选择一斤两斤的

            // 等待
            wait();
            //点击省份

            //等待
            wait();
            //选择省份


            //等待
            wait();
            //点击数量

            //等待
            wait();
            //选择数量为1

            //点击仅显示合并订单

            //提示操作完成



        }
    }


}

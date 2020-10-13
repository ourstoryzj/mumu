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
        int waittime = 1500;

        /// <summary>
        /// input的样式名称
        /// 00 商品名称
        /// 01 规格
        /// 02 快递公司
        /// 03 订单编号
        /// 04 快递单号
        /// 05 商品数量
        /// 06 售后状态
        /// 07 省份
        /// 08 剩余时间
        /// 09 商品简称
        /// 10 sku编码
        /// 11 订单支付时间
        /// 12 选择快递模板
        /// 13 排序方式
        /// 14 每页条数
        /// </summary>
        string classname_input = "IPT_input_4-62-1";

        /// <summary>
        /// 下拉列表的样式名称
        /// </summary>
        //string classname_dropdown = "ST_dropdownPanel_4-62-1";
        string classname_dropdown = "ST_dropdown_4-62-1";

        /// <summary>
        /// 列表上面的选择多选框
        /// 00 合并打印
        /// 01 仅展示可合并订单
        /// 02 仅展示有备注订单
        /// 03 仅展示加运费发顺丰订单
        /// 04 仅展示锁定订单
        /// 05 仅展示催发货订单
        /// CBX_input_4-62-1
        /// CBX_textWrapper_4-62-1
        /// </summary>
        string classname_check = "CBX_input_4-62-1";

        /// <summary>
        /// 按钮
        /// 00 查询
        /// 01 重置
        /// 02 打印快递单
        /// 03 打印发货单
        /// 04 发货
        /// 05 拆单
        /// </summary>
        string classname_button = "BTN_medium_4-62-1";



        public PDD_OrderPrint()
        {
            InitializeComponent();
            bind_chrome();
            ToPrintPage();
        }

        #region bind



        void bind_chrome()
        {


            if (chrome == null)
            {
                chrome = new CefsharpHelper("th://empty");

                chrome.Init("");

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

        #region ToPrintPage 打开打印页面
        /// <summary>
        /// 打开打印页面
        /// </summary>
        void ToPrintPage()
        {
            chrome.JumpUrl("https://mms.pinduoduo.com/print/order/list");
        }
        #endregion

        #region ClickInput 点击输入框的方法
        /// <summary>
        /// 点击输入框的方法
        /// 00 商品名称
        /// 01 规格
        /// 02 快递公司
        /// 03 订单编号
        /// 04 快递单号
        /// 05 商品数量
        /// 06 售后状态
        /// 07 省份
        /// 08 剩余时间
        /// 09 商品简称
        /// 10 sku编码
        /// 11 订单支付时间
        /// 12 选择快递模板
        /// 13 排序方式
        /// 14 每页条数
        /// </summary>
        /// <param name="index"></param>
        void ClickInput(int index)
        {
            chrome.JS_CEFBrowser("document.getElementsByClassName('" + classname_input + "')[" + index + "].click()");
        }
        #endregion

        #region ClickDropdown 点击下拉列表
        /// <summary>
        /// 点击下拉列表
        /// </summary>
        /// <param name="index"></param>
        void ClickDropdown(int index)
        {
            chrome.JS_CEFBrowser("document.getElementsByClassName('" + classname_dropdown + "')[0].getElementsByTagName('li')[" + index + "].click()");
        }
        #endregion

        #region ClickCheck 列表上面的选择多选框
        /// <summary>
        /// 列表上面的选择多选框
        /// 00 合并打印
        /// 01 仅展示可合并订单
        /// 02 仅展示有备注订单
        /// 03 仅展示加运费发顺丰订单
        /// 04 仅展示锁定订单
        /// 05 仅展示催发货订单
        /// </summary>
        /// <param name="index"></param>
        void ClickCheck(int index)
        {
            chrome.JS_CEFBrowser("document.getElementsByClassName('" + classname_check + "')[" + index + "].click()");
        }
        #endregion

        #region ClickButton 点击按钮
        /// <summary>
        /// 点击按钮
        /// 00 查询
        /// 01 重置
        /// 02 打印快递单
        /// 03 打印发货单
        /// 04 发货
        /// 05 拆单
        /// </summary>
        /// <param name="index"></param>
        void ClickButton(int index)
        {
            chrome.JS_CEFBrowser("document.getElementsByClassName('" + classname_button + "')[" + index + "].click()");
        }
        #endregion

        #region ResetCheck 多选重置
        /// <summary>
        /// 多选重置
        /// </summary>
        void ResetCheck()
        {
            for (int i = 1; i < 5; i++)
            {
                string res = chrome.JS_CEFBrowser("if(document.getElementsByClassName('" + classname_check + "')[" + i + "].checked==true){document.getElementsByClassName('" + classname_check + "')[" + i + "].click();}");
            }

        }
        #endregion

        #region ResetAll
        /// <summary>
        /// 重置所有数据
        /// </summary>
        void ResetAll()
        {
            ResetCheck();
            ClickButton(1);
            wait();
            wait();
            wait();
            chrome.browser.ToWait();
        }

        #endregion


        #region DropdownSetScroll
        /// <summary>
        /// 设置下拉菜单的滚动条位置 一般都是加150
        /// </summary>
        /// <param name="num"></param>
        void DropdownSetScroll(int num)
        {
            chrome.JS_CEFBrowser("document.getElementsByClassName('" + classname_dropdown + "')[0].getElementsByTagName('ul')[0].getElementsByTagName('div')[0].scrollTop =" + num);
        }


        void DropdownSetScroll_Sheng(int num)
        {
            chrome.JS_CEFBrowser("document.getElementsByClassName('" + classname_dropdown + "')[0].getElementsByTagName('ul')[0].scrollTop =" + num);
        }

        #endregion




        void DropdownCheck(string str)
        {

            //循环5次,每次加150
            int len = 150;
            for (int i = 0; i < 5; i++)
            {

                DropdownSetScroll(i * len);
                DropdownSetScroll_Sheng(i * len);
                wait();
                //获取li的数量
                int licount = chrome.JS_CEFBrowserToInt("document.getElementsByClassName('" + classname_dropdown + "')[0].getElementsByTagName('li').length");

                //循环li
                for (int j = 0; j < licount; j++)
                {
                    //判断每个li的文字中是否有制定文字
                    string temp = chrome.JS_CEFBrowser("document.getElementsByClassName('" + classname_dropdown + "')[0].getElementsByTagName('li')[" + j + "].innerText");
                    //如果有
                    if (temp.IndexOf(str) > -1)
                    {
                        //则判断是否已经被选中
                        if (!chrome.JS_CEFBrowserToBool("document.getElementsByClassName('" + classname_dropdown + "')[0].getElementsByClassName('" + classname_check + "')[" + j + "].checked==true"))
                        {
                            //如果没有选中则选中
                            ClickDropdown(j);
                        }

                    }
                }
            }

            chrome.MouseLeftByHtmlElement("document.getElementsByClassName('Grid_row_4-62-1')[0].getElementsByTagName('label')[0]", true);


        }




        /// <summary>147
        /// 打印备注订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_01_Click(object sender, EventArgs e)
        {
            ResetAll();
            ClickCheck(2);
            "操作成功".ToShow();

            #region MyRegion
            ////点击商品名称
            //ClickInput(0);

            ////等待
            //wait();
            ////选择豆腐丝选项

            ////等待
            //wait();
            ////点击规格

            ////等待
            //wait();
            ////选择一斤两斤的

            //// 等待
            //wait();
            ////点击省份

            ////等待
            //wait();
            ////选择省份


            ////等待
            //wait();
            ////点击数量

            ////等待
            //wait();
            ////选择数量为1

            ////点击仅显示合并订单

            ////提示操作完成 
            #endregion

        }

        #region btn_open_Click
        /// <summary>
        /// 打开页面
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_open_Click(object sender, EventArgs e)
        {
            ToPrintPage();
        }

        #endregion


        private void btn_02_Click(object sender, EventArgs e)
        {
            ResetAll();
            ClickCheck(1);
            "操作成功".ToShow();
        }


        private void btn_03_Click(object sender, EventArgs e)
        {
            ResetAll();
            ClickInput(5);
            wait();
            ClickDropdown(1);
            wait();
            ClickButton(0);
            "操作成功".ToShow();

        }

        private void btn_04_Click(object sender, EventArgs e)
        {
            ResetAll();
            //点击商品名称
            ClickInput(0);
            wait();
            //wait();
            //点击豆腐丝
            ClickDropdown(0);
            wait();
            //wait();

            //规格中输入2斤
            //WriteInput(1, "2斤");
            //wait();
            //ClickDropdown(0);
            //wait();
            //WriteInput(1, "2斤");
            //wait();
            //ClickDropdown(1);
            //wait();
            //WriteInput(1, "2斤");
            //wait();
            //ClickDropdown(2);
            //wait();


            ClickInput(1);
            wait();
            //wait();
            DropdownCheck("2斤");


            ClickButton(0);
            "操作成功".ToShow();
        }


        /// <summary>
        /// 鼠标点击输入框
        /// </summary>
        /// <param name="index"></param>
        void MouseClick_Input(int index)
        {
            this.Focus();

            chrome.MouseLeftByHtmlElement("document.getElementsByClassName('" + classname_input + "')[" + index + "]", 100, 10);
        }


        /// <summary>
        /// 在输入框中输入
        /// </summary>
        /// <param name="index"></param>
        /// <param name="str"></param>
        void WriteInput(int index, string str)
        {
            MouseClick_Input(index);
            wait();
            Auto.Ctrl_V(str);
            wait();
        }

        private void btn_05_Click(object sender, EventArgs e)
        {
            ResetAll();
            //点击商品名称
            ClickInput(0);
            wait();
            //点击豆腐丝
            ClickDropdown(0);
            wait();


            //规格中输入1斤
            //WriteInput(1, "1斤");
            //wait();
            //ClickDropdown(0);
            //wait();
            //WriteInput(1, "1斤");
            //wait();
            //ClickDropdown(1);
            //wait();

            //WriteInput(7, "北京");
            //wait();
            //ClickDropdown(0);
            //wait();

            //WriteInput(7, "贵州");
            //wait();
            //ClickDropdown(0);
            //wait();

            ClickInput(1);
            wait();
            //wait();
            DropdownCheck("1斤");

            ClickInput(7);
            wait();
            //wait();
            DropdownCheck("贵州");
            ClickInput(7);
            wait();
            DropdownCheck("北京");


            ClickButton(0);
            "操作成功".ToShow();

        }

        private void btn_06_Click(object sender, EventArgs e)
        {
            ResetAll();
            ClickButton(0);
            "操作成功".ToShow();
        }

        private void btn_other_Click(object sender, EventArgs e)
        {
            chrome.JumpUrl("https://mms.pinduoduo.com/print/manual-order");
        }

        private void btn_zhang_Click(object sender, EventArgs e)
        {
            chrome.JumpUrl("https://mms.pinduoduo.com/home/");
            chrome.WaitWebPageLoad("document.getElementsByClassName('BTN_outerWrapper_4-85-0')[1]");
            wait();
            chrome.JS_CEFBrowser("document.getElementsByClassName('BTN_outerWrapper_4-85-0')[1].click()");
            wait();
            string daidaozhang = chrome.JS_CEFBrowser("document.getElementsByClassName('dotted')[0].innerText");
            daidaozhang = daidaozhang.Replace("待到账¥", "");

            chrome.JumpUrl("https://mms.pinduoduo.com/finance/balance?q=1");
            chrome.WaitWebPageLoad("document.getElementsByClassName('balance-overview-new-content-main-amount')[0]");
            wait();
            wait();
            string huokuanjine = chrome.JS_CEFBrowser("document.getElementsByClassName('balance-overview-new-content-main-amount')[0].innerText");


            chrome.JumpUrl("https://mms.pinduoduo.com/logistics/account");
            chrome.WaitWebPageLoad("getElementsByInnerText_NoChildren('+展开')[1]");
            wait();
            wait();
            chrome.JS_CEFBrowser("getElementsByInnerText_NoChildren('+展开')[1].click()");
            wait();
            string jitucount = chrome.JS_CEFBrowser("document.getElementsByClassName('TB_cellTextAlignLeft_4-76-0')[12].innerText");


            //chrome.JumpUrl("https://mms.pinduoduo.com/logistics/account");
            chrome.WaitWebPageLoad("getElementsByInnerText_NoChildren('+展开')[1]");
            wait();
            wait();
            chrome.JS_CEFBrowser("getElementsByInnerText_NoChildren('+展开')[1].click()");
            wait();
            string zhongtongcount = chrome.JS_CEFBrowser("document.getElementsByClassName('TB_cellTextAlignLeft_4-76-0')[12].innerText");

            txt_info.Text = "未收回:\r\n";
            txt_info.Text += daidaozhang+"\r\n";
            txt_info.Text += "待提现:\r\n";
            txt_info.Text += huokuanjine + "\r\n";
            txt_info.Text += "极兔面单:\r\n";
            txt_info.Text += jitucount + "\r\n";
            txt_info.Text += "中通面单:\r\n";
            txt_info.Text += zhongtongcount + "\r\n";

        }
    }


}

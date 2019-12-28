using System;
using System.Windows.Forms;
using Operation.CS;

namespace Operation.DataAnalysis
{
    public partial class CanMou_KeysHelper : Form
    {
        public CanMou_KeysHelper()
        {
            Login_TaoBao tb = new Login_TaoBao();
            tb.Show();
            if (Taobao.WaitTaoBaoLogin(tb))
            {
                tb.Hide();
                InitializeComponent();
                this.StartPosition = FormStartPosition.CenterScreen;
                Browser.GetWebBrowser(tb.webBrowser1, webBrowser1);
                tb.Close();
                tb.Dispose();


            }
        }


        #region btn_hangyelidu_Click
        private void btn_hangyelidu_Click(object sender, EventArgs e)
        {
            //设置鼠标原始位置
            Manager.MousePoint = Control.MousePosition;

            //卖家中心
            webBrowser1.Navigate("https://myseller.taobao.com/seller_admin.htm");
            if (Browser.WaitWebPageLoad("getElementsByDataSpm('d58')[0]", webBrowser1))
            {
                //在卖家中心找到生意参谋
                string temp_url = Browser.GetTBUrlByElement_A("getElementsByDataSpm('d58')[0]", webBrowser1);
                if (!string.IsNullOrEmpty(temp_url))
                {
                    webBrowser1.Navigate(temp_url);
                    if (Browser.WaitWebPageLoad("getElementsByDataSpm('d18')[0]", webBrowser1))
                    {
                        //要删除的
                        //<div id="oui-dialog-mask" style="visibility: visible; z-index: 1100;"></div>屏障
                        //J_advice2visual
                        // classname=dialog-show  提示窗口
                        //Manager.JS_WebBrowser_RemoveElement(" getClassName('dialog-show')[0]", webBrowser1);
                        //Manager.JS_WebBrowser_RemoveElement(" document.getElementById('J_advice2visual')", webBrowser1);
                        //Manager.JS_WebBrowser_RemoveElement(" document.getElementById('oui-dialog-mask')", webBrowser1);
                        //关闭提示窗口dialog-show
                        Browser.MouseLeftByHtmlElement(" getClassName('dialog-show')[0].getElementsByTagName('i')[0] ", webBrowser1);


                        temp_url = Browser.GetTBUrlByElement_A("getElementsByDataSpm('d18')[0]", webBrowser1);
                        if (!string.IsNullOrEmpty(temp_url))
                        {
                            webBrowser1.Navigate(temp_url);
                            if (Browser.WaitWebPageLoad("getElementsByDataSpm('d342')[0]", webBrowser1))
                            {
                                Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d342')[0]", webBrowser1);
                                Browser.MouseLeftByHtmlElement("getElementsByDataSpm('d343')[0]", webBrowser1);
                                //Manager.GetTBMouseDown("getElementsByDataSpm('d342')[0]", webBrowser1);
                                //Manager.GetTBMouseDown("getElementsByDataSpm('d342')[0]", webBrowser1);
                                //Manager.GetTBMouseDown("getElementsByDataSpm('d343')[0]", webBrowser1);
                                //Manager.GetTBMouseDown("getElementsByDataSpm('d342')[0]", webBrowser1);
                                //Manager.GetTBMouseDown("getElementsByDataSpm('d342')[0]", webBrowser1);
                            }

                        }



                    }
                }



            }
        }
        #endregion



        private void btn_test_Click(object sender, EventArgs e)
        {
            string temp = textBox1.Text.Trim();
            Browser.JS_WebBrowser(temp, webBrowser1);
        }



        #region btn_testmouse_Click
        private void btn_testmouse_Click(object sender, EventArgs e)
        {
            //设置鼠标原始位置
            Manager.MousePoint = Control.MousePosition;

            if (Browser.WaitWebPageLoad(webBrowser1))
            {
                //Debug.WriteLine(Manager.JS_WebBrowser("getAbsoluteOffsetTop( document.getElementById('forget-pw-safe') )", webBrowser1));
                //Debug.WriteLine(Manager.JS_WebBrowser("getAbsoluteOffsetLeft( document.getElementById('forget-pw-safe') )", webBrowser1));
                Browser.JS_WebBrowser_NoReturn("removeElement( document.getElementById('forget-pw-safe') )", webBrowser1);
                //Manager.JS_WebBrowser("getAbsoluteOffsetLeft( document.getElementById('forget-pw-safe') )", webBrowser1);
            }



        }
        #endregion



    }
}

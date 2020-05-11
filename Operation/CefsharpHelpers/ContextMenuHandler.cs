using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.CefsharpHelpers
{
    class ContextMenuHandler: IContextMenuHandler
    {

         

        void IContextMenuHandler.OnBeforeContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            
        }

        bool IContextMenuHandler.OnContextMenuCommand(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return true;
        }

        void IContextMenuHandler.OnContextMenuDismissed(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame)
        {
            //隐藏菜单栏
            var webbrowser = (ChromiumWebBrowser)chromiumWebBrowser;
            webbrowser.Invoke(new Action(()=> {
                webbrowser.ContextMenu = null;
            }));
           
        }

 
        bool IContextMenuHandler.RunContextMenu(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            //绘制了一遍菜单栏  所以初始化的时候不必绘制菜单栏，再此处绘制即可
            var WebBrowser = (ChromiumWebBrowser)chromiumWebBrowser;

            WebBrowser.Invoke(new Action(() =>
            {
            }));
            var menu = new ContextMenu();

                //var menu = new ContextMenu
                //{
                //    IsOpen = true
                //};

                //RoutedEventHandler handler = null;

                //handler = (s, e) =>
                //{
                //    menu.Closed -= handler;

                //    //If the callback has been disposed then it's already been executed
                //    //so don't call Cancel
                //    if (!callback.IsDisposed)
                //    {
                //        callback.Cancel();
                //    }
                //};



                //menu.Closed += handler;

                var mi = new MenuItem();
                mi.Text = "最小化";
                mi.Click += Mi_Click;

                menu.MenuItems.Add(mi);
                //menu.Items.Add(new MenuItem
                //{
                //    Header = "关闭",
                //    Command = new CustomCommand(CloseWindow)
                //});
                WebBrowser.ContextMenu = menu;

           

            return true;
        }

        private void Mi_Click(object sender, EventArgs e)
        {
            "test".ToShow();
        }
    }
}

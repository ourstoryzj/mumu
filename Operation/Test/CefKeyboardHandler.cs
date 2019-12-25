using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CefSharp;

namespace Operation.Test
{
    public class CefKeyboardHandler 
    {

        /// <summary>
        /// 命名代理
        /// </summary>
        /// <param name="con"></param>
        /// <param name="text"></param>
        private delegate void PreKeyEventHandler(object sender, object webBrowser, int windowsKeyCode);
 

        public bool OnKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            return true;
        }

        public bool OnPreKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            throw new NotImplementedException();
        }
    }
}

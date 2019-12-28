using System;
using System.Security.Cryptography.X509Certificates;
using CefSharp;
using System.Collections.Generic;
using Operation.Test;

namespace Operation.Test
{
    public class MyRequestHandler : IRequestHandler
    {


        //public static readonly string VersionNumberString = String.Format("Chromium: {0}, CEF: {1}, CefSharp: {2}",   Cef.ChromiumVersion, Cef.CefVersion, Cef.CefSharpVersion);

        public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {

            //throw new NotImplementedException();
            return true;
        }

 

        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            //throw new NotImplementedException();
            //return null;
            var url = new Uri(request.Url);
            if (url.AbsoluteUri.Contains("http://test.test.com/somehead?"))
            {
                this.filter = new FilterManager();
                filter.NotifyData += filter_NotifyData;

                return filter;
            }

            return null;
        }
        void filter_NotifyData(byte[] data)
        {
            if (NotifyData != null)
            {
                NotifyData(data);
            }
        }





        public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
        {
            //throw new NotImplementedException();
            return true;
        }

        public  CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
        {
            //throw new NotImplementedException();
            Uri url;
            if (Uri.TryCreate(request.Url, UriKind.Absolute, out url) == false)
            {
                return CefReturnValue.Cancel;
            }
            var headers = request.Headers;
            headers["Upgrade-Insecure-Requests"] = "1"; //传递进去认证Token
            headers["User-Agent"] = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.169 Safari/537.36";
            headers["Accept-Encoding"] = "gzip, deflate, br";
            headers["Accept-Language"] = "zh-CN,zh;q=0.9";
            headers["anthor"] = "zj";
            request.Headers = headers;
            return CefReturnValue.Continue;

        }

        public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            //throw new NotImplementedException();
            return true;
        }

        public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            return true;
        }

        public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
        {
            
        }

        public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
        {
            //throw new NotImplementedException();
            return true;
        }

        public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
        {
            return true;
        }

        public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
        {
          
        }

        public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
        {
           
        }

        public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
           
        }

        public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
        {
            
        }


        private FilterManager filter = null;
        public event Action<byte[]> NotifyData;
        public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            try
            {
                var content_length = int.Parse(response.ResponseHeaders["Content-Length"]);
                if (this.filter != null)
                {
                    this.filter.SetContentLength(content_length);
                }
            }
            catch { }
            return false;
            //return true;
        }

        public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            return true;
        }
    }
}
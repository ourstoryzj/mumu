using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace words
{
    public class Net
    {

        [DllImport("wininet")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

        /**//// <summary>
        /// 检测本机是否联网
        /// </summary>
        /// <returns></returns>
        public static bool IsConnectedInternet()
        {
            int i = 0;
            if (InternetGetConnectedState(out i, 0))
            {
                //已联网
                return true;
            }
            else
            {
                //未联网
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Operation.CS
{
    public class WiFiHelper
    {
        #region 单例

        //private static WiFi instance = null;
        //private static object objLock = new object();

        //private WiFi()
        //{ }

        //public static WiFi Singlon()
        //{
        //    if (instance == null)
        //    { 
        //        lock(objLock)
        //        {
        //            if (instance == null)
        //            {
        //                instance = new WiFi();
        //            }
        //        }
        //    }
        //    return instance;
        //}

        #endregion

        public static string executeCmd(string command)
        {
            Process process = new Process
            {
                StartInfo = { FileName = " cmd.exe ", UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true, CreateNoWindow = true }
            };
            process.Start();
            process.StandardInput.WriteLine(command);
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            string str = process.StandardOutput.ReadToEnd();
            process.Close();
            return str;
        }

        /// <summary>
        /// 共享网络
        /// </summary>
        /// <param name="wifiName">WiFi名称</param>
        /// <param name="wifiPassword">WiFi密码(不少于8位)</param>
        /// <returns>"新建共享网络成功！"||"搭建失败，请重试！"</returns>
        public static string AllowWiFi(string wifiName, string wifiPassword)
        {
            string createWifiRet = "搭建失败，请重试！";
            try
            {
                string command = "netsh wlan set hostednetwork mode=allow ssid=" + wifiName.Trim() + " key=" + wifiPassword.Trim();
                string cmdExecRet = executeCmd(command);
                createWifiRet = cmdExecRet;
                if (((createWifiRet.IndexOf("承载网络模式已设置为允许") > -1) && (createWifiRet.IndexOf("已成功更改承载网络的 SSID。") > -1)) && (createWifiRet.IndexOf("已成功更改托管网络的用户密钥密码。") > -1))
                {
                    createWifiRet = "新建共享网络成功！";
                }
                return createWifiRet;
            }
            catch (Exception e)
            {
                return createWifiRet + "\n\r" + e.Message;
            }
        }

        /// <summary>
        /// 禁止共享网络
        /// </summary>
        /// <returns>disallowWifiRet = "禁止共享网络成功！"||"操作失败，请重试！"</returns>
        public static string DisallowWifi()
        {
            string disallowWifiRet = "操作失败，请重试！";
            try
            {
                string command = "netsh wlan set hostednetwork mode=disallow";
                if (executeCmd(command).IndexOf("承载网络模式已设置为禁止") > -1)
                {
                    disallowWifiRet = "禁止共享网络成功！";
                }
                return disallowWifiRet;
            }
            catch (Exception e)
            {
                return disallowWifiRet + "\n\r" + e.Message;
            }
        }

        /// <summary>
        /// 启动承载网络(WiFi)
        /// </summary>
        /// <returns>"已启动承载网络！"||"启动承载网络失败，请尝试新建网络共享！"</returns>
        public static string StartWiFi()
        {
            string startWifiRet = "启动承载网络失败，请尝试新建网络共享！";
            try
            {
                if (executeCmd("netsh wlan start hostednetwork").IndexOf("已启动承载网络") > -1)
                {
                    startWifiRet = "已启动承载网络！";
                }
                return startWifiRet;
            }
            catch (Exception e)
            {
                return startWifiRet + "\n\r" + e.Message;
            }
        }

        /// <summary>
        /// 停止承载网络(WiFi)
        /// </summary>
        /// <returns>"已停止承载网络！"||"停止承载网络失败！"</returns>
        public static string StopWiFi()
        {
            string stopWifiRet = "停止承载网络失败！";
            try
            {
                if (executeCmd("netsh wlan stop hostednetwork").IndexOf("已停止承载网络") > -1)
                {
                    stopWifiRet = "已停止承载网络！";
                }
                return stopWifiRet;
            }
            catch (Exception e)
            {
                return stopWifiRet + "\n\r" + e.Message;
            }
        }


        public static string CMD(string command)
        {
            Process process = new Process
            {
                StartInfo = { FileName = " cmd.exe ", UseShellExecute = false, RedirectStandardInput = true, RedirectStandardOutput = true, CreateNoWindow = true }
            };
            process.Start();
            process.StandardInput.WriteLine(command);
            process.StandardInput.WriteLine("exit");
            process.WaitForExit();
            string str = process.StandardOutput.ReadToEnd();
            process.Close();
            return str;
        }
    }
}
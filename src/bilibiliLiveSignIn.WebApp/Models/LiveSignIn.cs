using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;

namespace bilibiliLiveSignIn.WebApp.Models
{
    public class LiveSignIn
    {
        #region 读取cookie
        private static string ReadCookie()
        {
            string cookiePath = AppDomain.CurrentDomain.BaseDirectory + "/cookie.txt";
            string cookie = File.ReadAllText(cookiePath);
            return cookie;
        }
        #endregion

        #region 银币兑换成硬币
        public static string Silver2coin()
        {
            string url = "https://api.live.bilibili.com/pay/v1/Exchange/silver2coin";
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
            string[] headers = new string[] {
                "authority: live.bilibili.com"
            };
            string cookies = ReadCookie();
            string responseData = HttpAide.HttpGet(url: url, cookies: cookies, ua: userAgent, headers: headers);
            dynamic jsonObj = JsonAide.JsonStr2Obj(responseData);
            if (!JsonAide.IsPropertyExist(jsonObj, "msg"))
            {
                return null;
            }
            else
            {
                return jsonObj.msg.ToString();
            }
        }
        #endregion

        #region 签到
        public static string SignIn()
        {
            string url = "https://api.live.bilibili.com/sign/doSign";
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/68.0.3440.106 Safari/537.36";
            string[] headers = new string[] {
                "authority: live.bilibili.com"
            };
            string cookies = ReadCookie();
            string responseData = HttpAide.HttpGet(url: url, cookies: cookies, ua: userAgent, headers: headers);
            dynamic jsonObj = JsonAide.JsonStr2Obj(responseData);
            if (!JsonAide.IsPropertyExist(jsonObj, "msg"))
            {
                return null;
            }
            else
            {
                return jsonObj.msg.ToString();
            }
        }
        #endregion
    }
}
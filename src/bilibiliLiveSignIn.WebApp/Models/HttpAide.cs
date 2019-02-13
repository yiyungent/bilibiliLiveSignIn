using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net;
using System.Text;
using System.IO.Compression;
using System.IO;

namespace bilibiliLiveSignIn.WebApp.Models
{
    public class HttpAide
    {
        #region Http Get
        /// <summary>
        /// HTTP Get请求
        /// </summary>
        /// <param name="url">请求目标URL</param>
        /// <param name="isPost"></param>
        /// <param name="referer"></param>
        /// <param name="cookies"></param>
        /// <param name="ua"></param>
        /// <returns>返回请求回复字符串</returns>
        public static string HttpGet(string url, string referer = null, Dictionary<string, string> cookies = null, string ua = null, StringBuilder responseHeadersSb = null, string[] headers = null)
        {
            string rtResult = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Accept = "application/json";
                request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                request.KeepAlive = false;
                if (cookies != null && cookies.Count > 0)
                {
                    request.CookieContainer = new CookieContainer();
                    Uri target = new Uri(url);
                    foreach (string name in cookies.Keys)
                    {
                        request.CookieContainer.Add(new Cookie(name, cookies[name].Replace(",", "%2C").Replace(" ", "")) { Domain = target.Host });
                    }
                }
                if (!string.IsNullOrEmpty(referer))
                {
                    request.Referer = referer;
                }
                if (!string.IsNullOrEmpty(ua))
                {
                    request.UserAgent = ua;
                }
                else
                {
                    request.UserAgent = "Mozilla/5.0 (Linux; Android 4.4.2; H650 Build/KOT49H) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 Mobile Safari/537.36";
                }
                if (headers != null)
                {
                    foreach (string header in headers)
                    {
                        request.Headers.Add(header);
                    }
                }
                request.Timeout = 10000;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (responseHeadersSb != null)
                {
                    foreach (string name in response.Headers.AllKeys)
                    {
                        responseHeadersSb.AppendLine(name + ": " + response.Headers[name]);
                    }
                }
                Stream responseStream = response.GetResponseStream();
                //如果http头中接受gzip的话，这里就要判断是否为有压缩，有的话，直接解压缩即可 
                if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                }
                using (StreamReader sReader = new StreamReader(responseStream, System.Text.Encoding.UTF8))
                {
                    rtResult = sReader.ReadToEnd();
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rtResult;
        }

        public static string HttpGet(string url, string referer = null, string cookies = null, string ua = null, StringBuilder responseHeadersSb = null, string[] headers = null)
        {
            Dictionary<string, string> cookiesDic = CookiesStr2CookiesDic(cookies);
            return HttpGet(url: url, referer: referer, cookies: cookiesDic, ua: ua, responseHeadersSb: responseHeadersSb, headers: headers);
        }
        #endregion


        #region Http Post
        public static string HttpPost(string url, string postDataStr = "", string referer = null, Dictionary<string, string> cookies = null, string ua = null, StringBuilder responseHeadersSb = null, string[] headers = null)
        {
            string rtResult = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/html;charset=UTF-8";
                request.Accept = "application/json";
                request.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                request.KeepAlive = false;
                if (cookies != null && cookies.Count > 0)
                {
                    request.CookieContainer = new CookieContainer();
                    Uri target = new Uri(url);
                    foreach (string name in cookies.Keys)
                    {
                        request.CookieContainer.Add(new Cookie(name, cookies[name].Replace(",", "%2C").Replace(" ", "")) { Domain = target.Host });
                    }
                }
                if (!string.IsNullOrEmpty(referer))
                {
                    request.Referer = referer;
                }
                if (!string.IsNullOrEmpty(ua))
                {
                    request.UserAgent = ua;
                }
                else
                {
                    request.UserAgent = "Mozilla/5.0 (Linux; Android 4.4.2; H650 Build/KOT49H) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 Mobile Safari/537.36";
                }
                if (headers != null)
                {
                    foreach (string header in headers)
                    {
                        request.Headers.Add(header);
                    }
                }
                request.Timeout = 10000;
                byte[] postBytes = Encoding.UTF8.GetBytes(postDataStr);
                request.ContentLength = postBytes.Length;
                // 写 content-body 一定要在属性设置之后
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(postBytes, 0, postBytes.Length);
                requestStream.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (responseHeadersSb != null)
                {
                    foreach (string name in response.Headers.AllKeys)
                    {
                        responseHeadersSb.AppendLine(name + ": " + response.Headers[name]);
                    }
                }
                Stream responseStream = response.GetResponseStream();
                //如果http头中接受gzip的话，这里就要判断是否为有压缩，有的话，直接解压缩即可  
                if (response.Headers["Content-Encoding"] != null && response.Headers["Content-Encoding"].ToLower().Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                }
                using (StreamReader sReader = new StreamReader(responseStream, System.Text.Encoding.UTF8))
                {
                    rtResult = sReader.ReadToEnd();
                }
                responseStream.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return rtResult;
        }

        public static string HttpPost(string url, string postDataStr = "", string referer = null, string cookies = null, string ua = null, StringBuilder responseHeadersSb = null, string[] headers = null)
        {
            Dictionary<string, string> cookiesDic = CookiesStr2CookiesDic(cookies);
            return HttpPost(url: url, postDataStr: postDataStr, referer: referer, cookies: cookiesDic, ua: ua, responseHeadersSb: responseHeadersSb, headers: headers);
        }
        #endregion

        #region CookiesStr2CookiesDic
        private static Dictionary<string, string> CookiesStr2CookiesDic(string cookies)
        {
            Dictionary<string, string> cookiesDic = new Dictionary<string, string>();
            string[] cookieArr = cookies.Split(new string[] { ";", " " }, StringSplitOptions.RemoveEmptyEntries);
            string[] cookieTemp = new string[2];
            foreach (string cookie in cookieArr)
            {
                cookieTemp = cookie.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                cookiesDic.Add(cookieTemp[0], cookieTemp[1]);
            }

            return cookiesDic;
        }
        #endregion
    }
}
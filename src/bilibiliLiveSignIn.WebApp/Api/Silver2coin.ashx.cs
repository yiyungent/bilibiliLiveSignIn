using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using bilibiliLiveSignIn.WebApp.Models;

namespace bilibiliLiveSignIn.WebApp.Api
{
    /// <summary>
    /// Summary description for Silver2coin
    /// </summary>
    public class Silver2coin : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = LiveSignIn.AppSilver2coin();
            context.Response.Write(msg);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
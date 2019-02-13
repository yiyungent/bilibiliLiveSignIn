using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using bilibiliLiveSignIn.WebApp.Models;

namespace bilibiliLiveSignIn.WebApp.Api
{
    /// <summary>
    /// Summary description for SignIn
    /// </summary>
    public class SignIn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg = LiveSignIn.SignIn();
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
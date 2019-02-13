using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace bilibiliLiveSignIn.WebApp.Models
{
    public class JsonAide
    {
        public static dynamic JsonStr2Obj(string jsonStr)
        {
            return JsonConvert.DeserializeObject<dynamic>(jsonStr);
        }

        public static bool IsPropertyExist(dynamic data, string propertyname)
        {
            if (data is JObject)
            {
                return ((JObject)data).ContainsKey(propertyname);
            }
            return false;
        }
    }
}
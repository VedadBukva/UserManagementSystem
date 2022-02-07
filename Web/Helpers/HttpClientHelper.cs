using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Helpers
{
    public class HttpClientHelper
    {
        public HttpClientHelper()
        {
        }

        public static Method ReturnHttpClientMethod(string method)
        {
            return method switch
            {
                "POST" => Method.POST,
                "PATCH" => Method.PATCH,
                "PUT" => Method.PUT,
                "DELETE" => Method.DELETE,
                _ => Method.GET,
            };
        }
    }
}

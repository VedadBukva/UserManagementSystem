using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Interfaces
{
    public interface IHttpClientSenderService
    {
        dynamic Request<RESPONSE_TYPE>(string method, string query);
        dynamic RequestWithBody<RESPONSE_TYPE, BODY_TYPE>(string method, string query, BODY_TYPE body);
    }
}

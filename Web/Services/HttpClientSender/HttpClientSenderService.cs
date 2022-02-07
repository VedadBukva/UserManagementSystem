using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Interfaces;
using Web.Interfaces.HttpClientSender;

namespace Web.Services.HttpClientSender
{
    public class HttpClientSenderService : IHttpClientSenderService
    {
        private readonly ILogger<HttpClientSenderService> _logger;
        public string ApiUri { get; set; }
        private IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public HttpClientSenderService(ILogger<HttpClientSenderService> logger, IConfiguration configuration, IWebHostEnvironment environment)
        {
            _logger = logger;
            Configuration = configuration;
            Environment = environment;
            ApiUri = Configuration.GetSection("ApiUri").Value;
        }

        public dynamic Request<RESPONSE_TYPE>(string method, string query)
        {
            var client = new RestClient($"{ApiUri}{query}")
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };

            var request = new RestRequest(HttpClientHelper.ReturnHttpClientMethod(method));
            request.AddHeader("Content-Type", "application/json");

            var requestUri = client.BuildUri(request);

            var url = requestUri.ToString();

            IRestResponse response = client.Execute(request);
            var content = response.Content; 

            if (response.StatusCode == HttpStatusCode.OK)
            {
                RESPONSE_TYPE data = JsonConvert.DeserializeObject<RESPONSE_TYPE>(content);
                _logger.LogTrace($"{method} - {ApiUri}{query} HttpStatusCode.OK");
                return new { Status = "SUCCESS", Data = data, HttpStatus = "OK" };
            }
            else if (response.StatusCode == HttpStatusCode.Created)
            {
                _logger.LogTrace($"{method} - {ApiUri}{query} HttpStatusCode.Created");
                return new { Status = "SUCCESS", Data = "", HttpStatus = "Created" };
            }
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                _logger.LogTrace($"{method} - {ApiUri}{query} HttpStatusCode.NoContent");
                return new { Status = "SUCCESS", Data = "", HttpStatus = "NoContent" };
            }
            else
            {
                _logger.LogTrace($"{method} - {ApiUri}{query} HttpStatusCode.ERROR");
                return new { Status = "FAILURE", Data = content, HttpStatus = "Error" };
            }
        }

        public dynamic RequestWithBody<RESPONSE_TYPE, BODY_TYPE>(string method, string query, BODY_TYPE body)
        {
            var client = new RestClient($"{ApiUri}{query}")
            {
                RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            };

            var request = new RestRequest(HttpClientHelper.ReturnHttpClientMethod(method));
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(JsonConvert.SerializeObject(body));

            var requestUri = client.BuildUri(request);

            var url = requestUri.ToString();

            IRestResponse response = client.Execute(request);
            var content = response.Content; 

            if (response.StatusCode == HttpStatusCode.OK)
            {
                RESPONSE_TYPE data = JsonConvert.DeserializeObject<RESPONSE_TYPE>(content);
                _logger.LogTrace($"{method} - {ApiUri}{query} HttpStatusCode.OK");
                return new { Status = "SUCCESS", Data = data, HttpStatus = "OK" };
            }
            else if (response.StatusCode == HttpStatusCode.Created)
            {
                _logger.LogTrace($"{method} - {ApiUri}{query} HttpStatusCode.Created");
                return new { Status = "SUCCESS", Data = "", HttpStatus = "Created" };
            }
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                _logger.LogTrace($"{method} - {ApiUri}{query} HttpStatusCode.NoContent");
                return new { Status = "SUCCESS", Data = "", HttpStatus = "NoContent" };
            }
            else
            {
                _logger.LogTrace($"{method} - {ApiUri}{query} HttpStatusCode.ERROR");
                return new { Status = "FAILURE", Data = content, HttpStatus = "Error" };
            }
        }

    }
}

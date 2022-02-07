using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Interfaces;
using Web.Interfaces.HttpClientSender;
using Web.Interfaces.Permission;
using Web.Models;

namespace Web.Services.Permission
{
    public class PermissionViewModelService : IPermissionViewModelService
    {
        private readonly IHttpClientSenderService _httpClientService;
        public PermissionViewModelService(IHttpClientSenderService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public List<PermissionModel> Get()
        {
            var response = _httpClientService.Request<List<PermissionModel>>("GET", $"/Permission");
            if (response.Status != "FAILURE" && response.HttpStatus != "Error" && response.HttpStatus != "NoContent")
            {
                return response.Data;
            }
            return null;
        }
    }
}

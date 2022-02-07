using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces.HttpClientSender;
using Web.Interfaces.UserPermission;
using Web.Models;

namespace Web.Services.UserPermission
{
    public class UserPermissionViewModelService : IUserPermissionViewModelService
    {
        private readonly IHttpClientSenderService _httpClientService;
        public UserPermissionViewModelService(IHttpClientSenderService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        public List<PermissionModel> GetByUserId(Guid guid)
        {
            var response = _httpClientService.Request<PermissionModel>("GET", $"/UserPermission/UserId/{guid}");
            if (response.Status != "FAILURE" && response.HttpStatus != "Error" && response.HttpStatus != "NoContent")
            {
                return response.Data;
            }
            return null;
        }

        public List<PermissionModel> GetByPermissionId(Guid guid)
        {
            var response = _httpClientService.Request<PermissionModel> ("GET", $"/UserPermission/PermissionId/{guid}");
            if (response.Status != "FAILURE" && response.HttpStatus != "Error" && response.HttpStatus != "NoContent")
            {
                return response.Data;
            }
            return null;
        }
        public UserPermissionModel Add(UserPermissionModel model)
        {
            var response = _httpClientService.RequestWithBody<UserModel, UserPermissionModel>("POST", $"/UserPermission", model);
            if (response.Status != "FAILURE" && response.HttpStatus != "Error" && response.HttpStatus != "NoContent")
            {
                return response.Data;
            }
            return null;
        }

        public bool Delete(UserPermissionModel model)
        {
            var response = _httpClientService.RequestWithBody<bool, UserPermissionModel>("DELETE", $"/UserPermission", model);
            if (response.Status != "FAILURE" && response.HttpStatus != "Error" && response.HttpStatus != "NoContent")
            {
                return true;
            }
            return false;
        }
    }
}

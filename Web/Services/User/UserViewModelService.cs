using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Interfaces;
using Web.Interfaces.HttpClientSender;
using Web.Interfaces.User;
using Web.Models;

namespace Web.Services.User
{
    public class UserViewModelService : IUserViewModelService
    {
        private readonly IHttpClientSenderService _httpClientService;
        public UserViewModelService(IHttpClientSenderService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public PaginationDto<UserModel> Get(UserModel userModel, PaginationQueryDto paginationQueryDto)
        {
            var endpoint = "/User?";
            if(!string.IsNullOrEmpty(userModel.FirstName)) endpoint += "FirstName=" + userModel.FirstName + "&";
            if (!string.IsNullOrEmpty(userModel.LastName)) endpoint += "LastName=" + userModel.LastName + "&";
            if (!string.IsNullOrEmpty(userModel.Password)) endpoint += "Password=" + userModel.Password + "&";
            if (!string.IsNullOrEmpty(userModel.Email)) endpoint += "Email=" + userModel.Email + "&";
            if (!string.IsNullOrEmpty(userModel.Status)) endpoint += "Status=" + userModel.Status + "&";

            endpoint += "SortBy=" + paginationQueryDto.SortBy + "&";
            endpoint += "OrderBy=" + paginationQueryDto.OrderBy + "&";
            endpoint += "Page=" + paginationQueryDto.Page + "&";
            endpoint += "PageSize=" + paginationQueryDto.PageSize;

            var response = _httpClientService.Request<PaginationDto<UserModel>>("GET", endpoint);
            if (response.Status != "FAILURE" && response.HttpStatus != "Error" && response.HttpStatus != "NoContent")
            {
                return response.Data;
            }
            return null;
        }

        public UserModel GetUser(Guid guid)
        {
            var response = _httpClientService.Request<UserModel>("GET", $"/User/{guid}");
            if (response.Status != "FAILURE" && response.HttpStatus != "Error" && response.HttpStatus != "NoContent")
            {
                return response.Data;
            }
            return null;
        }

        public async Task<UserModel> Add(UserModel userModel)
        {
            var response = await _httpClientService.RequestWithBody<UserModel, UserModel>("POST", $"/User", userModel);
            if (response.Status != "FAILURE" && response.HttpStatus != "Error" && response.HttpStatus != "NoContent")
            {
                return response.Data;
            }
            return null;
        }

        public bool Delete(UserModel userModel)
        {
            var response = _httpClientService.RequestWithBody<bool, UserModel>("DELETE", $"/User", userModel);
            if (response.Status != "FAILURE" && response.HttpStatus != "Error" && response.HttpStatus != "NoContent")
            {
                return true;
            }
            return false;
        }
        public bool Update(UserModel userModel)
        {
            var response = _httpClientService.RequestWithBody<bool, UserModel>("PATCH", $"/User", userModel);
            if (response.Status != "FAILURE" && response.HttpStatus != "Error" && response.HttpStatus != "NoContent")
            {
                return true;
            }
            return false;
        }
    }
}

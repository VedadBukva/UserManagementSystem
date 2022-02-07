using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Models;

namespace Web.Interfaces.User
{
    public interface IUserViewModelService
    {
        PaginationDto<UserModel> Get(UserModel userModel, PaginationQueryDto paginationQueryDto);
        UserModel GetUser(Guid guid);
        Task<UserModel> Add(UserModel userModel);
        bool Delete(UserModel userModel);
        bool Update(UserModel userModel);
    }
}

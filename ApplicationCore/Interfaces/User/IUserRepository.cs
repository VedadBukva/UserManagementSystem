using ApplicationCore.Helpers;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository
    {
        Task<PaginationDto<UserModel>> Get(UserModel userModel, PaginationQueryDto paginationQueryDto);
        Task<UserModel> GetUser(Guid guid);
        Task<UserModel> Add(UserModel userModel);
        Task<bool> Delete(UserModel userModel);
        Task<bool> Update(UserModel userModel);

    }
}

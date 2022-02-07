using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<PaginationDto<UserModel>> Get(UserModel userModel, PaginationQueryDto paginationQueryDto)
        {
            return _userRepository.Get(userModel, paginationQueryDto);
        }

        public Task<UserModel> GetUser(Guid guid)
        {
            return _userRepository.GetUser(guid);
        }

        public Task<UserModel> Add(UserModel userModel)
        {
            return _userRepository.Add(userModel);
        }

        public Task<bool> Delete(UserModel userModel)
        {
            return _userRepository.Delete(userModel);
        }

        public Task<bool> Update(UserModel userModel)
        {
            return _userRepository.Update(userModel);
        }

    }
}

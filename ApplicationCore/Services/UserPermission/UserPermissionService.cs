using ApplicationCore.Interfaces.UserPermission;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services.UserPermission
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly IUserPermissionRepository _userPermissionRepository;
        public UserPermissionService(IUserPermissionRepository userPermissionRepository)
        {
            _userPermissionRepository = userPermissionRepository;
        }

        public Task<IEnumerable<PermissionModel>> GetByUserId(Guid guid)
        {
            return _userPermissionRepository.GetByUserId(guid);
        }
        public Task<IEnumerable<PermissionModel>> GetByPermissionId(Guid guid)
        {
            return _userPermissionRepository.GetByPermissionId(guid);
        }
        public Task<UserPermissionModel> Add(UserPermissionModel model)
        {
            return _userPermissionRepository.Add(model);
        }

        public Task<bool> Delete(UserPermissionModel model)
        {
            return _userPermissionRepository.Delete(model);
        }
    }
}

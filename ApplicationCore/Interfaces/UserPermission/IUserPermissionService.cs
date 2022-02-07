using ApplicationCore.Helpers;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.UserPermission
{
    public interface IUserPermissionService
    {
        Task<IEnumerable<PermissionModel>> GetByUserId(Guid guid);
        Task<IEnumerable<PermissionModel>> GetByPermissionId(Guid guid);
        Task<UserPermissionModel> Add(UserPermissionModel model);
        Task<bool> Delete(UserPermissionModel model);

    }
}

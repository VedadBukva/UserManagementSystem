using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Interfaces.UserPermission
{
    public interface IUserPermissionViewModelService
    {
        List<PermissionModel> GetByUserId(Guid guid);
        List<PermissionModel> GetByPermissionId(Guid guid);
        UserPermissionModel Add(UserPermissionModel model);
        bool Delete(UserPermissionModel model);
    }
}

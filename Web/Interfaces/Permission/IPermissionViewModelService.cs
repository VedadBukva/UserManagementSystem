using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Models;

namespace Web.Interfaces.Permission
{
    public interface IPermissionViewModelService
    {
        List<PermissionModel> Get();
    }
}

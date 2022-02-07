using ApplicationCore.Helpers;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.Permission
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<PermissionModel>> Get();

    }
}

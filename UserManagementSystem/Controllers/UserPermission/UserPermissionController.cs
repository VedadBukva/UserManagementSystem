using ApplicationCore.Interfaces.UserPermission;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserPermissionController : Controller
    {
        private readonly ILogger<UserPermissionController> _logger;
        private readonly IUserPermissionService _userPermissionService;

        public UserPermissionController(ILogger<UserPermissionController> logger, IUserPermissionService userPermissionService)
        {
            _logger = logger;
            _userPermissionService = userPermissionService;
        }

        [HttpGet("UserId/{guid}")]
        public async Task<IEnumerable<PermissionModel>> GetByUserId(Guid guid)
        {
            _logger.LogInformation("api/UserPermission - GetByUserId", new EventId());
            return await _userPermissionService.GetByUserId(guid);
        }

        [HttpGet("PermissionId/{guid}")]
        public async Task<IEnumerable<PermissionModel>> GetByPermissionId(Guid guid)
        {
            _logger.LogInformation("api/UserPermission - GetByUserId", new EventId());
            return await _userPermissionService.GetByPermissionId(guid);
        }

        [HttpPost]
        public async Task<UserPermissionModel> Add(UserPermissionModel model)
        {
            _logger.LogInformation("api/UserPermission - Add", new EventId());
            return await _userPermissionService.Add(model);
        }

        [HttpDelete]
        public async Task<bool> Delete(UserPermissionModel model)
        {
            _logger.LogInformation("api/UserPermission - Delete", new EventId());
            return await _userPermissionService.Delete(model);
        }

    }
}

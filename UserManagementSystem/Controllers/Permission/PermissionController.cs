using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Permission;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : Controller
    {
        private readonly ILogger<PermissionController> _logger;
        private readonly IPermissionService _permissionService;

        public PermissionController(ILogger<PermissionController> logger, IPermissionService permissionService)
        {
            _logger = logger;
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IEnumerable<PermissionModel>> Get()
        {
            _logger.LogInformation("api/Permission - Get", new EventId());
            return await _permissionService.Get();
        }

    }
}

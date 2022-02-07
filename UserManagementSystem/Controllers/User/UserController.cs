using ApplicationCore.Helpers;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<PaginationDto<UserModel>> Get([FromQuery] UserModel userModel, [FromQuery] PaginationQueryDto paginationQueryDto)
        {
            _logger.LogInformation("api/User - Get", new EventId());
            var users = await _userService.Get(userModel, paginationQueryDto);
            return users;
        }

        [HttpGet("{guid}")]
        public async Task<UserModel> GetUser(Guid guid)
        {
            _logger.LogInformation("api/User - GetUser", new EventId());
            var user = await _userService.GetUser(guid);
            return user;
        }

        [HttpPost]
        public async Task<UserModel> Add([FromBody] UserModel userModel)
        {
            _logger.LogInformation("api/User - Add", new EventId());
            return await _userService.Add(userModel);
        }

        [HttpPatch]
        public Task<bool> Update([FromBody] UserModel userModel)
        {
            _logger.LogInformation("api/User - Update", new EventId());
            return _userService.Update(userModel);
        }

        [HttpDelete]
        public Task<bool> Delete([FromBody] UserModel userModel)
        {
            _logger.LogInformation("api/User - Delete", new EventId());
            return _userService.Delete(userModel);
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Web.Interfaces.Permission;
using Web.Interfaces.User;
using Web.Interfaces.UserPermission;
using Web.Models;

namespace Web.Pages.Permission
{
    public class AssignPermissionModel : PageModel
    {
        private readonly ILogger<AssignPermissionModel> _logger;
        private readonly IPermissionViewModelService _permissionViewModelService;
        private readonly IUserViewModelService _userViewModelService;
        private readonly IUserPermissionViewModelService _userPermissionViewModelService;


        [BindProperty]
        public UserModel UserModel { get; set; } = new UserModel();

        [BindProperty(SupportsGet = true)]
        public List<PermissionModel> PermissionList { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<Guid> PermissionsId { get; set; }

        public AssignPermissionModel(ILogger<AssignPermissionModel> logger, IPermissionViewModelService permissionViewModelService, IUserViewModelService userViewModelService, IUserPermissionViewModelService userPermissionViewModelService)
        {
            _logger = logger;
            _permissionViewModelService = permissionViewModelService;
            _userViewModelService = userViewModelService;
            _userPermissionViewModelService = userPermissionViewModelService;
        }

        public IActionResult OnGet(Guid guid)
        {
            UserModel = _userViewModelService.GetUser(guid);
            PermissionList = _permissionViewModelService.Get();
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Web.Helpers;
using Web.Interfaces;
using Web.Models;

namespace Web.Pages
{
    public class CreateUserModel : PageModel
    {
        private readonly ILogger<CreateUserModel> _logger;
        private readonly IUserViewModelService _userViewModelService;

        [BindProperty]
        public UserModel UserModel { get; set; } = new UserModel();

        [BindProperty]
        public StatusEnum StatusEnum { get; set; }

        public CreateUserModel(ILogger<CreateUserModel> logger, IUserViewModelService userViewModelService)
        {
            _logger = logger;
            _userViewModelService = userViewModelService;
        }

        
        public void OnGet()
        {
        }

        public IActionResult OnPostCreate(UserModel userModel)
        {
            var addUser = _userViewModelService.Add(userModel);
            if (addUser == null) {
                return Page();
            }
            return RedirectToPage("UserList");
        }
    }
}

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Web.Interfaces.User;
using Web.Models;

namespace Web.Pages
{
    public class EditUserModel : PageModel
    {
        private readonly ILogger<EditUserModel> _logger;
        private readonly IUserViewModelService _userViewModelService;

        [BindProperty]
        public UserModel UserModel { get; set; } = new UserModel();

        public EditUserModel(ILogger<EditUserModel> logger, IUserViewModelService userViewModelService)
        {
            _logger = logger;
            _userViewModelService = userViewModelService;
        }

        
        public IActionResult OnGet(Guid guid)
        {
            UserModel = _userViewModelService.GetUser(guid);
            return Page();
        }

        public IActionResult OnPost(UserModel userModel)
        {
            var addUser = _userViewModelService.Update(userModel);
            if (addUser) {
                return RedirectToPage("UserList");
            }
            return Page();
        }
    }
}

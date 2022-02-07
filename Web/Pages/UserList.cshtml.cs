using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Interfaces;
using Web.Models;
using Web.ViewModels;

namespace Web.Pages
{
    public class UserListModel : PageModel
    {
        private readonly ILogger<UserListModel> _logger;
        private readonly IUserViewModelService _userViewModelService;

        [BindProperty]
        public List<UserModel> UserList { get; set; }

        [BindProperty]
        public PaginationDto<UserModel> PaginationDto { get; set; } = new PaginationDto<UserModel>();

        [BindProperty]
        public PaginationQueryDto PaginationQueryDto { get; set; } = new PaginationQueryDto();

        [BindProperty]
        public UserModel UserModel { get; set; } = new UserModel();

        [BindProperty]
        public UserListViewModel UserListViewModel { get; set; } = new UserListViewModel();

        public UserListModel(ILogger<UserListModel> logger, IUserViewModelService userViewModelService)
        {
            _logger = logger;
            _userViewModelService = userViewModelService;
        }

        public IActionResult OnGet()
        {
            PaginationDto =  _userViewModelService.Get(UserModel, PaginationQueryDto);
            UserListViewModel = new UserListViewModel
            {
                PaginationDto = PaginationDto,
                PaginationQueryDto = new PaginationQueryDto()
            };
            return Page();
        }

        public IActionResult OnPostSearch(UserModel userModel, PaginationQueryDto paginationQueryDto)
        {
            UserModel = userModel;
            PaginationQueryDto = paginationQueryDto;
            PaginationDto = _userViewModelService.Get(userModel, paginationQueryDto);
            UserListViewModel.PaginationDto = PaginationDto;
            UserListViewModel.PaginationQueryDto = paginationQueryDto;
            return Partial("_Table", UserListViewModel);
        }

        public async Task<IActionResult> OnDelete(Guid guid, UserModel userModel, PaginationQueryDto paginationQueryDto)
        {
            var user = _userViewModelService.GetUser(guid);
            try
            {
                if (user != null)
                {
                    var userDeleted = _userViewModelService.Delete(user);
                    if (userDeleted)
                    {
                        PaginationDto = _userViewModelService.Get(userModel, paginationQueryDto);
                        UserListViewModel.PaginationDto = PaginationDto;
                        UserListViewModel.PaginationQueryDto = paginationQueryDto;
                        UserListViewModel.StatusMessage = "success";
                        return Partial("_Table", UserListViewModel);
                    }
                }
                return new JsonResult(new UserListViewModel { StatusMessage = "error" });
            }

            catch (Exception ex)
            {
                _logger.LogError("UserList - OnDelete", ex, new EventId());
                return new JsonResult(new UserListViewModel { StatusMessage = "error" });
            }
        }

    }
}

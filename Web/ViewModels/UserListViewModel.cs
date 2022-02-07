using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Models;

namespace Web.ViewModels
{
    public class UserListViewModel
    {
        public PaginationDto<UserModel> PaginationDto { get; set; } = new PaginationDto<UserModel>();
        public PaginationQueryDto PaginationQueryDto { get; set; } = new PaginationQueryDto();
        public string StatusMessage { get; set; }
    }
}

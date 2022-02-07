using System;
using System.Collections.Generic;

namespace Web.Models
{
    public partial class UserPermissionModel
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ApplicationCore.Models
{
    public partial class PermissionModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}

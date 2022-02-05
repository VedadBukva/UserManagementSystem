using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class Permission
    {
        public Permission()
        {
            UserPermission = new HashSet<UserPermission>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserPermission> UserPermission { get; set; }
    }
}

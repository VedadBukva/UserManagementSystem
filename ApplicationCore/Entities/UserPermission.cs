using System;

namespace ApplicationCore.Entities
{
    public partial class UserPermission
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid PermissionId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual User User { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

namespace ApplicationCore.Entities
{
    public partial class User
    {
        public User()
        {
            UserPermission = new HashSet<UserPermission>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<UserPermission> UserPermission { get; set; }
    }
}

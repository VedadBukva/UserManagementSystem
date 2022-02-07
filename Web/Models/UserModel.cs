using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public partial class UserModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public string Username { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Status { get; set; } = "";
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

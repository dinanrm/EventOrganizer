using System;
using System.Collections.Generic;

namespace EventOrganizer.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public int? RoleId { get; set; }
        public int? OrganizerId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Organizer Organizer { get; set; }
        public virtual Role Role { get; set; }
    }
}

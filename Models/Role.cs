using System;
using System.Collections.Generic;

namespace EventOrganizer.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();

            Id = Guid.NewGuid();
            IsActive = true;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}

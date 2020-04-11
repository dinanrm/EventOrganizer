using System;
using System.Collections.Generic;

namespace EventOrganizer.Models
{
    public partial class Organizer
    {
        public Organizer()
        {
            Event = new HashSet<Event>();
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageLocation { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace EventOrganizer.Models
{
    public partial class Event
    {
        public Event()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Guid Id { get; set; }
        public Guid? OrganizerId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime? HeldDate { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public virtual Organizer Organizer { get; set; }
    }
}

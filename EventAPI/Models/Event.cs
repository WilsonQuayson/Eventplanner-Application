﻿using EventAPI.Authentication;

namespace EventAPI.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }

        // Foreign key for AppUser
        public required string UserId { get; set; }
        public AppUser? User { get; set; } // Navigation property
    }

}

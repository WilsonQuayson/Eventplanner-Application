namespace EventAPI.Models
{
    public class EventDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public string UserId { get; set; } = string.Empty;

        // Add user object to Event
        public UserDTO? User { get; set; } // this includes the user object
    }
}

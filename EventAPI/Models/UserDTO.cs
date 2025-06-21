namespace EventAPI.Models
{
    public class UserDTO
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; // Include other properties as needed

        // Add event object to user
        public List<EventDTO> Events { get; set; } = new();
    }
}

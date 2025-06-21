using EventAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace EventAPI.Authentication
{
    public class AppUser : IdentityUser
    {
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }

}

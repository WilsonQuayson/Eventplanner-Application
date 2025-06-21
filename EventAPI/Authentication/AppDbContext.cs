using EventAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventAPI.Authentication
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Event> Events => Set<Event>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-many relationship
            modelBuilder.Entity<Event>()
                .HasOne(e => e.User) // Each Event has one AppUser
                .WithMany(user => user.Events) // Each AppUser can have many Events
                .HasForeignKey(e => e.UserId) // Foreign key in Event
                .OnDelete(DeleteBehavior.Cascade);
            /*
            // Seed data (optional)
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Seed Event",
                    Description = "Description for a seeded event",
                    StartTime = new DateTime(2025, 1, 1),
                    UserId = "some-user-id" // Replace with a valid AppUser ID
                }
            );
            */
        }
    }
}

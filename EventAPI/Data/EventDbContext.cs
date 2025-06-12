using EventAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventAPI.Data
{
    public class EventDbContext(DbContextOptions<EventDbContext> options) : DbContext(options)
    {
        public DbSet<Event> Events => Set<Event>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = Guid.NewGuid(),
                    Title = "Seed Event",
                    Description = "Description for a seeded event",
                    StartTime = new DateTime(2025, 1, 1)

                }
            );
        }
    }
}

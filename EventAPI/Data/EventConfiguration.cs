using EventAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventAPI.Data
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            // Primary key
            builder.HasKey(e => e.Id);

            // Title is required, with a max length
            builder.Property(e => e.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            // Description is optional (already nullable), set max length
            builder.Property(e => e.Description)
                   .HasMaxLength(1000);

            // StartTime is required and stored as just date+time (datetime2 default)
            builder.Property(e => e.StartTime)
                   .IsRequired()
                   .HasColumnType("date");
        }
    }
}
